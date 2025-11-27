#include <memory>
#include <Wire.h>
#include <M5Unified.h>
#include "utility/Keyboard/Keyboard.h"
#include "utility/Keyboard/KeyboardReader/TCA8418.h"
#include "utility/Keyboard/KeyboardReader/IOMatrix.h"
#include "keyboard_factory.h"

// Global model detected at startup. Use accessor or read directly.
CardputerModel g_cardputer_model = CARDUPTER_UNKNOWN;

static const uint8_t TCA8418_ADDR = 0x34; // matches TCA8418_DEFAULT_ADDR in Adafruit header

// Create a reader using the TCA8418 driver.  We set the M5.In_I2C
// port to the application pins before constructing the driver so it
// uses the expected SDA/SCL.
std::unique_ptr<KeyboardReader> createTCA8418Reader(int irq, int sda, int scl) {
       // Ensure M5Unified I2C instance uses requested pins so the
       // Adafruit_TCA8418 driver (which calls m5::In_I2C) can communicate.
       M5.In_I2C.setPort(I2C_NUM_0, sda, scl);
       M5.In_I2C.begin(I2C_NUM_0, sda, scl);
       return std::unique_ptr<KeyboardReader>(new TCA8418KeyboardReader(irq));
}

// Application-level factory: detect whether TCA8418 is present on I2C.
// If present, return an ADV/TCA-based reader; otherwise return
// the library IOMatrix reader (v1.1 matrix keyboard).
std::unique_ptr<KeyboardReader> createKeyboardReader() {
       // The ADV hardware uses these pins for I2C / IRQ on Cardputer-ADV.
       constexpr int ADV_SDA = 8;
       constexpr int ADV_SCL = 9;
       constexpr int ADV_IRQ = 11;

       // Try a lightweight I2C probe on the expected address.
       // Use Wire to probe; do not permanently reconfigure global I2C here.
       Wire.begin();
       Wire.beginTransmission(TCA8418_ADDR);
       int res = Wire.endTransmission();
       if (res == 0) {
              // Device responded — treat as ADV.
              g_cardputer_model = CARDUPTER_ADV;
              return createTCA8418Reader(ADV_IRQ, ADV_SDA, ADV_SCL);
       }

       // Not present — assume v1.1 matrix keyboard.
       g_cardputer_model = CARDUPTER_V11;
       return std::unique_ptr<KeyboardReader>(new IOMatrixKeyboardReader());
}
