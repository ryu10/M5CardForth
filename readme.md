# M5CardForth (alpha)

[EN|[日本語](readmeJa.md)]

![M5CardForth](media/M5CardForth.png)

## Summary 

A simple console for M5Cardputer + ESP32forth.

The current release is alpha.

The following components are roughly combined:

* [ueforth](https://github.com/flagxor/ueforth)
* [M5Cardputer](https://github.com/m5stack/M5Cardputer)
* [LovyanGFX](https://github.com/lovyan03/LovyanGFX)
* [FastLED](https://github.com/FastLED/FastLED)

Build / flash the project with [Platformio](https://platformio.org/).

## Console

At startup, the console reads from the USBSerial input. Open `PlatformIO : Serial Console` and type on your computer. To use the M5Cardputer keyboard, type `m5key-on`. 

The following words can be used to switch the console I/O : `m5key-on m5key-off m5type-on m5type-off`

### Using M5Cardputer standalone

To use the M5CardForth standalone, without serial, follow the steps:

1. Do either:
 * Turn M5Cardputer power switch on, or, 
 * press and relase the button `BtnRst` (at the top-left of M5Cardputer).
2. Immediately after you complete Step 1, press `BtnG0` (top-right). 
3. After prompt `ok` is displayed, you may release `BtnG0`.

Both the M5Cardputer keyboard and console output will be enabled.

## Cardputer keyboard

Supported keys:

* Alphanumeric and symbols
* `Shift`
* `Enter` and `BS`

The `ctrl`/`opt`/`alt`/`fn`/`esc` keys do not work.

## Sample programs

[forth/fastLed.fs](forth/fastLed.fs) 

[forth/lgfx.fs](forth/lgfx.fs)

[forth/M5StampS3-gpio.fs](forth/M5StampS3-gpio.fs) 

## Additional words

In addition to ESP32Forth standard words, several new words are defined to access the M5cardputer features. Currently under development, the specs will be changed in the future.

-> ([See this page](cpwords.md))

## SD Card support

Use the ESP32Forth `SD` vocabulary.

![SDUsage](media/sdusage.png)

### Example: block editor 

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

Note ```visual editor``` does not work with SD.

### Using `/spiffs/autoexec.fs`

You may copy [forth/autoexec.fs](forth/autoexec.fs) to `/spiffs/autoexec.fs` (via an SD card), then the contents of the file will be automatically executed at startup. Type the following to run a demo.

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