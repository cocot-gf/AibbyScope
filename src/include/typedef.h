/*
 * typedef.h
 *
 *  AibbyScope
 *  Created on: 2026/02/14
 *      Author: cocot
 * Description: 新しい型定義
 */

#ifndef SRC_INCLUDE_TYPEDEF_H_
#define SRC_INCLUDE_TYPEDEF_H_

#include "AibbyScope.h"
#include "driver.h"

typedef enum {
  WAVE,
  FFT,
} RunMode;

typedef struct {
  RunMode   runMode;
  uint16_t  samplingRate;
  int       samples;
  uint8_t   qFormat;
  FftWindow fftWindow;
  uint16_t  sweepTimer;
  uint16_t  dotTimer;
} Settings;

typedef union {                     // FIFO[1024] + 新規データ領域[1024] + オーバーラン[OVERRUN]
  uint8_t     u8[BUFSIZE * 2 + OVERRUN];   // デバッグ中ブレークをかけると領域をはみ出るので多めに取っておく
  bfloat16    bf16[BUFSIZE * 2 + OVERRUN];
  uint32_t    u32[BUFSIZE + (OVERRUN / 2)];
} WaveFifo;

#endif /* SRC_INCLUDE_TYPEDEF_H_ */
