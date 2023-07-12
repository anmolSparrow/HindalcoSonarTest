
namespace HindalcoiOS.Audit_frm
{
    partial class ExternalAuditCalendar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GrpReport = new System.Windows.Forms.GroupBox();
            this.DgvViewCalendar = new SparrowRMSControl.SparrowControl.SparrowGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLoad = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnbrowser = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.firstRowNamesCheckBox = new SparrowRMSControl.SparrowControl.SparrowCheckBox();
            this.sheetCombo = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.bunifuLabel2 = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtfile = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.bunifuLabel1 = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.tabExternalaudit = new System.Windows.Forms.GroupBox();
            this.DGVAuditCal = new SparrowRMSControl.SparrowControl.SparrowGrid();
            this.SrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuditCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameofAudit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeofAudit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThirdPartyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Individual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuditOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnscope = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Prerequisite = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GrpReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvViewCalendar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabExternalaudit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAuditCal)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpReport
            // 
            this.GrpReport.Controls.Add(this.DgvViewCalendar);
            this.GrpReport.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpReport.Location = new System.Drawing.Point(13, 13);
            this.GrpReport.Name = "GrpReport";
            this.GrpReport.Size = new System.Drawing.Size(996, 191);
            this.GrpReport.TabIndex = 0;
            this.GrpReport.TabStop = false;
            this.GrpReport.Text = "View Calendar";
            // 
            // DgvViewCalendar
            // 
            this.DgvViewCalendar.AllowUserToAddRows = false;
            this.DgvViewCalendar.AllowUserToDeleteRows = false;
            this.DgvViewCalendar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvViewCalendar.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvViewCalendar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvViewCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvViewCalendar.ColumnNameToSum = null;
            this.DgvViewCalendar.ColumnSum = 0D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvViewCalendar.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvViewCalendar.EnableColumnSumming = false;
            this.DgvViewCalendar.EnableHeadersVisualStyles = false;
            this.DgvViewCalendar.Location = new System.Drawing.Point(7, 23);
            this.DgvViewCalendar.MultiSelect = false;
            this.DgvViewCalendar.Name = "DgvViewCalendar";
            this.DgvViewCalendar.RowHeadersVisible = false;
            this.DgvViewCalendar.RowHeadersWidth = 51;
            this.DgvViewCalendar.RowTemplate.Height = 24;
            this.DgvViewCalendar.Size = new System.Drawing.Size(983, 162);
            this.DgvViewCalendar.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Controls.Add(this.btnbrowser);
            this.groupBox1.Controls.Add(this.firstRowNamesCheckBox);
            this.groupBox1.Controls.Add(this.sheetCombo);
            this.groupBox1.Controls.Add(this.bunifuLabel2);
            this.groupBox1.Controls.Add(this.txtfile);
            this.groupBox1.Controls.Add(this.bunifuLabel1);
            this.groupBox1.Location = new System.Drawing.Point(13, 211);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(996, 149);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Upload Report";
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
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(774, 107);
            this.btnLoad.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnLoad.Size = new System.Drawing.Size(124, 30);
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
            this.btnbrowser.ForeColor = System.Drawing.Color.White;
            this.btnbrowser.Location = new System.Drawing.Point(225, 107);
            this.btnbrowser.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnbrowser.Name = "btnbrowser";
            this.btnbrowser.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnbrowser.Size = new System.Drawing.Size(124, 30);
            this.btnbrowser.TabIndex = 5;
            this.btnbrowser.Text = "Browse";
            this.btnbrowser.TextColor = System.Drawing.Color.White;
            this.btnbrowser.UseVisualStyleBackColor = false;
            this.btnbrowser.Click += new System.EventHandler(this.btnbrowser_Click);
            // 
            // firstRowNamesCheckBox
            // 
            this.firstRowNamesCheckBox.AutoSize = true;
            this.firstRowNamesCheckBox.Depth = 0;
            this.firstRowNamesCheckBox.Location = new System.Drawing.Point(192, 73);
            this.firstRowNamesCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.firstRowNamesCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.firstRowNamesCheckBox.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.firstRowNamesCheckBox.Name = "firstRowNamesCheckBox";
            this.firstRowNamesCheckBox.Ripple = true;
            this.firstRowNamesCheckBox.Size = new System.Drawing.Size(286, 30);
            this.firstRowNamesCheckBox.TabIndex = 4;
            this.firstRowNamesCheckBox.Text = "First row contains column names";
            this.firstRowNamesCheckBox.UseVisualStyleBackColor = true;
            // 
            // sheetCombo
            // 
            this.sheetCombo.BorderColor = System.Drawing.Color.DodgerBlue;
            this.sheetCombo.BorderSize = 1;
            this.sheetCombo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.sheetCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sheetCombo.FormattingEnabled = true;
            this.sheetCombo.IconColor = System.Drawing.Color.DodgerBlue;
            this.sheetCombo.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.sheetCombo.ListTextColor = System.Drawing.Color.White;
            this.sheetCombo.Location = new System.Drawing.Point(678, 38);
            this.sheetCombo.Name = "sheetCombo";
            this.sheetCombo.Size = new System.Drawing.Size(220, 27);
            this.sheetCombo.TabIndex = 3;
            // 
            // bunifuLabel2
            // 
            this.bunifuLabel2.AutoSize = true;
            this.bunifuLabel2.Depth = 0;
            this.bunifuLabel2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel2.Location = new System.Drawing.Point(507, 44);
            this.bunifuLabel2.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.bunifuLabel2.Name = "bunifuLabel2";
            this.bunifuLabel2.Size = new System.Drawing.Size(111, 21);
            this.bunifuLabel2.TabIndex = 2;
            this.bunifuLabel2.Text = "Choose Sheet";
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
            this.txtfile.Location = new System.Drawing.Point(192, 35);
            this.txtfile.Margin = new System.Windows.Forms.Padding(4);
            this.txtfile.Multiline = true;
            this.txtfile.Name = "txtfile";
            this.txtfile.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtfile.PasswordChar = false;
            this.txtfile.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtfile.PlaceholderText = "";
            this.txtfile.Size = new System.Drawing.Size(252, 30);
            this.txtfile.TabIndex = 1;
            this.txtfile.UnderlinedStyle = false;
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AutoSize = true;
            this.bunifuLabel1.Depth = 0;
            this.bunifuLabel1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel1.Location = new System.Drawing.Point(7, 44);
            this.bunifuLabel1.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.Size = new System.Drawing.Size(84, 21);
            this.bunifuLabel1.TabIndex = 0;
            this.bunifuLabel1.Text = "File Name";
            // 
            // tabExternalaudit
            // 
            this.tabExternalaudit.Controls.Add(this.DGVAuditCal);
            this.tabExternalaudit.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabExternalaudit.Location = new System.Drawing.Point(13, 367);
            this.tabExternalaudit.Name = "tabExternalaudit";
            this.tabExternalaudit.Size = new System.Drawing.Size(997, 286);
            this.tabExternalaudit.TabIndex = 2;
            this.tabExternalaudit.TabStop = false;
            this.tabExternalaudit.Text = "Audit Calendar";
            // 
            // DGVAuditCal
            // 
            this.DGVAuditCal.AllowUserToAddRows = false;
            this.DGVAuditCal.AllowUserToDeleteRows = false;
            this.DGVAuditCal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DGVAuditCal.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVAuditCal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVAuditCal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVAuditCal.ColumnNameToSum = null;
            this.DGVAuditCal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SrNo,
            this.AuditCode,
            this.NameofAudit,
            this.TypeofAudit,
            this.ProcessName,
            this.Area,
            this.FDate,
            this.TDate,
            this.ThirdPartyName,
            this.Department,
            this.Individual,
            this.AuditOwner,
            this.btnscope,
            this.Prerequisite,
            this.Remark,
            this.Status});
            this.DGVAuditCal.ColumnSum = 0D;
            this.DGVAuditCal.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVAuditCal.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGVAuditCal.EnableColumnSumming = false;
            this.DGVAuditCal.EnableHeadersVisualStyles = false;
            this.DGVAuditCal.Location = new System.Drawing.Point(7, 23);
            this.DGVAuditCal.MultiSelect = false;
            this.DGVAuditCal.Name = "DGVAuditCal";
            this.DGVAuditCal.RowHeadersVisible = false;
            this.DGVAuditCal.RowHeadersWidth = 51;
            this.DGVAuditCal.RowTemplate.Height = 24;
            this.DGVAuditCal.Size = new System.Drawing.Size(983, 248);
            this.DGVAuditCal.TabIndex = 0;
            this.DGVAuditCal.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVAuditCal_CellClick);
            this.DGVAuditCal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVAuditCal_CellContentClick);
            this.DGVAuditCal.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVAuditCal_CellEndEdit);
            this.DGVAuditCal.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVAuditCal_CellEnter);
            this.DGVAuditCal.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVAuditCal_CellValueChanged);
            this.DGVAuditCal.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DGVAuditCal_ColumnWidthChanged);
            this.DGVAuditCal.CurrentCellDirtyStateChanged += new System.EventHandler(this.DGVAuditCal_CurrentCellDirtyStateChanged);
            this.DGVAuditCal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGVAuditCal_KeyDown);
            // 
            // SrNo
            // 
            this.SrNo.MinimumWidth = 6;
            this.SrNo.Name = "SrNo";
            this.SrNo.Width = 125;
            // 
            // AuditCode
            // 
            this.AuditCode.MinimumWidth = 6;
            this.AuditCode.Name = "AuditCode";
            this.AuditCode.Width = 125;
            // 
            // NameofAudit
            // 
            this.NameofAudit.MinimumWidth = 6;
            this.NameofAudit.Name = "NameofAudit";
            this.NameofAudit.Width = 125;
            // 
            // TypeofAudit
            // 
            this.TypeofAudit.MinimumWidth = 6;
            this.TypeofAudit.Name = "TypeofAudit";
            this.TypeofAudit.Width = 125;
            // 
            // ProcessName
            // 
            this.ProcessName.MinimumWidth = 6;
            this.ProcessName.Name = "ProcessName";
            this.ProcessName.Width = 125;
            // 
            // Area
            // 
            this.Area.MinimumWidth = 6;
            this.Area.Name = "Area";
            this.Area.Width = 125;
            // 
            // FDate
            // 
            this.FDate.MinimumWidth = 6;
            this.FDate.Name = "FDate";
            this.FDate.Width = 125;
            // 
            // TDate
            // 
            this.TDate.MinimumWidth = 6;
            this.TDate.Name = "TDate";
            this.TDate.Width = 125;
            // 
            // ThirdPartyName
            // 
            this.ThirdPartyName.MinimumWidth = 6;
            this.ThirdPartyName.Name = "ThirdPartyName";
            this.ThirdPartyName.Width = 125;
            // 
            // Department
            // 
            this.Department.MinimumWidth = 6;
            this.Department.Name = "Department";
            this.Department.Width = 125;
            // 
            // Individual
            // 
            this.Individual.MinimumWidth = 6;
            this.Individual.Name = "Individual";
            this.Individual.Width = 125;
            // 
            // AuditOwner
            // 
            this.AuditOwner.MinimumWidth = 6;
            this.AuditOwner.Name = "AuditOwner";
            this.AuditOwner.Width = 125;
            // 
            // btnscope
            // 
            this.btnscope.MinimumWidth = 6;
            this.btnscope.Name = "btnscope";
            this.btnscope.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnscope.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnscope.Width = 125;
            // 
            // Prerequisite
            // 
            this.Prerequisite.MinimumWidth = 6;
            this.Prerequisite.Name = "Prerequisite";
            this.Prerequisite.Width = 125;
            // 
            // Remark
            // 
            this.Remark.MinimumWidth = 6;
            this.Remark.Name = "Remark";
            this.Remark.Width = 125;
            // 
            // Status
            // 
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.Width = 125;
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
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(787, 660);
            this.btnSave.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSave.Name = "btnSave";
            this.btnSave.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnSave.Size = new System.Drawing.Size(124, 30);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save Details";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDataToolStripMenuItem,
            this.deleteDataToolStripMenuItem,
            this.deleteAllToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(242, 82);
            // 
            // addDataToolStripMenuItem
            // 
            this.addDataToolStripMenuItem.Image = global::HindalcoiOS.Properties.Resources.AddToLibrary_32x32;
            this.addDataToolStripMenuItem.Name = "addDataToolStripMenuItem";
            this.addDataToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addDataToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.addDataToolStripMenuItem.Text = "Add Data";
            this.addDataToolStripMenuItem.Click += new System.EventHandler(this.addDataToolStripMenuItem_Click);
            // 
            // deleteDataToolStripMenuItem
            // 
            this.deleteDataToolStripMenuItem.Image = global::HindalcoiOS.Properties.Resources.Remove_32x32;
            this.deleteDataToolStripMenuItem.Name = "deleteDataToolStripMenuItem";
            this.deleteDataToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.deleteDataToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.deleteDataToolStripMenuItem.Text = "Delete Data";
            this.deleteDataToolStripMenuItem.Click += new System.EventHandler(this.addDataToolStripMenuItem_Click);
            // 
            // deleteAllToolStripMenuItem
            // 
            this.deleteAllToolStripMenuItem.Image = global::HindalcoiOS.Properties.Resources.DeleteAll;
            this.deleteAllToolStripMenuItem.Name = "deleteAllToolStripMenuItem";
            this.deleteAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.deleteAllToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.deleteAllToolStripMenuItem.Text = "Delete All";
            this.deleteAllToolStripMenuItem.Click += new System.EventHandler(this.addDataToolStripMenuItem_Click);
            // 
            // ExternalAuditCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 702);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabExternalaudit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GrpReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExternalAuditCalendar";
            this.Text = "External Audit Calendar";
            this.Load += new System.EventHandler(this.ExternalAuditCalendar_Load);
            this.GrpReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvViewCalendar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabExternalaudit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVAuditCal)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpReport;
        private SparrowRMSControl.SparrowControl.SparrowGrid DgvViewCalendar;
        private System.Windows.Forms.GroupBox groupBox1;
        private SparrowRMSControl.SparrowControl.SparrowButton btnLoad;
        private SparrowRMSControl.SparrowControl.SparrowButton btnbrowser;
        private SparrowRMSControl.SparrowControl.SparrowCheckBox firstRowNamesCheckBox;
        private SparrowRMSControl.SparrowControl.SparrowComboBox sheetCombo;
        private SparrowRMSControl.SparrowControl.SparrowLabel bunifuLabel2;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtfile;
        private SparrowRMSControl.SparrowControl.SparrowLabel bunifuLabel1;
        private System.Windows.Forms.GroupBox tabExternalaudit;
        private SparrowRMSControl.SparrowControl.SparrowGrid DGVAuditCal;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameofAudit;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeofAudit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area;
        private System.Windows.Forms.DataGridViewTextBoxColumn FDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThirdPartyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn Individual;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditOwner;
        private System.Windows.Forms.DataGridViewButtonColumn btnscope;
        private System.Windows.Forms.DataGridViewButtonColumn Prerequisite;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private SparrowRMSControl.SparrowControl.SparrowButton btnSave;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllToolStripMenuItem;
    }
}