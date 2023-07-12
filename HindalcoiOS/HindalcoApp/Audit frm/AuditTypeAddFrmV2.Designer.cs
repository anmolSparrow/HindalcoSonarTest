
namespace HindalcoiOS.Audit_frm
{
    partial class AuditTypeAddFrm
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
            this.bunifuGroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.txtAddAudit = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblaudit = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.bunifuGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuGroupBox1
            // 
            this.bunifuGroupBox1.Controls.Add(this.btnAdd);
            this.bunifuGroupBox1.Controls.Add(this.txtAddAudit);
            this.bunifuGroupBox1.Controls.Add(this.lblaudit);
            this.bunifuGroupBox1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuGroupBox1.Location = new System.Drawing.Point(13, 7);
            this.bunifuGroupBox1.Name = "bunifuGroupBox1";
            this.bunifuGroupBox1.Size = new System.Drawing.Size(410, 158);
            this.bunifuGroupBox1.TabIndex = 0;
            this.bunifuGroupBox1.TabStop = false;
            this.bunifuGroupBox1.Text = "Add Type";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAdd.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnAdd.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnAdd.BorderRadius = 14;
            this.btnAdd.BorderSize = 0;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(267, 94);
            this.btnAdd.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnAdd.Size = new System.Drawing.Size(124, 32);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add Type";
            this.btnAdd.TextColor = System.Drawing.Color.White;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtAddAudit
            // 
            this.txtAddAudit.BackColor = System.Drawing.SystemColors.Window;
            this.txtAddAudit.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtAddAudit.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtAddAudit.BorderRadius = 0;
            this.txtAddAudit.BorderSize = 1;
            this.txtAddAudit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddAudit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAddAudit.Location = new System.Drawing.Point(171, 37);
            this.txtAddAudit.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddAudit.Multiline = true;
            this.txtAddAudit.Name = "txtAddAudit";
            this.txtAddAudit.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtAddAudit.PasswordChar = false;
            this.txtAddAudit.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtAddAudit.PlaceholderText = "";
            this.txtAddAudit.Size = new System.Drawing.Size(220, 35);
            this.txtAddAudit.TabIndex = 1;
            this.txtAddAudit.UnderlinedStyle = false;
            // 
            // lblaudit
            // 
            this.lblaudit.AutoSize = true;
            this.lblaudit.Depth = 0;
            this.lblaudit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblaudit.Location = new System.Drawing.Point(26, 46);
            this.lblaudit.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblaudit.Name = "lblaudit";
            this.lblaudit.Size = new System.Drawing.Size(118, 18);
            this.lblaudit.TabIndex = 0;
            this.lblaudit.Text = "Enter Audit Type";
            // 
            // AuditTypeAddFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 183);
            this.Controls.Add(this.bunifuGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuditTypeAddFrm";
            this.Text = "Audit Type Add";
            this.Load += new System.EventHandler(this.AuditTypeAddFrm_Load);
            this.bunifuGroupBox1.ResumeLayout(false);
            this.bunifuGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox bunifuGroupBox1;
        private SparrowRMSControl.SparrowControl.SparrowButton btnAdd;
        public SparrowRMSControl.SparrowControl.SparrowTextBox txtAddAudit;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblaudit;
    }
}