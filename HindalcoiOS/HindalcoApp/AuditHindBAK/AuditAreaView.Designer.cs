
namespace Hind.AuditMgmt
{
    partial class AuditAreaView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbxAddVendor = new System.Windows.Forms.GroupBox();
            this.btnAdd = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnCancel = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.lblAreaCode = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblName = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtAreaCode = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtVendorName = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.gbxViewVendor = new System.Windows.Forms.GroupBox();
            this.dgvViewAreaMaster = new System.Windows.Forms.DataGridView();
            this.lblDept = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtDept = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.AreaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AreaCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxAddVendor.SuspendLayout();
            this.gbxViewVendor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewAreaMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxAddVendor
            // 
            this.gbxAddVendor.Controls.Add(this.txtDept);
            this.gbxAddVendor.Controls.Add(this.lblDept);
            this.gbxAddVendor.Controls.Add(this.btnAdd);
            this.gbxAddVendor.Controls.Add(this.btnCancel);
            this.gbxAddVendor.Controls.Add(this.lblAreaCode);
            this.gbxAddVendor.Controls.Add(this.lblName);
            this.gbxAddVendor.Controls.Add(this.txtAreaCode);
            this.gbxAddVendor.Controls.Add(this.txtVendorName);
            this.gbxAddVendor.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxAddVendor.Location = new System.Drawing.Point(12, 1);
            this.gbxAddVendor.Name = "gbxAddVendor";
            this.gbxAddVendor.Size = new System.Drawing.Size(727, 129);
            this.gbxAddVendor.TabIndex = 0;
            this.gbxAddVendor.TabStop = false;
            this.gbxAddVendor.Text = "Add ";
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
            this.btnAdd.Location = new System.Drawing.Point(501, 74);
            this.btnAdd.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnAdd.Size = new System.Drawing.Size(86, 30);
            this.btnAdd.TabIndex = 51;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextColor = System.Drawing.Color.White;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAddVendor_Click);
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
            this.btnCancel.Location = new System.Drawing.Point(620, 76);
            this.btnCancel.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnCancel.Size = new System.Drawing.Size(84, 30);
            this.btnCancel.TabIndex = 50;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextColor = System.Drawing.Color.White;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnVendorCancel_Click);
            // 
            // lblAreaCode
            // 
            this.lblAreaCode.AutoSize = true;
            this.lblAreaCode.Depth = 0;
            this.lblAreaCode.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblAreaCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAreaCode.Location = new System.Drawing.Point(32, 82);
            this.lblAreaCode.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblAreaCode.Name = "lblAreaCode";
            this.lblAreaCode.Size = new System.Drawing.Size(41, 18);
            this.lblAreaCode.TabIndex = 45;
            this.lblAreaCode.Text = "Code";
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
            this.lblName.Size = new System.Drawing.Size(52, 18);
            this.lblName.TabIndex = 44;
            this.lblName.Text = " Name";
            // 
            // txtAreaCode
            // 
            this.txtAreaCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtAreaCode.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtAreaCode.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtAreaCode.BorderRadius = 0;
            this.txtAreaCode.BorderSize = 1;
            this.txtAreaCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAreaCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAreaCode.Location = new System.Drawing.Point(109, 71);
            this.txtAreaCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtAreaCode.Multiline = true;
            this.txtAreaCode.Name = "txtAreaCode";
            this.txtAreaCode.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtAreaCode.PasswordChar = false;
            this.txtAreaCode.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtAreaCode.PlaceholderText = "";
            this.txtAreaCode.Size = new System.Drawing.Size(210, 35);
            this.txtAreaCode.TabIndex = 39;
            this.txtAreaCode.UnderlinedStyle = false;
            // 
            // txtVendorName
            // 
            this.txtVendorName.BackColor = System.Drawing.SystemColors.Window;
            this.txtVendorName.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtVendorName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtVendorName.BorderRadius = 0;
            this.txtVendorName.BorderSize = 1;
            this.txtVendorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendorName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtVendorName.Location = new System.Drawing.Point(109, 25);
            this.txtVendorName.Margin = new System.Windows.Forms.Padding(4);
            this.txtVendorName.Multiline = true;
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtVendorName.PasswordChar = false;
            this.txtVendorName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtVendorName.PlaceholderText = "";
            this.txtVendorName.Size = new System.Drawing.Size(210, 35);
            this.txtVendorName.TabIndex = 38;
            this.txtVendorName.UnderlinedStyle = false;
            // 
            // gbxViewVendor
            // 
            this.gbxViewVendor.Controls.Add(this.dgvViewAreaMaster);
            this.gbxViewVendor.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxViewVendor.Location = new System.Drawing.Point(12, 144);
            this.gbxViewVendor.Name = "gbxViewVendor";
            this.gbxViewVendor.Size = new System.Drawing.Size(727, 187);
            this.gbxViewVendor.TabIndex = 50;
            this.gbxViewVendor.TabStop = false;
            this.gbxViewVendor.Text = "View All";
            // 
            // dgvViewAreaMaster
            // 
            this.dgvViewAreaMaster.AllowUserToAddRows = false;
            this.dgvViewAreaMaster.AllowUserToDeleteRows = false;
            this.dgvViewAreaMaster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvViewAreaMaster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvViewAreaMaster.ColumnHeadersHeight = 35;
            this.dgvViewAreaMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvViewAreaMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AreaName,
            this.AreaCode,
            this.CreatedDate,
            this.Dept});
            this.dgvViewAreaMaster.EnableHeadersVisualStyles = false;
            this.dgvViewAreaMaster.Location = new System.Drawing.Point(16, 24);
            this.dgvViewAreaMaster.Name = "dgvViewAreaMaster";
            this.dgvViewAreaMaster.ReadOnly = true;
            this.dgvViewAreaMaster.RowHeadersWidth = 51;
            this.dgvViewAreaMaster.RowTemplate.Height = 24;
            this.dgvViewAreaMaster.Size = new System.Drawing.Size(699, 144);
            this.dgvViewAreaMaster.TabIndex = 0;
            this.dgvViewAreaMaster.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViewDeptMaster_CellDoubleClick);
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.Depth = 0;
            this.lblDept.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblDept.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDept.Location = new System.Drawing.Point(397, 32);
            this.lblDept.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(86, 18);
            this.lblDept.TabIndex = 52;
            this.lblDept.Text = "Department";
            // 
            // txtDept
            // 
            this.txtDept.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtDept.BorderSize = 0;
            this.txtDept.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDept.FormattingEnabled = true;
            this.txtDept.IconColor = System.Drawing.Color.DodgerBlue;
            this.txtDept.ListBackColor = System.Drawing.Color.Red;
            this.txtDept.ListTextColor = System.Drawing.Color.White;
            this.txtDept.Location = new System.Drawing.Point(497, 29);
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(207, 31);
            this.txtDept.TabIndex = 53;
            // 
            // AreaName
            // 
            this.AreaName.HeaderText = "Area Name";
            this.AreaName.MinimumWidth = 6;
            this.AreaName.Name = "AreaName";
            this.AreaName.ReadOnly = true;
            // 
            // AreaCode
            // 
            this.AreaCode.HeaderText = "Area Code";
            this.AreaCode.MinimumWidth = 6;
            this.AreaCode.Name = "AreaCode";
            this.AreaCode.ReadOnly = true;
            // 
            // CreatedDate
            // 
            this.CreatedDate.HeaderText = "Created Date";
            this.CreatedDate.MinimumWidth = 6;
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.ReadOnly = true;
            // 
            // Dept
            // 
            this.Dept.HeaderText = "Department";
            this.Dept.MinimumWidth = 6;
            this.Dept.Name = "Dept";
            this.Dept.ReadOnly = true;
            // 
            // AreaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 343);
            this.Controls.Add(this.gbxViewVendor);
            this.Controls.Add(this.gbxAddVendor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AreaView";
            this.Text = "Area";
            this.Load += new System.EventHandler(this.VendorMasterView_Load);
            this.gbxAddVendor.ResumeLayout(false);
            this.gbxAddVendor.PerformLayout();
            this.gbxViewVendor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewAreaMaster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxAddVendor;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblAreaCode;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblName;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtAreaCode;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtVendorName;
        private System.Windows.Forms.GroupBox gbxViewVendor;
        private SparrowRMSControl.SparrowControl.SparrowButton btnAdd;
        private SparrowRMSControl.SparrowControl.SparrowButton btnCancel;
        private System.Windows.Forms.DataGridView dgvViewAreaMaster;
        private SparrowRMSControl.SparrowControl.SparrowComboBox txtDept;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn AreaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AreaCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dept;
    }
}