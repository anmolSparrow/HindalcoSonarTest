
namespace HindalcoiOS.Login_Form
{
    partial class frmRecoverPassword
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
            this.btnRecover = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.txtEmailID = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.bunifuLabel1 = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSubmit = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.txtAnswer = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtQuestion = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.bunifuLabel3 = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.bunifuLabel2 = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnChangePassword = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.txtConfirmNewPassword = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtNewPassword = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.bunifuLabel5 = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.bunifuLabel4 = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRecover);
            this.groupBox1.Controls.Add(this.txtEmailID);
            this.groupBox1.Controls.Add(this.bunifuLabel1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(726, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recover Password";
            // 
            // btnRecover
            // 
            this.btnRecover.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRecover.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnRecover.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnRecover.BorderRadius = 14;
            this.btnRecover.BorderSize = 0;
            this.btnRecover.FlatAppearance.BorderSize = 0;
            this.btnRecover.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnRecover.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnRecover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecover.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecover.ForeColor = System.Drawing.Color.White;
            this.btnRecover.Location = new System.Drawing.Point(556, 27);
            this.btnRecover.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnRecover.Name = "btnRecover";
            this.btnRecover.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnRecover.Size = new System.Drawing.Size(137, 30);
            this.btnRecover.TabIndex = 2;
            this.btnRecover.Text = "Recover";
            this.btnRecover.TextColor = System.Drawing.Color.White;
            this.btnRecover.UseVisualStyleBackColor = false;
            this.btnRecover.Click += new System.EventHandler(this.BtnRecover_Click);
            // 
            // txtEmailID
            // 
            this.txtEmailID.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmailID.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtEmailID.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtEmailID.BorderRadius = 0;
            this.txtEmailID.BorderSize = 1;
            this.txtEmailID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtEmailID.Location = new System.Drawing.Point(241, 17);
            this.txtEmailID.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmailID.Multiline = true;
            this.txtEmailID.Name = "txtEmailID";
            this.txtEmailID.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtEmailID.PasswordChar = false;
            this.txtEmailID.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtEmailID.PlaceholderText = "Enter Text";
            this.txtEmailID.Size = new System.Drawing.Size(210, 34);
            this.txtEmailID.TabIndex = 1;
            this.txtEmailID.UnderlinedStyle = false;
            this.txtEmailID._TextChanged += new System.EventHandler(this.txtEmailID__TextChanged);
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AutoSize = true;
            this.bunifuLabel1.Depth = 0;
            this.bunifuLabel1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.bunifuLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bunifuLabel1.Location = new System.Drawing.Point(7, 36);
            this.bunifuLabel1.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.Size = new System.Drawing.Size(124, 21);
            this.bunifuLabel1.TabIndex = 0;
            this.bunifuLabel1.Text = "Enter E-Mail ID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSubmit);
            this.groupBox2.Controls.Add(this.txtAnswer);
            this.groupBox2.Controls.Add(this.txtQuestion);
            this.groupBox2.Controls.Add(this.bunifuLabel3);
            this.groupBox2.Controls.Add(this.bunifuLabel2);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(13, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(726, 115);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Security Question and Answer";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSubmit.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnSubmit.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSubmit.BorderRadius = 14;
            this.btnSubmit.BorderSize = 0;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSubmit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(556, 71);
            this.btnSubmit.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnSubmit.Size = new System.Drawing.Size(137, 30);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.TextColor = System.Drawing.Color.White;
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // txtAnswer
            // 
            this.txtAnswer.BackColor = System.Drawing.SystemColors.Window;
            this.txtAnswer.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtAnswer.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtAnswer.BorderRadius = 0;
            this.txtAnswer.BorderSize = 1;
            this.txtAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnswer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAnswer.Location = new System.Drawing.Point(241, 71);
            this.txtAnswer.Margin = new System.Windows.Forms.Padding(4);
            this.txtAnswer.Multiline = true;
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtAnswer.PasswordChar = false;
            this.txtAnswer.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtAnswer.PlaceholderText = "Enter Text";
            this.txtAnswer.Size = new System.Drawing.Size(210, 34);
            this.txtAnswer.TabIndex = 3;
            this.txtAnswer.UnderlinedStyle = false;
            // 
            // txtQuestion
            // 
            this.txtQuestion.BackColor = System.Drawing.SystemColors.Window;
            this.txtQuestion.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtQuestion.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtQuestion.BorderRadius = 0;
            this.txtQuestion.BorderSize = 1;
            this.txtQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuestion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtQuestion.Location = new System.Drawing.Point(241, 25);
            this.txtQuestion.Margin = new System.Windows.Forms.Padding(4);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtQuestion.PasswordChar = false;
            this.txtQuestion.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtQuestion.PlaceholderText = "Enter Text";
            this.txtQuestion.Size = new System.Drawing.Size(210, 34);
            this.txtQuestion.TabIndex = 2;
            this.txtQuestion.UnderlinedStyle = false;
            // 
            // bunifuLabel3
            // 
            this.bunifuLabel3.AutoSize = true;
            this.bunifuLabel3.Depth = 0;
            this.bunifuLabel3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.bunifuLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bunifuLabel3.Location = new System.Drawing.Point(11, 80);
            this.bunifuLabel3.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.bunifuLabel3.Name = "bunifuLabel3";
            this.bunifuLabel3.Size = new System.Drawing.Size(66, 21);
            this.bunifuLabel3.TabIndex = 1;
            this.bunifuLabel3.Text = "Answer";
            // 
            // bunifuLabel2
            // 
            this.bunifuLabel2.AutoSize = true;
            this.bunifuLabel2.Depth = 0;
            this.bunifuLabel2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.bunifuLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bunifuLabel2.Location = new System.Drawing.Point(11, 34);
            this.bunifuLabel2.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.bunifuLabel2.Name = "bunifuLabel2";
            this.bunifuLabel2.Size = new System.Drawing.Size(76, 21);
            this.bunifuLabel2.TabIndex = 0;
            this.bunifuLabel2.Text = "Question";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnChangePassword);
            this.groupBox3.Controls.Add(this.txtConfirmNewPassword);
            this.groupBox3.Controls.Add(this.txtNewPassword);
            this.groupBox3.Controls.Add(this.bunifuLabel5);
            this.groupBox3.Controls.Add(this.bunifuLabel4);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(13, 217);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(725, 115);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Change Password";
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnChangePassword.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnChangePassword.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnChangePassword.BorderRadius = 14;
            this.btnChangePassword.BorderSize = 0;
            this.btnChangePassword.FlatAppearance.BorderSize = 0;
            this.btnChangePassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnChangePassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.Location = new System.Drawing.Point(556, 71);
            this.btnChangePassword.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnChangePassword.Size = new System.Drawing.Size(137, 30);
            this.btnChangePassword.TabIndex = 7;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.TextColor = System.Drawing.Color.White;
            this.btnChangePassword.UseVisualStyleBackColor = false;
            this.btnChangePassword.Click += new System.EventHandler(this.BtnChangePassword_Click);
            // 
            // txtConfirmNewPassword
            // 
            this.txtConfirmNewPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtConfirmNewPassword.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtConfirmNewPassword.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtConfirmNewPassword.BorderRadius = 0;
            this.txtConfirmNewPassword.BorderSize = 1;
            this.txtConfirmNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConfirmNewPassword.Location = new System.Drawing.Point(241, 71);
            this.txtConfirmNewPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfirmNewPassword.Multiline = true;
            this.txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            this.txtConfirmNewPassword.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtConfirmNewPassword.PasswordChar = true;
            this.txtConfirmNewPassword.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtConfirmNewPassword.PlaceholderText = "Enter Text";
            this.txtConfirmNewPassword.Size = new System.Drawing.Size(210, 34);
            this.txtConfirmNewPassword.TabIndex = 6;
            this.txtConfirmNewPassword.UnderlinedStyle = false;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtNewPassword.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtNewPassword.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtNewPassword.BorderRadius = 0;
            this.txtNewPassword.BorderSize = 1;
            this.txtNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNewPassword.Location = new System.Drawing.Point(241, 27);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewPassword.Multiline = true;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtNewPassword.PasswordChar = true;
            this.txtNewPassword.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtNewPassword.PlaceholderText = "Enter Text";
            this.txtNewPassword.Size = new System.Drawing.Size(210, 34);
            this.txtNewPassword.TabIndex = 5;
            this.txtNewPassword.UnderlinedStyle = false;
            // 
            // bunifuLabel5
            // 
            this.bunifuLabel5.AutoSize = true;
            this.bunifuLabel5.Depth = 0;
            this.bunifuLabel5.Font = new System.Drawing.Font("Tahoma", 10F);
            this.bunifuLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bunifuLabel5.Location = new System.Drawing.Point(11, 80);
            this.bunifuLabel5.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.bunifuLabel5.Name = "bunifuLabel5";
            this.bunifuLabel5.Size = new System.Drawing.Size(181, 21);
            this.bunifuLabel5.TabIndex = 2;
            this.bunifuLabel5.Text = "Confirm New Password";
            // 
            // bunifuLabel4
            // 
            this.bunifuLabel4.AutoSize = true;
            this.bunifuLabel4.Depth = 0;
            this.bunifuLabel4.Font = new System.Drawing.Font("Tahoma", 10F);
            this.bunifuLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bunifuLabel4.Location = new System.Drawing.Point(11, 36);
            this.bunifuLabel4.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.bunifuLabel4.Name = "bunifuLabel4";
            this.bunifuLabel4.Size = new System.Drawing.Size(119, 21);
            this.bunifuLabel4.TabIndex = 1;
            this.bunifuLabel4.Text = "New Password";
            // 
            // frmRecoverPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 357);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRecoverPassword";
            this.Text = "Recover Password";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.RecoverPassword_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private SparrowRMSControl.SparrowControl.SparrowButton btnRecover;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtEmailID;
        private SparrowRMSControl.SparrowControl.SparrowLabel bunifuLabel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private SparrowRMSControl.SparrowControl.SparrowButton btnSubmit;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtAnswer;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtQuestion;
        private SparrowRMSControl.SparrowControl.SparrowLabel bunifuLabel3;
        private SparrowRMSControl.SparrowControl.SparrowLabel bunifuLabel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private SparrowRMSControl.SparrowControl.SparrowButton btnChangePassword;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtConfirmNewPassword;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtNewPassword;
        private SparrowRMSControl.SparrowControl.SparrowLabel bunifuLabel5;
        private SparrowRMSControl.SparrowControl.SparrowLabel bunifuLabel4;
    }
}