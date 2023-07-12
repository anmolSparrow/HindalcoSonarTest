
namespace RMPCL_Form_Design.Login_Form
{
    partial class DBConfiguration
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
            this.chkdetails = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.chckAutoCAD = new SparrowRMSControl.SparrowControl.SparrowCheckBox();
            this.txtPassword = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.labelControl4 = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtDBName = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblDBName = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtUserName = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblUserName = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtServerName = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblserver = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.BtnUpdate = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btncancel = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkdetails);
            this.groupBox1.Controls.Add(this.chckAutoCAD);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.labelControl4);
            this.groupBox1.Controls.Add(this.txtDBName);
            this.groupBox1.Controls.Add(this.lblDBName);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.lblUserName);
            this.groupBox1.Controls.Add(this.txtServerName);
            this.groupBox1.Controls.Add(this.lblserver);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(852, 229);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DB Configuration";
            // 
            // chkdetails
            // 
            this.chkdetails.AutoSize = true;
            this.chkdetails.Depth = 0;
            this.chkdetails.Font = new System.Drawing.Font("Tahoma", 10F);
            this.chkdetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chkdetails.Location = new System.Drawing.Point(455, 195);
            this.chkdetails.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.chkdetails.Name = "chkdetails";
            this.chkdetails.Size = new System.Drawing.Size(386, 21);
            this.chkdetails.TabIndex = 9;
            this.chkdetails.Text = "Tick the checkbox to enable CAD autoload feature.";
            // 
            // chckAutoCAD
            // 
            this.chckAutoCAD.AutoSize = true;
            this.chckAutoCAD.Depth = 0;
            this.chckAutoCAD.Location = new System.Drawing.Point(530, 165);
            this.chckAutoCAD.Margin = new System.Windows.Forms.Padding(0);
            this.chckAutoCAD.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chckAutoCAD.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.chckAutoCAD.Name = "chckAutoCAD";
            this.chckAutoCAD.Ripple = true;
            this.chckAutoCAD.Size = new System.Drawing.Size(161, 30);
            this.chckAutoCAD.TabIndex = 8;
            this.chckAutoCAD.Text = "CAD Load Status";
            this.chckAutoCAD.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtPassword.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtPassword.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtPassword.BorderRadius = 0;
            this.txtPassword.BorderSize = 1;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPassword.Location = new System.Drawing.Point(611, 104);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtPassword.PasswordChar = false;
            this.txtPassword.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtPassword.PlaceholderText = "Enter Text";
            this.txtPassword.Size = new System.Drawing.Size(210, 30);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.Texts = "";
            this.txtPassword.UnderlinedStyle = false;
            // 
            // labelControl4
            // 
            this.labelControl4.AutoSize = true;
            this.labelControl4.Depth = 0;
            this.labelControl4.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelControl4.Location = new System.Drawing.Point(434, 113);
            this.labelControl4.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(81, 21);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Password";
            // 
            // txtDBName
            // 
            this.txtDBName.BackColor = System.Drawing.SystemColors.Window;
            this.txtDBName.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtDBName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtDBName.BorderRadius = 0;
            this.txtDBName.BorderSize = 1;
            this.txtDBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDBName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDBName.Location = new System.Drawing.Point(611, 30);
            this.txtDBName.Margin = new System.Windows.Forms.Padding(4);
            this.txtDBName.Multiline = true;
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtDBName.PasswordChar = false;
            this.txtDBName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtDBName.PlaceholderText = "Enter Text";
            this.txtDBName.Size = new System.Drawing.Size(210, 30);
            this.txtDBName.TabIndex = 5;
            this.txtDBName.Texts = "";
            this.txtDBName.UnderlinedStyle = false;
            // 
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
            this.lblDBName.Depth = 0;
            this.lblDBName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblDBName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDBName.Location = new System.Drawing.Point(430, 39);
            this.lblDBName.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(80, 21);
            this.lblDBName.TabIndex = 4;
            this.lblDBName.Text = "DB Name";
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserName.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtUserName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtUserName.BorderRadius = 0;
            this.txtUserName.BorderSize = 1;
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUserName.Location = new System.Drawing.Point(188, 104);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserName.Multiline = true;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtUserName.PasswordChar = false;
            this.txtUserName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtUserName.PlaceholderText = "Enter Text";
            this.txtUserName.Size = new System.Drawing.Size(210, 30);
            this.txtUserName.TabIndex = 3;
            this.txtUserName.Texts = "";
            this.txtUserName.UnderlinedStyle = false;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Depth = 0;
            this.lblUserName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUserName.Location = new System.Drawing.Point(11, 113);
            this.lblUserName.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(92, 21);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "User Name";
            // 
            // txtServerName
            // 
            this.txtServerName.BackColor = System.Drawing.SystemColors.Window;
            this.txtServerName.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtServerName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtServerName.BorderRadius = 0;
            this.txtServerName.BorderSize = 1;
            this.txtServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtServerName.Location = new System.Drawing.Point(188, 30);
            this.txtServerName.Margin = new System.Windows.Forms.Padding(4);
            this.txtServerName.Multiline = true;
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtServerName.PasswordChar = false;
            this.txtServerName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtServerName.PlaceholderText = "Enter Text";
            this.txtServerName.Size = new System.Drawing.Size(210, 30);
            this.txtServerName.TabIndex = 1;
            this.txtServerName.Texts = "";
            this.txtServerName.UnderlinedStyle = false;
            // 
            // lblserver
            // 
            this.lblserver.AutoSize = true;
            this.lblserver.Depth = 0;
            this.lblserver.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblserver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblserver.Location = new System.Drawing.Point(7, 39);
            this.lblserver.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblserver.Name = "lblserver";
            this.lblserver.Size = new System.Drawing.Size(105, 21);
            this.lblserver.TabIndex = 0;
            this.lblserver.Text = "Server Name";
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnUpdate.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.BtnUpdate.BorderColor = System.Drawing.Color.DodgerBlue;
            this.BtnUpdate.BorderRadius = 14;
            this.BtnUpdate.BorderSize = 0;
            this.BtnUpdate.FlatAppearance.BorderSize = 0;
            this.BtnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.BtnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.BtnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUpdate.ForeColor = System.Drawing.Color.White;
            this.BtnUpdate.Location = new System.Drawing.Point(307, 248);
            this.BtnUpdate.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.BtnUpdate.Size = new System.Drawing.Size(124, 30);
            this.BtnUpdate.TabIndex = 1;
            this.BtnUpdate.Text = "Update";
            this.BtnUpdate.TextColor = System.Drawing.Color.White;
            this.BtnUpdate.UseVisualStyleBackColor = false;
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btncancel.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btncancel.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btncancel.BorderRadius = 14;
            this.btncancel.BorderSize = 0;
            this.btncancel.FlatAppearance.BorderSize = 0;
            this.btncancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btncancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancel.ForeColor = System.Drawing.Color.White;
            this.btncancel.Location = new System.Drawing.Point(471, 248);
            this.btncancel.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btncancel.Name = "btncancel";
            this.btncancel.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btncancel.Size = new System.Drawing.Size(124, 30);
            this.btncancel.TabIndex = 2;
            this.btncancel.Text = "Cancel";
            this.btncancel.TextColor = System.Drawing.Color.White;
            this.btncancel.UseVisualStyleBackColor = false;
            // 
            // DBConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 294);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DBConfiguration";
            this.Text = "DB Configuration";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private SparrowRMSControl.SparrowControl.SparrowLabel chkdetails;
        private SparrowRMSControl.SparrowControl.SparrowCheckBox chckAutoCAD;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtPassword;
        private SparrowRMSControl.SparrowControl.SparrowLabel labelControl4;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtDBName;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblDBName;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtUserName;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblUserName;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtServerName;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblserver;
        private SparrowRMSControl.SparrowControl.SparrowButton BtnUpdate;
        private SparrowRMSControl.SparrowControl.SparrowButton btncancel;
    }
}