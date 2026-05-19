/*
 * setup.c
 *
 *  AibbyScope
 *  Created on: 2026/02/12
 *      Author: cocot
 * Description: セットアップルーチン
 */

#include "AibbyScope.h"
#include "driver.h"
#include "global.h"

//------------------------------------------------------------------------------
void setupWdt(void) {
  wdt_init(WDT_2S);
  wdt_clear();
}

//------------------------------------------------------------------------------
void setupClock(void) {
  // XT32K有効化
  clk_setLsclkCircuit(CLK_LOSCMD_XT32K | CLK_LMOD_LOWPOWER);
  clk_setLsclk(CLK_XTM_CRYSTAL);

  // SYSC = OSCLK/1
  clk_setHsclk(CLK_SYSC_OSCLK | CLK_OUTC_OSCLK_DIV8, CLK_XSPEN_DIS, CLK_HXSPEN_DIS);

  // PLL有効化
  clk_enaPLLHsclk();

  while(clk_checkPllStable() == 0) {
      wdt_clear();
  }

  // 48.00512MHz切り替え
  clk_setSysclk(CLK_SYSCLK_HSCLK);

  // ペリフェラルクロック供給・リセット解除
  set_bit(LSICNT->CLKCON,   PERI_TM0 | PERI_TM1 | PERI_SAD0 | PERI_SIOF0 | PERI_DMAC | PERI_AI | PERI_UAF0);
  clear_bit(LSICNT->RSTCON, PERI_TM0 | PERI_TM1 | PERI_SAD0 | PERI_SIOF0 | PERI_DMAC | PERI_AI | PERI_UAF0);
}

//------------------------------------------------------------------------------
void setupGpio(void) {
  PORT5->P5MOD0 = 0x00000000U;    // P52 ADCIN(A8)

  DACPORT       = 0x00000000U;    // P4x DAC
  PORT4->P4MOD0 = 0x02020202U;
  PORT4->P4MOD1 = 0x02020202U;

  PORT8->P8MOD1 = 0x00002225U;    // P85 UART3-TX P84 UART3-RX 内部プルアップ付き

  VSYNCPORT     = 0x00000000U;
  PORT3->P3MOD1 = 0x00021111U;    // P36 VSYNC P35 SS# P34 SDI
  PORT3->P3MOD0 = 0x12110000U;    // P33 SDO P32 SCK
  
  LEDPORT       = 0x00000000U;    // P72 LED
  PORT7->P7MOD0 = 0x00020000U;
}

//------------------------------------------------------------------------------
void setupUartf(void) {
  irq_uaf0_dis();

  uartf0_init(UARTF_LG_8BIT | UARTF_STP_1BIT | UARTF_PT_NON | UARTF_BC_DIS
             | UARTF_DLAB_RBR_THR | UARTF_FEN_ENA | UARTF_RFR_KEEP
             | UARTF_TFR_KEEP | UARTF_FTL_2BYTE, (UARTF_RMV_ENA | 0x0019U), 0x0019U);

  irq_uaf0_clearIRQ();
  irq_uaf0_ena();
}

//------------------------------------------------------------------------------
void setupAdc(void) {
  irq_sad0_dis();
  saAdc0_stop();

  initAdc_t  initAdc;
    // SADMOD
  initAdc.clock              = SAADC_SACK_OSCLK_DIV3;   // 3.3V駆動なので16MHzで動作させる
  initAdc.discharge          = SAADC_SAINIT_DISCHARGE;
  initAdc.ampStabilityTime   = 0x0AU;   // SAINITT
  initAdc.holdTime           = 0x07U;   // SASHT
  initAdc.channelSync        = SAADC_SYNC_NORMAL;
  initAdc.mode               = SAADC_SALP_CONTINUOUS;
    // SADSTM
  initAdc.interval           = (OSCLK / ((uint16_t)cfg.samplingRate * 3U) - initAdc.ampStabilityTime - initAdc.holdTime - 15U); // さらにSAINITTとSASHT+1を引いてタイミングを合わせる-15は実機調整値
    // SADIMOD
  initAdc.interruptMode      = SAADC_SADIMD0_ALL_CH;
  initAdc.interruptLimitMode = SAADC_SADIMD1_LIMIT_MATCH;
    // SADLMOD
  initAdc.limitInterrupt     = SAADC_SALMD_INSIDE_LIMIT;
  initAdc.limitMode          = SAADC_SALEN_DISABLE;
  saAdc0_init(&initAdc);

  enableAdcChannel_t enableAdcChannel;
    // SADEN
  enableAdcChannel.ch0  = SAADC_OFF;  // P32
  enableAdcChannel.ch1  = SAADC_OFF;  // P33
  enableAdcChannel.ch2  = SAADC_OFF;  // P34
  enableAdcChannel.ch3  = SAADC_OFF;  // P35
  enableAdcChannel.ch4  = SAADC_OFF;  // P36
  enableAdcChannel.ch5  = SAADC_OFF;  // P37
  enableAdcChannel.ch6  = SAADC_OFF;  // P50
  enableAdcChannel.ch7  = SAADC_OFF;  // P51
  enableAdcChannel.ch8  = SAADC_RUN;  // P52 ■
  enableAdcChannel.ch9  = SAADC_OFF;  // P55
  enableAdcChannel.ch10 = SAADC_OFF;  // P56
  enableAdcChannel.ch11 = SAADC_OFF;  // P57
  saAdc0_setEnableChannel(&enableAdcChannel);

  irq_sad0_setLevel(1);
  irq_sad0_clearIRQ();
  irq_sad0_ena();
}

