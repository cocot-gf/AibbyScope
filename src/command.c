/*
 * command.c
 *
 *  AibbyScope
 *  Created on: 2026/02/17
 *      Author: cocot
 * Description: コマンドプロセッサ
 */

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

#include "global.h"
#include "setup.h"
#include "help.h"

bool cmdInterp(void);
int sampVal(int samples);

//------------------------------------------------------------------------------
bool cmdInput(char c) {  // コマンドラインエディタ

  const uint16_t dotTmrDB[] = {65535, 65535, 39300, 23500, 13100, 6930, 3570, 1820, 915, 460};
  bool echo = false;
  int cmdLen = strlen(cmdBuf);
  int i;


  switch(c) {
  case 0x1b:          // ESC
    initConfig();
    return true;
    break;

  case '\b':          // バックスペース
    if(cmdLen > 0) {
      cmdBuf[cmdLen - 1] = 0;
      printf("\b \b");
    }
    break;

  case ' ':          // ESC
    run = !run;
    return true;
    break;

  case '<':
    i = sampVal(cfg.samples);
    if(i > 1) {
      cfg.samples = cfg.samples >> 1;
      cfg.dotTimer = dotTmrDB[i - 2];
      run = true;
      return true;
    }
    return false;
    break;

  case '>':
    i = sampVal(cfg.samples);
    if(i < 10) {
      cfg.samples = cfg.samples << 1;
      cfg.dotTimer = dotTmrDB[i];
      run = true;
      return true;
    }
    return false;
    break;

  case '(':
    if(cfg.samplingRate < 500) { break; }
    cfg.samplingRate = cfg.samplingRate >> 1;
    run = true;
    return true;
    break;

  case ')':
    if(cfg.samplingRate > 25000) { break; }
    cfg.samplingRate = cfg.samplingRate << 1;
    run = true;
    return true;
    break;

  case '-':
    if(cfg.qFormat > 0) {
      cfg.qFormat--;
      run = true;
      return true;
    }
    return false;
    break;

  case '+':
    if(cfg.qFormat < 15) {
      cfg.qFormat++;
      run = true;
      return true;
    }
    return false;
    break;

  case 'w':
    cfg.runMode = WAVE;
    run = true;
    return true;
    break;

  case 'f':
    cfg.runMode = FFT;
    run = true;
    return true;
    break;

  case 'n':
    cfg.fftWindow = FFT_WINDOW_NONE;
    run = true;
    return true;
    break;

  case 'h':
    cfg.fftWindow = FFT_WINDOW_HANN;
    run = true;
    return true;
    break;

  case 'A' ... 'Z':   // 1文字目だけコマンドアルファベット入力
  case 'a' ... 'e':
  case 'g':
  case 'i' ... 'm':
  case 'o' ... 'v':
  case 'x' ... 'z':
    if(cmdLen == 0) {
      cmdBuf[0] = c;
      cmdBuf[1] = 0;
      echo = true;
    }
    break;

  case '0' ... '9':   // 引数の数字
    if(cmdLen > 0 && cmdLen < 6) {
      cmdBuf[cmdLen] = c;
      cmdBuf[cmdLen + 1] = 0;
      echo = true;
    }
    break;

  case '\r':          // CR
    if(cmdLen >= 2) {
      puts("\r");
      return cmdInterp();
    }
    break;

  case '?':
    help();
    cmdBuf[0] = 0;
    break;
  }

  if(echo) {
    putc(c, stdout);
  }

  return false;
}

//------------------------------------------------------------------------------
bool cmdInterp(void) {  // コマンド解析 設定を更新する場合はtrueを返す
  bool update = false;
  int arg = atoi(&cmdBuf[1]);

  switch(cmdBuf[0]) {
  case 'r':
    if(arg >= 250 && arg <= 50000) {
      cfg.samplingRate = arg;
      update = true;
      run = true;
    } else {
      puts("Set the sampling rate between 250 and 50000.\r\n");
    }
    break;

  case 's':
    if(sampVal(arg) != 0) {
      cfg.samples = arg;
      update = true;
      run = true;
    } else {
      puts("Specify the number of samples as a power of two between 2 and 1024.\r\n");
    }
    break;

    case 'q':
      if(arg >= 0 && arg <= 15) {
        cfg.qFormat = arg;
        update = true;
        run = true;
      } else {
        puts("Specify the Q-format value between 0 and 15.\r\n");
      }
      break;

    case 't':
      if(arg >= 12500 || arg <= 15000) {
        cfg.sweepTimer = arg;
        update = true;
      } else {
        puts("Specify the V-Sync timer value between 12500 and 15000.\r\n");
      }
      break;

    case 'd':
      if(arg >= 250 || arg <= 65535) {
        cfg.dotTimer = arg;
        update = true;
      } else {
        puts("Specify the dot timer value between 250 and 65535.\r\n");
      }
      break;

  default:
    break;
  }

  cmdBuf[0] = 0;
  return update;
}
//------------------------------------------------------------------------------
int sampVal(int samples) {

  switch(samples) {
    case 2:    return  1;  break;
    case 4:    return  2;  break;
    case 8:    return  3;  break;
    case 16:   return  4;  break;
    case 32:   return  5;  break;
    case 64:   return  6;  break;
    case 128:  return  7;  break;
    case 256:  return  8;  break;
    case 512:  return  9;  break;
    case 1024: return 10;  break;
  }
  return 0;
}
