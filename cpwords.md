# Additional words for M5CardPuter

```
( Cardupter console )
m5type-on ( -- ) ( use Cardputer display )
m5type-off ( -- ) ( use Serial output )
m5key-on ( -- ) ( use Cardputer keyboard )
m5key-off ( -- ) ( use Serial input )
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

( Display : LovyanGFX )
: m5gfx-on ( -- ) 1 m5gfxVisible ;
: m5gfx-off ( -- ) 0 m5gfxVisible ;
: home ( -- ) m5Home ;
: locate ( n n -- ) m5SetCursor ;
: gcls ( -- ) 0 m5gfxFillScreen ;
: palette ( n n n n -- ) m5gfxSetPaletteColor ;
: fillscreen ( n -- ) m5gfxFillScreen ;
: screenUpdate ( -- ) lcdUpdate ;
: pset ( n n n -- ) m5gfxPset ;
: vline ( n n n n -- ) m5gfxDrawFastVLine ;
: hline ( n n n n -- ) m5gfxDrawFastHLine ;
: rect ( n n n n n -- ) m5gfxDrawRect ;
: frect ( n n n n n -- ) m5gfxFillRect ;
: rrect ( n n n n n n -- ) m5gfxDrawRoundRect ;
: frrect ( n n n n n n -- ) m5gfxFillRoundRect ;
: circle ( n n n n -- ) m5gfxDrawCircle ;
: fcircle ( n n n n -- ) m5gfxFillCircle ;
: ellipsis ( n n n n n -- ) m5gfxDrawEllipse ;
: fellipsis ( n n n n n -- ) m5gfxFillEllipse ;
: line ( n n n n n -- ) m5gfxDrawLine ;
: triangle ( n n n n n n n -- ) m5gfxDrawTriangle ;
: ftriangle ( n n n n n n n -- ) m5gfxFillTriangle ;
: bezier ( n n n n n n n -- ) m5gfxDrawBezier ;
: bezier4 ( n n n n n n n n n -- ) m5gfxDrawBezier4 ;
: arc ( n n n n n n n -- ) m5gfxDrawArc ;
: farc ( n n n n n n n -- ) m5gfxFillArc ;

( Arduino enhancement )
delay ( n -- )
``` 
