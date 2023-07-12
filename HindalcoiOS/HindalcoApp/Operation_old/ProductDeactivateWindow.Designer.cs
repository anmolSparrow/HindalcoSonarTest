
namespace RMPCLApp.Operation
{
    partial class ProductDeactivateWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductDeactivateWindow));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges5 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges6 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdbDeActivate = new System.Windows.Forms.RadioButton();
            this.rdbActivate = new System.Windows.Forms.RadioButton();
            this.cmbPlantName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbProdName = new System.Windows.Forms.ComboBox();
            this.btnReset = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnSave = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDateFRom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.cmbPlantName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbProdName);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.dtpTo);
            this.panel1.Controls.Add(this.dtpFrom);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblDateFRom);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(699, 230);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rdbDeActivate);
            this.panel2.Controls.Add(this.rdbActivate);
            this.panel2.Location = new System.Drawing.Point(15, 128);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(392, 39);
            this.panel2.TabIndex = 98;
            // 
            // rdbDeActivate
            // 
            this.rdbDeActivate.AutoSize = true;
            this.rdbDeActivate.Location = new System.Drawing.Point(197, 7);
            this.rdbDeActivate.Name = "rdbDeActivate";
            this.rdbDeActivate.Size = new System.Drawing.Size(100, 21);
            this.rdbDeActivate.TabIndex = 97;
            this.rdbDeActivate.TabStop = true;
            this.rdbDeActivate.Text = "De-Activate";
            this.rdbDeActivate.UseVisualStyleBackColor = true;
            this.rdbDeActivate.CheckedChanged += new System.EventHandler(this.rdbDeActivate_CheckedChanged);
            // 
            // rdbActivate
            // 
            this.rdbActivate.AutoSize = true;
            this.rdbActivate.Location = new System.Drawing.Point(10, 7);
            this.rdbActivate.Name = "rdbActivate";
            this.rdbActivate.Size = new System.Drawing.Size(78, 21);
            this.rdbActivate.TabIndex = 96;
            this.rdbActivate.TabStop = true;
            this.rdbActivate.Text = "Activate";
            this.rdbActivate.UseVisualStyleBackColor = true;
            this.rdbActivate.CheckedChanged += new System.EventHandler(this.rdbActivate_CheckedChanged);
            // 
            // cmbPlantName
            // 
            this.cmbPlantName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlantName.FormattingEnabled = true;
            this.cmbPlantName.Location = new System.Drawing.Point(96, 26);
            this.cmbPlantName.Name = "cmbPlantName";
            this.cmbPlantName.Size = new System.Drawing.Size(200, 24);
            this.cmbPlantName.TabIndex = 95;
            this.cmbPlantName.SelectedIndexChanged += new System.EventHandler(this.cmbPlantName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 94;
            this.label2.Text = "Plant Name";
            // 
            // cmbProdName
            // 
            this.cmbProdName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProdName.FormattingEnabled = true;
            this.cmbProdName.Location = new System.Drawing.Point(456, 26);
            this.cmbProdName.Name = "cmbProdName";
            this.cmbProdName.Size = new System.Drawing.Size(200, 24);
            this.cmbProdName.TabIndex = 93;
            this.cmbProdName.SelectedIndexChanged += new System.EventHandler(this.cmbProdName_SelectedIndexChanged);
            // 
            // btnReset
            // 
            this.btnReset.AllowAnimations = true;
            this.btnReset.AllowMouseEffects = true;
            this.btnReset.AllowToggling = false;
            this.btnReset.AllowV2Features = false;
            this.btnReset.AnimationSpeed = 200;
            this.btnReset.AutoGenerateColors = false;
            this.btnReset.AutoRoundBorders = true;
            this.btnReset.AutoSizeLeftIcon = true;
            this.btnReset.AutoSizeRightIcon = true;
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.btnReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReset.BackgroundImage")));
            this.btnReset.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnReset.ButtonText = "Reset";
            this.btnReset.ButtonTextMarginLeft = 0;
            this.btnReset.ColorContrastOnClick = 45;
            this.btnReset.ColorContrastOnHover = 45;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges5.BottomLeft = true;
            borderEdges5.BottomRight = true;
            borderEdges5.TopLeft = true;
            borderEdges5.TopRight = true;
            this.btnReset.CustomizableEdges = borderEdges5;
            this.btnReset.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnReset.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnReset.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnReset.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnReset.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnReset.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnReset.IconMarginLeft = 11;
            this.btnReset.IconPadding = 10;
            this.btnReset.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnReset.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnReset.IconSize = 25;
            this.btnReset.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnReset.IdleBorderRadius = 37;
            this.btnReset.IdleBorderThickness = 1;
            this.btnReset.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.btnReset.IdleIconLeftImage = null;
            this.btnReset.IdleIconRightImage = null;
            this.btnReset.IndicateFocus = false;
            this.btnReset.Location = new System.Drawing.Point(561, 128);
            this.btnReset.Name = "btnReset";
            this.btnReset.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnReset.OnDisabledState.BorderRadius = 1;
            this.btnReset.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnReset.OnDisabledState.BorderThickness = 1;
            this.btnReset.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnReset.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnReset.OnDisabledState.IconLeftImage = null;
            this.btnReset.OnDisabledState.IconRightImage = null;
            this.btnReset.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnReset.onHoverState.BorderRadius = 1;
            this.btnReset.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnReset.onHoverState.BorderThickness = 1;
            this.btnReset.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnReset.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnReset.onHoverState.IconLeftImage = null;
            this.btnReset.onHoverState.IconRightImage = null;
            this.btnReset.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnReset.OnIdleState.BorderRadius = 1;
            this.btnReset.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnReset.OnIdleState.BorderThickness = 1;
            this.btnReset.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnReset.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnReset.OnIdleState.IconLeftImage = null;
            this.btnReset.OnIdleState.IconRightImage = null;
            this.btnReset.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnReset.OnPressedState.BorderRadius = 1;
            this.btnReset.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnReset.OnPressedState.BorderThickness = 1;
            this.btnReset.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnReset.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnReset.OnPressedState.IconLeftImage = null;
            this.btnReset.OnPressedState.IconRightImage = null;
            this.btnReset.Size = new System.Drawing.Size(95, 39);
            this.btnReset.TabIndex = 12;
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnReset.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnReset.TextMarginLeft = 0;
            this.btnReset.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnReset.UseDefaultRadiusAndThickness = true;
            // 
            // btnSave
            // 
            this.btnSave.AllowAnimations = true;
            this.btnSave.AllowMouseEffects = true;
            this.btnSave.AllowToggling = false;
            this.btnSave.AllowV2Features = false;
            this.btnSave.AnimationSpeed = 200;
            this.btnSave.AutoGenerateColors = false;
            this.btnSave.AutoRoundBorders = true;
            this.btnSave.AutoSizeLeftIcon = true;
            this.btnSave.AutoSizeRightIcon = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
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
            this.btnSave.IndicateFocus = false;
            this.btnSave.Location = new System.Drawing.Point(456, 128);
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
            this.btnSave.Size = new System.Drawing.Size(95, 39);
            this.btnSave.TabIndex = 11;
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSave.TextMarginLeft = 0;
            this.btnSave.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnSave.UseDefaultRadiusAndThickness = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(456, 77);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 23);
            this.dtpTo.TabIndex = 4;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(96, 79);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 23);
            this.dtpFrom.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(347, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "To";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblDateFRom
            // 
            this.lblDateFRom.AutoSize = true;
            this.lblDateFRom.Location = new System.Drawing.Point(12, 84);
            this.lblDateFRom.Name = "lblDateFRom";
            this.lblDateFRom.Size = new System.Drawing.Size(40, 17);
            this.lblDateFRom.TabIndex = 1;
            this.lblDateFRom.Text = "From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(347, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(453, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 17);
            this.label4.TabIndex = 99;
            this.label4.Text = "Current Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(558, 206);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 18);
            this.lblStatus.TabIndex = 100;
            this.lblStatus.Text = "****";
            // 
            // ProductDeactivateWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 266);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "ProductDeactivateWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductDeactivateWindow";
            this.Load += new System.EventHandler(this.ProductDeactivateWindow_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDateFRom;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnSave;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnReset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPlantName;
        private System.Windows.Forms.ComboBox cmbProdName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdbDeActivate;
        private System.Windows.Forms.RadioButton rdbActivate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label4;
    }
}