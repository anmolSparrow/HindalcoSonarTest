
namespace HindalcoiOS.Multifloor
{
    partial class PlantLayout
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
            this.lblfloor = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btncreate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblfloor
            // 
            this.lblfloor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblfloor.AutoSize = true;
            this.lblfloor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfloor.Location = new System.Drawing.Point(7, 31);
            this.lblfloor.Name = "lblfloor";
            this.lblfloor.Size = new System.Drawing.Size(101, 20);
            this.lblfloor.TabIndex = 0;
            this.lblfloor.Text = "Floor Number";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(129, 30);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.ReadOnly = true;
            this.numericUpDown1.Size = new System.Drawing.Size(86, 27);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // btncreate
            // 
            this.btncreate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btncreate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncreate.Location = new System.Drawing.Point(259, 318);
            this.btncreate.Name = "btncreate";
            this.btncreate.Size = new System.Drawing.Size(206, 38);
            this.btncreate.TabIndex = 2;
            this.btncreate.Text = "Create";
            this.btncreate.UseVisualStyleBackColor = true;
            this.btncreate.Visible = false;
            this.btncreate.Click += new System.EventHandler(this.Button_Click);
            // 
            // PlantLayout
            // 
            this.AcceptButton = this.btncreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(477, 368);
            this.Controls.Add(this.btncreate);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.lblfloor);
            this.Name = "PlantLayout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlantLayout";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlantLayout_FormClosing);
            this.Load += new System.EventHandler(this.PlantLayout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.NumericUpDown numericUpDown1;
        public System.Windows.Forms.Button btncreate;
        public System.Windows.Forms.Label lblfloor;
    }
}