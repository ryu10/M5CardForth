vocabulary m5demo m5demo definitions

( fastLed )
( addLeds is done during sytem startup )
: offLED ( -- ) 0 0 0 showLeds ;
: redLED ( -- ) 200 0 0 showLeds ;
: greenLED ( -- ) 0 200 0 showLeds ;
: blueLED ( -- ) 0 0 200 showLeds ;
: whiteLED ( -- ) 200 200 200 showLeds ;

: 3dup dup >r rot rot  dup >r rot rot dup >r rot rot r> r> r> ;
: flashLED ( n n n -- ) 64 0 do 3dup i 64 */ rot i 64 */ rot i 64 */ rot showLeds 10 delay loop 64 0 do 3dup 64 i - 64 */ rot 64 i - 64 */ rot 64 i - 64 */ rot showLeds 10 delay loop drop drop ;
: flashLEDgo ( -- ) 2 0 do 2 0 do 2 0 do i 255 * j 255 * k 255 * flashLED loop loop loop ;

( gfx )
: vgrad 231 0 do i 0 127 i 255 16 - 232 */ 16 + vline loop screenUpdate ;
: hgrad 127 0 do 0 i 231 i 255 16 -  128 */ 16 + hline loop screenUpdate ;
: go home gcls m5gfx-on screenUpdate 500 delay vgrad 500 delay hgrad 500 delay ;
 0 0 0 0 palette
 1 127 0 0 palette
  2 0 127 0 palette
 3 127 127 0 palette
 4 0 0 127 palette
 5 127 0 127 palette
 6 0 127 127 palette
 7 127 127 127 palette

 9 255 0 0 palette
 10 0 255 0 palette
 11 255 255 0 palette
 12 0 0 255 palette
 13 255 0 255 palette
 14 0 255 255 palette
 15 255 255 255 palette

: mbox 7 0 do 0 0 100 i 12 * - dup i frect loop screenUpdate ;
: bullseye 7 0 do 134 64 60 i 8 * - i 8 + fcircle loop screenUpdate ;
: moire 50 0 do 231 0 131 i 2 * 80 line screenUpdate loop  51 0 do 231 0 131 i 2 * + 100 80 line screenUpdate loop ;

: go2 m5gfx-on gcls go bullseye 500 delay mbox 500 delay moire 500 delay 3 0 do ." Hello " i . cr loop ;

( gpio )
0 constant G0 ( Cardputer Button B0 )
1 constant G1 ( Grove PortA G1 )
2 constant G2 ( Grove PortA G2 )
G0 INPUT pinMode
G1 OUTPUT pinMode
G2 OUTPUT pinMode

: led-off G1 0 digitalWrite ; ( G1 goes 0 V )
: led-on G1 1 digitalWrite ; ( G1 goes 3.3 V )
: button? ( -- n ) G0 digitalRead 0 = if 1 else 0 then ;

hex
: gogpio 0 0 do 2 60004008 L! 2 6000400C L! 0 +loop ;
decimal

forth definitions