//------------------------------------------------------------------------------
void setupDmac(void) {
  irq_dmac0_dis();  // 同期転送するので割り込みは使わない
  irq_dmac1_dis();

  dmac_setChFix();
  dmac1_init(DMAC_TMOD_ARQ_EXT | DMAC_TMOD_SDP_INC | DMAC_TMOD_DDP_FIX | DMAC_TMOD_TSIZ_BYTE
           | DMAC_TMOD_BRQ_CYCLE | DMAC_TMOD_IMK_IMASK, DMAC_REQ_SSIOF0_TX , (void*)0 ); // SPI用DMA
}

//------------------------------------------------------------------------------
void setupTimer(void) {
  irq_tm0_dis();
  irq_tm1_dis();
  timer0_stop();
  timer1_stop();

  timer0_init(TM_CS_OSCLK | TM_DIV64 | TM_MODE_16BIT | TM_OST_RELOAD);
  timer1_init(TM_CS_OSCLK | TM_DIV1  | TM_MODE_16BIT | TM_OST_RELOAD);
  timer0_setCnt(cfg.sweepTimer - 1);
  timer1_setCnt(cfg.dotTimer);

  irq_tm0_setLevel(2);
  irq_tm1_setLevel(0);
  irq_tm0_clearIRQ();
  irq_tm1_clearIRQ();
  irq_tm0_ena();
  irq_tm1_ena();
}

//------------------------------------------------------------------------------
void setupSsiof(void) {
  irq_siof0_dis();
  ssiof0_init(SSIOF_MST_SLAVE | SSIOF_LG_8BIT | SSIOF_MDF_DIS | SSIOF_DIR_MSB
            | SSIOF_CPHA_1SM_2SH | SSIOF_CPOL_LOW | SSIOF_SSZ_HIZ | SSIOF_SOZ_HIZ
            | SSIOF_MOZ_HIZ, SSIOF_INT_WR_THRESH_2 );
}

//------------------------------------------------------------------------------
void initConfig(void) {
  cfg.samplingRate  = DEF_RATE;
  cfg.samples       = DEF_SAMPLES;
  cfg.qFormat       = DEF_QFORMAT;
  cfg.fftWindow     = DEF_WINDOW;
  cfg.sweepTimer    = SWEEPTIMER;
  cfg.dotTimer      = DOTTIMER;
  cfg.rawPlot       = DEF_PLOT;

  run = true;
  quiet = false;
}

//------------------------------------------------------------------------------
void clearBuffer(void) {  // 波形バッファをゼロクリアする
  uint32_t val = 0;

  if(cfg.runMode == WAVE) {
    val = 0x80808080;
  }
  for(int i = 0; i < 512; i++) {
    wave.u32[i] = val;
  }
}

//------------------------------------------------------------------------------
void setup(void) {
  __disable_irq();

  setupWdt();
  setupClock();
  setupGpio();
  setupUartf();

  cfg.runMode = DEF_MODE;
  initConfig();
  clearBuffer();
  setupAdc();
  setupDmac();
  setupTimer();
  setupSsiof();

  __enable_irq();
}
