
namespace HindalcoiOS.AuditHind
{
    partial class AuditManagementView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuditManagementView));
            this.btnViewData = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.AuditMgmtPages = new SparrowRMSControl.SparrowControl.SparrowTabControl();
            this.pgView = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkCmbYear = new CheckComboBoxTest.CheckedComboBox();
            this.btnClearFilter = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnSearch = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.cmbToYear = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.lblfromYr = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.cmbAuditType = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.lblFDept = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.cmbDept = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.lblToYr = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblAudFtype = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.dgvViewAuditExeData = new System.Windows.Forms.DataGridView();
            this.AuditCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AudUpdateOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuditPlanId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuditManId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperationUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuditType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Auditor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Auditee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetClosDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpCloseMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuditStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuditEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuditCommMem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinQuarter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnViewBack = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.pgDetail = new System.Windows.Forms.TabPage();
            this.gbxObsDetails = new System.Windows.Forms.GroupBox();
            this.dgvAuditMgmtDetail = new System.Windows.Forms.DataGridView();
            this.SrlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AudMgmtDtlId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuditManIdDtl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObsCate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevSafetyStd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuditChkPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObsNarr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obsRootCauseAuditor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obsRootCauseAuditee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RiskCate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UploadImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.corrAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prevAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personResp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.complDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.audStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxAuditorSect = new System.Windows.Forms.GroupBox();
            this.lblRemarks = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtRemarks = new System.Windows.Forms.RichTextBox();
            this.btnDelete = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnBack = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.txtAudCommMem = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.sparrowLabel2 = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.dtpAudStartDate = new SparrowRMSControl.SparrowControl.SparrowDatePicker();
            this.lblAudStartDate = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtFinYear = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblFinYear = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtFinQtr = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblFinQtr = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.cmbAuditMonth = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.lblExpAudMonth = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.dtpAudEndDate = new SparrowRMSControl.SparrowControl.SparrowDatePicker();
            this.dtpTrgtClosDate = new SparrowRMSControl.SparrowControl.SparrowDatePicker();
            this.lblTrgtClosDate = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblAudEndDate = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblOpUnit = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtOpUnit = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.btnAddObs = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnSave = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnReject = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.lblDept = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtDept = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.dtpCreatedDate = new SparrowRMSControl.SparrowControl.SparrowDatePicker();
            this.lblStatus = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtStatus = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblName = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtAuditCode = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.sparrowLabel1 = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtAuditType = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblAuditType = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtCreatedBy = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtAuditee = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblAuditee = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblCreatedBy = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.txtArea = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtAuditor = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblArea = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.lblAuditor = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.pgAssigned = new System.Windows.Forms.TabPage();
            this.DGVDetails = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DxAuditManId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DxAuditPlanId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DxCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DxOperationUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DxDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DxAuditType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DxFinYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DxFinQuarter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DxExpCloseMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DxStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DxCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DxAuditor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DxAuditee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DxTargetClosDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DxAuditStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DxAuditEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DxAuditCommMem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DxRemarks = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAsgnBack = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.dgvAsgnData = new System.Windows.Forms.DataGridView();
            this.asgnDocNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asgnDocDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asgnDocBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asgnAuditor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asgnArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asgnAuditType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asgnObsRootCauseAuditor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asgnObsRootCauseAuditee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asgnsafetyStdDeviation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asgnCorrectiveActions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asgnRecurrPrevAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asgnOffResponsiblePrev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asgnComplDueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asgnAuditee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asgnOffResponsible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asgnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asgnObsCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asgnObsNarration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pgClosed = new System.Windows.Forms.TabPage();
            this.dgvClosData = new System.Windows.Forms.DataGridView();
            this.closAuditCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closAudUpdateOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closAuditPlanId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closAuditManId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closCreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closCreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closOperationUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closAuditType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closAuditor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closAuditee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closTargetClosDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closExpCloseMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closAuditStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closAuditEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closAuditCommMem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closFinYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closFinQuarter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClosBack = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.btnClosedData = new SparrowRMSControl.SparrowControl.SparrowButton();
            this.AuditMgmtPages.SuspendLayout();
            this.pgView.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewAuditExeData)).BeginInit();
            this.pgDetail.SuspendLayout();
            this.gbxObsDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditMgmtDetail)).BeginInit();
            this.gbxAuditorSect.SuspendLayout();
            this.pgAssigned.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsgnData)).BeginInit();
            this.pgClosed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClosData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnViewData
            // 
            this.btnViewData.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnViewData.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnViewData.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnViewData.BorderRadius = 14;
            this.btnViewData.BorderSize = 0;
            this.btnViewData.FlatAppearance.BorderSize = 0;
            this.btnViewData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnViewData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnViewData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewData.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewData.ForeColor = System.Drawing.Color.White;
            this.btnViewData.Location = new System.Drawing.Point(24, 5);
            this.btnViewData.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnViewData.Name = "btnViewData";
            this.btnViewData.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnViewData.Size = new System.Drawing.Size(102, 30);
            this.btnViewData.TabIndex = 56;
            this.btnViewData.Text = "View";
            this.btnViewData.TextColor = System.Drawing.Color.White;
            this.btnViewData.UseVisualStyleBackColor = false;
            this.btnViewData.Click += new System.EventHandler(this.btnViewData_Click);
            // 
            // AuditMgmtPages
            // 
            this.AuditMgmtPages.Controls.Add(this.pgView);
            this.AuditMgmtPages.Controls.Add(this.pgDetail);
            this.AuditMgmtPages.Controls.Add(this.pgAssigned);
            this.AuditMgmtPages.Controls.Add(this.pgClosed);
            // 
            // 
            // 
            this.AuditMgmtPages.DisplayStyleProvider.BlendStyle = SparrowRMSControl.SparrowControl.BlendStyle.Normal;
            this.AuditMgmtPages.DisplayStyleProvider.BorderColorDisabled = System.Drawing.SystemColors.ControlLight;
            this.AuditMgmtPages.DisplayStyleProvider.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.AuditMgmtPages.DisplayStyleProvider.BorderColorHighlighted = System.Drawing.SystemColors.ControlDark;
            this.AuditMgmtPages.DisplayStyleProvider.BorderColorSelected = System.Drawing.SystemColors.ControlDark;
            this.AuditMgmtPages.DisplayStyleProvider.BorderColorUnselected = System.Drawing.SystemColors.ControlDark;
            this.AuditMgmtPages.DisplayStyleProvider.CloserButtonFillColorFocused = System.Drawing.Color.Empty;
            this.AuditMgmtPages.DisplayStyleProvider.CloserButtonFillColorFocusedActive = System.Drawing.Color.Empty;
            this.AuditMgmtPages.DisplayStyleProvider.CloserButtonFillColorHighlighted = System.Drawing.Color.Empty;
            this.AuditMgmtPages.DisplayStyleProvider.CloserButtonFillColorHighlightedActive = System.Drawing.Color.Empty;
            this.AuditMgmtPages.DisplayStyleProvider.CloserButtonFillColorSelected = System.Drawing.Color.Empty;
            this.AuditMgmtPages.DisplayStyleProvider.CloserButtonFillColorSelectedActive = System.Drawing.Color.Empty;
            this.AuditMgmtPages.DisplayStyleProvider.CloserButtonFillColorUnselected = System.Drawing.Color.Empty;
            this.AuditMgmtPages.DisplayStyleProvider.CloserButtonOutlineColorFocused = System.Drawing.Color.Empty;
            this.AuditMgmtPages.DisplayStyleProvider.CloserButtonOutlineColorFocusedActive = System.Drawing.Color.Empty;
            this.AuditMgmtPages.DisplayStyleProvider.CloserButtonOutlineColorHighlighted = System.Drawing.Color.Empty;
            this.AuditMgmtPages.DisplayStyleProvider.CloserButtonOutlineColorHighlightedActive = System.Drawing.Color.Empty;
            this.AuditMgmtPages.DisplayStyleProvider.CloserButtonOutlineColorSelected = System.Drawing.Color.Empty;
            this.AuditMgmtPages.DisplayStyleProvider.CloserButtonOutlineColorSelectedActive = System.Drawing.Color.Empty;
            this.AuditMgmtPages.DisplayStyleProvider.CloserButtonOutlineColorUnselected = System.Drawing.Color.Empty;
            this.AuditMgmtPages.DisplayStyleProvider.CloserColorFocused = System.Drawing.SystemColors.ControlDark;
            this.AuditMgmtPages.DisplayStyleProvider.CloserColorFocusedActive = System.Drawing.SystemColors.ControlDark;
            this.AuditMgmtPages.DisplayStyleProvider.CloserColorHighlighted = System.Drawing.SystemColors.ControlDark;
            this.AuditMgmtPages.DisplayStyleProvider.CloserColorHighlightedActive = System.Drawing.SystemColors.ControlDark;
            this.AuditMgmtPages.DisplayStyleProvider.CloserColorSelected = System.Drawing.SystemColors.ControlDark;
            this.AuditMgmtPages.DisplayStyleProvider.CloserColorSelectedActive = System.Drawing.SystemColors.ControlDark;
            this.AuditMgmtPages.DisplayStyleProvider.CloserColorUnselected = System.Drawing.Color.Empty;
            this.AuditMgmtPages.DisplayStyleProvider.FocusTrack = false;
            this.AuditMgmtPages.DisplayStyleProvider.HotTrack = true;
            this.AuditMgmtPages.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AuditMgmtPages.DisplayStyleProvider.Opacity = 1F;
            this.AuditMgmtPages.DisplayStyleProvider.Overlap = 0;
            this.AuditMgmtPages.DisplayStyleProvider.Padding = new System.Drawing.Point(6, 3);
            this.AuditMgmtPages.DisplayStyleProvider.PageBackgroundColorDisabled = System.Drawing.SystemColors.Control;
            this.AuditMgmtPages.DisplayStyleProvider.PageBackgroundColorFocused = System.Drawing.Color.DodgerBlue;
            this.AuditMgmtPages.DisplayStyleProvider.PageBackgroundColorHighlighted = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.AuditMgmtPages.DisplayStyleProvider.PageBackgroundColorSelected = System.Drawing.SystemColors.ControlLightLight;
            this.AuditMgmtPages.DisplayStyleProvider.PageBackgroundColorUnselected = System.Drawing.SystemColors.Control;
            this.AuditMgmtPages.DisplayStyleProvider.Radius = 2;
            this.AuditMgmtPages.DisplayStyleProvider.SelectedTabIsLarger = true;
            this.AuditMgmtPages.DisplayStyleProvider.ShowTabCloser = false;
            this.AuditMgmtPages.DisplayStyleProvider.TabColorDisabled1 = System.Drawing.SystemColors.Control;
            this.AuditMgmtPages.DisplayStyleProvider.TabColorDisabled2 = System.Drawing.SystemColors.Control;
            this.AuditMgmtPages.DisplayStyleProvider.TabColorFocused1 = System.Drawing.Color.DodgerBlue;
            this.AuditMgmtPages.DisplayStyleProvider.TabColorFocused2 = System.Drawing.Color.DodgerBlue;
            this.AuditMgmtPages.DisplayStyleProvider.TabColorHighLighted1 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.AuditMgmtPages.DisplayStyleProvider.TabColorHighLighted2 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(237)))), ((int)(((byte)(252)))));
            this.AuditMgmtPages.DisplayStyleProvider.TabColorSelected1 = System.Drawing.SystemColors.ControlLightLight;
            this.AuditMgmtPages.DisplayStyleProvider.TabColorSelected2 = System.Drawing.SystemColors.ControlLightLight;
            this.AuditMgmtPages.DisplayStyleProvider.TabColorUnSelected1 = System.Drawing.SystemColors.Control;
            this.AuditMgmtPages.DisplayStyleProvider.TabColorUnSelected2 = System.Drawing.SystemColors.Control;
            this.AuditMgmtPages.DisplayStyleProvider.TabPageMargin = new System.Windows.Forms.Padding(1);
            this.AuditMgmtPages.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.AuditMgmtPages.DisplayStyleProvider.TextColorFocused = System.Drawing.Color.White;
            this.AuditMgmtPages.DisplayStyleProvider.TextColorHighlighted = System.Drawing.SystemColors.ControlText;
            this.AuditMgmtPages.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.AuditMgmtPages.DisplayStyleProvider.TextColorUnselected = System.Drawing.SystemColors.ControlText;
            this.AuditMgmtPages.HotTrack = true;
            this.AuditMgmtPages.Location = new System.Drawing.Point(14, 40);
            this.AuditMgmtPages.Name = "AuditMgmtPages";
            this.AuditMgmtPages.SelectedIndex = 0;
            this.AuditMgmtPages.SelectTabColor = System.Drawing.Color.DodgerBlue;
            this.AuditMgmtPages.SelectTabLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.AuditMgmtPages.Size = new System.Drawing.Size(1555, 710);
            this.AuditMgmtPages.TabColor = System.Drawing.Color.DodgerBlue;
            this.AuditMgmtPages.TabIndex = 58;
            // 
            // pgView
            // 
            this.pgView.BackColor = System.Drawing.Color.Gainsboro;
            this.pgView.Controls.Add(this.groupBox1);
            this.pgView.Controls.Add(this.dgvViewAuditExeData);
            this.pgView.Controls.Add(this.btnViewBack);
            this.pgView.Location = new System.Drawing.Point(4, 30);
            this.pgView.Name = "pgView";
            this.pgView.Padding = new System.Windows.Forms.Padding(3);
            this.pgView.Size = new System.Drawing.Size(1547, 676);
            this.pgView.TabIndex = 0;
            this.pgView.Text = "View";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkCmbYear);
            this.groupBox1.Controls.Add(this.btnClearFilter);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.cmbToYear);
            this.groupBox1.Controls.Add(this.lblfromYr);
            this.groupBox1.Controls.Add(this.cmbAuditType);
            this.groupBox1.Controls.Add(this.lblFDept);
            this.groupBox1.Controls.Add(this.cmbDept);
            this.groupBox1.Controls.Add(this.lblToYr);
            this.groupBox1.Controls.Add(this.lblAudFtype);
            this.groupBox1.Location = new System.Drawing.Point(22, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1496, 69);
            this.groupBox1.TabIndex = 108;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SearchBy";
            // 
            // chkCmbYear
            // 
            this.chkCmbYear.CheckOnClick = true;
            this.chkCmbYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.chkCmbYear.DropDownHeight = 1;
            this.chkCmbYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCmbYear.FormattingEnabled = true;
            this.chkCmbYear.IntegralHeight = false;
            this.chkCmbYear.Location = new System.Drawing.Point(153, 23);
            this.chkCmbYear.Name = "chkCmbYear";
            this.chkCmbYear.Size = new System.Drawing.Size(237, 28);
            this.chkCmbYear.TabIndex = 112;
            this.chkCmbYear.ValueSeparator = ", ";
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnClearFilter.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnClearFilter.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnClearFilter.BorderRadius = 14;
            this.btnClearFilter.BorderSize = 0;
            this.btnClearFilter.FlatAppearance.BorderSize = 0;
            this.btnClearFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnClearFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearFilter.ForeColor = System.Drawing.Color.White;
            this.btnClearFilter.Location = new System.Drawing.Point(1269, 23);
            this.btnClearFilter.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnClearFilter.Size = new System.Drawing.Size(113, 30);
            this.btnClearFilter.TabIndex = 111;
            this.btnClearFilter.Text = "Remove Filter";
            this.btnClearFilter.TextColor = System.Drawing.Color.White;
            this.btnClearFilter.UseVisualStyleBackColor = false;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.BorderRadius = 14;
            this.btnSearch.BorderSize = 0;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(970, 23);
            this.btnSearch.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnSearch.Size = new System.Drawing.Size(75, 30);
            this.btnSearch.TabIndex = 61;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextColor = System.Drawing.Color.White;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbToYear
            // 
            this.cmbToYear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbToYear.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbToYear.BorderSize = 1;
            this.cmbToYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbToYear.ForeColor = System.Drawing.Color.DimGray;
            this.cmbToYear.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbToYear.ItemHeight = 22;
            this.cmbToYear.Items.AddRange(new object[] {
            "20-21",
            "21-22",
            "22-23",
            "23-24",
            "24-25"});
            this.cmbToYear.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.cmbToYear.ListTextColor = System.Drawing.Color.White;
            this.cmbToYear.Location = new System.Drawing.Point(1469, 24);
            this.cmbToYear.MinimumSize = new System.Drawing.Size(45, 0);
            this.cmbToYear.Name = "cmbToYear";
            this.cmbToYear.Size = new System.Drawing.Size(45, 30);
            this.cmbToYear.TabIndex = 106;
            this.cmbToYear.Visible = false;
            // 
            // lblfromYr
            // 
            this.lblfromYr.AutoSize = true;
            this.lblfromYr.Depth = 0;
            this.lblfromYr.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblfromYr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblfromYr.Location = new System.Drawing.Point(40, 30);
            this.lblfromYr.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblfromYr.Name = "lblfromYr";
            this.lblfromYr.Size = new System.Drawing.Size(97, 18);
            this.lblfromYr.TabIndex = 107;
            this.lblfromYr.Text = "Financial Year";
            // 
            // cmbAuditType
            // 
            this.cmbAuditType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbAuditType.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbAuditType.BorderSize = 1;
            this.cmbAuditType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAuditType.ForeColor = System.Drawing.Color.DimGray;
            this.cmbAuditType.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbAuditType.ItemHeight = 22;
            this.cmbAuditType.Items.AddRange(new object[] {
            "L1",
            "L2",
            "L3"});
            this.cmbAuditType.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.cmbAuditType.ListTextColor = System.Drawing.Color.White;
            this.cmbAuditType.Location = new System.Drawing.Point(535, 24);
            this.cmbAuditType.MinimumSize = new System.Drawing.Size(45, 0);
            this.cmbAuditType.Name = "cmbAuditType";
            this.cmbAuditType.Size = new System.Drawing.Size(119, 30);
            this.cmbAuditType.TabIndex = 105;
            // 
            // lblFDept
            // 
            this.lblFDept.AutoSize = true;
            this.lblFDept.Depth = 0;
            this.lblFDept.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblFDept.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFDept.Location = new System.Drawing.Point(676, 29);
            this.lblFDept.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblFDept.Name = "lblFDept";
            this.lblFDept.Size = new System.Drawing.Size(86, 18);
            this.lblFDept.TabIndex = 102;
            this.lblFDept.Text = "Department";
            // 
            // cmbDept
            // 
            this.cmbDept.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbDept.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbDept.BorderSize = 1;
            this.cmbDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDept.ForeColor = System.Drawing.Color.DimGray;
            this.cmbDept.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbDept.ItemHeight = 22;
            this.cmbDept.ListBackColor = System.Drawing.Color.DodgerBlue;
            this.cmbDept.ListTextColor = System.Drawing.Color.White;
            this.cmbDept.Location = new System.Drawing.Point(787, 23);
            this.cmbDept.MinimumSize = new System.Drawing.Size(45, 0);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(159, 30);
            this.cmbDept.TabIndex = 101;
            // 
            // lblToYr
            // 
            this.lblToYr.AutoSize = true;
            this.lblToYr.Depth = 0;
            this.lblToYr.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblToYr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblToYr.Location = new System.Drawing.Point(1401, 30);
            this.lblToYr.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblToYr.Name = "lblToYr";
            this.lblToYr.Size = new System.Drawing.Size(62, 18);
            this.lblToYr.TabIndex = 100;
            this.lblToYr.Text = "To Year";
            this.lblToYr.Visible = false;
            // 
            // lblAudFtype
            // 
            this.lblAudFtype.AutoSize = true;
            this.lblAudFtype.Depth = 0;
            this.lblAudFtype.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblAudFtype.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAudFtype.Location = new System.Drawing.Point(427, 29);
            this.lblAudFtype.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblAudFtype.Name = "lblAudFtype";
            this.lblAudFtype.Size = new System.Drawing.Size(74, 18);
            this.lblAudFtype.TabIndex = 98;
            this.lblAudFtype.Text = "AuditType";
            // 
            // dgvViewAuditExeData
            // 
            this.dgvViewAuditExeData.AllowUserToAddRows = false;
            this.dgvViewAuditExeData.AllowUserToDeleteRows = false;
            this.dgvViewAuditExeData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvViewAuditExeData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvViewAuditExeData.ColumnHeadersHeight = 40;
            this.dgvViewAuditExeData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvViewAuditExeData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AuditCode,
            this.AudUpdateOn,
            this.AuditPlanId,
            this.AuditManId,
            this.CreatedDate,
            this.CreatedBy,
            this.OperationUnit,
            this.Department,
            this.AuditType,
            this.Auditor,
            this.Auditee,
            this.TargetClosDate,
            this.ExpCloseMonth,
            this.AuditStartDate,
            this.AuditEndDate,
            this.AuditCommMem,
            this.FinYear,
            this.FinQuarter,
            this.Status,
            this.Remarks});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvViewAuditExeData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvViewAuditExeData.EnableHeadersVisualStyles = false;
            this.dgvViewAuditExeData.Location = new System.Drawing.Point(15, 84);
            this.dgvViewAuditExeData.Name = "dgvViewAuditExeData";
            this.dgvViewAuditExeData.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvViewAuditExeData.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvViewAuditExeData.RowHeadersVisible = false;
            this.dgvViewAuditExeData.RowHeadersWidth = 65;
            this.dgvViewAuditExeData.RowTemplate.Height = 24;
            this.dgvViewAuditExeData.Size = new System.Drawing.Size(1521, 571);
            this.dgvViewAuditExeData.TabIndex = 107;
            this.dgvViewAuditExeData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViewAuditExeData_CellDoubleClick);
            // 
            // AuditCode
            // 
            this.AuditCode.HeaderText = "Audit Code";
            this.AuditCode.MinimumWidth = 6;
            this.AuditCode.Name = "AuditCode";
            this.AuditCode.ReadOnly = true;
            // 
            // AudUpdateOn
            // 
            this.AudUpdateOn.HeaderText = "AudUpdateOn";
            this.AudUpdateOn.MinimumWidth = 6;
            this.AudUpdateOn.Name = "AudUpdateOn";
            this.AudUpdateOn.ReadOnly = true;
            this.AudUpdateOn.Visible = false;
            // 
            // AuditPlanId
            // 
            this.AuditPlanId.HeaderText = "AuditPlanId";
            this.AuditPlanId.MinimumWidth = 6;
            this.AuditPlanId.Name = "AuditPlanId";
            this.AuditPlanId.ReadOnly = true;
            this.AuditPlanId.Visible = false;
            // 
            // AuditManId
            // 
            this.AuditManId.HeaderText = "AuditManId";
            this.AuditManId.MinimumWidth = 6;
            this.AuditManId.Name = "AuditManId";
            this.AuditManId.ReadOnly = true;
            this.AuditManId.Visible = false;
            // 
            // CreatedDate
            // 
            this.CreatedDate.HeaderText = "Created Date";
            this.CreatedDate.MinimumWidth = 6;
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.ReadOnly = true;
            // 
            // CreatedBy
            // 
            this.CreatedBy.HeaderText = "Created By";
            this.CreatedBy.MinimumWidth = 6;
            this.CreatedBy.Name = "CreatedBy";
            this.CreatedBy.ReadOnly = true;
            // 
            // OperationUnit
            // 
            this.OperationUnit.HeaderText = "OperationUnit";
            this.OperationUnit.MinimumWidth = 6;
            this.OperationUnit.Name = "OperationUnit";
            this.OperationUnit.ReadOnly = true;
            // 
            // Department
            // 
            this.Department.HeaderText = "Department";
            this.Department.MinimumWidth = 6;
            this.Department.Name = "Department";
            this.Department.ReadOnly = true;
            // 
            // AuditType
            // 
            this.AuditType.HeaderText = "Audit Type";
            this.AuditType.MinimumWidth = 6;
            this.AuditType.Name = "AuditType";
            this.AuditType.ReadOnly = true;
            // 
            // Auditor
            // 
            this.Auditor.HeaderText = "Auditor (DU)";
            this.Auditor.MinimumWidth = 6;
            this.Auditor.Name = "Auditor";
            this.Auditor.ReadOnly = true;
            // 
            // Auditee
            // 
            this.Auditee.HeaderText = "Auditee (DH)";
            this.Auditee.MinimumWidth = 6;
            this.Auditee.Name = "Auditee";
            this.Auditee.ReadOnly = true;
            // 
            // TargetClosDate
            // 
            this.TargetClosDate.HeaderText = "Target Closure Date";
            this.TargetClosDate.MinimumWidth = 6;
            this.TargetClosDate.Name = "TargetClosDate";
            this.TargetClosDate.ReadOnly = true;
            // 
            // ExpCloseMonth
            // 
            this.ExpCloseMonth.HeaderText = "Closure Month";
            this.ExpCloseMonth.MinimumWidth = 6;
            this.ExpCloseMonth.Name = "ExpCloseMonth";
            this.ExpCloseMonth.ReadOnly = true;
            // 
            // AuditStartDate
            // 
            this.AuditStartDate.HeaderText = "Audit Start Date";
            this.AuditStartDate.MinimumWidth = 6;
            this.AuditStartDate.Name = "AuditStartDate";
            this.AuditStartDate.ReadOnly = true;
            this.AuditStartDate.Visible = false;
            // 
            // AuditEndDate
            // 
            this.AuditEndDate.HeaderText = "Audit End Date";
            this.AuditEndDate.MinimumWidth = 6;
            this.AuditEndDate.Name = "AuditEndDate";
            this.AuditEndDate.ReadOnly = true;
            this.AuditEndDate.Visible = false;
            // 
            // AuditCommMem
            // 
            this.AuditCommMem.HeaderText = "Audit Commitee Member";
            this.AuditCommMem.MinimumWidth = 6;
            this.AuditCommMem.Name = "AuditCommMem";
            this.AuditCommMem.ReadOnly = true;
            this.AuditCommMem.Visible = false;
            // 
            // FinYear
            // 
            this.FinYear.HeaderText = "Financial Year";
            this.FinYear.MinimumWidth = 6;
            this.FinYear.Name = "FinYear";
            this.FinYear.ReadOnly = true;
            this.FinYear.Visible = false;
            // 
            // FinQuarter
            // 
            this.FinQuarter.HeaderText = "Financial Quarter";
            this.FinQuarter.MinimumWidth = 6;
            this.FinQuarter.Name = "FinQuarter";
            this.FinQuarter.ReadOnly = true;
            this.FinQuarter.Visible = false;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.MinimumWidth = 6;
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            this.Remarks.Visible = false;
            // 
            // btnViewBack
            // 
            this.btnViewBack.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnViewBack.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnViewBack.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnViewBack.BorderRadius = 14;
            this.btnViewBack.BorderSize = 0;
            this.btnViewBack.FlatAppearance.BorderSize = 0;
            this.btnViewBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnViewBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnViewBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewBack.ForeColor = System.Drawing.Color.White;
            this.btnViewBack.Location = new System.Drawing.Point(1685, 25);
            this.btnViewBack.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnViewBack.Name = "btnViewBack";
            this.btnViewBack.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnViewBack.Size = new System.Drawing.Size(128, 30);
            this.btnViewBack.TabIndex = 106;
            this.btnViewBack.Text = "<<Back";
            this.btnViewBack.TextColor = System.Drawing.Color.White;
            this.btnViewBack.UseVisualStyleBackColor = false;
            this.btnViewBack.Click += new System.EventHandler(this.btnViewBack_Click);
            // 
            // pgDetail
            // 
            this.pgDetail.BackColor = System.Drawing.Color.White;
            this.pgDetail.Controls.Add(this.gbxObsDetails);
            this.pgDetail.Controls.Add(this.gbxAuditorSect);
            this.pgDetail.Location = new System.Drawing.Point(4, 30);
            this.pgDetail.Name = "pgDetail";
            this.pgDetail.Padding = new System.Windows.Forms.Padding(3);
            this.pgDetail.Size = new System.Drawing.Size(1547, 676);
            this.pgDetail.TabIndex = 1;
            this.pgDetail.Text = "Detail";
            // 
            // gbxObsDetails
            // 
            this.gbxObsDetails.Controls.Add(this.dgvAuditMgmtDetail);
            this.gbxObsDetails.Location = new System.Drawing.Point(14, 427);
            this.gbxObsDetails.Name = "gbxObsDetails";
            this.gbxObsDetails.Size = new System.Drawing.Size(1513, 240);
            this.gbxObsDetails.TabIndex = 56;
            this.gbxObsDetails.TabStop = false;
            this.gbxObsDetails.Text = "Observation Details";
            // 
            // dgvAuditMgmtDetail
            // 
            this.dgvAuditMgmtDetail.AllowUserToAddRows = false;
            this.dgvAuditMgmtDetail.AllowUserToDeleteRows = false;
            this.dgvAuditMgmtDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAuditMgmtDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAuditMgmtDetail.ColumnHeadersHeight = 40;
            this.dgvAuditMgmtDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAuditMgmtDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SrlNo,
            this.AudMgmtDtlId,
            this.AuditManIdDtl,
            this.ObsCate,
            this.DevSafetyStd,
            this.AuditChkPoint,
            this.ObsNarr,
            this.obsRootCauseAuditor,
            this.obsRootCauseAuditee,
            this.RiskCate,
            this.UploadImg,
            this.corrAction,
            this.prevAction,
            this.personResp,
            this.complDate,
            this.audStatus});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAuditMgmtDetail.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvAuditMgmtDetail.EnableHeadersVisualStyles = false;
            this.dgvAuditMgmtDetail.Location = new System.Drawing.Point(13, 26);
            this.dgvAuditMgmtDetail.Name = "dgvAuditMgmtDetail";
            this.dgvAuditMgmtDetail.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAuditMgmtDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvAuditMgmtDetail.RowHeadersVisible = false;
            this.dgvAuditMgmtDetail.RowHeadersWidth = 65;
            this.dgvAuditMgmtDetail.RowTemplate.Height = 24;
            this.dgvAuditMgmtDetail.Size = new System.Drawing.Size(1482, 195);
            this.dgvAuditMgmtDetail.TabIndex = 114;
            this.dgvAuditMgmtDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAuditMgmtDetail_CellDoubleClick);
            // 
            // SrlNo
            // 
            this.SrlNo.HeaderText = "Obs. No.";
            this.SrlNo.MinimumWidth = 6;
            this.SrlNo.Name = "SrlNo";
            this.SrlNo.ReadOnly = true;
            // 
            // AudMgmtDtlId
            // 
            this.AudMgmtDtlId.HeaderText = "AudMgmtDtlId";
            this.AudMgmtDtlId.MinimumWidth = 6;
            this.AudMgmtDtlId.Name = "AudMgmtDtlId";
            this.AudMgmtDtlId.ReadOnly = true;
            this.AudMgmtDtlId.Visible = false;
            // 
            // AuditManIdDtl
            // 
            this.AuditManIdDtl.HeaderText = "AuditManId";
            this.AuditManIdDtl.MinimumWidth = 6;
            this.AuditManIdDtl.Name = "AuditManIdDtl";
            this.AuditManIdDtl.ReadOnly = true;
            this.AuditManIdDtl.Visible = false;
            // 
            // ObsCate
            // 
            this.ObsCate.HeaderText = "Obs. Category";
            this.ObsCate.MinimumWidth = 6;
            this.ObsCate.Name = "ObsCate";
            this.ObsCate.ReadOnly = true;
            // 
            // DevSafetyStd
            // 
            this.DevSafetyStd.HeaderText = "Deviation of Safety Standard";
            this.DevSafetyStd.MinimumWidth = 6;
            this.DevSafetyStd.Name = "DevSafetyStd";
            this.DevSafetyStd.ReadOnly = true;
            // 
            // AuditChkPoint
            // 
            this.AuditChkPoint.HeaderText = "Audit Check Point";
            this.AuditChkPoint.MinimumWidth = 6;
            this.AuditChkPoint.Name = "AuditChkPoint";
            this.AuditChkPoint.ReadOnly = true;
            // 
            // ObsNarr
            // 
            this.ObsNarr.HeaderText = "Narration of Observation";
            this.ObsNarr.MinimumWidth = 6;
            this.ObsNarr.Name = "ObsNarr";
            this.ObsNarr.ReadOnly = true;
            // 
            // obsRootCauseAuditor
            // 
            this.obsRootCauseAuditor.HeaderText = "Root Cause of Observation (Auditor)";
            this.obsRootCauseAuditor.MinimumWidth = 6;
            this.obsRootCauseAuditor.Name = "obsRootCauseAuditor";
            this.obsRootCauseAuditor.ReadOnly = true;
            this.obsRootCauseAuditor.Visible = false;
            // 
            // obsRootCauseAuditee
            // 
            this.obsRootCauseAuditee.HeaderText = "Root Cause of Observation (Auditee)";
            this.obsRootCauseAuditee.MinimumWidth = 6;
            this.obsRootCauseAuditee.Name = "obsRootCauseAuditee";
            this.obsRootCauseAuditee.ReadOnly = true;
            this.obsRootCauseAuditee.Visible = false;
            // 
            // RiskCate
            // 
            this.RiskCate.HeaderText = "Severity";
            this.RiskCate.MinimumWidth = 6;
            this.RiskCate.Name = "RiskCate";
            this.RiskCate.ReadOnly = true;
            // 
            // UploadImg
            // 
            this.UploadImg.HeaderText = "UploadImage";
            this.UploadImg.MinimumWidth = 6;
            this.UploadImg.Name = "UploadImg";
            this.UploadImg.ReadOnly = true;
            this.UploadImg.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UploadImg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.UploadImg.Visible = false;
            // 
            // corrAction
            // 
            this.corrAction.HeaderText = "Corrective Actions";
            this.corrAction.MinimumWidth = 6;
            this.corrAction.Name = "corrAction";
            this.corrAction.ReadOnly = true;
            this.corrAction.Visible = false;
            // 
            // prevAction
            // 
            this.prevAction.HeaderText = "Actions to Prevent Recurrance";
            this.prevAction.MinimumWidth = 6;
            this.prevAction.Name = "prevAction";
            this.prevAction.ReadOnly = true;
            this.prevAction.Visible = false;
            // 
            // personResp
            // 
            this.personResp.HeaderText = "Person Responsible";
            this.personResp.MinimumWidth = 6;
            this.personResp.Name = "personResp";
            this.personResp.ReadOnly = true;
            // 
            // complDate
            // 
            this.complDate.HeaderText = "Target Closure Date";
            this.complDate.MinimumWidth = 6;
            this.complDate.Name = "complDate";
            this.complDate.ReadOnly = true;
            // 
            // audStatus
            // 
            this.audStatus.HeaderText = "Obs. Status";
            this.audStatus.MinimumWidth = 6;
            this.audStatus.Name = "audStatus";
            this.audStatus.ReadOnly = true;
            // 
            // gbxAuditorSect
            // 
            this.gbxAuditorSect.BackColor = System.Drawing.Color.Gainsboro;
            this.gbxAuditorSect.Controls.Add(this.lblRemarks);
            this.gbxAuditorSect.Controls.Add(this.txtRemarks);
            this.gbxAuditorSect.Controls.Add(this.btnDelete);
            this.gbxAuditorSect.Controls.Add(this.btnBack);
            this.gbxAuditorSect.Controls.Add(this.txtAudCommMem);
            this.gbxAuditorSect.Controls.Add(this.sparrowLabel2);
            this.gbxAuditorSect.Controls.Add(this.dtpAudStartDate);
            this.gbxAuditorSect.Controls.Add(this.lblAudStartDate);
            this.gbxAuditorSect.Controls.Add(this.txtFinYear);
            this.gbxAuditorSect.Controls.Add(this.lblFinYear);
            this.gbxAuditorSect.Controls.Add(this.txtFinQtr);
            this.gbxAuditorSect.Controls.Add(this.lblFinQtr);
            this.gbxAuditorSect.Controls.Add(this.cmbAuditMonth);
            this.gbxAuditorSect.Controls.Add(this.lblExpAudMonth);
            this.gbxAuditorSect.Controls.Add(this.dtpAudEndDate);
            this.gbxAuditorSect.Controls.Add(this.dtpTrgtClosDate);
            this.gbxAuditorSect.Controls.Add(this.lblTrgtClosDate);
            this.gbxAuditorSect.Controls.Add(this.lblAudEndDate);
            this.gbxAuditorSect.Controls.Add(this.lblOpUnit);
            this.gbxAuditorSect.Controls.Add(this.txtOpUnit);
            this.gbxAuditorSect.Controls.Add(this.btnAddObs);
            this.gbxAuditorSect.Controls.Add(this.btnSave);
            this.gbxAuditorSect.Controls.Add(this.btnReject);
            this.gbxAuditorSect.Controls.Add(this.lblDept);
            this.gbxAuditorSect.Controls.Add(this.txtDept);
            this.gbxAuditorSect.Controls.Add(this.dtpCreatedDate);
            this.gbxAuditorSect.Controls.Add(this.lblStatus);
            this.gbxAuditorSect.Controls.Add(this.txtStatus);
            this.gbxAuditorSect.Controls.Add(this.lblName);
            this.gbxAuditorSect.Controls.Add(this.txtAuditCode);
            this.gbxAuditorSect.Controls.Add(this.sparrowLabel1);
            this.gbxAuditorSect.Controls.Add(this.txtAuditType);
            this.gbxAuditorSect.Controls.Add(this.lblAuditType);
            this.gbxAuditorSect.Controls.Add(this.txtCreatedBy);
            this.gbxAuditorSect.Controls.Add(this.txtAuditee);
            this.gbxAuditorSect.Controls.Add(this.lblAuditee);
            this.gbxAuditorSect.Controls.Add(this.lblCreatedBy);
            this.gbxAuditorSect.Controls.Add(this.txtArea);
            this.gbxAuditorSect.Controls.Add(this.txtAuditor);
            this.gbxAuditorSect.Controls.Add(this.lblArea);
            this.gbxAuditorSect.Controls.Add(this.lblAuditor);
            this.gbxAuditorSect.Location = new System.Drawing.Point(17, 10);
            this.gbxAuditorSect.Name = "gbxAuditorSect";
            this.gbxAuditorSect.Size = new System.Drawing.Size(1510, 411);
            this.gbxAuditorSect.TabIndex = 55;
            this.gbxAuditorSect.TabStop = false;
            this.gbxAuditorSect.Text = "Basic Details";
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Depth = 0;
            this.lblRemarks.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRemarks.Location = new System.Drawing.Point(480, 281);
            this.lblRemarks.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(65, 18);
            this.lblRemarks.TabIndex = 164;
            this.lblRemarks.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txtRemarks.Location = new System.Drawing.Point(622, 268);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtRemarks.Size = new System.Drawing.Size(781, 98);
            this.txtRemarks.TabIndex = 163;
            this.txtRemarks.Text = "";
            this.txtRemarks.TextChanged += new System.EventHandler(this.txtRemarks_TextChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.BackgroundColor = System.Drawing.Color.Red;
            this.btnDelete.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnDelete.BorderRadius = 14;
            this.btnDelete.BorderSize = 0;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(1053, 372);
            this.btnDelete.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnDelete.Size = new System.Drawing.Size(86, 30);
            this.btnDelete.TabIndex = 162;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextColor = System.Drawing.Color.White;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBack.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnBack.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnBack.BorderRadius = 14;
            this.btnBack.BorderSize = 0;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(1416, 9);
            this.btnBack.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnBack.Name = "btnBack";
            this.btnBack.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnBack.Size = new System.Drawing.Size(87, 30);
            this.btnBack.TabIndex = 161;
            this.btnBack.Text = "<< Back";
            this.btnBack.TextColor = System.Drawing.Color.White;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtAudCommMem
            // 
            this.txtAudCommMem.BackColor = System.Drawing.SystemColors.Window;
            this.txtAudCommMem.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtAudCommMem.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtAudCommMem.BorderRadius = 0;
            this.txtAudCommMem.BorderSize = 1;
            this.txtAudCommMem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAudCommMem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAudCommMem.Location = new System.Drawing.Point(1163, 79);
            this.txtAudCommMem.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtAudCommMem.Multiline = true;
            this.txtAudCommMem.Name = "txtAudCommMem";
            this.txtAudCommMem.Padding = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.txtAudCommMem.PasswordChar = false;
            this.txtAudCommMem.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtAudCommMem.PlaceholderText = "";
            this.txtAudCommMem.Size = new System.Drawing.Size(240, 35);
            this.txtAudCommMem.TabIndex = 159;
            this.txtAudCommMem.UnderlinedStyle = false;
            // 
            // sparrowLabel2
            // 
            this.sparrowLabel2.AutoSize = true;
            this.sparrowLabel2.Depth = 0;
            this.sparrowLabel2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.sparrowLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.sparrowLabel2.Location = new System.Drawing.Point(954, 85);
            this.sparrowLabel2.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.sparrowLabel2.Name = "sparrowLabel2";
            this.sparrowLabel2.Size = new System.Drawing.Size(175, 18);
            this.sparrowLabel2.TabIndex = 160;
            this.sparrowLabel2.Text = "Audit Committee Member";
            // 
            // dtpAudStartDate
            // 
            this.dtpAudStartDate.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.dtpAudStartDate.BorderSize = 0;
            this.dtpAudStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dtpAudStartDate.Location = new System.Drawing.Point(624, 175);
            this.dtpAudStartDate.MinimumSize = new System.Drawing.Size(4, 35);
            this.dtpAudStartDate.Name = "dtpAudStartDate";
            this.dtpAudStartDate.Size = new System.Drawing.Size(243, 35);
            this.dtpAudStartDate.SkinColor = System.Drawing.Color.MediumSlateBlue;
            this.dtpAudStartDate.TabIndex = 158;
            this.dtpAudStartDate.TextColor = System.Drawing.Color.White;
            // 
            // lblAudStartDate
            // 
            this.lblAudStartDate.AutoSize = true;
            this.lblAudStartDate.Depth = 0;
            this.lblAudStartDate.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblAudStartDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAudStartDate.Location = new System.Drawing.Point(480, 185);
            this.lblAudStartDate.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblAudStartDate.Name = "lblAudStartDate";
            this.lblAudStartDate.Size = new System.Drawing.Size(112, 18);
            this.lblAudStartDate.TabIndex = 157;
            this.lblAudStartDate.Text = "Audit Start Date";
            // 
            // txtFinYear
            // 
            this.txtFinYear.BackColor = System.Drawing.SystemColors.Window;
            this.txtFinYear.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtFinYear.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtFinYear.BorderRadius = 0;
            this.txtFinYear.BorderSize = 1;
            this.txtFinYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFinYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFinYear.Location = new System.Drawing.Point(624, 75);
            this.txtFinYear.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtFinYear.Multiline = true;
            this.txtFinYear.Name = "txtFinYear";
            this.txtFinYear.Padding = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.txtFinYear.PasswordChar = false;
            this.txtFinYear.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtFinYear.PlaceholderText = "";
            this.txtFinYear.Size = new System.Drawing.Size(243, 39);
            this.txtFinYear.TabIndex = 156;
            this.txtFinYear.UnderlinedStyle = false;
            // 
            // lblFinYear
            // 
            this.lblFinYear.AutoSize = true;
            this.lblFinYear.Depth = 0;
            this.lblFinYear.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblFinYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFinYear.Location = new System.Drawing.Point(480, 89);
            this.lblFinYear.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblFinYear.Name = "lblFinYear";
            this.lblFinYear.Size = new System.Drawing.Size(97, 18);
            this.lblFinYear.TabIndex = 155;
            this.lblFinYear.Text = "Financial Year";
            // 
            // txtFinQtr
            // 
            this.txtFinQtr.BackColor = System.Drawing.SystemColors.Window;
            this.txtFinQtr.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtFinQtr.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtFinQtr.BorderRadius = 0;
            this.txtFinQtr.BorderSize = 1;
            this.txtFinQtr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFinQtr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFinQtr.Location = new System.Drawing.Point(624, 126);
            this.txtFinQtr.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtFinQtr.Multiline = true;
            this.txtFinQtr.Name = "txtFinQtr";
            this.txtFinQtr.Padding = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.txtFinQtr.PasswordChar = false;
            this.txtFinQtr.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtFinQtr.PlaceholderText = "";
            this.txtFinQtr.Size = new System.Drawing.Size(243, 37);
            this.txtFinQtr.TabIndex = 154;
            this.txtFinQtr.UnderlinedStyle = false;
            // 
            // lblFinQtr
            // 
            this.lblFinQtr.AutoSize = true;
            this.lblFinQtr.Depth = 0;
            this.lblFinQtr.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblFinQtr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFinQtr.Location = new System.Drawing.Point(480, 133);
            this.lblFinQtr.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblFinQtr.Name = "lblFinQtr";
            this.lblFinQtr.Size = new System.Drawing.Size(116, 18);
            this.lblFinQtr.TabIndex = 153;
            this.lblFinQtr.Text = "Financial Quarter";
            // 
            // cmbAuditMonth
            // 
            this.cmbAuditMonth.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cmbAuditMonth.BorderSize = 0;
            this.cmbAuditMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.cmbAuditMonth.FormattingEnabled = true;
            this.cmbAuditMonth.IconColor = System.Drawing.Color.DodgerBlue;
            this.cmbAuditMonth.ListBackColor = System.Drawing.Color.Red;
            this.cmbAuditMonth.ListTextColor = System.Drawing.Color.White;
            this.cmbAuditMonth.Location = new System.Drawing.Point(1163, 127);
            this.cmbAuditMonth.Name = "cmbAuditMonth";
            this.cmbAuditMonth.Size = new System.Drawing.Size(239, 28);
            this.cmbAuditMonth.TabIndex = 152;
            // 
            // lblExpAudMonth
            // 
            this.lblExpAudMonth.AutoSize = true;
            this.lblExpAudMonth.Depth = 0;
            this.lblExpAudMonth.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblExpAudMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblExpAudMonth.Location = new System.Drawing.Point(954, 133);
            this.lblExpAudMonth.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblExpAudMonth.Name = "lblExpAudMonth";
            this.lblExpAudMonth.Size = new System.Drawing.Size(104, 18);
            this.lblExpAudMonth.TabIndex = 151;
            this.lblExpAudMonth.Text = "Month of Audit";
            // 
            // dtpAudEndDate
            // 
            this.dtpAudEndDate.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.dtpAudEndDate.BorderSize = 0;
            this.dtpAudEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dtpAudEndDate.Location = new System.Drawing.Point(627, 222);
            this.dtpAudEndDate.MinimumSize = new System.Drawing.Size(4, 35);
            this.dtpAudEndDate.Name = "dtpAudEndDate";
            this.dtpAudEndDate.Size = new System.Drawing.Size(239, 35);
            this.dtpAudEndDate.SkinColor = System.Drawing.Color.MediumSlateBlue;
            this.dtpAudEndDate.TabIndex = 150;
            this.dtpAudEndDate.TextColor = System.Drawing.Color.White;
            // 
            // dtpTrgtClosDate
            // 
            this.dtpTrgtClosDate.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.dtpTrgtClosDate.BorderSize = 0;
            this.dtpTrgtClosDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dtpTrgtClosDate.Location = new System.Drawing.Point(1163, 32);
            this.dtpTrgtClosDate.MinimumSize = new System.Drawing.Size(4, 35);
            this.dtpTrgtClosDate.Name = "dtpTrgtClosDate";
            this.dtpTrgtClosDate.Size = new System.Drawing.Size(239, 35);
            this.dtpTrgtClosDate.SkinColor = System.Drawing.Color.MediumSlateBlue;
            this.dtpTrgtClosDate.TabIndex = 149;
            this.dtpTrgtClosDate.TextColor = System.Drawing.Color.White;
            // 
            // lblTrgtClosDate
            // 
            this.lblTrgtClosDate.AutoSize = true;
            this.lblTrgtClosDate.Depth = 0;
            this.lblTrgtClosDate.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTrgtClosDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTrgtClosDate.Location = new System.Drawing.Point(954, 39);
            this.lblTrgtClosDate.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblTrgtClosDate.Name = "lblTrgtClosDate";
            this.lblTrgtClosDate.Size = new System.Drawing.Size(140, 18);
            this.lblTrgtClosDate.TabIndex = 148;
            this.lblTrgtClosDate.Text = "Target Closure Date";
            // 
            // lblAudEndDate
            // 
            this.lblAudEndDate.AutoSize = true;
            this.lblAudEndDate.Depth = 0;
            this.lblAudEndDate.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblAudEndDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAudEndDate.Location = new System.Drawing.Point(480, 229);
            this.lblAudEndDate.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblAudEndDate.Name = "lblAudEndDate";
            this.lblAudEndDate.Size = new System.Drawing.Size(105, 18);
            this.lblAudEndDate.TabIndex = 147;
            this.lblAudEndDate.Text = "Audit End Date";
            // 
            // lblOpUnit
            // 
            this.lblOpUnit.AutoSize = true;
            this.lblOpUnit.Depth = 0;
            this.lblOpUnit.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblOpUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblOpUnit.Location = new System.Drawing.Point(19, 183);
            this.lblOpUnit.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblOpUnit.Name = "lblOpUnit";
            this.lblOpUnit.Size = new System.Drawing.Size(101, 18);
            this.lblOpUnit.TabIndex = 117;
            this.lblOpUnit.Text = "Operation Unit";
            // 
            // txtOpUnit
            // 
            this.txtOpUnit.BackColor = System.Drawing.SystemColors.Window;
            this.txtOpUnit.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtOpUnit.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtOpUnit.BorderRadius = 0;
            this.txtOpUnit.BorderSize = 1;
            this.txtOpUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOpUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtOpUnit.Location = new System.Drawing.Point(162, 171);
            this.txtOpUnit.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtOpUnit.Multiline = true;
            this.txtOpUnit.Name = "txtOpUnit";
            this.txtOpUnit.Padding = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.txtOpUnit.PasswordChar = false;
            this.txtOpUnit.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtOpUnit.PlaceholderText = "";
            this.txtOpUnit.Size = new System.Drawing.Size(243, 35);
            this.txtOpUnit.TabIndex = 116;
            this.txtOpUnit.UnderlinedStyle = false;
            // 
            // btnAddObs
            // 
            this.btnAddObs.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddObs.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnAddObs.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnAddObs.BorderRadius = 14;
            this.btnAddObs.BorderSize = 0;
            this.btnAddObs.FlatAppearance.BorderSize = 0;
            this.btnAddObs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAddObs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAddObs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddObs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddObs.ForeColor = System.Drawing.Color.White;
            this.btnAddObs.Location = new System.Drawing.Point(1163, 371);
            this.btnAddObs.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAddObs.Name = "btnAddObs";
            this.btnAddObs.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnAddObs.Size = new System.Drawing.Size(142, 30);
            this.btnAddObs.TabIndex = 115;
            this.btnAddObs.Text = "Add Observation";
            this.btnAddObs.TextColor = System.Drawing.Color.White;
            this.btnAddObs.UseVisualStyleBackColor = false;
            this.btnAddObs.Click += new System.EventHandler(this.btnAddObs_Click);
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
            this.btnSave.Location = new System.Drawing.Point(1318, 371);
            this.btnSave.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnSave.Name = "btnSave";
            this.btnSave.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnSave.Size = new System.Drawing.Size(86, 30);
            this.btnSave.TabIndex = 112;
            this.btnSave.Text = "Submit";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnReject.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnReject.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnReject.BorderRadius = 14;
            this.btnReject.BorderSize = 0;
            this.btnReject.FlatAppearance.BorderSize = 0;
            this.btnReject.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnReject.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(1410, 371);
            this.btnReject.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnReject.Name = "btnReject";
            this.btnReject.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnReject.Size = new System.Drawing.Size(86, 30);
            this.btnReject.TabIndex = 110;
            this.btnReject.Text = "Reject";
            this.btnReject.TextColor = System.Drawing.Color.White;
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.Depth = 0;
            this.lblDept.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblDept.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDept.Location = new System.Drawing.Point(19, 226);
            this.lblDept.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(86, 18);
            this.lblDept.TabIndex = 113;
            this.lblDept.Text = "Department";
            // 
            // txtDept
            // 
            this.txtDept.BackColor = System.Drawing.SystemColors.Window;
            this.txtDept.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtDept.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtDept.BorderRadius = 0;
            this.txtDept.BorderSize = 1;
            this.txtDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDept.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDept.Location = new System.Drawing.Point(162, 219);
            this.txtDept.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtDept.Multiline = true;
            this.txtDept.Name = "txtDept";
            this.txtDept.Padding = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.txtDept.PasswordChar = false;
            this.txtDept.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtDept.PlaceholderText = "";
            this.txtDept.Size = new System.Drawing.Size(243, 35);
            this.txtDept.TabIndex = 112;
            this.txtDept.UnderlinedStyle = false;
            // 
            // dtpCreatedDate
            // 
            this.dtpCreatedDate.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.dtpCreatedDate.BorderSize = 0;
            this.dtpCreatedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dtpCreatedDate.Location = new System.Drawing.Point(162, 75);
            this.dtpCreatedDate.MinimumSize = new System.Drawing.Size(4, 35);
            this.dtpCreatedDate.Name = "dtpCreatedDate";
            this.dtpCreatedDate.Size = new System.Drawing.Size(243, 35);
            this.dtpCreatedDate.SkinColor = System.Drawing.Color.MediumSlateBlue;
            this.dtpCreatedDate.TabIndex = 109;
            this.dtpCreatedDate.TextColor = System.Drawing.Color.White;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Depth = 0;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblStatus.Location = new System.Drawing.Point(954, 175);
            this.lblStatus.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(49, 18);
            this.lblStatus.TabIndex = 108;
            this.lblStatus.Text = "Status";
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Window;
            this.txtStatus.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtStatus.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtStatus.BorderRadius = 0;
            this.txtStatus.BorderSize = 1;
            this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtStatus.Location = new System.Drawing.Point(1163, 171);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Padding = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.txtStatus.PasswordChar = false;
            this.txtStatus.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtStatus.PlaceholderText = "";
            this.txtStatus.Size = new System.Drawing.Size(240, 35);
            this.txtStatus.TabIndex = 87;
            this.txtStatus.UnderlinedStyle = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Depth = 0;
            this.lblName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblName.Location = new System.Drawing.Point(19, 39);
            this.lblName.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(83, 18);
            this.lblName.TabIndex = 69;
            this.lblName.Text = " Audit Code";
            // 
            // txtAuditCode
            // 
            this.txtAuditCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtAuditCode.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtAuditCode.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtAuditCode.BorderRadius = 0;
            this.txtAuditCode.BorderSize = 1;
            this.txtAuditCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuditCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAuditCode.Location = new System.Drawing.Point(162, 27);
            this.txtAuditCode.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtAuditCode.Multiline = true;
            this.txtAuditCode.Name = "txtAuditCode";
            this.txtAuditCode.Padding = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.txtAuditCode.PasswordChar = false;
            this.txtAuditCode.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtAuditCode.PlaceholderText = "";
            this.txtAuditCode.Size = new System.Drawing.Size(243, 35);
            this.txtAuditCode.TabIndex = 68;
            this.txtAuditCode.UnderlinedStyle = false;
            // 
            // sparrowLabel1
            // 
            this.sparrowLabel1.AutoSize = true;
            this.sparrowLabel1.Depth = 0;
            this.sparrowLabel1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.sparrowLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.sparrowLabel1.Location = new System.Drawing.Point(19, 83);
            this.sparrowLabel1.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.sparrowLabel1.Name = "sparrowLabel1";
            this.sparrowLabel1.Size = new System.Drawing.Size(95, 18);
            this.sparrowLabel1.TabIndex = 71;
            this.sparrowLabel1.Text = "Created Date";
            // 
            // txtAuditType
            // 
            this.txtAuditType.BackColor = System.Drawing.SystemColors.Window;
            this.txtAuditType.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtAuditType.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtAuditType.BorderRadius = 0;
            this.txtAuditType.BorderSize = 1;
            this.txtAuditType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuditType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAuditType.Location = new System.Drawing.Point(161, 270);
            this.txtAuditType.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtAuditType.Multiline = true;
            this.txtAuditType.Name = "txtAuditType";
            this.txtAuditType.Padding = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.txtAuditType.PasswordChar = false;
            this.txtAuditType.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtAuditType.PlaceholderText = "";
            this.txtAuditType.Size = new System.Drawing.Size(243, 35);
            this.txtAuditType.TabIndex = 72;
            this.txtAuditType.UnderlinedStyle = false;
            // 
            // lblAuditType
            // 
            this.lblAuditType.AutoSize = true;
            this.lblAuditType.Depth = 0;
            this.lblAuditType.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblAuditType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAuditType.Location = new System.Drawing.Point(19, 282);
            this.lblAuditType.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblAuditType.Name = "lblAuditType";
            this.lblAuditType.Size = new System.Drawing.Size(79, 18);
            this.lblAuditType.TabIndex = 73;
            this.lblAuditType.Text = "Audit Type";
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.BackColor = System.Drawing.SystemColors.Window;
            this.txtCreatedBy.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtCreatedBy.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtCreatedBy.BorderRadius = 0;
            this.txtCreatedBy.BorderSize = 1;
            this.txtCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreatedBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCreatedBy.Location = new System.Drawing.Point(162, 123);
            this.txtCreatedBy.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCreatedBy.Multiline = true;
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.Padding = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.txtCreatedBy.PasswordChar = false;
            this.txtCreatedBy.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtCreatedBy.PlaceholderText = "";
            this.txtCreatedBy.Size = new System.Drawing.Size(243, 35);
            this.txtCreatedBy.TabIndex = 75;
            this.txtCreatedBy.UnderlinedStyle = false;
            // 
            // txtAuditee
            // 
            this.txtAuditee.BackColor = System.Drawing.SystemColors.Window;
            this.txtAuditee.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtAuditee.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtAuditee.BorderRadius = 0;
            this.txtAuditee.BorderSize = 1;
            this.txtAuditee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuditee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAuditee.Location = new System.Drawing.Point(624, 31);
            this.txtAuditee.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtAuditee.Multiline = true;
            this.txtAuditee.Name = "txtAuditee";
            this.txtAuditee.Padding = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.txtAuditee.PasswordChar = false;
            this.txtAuditee.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtAuditee.PlaceholderText = "";
            this.txtAuditee.Size = new System.Drawing.Size(243, 35);
            this.txtAuditee.TabIndex = 74;
            this.txtAuditee.UnderlinedStyle = false;
            // 
            // lblAuditee
            // 
            this.lblAuditee.AutoSize = true;
            this.lblAuditee.Depth = 0;
            this.lblAuditee.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblAuditee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAuditee.Location = new System.Drawing.Point(480, 45);
            this.lblAuditee.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblAuditee.Name = "lblAuditee";
            this.lblAuditee.Size = new System.Drawing.Size(93, 18);
            this.lblAuditee.TabIndex = 76;
            this.lblAuditee.Text = "Auditee (DH)";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Depth = 0;
            this.lblCreatedBy.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblCreatedBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCreatedBy.Location = new System.Drawing.Point(19, 131);
            this.lblCreatedBy.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(81, 18);
            this.lblCreatedBy.TabIndex = 78;
            this.lblCreatedBy.Text = "Created By";
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
            this.txtArea.Location = new System.Drawing.Point(1419, 78);
            this.txtArea.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtArea.Multiline = true;
            this.txtArea.Name = "txtArea";
            this.txtArea.Padding = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.txtArea.PasswordChar = false;
            this.txtArea.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtArea.PlaceholderText = "";
            this.txtArea.Size = new System.Drawing.Size(72, 35);
            this.txtArea.TabIndex = 79;
            this.txtArea.UnderlinedStyle = false;
            this.txtArea.Visible = false;
            // 
            // txtAuditor
            // 
            this.txtAuditor.BackColor = System.Drawing.SystemColors.Window;
            this.txtAuditor.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtAuditor.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtAuditor.BorderRadius = 0;
            this.txtAuditor.BorderSize = 1;
            this.txtAuditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuditor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAuditor.Location = new System.Drawing.Point(161, 320);
            this.txtAuditor.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtAuditor.Multiline = true;
            this.txtAuditor.Name = "txtAuditor";
            this.txtAuditor.Padding = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.txtAuditor.PasswordChar = false;
            this.txtAuditor.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtAuditor.PlaceholderText = "";
            this.txtAuditor.Size = new System.Drawing.Size(243, 35);
            this.txtAuditor.TabIndex = 81;
            this.txtAuditor.UnderlinedStyle = false;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Depth = 0;
            this.lblArea.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblArea.Location = new System.Drawing.Point(1438, 126);
            this.lblArea.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(38, 18);
            this.lblArea.TabIndex = 82;
            this.lblArea.Text = "Area";
            this.lblArea.Visible = false;
            // 
            // lblAuditor
            // 
            this.lblAuditor.AutoSize = true;
            this.lblAuditor.Depth = 0;
            this.lblAuditor.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblAuditor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAuditor.Location = new System.Drawing.Point(19, 331);
            this.lblAuditor.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.lblAuditor.Name = "lblAuditor";
            this.lblAuditor.Size = new System.Drawing.Size(90, 18);
            this.lblAuditor.TabIndex = 83;
            this.lblAuditor.Text = "Auditor (DU)";
            // 
            // pgAssigned
            // 
            this.pgAssigned.BackColor = System.Drawing.Color.White;
            this.pgAssigned.Controls.Add(this.DGVDetails);
            this.pgAssigned.Controls.Add(this.btnAsgnBack);
            this.pgAssigned.Controls.Add(this.dgvAsgnData);
            this.pgAssigned.Location = new System.Drawing.Point(4, 30);
            this.pgAssigned.Name = "pgAssigned";
            this.pgAssigned.Padding = new System.Windows.Forms.Padding(3);
            this.pgAssigned.Size = new System.Drawing.Size(1547, 676);
            this.pgAssigned.TabIndex = 2;
            this.pgAssigned.Text = "Assigned";
            // 
            // DGVDetails
            // 
            this.DGVDetails.Location = new System.Drawing.Point(27, 36);
            this.DGVDetails.MainView = this.gridView1;
            this.DGVDetails.Name = "DGVDetails";
            this.DGVDetails.Size = new System.Drawing.Size(1146, 604);
            this.DGVDetails.TabIndex = 60;
            this.DGVDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DxAuditManId,
            this.DxAuditPlanId,
            this.DxCreatedDate,
            this.DxOperationUnit,
            this.DxDepartment,
            this.DxAuditType,
            this.DxFinYear,
            this.DxFinQuarter,
            this.DxExpCloseMonth,
            this.DxStatus,
            this.DxCreatedBy,
            this.DxAuditor,
            this.DxAuditee,
            this.DxTargetClosDate,
            this.DxAuditStartDate,
            this.DxAuditEndDate,
            this.DxAuditCommMem,
            this.DxRemarks});
            this.gridView1.GridControl = this.DGVDetails;
            this.gridView1.Name = "gridView1";
            // 
            // DxAuditManId
            // 
            this.DxAuditManId.Caption = "AuditManId";
            this.DxAuditManId.MinWidth = 25;
            this.DxAuditManId.Name = "DxAuditManId";
            this.DxAuditManId.Visible = true;
            this.DxAuditManId.VisibleIndex = 0;
            this.DxAuditManId.Width = 94;
            // 
            // DxAuditPlanId
            // 
            this.DxAuditPlanId.Caption = "AuditPlanId";
            this.DxAuditPlanId.MinWidth = 25;
            this.DxAuditPlanId.Name = "DxAuditPlanId";
            this.DxAuditPlanId.Visible = true;
            this.DxAuditPlanId.VisibleIndex = 1;
            this.DxAuditPlanId.Width = 94;
            // 
            // DxCreatedDate
            // 
            this.DxCreatedDate.Caption = "Created Date";
            this.DxCreatedDate.MinWidth = 25;
            this.DxCreatedDate.Name = "DxCreatedDate";
            this.DxCreatedDate.Visible = true;
            this.DxCreatedDate.VisibleIndex = 2;
            this.DxCreatedDate.Width = 94;
            // 
            // DxOperationUnit
            // 
            this.DxOperationUnit.Caption = "Operation Unit";
            this.DxOperationUnit.MinWidth = 25;
            this.DxOperationUnit.Name = "DxOperationUnit";
            this.DxOperationUnit.Visible = true;
            this.DxOperationUnit.VisibleIndex = 3;
            this.DxOperationUnit.Width = 94;
            // 
            // DxDepartment
            // 
            this.DxDepartment.Caption = "Department";
            this.DxDepartment.MinWidth = 25;
            this.DxDepartment.Name = "DxDepartment";
            this.DxDepartment.Visible = true;
            this.DxDepartment.VisibleIndex = 4;
            this.DxDepartment.Width = 94;
            // 
            // DxAuditType
            // 
            this.DxAuditType.Caption = "AuditType";
            this.DxAuditType.MinWidth = 25;
            this.DxAuditType.Name = "DxAuditType";
            this.DxAuditType.Visible = true;
            this.DxAuditType.VisibleIndex = 5;
            this.DxAuditType.Width = 94;
            // 
            // DxFinYear
            // 
            this.DxFinYear.Caption = "FinYear";
            this.DxFinYear.MinWidth = 25;
            this.DxFinYear.Name = "DxFinYear";
            this.DxFinYear.Visible = true;
            this.DxFinYear.VisibleIndex = 6;
            this.DxFinYear.Width = 94;
            // 
            // DxFinQuarter
            // 
            this.DxFinQuarter.Caption = "FinQuarter";
            this.DxFinQuarter.MinWidth = 25;
            this.DxFinQuarter.Name = "DxFinQuarter";
            this.DxFinQuarter.Visible = true;
            this.DxFinQuarter.VisibleIndex = 7;
            this.DxFinQuarter.Width = 94;
            // 
            // DxExpCloseMonth
            // 
            this.DxExpCloseMonth.Caption = "Exp Close Month";
            this.DxExpCloseMonth.MinWidth = 25;
            this.DxExpCloseMonth.Name = "DxExpCloseMonth";
            this.DxExpCloseMonth.Visible = true;
            this.DxExpCloseMonth.VisibleIndex = 8;
            this.DxExpCloseMonth.Width = 94;
            // 
            // DxStatus
            // 
            this.DxStatus.Caption = "Status";
            this.DxStatus.MinWidth = 25;
            this.DxStatus.Name = "DxStatus";
            this.DxStatus.Visible = true;
            this.DxStatus.VisibleIndex = 9;
            this.DxStatus.Width = 94;
            // 
            // DxCreatedBy
            // 
            this.DxCreatedBy.Caption = "CreatedBy";
            this.DxCreatedBy.MinWidth = 25;
            this.DxCreatedBy.Name = "DxCreatedBy";
            this.DxCreatedBy.Visible = true;
            this.DxCreatedBy.VisibleIndex = 10;
            this.DxCreatedBy.Width = 94;
            // 
            // DxAuditor
            // 
            this.DxAuditor.Caption = "Auditor";
            this.DxAuditor.MinWidth = 25;
            this.DxAuditor.Name = "DxAuditor";
            this.DxAuditor.Visible = true;
            this.DxAuditor.VisibleIndex = 11;
            this.DxAuditor.Width = 94;
            // 
            // DxAuditee
            // 
            this.DxAuditee.Caption = "Auditee";
            this.DxAuditee.MinWidth = 25;
            this.DxAuditee.Name = "DxAuditee";
            this.DxAuditee.Visible = true;
            this.DxAuditee.VisibleIndex = 12;
            this.DxAuditee.Width = 94;
            // 
            // DxTargetClosDate
            // 
            this.DxTargetClosDate.Caption = "Target Closure Date";
            this.DxTargetClosDate.MinWidth = 25;
            this.DxTargetClosDate.Name = "DxTargetClosDate";
            this.DxTargetClosDate.Visible = true;
            this.DxTargetClosDate.VisibleIndex = 13;
            this.DxTargetClosDate.Width = 94;
            // 
            // DxAuditStartDate
            // 
            this.DxAuditStartDate.Caption = "AuditStartDate";
            this.DxAuditStartDate.MinWidth = 25;
            this.DxAuditStartDate.Name = "DxAuditStartDate";
            this.DxAuditStartDate.Visible = true;
            this.DxAuditStartDate.VisibleIndex = 14;
            this.DxAuditStartDate.Width = 94;
            // 
            // DxAuditEndDate
            // 
            this.DxAuditEndDate.Caption = "Audit End Date";
            this.DxAuditEndDate.MinWidth = 25;
            this.DxAuditEndDate.Name = "DxAuditEndDate";
            this.DxAuditEndDate.Visible = true;
            this.DxAuditEndDate.VisibleIndex = 15;
            this.DxAuditEndDate.Width = 94;
            // 
            // DxAuditCommMem
            // 
            this.DxAuditCommMem.Caption = "Audit Comm Mem";
            this.DxAuditCommMem.MinWidth = 25;
            this.DxAuditCommMem.Name = "DxAuditCommMem";
            this.DxAuditCommMem.Visible = true;
            this.DxAuditCommMem.VisibleIndex = 16;
            this.DxAuditCommMem.Width = 94;
            // 
            // DxRemarks
            // 
            this.DxRemarks.Caption = "Remarks";
            this.DxRemarks.MinWidth = 25;
            this.DxRemarks.Name = "DxRemarks";
            this.DxRemarks.Visible = true;
            this.DxRemarks.VisibleIndex = 17;
            this.DxRemarks.Width = 94;
            // 
            // btnAsgnBack
            // 
            this.btnAsgnBack.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAsgnBack.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnAsgnBack.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnAsgnBack.BorderRadius = 14;
            this.btnAsgnBack.BorderSize = 0;
            this.btnAsgnBack.FlatAppearance.BorderSize = 0;
            this.btnAsgnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAsgnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAsgnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsgnBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsgnBack.ForeColor = System.Drawing.Color.White;
            this.btnAsgnBack.Location = new System.Drawing.Point(1691, 15);
            this.btnAsgnBack.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnAsgnBack.Name = "btnAsgnBack";
            this.btnAsgnBack.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnAsgnBack.Size = new System.Drawing.Size(128, 30);
            this.btnAsgnBack.TabIndex = 59;
            this.btnAsgnBack.Text = "<<Back";
            this.btnAsgnBack.TextColor = System.Drawing.Color.White;
            this.btnAsgnBack.UseVisualStyleBackColor = false;
            this.btnAsgnBack.Click += new System.EventHandler(this.btnAsgnBack_Click);
            // 
            // dgvAsgnData
            // 
            this.dgvAsgnData.AllowUserToAddRows = false;
            this.dgvAsgnData.AllowUserToDeleteRows = false;
            this.dgvAsgnData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAsgnData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvAsgnData.ColumnHeadersHeight = 40;
            this.dgvAsgnData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAsgnData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.asgnDocNo,
            this.asgnDocDate,
            this.asgnDocBy,
            this.asgnAuditor,
            this.asgnArea,
            this.asgnAuditType,
            this.asgnObsRootCauseAuditor,
            this.asgnObsRootCauseAuditee,
            this.asgnsafetyStdDeviation,
            this.asgnCorrectiveActions,
            this.asgnRecurrPrevAction,
            this.asgnOffResponsiblePrev,
            this.asgnComplDueDate,
            this.asgnAuditee,
            this.asgnOffResponsible,
            this.asgnStatus,
            this.asgnObsCategory,
            this.asgnObsNarration});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAsgnData.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvAsgnData.EnableHeadersVisualStyles = false;
            this.dgvAsgnData.Location = new System.Drawing.Point(1228, 16);
            this.dgvAsgnData.Name = "dgvAsgnData";
            this.dgvAsgnData.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAsgnData.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvAsgnData.RowHeadersVisible = false;
            this.dgvAsgnData.RowHeadersWidth = 65;
            this.dgvAsgnData.RowTemplate.Height = 24;
            this.dgvAsgnData.Size = new System.Drawing.Size(300, 333);
            this.dgvAsgnData.TabIndex = 2;
            this.dgvAsgnData.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAsgnData_CellContentDoubleClick);
            // 
            // asgnDocNo
            // 
            this.asgnDocNo.HeaderText = "Document No";
            this.asgnDocNo.MinimumWidth = 6;
            this.asgnDocNo.Name = "asgnDocNo";
            this.asgnDocNo.ReadOnly = true;
            this.asgnDocNo.Width = 140;
            // 
            // asgnDocDate
            // 
            this.asgnDocDate.HeaderText = "Document Date";
            this.asgnDocDate.MinimumWidth = 6;
            this.asgnDocDate.Name = "asgnDocDate";
            this.asgnDocDate.ReadOnly = true;
            this.asgnDocDate.Width = 156;
            // 
            // asgnDocBy
            // 
            this.asgnDocBy.HeaderText = "Documented By";
            this.asgnDocBy.MinimumWidth = 6;
            this.asgnDocBy.Name = "asgnDocBy";
            this.asgnDocBy.ReadOnly = true;
            this.asgnDocBy.Width = 156;
            // 
            // asgnAuditor
            // 
            this.asgnAuditor.HeaderText = "Auditor";
            this.asgnAuditor.MinimumWidth = 6;
            this.asgnAuditor.Name = "asgnAuditor";
            this.asgnAuditor.ReadOnly = true;
            this.asgnAuditor.Width = 93;
            // 
            // asgnArea
            // 
            this.asgnArea.HeaderText = "Area";
            this.asgnArea.MinimumWidth = 6;
            this.asgnArea.Name = "asgnArea";
            this.asgnArea.ReadOnly = true;
            this.asgnArea.Visible = false;
            this.asgnArea.Width = 74;
            // 
            // asgnAuditType
            // 
            this.asgnAuditType.HeaderText = "Audit Type";
            this.asgnAuditType.MinimumWidth = 6;
            this.asgnAuditType.Name = "asgnAuditType";
            this.asgnAuditType.ReadOnly = true;
            this.asgnAuditType.Width = 119;
            // 
            // asgnObsRootCauseAuditor
            // 
            this.asgnObsRootCauseAuditor.HeaderText = "Root Cause of Observation (Auditor)";
            this.asgnObsRootCauseAuditor.MinimumWidth = 6;
            this.asgnObsRootCauseAuditor.Name = "asgnObsRootCauseAuditor";
            this.asgnObsRootCauseAuditor.ReadOnly = true;
            this.asgnObsRootCauseAuditor.Width = 310;
            // 
            // asgnObsRootCauseAuditee
            // 
            this.asgnObsRootCauseAuditee.HeaderText = "Root Cause of Observation (Auditee)";
            this.asgnObsRootCauseAuditee.MinimumWidth = 6;
            this.asgnObsRootCauseAuditee.Name = "asgnObsRootCauseAuditee";
            this.asgnObsRootCauseAuditee.ReadOnly = true;
            this.asgnObsRootCauseAuditee.Width = 313;
            // 
            // asgnsafetyStdDeviation
            // 
            this.asgnsafetyStdDeviation.HeaderText = "Deviation of Safety Standard";
            this.asgnsafetyStdDeviation.MinimumWidth = 6;
            this.asgnsafetyStdDeviation.Name = "asgnsafetyStdDeviation";
            this.asgnsafetyStdDeviation.ReadOnly = true;
            this.asgnsafetyStdDeviation.Width = 250;
            // 
            // asgnCorrectiveActions
            // 
            this.asgnCorrectiveActions.HeaderText = "Corrective Actions";
            this.asgnCorrectiveActions.MinimumWidth = 6;
            this.asgnCorrectiveActions.Name = "asgnCorrectiveActions";
            this.asgnCorrectiveActions.ReadOnly = true;
            this.asgnCorrectiveActions.Visible = false;
            this.asgnCorrectiveActions.Width = 174;
            // 
            // asgnRecurrPrevAction
            // 
            this.asgnRecurrPrevAction.HeaderText = "Actions to Prevent Recurrance";
            this.asgnRecurrPrevAction.MinimumWidth = 6;
            this.asgnRecurrPrevAction.Name = "asgnRecurrPrevAction";
            this.asgnRecurrPrevAction.ReadOnly = true;
            this.asgnRecurrPrevAction.Visible = false;
            this.asgnRecurrPrevAction.Width = 264;
            // 
            // asgnOffResponsiblePrev
            // 
            this.asgnOffResponsiblePrev.HeaderText = "Person Responsible ";
            this.asgnOffResponsiblePrev.MinimumWidth = 6;
            this.asgnOffResponsiblePrev.Name = "asgnOffResponsiblePrev";
            this.asgnOffResponsiblePrev.ReadOnly = true;
            this.asgnOffResponsiblePrev.Width = 188;
            // 
            // asgnComplDueDate
            // 
            this.asgnComplDueDate.HeaderText = "Due Date of Completion";
            this.asgnComplDueDate.MinimumWidth = 6;
            this.asgnComplDueDate.Name = "asgnComplDueDate";
            this.asgnComplDueDate.ReadOnly = true;
            this.asgnComplDueDate.Width = 217;
            // 
            // asgnAuditee
            // 
            this.asgnAuditee.HeaderText = "Auditee";
            this.asgnAuditee.MinimumWidth = 6;
            this.asgnAuditee.Name = "asgnAuditee";
            this.asgnAuditee.ReadOnly = true;
            this.asgnAuditee.Width = 96;
            // 
            // asgnOffResponsible
            // 
            this.asgnOffResponsible.HeaderText = "Official Responsible (Corr)";
            this.asgnOffResponsible.MinimumWidth = 6;
            this.asgnOffResponsible.Name = "asgnOffResponsible";
            this.asgnOffResponsible.ReadOnly = true;
            this.asgnOffResponsible.Width = 234;
            // 
            // asgnStatus
            // 
            this.asgnStatus.HeaderText = "Current Status";
            this.asgnStatus.MinimumWidth = 6;
            this.asgnStatus.Name = "asgnStatus";
            this.asgnStatus.ReadOnly = true;
            this.asgnStatus.Width = 146;
            // 
            // asgnObsCategory
            // 
            this.asgnObsCategory.HeaderText = "Category of Observation";
            this.asgnObsCategory.MinimumWidth = 6;
            this.asgnObsCategory.Name = "asgnObsCategory";
            this.asgnObsCategory.ReadOnly = true;
            this.asgnObsCategory.Width = 218;
            // 
            // asgnObsNarration
            // 
            this.asgnObsNarration.HeaderText = "Narration Of Observation";
            this.asgnObsNarration.MinimumWidth = 6;
            this.asgnObsNarration.Name = "asgnObsNarration";
            this.asgnObsNarration.ReadOnly = true;
            this.asgnObsNarration.Width = 224;
            // 
            // pgClosed
            // 
            this.pgClosed.BackColor = System.Drawing.Color.White;
            this.pgClosed.Controls.Add(this.dgvClosData);
            this.pgClosed.Controls.Add(this.btnClosBack);
            this.pgClosed.Location = new System.Drawing.Point(4, 30);
            this.pgClosed.Name = "pgClosed";
            this.pgClosed.Padding = new System.Windows.Forms.Padding(3);
            this.pgClosed.Size = new System.Drawing.Size(1547, 676);
            this.pgClosed.TabIndex = 3;
            this.pgClosed.Text = "Closed";
            // 
            // dgvClosData
            // 
            this.dgvClosData.AllowUserToAddRows = false;
            this.dgvClosData.AllowUserToDeleteRows = false;
            this.dgvClosData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClosData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvClosData.ColumnHeadersHeight = 40;
            this.dgvClosData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvClosData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.closAuditCode,
            this.closAudUpdateOn,
            this.closRemarks,
            this.closAuditPlanId,
            this.closAuditManId,
            this.closCreatedDate,
            this.closCreatedBy,
            this.closOperationUnit,
            this.closDepartment,
            this.closAuditType,
            this.closAuditor,
            this.closAuditee,
            this.closTargetClosDate,
            this.closExpCloseMonth,
            this.closAuditStartDate,
            this.closAuditEndDate,
            this.closAuditCommMem,
            this.closFinYear,
            this.closFinQuarter,
            this.closStatus});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClosData.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvClosData.EnableHeadersVisualStyles = false;
            this.dgvClosData.Location = new System.Drawing.Point(23, 18);
            this.dgvClosData.Name = "dgvClosData";
            this.dgvClosData.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClosData.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvClosData.RowHeadersVisible = false;
            this.dgvClosData.RowHeadersWidth = 65;
            this.dgvClosData.RowTemplate.Height = 24;
            this.dgvClosData.Size = new System.Drawing.Size(1502, 637);
            this.dgvClosData.TabIndex = 109;
            // 
            // closAuditCode
            // 
            this.closAuditCode.HeaderText = "Audit Code";
            this.closAuditCode.MinimumWidth = 6;
            this.closAuditCode.Name = "closAuditCode";
            this.closAuditCode.ReadOnly = true;
            this.closAuditCode.Width = 107;
            // 
            // closAudUpdateOn
            // 
            this.closAudUpdateOn.HeaderText = "AudUpdateOn";
            this.closAudUpdateOn.MinimumWidth = 6;
            this.closAudUpdateOn.Name = "closAudUpdateOn";
            this.closAudUpdateOn.ReadOnly = true;
            this.closAudUpdateOn.Visible = false;
            this.closAudUpdateOn.Width = 128;
            // 
            // closRemarks
            // 
            this.closRemarks.HeaderText = "Remarks";
            this.closRemarks.MinimumWidth = 6;
            this.closRemarks.Name = "closRemarks";
            this.closRemarks.ReadOnly = true;
            this.closRemarks.Visible = false;
            this.closRemarks.Width = 94;
            // 
            // closAuditPlanId
            // 
            this.closAuditPlanId.HeaderText = "AuditPlanId";
            this.closAuditPlanId.MinimumWidth = 6;
            this.closAuditPlanId.Name = "closAuditPlanId";
            this.closAuditPlanId.ReadOnly = true;
            this.closAuditPlanId.Visible = false;
            this.closAuditPlanId.Width = 109;
            // 
            // closAuditManId
            // 
            this.closAuditManId.HeaderText = "AuditManId";
            this.closAuditManId.MinimumWidth = 6;
            this.closAuditManId.Name = "closAuditManId";
            this.closAuditManId.ReadOnly = true;
            this.closAuditManId.Visible = false;
            this.closAuditManId.Width = 111;
            // 
            // closCreatedDate
            // 
            this.closCreatedDate.HeaderText = "Created Date";
            this.closCreatedDate.MinimumWidth = 6;
            this.closCreatedDate.Name = "closCreatedDate";
            this.closCreatedDate.ReadOnly = true;
            this.closCreatedDate.Width = 124;
            // 
            // closCreatedBy
            // 
            this.closCreatedBy.HeaderText = "Created By";
            this.closCreatedBy.MinimumWidth = 6;
            this.closCreatedBy.Name = "closCreatedBy";
            this.closCreatedBy.ReadOnly = true;
            this.closCreatedBy.Width = 110;
            // 
            // closOperationUnit
            // 
            this.closOperationUnit.HeaderText = "OperationUnit";
            this.closOperationUnit.MinimumWidth = 6;
            this.closOperationUnit.Name = "closOperationUnit";
            this.closOperationUnit.ReadOnly = true;
            this.closOperationUnit.Visible = false;
            this.closOperationUnit.Width = 125;
            // 
            // closDepartment
            // 
            this.closDepartment.HeaderText = "Department";
            this.closDepartment.MinimumWidth = 6;
            this.closDepartment.Name = "closDepartment";
            this.closDepartment.ReadOnly = true;
            this.closDepartment.Width = 115;
            // 
            // closAuditType
            // 
            this.closAuditType.HeaderText = "Audit Type";
            this.closAuditType.MinimumWidth = 6;
            this.closAuditType.Name = "closAuditType";
            this.closAuditType.ReadOnly = true;
            this.closAuditType.Width = 108;
            // 
            // closAuditor
            // 
            this.closAuditor.HeaderText = "Auditor (DU)";
            this.closAuditor.MinimumWidth = 6;
            this.closAuditor.Name = "closAuditor";
            this.closAuditor.ReadOnly = true;
            this.closAuditor.Width = 119;
            // 
            // closAuditee
            // 
            this.closAuditee.HeaderText = "Auditee (DH)";
            this.closAuditee.MinimumWidth = 6;
            this.closAuditee.Name = "closAuditee";
            this.closAuditee.ReadOnly = true;
            this.closAuditee.Width = 122;
            // 
            // closTargetClosDate
            // 
            this.closTargetClosDate.HeaderText = "Target Closure Date";
            this.closTargetClosDate.MinimumWidth = 6;
            this.closTargetClosDate.Name = "closTargetClosDate";
            this.closTargetClosDate.ReadOnly = true;
            this.closTargetClosDate.Width = 169;
            // 
            // closExpCloseMonth
            // 
            this.closExpCloseMonth.HeaderText = "Closure Month";
            this.closExpCloseMonth.MinimumWidth = 6;
            this.closExpCloseMonth.Name = "closExpCloseMonth";
            this.closExpCloseMonth.ReadOnly = true;
            this.closExpCloseMonth.Width = 130;
            // 
            // closAuditStartDate
            // 
            this.closAuditStartDate.HeaderText = "Audit Start Date";
            this.closAuditStartDate.MinimumWidth = 6;
            this.closAuditStartDate.Name = "closAuditStartDate";
            this.closAuditStartDate.ReadOnly = true;
            this.closAuditStartDate.Visible = false;
            this.closAuditStartDate.Width = 141;
            // 
            // closAuditEndDate
            // 
            this.closAuditEndDate.HeaderText = "Audit End Date";
            this.closAuditEndDate.MinimumWidth = 6;
            this.closAuditEndDate.Name = "closAuditEndDate";
            this.closAuditEndDate.ReadOnly = true;
            this.closAuditEndDate.Visible = false;
            this.closAuditEndDate.Width = 134;
            // 
            // closAuditCommMem
            // 
            this.closAuditCommMem.HeaderText = "Audit Commitee Member";
            this.closAuditCommMem.MinimumWidth = 6;
            this.closAuditCommMem.Name = "closAuditCommMem";
            this.closAuditCommMem.ReadOnly = true;
            this.closAuditCommMem.Width = 199;
            // 
            // closFinYear
            // 
            this.closFinYear.HeaderText = "Financial Year";
            this.closFinYear.MinimumWidth = 6;
            this.closFinYear.Name = "closFinYear";
            this.closFinYear.ReadOnly = true;
            this.closFinYear.Width = 126;
            // 
            // closFinQuarter
            // 
            this.closFinQuarter.HeaderText = "Financial Quarter";
            this.closFinQuarter.MinimumWidth = 6;
            this.closFinQuarter.Name = "closFinQuarter";
            this.closFinQuarter.ReadOnly = true;
            this.closFinQuarter.Width = 145;
            // 
            // closStatus
            // 
            this.closStatus.HeaderText = "Status";
            this.closStatus.MinimumWidth = 6;
            this.closStatus.Name = "closStatus";
            this.closStatus.ReadOnly = true;
            this.closStatus.Width = 78;
            // 
            // btnClosBack
            // 
            this.btnClosBack.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnClosBack.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnClosBack.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnClosBack.BorderRadius = 14;
            this.btnClosBack.BorderSize = 0;
            this.btnClosBack.FlatAppearance.BorderSize = 0;
            this.btnClosBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnClosBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnClosBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClosBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClosBack.ForeColor = System.Drawing.Color.White;
            this.btnClosBack.Location = new System.Drawing.Point(1682, 16);
            this.btnClosBack.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnClosBack.Name = "btnClosBack";
            this.btnClosBack.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnClosBack.Size = new System.Drawing.Size(128, 30);
            this.btnClosBack.TabIndex = 58;
            this.btnClosBack.Text = "<<Back";
            this.btnClosBack.TextColor = System.Drawing.Color.White;
            this.btnClosBack.UseVisualStyleBackColor = false;
            this.btnClosBack.Click += new System.EventHandler(this.btnClosBack_Click);
            // 
            // btnClosedData
            // 
            this.btnClosedData.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnClosedData.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.btnClosedData.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnClosedData.BorderRadius = 14;
            this.btnClosedData.BorderSize = 0;
            this.btnClosedData.FlatAppearance.BorderSize = 0;
            this.btnClosedData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnClosedData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnClosedData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClosedData.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClosedData.ForeColor = System.Drawing.Color.White;
            this.btnClosedData.Location = new System.Drawing.Point(139, 5);
            this.btnClosedData.MouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(254)))));
            this.btnClosedData.Name = "btnClosedData";
            this.btnClosedData.OnPressed = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.btnClosedData.Size = new System.Drawing.Size(128, 30);
            this.btnClosedData.TabIndex = 60;
            this.btnClosedData.Text = "Closed Record";
            this.btnClosedData.TextColor = System.Drawing.Color.White;
            this.btnClosedData.UseVisualStyleBackColor = false;
            this.btnClosedData.Click += new System.EventHandler(this.btnClosedData_Click);
            // 
            // AuditManagementView
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1587, 762);
            this.Controls.Add(this.btnClosedData);
            this.Controls.Add(this.AuditMgmtPages);
            this.Controls.Add(this.btnViewData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("AuditManagementView.IconOptions.Image")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuditManagementView";
            this.Text = "Audit Management";
            this.Load += new System.EventHandler(this.AuditManagementView_Load);
            this.AuditMgmtPages.ResumeLayout(false);
            this.pgView.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewAuditExeData)).EndInit();
            this.pgDetail.ResumeLayout(false);
            this.gbxObsDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditMgmtDetail)).EndInit();
            this.gbxAuditorSect.ResumeLayout(false);
            this.gbxAuditorSect.PerformLayout();
            this.pgAssigned.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsgnData)).EndInit();
            this.pgClosed.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClosData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private SparrowRMSControl.SparrowControl.SparrowButton btnViewData;
        private SparrowRMSControl.SparrowControl.SparrowTabControl AuditMgmtPages;
        private System.Windows.Forms.TabPage pgView;
        private System.Windows.Forms.TabPage pgDetail;
        private System.Windows.Forms.GroupBox gbxAuditorSect;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblAuditor;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblArea;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtAuditor;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtArea;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblCreatedBy;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblAuditee;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtAuditee;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtCreatedBy;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblAuditType;
        private SparrowRMSControl.SparrowControl.SparrowLabel sparrowLabel1;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblName;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtAuditCode;
        private SparrowRMSControl.SparrowControl.SparrowDatePicker dtpCreatedDate;
        private SparrowRMSControl.SparrowControl.SparrowButton btnClosedData;
        private System.Windows.Forms.TabPage pgAssigned;
        private System.Windows.Forms.TabPage pgClosed;
        private SparrowRMSControl.SparrowControl.SparrowButton btnReject;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtAuditType;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblDept;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtDept;
        private System.Windows.Forms.DataGridView dgvAsgnData;
        private SparrowRMSControl.SparrowControl.SparrowButton btnClosBack;
        private SparrowRMSControl.SparrowControl.SparrowButton btnAsgnBack;
        private SparrowRMSControl.SparrowControl.SparrowButton btnViewBack;
        private SparrowRMSControl.SparrowControl.SparrowButton btnSave;
        private System.Windows.Forms.DataGridView dgvAuditMgmtDetail;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblStatus;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtStatus;
        private SparrowRMSControl.SparrowControl.SparrowButton btnAddObs;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblOpUnit;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtOpUnit;
        private SparrowRMSControl.SparrowControl.SparrowDatePicker dtpAudStartDate;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblAudStartDate;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtFinYear;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblFinYear;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtFinQtr;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblFinQtr;
        private SparrowRMSControl.SparrowControl.SparrowComboBox cmbAuditMonth;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblExpAudMonth;
        private SparrowRMSControl.SparrowControl.SparrowDatePicker dtpAudEndDate;
        private SparrowRMSControl.SparrowControl.SparrowDatePicker dtpTrgtClosDate;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblTrgtClosDate;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblAudEndDate;
        private SparrowRMSControl.SparrowControl.SparrowTextBox txtAudCommMem;
        private SparrowRMSControl.SparrowControl.SparrowLabel sparrowLabel2;
        private System.Windows.Forms.DataGridView dgvViewAuditExeData;
        private SparrowRMSControl.SparrowControl.SparrowButton btnBack;
        private System.Windows.Forms.DataGridViewTextBoxColumn asgnDocNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn asgnDocDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn asgnDocBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn asgnAuditor;
        private System.Windows.Forms.DataGridViewTextBoxColumn asgnArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn asgnAuditType;
        private System.Windows.Forms.DataGridViewTextBoxColumn asgnObsRootCauseAuditor;
        private System.Windows.Forms.DataGridViewTextBoxColumn asgnObsRootCauseAuditee;
        private System.Windows.Forms.DataGridViewTextBoxColumn asgnsafetyStdDeviation;
        private System.Windows.Forms.DataGridViewTextBoxColumn asgnCorrectiveActions;
        private System.Windows.Forms.DataGridViewTextBoxColumn asgnRecurrPrevAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn asgnOffResponsiblePrev;
        private System.Windows.Forms.DataGridViewTextBoxColumn asgnComplDueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn asgnAuditee;
        private System.Windows.Forms.DataGridViewTextBoxColumn asgnOffResponsible;
        private System.Windows.Forms.DataGridViewTextBoxColumn asgnStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn asgnObsCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn asgnObsNarration;
        private System.Windows.Forms.DataGridView dgvClosData;
        private System.Windows.Forms.GroupBox gbxObsDetails;
        private System.Windows.Forms.GroupBox groupBox1;
        private SparrowRMSControl.SparrowControl.SparrowButton btnDelete;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblRemarks;
        private System.Windows.Forms.RichTextBox txtRemarks;
        private SparrowRMSControl.SparrowControl.SparrowButton btnSearch;
        public SparrowRMSControl.SparrowControl.SparrowComboBox cmbToYear;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblfromYr;
        public SparrowRMSControl.SparrowControl.SparrowComboBox cmbAuditType;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblFDept;
        public SparrowRMSControl.SparrowControl.SparrowComboBox cmbDept;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblToYr;
        private SparrowRMSControl.SparrowControl.SparrowLabel lblAudFtype;
        private SparrowRMSControl.SparrowControl.SparrowButton btnClearFilter;
        private CheckComboBoxTest.CheckedComboBox chkCmbYear;
        private DevExpress.XtraGrid.GridControl DGVDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn DxAuditManId;
        private DevExpress.XtraGrid.Columns.GridColumn DxAuditPlanId;
        private DevExpress.XtraGrid.Columns.GridColumn DxCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn DxOperationUnit;
        private DevExpress.XtraGrid.Columns.GridColumn DxDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn DxAuditType;
        private DevExpress.XtraGrid.Columns.GridColumn DxFinYear;
        private DevExpress.XtraGrid.Columns.GridColumn DxFinQuarter;
        private DevExpress.XtraGrid.Columns.GridColumn DxExpCloseMonth;
        private DevExpress.XtraGrid.Columns.GridColumn DxStatus;
        private DevExpress.XtraGrid.Columns.GridColumn DxCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn DxAuditor;
        private DevExpress.XtraGrid.Columns.GridColumn DxAuditee;
        private DevExpress.XtraGrid.Columns.GridColumn DxTargetClosDate;
        private DevExpress.XtraGrid.Columns.GridColumn DxAuditStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn DxAuditEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn DxAuditCommMem;
        private DevExpress.XtraGrid.Columns.GridColumn DxRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn AudUpdateOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditPlanId;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditManId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperationUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Auditor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Auditee;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetClosDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpCloseMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditCommMem;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinQuarter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn closAuditCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn closAudUpdateOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn closAuditPlanId;
        private System.Windows.Forms.DataGridViewTextBoxColumn closAuditManId;
        private System.Windows.Forms.DataGridViewTextBoxColumn closCreatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn closCreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn closOperationUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn closDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn closAuditType;
        private System.Windows.Forms.DataGridViewTextBoxColumn closAuditor;
        private System.Windows.Forms.DataGridViewTextBoxColumn closAuditee;
        private System.Windows.Forms.DataGridViewTextBoxColumn closTargetClosDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn closExpCloseMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn closAuditStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn closAuditEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn closAuditCommMem;
        private System.Windows.Forms.DataGridViewTextBoxColumn closFinYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn closFinQuarter;
        private System.Windows.Forms.DataGridViewTextBoxColumn closStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrlNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AudMgmtDtlId;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditManIdDtl;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObsCate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevSafetyStd;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuditChkPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObsNarr;
        private System.Windows.Forms.DataGridViewTextBoxColumn obsRootCauseAuditor;
        private System.Windows.Forms.DataGridViewTextBoxColumn obsRootCauseAuditee;
        private System.Windows.Forms.DataGridViewTextBoxColumn RiskCate;
        private System.Windows.Forms.DataGridViewImageColumn UploadImg;
        private System.Windows.Forms.DataGridViewTextBoxColumn corrAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn prevAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn personResp;
        private System.Windows.Forms.DataGridViewTextBoxColumn complDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn audStatus;
    }
}