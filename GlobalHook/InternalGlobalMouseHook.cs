using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GlobalHooks
{
        

    

    class GlobalMouseHookEventArgs : HandledEventArgs
    {
        public InternalGlobalMouseHook.MouseMessages MouseMessages { get; private set; }
        public InternalGlobalMouseHook.MSLLHOOKSTRUCT MouseData { get; private set; }

        public GlobalMouseHookEventArgs(InternalGlobalMouseHook.MouseMessages mouseMessages, InternalGlobalMouseHook.MSLLHOOKSTRUCT mouseData)
        {
            MouseMessages = mouseMessages;
            MouseData = mouseData;
        }
    }

    class InternalGlobalMouseHook : IDisposable
    {
        public event EventHandler<GlobalMouseHookEventArgs> MouseEvent;


        public InternalGlobalMouseHook()
        {
            if (GlobalHookManager.singleton == null)
                GlobalHookManager.singleton = new GlobalHookManager();


            GlobalHookManager.singleton.CreateMouseHook(LowLevelMouseEvent);
        }
        

        private IntPtr LowLevelMouseEvent(int nCode, IntPtr wParam, IntPtr lParam)
        {
            bool fEatMouseEvent = false;

            var wparamTyped = wParam.ToInt32();
            if (Enum.IsDefined(typeof(MouseMessages), wparamTyped))
            {
                object o = Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                MSLLHOOKSTRUCT p = (MSLLHOOKSTRUCT)o;

                var eventArguments = new GlobalMouseHookEventArgs( (MouseMessages)wparamTyped, p);

                EventHandler<GlobalMouseHookEventArgs> handler = MouseEvent;
                handler?.Invoke(this, eventArguments);

                fEatMouseEvent = eventArguments.Handled;
            }

            return fEatMouseEvent ? (IntPtr)(-1) : DLLImports.CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
            
        }
        
        

        /* Dispose Methods */
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // because we can unhook only in the same thread, not in garbage collector thread
                if (GlobalHookManager.singleton != null)
                    GlobalHookManager.singleton.DisposeMouseHook(LowLevelMouseEvent);
            }
        }

        ~InternalGlobalMouseHook()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /* Enum and Structs declaration */
        internal enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205,
            WM_MBUTTONDOWN = 0x0207,
            WM_MBUTTONUP = 0x0208,
            WM_XBUTTONDOWN = 0x020B,
            WM_XBUTTONUP = 0x020C
        }

        internal enum XButtons
        {
            WM_XBUTTON1 = 0x0001,
            WM_XBUTTON2 = 0x0002
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct POINT
        {
            public int x;
            public int y;
        }

        //lParam
        [StructLayout(LayoutKind.Sequential)]
        internal struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
    }
}
