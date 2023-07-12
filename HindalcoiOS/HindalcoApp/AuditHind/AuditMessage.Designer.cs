
namespace HindalcoiOS.AuditHind
{
    partial class AuditMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuditMessage));
            this.txtRejectMsg = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.btnSave = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.SuspendLayout();
            // 
            // txtRejectMsg
            // 
            this.txtRejectMsg.BackColor = System.Drawing.SystemColors.Window;
            this.txtRejectMsg.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtRejectMsg.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtRejectMsg.BorderRadius = 0;
            this.txtRejectMsg.BorderSize = 1;
            this.txtRejectMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRejectMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtRejectMsg.Location = new System.Drawing.Point(14, 9);
            this.txtRejectMsg.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtRejectMsg.Multiline = true;
            this.txtRejectMsg.Name = "txtRejectMsg";
            this.txtRejectMsg.Padding = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.txtRejectMsg.PasswordChar = false;
            this.txtRejectMsg.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtRejectMsg.PlaceholderText = "";
            this.txtRejectMsg.Size = new System.Drawing.Size(549, 170);
            this.txtRejectMsg.TabIndex = 115;
            this.txtRejectMsg.UnderlinedStyle = false;
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
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(453, 190);
            this.btnSave.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSave.Name = "btnSave";
            this.btnSave.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnSave.Size = new System.Drawing.Size(110, 30);
            this.btnSave.TabIndex = 140;
            this.btnSave.Text = "Ok";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AuditMessage
            // 
            this.ClientSize = new System.Drawing.Size(577, 235);
            this.ControlBox = false;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtRejectMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("AuditMessage.IconOptions.Icon")));
            this.IconOptions.Image = global::HindalcoiOS.Properties.Resources.RMPCLIcon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuditMessage";
            this.Text = "Add Remaks";
            this.Load += new System.EventHandler(this.AuditMessage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SparrowRMSControl.SparrowControl.SparrowLabel lblAuditType;
        public SparrowRMSControl.SparrowControl.SparrowComboBox cmbAuditType;
        private SparrowRMSControl.SparrowControl.SparrowLabel sparrowLabel3;
        public SparrowRMSControl.SparrowControl.SparrowComboBox cmbYear;
        private SparrowRMSControl.SparrowControl.SparrowButton btnGenPlan;
        private System.Windows.Forms.GroupBox groupBox1;
        public SparrowRMSControl.SparrowControl.SparrowComboBox cmbQuater;
        private SparrowRMSControl.SparrowControl.SparrowLabel sparrowLabel2;
        public SparrowRMSControl.SparrowControl.SparrowComboBox cmbOunit;
        private SparrowRMSControl.SparrowControl.SparrowLabel sparrowLabel1;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtRejectMsg;
        private SparrowRMSControl.SparrowControl.SparrowButton btnSave;
    }
}