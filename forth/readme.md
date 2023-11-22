# Forth Tutorial

Tutorial based on https://esp32forth.forth2020.org/home、but on the ESP32C3 / M5Stamp / M5Cardputer

1. Digital read/write from a register

ESP32-WROOM ボードのとおりだと次のコードでうごく。

```
HEX
03FF44004 CONSTANT GPIO-OUTREG
: LED-OFF 0 GPIO-OUTREG L! ;
: LED-ON  4 GPIO-OUTREG L! ;
```

しかし上のコードは esp32-s3 (M5Stamp) では動かない。GPIO アドレスが違うようだ。そうすろと gpio レジスタのアドレス値をいちいち調べる必要があるが esp32 (wroom) と esp32-s3 それぞれについて明記された資料はないらしい

いっそ digitalWrite をマップしてしまえばいいのだ -> いやもうあるよ？

```
  Y(pinMode, pinMode(n1, n0); DROPn(2)) \
  Y(digitalWrite, digitalWrite(n1, n0); DROPn(2)) \
  Y(digitalRead, n0 = digitalRead(n0)) \
```

プログラムはこうなる

```
1 constant LED
2 constant OUTPUT
LED OUTPUT pinMode
: LED-OFF LED 0 digitalWrite ;
: LED-ON LED 1 digitalWrite ;
```

これで Grove Port A の G1 ピンをオン・オフできる。G2 ピンも同様。

2. RGB Digtal driver for M5Stamp

M5Stamp C3 の三色 LED を制御する

1. プロジェクトに FastLED ライブラリを追加
2. main.cpp 冒頭に次のコードを追加


```
/* For M5 CardUpter */
#define CONFIG_IDF_TARGET_ESP32S3
#include <FastLED.h>
#define PIN_LED    21   // G21
#define NUM_LEDS   1
CRGB leds[1];

void addLeds(void){
  FastLED.addLeds<WS2812B, PIN_LED, GRB>(leds, NUM_LEDS); 
}
```

" `#define REQUIRED_ARDUINO_GPIO_SUPPORT \` " ブロックの下辺りに次のコードを追加

```
#define OPTIONAL_FAST_LED \
  Y(addLeds, addLeds()) \
  Y(showLeds, leds[0] = CRGB(n2, n1, n0); FastLED.show(); DROPn(3))
```

ここで読み込む

```
  REQUIRED_ARDUINO_GPIO_SUPPORT \
  OPTIONAL_FAST_LED \
```

ビルド、書き込みして `fastLeds.fs` を読み込む。以下のワードが使えるようになる

`showLeds ( r g b -- )`

`redLED greenLED blueLED whiteLED offLED`