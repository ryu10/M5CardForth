0 constant G0 ( Cardputer Button B0 )
1 constant G1 ( Grove PortA G1 )
2 constant G2 ( Grove PortA G2 )
G0 INPUT pinMode
G1 OUTPUT pinMode
G2 OUTPUT pinMode

: led-off G1 0 digitalWrite ; ( G1 goes 0 V )
: led-on G1 1 digitalWrite ; ( G1 goes 3.3 V )
: button? ( -- n ) G0 digitalRead 0 = if 1 else 0 then ; 

( Caution: the following words go into infinite loops )

: go 0 0 do button? . cr 0 +loop ;

: go1 0 0 do led-off led-on 0 +loop ;

( ESP32-S3 HW ACCESS )
( GPIO BASE ADDRESS = 0x60004000 )
( GPIO_OUT_W1TS_REG = 0x0008 ; bit set, GPIO0 = 1 )
( GPIO_OUT_W1TC_REG = 0x000C ; bit clear, GPIO0 = 1 )
( GPIO_OUT_DATA_ORIG = 0x0004 ; to read the value )
hex
: go2 0 0 do 2 60004008 L! 2 6000400C L! 0 +loop ;
decimal 
