
namespace HindalcoiOS.Maintenance
{
    partial class MaintenanceBRK
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
            this.panelDisplay = new System.Windows.Forms.Panel();
            this.btnclosed = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.lblName = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.btnback = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpAllgrid = new System.Windows.Forms.GroupBox();
            this.DGVBRKDown = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BreakDownCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MachineTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operationplant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exactlocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Others = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpDetailView = new System.Windows.Forms.GroupBox();
            this.txtClosedby = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblClosedby = new System.Windows.Forms.Label();
            this.RTCHBRKComments = new System.Windows.Forms.RichTextBox();
            this.rtchcomments = new System.Windows.Forms.RichTextBox();
            this.lblBRKMaintAllComm = new System.Windows.Forms.Label();
            this.lblErrOunit = new System.Windows.Forms.Label();
            this.lblErrExtLoc = new System.Windows.Forms.Label();
            this.lblErrComm = new System.Windows.Forms.Label();
            this.lblErrPrity = new System.Windows.Forms.Label();
            this.lblErrMTag = new System.Windows.Forms.Label();
            this.lblplant = new System.Windows.Forms.Label();
            this.btnsubmit = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.txtarea = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.dropDownStatus = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.dropdownmachine = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.chkmaintenace = new SparrowRMSControl.SparrowControl.SparrowCheckBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtreportedby = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.dtpReportingDate = new SparrowRMSControl.SparrowControl.SparrowDatePicker();
            this.lblbrkdowncode = new System.Windows.Forms.Label();
            this.lblreportedby = new System.Windows.Forms.Label();
            this.lblpriority = new System.Windows.Forms.Label();
            this.lblothersdetails = new System.Windows.Forms.Label();
            this.txtxactlocation = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.dropdownOP = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtbrkcode = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblmachinetag = new System.Windows.Forms.Label();
            this.lblarea = new System.Windows.Forms.Label();
            this.dropdownpriority = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.lblExcatlocation = new System.Windows.Forms.Label();
            this.panelDisplay.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.grpAllgrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVBRKDown)).BeginInit();
            this.grpDetailView.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDisplay
            // 
            this.panelDisplay.Controls.Add(this.btnclosed);
            this.panelDisplay.Controls.Add(this.lblName);
            this.panelDisplay.Controls.Add(this.btnback);
            this.panelDisplay.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelDisplay.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelDisplay.Location = new System.Drawing.Point(13, 4);
            this.panelDisplay.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelDisplay.Name = "panelDisplay";
            this.panelDisplay.Size = new System.Drawing.Size(1091, 54);
            this.panelDisplay.TabIndex = 1;
            // 
            // btnclosed
            // 
            this.btnclosed.BackColor = System.Drawing.Color.IndianRed;
            this.btnclosed.BackgroundColor = System.Drawing.Color.IndianRed;
            this.btnclosed.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnclosed.BorderRadius = 14;
            this.btnclosed.BorderSize = 0;
            this.btnclosed.FlatAppearance.BorderSize = 0;
            this.btnclosed.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnclosed.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnclosed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclosed.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclosed.ForeColor = System.Drawing.Color.White;
            this.btnclosed.Location = new System.Drawing.Point(872, 10);
            this.btnclosed.Margin = new System.Windows.Forms.Padding(2, 3, 19, 3);
            this.btnclosed.MouseOver = System.Drawing.Color.SeaGreen;
            this.btnclosed.Name = "btnclosed";
            this.btnclosed.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnclosed.Size = new System.Drawing.Size(123, 30);
            this.btnclosed.TabIndex = 2;
            this.btnclosed.Text = "Close";
            this.btnclosed.TextColor = System.Drawing.Color.White;
            this.btnclosed.UseVisualStyleBackColor = false;
            this.btnclosed.Visible = false;
            this.btnclosed.Click += new System.EventHandler(this.btnclosed_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Depth = 0;
            this.lblName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblName.Location = new System.Drawing.Point(462, 13);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 21);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Break Down";
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.SeaGreen;
            this.btnback.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.btnback.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnback.BorderRadius = 14;
            this.btnback.BorderSize = 0;
            this.btnback.FlatAppearance.BorderSize = 0;
            this.btnback.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnback.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnback.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnback.ForeColor = System.Drawing.Color.White;
            this.btnback.Location = new System.Drawing.Point(19, 11);
            this.btnback.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnback.MouseOver = System.Drawing.Color.SeaGreen;
            this.btnback.Name = "btnback";
            this.btnback.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnback.Size = new System.Drawing.Size(96, 28);
            this.btnback.TabIndex = 0;
            this.btnback.Text = "<< Back";
            this.btnback.TextColor = System.Drawing.Color.White;
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Visible = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportSummaryToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(238, 30);
            // 
            // exportSummaryToolStripMenuItem
            // 
            this.exportSummaryToolStripMenuItem.Image = global::HindalcoiOS.Properties.Resources.AddToLibrary_32x32;
            this.exportSummaryToolStripMenuItem.Name = "exportSummaryToolStripMenuItem";
            this.exportSummaryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.exportSummaryToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.exportSummaryToolStripMenuItem.Text = "Export Summary";
            this.exportSummaryToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // grpAllgrid
            // 
            this.grpAllgrid.Controls.Add(this.DGVBRKDown);
            this.grpAllgrid.Location = new System.Drawing.Point(8, 76);
            this.grpAllgrid.Name = "grpAllgrid";
            this.grpAllgrid.Size = new System.Drawing.Size(1109, 431);
            this.grpAllgrid.TabIndex = 27;
            this.grpAllgrid.TabStop = false;
            // 
            // DGVBRKDown
            // 
            this.DGVBRKDown.AllowUserToAddRows = false;
            this.DGVBRKDown.AllowUserToDeleteRows = false;
            this.DGVBRKDown.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVBRKDown.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVBRKDown.ColumnHeadersHeight = 35;
            this.DGVBRKDown.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.BreakDownCode,
            this.MachineTag,
            this.Priority,
            this.Operationplant,
            this.Status,
            this.Area,
            this.Exactlocation,
            this.ReportedBy,
            this.Others,
            this.Remark});
            this.DGVBRKDown.ContextMenuStrip = this.contextMenuStrip2;
            this.DGVBRKDown.EnableHeadersVisualStyles = false;
            this.DGVBRKDown.Location = new System.Drawing.Point(15, 22);
            this.DGVBRKDown.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DGVBRKDown.Name = "DGVBRKDown";
            this.DGVBRKDown.ReadOnly = true;
            this.DGVBRKDown.RowHeadersVisible = false;
            this.DGVBRKDown.RowHeadersWidth = 62;
            this.DGVBRKDown.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGVBRKDown.RowTemplate.Height = 28;
            this.DGVBRKDown.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVBRKDown.Size = new System.Drawing.Size(1062, 350);
            this.DGVBRKDown.TabIndex = 26;
            this.DGVBRKDown.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVBRKDown_CellClick);
            this.DGVBRKDown.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSelectAll_CellContentClick);
            this.DGVBRKDown.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVBRKDown_CellContentDoubleClick);
            this.DGVBRKDown.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGVBRKDown_CellFormatting);
            // 
            // Date
            // 
            this.Date.HeaderText = "Reporting Date";
            this.Date.MinimumWidth = 8;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 130;
            // 
            // BreakDownCode
            // 
            this.BreakDownCode.HeaderText = "BreakDown Code";
            this.BreakDownCode.MinimumWidth = 8;
            this.BreakDownCode.Name = "BreakDownCode";
            this.BreakDownCode.ReadOnly = true;
            this.BreakDownCode.Width = 143;
            // 
            // MachineTag
            // 
            this.MachineTag.HeaderText = "Machine Tag";
            this.MachineTag.MinimumWidth = 8;
            this.MachineTag.Name = "MachineTag";
            this.MachineTag.ReadOnly = true;
            this.MachineTag.Width = 113;
            // 
            // Priority
            // 
            this.Priority.HeaderText = "Priority";
            this.Priority.MinimumWidth = 8;
            this.Priority.Name = "Priority";
            this.Priority.ReadOnly = true;
            this.Priority.Width = 80;
            // 
            // Operationplant
            // 
            this.Operationplant.HeaderText = "Operation Plant";
            this.Operationplant.MinimumWidth = 8;
            this.Operationplant.Name = "Operationplant";
            this.Operationplant.ReadOnly = true;
            this.Operationplant.Width = 131;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 8;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 76;
            // 
            // Area
            // 
            this.Area.HeaderText = "Area";
            this.Area.MinimumWidth = 8;
            this.Area.Name = "Area";
            this.Area.ReadOnly = true;
            this.Area.Width = 64;
            // 
            // Exactlocation
            // 
            this.Exactlocation.HeaderText = "Exact Location ";
            this.Exactlocation.MinimumWidth = 8;
            this.Exactlocation.Name = "Exactlocation";
            this.Exactlocation.ReadOnly = true;
            this.Exactlocation.Width = 132;
            // 
            // ReportedBy
            // 
            this.ReportedBy.HeaderText = "Reported By";
            this.ReportedBy.MinimumWidth = 8;
            this.ReportedBy.Name = "ReportedBy";
            this.ReportedBy.ReadOnly = true;
            this.ReportedBy.Width = 114;
            // 
            // Others
            // 
            this.Others.HeaderText = "Others";
            this.Others.MinimumWidth = 8;
            this.Others.Name = "Others";
            this.Others.ReadOnly = true;
            this.Others.Width = 78;
            // 
            // Remark
            // 
            this.Remark.HeaderText = "Comment";
            this.Remark.MinimumWidth = 8;
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.Width = 98;
            // 
            // grpDetailView
            // 
            this.grpDetailView.Controls.Add(this.txtClosedby);
            this.grpDetailView.Controls.Add(this.lblClosedby);
            this.grpDetailView.Controls.Add(this.RTCHBRKComments);
            this.grpDetailView.Controls.Add(this.rtchcomments);
            this.grpDetailView.Controls.Add(this.lblBRKMaintAllComm);
            this.grpDetailView.Controls.Add(this.lblErrOunit);
            this.grpDetailView.Controls.Add(this.lblErrExtLoc);
            this.grpDetailView.Controls.Add(this.lblErrComm);
            this.grpDetailView.Controls.Add(this.lblErrPrity);
            this.grpDetailView.Controls.Add(this.lblErrMTag);
            this.grpDetailView.Controls.Add(this.lblplant);
            this.grpDetailView.Controls.Add(this.btnsubmit);
            this.grpDetailView.Controls.Add(this.txtarea);
            this.grpDetailView.Controls.Add(this.dropDownStatus);
            this.grpDetailView.Controls.Add(this.dropdownmachine);
            this.grpDetailView.Controls.Add(this.chkmaintenace);
            this.grpDetailView.Controls.Add(this.lblDate);
            this.grpDetailView.Controls.Add(this.txtreportedby);
            this.grpDetailView.Controls.Add(this.dtpReportingDate);
            this.grpDetailView.Controls.Add(this.lblbrkdowncode);
            this.grpDetailView.Controls.Add(this.lblreportedby);
            this.grpDetailView.Controls.Add(this.lblpriority);
            this.grpDetailView.Controls.Add(this.lblothersdetails);
            this.grpDetailView.Controls.Add(this.txtxactlocation);
            this.grpDetailView.Controls.Add(this.dropdownOP);
            this.grpDetailView.Controls.Add(this.lblStatus);
            this.grpDetailView.Controls.Add(this.txtbrkcode);
            this.grpDetailView.Controls.Add(this.lblmachinetag);
            this.grpDetailView.Controls.Add(this.lblarea);
            this.grpDetailView.Controls.Add(this.dropdownpriority);
            this.grpDetailView.Controls.Add(this.lblExcatlocation);
            this.grpDetailView.Location = new System.Drawing.Point(16, 76);
            this.grpDetailView.Name = "grpDetailView";
            this.grpDetailView.Size = new System.Drawing.Size(1094, 409);
            this.grpDetailView.TabIndex = 28;
            this.grpDetailView.TabStop = false;
            // 
            // txtClosedby
            // 
            this.txtClosedby.BackColor = System.Drawing.SystemColors.Window;
            this.txtClosedby.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtClosedby.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtClosedby.BorderRadius = 0;
            this.txtClosedby.BorderSize = 1;
            this.txtClosedby.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtClosedby.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClosedby.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtClosedby.Location = new System.Drawing.Point(828, 193);
            this.txtClosedby.Margin = new System.Windows.Forms.Padding(5);
            this.txtClosedby.Multiline = false;
            this.txtClosedby.Name = "txtClosedby";
            this.txtClosedby.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.txtClosedby.PasswordChar = false;
            this.txtClosedby.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtClosedby.PlaceholderText = "Area";
            this.txtClosedby.Size = new System.Drawing.Size(190, 34);
            this.txtClosedby.TabIndex = 80;
            this.txtClosedby.UnderlinedStyle = false;
            this.txtClosedby.Visible = false;
            // 
            // lblClosedby
            // 
            this.lblClosedby.AutoSize = true;
            this.lblClosedby.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClosedby.Location = new System.Drawing.Point(737, 201);
            this.lblClosedby.Margin = new System.Windows.Forms.Padding(3);
            this.lblClosedby.Name = "lblClosedby";
            this.lblClosedby.Size = new System.Drawing.Size(82, 21);
            this.lblClosedby.TabIndex = 79;
            this.lblClosedby.Text = "Closed By";
            this.lblClosedby.Visible = false;
            // 
            // RTCHBRKComments
            // 
            this.RTCHBRKComments.Location = new System.Drawing.Point(589, 239);
            this.RTCHBRKComments.Name = "RTCHBRKComments";
            this.RTCHBRKComments.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.RTCHBRKComments.Size = new System.Drawing.Size(439, 80);
            this.RTCHBRKComments.TabIndex = 78;
            this.RTCHBRKComments.Text = "";
            // 
            // rtchcomments
            // 
            this.rtchcomments.Location = new System.Drawing.Point(42, 260);
            this.rtchcomments.Name = "rtchcomments";
            this.rtchcomments.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtchcomments.Size = new System.Drawing.Size(424, 132);
            this.rtchcomments.TabIndex = 77;
            this.rtchcomments.Text = "";
            this.rtchcomments.Leave += new System.EventHandler(this.rtchcomments_Leave);
            // 
            // lblBRKMaintAllComm
            // 
            this.lblBRKMaintAllComm.AutoSize = true;
            this.lblBRKMaintAllComm.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBRKMaintAllComm.Location = new System.Drawing.Point(585, 201);
            this.lblBRKMaintAllComm.Margin = new System.Windows.Forms.Padding(3);
            this.lblBRKMaintAllComm.Name = "lblBRKMaintAllComm";
            this.lblBRKMaintAllComm.Size = new System.Drawing.Size(113, 21);
            this.lblBRKMaintAllComm.TabIndex = 76;
            this.lblBRKMaintAllComm.Text = "All Comments";
            // 
            // lblErrOunit
            // 
            this.lblErrOunit.AutoSize = true;
            this.lblErrOunit.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrOunit.ForeColor = System.Drawing.Color.Red;
            this.lblErrOunit.Location = new System.Drawing.Point(1025, 78);
            this.lblErrOunit.Margin = new System.Windows.Forms.Padding(3);
            this.lblErrOunit.Name = "lblErrOunit";
            this.lblErrOunit.Size = new System.Drawing.Size(19, 21);
            this.lblErrOunit.TabIndex = 75;
            this.lblErrOunit.Text = "*";
            // 
            // lblErrExtLoc
            // 
            this.lblErrExtLoc.AutoSize = true;
            this.lblErrExtLoc.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrExtLoc.ForeColor = System.Drawing.Color.Red;
            this.lblErrExtLoc.Location = new System.Drawing.Point(1023, 157);
            this.lblErrExtLoc.Margin = new System.Windows.Forms.Padding(3);
            this.lblErrExtLoc.Name = "lblErrExtLoc";
            this.lblErrExtLoc.Size = new System.Drawing.Size(19, 21);
            this.lblErrExtLoc.TabIndex = 74;
            this.lblErrExtLoc.Text = "*";
            // 
            // lblErrComm
            // 
            this.lblErrComm.AutoSize = true;
            this.lblErrComm.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrComm.ForeColor = System.Drawing.Color.Red;
            this.lblErrComm.Location = new System.Drawing.Point(474, 270);
            this.lblErrComm.Margin = new System.Windows.Forms.Padding(3);
            this.lblErrComm.Name = "lblErrComm";
            this.lblErrComm.Size = new System.Drawing.Size(19, 21);
            this.lblErrComm.TabIndex = 73;
            this.lblErrComm.Text = "*";
            // 
            // lblErrPrity
            // 
            this.lblErrPrity.AutoSize = true;
            this.lblErrPrity.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrPrity.ForeColor = System.Drawing.Color.Red;
            this.lblErrPrity.Location = new System.Drawing.Point(469, 159);
            this.lblErrPrity.Margin = new System.Windows.Forms.Padding(3);
            this.lblErrPrity.Name = "lblErrPrity";
            this.lblErrPrity.Size = new System.Drawing.Size(19, 21);
            this.lblErrPrity.TabIndex = 72;
            this.lblErrPrity.Text = "*";
            // 
            // lblErrMTag
            // 
            this.lblErrMTag.AutoSize = true;
            this.lblErrMTag.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrMTag.ForeColor = System.Drawing.Color.Red;
            this.lblErrMTag.Location = new System.Drawing.Point(469, 117);
            this.lblErrMTag.Margin = new System.Windows.Forms.Padding(3);
            this.lblErrMTag.Name = "lblErrMTag";
            this.lblErrMTag.Size = new System.Drawing.Size(19, 21);
            this.lblErrMTag.TabIndex = 71;
            this.lblErrMTag.Text = "*";
            // 
            // lblplant
            // 
            this.lblplant.AutoSize = true;
            this.lblplant.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblplant.Location = new System.Drawing.Point(585, 74);
            this.lblplant.Margin = new System.Windows.Forms.Padding(3);
            this.lblplant.Name = "lblplant";
            this.lblplant.Size = new System.Drawing.Size(125, 21);
            this.lblplant.TabIndex = 58;
            this.lblplant.Text = "Operation Plant";
            // 
            // btnsubmit
            // 
            this.btnsubmit.BackColor = System.Drawing.Color.SeaGreen;
            this.btnsubmit.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.btnsubmit.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnsubmit.BorderRadius = 14;
            this.btnsubmit.BorderSize = 0;
            this.btnsubmit.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnsubmit.FlatAppearance.BorderSize = 0;
            this.btnsubmit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnsubmit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnsubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsubmit.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsubmit.ForeColor = System.Drawing.Color.White;
            this.btnsubmit.Location = new System.Drawing.Point(842, 364);
            this.btnsubmit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnsubmit.MouseOver = System.Drawing.Color.SeaGreen;
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnsubmit.Size = new System.Drawing.Size(178, 30);
            this.btnsubmit.TabIndex = 70;
            this.btnsubmit.Text = "Submit";
            this.btnsubmit.TextColor = System.Drawing.Color.White;
            this.btnsubmit.UseVisualStyleBackColor = false;
            this.btnsubmit.Visible = false;
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // txtarea
            // 
            this.txtarea.BackColor = System.Drawing.SystemColors.Window;
            this.txtarea.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtarea.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtarea.BorderRadius = 0;
            this.txtarea.BorderSize = 1;
            this.txtarea.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtarea.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtarea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtarea.Location = new System.Drawing.Point(777, 106);
            this.txtarea.Margin = new System.Windows.Forms.Padding(5);
            this.txtarea.Multiline = false;
            this.txtarea.Name = "txtarea";
            this.txtarea.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.txtarea.PasswordChar = false;
            this.txtarea.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtarea.PlaceholderText = "Area";
            this.txtarea.Size = new System.Drawing.Size(241, 34);
            this.txtarea.TabIndex = 65;
            this.txtarea.UnderlinedStyle = false;
            this.txtarea.Leave += new System.EventHandler(this.txtarea_Leave);
            // 
            // dropDownStatus
            // 
            this.dropDownStatus.BorderColor = System.Drawing.Color.DodgerBlue;
            this.dropDownStatus.BorderSize = 1;
            this.dropDownStatus.Cursor = System.Windows.Forms.Cursors.Default;
            this.dropDownStatus.Font = new System.Drawing.Font("Tahoma", 11F);
            this.dropDownStatus.ForeColor = System.Drawing.Color.DimGray;
            this.dropDownStatus.IconColor = System.Drawing.Color.Silver;
            this.dropDownStatus.ItemHeight = 22;
            this.dropDownStatus.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.dropDownStatus.ListTextColor = System.Drawing.Color.White;
            this.dropDownStatus.Location = new System.Drawing.Point(776, 28);
            this.dropDownStatus.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dropDownStatus.MinimumSize = new System.Drawing.Size(156, 0);
            this.dropDownStatus.Name = "dropDownStatus";
            this.dropDownStatus.Size = new System.Drawing.Size(243, 30);
            this.dropDownStatus.TabIndex = 61;
            // 
            // dropdownmachine
            // 
            this.dropdownmachine.BorderColor = System.Drawing.Color.DodgerBlue;
            this.dropdownmachine.BorderSize = 1;
            this.dropdownmachine.Cursor = System.Windows.Forms.Cursors.Default;
            this.dropdownmachine.Font = new System.Drawing.Font("Tahoma", 11F);
            this.dropdownmachine.ForeColor = System.Drawing.Color.DimGray;
            this.dropdownmachine.IconColor = System.Drawing.Color.Silver;
            this.dropdownmachine.ItemHeight = 22;
            this.dropdownmachine.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.dropdownmachine.ListTextColor = System.Drawing.Color.White;
            this.dropdownmachine.Location = new System.Drawing.Point(201, 112);
            this.dropdownmachine.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dropdownmachine.MinimumSize = new System.Drawing.Size(156, 0);
            this.dropdownmachine.Name = "dropdownmachine";
            this.dropdownmachine.Size = new System.Drawing.Size(265, 30);
            this.dropdownmachine.TabIndex = 53;
            this.dropdownmachine.SelectedIndexChanged += new System.EventHandler(this.dropdownmachine_SelectedIndexChanged);
            // 
            // chkmaintenace
            // 
            this.chkmaintenace.AutoSize = true;
            this.chkmaintenace.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkmaintenace.Depth = 0;
            this.chkmaintenace.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkmaintenace.Location = new System.Drawing.Point(583, 362);
            this.chkmaintenace.Margin = new System.Windows.Forms.Padding(0);
            this.chkmaintenace.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkmaintenace.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.chkmaintenace.Name = "chkmaintenace";
            this.chkmaintenace.Ripple = true;
            this.chkmaintenace.Size = new System.Drawing.Size(204, 30);
            this.chkmaintenace.TabIndex = 69;
            this.chkmaintenace.Text = "Maintenance Required";
            this.chkmaintenace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkmaintenace.UseVisualStyleBackColor = true;
            this.chkmaintenace.Visible = false;
            this.chkmaintenace.CheckedChanged += new System.EventHandler(this.chkmaintenace_CheckedChanged);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(39, 35);
            this.lblDate.Margin = new System.Windows.Forms.Padding(3);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(129, 21);
            this.lblDate.TabIndex = 48;
            this.lblDate.Text = "Reporting Date:";
            // 
            // txtreportedby
            // 
            this.txtreportedby.BackColor = System.Drawing.SystemColors.Window;
            this.txtreportedby.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtreportedby.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtreportedby.BorderRadius = 0;
            this.txtreportedby.BorderSize = 1;
            this.txtreportedby.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreportedby.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtreportedby.Location = new System.Drawing.Point(201, 193);
            this.txtreportedby.Margin = new System.Windows.Forms.Padding(5);
            this.txtreportedby.Multiline = false;
            this.txtreportedby.Name = "txtreportedby";
            this.txtreportedby.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.txtreportedby.PasswordChar = false;
            this.txtreportedby.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtreportedby.PlaceholderText = "Reported By";
            this.txtreportedby.Size = new System.Drawing.Size(265, 34);
            this.txtreportedby.TabIndex = 67;
            this.txtreportedby.UnderlinedStyle = false;
            // 
            // dtpReportingDate
            // 
            this.dtpReportingDate.BorderColor = System.Drawing.Color.Silver;
            this.dtpReportingDate.BorderSize = 0;
            this.dtpReportingDate.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtpReportingDate.CustomFormat = "dd-MM-yyyy HH:mm";
            this.dtpReportingDate.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReportingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReportingDate.Location = new System.Drawing.Point(202, 22);
            this.dtpReportingDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpReportingDate.MinimumSize = new System.Drawing.Size(4, 35);
            this.dtpReportingDate.Name = "dtpReportingDate";
            this.dtpReportingDate.Size = new System.Drawing.Size(264, 35);
            this.dtpReportingDate.SkinColor = System.Drawing.Color.MediumSlateBlue;
            this.dtpReportingDate.TabIndex = 49;
            this.dtpReportingDate.TextColor = System.Drawing.Color.White;
            this.dtpReportingDate.Value = new System.DateTime(2022, 9, 29, 14, 47, 34, 0);
            // 
            // lblbrkdowncode
            // 
            this.lblbrkdowncode.AutoSize = true;
            this.lblbrkdowncode.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbrkdowncode.Location = new System.Drawing.Point(39, 74);
            this.lblbrkdowncode.Margin = new System.Windows.Forms.Padding(3);
            this.lblbrkdowncode.Name = "lblbrkdowncode";
            this.lblbrkdowncode.Size = new System.Drawing.Size(134, 21);
            this.lblbrkdowncode.TabIndex = 50;
            this.lblbrkdowncode.Text = "Breakdown Code";
            // 
            // lblreportedby
            // 
            this.lblreportedby.AutoSize = true;
            this.lblreportedby.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblreportedby.Location = new System.Drawing.Point(39, 193);
            this.lblreportedby.Margin = new System.Windows.Forms.Padding(3);
            this.lblreportedby.Name = "lblreportedby";
            this.lblreportedby.Size = new System.Drawing.Size(101, 21);
            this.lblreportedby.TabIndex = 64;
            this.lblreportedby.Text = "Reported By";
            // 
            // lblpriority
            // 
            this.lblpriority.AutoSize = true;
            this.lblpriority.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpriority.Location = new System.Drawing.Point(39, 152);
            this.lblpriority.Margin = new System.Windows.Forms.Padding(3);
            this.lblpriority.Name = "lblpriority";
            this.lblpriority.Size = new System.Drawing.Size(62, 21);
            this.lblpriority.TabIndex = 54;
            this.lblpriority.Text = "Priority";
            // 
            // lblothersdetails
            // 
            this.lblothersdetails.AutoSize = true;
            this.lblothersdetails.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblothersdetails.Location = new System.Drawing.Point(40, 233);
            this.lblothersdetails.Margin = new System.Windows.Forms.Padding(3);
            this.lblothersdetails.Name = "lblothersdetails";
            this.lblothersdetails.Size = new System.Drawing.Size(153, 21);
            this.lblothersdetails.TabIndex = 56;
            this.lblothersdetails.Text = "Input Other Details";
            // 
            // txtxactlocation
            // 
            this.txtxactlocation.BackColor = System.Drawing.SystemColors.Window;
            this.txtxactlocation.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtxactlocation.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtxactlocation.BorderRadius = 0;
            this.txtxactlocation.BorderSize = 1;
            this.txtxactlocation.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtxactlocation.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtxactlocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtxactlocation.Location = new System.Drawing.Point(777, 149);
            this.txtxactlocation.Margin = new System.Windows.Forms.Padding(5);
            this.txtxactlocation.Multiline = false;
            this.txtxactlocation.Name = "txtxactlocation";
            this.txtxactlocation.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.txtxactlocation.PasswordChar = false;
            this.txtxactlocation.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtxactlocation.PlaceholderText = "Exact Location";
            this.txtxactlocation.Size = new System.Drawing.Size(241, 34);
            this.txtxactlocation.TabIndex = 66;
            this.txtxactlocation.UnderlinedStyle = false;
            this.txtxactlocation.Leave += new System.EventHandler(this.txtxactlocation_Leave);
            // 
            // dropdownOP
            // 
            this.dropdownOP.BorderColor = System.Drawing.Color.DodgerBlue;
            this.dropdownOP.BorderSize = 1;
            this.dropdownOP.Font = new System.Drawing.Font("Tahoma", 11F);
            this.dropdownOP.ForeColor = System.Drawing.Color.DimGray;
            this.dropdownOP.IconColor = System.Drawing.Color.Silver;
            this.dropdownOP.ItemHeight = 22;
            this.dropdownOP.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.dropdownOP.ListTextColor = System.Drawing.Color.White;
            this.dropdownOP.Location = new System.Drawing.Point(776, 67);
            this.dropdownOP.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dropdownOP.MinimumSize = new System.Drawing.Size(156, 0);
            this.dropdownOP.Name = "dropdownOP";
            this.dropdownOP.Size = new System.Drawing.Size(243, 30);
            this.dropdownOP.TabIndex = 59;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(585, 30);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(57, 21);
            this.lblStatus.TabIndex = 60;
            this.lblStatus.Text = "Status";
            // 
            // txtbrkcode
            // 
            this.txtbrkcode.BackColor = System.Drawing.SystemColors.Window;
            this.txtbrkcode.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtbrkcode.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtbrkcode.BorderRadius = 0;
            this.txtbrkcode.BorderSize = 1;
            this.txtbrkcode.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtbrkcode.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbrkcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtbrkcode.Location = new System.Drawing.Point(201, 65);
            this.txtbrkcode.Margin = new System.Windows.Forms.Padding(5);
            this.txtbrkcode.Multiline = false;
            this.txtbrkcode.Name = "txtbrkcode";
            this.txtbrkcode.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.txtbrkcode.PasswordChar = false;
            this.txtbrkcode.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtbrkcode.PlaceholderText = "Breakdown Code";
            this.txtbrkcode.Size = new System.Drawing.Size(265, 34);
            this.txtbrkcode.TabIndex = 52;
            this.txtbrkcode.UnderlinedStyle = false;
            // 
            // lblmachinetag
            // 
            this.lblmachinetag.AutoSize = true;
            this.lblmachinetag.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmachinetag.Location = new System.Drawing.Point(39, 113);
            this.lblmachinetag.Margin = new System.Windows.Forms.Padding(3);
            this.lblmachinetag.Name = "lblmachinetag";
            this.lblmachinetag.Size = new System.Drawing.Size(104, 21);
            this.lblmachinetag.TabIndex = 51;
            this.lblmachinetag.Text = "Machine Tag";
            // 
            // lblarea
            // 
            this.lblarea.AutoSize = true;
            this.lblarea.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblarea.Location = new System.Drawing.Point(585, 118);
            this.lblarea.Margin = new System.Windows.Forms.Padding(3);
            this.lblarea.Name = "lblarea";
            this.lblarea.Size = new System.Drawing.Size(45, 21);
            this.lblarea.TabIndex = 62;
            this.lblarea.Text = "Area";
            // 
            // dropdownpriority
            // 
            this.dropdownpriority.BorderColor = System.Drawing.Color.DodgerBlue;
            this.dropdownpriority.BorderSize = 1;
            this.dropdownpriority.Cursor = System.Windows.Forms.Cursors.Default;
            this.dropdownpriority.Font = new System.Drawing.Font("Tahoma", 11F);
            this.dropdownpriority.ForeColor = System.Drawing.Color.DimGray;
            this.dropdownpriority.IconColor = System.Drawing.Color.Silver;
            this.dropdownpriority.ItemHeight = 22;
            this.dropdownpriority.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.dropdownpriority.ListTextColor = System.Drawing.Color.White;
            this.dropdownpriority.Location = new System.Drawing.Point(201, 154);
            this.dropdownpriority.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dropdownpriority.MinimumSize = new System.Drawing.Size(156, 0);
            this.dropdownpriority.Name = "dropdownpriority";
            this.dropdownpriority.Size = new System.Drawing.Size(265, 30);
            this.dropdownpriority.TabIndex = 55;
            // 
            // lblExcatlocation
            // 
            this.lblExcatlocation.AutoSize = true;
            this.lblExcatlocation.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExcatlocation.Location = new System.Drawing.Point(585, 162);
            this.lblExcatlocation.Margin = new System.Windows.Forms.Padding(3);
            this.lblExcatlocation.Name = "lblExcatlocation";
            this.lblExcatlocation.Size = new System.Drawing.Size(118, 21);
            this.lblExcatlocation.TabIndex = 63;
            this.lblExcatlocation.Text = "Exact Location";
            // 
            // MaintenanceBRK
            // 
            this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 520);
            this.Controls.Add(this.grpDetailView);
            this.Controls.Add(this.grpAllgrid);
            this.Controls.Add(this.panelDisplay);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "MaintenanceBRK";
            this.Padding = new System.Windows.Forms.Padding(19, 0, 19, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Breakdown Reporting";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MaintenanceBRK_FormClosed);
            this.Load += new System.EventHandler(this.MaintenanceBRK_Load);
            this.panelDisplay.ResumeLayout(false);
            this.panelDisplay.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.grpAllgrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVBRKDown)).EndInit();
            this.grpDetailView.ResumeLayout(false);
            this.grpDetailView.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDisplay;
        private SparrowRMSControl.SparrowControl.SparrowButton btnclosed;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblName;
        private SparrowRMSControl.SparrowControl.SparrowButton btnback;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem exportSummaryToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpAllgrid;
        private System.Windows.Forms.GroupBox grpDetailView;
        private System.Windows.Forms.Label lblplant;
        private SparrowRMSControl.SparrowControl.SparrowButton btnsubmit;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtarea;
        private SparrowRMSControl.SparrowControl.SparrowComboBox dropDownStatus;
        public SparrowRMSControl.SparrowControl.SparrowComboBox dropdownmachine;
        private SparrowRMSControl.SparrowControl.SparrowCheckBox chkmaintenace;
        private System.Windows.Forms.Label lblDate;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtreportedby;
        private SparrowRMSControl.SparrowControl.SparrowDatePicker dtpReportingDate;
        private System.Windows.Forms.Label lblbrkdowncode;
        private System.Windows.Forms.Label lblreportedby;
        private System.Windows.Forms.Label lblpriority;
        private System.Windows.Forms.Label lblothersdetails;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtxactlocation;
        private SparrowRMSControl.SparrowControl.SparrowComboBox dropdownOP;
        private System.Windows.Forms.Label lblStatus;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtbrkcode;
        private System.Windows.Forms.Label lblmachinetag;
        private System.Windows.Forms.Label lblarea;
        private SparrowRMSControl.SparrowControl.SparrowComboBox dropdownpriority;
        private System.Windows.Forms.Label lblExcatlocation;
        private System.Windows.Forms.DataGridView DGVBRKDown;
        private System.Windows.Forms.Label lblErrMTag;
        private System.Windows.Forms.Label lblErrOunit;
        private System.Windows.Forms.Label lblErrExtLoc;
        private System.Windows.Forms.Label lblErrComm;
        private System.Windows.Forms.Label lblErrPrity;
        private System.Windows.Forms.Label lblBRKMaintAllComm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn BreakDownCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineTag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operationplant;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exactlocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Others;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.RichTextBox rtchcomments;
        private System.Windows.Forms.RichTextBox RTCHBRKComments;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtClosedby;
        private System.Windows.Forms.Label lblClosedby;
    }
}