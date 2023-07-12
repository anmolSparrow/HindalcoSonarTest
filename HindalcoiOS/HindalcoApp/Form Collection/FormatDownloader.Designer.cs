namespace HindalcoiOS.Form_Collection
{
    partial class FormatDownloader
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btndownload = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.cmbformat = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.lblformatDld = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblformat = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btndownload);
            this.groupBox1.Controls.Add(this.cmbformat);
            this.groupBox1.Controls.Add(this.lblformatDld);
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 162);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btndownload
            // 
            this.btndownload.BackColor = System.Drawing.Color.DodgerBlue;
            this.btndownload.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btndownload.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btndownload.BorderRadius = 14;
            this.btndownload.BorderSize = 0;
            this.btndownload.FlatAppearance.BorderSize = 0;
            this.btndownload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btndownload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btndownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndownload.ForeColor = System.Drawing.Color.White;
            this.btndownload.Location = new System.Drawing.Point(336, 116);
            this.btndownload.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btndownload.Name = "btndownload";
            this.btndownload.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btndownload.Size = new System.Drawing.Size(124, 32);
            this.btndownload.TabIndex = 2;
            this.btndownload.Text = "Download";
            this.btndownload.TextColor = System.Drawing.Color.White;
            this.btndownload.UseVisualStyleBackColor = false;
            this.btndownload.Click += new System.EventHandler(this.btndownload_Click);
            // 
            // cmbformat
            // 
            this.cmbformat.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbformat.BorderSize = 0;
            this.cmbformat.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbformat.FormattingEnabled = true;
            this.cmbformat.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbformat.Items.AddRange(new object[] {
            "Audit Report",
            "Audit Calendar",
            "MaintenanceU0",
            "MaintenanceU1",
            "Training",
            "OHC Form Format",
            "Item Master"});
            this.cmbformat.ListBackColor = System.Drawing.Color.Red;
            this.cmbformat.ListTextColor = System.Drawing.Color.White;
            this.cmbformat.Location = new System.Drawing.Point(229, 55);
            this.cmbformat.Name = "cmbformat";
            this.cmbformat.Size = new System.Drawing.Size(249, 30);
            this.cmbformat.TabIndex = 1;
            // 
            // lblformatDld
            // 
            this.lblformatDld.AutoSize = true;
            this.lblformatDld.Depth = 0;
            this.lblformatDld.Location = new System.Drawing.Point(21, 63);
            this.lblformatDld.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblformatDld.Name = "lblformatDld";
            this.lblformatDld.Size = new System.Drawing.Size(132, 17);
            this.lblformatDld.TabIndex = 0;
            this.lblformatDld.Text = "Select Format Type:";
            // 
            // lblformat
            // 
            this.lblformat.AutoSize = true;
            this.lblformat.Depth = 0;
            this.lblformat.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblformat.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblformat.Location = new System.Drawing.Point(143, -2);
            this.lblformat.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblformat.Name = "lblformat";
            this.lblformat.Size = new System.Drawing.Size(184, 17);
            this.lblformat.TabIndex = 3;
            this.lblformat.Text = "Excel Format Downloader";
            // 
            // FormatDownloader
            // 
            this.ClientSize = new System.Drawing.Size(538, 201);
            this.Controls.Add(this.lblformat);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormatDownloader";
            this.Load += new System.EventHandler(this.FormatDownloader_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private Bunifu.Framework.UI.BunifuCustomLabel lblformat;
        private DevExpress.XtraEditors.GroupControl GrpFormat;
        //private Bunifu.Framework.UI.BunifuCustomLabel lblformatDld;
        //public DevExpress.XtraEditors.ComboBoxEdit cmbformat;
        //private Bunifu.Framework.UI.BunifuFlatButton btndownload;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private SparrowRMSControl.SparrowControl.SparrowButton btndownload;
        private SparrowRMSControl.SparrowControl.SparrowComboBox cmbformat;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblformatDld;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblformat;
    }
}