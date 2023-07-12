
namespace HindalcoiOS.Operation
{
    partial class ProductionCalendar
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbOpUnit = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.lblOpUnit = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.chkEdit = new SparrowRMSControl.SparrowControl.SparrowCheckBox();
            this.btnCancel = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnSave = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.lblDaysErr = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblMonErr = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtNoDays = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblProdCalTotwrkDays = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.cmbMonthCalendar = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.lblProdCalProdMonth = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbOpUnit);
            this.panel1.Controls.Add(this.lblOpUnit);
            this.panel1.Controls.Add(this.chkEdit);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.lblDaysErr);
            this.panel1.Controls.Add(this.lblMonErr);
            this.panel1.Controls.Add(this.txtNoDays);
            this.panel1.Controls.Add(this.lblProdCalTotwrkDays);
            this.panel1.Controls.Add(this.cmbMonthCalendar);
            this.panel1.Controls.Add(this.lblProdCalProdMonth);
            this.panel1.Location = new System.Drawing.Point(22, 20);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1524, 306);
            this.panel1.TabIndex = 0;
            // 
            // cmbOpUnit
            // 
            this.cmbOpUnit.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbOpUnit.BorderSize = 1;
            this.cmbOpUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOpUnit.ForeColor = System.Drawing.Color.DimGray;
            this.cmbOpUnit.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbOpUnit.ItemHeight = 33;
            this.cmbOpUnit.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.cmbOpUnit.ListTextColor = System.Drawing.Color.White;
            this.cmbOpUnit.Location = new System.Drawing.Point(351, 139);
            this.cmbOpUnit.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cmbOpUnit.MinimumSize = new System.Drawing.Size(66, 0);
            this.cmbOpUnit.Name = "cmbOpUnit";
            this.cmbOpUnit.Size = new System.Drawing.Size(357, 41);
            this.cmbOpUnit.TabIndex = 2;
            // 
            // lblOpUnit
            // 
            this.lblOpUnit.AutoSize = true;
            this.lblOpUnit.Depth = 0;
            this.lblOpUnit.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblOpUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblOpUnit.Location = new System.Drawing.Point(21, 147);
            this.lblOpUnit.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblOpUnit.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblOpUnit.Name = "lblOpUnit";
            this.lblOpUnit.Size = new System.Drawing.Size(188, 33);
            this.lblOpUnit.TabIndex = 9;
            this.lblOpUnit.Text = "Operation Unit";
            // 
            // chkEdit
            // 
            this.chkEdit.AutoSize = true;
            this.chkEdit.Depth = 0;
            this.chkEdit.Font = new System.Drawing.Font("Tahoma", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEdit.Location = new System.Drawing.Point(355, 220);
            this.chkEdit.Margin = new System.Windows.Forms.Padding(0);
            this.chkEdit.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkEdit.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.chkEdit.Name = "chkEdit";
            this.chkEdit.Ripple = true;
            this.chkEdit.Size = new System.Drawing.Size(198, 30);
            this.chkEdit.TabIndex = 8;
            this.chkEdit.Text = "Edit Calendar";
            this.chkEdit.UseVisualStyleBackColor = true;
            this.chkEdit.CheckedChanged += new System.EventHandler(this.chkEdit_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.BorderRadius = 14;
            this.btnCancel.BorderSize = 0;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(1299, 205);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnCancel.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnCancel.Size = new System.Drawing.Size(180, 47);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextColor = System.Drawing.Color.White;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.BorderRadius = 14;
            this.btnSave.BorderSize = 0;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(1094, 206);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnSave.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSave.Name = "btnSave";
            this.btnSave.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnSave.Size = new System.Drawing.Size(178, 47);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblDaysErr
            // 
            this.lblDaysErr.AutoSize = true;
            this.lblDaysErr.Depth = 0;
            this.lblDaysErr.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblDaysErr.ForeColor = System.Drawing.Color.Red;
            this.lblDaysErr.Location = new System.Drawing.Point(1482, 58);
            this.lblDaysErr.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDaysErr.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblDaysErr.Name = "lblDaysErr";
            this.lblDaysErr.Size = new System.Drawing.Size(30, 33);
            this.lblDaysErr.TabIndex = 5;
            this.lblDaysErr.Text = "*";
            this.lblDaysErr.Visible = false;
            // 
            // lblMonErr
            // 
            this.lblMonErr.AutoSize = true;
            this.lblMonErr.Depth = 0;
            this.lblMonErr.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblMonErr.ForeColor = System.Drawing.Color.Red;
            this.lblMonErr.Location = new System.Drawing.Point(723, 53);
            this.lblMonErr.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMonErr.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblMonErr.Name = "lblMonErr";
            this.lblMonErr.Size = new System.Drawing.Size(30, 33);
            this.lblMonErr.TabIndex = 4;
            this.lblMonErr.Text = "*";
            this.lblMonErr.Visible = false;
            // 
            // txtNoDays
            // 
            this.txtNoDays.BackColor = System.Drawing.SystemColors.Window;
            this.txtNoDays.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtNoDays.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtNoDays.BorderRadius = 0;
            this.txtNoDays.BorderSize = 1;
            this.txtNoDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoDays.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNoDays.Location = new System.Drawing.Point(1113, 53);
            this.txtNoDays.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtNoDays.Multiline = true;
            this.txtNoDays.Name = "txtNoDays";
            this.txtNoDays.Padding = new System.Windows.Forms.Padding(17, 11, 17, 11);
            this.txtNoDays.PasswordChar = false;
            this.txtNoDays.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtNoDays.PlaceholderText = "Enter Text";
            this.txtNoDays.Size = new System.Drawing.Size(360, 59);
            this.txtNoDays.TabIndex = 3;
            this.txtNoDays.UnderlinedStyle = false;
            this.txtNoDays.TextChanged += new System.EventHandler(this.txtNoDays_TextChanged);
            this.txtNoDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoDays_KeyPress);
            this.txtNoDays.MouseLeave += new System.EventHandler(this.txtNoDays_MouseLeave);
            // 
            // lblProdCalTotwrkDays
            // 
            this.lblProdCalTotwrkDays.AutoSize = true;
            this.lblProdCalTotwrkDays.Depth = 0;
            this.lblProdCalTotwrkDays.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblProdCalTotwrkDays.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblProdCalTotwrkDays.Location = new System.Drawing.Point(799, 67);
            this.lblProdCalTotwrkDays.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblProdCalTotwrkDays.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblProdCalTotwrkDays.Name = "lblProdCalTotwrkDays";
            this.lblProdCalTotwrkDays.Size = new System.Drawing.Size(246, 33);
            this.lblProdCalTotwrkDays.TabIndex = 2;
            this.lblProdCalTotwrkDays.Text = "Total Working Days";
            // 
            // cmbMonthCalendar
            // 
            this.cmbMonthCalendar.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbMonthCalendar.BorderSize = 1;
            this.cmbMonthCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonthCalendar.ForeColor = System.Drawing.Color.DimGray;
            this.cmbMonthCalendar.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbMonthCalendar.ItemHeight = 33;
            this.cmbMonthCalendar.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.cmbMonthCalendar.ListTextColor = System.Drawing.Color.White;
            this.cmbMonthCalendar.Location = new System.Drawing.Point(351, 53);
            this.cmbMonthCalendar.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cmbMonthCalendar.MinimumSize = new System.Drawing.Size(66, 0);
            this.cmbMonthCalendar.Name = "cmbMonthCalendar";
            this.cmbMonthCalendar.Size = new System.Drawing.Size(357, 41);
            this.cmbMonthCalendar.TabIndex = 1;
            this.cmbMonthCalendar.SelectedIndexChanged += new System.EventHandler(this.cmbMonthCalendar_SelectedIndexChanged);
            // 
            // lblProdCalProdMonth
            // 
            this.lblProdCalProdMonth.AutoSize = true;
            this.lblProdCalProdMonth.Depth = 0;
            this.lblProdCalProdMonth.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblProdCalProdMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblProdCalProdMonth.Location = new System.Drawing.Point(17, 67);
            this.lblProdCalProdMonth.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblProdCalProdMonth.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblProdCalProdMonth.Name = "lblProdCalProdMonth";
            this.lblProdCalProdMonth.Size = new System.Drawing.Size(225, 33);
            this.lblProdCalProdMonth.TabIndex = 0;
            this.lblProdCalProdMonth.Text = "Production Month";
            // 
            // ProductionCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1567, 345);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductionCalendar";
            this.Text = "Production Calendar";
            this.Load += new System.EventHandler(this.Production_Calendar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private SparrowRMSControl.SparrowControl.SparrowCheckBox chkEdit;
        private SparrowRMSControl.SparrowControl.SparrowButton btnCancel;
        private SparrowRMSControl.SparrowControl.SparrowButton btnSave;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblDaysErr;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblMonErr;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtNoDays;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblProdCalTotwrkDays;
        private SparrowRMSControl.SparrowControl.SparrowComboBox cmbMonthCalendar;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblProdCalProdMonth;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblOpUnit;
        private SparrowRMSControl.SparrowControl.SparrowComboBox cmbOpUnit;
    }
}