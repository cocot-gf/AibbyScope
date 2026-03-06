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

//------------------------------------------------------------------------------
WaveFifo  wave;
Settings  cfg;
volatile uint32_t  newDataCnt;
int       dotCount;
int       dotMax;
bool      run;
char      cmdBuf[7] = {0};
