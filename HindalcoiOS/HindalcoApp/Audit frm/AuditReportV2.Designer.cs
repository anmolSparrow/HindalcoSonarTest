
namespace HindalcoiOS.Audit_frm
{
    partial class AuditReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GrpCode = new System.Windows.Forms.GroupBox();
            this.CodezviewList = new System.Windows.Forms.DataGridView();
            this.AuditCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameOfAudit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeofAudit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuditDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NextAuditDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new SparrowRMSControl.SparrowControl.SparrowCircularpictureBox();
            this.grpreport = new System.Windows.Forms.GroupBox();
            this.btnViewReport = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnLoad = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnbrowser = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.firstRowNamesCheckBox = new SparrowRMSControl.SparrowControl.SparrowCheckBox();
            this.txtfile = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblreport = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.bunifuGroupBox3 = new System.Windows.Forms.GroupBox();
            this.tabcontrolAudit = new SparrowRMSControl.SparrowControl.SparrowTabControl();
            this.pdffile = new System.Windows.Forms.TabPage();
            this.DGVPDF = new System.Windows.Forms.DataGridView();
            this.Download = new System.Windows.Forms.DataGridViewLinkColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuditCodePDF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrpCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CodezviewList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpreport.SuspendLayout();
            this.bunifuGroupBox3.SuspendLayout();
            this.tabcontrolAudit.SuspendLayout();
            this.pdffile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPDF)).BeginInit();
            this.SuspendLayout();
            // 
            // GrpCode
            // 
            this.GrpCode.Controls.Add(this.CodezviewList);
            this.GrpCode.Controls.Add(this.pictureBox1);
            this.GrpCode.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpCode.Location = new System.Drawing.Point(13, 13);
            this.GrpCode.Name = "GrpCode";
            this.GrpCode.Size = new System.Drawing.Size(1084, 221);
            this.GrpCode.TabIndex = 0;
            this.GrpCode.TabStop = false;
            this.GrpCode.Text = "Audit Code List";
            // 
            // CodezviewList
            // 
            this.CodezviewList.AllowUserToAddRows = false;
            this.CodezviewList.AllowUserToDeleteRows = false;
            this.CodezviewList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CodezviewList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.CodezviewList.ColumnHeadersHeight = 35;
            this.CodezviewList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.CodezviewList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AuditCode,
            this.NameOfAudit,
            this.TypeofAudit,
            this.AuditDate,
            this.NextAuditDate,
            this.ReportDate});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CodezviewList.DefaultCellStyle = dataGridViewCellStyle2;
            this.CodezviewList.EnableHeadersVisualStyles = false;
            this.CodezviewList.Location = new System.Drawing.Point(7, 23);
            this.CodezviewList.Name = "CodezviewList";
            this.CodezviewList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CodezviewList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.CodezviewList.RowHeadersVisible = false;
            this.CodezviewList.RowHeadersWidth = 51;
            this.CodezviewList.RowTemplate.Height = 24;
            this.CodezviewList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CodezviewList.Size = new System.Drawing.Size(1081, 190);
            this.CodezviewList.TabIndex = 0;
            this.CodezviewList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CodezviewList_CellClick);
            this.CodezviewList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CodezviewList_CellContentDoubleClick);
            this.CodezviewList.CurrentCellChanged += new System.EventHandler(this.CodezviewList_CurrentCellChanged);
            // 
            // AuditCode
            // 
            this.AuditCode.HeaderText = "Audit Code";
            this.AuditCode.MinimumWidth = 6;
            this.AuditCode.Name = "AuditCode";
            this.AuditCode.ReadOnly = true;
            // 
            // NameOfAudit
            // 
            this.NameOfAudit.HeaderText = "Name Of Audit";
            this.NameOfAudit.MinimumWidth = 6;
            this.NameOfAudit.Name = "NameOfAudit";
            this.NameOfAudit.ReadOnly = true;
            // 
            // TypeofAudit
            // 
            this.TypeofAudit.HeaderText = "Type of Audit";
            this.TypeofAudit.MinimumWidth = 6;
            this.TypeofAudit.Name = "TypeofAudit";
            this.TypeofAudit.ReadOnly = true;
            // 
            // AuditDate
            // 
            this.AuditDate.HeaderText = "Last Audit Date";
            this.AuditDate.MinimumWidth = 6;
            this.AuditDate.Name = "AuditDate";
            this.AuditDate.ReadOnly = true;
            // 
            // NextAuditDate
            // 
            this.NextAuditDate.HeaderText = "Next Audit Date";
            this.NextAuditDate.MinimumWidth = 6;
            this.NextAuditDate.Name = "NextAuditDate";
            this.NextAuditDate.ReadOnly = true;
            // 
            // ReportDate
            // 
            this.ReportDate.HeaderText = "Report Upload Date";
            this.ReportDate.MinimumWidth = 6;
            this.ReportDate.Name = "ReportDate";
            this.ReportDate.ReadOnly = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.pictureBox1.BorderColor = System.Drawing.Color.RoyalBlue;
            this.pictureBox1.BorderColor2 = System.Drawing.Color.HotPink;
            this.pictureBox1.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.pictureBox1.BorderSize = 2;
            this.pictureBox1.GradientAngle = 50F;
            this.pictureBox1.Location = new System.Drawing.Point(357, 103);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(14, 14);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // grpreport
            // 
            this.grpreport.Controls.Add(this.btnViewReport);
            this.grpreport.Controls.Add(this.btnLoad);
            this.grpreport.Controls.Add(this.btnbrowser);
            this.grpreport.Controls.Add(this.firstRowNamesCheckBox);
            this.grpreport.Controls.Add(this.txtfile);
            this.grpreport.Controls.Add(this.lblreport);
            this.grpreport.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpreport.Location = new System.Drawing.Point(13, 243);
            this.grpreport.Name = "grpreport";
            this.grpreport.Size = new System.Drawing.Size(1094, 118);
            this.grpreport.TabIndex = 1;
            this.grpreport.TabStop = false;
            this.grpreport.Text = "Upload Report";
            // 
            // btnViewReport
            // 
            this.btnViewReport.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnViewReport.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnViewReport.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnViewReport.BorderRadius = 14;
            this.btnViewReport.BorderSize = 0;
            this.btnViewReport.FlatAppearance.BorderSize = 0;
            this.btnViewReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnViewReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnViewReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewReport.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReport.ForeColor = System.Drawing.Color.White;
            this.btnViewReport.Location = new System.Drawing.Point(547, 74);
            this.btnViewReport.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnViewReport.Size = new System.Drawing.Size(146, 30);
            this.btnViewReport.TabIndex = 7;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.TextColor = System.Drawing.Color.White;
            this.btnViewReport.UseVisualStyleBackColor = false;
            this.btnViewReport.Visible = false;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
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
            this.btnLoad.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(547, 32);
            this.btnLoad.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnLoad.Size = new System.Drawing.Size(146, 30);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Load Report";
            this.btnLoad.TextColor = System.Drawing.Color.White;
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
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
            this.btnbrowser.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbrowser.ForeColor = System.Drawing.Color.White;
            this.btnbrowser.Location = new System.Drawing.Point(402, 22);
            this.btnbrowser.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnbrowser.Name = "btnbrowser";
            this.btnbrowser.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnbrowser.Size = new System.Drawing.Size(94, 30);
            this.btnbrowser.TabIndex = 3;
            this.btnbrowser.Text = "Browse";
            this.btnbrowser.TextColor = System.Drawing.Color.White;
            this.btnbrowser.UseVisualStyleBackColor = false;
            this.btnbrowser.Click += new System.EventHandler(this.btnbrowser_Click);
            // 
            // firstRowNamesCheckBox
            // 
            this.firstRowNamesCheckBox.AutoSize = true;
            this.firstRowNamesCheckBox.Depth = 0;
            this.firstRowNamesCheckBox.Location = new System.Drawing.Point(154, 68);
            this.firstRowNamesCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.firstRowNamesCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.firstRowNamesCheckBox.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.firstRowNamesCheckBox.Name = "firstRowNamesCheckBox";
            this.firstRowNamesCheckBox.Ripple = true;
            this.firstRowNamesCheckBox.Size = new System.Drawing.Size(298, 30);
            this.firstRowNamesCheckBox.TabIndex = 2;
            this.firstRowNamesCheckBox.Text = "First Row Contains Column Names";
            this.firstRowNamesCheckBox.UseVisualStyleBackColor = true;
            this.firstRowNamesCheckBox.Visible = false;
            // 
            // txtfile
            // 
            this.txtfile.BackColor = System.Drawing.SystemColors.Window;
            this.txtfile.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtfile.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtfile.BorderRadius = 0;
            this.txtfile.BorderSize = 1;
            this.txtfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtfile.Location = new System.Drawing.Point(161, 23);
            this.txtfile.Margin = new System.Windows.Forms.Padding(4);
            this.txtfile.Multiline = true;
            this.txtfile.Name = "txtfile";
            this.txtfile.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtfile.PasswordChar = false;
            this.txtfile.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtfile.PlaceholderText = "Enter Text";
            this.txtfile.Size = new System.Drawing.Size(210, 30);
            this.txtfile.TabIndex = 1;
            this.txtfile.UnderlinedStyle = false;
            // 
            // lblreport
            // 
            this.lblreport.AutoSize = true;
            this.lblreport.Depth = 0;
            this.lblreport.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblreport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblreport.Location = new System.Drawing.Point(7, 32);
            this.lblreport.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblreport.Name = "lblreport";
            this.lblreport.Size = new System.Drawing.Size(84, 21);
            this.lblreport.TabIndex = 0;
            this.lblreport.Text = "File Name";
            // 
            // bunifuGroupBox3
            // 
            this.bunifuGroupBox3.Controls.Add(this.tabcontrolAudit);
            this.bunifuGroupBox3.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuGroupBox3.Location = new System.Drawing.Point(13, 367);
            this.bunifuGroupBox3.Name = "bunifuGroupBox3";
            this.bunifuGroupBox3.Size = new System.Drawing.Size(1094, 379);
            this.bunifuGroupBox3.TabIndex = 2;
            this.bunifuGroupBox3.TabStop = false;
            this.bunifuGroupBox3.Text = "Report Details";
            // 
            // tabcontrolAudit
            // 
            this.tabcontrolAudit.Controls.Add(this.pdffile);
            this.tabcontrolAudit.Cursor = System.Windows.Forms.Cursors.Arrow;
            // 
            // 
            // 
            this.tabcontrolAudit.DisplayStyleProvider.BlendStyle = SparrowRMSControl.SparrowControl.BlendStyle.Normal;
            this.tabcontrolAudit.DisplayStyleProvider.BorderColorDisabled = System.Drawing.SystemColors.ControlLight;
            this.tabcontrolAudit.DisplayStyleProvider.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.tabcontrolAudit.DisplayStyleProvider.BorderColorHighlighted = System.Drawing.SystemColors.ControlDark;
            this.tabcontrolAudit.DisplayStyleProvider.BorderColorSelected = System.Drawing.SystemColors.ControlDark;
            this.tabcontrolAudit.DisplayStyleProvider.BorderColorUnselected = System.Drawing.SystemColors.ControlDark;
            this.tabcontrolAudit.DisplayStyleProvider.CloserButtonFillColorFocused = System.Drawing.Color.Empty;
            this.tabcontrolAudit.DisplayStyleProvider.CloserButtonFillColorFocusedActive = System.Drawing.Color.Empty;
            this.tabcontrolAudit.DisplayStyleProvider.CloserButtonFillColorHighlighted = System.Drawing.Color.Empty;
            this.tabcontrolAudit.DisplayStyleProvider.CloserButtonFillColorHighlightedActive = System.Drawing.Color.Empty;
            this.tabcontrolAudit.DisplayStyleProvider.CloserButtonFillColorSelected = System.Drawing.Color.Empty;
            this.tabcontrolAudit.DisplayStyleProvider.CloserButtonFillColorSelectedActive = System.Drawing.Color.Empty;
            this.tabcontrolAudit.DisplayStyleProvider.CloserButtonFillColorUnselected = System.Drawing.Color.Empty;
            this.tabcontrolAudit.DisplayStyleProvider.CloserButtonOutlineColorFocused = System.Drawing.Color.Empty;
            this.tabcontrolAudit.DisplayStyleProvider.CloserButtonOutlineColorFocusedActive = System.Drawing.Color.Empty;
            this.tabcontrolAudit.DisplayStyleProvider.CloserButtonOutlineColorHighlighted = System.Drawing.Color.Empty;
            this.tabcontrolAudit.DisplayStyleProvider.CloserButtonOutlineColorHighlightedActive = System.Drawing.Color.Empty;
            this.tabcontrolAudit.DisplayStyleProvider.CloserButtonOutlineColorSelected = System.Drawing.Color.Empty;
            this.tabcontrolAudit.DisplayStyleProvider.CloserButtonOutlineColorSelectedActive = System.Drawing.Color.Empty;
            this.tabcontrolAudit.DisplayStyleProvider.CloserButtonOutlineColorUnselected = System.Drawing.Color.Empty;
            this.tabcontrolAudit.DisplayStyleProvider.CloserColorFocused = System.Drawing.SystemColors.ControlDark;
            this.tabcontrolAudit.DisplayStyleProvider.CloserColorFocusedActive = System.Drawing.SystemColors.ControlDark;
            this.tabcontrolAudit.DisplayStyleProvider.CloserColorHighlighted = System.Drawing.SystemColors.ControlDark;
            this.tabcontrolAudit.DisplayStyleProvider.CloserColorHighlightedActive = System.Drawing.SystemColors.ControlDark;
            this.tabcontrolAudit.DisplayStyleProvider.CloserColorSelected = System.Drawing.SystemColors.ControlDark;
            this.tabcontrolAudit.DisplayStyleProvider.CloserColorSelectedActive = System.Drawing.SystemColors.ControlDark;
            this.tabcontrolAudit.DisplayStyleProvider.CloserColorUnselected = System.Drawing.Color.Empty;
            this.tabcontrolAudit.DisplayStyleProvider.FocusTrack = false;
            this.tabcontrolAudit.DisplayStyleProvider.HotTrack = true;
            this.tabcontrolAudit.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tabcontrolAudit.DisplayStyleProvider.Opacity = 1F;
            this.tabcontrolAudit.DisplayStyleProvider.Overlap = 0;
            this.tabcontrolAudit.DisplayStyleProvider.Padding = new System.Drawing.Point(6, 3);
            this.tabcontrolAudit.DisplayStyleProvider.PageBackgroundColorDisabled = System.Drawing.SystemColors.Control;
            this.tabcontrolAudit.DisplayStyleProvider.PageBackgroundColorFocused = System.Drawing.Color.DodgerBlue;
            this.tabcontrolAudit.DisplayStyleProvider.PageBackgroundColorHighlighted = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.tabcontrolAudit.DisplayStyleProvider.PageBackgroundColorSelected = System.Drawing.SystemColors.ControlLightLight;
            this.tabcontrolAudit.DisplayStyleProvider.PageBackgroundColorUnselected = System.Drawing.SystemColors.Control;
            this.tabcontrolAudit.DisplayStyleProvider.Radius = 2;
            this.tabcontrolAudit.DisplayStyleProvider.SelectedTabIsLarger = true;
            this.tabcontrolAudit.DisplayStyleProvider.ShowTabCloser = false;
            this.tabcontrolAudit.DisplayStyleProvider.TabColorDisabled1 = System.Drawing.SystemColors.Control;
            this.tabcontrolAudit.DisplayStyleProvider.TabColorDisabled2 = System.Drawing.SystemColors.Control;
            this.tabcontrolAudit.DisplayStyleProvider.TabColorFocused1 = System.Drawing.Color.DodgerBlue;
            this.tabcontrolAudit.DisplayStyleProvider.TabColorFocused2 = System.Drawing.Color.DodgerBlue;
            this.tabcontrolAudit.DisplayStyleProvider.TabColorHighLighted1 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.tabcontrolAudit.DisplayStyleProvider.TabColorHighLighted2 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.tabcontrolAudit.DisplayStyleProvider.TabColorSelected1 = System.Drawing.SystemColors.ControlLightLight;
            this.tabcontrolAudit.DisplayStyleProvider.TabColorSelected2 = System.Drawing.SystemColors.ControlLightLight;
            this.tabcontrolAudit.DisplayStyleProvider.TabColorUnSelected1 = System.Drawing.SystemColors.Control;
            this.tabcontrolAudit.DisplayStyleProvider.TabColorUnSelected2 = System.Drawing.SystemColors.Control;
            this.tabcontrolAudit.DisplayStyleProvider.TabPageMargin = new System.Windows.Forms.Padding(1);
            this.tabcontrolAudit.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.tabcontrolAudit.DisplayStyleProvider.TextColorFocused = System.Drawing.Color.White;
            this.tabcontrolAudit.DisplayStyleProvider.TextColorHighlighted = System.Drawing.SystemColors.ControlText;
            this.tabcontrolAudit.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.tabcontrolAudit.DisplayStyleProvider.TextColorUnselected = System.Drawing.SystemColors.ControlText;
            this.tabcontrolAudit.HotTrack = true;
            this.tabcontrolAudit.Location = new System.Drawing.Point(11, 22);
            this.tabcontrolAudit.Name = "tabcontrolAudit";
            this.tabcontrolAudit.SelectedIndex = 0;
            this.tabcontrolAudit.SelectTabColor = System.Drawing.Color.DodgerBlue;
            this.tabcontrolAudit.SelectTabLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabcontrolAudit.Size = new System.Drawing.Size(1077, 304);
            this.tabcontrolAudit.TabColor = System.Drawing.Color.DodgerBlue;
            this.tabcontrolAudit.TabIndex = 3;
            // 
            // pdffile
            // 
            this.pdffile.Controls.Add(this.DGVPDF);
            this.pdffile.Location = new System.Drawing.Point(4, 30);
            this.pdffile.Name = "pdffile";
            this.pdffile.Padding = new System.Windows.Forms.Padding(3);
            this.pdffile.Size = new System.Drawing.Size(1069, 270);
            this.pdffile.TabIndex = 2;
            this.pdffile.Text = "PDF File";
            this.pdffile.UseVisualStyleBackColor = true;
            // 
            // DGVPDF
            // 
            this.DGVPDF.AllowUserToAddRows = false;
            this.DGVPDF.AllowUserToDeleteRows = false;
            this.DGVPDF.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVPDF.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVPDF.ColumnHeadersHeight = 35;
            this.DGVPDF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVPDF.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Download,
            this.FileName,
            this.AuditCodePDF});
            this.DGVPDF.EnableHeadersVisualStyles = false;
            this.DGVPDF.Location = new System.Drawing.Point(7, 7);
            this.DGVPDF.Name = "DGVPDF";
            this.DGVPDF.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVPDF.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DGVPDF.RowHeadersVisible = false;
            this.DGVPDF.RowHeadersWidth = 51;
            this.DGVPDF.RowTemplate.Height = 24;
            this.DGVPDF.Size = new System.Drawing.Size(1056, 243);
            this.DGVPDF.TabIndex = 0;
            this.DGVPDF.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVPDF_CellContentClick);
            // 
            // Download
            // 
            this.Download.ActiveLinkColor = System.Drawing.Color.White;
            this.Download.HeaderText = "Download";
            this.Download.LinkColor = System.Drawing.Color.DodgerBlue;
            this.Download.MinimumWidth = 6;
            this.Download.Name = "Download";
            this.Download.ReadOnly = true;
            this.Download.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Download.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Download.Text = "Click Here";
            this.Download.ToolTipText = "Download Uploaded File";
            this.Download.UseColumnTextForLinkValue = true;
            this.Download.VisitedLinkColor = System.Drawing.Color.YellowGreen;
            // 
            // FileName
            // 
            this.FileName.HeaderText = "File Name";
            this.FileName.MinimumWidth = 6;
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            // 
            // AuditCodePDF
            // 
            this.AuditCodePDF.HeaderText = "Audit Code";
            this.AuditCodePDF.MinimumWidth = 6;
            this.AuditCodePDF.Name = "AuditCodePDF";
            this.AuditCodePDF.ReadOnly = true;
            // 
            // AuditReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 700);
            this.Controls.Add(this.bunifuGroupBox3);
            this.Controls.Add(this.grpreport);
            this.Controls.Add(this.GrpCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "AuditReport";
            this.Text = "Audit Report";
            this.Load += new System.EventHandler(this.AuditReport_Load);
            this.GrpCode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CodezviewList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpreport.ResumeLayout(false);
            this.grpreport.PerformLayout();
            this.bunifuGroupBox3.ResumeLayout(false);
            this.tabcontrolAudit.ResumeLayout(false);
            this.pdffile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVPDF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpCode;
        private System.Windows.Forms.DataGridView CodezviewList;
        private System.Windows.Forms.GroupBox grpreport;
        private SparrowRMSControl.SparrowControl.SparrowButton btnViewReport;
        private SparrowRMSControl.SparrowControl.SparrowButton btnLoad;
        private SparrowRMSControl.SparrowControl.SparrowButton btnbrowser;
        private SparrowRMSControl.SparrowControl.SparrowCheckBox firstRowNamesCheckBox;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtfile;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblreport;
        private System.Windows.Forms.GroupBox bunifuGroupBox3;
        private SparrowRMSControl.SparrowControl.SparrowTabControl tabcontrolAudit;
        private System.Windows.Forms.TabPage pdffile;
        private System.Windows.Forms.DataGridView DGVPDF;
        private SparrowRMSControl.SparrowControl.SparrowCircularpictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOfAudit;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeofAudit;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NextAuditDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportDate;
        private System.Windows.Forms.DataGridViewLinkColumn Download;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditCodePDF;
    }
}