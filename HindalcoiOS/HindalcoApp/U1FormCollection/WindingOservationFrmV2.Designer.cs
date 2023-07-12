
namespace HindalcoiOS.U1FormCollection
{
    partial class WindingOservationFrm
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
            this.grpobj = new System.Windows.Forms.GroupBox();
            this.DgvObser = new SparrowRMSControl.SparrowControl.SparrowGrid();
            this.grpobj.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvObser)).BeginInit();
            this.SuspendLayout();
            // 
            // grpobj
            // 
            this.grpobj.Controls.Add(this.DgvObser);
            this.grpobj.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpobj.Location = new System.Drawing.Point(13, 13);
            this.grpobj.Name = "grpobj";
            this.grpobj.Size = new System.Drawing.Size(718, 204);
            this.grpobj.TabIndex = 0;
            this.grpobj.TabStop = false;
            this.grpobj.Text = "Observation Details";
            // 
            // DgvObser
            // 
            this.DgvObser.AllowUserToAddRows = false;
            this.DgvObser.AllowUserToDeleteRows = false;
            this.DgvObser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvObser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvObser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvObser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvObser.ColumnNameToSum = null;
            this.DgvObser.ColumnSum = 0D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvObser.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvObser.EnableColumnSumming = false;
            this.DgvObser.EnableHeadersVisualStyles = false;
            this.DgvObser.Location = new System.Drawing.Point(7, 23);
            this.DgvObser.MultiSelect = false;
            this.DgvObser.Name = "DgvObser";
            this.DgvObser.RowHeadersVisible = false;
            this.DgvObser.RowHeadersWidth = 51;
            this.DgvObser.RowTemplate.Height = 24;
            this.DgvObser.Size = new System.Drawing.Size(705, 175);
            this.DgvObser.TabIndex = 0;
            this.DgvObser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvObser_CellClick);
            this.DgvObser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvObser_CellContentClick);
            // 
            // WindingOservationFrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 246);
            this.Controls.Add(this.grpobj);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WindingOservationFrm";
            this.Text = "Winding Observation Form";
            this.grpobj.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvObser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpobj;
        private SparrowRMSControl.SparrowControl.SparrowGrid DgvObser;
    }
}