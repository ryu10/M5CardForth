: vgrad 231 0 do i 0 127 i 255 16 - 232 */ 16 + vline loop screenUpdate ;
: hgrad 127 0 do 0 i 231 i 255 16 -  128 */ 16 + hline loop screenUpdate ;
: go home gcls m5gfx-on screenUpdate 500 delay vgrad 500 delay hgrad 500 delay ;
0 0 0 0 palette \
1 127 0 0 palette \
2 0 127 0 palette \
3 127 127 0 palette \
4 0 0 127 palette \
5 127 0 127 palette \
6 0 127 127 palette \
7 127 127 127 palette

9 255 0 0 palette \
10 0 255 0 palette \
11 255 255 0 palette \
12 0 0 255 palette \
13 255 0 255 palette \
14 0 255 255 palette \
15 255 255 255 palette 
: mbox 7 0 do 0 0 100 i 12 * - dup i frect loop screenUpdate ;
: bullseye 7 0 do 134 64 60 i 8 * - i 8 + fcircle loop screenUpdate ;
: moire 50 0 do 231 0 131 i 2 * 80 line screenUpdate loop  51 0 do 231 0 131 i 2 * + 100 80 line screenUpdate loop ;

m5gfx-on go bullseye 500 delay mbox 500 delay moire 3000 delay
