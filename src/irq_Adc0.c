/*
 * irq_Adc0.c
 *
 *  AibbyScope
 *  Created on: 2026/02/12
 *      Author: cocot
 * Description: ADCサンプリング割り込み 優先度1
 */

#include "driver.h"
#include "global.h"

//------------------------------------------------------------------------------
void SAD_IRQHandler(void){

  if(newDataCnt >= (BUFSIZE + OVERRUN)) {
    __NOP();  // ブレークポイント用
    return;   // オーバーランエリアも足りない場合は何もせずリターン
  }

  int16_t adin = saAdc0_getResult();

  switch(cfg.runMode) {
  case WAVE:  // ADデータを8bitに落としてFIFO前の新規バッファに追加
    wave.u8[cfg.samples + newDataCnt] = adin >> 8;
    break;

  case FFT:   // ADデータを符号付きQ8.8に変換して固定小数点でバッファに追加、bf16への変換はTmr0割り込みで一括実施するほうが速い
    wave.bf16[cfg.samples + newDataCnt] = (bfloat16)(adin - 0x8000);
    break;
  }

  newDataCnt++;
}
