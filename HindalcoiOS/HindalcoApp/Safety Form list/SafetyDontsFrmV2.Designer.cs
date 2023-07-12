
namespace HindalcoiOS.Safety_Form_list

{
    partial class SafetyDontsFrm
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
            this.gbxSafetyDonts = new System.Windows.Forms.GroupBox();
            this.btnAdd = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.lbllist = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.cmblist = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.lblAdd = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblSpecificDonts = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.btnUpdate = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.txtAdd = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.cmboperartion = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.gbxSafetyDonts.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxSafetyDonts
            // 
            this.gbxSafetyDonts.Controls.Add(this.btnAdd);
            this.gbxSafetyDonts.Controls.Add(this.lbllist);
            this.gbxSafetyDonts.Controls.Add(this.cmblist);
            this.gbxSafetyDonts.Controls.Add(this.lblAdd);
            this.gbxSafetyDonts.Controls.Add(this.lblSpecificDonts);
            this.gbxSafetyDonts.Controls.Add(this.btnUpdate);
            this.gbxSafetyDonts.Controls.Add(this.txtAdd);
            this.gbxSafetyDonts.Controls.Add(this.cmboperartion);
            this.gbxSafetyDonts.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxSafetyDonts.Location = new System.Drawing.Point(13, 10);
            this.gbxSafetyDonts.Name = "gbxSafetyDonts";
            this.gbxSafetyDonts.Size = new System.Drawing.Size(810, 195);
            this.gbxSafetyDonts.TabIndex = 1;
            this.gbxSafetyDonts.TabStop = false;
            this.gbxSafetyDonts.Text = "Safety Do && Don\'ts Operation";
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
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(560, 117);
            this.btnAdd.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnAdd.Size = new System.Drawing.Size(119, 30);
            this.btnAdd.TabIndex = 39;
            this.btnAdd.Text = "Add Operation";
            this.btnAdd.TextColor = System.Drawing.Color.White;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lbllist
            // 
            this.lbllist.AutoSize = true;
            this.lbllist.Depth = 0;
            this.lbllist.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbllist.Location = new System.Drawing.Point(436, 66);
            this.lbllist.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lbllist.Name = "lbllist";
            this.lbllist.Size = new System.Drawing.Size(97, 18);
            this.lbllist.TabIndex = 38;
            this.lbllist.Text = "Operation List";
            // 
            // cmblist
            // 
            this.cmblist.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmblist.BorderSize = 1;
            this.cmblist.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmblist.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmblist.ForeColor = System.Drawing.Color.DimGray;
            this.cmblist.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmblist.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.cmblist.ListTextColor = System.Drawing.Color.White;
            this.cmblist.Location = new System.Drawing.Point(560, 62);
            this.cmblist.MinimumSize = new System.Drawing.Size(200, 0);
            this.cmblist.Name = "cmblist";
            this.cmblist.Size = new System.Drawing.Size(236, 27);
            this.cmblist.TabIndex = 37;
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Depth = 0;
            this.lblAdd.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAdd.Location = new System.Drawing.Point(20, 126);
            this.lblAdd.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(101, 18);
            this.lblAdd.TabIndex = 36;
            this.lblAdd.Text = "Add Operation";
            // 
            // lblSpecificDonts
            // 
            this.lblSpecificDonts.AutoSize = true;
            this.lblSpecificDonts.Depth = 0;
            this.lblSpecificDonts.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpecificDonts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSpecificDonts.Location = new System.Drawing.Point(20, 66);
            this.lblSpecificDonts.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblSpecificDonts.Name = "lblSpecificDonts";
            this.lblSpecificDonts.Size = new System.Drawing.Size(149, 18);
            this.lblSpecificDonts.TabIndex = 35;
            this.lblSpecificDonts.Text = "Specific Do\'s && Don’ts";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdate.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdate.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdate.BorderRadius = 14;
            this.btnUpdate.BorderSize = 0;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(685, 117);
            this.btnUpdate.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnUpdate.Size = new System.Drawing.Size(111, 30);
            this.btnUpdate.TabIndex = 34;
            this.btnUpdate.Text = "Update Data";
            this.btnUpdate.TextColor = System.Drawing.Color.White;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtAdd
            // 
            this.txtAdd.BackColor = System.Drawing.SystemColors.Window;
            this.txtAdd.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtAdd.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtAdd.BorderRadius = 0;
            this.txtAdd.BorderSize = 1;
            this.txtAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAdd.Location = new System.Drawing.Point(180, 117);
            this.txtAdd.Margin = new System.Windows.Forms.Padding(4);
            this.txtAdd.Multiline = true;
            this.txtAdd.Name = "txtAdd";
            this.txtAdd.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtAdd.PasswordChar = false;
            this.txtAdd.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtAdd.PlaceholderText = "";
            this.txtAdd.Size = new System.Drawing.Size(210, 32);
            this.txtAdd.TabIndex = 33;
            this.txtAdd.UnderlinedStyle = false;
            // 
            // cmboperartion
            // 
            this.cmboperartion.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmboperartion.BorderSize = 1;
            this.cmboperartion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmboperartion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmboperartion.ForeColor = System.Drawing.Color.DimGray;
            this.cmboperartion.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmboperartion.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.cmboperartion.ListTextColor = System.Drawing.Color.White;
            this.cmboperartion.Location = new System.Drawing.Point(180, 62);
            this.cmboperartion.MinimumSize = new System.Drawing.Size(200, 0);
            this.cmboperartion.Name = "cmboperartion";
            this.cmboperartion.Size = new System.Drawing.Size(210, 27);
            this.cmboperartion.TabIndex = 32;
            this.cmboperartion.SelectedIndexChanged += new System.EventHandler(this.cmboperartion_SelectedIndexChanged);
            // 
            // SafetyDontsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 221);
            this.Controls.Add(this.gbxSafetyDonts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SafetyDontsFrm";
            this.Text = "Safety Don\'ts Form";
            this.Load += new System.EventHandler(this.SafetyDontsFrm_Load);
            this.gbxSafetyDonts.ResumeLayout(false);
            this.gbxSafetyDonts.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxSafetyDonts;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblAdd;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblSpecificDonts;
        private SparrowRMSControl.SparrowControl.SparrowButton btnUpdate;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtAdd;
        private SparrowRMSControl.SparrowControl.SparrowComboBox cmboperartion;
        private SparrowRMSControl.SparrowControl.SparrowButton btnAdd;
        private SparrowRMSControl.SparrowControl.SparrowLabel lbllist;
        private SparrowRMSControl.SparrowControl.SparrowComboBox cmblist;
    }
}