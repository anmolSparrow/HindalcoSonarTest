
namespace HindalcoiOS.U1FormCollection
{
    partial class TrainingDashBoardFrm
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
            this.grpstatus = new System.Windows.Forms.GroupBox();
            this.DgvStatus = new SparrowRMSControl.SparrowControl.SparrowGrid();
            this.grpstatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // grpstatus
            // 
            this.grpstatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpstatus.Controls.Add(this.DgvStatus);
            this.grpstatus.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpstatus.Location = new System.Drawing.Point(13, 13);
            this.grpstatus.Name = "grpstatus";
            this.grpstatus.Size = new System.Drawing.Size(1037, 301);
            this.grpstatus.TabIndex = 0;
            this.grpstatus.TabStop = false;
            this.grpstatus.Text = "Training Status Report";
            // 
            // DgvStatus
            // 
            this.DgvStatus.AllowUserToAddRows = false;
            this.DgvStatus.AllowUserToDeleteRows = false;
            this.DgvStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvStatus.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvStatus.ColumnNameToSum = null;
            this.DgvStatus.ColumnSum = 0D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvStatus.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvStatus.EnableColumnSumming = false;
            this.DgvStatus.EnableHeadersVisualStyles = false;
            this.DgvStatus.Location = new System.Drawing.Point(7, 23);
            this.DgvStatus.MultiSelect = false;
            this.DgvStatus.Name = "DgvStatus";
            this.DgvStatus.RowHeadersVisible = false;
            this.DgvStatus.RowHeadersWidth = 51;
            this.DgvStatus.RowTemplate.Height = 24;
            this.DgvStatus.Size = new System.Drawing.Size(1024, 272);
            this.DgvStatus.TabIndex = 0;
            // 
            // TrainingDashBoardFrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 326);
            this.Controls.Add(this.grpstatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "TrainingDashBoardFrm";
            this.Text = "Training DashBoard Form";
            this.Load += new System.EventHandler(this.TrainingDashBoardFrm_Load);
            this.grpstatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpstatus;
        private SparrowRMSControl.SparrowControl.SparrowGrid DgvStatus;
    }
}