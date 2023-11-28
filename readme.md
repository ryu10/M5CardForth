# M5CardForth (beta)

[EN|[JA](readmeJa.md)]

![M5CardForth](media/M5CardForth.png)

## Summary 

A simple console for ESP32forth.
The following components are roughly combined:

* [ueforth](https://github.com/flagxor/ueforth)
* [M5Cardputer](https://github.com/m5stack/M5Cardputer)
* [LovyanGFX](https://github.com/lovyan03/LovyanGFX)
* [FastLED](https://github.com/FastLED/FastLED)

Build / flash the project with [Platformio](https://platformio.org/).

## Console

At startup, the console reads USBSerial. Open PlatformIO : Serial Console and type from your computer. 

To use the M5Cardputer keyboard, type `m5key-on`. 

The following words can be used to switch the console I/O : `m5key-on m5key-off m5type-on m5type-off`

Supported keys:

* Alfa-numeric and symbols
* `Shift`
* `Enter` and `BS`

The ctrl/opt/al/fn/esc keys do not work.

## Add'l Internal words

```
( Cardupter console )
m5type-on ( -- ) ( use Cardputer display )
m5type-off ( -- ) ( use serial output )
m5key-on ( -- ) ( use Cardputer keyboard )
m5key-off ( -- ) ( use serial input )
m5-key ( -- n ) 
m5-key? ( -- n )
m5-type ( a n -- ) 

( RGB Led : FastLED library )
showLeds ( n n n -- )
offLED ( -- )
redLED ( -- )
greenLED ( -- )
blueLED ( -- )
whiteLED ( -- )

(Arduino enhancement)
delay ( n -- )
``` 

## Todo

* switch console/serial ✅
* rgb led ✅
* backspace ✅
* graphics 
* sd card
* sound 
* mic
* ir
* (clock)
* (wifi)


Have fun.