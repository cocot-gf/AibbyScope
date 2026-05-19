/*
 * irq_Timer.c
 *
 *  AibbyScope
 *  Created on: 2026/02/12
 *      Author: cocot
 * Description: TM0スイープタイマー割り込み  優先度2
 *            : TM1ドットクロックタイマー割り込みで自律的に波形を出力する  優先度0(最高)
 *            : DACPORT=255, dotCount=0でタイマー1をスタートさせるとdotMaxまで出力してDACPORT=255で止まる
 */

#include "AibbyScope.h"
#include "global.h"
#include <string.h>
#include <stdalign.h>

float bf16ToFloat(bfloat16);

alignas(4) static uint8_t  video[BUFSIZE + 2];  // 1024 + 2  DMA対象なので4バイトアライメントに揃える

//------------------------------------------------------------------------------
void TM0_IRQHandler(void)
{
  uint32_t captDataCnt;

  clear_bit(SSIOF0->SF0CTRL, 1);
  dmac1_disable();
  dmac1_clrIntStatus();

  if(run) {
    switch(cfg.runMode) {
    case WAVE:

      // 新規サンプリングデータをFIFOへマージ
      // データ数が多いため、割り込み可能なサイクルスチールDMAかmemcpyで転送する。
      // サンプルサイズに依存し1024ptで最長になる
#if 0 // DMA 141μs
      dmac0_init(DMAC_TMOD_ARQ_AUTO | DMAC_TMOD_SDP_INC | DMAC_TMOD_DDP_INC | DMAC_TMOD_TSIZ_BYTE | DMAC_TMOD_BRQ_CYCLE | DMAC_TMOD_IMK_IMASK, DMAC_REQ_NOTSEL, (void*)0 );
      captDataCnt = newDataCnt;
      dmac0_Transfer(&wave.u8[captDataCnt], &wave.u8[0], cfg.samples);
      dmac0_enable();
      while(DMAC->DMASTA & 1U)  __NOP();
#else // memcpy 39μs
      captDataCnt = newDataCnt;
      memcpy(&wave.u8[0], &wave.u8[captDataCnt], cfg.samples);
#endif

      // 最初のコピー中にサンプリングされた追加データをサンプリングバッファの先頭へ移動する。このデータは次回にFIFOへマージされる。
      // ここでコピーするデータ数は20μs以内に終わる少量のため、割り込みを禁止して一括転送する。
      // サンプリングレートに依存し50kHzで最長になる
#if 0 // DMA 6.0μs
      dmac0_init(DMAC_TMOD_ARQ_AUTO | DMAC_TMOD_SDP_INC | DMAC_TMOD_DDP_INC | DMAC_TMOD_TSIZ_BYTE | DMAC_TMOD_BRQ_BURST | DMAC_TMOD_IMK_IMASK, DMAC_REQ_NOTSEL, (void*)0 );
      __disable_irq();
      dmac0_Transfer(&wave.u8[cfg.samples + captDataCnt], &wave.u8[cfg.samples], newDataCnt - captDataCnt);
      dmac0_enable();
      while(DMAC->DMASTA & 1U)  __NOP();
#else // memcpy 4.7μs
      __disable_irq();
      memcpy(&wave.u8[cfg.samples], &wave.u8[cfg.samples + captDataCnt], newDataCnt - captDataCnt);
#endif
      newDataCnt -= captDataCnt;
      __enable_irq();

      // 画像データスナップショット
      // FIFOの先頭から1024バイトを画像バッファへコピー
#if 1 // DMA 12.6μs
      dmac0_init(( DMAC_TMOD_ARQ_AUTO | DMAC_TMOD_SDP_INC | DMAC_TMOD_DDP_INC | DMAC_TMOD_TSIZ_WORD | DMAC_TMOD_BRQ_BURST | DMAC_TMOD_IMK_IMASK), DMAC_REQ_NOTSEL, (void*)0 );
      dmac0_Transfer(&wave.u32[0], &video[0], dotMax >> 2);
      dmac0_enable();
      while(DMAC->DMASTA & 1U)  __NOP();
      dmac0_clrIntStatus();
#else // memcpy 36.5μs
      memcpy(&video[0], &wave.u32[0], dotMax);
#endif
      break;



    case FFT:
      // 新規サンプリングデータをbf16変換してからFIFOへマージ
      // BF変換はサンプリングレートに依存し50kHzで715μs
      captDataCnt = newDataCnt;
      ODL_ToBfloat16(&wave.bf16[cfg.samples], &wave.bf16[cfg.samples], cfg.qFormat, captDataCnt); // 変換中でも割り込みは受け付ける

#if 0 // DMA 141μs
      dmac0_init(DMAC_TMOD_ARQ_AUTO | DMAC_TMOD_SDP_INC | DMAC_TMOD_DDP_INC | DMAC_TMOD_TSIZ_HWORD | DMAC_TMOD_BRQ_CYCLE | DMAC_TMOD_IMK_IMASK, DMAC_REQ_NOTSEL, (void*)0 );
      dmac0_Transfer(&wave.bf16[captDataCnt], &wave.bf16[0], cfg.samples);
      dmac0_enable();
      while(DMAC->DMASTA & 1U)  __NOP();
#else // memcpy 73μs
      memcpy(&wave.bf16[0], &wave.bf16[captDataCnt], cfg.samples << 1);
#endif

      // 追加サンプリングデータをサンプリングバッファの先頭へ移動する。このデータは次回にbf16変換されFIFOへマージされる。
      // サンプリングレートに依存し50kHzで最長になる
#if 1 // DMA 7.5μs
      dmac0_init(DMAC_TMOD_ARQ_AUTO | DMAC_TMOD_SDP_INC | DMAC_TMOD_DDP_INC | DMAC_TMOD_TSIZ_HWORD | DMAC_TMOD_BRQ_BURST | DMAC_TMOD_IMK_IMASK, DMAC_REQ_NOTSEL, (void*)0 );
      __disable_irq();
      dmac0_Transfer(&wave.bf16[cfg.samples + captDataCnt], &wave.bf16[cfg.samples], newDataCnt - captDataCnt);
      dmac0_enable();
      while(DMAC->DMASTA & 1U)  __NOP();
#else // memcpy 8.3μs
      __disable_irq();
      memcpy(&wave.bf16[cfg.samples], &wave.bf16[cfg.samples + captDataCnt], (newDataCnt - captDataCnt) << 1);
#endif
      newDataCnt -= captDataCnt;
      __enable_irq();

      // FFT実行
      fft_Init(cfg.samples, cfg.fftWindow);
      fft_Start(&wave.bf16[0], cfg.samples);
      while(fft_IsBusy())  __NOP();

      if(cfg.rawPlot) {
        fft_GetResult((bfloat16*)&video[0], dotMax);
      }
      else{
        fft_t fftResult[513];     // ローカル変数を使う方がFloat変換が速い
        fft_GetResult(fftResult, dotMax);

        for(int i = 0; i < dotMax; i++) {
          float f = bf16ToFloat(fftResult[i]);
          if(f > 255) { f = 255; }
          video[i] = f;
        }
      }
      break;
    } // switch(cfg.runMode)

  } else {  // pause
    newDataCnt = 0;
  }


  // 描画
  timer1_clrCnt();
  timer1_start();
  ssiof0_clearFifo();
  if((cfg.runMode == FFT) && cfg.rawPlot) {
    ssiof0_putcByte(0x50 + (((dotMax << 1) & 0xff00) >> 8));
    ssiof0_putcByte((dotMax << 1) & 0xff);
    set_bit(SSIOF0->SF0CTRL, 1);
    dmac1_Transfer(&video[0], (void*)&SSIOF0->SF0DWR, dotMax << 1);
  }
  else {
    ssiof0_putcByte(0x50 + ((dotMax & 0xff00) >> 8));
    ssiof0_putcByte(dotMax & 0xff);
    set_bit(SSIOF0->SF0CTRL, 1);
    dmac1_Transfer(&video[0], (void*)&SSIOF0->SF0DWR, dotMax);
  }
  dmac1_enable();
  DACPORT = 255;
  VSYNCPORT |= VSYNC;
}

//------------------------------------------------------------------------------
void TM1_IRQHandler(void) {

  if(dotCount < dotMax) {
    DACPORT = video[dotCount];
    dotCount++;
  }
  else {
    DACPORT = 0;
    dotCount = 0;
    timer1_stop();
    VSYNCPORT &= ~VSYNC;
  }
}

//------------------------------------------------------------------------------
float bf16ToFloat(bfloat16 bf) {
  union {
    uint32_t  u;
    float     f;
  } conv;

  conv.u = ((uint32_t)bf) << 16;
  return conv.f;
}
//------------------------------------------------------------------------------
