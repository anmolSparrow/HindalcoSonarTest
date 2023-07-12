
namespace HindalcoiOS.PermitToWork
{
    partial class HazardMonitor
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
            this.pnlHazard = new System.Windows.Forms.Panel();
            this.btncancel = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnAdd = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.txthazardesc = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblHazard = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.pnlHazard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHazard
            // 
            this.pnlHazard.Controls.Add(this.btncancel);
            this.pnlHazard.Controls.Add(this.btnAdd);
            this.pnlHazard.Controls.Add(this.txthazardesc);
            this.pnlHazard.Controls.Add(this.lblHazard);
            this.pnlHazard.Location = new System.Drawing.Point(11, 13);
            this.pnlHazard.Name = "pnlHazard";
            this.pnlHazard.Size = new System.Drawing.Size(421, 144);
            this.pnlHazard.TabIndex = 0;
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btncancel.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btncancel.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btncancel.BorderRadius = 14;
            this.btncancel.BorderSize = 0;
            this.btncancel.FlatAppearance.BorderSize = 0;
            this.btncancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btncancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancel.ForeColor = System.Drawing.Color.White;
            this.btncancel.Location = new System.Drawing.Point(271, 95);
            this.btncancel.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btncancel.Name = "btncancel";
            this.btncancel.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btncancel.Size = new System.Drawing.Size(106, 29);
            this.btncancel.TabIndex = 3;
            this.btncancel.Text = "Cancel";
            this.btncancel.TextColor = System.Drawing.Color.White;
            this.btncancel.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAdd.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnAdd.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnAdd.BorderRadius = 14;
            this.btnAdd.BorderSize = 0;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(149, 95);
            this.btnAdd.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnAdd.Size = new System.Drawing.Size(106, 29);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextColor = System.Drawing.Color.White;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txthazardesc
            // 
            this.txthazardesc.BackColor = System.Drawing.SystemColors.Window;
            this.txthazardesc.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txthazardesc.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txthazardesc.BorderRadius = 0;
            this.txthazardesc.BorderSize = 1;
            this.txthazardesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthazardesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txthazardesc.Location = new System.Drawing.Point(158, 27);
            this.txthazardesc.Margin = new System.Windows.Forms.Padding(4);
            this.txthazardesc.Multiline = true;
            this.txthazardesc.Name = "txthazardesc";
            this.txthazardesc.Padding = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.txthazardesc.PasswordChar = false;
            this.txthazardesc.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txthazardesc.PlaceholderText = "Enter Text";
            this.txthazardesc.Size = new System.Drawing.Size(219, 32);
            this.txthazardesc.TabIndex = 1;
            this.txthazardesc.UnderlinedStyle = false;
            // 
            // lblHazard
            // 
            this.lblHazard.AutoSize = true;
            this.lblHazard.Depth = 0;
            this.lblHazard.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblHazard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblHazard.Location = new System.Drawing.Point(18, 35);
            this.lblHazard.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblHazard.Name = "lblHazard";
            this.lblHazard.Size = new System.Drawing.Size(62, 21);
            this.lblHazard.TabIndex = 0;
            this.lblHazard.Text = "Hazard";
            // 
            // HazardMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 169);
            this.Controls.Add(this.pnlHazard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HazardMonitor";
            this.Text = "Hazard Monitor";
            this.Load += new System.EventHandler(this.HazardMonitor_Load);
            this.pnlHazard.ResumeLayout(false);
            this.pnlHazard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHazard;
        private SparrowRMSControl.SparrowControl.SparrowButton btncancel;
        private SparrowRMSControl.SparrowControl.SparrowButton btnAdd;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txthazardesc;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblHazard;
    }
}