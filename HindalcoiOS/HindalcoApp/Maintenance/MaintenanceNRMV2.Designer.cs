
namespace HindalcoiOS.Maintenance
{
    partial class MaintenanceNRM
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
            base.Dispose(disposing);
            if (disposing && (components != null))
            {
                components.Dispose();
            }
           
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaintenanceNRM));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mntpanel = new System.Windows.Forms.Panel();
            this.lblmntdate = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.btnApproval = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnReject = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnclosed = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnback = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.contextInventory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddInverntroy = new System.Windows.Forms.ToolStripMenuItem();
            this.Removeinventory = new System.Windows.Forms.ToolStripMenuItem();
            this.returnInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addWorkerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeWorkerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblcode = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtmntcode = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lbldate = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.DatePickerMNTDate = new SparrowRMSControl.SparrowControl.SparrowDatePicker();
            this.lbloperationPlant = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.dropdownOP = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.lblstatus = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.dropdownstatus = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.lblmachinetag = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblothers = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lbldescription = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.dropdownmachinetag = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.txtothers = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.rtchtext = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblpriority = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblArea = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblexpectedtime = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblextactlocation = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblreportedby = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblAssignTo = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblcomments = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.dropdownpriority = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.txtArea = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtExtactlocation = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtReportedby = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.dropdownAssignTo = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.rtchcomments = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.btnsumbitaprl = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnAddWorker = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnInvertory = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.numericMinutes = new SparrowRMSControl.SparrowControl.SparrowNumericUpDown();
            this.numericHour = new SparrowRMSControl.SparrowControl.SparrowNumericUpDown();
            this.DGVRequestDetails = new System.Windows.Forms.DataGridView();
            this.MCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaintenanceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperationPlant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Statuss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MachineTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Others = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExactLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstimatedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssignTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabcontrolMNT = new SparrowRMSControl.SparrowControl.SparrowTabControl();
            this.Worker = new System.Windows.Forms.TabPage();
            this.DGVWorker = new System.Windows.Forms.DataGridView();
            this.WorkerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaintenanceCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inventory = new System.Windows.Forms.TabPage();
            this.DGVInventory = new System.Windows.Forms.DataGridView();
            this.DocumentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReferenceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Make = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpMaintenance = new System.Windows.Forms.GroupBox();
            this.lblMTagError = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.mntpanel.SuspendLayout();
            this.contextInventory.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVRequestDetails)).BeginInit();
            this.tabcontrolMNT.SuspendLayout();
            this.Worker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVWorker)).BeginInit();
            this.Inventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVInventory)).BeginInit();
            this.grpMaintenance.SuspendLayout();
            this.SuspendLayout();
            // 
            // mntpanel
            // 
            this.mntpanel.Controls.Add(this.lblmntdate);
            this.mntpanel.Controls.Add(this.btnApproval);
            this.mntpanel.Controls.Add(this.btnReject);
            this.mntpanel.Controls.Add(this.btnclosed);
            this.mntpanel.Controls.Add(this.btnback);
            this.mntpanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.mntpanel.Location = new System.Drawing.Point(0, 0);
            this.mntpanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.mntpanel.Name = "mntpanel";
            this.mntpanel.Size = new System.Drawing.Size(1137, 46);
            this.mntpanel.TabIndex = 0;
            // 
            // lblmntdate
            // 
            this.lblmntdate.AutoSize = true;
            this.lblmntdate.Depth = 0;
            this.lblmntdate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblmntdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblmntdate.Location = new System.Drawing.Point(389, 11);
            this.lblmntdate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblmntdate.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblmntdate.Name = "lblmntdate";
            this.lblmntdate.Size = new System.Drawing.Size(221, 21);
            this.lblmntdate.TabIndex = 6;
            this.lblmntdate.Text = "Fill Maintenance Information";
            this.lblmntdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnApproval
            // 
            this.btnApproval.BackColor = System.Drawing.Color.SeaGreen;
            this.btnApproval.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.btnApproval.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnApproval.BorderRadius = 14;
            this.btnApproval.BorderSize = 0;
            this.btnApproval.FlatAppearance.BorderSize = 0;
            this.btnApproval.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnApproval.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnApproval.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApproval.ForeColor = System.Drawing.Color.White;
            this.btnApproval.Location = new System.Drawing.Point(778, 8);
            this.btnApproval.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnApproval.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnApproval.Name = "btnApproval";
            this.btnApproval.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnApproval.Size = new System.Drawing.Size(96, 30);
            this.btnApproval.TabIndex = 5;
            this.btnApproval.Text = "Approve";
            this.btnApproval.TextColor = System.Drawing.Color.White;
            this.btnApproval.UseVisualStyleBackColor = false;
            this.btnApproval.Visible = false;
            this.btnApproval.Click += new System.EventHandler(this.btnApproval_Click);
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.IndianRed;
            this.btnReject.BackgroundColor = System.Drawing.Color.IndianRed;
            this.btnReject.BorderColor = System.Drawing.Color.IndianRed;
            this.btnReject.BorderRadius = 14;
            this.btnReject.BorderSize = 0;
            this.btnReject.FlatAppearance.BorderSize = 0;
            this.btnReject.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnReject.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(886, 8);
            this.btnReject.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnReject.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnReject.Name = "btnReject";
            this.btnReject.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnReject.Size = new System.Drawing.Size(96, 30);
            this.btnReject.TabIndex = 4;
            this.btnReject.Text = "Reject";
            this.btnReject.TextColor = System.Drawing.Color.White;
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Visible = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnclosed
            // 
            this.btnclosed.BackColor = System.Drawing.Color.IndianRed;
            this.btnclosed.BackgroundColor = System.Drawing.Color.IndianRed;
            this.btnclosed.BorderColor = System.Drawing.Color.IndianRed;
            this.btnclosed.BorderRadius = 14;
            this.btnclosed.BorderSize = 0;
            this.btnclosed.FlatAppearance.BorderSize = 0;
            this.btnclosed.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnclosed.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnclosed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclosed.ForeColor = System.Drawing.Color.White;
            this.btnclosed.Location = new System.Drawing.Point(998, 8);
            this.btnclosed.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnclosed.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnclosed.Name = "btnclosed";
            this.btnclosed.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnclosed.Size = new System.Drawing.Size(96, 30);
            this.btnclosed.TabIndex = 1;
            this.btnclosed.Text = "Close";
            this.btnclosed.TextColor = System.Drawing.Color.White;
            this.btnclosed.UseVisualStyleBackColor = false;
            this.btnclosed.Visible = false;
            this.btnclosed.Click += new System.EventHandler(this.btnclosed_Click);
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
            this.btnback.ForeColor = System.Drawing.Color.White;
            this.btnback.Location = new System.Drawing.Point(18, 8);
            this.btnback.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnback.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnback.Name = "btnback";
            this.btnback.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnback.Size = new System.Drawing.Size(96, 30);
            this.btnback.TabIndex = 0;
            this.btnback.Text = "<<Back";
            this.btnback.TextColor = System.Drawing.Color.White;
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Visible = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // contextInventory
            // 
            this.contextInventory.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextInventory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddInverntroy,
            this.Removeinventory,
            this.returnInventory});
            this.contextInventory.Name = "contextInventory";
            this.contextInventory.Size = new System.Drawing.Size(195, 94);
            // 
            // AddInverntroy
            // 
            this.AddInverntroy.Image = global::HindalcoiOS.Properties.Resources.AddToLibrary_32x32;
            this.AddInverntroy.Name = "AddInverntroy";
            this.AddInverntroy.Size = new System.Drawing.Size(194, 30);
            this.AddInverntroy.Tag = "AddINV";
            this.AddInverntroy.Text = "Add Inventory";
            this.AddInverntroy.Click += new System.EventHandler(this.addWorkerToolStripMenuItem_Click);
            // 
            // Removeinventory
            // 
            this.Removeinventory.Image = global::HindalcoiOS.Properties.Resources.DeleteAll;
            this.Removeinventory.Name = "Removeinventory";
            this.Removeinventory.Size = new System.Drawing.Size(194, 30);
            this.Removeinventory.Tag = "RemoveINV";
            this.Removeinventory.Text = "Remove Items";
            this.Removeinventory.Click += new System.EventHandler(this.addWorkerToolStripMenuItem_Click);
            // 
            // returnInventory
            // 
            this.returnInventory.Image = ((System.Drawing.Image)(resources.GetObject("returnInventory.Image")));
            this.returnInventory.Name = "returnInventory";
            this.returnInventory.Size = new System.Drawing.Size(194, 30);
            this.returnInventory.Tag = "ReturnINV";
            this.returnInventory.Text = "Return Inventory";
            this.returnInventory.Click += new System.EventHandler(this.addWorkerToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addWorkerToolStripMenuItem,
            this.removeWorkerToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(248, 64);
            // 
            // addWorkerToolStripMenuItem
            // 
            this.addWorkerToolStripMenuItem.Image = global::HindalcoiOS.Properties.Resources.AddToLibrary_32x32;
            this.addWorkerToolStripMenuItem.Name = "addWorkerToolStripMenuItem";
            this.addWorkerToolStripMenuItem.Size = new System.Drawing.Size(247, 30);
            this.addWorkerToolStripMenuItem.Tag = "Add";
            this.addWorkerToolStripMenuItem.Text = "Add Worker          Alt+A";
            this.addWorkerToolStripMenuItem.Click += new System.EventHandler(this.addWorkerToolStripMenuItem_Click);
            // 
            // removeWorkerToolStripMenuItem
            // 
            this.removeWorkerToolStripMenuItem.Image = global::HindalcoiOS.Properties.Resources.Remove_32x32;
            this.removeWorkerToolStripMenuItem.Name = "removeWorkerToolStripMenuItem";
            this.removeWorkerToolStripMenuItem.Size = new System.Drawing.Size(247, 30);
            this.removeWorkerToolStripMenuItem.Tag = "Remove";
            this.removeWorkerToolStripMenuItem.Text = "Remove Worker    Alt+D";
            this.removeWorkerToolStripMenuItem.Click += new System.EventHandler(this.addWorkerToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportSummaryToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(245, 34);
            // 
            // exportSummaryToolStripMenuItem
            // 
            this.exportSummaryToolStripMenuItem.Image = global::HindalcoiOS.Properties.Resources.AddToLibrary_32x32;
            this.exportSummaryToolStripMenuItem.Name = "exportSummaryToolStripMenuItem";
            this.exportSummaryToolStripMenuItem.Size = new System.Drawing.Size(244, 30);
            this.exportSummaryToolStripMenuItem.Text = "Export Summary   Alt+E";
            this.exportSummaryToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // lblcode
            // 
            this.lblcode.AutoSize = true;
            this.lblcode.Depth = 0;
            this.lblcode.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblcode.Location = new System.Drawing.Point(5, 19);
            this.lblcode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblcode.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblcode.Name = "lblcode";
            this.lblcode.Padding = new System.Windows.Forms.Padding(19, 21, 0, 0);
            this.lblcode.Size = new System.Drawing.Size(165, 42);
            this.lblcode.TabIndex = 3;
            this.lblcode.Text = "Maintenance Code";
            // 
            // txtmntcode
            // 
            this.txtmntcode.BackColor = System.Drawing.SystemColors.Window;
            this.txtmntcode.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtmntcode.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtmntcode.BorderRadius = 0;
            this.txtmntcode.BorderSize = 1;
            this.txtmntcode.Enabled = false;
            this.txtmntcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmntcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtmntcode.Location = new System.Drawing.Point(205, 33);
            this.txtmntcode.Margin = new System.Windows.Forms.Padding(4);
            this.txtmntcode.Multiline = false;
            this.txtmntcode.Name = "txtmntcode";
            this.txtmntcode.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.txtmntcode.PasswordChar = false;
            this.txtmntcode.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtmntcode.PlaceholderText = "Maintennenace Code";
            this.txtmntcode.Size = new System.Drawing.Size(243, 33);
            this.txtmntcode.TabIndex = 4;
            this.txtmntcode.UnderlinedStyle = false;
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Depth = 0;
            this.lbldate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lbldate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbldate.Location = new System.Drawing.Point(5, 61);
            this.lbldate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbldate.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lbldate.Name = "lbldate";
            this.lbldate.Padding = new System.Windows.Forms.Padding(19, 21, 0, 0);
            this.lbldate.Size = new System.Drawing.Size(164, 42);
            this.lbldate.TabIndex = 5;
            this.lbldate.Text = "Maintenance Date";
            // 
            // DatePickerMNTDate
            // 
            this.DatePickerMNTDate.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.DatePickerMNTDate.BorderSize = 0;
            this.DatePickerMNTDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.DatePickerMNTDate.Location = new System.Drawing.Point(205, 78);
            this.DatePickerMNTDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DatePickerMNTDate.MinimumSize = new System.Drawing.Size(4, 35);
            this.DatePickerMNTDate.Name = "DatePickerMNTDate";
            this.DatePickerMNTDate.Size = new System.Drawing.Size(244, 35);
            this.DatePickerMNTDate.SkinColor = System.Drawing.Color.MediumSlateBlue;
            this.DatePickerMNTDate.TabIndex = 6;
            this.DatePickerMNTDate.TextColor = System.Drawing.Color.White;
            // 
            // lbloperationPlant
            // 
            this.lbloperationPlant.AutoSize = true;
            this.lbloperationPlant.Depth = 0;
            this.lbloperationPlant.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lbloperationPlant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbloperationPlant.Location = new System.Drawing.Point(5, 103);
            this.lbloperationPlant.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbloperationPlant.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lbloperationPlant.Name = "lbloperationPlant";
            this.lbloperationPlant.Padding = new System.Windows.Forms.Padding(19, 21, 0, 0);
            this.lbloperationPlant.Size = new System.Drawing.Size(144, 42);
            this.lbloperationPlant.TabIndex = 7;
            this.lbloperationPlant.Text = "Operation Plant";
            // 
            // dropdownOP
            // 
            this.dropdownOP.BorderColor = System.Drawing.Color.DodgerBlue;
            this.dropdownOP.BorderSize = 1;
            this.dropdownOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropdownOP.FormattingEnabled = true;
            this.dropdownOP.IconColor = System.Drawing.Color.DodgerBlue;
            this.dropdownOP.ItemHeight = 22;
            this.dropdownOP.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.dropdownOP.ListTextColor = System.Drawing.Color.White;
            this.dropdownOP.Location = new System.Drawing.Point(205, 125);
            this.dropdownOP.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dropdownOP.MinimumSize = new System.Drawing.Size(156, 0);
            this.dropdownOP.Name = "dropdownOP";
            this.dropdownOP.Size = new System.Drawing.Size(244, 30);
            this.dropdownOP.TabIndex = 12;
            this.dropdownOP.SelectedIndexChanged += new System.EventHandler(this.dropdownOP_SelectedIndexChanged);
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Depth = 0;
            this.lblstatus.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblstatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblstatus.Location = new System.Drawing.Point(6, 144);
            this.lblstatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblstatus.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Padding = new System.Windows.Forms.Padding(19, 21, 0, 0);
            this.lblstatus.Size = new System.Drawing.Size(76, 42);
            this.lblstatus.TabIndex = 9;
            this.lblstatus.Text = "Status";
            // 
            // dropdownstatus
            // 
            this.dropdownstatus.BorderColor = System.Drawing.Color.DodgerBlue;
            this.dropdownstatus.BorderSize = 1;
            this.dropdownstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropdownstatus.FormattingEnabled = true;
            this.dropdownstatus.IconColor = System.Drawing.Color.DodgerBlue;
            this.dropdownstatus.ItemHeight = 22;
            this.dropdownstatus.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.dropdownstatus.ListTextColor = System.Drawing.Color.White;
            this.dropdownstatus.Location = new System.Drawing.Point(205, 167);
            this.dropdownstatus.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dropdownstatus.MinimumSize = new System.Drawing.Size(156, 0);
            this.dropdownstatus.Name = "dropdownstatus";
            this.dropdownstatus.Size = new System.Drawing.Size(244, 30);
            this.dropdownstatus.TabIndex = 10;
            this.dropdownstatus.SelectedIndexChanged += new System.EventHandler(this.dropdownstatus_SelectedValueChanged);
            // 
            // lblmachinetag
            // 
            this.lblmachinetag.AutoSize = true;
            this.lblmachinetag.Depth = 0;
            this.lblmachinetag.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblmachinetag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblmachinetag.Location = new System.Drawing.Point(6, 192);
            this.lblmachinetag.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblmachinetag.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblmachinetag.Name = "lblmachinetag";
            this.lblmachinetag.Padding = new System.Windows.Forms.Padding(19, 21, 0, 0);
            this.lblmachinetag.Size = new System.Drawing.Size(123, 42);
            this.lblmachinetag.TabIndex = 11;
            this.lblmachinetag.Text = "Machine Tag";
            // 
            // lblothers
            // 
            this.lblothers.AutoSize = true;
            this.lblothers.Depth = 0;
            this.lblothers.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblothers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblothers.Location = new System.Drawing.Point(7, 233);
            this.lblothers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblothers.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblothers.Name = "lblothers";
            this.lblothers.Padding = new System.Windows.Forms.Padding(19, 21, 0, 0);
            this.lblothers.Size = new System.Drawing.Size(79, 42);
            this.lblothers.TabIndex = 12;
            this.lblothers.Text = "Others";
            // 
            // lbldescription
            // 
            this.lbldescription.AutoSize = true;
            this.lbldescription.Depth = 0;
            this.lbldescription.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lbldescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbldescription.Location = new System.Drawing.Point(7, 275);
            this.lbldescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbldescription.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lbldescription.Name = "lbldescription";
            this.lbldescription.Padding = new System.Windows.Forms.Padding(19, 21, 0, 0);
            this.lbldescription.Size = new System.Drawing.Size(113, 42);
            this.lbldescription.TabIndex = 13;
            this.lbldescription.Text = "Description";
            // 
            // dropdownmachinetag
            // 
            this.dropdownmachinetag.BorderColor = System.Drawing.Color.DodgerBlue;
            this.dropdownmachinetag.BorderSize = 1;
            this.dropdownmachinetag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropdownmachinetag.FormattingEnabled = true;
            this.dropdownmachinetag.IconColor = System.Drawing.Color.DodgerBlue;
            this.dropdownmachinetag.ItemHeight = 22;
            this.dropdownmachinetag.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.dropdownmachinetag.ListTextColor = System.Drawing.Color.White;
            this.dropdownmachinetag.Location = new System.Drawing.Point(206, 209);
            this.dropdownmachinetag.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dropdownmachinetag.MinimumSize = new System.Drawing.Size(156, 0);
            this.dropdownmachinetag.Name = "dropdownmachinetag";
            this.dropdownmachinetag.Size = new System.Drawing.Size(244, 30);
            this.dropdownmachinetag.TabIndex = 14;
            this.dropdownmachinetag.SelectedIndexChanged += new System.EventHandler(this.dropdownmachinetag_SelectedIndexChanged);
            // 
            // txtothers
            // 
            this.txtothers.BackColor = System.Drawing.SystemColors.Window;
            this.txtothers.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtothers.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtothers.BorderRadius = 0;
            this.txtothers.BorderSize = 1;
            this.txtothers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtothers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtothers.Location = new System.Drawing.Point(206, 251);
            this.txtothers.Margin = new System.Windows.Forms.Padding(4);
            this.txtothers.Multiline = false;
            this.txtothers.Name = "txtothers";
            this.txtothers.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.txtothers.PasswordChar = false;
            this.txtothers.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtothers.PlaceholderText = "";
            this.txtothers.Size = new System.Drawing.Size(243, 33);
            this.txtothers.TabIndex = 15;
            this.txtothers.UnderlinedStyle = false;
            this.txtothers.Leave += new System.EventHandler(this.txtothers_Leave);
            // 
            // rtchtext
            // 
            this.rtchtext.AutoScroll = true;
            this.rtchtext.BackColor = System.Drawing.SystemColors.Window;
            this.rtchtext.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rtchtext.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.rtchtext.BorderRadius = 0;
            this.rtchtext.BorderSize = 1;
            this.rtchtext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtchtext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rtchtext.Location = new System.Drawing.Point(23, 329);
            this.rtchtext.Margin = new System.Windows.Forms.Padding(4);
            this.rtchtext.Multiline = true;
            this.rtchtext.Name = "rtchtext";
            this.rtchtext.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.rtchtext.PasswordChar = false;
            this.rtchtext.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.rtchtext.PlaceholderText = "";
            this.rtchtext.Size = new System.Drawing.Size(426, 88);
            this.rtchtext.TabIndex = 16;
            this.rtchtext.UnderlinedStyle = false;
            this.rtchtext.Leave += new System.EventHandler(this.rtchtext_Leave);
            // 
            // lblpriority
            // 
            this.lblpriority.AutoSize = true;
            this.lblpriority.Depth = 0;
            this.lblpriority.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblpriority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblpriority.Location = new System.Drawing.Point(618, 8);
            this.lblpriority.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblpriority.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblpriority.Name = "lblpriority";
            this.lblpriority.Padding = new System.Windows.Forms.Padding(0, 21, 0, 0);
            this.lblpriority.Size = new System.Drawing.Size(62, 42);
            this.lblpriority.TabIndex = 17;
            this.lblpriority.Text = "Priority";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Depth = 0;
            this.lblArea.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblArea.Location = new System.Drawing.Point(617, 54);
            this.lblArea.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblArea.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblArea.Name = "lblArea";
            this.lblArea.Padding = new System.Windows.Forms.Padding(0, 21, 0, 0);
            this.lblArea.Size = new System.Drawing.Size(45, 42);
            this.lblArea.TabIndex = 18;
            this.lblArea.Text = "Area";
            // 
            // lblexpectedtime
            // 
            this.lblexpectedtime.AutoSize = true;
            this.lblexpectedtime.Depth = 0;
            this.lblexpectedtime.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblexpectedtime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblexpectedtime.Location = new System.Drawing.Point(617, 142);
            this.lblexpectedtime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblexpectedtime.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblexpectedtime.Name = "lblexpectedtime";
            this.lblexpectedtime.Padding = new System.Windows.Forms.Padding(0, 21, 0, 0);
            this.lblexpectedtime.Size = new System.Drawing.Size(200, 42);
            this.lblexpectedtime.TabIndex = 19;
            this.lblexpectedtime.Text = "Estimated Time (HH:MM)";
            // 
            // lblextactlocation
            // 
            this.lblextactlocation.AutoSize = true;
            this.lblextactlocation.Depth = 0;
            this.lblextactlocation.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblextactlocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblextactlocation.Location = new System.Drawing.Point(617, 96);
            this.lblextactlocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblextactlocation.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblextactlocation.Name = "lblextactlocation";
            this.lblextactlocation.Padding = new System.Windows.Forms.Padding(0, 21, 0, 0);
            this.lblextactlocation.Size = new System.Drawing.Size(118, 42);
            this.lblextactlocation.TabIndex = 20;
            this.lblextactlocation.Text = "Exact Location";
            // 
            // lblreportedby
            // 
            this.lblreportedby.AutoSize = true;
            this.lblreportedby.Depth = 0;
            this.lblreportedby.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblreportedby.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblreportedby.Location = new System.Drawing.Point(620, 184);
            this.lblreportedby.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblreportedby.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblreportedby.Name = "lblreportedby";
            this.lblreportedby.Padding = new System.Windows.Forms.Padding(0, 21, 0, 0);
            this.lblreportedby.Size = new System.Drawing.Size(101, 42);
            this.lblreportedby.TabIndex = 21;
            this.lblreportedby.Text = "Reported By";
            // 
            // lblAssignTo
            // 
            this.lblAssignTo.AutoSize = true;
            this.lblAssignTo.Depth = 0;
            this.lblAssignTo.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblAssignTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAssignTo.Location = new System.Drawing.Point(620, 225);
            this.lblAssignTo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAssignTo.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblAssignTo.Name = "lblAssignTo";
            this.lblAssignTo.Padding = new System.Windows.Forms.Padding(0, 21, 0, 0);
            this.lblAssignTo.Size = new System.Drawing.Size(83, 42);
            this.lblAssignTo.TabIndex = 22;
            this.lblAssignTo.Text = "Assign To";
            // 
            // lblcomments
            // 
            this.lblcomments.AutoSize = true;
            this.lblcomments.Depth = 0;
            this.lblcomments.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblcomments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblcomments.Location = new System.Drawing.Point(618, 271);
            this.lblcomments.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblcomments.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblcomments.Name = "lblcomments";
            this.lblcomments.Padding = new System.Windows.Forms.Padding(0, 21, 0, 0);
            this.lblcomments.Size = new System.Drawing.Size(89, 42);
            this.lblcomments.TabIndex = 23;
            this.lblcomments.Text = "Comments";
            // 
            // dropdownpriority
            // 
            this.dropdownpriority.BorderColor = System.Drawing.Color.DodgerBlue;
            this.dropdownpriority.BorderSize = 1;
            this.dropdownpriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dropdownpriority.FormattingEnabled = true;
            this.dropdownpriority.IconColor = System.Drawing.Color.DodgerBlue;
            this.dropdownpriority.ItemHeight = 20;
            this.dropdownpriority.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.dropdownpriority.ListTextColor = System.Drawing.Color.White;
            this.dropdownpriority.Location = new System.Drawing.Point(825, 22);
            this.dropdownpriority.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dropdownpriority.MinimumSize = new System.Drawing.Size(156, 0);
            this.dropdownpriority.Name = "dropdownpriority";
            this.dropdownpriority.Size = new System.Drawing.Size(244, 28);
            this.dropdownpriority.TabIndex = 24;
            this.dropdownpriority.SelectedIndexChanged += new System.EventHandler(this.dropdownpriority_SelectedIndexChanged);
            // 
            // txtArea
            // 
            this.txtArea.BackColor = System.Drawing.SystemColors.Window;
            this.txtArea.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtArea.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtArea.BorderRadius = 0;
            this.txtArea.BorderSize = 1;
            this.txtArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtArea.Location = new System.Drawing.Point(825, 64);
            this.txtArea.Margin = new System.Windows.Forms.Padding(4);
            this.txtArea.Multiline = false;
            this.txtArea.Name = "txtArea";
            this.txtArea.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.txtArea.PasswordChar = false;
            this.txtArea.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtArea.PlaceholderText = "";
            this.txtArea.Size = new System.Drawing.Size(243, 33);
            this.txtArea.TabIndex = 25;
            this.txtArea.UnderlinedStyle = false;
            this.txtArea.Leave += new System.EventHandler(this.txtArea_Leave);
            // 
            // txtExtactlocation
            // 
            this.txtExtactlocation.BackColor = System.Drawing.SystemColors.Window;
            this.txtExtactlocation.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtExtactlocation.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtExtactlocation.BorderRadius = 0;
            this.txtExtactlocation.BorderSize = 1;
            this.txtExtactlocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExtactlocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtExtactlocation.Location = new System.Drawing.Point(825, 111);
            this.txtExtactlocation.Margin = new System.Windows.Forms.Padding(4);
            this.txtExtactlocation.Multiline = false;
            this.txtExtactlocation.Name = "txtExtactlocation";
            this.txtExtactlocation.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.txtExtactlocation.PasswordChar = false;
            this.txtExtactlocation.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtExtactlocation.PlaceholderText = "";
            this.txtExtactlocation.Size = new System.Drawing.Size(243, 33);
            this.txtExtactlocation.TabIndex = 26;
            this.txtExtactlocation.UnderlinedStyle = false;
            this.txtExtactlocation.Leave += new System.EventHandler(this.txtExtactlocation_Leave);
            // 
            // txtReportedby
            // 
            this.txtReportedby.BackColor = System.Drawing.SystemColors.Window;
            this.txtReportedby.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtReportedby.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtReportedby.BorderRadius = 0;
            this.txtReportedby.BorderSize = 1;
            this.txtReportedby.Enabled = false;
            this.txtReportedby.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReportedby.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtReportedby.Location = new System.Drawing.Point(828, 195);
            this.txtReportedby.Margin = new System.Windows.Forms.Padding(4);
            this.txtReportedby.Multiline = false;
            this.txtReportedby.Name = "txtReportedby";
            this.txtReportedby.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.txtReportedby.PasswordChar = false;
            this.txtReportedby.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtReportedby.PlaceholderText = "";
            this.txtReportedby.Size = new System.Drawing.Size(243, 33);
            this.txtReportedby.TabIndex = 29;
            this.txtReportedby.UnderlinedStyle = false;
            // 
            // dropdownAssignTo
            // 
            this.dropdownAssignTo.BorderColor = System.Drawing.Color.DodgerBlue;
            this.dropdownAssignTo.BorderSize = 1;
            this.dropdownAssignTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropdownAssignTo.FormattingEnabled = true;
            this.dropdownAssignTo.IconColor = System.Drawing.Color.DodgerBlue;
            this.dropdownAssignTo.ItemHeight = 22;
            this.dropdownAssignTo.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.dropdownAssignTo.ListTextColor = System.Drawing.Color.White;
            this.dropdownAssignTo.Location = new System.Drawing.Point(828, 242);
            this.dropdownAssignTo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dropdownAssignTo.MinimumSize = new System.Drawing.Size(156, 0);
            this.dropdownAssignTo.Name = "dropdownAssignTo";
            this.dropdownAssignTo.Size = new System.Drawing.Size(244, 30);
            this.dropdownAssignTo.TabIndex = 30;
            this.dropdownAssignTo.SelectedIndexChanged += new System.EventHandler(this.dropdownAssignTo_SelectedIndexChanged);
            // 
            // rtchcomments
            // 
            this.rtchcomments.BackColor = System.Drawing.SystemColors.Window;
            this.rtchcomments.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rtchcomments.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.rtchcomments.BorderRadius = 0;
            this.rtchcomments.BorderSize = 1;
            this.rtchcomments.Enabled = false;
            this.rtchcomments.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtchcomments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rtchcomments.Location = new System.Drawing.Point(621, 323);
            this.rtchcomments.Margin = new System.Windows.Forms.Padding(4);
            this.rtchcomments.Multiline = true;
            this.rtchcomments.Name = "rtchcomments";
            this.rtchcomments.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.rtchcomments.PasswordChar = false;
            this.rtchcomments.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.rtchcomments.PlaceholderText = "";
            this.rtchcomments.Size = new System.Drawing.Size(426, 88);
            this.rtchcomments.TabIndex = 31;
            this.rtchcomments.UnderlinedStyle = false;
            // 
            // btnsumbitaprl
            // 
            this.btnsumbitaprl.BackColor = System.Drawing.Color.SeaGreen;
            this.btnsumbitaprl.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.btnsumbitaprl.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnsumbitaprl.BorderRadius = 14;
            this.btnsumbitaprl.BorderSize = 0;
            this.btnsumbitaprl.FlatAppearance.BorderSize = 0;
            this.btnsumbitaprl.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnsumbitaprl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnsumbitaprl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsumbitaprl.ForeColor = System.Drawing.Color.White;
            this.btnsumbitaprl.Location = new System.Drawing.Point(621, 419);
            this.btnsumbitaprl.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnsumbitaprl.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnsumbitaprl.Name = "btnsumbitaprl";
            this.btnsumbitaprl.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnsumbitaprl.Size = new System.Drawing.Size(128, 30);
            this.btnsumbitaprl.TabIndex = 6;
            this.btnsumbitaprl.Text = "Submit Document";
            this.btnsumbitaprl.TextColor = System.Drawing.Color.White;
            this.btnsumbitaprl.UseVisualStyleBackColor = false;
            this.btnsumbitaprl.Click += new System.EventHandler(this.btnsumbitaprl_Click);
            // 
            // btnAddWorker
            // 
            this.btnAddWorker.BackColor = System.Drawing.Color.Gray;
            this.btnAddWorker.BackgroundColor = System.Drawing.Color.Gray;
            this.btnAddWorker.BorderColor = System.Drawing.Color.Gray;
            this.btnAddWorker.BorderRadius = 14;
            this.btnAddWorker.BorderSize = 0;
            this.btnAddWorker.FlatAppearance.BorderSize = 0;
            this.btnAddWorker.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAddWorker.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAddWorker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddWorker.ForeColor = System.Drawing.Color.White;
            this.btnAddWorker.Location = new System.Drawing.Point(791, 420);
            this.btnAddWorker.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAddWorker.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAddWorker.Name = "btnAddWorker";
            this.btnAddWorker.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnAddWorker.Size = new System.Drawing.Size(128, 30);
            this.btnAddWorker.TabIndex = 32;
            this.btnAddWorker.Text = "Add Worker";
            this.btnAddWorker.TextColor = System.Drawing.Color.White;
            this.btnAddWorker.UseVisualStyleBackColor = false;
            this.btnAddWorker.Click += new System.EventHandler(this.btnAddWorker_Click);
            // 
            // btnInvertory
            // 
            this.btnInvertory.BackColor = System.Drawing.Color.Gray;
            this.btnInvertory.BackgroundColor = System.Drawing.Color.Gray;
            this.btnInvertory.BorderColor = System.Drawing.Color.Gray;
            this.btnInvertory.BorderRadius = 14;
            this.btnInvertory.BorderSize = 0;
            this.btnInvertory.FlatAppearance.BorderSize = 0;
            this.btnInvertory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnInvertory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnInvertory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvertory.ForeColor = System.Drawing.Color.White;
            this.btnInvertory.Location = new System.Drawing.Point(941, 420);
            this.btnInvertory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnInvertory.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnInvertory.Name = "btnInvertory";
            this.btnInvertory.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnInvertory.Size = new System.Drawing.Size(128, 30);
            this.btnInvertory.TabIndex = 33;
            this.btnInvertory.Text = "Add Inventory";
            this.btnInvertory.TextColor = System.Drawing.Color.White;
            this.btnInvertory.UseVisualStyleBackColor = false;
            this.btnInvertory.Click += new System.EventHandler(this.btnInvertory_Click);
            // 
            // numericMinutes
            // 
            this.numericMinutes.BorderColor = System.Drawing.Color.DodgerBlue;
            this.numericMinutes.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericMinutes.Location = new System.Drawing.Point(951, 158);
            this.numericMinutes.Name = "numericMinutes";
            this.numericMinutes.Size = new System.Drawing.Size(120, 28);
            this.numericMinutes.TabIndex = 35;
            this.numericMinutes.Leave += new System.EventHandler(this.txtexpectedtimeInmutes_Leave);
            // 
            // numericHour
            // 
            this.numericHour.BorderColor = System.Drawing.Color.DodgerBlue;
            this.numericHour.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericHour.Location = new System.Drawing.Point(825, 158);
            this.numericHour.Name = "numericHour";
            this.numericHour.Size = new System.Drawing.Size(120, 28);
            this.numericHour.TabIndex = 34;
            this.numericHour.Leave += new System.EventHandler(this.txtexpectedtime_Leave);
            // 
            // DGVRequestDetails
            // 
            this.DGVRequestDetails.AllowUserToAddRows = false;
            this.DGVRequestDetails.AllowUserToDeleteRows = false;
            this.DGVRequestDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DGVRequestDetails.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.DGVRequestDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVRequestDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVRequestDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVRequestDetails.ColumnHeadersHeight = 40;
            this.DGVRequestDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVRequestDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MCode,
            this.MaintenanceDate,
            this.OperationPlant,
            this.Statuss,
            this.MachineTag,
            this.Others,
            this.Priority,
            this.ExactLocation,
            this.EstimatedTime,
            this.Area,
            this.ReportedBy,
            this.AssignTo,
            this.Description,
            this.Remark});
            this.DGVRequestDetails.ContextMenuStrip = this.contextMenuStrip2;
            this.DGVRequestDetails.EnableHeadersVisualStyles = false;
            this.DGVRequestDetails.Location = new System.Drawing.Point(657, 521);
            this.DGVRequestDetails.Name = "DGVRequestDetails";
            this.DGVRequestDetails.ReadOnly = true;
            this.DGVRequestDetails.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVRequestDetails.RowHeadersVisible = false;
            this.DGVRequestDetails.RowHeadersWidth = 51;
            this.DGVRequestDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.DGVRequestDetails.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVRequestDetails.RowTemplate.Height = 24;
            this.DGVRequestDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVRequestDetails.Size = new System.Drawing.Size(15, 13);
            this.DGVRequestDetails.TabIndex = 1;
            this.DGVRequestDetails.Visible = false;
            this.DGVRequestDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVRequestDetails_CellClick);
            this.DGVRequestDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSelectAll_CellContentClick);
            this.DGVRequestDetails.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVRequestDetails_CellContentDoubleClick);
            this.DGVRequestDetails.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGVRequestDetails_CellFormatting);
            // 
            // MCode
            // 
            this.MCode.HeaderText = "Maintenance Code";
            this.MCode.MinimumWidth = 6;
            this.MCode.Name = "MCode";
            this.MCode.ReadOnly = true;
            this.MCode.Width = 148;
            // 
            // MaintenanceDate
            // 
            this.MaintenanceDate.HeaderText = "Maintenance Date";
            this.MaintenanceDate.MinimumWidth = 6;
            this.MaintenanceDate.Name = "MaintenanceDate";
            this.MaintenanceDate.ReadOnly = true;
            this.MaintenanceDate.Width = 145;
            // 
            // OperationPlant
            // 
            this.OperationPlant.HeaderText = "Operation Plant";
            this.OperationPlant.MinimumWidth = 6;
            this.OperationPlant.Name = "OperationPlant";
            this.OperationPlant.ReadOnly = true;
            this.OperationPlant.Width = 130;
            // 
            // Statuss
            // 
            this.Statuss.HeaderText = "Status";
            this.Statuss.MinimumWidth = 6;
            this.Statuss.Name = "Statuss";
            this.Statuss.ReadOnly = true;
            this.Statuss.Width = 75;
            // 
            // MachineTag
            // 
            this.MachineTag.HeaderText = "Machine Tag";
            this.MachineTag.MinimumWidth = 6;
            this.MachineTag.Name = "MachineTag";
            this.MachineTag.ReadOnly = true;
            this.MachineTag.Width = 112;
            // 
            // Others
            // 
            this.Others.HeaderText = "Others";
            this.Others.MinimumWidth = 6;
            this.Others.Name = "Others";
            this.Others.ReadOnly = true;
            this.Others.Width = 77;
            // 
            // Priority
            // 
            this.Priority.HeaderText = "Priority";
            this.Priority.MinimumWidth = 6;
            this.Priority.Name = "Priority";
            this.Priority.ReadOnly = true;
            this.Priority.Width = 79;
            // 
            // ExactLocation
            // 
            this.ExactLocation.HeaderText = "Exact Location";
            this.ExactLocation.MinimumWidth = 6;
            this.ExactLocation.Name = "ExactLocation";
            this.ExactLocation.ReadOnly = true;
            this.ExactLocation.Width = 127;
            // 
            // EstimatedTime
            // 
            this.EstimatedTime.HeaderText = "Estimated Time";
            this.EstimatedTime.MinimumWidth = 6;
            this.EstimatedTime.Name = "EstimatedTime";
            this.EstimatedTime.ReadOnly = true;
            this.EstimatedTime.Width = 129;
            // 
            // Area
            // 
            this.Area.HeaderText = "Area";
            this.Area.MinimumWidth = 6;
            this.Area.Name = "Area";
            this.Area.ReadOnly = true;
            this.Area.Width = 63;
            // 
            // ReportedBy
            // 
            this.ReportedBy.HeaderText = "Reported By";
            this.ReportedBy.MinimumWidth = 6;
            this.ReportedBy.Name = "ReportedBy";
            this.ReportedBy.ReadOnly = true;
            this.ReportedBy.Width = 113;
            // 
            // AssignTo
            // 
            this.AssignTo.HeaderText = "Assign To";
            this.AssignTo.MinimumWidth = 6;
            this.AssignTo.Name = "AssignTo";
            this.AssignTo.ReadOnly = true;
            this.AssignTo.Width = 94;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 104;
            // 
            // Remark
            // 
            this.Remark.HeaderText = "Remark";
            this.Remark.MinimumWidth = 6;
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.Width = 83;
            // 
            // tabcontrolMNT
            // 
            this.tabcontrolMNT.Controls.Add(this.Worker);
            this.tabcontrolMNT.Controls.Add(this.Inventory);
            // 
            // 
            // 
            this.tabcontrolMNT.DisplayStyleProvider.BlendStyle = SparrowRMSControl.SparrowControl.BlendStyle.Normal;
            this.tabcontrolMNT.DisplayStyleProvider.BorderColorDisabled = System.Drawing.SystemColors.ControlLight;
            this.tabcontrolMNT.DisplayStyleProvider.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.tabcontrolMNT.DisplayStyleProvider.BorderColorHighlighted = System.Drawing.SystemColors.ControlDark;
            this.tabcontrolMNT.DisplayStyleProvider.BorderColorSelected = System.Drawing.SystemColors.ControlDark;
            this.tabcontrolMNT.DisplayStyleProvider.BorderColorUnselected = System.Drawing.SystemColors.ControlDark;
            this.tabcontrolMNT.DisplayStyleProvider.CloserButtonFillColorFocused = System.Drawing.Color.Empty;
            this.tabcontrolMNT.DisplayStyleProvider.CloserButtonFillColorFocusedActive = System.Drawing.Color.Empty;
            this.tabcontrolMNT.DisplayStyleProvider.CloserButtonFillColorHighlighted = System.Drawing.Color.Empty;
            this.tabcontrolMNT.DisplayStyleProvider.CloserButtonFillColorHighlightedActive = System.Drawing.Color.Empty;
            this.tabcontrolMNT.DisplayStyleProvider.CloserButtonFillColorSelected = System.Drawing.Color.Empty;
            this.tabcontrolMNT.DisplayStyleProvider.CloserButtonFillColorSelectedActive = System.Drawing.Color.Empty;
            this.tabcontrolMNT.DisplayStyleProvider.CloserButtonFillColorUnselected = System.Drawing.Color.Empty;
            this.tabcontrolMNT.DisplayStyleProvider.CloserButtonOutlineColorFocused = System.Drawing.Color.Empty;
            this.tabcontrolMNT.DisplayStyleProvider.CloserButtonOutlineColorFocusedActive = System.Drawing.Color.Empty;
            this.tabcontrolMNT.DisplayStyleProvider.CloserButtonOutlineColorHighlighted = System.Drawing.Color.Empty;
            this.tabcontrolMNT.DisplayStyleProvider.CloserButtonOutlineColorHighlightedActive = System.Drawing.Color.Empty;
            this.tabcontrolMNT.DisplayStyleProvider.CloserButtonOutlineColorSelected = System.Drawing.Color.Empty;
            this.tabcontrolMNT.DisplayStyleProvider.CloserButtonOutlineColorSelectedActive = System.Drawing.Color.Empty;
            this.tabcontrolMNT.DisplayStyleProvider.CloserButtonOutlineColorUnselected = System.Drawing.Color.Empty;
            this.tabcontrolMNT.DisplayStyleProvider.CloserColorFocused = System.Drawing.SystemColors.ControlDark;
            this.tabcontrolMNT.DisplayStyleProvider.CloserColorFocusedActive = System.Drawing.SystemColors.ControlDark;
            this.tabcontrolMNT.DisplayStyleProvider.CloserColorHighlighted = System.Drawing.SystemColors.ControlDark;
            this.tabcontrolMNT.DisplayStyleProvider.CloserColorHighlightedActive = System.Drawing.SystemColors.ControlDark;
            this.tabcontrolMNT.DisplayStyleProvider.CloserColorSelected = System.Drawing.SystemColors.ControlDark;
            this.tabcontrolMNT.DisplayStyleProvider.CloserColorSelectedActive = System.Drawing.SystemColors.ControlDark;
            this.tabcontrolMNT.DisplayStyleProvider.CloserColorUnselected = System.Drawing.Color.Empty;
            this.tabcontrolMNT.DisplayStyleProvider.FocusTrack = false;
            this.tabcontrolMNT.DisplayStyleProvider.HotTrack = true;
            this.tabcontrolMNT.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tabcontrolMNT.DisplayStyleProvider.Opacity = 1F;
            this.tabcontrolMNT.DisplayStyleProvider.Overlap = 0;
            this.tabcontrolMNT.DisplayStyleProvider.Padding = new System.Drawing.Point(6, 3);
            this.tabcontrolMNT.DisplayStyleProvider.PageBackgroundColorDisabled = System.Drawing.SystemColors.Control;
            this.tabcontrolMNT.DisplayStyleProvider.PageBackgroundColorFocused = System.Drawing.Color.DodgerBlue;
            this.tabcontrolMNT.DisplayStyleProvider.PageBackgroundColorHighlighted = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.tabcontrolMNT.DisplayStyleProvider.PageBackgroundColorSelected = System.Drawing.SystemColors.ControlLightLight;
            this.tabcontrolMNT.DisplayStyleProvider.PageBackgroundColorUnselected = System.Drawing.SystemColors.Control;
            this.tabcontrolMNT.DisplayStyleProvider.Radius = 2;
            this.tabcontrolMNT.DisplayStyleProvider.SelectedTabIsLarger = true;
            this.tabcontrolMNT.DisplayStyleProvider.ShowTabCloser = false;
            this.tabcontrolMNT.DisplayStyleProvider.TabColorDisabled1 = System.Drawing.SystemColors.Control;
            this.tabcontrolMNT.DisplayStyleProvider.TabColorDisabled2 = System.Drawing.SystemColors.Control;
            this.tabcontrolMNT.DisplayStyleProvider.TabColorFocused1 = System.Drawing.Color.DodgerBlue;
            this.tabcontrolMNT.DisplayStyleProvider.TabColorFocused2 = System.Drawing.Color.DodgerBlue;
            this.tabcontrolMNT.DisplayStyleProvider.TabColorHighLighted1 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.tabcontrolMNT.DisplayStyleProvider.TabColorHighLighted2 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.tabcontrolMNT.DisplayStyleProvider.TabColorSelected1 = System.Drawing.SystemColors.ControlLightLight;
            this.tabcontrolMNT.DisplayStyleProvider.TabColorSelected2 = System.Drawing.SystemColors.ControlLightLight;
            this.tabcontrolMNT.DisplayStyleProvider.TabColorUnSelected1 = System.Drawing.SystemColors.Control;
            this.tabcontrolMNT.DisplayStyleProvider.TabColorUnSelected2 = System.Drawing.SystemColors.Control;
            this.tabcontrolMNT.DisplayStyleProvider.TabPageMargin = new System.Windows.Forms.Padding(1);
            this.tabcontrolMNT.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.tabcontrolMNT.DisplayStyleProvider.TextColorFocused = System.Drawing.Color.White;
            this.tabcontrolMNT.DisplayStyleProvider.TextColorHighlighted = System.Drawing.SystemColors.ControlText;
            this.tabcontrolMNT.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.tabcontrolMNT.DisplayStyleProvider.TextColorUnselected = System.Drawing.SystemColors.ControlText;
            this.tabcontrolMNT.HotTrack = true;
            this.tabcontrolMNT.Location = new System.Drawing.Point(11, 540);
            this.tabcontrolMNT.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabcontrolMNT.Name = "tabcontrolMNT";
            this.tabcontrolMNT.SelectedIndex = 0;
            this.tabcontrolMNT.SelectTabColor = System.Drawing.Color.DodgerBlue;
            this.tabcontrolMNT.SelectTabLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabcontrolMNT.Size = new System.Drawing.Size(1114, 219);
            this.tabcontrolMNT.TabColor = System.Drawing.Color.DodgerBlue;
            this.tabcontrolMNT.TabIndex = 35;
            this.tabcontrolMNT.SelectedIndexChanged += new System.EventHandler(this.tabcontrolMNT_SelectedIndexChanged);
            // 
            // Worker
            // 
            this.Worker.Controls.Add(this.DGVWorker);
            this.Worker.Location = new System.Drawing.Point(4, 30);
            this.Worker.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Worker.Name = "Worker";
            this.Worker.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Worker.Size = new System.Drawing.Size(1106, 185);
            this.Worker.TabIndex = 0;
            this.Worker.Text = "Worker";
            this.Worker.UseVisualStyleBackColor = true;
            // 
            // DGVWorker
            // 
            this.DGVWorker.AllowUserToAddRows = false;
            this.DGVWorker.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVWorker.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVWorker.ColumnHeadersHeight = 35;
            this.DGVWorker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVWorker.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WorkerName,
            this.MaintenanceCode,
            this.StatusW});
            this.DGVWorker.ContextMenuStrip = this.contextMenuStrip1;
            this.DGVWorker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVWorker.EnableHeadersVisualStyles = false;
            this.DGVWorker.Location = new System.Drawing.Point(2, 3);
            this.DGVWorker.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DGVWorker.Name = "DGVWorker";
            this.DGVWorker.RowHeadersVisible = false;
            this.DGVWorker.RowHeadersWidth = 62;
            this.DGVWorker.RowTemplate.Height = 28;
            this.DGVWorker.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVWorker.Size = new System.Drawing.Size(1102, 179);
            this.DGVWorker.TabIndex = 0;
            this.DGVWorker.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGVWorker_EditingControlShowing);
            // 
            // WorkerName
            // 
            this.WorkerName.HeaderText = "Worker Name";
            this.WorkerName.MinimumWidth = 8;
            this.WorkerName.Name = "WorkerName";
            this.WorkerName.Width = 150;
            // 
            // MaintenanceCode
            // 
            this.MaintenanceCode.HeaderText = "Maintenance Code";
            this.MaintenanceCode.MinimumWidth = 8;
            this.MaintenanceCode.Name = "MaintenanceCode";
            this.MaintenanceCode.Visible = false;
            this.MaintenanceCode.Width = 150;
            // 
            // StatusW
            // 
            this.StatusW.HeaderText = "Status";
            this.StatusW.MinimumWidth = 8;
            this.StatusW.Name = "StatusW";
            this.StatusW.Visible = false;
            this.StatusW.Width = 150;
            // 
            // Inventory
            // 
            this.Inventory.Controls.Add(this.DGVInventory);
            this.Inventory.Location = new System.Drawing.Point(4, 30);
            this.Inventory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Inventory.Name = "Inventory";
            this.Inventory.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Inventory.Size = new System.Drawing.Size(1106, 185);
            this.Inventory.TabIndex = 1;
            this.Inventory.Text = "Inventory";
            this.Inventory.UseVisualStyleBackColor = true;
            // 
            // DGVInventory
            // 
            this.DGVInventory.AllowUserToAddRows = false;
            this.DGVInventory.AllowUserToDeleteRows = false;
            this.DGVInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVInventory.ColumnHeadersHeight = 35;
            this.DGVInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DocumentNo,
            this.ReferenceNo,
            this.ItemName,
            this.Make,
            this.Model,
            this.Quantity,
            this.Unit,
            this.TotalCost,
            this.StatusI,
            this.BatchNo,
            this.ItemCode,
            this.UnitCode});
            this.DGVInventory.ContextMenuStrip = this.contextInventory;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVInventory.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGVInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVInventory.EnableHeadersVisualStyles = false;
            this.DGVInventory.Location = new System.Drawing.Point(2, 3);
            this.DGVInventory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DGVInventory.Name = "DGVInventory";
            this.DGVInventory.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVInventory.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DGVInventory.RowHeadersVisible = false;
            this.DGVInventory.RowHeadersWidth = 62;
            this.DGVInventory.RowTemplate.Height = 28;
            this.DGVInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVInventory.Size = new System.Drawing.Size(1102, 179);
            this.DGVInventory.TabIndex = 2;
            this.DGVInventory.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVInventory_CellContentDoubleClick);
            // 
            // DocumentNo
            // 
            this.DocumentNo.HeaderText = "Document No";
            this.DocumentNo.MinimumWidth = 8;
            this.DocumentNo.Name = "DocumentNo";
            this.DocumentNo.ReadOnly = true;
            // 
            // ReferenceNo
            // 
            this.ReferenceNo.HeaderText = "Reference No";
            this.ReferenceNo.MinimumWidth = 8;
            this.ReferenceNo.Name = "ReferenceNo";
            this.ReferenceNo.ReadOnly = true;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.MinimumWidth = 8;
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // Make
            // 
            this.Make.HeaderText = "Make";
            this.Make.MinimumWidth = 8;
            this.Make.Name = "Make";
            this.Make.ReadOnly = true;
            // 
            // Model
            // 
            this.Model.HeaderText = "Model";
            this.Model.MinimumWidth = 8;
            this.Model.Name = "Model";
            this.Model.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Required Qty";
            this.Quantity.MinimumWidth = 8;
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Unit Cost";
            this.Unit.MinimumWidth = 8;
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            // 
            // TotalCost
            // 
            this.TotalCost.HeaderText = "Total Cost";
            this.TotalCost.MinimumWidth = 8;
            this.TotalCost.Name = "TotalCost";
            this.TotalCost.ReadOnly = true;
            // 
            // StatusI
            // 
            this.StatusI.HeaderText = "Status ";
            this.StatusI.MinimumWidth = 8;
            this.StatusI.Name = "StatusI";
            this.StatusI.ReadOnly = true;
            // 
            // BatchNo
            // 
            this.BatchNo.HeaderText = "BatchNo";
            this.BatchNo.MinimumWidth = 8;
            this.BatchNo.Name = "BatchNo";
            this.BatchNo.ReadOnly = true;
            // 
            // ItemCode
            // 
            this.ItemCode.HeaderText = "ItemCode";
            this.ItemCode.MinimumWidth = 8;
            this.ItemCode.Name = "ItemCode";
            this.ItemCode.ReadOnly = true;
            // 
            // UnitCode
            // 
            this.UnitCode.HeaderText = "UnitCode";
            this.UnitCode.MinimumWidth = 8;
            this.UnitCode.Name = "UnitCode";
            this.UnitCode.ReadOnly = true;
            // 
            // grpMaintenance
            // 
            this.grpMaintenance.Controls.Add(this.lblMTagError);
            this.grpMaintenance.Controls.Add(this.txtReportedby);
            this.grpMaintenance.Controls.Add(this.rtchtext);
            this.grpMaintenance.Controls.Add(this.dropdownAssignTo);
            this.grpMaintenance.Controls.Add(this.numericMinutes);
            this.grpMaintenance.Controls.Add(this.rtchcomments);
            this.grpMaintenance.Controls.Add(this.lbldescription);
            this.grpMaintenance.Controls.Add(this.btnInvertory);
            this.grpMaintenance.Controls.Add(this.lblcode);
            this.grpMaintenance.Controls.Add(this.btnAddWorker);
            this.grpMaintenance.Controls.Add(this.lblothers);
            this.grpMaintenance.Controls.Add(this.btnsumbitaprl);
            this.grpMaintenance.Controls.Add(this.numericHour);
            this.grpMaintenance.Controls.Add(this.lblreportedby);
            this.grpMaintenance.Controls.Add(this.lblAssignTo);
            this.grpMaintenance.Controls.Add(this.lbldate);
            this.grpMaintenance.Controls.Add(this.lblcomments);
            this.grpMaintenance.Controls.Add(this.lblpriority);
            this.grpMaintenance.Controls.Add(this.lbloperationPlant);
            this.grpMaintenance.Controls.Add(this.lblstatus);
            this.grpMaintenance.Controls.Add(this.lblmachinetag);
            this.grpMaintenance.Controls.Add(this.txtmntcode);
            this.grpMaintenance.Controls.Add(this.dropdownpriority);
            this.grpMaintenance.Controls.Add(this.dropdownstatus);
            this.grpMaintenance.Controls.Add(this.txtArea);
            this.grpMaintenance.Controls.Add(this.DatePickerMNTDate);
            this.grpMaintenance.Controls.Add(this.txtothers);
            this.grpMaintenance.Controls.Add(this.txtExtactlocation);
            this.grpMaintenance.Controls.Add(this.dropdownmachinetag);
            this.grpMaintenance.Controls.Add(this.dropdownOP);
            this.grpMaintenance.Controls.Add(this.lblexpectedtime);
            this.grpMaintenance.Controls.Add(this.lblextactlocation);
            this.grpMaintenance.Controls.Add(this.lblArea);
            this.grpMaintenance.Location = new System.Drawing.Point(26, 54);
            this.grpMaintenance.Name = "grpMaintenance";
            this.grpMaintenance.Size = new System.Drawing.Size(1090, 460);
            this.grpMaintenance.TabIndex = 36;
            this.grpMaintenance.TabStop = false;
            // 
            // lblMTagError
            // 
            this.lblMTagError.AutoSize = true;
            this.lblMTagError.Depth = 0;
            this.lblMTagError.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblMTagError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMTagError.Location = new System.Drawing.Point(454, 197);
            this.lblMTagError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMTagError.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblMTagError.Name = "lblMTagError";
            this.lblMTagError.Padding = new System.Windows.Forms.Padding(19, 21, 0, 0);
            this.lblMTagError.Size = new System.Drawing.Size(38, 42);
            this.lblMTagError.TabIndex = 36;
            this.lblMTagError.Text = "*";
            // 
            // MaintenanceNRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 765);
            this.Controls.Add(this.grpMaintenance);
            this.Controls.Add(this.tabcontrolMNT);
            this.Controls.Add(this.DGVRequestDetails);
            this.Controls.Add(this.mntpanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaintenanceNRM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MaintenanceNRM_FormClosed);
            this.Load += new System.EventHandler(this.MaintenanceNRM_Load);
            this.mntpanel.ResumeLayout(false);
            this.mntpanel.PerformLayout();
            this.contextInventory.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVRequestDetails)).EndInit();
            this.tabcontrolMNT.ResumeLayout(false);
            this.Worker.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVWorker)).EndInit();
            this.Inventory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVInventory)).EndInit();
            this.grpMaintenance.ResumeLayout(false);
            this.grpMaintenance.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mntpanel;
        private System.Windows.Forms.ContextMenuStrip contextInventory;
        public System.Windows.Forms.ToolStripMenuItem AddInverntroy;
        public System.Windows.Forms.ToolStripMenuItem Removeinventory;
        public System.Windows.Forms.ToolStripMenuItem returnInventory;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public System.Windows.Forms.ToolStripMenuItem addWorkerToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem removeWorkerToolStripMenuItem;
        public SparrowRMSControl.SparrowControl.SparrowButton btnApproval;
        public SparrowRMSControl.SparrowControl.SparrowButton btnReject;
        public SparrowRMSControl.SparrowControl.SparrowButton btnclosed;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem exportSummaryToolStripMenuItem;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblcode;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtmntcode;
        private SparrowRMSControl.SparrowControl.SparrowLabel lbldate;
        private SparrowRMSControl.SparrowControl.SparrowDatePicker DatePickerMNTDate;
        private SparrowRMSControl.SparrowControl.SparrowLabel lbloperationPlant;
        public SparrowRMSControl.SparrowControl.SparrowComboBox dropdownOP;
        public SparrowRMSControl.SparrowControl.SparrowLabel lblstatus;
        public SparrowRMSControl.SparrowControl.SparrowComboBox dropdownstatus;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblmachinetag;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblothers;
        private SparrowRMSControl.SparrowControl.SparrowLabel lbldescription;
        public SparrowRMSControl.SparrowControl.SparrowComboBox dropdownmachinetag;
        public SparrowRMSControl.SparrowControl.SparrowTextBox txtothers;
        private SparrowRMSControl.SparrowControl.SparrowTextBox rtchtext;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblpriority;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblArea;
        public SparrowRMSControl.SparrowControl.SparrowLabel lblexpectedtime;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblextactlocation;
        public SparrowRMSControl.SparrowControl.SparrowLabel lblreportedby;
        public SparrowRMSControl.SparrowControl.SparrowLabel lblAssignTo;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblcomments;
        public SparrowRMSControl.SparrowControl.SparrowComboBox dropdownpriority;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtArea;
        public SparrowRMSControl.SparrowControl.SparrowTextBox txtExtactlocation;
        public SparrowRMSControl.SparrowControl.SparrowTextBox txtReportedby;
        public SparrowRMSControl.SparrowControl.SparrowComboBox dropdownAssignTo;
        private SparrowRMSControl.SparrowControl.SparrowTextBox rtchcomments;
        public SparrowRMSControl.SparrowControl.SparrowButton btnsumbitaprl;
        public SparrowRMSControl.SparrowControl.SparrowButton btnAddWorker;
        public SparrowRMSControl.SparrowControl.SparrowButton btnInvertory;
        private SparrowRMSControl.SparrowControl.SparrowTabControl tabcontrolMNT;
        private System.Windows.Forms.TabPage Worker;
        private System.Windows.Forms.DataGridView DGVWorker;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaintenanceCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusW;
        private System.Windows.Forms.TabPage Inventory;
        private System.Windows.Forms.DataGridView DGVInventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReferenceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Make;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusI;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitCode;
        public SparrowRMSControl.SparrowControl.SparrowLabel lblmntdate;
        private System.Windows.Forms.DataGridView DGVRequestDetails;
        public SparrowRMSControl.SparrowControl.SparrowNumericUpDown numericMinutes;
        public SparrowRMSControl.SparrowControl.SparrowNumericUpDown numericHour;
        private System.Windows.Forms.DataGridViewTextBoxColumn MCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaintenanceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperationPlant;
        private System.Windows.Forms.DataGridViewTextBoxColumn Statuss;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineTag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Others;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExactLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstimatedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssignTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.GroupBox grpMaintenance;
        public SparrowRMSControl.SparrowControl.SparrowButton btnback;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblMTagError;
    }
}