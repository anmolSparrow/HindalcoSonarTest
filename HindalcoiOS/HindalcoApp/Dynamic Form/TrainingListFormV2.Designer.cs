
namespace HindalcoiOS.Dynamic_Form
{
    partial class TrainingListForm
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
            this.gbxTrnDetail = new System.Windows.Forms.GroupBox();
            this.btnAdd = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.cmbemployee = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.txtduration = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txttype = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txttile = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtcode = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblEmp = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblTrainingDuration = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblTraintitle = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lbltype = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lbltraingCode = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.gbxAllTrnDetail = new System.Windows.Forms.GroupBox();
            this.DgvEmployee = new System.Windows.Forms.DataGridView();
            this.Tcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ttype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ischk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpdate = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.gbxTrnDetail.SuspendLayout();
            this.gbxAllTrnDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxTrnDetail
            // 
            this.gbxTrnDetail.Controls.Add(this.btnAdd);
            this.gbxTrnDetail.Controls.Add(this.cmbemployee);
            this.gbxTrnDetail.Controls.Add(this.txtduration);
            this.gbxTrnDetail.Controls.Add(this.txttype);
            this.gbxTrnDetail.Controls.Add(this.txttile);
            this.gbxTrnDetail.Controls.Add(this.txtcode);
            this.gbxTrnDetail.Controls.Add(this.lblEmp);
            this.gbxTrnDetail.Controls.Add(this.lblTrainingDuration);
            this.gbxTrnDetail.Controls.Add(this.lblTraintitle);
            this.gbxTrnDetail.Controls.Add(this.lbltype);
            this.gbxTrnDetail.Controls.Add(this.lbltraingCode);
            this.gbxTrnDetail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxTrnDetail.Location = new System.Drawing.Point(12, 8);
            this.gbxTrnDetail.Name = "gbxTrnDetail";
            this.gbxTrnDetail.Size = new System.Drawing.Size(867, 171);
            this.gbxTrnDetail.TabIndex = 0;
            this.gbxTrnDetail.TabStop = false;
            this.gbxTrnDetail.Text = "List Of Training ";
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
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(733, 125);
            this.btnAdd.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnAdd.Size = new System.Drawing.Size(124, 32);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "&Add Details";
            this.btnAdd.TextColor = System.Drawing.Color.White;
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // cmbemployee
            // 
            this.cmbemployee.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbemployee.BorderSize = 0;
            this.cmbemployee.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbemployee.FormattingEnabled = true;
            this.cmbemployee.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbemployee.ListBackColor = System.Drawing.Color.Red;
            this.cmbemployee.ListTextColor = System.Drawing.Color.White;
            this.cmbemployee.Location = new System.Drawing.Point(607, 84);
            this.cmbemployee.Name = "cmbemployee";
            this.cmbemployee.Size = new System.Drawing.Size(250, 30);
            this.cmbemployee.TabIndex = 9;
            // 
            // txtduration
            // 
            this.txtduration.BackColor = System.Drawing.SystemColors.Window;
            this.txtduration.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtduration.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtduration.BorderRadius = 0;
            this.txtduration.BorderSize = 1;
            this.txtduration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtduration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtduration.Location = new System.Drawing.Point(607, 32);
            this.txtduration.Margin = new System.Windows.Forms.Padding(4);
            this.txtduration.Multiline = false;
            this.txtduration.Name = "txtduration";
            this.txtduration.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtduration.PasswordChar = false;
            this.txtduration.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtduration.PlaceholderText = "";
            this.txtduration.Size = new System.Drawing.Size(250, 35);
            this.txtduration.TabIndex = 8;
            this.txtduration.UnderlinedStyle = false;
            // 
            // txttype
            // 
            this.txttype.BackColor = System.Drawing.SystemColors.Window;
            this.txttype.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txttype.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txttype.BorderRadius = 0;
            this.txttype.BorderSize = 1;
            this.txttype.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttype.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txttype.Location = new System.Drawing.Point(148, 118);
            this.txttype.Margin = new System.Windows.Forms.Padding(4);
            this.txttype.Multiline = false;
            this.txttype.Name = "txttype";
            this.txttype.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txttype.PasswordChar = false;
            this.txttype.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txttype.PlaceholderText = "";
            this.txttype.Size = new System.Drawing.Size(250, 33);
            this.txttype.TabIndex = 7;
            this.txttype.UnderlinedStyle = false;
            // 
            // txttile
            // 
            this.txttile.BackColor = System.Drawing.SystemColors.Window;
            this.txttile.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txttile.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txttile.BorderRadius = 0;
            this.txttile.BorderSize = 1;
            this.txttile.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txttile.Location = new System.Drawing.Point(148, 75);
            this.txttile.Margin = new System.Windows.Forms.Padding(4);
            this.txttile.Multiline = false;
            this.txttile.Name = "txttile";
            this.txttile.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txttile.PasswordChar = false;
            this.txttile.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txttile.PlaceholderText = "";
            this.txttile.Size = new System.Drawing.Size(250, 33);
            this.txttile.TabIndex = 6;
            this.txttile.UnderlinedStyle = false;
            // 
            // txtcode
            // 
            this.txtcode.BackColor = System.Drawing.SystemColors.Window;
            this.txtcode.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtcode.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtcode.BorderRadius = 0;
            this.txtcode.BorderSize = 1;
            this.txtcode.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtcode.Location = new System.Drawing.Point(148, 32);
            this.txtcode.Margin = new System.Windows.Forms.Padding(4);
            this.txtcode.Multiline = false;
            this.txtcode.Name = "txtcode";
            this.txtcode.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtcode.PasswordChar = false;
            this.txtcode.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtcode.PlaceholderText = "";
            this.txtcode.Size = new System.Drawing.Size(250, 33);
            this.txtcode.TabIndex = 5;
            this.txtcode.UnderlinedStyle = false;
            // 
            // lblEmp
            // 
            this.lblEmp.AutoSize = true;
            this.lblEmp.Depth = 0;
            this.lblEmp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmp.Location = new System.Drawing.Point(485, 85);
            this.lblEmp.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblEmp.Name = "lblEmp";
            this.lblEmp.Size = new System.Drawing.Size(115, 18);
            this.lblEmp.TabIndex = 4;
            this.lblEmp.Text = "Employee Name";
            // 
            // lblTrainingDuration
            // 
            this.lblTrainingDuration.AutoSize = true;
            this.lblTrainingDuration.Depth = 0;
            this.lblTrainingDuration.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrainingDuration.Location = new System.Drawing.Point(481, 37);
            this.lblTrainingDuration.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblTrainingDuration.Name = "lblTrainingDuration";
            this.lblTrainingDuration.Size = new System.Drawing.Size(118, 18);
            this.lblTrainingDuration.TabIndex = 3;
            this.lblTrainingDuration.Text = "Training Duration";
            // 
            // lblTraintitle
            // 
            this.lblTraintitle.AutoSize = true;
            this.lblTraintitle.Depth = 0;
            this.lblTraintitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTraintitle.Location = new System.Drawing.Point(33, 84);
            this.lblTraintitle.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblTraintitle.Name = "lblTraintitle";
            this.lblTraintitle.Size = new System.Drawing.Size(93, 18);
            this.lblTraintitle.TabIndex = 2;
            this.lblTraintitle.Text = "Training Titile";
            // 
            // lbltype
            // 
            this.lbltype.AutoSize = true;
            this.lbltype.Depth = 0;
            this.lbltype.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltype.Location = new System.Drawing.Point(33, 129);
            this.lbltype.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lbltype.Name = "lbltype";
            this.lbltype.Size = new System.Drawing.Size(98, 18);
            this.lbltype.TabIndex = 1;
            this.lbltype.Text = "Training Type";
            // 
            // lbltraingCode
            // 
            this.lbltraingCode.AutoSize = true;
            this.lbltraingCode.Depth = 0;
            this.lbltraingCode.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltraingCode.Location = new System.Drawing.Point(33, 41);
            this.lbltraingCode.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lbltraingCode.Name = "lbltraingCode";
            this.lbltraingCode.Size = new System.Drawing.Size(97, 18);
            this.lbltraingCode.TabIndex = 0;
            this.lbltraingCode.Text = "Training Code";
            // 
            // gbxAllTrnDetail
            // 
            this.gbxAllTrnDetail.Controls.Add(this.DgvEmployee);
            this.gbxAllTrnDetail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxAllTrnDetail.Location = new System.Drawing.Point(12, 190);
            this.gbxAllTrnDetail.Name = "gbxAllTrnDetail";
            this.gbxAllTrnDetail.Size = new System.Drawing.Size(867, 176);
            this.gbxAllTrnDetail.TabIndex = 0;
            this.gbxAllTrnDetail.TabStop = false;
            this.gbxAllTrnDetail.Text = "Training Details";
            // 
            // DgvEmployee
            // 
            this.DgvEmployee.AllowUserToAddRows = false;
            this.DgvEmployee.AllowUserToDeleteRows = false;
            this.DgvEmployee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvEmployee.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvEmployee.ColumnHeadersHeight = 35;
            this.DgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tcode,
            this.TTitle,
            this.Ttype,
            this.Ischk});
            this.DgvEmployee.EnableHeadersVisualStyles = false;
            this.DgvEmployee.Location = new System.Drawing.Point(10, 22);
            this.DgvEmployee.Name = "DgvEmployee";
            this.DgvEmployee.ReadOnly = true;
            this.DgvEmployee.RowHeadersWidth = 51;
            this.DgvEmployee.RowTemplate.Height = 24;
            this.DgvEmployee.Size = new System.Drawing.Size(847, 136);
            this.DgvEmployee.TabIndex = 0;
            // 
            // Tcode
            // 
            this.Tcode.HeaderText = "TrainingCode";
            this.Tcode.MinimumWidth = 6;
            this.Tcode.Name = "Tcode";
            this.Tcode.ReadOnly = true;
            // 
            // TTitle
            // 
            this.TTitle.HeaderText = "Training Title";
            this.TTitle.MinimumWidth = 6;
            this.TTitle.Name = "TTitle";
            this.TTitle.ReadOnly = true;
            // 
            // Ttype
            // 
            this.Ttype.HeaderText = "Training Type";
            this.Ttype.MinimumWidth = 6;
            this.Ttype.Name = "Ttype";
            this.Ttype.ReadOnly = true;
            // 
            // Ischk
            // 
            this.Ischk.HeaderText = "Select";
            this.Ischk.MinimumWidth = 6;
            this.Ischk.Name = "Ischk";
            this.Ischk.ReadOnly = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdate.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdate.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdate.BorderRadius = 14;
            this.btnUpdate.BorderSize = 0;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(745, 374);
            this.btnUpdate.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnUpdate.Size = new System.Drawing.Size(124, 32);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.TextColor = System.Drawing.Color.White;
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // TrainingListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 416);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.gbxAllTrnDetail);
            this.Controls.Add(this.gbxTrnDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TrainingListForm";
            this.Text = "Training List Form";
            this.gbxTrnDetail.ResumeLayout(false);
            this.gbxTrnDetail.PerformLayout();
            this.gbxAllTrnDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvEmployee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxTrnDetail;
        private System.Windows.Forms.GroupBox gbxAllTrnDetail;
        private SparrowRMSControl.SparrowControl.SparrowButton btnAdd;
        private SparrowRMSControl.SparrowControl.SparrowComboBox cmbemployee;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtduration;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txttype;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txttile;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtcode;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblEmp;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblTrainingDuration;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblTraintitle;
        private SparrowRMSControl.SparrowControl.SparrowLabel lbltype;
        private SparrowRMSControl.SparrowControl.SparrowLabel lbltraingCode;
        private SparrowRMSControl.SparrowControl.SparrowButton btnUpdate;
        private System.Windows.Forms.DataGridView DgvEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ttype;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ischk;
    }
}