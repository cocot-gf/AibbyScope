################################################################################
# 自動生成ファイルです。 編集しないでください!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
C_SRCS += \
../driver/src/dmac0.c \
../driver/src/dmac1.c \
../driver/src/irq.c \
../driver/src/saAdc0.c \
../driver/src/timer0_1.c \
../driver/src/uartf3.c \
../driver/src/wdt.c 

RESS += \
./driver/src/dmac0.res \
./driver/src/dmac1.res \
./driver/src/irq.res \
./driver/src/saAdc0.res \
./driver/src/timer0_1.res \
./driver/src/uartf3.res \
./driver/src/wdt.res 

RESS__QUOTED += \
"./driver/src/dmac0.res" \
"./driver/src/dmac1.res" \
"./driver/src/irq.res" \
"./driver/src/saAdc0.res" \
"./driver/src/timer0_1.res" \
"./driver/src/uartf3.res" \
"./driver/src/wdt.res" 

ASMS += \
./driver/src/dmac0.asm \
./driver/src/dmac1.asm \
./driver/src/irq.asm \
./driver/src/saAdc0.asm \
./driver/src/timer0_1.asm \
./driver/src/uartf3.asm \
./driver/src/wdt.asm 

ASMS__QUOTED += \
"./driver/src/dmac0.asm" \
"./driver/src/dmac1.asm" \
"./driver/src/irq.asm" \
"./driver/src/saAdc0.asm" \
"./driver/src/timer0_1.asm" \
"./driver/src/uartf3.asm" \
"./driver/src/wdt.asm" 

OBJS += \
./driver/src/dmac0.o \
./driver/src/dmac1.o \
./driver/src/irq.o \
./driver/src/saAdc0.o \
./driver/src/timer0_1.o \
./driver/src/uartf3.o \
./driver/src/wdt.o 

OBJS__QUOTED += \
"./driver/src/dmac0.o" \
"./driver/src/dmac1.o" \
"./driver/src/irq.o" \
"./driver/src/saAdc0.o" \
"./driver/src/timer0_1.o" \
"./driver/src/uartf3.o" \
"./driver/src/wdt.o" 

IS += \
./driver/src/dmac0.i \
./driver/src/dmac1.i \
./driver/src/irq.i \
./driver/src/saAdc0.i \
./driver/src/timer0_1.i \
./driver/src/uartf3.i \
./driver/src/wdt.i 

IS__QUOTED += \
"./driver/src/dmac0.i" \
"./driver/src/dmac1.i" \
"./driver/src/irq.i" \
"./driver/src/saAdc0.i" \
"./driver/src/timer0_1.i" \
"./driver/src/uartf3.i" \
"./driver/src/wdt.i" 


# サブディレクトリーはすべて、それ自身がコントリビュートするソースをビルドするためのルールを提供しなければなりません
driver/src/dmac0.asm: ../driver/src/dmac0.c
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Compiler'
	lccarm @"./driver/src/dmac0.res"
	@echo 'ビルド完了: $<'
	@echo ' '

driver/src/dmac0.res: driver/src/dmac0.asm
driver/src/dmac0.i: driver/src/dmac0.asm

driver/src/dmac0.o: ./driver/src/dmac0.asm
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Assembler'
	llvm-mc-arm -g -dwarf-version=4 -filetype=obj -o="driver/src/dmac0.o" -mcpu=cortex-m0plus "$<"
	@echo 'ビルド完了: $<'
	@echo ' '

driver/src/dmac1.asm: ../driver/src/dmac1.c
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Compiler'
	lccarm @"./driver/src/dmac1.res"
	@echo 'ビルド完了: $<'
	@echo ' '

driver/src/dmac1.res: driver/src/dmac1.asm
driver/src/dmac1.i: driver/src/dmac1.asm

driver/src/dmac1.o: ./driver/src/dmac1.asm
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Assembler'
	llvm-mc-arm -g -dwarf-version=4 -filetype=obj -o="driver/src/dmac1.o" -mcpu=cortex-m0plus "$<"
	@echo 'ビルド完了: $<'
	@echo ' '

driver/src/irq.asm: ../driver/src/irq.c
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Compiler'
	lccarm @"./driver/src/irq.res"
	@echo 'ビルド完了: $<'
	@echo ' '

driver/src/irq.res: driver/src/irq.asm
driver/src/irq.i: driver/src/irq.asm

driver/src/irq.o: ./driver/src/irq.asm
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Assembler'
	llvm-mc-arm -g -dwarf-version=4 -filetype=obj -o="driver/src/irq.o" -mcpu=cortex-m0plus "$<"
	@echo 'ビルド完了: $<'
	@echo ' '

driver/src/saAdc0.asm: ../driver/src/saAdc0.c
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Compiler'
	lccarm @"./driver/src/saAdc0.res"
	@echo 'ビルド完了: $<'
	@echo ' '

driver/src/saAdc0.res: driver/src/saAdc0.asm
driver/src/saAdc0.i: driver/src/saAdc0.asm

driver/src/saAdc0.o: ./driver/src/saAdc0.asm
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Assembler'
	llvm-mc-arm -g -dwarf-version=4 -filetype=obj -o="driver/src/saAdc0.o" -mcpu=cortex-m0plus "$<"
	@echo 'ビルド完了: $<'
	@echo ' '

driver/src/timer0_1.asm: ../driver/src/timer0_1.c
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Compiler'
	lccarm @"./driver/src/timer0_1.res"
	@echo 'ビルド完了: $<'
	@echo ' '

driver/src/timer0_1.res: driver/src/timer0_1.asm
driver/src/timer0_1.i: driver/src/timer0_1.asm

driver/src/timer0_1.o: ./driver/src/timer0_1.asm
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Assembler'
	llvm-mc-arm -g -dwarf-version=4 -filetype=obj -o="driver/src/timer0_1.o" -mcpu=cortex-m0plus "$<"
	@echo 'ビルド完了: $<'
	@echo ' '

driver/src/uartf3.asm: ../driver/src/uartf3.c
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Compiler'
	lccarm @"./driver/src/uartf3.res"
	@echo 'ビルド完了: $<'
	@echo ' '

driver/src/uartf3.res: driver/src/uartf3.asm
driver/src/uartf3.i: driver/src/uartf3.asm

driver/src/uartf3.o: ./driver/src/uartf3.asm
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Assembler'
	llvm-mc-arm -g -dwarf-version=4 -filetype=obj -o="driver/src/uartf3.o" -mcpu=cortex-m0plus "$<"
	@echo 'ビルド完了: $<'
	@echo ' '

driver/src/wdt.asm: ../driver/src/wdt.c
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Compiler'
	lccarm @"./driver/src/wdt.res"
	@echo 'ビルド完了: $<'
	@echo ' '

driver/src/wdt.res: driver/src/wdt.asm
driver/src/wdt.i: driver/src/wdt.asm

driver/src/wdt.o: ./driver/src/wdt.asm
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Assembler'
	llvm-mc-arm -g -dwarf-version=4 -filetype=obj -o="driver/src/wdt.o" -mcpu=cortex-m0plus "$<"
	@echo 'ビルド完了: $<'
	@echo ' '


