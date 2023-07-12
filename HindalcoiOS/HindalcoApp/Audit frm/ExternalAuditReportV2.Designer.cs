
namespace HindalcoiOS.Audit_frm
{
    partial class ExternalAuditReport
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
            this.GrpCode = new System.Windows.Forms.GroupBox();
            this.CodezviewList = new System.Windows.Forms.DataGridView();
            this.AuditCodeEx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeOfAuditEx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameOfAuditEx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuditDateEx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportDateEx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpreport = new System.Windows.Forms.GroupBox();
            this.firstRowNamesCheckBox = new System.Windows.Forms.CheckBox();
            this.txtfile = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblreport = new System.Windows.Forms.Label();
            this.btnLoad = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnbrowser = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.gbxReportDetails = new System.Windows.Forms.GroupBox();
            this.tabcontrolAudit = new SparrowRMSControl.SparrowControl.SparrowTabControl();
            this.pdffile = new System.Windows.Forms.TabPage();
            this.DGVPDF = new SparrowRMSControl.SparrowControl.SparrowGrid();
            this.Download = new System.Windows.Forms.DataGridViewLinkColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuditCodePDF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnViewReport = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.GrpCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CodezviewList)).BeginInit();
            this.grpreport.SuspendLayout();
            this.gbxReportDetails.SuspendLayout();
            this.tabcontrolAudit.SuspendLayout();
            this.pdffile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPDF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GrpCode
            // 
            this.GrpCode.Controls.Add(this.CodezviewList);
            this.GrpCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpCode.Location = new System.Drawing.Point(27, 12);
            this.GrpCode.Name = "GrpCode";
            this.GrpCode.Size = new System.Drawing.Size(1178, 211);
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CodezviewList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.CodezviewList.ColumnHeadersHeight = 35;
            this.CodezviewList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.CodezviewList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AuditCodeEx,
            this.TypeOfAuditEx,
            this.NameOfAuditEx,
            this.AuditDateEx,
            this.ReportDateEx});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CodezviewList.DefaultCellStyle = dataGridViewCellStyle2;
            this.CodezviewList.EnableHeadersVisualStyles = false;
            this.CodezviewList.Location = new System.Drawing.Point(15, 26);
            this.CodezviewList.Name = "CodezviewList";
            this.CodezviewList.ReadOnly = true;
            this.CodezviewList.RowHeadersVisible = false;
            this.CodezviewList.RowHeadersWidth = 51;
            this.CodezviewList.RowTemplate.Height = 24;
            this.CodezviewList.Size = new System.Drawing.Size(1142, 172);
            this.CodezviewList.TabIndex = 0;
            this.CodezviewList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CodezviewList_CellClick);
            this.CodezviewList.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CodezviewList_CellContentDoubleClick);
            this.CodezviewList.CurrentCellChanged += new System.EventHandler(this.CodezviewList_CurrentCellChanged);
            // 
            // AuditCodeEx
            // 
            this.AuditCodeEx.HeaderText = "Audit Code";
            this.AuditCodeEx.MinimumWidth = 6;
            this.AuditCodeEx.Name = "AuditCodeEx";
            this.AuditCodeEx.ReadOnly = true;
            // 
            // TypeOfAuditEx
            // 
            this.TypeOfAuditEx.HeaderText = "Type of Audit";
            this.TypeOfAuditEx.MinimumWidth = 6;
            this.TypeOfAuditEx.Name = "TypeOfAuditEx";
            this.TypeOfAuditEx.ReadOnly = true;
            // 
            // NameOfAuditEx
            // 
            this.NameOfAuditEx.HeaderText = "Name of Audit";
            this.NameOfAuditEx.MinimumWidth = 6;
            this.NameOfAuditEx.Name = "NameOfAuditEx";
            this.NameOfAuditEx.ReadOnly = true;
            // 
            // AuditDateEx
            // 
            this.AuditDateEx.HeaderText = "Last Audit Date";
            this.AuditDateEx.MinimumWidth = 6;
            this.AuditDateEx.Name = "AuditDateEx";
            this.AuditDateEx.ReadOnly = true;
            // 
            // ReportDateEx
            // 
            this.ReportDateEx.HeaderText = "Report Upload Date";
            this.ReportDateEx.MinimumWidth = 6;
            this.ReportDateEx.Name = "ReportDateEx";
            this.ReportDateEx.ReadOnly = true;
            // 
            // grpreport
            // 
            this.grpreport.Controls.Add(this.firstRowNamesCheckBox);
            this.grpreport.Controls.Add(this.txtfile);
            this.grpreport.Controls.Add(this.lblreport);
            this.grpreport.Controls.Add(this.btnLoad);
            this.grpreport.Controls.Add(this.btnbrowser);
            this.grpreport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpreport.Location = new System.Drawing.Point(27, 223);
            this.grpreport.Name = "grpreport";
            this.grpreport.Size = new System.Drawing.Size(1178, 108);
            this.grpreport.TabIndex = 1;
            this.grpreport.TabStop = false;
            this.grpreport.Text = "Upload Report";
            // 
            // firstRowNamesCheckBox
            // 
            this.firstRowNamesCheckBox.AutoSize = true;
            this.firstRowNamesCheckBox.Location = new System.Drawing.Point(127, 78);
            this.firstRowNamesCheckBox.Name = "firstRowNamesCheckBox";
            this.firstRowNamesCheckBox.Size = new System.Drawing.Size(255, 24);
            this.firstRowNamesCheckBox.TabIndex = 6;
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
            this.txtfile.Location = new System.Drawing.Point(122, 31);
            this.txtfile.Margin = new System.Windows.Forms.Padding(4);
            this.txtfile.Multiline = false;
            this.txtfile.Name = "txtfile";
            this.txtfile.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtfile.PasswordChar = false;
            this.txtfile.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtfile.PlaceholderText = "";
            this.txtfile.Size = new System.Drawing.Size(210, 35);
            this.txtfile.TabIndex = 5;
            this.txtfile.UnderlinedStyle = false;
            // 
            // lblreport
            // 
            this.lblreport.AutoSize = true;
            this.lblreport.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblreport.Location = new System.Drawing.Point(23, 37);
            this.lblreport.Name = "lblreport";
            this.lblreport.Size = new System.Drawing.Size(72, 18);
            this.lblreport.TabIndex = 4;
            this.lblreport.Text = "File Name";
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
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(528, 32);
            this.btnLoad.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnLoad.Size = new System.Drawing.Size(129, 29);
            this.btnLoad.TabIndex = 1;
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
            this.btnbrowser.BorderRadius = 15;
            this.btnbrowser.BorderSize = 0;
            this.btnbrowser.FlatAppearance.BorderSize = 0;
            this.btnbrowser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnbrowser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnbrowser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbrowser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbrowser.ForeColor = System.Drawing.Color.White;
            this.btnbrowser.Location = new System.Drawing.Point(375, 31);
            this.btnbrowser.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnbrowser.Name = "btnbrowser";
            this.btnbrowser.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnbrowser.Size = new System.Drawing.Size(110, 30);
            this.btnbrowser.TabIndex = 0;
            this.btnbrowser.Text = "Browse";
            this.btnbrowser.TextColor = System.Drawing.Color.White;
            this.btnbrowser.UseVisualStyleBackColor = false;
            this.btnbrowser.Click += new System.EventHandler(this.btnbrowser_Click);
            // 
            // gbxReportDetails
            // 
            this.gbxReportDetails.Controls.Add(this.tabcontrolAudit);
            this.gbxReportDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxReportDetails.Location = new System.Drawing.Point(27, 337);
            this.gbxReportDetails.Name = "gbxReportDetails";
            this.gbxReportDetails.Size = new System.Drawing.Size(1178, 254);
            this.gbxReportDetails.TabIndex = 2;
            this.gbxReportDetails.TabStop = false;
            this.gbxReportDetails.Text = "Report Details";
            // 
            // tabcontrolAudit
            // 
            this.tabcontrolAudit.Controls.Add(this.pdffile);
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
            this.tabcontrolAudit.DisplayStyleProvider.CloserColorFocused = System.Drawing.Color.Empty;
            this.tabcontrolAudit.DisplayStyleProvider.CloserColorFocusedActive = System.Drawing.Color.Empty;
            this.tabcontrolAudit.DisplayStyleProvider.CloserColorHighlighted = System.Drawing.Color.Empty;
            this.tabcontrolAudit.DisplayStyleProvider.CloserColorHighlightedActive = System.Drawing.Color.Empty;
            this.tabcontrolAudit.DisplayStyleProvider.CloserColorSelected = System.Drawing.Color.Empty;
            this.tabcontrolAudit.DisplayStyleProvider.CloserColorSelectedActive = System.Drawing.Color.Empty;
            this.tabcontrolAudit.DisplayStyleProvider.CloserColorUnselected = System.Drawing.Color.Empty;
            this.tabcontrolAudit.DisplayStyleProvider.FocusTrack = false;
            this.tabcontrolAudit.DisplayStyleProvider.HotTrack = true;
            this.tabcontrolAudit.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tabcontrolAudit.DisplayStyleProvider.Opacity = 1F;
            this.tabcontrolAudit.DisplayStyleProvider.Overlap = 0;
            this.tabcontrolAudit.DisplayStyleProvider.Padding = new System.Drawing.Point(22, 4);
            this.tabcontrolAudit.DisplayStyleProvider.PageBackgroundColorDisabled = System.Drawing.SystemColors.Control;
            this.tabcontrolAudit.DisplayStyleProvider.PageBackgroundColorFocused = System.Drawing.Color.DodgerBlue;
            this.tabcontrolAudit.DisplayStyleProvider.PageBackgroundColorHighlighted = System.Drawing.SystemColors.Control;
            this.tabcontrolAudit.DisplayStyleProvider.PageBackgroundColorSelected = System.Drawing.SystemColors.ControlLightLight;
            this.tabcontrolAudit.DisplayStyleProvider.PageBackgroundColorUnselected = System.Drawing.SystemColors.Control;
            this.tabcontrolAudit.DisplayStyleProvider.SelectedTabIsLarger = true;
            this.tabcontrolAudit.DisplayStyleProvider.ShowTabCloser = false;
            this.tabcontrolAudit.DisplayStyleProvider.TabColorDisabled1 = System.Drawing.SystemColors.Control;
            this.tabcontrolAudit.DisplayStyleProvider.TabColorDisabled2 = System.Drawing.SystemColors.Control;
            this.tabcontrolAudit.DisplayStyleProvider.TabColorFocused1 = System.Drawing.Color.DodgerBlue;
            this.tabcontrolAudit.DisplayStyleProvider.TabColorFocused2 = System.Drawing.Color.DodgerBlue;
            this.tabcontrolAudit.DisplayStyleProvider.TabColorHighLighted1 = System.Drawing.SystemColors.Control;
            this.tabcontrolAudit.DisplayStyleProvider.TabColorHighLighted2 = System.Drawing.SystemColors.Control;
            this.tabcontrolAudit.DisplayStyleProvider.TabColorSelected1 = System.Drawing.SystemColors.ControlLightLight;
            this.tabcontrolAudit.DisplayStyleProvider.TabColorSelected2 = System.Drawing.SystemColors.ControlLightLight;
            this.tabcontrolAudit.DisplayStyleProvider.TabColorUnSelected1 = System.Drawing.SystemColors.Control;
            this.tabcontrolAudit.DisplayStyleProvider.TabColorUnSelected2 = System.Drawing.SystemColors.Control;
            this.tabcontrolAudit.DisplayStyleProvider.TabPageMargin = new System.Windows.Forms.Padding(0);
            this.tabcontrolAudit.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.tabcontrolAudit.DisplayStyleProvider.TextColorFocused = System.Drawing.Color.White;
            this.tabcontrolAudit.DisplayStyleProvider.TextColorHighlighted = System.Drawing.SystemColors.ControlText;
            this.tabcontrolAudit.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.tabcontrolAudit.DisplayStyleProvider.TextColorUnselected = System.Drawing.SystemColors.ControlText;
            this.tabcontrolAudit.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabcontrolAudit.HotTrack = true;
            this.tabcontrolAudit.Location = new System.Drawing.Point(15, 37);
            this.tabcontrolAudit.Name = "tabcontrolAudit";
            this.tabcontrolAudit.SelectedIndex = 0;
            this.tabcontrolAudit.SelectTabColor = System.Drawing.Color.DodgerBlue;
            this.tabcontrolAudit.SelectTabLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabcontrolAudit.Size = new System.Drawing.Size(1157, 211);
            this.tabcontrolAudit.TabColor = System.Drawing.Color.DodgerBlue;
            this.tabcontrolAudit.TabIndex = 0;
            // 
            // pdffile
            // 
            this.pdffile.Controls.Add(this.DGVPDF);
            this.pdffile.Location = new System.Drawing.Point(4, 32);
            this.pdffile.Name = "pdffile";
            this.pdffile.Padding = new System.Windows.Forms.Padding(3);
            this.pdffile.Size = new System.Drawing.Size(1149, 175);
            this.pdffile.TabIndex = 2;
            this.pdffile.Text = "PDF File";
            this.pdffile.UseVisualStyleBackColor = true;
            // 
            // DGVPDF
            // 
            this.DGVPDF.AllowUserToAddRows = false;
            this.DGVPDF.AllowUserToDeleteRows = false;
            this.DGVPDF.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVPDF.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DGVPDF.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVPDF.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVPDF.ColumnHeadersHeight = 29;
            this.DGVPDF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVPDF.ColumnNameToSum = null;
            this.DGVPDF.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Download,
            this.FileName,
            this.AuditCodePDF});
            this.DGVPDF.ColumnSum = 0D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVPDF.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGVPDF.EnableColumnSumming = false;
            this.DGVPDF.EnableHeadersVisualStyles = false;
            this.DGVPDF.Location = new System.Drawing.Point(11, 7);
            this.DGVPDF.MultiSelect = false;
            this.DGVPDF.Name = "DGVPDF";
            this.DGVPDF.RowHeadersVisible = false;
            this.DGVPDF.RowHeadersWidth = 51;
            this.DGVPDF.RowTemplate.Height = 24;
            this.DGVPDF.Size = new System.Drawing.Size(1127, 160);
            this.DGVPDF.TabIndex = 2;
            this.DGVPDF.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVPDF_CellContentClick);
            // 
            // Download
            // 
            this.Download.ActiveLinkColor = System.Drawing.Color.White;
            this.Download.LinkColor = System.Drawing.Color.DodgerBlue;
            this.Download.MinimumWidth = 6;
            this.Download.Name = "Download";
            this.Download.ReadOnly = true;
            this.Download.Text = "Click Here";
            this.Download.UseColumnTextForLinkValue = true;
            // 
            // FileName
            // 
            this.FileName.MinimumWidth = 6;
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            // 
            // AuditCodePDF
            // 
            this.AuditCodePDF.MinimumWidth = 6;
            this.AuditCodePDF.Name = "AuditCodePDF";
            this.AuditCodePDF.ReadOnly = true;
            // 
            // btnViewReport
            // 
            this.btnViewReport.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnViewReport.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnViewReport.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnViewReport.BorderRadius = 15;
            this.btnViewReport.BorderSize = 0;
            this.btnViewReport.FlatAppearance.BorderSize = 0;
            this.btnViewReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnViewReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnViewReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewReport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReport.ForeColor = System.Drawing.Color.White;
            this.btnViewReport.Location = new System.Drawing.Point(378, 97);
            this.btnViewReport.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnViewReport.Size = new System.Drawing.Size(121, 30);
            this.btnViewReport.TabIndex = 7;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.TextColor = System.Drawing.Color.White;
            this.btnViewReport.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(342, 97);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(17, 24);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // ExternalAuditReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 611);
            this.Controls.Add(this.grpreport);
            this.Controls.Add(this.gbxReportDetails);
            this.Controls.Add(this.GrpCode);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnViewReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExternalAuditReport";
            this.Text = "External Audit Report";
            this.Load += new System.EventHandler(this.ExternalAuditReport_Load);
            this.GrpCode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CodezviewList)).EndInit();
            this.grpreport.ResumeLayout(false);
            this.grpreport.PerformLayout();
            this.gbxReportDetails.ResumeLayout(false);
            this.tabcontrolAudit.ResumeLayout(false);
            this.pdffile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVPDF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpCode;
        private System.Windows.Forms.GroupBox grpreport;
        private System.Windows.Forms.GroupBox gbxReportDetails;
        private System.Windows.Forms.DataGridView CodezviewList;
        private System.Windows.Forms.Label lblreport;
        private SparrowRMSControl.SparrowControl.SparrowButton btnLoad;
        private SparrowRMSControl.SparrowControl.SparrowButton btnbrowser;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtfile;
        private System.Windows.Forms.CheckBox firstRowNamesCheckBox;
        private SparrowRMSControl.SparrowControl.SparrowTabControl tabcontrolAudit;
        private SparrowRMSControl.SparrowControl.SparrowButton btnViewReport;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage pdffile;
        private SparrowRMSControl.SparrowControl.SparrowGrid DGVPDF;
        private System.Windows.Forms.DataGridViewLinkColumn Download;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditCodePDF;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditCodeEx;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeOfAuditEx;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOfAuditEx;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditDateEx;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportDateEx;
    }
}