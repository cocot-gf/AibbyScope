################################################################################
# 自動生成ファイルです。 編集しないでください!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
C_SRCS += \
../src/command.c \
../src/global.c \
../src/help.c \
../src/int_Uartf3_Stream.c \
../src/irq_Adc0.c \
../src/irq_Timer.c \
../src/main.c \
../src/setup.c \
../src/startup_ML63Q25x7.c \
../src/system_ML63Q25x7.c 

RESS += \
./src/command.res \
./src/global.res \
./src/help.res \
./src/int_Uartf3_Stream.res \
./src/irq_Adc0.res \
./src/irq_Timer.res \
./src/main.res \
./src/setup.res \
./src/startup_ML63Q25x7.res \
./src/system_ML63Q25x7.res 

RESS__QUOTED += \
"./src/command.res" \
"./src/global.res" \
"./src/help.res" \
"./src/int_Uartf3_Stream.res" \
"./src/irq_Adc0.res" \
"./src/irq_Timer.res" \
"./src/main.res" \
"./src/setup.res" \
"./src/startup_ML63Q25x7.res" \
"./src/system_ML63Q25x7.res" 

ASMS += \
./src/command.asm \
./src/global.asm \
./src/help.asm \
./src/int_Uartf3_Stream.asm \
./src/irq_Adc0.asm \
./src/irq_Timer.asm \
./src/main.asm \
./src/setup.asm \
./src/startup_ML63Q25x7.asm \
./src/system_ML63Q25x7.asm 

ASMS__QUOTED += \
"./src/command.asm" \
"./src/global.asm" \
"./src/help.asm" \
"./src/int_Uartf3_Stream.asm" \
"./src/irq_Adc0.asm" \
"./src/irq_Timer.asm" \
"./src/main.asm" \
"./src/setup.asm" \
"./src/startup_ML63Q25x7.asm" \
"./src/system_ML63Q25x7.asm" 

OBJS += \
./src/command.o \
./src/global.o \
./src/help.o \
./src/int_Uartf3_Stream.o \
./src/irq_Adc0.o \
./src/irq_Timer.o \
./src/main.o \
./src/setup.o \
./src/startup_ML63Q25x7.o \
./src/system_ML63Q25x7.o 

OBJS__QUOTED += \
"./src/command.o" \
"./src/global.o" \
"./src/help.o" \
"./src/int_Uartf3_Stream.o" \
"./src/irq_Adc0.o" \
"./src/irq_Timer.o" \
"./src/main.o" \
"./src/setup.o" \
"./src/startup_ML63Q25x7.o" \
"./src/system_ML63Q25x7.o" 

IS += \
./src/command.i \
./src/global.i \
./src/help.i \
./src/int_Uartf3_Stream.i \
./src/irq_Adc0.i \
./src/irq_Timer.i \
./src/main.i \
./src/setup.i \
./src/startup_ML63Q25x7.i \
./src/system_ML63Q25x7.i 

IS__QUOTED += \
"./src/command.i" \
"./src/global.i" \
"./src/help.i" \
"./src/int_Uartf3_Stream.i" \
"./src/irq_Adc0.i" \
"./src/irq_Timer.i" \
"./src/main.i" \
"./src/setup.i" \
"./src/startup_ML63Q25x7.i" \
"./src/system_ML63Q25x7.i" 


# サブディレクトリーはすべて、それ自身がコントリビュートするソースをビルドするためのルールを提供しなければなりません
src/command.asm: ../src/command.c
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Compiler'
	lccarm @"./src/command.res"
	@echo 'ビルド完了: $<'
	@echo ' '

src/command.res: src/command.asm
src/command.i: src/command.asm

src/command.o: ./src/command.asm
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Assembler'
	llvm-mc-arm -g -dwarf-version=4 -filetype=obj -o="src/command.o" -mcpu=cortex-m0plus "$<"
	@echo 'ビルド完了: $<'
	@echo ' '

src/global.asm: ../src/global.c
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Compiler'
	lccarm @"./src/global.res"
	@echo 'ビルド完了: $<'
	@echo ' '

src/global.res: src/global.asm
src/global.i: src/global.asm

src/global.o: ./src/global.asm
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Assembler'
	llvm-mc-arm -g -dwarf-version=4 -filetype=obj -o="src/global.o" -mcpu=cortex-m0plus "$<"
	@echo 'ビルド完了: $<'
	@echo ' '

src/help.asm: ../src/help.c
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Compiler'
	lccarm @"./src/help.res"
	@echo 'ビルド完了: $<'
	@echo ' '

src/help.res: src/help.asm
src/help.i: src/help.asm

