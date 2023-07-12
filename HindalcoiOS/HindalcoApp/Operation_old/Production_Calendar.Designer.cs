
namespace RMPCLApp.Operation
{
    partial class Production_Calendar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Production_Calendar));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges5 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges6 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkEdit = new System.Windows.Forms.CheckBox();
            this.txtNoDays = new System.Windows.Forms.TextBox();
            this.lblDaysErr = new Bunifu.UI.WinForms.BunifuLabel();
            this.lblMonErr = new Bunifu.UI.WinForms.BunifuLabel();
            this.btnCancel = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnSave = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.cmbMonthCalendar = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkEdit);
            this.panel1.Controls.Add(this.txtNoDays);
            this.panel1.Controls.Add(this.lblDaysErr);
            this.panel1.Controls.Add(this.lblMonErr);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.cmbMonthCalendar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 191);
            this.panel1.TabIndex = 0;
            // 
            // chkEdit
            // 
            this.chkEdit.AutoSize = true;
            this.chkEdit.Location = new System.Drawing.Point(16, 143);
            this.chkEdit.Name = "chkEdit";
            this.chkEdit.Size = new System.Drawing.Size(106, 20);
            this.chkEdit.TabIndex = 142;
            this.chkEdit.Text = "Edit Calendar";
            this.chkEdit.UseVisualStyleBackColor = true;
            this.chkEdit.CheckedChanged += new System.EventHandler(this.chkEdit_CheckedChanged);
            // 
            // txtNoDays
            // 
            this.txtNoDays.Location = new System.Drawing.Point(434, 53);
            this.txtNoDays.MaxLength = 2;
            this.txtNoDays.Name = "txtNoDays";
            this.txtNoDays.Size = new System.Drawing.Size(181, 23);
            this.txtNoDays.TabIndex = 141;
            this.txtNoDays.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtNoDays.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNoDays_KeyDown);
            this.txtNoDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoDays_KeyPress);
            this.txtNoDays.Leave += new System.EventHandler(this.txtNoDays_Leave);
            this.txtNoDays.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtNoDays_MouseDown);
            this.txtNoDays.MouseLeave += new System.EventHandler(this.txtNoDays_MouseLeave);
            // 
            // lblDaysErr
            // 
            this.lblDaysErr.AllowParentOverrides = false;
            this.lblDaysErr.AutoEllipsis = false;
            this.lblDaysErr.CursorType = null;
            this.lblDaysErr.Font = new System.Drawing.Font("Times New Roman", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDaysErr.ForeColor = System.Drawing.Color.Red;
            this.lblDaysErr.Location = new System.Drawing.Point(621, 56);
            this.lblDaysErr.Name = "lblDaysErr";
            this.lblDaysErr.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDaysErr.Size = new System.Drawing.Size(11, 24);
            this.lblDaysErr.TabIndex = 140;
            this.lblDaysErr.Text = "*";
            this.lblDaysErr.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblDaysErr.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.lblDaysErr.Visible = false;
            // 
            // lblMonErr
            // 
            this.lblMonErr.AllowParentOverrides = false;
            this.lblMonErr.AutoEllipsis = false;
            this.lblMonErr.CursorType = null;
            this.lblMonErr.Font = new System.Drawing.Font("Times New Roman", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonErr.ForeColor = System.Drawing.Color.Red;
            this.lblMonErr.Location = new System.Drawing.Point(320, 56);
            this.lblMonErr.Name = "lblMonErr";
            this.lblMonErr.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMonErr.Size = new System.Drawing.Size(11, 24);
            this.lblMonErr.TabIndex = 139;
            this.lblMonErr.Text = "*";
            this.lblMonErr.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblMonErr.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.lblMonErr.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.AllowAnimations = true;
            this.btnCancel.AllowMouseEffects = true;
            this.btnCancel.AllowToggling = false;
            this.btnCancel.AllowV2Features = false;
            this.btnCancel.AnimationSpeed = 200;
            this.btnCancel.AutoGenerateColors = false;
            this.btnCancel.AutoRoundBorders = true;
            this.btnCancel.AutoSizeLeftIcon = true;
            this.btnCancel.AutoSizeRightIcon = true;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCancel.ButtonText = "Cancel";
            this.btnCancel.ButtonTextMarginLeft = 0;
            this.btnCancel.ColorContrastOnClick = 45;
            this.btnCancel.ColorContrastOnHover = 45;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges5.BottomLeft = true;
            borderEdges5.BottomRight = true;
            borderEdges5.TopLeft = true;
            borderEdges5.TopRight = true;
            this.btnCancel.CustomizableEdges = borderEdges5;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancel.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnCancel.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnCancel.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnCancel.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnCancel.IconMarginLeft = 11;
            this.btnCancel.IconPadding = 10;
            this.btnCancel.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnCancel.IconSize = 25;
            this.btnCancel.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.IdleBorderRadius = 37;
            this.btnCancel.IdleBorderThickness = 1;
            this.btnCancel.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.IdleIconLeftImage = null;
            this.btnCancel.IdleIconRightImage = null;
            this.btnCancel.IndicateFocus = false;
            this.btnCancel.Location = new System.Drawing.Point(361, 124);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnCancel.OnDisabledState.BorderRadius = 1;
            this.btnCancel.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCancel.OnDisabledState.BorderThickness = 1;
            this.btnCancel.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnCancel.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnCancel.OnDisabledState.IconLeftImage = null;
            this.btnCancel.OnDisabledState.IconRightImage = null;
            this.btnCancel.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnCancel.onHoverState.BorderRadius = 1;
            this.btnCancel.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCancel.onHoverState.BorderThickness = 1;
            this.btnCancel.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnCancel.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnCancel.onHoverState.IconLeftImage = null;
            this.btnCancel.onHoverState.IconRightImage = null;
            this.btnCancel.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.OnIdleState.BorderRadius = 1;
            this.btnCancel.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCancel.OnIdleState.BorderThickness = 1;
            this.btnCancel.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnCancel.OnIdleState.IconLeftImage = null;
            this.btnCancel.OnIdleState.IconRightImage = null;
            this.btnCancel.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnCancel.OnPressedState.BorderRadius = 1;
            this.btnCancel.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnCancel.OnPressedState.BorderThickness = 1;
            this.btnCancel.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnCancel.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnCancel.OnPressedState.IconLeftImage = null;
            this.btnCancel.OnPressedState.IconRightImage = null;
            this.btnCancel.Size = new System.Drawing.Size(93, 39);
            this.btnCancel.TabIndex = 129;
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnCancel.TextMarginLeft = 0;
            this.btnCancel.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnCancel.UseDefaultRadiusAndThickness = true;
            this.btnCancel.Click += new System.EventHandler(this.bunifuButton3_Click);
            // 
            // btnSave
            // 
            this.btnSave.AllowAnimations = true;
            this.btnSave.AllowDrop = true;
            this.btnSave.AllowMouseEffects = true;
            this.btnSave.AllowToggling = true;
            this.btnSave.AllowV2Features = false;
            this.btnSave.AnimationSpeed = 200;
            this.btnSave.AutoGenerateColors = false;
            this.btnSave.AutoRoundBorders = true;
            this.btnSave.AutoSizeLeftIcon = true;
            this.btnSave.AutoSizeRightIcon = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSave.ButtonText = "Save";
            this.btnSave.ButtonTextMarginLeft = 0;
            this.btnSave.ColorContrastOnClick = 45;
            this.btnSave.ColorContrastOnHover = 45;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges6.BottomLeft = true;
            borderEdges6.BottomRight = true;
            borderEdges6.TopLeft = true;
            borderEdges6.TopRight = true;
            this.btnSave.CustomizableEdges = borderEdges6;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSave.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSave.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSave.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnSave.IconMarginLeft = 11;
            this.btnSave.IconPadding = 10;
            this.btnSave.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnSave.IconSize = 25;
            this.btnSave.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.IdleBorderRadius = 37;
            this.btnSave.IdleBorderThickness = 1;
            this.btnSave.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.IdleIconLeftImage = null;
            this.btnSave.IdleIconRightImage = null;
            this.btnSave.IndicateFocus = true;
            this.btnSave.Location = new System.Drawing.Point(255, 124);
            this.btnSave.Name = "btnSave";
            this.btnSave.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSave.OnDisabledState.BorderRadius = 1;
            this.btnSave.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSave.OnDisabledState.BorderThickness = 1;
            this.btnSave.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSave.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSave.OnDisabledState.IconLeftImage = null;
            this.btnSave.OnDisabledState.IconRightImage = null;
            this.btnSave.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnSave.onHoverState.BorderRadius = 1;
            this.btnSave.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSave.onHoverState.BorderThickness = 1;
            this.btnSave.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnSave.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnSave.onHoverState.IconLeftImage = null;
            this.btnSave.onHoverState.IconRightImage = null;
            this.btnSave.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.OnIdleState.BorderRadius = 1;
            this.btnSave.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSave.OnIdleState.BorderThickness = 1;
            this.btnSave.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnSave.OnIdleState.IconLeftImage = null;
            this.btnSave.OnIdleState.IconRightImage = null;
            this.btnSave.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnSave.OnPressedState.BorderRadius = 1;
            this.btnSave.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSave.OnPressedState.BorderThickness = 1;
            this.btnSave.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnSave.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnSave.OnPressedState.IconLeftImage = null;
            this.btnSave.OnPressedState.IconRightImage = null;
            this.btnSave.Size = new System.Drawing.Size(100, 39);
            this.btnSave.TabIndex = 128;
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSave.TextMarginLeft = 0;
            this.btnSave.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnSave.UseDefaultRadiusAndThickness = true;
            this.btnSave.Click += new System.EventHandler(this.bunifuButton4_Click);
            // 
            // cmbMonthCalendar
            // 
            this.cmbMonthCalendar.FormattingEnabled = true;
            this.cmbMonthCalendar.Location = new System.Drawing.Point(115, 53);
            this.cmbMonthCalendar.Name = "cmbMonthCalendar";
            this.cmbMonthCalendar.Size = new System.Drawing.Size(199, 24);
            this.cmbMonthCalendar.TabIndex = 2;
            this.cmbMonthCalendar.SelectedIndexChanged += new System.EventHandler(this.cmbMonthCalendar_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(358, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Days";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Month";
            // 
            // Production_Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 221);
            this.Controls.Add(this.panel1);
            this.Name = "Production_Calendar";
            this.Text = "Production Calendar";
            this.Load += new System.EventHandler(this.Production_Calendar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbMonthCalendar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnCancel;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnSave;
        private Bunifu.UI.WinForms.BunifuLabel lblDaysErr;
        private Bunifu.UI.WinForms.BunifuLabel lblMonErr;
        private System.Windows.Forms.TextBox txtNoDays;
        private System.Windows.Forms.CheckBox chkEdit;
    }
}