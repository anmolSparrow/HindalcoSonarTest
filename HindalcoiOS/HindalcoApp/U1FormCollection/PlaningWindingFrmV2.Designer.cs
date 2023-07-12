
namespace HindalcoiOS.U1FormCollection
{
    partial class PlaningWindingFrm
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
            this.grpPlaing = new System.Windows.Forms.GroupBox();
            this.DgvPlaningWinding = new System.Windows.Forms.DataGridView();
            this.grpPlaing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPlaningWinding)).BeginInit();
            this.SuspendLayout();
            // 
            // grpPlaing
            // 
            this.grpPlaing.Controls.Add(this.DgvPlaningWinding);
            this.grpPlaing.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPlaing.Location = new System.Drawing.Point(13, 13);
            this.grpPlaing.Name = "grpPlaing";
            this.grpPlaing.Size = new System.Drawing.Size(835, 261);
            this.grpPlaing.TabIndex = 0;
            this.grpPlaing.TabStop = false;
            this.grpPlaing.Text = "Planning Info";
            // 
            // DgvPlaningWinding
            // 
            this.DgvPlaningWinding.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPlaningWinding.Location = new System.Drawing.Point(7, 23);
            this.DgvPlaningWinding.Name = "DgvPlaningWinding";
            this.DgvPlaningWinding.RowHeadersWidth = 51;
            this.DgvPlaningWinding.RowTemplate.Height = 24;
            this.DgvPlaningWinding.Size = new System.Drawing.Size(822, 232);
            this.DgvPlaningWinding.TabIndex = 0;
            this.DgvPlaningWinding.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPlaning_CellClick);
            this.DgvPlaningWinding.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPlaning_CellContentClick);
            this.DgvPlaningWinding.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPlaning_CellEnter);
            this.DgvPlaningWinding.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DgvPlaningWinding_ColumnWidthChanged);
            this.DgvPlaningWinding.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DgvPlaningWinding_Scroll);
            // 
            // PlaningWindingFrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 287);
            this.Controls.Add(this.grpPlaing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlaningWindingFrm";
            this.Text = "Planing Winding Form";
            this.grpPlaing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPlaningWinding)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPlaing;
        private System.Windows.Forms.DataGridView DgvPlaningWinding;
    }
}