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
### AibbyScope
AIBBY用ファームウェア  
※ローム製リファレンスボード「RB-D63Q2557TB64」はピンの構成が異なるため、基板に合わせたプログラムの移植作業が必要です。
  
### AibbyScopeDT
データ・テクノ製「DT-EBML63Q2557」への移植版ファームウェア  
※このボードはDACへの出力ポート数が不足しているためオシロスコープへの表示機能を削除しています。

### AibbyScopeViewer
Windows用 表示ソフトウェア

## マニュアル
* 準備中

## 回路図
* 準備中

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
