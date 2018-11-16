using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GlobalHooks
{
    delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
   
    internal static class DLLImports
    {
        //constant needed by the GlobalHook
        internal const int WH_KEYBOARD_LL = 13;
        internal const int WH_MOUSE_LL = 14;


        [DllImport("kernel32.dll")]
        internal static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        internal static extern bool FreeLibrary(IntPtr hModule);
        

        /// <summary>
        /// The SetWindowsHookEx function installs an application-defined hook procedure into a hook chain.
        /// You would install a hook procedure to monitor the system for certain types of events. These events are
        /// associated either with a specific thread or with all threads in the same desktop as the calling thread.
        /// </summary>
        /// <param name="idHook">hook type</param>
        /// <param name="lpfn">hook procedure</param>
        /// <param name="hMod">handle to application instance</param>
        /// <param name="dwThreadId">thread identifier</param>
        /// <returns>If the function succeeds, the return value is the handle to the hook procedure.</returns>
        [DllImport("USER32", SetLastError = true)]
        internal static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, int dwThreadId);


        /// <summary>
        /// The UnhookWindowsHookEx function removes a hook procedure installed in a hook chain by the SetWindowsHookEx function.
        /// </summary>
        /// <param name="hhk">handle to hook procedure</param>
        /// <returns>If the function succeeds, the return value is true.</returns>
        [DllImport("USER32", SetLastError = true)]
        internal static extern bool UnhookWindowsHookEx(IntPtr hHook);

        /// <summary>
        /// The CallNextHookEx function passes the hook information to the next hook procedure in the current hook chain.
        /// A hook procedure can call this function either before or after processing the hook information.
        /// </summary>
        /// <param name="hHook">handle to current hook</param>
        /// <param name="code">hook code passed to hook procedure</param>
        /// <param name="wParam">value passed to hook procedure</param>
        /// <param name="lParam">value passed to hook procedure</param>
        /// <returns>If the function succeeds, the return value is true.</returns>
        [DllImport("USER32", SetLastError = true)]
        internal static extern IntPtr CallNextHookEx(IntPtr hHook, int code, IntPtr wParam, IntPtr lParam);

        [DllImport("USER32")]
        internal static extern bool GetKeyboardState(byte[] lpKeyState);
        

        [DllImport("USER32")]
        internal static extern IntPtr GetKeyboardLayout(uint idThread);
        

        [DllImport("USER32")]
        internal static extern int ToUnicodeEx(uint wVirtKey, uint wScanCode, byte[] lpKeyState, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszBuff, int cchBuff, uint wFlags, IntPtr dwhkl);
    }
}
