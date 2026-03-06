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
#include <uartf3.h>
//#include <can.h>
#include <stdio.h>

// ロームのヘッダに書かれていない定義
#define PERI_TM0    (0x00000001U)
#define PERI_TM1    (0x00000002U)
#define PERI_SAD0   (0x00002000U)
#define PERI_UAF3   (0x00400000U)
#define PERI_DMAC   (0x20000000U)
#define PERI_AI     (0x40000000U)
// GPIO
#define DACPORT     (PORT4->P4DO)
#define DEBUGOUT2   (PORT2->P2DO)
#define DEBUGOUT7   (PORT7->P7DO)
#define DEBUGIN     (PORT7->P7DI)
#define P70         (1U)
#define P71         (2U)
#define P21         (2U)
#define LED         (4U)
// UART
#define RXBUFMAX    (1)

#endif /* SRC_INCLUDE_DRIVER_H_ */
