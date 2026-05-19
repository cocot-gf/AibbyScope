/*
 * main.c
 *
 *  AibbyScope - オシロスコープでSolist-AIを使う
 *  Created on: 2026/02/12
 *      Author: cocot
 * Description:
 */

#include "driver.h"
#include "global.h"
#include "setup.h"
#include "help.h"
#include "command.h"
#include "int_Uart_Stream.h"

static uint8_t rxBuf = 0;

//------------------------------------------------------------------------------
int main(void) {
  setup();

  while(1) {
    switch(cfg.runMode) {
      case WAVE: dotMax =  cfg.samples;           break;
      case FFT:  dotMax = (cfg.samples >> 1) + 1; break;
    }

    newDataCnt = 0;
    dotCount   = 0;

    cmdBuf[0] = 0;
    rxEnd = false;
    uartf0_read(&rxBuf, 1U, proc_UartfRead);

    if(!quiet) splashScreen();
    LEDPORT |= LED;
    saAdc0_start();
    timer0_start();

    while(1) {
      wdt_clear();

      if(rxEnd) {
        char c = rxBuf;
        rxEnd = false;
        uartf0_read(&rxBuf, 1U, proc_UartfRead);
        if(cmdInput(c)) {
          break;
        }
      }
    }

    LEDPORT &= ~LED;
    setupAdc();
    setupDmac();
    setupTimer();
    if(run) clearBuffer();
  }
}
