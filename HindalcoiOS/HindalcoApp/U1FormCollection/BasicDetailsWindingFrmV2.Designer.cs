
namespace HindalcoiOS.U1FormCollection
{
    partial class BasicDetailsWindingFrm
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
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.DgvBasic = new System.Windows.Forms.DataGridView();
            this.grpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvBasic)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.DgvBasic);
            this.grpDetails.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDetails.Location = new System.Drawing.Point(13, 13);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(733, 256);
            this.grpDetails.TabIndex = 0;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Basic Details(Machine Logs)";
            // 
            // DgvBasic
            // 
            this.DgvBasic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvBasic.Location = new System.Drawing.Point(7, 23);
            this.DgvBasic.Name = "DgvBasic";
            this.DgvBasic.RowHeadersWidth = 51;
            this.DgvBasic.RowTemplate.Height = 24;
            this.DgvBasic.Size = new System.Drawing.Size(720, 227);
            this.DgvBasic.TabIndex = 0;
            this.DgvBasic.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvBasic_CellClick);
            // 
            // BasicDetailsWindingFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 281);
            this.Controls.Add(this.grpDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "BasicDetailsWindingFrm";
            this.Text = "Basic Details Winding Form";
            this.Load += new System.EventHandler(this.BasicDetailsWindingFrm_Load);
            this.grpDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvBasic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.DataGridView DgvBasic;
    }
}