src/help.o: ./src/help.asm
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Assembler'
	llvm-mc-arm -g -dwarf-version=4 -filetype=obj -o="src/help.o" -mcpu=cortex-m0plus "$<"
	@echo 'ビルド完了: $<'
	@echo ' '

src/int_Uartf3_Stream.asm: ../src/int_Uartf3_Stream.c
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Compiler'
	lccarm @"./src/int_Uartf3_Stream.res"
	@echo 'ビルド完了: $<'
	@echo ' '

src/int_Uartf3_Stream.res: src/int_Uartf3_Stream.asm
src/int_Uartf3_Stream.i: src/int_Uartf3_Stream.asm

src/int_Uartf3_Stream.o: ./src/int_Uartf3_Stream.asm
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Assembler'
	llvm-mc-arm -g -dwarf-version=4 -filetype=obj -o="src/int_Uartf3_Stream.o" -mcpu=cortex-m0plus "$<"
	@echo 'ビルド完了: $<'
	@echo ' '

src/irq_Adc0.asm: ../src/irq_Adc0.c
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Compiler'
	lccarm @"./src/irq_Adc0.res"
	@echo 'ビルド完了: $<'
	@echo ' '

src/irq_Adc0.res: src/irq_Adc0.asm
src/irq_Adc0.i: src/irq_Adc0.asm

src/irq_Adc0.o: ./src/irq_Adc0.asm
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Assembler'
	llvm-mc-arm -g -dwarf-version=4 -filetype=obj -o="src/irq_Adc0.o" -mcpu=cortex-m0plus "$<"
	@echo 'ビルド完了: $<'
	@echo ' '

src/irq_Timer.asm: ../src/irq_Timer.c
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Compiler'
	lccarm @"./src/irq_Timer.res"
	@echo 'ビルド完了: $<'
	@echo ' '

src/irq_Timer.res: src/irq_Timer.asm
src/irq_Timer.i: src/irq_Timer.asm

src/irq_Timer.o: ./src/irq_Timer.asm
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Assembler'
	llvm-mc-arm -g -dwarf-version=4 -filetype=obj -o="src/irq_Timer.o" -mcpu=cortex-m0plus "$<"
	@echo 'ビルド完了: $<'
	@echo ' '

src/main.asm: ../src/main.c
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Compiler'
	lccarm @"./src/main.res"
	@echo 'ビルド完了: $<'
	@echo ' '

src/main.res: src/main.asm
src/main.i: src/main.asm

src/main.o: ./src/main.asm
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Assembler'
	llvm-mc-arm -g -dwarf-version=4 -filetype=obj -o="src/main.o" -mcpu=cortex-m0plus "$<"
	@echo 'ビルド完了: $<'
	@echo ' '

src/setup.asm: ../src/setup.c
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Compiler'
	lccarm @"./src/setup.res"
	@echo 'ビルド完了: $<'
	@echo ' '

src/setup.res: src/setup.asm
src/setup.i: src/setup.asm

src/setup.o: ./src/setup.asm
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Assembler'
	llvm-mc-arm -g -dwarf-version=4 -filetype=obj -o="src/setup.o" -mcpu=cortex-m0plus "$<"
	@echo 'ビルド完了: $<'
	@echo ' '

src/startup_ML63Q25x7.asm: ../src/startup_ML63Q25x7.c
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Compiler'
	lccarm @"./src/startup_ML63Q25x7.res"
	@echo 'ビルド完了: $<'
	@echo ' '

src/startup_ML63Q25x7.res: src/startup_ML63Q25x7.asm
src/startup_ML63Q25x7.i: src/startup_ML63Q25x7.asm

src/startup_ML63Q25x7.o: ./src/startup_ML63Q25x7.asm
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Assembler'
	llvm-mc-arm -g -dwarf-version=4 -filetype=obj -o="src/startup_ML63Q25x7.o" -mcpu=cortex-m0plus "$<"
	@echo 'ビルド完了: $<'
	@echo ' '

src/system_ML63Q25x7.asm: ../src/system_ML63Q25x7.c
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Compiler'
	lccarm @"./src/system_ML63Q25x7.res"
	@echo 'ビルド完了: $<'
	@echo ' '

src/system_ML63Q25x7.res: src/system_ML63Q25x7.asm
src/system_ML63Q25x7.i: src/system_ML63Q25x7.asm

src/system_ML63Q25x7.o: ./src/system_ML63Q25x7.asm
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Assembler'
	llvm-mc-arm -g -dwarf-version=4 -filetype=obj -o="src/system_ML63Q25x7.o" -mcpu=cortex-m0plus "$<"
	@echo 'ビルド完了: $<'
	@echo ' '


