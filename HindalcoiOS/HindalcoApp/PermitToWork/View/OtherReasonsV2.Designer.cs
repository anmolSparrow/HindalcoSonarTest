
namespace HindalcoiOS.PermitToWork
{
    partial class OtherReasons
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
            this.components = new System.ComponentModel.Container();
            this.txtResson = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtpermitName = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblResson = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblpermitName = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddReason = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnCancel = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtResson
            // 
            this.txtResson.BackColor = System.Drawing.SystemColors.Window;
            this.txtResson.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtResson.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtResson.BorderRadius = 0;
            this.txtResson.BorderSize = 1;
            this.txtResson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResson.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtResson.Location = new System.Drawing.Point(186, 76);
            this.txtResson.Margin = new System.Windows.Forms.Padding(4);
            this.txtResson.Multiline = true;
            this.txtResson.Name = "txtResson";
            this.txtResson.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtResson.PasswordChar = false;
            this.txtResson.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtResson.PlaceholderText = "Enter Text";
            this.txtResson.Size = new System.Drawing.Size(248, 30);
            this.txtResson.TabIndex = 12;
            this.txtResson.UnderlinedStyle = false;
            // 
            // txtpermitName
            // 
            this.txtpermitName.BackColor = System.Drawing.SystemColors.Window;
            this.txtpermitName.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtpermitName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtpermitName.BorderRadius = 0;
            this.txtpermitName.BorderSize = 1;
            this.txtpermitName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpermitName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtpermitName.Location = new System.Drawing.Point(186, 34);
            this.txtpermitName.Margin = new System.Windows.Forms.Padding(4);
            this.txtpermitName.Multiline = true;
            this.txtpermitName.Name = "txtpermitName";
            this.txtpermitName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtpermitName.PasswordChar = false;
            this.txtpermitName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtpermitName.PlaceholderText = "Enter Text";
            this.txtpermitName.Size = new System.Drawing.Size(248, 30);
            this.txtpermitName.TabIndex = 11;
            this.txtpermitName.UnderlinedStyle = false;
            // 
            // lblResson
            // 
            this.lblResson.AutoSize = true;
            this.lblResson.Depth = 0;
            this.lblResson.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblResson.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblResson.Location = new System.Drawing.Point(20, 83);
            this.lblResson.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblResson.Name = "lblResson";
            this.lblResson.Size = new System.Drawing.Size(110, 21);
            this.lblResson.TabIndex = 10;
            this.lblResson.Text = "Enter Reason";
            // 
            // lblpermitName
            // 
            this.lblpermitName.AutoSize = true;
            this.lblpermitName.Depth = 0;
            this.lblpermitName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblpermitName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblpermitName.Location = new System.Drawing.Point(20, 34);
            this.lblpermitName.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblpermitName.Name = "lblpermitName";
            this.lblpermitName.Size = new System.Drawing.Size(106, 21);
            this.lblpermitName.TabIndex = 9;
            this.lblpermitName.Text = "Permit Name";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblpermitName);
            this.panel1.Controls.Add(this.btnAddReason);
            this.panel1.Controls.Add(this.txtResson);
            this.panel1.Controls.Add(this.lblResson);
            this.panel1.Controls.Add(this.txtpermitName);
            this.panel1.Location = new System.Drawing.Point(12, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 171);
            this.panel1.TabIndex = 13;
            // 
            // btnAddReason
            // 
            this.btnAddReason.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddReason.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnAddReason.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnAddReason.BorderRadius = 14;
            this.btnAddReason.BorderSize = 0;
            this.btnAddReason.FlatAppearance.BorderSize = 0;
            this.btnAddReason.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAddReason.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAddReason.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddReason.ForeColor = System.Drawing.Color.White;
            this.btnAddReason.Location = new System.Drawing.Point(186, 116);
            this.btnAddReason.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAddReason.Name = "btnAddReason";
            this.btnAddReason.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnAddReason.Size = new System.Drawing.Size(120, 30);
            this.btnAddReason.TabIndex = 14;
            this.btnAddReason.Text = "Update Status";
            this.btnAddReason.TextColor = System.Drawing.Color.White;
            this.btnAddReason.UseVisualStyleBackColor = false;
            this.btnAddReason.Click += new System.EventHandler(this.btnAddReason_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.BorderRadius = 14;
            this.btnCancel.BorderSize = 0;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(360, 116);
            this.btnCancel.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnCancel.Size = new System.Drawing.Size(92, 30);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextColor = System.Drawing.Color.White;
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // OtherReasons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 184);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OtherReasons";
            this.Text = "Other Reasons";
            this.Load += new System.EventHandler(this.OtherReasonsUpd_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SparrowRMSControl.SparrowControl.SparrowTextBox txtResson;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtpermitName;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblResson;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblpermitName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private SparrowRMSControl.SparrowControl.SparrowButton btnAddReason;
        private SparrowRMSControl.SparrowControl.SparrowButton btnCancel;
    }
}