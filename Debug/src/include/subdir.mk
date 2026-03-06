################################################################################
# 自動生成ファイルです。 編集しないでください!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
C_SRCS += \
../src/include/global.c 

RESS += \
./src/include/global.res 

RESS__QUOTED += \
"./src/include/global.res" 

ASMS += \
./src/include/global.asm 

ASMS__QUOTED += \
"./src/include/global.asm" 

OBJS += \
./src/include/global.o 

OBJS__QUOTED += \
"./src/include/global.o" 

IS += \
./src/include/global.i 

IS__QUOTED += \
"./src/include/global.i" 


# サブディレクトリーはすべて、それ自身がコントリビュートするソースをビルドするためのルールを提供しなければなりません
src/include/global.asm: ../src/include/global.c
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Compiler'
	lccarm @"./src/include/global.res"
	@echo 'ビルド完了: $<'
	@echo ' '

src/include/global.res: src/include/global.asm
src/include/global.i: src/include/global.asm

src/include/global.o: ./src/include/global.asm
	@echo 'ビルドするファイル: $<'
	@echo '呼び出し中: Assembler'
	llvm-mc-arm -g -dwarf-version=4 -filetype=obj -o="src/include/global.o" -mcpu=cortex-m0plus "$<"
	@echo 'ビルド完了: $<'
	@echo ' '


