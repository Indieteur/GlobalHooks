using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

//Code based from the answer of Siarhei Kuchuk at https://stackoverflow.com/questions/604410/global-keyboard-capture-in-c-sharp-application and https://stackoverflow.com/questions/11607133/global-mouse-event-handler

namespace GlobalHooks
{
    class GlobalKeyboardHookEventArgs : HandledEventArgs
    {
        public InternalGlobalKeyHook.KeyboardState KeyboardState { get; private set; }
        public InternalGlobalKeyHook.LowLevelKeyboardInputEvent KeyboardData { get; private set; }

        public GlobalKeyboardHookEventArgs(InternalGlobalKeyHook.LowLevelKeyboardInputEvent keyboardData, InternalGlobalKeyHook.KeyboardState keyboardState)
        {
            KeyboardData = keyboardData;
            KeyboardState = keyboardState;
        }
    }

    //Based on https://gist.github.com/Stasonix
    class InternalGlobalKeyHook : IDisposable
    {
        public event EventHandler<GlobalKeyboardHookEventArgs> KeyboardPressed;

        public InternalGlobalKeyHook()
        {
            //We check if there's already an instance of the GlobalHookManager. If there's none, we create one.
            if (GlobalHookManager.singleton == null)
                GlobalHookManager.singleton = new GlobalHookManager();

          
            GlobalHookManager.singleton.CreateKeyboardHook(LowLevelKeyboardProc);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // because we can unhook only in the same thread, not in garbage collector thread
                if (GlobalHookManager.singleton != null)
                    GlobalHookManager.singleton.DisposeKeyHook(LowLevelKeyboardProc);
            }
        }

        ~InternalGlobalKeyHook()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        


        [StructLayout(LayoutKind.Sequential)]
        public struct LowLevelKeyboardInputEvent
        {
            /// <summary>
            /// A virtual-key code. The code must be a value in the range 1 to 254.
            /// </summary>
            public VirtualKeycodes VirtualCode;

            /// <summary>
            /// A hardware scan code for the key. 
            /// </summary>
            public int HardwareScanCode;

            /// <summary>
            /// The extended-key flag, event-injected Flags, context code, and transition-state flag. This member is specified as follows. An application can use the following values to test the keystroke Flags. Testing LLKHF_INJECTED (bit 4) will tell you whether the event was injected. If it was, then testing LLKHF_LOWER_IL_INJECTED (bit 1) will tell you whether or not the event was injected from a process running at lower integrity level.
            /// </summary>
            public int Flags;

            /// <summary>
            /// The time stamp stamp for this message, equivalent to what GetMessageTime would return for this message.
            /// </summary>
            public int TimeStamp;

            /// <summary>
            /// Additional information associated with the message. 
            /// </summary>
            public IntPtr AdditionalInformation;
        }

        
        //const int HC_ACTION = 0;

        internal enum KeyboardState
        {
            KeyDown = 0x0100,
            KeyUp = 0x0101,
            SysKeyDown = 0x0104,
            SysKeyUp = 0x0105
        }
        

        public IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            bool fEatKeyStroke = false;

            var wparamTyped = wParam.ToInt32();
            if (Enum.IsDefined(typeof(KeyboardState), wparamTyped))
            {
                object o = Marshal.PtrToStructure(lParam, typeof(LowLevelKeyboardInputEvent));
                LowLevelKeyboardInputEvent p = (LowLevelKeyboardInputEvent)o;

                var eventArguments = new GlobalKeyboardHookEventArgs(p, (KeyboardState)wparamTyped);

                EventHandler<GlobalKeyboardHookEventArgs> handler = KeyboardPressed;
                handler?.Invoke(this, eventArguments);

                fEatKeyStroke = eventArguments.Handled;
            }

            return fEatKeyStroke ? (IntPtr)(-1) : DLLImports.CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }
    }
}
