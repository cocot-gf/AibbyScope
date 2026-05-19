/*
 * global.c
 *
 *  AibbyScope
 *  Created on: 2026/02/14
 *      Author: cocot
 * Description: グローバル変数の宣言
 */

#include "driver.h"
#include "typedef.h"
#include <stdalign.h>

//------------------------------------------------------------------------------
alignas(4) WaveFifo  wave; // DMA対象なので4バイトアライメントに揃える
Settings  cfg;
volatile uint32_t  newDataCnt;
int       dotCount;
int       dotMax;
bool      run;
bool      quiet;
char      cmdBuf[7] = {0};
