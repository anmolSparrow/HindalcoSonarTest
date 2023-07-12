
namespace HindalcoiOS.Reporting
{
    partial class IncidentClosure
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
            this.bunifuLabel13 = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtRemarks = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.btnSave = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnReset = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuLabel13
            // 
            this.bunifuLabel13.AutoSize = true;
            this.bunifuLabel13.Depth = 0;
            this.bunifuLabel13.Font = new System.Drawing.Font("Tahoma", 10F);
            this.bunifuLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bunifuLabel13.Location = new System.Drawing.Point(14, 77);
            this.bunifuLabel13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bunifuLabel13.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.bunifuLabel13.Name = "bunifuLabel13";
            this.bunifuLabel13.Padding = new System.Windows.Forms.Padding(0, 21, 0, 0);
            this.bunifuLabel13.Size = new System.Drawing.Size(81, 42);
            this.bunifuLabel13.TabIndex = 0;
            this.bunifuLabel13.Text = "Remarks:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.SystemColors.Window;
            this.txtRemarks.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtRemarks.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtRemarks.BorderRadius = 1;
            this.txtRemarks.BorderSize = 1;
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtRemarks.Location = new System.Drawing.Point(112, 19);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(4);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.txtRemarks.PasswordChar = false;
            this.txtRemarks.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtRemarks.PlaceholderText = "";
            this.txtRemarks.Size = new System.Drawing.Size(511, 145);
            this.txtRemarks.TabIndex = 1;
            this.txtRemarks.UnderlinedStyle = false;
            this.txtRemarks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemarks_KeyPress);
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
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(348, 180);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSave.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSave.Name = "btnSave";
            this.btnSave.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnSave.Size = new System.Drawing.Size(121, 29);
            this.btnSave.TabIndex = 2;
            this.btnSave.Tag = "Close";
            this.btnSave.Text = "Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnReset.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnReset.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnReset.BorderRadius = 14;
            this.btnReset.BorderSize = 0;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(488, 180);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnReset.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnReset.Name = "btnReset";
            this.btnReset.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnReset.Size = new System.Drawing.Size(121, 29);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.TextColor = System.Drawing.Color.White;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.bunifuLabel13);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(11, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(627, 227);
            this.panel1.TabIndex = 4;
            // 
            // IncidentClosure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 241);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IncidentClosure";
            this.Text = "Incident Closure";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EmployeeType_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SparrowRMSControl.SparrowControl.SparrowLabel bunifuLabel13;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtRemarks;
        private SparrowRMSControl.SparrowControl.SparrowButton btnSave;
        private SparrowRMSControl.SparrowControl.SparrowButton btnReset;
        private System.Windows.Forms.Panel panel1;
    }
}