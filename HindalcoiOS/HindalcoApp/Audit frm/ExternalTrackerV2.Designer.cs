
namespace HindalcoiOS.Audit_frm
{
    partial class ExternalTracker
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bntSubmit = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.grpstatus = new System.Windows.Forms.GroupBox();
            this.DgvStatus = new SparrowRMSControl.SparrowControl.SparrowGrid();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpstatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // bntSubmit
            // 
            this.bntSubmit.BackColor = System.Drawing.Color.DodgerBlue;
            this.bntSubmit.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.bntSubmit.BorderColor = System.Drawing.Color.DodgerBlue;
            this.bntSubmit.BorderRadius = 14;
            this.bntSubmit.BorderSize = 0;
            this.bntSubmit.FlatAppearance.BorderSize = 0;
            this.bntSubmit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.bntSubmit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.bntSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntSubmit.ForeColor = System.Drawing.Color.White;
            this.bntSubmit.Location = new System.Drawing.Point(935, 45);
            this.bntSubmit.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.bntSubmit.Name = "bntSubmit";
            this.bntSubmit.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.bntSubmit.Size = new System.Drawing.Size(124, 30);
            this.bntSubmit.TabIndex = 0;
            this.bntSubmit.Text = "Status";
            this.bntSubmit.TextColor = System.Drawing.Color.White;
            this.bntSubmit.UseVisualStyleBackColor = false;
            this.bntSubmit.Click += new System.EventHandler(this.bntSubmit_Click);
            // 
            // grpstatus
            // 
            this.grpstatus.Controls.Add(this.DgvStatus);
            this.grpstatus.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpstatus.Location = new System.Drawing.Point(13, 99);
            this.grpstatus.Name = "grpstatus";
            this.grpstatus.Size = new System.Drawing.Size(1087, 238);
            this.grpstatus.TabIndex = 1;
            this.grpstatus.TabStop = false;
            this.grpstatus.Text = "Audit Status";
            // 
            // DgvStatus
            // 
            this.DgvStatus.AllowUserToAddRows = false;
            this.DgvStatus.AllowUserToDeleteRows = false;
            this.DgvStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvStatus.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DgvStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvStatus.ColumnNameToSum = null;
            this.DgvStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Category,
            this.Count});
            this.DgvStatus.ColumnSum = 0D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvStatus.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvStatus.EnableColumnSumming = false;
            this.DgvStatus.EnableHeadersVisualStyles = false;
            this.DgvStatus.Location = new System.Drawing.Point(7, 23);
            this.DgvStatus.MultiSelect = false;
            this.DgvStatus.Name = "DgvStatus";
            this.DgvStatus.ReadOnly = true;
            this.DgvStatus.RowHeadersVisible = false;
            this.DgvStatus.RowHeadersWidth = 51;
            this.DgvStatus.RowTemplate.Height = 24;
            this.DgvStatus.Size = new System.Drawing.Size(1074, 209);
            this.DgvStatus.TabIndex = 0;
            // 
            // Category
            // 
            this.Category.MinimumWidth = 6;
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            this.Category.Width = 125;
            // 
            // Count
            // 
            this.Count.MinimumWidth = 6;
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            this.Count.Width = 125;
            // 
            // ExternalTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 349);
            this.Controls.Add(this.grpstatus);
            this.Controls.Add(this.bntSubmit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExternalTracker";
            this.Text = "External Tracker";
            this.Load += new System.EventHandler(this.ExternalTracker_Load);
            this.grpstatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SparrowRMSControl.SparrowControl.SparrowButton bntSubmit;
        private System.Windows.Forms.GroupBox grpstatus;
        private SparrowRMSControl.SparrowControl.SparrowGrid DgvStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
    }
}