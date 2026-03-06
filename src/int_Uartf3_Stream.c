/*
 * int_Uartf3_Stream.c
 *
 *  AibbyScope
 *  Created on: 2026/02/15
 *      Author: cocot
 * Description:
 */

#include "driver.h"
#include "global.h"

static volatile bool     txEnd;
static volatile uint32_t txSize;
static volatile uint16_t txErrStat;

       volatile bool     rxEnd;
static volatile uint32_t rxSize;
static volatile uint16_t rxErrStat;

//------------------------------------------------------------------------------
void UAF3_IRQHandler(void) {
  uint32_t  intStat = uartf3_getIntCause() & UARTF_IRID_MASK;

  switch(intStat) {   // UARTF割り込み要因チェック
  case UARTF_IRID_DATA_ERR:
  case UARTF_IRID_READ_REQ:
  case UARTF_IRID_CHAR_TIMEOUT:
    uartf3_continueRead();
    break;

  case UARTF_IRID_WRITE_REQ:
  case UARTF_IRID_TRANS_COMP:
    uartf3_continueWrite((uint16_t)intStat);
    break;

  default:
    break;
  }
}

//------------------------------------------------------------------------------
static void proc_UartfWrite(uint32_t size, uint16_t errStatus)
{
  txEnd     = true;
  txSize    = size;
  txErrStat = errStatus;
}

//------------------------------------------------------------------------------
void proc_UartfRead(uint32_t size, uint16_t errStatus) {
  rxEnd     = true;
  rxSize    = size;
  rxErrStat = errStatus;
}

//------------------------------------------------------------------------------
#ifdef __LCCARM__

// CMSISに用意されているSTDIO設定用の関数
static int my_putc(char c, FILE *file)
{
  txEnd = false;
  uartf3_write((uint8_t*)&c, 1U, proc_UartfWrite);   // 1バイトを送信キューに入れて送信完了割り込み待ち

  while(txEnd == false) {  // 送信が終わるまでブロックする
    wdt_clear();
  }
  return c;
}

//------------------------------------------------------------------------------
static int my_getc(FILE *file)
{
  return (int)0;
}

//------------------------------------------------------------------------------
static int my_flush(FILE *file)
{
  (void)file;
  return (int)0;
}

//------------------------------------------------------------------------------
static FILE __stdio = FDEV_SETUP_STREAM(my_putc, my_getc, my_flush, _FDEV_SETUP_RW);

#ifdef __strong_reference
#define STDIO_ALIAS(x) __strong_reference(stdin, x);
#else
#define STDIO_ALIAS(x) FILE *const x = &__stdio;
#endif

FILE *const stdin = &__stdio;
STDIO_ALIAS(stdout);
STDIO_ALIAS(stderr);
#endif // __LCCARM__
