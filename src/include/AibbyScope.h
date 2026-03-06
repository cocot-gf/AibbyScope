/*
 * AibbyScope.h
 *
 *  AibbyScope
 *  Created on: 2026/02/12
 *      Author: cocot
 * Description: システムの動作設定を定義
 */

#ifndef SRC_INCLUDE_AIBBYSCOPE_H_
#define SRC_INCLUDE_AIBBYSCOPE_H_

// ユーザー設定項目
#define DEF_MODE    (WAVE)
#define DEF_RATE    (50000)   // SAMPLE_RATE * SAMPLES が21M以下になるように調整すること
#define DEF_SAMPLES (1024)    // それ以上ではFIFO転送が間に合わない
#define DEF_QFORMAT (4)
#define DEF_WINDOW  (FFT_WINDOW_NONE)

// 動作調整項目
#define OSCLK       (48000000U)
#define SWEEPTIMER  ((uint32_t)(OSCLK / 64 / 50))
#define DOTTIMER    (460)

// その他
#define BUFSIZE     (1024)
#define OVERRUN     (64)      // FIFOオーバーラン防止用の追加領域

#endif /* SRC_INCLUDE_AIBBYSCOPE_H_ */
