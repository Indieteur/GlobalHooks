namespace Demo
{
    partial class frmDemo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnKeyHook = new System.Windows.Forms.Button();
            this.btnMouseHook = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusADisableTricks = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripMousePos = new System.Windows.Forms.ToolStripStatusLabel();
            this.listLog = new System.Windows.Forms.ListBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.checkNotLogModifier = new System.Windows.Forms.CheckBox();
            this.checkNoLogKeyPress = new System.Windows.Forms.CheckBox();
            this.checkNoLogScrollWheel = new System.Windows.Forms.CheckBox();
            this.checkNoLogMouseMove = new System.Windows.Forms.CheckBox();
            this.groupKeysLogSettings = new System.Windows.Forms.GroupBox();
            this.checkNoLogKeyUp = new System.Windows.Forms.CheckBox();
            this.checkNoLogKeyDown = new System.Windows.Forms.CheckBox();
            this.groupMouseLogSettings = new System.Windows.Forms.GroupBox();
            this.checkNoLogButtonDown = new System.Windows.Forms.CheckBox();
            this.checkNoLogButtonUp = new System.Windows.Forms.CheckBox();
            this.checkDisableAltF4 = new System.Windows.Forms.CheckBox();
            this.checkDisableNotABC = new System.Windows.Forms.CheckBox();
            this.checkNoLeftMouse = new System.Windows.Forms.CheckBox();
            this.checkNoScroll = new System.Windows.Forms.CheckBox();
            this.groupTricks = new System.Windows.Forms.GroupBox();
            this.checkNoMiddleMouse = new System.Windows.Forms.CheckBox();
            this.checkNoMouseMove = new System.Windows.Forms.CheckBox();
            this.checkNoRightMouse = new System.Windows.Forms.CheckBox();
            this.statusStrip.SuspendLayout();
            this.groupKeysLogSettings.SuspendLayout();
            this.groupMouseLogSettings.SuspendLayout();
            this.groupTricks.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnKeyHook
            // 
            this.btnKeyHook.Location = new System.Drawing.Point(469, 44);
            this.btnKeyHook.Name = "btnKeyHook";
            this.btnKeyHook.Size = new System.Drawing.Size(152, 27);
            this.btnKeyHook.TabIndex = 1;
            this.btnKeyHook.Text = "Install Keyboard Hook";
            this.btnKeyHook.UseVisualStyleBackColor = true;
            this.btnKeyHook.Click += new System.EventHandler(this.btnKeyHook_Click);
            // 
            // btnMouseHook
            // 
            this.btnMouseHook.Location = new System.Drawing.Point(469, 77);
            this.btnMouseHook.Name = "btnMouseHook";
            this.btnMouseHook.Size = new System.Drawing.Size(152, 27);
            this.btnMouseHook.TabIndex = 2;
            this.btnMouseHook.Text = "Install Mouse Hook";
            this.btnMouseHook.UseVisualStyleBackColor = true;
            this.btnMouseHook.Click += new System.EventHandler(this.btnMouseHook_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusADisableTricks,
            this.toolStripMousePos});
            this.statusStrip.Location = new System.Drawing.Point(0, 436);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(633, 25);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusADisableTricks
            // 
            this.statusADisableTricks.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusADisableTricks.ForeColor = System.Drawing.SystemColors.Control;
            this.statusADisableTricks.Name = "statusADisableTricks";
            this.statusADisableTricks.Size = new System.Drawing.Size(433, 20);
            this.statusADisableTricks.Text = "Press the A key to untick all checkboxes under the Tricks settings.";
            // 
            // toolStripMousePos
            // 
            this.toolStripMousePos.Name = "toolStripMousePos";
            this.toolStripMousePos.Size = new System.Drawing.Size(145, 20);
            this.toolStripMousePos.Spring = true;
            this.toolStripMousePos.Text = "Pointer Position: (0, 0)";
            this.toolStripMousePos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listLog
            // 
            this.listLog.FormattingEnabled = true;
            this.listLog.HorizontalScrollbar = true;
            this.listLog.Location = new System.Drawing.Point(12, 13);
            this.listLog.Name = "listLog";
            this.listLog.Size = new System.Drawing.Size(441, 173);
            this.listLog.TabIndex = 5;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(469, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(152, 26);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear Log";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // checkNotLogModifier
            // 
            this.checkNotLogModifier.AutoSize = true;
            this.checkNotLogModifier.Location = new System.Drawing.Point(6, 23);
            this.checkNotLogModifier.Name = "checkNotLogModifier";
            this.checkNotLogModifier.Size = new System.Drawing.Size(188, 17);
            this.checkNotLogModifier.TabIndex = 7;
            this.checkNotLogModifier.Text = "Don\'t Capture Modifier Key Events";
            this.checkNotLogModifier.UseVisualStyleBackColor = true;
            // 
            // checkNoLogKeyPress
            // 
            this.checkNoLogKeyPress.AutoSize = true;
            this.checkNoLogKeyPress.Location = new System.Drawing.Point(6, 46);
            this.checkNoLogKeyPress.Name = "checkNoLogKeyPress";
            this.checkNoLogKeyPress.Size = new System.Drawing.Size(182, 17);
            this.checkNoLogKeyPress.TabIndex = 8;
            this.checkNoLogKeyPress.Text = "Don\'t Capture OnKeyPress event";
            this.checkNoLogKeyPress.UseVisualStyleBackColor = true;
            // 
            // checkNoLogScrollWheel
            // 
            this.checkNoLogScrollWheel.AutoSize = true;
            this.checkNoLogScrollWheel.Location = new System.Drawing.Point(6, 24);
            this.checkNoLogScrollWheel.Name = "checkNoLogScrollWheel";
            this.checkNoLogScrollWheel.Size = new System.Drawing.Size(227, 17);
            this.checkNoLogScrollWheel.TabIndex = 9;
            this.checkNoLogScrollWheel.Text = "Don\'t Capture OnMouseWheelScroll event";
            this.checkNoLogScrollWheel.UseVisualStyleBackColor = true;
            // 
            // checkNoLogMouseMove
            // 
            this.checkNoLogMouseMove.AutoSize = true;
            this.checkNoLogMouseMove.Location = new System.Drawing.Point(6, 47);
            this.checkNoLogMouseMove.Name = "checkNoLogMouseMove";
            this.checkNoLogMouseMove.Size = new System.Drawing.Size(197, 17);
            this.checkNoLogMouseMove.TabIndex = 10;
            this.checkNoLogMouseMove.Text = "Don\'t Capture OnMouseMove event";
            this.checkNoLogMouseMove.UseVisualStyleBackColor = true;
            // 
            // groupKeysLogSettings
            // 
            this.groupKeysLogSettings.Controls.Add(this.checkNoLogKeyUp);
            this.groupKeysLogSettings.Controls.Add(this.checkNoLogKeyDown);
            this.groupKeysLogSettings.Controls.Add(this.checkNotLogModifier);
            this.groupKeysLogSettings.Controls.Add(this.checkNoLogKeyPress);
            this.groupKeysLogSettings.Location = new System.Drawing.Point(12, 192);
            this.groupKeysLogSettings.Name = "groupKeysLogSettings";
            this.groupKeysLogSettings.Size = new System.Drawing.Size(308, 116);
            this.groupKeysLogSettings.TabIndex = 11;
            this.groupKeysLogSettings.TabStop = false;
            this.groupKeysLogSettings.Text = "Global Key Hook Log Settings";
            // 
            // checkNoLogKeyUp
            // 
            this.checkNoLogKeyUp.AutoSize = true;
            this.checkNoLogKeyUp.Location = new System.Drawing.Point(6, 92);
            this.checkNoLogKeyUp.Name = "checkNoLogKeyUp";
            this.checkNoLogKeyUp.Size = new System.Drawing.Size(170, 17);
            this.checkNoLogKeyUp.TabIndex = 10;
            this.checkNoLogKeyUp.Text = "Don\'t Capture OnKeyUp event";
            this.checkNoLogKeyUp.UseVisualStyleBackColor = true;
            // 
            // checkNoLogKeyDown
            // 
            this.checkNoLogKeyDown.AutoSize = true;
            this.checkNoLogKeyDown.Location = new System.Drawing.Point(6, 69);
            this.checkNoLogKeyDown.Name = "checkNoLogKeyDown";
            this.checkNoLogKeyDown.Size = new System.Drawing.Size(184, 17);
            this.checkNoLogKeyDown.TabIndex = 9;
            this.checkNoLogKeyDown.Text = "Don\'t Capture OnKeyDown event";
            this.checkNoLogKeyDown.UseVisualStyleBackColor = true;
            // 
            // groupMouseLogSettings
            // 
            this.groupMouseLogSettings.Controls.Add(this.checkNoLogButtonDown);
            this.groupMouseLogSettings.Controls.Add(this.checkNoLogButtonUp);
            this.groupMouseLogSettings.Controls.Add(this.checkNoLogScrollWheel);
            this.groupMouseLogSettings.Controls.Add(this.checkNoLogMouseMove);
            this.groupMouseLogSettings.Location = new System.Drawing.Point(326, 191);
            this.groupMouseLogSettings.Name = "groupMouseLogSettings";
            this.groupMouseLogSettings.Size = new System.Drawing.Size(295, 117);
            this.groupMouseLogSettings.TabIndex = 12;
            this.groupMouseLogSettings.TabStop = false;
            this.groupMouseLogSettings.Text = "Global Mouse Hook Log Settings";
            // 
            // checkNoLogButtonDown
            // 
            this.checkNoLogButtonDown.AutoSize = true;
            this.checkNoLogButtonDown.Location = new System.Drawing.Point(6, 70);
            this.checkNoLogButtonDown.Name = "checkNoLogButtonDown";
            this.checkNoLogButtonDown.Size = new System.Drawing.Size(197, 17);
            this.checkNoLogButtonDown.TabIndex = 11;
            this.checkNoLogButtonDown.Text = "Don\'t Capture OnButtonDown event";
            this.checkNoLogButtonDown.UseVisualStyleBackColor = true;
            // 
            // checkNoLogButtonUp
            // 
            this.checkNoLogButtonUp.AutoSize = true;
            this.checkNoLogButtonUp.Location = new System.Drawing.Point(6, 93);
            this.checkNoLogButtonUp.Name = "checkNoLogButtonUp";
            this.checkNoLogButtonUp.Size = new System.Drawing.Size(183, 17);
            this.checkNoLogButtonUp.TabIndex = 12;
            this.checkNoLogButtonUp.Text = "Don\'t Capture OnButtonUp event";
            this.checkNoLogButtonUp.UseVisualStyleBackColor = true;
            // 
            // checkDisableAltF4
            // 
            this.checkDisableAltF4.AutoSize = true;
            this.checkDisableAltF4.Location = new System.Drawing.Point(6, 19);
            this.checkDisableAltF4.Name = "checkDisableAltF4";
            this.checkDisableAltF4.Size = new System.Drawing.Size(159, 17);
            this.checkDisableAltF4.TabIndex = 11;
            this.checkDisableAltF4.Text = "Disable Alt + F4 For All Apps";
            this.checkDisableAltF4.UseVisualStyleBackColor = true;
            // 
            // checkDisableNotABC
            // 
            this.checkDisableNotABC.AutoSize = true;
            this.checkDisableNotABC.Location = new System.Drawing.Point(6, 42);
            this.checkDisableNotABC.Name = "checkDisableNotABC";
            this.checkDisableNotABC.Size = new System.Drawing.Size(206, 17);
            this.checkDisableNotABC.TabIndex = 12;
            this.checkDisableNotABC.Text = "Disable All Keys Except for A, B and C";
            this.checkDisableNotABC.UseVisualStyleBackColor = true;
            // 
            // checkNoLeftMouse
            // 
            this.checkNoLeftMouse.AutoSize = true;
            this.checkNoLeftMouse.Enabled = false;
            this.checkNoLeftMouse.Location = new System.Drawing.Point(6, 88);
            this.checkNoLeftMouse.Name = "checkNoLeftMouse";
            this.checkNoLeftMouse.Size = new System.Drawing.Size(151, 17);
            this.checkNoLeftMouse.TabIndex = 13;
            this.checkNoLeftMouse.Text = "Disable Left Mouse Button";
            this.checkNoLeftMouse.UseVisualStyleBackColor = true;
            // 
            // checkNoScroll
            // 
            this.checkNoScroll.AutoSize = true;
            this.checkNoScroll.Location = new System.Drawing.Point(6, 65);
            this.checkNoScroll.Name = "checkNoScroll";
            this.checkNoScroll.Size = new System.Drawing.Size(124, 17);
            this.checkNoScroll.TabIndex = 14;
            this.checkNoScroll.Text = "Disable Scroll Wheel";
            this.checkNoScroll.UseVisualStyleBackColor = true;
            // 
            // groupTricks
            // 
            this.groupTricks.Controls.Add(this.checkNoMiddleMouse);
            this.groupTricks.Controls.Add(this.checkNoMouseMove);
            this.groupTricks.Controls.Add(this.checkNoRightMouse);
            this.groupTricks.Controls.Add(this.checkNoLeftMouse);
            this.groupTricks.Controls.Add(this.checkDisableNotABC);
            this.groupTricks.Controls.Add(this.checkNoScroll);
            this.groupTricks.Controls.Add(this.checkDisableAltF4);
            this.groupTricks.Location = new System.Drawing.Point(12, 314);
            this.groupTricks.Name = "groupTricks";
            this.groupTricks.Size = new System.Drawing.Size(609, 114);
            this.groupTricks.TabIndex = 15;
            this.groupTricks.TabStop = false;
            this.groupTricks.Text = "Tricks";
            // 
            // checkNoMiddleMouse
            // 
            this.checkNoMiddleMouse.AutoSize = true;
            this.checkNoMiddleMouse.Location = new System.Drawing.Point(320, 42);
            this.checkNoMiddleMouse.Name = "checkNoMiddleMouse";
            this.checkNoMiddleMouse.Size = new System.Drawing.Size(164, 17);
            this.checkNoMiddleMouse.TabIndex = 17;
            this.checkNoMiddleMouse.Text = "Disable Middle Mouse Button";
            this.checkNoMiddleMouse.UseVisualStyleBackColor = true;
            // 
            // checkNoMouseMove
            // 
            this.checkNoMouseMove.AutoSize = true;
            this.checkNoMouseMove.Enabled = false;
            this.checkNoMouseMove.Location = new System.Drawing.Point(320, 65);
            this.checkNoMouseMove.Name = "checkNoMouseMove";
            this.checkNoMouseMove.Size = new System.Drawing.Size(144, 17);
            this.checkNoMouseMove.TabIndex = 16;
            this.checkNoMouseMove.Text = "Disable Move Movement";
            this.checkNoMouseMove.UseVisualStyleBackColor = true;
            // 
            // checkNoRightMouse
            // 
            this.checkNoRightMouse.AutoSize = true;
            this.checkNoRightMouse.Location = new System.Drawing.Point(320, 19);
            this.checkNoRightMouse.Name = "checkNoRightMouse";
            this.checkNoRightMouse.Size = new System.Drawing.Size(158, 17);
            this.checkNoRightMouse.TabIndex = 15;
            this.checkNoRightMouse.Text = "Disable Right Mouse Button";
            this.checkNoRightMouse.UseVisualStyleBackColor = true;
            // 
            // frmDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 461);
            this.Controls.Add(this.groupTricks);
            this.Controls.Add(this.groupMouseLogSettings);
            this.Controls.Add(this.groupKeysLogSettings);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.listLog);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.btnMouseHook);
            this.Controls.Add(this.btnKeyHook);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmDemo";
            this.ShowIcon = false;
            this.Text = "Global Hooks Demo";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupKeysLogSettings.ResumeLayout(false);
            this.groupKeysLogSettings.PerformLayout();
            this.groupMouseLogSettings.ResumeLayout(false);
            this.groupMouseLogSettings.PerformLayout();
            this.groupTricks.ResumeLayout(false);
            this.groupTricks.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKeyHook;
        private System.Windows.Forms.Button btnMouseHook;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripMousePos;
        private System.Windows.Forms.ListBox listLog;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox checkNotLogModifier;
        private System.Windows.Forms.CheckBox checkNoLogKeyPress;
        private System.Windows.Forms.CheckBox checkNoLogScrollWheel;
        private System.Windows.Forms.CheckBox checkNoLogMouseMove;
        private System.Windows.Forms.GroupBox groupKeysLogSettings;
        private System.Windows.Forms.CheckBox checkNoLogKeyUp;
        private System.Windows.Forms.CheckBox checkNoLogKeyDown;
        private System.Windows.Forms.GroupBox groupMouseLogSettings;
        private System.Windows.Forms.CheckBox checkNoLogButtonDown;
        private System.Windows.Forms.CheckBox checkNoLogButtonUp;
        private System.Windows.Forms.CheckBox checkDisableNotABC;
        private System.Windows.Forms.CheckBox checkDisableAltF4;
        private System.Windows.Forms.CheckBox checkNoLeftMouse;
        private System.Windows.Forms.CheckBox checkNoScroll;
        private System.Windows.Forms.GroupBox groupTricks;
        private System.Windows.Forms.CheckBox checkNoRightMouse;
        private System.Windows.Forms.CheckBox checkNoMouseMove;
        private System.Windows.Forms.CheckBox checkNoMiddleMouse;
        private System.Windows.Forms.ToolStripStatusLabel statusADisableTricks;
    }
}

