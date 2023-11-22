addLeds
: offLED 0 0 0 showLeds ;
: redLED 200 0 0 showLeds ;
: greenLED 0 200 0 showLeds ;
: blueLED 0 0 200 showLeds ;
: whiteLED 200 200 200 showLeds ;
 : flashall 16 0 do 16 0 do 16 0 do i 16 * dup . j 16 * dup . k 16 * dup . cr showLeds loop loop loop ;