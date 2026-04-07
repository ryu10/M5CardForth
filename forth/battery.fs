\ GPIO 10 is connected to the battery voltage divider, which is used to measure the battery voltage.
10 constant BATTERY_PIN
\ the full battery level - it depends on the battery on your CardPuter.
2502 constant BATTERY_FULL
\ the empty battery level - it depends on the battery on your CardPuter.
1937 constant BATTERY_EMPTY

\ note this is a very rough estimation of the battery level, it may not be accurate and may need calibration for your specific battery and voltage divider.
: get-battery-level ( -- n )
BATTERY_PIN analogRead BATTERY_EMPTY - 100 BATTERY_FULL BATTERY_EMPTY - */ 
;