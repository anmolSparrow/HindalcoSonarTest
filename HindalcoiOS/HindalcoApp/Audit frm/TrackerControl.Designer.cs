namespace HindalcoiOS.Audit_frm
{
    partial class TrackerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.cmbuditName = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.dateTimePicker1 = new SparrowRMSControl.SparrowControl.SparrowDatePicker();
            this.lblauditoname = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblcode = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.cmbcode = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.cmbaudit = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.lbldate = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblname = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.cmbuditName);
            this.groupBox11.Controls.Add(this.dateTimePicker1);
            this.groupBox11.Controls.Add(this.lblauditoname);
            this.groupBox11.Controls.Add(this.lblcode);
            this.groupBox11.Controls.Add(this.cmbcode);
            this.groupBox11.Controls.Add(this.cmbaudit);
            this.groupBox11.Controls.Add(this.lbldate);
            this.groupBox11.Controls.Add(this.lblname);
            this.groupBox11.Location = new System.Drawing.Point(14, 17);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(896, 113);
            this.groupBox11.TabIndex = 8;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Tracker Details";
            // 
            // cmbuditName
            // 
            this.cmbuditName.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbuditName.BorderSize = 0;
            this.cmbuditName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbuditName.FormattingEnabled = true;
            this.cmbuditName.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbuditName.ListBackColor = System.Drawing.Color.Red;
            this.cmbuditName.ListTextColor = System.Drawing.Color.White;
            this.cmbuditName.Location = new System.Drawing.Point(698, 68);
            this.cmbuditName.Name = "cmbuditName";
            this.cmbuditName.Size = new System.Drawing.Size(160, 31);
            this.cmbuditName.TabIndex = 18;
            this.cmbuditName.SelectedValueChanged += new System.EventHandler(this.cmbuditName_SelectedValueChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.dateTimePicker1.BorderSize = 0;
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dateTimePicker1.Location = new System.Drawing.Point(190, 68);
            this.dateTimePicker1.MinimumSize = new System.Drawing.Size(4, 35);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(195, 35);
            this.dateTimePicker1.SkinColor = System.Drawing.Color.MediumSlateBlue;
            this.dateTimePicker1.TabIndex = 19;
            this.dateTimePicker1.TextColor = System.Drawing.Color.White;
            // 
            // lblauditoname
            // 
            this.lblauditoname.AutoSize = true;
            this.lblauditoname.Depth = 0;
            this.lblauditoname.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblauditoname.Location = new System.Drawing.Point(505, 68);
            this.lblauditoname.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblauditoname.Name = "lblauditoname";
            this.lblauditoname.Size = new System.Drawing.Size(103, 20);
            this.lblauditoname.TabIndex = 13;
            this.lblauditoname.Text = "Auditor Name";
            // 
            // lblcode
            // 
            this.lblcode.AutoSize = true;
            this.lblcode.Depth = 0;
            this.lblcode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcode.Location = new System.Drawing.Point(24, 29);
            this.lblcode.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblcode.Name = "lblcode";
            this.lblcode.Size = new System.Drawing.Size(84, 20);
            this.lblcode.TabIndex = 9;
            this.lblcode.Text = "Audit Code";
            // 
            // cmbcode
            // 
            this.cmbcode.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbcode.BorderSize = 0;
            this.cmbcode.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcode.FormattingEnabled = true;
            this.cmbcode.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbcode.ListBackColor = System.Drawing.Color.Red;
            this.cmbcode.ListTextColor = System.Drawing.Color.White;
            this.cmbcode.Location = new System.Drawing.Point(190, 24);
            this.cmbcode.Name = "cmbcode";
            this.cmbcode.Size = new System.Drawing.Size(195, 31);
            this.cmbcode.TabIndex = 14;
            this.cmbcode.SelectedValueChanged += new System.EventHandler(this.cmbcode_SelectedValueChanged);
            // 
            // cmbaudit
            // 
            this.cmbaudit.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbaudit.BorderSize = 0;
            this.cmbaudit.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbaudit.FormattingEnabled = true;
            this.cmbaudit.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbaudit.ListBackColor = System.Drawing.Color.Red;
            this.cmbaudit.ListTextColor = System.Drawing.Color.White;
            this.cmbaudit.Location = new System.Drawing.Point(698, 19);
            this.cmbaudit.Name = "cmbaudit";
            this.cmbaudit.Size = new System.Drawing.Size(160, 31);
            this.cmbaudit.TabIndex = 17;
            this.cmbaudit.SelectedValueChanged += new System.EventHandler(this.cmbaudit_SelectedValueChanged);
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Depth = 0;
            this.lbldate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldate.Location = new System.Drawing.Point(24, 68);
            this.lbldate.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(41, 20);
            this.lbldate.TabIndex = 12;
            this.lbldate.Text = "Date";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Depth = 0;
            this.lblname.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.Location = new System.Drawing.Point(505, 29);
            this.lblname.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(109, 20);
            this.lblname.TabIndex = 11;
            this.lblname.Text = "Name Of Audit";
            // 
            // TrackerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupBox11);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TrackerControl";
            this.Size = new System.Drawing.Size(928, 144);
            this.Load += new System.EventHandler(this.TrackerControl_Load);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox11;
        public SparrowRMSControl.SparrowControl.SparrowComboBox cmbuditName;
        public SparrowRMSControl.SparrowControl.SparrowDatePicker dateTimePicker1;
        public SparrowRMSControl.SparrowControl.SparrowLabel lblauditoname;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblcode;
        public SparrowRMSControl.SparrowControl.SparrowComboBox cmbcode;
        public SparrowRMSControl.SparrowControl.SparrowComboBox cmbaudit;
        private SparrowRMSControl.SparrowControl.SparrowLabel lbldate;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblname;
    }
}
