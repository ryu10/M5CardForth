#include <memory>
#include <M5Unified.h>
#include "utility/Keyboard/Keyboard.h"
#include "utility/Keyboard/KeyboardReader/TCA8418.h"

std::unique_ptr<KeyboardReader> createTCA8418Reader(int irq, int sda, int scl) {
       // debug print removed to reduce startup noise
       // Ensure M5Unified I2C instance uses the same pins as Wire so the
       // Adafruit_TCA8418 driver (which calls M5.In_I2C) can communicate.
       M5.In_I2C.setPort(I2C_NUM_0, sda, scl);
       M5.In_I2C.begin(I2C_NUM_0, sda, scl);
       return std::unique_ptr<KeyboardReader>(new TCA8418KeyboardReader(irq));
}
