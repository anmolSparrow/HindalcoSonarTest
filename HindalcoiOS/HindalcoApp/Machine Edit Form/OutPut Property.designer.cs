namespace RMPCLApp.Machine_Edit_Form
{
    partial class OutPut_Property
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
            this.grpoutput = new System.Windows.Forms.GroupBox();
            this.DGVOutput = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpoutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // grpoutput
            // 
            this.grpoutput.Controls.Add(this.DGVOutput);
            this.grpoutput.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpoutput.Location = new System.Drawing.Point(0, 0);
            this.grpoutput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpoutput.Name = "grpoutput";
            this.grpoutput.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpoutput.Size = new System.Drawing.Size(496, 189);
            this.grpoutput.TabIndex = 0;
            this.grpoutput.TabStop = false;
            this.grpoutput.Text = "Connector OutPut Connection";
            // 
            // DGVOutput
            // 
            this.DGVOutput.AllowUserToAddRows = false;
            this.DGVOutput.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.DGVOutput.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVOutput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DGVOutput.ColumnHeadersHeight = 29;
            this.DGVOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVOutput.Location = new System.Drawing.Point(3, 18);
            this.DGVOutput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DGVOutput.Name = "DGVOutput";
            this.DGVOutput.ReadOnly = true;
            this.DGVOutput.RowHeadersWidth = 51;
            this.DGVOutput.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGVOutput.RowTemplate.Height = 24;
            this.DGVOutput.Size = new System.Drawing.Size(490, 169);
            this.DGVOutput.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(147, 193);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(185, 26);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save Data";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // OutPut_Property
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 229);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpoutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OutPut_Property";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OutPut_Property";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.OutPut_Property_Load);
            this.grpoutput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVOutput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpoutput;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView DGVOutput;
    }
}