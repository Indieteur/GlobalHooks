using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalHooks;

namespace Demo
{
    public enum hookType
    {
        keyHook,
        mouseHook,
        All
    }
    static class Misc
    {
        
        public enum KeyEventType
        {
            OnKeyDown,
            OnKeyPress,
            OnKeyUp
        }

       
        
        public static string MakeKeyLog(GlobalKeyEventArgs e, KeyEventType keyEventType)
        {
            bool ModifierKeyPressed = false;

            StringBuilder logMessage = new StringBuilder("Keyboard: "); //Start creating our text

            switch (keyEventType) //Check which event called this method and set the appropriate text for it. The calling method passed on the event type to us via keyEventType argument.
            {
                case KeyEventType.OnKeyDown:
                    logMessage.Append(e.KeyCode + " key has been pressed. ");
                    break;
                case KeyEventType.OnKeyPress:
                    logMessage.Append(e.KeyCode + " key is still being pressed. ");
                    break;
                default:
                    logMessage.Append(e.KeyCode + " key has been released. ");
                    break;
            }
            
            //Check if the resulting character is set to something or not (e.g. CharResult would be empty if the user presses Shift on it's own.)
            if (!string.IsNullOrWhiteSpace(e.CharResult))
            {
                logMessage.Append(" Resulting Character: " + e.CharResult + " -- ");
            }

            logMessage.Append("[Modifier Key(s) Pressed: ");

            //Let's check which modifier keys are being pressed and append it to the log.
            if (e.Control != ModifierKeySide.None)
            {
                ModifierKeyPressed = true;
                logMessage.Append(e.Control.ToString() + " Control");
            }
            if (e.Shift != ModifierKeySide.None)
            {
                logMessage.Append((ModifierKeyPressed ? ", " : "") + e.Shift.ToString() + " Shift");
                ModifierKeyPressed = true;

            }
            if (e.Alt != ModifierKeySide.None)
            {
                logMessage.Append((ModifierKeyPressed ? ", " : "") + e.Alt.ToString() + " Alt");
                ModifierKeyPressed = true;

            }

            //If no modifier key was pressed, we append 'None' to the log to indicate that there was no modifier key being pressed.
            if (!ModifierKeyPressed)
                logMessage.Append("None");
            logMessage.Append("]");
            return logMessage.ToString(); //Build the log text and return it to the calling method.
        }

        public static string MousePositionToString (MousePosition mousePosition)
        {
            return "[Mouse Position: " + mousePosition.X.ToString() + "X, " + mousePosition.Y.ToString() + "Y]";
        }
    }
}
