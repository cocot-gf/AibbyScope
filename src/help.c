/*
 * help.c
 *
 *  AibbyScope
 *  Created on: 2026/02/17
 *      Author: cocot
 * Description: ヘルプ画面
 */

#include <stdio.h>
#include "global.h"

//------------------------------------------------------------------------------
void splashScreen(void) {
  puts("\r\n*** AibbyScope ***\r\n\r");

  printf(" w   WAVE View    %s\r\n", cfg.runMode == WAVE ? "<= Now" : "");
  printf(" f   FFT View     %s\r\n", cfg.runMode == FFT ? "<= Now" : "");
  printf("(r)  Sampling Rate : %u Hz\r\n", cfg.samplingRate);
  printf("<s>  Sample Size   : %u\r\n", cfg.samples);
  if(cfg.runMode == FFT) {
  printf("-q+  Q-Format      : Q%u\r\n", cfg.qFormat);
  printf(" nh  Window Func   : %s\r\n", cfg.fftWindow == FFT_WINDOW_NONE ? "Rectangular" : "Hanning");
  }
  printf(" t   V-Sync Adjust : %u\r\n", cfg.sweepTimer);
  printf(" d   Dot Adjust    : %u\r\n", cfg.dotTimer);
    puts(" ?   Show Help\r\n\r");
    puts("Press SPACE to pause/resume sampling.\r");
    puts("Press ESC to restore the default settings.\r\n\r");
}

//------------------------------------------------------------------------------
void help(void) {
  puts("\r\n*** How to use AibbyScope ***\r\n\r");
  puts("Recommended Range : VERT 0.5V/div, WAVE 10ms, FFT 5ms\r\n\r");
  puts(" w   WAVE View\r");
  puts(" f   FFT View\r");
  puts("(r)  Sampling Rate : Between 250 and 50000 Hz\r");
  puts("<s>  Sample Size   : 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024\r");
  puts("-q+  Q-Format      : Between 0 and 15 (Effective FFT Only)\r");
  puts(" nh  Window Func   : [n]:Rectangular [h]:Hanning\r");
  puts(" t   V-Sync Adjust : Between 12500 and 15000, default 15000\r");
  puts(" d   Dot Adjust    : Between 250 and 65535, default 460\r");
  puts("                   : 460 915 1820 3570 6930 13100 23500 39300 65535\r\n\r");
  puts("Press SPACE to pause/resume sampling.\r");
  puts("Press ESC to restore the default settings.\r\n\r");
  puts("[P36] Analog Input\r");
  puts("[P4x] Digital Output for R-2R DAC\r");
  puts("[P70] Video Sync Output\r");
  puts("[P53] UART TX Output, 115200 8N1\r");
  puts("[P54] UART RX Input\r");
  puts("[P21] Processing Indicator\r");
}
