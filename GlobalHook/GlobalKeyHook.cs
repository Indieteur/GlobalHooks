using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GlobalHooks
{
    /// <summary>
    /// This enumarates the sides on your keyboard where you can find the modifier keys. (Left and Right)
    /// </summary>
    public enum ModifierKeySide
    {
        /// <summary>
        /// The left instance of the modifier key on the Keyboard.
        /// </summary>
        Left,
        /// <summary>
        /// The right instance of the modifier key on the Keyboard.
        /// </summary>
        Right,
        None
    }

    /// <summary>
    /// Creates a low level hook which detects events from the Keyboard even when the application doesn't have the focus.
    /// </summary>
    public class GlobalKeyHook
    {
        static GlobalKeyHook singleton; //This will allow us to check if there's already an instance of this class created.

        /// <summary>
        /// This event will be called when the user presses down a key.
        /// </summary>
        public event EventHandler<GlobalKeyEventArgs> OnKeyDown;

        /// <summary>
        /// This event will be called right after the user presses down a key and it will be called continuously until the user lets go of the key.
        /// </summary>
        public event EventHandler<GlobalKeyEventArgs> OnKeyPressed;

        /// <summary>
        /// This event will be called when the user lets go of a key.
        /// </summary>
        public event EventHandler<GlobalKeyEventArgs> OnKeyUp;

        /// <summary>
        /// Contains the keys that are currently being pressed.
        /// </summary>
        public VirtualKeycodes[] KeysBeingPressed
        {
            get
            {
                return currentKeysPressed.ToArray();
            }
        }

        InternalGlobalKeyHook _globalKeyboardHook; //A variable pertaining to an instance of the InternalGlobalKeyHook which handles low level stuff for us.

        //Keep track of the modifiers key that are being pressed as well as the location of that modifier key.
        ModifierKeySide shift = ModifierKeySide.None;
        ModifierKeySide alt = ModifierKeySide.None;
        ModifierKeySide ctrl = ModifierKeySide.None;

        List<VirtualKeycodes> currentKeysPressed = new List<VirtualKeycodes>(); //This will store all the keys that are currently being pressed by the user. This will prevent the event OnKeyDown from being continually called.

        public GlobalKeyHook()
        {
            SetupKeyboardHooks(); //Setup our _globalKeyboardHook variable
        }
        void SetupKeyboardHooks()
        {
            //If there's already an instance of this class, we throw an error. We must not have more than one.
            if (singleton != null)
                throw new Exception("There's already an instance of Global Keyboard Hook! Cannot create another one.");

            singleton = this;

            _globalKeyboardHook = new InternalGlobalKeyHook(); //Instantiate GlobalKeyboardHook
            _globalKeyboardHook.KeyboardPressed += _OnKeyPressed; //Subscribe OnKeyPressed method to KeyboardPressed event
        }

        //This is the method that is subscribed to our KeyboardPressed event found in the internal GlobalKeyboardHook class.
        private void _OnKeyPressed(object sender, GlobalKeyboardHookEventArgs e)
        {
            
            if (e.KeyboardState == InternalGlobalKeyHook.KeyboardState.KeyDown || e.KeyboardState == InternalGlobalKeyHook.KeyboardState.SysKeyDown) //When the user presses down a key.
            {
                if (currentKeysPressed.Contains(e.KeyboardData.VirtualCode)) //We check if the key is already being pressed by the user. If it is, we call the OnKeyPressed event instead of OnKeyDown.
                {
                    e.Handled = KeyPressed(e);
                    return;
                }

                currentKeysPressed.Add(e.KeyboardData.VirtualCode);

                handleModifierKeyDown(e);
                    
                e.Handled = KeyDown(e); //We fire the KeyDown event which will also return a bool value (Handled var). If variable handled is set to true, the succeeding events handling a KeyDown will not be called.
            }
            else if (e.KeyboardState == InternalGlobalKeyHook.KeyboardState.KeyUp || e.KeyboardState == InternalGlobalKeyHook.KeyboardState.SysKeyUp) //When the user lets go of a key.
            {
                //We remove the key that was released from the list of keys currently being pressed.
                currentKeysPressed.Remove(e.KeyboardData.VirtualCode);

                handleModifierKeyUp(e);
               e.Handled = KeyUp(e);
            }
        }

        /// <summary>
        /// Checks if key pressed is a modifier key. If it is, we set the values of shift, alt and ctrl accordingly. We also return the bool value of true if the key pressed is a modifier and vice versa.
        /// </summary>
        /// <param name="e">Argument passed by the KeyboardPressed event found in the internal GlobalKeyboardHook class.</param>
        /// <returns>Returns true if the key that was pressed is a modifier key. False if otherwise.</returns>
        bool handleModifierKeyDown(GlobalKeyboardHookEventArgs e)
        {
            switch (e.KeyboardData.VirtualCode) //Check which Modifier Key was pressed, set the appropriate variable to the location of the modifier key that was pressed and return true. Return False if the key wasn't a modifier key.
            {
                case VirtualKeycodes.LeftShift:
                    shift = ModifierKeySide.Left;
                    return true;
                case VirtualKeycodes.LeftAlt:
                    alt = ModifierKeySide.Left;
                    return true;
                case VirtualKeycodes.LeftCtrl:
                    ctrl = ModifierKeySide.Left;
                    return true;
                case VirtualKeycodes.RightCtrl:
                    ctrl = ModifierKeySide.Right;
                    return true;
                case VirtualKeycodes.RightShift:
                    shift = ModifierKeySide.Right;
                    return true;
                case VirtualKeycodes.RightAlt:
                    alt = ModifierKeySide.Right;
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Checks if the key that was let go is a modifier key. If it is, we set the values of shift, alt and ctrl accordingly. We also return the bool value of true if the key that was let go is a modifier and vice versa.
        /// </summary>
        /// <param name="e">Argument passed by the KeyboardPressed event found in the internal GlobalKeyboardHook class.</param>
        /// <returns>Returns true if the key that was let go is a modifier key. If otherwise, false.</returns>
        bool handleModifierKeyUp(GlobalKeyboardHookEventArgs e)
        {
            switch (e.KeyboardData.VirtualCode) //Check which Modifier Key was let go, set the appropriate variable back to not pressed state (none) and return true. Return False if the key wasn't a modifier key.
            {
                case VirtualKeycodes.LeftShift:
                    shift = ModifierKeySide.None;
                    return true;
                case VirtualKeycodes.LeftAlt:
                    alt = ModifierKeySide.None;
                    return true;
                case VirtualKeycodes.LeftCtrl:
                    ctrl = ModifierKeySide.None;
                    return true;
                case VirtualKeycodes.RightCtrl:
                    ctrl = ModifierKeySide.None;
                    return true;
                case VirtualKeycodes.RightShift:
                    shift = ModifierKeySide.None;
                    return true;
                case VirtualKeycodes.RightAlt:
                    alt = ModifierKeySide.None;
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// This method will call the OnKeyDown event exposed from the library and pass on the information about the key that was pressed.
        /// </summary>
        /// <param name="e">Argument passed by the KeyboardPressed event found in the internal GlobalKeyboardHook class.</param>
        /// <returns>Returns true if the event was handled and false if not.</returns>
        bool KeyDown(GlobalKeyboardHookEventArgs e)
        {

            GlobalKeyEventArgs globalKeyEventArgs = new GlobalKeyEventArgs(e, alt, ctrl, shift); //Store the information passed to this method by the _OnKeyPressed method. This variable will be passed to the methods subscribed to the OnKeyDown event.

            EventHandler<GlobalKeyEventArgs> handler = OnKeyDown;
            if (handler == null) //If there's nothing subscribed to the OnKeyDown event, we exit from the method.
                return false;
            handler(this, globalKeyEventArgs); //Call the OnKeyDown event and pass on the globalKeyEventArgs as an argument
            return globalKeyEventArgs.Handled; //Now, we return the bool value of the handled variable back to the OnKeyPressed method.
        }

        /// <summary>
        /// This method will call the OnKeyPressed event exposed from the library and pass on the information about the key that was pressed.
        /// </summary>
        /// <param name="e">Argument passed by the KeyboardPressed event found in the internal GlobalKeyboardHook class.</param>
        /// <returns>Returns true if the event was handled and false if not.</returns>
        bool KeyPressed(GlobalKeyboardHookEventArgs e)
        {

            GlobalKeyEventArgs globalKeyEventArgs = new GlobalKeyEventArgs(e, alt, ctrl, shift); //Store the information passed to this method by the _OnKeyPressed method. This variable will be passed to the methods subscribed to the OnKeyPressed event.

            EventHandler<GlobalKeyEventArgs> handler = OnKeyPressed;
            if (handler == null) //If there's nothing subscribed to the OnKeyPressed event, we exit from the method.
                return false;
            handler(this, globalKeyEventArgs); //Call the OnKeyPressed event and pass on the globalKeyEventArgs as an argument
            return globalKeyEventArgs.Handled; //Now, we return the bool value of the handled variable back to the _OnKeyPressed method.
        }

        /// <summary>
        /// This method will call the OnKeyUp event exposed from the library and pass on the information about the key that was pressed.
        /// </summary>
        /// <param name="e">Argument passed by the KeyboardPressed event found in the internal GlobalKeyboardHook class.</param>
        /// <returns>Returns true if the event was handled and false if not.</returns>
        bool KeyUp(GlobalKeyboardHookEventArgs e)
        {

            GlobalKeyEventArgs globalKeyEventArgs = new GlobalKeyEventArgs(e, alt, ctrl, shift);

            EventHandler<GlobalKeyEventArgs> handler = OnKeyUp;
            if (handler == null)
                return false;
            handler(this, globalKeyEventArgs);
            return globalKeyEventArgs.Handled;
        }

        
        //The built in GC doesn't know that there is a System Hook installed. We must handle the disposal ourselves when this instance of the class is disposed.
        public void Dispose()
        {
            singleton = null; //Set the value of the singleton to nothing as we are disposing this instance.
            _globalKeyboardHook?.Dispose(); //We also need to dispose of the GlobalKeyboardHook instance that we created.
            OnKeyDown = null;
            OnKeyPressed = null;
            OnKeyUp = null;
        }
    }

    /// <summary>
    /// Contains the information about the keyboard event that has happened. (e.g. Key that was pressed; Which modifier keys were pressed)
    /// </summary>
    public class GlobalKeyEventArgs : HandledEventArgs
    {
        //Key Modifiers information

        /// <summary>
        /// Value equates to which Alt Modifier Key was pressed. If neither was pressed, value will be set to none.
        /// </summary>
        public ModifierKeySide Alt { get; private set; } = ModifierKeySide.None;
        /// <summary>
        /// Value equates to which Ctrl Modifier Key was pressed. If neither was pressed, value will be set to none.
        /// </summary>
        public ModifierKeySide Control { get; private set; } = ModifierKeySide.None;
        /// <summary>
        /// Value equates to which Shift Modifier Key was pressed. If neither was pressed, value will be set to none.
        /// </summary>
        public ModifierKeySide Shift { get; private set; } = ModifierKeySide.None;

        /// <summary>
        /// Returns the key that was pressed (OnKeyDown), being pressed (OnKeyPressed) or that was let go (OnKeyUp).
        /// </summary>
        public VirtualKeycodes KeyCode { get; private set; }

        /// <summary>
        /// Returns the hardware keycode of the key that was pressed (OnKeyDown), being pressed (OnKeyPressed) or that was let go (OnKeyUp).
        /// </summary>
        public int hardwareScanCode { get; private set; }

        /// <summary>
        /// Returns true if the key that was pressed (OnKeyDown), being pressed (OnKeyPressed) or that was let go (OnKeyUp) was a Modifier key (Ctrl, Alt, Shift).
        /// </summary>
        public bool IsModifierKey { get; private set; } = false;

        /// <summary>
        /// The resulting readable character from the Keyboard event. (e.g. Left Shift + 1 = !)
        /// </summary>
        public string CharResult { get; private set; }

        
        //Handle the creation of an instance of this class. Set the values of the properties.
        internal GlobalKeyEventArgs(GlobalKeyboardHookEventArgs e, ModifierKeySide alt, ModifierKeySide ctrl, ModifierKeySide shift)
        {
            Alt = alt;
            Control = ctrl;
            Shift = shift;
            KeyCode = e.KeyboardData.VirtualCode;
            hardwareScanCode = e.KeyboardData.HardwareScanCode;
                        
            //Set the IsModifierKey variable by checking if the KeyCode is a modifier key.
            IsModifierKey = (KeyCode == VirtualKeycodes.LeftShift || KeyCode == VirtualKeycodes.LeftCtrl || KeyCode == VirtualKeycodes.LeftAlt
                    || KeyCode == VirtualKeycodes.RightAlt || KeyCode == VirtualKeycodes.RightCtrl || KeyCode == VirtualKeycodes.RightShift);

            CharResult = GetCharFromKey(e);
        
        }

        //Gets the resulting character from the Keyboard event. Based from the answers on https://stackoverflow.com/questions/23170259/convert-keycode-to-char-string 
        string GetCharFromKey(GlobalKeyboardHookEventArgs e)
        {
            byte[] keyboardState = new byte[255];
            bool keyboardStateStatus = DLLImports.GetKeyboardState(keyboardState);

            //Added this code in as the method doesn't work well without this piece of code when the application loses focus.
            if (Shift != ModifierKeySide.None)
            {
                keyboardState[(int)VirtualKeycodes.Shift] = 0xff;
            }
            if (Control != ModifierKeySide.None)
            {
                keyboardState[(int)VirtualKeycodes.Control] = 0xff;
            }
            if (Alt != ModifierKeySide.None)
            {
                keyboardState[(int)VirtualKeycodes.Alt] = 0xff;
            }

            if (!keyboardStateStatus)
            {
                return "";
            }

            uint virtualKeyCode = (uint)e.KeyboardData.VirtualCode;
            IntPtr inputLocaleIdentifier = DLLImports.GetKeyboardLayout(0);

            StringBuilder result = new StringBuilder();
            DLLImports.ToUnicodeEx(virtualKeyCode, (uint)e.KeyboardData.HardwareScanCode, keyboardState, result, (int)5, (uint)0, inputLocaleIdentifier);

            return result.ToString();
        }
        
    }

    
}
