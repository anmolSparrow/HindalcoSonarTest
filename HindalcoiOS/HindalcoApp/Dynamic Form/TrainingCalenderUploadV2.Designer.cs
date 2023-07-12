
namespace HindalcoiOS.Dynamic_Form
{
    partial class TrainingCalenderUpload
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtfile = new System.Windows.Forms.GroupBox();
            this.firstRowNamesCheckBox = new System.Windows.Forms.CheckBox();
            this.sheetCombo = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.sparrowTextBox1 = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblChooseSheet = new System.Windows.Forms.Label();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.btnDownLoad = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnLoad = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnbrowser = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.grpcalender = new System.Windows.Forms.GroupBox();
            this.DgvCalender = new System.Windows.Forms.DataGridView();
            this.btnsave = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btncancel = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addTrainingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTrainingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtfile.SuspendLayout();
            this.grpcalender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCalender)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtfile
            // 
            this.txtfile.Controls.Add(this.firstRowNamesCheckBox);
            this.txtfile.Controls.Add(this.sheetCombo);
            this.txtfile.Controls.Add(this.sparrowTextBox1);
            this.txtfile.Controls.Add(this.lblChooseSheet);
            this.txtfile.Controls.Add(this.lblFilePath);
            this.txtfile.Controls.Add(this.btnDownLoad);
            this.txtfile.Controls.Add(this.btnLoad);
            this.txtfile.Controls.Add(this.btnbrowser);
            this.txtfile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfile.Location = new System.Drawing.Point(12, -2);
            this.txtfile.Name = "txtfile";
            this.txtfile.Size = new System.Drawing.Size(815, 162);
            this.txtfile.TabIndex = 0;
            this.txtfile.TabStop = false;
            this.txtfile.Text = "Upload Report Format";
            // 
            // firstRowNamesCheckBox
            // 
            this.firstRowNamesCheckBox.AutoSize = true;
            this.firstRowNamesCheckBox.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstRowNamesCheckBox.Location = new System.Drawing.Point(162, 81);
            this.firstRowNamesCheckBox.Name = "firstRowNamesCheckBox";
            this.firstRowNamesCheckBox.Size = new System.Drawing.Size(239, 21);
            this.firstRowNamesCheckBox.TabIndex = 7;
            this.firstRowNamesCheckBox.Text = "First Row Contains Column Names";
            this.firstRowNamesCheckBox.UseVisualStyleBackColor = true;
            // 
            // sheetCombo
            // 
            this.sheetCombo.BorderColor = System.Drawing.Color.DodgerBlue;
            this.sheetCombo.BorderSize = 2;
            this.sheetCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sheetCombo.ForeColor = System.Drawing.Color.DimGray;
            this.sheetCombo.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.sheetCombo.ItemHeight = 22;
            this.sheetCombo.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.sheetCombo.ListTextColor = System.Drawing.Color.DimGray;
            this.sheetCombo.Location = new System.Drawing.Point(158, 116);
            this.sheetCombo.MinimumSize = new System.Drawing.Size(200, 0);
            this.sheetCombo.Name = "sheetCombo";
            this.sheetCombo.Size = new System.Drawing.Size(243, 30);
            this.sheetCombo.TabIndex = 6;
            // 
            // sparrowTextBox1
            // 
            this.sparrowTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.sparrowTextBox1.BorderColor = System.Drawing.Color.DodgerBlue;
            this.sparrowTextBox1.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.sparrowTextBox1.BorderRadius = 0;
            this.sparrowTextBox1.BorderSize = 1;
            this.sparrowTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sparrowTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sparrowTextBox1.Location = new System.Drawing.Point(158, 32);
            this.sparrowTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.sparrowTextBox1.Multiline = false;
            this.sparrowTextBox1.Name = "sparrowTextBox1";
            this.sparrowTextBox1.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.sparrowTextBox1.PasswordChar = false;
            this.sparrowTextBox1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.sparrowTextBox1.PlaceholderText = "File Path";
            this.sparrowTextBox1.Size = new System.Drawing.Size(243, 33);
            this.sparrowTextBox1.TabIndex = 5;
            this.sparrowTextBox1.UnderlinedStyle = false;
            // 
            // lblChooseSheet
            // 
            this.lblChooseSheet.AutoSize = true;
            this.lblChooseSheet.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseSheet.Location = new System.Drawing.Point(37, 121);
            this.lblChooseSheet.Name = "lblChooseSheet";
            this.lblChooseSheet.Size = new System.Drawing.Size(98, 18);
            this.lblChooseSheet.TabIndex = 4;
            this.lblChooseSheet.Text = "Choose Sheet";
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilePath.Location = new System.Drawing.Point(37, 41);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(62, 18);
            this.lblFilePath.TabIndex = 3;
            this.lblFilePath.Text = "File Path";
            // 
            // btnDownLoad
            // 
            this.btnDownLoad.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDownLoad.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnDownLoad.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnDownLoad.BorderRadius = 15;
            this.btnDownLoad.BorderSize = 0;
            this.btnDownLoad.FlatAppearance.BorderSize = 0;
            this.btnDownLoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnDownLoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnDownLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownLoad.ForeColor = System.Drawing.Color.White;
            this.btnDownLoad.Location = new System.Drawing.Point(621, 115);
            this.btnDownLoad.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnDownLoad.Size = new System.Drawing.Size(139, 30);
            this.btnDownLoad.TabIndex = 2;
            this.btnDownLoad.Text = "Download Format";
            this.btnDownLoad.TextColor = System.Drawing.Color.White;
            this.btnDownLoad.UseVisualStyleBackColor = false;
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLoad.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnLoad.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnLoad.BorderRadius = 15;
            this.btnLoad.BorderSize = 0;
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnLoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(484, 115);
            this.btnLoad.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnLoad.Size = new System.Drawing.Size(107, 30);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load Report";
            this.btnLoad.TextColor = System.Drawing.Color.White;
            this.btnLoad.UseVisualStyleBackColor = false;
            // 
            // btnbrowser
            // 
            this.btnbrowser.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnbrowser.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnbrowser.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnbrowser.BorderRadius = 15;
            this.btnbrowser.BorderSize = 0;
            this.btnbrowser.FlatAppearance.BorderSize = 0;
            this.btnbrowser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnbrowser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnbrowser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbrowser.ForeColor = System.Drawing.Color.White;
            this.btnbrowser.Location = new System.Drawing.Point(484, 32);
            this.btnbrowser.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnbrowser.Name = "btnbrowser";
            this.btnbrowser.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnbrowser.Size = new System.Drawing.Size(98, 30);
            this.btnbrowser.TabIndex = 0;
            this.btnbrowser.Text = "Browse";
            this.btnbrowser.TextColor = System.Drawing.Color.White;
            this.btnbrowser.UseVisualStyleBackColor = false;
            // 
            // grpcalender
            // 
            this.grpcalender.Controls.Add(this.DgvCalender);
            this.grpcalender.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpcalender.Location = new System.Drawing.Point(12, 171);
            this.grpcalender.Name = "grpcalender";
            this.grpcalender.Size = new System.Drawing.Size(815, 187);
            this.grpcalender.TabIndex = 1;
            this.grpcalender.TabStop = false;
            this.grpcalender.Text = "Upload Report Details";
            // 
            // DgvCalender
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvCalender.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DgvCalender.ColumnHeadersHeight = 35;
            this.DgvCalender.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvCalender.EnableHeadersVisualStyles = false;
            this.DgvCalender.Location = new System.Drawing.Point(16, 22);
            this.DgvCalender.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DgvCalender.Name = "DgvCalender";
            this.DgvCalender.RowHeadersWidth = 62;
            this.DgvCalender.RowTemplate.Height = 28;
            this.DgvCalender.Size = new System.Drawing.Size(780, 152);
            this.DgvCalender.TabIndex = 0;
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnsave.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnsave.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnsave.BorderRadius = 15;
            this.btnsave.BorderSize = 0;
            this.btnsave.FlatAppearance.BorderSize = 0;
            this.btnsave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnsave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Location = new System.Drawing.Point(548, 367);
            this.btnsave.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnsave.Name = "btnsave";
            this.btnsave.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnsave.Size = new System.Drawing.Size(98, 30);
            this.btnsave.TabIndex = 8;
            this.btnsave.Text = "Save";
            this.btnsave.TextColor = System.Drawing.Color.White;
            this.btnsave.UseVisualStyleBackColor = false;
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btncancel.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btncancel.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btncancel.BorderRadius = 15;
            this.btncancel.BorderSize = 0;
            this.btncancel.FlatAppearance.BorderSize = 0;
            this.btncancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btncancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.ForeColor = System.Drawing.Color.White;
            this.btncancel.Location = new System.Drawing.Point(674, 367);
            this.btncancel.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btncancel.Name = "btncancel";
            this.btncancel.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btncancel.Size = new System.Drawing.Size(98, 30);
            this.btncancel.TabIndex = 9;
            this.btncancel.Text = "Cancel";
            this.btncancel.TextColor = System.Drawing.Color.White;
            this.btncancel.UseVisualStyleBackColor = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTrainingToolStripMenuItem,
            this.removeTrainingToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(190, 52);
            // 
            // addTrainingToolStripMenuItem
            // 
            this.addTrainingToolStripMenuItem.Name = "addTrainingToolStripMenuItem";
            this.addTrainingToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.addTrainingToolStripMenuItem.Text = "Add Training";
            // 
            // removeTrainingToolStripMenuItem
            // 
            this.removeTrainingToolStripMenuItem.Name = "removeTrainingToolStripMenuItem";
            this.removeTrainingToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.removeTrainingToolStripMenuItem.Text = "Remove Training";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // TrainingCalenderUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 408);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.grpcalender);
            this.Controls.Add(this.txtfile);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TrainingCalenderUpload";
            this.Text = "Training Calender Upload";
            this.txtfile.ResumeLayout(false);
            this.txtfile.PerformLayout();
            this.grpcalender.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCalender)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox txtfile;
        private System.Windows.Forms.GroupBox grpcalender;
        private System.Windows.Forms.Label lblFilePath;
        private SparrowRMSControl.SparrowControl.SparrowButton btnDownLoad;
        private SparrowRMSControl.SparrowControl.SparrowButton btnLoad;
        private SparrowRMSControl.SparrowControl.SparrowButton btnbrowser;
        private SparrowRMSControl.SparrowControl.SparrowComboBox sheetCombo;
        private SparrowRMSControl.SparrowControl.SparrowTextBox sparrowTextBox1;
        private System.Windows.Forms.Label lblChooseSheet;
        private System.Windows.Forms.CheckBox firstRowNamesCheckBox;
        private SparrowRMSControl.SparrowControl.SparrowButton btnsave;
        private SparrowRMSControl.SparrowControl.SparrowButton btncancel;
        private System.Windows.Forms.DataGridView DgvCalender;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addTrainingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeTrainingToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}