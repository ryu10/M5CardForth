#include <memory>
#include <M5Unified.h>
#include "utility/Keyboard/Keyboard.h"
#include "utility/Keyboard/KeyboardReader/TCA8418.h"
#include "utility/Keyboard/KeyboardReader/IOMatrix.h"
#include "keyboard_factory.h"

// Global model detected at startup. Use accessor or read directly.
CardputerModel g_cardputer_model = CARDUPTER_UNKNOWN;

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
// Prefer using the library's Adafruit_TCA8418::begin() detection instead
// of a raw Wire probe so we reuse the library's initialization logic.
std::unique_ptr<KeyboardReader> createKeyboardReader() {
       // The ADV hardware uses these pins for I2C / IRQ on Cardputer-ADV.
       // modified for the external 'calc-keyboard' connected at the port2 header. 
       // constexpr int ADV_SDA = 8;
       // constexpr int ADV_SCL = 9;
       // constexpr int ADV_IRQ = 11;
       constexpr int ADV_SDA = 13;
       constexpr int ADV_SCL = 15;
       constexpr int ADV_IRQ = 5;

       // Configure M5.In_I2C to the ADV pins so the Adafruit driver uses them.
       M5.In_I2C.setPort(I2C_NUM_0, ADV_SDA, ADV_SCL);
       M5.In_I2C.begin(I2C_NUM_0, ADV_SDA, ADV_SCL);

       // Try to initialize the Adafruit TCA8418 device using its begin().
       // This reuses the library detection (and avoids duplicating raw I2C probe logic).
       {
              Adafruit_TCA8418 probeDev;
              if (probeDev.begin()) {
                     // Device present and initialized.
                     g_cardputer_model = CARDUPTER_ADV;
                     return createTCA8418Reader(ADV_IRQ, ADV_SDA, ADV_SCL);
              }
       }

       // Not present — assume v1.1 matrix keyboard.
       g_cardputer_model = CARDUPTER_V11;
       return std::unique_ptr<KeyboardReader>(new IOMatrixKeyboardReader());
}
