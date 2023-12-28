# M5CardForth (alpha)

[[EN](readme.md)|JA]

![M5CardForth](media/M5CardForth.png)

## 概要

M5Cardputer を使って ESP32forth コンソールを作っています。
まだ作業中なので仕様は頻繁に変更されます。

以下のコンポーネントを使用しています。

* [ueforth](https://github.com/flagxor/ueforth)
* [M5Cardputer](https://github.com/m5stack/M5Cardputer)
* [LovyanGFX](https://github.com/lovyan03/LovyanGFX)
* [FastLED](https://github.com/FastLED/FastLED)

プロジェクトは [Platformio](https://platformio.org/) でビルド、書き込みできます。

## コンソール

初期状態で入力は Platformio Serial Monitor コンソール、出力は M5Cardputer ディスプレイです。Platformio の Serial Monitor コンソールウィンドウ内をクリックしてからコンピュータのキーボードを使って入力します。

`m5key-on` と入力すると M5Cardputer キーボードに切り替わります。

## Cardputer キーボード

以下のキーが使えます。

* 英数文字および記号入力キー
* `Shift` キー ('`Aa`')
* `Enter` キーと `BS` キー

`ctrl`/`opt`/`alt`/`fn`/`esc` キーは機能しません。

## サンプルコード

[forth/fastLed.fs](forth/fastLed.fs) : RGB LED の操作

[forth/lgfx.fs](forth/lgfx.fs) : LovyanGFX でグラフィックス表示

[forth/M5StampS3-gpio.fs](forth/M5StampS3-gpio.fs) : Grove PortA の G1 と G2 を制御

Serial Monitor コンソールにコピペして使います。入力バッファに上限があるためコンソールには大量のテキストを一度に貼り付けられません。複数回に分けてコピペしてください。

## 追加 Forth ワード

各コンポーネントの機能を呼び出します。作者が Forth 初学者のためワード定義の記述や配置はあまりまとまっていません。今後整理します。

-> ([See this page](cpwords.md))

## SD カードサポート

ESP32Forth の ```SD``` ボキャブラリを使用します。

![SDUsage](media/sdusage.png)

### ブロックエディタ使用例

```
sd
sd.begin
use /sd/myblk
s" /sd/myblk" open-blocks
editor
0 a : hi ." Howdy!" ;
update
save-buffers
0 load hi
```

```visual editor /sd``` は動きません。 

### /spiffs/autoexec.fs の使用

本リポジトリ `src/autoexec.fs` を SD カード経由で `/spiffs/autoexec.fs`にコピーすると ESP32Forth 起動時に自動実行されます。`src/autoexec.fs` には上記サンプルコードの内容が `m5demo` ボキャブラリとして記述されています。

```
m5demo
go2
```

## Todo

* switch between Cardputer console and serial ✅
* rgb led ✅
* backspace ✅
* graphics ✅
* sd card ✅
* sound 
* mic
* (ir)
* (clock)
* (wifi)

Have fun.