
namespace HindalcoiOS.InventoryMgmt
{
    partial class CategoryMasterView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbxCategory = new System.Windows.Forms.GroupBox();
            this.dgvCatMaster = new System.Windows.Forms.DataGridView();
            this.cmbCatParent = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.btnAdd = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnCatParent = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.lblCatgCode = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblCatParent = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblCatgName = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtCatCode = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtCatName = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.gbxCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxCategory
            // 
            this.gbxCategory.Controls.Add(this.dgvCatMaster);
            this.gbxCategory.Controls.Add(this.cmbCatParent);
            this.gbxCategory.Controls.Add(this.btnAdd);
            this.gbxCategory.Controls.Add(this.btnCatParent);
            this.gbxCategory.Controls.Add(this.lblCatgCode);
            this.gbxCategory.Controls.Add(this.lblCatParent);
            this.gbxCategory.Controls.Add(this.lblCatgName);
            this.gbxCategory.Controls.Add(this.txtCatCode);
            this.gbxCategory.Controls.Add(this.txtCatName);
            this.gbxCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxCategory.Location = new System.Drawing.Point(13, 3);
            this.gbxCategory.Name = "gbxCategory";
            this.gbxCategory.Size = new System.Drawing.Size(844, 309);
            this.gbxCategory.TabIndex = 0;
            this.gbxCategory.TabStop = false;
            this.gbxCategory.Text = "Details";
            // 
            // dgvCatMaster
            // 
            this.dgvCatMaster.AllowUserToAddRows = false;
            this.dgvCatMaster.AllowUserToDeleteRows = false;
            this.dgvCatMaster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCatMaster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCatMaster.ColumnHeadersHeight = 35;
            this.dgvCatMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCatMaster.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCatMaster.EnableHeadersVisualStyles = false;
            this.dgvCatMaster.Location = new System.Drawing.Point(17, 123);
            this.dgvCatMaster.Name = "dgvCatMaster";
            this.dgvCatMaster.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCatMaster.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCatMaster.RowHeadersWidth = 51;
            this.dgvCatMaster.RowTemplate.Height = 24;
            this.dgvCatMaster.Size = new System.Drawing.Size(812, 169);
            this.dgvCatMaster.TabIndex = 13;
            // 
            // cmbCatParent
            // 
            this.cmbCatParent.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbCatParent.BorderSize = 1;
            this.cmbCatParent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCatParent.ForeColor = System.Drawing.Color.DimGray;
            this.cmbCatParent.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbCatParent.ItemHeight = 22;
            this.cmbCatParent.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.cmbCatParent.ListTextColor = System.Drawing.Color.White;
            this.cmbCatParent.Location = new System.Drawing.Point(506, 26);
            this.cmbCatParent.MinimumSize = new System.Drawing.Size(200, 0);
            this.cmbCatParent.Name = "cmbCatParent";
            this.cmbCatParent.Size = new System.Drawing.Size(205, 30);
            this.cmbCatParent.TabIndex = 12;
            this.cmbCatParent.SelectedIndexChanged += new System.EventHandler(this.cmbCatParent_SelectedIndexChanged);
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
            this.btnAdd.Location = new System.Drawing.Point(717, 77);
            this.btnAdd.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnAdd.Size = new System.Drawing.Size(112, 30);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextColor = System.Drawing.Color.White;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCatParent
            // 
            this.btnCatParent.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCatParent.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnCatParent.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnCatParent.BorderRadius = 14;
            this.btnCatParent.BorderSize = 0;
            this.btnCatParent.FlatAppearance.BorderSize = 0;
            this.btnCatParent.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnCatParent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnCatParent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatParent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCatParent.ForeColor = System.Drawing.Color.White;
            this.btnCatParent.Location = new System.Drawing.Point(717, 25);
            this.btnCatParent.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnCatParent.Name = "btnCatParent";
            this.btnCatParent.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnCatParent.Size = new System.Drawing.Size(112, 30);
            this.btnCatParent.TabIndex = 10;
            this.btnCatParent.Text = "Add Category";
            this.btnCatParent.TextColor = System.Drawing.Color.White;
            this.btnCatParent.UseVisualStyleBackColor = false;
            this.btnCatParent.Click += new System.EventHandler(this.btnCatParent_Click);
            // 
            // lblCatgCode
            // 
            this.lblCatgCode.AutoSize = true;
            this.lblCatgCode.Depth = 0;
            this.lblCatgCode.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblCatgCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCatgCode.Location = new System.Drawing.Point(24, 75);
            this.lblCatgCode.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblCatgCode.Name = "lblCatgCode";
            this.lblCatgCode.Size = new System.Drawing.Size(150, 21);
            this.lblCatgCode.TabIndex = 9;
            this.lblCatgCode.Text = "Sub Category Code";
            // 
            // lblCatParent
            // 
            this.lblCatParent.AutoSize = true;
            this.lblCatParent.Depth = 0;
            this.lblCatParent.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblCatParent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCatParent.Location = new System.Drawing.Point(425, 31);
            this.lblCatParent.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblCatParent.Name = "lblCatParent";
            this.lblCatParent.Size = new System.Drawing.Size(76, 21);
            this.lblCatParent.TabIndex = 8;
            this.lblCatParent.Text = "Category";
            // 
            // lblCatgName
            // 
            this.lblCatgName.AutoSize = true;
            this.lblCatgName.Depth = 0;
            this.lblCatgName.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCatgName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCatgName.Location = new System.Drawing.Point(26, 32);
            this.lblCatgName.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblCatgName.Name = "lblCatgName";
            this.lblCatgName.Size = new System.Drawing.Size(156, 21);
            this.lblCatgName.TabIndex = 7;
            this.lblCatgName.Text = "Sub Category Name";
            // 
            // txtCatCode
            // 
            this.txtCatCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtCatCode.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtCatCode.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtCatCode.BorderRadius = 0;
            this.txtCatCode.BorderSize = 1;
            this.txtCatCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCatCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCatCode.Location = new System.Drawing.Point(189, 70);
            this.txtCatCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtCatCode.Multiline = true;
            this.txtCatCode.Name = "txtCatCode";
            this.txtCatCode.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtCatCode.PasswordChar = false;
            this.txtCatCode.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtCatCode.PlaceholderText = "Enter Text";
            this.txtCatCode.Size = new System.Drawing.Size(210, 34);
            this.txtCatCode.TabIndex = 3;
            this.txtCatCode.UnderlinedStyle = false;
            // 
            // txtCatName
            // 
            this.txtCatName.BackColor = System.Drawing.SystemColors.Window;
            this.txtCatName.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtCatName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtCatName.BorderRadius = 0;
            this.txtCatName.BorderSize = 1;
            this.txtCatName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCatName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCatName.Location = new System.Drawing.Point(189, 23);
            this.txtCatName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCatName.Multiline = true;
            this.txtCatName.Name = "txtCatName";
            this.txtCatName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtCatName.PasswordChar = false;
            this.txtCatName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtCatName.PlaceholderText = "Enter Text";
            this.txtCatName.Size = new System.Drawing.Size(210, 34);
            this.txtCatName.TabIndex = 2;
            this.txtCatName.UnderlinedStyle = false;
            // 
            // CategoryMasterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 325);
            this.Controls.Add(this.gbxCategory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CategoryMasterView";
            this.Text = "Sub Category ";
            this.Load += new System.EventHandler(this.CategoryMasterView_Load);
            this.gbxCategory.ResumeLayout(false);
            this.gbxCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatMaster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxCategory;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtCatCode;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtCatName;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblCatgCode;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblCatParent;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblCatgName;
        private SparrowRMSControl.SparrowControl.SparrowComboBox cmbCatParent;
        private SparrowRMSControl.SparrowControl.SparrowButton btnAdd;
        private SparrowRMSControl.SparrowControl.SparrowButton btnCatParent;
        private System.Windows.Forms.DataGridView dgvCatMaster;
    }
}