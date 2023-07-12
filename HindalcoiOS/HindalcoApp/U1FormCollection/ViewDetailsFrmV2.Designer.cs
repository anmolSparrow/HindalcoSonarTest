
namespace HindalcoiOS.U1FormCollection
{
    partial class ViewDetailsFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbxMaintMachineRawDetails = new System.Windows.Forms.GroupBox();
            this.DgvView = new SparrowRMSControl.SparrowControl.SparrowGrid();
            this.gbxMaintMachineRawDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvView)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxMaintMachineRawDetails
            // 
            this.gbxMaintMachineRawDetails.Controls.Add(this.DgvView);
            this.gbxMaintMachineRawDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxMaintMachineRawDetails.Location = new System.Drawing.Point(13, 13);
            this.gbxMaintMachineRawDetails.Name = "gbxMaintMachineRawDetails";
            this.gbxMaintMachineRawDetails.Size = new System.Drawing.Size(910, 268);
            this.gbxMaintMachineRawDetails.TabIndex = 0;
            this.gbxMaintMachineRawDetails.TabStop = false;
            this.gbxMaintMachineRawDetails.Text = "Maintenace Machine Raw Details";
            // 
            // DgvView
            // 
            this.DgvView.AllowUserToAddRows = false;
            this.DgvView.AllowUserToDeleteRows = false;
            this.DgvView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvView.ColumnNameToSum = null;
            this.DgvView.ColumnSum = 0D;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvView.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvView.EnableColumnSumming = false;
            this.DgvView.EnableHeadersVisualStyles = false;
            this.DgvView.Location = new System.Drawing.Point(7, 23);
            this.DgvView.MultiSelect = false;
            this.DgvView.Name = "DgvView";
            this.DgvView.RowHeadersVisible = false;
            this.DgvView.RowHeadersWidth = 51;
            this.DgvView.RowTemplate.Height = 24;
            this.DgvView.Size = new System.Drawing.Size(889, 232);
            this.DgvView.TabIndex = 0;
            // 
            // ViewDetailsFrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 293);
            this.Controls.Add(this.gbxMaintMachineRawDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewDetailsFrm";
            this.Text = "View Details Form";
            this.Load += new System.EventHandler(this.ViewDetailsFrm_Load);
            this.gbxMaintMachineRawDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxMaintMachineRawDetails;
        private SparrowRMSControl.SparrowControl.SparrowGrid DgvView;
    }
}