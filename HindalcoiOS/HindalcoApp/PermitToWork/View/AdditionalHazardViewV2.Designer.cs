
namespace HindalcoiOS.PermitToWork
{
    partial class AdditionalHazardView
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
            this.gbxAddHaz = new System.Windows.Forms.GroupBox();
            this.btnAddHazSave = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnAddHazDelete = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.txtAddHazRemarks = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblAddHazRemarks = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtAddHazard = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblAddHazItem = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.gbxAddHaz.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxAddHaz
            // 
            this.gbxAddHaz.Controls.Add(this.btnAddHazSave);
            this.gbxAddHaz.Controls.Add(this.btnAddHazDelete);
            this.gbxAddHaz.Controls.Add(this.txtAddHazRemarks);
            this.gbxAddHaz.Controls.Add(this.lblAddHazRemarks);
            this.gbxAddHaz.Controls.Add(this.txtAddHazard);
            this.gbxAddHaz.Controls.Add(this.lblAddHazItem);
            this.gbxAddHaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxAddHaz.Location = new System.Drawing.Point(11, 13);
            this.gbxAddHaz.Name = "gbxAddHaz";
            this.gbxAddHaz.Size = new System.Drawing.Size(356, 216);
            this.gbxAddHaz.TabIndex = 0;
            this.gbxAddHaz.TabStop = false;
            this.gbxAddHaz.Text = "Add Hazard";
            // 
            // btnAddHazSave
            // 
            this.btnAddHazSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddHazSave.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnAddHazSave.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnAddHazSave.BorderRadius = 14;
            this.btnAddHazSave.BorderSize = 0;
            this.btnAddHazSave.FlatAppearance.BorderSize = 0;
            this.btnAddHazSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAddHazSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAddHazSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddHazSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddHazSave.ForeColor = System.Drawing.Color.White;
            this.btnAddHazSave.Location = new System.Drawing.Point(226, 170);
            this.btnAddHazSave.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAddHazSave.Name = "btnAddHazSave";
            this.btnAddHazSave.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnAddHazSave.Size = new System.Drawing.Size(111, 30);
            this.btnAddHazSave.TabIndex = 5;
            this.btnAddHazSave.Text = "Add Item";
            this.btnAddHazSave.TextColor = System.Drawing.Color.White;
            this.btnAddHazSave.UseVisualStyleBackColor = false;
            this.btnAddHazSave.Click += new System.EventHandler(this.btnAddHazSave_Click);
            // 
            // btnAddHazDelete
            // 
            this.btnAddHazDelete.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddHazDelete.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnAddHazDelete.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnAddHazDelete.BorderRadius = 14;
            this.btnAddHazDelete.BorderSize = 0;
            this.btnAddHazDelete.FlatAppearance.BorderSize = 0;
            this.btnAddHazDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAddHazDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAddHazDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddHazDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddHazDelete.ForeColor = System.Drawing.Color.White;
            this.btnAddHazDelete.Location = new System.Drawing.Point(113, 170);
            this.btnAddHazDelete.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAddHazDelete.Name = "btnAddHazDelete";
            this.btnAddHazDelete.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnAddHazDelete.Size = new System.Drawing.Size(107, 30);
            this.btnAddHazDelete.TabIndex = 4;
            this.btnAddHazDelete.Text = "Delete";
            this.btnAddHazDelete.TextColor = System.Drawing.Color.White;
            this.btnAddHazDelete.UseVisualStyleBackColor = false;
            this.btnAddHazDelete.Click += new System.EventHandler(this.btnAddHazDelete_Click);
            // 
            // txtAddHazRemarks
            // 
            this.txtAddHazRemarks.BackColor = System.Drawing.SystemColors.Window;
            this.txtAddHazRemarks.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtAddHazRemarks.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtAddHazRemarks.BorderRadius = 0;
            this.txtAddHazRemarks.BorderSize = 1;
            this.txtAddHazRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddHazRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAddHazRemarks.Location = new System.Drawing.Point(113, 85);
            this.txtAddHazRemarks.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddHazRemarks.Multiline = true;
            this.txtAddHazRemarks.Name = "txtAddHazRemarks";
            this.txtAddHazRemarks.Padding = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.txtAddHazRemarks.PasswordChar = false;
            this.txtAddHazRemarks.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtAddHazRemarks.PlaceholderText = "Enter Text";
            this.txtAddHazRemarks.Size = new System.Drawing.Size(224, 64);
            this.txtAddHazRemarks.TabIndex = 3;
            this.txtAddHazRemarks.UnderlinedStyle = false;
            // 
            // lblAddHazRemarks
            // 
            this.lblAddHazRemarks.AutoSize = true;
            this.lblAddHazRemarks.Depth = 0;
            this.lblAddHazRemarks.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblAddHazRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAddHazRemarks.Location = new System.Drawing.Point(6, 101);
            this.lblAddHazRemarks.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblAddHazRemarks.Name = "lblAddHazRemarks";
            this.lblAddHazRemarks.Size = new System.Drawing.Size(75, 21);
            this.lblAddHazRemarks.TabIndex = 2;
            this.lblAddHazRemarks.Text = "Remarks";
            // 
            // txtAddHazard
            // 
            this.txtAddHazard.BackColor = System.Drawing.SystemColors.Window;
            this.txtAddHazard.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtAddHazard.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtAddHazard.BorderRadius = 0;
            this.txtAddHazard.BorderSize = 1;
            this.txtAddHazard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddHazard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAddHazard.Location = new System.Drawing.Point(113, 28);
            this.txtAddHazard.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddHazard.Multiline = false;
            this.txtAddHazard.Name = "txtAddHazard";
            this.txtAddHazard.Padding = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.txtAddHazard.PasswordChar = false;
            this.txtAddHazard.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtAddHazard.PlaceholderText = "Enter Text";
            this.txtAddHazard.Size = new System.Drawing.Size(224, 35);
            this.txtAddHazard.TabIndex = 1;
            this.txtAddHazard.UnderlinedStyle = false;
            // 
            // lblAddHazItem
            // 
            this.lblAddHazItem.AutoSize = true;
            this.lblAddHazItem.Depth = 0;
            this.lblAddHazItem.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblAddHazItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAddHazItem.Location = new System.Drawing.Point(11, 35);
            this.lblAddHazItem.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblAddHazItem.Name = "lblAddHazItem";
            this.lblAddHazItem.Size = new System.Drawing.Size(62, 21);
            this.lblAddHazItem.TabIndex = 0;
            this.lblAddHazItem.Text = "Hazard";
            // 
            // AdditionalHazardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 242);
            this.Controls.Add(this.gbxAddHaz);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdditionalHazardView";
            this.Text = "Additional Hazard";
            this.gbxAddHaz.ResumeLayout(false);
            this.gbxAddHaz.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxAddHaz;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtAddHazard;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblAddHazItem;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtAddHazRemarks;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblAddHazRemarks;
        private SparrowRMSControl.SparrowControl.SparrowButton btnAddHazSave;
        private SparrowRMSControl.SparrowControl.SparrowButton btnAddHazDelete;
    }
}

