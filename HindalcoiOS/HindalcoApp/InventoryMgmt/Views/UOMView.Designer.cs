
namespace HindalcoiOS.InventoryMgmt
{
    partial class UOMView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUOMDelete = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnUnitCancel = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnAdd = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.txtUnitCode = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtUnitName = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblUnitCode = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblUnitName = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.dgvUnitsView = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnitsView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUOMDelete);
            this.groupBox1.Controls.Add(this.btnUnitCancel);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtUnitCode);
            this.groupBox1.Controls.Add(this.txtUnitName);
            this.groupBox1.Controls.Add(this.lblUnitCode);
            this.groupBox1.Controls.Add(this.lblUnitName);
            this.groupBox1.Controls.Add(this.dgvUnitsView);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 331);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // btnUOMDelete
            // 
            this.btnUOMDelete.BackColor = System.Drawing.Color.Red;
            this.btnUOMDelete.BackgroundColor = System.Drawing.Color.Red;
            this.btnUOMDelete.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnUOMDelete.BorderRadius = 14;
            this.btnUOMDelete.BorderSize = 0;
            this.btnUOMDelete.FlatAppearance.BorderSize = 0;
            this.btnUOMDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnUOMDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnUOMDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUOMDelete.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUOMDelete.ForeColor = System.Drawing.Color.White;
            this.btnUOMDelete.Location = new System.Drawing.Point(141, 117);
            this.btnUOMDelete.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnUOMDelete.Name = "btnUOMDelete";
            this.btnUOMDelete.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnUOMDelete.Size = new System.Drawing.Size(67, 30);
            this.btnUOMDelete.TabIndex = 16;
            this.btnUOMDelete.Text = "Delete";
            this.btnUOMDelete.TextColor = System.Drawing.Color.White;
            this.btnUOMDelete.UseVisualStyleBackColor = false;
            this.btnUOMDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUnitCancel
            // 
            this.btnUnitCancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUnitCancel.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnUnitCancel.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnUnitCancel.BorderRadius = 14;
            this.btnUnitCancel.BorderSize = 0;
            this.btnUnitCancel.FlatAppearance.BorderSize = 0;
            this.btnUnitCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnUnitCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnUnitCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnitCancel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnitCancel.ForeColor = System.Drawing.Color.White;
            this.btnUnitCancel.Location = new System.Drawing.Point(301, 117);
            this.btnUnitCancel.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnUnitCancel.Name = "btnUnitCancel";
            this.btnUnitCancel.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnUnitCancel.Size = new System.Drawing.Size(80, 30);
            this.btnUnitCancel.TabIndex = 15;
            this.btnUnitCancel.Text = "Cancel";
            this.btnUnitCancel.TextColor = System.Drawing.Color.White;
            this.btnUnitCancel.UseVisualStyleBackColor = false;
            this.btnUnitCancel.Click += new System.EventHandler(this.btnUnitCancel_Click);
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
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(214, 117);
            this.btnAdd.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnAdd.Size = new System.Drawing.Size(77, 30);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextColor = System.Drawing.Color.White;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtUnitCode
            // 
            this.txtUnitCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtUnitCode.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtUnitCode.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtUnitCode.BorderRadius = 0;
            this.txtUnitCode.BorderSize = 1;
            this.txtUnitCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnitCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUnitCode.Location = new System.Drawing.Point(131, 71);
            this.txtUnitCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtUnitCode.Multiline = false;
            this.txtUnitCode.Name = "txtUnitCode";
            this.txtUnitCode.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtUnitCode.PasswordChar = false;
            this.txtUnitCode.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtUnitCode.PlaceholderText = "";
            this.txtUnitCode.Size = new System.Drawing.Size(250, 35);
            this.txtUnitCode.TabIndex = 13;
            this.txtUnitCode.UnderlinedStyle = false;
            // 
            // txtUnitName
            // 
            this.txtUnitName.BackColor = System.Drawing.SystemColors.Window;
            this.txtUnitName.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtUnitName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtUnitName.BorderRadius = 0;
            this.txtUnitName.BorderSize = 1;
            this.txtUnitName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnitName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUnitName.Location = new System.Drawing.Point(131, 25);
            this.txtUnitName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUnitName.Multiline = false;
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtUnitName.PasswordChar = false;
            this.txtUnitName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtUnitName.PlaceholderText = "";
            this.txtUnitName.Size = new System.Drawing.Size(250, 35);
            this.txtUnitName.TabIndex = 12;
            this.txtUnitName.UnderlinedStyle = false;
            // 
            // lblUnitCode
            // 
            this.lblUnitCode.AutoSize = true;
            this.lblUnitCode.Depth = 0;
            this.lblUnitCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitCode.Location = new System.Drawing.Point(28, 86);
            this.lblUnitCode.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblUnitCode.Name = "lblUnitCode";
            this.lblUnitCode.Size = new System.Drawing.Size(75, 20);
            this.lblUnitCode.TabIndex = 11;
            this.lblUnitCode.Text = "Unit Code";
            // 
            // lblUnitName
            // 
            this.lblUnitName.AutoSize = true;
            this.lblUnitName.Depth = 0;
            this.lblUnitName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitName.Location = new System.Drawing.Point(28, 40);
            this.lblUnitName.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblUnitName.Name = "lblUnitName";
            this.lblUnitName.Size = new System.Drawing.Size(80, 20);
            this.lblUnitName.TabIndex = 10;
            this.lblUnitName.Text = "Unit Name";
            // 
            // dgvUnitsView
            // 
            this.dgvUnitsView.AllowUserToAddRows = false;
            this.dgvUnitsView.AllowUserToDeleteRows = false;
            this.dgvUnitsView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUnitsView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUnitsView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUnitsView.ColumnHeadersHeight = 35;
            this.dgvUnitsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUnitsView.EnableHeadersVisualStyles = false;
            this.dgvUnitsView.Location = new System.Drawing.Point(19, 162);
            this.dgvUnitsView.Name = "dgvUnitsView";
            this.dgvUnitsView.ReadOnly = true;
            this.dgvUnitsView.RowHeadersWidth = 51;
            this.dgvUnitsView.RowTemplate.Height = 24;
            this.dgvUnitsView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUnitsView.Size = new System.Drawing.Size(413, 150);
            this.dgvUnitsView.TabIndex = 9;
            this.dgvUnitsView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUnitsView_CellDoubleClick);
            // 
            // UOMView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 347);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UOMView";
            this.Text = "Unit of Measurement";
            this.Load += new System.EventHandler(this.UOMView_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnitsView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblUnitCode;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblUnitName;
        private System.Windows.Forms.DataGridView dgvUnitsView;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtUnitCode;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtUnitName;
        private SparrowRMSControl.SparrowControl.SparrowButton btnUnitCancel;
        private SparrowRMSControl.SparrowControl.SparrowButton btnAdd;
        private SparrowRMSControl.SparrowControl.SparrowButton btnUOMDelete;
    }
}