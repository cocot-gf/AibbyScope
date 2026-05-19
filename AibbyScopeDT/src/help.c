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
  puts("\r\n*** AibbyScopeDT 1.1 ***\r\n\r");

  printf(" w   WAVE View    %s\r\n", cfg.runMode == WAVE ? "<= Now" : "");
  printf(" f   FFT View     %s\r\n", cfg.runMode == FFT ? "<= Now" : "");
  printf("(r)  Sampling Rate : %u Hz\r\n", (uint16_t)cfg.samplingRate);
  printf("<s>  Sample Size   : %u\r\n", cfg.samples);
  if(cfg.runMode == FFT) {
  printf("-q+  Q-Format      : Q%u\r\n", cfg.qFormat);
  printf(" nh  Window Func   : %s\r\n", cfg.fftWindow == FFT_WINDOW_NONE ? "Rectangular" : "Hanning");
  printf(" lb  Plot Mode     : %s\r\n", cfg.rawPlot ? "Raw BF16" : "Linear");
  }
  printf(" d   Dot Adjust    : %u\r\n", cfg.dotTimer);
  printf(" v   V-Sync Adjust : %u\r\n", cfg.sweepTimer);
    puts(" ?   Show Help\r\n\r");
    puts("Press SPACE to pause/resume sampling.\r");
    puts("Press ESC to restore the default settings.\r\n\r");
}

//------------------------------------------------------------------------------
void help(void) {
  puts("\r\n*** How to use AibbyScopeDT ***\r\n\r");
  puts("Recommended Range : VERT 0.5V/div, WAVE 10ms, FFT 5ms\r\n\r");
  puts(" w   WAVE View\r");
  puts(" f   FFT View\r");
  puts("(r)  Sampling Rate : Between 250 and 50000 Hz\r");
  puts("<s>  Sample Size   : 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024\r");
  puts("-q+  Q-Format      : Between 0 and 15 (Effective FFT Only)\r");
  puts(" nh  Window Func   : [n]:Rectangular [h]:Hanning\r");
  puts(" lb  FFT Plot Mode : [l]:Linear [b]:BF16(not shown)\r");
  puts(" d   Dot Adjust    : Between 250 and 65535, default 460\r");
  puts("                   : 460 915 1820 3570 6930 13100 23500 39300 65535\r");
  puts(" v   V-Sync Adjust : Between 12500 and 15000, default 15000\r");
  puts(" x   Quiet         : Do not response for GUI, ESC or help to resume\r");
  puts(" c   Show Config   : Show Configration for GUI\r\n\r");
  puts("Press SPACE to pause/resume sampling.\r");
  puts("Press ESC to restore the default settings.\r\n\r");
  puts("[P32] Analog Input        [P71] UART TX [P70] UART RX\r");
  puts("[P76] Video Sync Output   [P60] SCK [P61] SDO [P62] SDI [P63] SS#\r");
  puts("[P55] Monitor LED\r");
}

//------------------------------------------------------------------------------
void showConfig(void) {
  putchar(cfg.runMode == WAVE ? 'w' : cfg.runMode == FFT ? 'f' : 'u');
  printf(",r%u,s%u,q%u,", (uint16_t)cfg.samplingRate, cfg.samples, cfg.qFormat);
  putchar(cfg.fftWindow == FFT_WINDOW_NONE ? 'n' : 'h');
  putchar(',');
  putchar(cfg.rawPlot ? 'b' : 'l');
  printf(",d%u,v%u,%u\r\n", cfg.dotTimer, cfg.sweepTimer, run ? 1 : 0);
}
