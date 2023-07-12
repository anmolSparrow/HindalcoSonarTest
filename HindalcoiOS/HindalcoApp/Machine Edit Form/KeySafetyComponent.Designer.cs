namespace RMPCLApp.Machine_Edit_Form
{
    partial class KeySafetyComponent
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbsearch = new System.Windows.Forms.ComboBox();
            this.lblsearch = new System.Windows.Forms.Label();
            this.btnADD = new System.Windows.Forms.Button();
            this.txtAddKeySafety = new System.Windows.Forms.TextBox();
            this.lblkeysaftey = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbsearch);
            this.groupBox1.Controls.Add(this.lblsearch);
            this.groupBox1.Controls.Add(this.btnADD);
            this.groupBox1.Controls.Add(this.txtAddKeySafety);
            this.groupBox1.Controls.Add(this.lblkeysaftey);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 173);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Safety Key Components ";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cmbsearch
            // 
            this.cmbsearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbsearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbsearch.FormattingEnabled = true;
            this.cmbsearch.Location = new System.Drawing.Point(179, 39);
            this.cmbsearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbsearch.Name = "cmbsearch";
            this.cmbsearch.Size = new System.Drawing.Size(170, 28);
            this.cmbsearch.TabIndex = 4;
            // 
            // lblsearch
            // 
            this.lblsearch.AutoSize = true;
            this.lblsearch.Location = new System.Drawing.Point(5, 43);
            this.lblsearch.Name = "lblsearch";
            this.lblsearch.Size = new System.Drawing.Size(81, 20);
            this.lblsearch.TabIndex = 3;
            this.lblsearch.Text = "Search Key";
            // 
            // btnADD
            // 
            this.btnADD.Location = new System.Drawing.Point(179, 122);
            this.btnADD.Name = "btnADD";
            this.btnADD.Size = new System.Drawing.Size(170, 30);
            this.btnADD.TabIndex = 2;
            this.btnADD.Text = "Save Key";
            this.btnADD.UseVisualStyleBackColor = true;
            this.btnADD.Click += new System.EventHandler(this.btnADD_Click);
            // 
            // txtAddKeySafety
            // 
            this.txtAddKeySafety.Location = new System.Drawing.Point(179, 84);
            this.txtAddKeySafety.MaxLength = 25;
            this.txtAddKeySafety.Name = "txtAddKeySafety";
            this.txtAddKeySafety.Size = new System.Drawing.Size(170, 27);
            this.txtAddKeySafety.TabIndex = 1;
            this.txtAddKeySafety.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddKeySafety_KeyPress);
            // 
            // lblkeysaftey
            // 
            this.lblkeysaftey.AutoSize = true;
            this.lblkeysaftey.Location = new System.Drawing.Point(5, 87);
            this.lblkeysaftey.Name = "lblkeysaftey";
            this.lblkeysaftey.Size = new System.Drawing.Size(69, 20);
            this.lblkeysaftey.TabIndex = 0;
            this.lblkeysaftey.Text = " Add Key";
            // 
            // KeySafetyComp
            // 
            this.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 173);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KeySafetyComp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KeySafetyComp";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.KeySafetyComp_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblkeysaftey;
        private System.Windows.Forms.TextBox txtAddKeySafety;
        private System.Windows.Forms.Button btnADD;
        private System.Windows.Forms.ComboBox cmbsearch;
        private System.Windows.Forms.Label lblsearch;
    }
}