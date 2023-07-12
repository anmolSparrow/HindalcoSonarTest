
namespace HindalcoiOS.U1FormCollection
{
    partial class UploadReportFrm
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
            this.bunifuLabel2 = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.firstRowNamesCheckBox = new SparrowRMSControl.SparrowControl.SparrowCheckBox();
            this.btnLoad = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.sheetCombo = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.lblUpldFormChosSheet = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.btnbrowser = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.txtfile = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblUpldFormFilepath = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bunifuLabel2);
            this.groupBox1.Controls.Add(this.firstRowNamesCheckBox);
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Controls.Add(this.sheetCombo);
            this.groupBox1.Controls.Add(this.lblUpldFormChosSheet);
            this.groupBox1.Controls.Add(this.btnbrowser);
            this.groupBox1.Controls.Add(this.txtfile);
            this.groupBox1.Controls.Add(this.lblUpldFormFilepath);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(616, 173);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Upload Report Format";
            // 
            // bunifuLabel2
            // 
            this.bunifuLabel2.AutoSize = true;
            this.bunifuLabel2.Depth = 0;
            this.bunifuLabel2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.bunifuLabel2.Location = new System.Drawing.Point(234, 65);
            this.bunifuLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bunifuLabel2.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.bunifuLabel2.Name = "bunifuLabel2";
            this.bunifuLabel2.Size = new System.Drawing.Size(215, 17);
            this.bunifuLabel2.TabIndex = 15;
            this.bunifuLabel2.Text = "First Row Contains Column Name ";
            // 
            // firstRowNamesCheckBox
            // 
            this.firstRowNamesCheckBox.AutoSize = true;
            this.firstRowNamesCheckBox.Depth = 0;
            this.firstRowNamesCheckBox.Location = new System.Drawing.Point(205, 59);
            this.firstRowNamesCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.firstRowNamesCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.firstRowNamesCheckBox.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.firstRowNamesCheckBox.Name = "firstRowNamesCheckBox";
            this.firstRowNamesCheckBox.Ripple = true;
            this.firstRowNamesCheckBox.Size = new System.Drawing.Size(26, 30);
            this.firstRowNamesCheckBox.TabIndex = 14;
            this.firstRowNamesCheckBox.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLoad.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnLoad.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnLoad.BorderRadius = 14;
            this.btnLoad.BorderSize = 0;
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnLoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(471, 100);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnLoad.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnLoad.Size = new System.Drawing.Size(131, 31);
            this.btnLoad.TabIndex = 13;
            this.btnLoad.Text = "Load Report";
            this.btnLoad.TextColor = System.Drawing.Color.White;
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // sheetCombo
            // 
            this.sheetCombo.BorderColor = System.Drawing.Color.DodgerBlue;
            this.sheetCombo.BorderSize = 1;
            this.sheetCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sheetCombo.FormattingEnabled = true;
            this.sheetCombo.IconColor = System.Drawing.Color.DodgerBlue;
            this.sheetCombo.ItemHeight = 22;
            this.sheetCombo.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.sheetCombo.ListTextColor = System.Drawing.Color.White;
            this.sheetCombo.Location = new System.Drawing.Point(205, 99);
            this.sheetCombo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.sheetCombo.MinimumSize = new System.Drawing.Size(156, 0);
            this.sheetCombo.Name = "sheetCombo";
            this.sheetCombo.Size = new System.Drawing.Size(244, 30);
            this.sheetCombo.TabIndex = 12;
            this.sheetCombo.Click += new System.EventHandler(this.SheetComboSelectedIndexChanged);
            // 
            // lblUpldFormChosSheet
            // 
            this.lblUpldFormChosSheet.AutoSize = true;
            this.lblUpldFormChosSheet.Depth = 0;
            this.lblUpldFormChosSheet.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblUpldFormChosSheet.Location = new System.Drawing.Point(39, 99);
            this.lblUpldFormChosSheet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUpldFormChosSheet.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblUpldFormChosSheet.Name = "lblUpldFormChosSheet";
            this.lblUpldFormChosSheet.Size = new System.Drawing.Size(111, 21);
            this.lblUpldFormChosSheet.TabIndex = 11;
            this.lblUpldFormChosSheet.Text = "Choose Sheet";
            // 
            // btnbrowser
            // 
            this.btnbrowser.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnbrowser.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnbrowser.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnbrowser.BorderRadius = 14;
            this.btnbrowser.BorderSize = 0;
            this.btnbrowser.FlatAppearance.BorderSize = 0;
            this.btnbrowser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnbrowser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnbrowser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbrowser.ForeColor = System.Drawing.Color.White;
            this.btnbrowser.Location = new System.Drawing.Point(471, 30);
            this.btnbrowser.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnbrowser.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnbrowser.Name = "btnbrowser";
            this.btnbrowser.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnbrowser.Size = new System.Drawing.Size(131, 31);
            this.btnbrowser.TabIndex = 9;
            this.btnbrowser.Text = "Browse";
            this.btnbrowser.TextColor = System.Drawing.Color.White;
            this.btnbrowser.UseVisualStyleBackColor = false;
            this.btnbrowser.Click += new System.EventHandler(this.btnbrowser_Click);
            // 
            // txtfile
            // 
            this.txtfile.BackColor = System.Drawing.SystemColors.Window;
            this.txtfile.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtfile.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtfile.BorderRadius = 0;
            this.txtfile.BorderSize = 1;
            this.txtfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtfile.Location = new System.Drawing.Point(205, 23);
            this.txtfile.Margin = new System.Windows.Forms.Padding(4);
            this.txtfile.Multiline = true;
            this.txtfile.Name = "txtfile";
            this.txtfile.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.txtfile.PasswordChar = false;
            this.txtfile.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtfile.PlaceholderText = "FIle Path";
            this.txtfile.Size = new System.Drawing.Size(243, 35);
            this.txtfile.TabIndex = 8;
            this.txtfile.UnderlinedStyle = false;
            // 
            // lblUpldFormFilepath
            // 
            this.lblUpldFormFilepath.AutoSize = true;
            this.lblUpldFormFilepath.Depth = 0;
            this.lblUpldFormFilepath.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblUpldFormFilepath.Location = new System.Drawing.Point(39, 29);
            this.lblUpldFormFilepath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUpldFormFilepath.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblUpldFormFilepath.Name = "lblUpldFormFilepath";
            this.lblUpldFormFilepath.Size = new System.Drawing.Size(74, 21);
            this.lblUpldFormFilepath.TabIndex = 0;
            this.lblUpldFormFilepath.Text = "File Path";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // UploadReportFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 186);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UploadReportFrm";
            this.Text = "Upload Report Form";
            this.Load += new System.EventHandler(this.UploadReportFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblUpldFormFilepath;
        private SparrowRMSControl.SparrowControl.SparrowLabel bunifuLabel2;
        private SparrowRMSControl.SparrowControl.SparrowCheckBox firstRowNamesCheckBox;
        private SparrowRMSControl.SparrowControl.SparrowButton btnLoad;
        private SparrowRMSControl.SparrowControl.SparrowComboBox sheetCombo;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblUpldFormChosSheet;
        private SparrowRMSControl.SparrowControl.SparrowButton btnbrowser;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtfile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}