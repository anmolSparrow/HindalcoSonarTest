
namespace HindalcoiOS.Configuration
{
    partial class OperationUnitView
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
            this.bunifuGroupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvOperationUnitView = new System.Windows.Forms.DataGridView();
            this.btnOunitSave = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.txtOUnitCode = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtOUnitName = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblOUnitCode = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblOUnitName = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.bunifuGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperationUnitView)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuGroupBox1
            // 
            this.bunifuGroupBox1.Controls.Add(this.dgvOperationUnitView);
            this.bunifuGroupBox1.Controls.Add(this.btnOunitSave);
            this.bunifuGroupBox1.Controls.Add(this.txtOUnitCode);
            this.bunifuGroupBox1.Controls.Add(this.txtOUnitName);
            this.bunifuGroupBox1.Controls.Add(this.lblOUnitCode);
            this.bunifuGroupBox1.Controls.Add(this.lblOUnitName);
            this.bunifuGroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuGroupBox1.Location = new System.Drawing.Point(11, 8);
            this.bunifuGroupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bunifuGroupBox1.Name = "bunifuGroupBox1";
            this.bunifuGroupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bunifuGroupBox1.Size = new System.Drawing.Size(635, 265);
            this.bunifuGroupBox1.TabIndex = 0;
            this.bunifuGroupBox1.TabStop = false;
            this.bunifuGroupBox1.Text = "Details";
            // 
            // dgvOperationUnitView
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOperationUnitView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOperationUnitView.ColumnHeadersHeight = 35;
            this.dgvOperationUnitView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOperationUnitView.EnableHeadersVisualStyles = false;
            this.dgvOperationUnitView.Location = new System.Drawing.Point(9, 134);
            this.dgvOperationUnitView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvOperationUnitView.Name = "dgvOperationUnitView";
            this.dgvOperationUnitView.RowHeadersWidth = 62;
            this.dgvOperationUnitView.RowTemplate.Height = 28;
            this.dgvOperationUnitView.Size = new System.Drawing.Size(614, 119);
            this.dgvOperationUnitView.TabIndex = 27;
            // 
            // btnOunitSave
            // 
            this.btnOunitSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnOunitSave.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnOunitSave.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnOunitSave.BorderRadius = 14;
            this.btnOunitSave.BorderSize = 0;
            this.btnOunitSave.FlatAppearance.BorderSize = 0;
            this.btnOunitSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnOunitSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnOunitSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOunitSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOunitSave.ForeColor = System.Drawing.Color.White;
            this.btnOunitSave.Location = new System.Drawing.Point(511, 87);
            this.btnOunitSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnOunitSave.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnOunitSave.Name = "btnOunitSave";
            this.btnOunitSave.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnOunitSave.Size = new System.Drawing.Size(98, 32);
            this.btnOunitSave.TabIndex = 26;
            this.btnOunitSave.Text = "Add";
            this.btnOunitSave.TextColor = System.Drawing.Color.White;
            this.btnOunitSave.UseVisualStyleBackColor = false;
            this.btnOunitSave.Click += new System.EventHandler(this.btnOunitSave_Click);
            // 
            // txtOUnitCode
            // 
            this.txtOUnitCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtOUnitCode.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtOUnitCode.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtOUnitCode.BorderRadius = 0;
            this.txtOUnitCode.BorderSize = 1;
            this.txtOUnitCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOUnitCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtOUnitCode.Location = new System.Drawing.Point(166, 79);
            this.txtOUnitCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtOUnitCode.Multiline = false;
            this.txtOUnitCode.Name = "txtOUnitCode";
            this.txtOUnitCode.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.txtOUnitCode.PasswordChar = false;
            this.txtOUnitCode.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtOUnitCode.PlaceholderText = "Unit Code";
            this.txtOUnitCode.Size = new System.Drawing.Size(243, 33);
            this.txtOUnitCode.TabIndex = 25;
            this.txtOUnitCode.UnderlinedStyle = false;
            // 
            // txtOUnitName
            // 
            this.txtOUnitName.BackColor = System.Drawing.SystemColors.Window;
            this.txtOUnitName.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtOUnitName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtOUnitName.BorderRadius = 0;
            this.txtOUnitName.BorderSize = 1;
            this.txtOUnitName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOUnitName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtOUnitName.Location = new System.Drawing.Point(166, 33);
            this.txtOUnitName.Margin = new System.Windows.Forms.Padding(4);
            this.txtOUnitName.Multiline = false;
            this.txtOUnitName.Name = "txtOUnitName";
            this.txtOUnitName.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.txtOUnitName.PasswordChar = false;
            this.txtOUnitName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtOUnitName.PlaceholderText = "OperationUnit name";
            this.txtOUnitName.Size = new System.Drawing.Size(243, 33);
            this.txtOUnitName.TabIndex = 24;
            this.txtOUnitName.UnderlinedStyle = false;
            // 
            // lblOUnitCode
            // 
            this.lblOUnitCode.AutoSize = true;
            this.lblOUnitCode.Depth = 0;
            this.lblOUnitCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOUnitCode.Location = new System.Drawing.Point(50, 68);
            this.lblOUnitCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOUnitCode.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblOUnitCode.Name = "lblOUnitCode";
            this.lblOUnitCode.Padding = new System.Windows.Forms.Padding(19, 20, 0, 0);
            this.lblOUnitCode.Size = new System.Drawing.Size(63, 40);
            this.lblOUnitCode.TabIndex = 1;
            this.lblOUnitCode.Text = "Code";
            // 
            // lblOUnitName
            // 
            this.lblOUnitName.AutoSize = true;
            this.lblOUnitName.Depth = 0;
            this.lblOUnitName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOUnitName.Location = new System.Drawing.Point(50, 20);
            this.lblOUnitName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOUnitName.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblOUnitName.Name = "lblOUnitName";
            this.lblOUnitName.Padding = new System.Windows.Forms.Padding(19, 20, 0, 0);
            this.lblOUnitName.Size = new System.Drawing.Size(68, 40);
            this.lblOUnitName.TabIndex = 0;
            this.lblOUnitName.Text = "Name";
            // 
            // OperationUnitView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 285);
            this.Controls.Add(this.bunifuGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OperationUnitView";
            this.Text = "OperationUnit";
            this.Load += new System.EventHandler(this.OperationUnitView_Load);
            this.bunifuGroupBox1.ResumeLayout(false);
            this.bunifuGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperationUnitView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox bunifuGroupBox1;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblOUnitCode;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblOUnitName;
        private SparrowRMSControl.SparrowControl.SparrowButton btnOunitSave;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtOUnitCode;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtOUnitName;
        private System.Windows.Forms.DataGridView dgvOperationUnitView;
    }
}