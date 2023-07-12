
namespace HindalcoiOS.Machine_Edit_Form
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
            this.btnSave = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.DGVOutput = new System.Windows.Forms.DataGridView();
            this.grpoutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // grpoutput
            // 
            this.grpoutput.Controls.Add(this.btnSave);
            this.grpoutput.Controls.Add(this.DGVOutput);
            this.grpoutput.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpoutput.Location = new System.Drawing.Point(12, -1);
            this.grpoutput.Name = "grpoutput";
            this.grpoutput.Size = new System.Drawing.Size(764, 274);
            this.grpoutput.TabIndex = 0;
            this.grpoutput.TabStop = false;
            this.grpoutput.Text = "Output Connection";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.BorderRadius = 14;
            this.btnSave.BorderSize = 0;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(638, 235);
            this.btnSave.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSave.Name = "btnSave";
            this.btnSave.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnSave.Size = new System.Drawing.Size(112, 30);
            this.btnSave.TabIndex = 56;
            this.btnSave.Text = "Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // DGVOutput
            // 
            this.DGVOutput.AllowUserToAddRows = false;
            this.DGVOutput.AllowUserToDeleteRows = false;
            this.DGVOutput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVOutput.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVOutput.ColumnHeadersHeight = 35;
            this.DGVOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVOutput.Location = new System.Drawing.Point(10, 26);
            this.DGVOutput.Name = "DGVOutput";
            this.DGVOutput.ReadOnly = true;
            this.DGVOutput.RowHeadersWidth = 51;
            this.DGVOutput.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGVOutput.RowTemplate.Height = 24;
            this.DGVOutput.Size = new System.Drawing.Size(740, 203);
            this.DGVOutput.TabIndex = 0;
            // 
            // OutPut_Property
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 284);
            this.Controls.Add(this.grpoutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OutPut_Property";
            this.Text = "Output Property";
            this.Load += new System.EventHandler(this.OutPut_PropertyUpd_Load);
            this.grpoutput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVOutput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpoutput;
        private System.Windows.Forms.DataGridView DGVOutput;
        private SparrowRMSControl.SparrowControl.SparrowButton btnSave;
    }
}