namespace RMPCLApp.Login_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageUsers));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.chkIsActived = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cobRole = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvUserdata = new System.Windows.Forms.DataGridView();
            this.lblunlock = new System.Windows.Forms.Label();
            this.chkunlick = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserdata)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblunlock);
            this.groupBox1.Controls.Add(this.chkunlick);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.chkIsActived);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cobRole);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(684, 238);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Information";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSave.Location = new System.Drawing.Point(523, 50);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 28);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(88, 178);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Active";
            // 
            // chkIsActived
            // 
            this.chkIsActived.AutoSize = true;
            this.chkIsActived.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkIsActived.Location = new System.Drawing.Point(152, 180);
            this.chkIsActived.Margin = new System.Windows.Forms.Padding(4);
            this.chkIsActived.Name = "chkIsActived";
            this.chkIsActived.Size = new System.Drawing.Size(18, 17);
            this.chkIsActived.TabIndex = 4;
            this.chkIsActived.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(88, 132);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Role";
            // 
            // cobRole
            // 
            this.cobRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cobRole.FormattingEnabled = true;
            this.cobRole.Location = new System.Drawing.Point(152, 132);
            this.cobRole.Margin = new System.Windows.Forms.Padding(4);
            this.cobRole.Name = "cobRole";
            this.cobRole.Size = new System.Drawing.Size(344, 28);
            this.cobRole.TabIndex = 3;
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtEmail.Location = new System.Drawing.Point(152, 92);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(344, 26);
            this.txtEmail.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(80, 92);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Email";
            // 
            // txtUserName
            // 
            this.txtUserName.Enabled = false;
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtUserName.Location = new System.Drawing.Point(152, 53);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(344, 26);
            this.txtUserName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(39, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "User Name";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSearch.Location = new System.Drawing.Point(539, 260);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(119, 41);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(16, 271);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtSearch.Location = new System.Drawing.Point(85, 267);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(427, 26);
            this.txtSearch.TabIndex = 0;
            // 
            // dgvUserdata
            // 
            this.dgvUserdata.AllowUserToAddRows = false;
            this.dgvUserdata.AllowUserToDeleteRows = false;
            this.dgvUserdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserdata.Location = new System.Drawing.Point(16, 318);
            this.dgvUserdata.Margin = new System.Windows.Forms.Padding(4);
            this.dgvUserdata.Name = "dgvUserdata";
            this.dgvUserdata.ReadOnly = true;
            this.dgvUserdata.RowHeadersWidth = 51;
            this.dgvUserdata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserdata.Size = new System.Drawing.Size(684, 304);
            this.dgvUserdata.TabIndex = 6;
            this.dgvUserdata.SelectionChanged += new System.EventHandler(this.dgvUserdata_SelectionChanged);
            // 
            // lblunlock
            // 
            this.lblunlock.AutoSize = true;
            this.lblunlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblunlock.Location = new System.Drawing.Point(88, 201);
            this.lblunlock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblunlock.Name = "lblunlock";
            this.lblunlock.Size = new System.Drawing.Size(101, 20);
            this.lblunlock.TabIndex = 9;
            this.lblunlock.Text = "Unlock User";
            this.lblunlock.Visible = false;
            // 
            // chkunlick
            // 
            this.chkunlick.AutoSize = true;
            this.chkunlick.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkunlick.Location = new System.Drawing.Point(194, 204);
            this.chkunlick.Margin = new System.Windows.Forms.Padding(4);
            this.chkunlick.Name = "chkunlick";
            this.chkunlick.Size = new System.Drawing.Size(18, 17);
            this.chkunlick.TabIndex = 8;
            this.chkunlick.UseVisualStyleBackColor = true;
            this.chkunlick.Visible = false;
            // 
            // frmManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 639);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvUserdata);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmManageUsers.IconOptions.Icon")));
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("frmManageUsers.IconOptions.SvgImage")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmManageUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Users";
            this.Load += new System.EventHandler(this.ManageUsers_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkIsActived;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cobRole;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvUserdata;
        private System.Windows.Forms.Label lblunlock;
        private System.Windows.Forms.CheckBox chkunlick;
    }
}