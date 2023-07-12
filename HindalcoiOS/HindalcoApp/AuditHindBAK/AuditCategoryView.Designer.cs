
namespace Hind.AuditMgmt
{
    partial class AuditCategoryView
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
            this.gbxAddCate = new System.Windows.Forms.GroupBox();
            this.cmbDept = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.lblDept = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.btnCateCancel = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.lblCateCode = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.btnAddCate = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.lblName = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtCateCode = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtCateName = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.gbxViewCate = new System.Windows.Forms.GroupBox();
            this.dgvViewCateMaster = new System.Windows.Forms.DataGridView();
            this.CateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeptCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxAddCate.SuspendLayout();
            this.gbxViewCate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewCateMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxAddCate
            // 
            this.gbxAddCate.Controls.Add(this.cmbDept);
            this.gbxAddCate.Controls.Add(this.lblDept);
            this.gbxAddCate.Controls.Add(this.btnCateCancel);
            this.gbxAddCate.Controls.Add(this.lblCateCode);
            this.gbxAddCate.Controls.Add(this.btnAddCate);
            this.gbxAddCate.Controls.Add(this.lblName);
            this.gbxAddCate.Controls.Add(this.txtCateCode);
            this.gbxAddCate.Controls.Add(this.txtCateName);
            this.gbxAddCate.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxAddCate.Location = new System.Drawing.Point(12, 0);
            this.gbxAddCate.Name = "gbxAddCate";
            this.gbxAddCate.Size = new System.Drawing.Size(767, 129);
            this.gbxAddCate.TabIndex = 0;
            this.gbxAddCate.TabStop = false;
            this.gbxAddCate.Text = "Add";
            // 
            // cmbDept
            // 
            this.cmbDept.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbDept.BorderSize = 0;
            this.cmbDept.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbDept.ListBackColor = System.Drawing.Color.Red;
            this.cmbDept.ListTextColor = System.Drawing.Color.White;
            this.cmbDept.Location = new System.Drawing.Point(505, 29);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(207, 31);
            this.cmbDept.TabIndex = 55;
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.Depth = 0;
            this.lblDept.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblDept.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDept.Location = new System.Drawing.Point(405, 32);
            this.lblDept.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(86, 18);
            this.lblDept.TabIndex = 54;
            this.lblDept.Text = "Department";
            // 
            // btnCateCancel
            // 
            this.btnCateCancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCateCancel.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnCateCancel.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnCateCancel.BorderRadius = 14;
            this.btnCateCancel.BorderSize = 0;
            this.btnCateCancel.FlatAppearance.BorderSize = 0;
            this.btnCateCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnCateCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnCateCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCateCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCateCancel.ForeColor = System.Drawing.Color.White;
            this.btnCateCancel.Location = new System.Drawing.Point(629, 80);
            this.btnCateCancel.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnCateCancel.Name = "btnCateCancel";
            this.btnCateCancel.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnCateCancel.Size = new System.Drawing.Size(79, 30);
            this.btnCateCancel.TabIndex = 50;
            this.btnCateCancel.Text = "Cancel";
            this.btnCateCancel.TextColor = System.Drawing.Color.White;
            this.btnCateCancel.UseVisualStyleBackColor = false;
            this.btnCateCancel.Click += new System.EventHandler(this.btnCateCancel_Click);
            // 
            // lblCateCode
            // 
            this.lblCateCode.AutoSize = true;
            this.lblCateCode.Depth = 0;
            this.lblCateCode.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblCateCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCateCode.Location = new System.Drawing.Point(32, 82);
            this.lblCateCode.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblCateCode.Name = "lblCateCode";
            this.lblCateCode.Size = new System.Drawing.Size(54, 18);
            this.lblCateCode.TabIndex = 45;
            this.lblCateCode.Text = "Code *";
            // 
            // btnAddCate
            // 
            this.btnAddCate.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddCate.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnAddCate.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnAddCate.BorderRadius = 14;
            this.btnAddCate.BorderSize = 0;
            this.btnAddCate.FlatAppearance.BorderSize = 0;
            this.btnAddCate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAddCate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAddCate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCate.ForeColor = System.Drawing.Color.White;
            this.btnAddCate.Location = new System.Drawing.Point(531, 79);
            this.btnAddCate.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAddCate.Name = "btnAddCate";
            this.btnAddCate.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnAddCate.Size = new System.Drawing.Size(77, 30);
            this.btnAddCate.TabIndex = 51;
            this.btnAddCate.Text = "Add";
            this.btnAddCate.TextColor = System.Drawing.Color.White;
            this.btnAddCate.UseVisualStyleBackColor = false;
            this.btnAddCate.Click += new System.EventHandler(this.btnAddCate_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Depth = 0;
            this.lblName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblName.Location = new System.Drawing.Point(28, 35);
            this.lblName.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(65, 18);
            this.lblName.TabIndex = 44;
            this.lblName.Text = " Name *";
            // 
            // txtCateCode
            // 
            this.txtCateCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtCateCode.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtCateCode.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtCateCode.BorderRadius = 0;
            this.txtCateCode.BorderSize = 1;
            this.txtCateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCateCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCateCode.Location = new System.Drawing.Point(113, 71);
            this.txtCateCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtCateCode.Multiline = true;
            this.txtCateCode.Name = "txtCateCode";
            this.txtCateCode.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtCateCode.PasswordChar = false;
            this.txtCateCode.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtCateCode.PlaceholderText = "";
            this.txtCateCode.Size = new System.Drawing.Size(210, 35);
            this.txtCateCode.TabIndex = 39;
            this.txtCateCode.UnderlinedStyle = false;
            // 
            // txtCateName
            // 
            this.txtCateName.BackColor = System.Drawing.SystemColors.Window;
            this.txtCateName.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtCateName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtCateName.BorderRadius = 0;
            this.txtCateName.BorderSize = 1;
            this.txtCateName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCateName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCateName.Location = new System.Drawing.Point(114, 25);
            this.txtCateName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCateName.Multiline = true;
            this.txtCateName.Name = "txtCateName";
            this.txtCateName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtCateName.PasswordChar = false;
            this.txtCateName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtCateName.PlaceholderText = "";
            this.txtCateName.Size = new System.Drawing.Size(210, 35);
            this.txtCateName.TabIndex = 38;
            this.txtCateName.UnderlinedStyle = false;
            // 
            // gbxViewCate
            // 
            this.gbxViewCate.Controls.Add(this.dgvViewCateMaster);
            this.gbxViewCate.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxViewCate.Location = new System.Drawing.Point(12, 141);
            this.gbxViewCate.Name = "gbxViewCate";
            this.gbxViewCate.Size = new System.Drawing.Size(767, 187);
            this.gbxViewCate.TabIndex = 50;
            this.gbxViewCate.TabStop = false;
            this.gbxViewCate.Text = "View All";
            // 
            // dgvViewCateMaster
            // 
            this.dgvViewCateMaster.AllowUserToAddRows = false;
            this.dgvViewCateMaster.AllowUserToDeleteRows = false;
            this.dgvViewCateMaster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvViewCateMaster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvViewCateMaster.ColumnHeadersHeight = 35;
            this.dgvViewCateMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvViewCateMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CateName,
            this.DeptCode,
            this.Dept,
            this.CreatedDate});
            this.dgvViewCateMaster.EnableHeadersVisualStyles = false;
            this.dgvViewCateMaster.Location = new System.Drawing.Point(16, 24);
            this.dgvViewCateMaster.Name = "dgvViewCateMaster";
            this.dgvViewCateMaster.ReadOnly = true;
            this.dgvViewCateMaster.RowHeadersVisible = false;
            this.dgvViewCateMaster.RowHeadersWidth = 51;
            this.dgvViewCateMaster.RowTemplate.Height = 24;
            this.dgvViewCateMaster.Size = new System.Drawing.Size(734, 144);
            this.dgvViewCateMaster.TabIndex = 0;
            this.dgvViewCateMaster.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViewCateMaster_CellDoubleClick);
            // 
            // CateName
            // 
            this.CateName.HeaderText = "Category Name";
            this.CateName.MinimumWidth = 6;
            this.CateName.Name = "CateName";
            this.CateName.ReadOnly = true;
            // 
            // DeptCode
            // 
            this.DeptCode.HeaderText = "Category Code";
            this.DeptCode.MinimumWidth = 6;
            this.DeptCode.Name = "DeptCode";
            this.DeptCode.ReadOnly = true;
            // 
            // Dept
            // 
            this.Dept.HeaderText = "Department";
            this.Dept.MinimumWidth = 6;
            this.Dept.Name = "Dept";
            this.Dept.ReadOnly = true;
            // 
            // CreatedDate
            // 
            this.CreatedDate.HeaderText = "Created Date";
            this.CreatedDate.MinimumWidth = 6;
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.ReadOnly = true;
            // 
            // AuditCategoryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 341);
            this.Controls.Add(this.gbxViewCate);
            this.Controls.Add(this.gbxAddCate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuditCategoryView";
            this.Text = "Audit Category";
            this.Load += new System.EventHandler(this.AuditCateMasterView_Load);
            this.gbxAddCate.ResumeLayout(false);
            this.gbxAddCate.PerformLayout();
            this.gbxViewCate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewCateMaster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxAddCate;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblCateCode;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblName;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtCateCode;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtCateName;
        private System.Windows.Forms.GroupBox gbxViewCate;
        private SparrowRMSControl.SparrowControl.SparrowButton btnAddCate;
        private SparrowRMSControl.SparrowControl.SparrowButton btnCateCancel;
        private System.Windows.Forms.DataGridView dgvViewCateMaster;
        private SparrowRMSControl.SparrowControl.SparrowComboBox cmbDept;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn CateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeptCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dept;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
    }
}