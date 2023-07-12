
namespace RMPCLApp.Operation
{
    partial class CalendarSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarSelection));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlLoadCalendar = new System.Windows.Forms.Panel();
            this.lstDatreCalendar = new System.Windows.Forms.ListView();
            this.btnClose = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnOk = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.DateCalendarGrp = new DevExpress.XtraEditors.Controls.CalendarControl();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlLoadCalendar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DateCalendarGrp.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Edit";
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 913;
            // 
            // pnlLoadCalendar
            // 
            this.pnlLoadCalendar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlLoadCalendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLoadCalendar.Controls.Add(this.lstDatreCalendar);
            this.pnlLoadCalendar.Controls.Add(this.btnClose);
            this.pnlLoadCalendar.Controls.Add(this.btnOk);
            this.pnlLoadCalendar.Controls.Add(this.DateCalendarGrp);
            this.pnlLoadCalendar.Controls.Add(this.label1);
            this.pnlLoadCalendar.Location = new System.Drawing.Point(3, 2);
            this.pnlLoadCalendar.Name = "pnlLoadCalendar";
            this.pnlLoadCalendar.Size = new System.Drawing.Size(610, 296);
            this.pnlLoadCalendar.TabIndex = 63;
            // 
            // lstDatreCalendar
            // 
            this.lstDatreCalendar.HideSelection = false;
            this.lstDatreCalendar.Location = new System.Drawing.Point(25, 72);
            this.lstDatreCalendar.Name = "lstDatreCalendar";
            this.lstDatreCalendar.Size = new System.Drawing.Size(196, 145);
            this.lstDatreCalendar.TabIndex = 17;
            this.lstDatreCalendar.UseCompatibleStateImageBehavior = false;
            // 
            // btnClose
            // 
            this.btnClose.AllowAnimations = true;
            this.btnClose.AllowMouseEffects = true;
            this.btnClose.AllowToggling = false;
            this.btnClose.AllowV2Features = false;
            this.btnClose.AnimationSpeed = 200;
            this.btnClose.AutoGenerateColors = false;
            this.btnClose.AutoRoundBorders = true;
            this.btnClose.AutoSizeLeftIcon = true;
            this.btnClose.AutoSizeRightIcon = true;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnClose.ButtonText = "Close";
            this.btnClose.ButtonTextMarginLeft = 0;
            this.btnClose.ColorContrastOnClick = 45;
            this.btnClose.ColorContrastOnHover = 45;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnClose.CustomizableEdges = borderEdges1;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnClose.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnClose.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnClose.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnClose.IconMarginLeft = 11;
            this.btnClose.IconPadding = 10;
            this.btnClose.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnClose.IconSize = 25;
            this.btnClose.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnClose.IdleBorderRadius = 36;
            this.btnClose.IdleBorderThickness = 1;
            this.btnClose.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.btnClose.IdleIconLeftImage = null;
            this.btnClose.IdleIconRightImage = null;
            this.btnClose.IndicateFocus = false;
            this.btnClose.Location = new System.Drawing.Point(350, 231);
            this.btnClose.Name = "btnClose";
            this.btnClose.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnClose.OnDisabledState.BorderRadius = 1;
            this.btnClose.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnClose.OnDisabledState.BorderThickness = 1;
            this.btnClose.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnClose.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnClose.OnDisabledState.IconLeftImage = null;
            this.btnClose.OnDisabledState.IconRightImage = null;
            this.btnClose.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnClose.onHoverState.BorderRadius = 1;
            this.btnClose.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnClose.onHoverState.BorderThickness = 1;
            this.btnClose.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnClose.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnClose.onHoverState.IconLeftImage = null;
            this.btnClose.onHoverState.IconRightImage = null;
            this.btnClose.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnClose.OnIdleState.BorderRadius = 1;
            this.btnClose.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnClose.OnIdleState.BorderThickness = 1;
            this.btnClose.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnClose.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnClose.OnIdleState.IconLeftImage = null;
            this.btnClose.OnIdleState.IconRightImage = null;
            this.btnClose.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnClose.OnPressedState.BorderRadius = 1;
            this.btnClose.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnClose.OnPressedState.BorderThickness = 1;
            this.btnClose.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnClose.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnClose.OnPressedState.IconLeftImage = null;
            this.btnClose.OnPressedState.IconRightImage = null;
            this.btnClose.Size = new System.Drawing.Size(93, 38);
            this.btnClose.TabIndex = 16;
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnClose.TextMarginLeft = 0;
            this.btnClose.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnClose.UseDefaultRadiusAndThickness = true;
            // 
            // btnOk
            // 
            this.btnOk.AllowAnimations = true;
            this.btnOk.AllowMouseEffects = true;
            this.btnOk.AllowToggling = false;
            this.btnOk.AllowV2Features = false;
            this.btnOk.AnimationSpeed = 200;
            this.btnOk.AutoGenerateColors = false;
            this.btnOk.AutoRoundBorders = true;
            this.btnOk.AutoSizeLeftIcon = true;
            this.btnOk.AutoSizeRightIcon = true;
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.btnOk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOk.BackgroundImage")));
            this.btnOk.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnOk.ButtonText = "Ok";
            this.btnOk.ButtonTextMarginLeft = 0;
            this.btnOk.ColorContrastOnClick = 45;
            this.btnOk.ColorContrastOnHover = 45;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnOk.CustomizableEdges = borderEdges2;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOk.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnOk.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnOk.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnOk.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnOk.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnOk.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnOk.IconMarginLeft = 11;
            this.btnOk.IconPadding = 10;
            this.btnOk.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnOk.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnOk.IconSize = 25;
            this.btnOk.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnOk.IdleBorderRadius = 37;
            this.btnOk.IdleBorderThickness = 1;
            this.btnOk.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.btnOk.IdleIconLeftImage = null;
            this.btnOk.IdleIconRightImage = null;
            this.btnOk.IndicateFocus = false;
            this.btnOk.Location = new System.Drawing.Point(257, 231);
            this.btnOk.Name = "btnOk";
            this.btnOk.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnOk.OnDisabledState.BorderRadius = 1;
            this.btnOk.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnOk.OnDisabledState.BorderThickness = 1;
            this.btnOk.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnOk.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnOk.OnDisabledState.IconLeftImage = null;
            this.btnOk.OnDisabledState.IconRightImage = null;
            this.btnOk.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnOk.onHoverState.BorderRadius = 1;
            this.btnOk.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnOk.onHoverState.BorderThickness = 1;
            this.btnOk.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnOk.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnOk.onHoverState.IconLeftImage = null;
            this.btnOk.onHoverState.IconRightImage = null;
            this.btnOk.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnOk.OnIdleState.BorderRadius = 1;
            this.btnOk.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnOk.OnIdleState.BorderThickness = 1;
            this.btnOk.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnOk.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnOk.OnIdleState.IconLeftImage = null;
            this.btnOk.OnIdleState.IconRightImage = null;
            this.btnOk.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnOk.OnPressedState.BorderRadius = 1;
            this.btnOk.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnOk.OnPressedState.BorderThickness = 1;
            this.btnOk.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnOk.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnOk.OnPressedState.IconLeftImage = null;
            this.btnOk.OnPressedState.IconRightImage = null;
            this.btnOk.Size = new System.Drawing.Size(74, 39);
            this.btnOk.TabIndex = 15;
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOk.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnOk.TextMarginLeft = 0;
            this.btnOk.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnOk.UseDefaultRadiusAndThickness = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click_1);
            // 
            // DateCalendarGrp
            // 
            this.DateCalendarGrp.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateCalendarGrp.Location = new System.Drawing.Point(256, 41);
            this.DateCalendarGrp.Name = "DateCalendarGrp";
            this.DateCalendarGrp.ShowHeader = false;
            this.DateCalendarGrp.ShowMonthHeaders = false;
            this.DateCalendarGrp.ShowMonthNavigationButtons = DevExpress.Utils.DefaultBoolean.False;
            this.DateCalendarGrp.ShowTodayButton = false;
            this.DateCalendarGrp.ShowToolTips = false;
            this.DateCalendarGrp.ShowYearNavigationButtons = DevExpress.Utils.DefaultBoolean.False;
            this.DateCalendarGrp.Size = new System.Drawing.Size(285, 184);
            this.DateCalendarGrp.TabIndex = 1;
            this.DateCalendarGrp.WeekNumberRule = DevExpress.XtraEditors.Controls.WeekNumberRule.FirstDay;
            this.DateCalendarGrp.SelectionChanged += new System.EventHandler(this.DateCalendarGrp_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Work Days";
            // 
            // CalendarSelection
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 278);
            this.Controls.Add(this.pnlLoadCalendar);
            this.Name = "CalendarSelection";
            this.Text = "Production Master";
            this.Load += new System.EventHandler(this.ProductDetails_Load);
            this.pnlLoadCalendar.ResumeLayout(false);
            this.pnlLoadCalendar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DateCalendarGrp.CalendarTimeProperties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Panel pnlLoadCalendar;
        private System.Windows.Forms.ListView lstDatreCalendar;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnClose;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnOk;
        private DevExpress.XtraEditors.Controls.CalendarControl DateCalendarGrp;
        private System.Windows.Forms.Label label1;
    }
}