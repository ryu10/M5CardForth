1 constant G1 ( Grove PortA G1 )
2 constant G2 ( Grove PortA G2 )
G1 OUTPUT pinMode
G2 OUTPUT pinMode

: led-off G1 0 digitalWrite ; ( G1 goes 0 V )
: led-on G1 1 digitalWrite ; ( G1 goes 3.3 V )
