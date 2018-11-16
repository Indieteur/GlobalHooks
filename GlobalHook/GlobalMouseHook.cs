using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalHooks
{
    /// <summary>
    /// List of buttons on a mouse.
    /// </summary>
    public enum GHMouseButtons //Create an enum of Mouse Buttons withoutf referencing System.Windows.Forms.
    {
        /// <summary>
        /// The Left Button.
        /// </summary>
        Left = 0x01,
        /// <summary>
        /// The Right Button.
        /// </summary>
        Right = 0x02,
        /// <summary>
        /// The Middle Button.
        /// </summary>
        Middle = 0x04,
        /// <summary>
        /// The X Button 1.
        /// </summary>
        XButton1 = 0x05,
        /// <summary>
        /// The X Button 2.
        /// </summary>
        XButton2 = 0x06,
        None = 0x00
    }

    /// <summary>
    /// This enumerates the scroll direction of the scroll wheel on the mouse.
    /// </summary>
    public enum WheelRotation
    {
        /// <summary>
        /// The Scroll Wheel was rotated away from the user.
        /// </summary>
        Forwards = 120,
        /// <summary>
        /// The Scroll Wheel was rotated towards the user.
        /// </summary>
        Backwards = -120,
        None = 0
    }

    /// <summary>
    /// The location of the mouse pointer on the screen.
    /// </summary>
    public struct MousePosition
    {
        /// <summary>
        /// The location of the mouse pointer on the x-axis.
        /// </summary>
        public int X { get; internal set; }
        /// <summary>
        /// The location of the mouse pointer on the y-axis.
        /// </summary>
        public int Y { get; internal set; }
        public MousePosition(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    /// <summary>
    /// Creates a low level hook which detects events from the Mouse even when the application doesn't have the focus.
    /// </summary>
    public class GlobalMouseHook
    {
        GlobalMouseHook singleton; //We must only instantiate one instance of this class. This variable keeps record of that.

        InternalGlobalMouseHook _globalMouseHook; // A variable pertaining to an instance of the InternalGlobalMouseHook which handles low level stuff for us.

        /// <summary>
        /// This event will be called when a mouse button is pressed.
        /// </summary>
        public event EventHandler<GlobalMouseEventArgs> OnButtonDown;

        /// <summary>
        /// This event will be called when the user lets go of a mouse button.
        /// </summary>
        public event EventHandler<GlobalMouseEventArgs> OnButtonUp;

        /// <summary>
        /// This event will be called everytime the Mouse Pointer moves on the screen.
        /// </summary>
        public event EventHandler<GlobalMouseEventArgs> OnMouseMove;

        /// <summary>
        /// This event will be called when the user rotates the scroll wheel.
        /// </summary>
        public event EventHandler<GlobalMouseEventArgs> OnMouseWheelScroll;

        /// <summary>
        /// Contains all the mouse buttons that are currently being pressed.
        /// </summary>
        public GHMouseButtons[] ButtonsBeingPressed
        {
            get
            {
                return currentMouseButtonsPressed.ToArray();
            }
        }

        List<GHMouseButtons> currentMouseButtonsPressed = new List<GHMouseButtons>(6); //Store all the mouse buttons currently being pressed

        public GlobalMouseHook()
        {
            SetupMouseHook();
        }

        //We setup the base Mousehook through this method.
        void SetupMouseHook()
        {
            //If there's already an instance of this class, we throw an error. We must not have more than one.
            if (singleton != null)
                throw new Exception("There's already an instance of GlobalMouseHook created. Must not create another one.");

            _globalMouseHook = new InternalGlobalMouseHook(); //We create a new instance of the internal global mouse hook class which take cares of low level stuff.
            _globalMouseHook.MouseEvent += _globalMouseHook_MouseEvent; //We subscribe for any mouse event that happens through the MouseEvent provided by the Internal Global Mouse hook class.
        }

        //This method will be called when a Mouse Event happens.
        private void _globalMouseHook_MouseEvent(object sender, GlobalMouseHookEventArgs e)
        {
            
           if ( e.MouseMessages == InternalGlobalMouseHook.MouseMessages.WM_LBUTTONDOWN  || e.MouseMessages == InternalGlobalMouseHook.MouseMessages.WM_MBUTTONDOWN 
                || e.MouseMessages == InternalGlobalMouseHook.MouseMessages.WM_RBUTTONDOWN || e.MouseMessages == InternalGlobalMouseHook.MouseMessages.WM_XBUTTONDOWN )
            {
                e.Handled = ButtonDown(e); //If the left, middle, right or the X buttons were pressed, we call the ButtonDown method which handles the calling of the OnButtonDown event. 
                // The ButtonDown method also returns a bool value. If it is set to true, succeeding events handling a ButtonDown will not be called.
            }
           else if (e.MouseMessages == InternalGlobalMouseHook.MouseMessages.WM_LBUTTONUP || e.MouseMessages == InternalGlobalMouseHook.MouseMessages.WM_MBUTTONUP
                || e.MouseMessages == InternalGlobalMouseHook.MouseMessages.WM_RBUTTONUP || e.MouseMessages == InternalGlobalMouseHook.MouseMessages.WM_XBUTTONUP)
            {
                e.Handled = ButtonUp(e); //If the left, middle, right or the X buttons were released, we call the ButtonUp method which handles the calling of the OnButtonUp event. 
            }
           else if (e.MouseMessages == InternalGlobalMouseHook.MouseMessages.WM_MOUSEMOVE)
            {
                e.Handled = MouseMove(e.MouseData.pt); //If the mouse pointers on the screen, we call the MouseMove method which handles the calling of the OnMouseMove event.
            }
           else if (e.MouseMessages == InternalGlobalMouseHook.MouseMessages.WM_MOUSEWHEEL)
            {
                e.Handled = MouseWheelEvent(e); //If the mouse wheel was rotated, we call the MouseWheelEvent method which handles the OnMouseWheelScroll event.
            }
        }

        /// <summary>
        /// This method will call the OnButtonDown event exposed from the library and pass on information about the button that was pressed and the location of the mouse pointer.
        /// </summary>
        /// <param name="e">Argument passed by the MouseEvent under the Internal GlobalMouseHook.</param>
        /// <returns>Returns true if the event was handled and false if not.</returns>
        bool ButtonDown(GlobalMouseHookEventArgs e)
        {
            GHMouseButtons mouseButton = MouseMessageToGHMouseButton(e.MouseMessages, e.MouseData.mouseData); //We convert the ugly looking MouseMessages to an enumartion of the GHMouseButtons. 
            currentMouseButtonsPressed.Remove(mouseButton); //Remove the mouse button from the list of buttons currently being pressed.

            MousePosition mousePosition = new MousePosition(e.MouseData.pt.x, e.MouseData.pt.y); //Store the x and y coordinates of the mouse pointer on the screen.

            GlobalMouseEventArgs globalMouseEventArgs = new GlobalMouseEventArgs(mouseButton, mousePosition); //Now, we store the values of the mouseButton and the mousePosition into one class which will be the argument for the OnButtonDown event.

            return CallEvent(OnButtonDown, globalMouseEventArgs); //Let's now call the CallEvent method which handles the necessary "set up" needed before calling the OnButtonDown event for us. We also pass on the globalMouseEventArgs as the argument of the event.
            //It also returns a boolean value which tells us if the event was handled. We have to pass that value back to the _globalMouseHook_MouseEvent method.
        }

        /// <summary>
        /// This method will call the OnButtonUp event exposed from the library and pass on information about the button that was let go and the location of the mouse pointer.
        /// </summary>
        /// <param name="e">Argument passed by the MouseEvent under the Internal GlobalMouseHook.</param>
        /// <returns>Returns true if the event was handled and false if not.</returns>
        bool ButtonUp(GlobalMouseHookEventArgs e)
        {
            GHMouseButtons mouseButton = MouseMessageToGHMouseButton(e.MouseMessages, e.MouseData.mouseData);
            currentMouseButtonsPressed.Add(mouseButton); //Add mouse button to the list of currently being pressed mouse buttons.

            MousePosition mousePosition = new MousePosition(e.MouseData.pt.x, e.MouseData.pt.y);

            GlobalMouseEventArgs globalMouseEventArgs = new GlobalMouseEventArgs(mouseButton, mousePosition);

            return CallEvent(OnButtonUp, globalMouseEventArgs);
        }

        /// <summary>
        /// This method will call the OnMouseMove event exposed from the library and pass on the location of the mouse pointer.
        /// </summary>
        /// <param name="e">Argument passed by the MouseEvent under the Internal GlobalMouseHook.</param>
        /// <returns>Returns true if the event was handled and false if not.</returns>
        bool MouseMove(InternalGlobalMouseHook.POINT mousePos)
        {
            //Compared to the previous two methods, we just need the position of the mouse as it moved.
            MousePosition mousePosition = new MousePosition(mousePos.x, mousePos.y);
            GlobalMouseEventArgs globalMouseEventArgs = new GlobalMouseEventArgs(GHMouseButtons.None, mousePosition); //No button was pressed. We only need to pass on the mousePosition to the event.

            return CallEvent(OnMouseMove, globalMouseEventArgs);
        }

        bool MouseWheelEvent(GlobalMouseHookEventArgs e)
        {
            MousePosition mousePosition = new MousePosition(e.MouseData.pt.x, e.MouseData.pt.y);

            /* Compared to the other events, we need to find the rotation of the scroll wheel (wheel delta). Unfortunately, the low level mouse event doesn't pass it as a human readable value. 
              Instead, it is passed on as a high order word of the e.mouseData.mouseData value. We have to retrieve that High Order Word by using a helper function called GetSignedHWord.*/
            WheelRotation wheelRotation = (WheelRotation)(Helper.GetSignedHWORD(e.MouseData.mouseData)); //The Wheel Delta will always be either 120 for forwards movement and -120 for backwards movement which is already declared on the WheelRotation enum. All we have to do is cast the Wheel Delta to WheelRotation.
            

            GlobalMouseEventArgs globalMouseEventArgs = new GlobalMouseEventArgs(GHMouseButtons.None, mousePosition, wheelRotation);

            return CallEvent(OnMouseWheelScroll, globalMouseEventArgs);
        }

        /// <summary>
        /// Calls an event after taking care of the necessary setting up needed.
        /// </summary>
        /// <param name="_handler">The event that will be called.</param>
        /// <param name="argument">The argument that will be passed on to the methods subscribed to the event.</param>
        /// <returns>Returns true if the event was handled and false if not.</returns>
        bool CallEvent(EventHandler<GlobalMouseEventArgs> _handler, GlobalMouseEventArgs argument)
        {
            GlobalMouseEventArgs _argument = argument;

            EventHandler<GlobalMouseEventArgs> handler = _handler;
            if (handler == null) //Check if there's anything subscribed to the event. If there's none, we exit from the method.
                return false;

            handler(this, _argument); //Call the event
            return _argument.Handled;  //Now, we return the bool value of the handled variable back to the method that called this method.
        }

        /// <summary>
        /// Converts the internal MouseMessage enum to GHMouseButtons enumeration.
        /// </summary>
        /// <param name="button">The MouseMessage argument that was passed on by the InternalGlobalMouseHook to the MouseEvent event.</param>
        /// <param name="mouseData">(Optional) For an X Button Down or Up, we need to retrieve which X Button was pressed and the information is stored on the mouseData variable.</param>
        /// <returns></returns>
        GHMouseButtons MouseMessageToGHMouseButton(InternalGlobalMouseHook.MouseMessages button, uint mouseData = 0)
        {
            switch (button) //We need to check which button was pressed and we need to return the associated GHMouseButton enumeration.
            {
                case InternalGlobalMouseHook.MouseMessages.WM_LBUTTONDOWN:
                    return GHMouseButtons.Left;
                case InternalGlobalMouseHook.MouseMessages.WM_LBUTTONUP:
                    return GHMouseButtons.Left;
                case InternalGlobalMouseHook.MouseMessages.WM_MBUTTONDOWN:
                    return GHMouseButtons.Middle;
                case InternalGlobalMouseHook.MouseMessages.WM_MBUTTONUP:
                    return GHMouseButtons.Middle;
                case InternalGlobalMouseHook.MouseMessages.WM_RBUTTONDOWN:
                    return GHMouseButtons.Right;
                case InternalGlobalMouseHook.MouseMessages.WM_RBUTTONUP:
                    return GHMouseButtons.Right;
                case InternalGlobalMouseHook.MouseMessages.WM_XBUTTONDOWN:
                    if ((InternalGlobalMouseHook.XButtons)Helper.GetUnsignedHWORD(mouseData) == InternalGlobalMouseHook.XButtons.WM_XBUTTON1) //The high order word stored in mouseData tells us which button was clicked. We need to get that by using the GetUnsignedHWord helper method.
                        return GHMouseButtons.XButton1;
                    else
                        return GHMouseButtons.XButton2;
                case InternalGlobalMouseHook.MouseMessages.WM_XBUTTONUP:
                    if ((InternalGlobalMouseHook.XButtons)Helper.GetUnsignedHWORD(mouseData) == InternalGlobalMouseHook.XButtons.WM_XBUTTON1)
                        return GHMouseButtons.XButton1;
                    else
                        return GHMouseButtons.XButton2;
                default:
                    return GHMouseButtons.None;
            }

        }


        //The built in GC doesn't know that there is a System Hook installed. We must handle the disposal ourselves when this instance of the class is disposed.
        public void Dispose()
        {
            singleton = null; //Set the value of the singleton to nothing as we are disposing this instance.
            _globalMouseHook?.Dispose(); //We also need to dispose of the GlobalMouseHook instance that we created.
            OnButtonDown = null;
            OnButtonUp = null;
            OnMouseMove = null;
            OnMouseWheelScroll = null;
        }
        
    }

    /// <summary>
    /// Contains the information about the Mouse Event that has occured. (e.g. Mouse button that was pressed; The location of the mouse pointer.)
    /// </summary>
    public class GlobalMouseEventArgs : HandledEventArgs
    {
        /// <summary>
        /// Indicates which button was pressed or was let go. Only applicable for OnMouseDown and OnMouseUp.
        /// </summary>
        public GHMouseButtons Button { get; internal set; }
        /// <summary>
        /// Indicates the location of the mouse pointer on the screen as the event occured.
        /// </summary>
        public MousePosition PointerPos { get; internal set; }
        /// <summary>
        /// Indicates the rotation of the Scroll Wheel. Only applicable for OnMouseWheelScroll.
        /// </summary>
        public WheelRotation wheelRotation { get; internal set; }
        public GlobalMouseEventArgs(GHMouseButtons _button, MousePosition _pos, WheelRotation _wheelRot = WheelRotation.None)
        {
            Button = _button;
            PointerPos = _pos;
            wheelRotation = _wheelRot;
        }
    }
}
