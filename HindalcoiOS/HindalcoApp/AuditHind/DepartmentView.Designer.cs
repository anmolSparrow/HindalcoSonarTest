
namespace HindalcoiOS.AuditHind
{
    partial class DepartmentView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbxAddVendor = new System.Windows.Forms.GroupBox();
            this.cmbOpUnit = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.lblDept = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.btnAdd = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnCancel = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.lblDeptCode = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblDeptName = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtDeptCode = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtDeptName = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.gbxViewVendor = new System.Windows.Forms.GroupBox();
            this.dgvViewDeptMaster = new System.Windows.Forms.DataGridView();
            this.DeptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeptCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperationUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxAddVendor.SuspendLayout();
            this.gbxViewVendor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewDeptMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxAddVendor
            // 
            this.gbxAddVendor.Controls.Add(this.cmbOpUnit);
            this.gbxAddVendor.Controls.Add(this.lblDept);
            this.gbxAddVendor.Controls.Add(this.btnAdd);
            this.gbxAddVendor.Controls.Add(this.btnCancel);
            this.gbxAddVendor.Controls.Add(this.lblDeptCode);
            this.gbxAddVendor.Controls.Add(this.lblDeptName);
            this.gbxAddVendor.Controls.Add(this.txtDeptCode);
            this.gbxAddVendor.Controls.Add(this.txtDeptName);
            this.gbxAddVendor.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxAddVendor.Location = new System.Drawing.Point(12, 1);
            this.gbxAddVendor.Name = "gbxAddVendor";
            this.gbxAddVendor.Size = new System.Drawing.Size(750, 126);
            this.gbxAddVendor.TabIndex = 0;
            this.gbxAddVendor.TabStop = false;
            this.gbxAddVendor.Text = "Add";
            // 
            // cmbOpUnit
            // 
            this.cmbOpUnit.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbOpUnit.BorderSize = 0;
            this.cmbOpUnit.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOpUnit.FormattingEnabled = true;
            this.cmbOpUnit.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbOpUnit.ListBackColor = System.Drawing.Color.Red;
            this.cmbOpUnit.ListTextColor = System.Drawing.Color.White;
            this.cmbOpUnit.Location = new System.Drawing.Point(526, 28);
            this.cmbOpUnit.Name = "cmbOpUnit";
            this.cmbOpUnit.Size = new System.Drawing.Size(207, 31);
            this.cmbOpUnit.TabIndex = 55;
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.Depth = 0;
            this.lblDept.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblDept.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDept.Location = new System.Drawing.Point(415, 35);
            this.lblDept.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(101, 18);
            this.lblDept.TabIndex = 54;
            this.lblDept.Text = "Operation Unit";
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
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(544, 82);
            this.btnAdd.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnAdd.Size = new System.Drawing.Size(72, 30);
            this.btnAdd.TabIndex = 51;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextColor = System.Drawing.Color.White;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(642, 82);
            this.btnCancel.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnCancel.Size = new System.Drawing.Size(83, 30);
            this.btnCancel.TabIndex = 50;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextColor = System.Drawing.Color.White;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblDeptCode
            // 
            this.lblDeptCode.AutoSize = true;
            this.lblDeptCode.Depth = 0;
            this.lblDeptCode.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblDeptCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDeptCode.Location = new System.Drawing.Point(32, 82);
            this.lblDeptCode.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblDeptCode.Name = "lblDeptCode";
            this.lblDeptCode.Size = new System.Drawing.Size(41, 18);
            this.lblDeptCode.TabIndex = 45;
            this.lblDeptCode.Text = "Code";
            // 
            // lblDeptName
            // 
            this.lblDeptName.AutoSize = true;
            this.lblDeptName.Depth = 0;
            this.lblDeptName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblDeptName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDeptName.Location = new System.Drawing.Point(28, 35);
            this.lblDeptName.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblDeptName.Name = "lblDeptName";
            this.lblDeptName.Size = new System.Drawing.Size(52, 18);
            this.lblDeptName.TabIndex = 44;
            this.lblDeptName.Text = " Name";
            // 
            // txtDeptCode
            // 
            this.txtDeptCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtDeptCode.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtDeptCode.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtDeptCode.BorderRadius = 0;
            this.txtDeptCode.BorderSize = 1;
            this.txtDeptCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeptCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDeptCode.Location = new System.Drawing.Point(129, 71);
            this.txtDeptCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtDeptCode.Multiline = true;
            this.txtDeptCode.Name = "txtDeptCode";
            this.txtDeptCode.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtDeptCode.PasswordChar = false;
            this.txtDeptCode.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtDeptCode.PlaceholderText = "";
            this.txtDeptCode.Size = new System.Drawing.Size(249, 35);
            this.txtDeptCode.TabIndex = 39;
            this.txtDeptCode.UnderlinedStyle = false;
            // 
            // txtDeptName
            // 
            this.txtDeptName.BackColor = System.Drawing.SystemColors.Window;
            this.txtDeptName.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtDeptName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtDeptName.BorderRadius = 0;
            this.txtDeptName.BorderSize = 1;
            this.txtDeptName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeptName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDeptName.Location = new System.Drawing.Point(129, 25);
            this.txtDeptName.Margin = new System.Windows.Forms.Padding(4);
            this.txtDeptName.Multiline = true;
            this.txtDeptName.Name = "txtDeptName";
            this.txtDeptName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtDeptName.PasswordChar = false;
            this.txtDeptName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtDeptName.PlaceholderText = "";
            this.txtDeptName.Size = new System.Drawing.Size(249, 35);
            this.txtDeptName.TabIndex = 38;
            this.txtDeptName.UnderlinedStyle = false;
            // 
            // gbxViewVendor
            // 
            this.gbxViewVendor.Controls.Add(this.dgvViewDeptMaster);
            this.gbxViewVendor.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxViewVendor.Location = new System.Drawing.Point(12, 138);
            this.gbxViewVendor.Name = "gbxViewVendor";
            this.gbxViewVendor.Size = new System.Drawing.Size(750, 187);
            this.gbxViewVendor.TabIndex = 50;
            this.gbxViewVendor.TabStop = false;
            this.gbxViewVendor.Text = "View All";
            // 
            // dgvViewDeptMaster
            // 
            this.dgvViewDeptMaster.AllowUserToAddRows = false;
            this.dgvViewDeptMaster.AllowUserToDeleteRows = false;
            this.dgvViewDeptMaster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvViewDeptMaster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvViewDeptMaster.ColumnHeadersHeight = 35;
            this.dgvViewDeptMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvViewDeptMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeptName,
            this.DeptCode,
            this.OperationUnit,
            this.CreatedDate});
            this.dgvViewDeptMaster.EnableHeadersVisualStyles = false;
            this.dgvViewDeptMaster.Location = new System.Drawing.Point(18, 25);
            this.dgvViewDeptMaster.Name = "dgvViewDeptMaster";
            this.dgvViewDeptMaster.ReadOnly = true;
            this.dgvViewDeptMaster.RowHeadersVisible = false;
            this.dgvViewDeptMaster.RowHeadersWidth = 51;
            this.dgvViewDeptMaster.RowTemplate.Height = 24;
            this.dgvViewDeptMaster.Size = new System.Drawing.Size(715, 144);
            this.dgvViewDeptMaster.TabIndex = 0;
            this.dgvViewDeptMaster.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViewDeptMaster_CellDoubleClick);
            // 
            // DeptName
            // 
            this.DeptName.HeaderText = "Department Name";
            this.DeptName.MinimumWidth = 6;
            this.DeptName.Name = "DeptName";
            this.DeptName.ReadOnly = true;
            // 
            // DeptCode
            // 
            this.DeptCode.HeaderText = "Department Code";
            this.DeptCode.MinimumWidth = 6;
            this.DeptCode.Name = "DeptCode";
            this.DeptCode.ReadOnly = true;
            // 
            // OperationUnit
            // 
            this.OperationUnit.HeaderText = "OperationUnit";
            this.OperationUnit.MinimumWidth = 6;
            this.OperationUnit.Name = "OperationUnit";
            this.OperationUnit.ReadOnly = true;
            // 
            // CreatedDate
            // 
            this.CreatedDate.HeaderText = "Created Date";
            this.CreatedDate.MinimumWidth = 6;
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.ReadOnly = true;
            // 
            // DepartmentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 337);
            this.Controls.Add(this.gbxViewVendor);
            this.Controls.Add(this.gbxAddVendor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DepartmentView";
            this.Text = "Department";
            this.Load += new System.EventHandler(this.Department_Load);
            this.gbxAddVendor.ResumeLayout(false);
            this.gbxAddVendor.PerformLayout();
            this.gbxViewVendor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewDeptMaster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxAddVendor;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblDeptCode;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblDeptName;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtDeptCode;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtDeptName;
        private System.Windows.Forms.GroupBox gbxViewVendor;
        private SparrowRMSControl.SparrowControl.SparrowButton btnAdd;
        private SparrowRMSControl.SparrowControl.SparrowButton btnCancel;
        private System.Windows.Forms.DataGridView dgvViewDeptMaster;
        private SparrowRMSControl.SparrowControl.SparrowComboBox cmbOpUnit;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeptCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperationUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
    }
}