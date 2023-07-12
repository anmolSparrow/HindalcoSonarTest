namespace RMPCLApp.Machine_Edit_Form
{
    partial class KeyCompoSpecsReader
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.DBGridGeneral = new System.Windows.Forms.DataGridView();
            this.tabSpecific = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DBGridGeneral)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabSpecific);
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1157, 480);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.DBGridGeneral);
            this.tabGeneral.Location = new System.Drawing.Point(4, 25);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(1149, 451);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Tag = "General";
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // DBGridGeneral
            // 
            this.DBGridGeneral.AllowUserToAddRows = false;
            this.DBGridGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DBGridGeneral.Location = new System.Drawing.Point(6, 4);
            this.DBGridGeneral.Name = "DBGridGeneral";
            this.DBGridGeneral.RowHeadersWidth = 51;
            this.DBGridGeneral.RowTemplate.Height = 24;
            this.DBGridGeneral.Size = new System.Drawing.Size(1137, 441);
            this.DBGridGeneral.TabIndex = 1;
            this.DBGridGeneral.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DBGridGeneral_CellEnter);
            this.DBGridGeneral.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DBGridGeneral_CellValueChanged);
            // 
            // tabSpecific
            // 
            this.tabSpecific.Location = new System.Drawing.Point(4, 25);
            this.tabSpecific.Name = "tabSpecific";
            this.tabSpecific.Padding = new System.Windows.Forms.Padding(3);
            this.tabSpecific.Size = new System.Drawing.Size(1149, 451);
            this.tabSpecific.TabIndex = 1;
            this.tabSpecific.Tag = "Specific";
            this.tabSpecific.Text = "Specific Parameter";
            this.tabSpecific.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1040, 490);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 40);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // KeyCompoSpecsReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 571);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Name = "KeyCompoSpecsReader";
            this.Text = "c";
            this.Load += new System.EventHandler(this.KeyCompoSpecsReader_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DBGridGeneral)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.DataGridView DBGridGeneral;
        private System.Windows.Forms.TabPage tabSpecific;
        private System.Windows.Forms.Button btnSave;
    }
}