
namespace HindalcoiOS.Login_Form
{
    partial class frmManageUsers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageUsers));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cobRole = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.chkIsActived = new System.Windows.Forms.CheckBox();
            this.chkunlick = new System.Windows.Forms.CheckBox();
            this.txtEmail = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtUserName = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblunlock = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.label6 = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.label5 = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.label4 = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.label3 = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.btnSave = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.txtSearch = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.sparrowButton2 = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.dgvUserdata = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserdata)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cobRole);
            this.groupBox1.Controls.Add(this.chkIsActived);
            this.groupBox1.Controls.Add(this.chkunlick);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.lblunlock);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(941, 197);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Information";
            // 
            // cobRole
            // 
            this.cobRole.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cobRole.BorderSize = 1;
            this.cobRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cobRole.FormattingEnabled = true;
            this.cobRole.IconColor = System.Drawing.Color.DodgerBlue;
            this.cobRole.ItemHeight = 22;
            this.cobRole.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.cobRole.ListTextColor = System.Drawing.Color.White;
            this.cobRole.Location = new System.Drawing.Point(689, 44);
            this.cobRole.MinimumSize = new System.Drawing.Size(200, 0);
            this.cobRole.Name = "cobRole";
            this.cobRole.Size = new System.Drawing.Size(235, 30);
            this.cobRole.TabIndex = 33;
            // 
            // chkIsActived
            // 
            this.chkIsActived.AutoSize = true;
            this.chkIsActived.Location = new System.Drawing.Point(153, 149);
            this.chkIsActived.Name = "chkIsActived";
            this.chkIsActived.Size = new System.Drawing.Size(18, 17);
            this.chkIsActived.TabIndex = 29;
            this.chkIsActived.UseVisualStyleBackColor = true;
            // 
            // chkunlick
            // 
            this.chkunlick.AutoSize = true;
            this.chkunlick.Location = new System.Drawing.Point(398, 149);
            this.chkunlick.Name = "chkunlick";
            this.chkunlick.Size = new System.Drawing.Size(18, 17);
            this.chkunlick.TabIndex = 28;
            this.chkunlick.UseVisualStyleBackColor = true;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmail.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtEmail.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtEmail.BorderRadius = 0;
            this.txtEmail.BorderSize = 1;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtEmail.Location = new System.Drawing.Point(147, 90);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtEmail.PasswordChar = false;
            this.txtEmail.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtEmail.PlaceholderText = "Email";
            this.txtEmail.Size = new System.Drawing.Size(269, 32);
            this.txtEmail.TabIndex = 26;
            this.txtEmail.UnderlinedStyle = false;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserName.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtUserName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtUserName.BorderRadius = 0;
            this.txtUserName.BorderSize = 1;
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUserName.Location = new System.Drawing.Point(147, 44);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserName.Multiline = true;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtUserName.PasswordChar = false;
            this.txtUserName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtUserName.PlaceholderText = "User Name";
            this.txtUserName.Size = new System.Drawing.Size(269, 32);
            this.txtUserName.TabIndex = 25;
            this.txtUserName.UnderlinedStyle = false;
            // 
            // lblunlock
            // 
            this.lblunlock.AutoSize = true;
            this.lblunlock.Depth = 0;
            this.lblunlock.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblunlock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblunlock.Location = new System.Drawing.Point(250, 138);
            this.lblunlock.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblunlock.Name = "lblunlock";
            this.lblunlock.Padding = new System.Windows.Forms.Padding(25, 10, 0, 0);
            this.lblunlock.Size = new System.Drawing.Size(123, 31);
            this.lblunlock.TabIndex = 4;
            this.lblunlock.Text = "Unlock User";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Depth = 0;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(13, 123);
            this.label6.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(25, 25, 0, 0);
            this.label6.Size = new System.Drawing.Size(81, 46);
            this.label6.TabIndex = 3;
            this.label6.Text = "Active";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Depth = 0;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(587, 28);
            this.label5.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(25, 25, 0, 0);
            this.label5.Size = new System.Drawing.Size(68, 46);
            this.label5.TabIndex = 2;
            this.label5.Text = "Role";
            // 
            // label4
            // 
            this.label4.Depth = 0;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(18, 73);
            this.label4.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(25, 25, 0, 0);
            this.label4.Size = new System.Drawing.Size(76, 46);
            this.label4.TabIndex = 1;
            this.label4.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Depth = 0;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label3.Location = new System.Drawing.Point(13, 27);
            this.label3.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(25, 25, 0, 0);
            this.label3.Size = new System.Drawing.Size(117, 46);
            this.label3.TabIndex = 0;
            this.label3.Text = "User Name";
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
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(804, 558);
            this.btnSave.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSave.Name = "btnSave";
            this.btnSave.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnSave.Size = new System.Drawing.Size(396, 34);
            this.btnSave.TabIndex = 32;
            this.btnSave.Text = "Update User";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtSearch.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtSearch.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtSearch.BorderRadius = 0;
            this.txtSearch.BorderSize = 1;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSearch.Location = new System.Drawing.Point(13, 30);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtSearch.PasswordChar = false;
            this.txtSearch.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSearch.PlaceholderText = "Search Here";
            this.txtSearch.Size = new System.Drawing.Size(312, 32);
            this.txtSearch.TabIndex = 31;
            this.txtSearch.UnderlinedStyle = false;
            // 
            // sparrowButton2
            // 
            this.sparrowButton2.BackColor = System.Drawing.Color.DodgerBlue;
            this.sparrowButton2.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.sparrowButton2.BorderColor = System.Drawing.Color.DodgerBlue;
            this.sparrowButton2.BorderRadius = 14;
            this.sparrowButton2.BorderSize = 0;
            this.sparrowButton2.FlatAppearance.BorderSize = 0;
            this.sparrowButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.sparrowButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.sparrowButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sparrowButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sparrowButton2.ForeColor = System.Drawing.Color.White;
            this.sparrowButton2.Location = new System.Drawing.Point(333, 30);
            this.sparrowButton2.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.sparrowButton2.Name = "sparrowButton2";
            this.sparrowButton2.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.sparrowButton2.Size = new System.Drawing.Size(93, 30);
            this.sparrowButton2.TabIndex = 31;
            this.sparrowButton2.Text = "Search";
            this.sparrowButton2.TextColor = System.Drawing.Color.White;
            this.sparrowButton2.UseVisualStyleBackColor = false;
            this.sparrowButton2.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvUserdata
            // 
            this.dgvUserdata.AllowUserToAddRows = false;
            this.dgvUserdata.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUserdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUserdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserdata.EnableHeadersVisualStyles = false;
            this.dgvUserdata.Location = new System.Drawing.Point(13, 69);
            this.dgvUserdata.Name = "dgvUserdata";
            this.dgvUserdata.ReadOnly = true;
            this.dgvUserdata.RowHeadersVisible = false;
            this.dgvUserdata.RowHeadersWidth = 62;
            this.dgvUserdata.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvUserdata.RowTemplate.Height = 28;
            this.dgvUserdata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserdata.Size = new System.Drawing.Size(1188, 263);
            this.dgvUserdata.TabIndex = 32;
            this.dgvUserdata.SelectionChanged += new System.EventHandler(this.dgvUserdata_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvUserdata);
            this.groupBox2.Controls.Add(this.sparrowButton2);
            this.groupBox2.Controls.Add(this.txtSearch);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(19, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1201, 338);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "All Details";
            // 
            // frmManageUsers
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 604);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("frmManageUsers.IconOptions.LargeImage")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageUsers";
            this.Text = "Manage Users";
            this.Load += new System.EventHandler(this.ManageUsers_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserdata)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblunlock;
        private SparrowRMSControl.SparrowControl.SparrowLabel label5;
        private SparrowRMSControl.SparrowControl.SparrowLabel label4;
        private SparrowRMSControl.SparrowControl.SparrowLabel label3;
        private SparrowRMSControl.SparrowControl.SparrowButton btnSave;
        private System.Windows.Forms.CheckBox chkIsActived;
        private System.Windows.Forms.CheckBox chkunlick;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtEmail;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtUserName;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtSearch;
        private SparrowRMSControl.SparrowControl.SparrowButton sparrowButton2;
        private SparrowRMSControl.SparrowControl.SparrowComboBox cobRole;
        private System.Windows.Forms.DataGridView dgvUserdata;
        private System.Windows.Forms.GroupBox groupBox2;
        private SparrowRMSControl.SparrowControl.SparrowLabel label6;
    }
}