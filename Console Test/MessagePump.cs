using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

//Solution based on https://social.msdn.microsoft.com/Forums/vstudio/en-US/ed5be22c-cef8-4615-a625-d05caf113afc/console-keyboard-hook-not-getting-called?forum=csharpgeneral

namespace Console_Test
{
    static class MessagePump
    {
        [Serializable]
        public struct MSG
        {
            public IntPtr hwnd;

            public IntPtr lParam;

            public int message;

            public int pt_x;

            public int pt_y;

            public int time;

            public IntPtr wParam;
        }

        [DllImport("user32.dll")]
        public static extern bool GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

        [DllImport("user32.dll")]
        public static extern bool TranslateMessage([In] ref MSG lpMsg);

        [DllImport("user32.dll")]
        public static extern IntPtr DispatchMessage([In] ref MSG lpmsg);

        public static void WaitForMessages()
        {
            MSG msg;

            while ((!GetMessage(out msg, IntPtr.Zero, 0, 0)))
            {
                TranslateMessage(ref msg);
                DispatchMessage(ref msg);
            }
        }
    }
}
