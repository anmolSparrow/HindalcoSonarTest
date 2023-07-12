
namespace Hind.AuditMgmt
{
    partial class AuditMasterView
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
            this.gbxAddVendor = new System.Windows.Forms.GroupBox();
            this.lblCate = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.cmbCategory = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.btnSave = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnCancel = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.lblDescrip = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblChkPoints = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtRemarks = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtCheckPoint = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.dgvViewAuditMaster = new System.Windows.Forms.DataGridView();
            this.CheckPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuditCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuditMasterPages = new SparrowRMSControl.SparrowControl.SparrowTabControl();
            this.pgView = new System.Windows.Forms.TabPage();
            this.pgDetail = new System.Windows.Forms.TabPage();
            this.btnView = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnCreateNew = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.gbxAddVendor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewAuditMaster)).BeginInit();
            this.AuditMasterPages.SuspendLayout();
            this.pgView.SuspendLayout();
            this.pgDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxAddVendor
            // 
            this.gbxAddVendor.BackColor = System.Drawing.Color.White;
            this.gbxAddVendor.Controls.Add(this.lblCate);
            this.gbxAddVendor.Controls.Add(this.cmbCategory);
            this.gbxAddVendor.Controls.Add(this.btnSave);
            this.gbxAddVendor.Controls.Add(this.btnCancel);
            this.gbxAddVendor.Controls.Add(this.lblDescrip);
            this.gbxAddVendor.Controls.Add(this.lblChkPoints);
            this.gbxAddVendor.Controls.Add(this.txtRemarks);
            this.gbxAddVendor.Controls.Add(this.txtCheckPoint);
            this.gbxAddVendor.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxAddVendor.Location = new System.Drawing.Point(18, 17);
            this.gbxAddVendor.Name = "gbxAddVendor";
            this.gbxAddVendor.Size = new System.Drawing.Size(1064, 255);
            this.gbxAddVendor.TabIndex = 0;
            this.gbxAddVendor.TabStop = false;
            // 
            // lblCate
            // 
            this.lblCate.AutoSize = true;
            this.lblCate.Depth = 0;
            this.lblCate.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblCate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCate.Location = new System.Drawing.Point(662, 36);
            this.lblCate.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblCate.Name = "lblCate";
            this.lblCate.Size = new System.Drawing.Size(67, 18);
            this.lblCate.TabIndex = 54;
            this.lblCate.Text = "Category";
            // 
            // cmbCategory
            // 
            this.cmbCategory.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbCategory.BorderSize = 0;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbCategory.ListBackColor = System.Drawing.Color.Red;
            this.cmbCategory.ListTextColor = System.Drawing.Color.White;
            this.cmbCategory.Location = new System.Drawing.Point(741, 29);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(283, 31);
            this.cmbCategory.TabIndex = 53;
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
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(834, 104);
            this.btnSave.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSave.Name = "btnSave";
            this.btnSave.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnSave.Size = new System.Drawing.Size(86, 30);
            this.btnSave.TabIndex = 51;
            this.btnSave.Text = "Add";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.BorderRadius = 14;
            this.btnCancel.BorderSize = 0;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(940, 104);
            this.btnCancel.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnCancel.Size = new System.Drawing.Size(84, 30);
            this.btnCancel.TabIndex = 50;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextColor = System.Drawing.Color.White;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnVendorCancel_Click);
            // 
            // lblDescrip
            // 
            this.lblDescrip.AutoSize = true;
            this.lblDescrip.Depth = 0;
            this.lblDescrip.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblDescrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDescrip.Location = new System.Drawing.Point(26, 143);
            this.lblDescrip.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblDescrip.Name = "lblDescrip";
            this.lblDescrip.Size = new System.Drawing.Size(65, 18);
            this.lblDescrip.TabIndex = 45;
            this.lblDescrip.Text = "Remarks";
            // 
            // lblChkPoints
            // 
            this.lblChkPoints.AutoSize = true;
            this.lblChkPoints.Depth = 0;
            this.lblChkPoints.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblChkPoints.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblChkPoints.Location = new System.Drawing.Point(26, 35);
            this.lblChkPoints.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblChkPoints.Name = "lblChkPoints";
            this.lblChkPoints.Size = new System.Drawing.Size(83, 18);
            this.lblChkPoints.TabIndex = 44;
            this.lblChkPoints.Text = "Check Point";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.SystemColors.Window;
            this.txtRemarks.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtRemarks.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtRemarks.BorderRadius = 0;
            this.txtRemarks.BorderSize = 1;
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtRemarks.Location = new System.Drawing.Point(120, 87);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(4);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtRemarks.PasswordChar = false;
            this.txtRemarks.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtRemarks.PlaceholderText = "";
            this.txtRemarks.Size = new System.Drawing.Size(474, 142);
            this.txtRemarks.TabIndex = 39;
            this.txtRemarks.UnderlinedStyle = false;
            // 
            // txtCheckPoint
            // 
            this.txtCheckPoint.BackColor = System.Drawing.SystemColors.Window;
            this.txtCheckPoint.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtCheckPoint.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtCheckPoint.BorderRadius = 0;
            this.txtCheckPoint.BorderSize = 1;
            this.txtCheckPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckPoint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCheckPoint.Location = new System.Drawing.Point(120, 28);
            this.txtCheckPoint.Margin = new System.Windows.Forms.Padding(4);
            this.txtCheckPoint.Multiline = true;
            this.txtCheckPoint.Name = "txtCheckPoint";
            this.txtCheckPoint.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtCheckPoint.PasswordChar = false;
            this.txtCheckPoint.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtCheckPoint.PlaceholderText = "";
            this.txtCheckPoint.Size = new System.Drawing.Size(474, 35);
            this.txtCheckPoint.TabIndex = 38;
            this.txtCheckPoint.UnderlinedStyle = false;
            // 
            // dgvViewAuditMaster
            // 
            this.dgvViewAuditMaster.AllowUserToAddRows = false;
            this.dgvViewAuditMaster.AllowUserToDeleteRows = false;
            this.dgvViewAuditMaster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvViewAuditMaster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvViewAuditMaster.ColumnHeadersHeight = 35;
            this.dgvViewAuditMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvViewAuditMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckPoint,
            this.Description,
            this.AuditCategory,
            this.CreatedDate});
            this.dgvViewAuditMaster.EnableHeadersVisualStyles = false;
            this.dgvViewAuditMaster.Location = new System.Drawing.Point(17, 16);
            this.dgvViewAuditMaster.Name = "dgvViewAuditMaster";
            this.dgvViewAuditMaster.ReadOnly = true;
            this.dgvViewAuditMaster.RowHeadersVisible = false;
            this.dgvViewAuditMaster.RowHeadersWidth = 51;
            this.dgvViewAuditMaster.RowTemplate.Height = 24;
            this.dgvViewAuditMaster.Size = new System.Drawing.Size(1059, 254);
            this.dgvViewAuditMaster.TabIndex = 0;
            this.dgvViewAuditMaster.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViewAuditMaster_CellDoubleClick);
            // 
            // CheckPoint
            // 
            this.CheckPoint.HeaderText = "Check Point";
            this.CheckPoint.MinimumWidth = 6;
            this.CheckPoint.Name = "CheckPoint";
            this.CheckPoint.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // AuditCategory
            // 
            this.AuditCategory.HeaderText = "Category";
            this.AuditCategory.MinimumWidth = 6;
            this.AuditCategory.Name = "AuditCategory";
            this.AuditCategory.ReadOnly = true;
            // 
            // CreatedDate
            // 
            this.CreatedDate.HeaderText = "Created Date";
            this.CreatedDate.MinimumWidth = 6;
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.ReadOnly = true;
            // 
            // AuditMasterPages
            // 
            this.AuditMasterPages.Controls.Add(this.pgView);
            this.AuditMasterPages.Controls.Add(this.pgDetail);
            // 
            // 
            // 
            this.AuditMasterPages.DisplayStyleProvider.BlendStyle = SparrowRMSControl.SparrowControl.BlendStyle.Normal;
            this.AuditMasterPages.DisplayStyleProvider.BorderColorDisabled = System.Drawing.SystemColors.ControlLight;
            this.AuditMasterPages.DisplayStyleProvider.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.AuditMasterPages.DisplayStyleProvider.BorderColorHighlighted = System.Drawing.SystemColors.ControlDark;
            this.AuditMasterPages.DisplayStyleProvider.BorderColorSelected = System.Drawing.SystemColors.ControlDark;
            this.AuditMasterPages.DisplayStyleProvider.BorderColorUnselected = System.Drawing.SystemColors.ControlDark;
            this.AuditMasterPages.DisplayStyleProvider.CloserButtonFillColorFocused = System.Drawing.Color.Empty;
            this.AuditMasterPages.DisplayStyleProvider.CloserButtonFillColorFocusedActive = System.Drawing.Color.Empty;
            this.AuditMasterPages.DisplayStyleProvider.CloserButtonFillColorHighlighted = System.Drawing.Color.Empty;
            this.AuditMasterPages.DisplayStyleProvider.CloserButtonFillColorHighlightedActive = System.Drawing.Color.Empty;
            this.AuditMasterPages.DisplayStyleProvider.CloserButtonFillColorSelected = System.Drawing.Color.Empty;
            this.AuditMasterPages.DisplayStyleProvider.CloserButtonFillColorSelectedActive = System.Drawing.Color.Empty;
            this.AuditMasterPages.DisplayStyleProvider.CloserButtonFillColorUnselected = System.Drawing.Color.Empty;
            this.AuditMasterPages.DisplayStyleProvider.CloserButtonOutlineColorFocused = System.Drawing.Color.Empty;
            this.AuditMasterPages.DisplayStyleProvider.CloserButtonOutlineColorFocusedActive = System.Drawing.Color.Empty;
            this.AuditMasterPages.DisplayStyleProvider.CloserButtonOutlineColorHighlighted = System.Drawing.Color.Empty;
            this.AuditMasterPages.DisplayStyleProvider.CloserButtonOutlineColorHighlightedActive = System.Drawing.Color.Empty;
            this.AuditMasterPages.DisplayStyleProvider.CloserButtonOutlineColorSelected = System.Drawing.Color.Empty;
            this.AuditMasterPages.DisplayStyleProvider.CloserButtonOutlineColorSelectedActive = System.Drawing.Color.Empty;
            this.AuditMasterPages.DisplayStyleProvider.CloserButtonOutlineColorUnselected = System.Drawing.Color.Empty;
            this.AuditMasterPages.DisplayStyleProvider.CloserColorFocused = System.Drawing.SystemColors.ControlDark;
            this.AuditMasterPages.DisplayStyleProvider.CloserColorFocusedActive = System.Drawing.SystemColors.ControlDark;
            this.AuditMasterPages.DisplayStyleProvider.CloserColorHighlighted = System.Drawing.SystemColors.ControlDark;
            this.AuditMasterPages.DisplayStyleProvider.CloserColorHighlightedActive = System.Drawing.SystemColors.ControlDark;
            this.AuditMasterPages.DisplayStyleProvider.CloserColorSelected = System.Drawing.SystemColors.ControlDark;
            this.AuditMasterPages.DisplayStyleProvider.CloserColorSelectedActive = System.Drawing.SystemColors.ControlDark;
            this.AuditMasterPages.DisplayStyleProvider.CloserColorUnselected = System.Drawing.Color.Empty;
            this.AuditMasterPages.DisplayStyleProvider.FocusTrack = false;
            this.AuditMasterPages.DisplayStyleProvider.HotTrack = true;
            this.AuditMasterPages.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AuditMasterPages.DisplayStyleProvider.Opacity = 1F;
            this.AuditMasterPages.DisplayStyleProvider.Overlap = 0;
            this.AuditMasterPages.DisplayStyleProvider.Padding = new System.Drawing.Point(6, 3);
            this.AuditMasterPages.DisplayStyleProvider.PageBackgroundColorDisabled = System.Drawing.SystemColors.Control;
            this.AuditMasterPages.DisplayStyleProvider.PageBackgroundColorFocused = System.Drawing.Color.DodgerBlue;
            this.AuditMasterPages.DisplayStyleProvider.PageBackgroundColorHighlighted = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.AuditMasterPages.DisplayStyleProvider.PageBackgroundColorSelected = System.Drawing.SystemColors.ControlLightLight;
            this.AuditMasterPages.DisplayStyleProvider.PageBackgroundColorUnselected = System.Drawing.SystemColors.Control;
            this.AuditMasterPages.DisplayStyleProvider.Radius = 2;
            this.AuditMasterPages.DisplayStyleProvider.SelectedTabIsLarger = true;
            this.AuditMasterPages.DisplayStyleProvider.ShowTabCloser = false;
            this.AuditMasterPages.DisplayStyleProvider.TabColorDisabled1 = System.Drawing.SystemColors.Control;
            this.AuditMasterPages.DisplayStyleProvider.TabColorDisabled2 = System.Drawing.SystemColors.Control;
            this.AuditMasterPages.DisplayStyleProvider.TabColorFocused1 = System.Drawing.Color.DodgerBlue;
            this.AuditMasterPages.DisplayStyleProvider.TabColorFocused2 = System.Drawing.Color.DodgerBlue;
            this.AuditMasterPages.DisplayStyleProvider.TabColorHighLighted1 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.AuditMasterPages.DisplayStyleProvider.TabColorHighLighted2 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.AuditMasterPages.DisplayStyleProvider.TabColorSelected1 = System.Drawing.SystemColors.ControlLightLight;
            this.AuditMasterPages.DisplayStyleProvider.TabColorSelected2 = System.Drawing.SystemColors.ControlLightLight;
            this.AuditMasterPages.DisplayStyleProvider.TabColorUnSelected1 = System.Drawing.SystemColors.Control;
            this.AuditMasterPages.DisplayStyleProvider.TabColorUnSelected2 = System.Drawing.SystemColors.Control;
            this.AuditMasterPages.DisplayStyleProvider.TabPageMargin = new System.Windows.Forms.Padding(1);
            this.AuditMasterPages.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.AuditMasterPages.DisplayStyleProvider.TextColorFocused = System.Drawing.Color.White;
            this.AuditMasterPages.DisplayStyleProvider.TextColorHighlighted = System.Drawing.SystemColors.ControlText;
            this.AuditMasterPages.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.AuditMasterPages.DisplayStyleProvider.TextColorUnselected = System.Drawing.SystemColors.ControlText;
            this.AuditMasterPages.HotTrack = true;
            this.AuditMasterPages.Location = new System.Drawing.Point(12, 51);
            this.AuditMasterPages.Name = "AuditMasterPages";
            this.AuditMasterPages.SelectedIndex = 0;
            this.AuditMasterPages.SelectTabColor = System.Drawing.Color.DodgerBlue;
            this.AuditMasterPages.SelectTabLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.AuditMasterPages.Size = new System.Drawing.Size(1107, 321);
            this.AuditMasterPages.TabColor = System.Drawing.Color.DodgerBlue;
            this.AuditMasterPages.TabIndex = 51;
            // 
            // pgView
            // 
            this.pgView.Controls.Add(this.dgvViewAuditMaster);
            this.pgView.Location = new System.Drawing.Point(4, 30);
            this.pgView.Name = "pgView";
            this.pgView.Padding = new System.Windows.Forms.Padding(3);
            this.pgView.Size = new System.Drawing.Size(1099, 287);
            this.pgView.TabIndex = 0;
            this.pgView.Text = "View";
            this.pgView.UseVisualStyleBackColor = true;
            // 
            // pgDetail
            // 
            this.pgDetail.Controls.Add(this.gbxAddVendor);
            this.pgDetail.Location = new System.Drawing.Point(4, 30);
            this.pgDetail.Name = "pgDetail";
            this.pgDetail.Padding = new System.Windows.Forms.Padding(3);
            this.pgDetail.Size = new System.Drawing.Size(1099, 287);
            this.pgDetail.TabIndex = 1;
            this.pgDetail.Text = "Detail";
            this.pgDetail.UseVisualStyleBackColor = true;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnView.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnView.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnView.BorderRadius = 14;
            this.btnView.BorderSize = 0;
            this.btnView.FlatAppearance.BorderSize = 0;
            this.btnView.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Location = new System.Drawing.Point(16, 9);
            this.btnView.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnView.Name = "btnView";
            this.btnView.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnView.Size = new System.Drawing.Size(86, 30);
            this.btnView.TabIndex = 52;
            this.btnView.Text = "View Audit";
            this.btnView.TextColor = System.Drawing.Color.White;
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnCreateNew
            // 
            this.btnCreateNew.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCreateNew.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnCreateNew.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnCreateNew.BorderRadius = 14;
            this.btnCreateNew.BorderSize = 0;
            this.btnCreateNew.FlatAppearance.BorderSize = 0;
            this.btnCreateNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnCreateNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnCreateNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateNew.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateNew.ForeColor = System.Drawing.Color.White;
            this.btnCreateNew.Location = new System.Drawing.Point(115, 9);
            this.btnCreateNew.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnCreateNew.Name = "btnCreateNew";
            this.btnCreateNew.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnCreateNew.Size = new System.Drawing.Size(97, 30);
            this.btnCreateNew.TabIndex = 53;
            this.btnCreateNew.Text = "Create New";
            this.btnCreateNew.TextColor = System.Drawing.Color.White;
            this.btnCreateNew.UseVisualStyleBackColor = false;
            this.btnCreateNew.Click += new System.EventHandler(this.btnCreateNew_Click);
            // 
            // AuditMasterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 388);
            this.Controls.Add(this.btnCreateNew);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.AuditMasterPages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuditMasterView";
            this.Text = "Audit Master";
            this.Load += new System.EventHandler(this.AuditMasterView_Load);
            this.gbxAddVendor.ResumeLayout(false);
            this.gbxAddVendor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewAuditMaster)).EndInit();
            this.AuditMasterPages.ResumeLayout(false);
            this.pgView.ResumeLayout(false);
            this.pgDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxAddVendor;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblDescrip;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblChkPoints;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtRemarks;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtCheckPoint;
        private SparrowRMSControl.SparrowControl.SparrowButton btnSave;
        private SparrowRMSControl.SparrowControl.SparrowButton btnCancel;
        private System.Windows.Forms.DataGridView dgvViewAuditMaster;
        private SparrowRMSControl.SparrowControl.SparrowComboBox cmbCategory;
        private SparrowRMSControl.SparrowControl.SparrowTabControl AuditMasterPages;
        private System.Windows.Forms.TabPage pgView;
        private System.Windows.Forms.TabPage pgDetail;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblCate;
        private SparrowRMSControl.SparrowControl.SparrowButton btnView;
        private SparrowRMSControl.SparrowControl.SparrowButton btnCreateNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
    }
}