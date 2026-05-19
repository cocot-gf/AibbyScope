/*
 * driver.h
 *
 *  AibbyScope
 *  Created on: 2026/02/14
 *      Author: cocot
 * Description: ロームのドライバをインポートし、足りない定数を定義する
 */

#ifndef SRC_INCLUDE_DRIVER_H_
#define SRC_INCLUDE_DRIVER_H_

// 使用するペリフェラル
#include <wdt.h>
#include <clock.h>
#include <dmac.h>
#include <dmac0.h>
#include <dmac1.h>
#include <dmac_common.h>
#include <saAdc0.h>
#include <irq.h>
#include <solistAi.h>
#include <timer0_1.h>
#include <uartf1.h>
#include <ssiof1.h>
#include <stdio.h>

// ロームのヘッダに書かれていない定義
#define PERI_TM0    (1U << 0)
#define PERI_TM1    (1U << 1)
#define PERI_SAD0   (1U << 13)
//#define PERI_SIOF0  (1U << 16)
#define PERI_SIOF1  (1U << 17)
#define PERI_UAF1   (1U << 19)
#define PERI_DMAC   (1U << 29)
#define PERI_AI     (1U << 30)

// GPIO
#define LEDPORT     (PORT5->P5DO)
#define LED         (1U << 5)
#define VSYNCPORT   (PORT7->P7DO)
#define VSYNC       (1U << 6)
#define KEEPPORT    (PORT4->P4DO)
#define KEEP        (1U << 5)

// UART
#define RXBUFMAX    (1)

#endif /* SRC_INCLUDE_DRIVER_H_ */
