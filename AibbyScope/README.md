# AibbyScope LEXIDE-Ω用ソースツリー

## ビルド環境
* LEXIDE-Ω Version: 2.1.0 
* ARM.CMSIS: 6.3.0、6.x系なら使用可能

## 対象ボード
* (株)データ・テクノ製 AIBBY

(株)ローム製 RB-D63Q2557TB64では以下のポートが予約済みのため割り当て変更が必要です。

| AibbyScopeでの想定 | RB-D63Q2557TB64 | 用途 |
|-|-|-|
| P52 | P32-P35のどれか | アナログ入力 |
| P32-P35 | P60-P63 | SPI |
| P72 | P52 | モニターLED |
