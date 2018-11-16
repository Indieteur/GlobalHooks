using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalHooks
{
    /// <summary>
    /// List of KeyCodes that is independent of the configuration of the system of the user. (as opposed to Hardware Scancodes)
    /// </summary>
    public enum VirtualKeycodes    //We create a human understandable enumeration of Virtual Key Codes without having to reference System.Windows.Forms
    {
        /// <summary>
        /// The Backspace Key.
        /// </summary>
        Backspace = 0x08,
        /// <summary>
        /// The Tab Key.
        /// </summary>
        Tab = 0x09,
        /// <summary>
        /// The Clear Key.
        /// </summary>
        Clear = 0x0C,
        /// <summary>
        /// The Return or Enter Key.
        /// </summary>
        Enter = 0x0D,
        /// <summary>
        /// The Shift Key (Left or Right).
        /// </summary>
        Shift = 0x10,
        /// <summary>
        /// The Control Key (Left or Right).
        /// </summary>
        Control = 0x11,
        /// <summary>
        /// The Alt Key (Left or Right).
        /// </summary>
        Alt = 0x12,
        /// <summary>
        /// The Pause Key
        /// </summary>
        Pause = 0x13,
        /// <summary>
        /// The Capslock key.
        /// </summary>
        Capslock = 0x14,
        /// <summary>
        /// IME Kana mode.
        /// </summary>
        Kana = 0x15,
        /// <summary>
        /// IME Hanguel mode. 
        /// </summary>
        Hanguel = 0x15,
        /// <summary>
        /// IME Hangul mode. 
        /// </summary>
        Hangul = 0x15,
        /// <summary>
        /// IME Junja mode.
        /// </summary>
        Junja = 0x17,
        /// <summary>
        /// IME final mode.
        /// </summary>
        Final = 0x18,
        /// <summary>
        /// IME Hanja mode.
        /// </summary>
        Hanja = 0x19,
        /// <summary>
        /// IME Kanji mode.
        /// </summary>
        Kanji = 0x19,
        /// <summary>
        /// Esc or Escape key.
        /// </summary>
        Esc = 0x1B,
        /// <summary>
        /// IME convert.
        /// </summary>
        Convert = 0x1C,
        /// <summary>
        /// IME nonconvert.
        /// </summary>
        NonConvert = 0x1D,
        /// <summary>
        /// IME accept.
        /// </summary>
        Accept = 0x1E,
        /// <summary>
        /// IME mode change request.
        /// </summary>
        ModeChange = 0x1F,
        /// <summary>
        /// The Spacebar key.
        /// </summary>
        Space = 0x20,
        /// <summary>
        /// The Page Up key.
        /// </summary>
        PageUp = 0x21,
        /// <summary>
        /// The Page Down key.
        /// </summary>
        PageDown = 0x22,
        /// <summary>
        /// The End key.
        /// </summary>
        End = 0x23,
        /// <summary>
        /// The Home key.
        /// </summary>
        Home = 0x24,
        /// <summary>
        /// The Left Arrow key.
        /// </summary>
        LeftArrow = 0x25,
        /// <summary>
        /// The Up Arrow key.
        /// </summary>
        UpArrow = 0x26,
        /// <summary>
        /// The Right Arrow key.
        /// </summary>
        RightArrow = 0x27,
        /// <summary>
        /// The Down Arrow key.
        /// </summary>
        DownArrow = 0x28,
        /// <summary>
        /// The Select key.
        /// </summary>
        Select = 0x29,
        /// <summary>
        /// The Print key.
        /// </summary>
        Print = 0x2A,
        /// <summary>
        /// The Execute key.
        /// </summary>
        Execute = 0x2B,
        /// <summary>
        /// The Print Screen key.
        /// </summary>
        PrintScreen = 0x2C,
        /// <summary>
        /// The Insert or Ins key.
        /// </summary>
        Insert = 0x2D,
        /// <summary>
        /// The Delete or Del key.
        /// </summary>
        Delete = 0x2E,
        /// <summary>
        /// The Help key.
        /// </summary>
        Help = 0x2F,
        /// <summary>
        /// The 0 key in the Alphanumeric region of the keyboard.
        /// </summary>
        Alphanumeric_0 = 0x30,
        /// <summary>
        /// The 1 key in the Alphanumeric region of the keyboard.
        /// </summary>
        Alphanumeric_1 = 0x31,
        /// <summary>
        /// The 2 key in the Alphanumeric region of the keyboard.
        /// </summary>
        Alphanumeric_2 = 0x32,
        /// <summary>
        /// The 3 key in the Alphanumeric region of the keyboard.
        /// </summary>
        Alphanumeric_3 = 0x33,
        /// <summary>
        /// The 4 key in the Alphanumeric region of the keyboard.
        /// </summary>
        Alphanumeric_4 = 0x34,
        /// <summary>
        /// The 5 key in the Alphanumeric region of the keyboard.
        /// </summary>
        Alphanumeric_5 = 0x35,
        /// <summary>
        /// The 6 key in the Alphanumeric region of the keyboard.
        /// </summary>
        Alphanumeric_6 = 0x36,
        /// <summary>
        /// The 7 key in the Alphanumeric region of the keyboard.
        /// </summary>
        Alphanumeric_7 = 0x37,
        /// <summary>
        /// The 8 key in the Alphanumeric region of the keyboard.
        /// </summary>
        Alphanumeric_8 = 0x38,
        /// <summary>
        /// The 9 key in the Alphanumeric region of the keyboard.
        /// </summary>
        Alphanumeric_9 = 0x39,
        /// <summary>
        /// The A Key.
        /// </summary>
        A = 0x41,
        /// <summary>
        /// The B Key.
        /// </summary>
        B = 0x42,
        /// <summary>
        /// The C Key.
        /// </summary>
        C = 0x43,
        /// <summary>
        /// The D Key.
        /// </summary>
        D = 0x44,
        /// <summary>
        /// The E Key.
        /// </summary>
        E = 0x45,
        /// <summary>
        /// The F Key.
        /// </summary>
        F = 0x46,
        /// <summary>
        /// The G Key.
        /// </summary>
        G = 0x47,
        /// <summary>
        /// The H Key.
        /// </summary>
        H = 0x48,
        /// <summary>
        /// The I Key.
        /// </summary>
        I = 0x49,
        /// <summary>
        /// The J Key.
        /// </summary>
        J = 0x4A,
        /// <summary>
        /// The K Key.
        /// </summary>
        K = 0x4B,
        /// <summary>
        /// The L Key.
        /// </summary>
        L = 0x4C,
        /// <summary>
        /// The M Key.
        /// </summary>
        M = 0x4D,
        /// <summary>
        /// The N Key.
        /// </summary>
        N = 0x4E,
        /// <summary>
        /// The O Key.
        /// </summary>
        O = 0x4F,
        /// <summary>
        /// The P Key.
        /// </summary>
        P = 0x50,
        /// <summary>
        /// The Q Key.
        /// </summary>
        Q = 0x51,
        /// <summary>
        /// The R Key.
        /// </summary>
        R = 0x52,
        /// <summary>
        /// The S Key.
        /// </summary>
        S = 0x53,
        /// <summary>
        /// The T Key.
        /// </summary>
        T = 0x54,
        /// <summary>
        /// The U Key.
        /// </summary>
        U = 0x55,
        /// <summary>
        /// The V Key.
        /// </summary>
        V = 0x56,
        /// <summary>
        /// The W Key.
        /// </summary>
        W = 0x57,
        /// <summary>
        /// The X Key.
        /// </summary>
        X = 0x58,
        /// <summary>
        /// The Y Key.
        /// </summary>
        Y = 0x59,
        /// <summary>
        /// The Z Key.
        /// </summary>
        Z = 0x5A,
        /// <summary>
        /// The Left Windows key.
        /// </summary>
        LeftWin = 0x5B,
        /// <summary>
        /// The Right Windows key.
        /// </summary>
        RightWin = 0x5C,
        /// <summary>
        /// The Applications key.
        /// </summary>
        Apps = 0x5D,
        /// <summary>
        /// The Computer Sleep key.
        /// </summary>
        Sleep = 0x5F,
        /// <summary>
        /// The 0 key in the Numpad region of the keyboard.
        /// </summary>
        Numpad_0 = 0x60,
        /// <summary>
        /// The 1 key in the Numpad region of the keyboard.
        /// </summary>
        Numpad_1 = 0x61,
        /// <summary>
        /// The 2 key in the Numpad region of the keyboard.
        /// </summary>
        Numpad_2 = 0x62,
        /// <summary>
        /// The 3 key in the Numpad region of the keyboard.
        /// </summary>
        Numpad_3 = 0x63,
        /// <summary>
        /// The 4 key in the Numpad region of the keyboard.
        /// </summary>
        Numpad_4 = 0x64,
        /// <summary>
        /// The 5 key in the Numpad region of the keyboard.
        /// </summary>
        Numpad_5 = 0x65,
        /// <summary>
        /// The 6 key in the Numpad region of the keyboard.
        /// </summary>
        Numpad_6 = 0x66,
        /// <summary>
        /// The 7 key in the Numpad region of the keyboard.
        /// </summary>
        Numpad_7 = 0x67,
        /// <summary>
        /// The 8 key in the Numpad region of the keyboard.
        /// </summary>
        Numpad_8 = 0x68,
        /// <summary>
        /// The 9 key in the Numpad region of the keyboard.
        /// </summary>
        Numpad_9 = 0x69,
        /// <summary>
        /// The Multiply key.
        /// </summary>
        Multiply = 0x6A,
        /// <summary>
        /// The Add key.
        /// </summary>
        Add = 0x6B,
        /// <summary>
        /// The Separator key.
        /// </summary>
        Separator = 0x6C,
        /// <summary>
        /// The Subtracy key.
        /// </summary>
        Subtract = 0x6D,
        /// <summary>
        /// The Decimal key.
        /// </summary>
        Decimal = 0x6E,
        /// <summary>
        /// The Divide key.
        /// </summary>
        Divide = 0x6F,
        /// <summary>
        /// The F1 key.
        /// </summary>
        F1 = 0x70,
        /// <summary>
        /// The F2 key.
        /// </summary>
        F2 = 0x71,
        /// <summary>
        /// The F3 key.
        /// </summary>
        F3 = 0x72,
        /// <summary>
        /// The F4 key.
        /// </summary>
        F4 = 0x73,
        /// <summary>
        /// The F5 key.
        /// </summary>
        F5 = 0x74,
        /// <summary>
        /// The F6 key.
        /// </summary>
        F6 = 0x75,
        /// <summary>
        /// The F7 key.
        /// </summary>
        F7 = 0x76,
        /// <summary>
        /// The F8 key.
        /// </summary>
        F8 = 0x77,
        /// <summary>
        /// The F9 key.
        /// </summary>
        F9 = 0x78,
        /// <summary>
        /// The F10 key.
        /// </summary>
        F10 = 0x79,
        /// <summary>
        /// The F11 key.
        /// </summary>
        F11 = 0x7A,
        /// <summary>
        /// The F12 key.
        /// </summary>
        F12 = 0x7B,
        /// <summary>
        /// The F13 key.
        /// </summary>
        F13 = 0x7C,
        /// <summary>
        /// The F14 key.
        /// </summary>
        F14 = 0x7D,
        /// <summary>
        /// The F15 key.
        /// </summary>
        F15 = 0x7E,
        /// <summary>
        /// The F16 key.
        /// </summary>
        F16 = 0x7F,
        /// <summary>
        /// The F17 key.
        /// </summary>
        F17 = 0x80,
        /// <summary>
        /// The F18 key.
        /// </summary>
        F18 = 0x81,
        /// <summary>
        /// The F19 key.
        /// </summary>
        F19 = 0x82,
        /// <summary>
        /// The F20 key.
        /// </summary>
        F20 = 0x83,
        /// <summary>
        /// The F21 key.
        /// </summary>
        F21 = 0x84,
        /// <summary>
        /// The F22 key.
        /// </summary>
        F22 = 0x85,
        /// <summary>
        /// The F23 key.
        /// </summary>
        F23 = 0x86,
        /// <summary>
        /// The F24 key.
        /// </summary>
        F24 = 0x87,
        /// <summary>
        /// The Num Lock key.
        /// </summary>
        Numlock = 0x90,
        /// <summary>
        /// The Scroll Lock key.
        /// </summary>
        ScrollLock = 0x91,
        /// <summary>
        /// The Left Shift key.
        /// </summary>
        LeftShift = 0xA0,
        /// <summary>
        /// The Right Shift key.
        /// </summary>
        RightShift = 0xA1,
        /// <summary>
        /// The Left Control key.
        /// </summary>
        LeftCtrl = 0xA2,
        /// <summary>
        /// The Right Control key.
        /// </summary>
        RightCtrl = 0xA3,
        /// <summary>
        /// The Left Alt key.
        /// </summary>
        LeftAlt = 0xA4,
        /// <summary>
        /// The Right Alt key.
        /// </summary>
        RightAlt = 0xA5,
        /// <summary>
        /// The Browser Back key.
        /// </summary>
        BrowserBack = 0xA6,
        /// <summary>
        /// The Browser Forward key.
        /// </summary>
        BrowserForward = 0xA7,
        /// <summary>
        /// The Browser Refresh key.
        /// </summary>
        BrowserRefresh = 0xA8,
        /// <summary>
        /// The Browser Stop key.
        /// </summary>
        BrowserStop = 0xA9,
        /// <summary>
        /// The Browser Search key.
        /// </summary>
        BrowserSearch = 0xAA,
        /// <summary>
        /// The Browser Favorites key.
        /// </summary>
        BrowserFavorites = 0xAB,
        /// <summary>
        /// The Browser Home key.
        /// </summary>
        BrowserHome = 0xAC,
        /// <summary>
        /// The Volume Mute key.
        /// </summary>
        VolumeMute = 0xAD,
        /// <summary>
        /// The Volume Down key.
        /// </summary>
        VolumeDown = 0xAE,
        /// <summary>
        /// The Volume Up key.
        /// </summary>
        VolumeUp = 0xAF,
        /// <summary>
        /// The Next Track key.
        /// </summary>
        MediaNextTrack = 0xB0,
        /// <summary>
        /// The Previous Track key.
        /// </summary>
        MediaPrevTrack = 0xB1,
        /// <summary>
        /// The Stop Media key.
        /// </summary>
        MediaStop = 0xB2,
        /// <summary>
        /// The Play/Pause Media key.
        /// </summary>
        MediaPlayPause = 0xB3,
        /// <summary>
        /// The Launch Mail key.
        /// </summary>
        LaunchMail = 0xB4,
        /// <summary>
        /// The Launch Media key.
        /// </summary>
        LaunchMedia = 0xB5,
        /// <summary>
        /// The Launch Application 1 key.
        /// </summary>
        LaunchApp1 = 0xB6,
        /// <summary>
        /// The Launch Application 2 key.
        /// </summary>
        LaunchApp2 = 0xB7,
        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the ';:' key.
        /// </summary>
        OEM_1 = 0xBA,
        /// <summary>
        /// For any country/region, the '+' key.
        /// </summary>
        OEM_Plus = 0xBB,
        /// <summary>
        /// For any country/region, the ',' key.
        /// </summary>
        OEM_Comma = 0xBC,
        /// <summary>
        /// For any country/region, the '-' key.
        /// </summary>
        OEM_Minus = 0xBD,
        /// <summary>
        /// For any country/region, the '.' key.
        /// </summary>
        OEM_Period = 0xBE,
        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '/?' key.
        /// </summary>
        OEM_2 = 0xBF,
        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '~' key.
        /// </summary>
        OEM_3 = 0xC0,
        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '[{' key.
        /// </summary>
        OEM_4 = 0xDB,
        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '\|' key.
        /// </summary>
        OEM_5 = 0xDC,
        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the ']}' key.
        /// </summary>
        OEM_6 = 0xDD,
        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the 'single-quote/double-quote' key.
        /// </summary>
        OEM_7 = 0xDE,
        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard. 
        /// </summary>
        OEM_8 = 0xDF,
        /// <summary>
        /// Either the angle bracket key or the backslash key on the RT 102-key keyboard.
        /// </summary>
        OEM_102 = 0xE2,
        /// <summary>
        /// The IME Process key.
        /// </summary>
        ProcessKey = 0xE5,
        /// <summary>
        /// Used to pass Unicode characters as if they were keystrokes. The Packey key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods.
        /// </summary>
        Packet = 0xE7,
        /// <summary>
        /// The Attn key.
        /// </summary>
        Attn = 0xF6,
        /// <summary>
        /// The CrSel key.
        /// </summary>
        CrSel = 0xF7,
        /// <summary>
        /// The ExSel key.
        /// </summary>
        ExSel = 0xF8,
        /// <summary>
        /// The Erase EOF key.
        /// </summary>
        EREOF = 0xF9,
        /// <summary>
        /// The Play key.
        /// </summary>
        Play = 0xFA,
        /// <summary>
        /// The Zoom key.
        /// </summary>
        Zoom = 0xFB,
        /// <summary>
        /// Reserved.
        /// </summary>
        NONAME = 0xFC,
        /// <summary>
        /// The PA1 key.
        /// </summary>
        PA1 = 0xFD,
        /// <summary>
        /// The Clear key.
        /// </summary>
        OEM_Clear = 0xFE,
        None = 0x00
    }
}
