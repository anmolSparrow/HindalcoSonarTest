
namespace HindalcoiOS.Dynamic_Form
{
    partial class PackageMachine
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
            this.grppackage = new System.Windows.Forms.GroupBox();
            this.btnSave = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.txtmachine = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblMachineName = new System.Windows.Forms.Label();
            this.grppackage.SuspendLayout();
            this.SuspendLayout();
            // 
            // grppackage
            // 
            this.grppackage.Controls.Add(this.btnSave);
            this.grppackage.Controls.Add(this.txtmachine);
            this.grppackage.Controls.Add(this.lblMachineName);
            this.grppackage.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grppackage.Location = new System.Drawing.Point(12, 3);
            this.grppackage.Name = "grppackage";
            this.grppackage.Size = new System.Drawing.Size(492, 144);
            this.grppackage.TabIndex = 0;
            this.grppackage.TabStop = false;
            this.grppackage.Text = "Components Machine\'s ";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.BorderRadius = 15;
            this.btnSave.BorderSize = 0;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(316, 90);
            this.btnSave.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSave.Name = "btnSave";
            this.btnSave.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnSave.Size = new System.Drawing.Size(145, 28);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Generate Machine";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // txtmachine
            // 
            this.txtmachine.BackColor = System.Drawing.SystemColors.Window;
            this.txtmachine.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtmachine.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtmachine.BorderRadius = 0;
            this.txtmachine.BorderSize = 1;
            this.txtmachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmachine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtmachine.Location = new System.Drawing.Point(182, 32);
            this.txtmachine.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtmachine.Multiline = false;
            this.txtmachine.Name = "txtmachine";
            this.txtmachine.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtmachine.PasswordChar = false;
            this.txtmachine.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtmachine.PlaceholderText = "Machine Name";
            this.txtmachine.Size = new System.Drawing.Size(278, 33);
            this.txtmachine.TabIndex = 1;
            this.txtmachine.UnderlinedStyle = false;
            // 
            // lblMachineName
            // 
            this.lblMachineName.AutoSize = true;
            this.lblMachineName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMachineName.Location = new System.Drawing.Point(40, 40);
            this.lblMachineName.Name = "lblMachineName";
            this.lblMachineName.Size = new System.Drawing.Size(119, 21);
            this.lblMachineName.TabIndex = 0;
            this.lblMachineName.Text = "Machine Name";
            // 
            // PackageMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 163);
            this.Controls.Add(this.grppackage);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PackageMachine";
            this.Text = "Package Machine";
            this.grppackage.ResumeLayout(false);
            this.grppackage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grppackage;
        private System.Windows.Forms.Label lblMachineName;
        private SparrowRMSControl.SparrowControl.SparrowButton btnSave;
        public  SparrowRMSControl.SparrowControl.SparrowTextBox txtmachine;
    }
}