
namespace HindalcoiOS.Dynamic_Form
{
    partial class FileDocumentsFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ggrpInformation = new System.Windows.Forms.GroupBox();
            this.btnupload = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.txtUplodadate = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblFileDocUpldDate = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtremark = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblFileDocRemark = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.cmbArea = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.lblFileDocArea = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtnickName = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblFileDocTag = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.cmbcategory = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.lblFileDocCat = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtfileextension = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtFileName = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblFileDocName = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.grpFileDoc = new System.Windows.Forms.GroupBox();
            this.btnsave = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.DGVDocument = new System.Windows.Forms.DataGridView();
            this.ggrpInformation.SuspendLayout();
            this.grpFileDoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDocument)).BeginInit();
            this.SuspendLayout();
            // 
            // ggrpInformation
            // 
            this.ggrpInformation.Controls.Add(this.btnupload);
            this.ggrpInformation.Controls.Add(this.txtUplodadate);
            this.ggrpInformation.Controls.Add(this.lblFileDocUpldDate);
            this.ggrpInformation.Controls.Add(this.txtremark);
            this.ggrpInformation.Controls.Add(this.lblFileDocRemark);
            this.ggrpInformation.Controls.Add(this.cmbArea);
            this.ggrpInformation.Controls.Add(this.lblFileDocArea);
            this.ggrpInformation.Controls.Add(this.txtnickName);
            this.ggrpInformation.Controls.Add(this.lblFileDocTag);
            this.ggrpInformation.Controls.Add(this.cmbcategory);
            this.ggrpInformation.Controls.Add(this.lblFileDocCat);
            this.ggrpInformation.Controls.Add(this.txtfileextension);
            this.ggrpInformation.Controls.Add(this.txtFileName);
            this.ggrpInformation.Controls.Add(this.lblFileDocName);
            this.ggrpInformation.Enabled = false;
            this.ggrpInformation.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ggrpInformation.Location = new System.Drawing.Point(13, 13);
            this.ggrpInformation.Name = "ggrpInformation";
            this.ggrpInformation.Size = new System.Drawing.Size(918, 219);
            this.ggrpInformation.TabIndex = 0;
            this.ggrpInformation.TabStop = false;
            this.ggrpInformation.Text = "Document Information";
            // 
            // btnupload
            // 
            this.btnupload.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnupload.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnupload.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnupload.BorderRadius = 14;
            this.btnupload.BorderSize = 0;
            this.btnupload.FlatAppearance.BorderSize = 0;
            this.btnupload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnupload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnupload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupload.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupload.ForeColor = System.Drawing.Color.White;
            this.btnupload.Location = new System.Drawing.Point(763, 16);
            this.btnupload.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnupload.Name = "btnupload";
            this.btnupload.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnupload.Size = new System.Drawing.Size(130, 30);
            this.btnupload.TabIndex = 13;
            this.btnupload.Text = "Browse";
            this.btnupload.TextColor = System.Drawing.Color.White;
            this.btnupload.UseVisualStyleBackColor = false;
            // 
            // txtUplodadate
            // 
            this.txtUplodadate.BackColor = System.Drawing.SystemColors.Window;
            this.txtUplodadate.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtUplodadate.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtUplodadate.BorderRadius = 0;
            this.txtUplodadate.BorderSize = 1;
            this.txtUplodadate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUplodadate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUplodadate.Location = new System.Drawing.Point(701, 167);
            this.txtUplodadate.Margin = new System.Windows.Forms.Padding(4);
            this.txtUplodadate.Multiline = true;
            this.txtUplodadate.Name = "txtUplodadate";
            this.txtUplodadate.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtUplodadate.PasswordChar = false;
            this.txtUplodadate.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtUplodadate.PlaceholderText = "";
            this.txtUplodadate.Size = new System.Drawing.Size(210, 30);
            this.txtUplodadate.TabIndex = 12;
            this.txtUplodadate.UnderlinedStyle = false;
            // 
            // lblFileDocUpldDate
            // 
            this.lblFileDocUpldDate.AutoSize = true;
            this.lblFileDocUpldDate.Depth = 0;
            this.lblFileDocUpldDate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblFileDocUpldDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFileDocUpldDate.Location = new System.Drawing.Point(533, 176);
            this.lblFileDocUpldDate.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblFileDocUpldDate.Name = "lblFileDocUpldDate";
            this.lblFileDocUpldDate.Size = new System.Drawing.Size(121, 21);
            this.lblFileDocUpldDate.TabIndex = 11;
            this.lblFileDocUpldDate.Text = "Date of Upload";
            // 
            // txtremark
            // 
            this.txtremark.BackColor = System.Drawing.SystemColors.Window;
            this.txtremark.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtremark.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtremark.BorderRadius = 0;
            this.txtremark.BorderSize = 1;
            this.txtremark.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtremark.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtremark.Location = new System.Drawing.Point(702, 112);
            this.txtremark.Margin = new System.Windows.Forms.Padding(4);
            this.txtremark.Multiline = true;
            this.txtremark.Name = "txtremark";
            this.txtremark.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtremark.PasswordChar = false;
            this.txtremark.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtremark.PlaceholderText = "Enter Text";
            this.txtremark.Size = new System.Drawing.Size(210, 30);
            this.txtremark.TabIndex = 10;
            this.txtremark.UnderlinedStyle = false;
            // 
            // lblFileDocRemark
            // 
            this.lblFileDocRemark.AutoSize = true;
            this.lblFileDocRemark.Depth = 0;
            this.lblFileDocRemark.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblFileDocRemark.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFileDocRemark.Location = new System.Drawing.Point(533, 121);
            this.lblFileDocRemark.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblFileDocRemark.Name = "lblFileDocRemark";
            this.lblFileDocRemark.Size = new System.Drawing.Size(67, 21);
            this.lblFileDocRemark.TabIndex = 9;
            this.lblFileDocRemark.Text = "Remark";
            // 
            // cmbArea
            // 
            this.cmbArea.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbArea.BorderSize = 1;
            this.cmbArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbArea.ForeColor = System.Drawing.Color.DimGray;
            this.cmbArea.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbArea.ItemHeight = 22;
            this.cmbArea.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.cmbArea.ListTextColor = System.Drawing.Color.White;
            this.cmbArea.Location = new System.Drawing.Point(702, 55);
            this.cmbArea.MinimumSize = new System.Drawing.Size(40, 0);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(210, 30);
            this.cmbArea.TabIndex = 8;
            // 
            // lblFileDocArea
            // 
            this.lblFileDocArea.AutoSize = true;
            this.lblFileDocArea.Depth = 0;
            this.lblFileDocArea.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblFileDocArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFileDocArea.Location = new System.Drawing.Point(533, 64);
            this.lblFileDocArea.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblFileDocArea.Name = "lblFileDocArea";
            this.lblFileDocArea.Size = new System.Drawing.Size(45, 21);
            this.lblFileDocArea.TabIndex = 7;
            this.lblFileDocArea.Text = "Area";
            // 
            // txtnickName
            // 
            this.txtnickName.BackColor = System.Drawing.SystemColors.Window;
            this.txtnickName.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtnickName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtnickName.BorderRadius = 0;
            this.txtnickName.BorderSize = 1;
            this.txtnickName.Enabled = false;
            this.txtnickName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnickName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtnickName.Location = new System.Drawing.Point(184, 167);
            this.txtnickName.Margin = new System.Windows.Forms.Padding(4);
            this.txtnickName.Multiline = true;
            this.txtnickName.Name = "txtnickName";
            this.txtnickName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtnickName.PasswordChar = false;
            this.txtnickName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtnickName.PlaceholderText = "Enter Text";
            this.txtnickName.Size = new System.Drawing.Size(210, 30);
            this.txtnickName.TabIndex = 6;
            this.txtnickName.UnderlinedStyle = false;
            // 
            // lblFileDocTag
            // 
            this.lblFileDocTag.AutoSize = true;
            this.lblFileDocTag.Depth = 0;
            this.lblFileDocTag.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblFileDocTag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFileDocTag.Location = new System.Drawing.Point(23, 167);
            this.lblFileDocTag.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblFileDocTag.Name = "lblFileDocTag";
            this.lblFileDocTag.Size = new System.Drawing.Size(129, 21);
            this.lblFileDocTag.TabIndex = 5;
            this.lblFileDocTag.Text = "Tag (Nickname)";
            // 
            // cmbcategory
            // 
            this.cmbcategory.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbcategory.BorderSize = 1;
            this.cmbcategory.Enabled = false;
            this.cmbcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcategory.ForeColor = System.Drawing.Color.DimGray;
            this.cmbcategory.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbcategory.ItemHeight = 22;
            this.cmbcategory.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.cmbcategory.ListTextColor = System.Drawing.Color.White;
            this.cmbcategory.Location = new System.Drawing.Point(184, 112);
            this.cmbcategory.MinimumSize = new System.Drawing.Size(40, 0);
            this.cmbcategory.Name = "cmbcategory";
            this.cmbcategory.Size = new System.Drawing.Size(210, 30);
            this.cmbcategory.TabIndex = 4;
            // 
            // lblFileDocCat
            // 
            this.lblFileDocCat.AutoSize = true;
            this.lblFileDocCat.Depth = 0;
            this.lblFileDocCat.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblFileDocCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFileDocCat.Location = new System.Drawing.Point(23, 116);
            this.lblFileDocCat.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblFileDocCat.Name = "lblFileDocCat";
            this.lblFileDocCat.Size = new System.Drawing.Size(76, 21);
            this.lblFileDocCat.TabIndex = 3;
            this.lblFileDocCat.Text = "Category";
            // 
            // txtfileextension
            // 
            this.txtfileextension.BackColor = System.Drawing.SystemColors.Window;
            this.txtfileextension.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtfileextension.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtfileextension.BorderRadius = 0;
            this.txtfileextension.BorderSize = 1;
            this.txtfileextension.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfileextension.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtfileextension.Location = new System.Drawing.Point(394, 55);
            this.txtfileextension.Margin = new System.Windows.Forms.Padding(4);
            this.txtfileextension.Multiline = true;
            this.txtfileextension.Name = "txtfileextension";
            this.txtfileextension.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtfileextension.PasswordChar = false;
            this.txtfileextension.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtfileextension.PlaceholderText = "";
            this.txtfileextension.Size = new System.Drawing.Size(76, 30);
            this.txtfileextension.TabIndex = 2;
            this.txtfileextension.UnderlinedStyle = false;
            // 
            // txtFileName
            // 
            this.txtFileName.BackColor = System.Drawing.SystemColors.Window;
            this.txtFileName.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtFileName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtFileName.BorderRadius = 0;
            this.txtFileName.BorderSize = 1;
            this.txtFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFileName.Location = new System.Drawing.Point(184, 55);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFileName.Multiline = true;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtFileName.PasswordChar = false;
            this.txtFileName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtFileName.PlaceholderText = "";
            this.txtFileName.Size = new System.Drawing.Size(210, 30);
            this.txtFileName.TabIndex = 1;
            this.txtFileName.UnderlinedStyle = false;
            // 
            // lblFileDocName
            // 
            this.lblFileDocName.AutoSize = true;
            this.lblFileDocName.Depth = 0;
            this.lblFileDocName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblFileDocName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFileDocName.Location = new System.Drawing.Point(23, 63);
            this.lblFileDocName.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblFileDocName.Name = "lblFileDocName";
            this.lblFileDocName.Size = new System.Drawing.Size(82, 21);
            this.lblFileDocName.TabIndex = 0;
            this.lblFileDocName.Text = "File name";
            // 
            // grpFileDoc
            // 
            this.grpFileDoc.Controls.Add(this.btnsave);
            this.grpFileDoc.Controls.Add(this.DGVDocument);
            this.grpFileDoc.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFileDoc.Location = new System.Drawing.Point(13, 248);
            this.grpFileDoc.Name = "grpFileDoc";
            this.grpFileDoc.Size = new System.Drawing.Size(918, 250);
            this.grpFileDoc.TabIndex = 1;
            this.grpFileDoc.TabStop = false;
            this.grpFileDoc.Text = "The Document Load List";
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnsave.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnsave.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnsave.BorderRadius = 14;
            this.btnsave.BorderSize = 0;
            this.btnsave.FlatAppearance.BorderSize = 0;
            this.btnsave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnsave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Location = new System.Drawing.Point(763, 201);
            this.btnsave.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnsave.Name = "btnsave";
            this.btnsave.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnsave.Size = new System.Drawing.Size(130, 30);
            this.btnsave.TabIndex = 1;
            this.btnsave.Text = "Save Info";
            this.btnsave.TextColor = System.Drawing.Color.White;
            this.btnsave.UseVisualStyleBackColor = false;
            // 
            // DGVDocument
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVDocument.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVDocument.ColumnHeadersHeight = 35;
            this.DGVDocument.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVDocument.EnableHeadersVisualStyles = false;
            this.DGVDocument.Location = new System.Drawing.Point(6, 34);
            this.DGVDocument.Name = "DGVDocument";
            this.DGVDocument.RowHeadersWidth = 51;
            this.DGVDocument.RowTemplate.Height = 24;
            this.DGVDocument.Size = new System.Drawing.Size(905, 160);
            this.DGVDocument.TabIndex = 0;
            // 
            // FileDocumentsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 510);
            this.Controls.Add(this.grpFileDoc);
            this.Controls.Add(this.ggrpInformation);
            this.MaximizeBox = false;
            this.Name = "FileDocumentsFrm";
            this.Text = "File Documents Form";
            this.ggrpInformation.ResumeLayout(false);
            this.ggrpInformation.PerformLayout();
            this.grpFileDoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDocument)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ggrpInformation;
        private SparrowRMSControl.SparrowControl.SparrowButton btnupload;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtUplodadate;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblFileDocUpldDate;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtremark;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblFileDocRemark;
        private SparrowRMSControl.SparrowControl.SparrowComboBox cmbArea;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblFileDocArea;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtnickName;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblFileDocTag;
        private SparrowRMSControl.SparrowControl.SparrowComboBox cmbcategory;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblFileDocCat;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtfileextension;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtFileName;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblFileDocName;
        private System.Windows.Forms.GroupBox grpFileDoc;
        private SparrowRMSControl.SparrowControl.SparrowButton btnsave;
        private System.Windows.Forms.DataGridView DGVDocument;
    }
}