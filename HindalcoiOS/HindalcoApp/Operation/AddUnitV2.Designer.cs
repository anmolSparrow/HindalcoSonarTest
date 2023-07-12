
namespace HindalcoiOS.Operation
{
    partial class AddUnit
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReset = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnSave = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.lblErr = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblUnitname = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtUnitName = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.lblErr);
            this.panel1.Controls.Add(this.lblUnitname);
            this.panel1.Controls.Add(this.txtUnitName);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(437, 135);
            this.panel1.TabIndex = 0;
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
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(248, 74);
            this.btnReset.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnReset.Name = "btnReset";
            this.btnReset.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnReset.Size = new System.Drawing.Size(97, 30);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.TextColor = System.Drawing.Color.White;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
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
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(124, 74);
            this.btnSave.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSave.Name = "btnSave";
            this.btnSave.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnSave.Size = new System.Drawing.Size(94, 30);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblErr
            // 
            this.lblErr.AutoSize = true;
            this.lblErr.Depth = 0;
            this.lblErr.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblErr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblErr.Location = new System.Drawing.Point(353, 29);
            this.lblErr.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(19, 21);
            this.lblErr.TabIndex = 2;
            this.lblErr.Text = "*";
            // 
            // lblUnitname
            // 
            this.lblUnitname.AutoSize = true;
            this.lblUnitname.Depth = 0;
            this.lblUnitname.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblUnitname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUnitname.Location = new System.Drawing.Point(12, 31);
            this.lblUnitname.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblUnitname.Name = "lblUnitname";
            this.lblUnitname.Size = new System.Drawing.Size(53, 21);
            this.lblUnitname.TabIndex = 1;
            this.lblUnitname.Text = "Name";
            // 
            // txtUnitName
            // 
            this.txtUnitName.BackColor = System.Drawing.SystemColors.Window;
            this.txtUnitName.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtUnitName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtUnitName.BorderRadius = 0;
            this.txtUnitName.BorderSize = 1;
            this.txtUnitName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnitName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUnitName.Location = new System.Drawing.Point(124, 26);
            this.txtUnitName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUnitName.Multiline = true;
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtUnitName.PasswordChar = false;
            this.txtUnitName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtUnitName.PlaceholderText = "Enter Text";
            this.txtUnitName.Size = new System.Drawing.Size(221, 30);
            this.txtUnitName.TabIndex = 0;
            this.txtUnitName.UnderlinedStyle = false;
            this.txtUnitName._TextChanged += new System.EventHandler(this.txtUnitName_TextChanged);
            // 
            // AddUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 160);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUnit";
            this.Text = "Unit Master";
            this.Click += new System.EventHandler(this.AddUnit_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private SparrowRMSControl.SparrowControl.SparrowButton btnReset;
        private SparrowRMSControl.SparrowControl.SparrowButton btnSave;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblErr;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblUnitname;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtUnitName;
    }
}