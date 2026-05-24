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


## プログラムの内容について
プログラムの動作はZennで解説しています。  
興味がある方はそちらをご確認ください。

[Q2557-11:ハードウェアFFT内蔵マイコンでスペアナを作る・ハード解説](https://zenn.dev/gadget_factory/articles/8f2e3d11bc3816)

[Q2557-12:ハードウェアFFT内蔵マイコンでスペアナを作る・ソフト解説](https://zenn.dev/gadget_factory/articles/86c3ef48f24fdd)
