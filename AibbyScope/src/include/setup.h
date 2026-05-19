/*
 * setup.h
 *
 *  AibbyScope
 *  Created on: 2026/02/12
 *      Author: cocot
 * Description: 公開するセットアップルーチン
 */

#ifndef SRC_INCLUDE_SETUP_H_
#define SRC_INCLUDE_SETUP_H_

void setup(void);
void setupAdc(void);
void setupDmac(void);
void setupTimer(void);
void clearBuffer(void);
void initConfig(void);

#endif /* SRC_INCLUDE_SETUP_H_ */
