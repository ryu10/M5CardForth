// keyboard_factory.h
#pragma once
#include <memory>
#include "utility/Keyboard/Keyboard.h"
// keyboard_factory.h
#pragma once
#include <memory>
#include "utility/Keyboard/Keyboard.h"

typedef enum {
  CARDUPTER_UNKNOWN = 0,
  CARDUPTER_ADV,
  CARDUPTER_V11,
} CardputerModel;

extern CardputerModel g_cardputer_model;

// Create a keyboard reader appropriate for the detected hardware.
std::unique_ptr<KeyboardReader> createKeyboardReader();
