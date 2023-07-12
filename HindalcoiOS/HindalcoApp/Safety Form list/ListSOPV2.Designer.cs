
namespace HindalcoiOS.Safety_Form_list
{
    partial class ListSOP
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
            this.grpsop = new System.Windows.Forms.GroupBox();
            this.bunifuDropdown1 = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.btnDefinationLoad = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.lblfilled = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblDefination = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.btnAttachFile = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.lblAttached = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.btnSave = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.grpsop.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpsop
            // 
            this.grpsop.Controls.Add(this.bunifuDropdown1);
            this.grpsop.Controls.Add(this.btnDefinationLoad);
            this.grpsop.Controls.Add(this.lblfilled);
            this.grpsop.Controls.Add(this.lblDefination);
            this.grpsop.Controls.Add(this.btnAttachFile);
            this.grpsop.Controls.Add(this.lblAttached);
            this.grpsop.Controls.Add(this.btnSave);
            this.grpsop.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpsop.Location = new System.Drawing.Point(14, 7);
            this.grpsop.Name = "grpsop";
            this.grpsop.Size = new System.Drawing.Size(466, 193);
            this.grpsop.TabIndex = 1;
            this.grpsop.TabStop = false;
            this.grpsop.Text = "SOP List Details";
            // 
            // bunifuDropdown1
            // 
            this.bunifuDropdown1.BorderColor = System.Drawing.Color.DodgerBlue;
            this.bunifuDropdown1.BorderSize = 1;
            this.bunifuDropdown1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.bunifuDropdown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.bunifuDropdown1.ForeColor = System.Drawing.Color.DimGray;
            this.bunifuDropdown1.IconColor = System.Drawing.Color.DodgerBlue;
            this.bunifuDropdown1.ItemHeight = 26;
            this.bunifuDropdown1.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.bunifuDropdown1.ListTextColor = System.Drawing.Color.White;
            this.bunifuDropdown1.Location = new System.Drawing.Point(223, 109);
            this.bunifuDropdown1.MinimumSize = new System.Drawing.Size(200, 0);
            this.bunifuDropdown1.Name = "bunifuDropdown1";
            this.bunifuDropdown1.Size = new System.Drawing.Size(210, 32);
            this.bunifuDropdown1.TabIndex = 41;
            // 
            // btnDefinationLoad
            // 
            this.btnDefinationLoad.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDefinationLoad.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnDefinationLoad.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnDefinationLoad.BorderRadius = 14;
            this.btnDefinationLoad.BorderSize = 0;
            this.btnDefinationLoad.FlatAppearance.BorderSize = 0;
            this.btnDefinationLoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnDefinationLoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnDefinationLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefinationLoad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDefinationLoad.ForeColor = System.Drawing.Color.White;
            this.btnDefinationLoad.Location = new System.Drawing.Point(223, 73);
            this.btnDefinationLoad.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnDefinationLoad.Name = "btnDefinationLoad";
            this.btnDefinationLoad.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnDefinationLoad.Size = new System.Drawing.Size(114, 30);
            this.btnDefinationLoad.TabIndex = 40;
            this.btnDefinationLoad.Tag = "Defination";
            this.btnDefinationLoad.Text = "Upload File";
            this.btnDefinationLoad.TextColor = System.Drawing.Color.White;
            this.btnDefinationLoad.UseVisualStyleBackColor = false;
            this.btnDefinationLoad.Click += new System.EventHandler(this.CallInvoke);
            // 
            // lblfilled
            // 
            this.lblfilled.AutoSize = true;
            this.lblfilled.Depth = 0;
            this.lblfilled.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblfilled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblfilled.Location = new System.Drawing.Point(16, 118);
            this.lblfilled.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblfilled.Name = "lblfilled";
            this.lblfilled.Size = new System.Drawing.Size(121, 18);
            this.lblfilled.TabIndex = 39;
            this.lblfilled.Text = "Details To Be Fills";
            // 
            // lblDefination
            // 
            this.lblDefination.AutoSize = true;
            this.lblDefination.Depth = 0;
            this.lblDefination.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblDefination.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDefination.Location = new System.Drawing.Point(16, 73);
            this.lblDefination.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblDefination.Name = "lblDefination";
            this.lblDefination.Size = new System.Drawing.Size(103, 18);
            this.lblDefination.TabIndex = 38;
            this.lblDefination.Text = "Add Definitions";
            // 
            // btnAttachFile
            // 
            this.btnAttachFile.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAttachFile.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnAttachFile.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnAttachFile.BorderRadius = 14;
            this.btnAttachFile.BorderSize = 0;
            this.btnAttachFile.FlatAppearance.BorderSize = 0;
            this.btnAttachFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAttachFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAttachFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttachFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttachFile.ForeColor = System.Drawing.Color.White;
            this.btnAttachFile.Location = new System.Drawing.Point(223, 24);
            this.btnAttachFile.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAttachFile.Name = "btnAttachFile";
            this.btnAttachFile.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnAttachFile.Size = new System.Drawing.Size(114, 30);
            this.btnAttachFile.TabIndex = 37;
            this.btnAttachFile.Tag = "Attached";
            this.btnAttachFile.Text = "Load File";
            this.btnAttachFile.TextColor = System.Drawing.Color.White;
            this.btnAttachFile.UseVisualStyleBackColor = false;
            this.btnAttachFile.Click += new System.EventHandler(this.CallInvoke);
            // 
            // lblAttached
            // 
            this.lblAttached.AutoSize = true;
            this.lblAttached.Depth = 0;
            this.lblAttached.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblAttached.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAttached.Location = new System.Drawing.Point(16, 30);
            this.lblAttached.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblAttached.Name = "lblAttached";
            this.lblAttached.Size = new System.Drawing.Size(66, 18);
            this.lblAttached.TabIndex = 36;
            this.lblAttached.Text = "Attached";
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
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(319, 157);
            this.btnSave.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSave.Name = "btnSave";
            this.btnSave.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnSave.Size = new System.Drawing.Size(114, 30);
            this.btnSave.TabIndex = 34;
            this.btnSave.Tag = "Save";
            this.btnSave.Text = "Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.CallInvoke);
            // 
            // ListSOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 219);
            this.Controls.Add(this.grpsop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListSOP";
            this.Text = "List SOP";
            this.Load += new System.EventHandler(this.ListSOP_Load);
            this.grpsop.ResumeLayout(false);
            this.grpsop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpsop;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblAttached;
        private SparrowRMSControl.SparrowControl.SparrowButton btnSave;
        private SparrowRMSControl.SparrowControl.SparrowButton btnAttachFile;
        private SparrowRMSControl.SparrowControl.SparrowButton btnDefinationLoad;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblfilled;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblDefination;
        private SparrowRMSControl.SparrowControl.SparrowComboBox bunifuDropdown1;
    }
}