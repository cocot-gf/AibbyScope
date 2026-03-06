################################################################################
# 自動生成ファイルです。 編集しないでください!
################################################################################

-include ../makefile.init

RM := rm -f

# ビルドに関係するソースがすべて、ここに定義されています
-include sources.mk
-include src/subdir.mk
-include driver/src/subdir.mk
-include subdir.mk
-include objects.mk

-include ../makefile.defs

# Export environment variables
export DCL=C:/LAPIS/LEXIDE/Dcl
export INCLU8=C:/LAPIS/LEXIDE/Inc;C:/LAPIS/LEXIDE/BuildTools/Ver.20251017/Inc/Arm
export LIBU8=C:/LAPIS/LEXIDE/BuildTools/Ver.20251017/Lib/Arm
export PATH=C:/LAPIS/LEXIDE/Bin;C:/LAPIS/LEXIDE/BuildTools/Ver.20251017/Bin;C:/LAPIS/LEXIDE/Utilities/Bin

# Add inputs and outputs from these tool invocations to the build variables 
MAP += \
AibbyScope.map \

IMPLIB += \
AibbyScope_implib.o \

ELF += \
AibbyScope.elf \

ELF__QUOTED += \
"AibbyScope.elf" \

PRINT_SIZE_OUTPUT_OUTPUTS += \
AibbyScope.printsize \


# すべてのターゲット
all: $(ELF) secondary-outputs

# ツール呼び出し
AibbyScope.elf: $(OBJS)
	@echo 'ビルド・ターゲット: $@'
	@echo '呼び出し中: Linker'
	lld-arm -T"../ML63Q25x7_lccarm.ld" -L"C:/LAPIS/LEXIDE/eclipse/../BuildTools/Ver.20251017/Lib/ARM" -Map "AibbyScope.map" -o"AibbyScope.elf" -gc-sections $(OBJS__QUOTED) "" "C:\Users\cocot\lexide\workspace_omega_v2\AibbyScope\driver\lib\SolistAi_Library_1_512_64.a" -l"PL99ARMM0P.a" -l"PCRT0ARMM0P.o" -l"LCRTARMM0P.a"
	@echo 'ビルド完了ターゲット: $@'
	@echo ' '

AibbyScope.map: AibbyScope.elf $(OBJS)
AibbyScope_implib.o: AibbyScope.elf $(OBJS)

AibbyScope.printsize: $(ELF)
	@echo '呼び出し中: Print Size'
	llvm-size $(ELF__QUOTED)
	@echo 'ビルド完了: $@'
	@echo ' '

# その他のターゲット
clean:
	-$(RM) "./AibbyScope.objreader" "./driver/src/dmac0.res" "./driver/src/dmac1.res" "./driver/src/irq.res" "./driver/src/saAdc0.res" "./driver/src/timer0_1.res" "./driver/src/uartf3.res" "./driver/src/wdt.res" "./src/command.res" "./src/global.res" "./src/help.res" "./src/int_Uartf3_Stream.res" "./src/irq_Adc0.res" "./src/irq_Timer.res" "./src/main.res" "./src/setup.res" "./src/startup_ML63Q25x7.res" "./src/system_ML63Q25x7.res" "./driver/src/dmac0.asm" "./driver/src/dmac1.asm" "./driver/src/irq.asm" "./driver/src/saAdc0.asm" "./driver/src/timer0_1.asm" "./driver/src/uartf3.asm" "./driver/src/wdt.asm" "./src/command.asm" "./src/global.asm" "./src/help.asm" "./src/int_Uartf3_Stream.asm" "./src/irq_Adc0.asm" "./src/irq_Timer.asm" "./src/main.asm" "./src/setup.asm" "./src/startup_ML63Q25x7.asm" "./src/system_ML63Q25x7.asm" "./AibbyScope.hex" "./driver/src/dmac0.o" "./driver/src/dmac1.o" "./driver/src/irq.o" "./driver/src/saAdc0.o" "./driver/src/timer0_1.o" "./driver/src/uartf3.o" "./driver/src/wdt.o" 
	-$(RM) "./src/command.o" "./src/global.o" "./src/help.o" "./src/int_Uartf3_Stream.o" "./src/irq_Adc0.o" "./src/irq_Timer.o" "./src/main.o" "./src/setup.o" "./src/startup_ML63Q25x7.o" "./src/system_ML63Q25x7.o" "./driver/src/dmac0.i" "./driver/src/dmac1.i" "./driver/src/irq.i" "./driver/src/saAdc0.i" "./driver/src/timer0_1.i" "./driver/src/uartf3.i" "./driver/src/wdt.i" "./src/command.i" "./src/global.i" "./src/help.i" "./src/int_Uartf3_Stream.i" "./src/irq_Adc0.i" "./src/irq_Timer.i" "./src/main.i" "./src/setup.i" "./src/startup_ML63Q25x7.i" "./src/system_ML63Q25x7.i" "./AibbyScope.map" "./AibbyScope_implib.o" "./AibbyScope.sc" "./AibbyScope.elf" "./AibbyScope.printsize" 
	-@echo ' '

secondary-outputs: $(PRINT_SIZE_OUTPUT_OUTPUTS)

.PHONY: all clean dependents

-include ../makefile.targets
