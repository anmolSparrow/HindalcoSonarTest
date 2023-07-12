
namespace HindalcoiOS.Machine_Edit_Form
{
    partial class MachineEditKeyComponent
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
            this.lblkeysaftey = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblSearch = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.button1 = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.txtAddKey = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.cmbsearch = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.btnAdd = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblkeysaftey
            // 
            this.lblkeysaftey.AutoSize = true;
            this.lblkeysaftey.Depth = 0;
            this.lblkeysaftey.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblkeysaftey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblkeysaftey.Location = new System.Drawing.Point(20, 101);
            this.lblkeysaftey.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblkeysaftey.Name = "lblkeysaftey";
            this.lblkeysaftey.Size = new System.Drawing.Size(63, 18);
            this.lblkeysaftey.TabIndex = 41;
            this.lblkeysaftey.Text = "Add Key";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Depth = 0;
            this.lblSearch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSearch.Location = new System.Drawing.Point(20, 50);
            this.lblSearch.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(82, 18);
            this.lblSearch.TabIndex = 40;
            this.lblSearch.Text = "Search Key";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.button1.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button1.BorderRadius = 14;
            this.button1.BorderSize = 0;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(376, 42);
            this.button1.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.button1.Name = "button1";
            this.button1.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.button1.Size = new System.Drawing.Size(94, 30);
            this.button1.TabIndex = 39;
            this.button1.Text = "View";
            this.button1.TextColor = System.Drawing.Color.White;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnView_Click);
            // 
            // txtAddKey
            // 
            this.txtAddKey.BackColor = System.Drawing.SystemColors.Window;
            this.txtAddKey.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtAddKey.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtAddKey.BorderRadius = 0;
            this.txtAddKey.BorderSize = 1;
            this.txtAddKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAddKey.Location = new System.Drawing.Point(141, 90);
            this.txtAddKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddKey.Multiline = true;
            this.txtAddKey.Name = "txtAddKey";
            this.txtAddKey.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtAddKey.PasswordChar = false;
            this.txtAddKey.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtAddKey.PlaceholderText = "";
            this.txtAddKey.Size = new System.Drawing.Size(210, 32);
            this.txtAddKey.TabIndex = 38;
            this.txtAddKey.UnderlinedStyle = false;
            this.txtAddKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddKey_KeyPress);
            // 
            // cmbsearch
            // 
            this.cmbsearch.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbsearch.BorderSize = 1;
            this.cmbsearch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbsearch.ForeColor = System.Drawing.Color.DimGray;
            this.cmbsearch.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbsearch.ItemHeight = 26;
            this.cmbsearch.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.cmbsearch.ListTextColor = System.Drawing.Color.White;
            this.cmbsearch.Location = new System.Drawing.Point(141, 44);
            this.cmbsearch.MinimumSize = new System.Drawing.Size(200, 0);
            this.cmbsearch.Name = "cmbsearch";
            this.cmbsearch.Size = new System.Drawing.Size(210, 32);
            this.cmbsearch.TabIndex = 37;
            this.cmbsearch.SelectedIndexChanged += new System.EventHandler(this.cmbsearch_SelectedIndexChanged);
            this.cmbsearch.TextChanged += new System.EventHandler(this.cmbsearch_TextChanged);
            this.cmbsearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbsearch_KeyPress);
            this.cmbsearch.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cmbsearch_PreviewKeyDown);
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
            this.btnAdd.Location = new System.Drawing.Point(376, 92);
            this.btnAdd.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnAdd.Size = new System.Drawing.Size(94, 30);
            this.btnAdd.TabIndex = 42;
            this.btnAdd.Text = "Save";
            this.btnAdd.TextColor = System.Drawing.Color.White;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.lblSearch);
            this.panel1.Controls.Add(this.lblkeysaftey);
            this.panel1.Controls.Add(this.cmbsearch);
            this.panel1.Controls.Add(this.txtAddKey);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(12, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(497, 171);
            this.panel1.TabIndex = 1;
            // 
            // MachineEditKeyComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 189);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MachineEditKeyComponent";
            this.Text = "Machine Edit Key Component";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MachineEditKeyComponentUpd_FormClosing);
            this.Load += new System.EventHandler(this.MachineEditKeyComponentUpd_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MachineEditKeyComponentUpd_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MachineEditKeyComponentUpd_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private SparrowRMSControl.SparrowControl.SparrowButton btnAdd;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblkeysaftey;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblSearch;
        private SparrowRMSControl.SparrowControl.SparrowButton button1;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtAddKey;
        private SparrowRMSControl.SparrowControl.SparrowComboBox cmbsearch;
        private System.Windows.Forms.Panel panel1;
    }
}