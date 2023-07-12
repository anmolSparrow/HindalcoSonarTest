
namespace HindalcoiOS.Maintenance
{
    partial class CommentsFrm
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
            this.txtcomments = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblComments = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.gbxComments = new System.Windows.Forms.GroupBox();
            this.btnCommSave = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.gbxComments.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtcomments
            // 
            this.txtcomments.AutoSize = true;
            this.txtcomments.BackColor = System.Drawing.SystemColors.Window;
            this.txtcomments.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtcomments.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtcomments.BorderRadius = 0;
            this.txtcomments.BorderSize = 1;
            this.txtcomments.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcomments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtcomments.Location = new System.Drawing.Point(158, 27);
            this.txtcomments.Margin = new System.Windows.Forms.Padding(4);
            this.txtcomments.Multiline = true;
            this.txtcomments.Name = "txtcomments";
            this.txtcomments.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtcomments.PasswordChar = false;
            this.txtcomments.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtcomments.PlaceholderText = "";
            this.txtcomments.Size = new System.Drawing.Size(366, 90);
            this.txtcomments.TabIndex = 3;
            this.txtcomments.UnderlinedStyle = false;
            this.txtcomments._TextChanged += new System.EventHandler(this.txtcomments__TextChanged);
            // 
            // lblComments
            // 
            this.lblComments.AutoSize = true;
            this.lblComments.Depth = 0;
            this.lblComments.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblComments.Location = new System.Drawing.Point(12, 65);
            this.lblComments.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblComments.Name = "lblComments";
            this.lblComments.Size = new System.Drawing.Size(93, 23);
            this.lblComments.TabIndex = 5;
            this.lblComments.Text = "Comments";
            this.lblComments.Click += new System.EventHandler(this.lblComments_Click);
            // 
            // gbxComments
            // 
            this.gbxComments.AutoSize = true;
            this.gbxComments.Controls.Add(this.btnCommSave);
            this.gbxComments.Controls.Add(this.txtcomments);
            this.gbxComments.Controls.Add(this.lblComments);
            this.gbxComments.Location = new System.Drawing.Point(12, 3);
            this.gbxComments.Name = "gbxComments";
            this.gbxComments.Size = new System.Drawing.Size(536, 194);
            this.gbxComments.TabIndex = 6;
            this.gbxComments.TabStop = false;
            // 
            // btnCommSave
            // 
            this.btnCommSave.AutoSize = true;
            this.btnCommSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCommSave.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnCommSave.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnCommSave.BorderRadius = 14;
            this.btnCommSave.BorderSize = 0;
            this.btnCommSave.FlatAppearance.BorderSize = 0;
            this.btnCommSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnCommSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnCommSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCommSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCommSave.ForeColor = System.Drawing.Color.White;
            this.btnCommSave.Location = new System.Drawing.Point(392, 134);
            this.btnCommSave.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnCommSave.Name = "btnCommSave";
            this.btnCommSave.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnCommSave.Size = new System.Drawing.Size(124, 30);
            this.btnCommSave.TabIndex = 8;
            this.btnCommSave.Text = "OK";
            this.btnCommSave.TextColor = System.Drawing.Color.White;
            this.btnCommSave.UseVisualStyleBackColor = false;
            this.btnCommSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CommentsFrm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(560, 210);
            this.Controls.Add(this.gbxComments);
            this.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CommentsFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.gbxComments.ResumeLayout(false);
            this.gbxComments.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public SparrowRMSControl.SparrowControl.SparrowTextBox txtcomments;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblComments;
        private System.Windows.Forms.GroupBox gbxComments;
        private SparrowRMSControl.SparrowControl.SparrowButton btnCommSave;
    }
}