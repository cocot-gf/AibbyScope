/*
 * int_Uartf3_Stream.h
 *
 *  Created on: 2026/02/15
 *      Author: cocot
 */

#ifndef SRC_INCLUDE_INT_UARTF3_STREAM_H_
#define SRC_INCLUDE_INT_UARTF3_STREAM_H_

void proc_UartfRead(uint32_t, uint16_t);

extern volatile bool     rxEnd;
extern volatile uint32_t s_RxSize;
extern volatile uint16_t s_RxErrStat;

#endif /* SRC_INCLUDE_INT_UARTF3_STREAM_H_ */
