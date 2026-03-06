/*
 * global.h
 *
 *  AibbyScope
 *  Created on: 2026/02/13
 *      Author: cocot
 * Description: 公開するグローバル変数
 */

#ifndef SRC_INCLUDE_GLOBAL_H_
#define SRC_INCLUDE_GLOBAL_H_

#include "typedef.h"

extern WaveFifo   wave;         // 波形FIFO[1024] + 新規データ領域[1024]
extern Settings   cfg;          // 設定
extern volatile uint32_t   newDataCnt;   // FIFOに統合されていない新しいADCデータの数
extern int        dotCount;     // 次に描画するドット番号
extern int        dotMax;       // 描画するドットの数 FFTの時はsamplesの半分になる
extern bool       run;          // pause判定
extern char       cmdBuf[7];

#endif /* SRC_INCLUDE_GLOBAL_H_ */
