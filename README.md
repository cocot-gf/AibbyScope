# AibbyScope
「AibbyScope」はローム製AIアクセラレータ付きマイコンML63Q2500シリーズを使ったスペクトラムアナライザです。
オーディオ帯域のアナログ信号をマイコン内蔵ADCでサンプリングし、FFTの結果をオシロスコープやPC上に表示させます。

動作ハードウェアは(株)データ・テクノで販売されているSolist-AIマイコン ブレークアウトボード「[AIBBY](https://www.datatecno.co.jp/prod_info/dt-bbml63q2557/)」をはじめ、
評価ボード「[DT-EBML63Q2557](https://www.datatecno.co.jp/prod_info/solistai_board/)」や(株)ローム製 リファレンスボード「[RB-D63Q2557TB64](https://ros.rohm.co.jp/product/rbd63q2557tb64evk/01tRC00000BcvYPYAZ)」で動作します。

人目を引くちょっとしたお遊びに、音楽再生中のインテリアに、1台作ってみませんか？

[![Youtube](https://github.com/user-attachments/assets/3bf2b3cd-ec55-4929-a7e0-7f8a2fe3e476)](https://youtu.be/u3YaAkrQtn4)
<img width="450" alt="DSC01845" src="https://github.com/user-attachments/assets/5647e19d-46f5-40ef-967e-c309cc95a5ea" />
<img width="450" alt="DSC01844" src="https://github.com/user-attachments/assets/843fcaff-a7aa-4d2d-9da3-da312cc73ab1" />
<img alt="AibbyScope" src="https://github.com/user-attachments/assets/f834b8ca-0777-4cc3-afa0-10c650fb751e" />

## システム構成
AIBBYとロームのリファレンスボードはCPU単体製品のため、外部に入力アンプと出力用のインターフェースが必要です。
  
データ・テクノの評価ボードには入力アンプとFT2232Hが搭載されているのでボード単体で使用できます。  
ただしこちらの製品はDACへの出力ポート数が不足しているため、オシロスコープへの表示はできません。

<img width="787" height="413" alt="block" src="https://github.com/user-attachments/assets/c485d6cb-4a51-47a4-8fa8-267b6a63afe8" />

## プログラム構成
### [AibbyScope](AibbyScope/README.md)
AIBBY用ファームウェア
  
ローム製リファレンスボード「RB-D63Q2557TB64」はピンの構成が異なるため、基板に合わせたプログラムの移植作業が必要です。
  
### [AibbyScopeDT](AibbyScopeDT/README.md)
データ・テクノ製「DT-EBML63Q2557」への移植版ファームウェア
  
このボードはDACへの出力ポート数が不足しているためオシロスコープへの表示機能を削除しています。  
さらに、基板を改造してSPIの転送タイミング通知用の配線を1本追加しないと動作しません。

### [AibbyScopeViewer](AibbyScopeViewer/README.md)
Windows用 表示ソフトウェア  
  
FTDIの通信インターフェースFT232H/FT2232H/FT4232Hのどれかを使ってPCと接続します。 

## 参考回路図
### 入力アンプ
サンプリング周波数が可変なので、申し訳程度の緩いフィルタを入れてあります。
C2があるのでDC入力はできません。無入力時にADCへ1.65Vが入力されるようにVR1を調整します。  

<img width="733" height="360" alt="Untitled" src="https://github.com/user-attachments/assets/27c88915-b414-4804-939b-c1ca5a17325d" />

データ・テクノ製の評価ボードも回路図が公開されていて、fc=10kHzで強めのフィルタが入ってるのとゲインが可変できるようなので、そちらの回路を参考にするとよいかもしれません。

### CPU入出力
ブレークアウトボードAIBBYを使った場合の接続例です。
<img width="730" height="400" alt="Untitled" src="https://github.com/user-attachments/assets/aab1cae5-b9cb-4283-ac1e-cd8ac55ca403" />

| ピン名 | 用途 |
|-|-|
| P52 | ADC入力 |
| P40-P47 | R-2R DAC出力 |
| P84,P85 | UART入出力 |
| P32-P35 | SPI入出力 |
| P36 | 同期信号 |

同期信号はR-2Rの描画開始直前にHIGH、R-2Rの描画終了直後にLOWになり、HIGHの期間は10msです。

SPIはスレーブデバイスとして動作していて、R-2Rで出力する画像データをバイナリで取得可能です。データの有効期間は同期信号がHIGHの時だけなので、SPI読み取り前後にGPIOでHIGHである事を確認できれば、データが有効である証明になります。

# ターミナル上のキーアサイン
値指定があるものはスペースを空けずに数値を入力後に改行コードCRで受け入れます。
| KEY | 役割 |
|---|---|
| w | 波形表示 |
| f | FFT表示 |
| r ( ) | サンプリングレート値指定 または 現在の設定÷2、×2 |
| s < > | サンプル数値指定 または 現在の設定÷2、×2 |
| q - + | FFT入力波形のゲイン値指定 または 現在の設定－1、＋1 |
| n h | FFT前の窓関数 n:矩形窓 h:ハニング窓 |
| l b | FFTの表示方法 l:リニア画像表示 b:bfloat16生データ |
| d | ドットクロック タイミング調整値 |
| t | VSYNCタイミング調整値 |
| x | エコーバック・ヘルプ表示抑制 ESCか?で復帰 |
| c | 動作状況文字列取得 |
| ? | ヘルプ表示 |
| SPACE | サンプリング一時停止・再開 |
| ESC | デフォルト設定に戻す |

## 機能仕様
#### 信号入力
* 0～3.3Vアナログ入力×1チャンネル
* ADC：マイコン内蔵の12bit SAR ADC
* アンチエイリアスフィルタ：入力アナログアンプに依存
#### 表示出力
* 表示リフレッシュレート：50Hz固定
* DAC/PC同時表示可能
* DAC出力：8bitパラレル R-2Rラダー
* PC出力：SPIスレーブとして動作 クロック3～12MHz
#### 内部処理
* サンプリングレート：250Hz～50kHz 1Hz刻みの任意設定
* 波形バッファ：16bit×1024サンプル 2KB オーバーラップ処理あり
* FFTバッファ：16bit×1024サンプル 2KB
* 表示バッファ：8bit×1024サンプル または 対数表示用 16bit×1024サンプル 合計2KB(共用体)
* 対数表示：PC出力時のみ表示可能、bfloat16のバイナリデータを転送しPC側でlog10処理
* 動作設定方法：TeraTerm等のターミナルソフトで操作可能、UART 115200,8n1

## FAQ
#### 波形表示中に20ms周期でノイズが見える
ブレッドボードで回路を組んだときなど、GNDが弱くアナログ入力系統とSPI信号がクロストークを起こしている時に発生します。
オシロスコープ表示のみで動作している時には発生しません。

#### データ・テクノ製DT-EBML63Q2557評価ボードで動作させるとノイズが多い
ADCのVREFにつながっている3.3V系統の電圧生成にスイッチングレギュレータが使われているため全体的にノイジーです。
