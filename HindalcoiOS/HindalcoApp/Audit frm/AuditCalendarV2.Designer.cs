
namespace HindalcoiOS.Audit_frm
{
    partial class AuditCalendar
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
            this.DgvViewCalendar = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLoad = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.sheetCombo = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.bunifuLabel2 = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.btnbrowser = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.firstRowNamesCheckBox = new SparrowRMSControl.SparrowControl.SparrowCheckBox();
            this.txtfile = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.bunifuLabel1 = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.grpauditcl = new System.Windows.Forms.GroupBox();
            this.DgvAudit = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.SrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuditCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameofAudit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeofAudit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NextDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Individual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuditOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reviewedby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Approvedby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrpReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvViewCalendar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpauditcl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAudit)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpReport
            // 
            this.GrpReport.Controls.Add(this.DgvViewCalendar);
            this.GrpReport.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpReport.Location = new System.Drawing.Point(13, 6);
            this.GrpReport.Name = "GrpReport";
            this.GrpReport.Size = new System.Drawing.Size(1347, 205);
            this.GrpReport.TabIndex = 0;
            this.GrpReport.TabStop = false;
            this.GrpReport.Text = "View Calendar";
            // 
            // DgvViewCalendar
            // 
            this.DgvViewCalendar.AllowUserToAddRows = false;
            this.DgvViewCalendar.AllowUserToDeleteRows = false;
            this.DgvViewCalendar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DgvViewCalendar.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvViewCalendar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvViewCalendar.ColumnHeadersHeight = 35;
            this.DgvViewCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvViewCalendar.EnableHeadersVisualStyles = false;
            this.DgvViewCalendar.Location = new System.Drawing.Point(4, 21);
            this.DgvViewCalendar.Name = "DgvViewCalendar";
            this.DgvViewCalendar.ReadOnly = true;
            this.DgvViewCalendar.RowHeadersVisible = false;
            this.DgvViewCalendar.RowHeadersWidth = 51;
            this.DgvViewCalendar.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgvViewCalendar.RowTemplate.Height = 24;
            this.DgvViewCalendar.Size = new System.Drawing.Size(1332, 179);
            this.DgvViewCalendar.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Controls.Add(this.sheetCombo);
            this.groupBox1.Controls.Add(this.bunifuLabel2);
            this.groupBox1.Controls.Add(this.btnbrowser);
            this.groupBox1.Controls.Add(this.firstRowNamesCheckBox);
            this.groupBox1.Controls.Add(this.txtfile);
            this.groupBox1.Controls.Add(this.bunifuLabel1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 221);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1336, 98);
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
            this.btnLoad.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(1191, 29);
            this.btnLoad.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnLoad.Size = new System.Drawing.Size(104, 30);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Load Report";
            this.btnLoad.TextColor = System.Drawing.Color.White;
            this.btnLoad.UseVisualStyleBackColor = false;
            // 
            // sheetCombo
            // 
            this.sheetCombo.BorderColor = System.Drawing.Color.DodgerBlue;
            this.sheetCombo.BorderSize = 0;
            this.sheetCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sheetCombo.ForeColor = System.Drawing.Color.DimGray;
            this.sheetCombo.IconColor = System.Drawing.Color.DodgerBlue;
            this.sheetCombo.ListBackColor = System.Drawing.Color.Red;
            this.sheetCombo.ListTextColor = System.Drawing.Color.White;
            this.sheetCombo.Location = new System.Drawing.Point(922, 27);
            this.sheetCombo.MinimumSize = new System.Drawing.Size(40, 0);
            this.sheetCombo.Name = "sheetCombo";
            this.sheetCombo.Size = new System.Drawing.Size(238, 28);
            this.sheetCombo.TabIndex = 5;
            // 
            // bunifuLabel2
            // 
            this.bunifuLabel2.AutoSize = true;
            this.bunifuLabel2.Depth = 0;
            this.bunifuLabel2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.bunifuLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bunifuLabel2.Location = new System.Drawing.Point(784, 29);
            this.bunifuLabel2.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.bunifuLabel2.Name = "bunifuLabel2";
            this.bunifuLabel2.Size = new System.Drawing.Size(111, 21);
            this.bunifuLabel2.TabIndex = 4;
            this.bunifuLabel2.Text = "Choose Sheet";
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
            this.btnbrowser.Location = new System.Drawing.Point(399, 26);
            this.btnbrowser.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnbrowser.Name = "btnbrowser";
            this.btnbrowser.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnbrowser.Size = new System.Drawing.Size(98, 30);
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
            this.firstRowNamesCheckBox.Location = new System.Drawing.Point(169, 62);
            this.firstRowNamesCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.firstRowNamesCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.firstRowNamesCheckBox.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.firstRowNamesCheckBox.Name = "firstRowNamesCheckBox";
            this.firstRowNamesCheckBox.Ripple = true;
            this.firstRowNamesCheckBox.Size = new System.Drawing.Size(298, 30);
            this.firstRowNamesCheckBox.TabIndex = 2;
            this.firstRowNamesCheckBox.Text = "First Row Contains Column Names";
            this.firstRowNamesCheckBox.UseVisualStyleBackColor = true;
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
            this.txtfile.Location = new System.Drawing.Point(172, 24);
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
            // bunifuLabel1
            // 
            this.bunifuLabel1.AutoSize = true;
            this.bunifuLabel1.Depth = 0;
            this.bunifuLabel1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.bunifuLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bunifuLabel1.Location = new System.Drawing.Point(7, 33);
            this.bunifuLabel1.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.Size = new System.Drawing.Size(84, 21);
            this.bunifuLabel1.TabIndex = 0;
            this.bunifuLabel1.Text = "File Name";
            // 
            // grpauditcl
            // 
            this.grpauditcl.Controls.Add(this.DgvAudit);
            this.grpauditcl.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpauditcl.Location = new System.Drawing.Point(15, 325);
            this.grpauditcl.Name = "grpauditcl";
            this.grpauditcl.Size = new System.Drawing.Size(1333, 211);
            this.grpauditcl.TabIndex = 2;
            this.grpauditcl.TabStop = false;
            this.grpauditcl.Text = "Audit Calendar";
            // 
            // DgvAudit
            // 
            this.DgvAudit.AllowUserToAddRows = false;
            this.DgvAudit.AllowUserToDeleteRows = false;
            this.DgvAudit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvAudit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvAudit.ColumnHeadersHeight = 35;
            this.DgvAudit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvAudit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SrNo,
            this.AuditCode,
            this.NameofAudit,
            this.TypeofAudit,
            this.Area,
            this.ProcessName,
            this.Frequency,
            this.LastDate,
            this.NextDate,
            this.Department,
            this.Individual,
            this.AuditOwner,
            this.Reviewedby,
            this.Approvedby,
            this.Status});
            this.DgvAudit.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvAudit.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvAudit.EnableHeadersVisualStyles = false;
            this.DgvAudit.Location = new System.Drawing.Point(7, 22);
            this.DgvAudit.Name = "DgvAudit";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvAudit.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvAudit.RowHeadersVisible = false;
            this.DgvAudit.RowHeadersWidth = 51;
            this.DgvAudit.RowTemplate.Height = 24;
            this.DgvAudit.Size = new System.Drawing.Size(1314, 173);
            this.DgvAudit.TabIndex = 0;
            this.DgvAudit.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAudit_CellClick);
            this.DgvAudit.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAudit_CellContentClick);
            this.DgvAudit.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAudit_CellEndEdit);
            this.DgvAudit.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAudit_CellEnter);
            this.DgvAudit.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAudit_CellValueChanged);
            this.DgvAudit.CurrentCellDirtyStateChanged += new System.EventHandler(this.DgvAudit_CurrentCellDirtyStateChanged);
            this.DgvAudit.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgvAudit_DataError);
            this.DgvAudit.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DgvAudit_Scroll);
            this.DgvAudit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvAudit_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDataToolStripMenuItem,
            this.deleteDataToolStripMenuItem,
            this.deleteAllToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(163, 82);
            // 
            // addDataToolStripMenuItem
            // 
            this.addDataToolStripMenuItem.Image = global::HindalcoiOS.Properties.Resources.AddToLibrary_32x32;
            this.addDataToolStripMenuItem.Name = "addDataToolStripMenuItem";
            this.addDataToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.addDataToolStripMenuItem.Tag = "Add";
            this.addDataToolStripMenuItem.Text = "Add Data";
            this.addDataToolStripMenuItem.Click += new System.EventHandler(this.addDataToolStripMenuItem_Click);
            // 
            // deleteDataToolStripMenuItem
            // 
            this.deleteDataToolStripMenuItem.Image = global::HindalcoiOS.Properties.Resources.DeleteAll;
            this.deleteDataToolStripMenuItem.Name = "deleteDataToolStripMenuItem";
            this.deleteDataToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.deleteDataToolStripMenuItem.Tag = "delete";
            this.deleteDataToolStripMenuItem.Text = "Delete Data";
            this.deleteDataToolStripMenuItem.Click += new System.EventHandler(this.addDataToolStripMenuItem_Click);
            // 
            // deleteAllToolStripMenuItem
            // 
            this.deleteAllToolStripMenuItem.Image = global::HindalcoiOS.Properties.Resources.Remove_32x32;
            this.deleteAllToolStripMenuItem.Name = "deleteAllToolStripMenuItem";
            this.deleteAllToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.deleteAllToolStripMenuItem.Tag = "deleteall";
            this.deleteAllToolStripMenuItem.Text = "Delete All";
            this.deleteAllToolStripMenuItem.Click += new System.EventHandler(this.addDataToolStripMenuItem_Click);
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
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(1204, 544);
            this.btnSave.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSave.Name = "btnSave";
            this.btnSave.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnSave.Size = new System.Drawing.Size(132, 30);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SrNo
            // 
            this.SrNo.HeaderText = "SI No.";
            this.SrNo.MinimumWidth = 6;
            this.SrNo.Name = "SrNo";
            // 
            // AuditCode
            // 
            this.AuditCode.HeaderText = "Audit Code";
            this.AuditCode.MinimumWidth = 6;
            this.AuditCode.Name = "AuditCode";
            // 
            // NameofAudit
            // 
            this.NameofAudit.HeaderText = "Name of Audit";
            this.NameofAudit.MinimumWidth = 6;
            this.NameofAudit.Name = "NameofAudit";
            // 
            // TypeofAudit
            // 
            this.TypeofAudit.HeaderText = "Type of Audit";
            this.TypeofAudit.MinimumWidth = 6;
            this.TypeofAudit.Name = "TypeofAudit";
            // 
            // Area
            // 
            this.Area.HeaderText = "Area";
            this.Area.MinimumWidth = 6;
            this.Area.Name = "Area";
            // 
            // ProcessName
            // 
            this.ProcessName.HeaderText = "Process Name";
            this.ProcessName.MinimumWidth = 6;
            this.ProcessName.Name = "ProcessName";
            // 
            // Frequency
            // 
            this.Frequency.HeaderText = "Frequency";
            this.Frequency.MinimumWidth = 6;
            this.Frequency.Name = "Frequency";
            // 
            // LastDate
            // 
            this.LastDate.HeaderText = "Last Date";
            this.LastDate.MinimumWidth = 6;
            this.LastDate.Name = "LastDate";
            // 
            // NextDate
            // 
            this.NextDate.HeaderText = "Next Audit Date";
            this.NextDate.MinimumWidth = 6;
            this.NextDate.Name = "NextDate";
            // 
            // Department
            // 
            this.Department.HeaderText = "Department";
            this.Department.MinimumWidth = 6;
            this.Department.Name = "Department";
            // 
            // Individual
            // 
            this.Individual.HeaderText = "Individual";
            this.Individual.MinimumWidth = 6;
            this.Individual.Name = "Individual";
            // 
            // AuditOwner
            // 
            this.AuditOwner.HeaderText = "Audit Owner";
            this.AuditOwner.MinimumWidth = 6;
            this.AuditOwner.Name = "AuditOwner";
            // 
            // Reviewedby
            // 
            this.Reviewedby.HeaderText = "Reviewed By";
            this.Reviewedby.MinimumWidth = 6;
            this.Reviewedby.Name = "Reviewedby";
            // 
            // Approvedby
            // 
            this.Approvedby.HeaderText = "Approved By";
            this.Approvedby.MinimumWidth = 6;
            this.Approvedby.Name = "Approvedby";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.Visible = false;
            // 
            // AuditCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1372, 586);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpauditcl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GrpReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "AuditCalendar";
            this.Text = "Audit Calendar";
            this.Load += new System.EventHandler(this.AuditCalendar_Load);
            this.Click += new System.EventHandler(this.AuditCalendar_Load);
            this.GrpReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvViewCalendar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpauditcl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvAudit)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpReport;
        private System.Windows.Forms.DataGridView DgvViewCalendar;
        private System.Windows.Forms.GroupBox groupBox1;
        private SparrowRMSControl.SparrowControl.SparrowButton btnLoad;
        private SparrowRMSControl.SparrowControl.SparrowComboBox sheetCombo;
        private SparrowRMSControl.SparrowControl.SparrowLabel bunifuLabel2;
        private SparrowRMSControl.SparrowControl.SparrowButton btnbrowser;
        private SparrowRMSControl.SparrowControl.SparrowCheckBox firstRowNamesCheckBox;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtfile;
        private SparrowRMSControl.SparrowControl.SparrowLabel bunifuLabel1;
        private System.Windows.Forms.GroupBox grpauditcl;
        private System.Windows.Forms.DataGridView DgvAudit;
        private SparrowRMSControl.SparrowControl.SparrowButton btnSave;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameofAudit;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeofAudit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NextDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn Individual;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reviewedby;
        private System.Windows.Forms.DataGridViewTextBoxColumn Approvedby;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}