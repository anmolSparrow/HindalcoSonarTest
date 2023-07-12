
namespace RMPCLApp.Maintenance
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
            this.btnclosed = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.lblName = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.btnback = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.lblDate = new System.Windows.Forms.Label();
            this.datetimepicker = new SparrowRMSControl.SparrowControl.SparrowDatePicker();
            this.lblbrkdowncode = new System.Windows.Forms.Label();
            this.lblmachinetag = new System.Windows.Forms.Label();
            this.txtbrkcode = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.dropdownmachine = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.lblpriority = new System.Windows.Forms.Label();
            this.dropdownpriority = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.lblothersdetails = new System.Windows.Forms.Label();
            this.rtchcomments = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblplant = new System.Windows.Forms.Label();
            this.dropdownOP = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dropDownStatus = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.lblarea = new System.Windows.Forms.Label();
            this.lblExcatlocation = new System.Windows.Forms.Label();
            this.lblreportedby = new System.Windows.Forms.Label();
            this.txtarea = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtxactlocation = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtreportedby = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.RTCHBRKComments = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.chkmaintenace = new SparrowRMSControl.SparrowControl.SparrowCheckBox();
            this.btnsubmit = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.DGVBRKDown = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpgrid = new System.Windows.Forms.GroupBox();
            this.GRPDetailView = new System.Windows.Forms.GroupBox();
            this.panelDisplay = new System.Windows.Forms.Panel();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BreakDownCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MachineTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Others = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operationplant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exactlocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVBRKDown)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.grpgrid.SuspendLayout();
            this.GRPDetailView.SuspendLayout();
            this.panelDisplay.SuspendLayout();
            this.SuspendLayout();
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
            this.btnclosed.Location = new System.Drawing.Point(925, 9);
            this.btnclosed.Margin = new System.Windows.Forms.Padding(2, 3, 19, 3);
            this.btnclosed.MouseOver = System.Drawing.Color.SeaGreen;
            this.btnclosed.Name = "btnclosed";
            this.btnclosed.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnclosed.Size = new System.Drawing.Size(123, 30);
            this.btnclosed.TabIndex = 2;
            this.btnclosed.Text = "Close";
            this.btnclosed.TextColor = System.Drawing.Color.White;
            this.btnclosed.UseVisualStyleBackColor = false;
            this.btnclosed.UseWaitCursor = true;
            this.btnclosed.Click += new System.EventHandler(this.btnclosed_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Depth = 0;
            this.lblName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblName.Location = new System.Drawing.Point(459, 9);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 21);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Break Down";
            this.lblName.UseWaitCursor = true;
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
            this.btnback.Location = new System.Drawing.Point(13, 5);
            this.btnback.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnback.MouseOver = System.Drawing.Color.SeaGreen;
            this.btnback.Name = "btnback";
            this.btnback.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnback.Size = new System.Drawing.Size(123, 28);
            this.btnback.TabIndex = 0;
            this.btnback.Text = "Back";
            this.btnback.TextColor = System.Drawing.Color.White;
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.UseWaitCursor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(26, 29);
            this.lblDate.Margin = new System.Windows.Forms.Padding(3);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(129, 21);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Reporting Date:";
            this.lblDate.UseWaitCursor = true;
            // 
            // datetimepicker
            // 
            this.datetimepicker.BorderColor = System.Drawing.Color.Silver;
            this.datetimepicker.BorderSize = 0;
            this.datetimepicker.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetimepicker.Location = new System.Drawing.Point(224, 20);
            this.datetimepicker.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.datetimepicker.MinimumSize = new System.Drawing.Size(4, 35);
            this.datetimepicker.Name = "datetimepicker";
            this.datetimepicker.Size = new System.Drawing.Size(244, 35);
            this.datetimepicker.SkinColor = System.Drawing.Color.MediumSlateBlue;
            this.datetimepicker.TabIndex = 3;
            this.datetimepicker.TextColor = System.Drawing.Color.White;
            this.datetimepicker.UseWaitCursor = true;
            // 
            // lblbrkdowncode
            // 
            this.lblbrkdowncode.AutoSize = true;
            this.lblbrkdowncode.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbrkdowncode.Location = new System.Drawing.Point(26, 76);
            this.lblbrkdowncode.Margin = new System.Windows.Forms.Padding(3);
            this.lblbrkdowncode.Name = "lblbrkdowncode";
            this.lblbrkdowncode.Size = new System.Drawing.Size(134, 21);
            this.lblbrkdowncode.TabIndex = 4;
            this.lblbrkdowncode.Text = "Breakdown Code";
            this.lblbrkdowncode.UseWaitCursor = true;
            // 
            // lblmachinetag
            // 
            this.lblmachinetag.AutoSize = true;
            this.lblmachinetag.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmachinetag.Location = new System.Drawing.Point(26, 117);
            this.lblmachinetag.Margin = new System.Windows.Forms.Padding(3);
            this.lblmachinetag.Name = "lblmachinetag";
            this.lblmachinetag.Size = new System.Drawing.Size(104, 21);
            this.lblmachinetag.TabIndex = 5;
            this.lblmachinetag.Text = "Machine Tag";
            this.lblmachinetag.UseWaitCursor = true;
            // 
            // txtbrkcode
            // 
            this.txtbrkcode.BackColor = System.Drawing.SystemColors.Window;
            this.txtbrkcode.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtbrkcode.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtbrkcode.BorderRadius = 0;
            this.txtbrkcode.BorderSize = 1;
            this.txtbrkcode.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbrkcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtbrkcode.Location = new System.Drawing.Point(224, 67);
            this.txtbrkcode.Margin = new System.Windows.Forms.Padding(5);
            this.txtbrkcode.Multiline = false;
            this.txtbrkcode.Name = "txtbrkcode";
            this.txtbrkcode.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.txtbrkcode.PasswordChar = false;
            this.txtbrkcode.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtbrkcode.PlaceholderText = "Breakdown Code";
            this.txtbrkcode.Size = new System.Drawing.Size(244, 34);
            this.txtbrkcode.TabIndex = 6;
            this.txtbrkcode.UnderlinedStyle = false;
            this.txtbrkcode.UseWaitCursor = true;
            this.txtbrkcode.Leave += new System.EventHandler(this.txtbrkcode_Leave);
            // 
            // dropdownmachine
            // 
            this.dropdownmachine.BorderColor = System.Drawing.Color.DodgerBlue;
            this.dropdownmachine.BorderSize = 1;
            this.dropdownmachine.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropdownmachine.ForeColor = System.Drawing.Color.DimGray;
            this.dropdownmachine.IconColor = System.Drawing.Color.Silver;
            this.dropdownmachine.ItemHeight = 22;
            this.dropdownmachine.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.dropdownmachine.ListTextColor = System.Drawing.Color.White;
            this.dropdownmachine.Location = new System.Drawing.Point(225, 114);
            this.dropdownmachine.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dropdownmachine.MinimumSize = new System.Drawing.Size(156, 0);
            this.dropdownmachine.Name = "dropdownmachine";
            this.dropdownmachine.Size = new System.Drawing.Size(243, 30);
            this.dropdownmachine.TabIndex = 7;
            this.dropdownmachine.UseWaitCursor = true;
            this.dropdownmachine.SelectedIndexChanged += new System.EventHandler(this.dropdownmachine_SelectedIndexChanged);
            // 
            // lblpriority
            // 
            this.lblpriority.AutoSize = true;
            this.lblpriority.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpriority.Location = new System.Drawing.Point(27, 157);
            this.lblpriority.Margin = new System.Windows.Forms.Padding(3);
            this.lblpriority.Name = "lblpriority";
            this.lblpriority.Size = new System.Drawing.Size(62, 21);
            this.lblpriority.TabIndex = 8;
            this.lblpriority.Text = "Priority";
            this.lblpriority.UseWaitCursor = true;
            // 
            // dropdownpriority
            // 
            this.dropdownpriority.BorderColor = System.Drawing.Color.DodgerBlue;
            this.dropdownpriority.BorderSize = 1;
            this.dropdownpriority.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropdownpriority.ForeColor = System.Drawing.Color.DimGray;
            this.dropdownpriority.IconColor = System.Drawing.Color.Silver;
            this.dropdownpriority.ItemHeight = 22;
            this.dropdownpriority.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.dropdownpriority.ListTextColor = System.Drawing.Color.White;
            this.dropdownpriority.Location = new System.Drawing.Point(225, 160);
            this.dropdownpriority.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dropdownpriority.MinimumSize = new System.Drawing.Size(156, 0);
            this.dropdownpriority.Name = "dropdownpriority";
            this.dropdownpriority.Size = new System.Drawing.Size(243, 30);
            this.dropdownpriority.TabIndex = 9;
            this.dropdownpriority.UseWaitCursor = true;
            this.dropdownpriority.SelectedIndexChanged += new System.EventHandler(this.dropdownpriority_SelectedIndexChanged);
            // 
            // lblothersdetails
            // 
            this.lblothersdetails.AutoSize = true;
            this.lblothersdetails.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblothersdetails.Location = new System.Drawing.Point(27, 204);
            this.lblothersdetails.Margin = new System.Windows.Forms.Padding(3);
            this.lblothersdetails.Name = "lblothersdetails";
            this.lblothersdetails.Size = new System.Drawing.Size(109, 21);
            this.lblothersdetails.TabIndex = 10;
            this.lblothersdetails.Text = "Other Details";
            this.lblothersdetails.UseWaitCursor = true;
            // 
            // rtchcomments
            // 
            this.rtchcomments.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.rtchcomments.BackColor = System.Drawing.SystemColors.Window;
            this.rtchcomments.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rtchcomments.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.rtchcomments.BorderRadius = 1;
            this.rtchcomments.BorderSize = 1;
            this.rtchcomments.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.rtchcomments.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtchcomments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rtchcomments.Location = new System.Drawing.Point(30, 233);
            this.rtchcomments.Margin = new System.Windows.Forms.Padding(5);
            this.rtchcomments.Multiline = true;
            this.rtchcomments.Name = "rtchcomments";
            this.rtchcomments.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.rtchcomments.PasswordChar = false;
            this.rtchcomments.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.rtchcomments.PlaceholderText = "";
            this.rtchcomments.Size = new System.Drawing.Size(455, 90);
            this.rtchcomments.TabIndex = 11;
            this.rtchcomments.UnderlinedStyle = false;
            this.rtchcomments.UseWaitCursor = true;
            this.rtchcomments.Leave += new System.EventHandler(this.rtchcomments_Leave);
            // 
            // lblplant
            // 
            this.lblplant.AutoSize = true;
            this.lblplant.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblplant.Location = new System.Drawing.Point(580, 24);
            this.lblplant.Margin = new System.Windows.Forms.Padding(3);
            this.lblplant.Name = "lblplant";
            this.lblplant.Size = new System.Drawing.Size(125, 21);
            this.lblplant.TabIndex = 12;
            this.lblplant.Text = "Operation Plant";
            this.lblplant.UseWaitCursor = true;
            // 
            // dropdownOP
            // 
            this.dropdownOP.BorderColor = System.Drawing.Color.DodgerBlue;
            this.dropdownOP.BorderSize = 1;
            this.dropdownOP.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropdownOP.ForeColor = System.Drawing.Color.DimGray;
            this.dropdownOP.IconColor = System.Drawing.Color.Silver;
            this.dropdownOP.ItemHeight = 22;
            this.dropdownOP.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.dropdownOP.ListTextColor = System.Drawing.Color.White;
            this.dropdownOP.Location = new System.Drawing.Point(794, 20);
            this.dropdownOP.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dropdownOP.MinimumSize = new System.Drawing.Size(156, 0);
            this.dropdownOP.Name = "dropdownOP";
            this.dropdownOP.Size = new System.Drawing.Size(243, 30);
            this.dropdownOP.TabIndex = 13;
            this.dropdownOP.UseWaitCursor = true;
            this.dropdownOP.SelectedIndexChanged += new System.EventHandler(this.dropdownOP_SelectedIndexChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(580, 71);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(57, 21);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Status";
            this.lblStatus.UseWaitCursor = true;
            // 
            // dropDownStatus
            // 
            this.dropDownStatus.BorderColor = System.Drawing.Color.DodgerBlue;
            this.dropDownStatus.BorderSize = 1;
            this.dropDownStatus.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropDownStatus.ForeColor = System.Drawing.Color.DimGray;
            this.dropDownStatus.IconColor = System.Drawing.Color.Silver;
            this.dropDownStatus.ItemHeight = 22;
            this.dropDownStatus.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.dropDownStatus.ListTextColor = System.Drawing.Color.White;
            this.dropDownStatus.Location = new System.Drawing.Point(794, 62);
            this.dropDownStatus.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dropDownStatus.MinimumSize = new System.Drawing.Size(156, 0);
            this.dropDownStatus.Name = "dropDownStatus";
            this.dropDownStatus.Size = new System.Drawing.Size(243, 30);
            this.dropDownStatus.TabIndex = 15;
            this.dropDownStatus.UseWaitCursor = true;
            // 
            // lblarea
            // 
            this.lblarea.AutoSize = true;
            this.lblarea.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblarea.Location = new System.Drawing.Point(580, 108);
            this.lblarea.Margin = new System.Windows.Forms.Padding(3);
            this.lblarea.Name = "lblarea";
            this.lblarea.Size = new System.Drawing.Size(45, 21);
            this.lblarea.TabIndex = 16;
            this.lblarea.Text = "Area";
            this.lblarea.UseWaitCursor = true;
            // 
            // lblExcatlocation
            // 
            this.lblExcatlocation.AutoSize = true;
            this.lblExcatlocation.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExcatlocation.Location = new System.Drawing.Point(580, 158);
            this.lblExcatlocation.Margin = new System.Windows.Forms.Padding(3);
            this.lblExcatlocation.Name = "lblExcatlocation";
            this.lblExcatlocation.Size = new System.Drawing.Size(118, 21);
            this.lblExcatlocation.TabIndex = 17;
            this.lblExcatlocation.Text = "Exact Location";
            this.lblExcatlocation.UseWaitCursor = true;
            // 
            // lblreportedby
            // 
            this.lblreportedby.AutoSize = true;
            this.lblreportedby.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblreportedby.Location = new System.Drawing.Point(580, 201);
            this.lblreportedby.Margin = new System.Windows.Forms.Padding(3);
            this.lblreportedby.Name = "lblreportedby";
            this.lblreportedby.Size = new System.Drawing.Size(101, 21);
            this.lblreportedby.TabIndex = 18;
            this.lblreportedby.Text = "Reported By";
            this.lblreportedby.UseWaitCursor = true;
            // 
            // txtarea
            // 
            this.txtarea.BackColor = System.Drawing.SystemColors.Window;
            this.txtarea.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtarea.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtarea.BorderRadius = 0;
            this.txtarea.BorderSize = 1;
            this.txtarea.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtarea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtarea.Location = new System.Drawing.Point(796, 100);
            this.txtarea.Margin = new System.Windows.Forms.Padding(5);
            this.txtarea.Multiline = false;
            this.txtarea.Name = "txtarea";
            this.txtarea.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.txtarea.PasswordChar = false;
            this.txtarea.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtarea.PlaceholderText = "Area";
            this.txtarea.Size = new System.Drawing.Size(241, 34);
            this.txtarea.TabIndex = 19;
            this.txtarea.UnderlinedStyle = false;
            this.txtarea.UseWaitCursor = true;
            this.txtarea.Leave += new System.EventHandler(this.txtarea_Leave);
            // 
            // txtxactlocation
            // 
            this.txtxactlocation.BackColor = System.Drawing.SystemColors.Window;
            this.txtxactlocation.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtxactlocation.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtxactlocation.BorderRadius = 0;
            this.txtxactlocation.BorderSize = 1;
            this.txtxactlocation.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtxactlocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtxactlocation.Location = new System.Drawing.Point(796, 144);
            this.txtxactlocation.Margin = new System.Windows.Forms.Padding(5);
            this.txtxactlocation.Multiline = false;
            this.txtxactlocation.Name = "txtxactlocation";
            this.txtxactlocation.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.txtxactlocation.PasswordChar = false;
            this.txtxactlocation.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtxactlocation.PlaceholderText = "Exact Location";
            this.txtxactlocation.Size = new System.Drawing.Size(241, 34);
            this.txtxactlocation.TabIndex = 20;
            this.txtxactlocation.UnderlinedStyle = false;
            this.txtxactlocation.UseWaitCursor = true;
            this.txtxactlocation.Leave += new System.EventHandler(this.txtxactlocation_Leave);
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
            this.txtreportedby.Location = new System.Drawing.Point(796, 191);
            this.txtreportedby.Margin = new System.Windows.Forms.Padding(5);
            this.txtreportedby.Multiline = false;
            this.txtreportedby.Name = "txtreportedby";
            this.txtreportedby.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.txtreportedby.PasswordChar = false;
            this.txtreportedby.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtreportedby.PlaceholderText = "Reported By";
            this.txtreportedby.Size = new System.Drawing.Size(241, 34);
            this.txtreportedby.TabIndex = 21;
            this.txtreportedby.UnderlinedStyle = false;
            this.txtreportedby.UseWaitCursor = true;
            // 
            // RTCHBRKComments
            // 
            this.RTCHBRKComments.BackColor = System.Drawing.SystemColors.Window;
            this.RTCHBRKComments.BorderColor = System.Drawing.Color.DodgerBlue;
            this.RTCHBRKComments.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.RTCHBRKComments.BorderRadius = 1;
            this.RTCHBRKComments.BorderSize = 1;
            this.RTCHBRKComments.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTCHBRKComments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RTCHBRKComments.Location = new System.Drawing.Point(584, 237);
            this.RTCHBRKComments.Margin = new System.Windows.Forms.Padding(5);
            this.RTCHBRKComments.Multiline = true;
            this.RTCHBRKComments.Name = "RTCHBRKComments";
            this.RTCHBRKComments.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.RTCHBRKComments.PasswordChar = false;
            this.RTCHBRKComments.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.RTCHBRKComments.PlaceholderText = "";
            this.RTCHBRKComments.Size = new System.Drawing.Size(453, 86);
            this.RTCHBRKComments.TabIndex = 22;
            this.RTCHBRKComments.UnderlinedStyle = false;
            this.RTCHBRKComments.UseWaitCursor = true;
            // 
            // chkmaintenace
            // 
            this.chkmaintenace.AutoSize = true;
            this.chkmaintenace.Depth = 0;
            this.chkmaintenace.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkmaintenace.Location = new System.Drawing.Point(590, 336);
            this.chkmaintenace.Margin = new System.Windows.Forms.Padding(0);
            this.chkmaintenace.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkmaintenace.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.chkmaintenace.Name = "chkmaintenace";
            this.chkmaintenace.Ripple = true;
            this.chkmaintenace.Size = new System.Drawing.Size(204, 30);
            this.chkmaintenace.TabIndex = 23;
            this.chkmaintenace.Text = "Maintenance Required";
            this.chkmaintenace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkmaintenace.UseVisualStyleBackColor = true;
            this.chkmaintenace.UseWaitCursor = true;
            this.chkmaintenace.CheckedChanged += new System.EventHandler(this.chkmaintenace_CheckedChanged);
            // 
            // btnsubmit
            // 
            this.btnsubmit.BackColor = System.Drawing.Color.SeaGreen;
            this.btnsubmit.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.btnsubmit.BorderColor = System.Drawing.Color.SeaGreen;
            this.btnsubmit.BorderRadius = 14;
            this.btnsubmit.BorderSize = 0;
            this.btnsubmit.FlatAppearance.BorderSize = 0;
            this.btnsubmit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnsubmit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnsubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsubmit.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsubmit.ForeColor = System.Drawing.Color.White;
            this.btnsubmit.Location = new System.Drawing.Point(909, 337);
            this.btnsubmit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnsubmit.MouseOver = System.Drawing.Color.SeaGreen;
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnsubmit.Size = new System.Drawing.Size(132, 30);
            this.btnsubmit.TabIndex = 24;
            this.btnsubmit.Text = "Submit";
            this.btnsubmit.TextColor = System.Drawing.Color.White;
            this.btnsubmit.UseVisualStyleBackColor = false;
            this.btnsubmit.UseWaitCursor = true;
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // DGVBRKDown
            // 
            this.DGVBRKDown.AllowUserToAddRows = false;
            this.DGVBRKDown.AllowUserToDeleteRows = false;
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
            this.Others,
            this.Operationplant,
            this.Status,
            this.Area,
            this.Exactlocation,
            this.ReportedBy,
            this.Remark});
            this.DGVBRKDown.ContextMenuStrip = this.contextMenuStrip2;
            this.DGVBRKDown.EnableHeadersVisualStyles = false;
            this.DGVBRKDown.Location = new System.Drawing.Point(12, 23);
            this.DGVBRKDown.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DGVBRKDown.Name = "DGVBRKDown";
            this.DGVBRKDown.ReadOnly = true;
            this.DGVBRKDown.RowHeadersVisible = false;
            this.DGVBRKDown.RowHeadersWidth = 62;
            this.DGVBRKDown.RowTemplate.Height = 28;
            this.DGVBRKDown.Size = new System.Drawing.Size(1057, 187);
            this.DGVBRKDown.TabIndex = 25;
            this.DGVBRKDown.UseWaitCursor = true;
            this.DGVBRKDown.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVBRKDown_CellClick);
            this.DGVBRKDown.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSelectAll_CellContentClick);
            this.DGVBRKDown.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVBRKDown_CellContentDoubleClick);
            this.DGVBRKDown.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGVBRKDown_CellFormatting);
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
            this.exportSummaryToolStripMenuItem.Image = global::RMPCLApp.Properties.Resources.AddToLibrary_32x32;
            this.exportSummaryToolStripMenuItem.Name = "exportSummaryToolStripMenuItem";
            this.exportSummaryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.exportSummaryToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.exportSummaryToolStripMenuItem.Text = "Export Summary";
            // 
            // grpgrid
            // 
            this.grpgrid.Controls.Add(this.DGVBRKDown);
            this.grpgrid.Location = new System.Drawing.Point(13, 456);
            this.grpgrid.Name = "grpgrid";
            this.grpgrid.Size = new System.Drawing.Size(1074, 229);
            this.grpgrid.TabIndex = 28;
            this.grpgrid.TabStop = false;
            // 
            // GRPDetailView
            // 
            this.GRPDetailView.Controls.Add(this.lblDate);
            this.GRPDetailView.Controls.Add(this.lblbrkdowncode);
            this.GRPDetailView.Controls.Add(this.rtchcomments);
            this.GRPDetailView.Controls.Add(this.lblStatus);
            this.GRPDetailView.Controls.Add(this.RTCHBRKComments);
            this.GRPDetailView.Controls.Add(this.lblmachinetag);
            this.GRPDetailView.Controls.Add(this.dropDownStatus);
            this.GRPDetailView.Controls.Add(this.dropdownOP);
            this.GRPDetailView.Controls.Add(this.lblarea);
            this.GRPDetailView.Controls.Add(this.lblplant);
            this.GRPDetailView.Controls.Add(this.lblreportedby);
            this.GRPDetailView.Controls.Add(this.txtbrkcode);
            this.GRPDetailView.Controls.Add(this.txtarea);
            this.GRPDetailView.Controls.Add(this.datetimepicker);
            this.GRPDetailView.Controls.Add(this.chkmaintenace);
            this.GRPDetailView.Controls.Add(this.lblExcatlocation);
            this.GRPDetailView.Controls.Add(this.txtreportedby);
            this.GRPDetailView.Controls.Add(this.dropdownmachine);
            this.GRPDetailView.Controls.Add(this.txtxactlocation);
            this.GRPDetailView.Controls.Add(this.lblpriority);
            this.GRPDetailView.Controls.Add(this.btnsubmit);
            this.GRPDetailView.Controls.Add(this.dropdownpriority);
            this.GRPDetailView.Controls.Add(this.lblothersdetails);
            this.GRPDetailView.Location = new System.Drawing.Point(13, 75);
            this.GRPDetailView.Name = "GRPDetailView";
            this.GRPDetailView.Size = new System.Drawing.Size(1064, 375);
            this.GRPDetailView.TabIndex = 29;
            this.GRPDetailView.TabStop = false;
            // 
            // panelDisplay
            // 
            this.panelDisplay.Controls.Add(this.lblName);
            this.panelDisplay.Controls.Add(this.btnback);
            this.panelDisplay.Controls.Add(this.btnclosed);
            this.panelDisplay.Location = new System.Drawing.Point(13, 7);
            this.panelDisplay.Name = "panelDisplay";
            this.panelDisplay.Size = new System.Drawing.Size(1064, 46);
            this.panelDisplay.TabIndex = 31;
            // 
            // Date
            // 
            this.Date.HeaderText = "Reporting Date";
            this.Date.MinimumWidth = 8;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 150;
            // 
            // BreakDownCode
            // 
            this.BreakDownCode.HeaderText = "BreakDown Code";
            this.BreakDownCode.MinimumWidth = 8;
            this.BreakDownCode.Name = "BreakDownCode";
            this.BreakDownCode.ReadOnly = true;
            this.BreakDownCode.Width = 150;
            // 
            // MachineTag
            // 
            this.MachineTag.HeaderText = "Machine Tag";
            this.MachineTag.MinimumWidth = 8;
            this.MachineTag.Name = "MachineTag";
            this.MachineTag.ReadOnly = true;
            this.MachineTag.Width = 150;
            // 
            // Priority
            // 
            this.Priority.HeaderText = "Priority";
            this.Priority.MinimumWidth = 8;
            this.Priority.Name = "Priority";
            this.Priority.ReadOnly = true;
            this.Priority.Width = 150;
            // 
            // Others
            // 
            this.Others.HeaderText = "Others";
            this.Others.MinimumWidth = 8;
            this.Others.Name = "Others";
            this.Others.ReadOnly = true;
            this.Others.Width = 150;
            // 
            // Operationplant
            // 
            this.Operationplant.HeaderText = "Operation Plant";
            this.Operationplant.MinimumWidth = 8;
            this.Operationplant.Name = "Operationplant";
            this.Operationplant.ReadOnly = true;
            this.Operationplant.Width = 150;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 8;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 150;
            // 
            // Area
            // 
            this.Area.HeaderText = "Area";
            this.Area.MinimumWidth = 8;
            this.Area.Name = "Area";
            this.Area.ReadOnly = true;
            this.Area.Width = 150;
            // 
            // Exactlocation
            // 
            this.Exactlocation.HeaderText = "Exact Location ";
            this.Exactlocation.MinimumWidth = 8;
            this.Exactlocation.Name = "Exactlocation";
            this.Exactlocation.ReadOnly = true;
            this.Exactlocation.Width = 150;
            // 
            // ReportedBy
            // 
            this.ReportedBy.HeaderText = "Reported By";
            this.ReportedBy.MinimumWidth = 8;
            this.ReportedBy.Name = "ReportedBy";
            this.ReportedBy.ReadOnly = true;
            this.ReportedBy.Width = 150;
            // 
            // Remark
            // 
            this.Remark.HeaderText = "Comment";
            this.Remark.MinimumWidth = 8;
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.Width = 150;
            // 
            // MaintenanceBRK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 707);
            this.Controls.Add(this.panelDisplay);
            this.Controls.Add(this.GRPDetailView);
            this.Controls.Add(this.grpgrid);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MaintenanceBRK";
            this.Padding = new System.Windows.Forms.Padding(19, 0, 19, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Maintenance Breakdown";
            this.UseWaitCursor = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MaintenanceBRK_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.DGVBRKDown)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.grpgrid.ResumeLayout(false);
            this.GRPDetailView.ResumeLayout(false);
            this.GRPDetailView.PerformLayout();
            this.panelDisplay.ResumeLayout(false);
            this.panelDisplay.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private SparrowRMSControl.SparrowControl.SparrowButton btnclosed;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblName;
        private SparrowRMSControl.SparrowControl.SparrowButton btnback;
        private System.Windows.Forms.Label lblDate;
        private SparrowRMSControl.SparrowControl.SparrowDatePicker datetimepicker;
        private System.Windows.Forms.Label lblbrkdowncode;
        private System.Windows.Forms.Label lblmachinetag;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtbrkcode;
        public SparrowRMSControl.SparrowControl.SparrowComboBox dropdownmachine;
        private System.Windows.Forms.Label lblpriority;
        private SparrowRMSControl.SparrowControl.SparrowComboBox dropdownpriority;
        private System.Windows.Forms.Label lblothersdetails;
        private SparrowRMSControl.SparrowControl.SparrowTextBox rtchcomments;
        private System.Windows.Forms.Label lblplant;
        private SparrowRMSControl.SparrowControl.SparrowComboBox dropdownOP;
        private System.Windows.Forms.Label lblStatus;
        private SparrowRMSControl.SparrowControl.SparrowComboBox dropDownStatus;
        private System.Windows.Forms.Label lblarea;
        private System.Windows.Forms.Label lblExcatlocation;
        private System.Windows.Forms.Label lblreportedby;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtarea;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtxactlocation;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtreportedby;
        private SparrowRMSControl.SparrowControl.SparrowTextBox RTCHBRKComments;
        private SparrowRMSControl.SparrowControl.SparrowCheckBox chkmaintenace;
        private SparrowRMSControl.SparrowControl.SparrowButton btnsubmit;
        private System.Windows.Forms.DataGridView DGVBRKDown;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem exportSummaryToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpgrid;
        private System.Windows.Forms.GroupBox GRPDetailView;
        private System.Windows.Forms.Panel panelDisplay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn BreakDownCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineTag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn Others;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operationplant;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exactlocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}