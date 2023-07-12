
namespace HindalcoiOS.InventoryMgmt
{
    partial class MailDetailView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSendMail = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.txtMailBody = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblBody = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblMailCc = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblSubject = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblMailTo = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtIMailCc = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtIMailto = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtMailSubject = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSendMail);
            this.groupBox1.Controls.Add(this.txtMailBody);
            this.groupBox1.Controls.Add(this.lblBody);
            this.groupBox1.Controls.Add(this.lblMailCc);
            this.groupBox1.Controls.Add(this.lblSubject);
            this.groupBox1.Controls.Add(this.lblMailTo);
            this.groupBox1.Controls.Add(this.txtIMailCc);
            this.groupBox1.Controls.Add(this.txtIMailto);
            this.groupBox1.Controls.Add(this.txtMailSubject);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(790, 274);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mail Details";
            // 
            // btnSendMail
            // 
            this.btnSendMail.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSendMail.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnSendMail.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSendMail.BorderRadius = 14;
            this.btnSendMail.BorderSize = 0;
            this.btnSendMail.FlatAppearance.BorderSize = 0;
            this.btnSendMail.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSendMail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSendMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendMail.ForeColor = System.Drawing.Color.White;
            this.btnSendMail.Location = new System.Drawing.Point(659, 28);
            this.btnSendMail.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnSendMail.Size = new System.Drawing.Size(112, 30);
            this.btnSendMail.TabIndex = 55;
            this.btnSendMail.Text = "Send";
            this.btnSendMail.TextColor = System.Drawing.Color.White;
            this.btnSendMail.UseVisualStyleBackColor = true;
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
            // 
            // txtMailBody
            // 
            this.txtMailBody.BackColor = System.Drawing.SystemColors.Window;
            this.txtMailBody.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtMailBody.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtMailBody.BorderRadius = 0;
            this.txtMailBody.BorderSize = 1;
            this.txtMailBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMailBody.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMailBody.Location = new System.Drawing.Point(91, 122);
            this.txtMailBody.Margin = new System.Windows.Forms.Padding(4);
            this.txtMailBody.Multiline = true;
            this.txtMailBody.Name = "txtMailBody";
            this.txtMailBody.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtMailBody.PasswordChar = false;
            this.txtMailBody.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtMailBody.PlaceholderText = "";
            this.txtMailBody.Size = new System.Drawing.Size(680, 126);
            this.txtMailBody.TabIndex = 52;
            this.txtMailBody.UnderlinedStyle = false;
            // 
            // lblBody
            // 
            this.lblBody.AutoSize = true;
            this.lblBody.Depth = 0;
            this.lblBody.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblBody.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBody.Location = new System.Drawing.Point(15, 166);
            this.lblBody.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(41, 18);
            this.lblBody.TabIndex = 51;
            this.lblBody.Text = "Body";
            // 
            // lblMailCc
            // 
            this.lblMailCc.AutoSize = true;
            this.lblMailCc.Depth = 0;
            this.lblMailCc.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblMailCc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMailCc.Location = new System.Drawing.Point(15, 83);
            this.lblMailCc.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblMailCc.Name = "lblMailCc";
            this.lblMailCc.Size = new System.Drawing.Size(53, 18);
            this.lblMailCc.TabIndex = 50;
            this.lblMailCc.Text = "Mail Cc";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Depth = 0;
            this.lblSubject.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblSubject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSubject.Location = new System.Drawing.Point(413, 91);
            this.lblSubject.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(56, 18);
            this.lblSubject.TabIndex = 49;
            this.lblSubject.Text = "Subject";
            // 
            // lblMailTo
            // 
            this.lblMailTo.AutoSize = true;
            this.lblMailTo.Depth = 0;
            this.lblMailTo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblMailTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMailTo.Location = new System.Drawing.Point(15, 40);
            this.lblMailTo.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblMailTo.Name = "lblMailTo";
            this.lblMailTo.Size = new System.Drawing.Size(55, 18);
            this.lblMailTo.TabIndex = 48;
            this.lblMailTo.Text = "Mail To";
            // 
            // txtIMailCc
            // 
            this.txtIMailCc.BackColor = System.Drawing.SystemColors.Window;
            this.txtIMailCc.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtIMailCc.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtIMailCc.BorderRadius = 0;
            this.txtIMailCc.BorderSize = 1;
            this.txtIMailCc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIMailCc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtIMailCc.Location = new System.Drawing.Point(91, 78);
            this.txtIMailCc.Margin = new System.Windows.Forms.Padding(4);
            this.txtIMailCc.Multiline = true;
            this.txtIMailCc.Name = "txtIMailCc";
            this.txtIMailCc.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtIMailCc.PasswordChar = false;
            this.txtIMailCc.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtIMailCc.PlaceholderText = "";
            this.txtIMailCc.Size = new System.Drawing.Size(277, 35);
            this.txtIMailCc.TabIndex = 47;
            this.txtIMailCc.UnderlinedStyle = false;
            // 
            // txtIMailto
            // 
            this.txtIMailto.BackColor = System.Drawing.SystemColors.Window;
            this.txtIMailto.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtIMailto.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtIMailto.BorderRadius = 0;
            this.txtIMailto.BorderSize = 1;
            this.txtIMailto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIMailto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtIMailto.Location = new System.Drawing.Point(91, 35);
            this.txtIMailto.Margin = new System.Windows.Forms.Padding(4);
            this.txtIMailto.Multiline = true;
            this.txtIMailto.Name = "txtIMailto";
            this.txtIMailto.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtIMailto.PasswordChar = false;
            this.txtIMailto.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtIMailto.PlaceholderText = "";
            this.txtIMailto.Size = new System.Drawing.Size(277, 35);
            this.txtIMailto.TabIndex = 46;
            this.txtIMailto.UnderlinedStyle = false;
            // 
            // txtMailSubject
            // 
            this.txtMailSubject.BackColor = System.Drawing.SystemColors.Window;
            this.txtMailSubject.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtMailSubject.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtMailSubject.BorderRadius = 0;
            this.txtMailSubject.BorderSize = 1;
            this.txtMailSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMailSubject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMailSubject.Location = new System.Drawing.Point(476, 78);
            this.txtMailSubject.Margin = new System.Windows.Forms.Padding(4);
            this.txtMailSubject.Multiline = true;
            this.txtMailSubject.Name = "txtMailSubject";
            this.txtMailSubject.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtMailSubject.PasswordChar = false;
            this.txtMailSubject.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtMailSubject.PlaceholderText = "";
            this.txtMailSubject.Size = new System.Drawing.Size(295, 35);
            this.txtMailSubject.TabIndex = 45;
            this.txtMailSubject.UnderlinedStyle = false;
            // 
            // MailDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 290);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MailDetailView";
            this.Text = "Mail Detail";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtMailBody;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblBody;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblMailCc;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblSubject;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblMailTo;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtIMailCc;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtIMailto;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtMailSubject;
        private SparrowRMSControl.SparrowControl.SparrowButton btnSendMail;
    }
}