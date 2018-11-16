using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Diagnostics;

namespace GlobalHooks
{
    internal class GlobalHookManager : IDisposable
    {
        internal static GlobalHookManager singleton; //We only need one instance of this class

        IntPtr _user32LibraryHandle; //Int Pointer for the User32 Library

        //Keyboard Hook necessary variables
        HookProc _keyHookProc; //methods subscribed to this delegate will be called when a keyboard event happens
        IntPtr _keyHookWindowsHandle = IntPtr.Zero; //Int pointer to the keyboard hook

        //Mouse Hook necessary variables
        HookProc _mouseHookProc; //methods subscribed to this delegate will be called when a Mouse event happens
        IntPtr _mouseHookWindowsHandle = IntPtr.Zero; //Int pointer to the Mouse hook

        //This constructor will handle the loading of the User32 Library which is the one that manages system hooks.
        public GlobalHookManager()
        {
            //Check if there's already an instance of this class, if there is throw an error.
            if (singleton != null)
                throw new Exception("There's already another instance of GlobalHookManager! No need to create another one.");


            _user32LibraryHandle = IntPtr.Zero;

            _user32LibraryHandle = DLLImports.LoadLibrary("User32");
            if (_user32LibraryHandle == IntPtr.Zero)
            {
                int errorCode = Marshal.GetLastWin32Error();
                throw new Win32Exception(errorCode, $"Failed to load library 'User32.dll'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
            }

            
            singleton = this;
        }

        //This handles the creation of Keyboard Hook
        public void CreateKeyboardHook(HookProc _hookCB)
        {
            //We must not have more than one Keyboard hook for this instance of the class so we check if there's already one. If there is, we throw an error.
            if (_keyHookWindowsHandle != IntPtr.Zero)
                throw new Exception("There's already a keyboard hook instantiated! No need to create another one.");
            
            _keyHookProc = _hookCB; // we must keep alive _hookProc, because GC is not aware about SetWindowsHookEx behaviour.

            _keyHookWindowsHandle = DLLImports.SetWindowsHookEx(DLLImports.WH_KEYBOARD_LL, _keyHookProc, _user32LibraryHandle, 0);
            if (_keyHookWindowsHandle == IntPtr.Zero)
            {
                int errorCode = Marshal.GetLastWin32Error();
                throw new Win32Exception(errorCode, $"Failed to adjust keyboard hooks for '{Process.GetCurrentProcess().ProcessName}'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
            }
        }

        //This handles the creation of Mouse Hook
        public void CreateMouseHook(HookProc _hookCB)
        {
            //We must not have more than one Keyboard hook for this instance of the class so we check if there's already one. If there is, we throw an error.
            if (_mouseHookWindowsHandle != IntPtr.Zero)
                throw new Exception("There's already a mouse hook instantiated! No need to create another one.");
            
            _mouseHookProc = _hookCB; // we must keep alive _hookProc, because GC is not aware about SetWindowsHookEx behaviour.

            _mouseHookWindowsHandle = DLLImports.SetWindowsHookEx(DLLImports.WH_MOUSE_LL, _mouseHookProc, _user32LibraryHandle, 0);
            if (_mouseHookWindowsHandle == IntPtr.Zero)
            {
                int errorCode = Marshal.GetLastWin32Error();
                throw new Win32Exception(errorCode, $"Failed to adjust mouse hooks for '{Process.GetCurrentProcess().ProcessName}'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
            }
        }



        /*--- Dispose Functions ---*/
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // because we can unhook only in the same thread, not in garbage collector thread
                DisposeKeyHook();
                DisposeMouseHook();
            }

            DisposeUser32Handle();
        }

        ~GlobalHookManager()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //Dipose our Mousehook as it is not automatically handled by the GC
        public void DisposeMouseHook()
        {
            if (_mouseHookWindowsHandle != IntPtr.Zero)
            {
                if (!DLLImports.UnhookWindowsHookEx(_mouseHookWindowsHandle))
                {
                    int errorCode = Marshal.GetLastWin32Error();
                    throw new Win32Exception(errorCode, $"Failed to remove keyboard hooks for '{Process.GetCurrentProcess().ProcessName}'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
                }
                _mouseHookWindowsHandle = IntPtr.Zero;

                _mouseHookProc = null;
            }
        }

        //An overload of the DisposeMouseHook function. After disposing the hook, we unsubscribe hookProc event from the _mouseHookProc instead of setting the _mouseHookProc to null.
        public void DisposeMouseHook(HookProc hookProc)
        {
            if (_mouseHookWindowsHandle != IntPtr.Zero)
            {
                if (!DLLImports.UnhookWindowsHookEx(_mouseHookWindowsHandle))
                {
                    int errorCode = Marshal.GetLastWin32Error();
                    throw new Win32Exception(errorCode, $"Failed to remove keyboard hooks for '{Process.GetCurrentProcess().ProcessName}'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
                }
                _mouseHookWindowsHandle = IntPtr.Zero;

                _mouseHookProc -= hookProc;
            }
        }

        //Dipose our Keyhook as it is not automatically handled by the GC
        public void DisposeKeyHook()
        {
            if (_keyHookWindowsHandle != IntPtr.Zero)
            {
                if (!DLLImports.UnhookWindowsHookEx(_keyHookWindowsHandle))
                {
                    int errorCode = Marshal.GetLastWin32Error();
                    throw new Win32Exception(errorCode, $"Failed to remove keyboard hooks for '{Process.GetCurrentProcess().ProcessName}'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
                }
                _keyHookWindowsHandle = IntPtr.Zero;

                _keyHookProc = null;
            }
        }

        //An overload of the DisposeKeyHook function. After disposing the hook, we unsubscribe hookProc event from the _keyHookProc instead of setting the _KeyHookProc to null.
        public void DisposeKeyHook(HookProc hookProc)
        {
            if (_keyHookWindowsHandle != IntPtr.Zero)
            {
                if (!DLLImports.UnhookWindowsHookEx(_keyHookWindowsHandle))
                {
                    int errorCode = Marshal.GetLastWin32Error();
                    throw new Win32Exception(errorCode, $"Failed to remove keyboard hooks for '{Process.GetCurrentProcess().ProcessName}'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
                }
                _keyHookWindowsHandle = IntPtr.Zero;

                // ReSharper disable once DelegateSubtraction
                _keyHookProc -= hookProc;
            }
        }

        //Unloads the User32 Library as this is not automatically done by GC.
        void DisposeUser32Handle()
        {
            if (_user32LibraryHandle != IntPtr.Zero)
            {
                if (!DLLImports.FreeLibrary(_user32LibraryHandle)) // reduces reference to library by 1.
                {
                    int errorCode = Marshal.GetLastWin32Error();
                    throw new Win32Exception(errorCode, $"Failed to unload library 'User32.dll'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
                }
                _user32LibraryHandle = IntPtr.Zero;
            }
        }

        
        
        
    }
}
