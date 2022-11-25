using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Indieteur.GlobalHooks;
using System.Timers;

namespace Demo
{

    public partial class frmDemo : Form
    {
        //It's best that we store the text that will appear on the btnKeyHook and btnMouseHook at the top part of the code so it'll be easier for us to edit it.
        const string INSTALL_KEY_HOOK = "Install Keyboard Hook";
        const string REMOVE_KEY_HOOK = "Remove Keyboard Hook";
        const string INSTALL_MOUSE_HOOK = "Install Mouse Hook";
        const string REMOVE_MOUSE_HOOK = "Remove Mouse Hook";

        GlobalKeyHook globalKeyHook;
        GlobalMouseHook globalMouseHook;
        
        public frmDemo()
        {
            InitializeComponent();

        }

        private void btnKeyHook_Click(object sender, EventArgs e)
        {
            //We check if globalKeyHook is instantiated or not.
            if (globalKeyHook == null)
            {
                //If the globalKeyhook isn't created, we instantiate it and subscribe to the available events.
                globalKeyHook = new GlobalKeyHook();
                globalKeyHook.OnKeyDown += GlobalKeyHook_OnKeyDown;
                globalKeyHook.OnKeyPressed += GlobalKeyHook_OnKeyPressed;
                globalKeyHook.OnKeyUp += GlobalKeyHook_OnKeyUp;

                //We also need to change the text of the button itself to let the user know that he or she can remove the key hook by clicking it.
                btnKeyHook.Text = REMOVE_KEY_HOOK;

                //Enable the disable left mouse button and mouse movement checkboxes as we can now detect key press for the A key.
                checkNoMouseMove.Enabled = true;
                checkNoLeftMouse.Enabled = true;

                //Also make the status label text which tells us how to disble tricks via keyboard, visible by changing the font color.
                statusADisableTricks.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            }
            else
            {
                //If the globablKeyHook is already created, we dispose the instance.
                globalKeyHook.Dispose();
                globalKeyHook = null; //Probably not needed but just to be sure.

                //Change the text of the button itself to its defaults.
                btnKeyHook.Text = INSTALL_KEY_HOOK;

                //Uncheck and disable the disable left mouse button and mouse movement checkboxes as we do not have anyways of unticking it.
                checkNoLeftMouse.Checked = false;
                checkNoMouseMove.Checked = false;
                checkNoMouseMove.Enabled = false;
                checkNoLeftMouse.Enabled = false;

                // Also make the status label text which tells us how to disble tricks via keyboard, not visible by changing the font color.
                statusADisableTricks.ForeColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        private void GlobalKeyHook_OnKeyUp(object sender, GlobalKeyEventArgs e)
        {
            //Log modifier key up if the checkNotLogModifier checkbox is not checked.
            if (!(checkNotLogModifier.Checked && e.IsModifierKey))
            {
                if(!checkNoLogKeyUp.Checked)
                    listLog.Items.Add(Misc.MakeKeyLog(e, Misc.KeyEventType.OnKeyUp)); //Our Helper method MakeKeyLog will make the log text for us. We just need to add it it to listLog.
            }

            //If checkDisableAltF4 checkbox is checked and we released alt + F4, let our system know that we are handling the input thus disabling it.
            if (checkDisableAltF4.Checked && (e.Alt != ModifierKeySide.None && e.KeyCode == VirtualKeycodes.F4))
            {
                e.Handled = true;
                return;
            }

            //If checkDisableNotABC checkbox is checked and we released any keys besides A, B and C, let our system know that we are handling the input which in effect disabling it.
            if (checkDisableNotABC.Checked && (e.KeyCode < VirtualKeycodes.A || e.KeyCode > VirtualKeycodes.C))
            {
                e.Handled = true;
                return;
            }
        }

        private void GlobalKeyHook_OnKeyPressed(object sender, GlobalKeyEventArgs e)
        {
            //Log modifier key press if the checkNotLogModifier checkbox is not checked.
            if (!(checkNotLogModifier.Checked && e.IsModifierKey))
            {
                //If checkNoKeyPress is checked, we are not going to make a log for the key press event.
                if (!checkNoLogKeyPress.Checked)
                    listLog.Items.Add(Misc.MakeKeyLog(e, Misc.KeyEventType.OnKeyPress));
            }

            //If checkDisableAltF4 checkbox is checked and we are pressing alt + F4, let our system know that we are handling the input thus disabling it.
            if (checkDisableAltF4.Checked && (e.Alt != ModifierKeySide.None && e.KeyCode == VirtualKeycodes.F4))
            {
                e.Handled = true;
                return;
            }

            //If checkDisableNotABC checkbox is checked and we are pressing any keys besides A, B and C, let our system know that we are handling the input which in effect disabling it.
            if (checkDisableNotABC.Checked && (e.KeyCode < VirtualKeycodes.A || e.KeyCode > VirtualKeycodes.C))
            {
                e.Handled = true;
                return;
            }
        }

        private void GlobalKeyHook_OnKeyDown(object sender, GlobalKeyEventArgs e)
        {
            //Log modifier keys if the checkNotLogModifier checkbox is not checked.
            if (!(checkNotLogModifier.Checked && e.IsModifierKey))
            {
                if (!checkNoLogKeyDown.Checked)
                    listLog.Items.Add(Misc.MakeKeyLog(e, Misc.KeyEventType.OnKeyDown));
            }

            //If checkDisableAltF4 checkbox is checked and we are pressing alt + F4, let our system know that we are handling the input which in effect disabling it.
            if (checkDisableAltF4.Checked && (e.Alt != ModifierKeySide.None && e.KeyCode == VirtualKeycodes.F4))
            {
                e.Handled = true;
                return;
            }

            //If checkDisableNotABC checkbox is checked and we are pressing any keys besides A, B and C, let our system know that we are handling the input which in effect disabling it.
            if (checkDisableNotABC.Checked && (e.KeyCode < VirtualKeycodes.A || e.KeyCode > VirtualKeycodes.C))
            {
                e.Handled = true;
                return;
            }

            //Reset all the tricks by checking if we pressed the A key.
            if (e.KeyCode == VirtualKeycodes.A)
            {
                DisableAllTricks();
                return;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listLog.Items.Clear();
        }

        private void btnMouseHook_Click(object sender, EventArgs e)
        {
            //Let's check if the globablMouseHook is instantiated.
            if (globalMouseHook == null)
            {
                //If it is not created, we instantiate it and subscribe to the available events.
                globalMouseHook = new GlobalMouseHook();
                globalMouseHook.OnButtonDown += GlobalMouseHook_OnButtonDown;
                globalMouseHook.OnButtonUp += GlobalMouseHook_OnButtonUp;
                globalMouseHook.OnMouseMove += GlobalMouseHook_OnMouseMove;
                globalMouseHook.OnMouseWheelScroll += GlobalMouseHook_OnMouseWheelScroll;

                //Let's also change the text of the button to let the user know that he or she can remove the mouse hook
                btnMouseHook.Text = REMOVE_MOUSE_HOOK;
            }
            else
            {
                //If there's already an instance of globalMouseHook, we have to destroy it.
                globalMouseHook.Dispose();
                globalMouseHook = null; //Probably not needed but just to be sure.

                //Set the text of the button back to the original prompt.
                btnMouseHook.Text = INSTALL_MOUSE_HOOK;

            }
        }

        private void GlobalMouseHook_OnMouseWheelScroll(object sender, GlobalMouseEventArgs e)
        {
            //We shouldn't make a log for this if the checkNoScrollWheel checkbox is checked.
            if (!checkNoLogScrollWheel.Checked)
            {
                StringBuilder logText = new StringBuilder("Mouse: Scroll Wheel has been rotated "); //Let's start buliding the log text.

                logText.Append(e.wheelRotation.ToString()); //Append the rotation of the scroll wheel.
                logText.Append(" " + Misc.MousePositionToString(e.PointerPos)); //Append the position of the mouse pointer on the screen as the event occured.

                listLog.Items.Add(logText.ToString()); //Build the log text and it to the log.
            }

            //if checkNoScroll checkbox is checked, disable our scroll wheel by letting the system know that we are handling scroll events.
            if (checkNoScroll.Checked)
            {
                e.Handled = true;
                return;
            }

        }

        private void GlobalMouseHook_OnMouseMove(object sender, GlobalMouseEventArgs e)
        {
            //This is a very cool trick but very dangerous as well. This has an effect of disabling mouse movement by letting our system know that we have handled the event.
            if (checkNoMouseMove.Checked)
            {
                e.Handled = true;
                return;
            }

            //Update the status bar only if checkNoMouseMove checkbox is not checked.
            if (!checkNoLogMouseMove.Checked)
            {
                string pointerStatus = "Pointer Position: (" + e.PointerPos.X.ToString() + "," + e.PointerPos.Y.ToString() + ")"; //Let's not do StringBuilder for this one.
                toolStripMousePos.Text = pointerStatus; //Update the status bar
            }
        }

        private void GlobalMouseHook_OnButtonUp(object sender, GlobalMouseEventArgs e)
        {
            //Create a log only if checkNoButtonUp checkbox is not checked.
            if (!checkNoLogButtonUp.Checked)
            {
                StringBuilder logText = new StringBuilder("Mouse: "); //Start building our log

                logText.Append(e.Button.ToString()); //Append the button that was released.
                logText.Append(" has been released. ");

                logText.Append(Misc.MousePositionToString(e.PointerPos)); //Append the position of the mouse as the event occured.

                listLog.Items.Add(logText.ToString()); //Add the log to our list of logs.
            }

            //If checkNoLeftMouse checkbox is checked and we pressed the left mouse button, we tell the system that we handled the event which disables it.
            if (checkNoLeftMouse.Checked && e.Button == GHMouseButtons.Left)
            {
                e.Handled = true;
                return;
            }
            //If checkNoRightMouse checkbox is checked and we pressed the right mouse button, we tell the system that we handled the event which disables it.
            if (checkNoRightMouse.Checked && e.Button == GHMouseButtons.Right)
            {
                e.Handled = true;
                return;
            }
            //If checkNoMiddleMouse checkbox is checked and we pressed the middle mouse button, we tell the system that we handled the event which disables it.
            if (checkNoMiddleMouse.Checked && e.Button == GHMouseButtons.Middle)
            {
                e.Handled = true;
                return;
            }
        }

        private void GlobalMouseHook_OnButtonDown(object sender, GlobalMouseEventArgs e)
        {
            //Create a log only if checkNoButtonDown checkbox is not checked.
            if (!checkNoLogButtonDown.Checked)
            {
                StringBuilder logText = new StringBuilder("Mouse: "); //Start building our log

                logText.Append(e.Button.ToString()); //Append the button that was pressed.
                logText.Append(" has been pressed. ");

                logText.Append(Misc.MousePositionToString(e.PointerPos)); //Append the position of the mouse as the event occured.

                listLog.Items.Add(logText.ToString()); //Add the log to our list of logs.
            }

            //If checkNoLeftMouse checkbox is checked and we pressed the left mouse button, we tell the system that we handled the event which disables it.
            if (checkNoLeftMouse.Checked && e.Button == GHMouseButtons.Left)
            {
                e.Handled = true;
                return;
            }
            //If checkNoRightMouse checkbox is checked and we pressed the right mouse button, we tell the system that we handled the event which disables it.
            if (checkNoRightMouse.Checked && e.Button == GHMouseButtons.Right)
            {
                e.Handled = true;
                return;
            }
            //If checkNoMiddleMouse checkbox is checked and we pressed the middle mouse button, we tell the system that we handled the event which disables it.
            if (checkNoMiddleMouse.Checked && e.Button == GHMouseButtons.Middle)
            {
                e.Handled = true;
                return;
            }
        }
        
        //This function unticks all checkboxes under the Tricks settings.
        void DisableAllTricks()
        {
            checkDisableAltF4.Checked = false;
            checkDisableNotABC.Checked = false;
            checkNoScroll.Checked = false;
            checkNoLeftMouse.Checked = false;
            checkNoRightMouse.Checked = false;
            checkNoMiddleMouse.Checked = false;
            checkNoMouseMove.Checked = false;
        }
    }
}
