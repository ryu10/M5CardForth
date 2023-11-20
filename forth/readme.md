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





