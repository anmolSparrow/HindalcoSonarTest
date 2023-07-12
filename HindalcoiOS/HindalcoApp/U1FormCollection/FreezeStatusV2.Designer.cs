
namespace HindalcoiOS.U1FormCollection
{
    partial class FreezeStatus
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
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.DgvStatus = new System.Windows.Forms.DataGridView();
            this.grpStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.DgvStatus);
            this.grpStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStatus.Location = new System.Drawing.Point(12, 11);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(1057, 277);
            this.grpStatus.TabIndex = 0;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "Maintenance Calender Status";
            // 
            // DgvStatus
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvStatus.ColumnHeadersHeight = 35;
            this.DgvStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvStatus.EnableHeadersVisualStyles = false;
            this.DgvStatus.Location = new System.Drawing.Point(15, 31);
            this.DgvStatus.Name = "DgvStatus";
            this.DgvStatus.RowHeadersWidth = 62;
            this.DgvStatus.RowTemplate.Height = 28;
            this.DgvStatus.Size = new System.Drawing.Size(1022, 226);
            this.DgvStatus.TabIndex = 0;
            // 
            // FreezeStatus
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 301);
            this.Controls.Add(this.grpStatus);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FreezeStatus";
            this.Text = "Freeze Status";
            this.Load += new System.EventHandler(this.FreezeStatus_Load);
            this.grpStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.DataGridView DgvStatus;
    }
}