namespace HindalcoiOS.U1FormCollection
{
    partial class PopUpAction
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
            this.btndatePiker = new SparrowRMSControl.SparrowControl.SparrowDatePicker();
            this.btnOk = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.SuspendLayout();
            // 
            // btndatePiker
            // 
            this.btndatePiker.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btndatePiker.BorderSize = 0;
            this.btndatePiker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.btndatePiker.Location = new System.Drawing.Point(12, 12);
            this.btndatePiker.MinimumSize = new System.Drawing.Size(4, 35);
            this.btndatePiker.Name = "btndatePiker";
            this.btndatePiker.Size = new System.Drawing.Size(230, 35);
            this.btndatePiker.SkinColor = System.Drawing.Color.MediumSlateBlue;
            this.btndatePiker.TabIndex = 2;
            this.btndatePiker.TextColor = System.Drawing.Color.White;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnOk.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnOk.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnOk.BorderRadius = 14;
            this.btnOk.BorderSize = 0;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(12, 65);
            this.btnOk.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnOk.Name = "btnOk";
            this.btnOk.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnOk.Size = new System.Drawing.Size(230, 32);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.TextColor = System.Drawing.Color.White;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // PopUpAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 134);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btndatePiker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopUpAction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PopUpAction";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.PopUpAction_Load);
            this.ResumeLayout(false);

        }

        #endregion
        public SparrowRMSControl.SparrowControl.SparrowDatePicker btndatePiker;
        private SparrowRMSControl.SparrowControl.SparrowButton btnOk;
    }
}