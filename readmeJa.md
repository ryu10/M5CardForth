# M5CardForth (beta)

[[EN](readme.md)|JA]

![M5CardForth](media/M5CardForth.png)

## 概要

M5Cardputer を使って ESP32forth コンソールをざっくり作っています。
まだ作業中なので仕様はどんどん変わります。

以下のコンポーネントを使用しています。

* [ueforth](https://github.com/flagxor/ueforth)
* [M5Cardputer](https://github.com/m5stack/M5Cardputer)
* [LovyanGFX](https://github.com/lovyan03/LovyanGFX)
* [FastLED](https://github.com/FastLED/FastLED)

プロジェクトは [Platformio](https://platformio.org/) でビルド、書き込みしてください。

## コンソール

初期状態で入力は Platformio Serial Monitor コンソール、出力は M5Cardputer ディスプレイです。Platformio の Serial Monitor コンソールウィンドウ内をクリックしてからコンピュータのキーボードを使って入力します。

`m5key-on` と入力すると M5Cardputer キーボードに切り替わります。

## Cardputer キーボード

以下のキーが使えます。

* 英数文字および記号入力キー
* `Shift` キー ('`Aa`')
* `Enter` キーと `BS` キー

ctrl/opt/al/fn/esc キーは機能しません。

## サンプルコード

[forth/fastLeds.fs](forth/fastLeds.fs) : RGB LED をいじるやつ

[forth/lgfx.fs](forth/fastLeds.fs) : LovyanGFX でグラフィックス表示

[forth/M5StampS3-gpio.fs](forth/M5StampS3-gpio.fs) : Grove PortA の G1 と G2 を制御

Serial Monitor コンソールにコピペしてください。入力バッファに上限があるため大量のテキストを一度に貼り付けられません。複数回に分けてコピペします。

## 追加 Forth ワード

各コンポーネントの機能を呼び出しているだけです。作者は Forth 初学者のためワード定義の記述や配置があまりうまくありません。将来はもっと整理します。

-> ([See this page](cpwords.md))

## Todo

* switch console/serial ✅
* rgb led ✅
* backspace ✅
* graphics ✅
* sd card
* sound 
* mic
* (ir)
* (clock)
* (wifi)


Have fun.