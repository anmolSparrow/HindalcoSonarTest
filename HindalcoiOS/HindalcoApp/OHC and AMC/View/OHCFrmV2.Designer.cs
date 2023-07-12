
namespace HindalcoiOS.OHC_and_AMC.View
{
    partial class OHCFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OHCFrm));
            this.OHCPanel = new DevExpress.XtraEditors.PanelControl();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.OHClbl = new SparrowRMSControl.SparrowControl.SparrowLabel();
            this.btnUpload = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportData = new DevExpress.XtraEditors.SimpleButton();
            this.GRPOHCDetails = new DevExpress.XtraEditors.GroupControl();
            this.txtEmployeeCode = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtCompnay = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnuploadImage = new DevExpress.XtraEditors.SimpleButton();
            this.btnUploadRPT = new DevExpress.XtraEditors.SimpleButton();
            this.pictureEmp = new DevExpress.XtraEditors.PictureEdit();
            this.lblupload = new DevExpress.XtraEditors.LabelControl();
            this.dropdownHealth = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.dropdownEMPType = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.dropdownDPT = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.datetimeDOJ = new SparrowRMSControl.SparrowControl.SparrowDatePicker();
            this.dropdownGender = new SparrowRMSControl.SparrowControl.SparrowComboBox();
            this.datetimeCheckDate = new SparrowRMSControl.SparrowControl.SparrowDatePicker();
            this.DatePickerDOB = new SparrowRMSControl.SparrowControl.SparrowDatePicker();
            this.txtRemark = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtAaDharNo = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtEmpName = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.txtsrno = new SparrowRMSControl.SparrowControl.SparrowTextBox();
            this.lblReport = new DevExpress.XtraEditors.LabelControl();
            this.lblRemark = new DevExpress.XtraEditors.LabelControl();
            this.lblHealthChk = new DevExpress.XtraEditors.LabelControl();
            this.lblchkdate = new DevExpress.XtraEditors.LabelControl();
            this.lblCompnay = new DevExpress.XtraEditors.LabelControl();
            this.lblEmpType = new DevExpress.XtraEditors.LabelControl();
            this.lblDPT = new DevExpress.XtraEditors.LabelControl();
            this.lblDOJ = new DevExpress.XtraEditors.LabelControl();
            this.lblAdarNo = new DevExpress.XtraEditors.LabelControl();
            this.lblgender = new DevExpress.XtraEditors.LabelControl();
            this.lblDob = new DevExpress.XtraEditors.LabelControl();
            this.lblEmpName = new DevExpress.XtraEditors.LabelControl();
            this.lblEmpCode = new DevExpress.XtraEditors.LabelControl();
            this.lblSrNo = new DevExpress.XtraEditors.LabelControl();
            this.GrpDGV = new DevExpress.XtraEditors.GroupControl();
            this.DGVDetails = new DevExpress.XtraGrid.GridControl();
            this.DGVGridview = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SrNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EmpCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EmpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DOBDetails = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GenderGND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AadharNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DOJ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DepartmentDPT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EmpType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CompanyCPS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ChckDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HealthStatusEmp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RemarkEmp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReportEmp = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.OHCPanel)).BeginInit();
            this.OHCPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GRPOHCDetails)).BeginInit();
            this.GRPOHCDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEmp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrpDGV)).BeginInit();
            this.GrpDGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVGridview)).BeginInit();
            this.SuspendLayout();
            // 
            // OHCPanel
            // 
            this.OHCPanel.Controls.Add(this.btnBack);
            this.OHCPanel.Controls.Add(this.OHClbl);
            this.OHCPanel.Controls.Add(this.btnUpload);
            this.OHCPanel.Controls.Add(this.btnExportData);
            this.OHCPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.OHCPanel.Location = new System.Drawing.Point(0, 0);
            this.OHCPanel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.OHCPanel.Name = "OHCPanel";
            this.OHCPanel.Size = new System.Drawing.Size(2040, 106);
            this.OHCPanel.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.btnBack.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBack.Appearance.Options.UseBackColor = true;
            this.btnBack.Appearance.Options.UseFont = true;
            this.btnBack.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnBack.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBack.ImageOptions.SvgImage")));
            this.btnBack.Location = new System.Drawing.Point(45, 24);
            this.btnBack.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.btnBack.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnBack.Size = new System.Drawing.Size(82, 69);
            this.btnBack.TabIndex = 20;
            this.btnBack.Visible = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // OHClbl
            // 
            this.OHClbl.Cursor = System.Windows.Forms.Cursors.Default;
            this.OHClbl.Depth = 0;
            this.OHClbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OHClbl.ForeColor = System.Drawing.Color.RoyalBlue;
            this.OHClbl.Location = new System.Drawing.Point(834, 34);
            this.OHClbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.OHClbl.MouseState = SparrowRMSControl.SparrowControl.MouseState.HOVER;
            this.OHClbl.Name = "OHClbl";
            this.OHClbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.OHClbl.Size = new System.Drawing.Size(501, 46);
            this.OHClbl.TabIndex = 2;
            this.OHClbl.Text = "Occupational Health and Safety";
            // 
            // btnUpload
            // 
            this.btnUpload.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.btnUpload.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUpload.Appearance.Options.UseBackColor = true;
            this.btnUpload.Appearance.Options.UseFont = true;
            this.btnUpload.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnUpload.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnUpload.ImageOptions.SvgImage")));
            this.btnUpload.Location = new System.Drawing.Point(1738, 24);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(82, 69);
            this.btnUpload.TabIndex = 4;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnExportData
            // 
            this.btnExportData.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.btnExportData.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExportData.Appearance.Options.UseBackColor = true;
            this.btnExportData.Appearance.Options.UseFont = true;
            this.btnExportData.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnExportData.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnExportData.ImageOptions.SvgImage")));
            this.btnExportData.Location = new System.Drawing.Point(1848, 24);
            this.btnExportData.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnExportData.Name = "btnExportData";
            this.btnExportData.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnExportData.Size = new System.Drawing.Size(82, 69);
            this.btnExportData.TabIndex = 5;
            this.btnExportData.Click += new System.EventHandler(this.btnExportData_Click);
            // 
            // GRPOHCDetails
            // 
            this.GRPOHCDetails.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.GRPOHCDetails.Appearance.Options.UseFont = true;
            this.GRPOHCDetails.AppearanceCaption.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.GRPOHCDetails.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.GRPOHCDetails.AppearanceCaption.Options.UseBorderColor = true;
            this.GRPOHCDetails.AppearanceCaption.Options.UseFont = true;
            this.GRPOHCDetails.CaptionImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("GRPOHCDetails.CaptionImageOptions.SvgImage")));
            this.GRPOHCDetails.Controls.Add(this.txtEmployeeCode);
            this.GRPOHCDetails.Controls.Add(this.txtCompnay);
            this.GRPOHCDetails.Controls.Add(this.btnDelete);
            this.GRPOHCDetails.Controls.Add(this.btnUpdate);
            this.GRPOHCDetails.Controls.Add(this.btnAdd);
            this.GRPOHCDetails.Controls.Add(this.btnuploadImage);
            this.GRPOHCDetails.Controls.Add(this.btnUploadRPT);
            this.GRPOHCDetails.Controls.Add(this.pictureEmp);
            this.GRPOHCDetails.Controls.Add(this.lblupload);
            this.GRPOHCDetails.Controls.Add(this.dropdownHealth);
            this.GRPOHCDetails.Controls.Add(this.dropdownEMPType);
            this.GRPOHCDetails.Controls.Add(this.dropdownDPT);
            this.GRPOHCDetails.Controls.Add(this.datetimeDOJ);
            this.GRPOHCDetails.Controls.Add(this.dropdownGender);
            this.GRPOHCDetails.Controls.Add(this.datetimeCheckDate);
            this.GRPOHCDetails.Controls.Add(this.DatePickerDOB);
            this.GRPOHCDetails.Controls.Add(this.txtRemark);
            this.GRPOHCDetails.Controls.Add(this.txtAaDharNo);
            this.GRPOHCDetails.Controls.Add(this.txtEmpName);
            this.GRPOHCDetails.Controls.Add(this.txtsrno);
            this.GRPOHCDetails.Controls.Add(this.lblReport);
            this.GRPOHCDetails.Controls.Add(this.lblRemark);
            this.GRPOHCDetails.Controls.Add(this.lblHealthChk);
            this.GRPOHCDetails.Controls.Add(this.lblchkdate);
            this.GRPOHCDetails.Controls.Add(this.lblCompnay);
            this.GRPOHCDetails.Controls.Add(this.lblEmpType);
            this.GRPOHCDetails.Controls.Add(this.lblDPT);
            this.GRPOHCDetails.Controls.Add(this.lblDOJ);
            this.GRPOHCDetails.Controls.Add(this.lblAdarNo);
            this.GRPOHCDetails.Controls.Add(this.lblgender);
            this.GRPOHCDetails.Controls.Add(this.lblDob);
            this.GRPOHCDetails.Controls.Add(this.lblEmpName);
            this.GRPOHCDetails.Controls.Add(this.lblEmpCode);
            this.GRPOHCDetails.Controls.Add(this.lblSrNo);
            this.GRPOHCDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.GRPOHCDetails.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.GRPOHCDetails.Location = new System.Drawing.Point(0, 106);
            this.GRPOHCDetails.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.GRPOHCDetails.Name = "GRPOHCDetails";
            this.GRPOHCDetails.Size = new System.Drawing.Size(2040, 630);
            this.GRPOHCDetails.TabIndex = 1;
            this.GRPOHCDetails.Text = "Employee Health Check-UP Entry";
            // 
            // txtEmployeeCode
            // 
            this.txtEmployeeCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmployeeCode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtEmployeeCode.BackgroundImage")));
            this.txtEmployeeCode.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtEmployeeCode.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtEmployeeCode.BorderRadius = 1;
            this.txtEmployeeCode.BorderSize = 1;
            this.txtEmployeeCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmployeeCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtEmployeeCode.Location = new System.Drawing.Point(280, 162);
            this.txtEmployeeCode.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtEmployeeCode.MinimumSize = new System.Drawing.Size(2, 2);
            this.txtEmployeeCode.Multiline = true;
            this.txtEmployeeCode.Name = "txtEmployeeCode";
            this.txtEmployeeCode.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtEmployeeCode.PasswordChar = false;
            this.txtEmployeeCode.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtEmployeeCode.PlaceholderText = "Employee Code";
            this.txtEmployeeCode.Size = new System.Drawing.Size(325, 56);
            this.txtEmployeeCode.TabIndex = 1;
            this.txtEmployeeCode.UnderlinedStyle = false;
            this.txtEmployeeCode.Leave += new System.EventHandler(this.txtEmployeeCode_Leave);
            // 
            // txtCompnay
            // 
            this.txtCompnay.BackColor = System.Drawing.SystemColors.Window;
            this.txtCompnay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtCompnay.BackgroundImage")));
            this.txtCompnay.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtCompnay.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtCompnay.BorderRadius = 1;
            this.txtCompnay.BorderSize = 1;
            this.txtCompnay.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCompnay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompnay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCompnay.Location = new System.Drawing.Point(950, 242);
            this.txtCompnay.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtCompnay.MinimumSize = new System.Drawing.Size(2, 2);
            this.txtCompnay.Multiline = true;
            this.txtCompnay.Name = "txtCompnay";
            this.txtCompnay.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtCompnay.PasswordChar = false;
            this.txtCompnay.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtCompnay.PlaceholderText = "Company Name";
            this.txtCompnay.Size = new System.Drawing.Size(325, 56);
            this.txtCompnay.TabIndex = 29;
            this.txtCompnay.UnderlinedStyle = false;
            this.txtCompnay.Leave += new System.EventHandler(this.txtCompnay_Leave);
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDelete.Appearance.Options.UseBackColor = true;
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.ImageOptions.Image = global::HindalcoiOS.Properties.Resources.DeleteAll;
            this.btnDelete.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnDelete.Location = new System.Drawing.Point(1896, 550);
            this.btnDelete.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.btnDelete.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnDelete.Size = new System.Drawing.Size(118, 66);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.btnUpdate.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUpdate.Appearance.Options.UseBackColor = true;
            this.btnUpdate.Appearance.Options.UseFont = true;
            this.btnUpdate.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnUpdate.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnUpdate.ImageOptions.SvgImage")));
            this.btnUpdate.Location = new System.Drawing.Point(1763, 550);
            this.btnUpdate.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnUpdate.Size = new System.Drawing.Size(101, 66);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd.Appearance.Options.UseBackColor = true;
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnAdd.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAdd.ImageOptions.SvgImage")));
            this.btnAdd.Location = new System.Drawing.Point(1650, 550);
            this.btnAdd.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.btnAdd.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnAdd.Size = new System.Drawing.Size(115, 66);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnuploadImage
            // 
            this.btnuploadImage.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.btnuploadImage.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnuploadImage.Appearance.Options.UseBackColor = true;
            this.btnuploadImage.Appearance.Options.UseFont = true;
            this.btnuploadImage.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnuploadImage.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnuploadImage.ImageOptions.SvgImage")));
            this.btnuploadImage.Location = new System.Drawing.Point(1482, 550);
            this.btnuploadImage.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.btnuploadImage.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnuploadImage.Name = "btnuploadImage";
            this.btnuploadImage.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnuploadImage.Size = new System.Drawing.Size(115, 66);
            this.btnuploadImage.TabIndex = 2;
            this.btnuploadImage.Text = "Pic";
            this.btnuploadImage.Click += new System.EventHandler(this.btnuploadImage_Click);
            // 
            // btnUploadRPT
            // 
            this.btnUploadRPT.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.btnUploadRPT.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUploadRPT.Appearance.Options.UseBackColor = true;
            this.btnUploadRPT.Appearance.Options.UseFont = true;
            this.btnUploadRPT.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnUploadRPT.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnUploadRPT.ImageOptions.SvgImage")));
            this.btnUploadRPT.Location = new System.Drawing.Point(1306, 550);
            this.btnUploadRPT.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.btnUploadRPT.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnUploadRPT.Name = "btnUploadRPT";
            this.btnUploadRPT.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnUploadRPT.Size = new System.Drawing.Size(152, 64);
            this.btnUploadRPT.TabIndex = 1;
            this.btnUploadRPT.Text = "Report";
            this.btnUploadRPT.Click += new System.EventHandler(this.btnUploadRPT_Click);
            // 
            // pictureEmp
            // 
            this.pictureEmp.Location = new System.Drawing.Point(1306, 88);
            this.pictureEmp.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pictureEmp.Name = "pictureEmp";
            this.pictureEmp.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEmp.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEmp.Size = new System.Drawing.Size(710, 427);
            this.pictureEmp.TabIndex = 0;
            // 
            // lblupload
            // 
            this.lblupload.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.lblupload.Appearance.Options.UseFont = true;
            this.lblupload.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblupload.Location = new System.Drawing.Point(950, 539);
            this.lblupload.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lblupload.Name = "lblupload";
            this.lblupload.Size = new System.Drawing.Size(306, 40);
            this.lblupload.TabIndex = 33;
            this.lblupload.Text = "...................................................";
            this.lblupload.Click += new System.EventHandler(this.lblupload_Click);
            // 
            // dropdownHealth
            // 
            this.dropdownHealth.BorderColor = System.Drawing.Color.Silver;
            this.dropdownHealth.BorderSize = 0;
            this.dropdownHealth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dropdownHealth.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropdownHealth.ForeColor = System.Drawing.Color.Black;
            this.dropdownHealth.FormattingEnabled = true;
            this.dropdownHealth.IconColor = System.Drawing.Color.DodgerBlue;
            this.dropdownHealth.ListBackColor = System.Drawing.Color.Red;
            this.dropdownHealth.ListTextColor = System.Drawing.Color.White;
            this.dropdownHealth.Location = new System.Drawing.Point(950, 387);
            this.dropdownHealth.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dropdownHealth.Name = "dropdownHealth";
            this.dropdownHealth.Size = new System.Drawing.Size(322, 48);
            this.dropdownHealth.TabIndex = 31;
            this.dropdownHealth.SelectedIndexChanged += new System.EventHandler(this.dropdownHealth_SelectedIndexChanged);
            // 
            // dropdownEMPType
            // 
            this.dropdownEMPType.BorderColor = System.Drawing.Color.Silver;
            this.dropdownEMPType.BorderSize = 0;
            this.dropdownEMPType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dropdownEMPType.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropdownEMPType.ForeColor = System.Drawing.Color.Black;
            this.dropdownEMPType.FormattingEnabled = true;
            this.dropdownEMPType.IconColor = System.Drawing.Color.DodgerBlue;
            this.dropdownEMPType.ListBackColor = System.Drawing.Color.Red;
            this.dropdownEMPType.ListTextColor = System.Drawing.Color.White;
            this.dropdownEMPType.Location = new System.Drawing.Point(950, 165);
            this.dropdownEMPType.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dropdownEMPType.Name = "dropdownEMPType";
            this.dropdownEMPType.Size = new System.Drawing.Size(322, 45);
            this.dropdownEMPType.TabIndex = 28;
            this.dropdownEMPType.SelectedValueChanged += new System.EventHandler(this.dropdownEMPType_SelectedIndexChanged);
            // 
            // dropdownDPT
            // 
            this.dropdownDPT.BorderColor = System.Drawing.Color.Silver;
            this.dropdownDPT.BorderSize = 0;
            this.dropdownDPT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dropdownDPT.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropdownDPT.ForeColor = System.Drawing.Color.Black;
            this.dropdownDPT.FormattingEnabled = true;
            this.dropdownDPT.IconColor = System.Drawing.Color.DodgerBlue;
            this.dropdownDPT.ListBackColor = System.Drawing.Color.Red;
            this.dropdownDPT.ListTextColor = System.Drawing.Color.White;
            this.dropdownDPT.Location = new System.Drawing.Point(950, 88);
            this.dropdownDPT.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dropdownDPT.Name = "dropdownDPT";
            this.dropdownDPT.Size = new System.Drawing.Size(322, 45);
            this.dropdownDPT.TabIndex = 27;
            this.dropdownDPT.SelectedValueChanged += new System.EventHandler(this.dropdownDPT_SelectedIndexChanged);
            // 
            // datetimeDOJ
            // 
            this.datetimeDOJ.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.datetimeDOJ.BorderSize = 0;
            this.datetimeDOJ.CustomFormat = "dd-MM-yyyy";
            this.datetimeDOJ.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.datetimeDOJ.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.datetimeDOJ.ForeColor = System.Drawing.Color.Black;
            this.datetimeDOJ.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetimeDOJ.Location = new System.Drawing.Point(280, 533);
            this.datetimeDOJ.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.datetimeDOJ.MinDate = new System.DateTime(1999, 12, 1, 0, 0, 0, 0);
            this.datetimeDOJ.MinimumSize = new System.Drawing.Size(4, 32);
            this.datetimeDOJ.Name = "datetimeDOJ";
            this.datetimeDOJ.Size = new System.Drawing.Size(322, 39);
            this.datetimeDOJ.SkinColor = System.Drawing.Color.MediumSlateBlue;
            this.datetimeDOJ.TabIndex = 26;
            this.datetimeDOJ.TextColor = System.Drawing.Color.White;
            this.datetimeDOJ.Value = new System.DateTime(2021, 11, 12, 15, 6, 22, 0);
            this.datetimeDOJ.ValueChanged += new System.EventHandler(this.datetimeDOJ_ValueChanged);
            // 
            // dropdownGender
            // 
            this.dropdownGender.BorderColor = System.Drawing.Color.Silver;
            this.dropdownGender.BorderSize = 0;
            this.dropdownGender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dropdownGender.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropdownGender.ForeColor = System.Drawing.Color.Black;
            this.dropdownGender.FormattingEnabled = true;
            this.dropdownGender.IconColor = System.Drawing.Color.DodgerBlue;
            this.dropdownGender.ListBackColor = System.Drawing.Color.Red;
            this.dropdownGender.ListTextColor = System.Drawing.Color.White;
            this.dropdownGender.Location = new System.Drawing.Point(280, 387);
            this.dropdownGender.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dropdownGender.Name = "dropdownGender";
            this.dropdownGender.Size = new System.Drawing.Size(322, 45);
            this.dropdownGender.TabIndex = 24;
            this.dropdownGender.SelectedIndexChanged += new System.EventHandler(this.dropdownGender_SelectedIndexChanged);
            // 
            // datetimeCheckDate
            // 
            this.datetimeCheckDate.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.datetimeCheckDate.BorderSize = 0;
            this.datetimeCheckDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.datetimeCheckDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.datetimeCheckDate.ForeColor = System.Drawing.Color.Black;
            this.datetimeCheckDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetimeCheckDate.Location = new System.Drawing.Point(950, 318);
            this.datetimeCheckDate.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.datetimeCheckDate.MinDate = new System.DateTime(1999, 1, 1, 0, 0, 0, 0);
            this.datetimeCheckDate.MinimumSize = new System.Drawing.Size(4, 32);
            this.datetimeCheckDate.Name = "datetimeCheckDate";
            this.datetimeCheckDate.Size = new System.Drawing.Size(322, 39);
            this.datetimeCheckDate.SkinColor = System.Drawing.Color.MediumSlateBlue;
            this.datetimeCheckDate.TabIndex = 30;
            this.datetimeCheckDate.TextColor = System.Drawing.Color.White;
            this.datetimeCheckDate.Value = new System.DateTime(2021, 11, 12, 15, 6, 22, 0);
            this.datetimeCheckDate.ValueChanged += new System.EventHandler(this.datetimeCheckDate_ValueChanged);
            // 
            // DatePickerDOB
            // 
            this.DatePickerDOB.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.DatePickerDOB.BorderSize = 0;
            this.DatePickerDOB.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DatePickerDOB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DatePickerDOB.ForeColor = System.Drawing.Color.Black;
            this.DatePickerDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DatePickerDOB.Location = new System.Drawing.Point(280, 318);
            this.DatePickerDOB.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.DatePickerDOB.MinDate = new System.DateTime(1919, 1, 1, 0, 0, 0, 0);
            this.DatePickerDOB.MinimumSize = new System.Drawing.Size(4, 32);
            this.DatePickerDOB.Name = "DatePickerDOB";
            this.DatePickerDOB.Size = new System.Drawing.Size(322, 39);
            this.DatePickerDOB.SkinColor = System.Drawing.Color.MediumSlateBlue;
            this.DatePickerDOB.TabIndex = 23;
            this.DatePickerDOB.TextColor = System.Drawing.Color.White;
            this.DatePickerDOB.Value = new System.DateTime(2021, 11, 12, 15, 6, 22, 0);
            this.DatePickerDOB.ValueChanged += new System.EventHandler(this.DatePickerDOB_ValueChanged);
            // 
            // txtRemark
            // 
            this.txtRemark.BackColor = System.Drawing.SystemColors.Window;
            this.txtRemark.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtRemark.BackgroundImage")));
            this.txtRemark.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtRemark.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtRemark.BorderRadius = 1;
            this.txtRemark.BorderSize = 1;
            this.txtRemark.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtRemark.Location = new System.Drawing.Point(950, 456);
            this.txtRemark.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtRemark.MinimumSize = new System.Drawing.Size(2, 2);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtRemark.PasswordChar = false;
            this.txtRemark.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtRemark.PlaceholderText = "";
            this.txtRemark.Size = new System.Drawing.Size(326, 56);
            this.txtRemark.TabIndex = 34;
            this.txtRemark.UnderlinedStyle = false;
            this.txtRemark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemark_KeyPress);
            this.txtRemark.Leave += new System.EventHandler(this.txtRemark_Leave);
            // 
            // txtAaDharNo
            // 
            this.txtAaDharNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtAaDharNo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtAaDharNo.BackgroundImage")));
            this.txtAaDharNo.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtAaDharNo.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtAaDharNo.BorderRadius = 1;
            this.txtAaDharNo.BorderSize = 1;
            this.txtAaDharNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAaDharNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAaDharNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAaDharNo.Location = new System.Drawing.Point(280, 456);
            this.txtAaDharNo.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtAaDharNo.MinimumSize = new System.Drawing.Size(2, 2);
            this.txtAaDharNo.Multiline = false;
            this.txtAaDharNo.Name = "txtAaDharNo";
            this.txtAaDharNo.Padding = new System.Windows.Forms.Padding(16, 11, 16, 11);
            this.txtAaDharNo.PasswordChar = false;
            this.txtAaDharNo.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtAaDharNo.PlaceholderText = "";
            this.txtAaDharNo.Size = new System.Drawing.Size(325, 53);
            this.txtAaDharNo.TabIndex = 35;
            this.txtAaDharNo.UnderlinedStyle = false;
            this.txtAaDharNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAaDharNo_KeyPress);
            this.txtAaDharNo.Leave += new System.EventHandler(this.txtAaDharNo_Leave);
            // 
            // txtEmpName
            // 
            this.txtEmpName.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmpName.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtEmpName.BackgroundImage")));
            this.txtEmpName.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtEmpName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtEmpName.BorderRadius = 1;
            this.txtEmpName.BorderSize = 1;
            this.txtEmpName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmpName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtEmpName.Location = new System.Drawing.Point(280, 242);
            this.txtEmpName.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtEmpName.MinimumSize = new System.Drawing.Size(2, 2);
            this.txtEmpName.Multiline = true;
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtEmpName.PasswordChar = false;
            this.txtEmpName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtEmpName.PlaceholderText = "Employee Name";
            this.txtEmpName.Size = new System.Drawing.Size(325, 56);
            this.txtEmpName.TabIndex = 22;
            this.txtEmpName.UnderlinedStyle = false;
            this.txtEmpName.Leave += new System.EventHandler(this.txtEmpName_Leave);
            // 
            // txtsrno
            // 
            this.txtsrno.BackColor = System.Drawing.SystemColors.Window;
            this.txtsrno.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtsrno.BackgroundImage")));
            this.txtsrno.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtsrno.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(143)))));
            this.txtsrno.BorderRadius = 1;
            this.txtsrno.BorderSize = 1;
            this.txtsrno.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtsrno.Enabled = false;
            this.txtsrno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsrno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtsrno.Location = new System.Drawing.Point(280, 88);
            this.txtsrno.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtsrno.MinimumSize = new System.Drawing.Size(2, 2);
            this.txtsrno.Multiline = true;
            this.txtsrno.Name = "txtsrno";
            this.txtsrno.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtsrno.PasswordChar = false;
            this.txtsrno.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtsrno.PlaceholderText = "Employee S.No.";
            this.txtsrno.Size = new System.Drawing.Size(325, 56);
            this.txtsrno.TabIndex = 20;
            this.txtsrno.UnderlinedStyle = false;
            // 
            // lblReport
            // 
            this.lblReport.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.lblReport.Appearance.Options.UseFont = true;
            this.lblReport.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblReport.Location = new System.Drawing.Point(690, 539);
            this.lblReport.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(187, 40);
            this.lblReport.TabIndex = 18;
            this.lblReport.Text = "Report Upload";
            // 
            // lblRemark
            // 
            this.lblRemark.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.lblRemark.Appearance.Options.UseFont = true;
            this.lblRemark.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblRemark.Location = new System.Drawing.Point(690, 466);
            this.lblRemark.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(108, 40);
            this.lblRemark.TabIndex = 17;
            this.lblRemark.Text = "Remarks";
            // 
            // lblHealthChk
            // 
            this.lblHealthChk.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.lblHealthChk.Appearance.Options.UseFont = true;
            this.lblHealthChk.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblHealthChk.Location = new System.Drawing.Point(690, 392);
            this.lblHealthChk.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lblHealthChk.Name = "lblHealthChk";
            this.lblHealthChk.Size = new System.Drawing.Size(170, 40);
            this.lblHealthChk.TabIndex = 16;
            this.lblHealthChk.Text = "Health Status";
            // 
            // lblchkdate
            // 
            this.lblchkdate.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.lblchkdate.Appearance.Options.UseFont = true;
            this.lblchkdate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblchkdate.Location = new System.Drawing.Point(690, 318);
            this.lblchkdate.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lblchkdate.Name = "lblchkdate";
            this.lblchkdate.Size = new System.Drawing.Size(193, 40);
            this.lblchkdate.TabIndex = 15;
            this.lblchkdate.Text = "Check-Up Date";
            // 
            // lblCompnay
            // 
            this.lblCompnay.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.lblCompnay.Appearance.Options.UseFont = true;
            this.lblCompnay.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblCompnay.Location = new System.Drawing.Point(690, 245);
            this.lblCompnay.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lblCompnay.Name = "lblCompnay";
            this.lblCompnay.Size = new System.Drawing.Size(122, 40);
            this.lblCompnay.TabIndex = 14;
            this.lblCompnay.Text = "Company";
            // 
            // lblEmpType
            // 
            this.lblEmpType.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.lblEmpType.Appearance.Options.UseFont = true;
            this.lblEmpType.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblEmpType.Location = new System.Drawing.Point(690, 171);
            this.lblEmpType.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lblEmpType.Name = "lblEmpType";
            this.lblEmpType.Size = new System.Drawing.Size(230, 40);
            this.lblEmpType.TabIndex = 13;
            this.lblEmpType.Text = "Employment Type";
            // 
            // lblDPT
            // 
            this.lblDPT.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.lblDPT.Appearance.Options.UseFont = true;
            this.lblDPT.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblDPT.Location = new System.Drawing.Point(690, 98);
            this.lblDPT.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lblDPT.Name = "lblDPT";
            this.lblDPT.Size = new System.Drawing.Size(153, 40);
            this.lblDPT.TabIndex = 12;
            this.lblDPT.Text = "Department";
            // 
            // lblDOJ
            // 
            this.lblDOJ.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.lblDOJ.Appearance.Options.UseFont = true;
            this.lblDOJ.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblDOJ.Location = new System.Drawing.Point(35, 539);
            this.lblDOJ.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lblDOJ.Name = "lblDOJ";
            this.lblDOJ.Size = new System.Drawing.Size(197, 40);
            this.lblDOJ.TabIndex = 11;
            this.lblDOJ.Text = "Date Of Joining";
            // 
            // lblAdarNo
            // 
            this.lblAdarNo.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.lblAdarNo.Appearance.Options.UseFont = true;
            this.lblAdarNo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblAdarNo.Location = new System.Drawing.Point(35, 466);
            this.lblAdarNo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lblAdarNo.Name = "lblAdarNo";
            this.lblAdarNo.Size = new System.Drawing.Size(205, 40);
            this.lblAdarNo.TabIndex = 10;
            this.lblAdarNo.Text = "Aadhar Number";
            // 
            // lblgender
            // 
            this.lblgender.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.lblgender.Appearance.Options.UseFont = true;
            this.lblgender.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblgender.Location = new System.Drawing.Point(35, 392);
            this.lblgender.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lblgender.Name = "lblgender";
            this.lblgender.Size = new System.Drawing.Size(93, 40);
            this.lblgender.TabIndex = 9;
            this.lblgender.Text = "Gender";
            // 
            // lblDob
            // 
            this.lblDob.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.lblDob.Appearance.Options.UseFont = true;
            this.lblDob.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblDob.Location = new System.Drawing.Point(35, 318);
            this.lblDob.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lblDob.Name = "lblDob";
            this.lblDob.Size = new System.Drawing.Size(59, 40);
            this.lblDob.TabIndex = 8;
            this.lblDob.Text = "DOB";
            // 
            // lblEmpName
            // 
            this.lblEmpName.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.lblEmpName.Appearance.Options.UseFont = true;
            this.lblEmpName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblEmpName.Location = new System.Drawing.Point(35, 245);
            this.lblEmpName.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(210, 40);
            this.lblEmpName.TabIndex = 7;
            this.lblEmpName.Text = "Employee Name";
            // 
            // lblEmpCode
            // 
            this.lblEmpCode.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.lblEmpCode.Appearance.Options.UseFont = true;
            this.lblEmpCode.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblEmpCode.Location = new System.Drawing.Point(35, 171);
            this.lblEmpCode.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lblEmpCode.Name = "lblEmpCode";
            this.lblEmpCode.Size = new System.Drawing.Size(200, 40);
            this.lblEmpCode.TabIndex = 6;
            this.lblEmpCode.Text = "Employee Code";
            // 
            // lblSrNo
            // 
            this.lblSrNo.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.lblSrNo.Appearance.Options.UseFont = true;
            this.lblSrNo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblSrNo.Location = new System.Drawing.Point(35, 98);
            this.lblSrNo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lblSrNo.Name = "lblSrNo";
            this.lblSrNo.Size = new System.Drawing.Size(74, 40);
            this.lblSrNo.TabIndex = 5;
            this.lblSrNo.Text = "S. No.";
            // 
            // GrpDGV
            // 
            this.GrpDGV.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.GrpDGV.AppearanceCaption.Options.UseFont = true;
            this.GrpDGV.CaptionImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("GrpDGV.CaptionImageOptions.SvgImage")));
            this.GrpDGV.Controls.Add(this.DGVDetails);
            this.GrpDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpDGV.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.GrpDGV.Location = new System.Drawing.Point(0, 736);
            this.GrpDGV.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.GrpDGV.Name = "GrpDGV";
            this.GrpDGV.Size = new System.Drawing.Size(2040, 333);
            this.GrpDGV.TabIndex = 2;
            this.GrpDGV.Text = "Employee Details";
            // 
            // DGVDetails
            // 
            this.DGVDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVDetails.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.DGVDetails.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.DGVDetails.Location = new System.Drawing.Point(3, 65);
            this.DGVDetails.MainView = this.DGVGridview;
            this.DGVDetails.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.DGVDetails.Name = "DGVDetails";
            this.DGVDetails.Size = new System.Drawing.Size(2034, 265);
            this.DGVDetails.TabIndex = 0;
            this.DGVDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.DGVGridview});
            // 
            // DGVGridview
            // 
            this.DGVGridview.Appearance.EvenRow.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.DGVGridview.Appearance.EvenRow.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.DGVGridview.Appearance.EvenRow.Options.UseFont = true;
            this.DGVGridview.Appearance.EvenRow.Options.UseForeColor = true;
            this.DGVGridview.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.DarkGray;
            this.DGVGridview.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.DGVGridview.Appearance.OddRow.ForeColor = System.Drawing.Color.Gray;
            this.DGVGridview.Appearance.OddRow.Options.UseForeColor = true;
            this.DGVGridview.Appearance.SelectedRow.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Question;
            this.DGVGridview.Appearance.SelectedRow.Options.UseForeColor = true;
            this.DGVGridview.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.DGVGridview.AppearancePrint.EvenRow.Options.UseFont = true;
            this.DGVGridview.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.DGVGridview.AppearancePrint.FilterPanel.Options.UseFont = true;
            this.DGVGridview.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SrNo,
            this.EmpCode,
            this.EmpName,
            this.DOBDetails,
            this.GenderGND,
            this.AadharNo,
            this.DOJ,
            this.DepartmentDPT,
            this.EmpType,
            this.CompanyCPS,
            this.ChckDate,
            this.HealthStatusEmp,
            this.RemarkEmp,
            this.ReportEmp});
            this.DGVGridview.DetailHeight = 560;
            this.DGVGridview.GridControl = this.DGVDetails;
            this.DGVGridview.Name = "DGVGridview";
            this.DGVGridview.OptionsBehavior.Editable = false;
            this.DGVGridview.OptionsBehavior.ReadOnly = true;
            this.DGVGridview.OptionsPrint.EnableAppearanceEvenRow = true;
            this.DGVGridview.OptionsPrint.EnableAppearanceOddRow = true;
            this.DGVGridview.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // SrNo
            // 
            this.SrNo.Caption = "S.No.";
            this.SrNo.MinWidth = 40;
            this.SrNo.Name = "SrNo";
            this.SrNo.Visible = true;
            this.SrNo.VisibleIndex = 0;
            this.SrNo.Width = 150;
            // 
            // EmpCode
            // 
            this.EmpCode.Caption = "Employee Code";
            this.EmpCode.MinWidth = 40;
            this.EmpCode.Name = "EmpCode";
            this.EmpCode.Visible = true;
            this.EmpCode.VisibleIndex = 1;
            this.EmpCode.Width = 150;
            // 
            // EmpName
            // 
            this.EmpName.Caption = "Employee Name";
            this.EmpName.MinWidth = 40;
            this.EmpName.Name = "EmpName";
            this.EmpName.Visible = true;
            this.EmpName.VisibleIndex = 2;
            this.EmpName.Width = 150;
            // 
            // DOBDetails
            // 
            this.DOBDetails.Caption = "DOB";
            this.DOBDetails.MinWidth = 40;
            this.DOBDetails.Name = "DOBDetails";
            this.DOBDetails.Visible = true;
            this.DOBDetails.VisibleIndex = 3;
            this.DOBDetails.Width = 150;
            // 
            // GenderGND
            // 
            this.GenderGND.Caption = "Gender";
            this.GenderGND.MinWidth = 40;
            this.GenderGND.Name = "GenderGND";
            this.GenderGND.Visible = true;
            this.GenderGND.VisibleIndex = 4;
            this.GenderGND.Width = 150;
            // 
            // AadharNo
            // 
            this.AadharNo.Caption = "Aadhar Number";
            this.AadharNo.MinWidth = 40;
            this.AadharNo.Name = "AadharNo";
            this.AadharNo.Visible = true;
            this.AadharNo.VisibleIndex = 5;
            this.AadharNo.Width = 150;
            // 
            // DOJ
            // 
            this.DOJ.Caption = "Date Of Joining";
            this.DOJ.MinWidth = 40;
            this.DOJ.Name = "DOJ";
            this.DOJ.Visible = true;
            this.DOJ.VisibleIndex = 6;
            this.DOJ.Width = 150;
            // 
            // DepartmentDPT
            // 
            this.DepartmentDPT.Caption = "Department";
            this.DepartmentDPT.MinWidth = 40;
            this.DepartmentDPT.Name = "DepartmentDPT";
            this.DepartmentDPT.Visible = true;
            this.DepartmentDPT.VisibleIndex = 7;
            this.DepartmentDPT.Width = 150;
            // 
            // EmpType
            // 
            this.EmpType.Caption = "Employee Type";
            this.EmpType.MinWidth = 40;
            this.EmpType.Name = "EmpType";
            this.EmpType.Visible = true;
            this.EmpType.VisibleIndex = 8;
            this.EmpType.Width = 150;
            // 
            // CompanyCPS
            // 
            this.CompanyCPS.Caption = "Company";
            this.CompanyCPS.MinWidth = 40;
            this.CompanyCPS.Name = "CompanyCPS";
            this.CompanyCPS.Visible = true;
            this.CompanyCPS.VisibleIndex = 9;
            this.CompanyCPS.Width = 150;
            // 
            // ChckDate
            // 
            this.ChckDate.Caption = "Check Up Date";
            this.ChckDate.MinWidth = 40;
            this.ChckDate.Name = "ChckDate";
            this.ChckDate.Visible = true;
            this.ChckDate.VisibleIndex = 10;
            this.ChckDate.Width = 150;
            // 
            // HealthStatusEmp
            // 
            this.HealthStatusEmp.Caption = "Health Status";
            this.HealthStatusEmp.MinWidth = 40;
            this.HealthStatusEmp.Name = "HealthStatusEmp";
            this.HealthStatusEmp.Visible = true;
            this.HealthStatusEmp.VisibleIndex = 11;
            this.HealthStatusEmp.Width = 150;
            // 
            // RemarkEmp
            // 
            this.RemarkEmp.Caption = "Remarks";
            this.RemarkEmp.MinWidth = 40;
            this.RemarkEmp.Name = "RemarkEmp";
            this.RemarkEmp.Visible = true;
            this.RemarkEmp.VisibleIndex = 12;
            this.RemarkEmp.Width = 150;
            // 
            // ReportEmp
            // 
            this.ReportEmp.Caption = "Report";
            this.ReportEmp.MinWidth = 40;
            this.ReportEmp.Name = "ReportEmp";
            this.ReportEmp.Visible = true;
            this.ReportEmp.VisibleIndex = 13;
            this.ReportEmp.Width = 150;
            // 
            // OHCFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(2040, 1069);
            this.Controls.Add(this.GrpDGV);
            this.Controls.Add(this.GRPOHCDetails);
            this.Controls.Add(this.OHCPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OHCFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OHCFrm_FormClosed);
            this.Load += new System.EventHandler(this.OHCFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OHCPanel)).EndInit();
            this.OHCPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GRPOHCDetails)).EndInit();
            this.GRPOHCDetails.ResumeLayout(false);
            this.GRPOHCDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEmp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrpDGV)).EndInit();
            this.GrpDGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVGridview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl OHCPanel;
        public SparrowRMSControl.SparrowControl.SparrowLabel OHClbl;
        private DevExpress.XtraEditors.GroupControl GRPOHCDetails;
        private DevExpress.XtraEditors.SimpleButton btnExportData;
        private DevExpress.XtraEditors.SimpleButton btnUpload;
        private DevExpress.XtraEditors.LabelControl lblSrNo;
        private DevExpress.XtraEditors.LabelControl lblEmpCode;
        private DevExpress.XtraEditors.LabelControl lblEmpName;
        private DevExpress.XtraEditors.LabelControl lblDob;
        public DevExpress.XtraEditors.LabelControl lblgender;
        private DevExpress.XtraEditors.LabelControl lblAdarNo;
        public DevExpress.XtraEditors.LabelControl lblDOJ;
        public DevExpress.XtraEditors.LabelControl lblDPT;
        public DevExpress.XtraEditors.LabelControl lblEmpType;
        public DevExpress.XtraEditors.LabelControl lblCompnay;
        public DevExpress.XtraEditors.LabelControl lblchkdate;
        public DevExpress.XtraEditors.LabelControl lblHealthChk;
        public DevExpress.XtraEditors.LabelControl lblRemark;
        public DevExpress.XtraEditors.LabelControl lblReport;
        public SparrowRMSControl.SparrowControl.SparrowTextBox txtsrno;
        public SparrowRMSControl.SparrowControl.SparrowTextBox txtEmpName;
        public SparrowRMSControl.SparrowControl.SparrowTextBox txtAaDharNo;
        public SparrowRMSControl.SparrowControl.SparrowTextBox txtRemark;
        public SparrowRMSControl.SparrowControl.SparrowDatePicker datetimeCheckDate;
        public SparrowRMSControl.SparrowControl.SparrowDatePicker DatePickerDOB;
        public SparrowRMSControl.SparrowControl.SparrowComboBox dropdownGender;
        public SparrowRMSControl.SparrowControl.SparrowDatePicker datetimeDOJ;
        public SparrowRMSControl.SparrowControl.SparrowComboBox dropdownDPT;
        public SparrowRMSControl.SparrowControl.SparrowComboBox dropdownEMPType;
        public SparrowRMSControl.SparrowControl.SparrowComboBox dropdownHealth;
        public DevExpress.XtraEditors.LabelControl lblupload;
        public DevExpress.XtraEditors.PictureEdit pictureEmp;
        public DevExpress.XtraEditors.SimpleButton btnUploadRPT;
        public DevExpress.XtraEditors.SimpleButton btnuploadImage;
        public DevExpress.XtraEditors.SimpleButton btnAdd;
        public DevExpress.XtraEditors.SimpleButton btnUpdate;
        public DevExpress.XtraEditors.SimpleButton btnDelete;
        public DevExpress.XtraEditors.GroupControl GrpDGV;
        public SparrowRMSControl.SparrowControl.SparrowTextBox txtCompnay;
        private DevExpress.XtraGrid.GridControl DGVDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView DGVGridview;
        private DevExpress.XtraGrid.Columns.GridColumn SrNo;
        private DevExpress.XtraGrid.Columns.GridColumn EmpCode;
        private DevExpress.XtraGrid.Columns.GridColumn EmpName;
        private DevExpress.XtraGrid.Columns.GridColumn DOBDetails;
        private DevExpress.XtraGrid.Columns.GridColumn GenderGND;
        private DevExpress.XtraGrid.Columns.GridColumn AadharNo;
        private DevExpress.XtraGrid.Columns.GridColumn DOJ;
        private DevExpress.XtraGrid.Columns.GridColumn DepartmentDPT;
        private DevExpress.XtraGrid.Columns.GridColumn EmpType;
        private DevExpress.XtraGrid.Columns.GridColumn CompanyCPS;
        private DevExpress.XtraGrid.Columns.GridColumn ChckDate;
        private DevExpress.XtraGrid.Columns.GridColumn HealthStatusEmp;
        private DevExpress.XtraGrid.Columns.GridColumn RemarkEmp;
        private DevExpress.XtraGrid.Columns.GridColumn ReportEmp;
        public DevExpress.XtraEditors.SimpleButton btnBack;
        public SparrowRMSControl.SparrowControl.SparrowTextBox txtEmployeeCode;
    }
}