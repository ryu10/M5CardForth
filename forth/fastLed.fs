( addLeds is done during sytem startup )
: offLED ( -- ) 0 0 0 showLeds ;
: redLED ( -- ) 200 0 0 showLeds ;
: greenLED ( -- ) 0 200 0 showLeds ;
: blueLED ( -- ) 0 0 200 showLeds ;
: whiteLED ( -- ) 200 200 200 showLeds ;

: 3dup dup >r rot rot  dup >r rot rot dup >r rot rot r> r> r> ;
: flashLED ( n n n -- ) 64 0 do 3dup i 64 */ rot i 64 */ rot i 64 */ rot showLeds 10 delay loop 64 0 do 3dup 64 i - 64 */ rot 64 i - 64 */ rot 64 i - 64 */ rot showLeds 10 delay loop drop drop drop ;
: flashLEDgo ( -- ) 2 0 do 2 0 do 2 0 do i 255 * j 255 * k 255 * flashLED loop loop loop ;
