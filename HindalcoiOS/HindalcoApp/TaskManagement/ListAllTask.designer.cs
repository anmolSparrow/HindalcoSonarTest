
namespace HindalcoiOS
{
    partial class ListAllTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListAllTask));
            this.DgvViewTaskList = new DevExpress.XtraGrid.GridControl();
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
            this.toastNotificationsManager1 = new DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DgvViewTaskList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVGridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toastNotificationsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvViewTaskList
            // 
            this.DgvViewTaskList.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5);
            this.DgvViewTaskList.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.DgvViewTaskList.Location = new System.Drawing.Point(11, 18);
            this.DgvViewTaskList.MainView = this.DGVGridview;
            this.DgvViewTaskList.Margin = new System.Windows.Forms.Padding(5);
            this.DgvViewTaskList.Name = "DgvViewTaskList";
            this.DgvViewTaskList.Size = new System.Drawing.Size(1719, 920);
            this.DgvViewTaskList.TabIndex = 11;
            this.DgvViewTaskList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.DGVGridview});
            this.DgvViewTaskList.DoubleClick += new System.EventHandler(this.DgvViewTaskList_DoubleClick);
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
            this.DGVGridview.GridControl = this.DgvViewTaskList;
            this.DGVGridview.Name = "DGVGridview";
            this.DGVGridview.OptionsBehavior.Editable = false;
            this.DGVGridview.OptionsBehavior.ReadOnly = true;
            this.DGVGridview.OptionsPrint.EnableAppearanceEvenRow = true;
            this.DGVGridview.OptionsPrint.EnableAppearanceOddRow = true;
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
            // toastNotificationsManager1
            // 
            this.toastNotificationsManager1.ApplicationId = "8281db08-6ba4-406b-abda-e326b98f7d42";
            this.toastNotificationsManager1.Notifications.AddRange(new DevExpress.XtraBars.ToastNotifications.IToastNotificationProperties[] {
            new DevExpress.XtraBars.ToastNotifications.ToastNotification("2966d717-2d6e-42c7-984c-7e9697bf0314", ((System.Drawing.Image)(resources.GetObject("toastNotificationsManager1.Notifications"))), null, ((System.Drawing.Image)(resources.GetObject("toastNotificationsManager1.Notifications1"))), null, ((System.Drawing.Image)(resources.GetObject("toastNotificationsManager1.Notifications2"))), null, "New Task Notification", "New task added", "Please take a look", null, DevExpress.XtraBars.ToastNotifications.ToastNotificationSound.Reminder, DevExpress.XtraBars.ToastNotifications.ToastNotificationDuration.Default, null, DevExpress.XtraBars.ToastNotifications.AppLogoCrop.Default, DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.Generic)});
            // 
            // ListAllTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1744, 948);
            this.Controls.Add(this.DgvViewTaskList);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("ListAllTask.IconOptions.Image")));
            this.MaximizeBox = false;
            this.Name = "ListAllTask";
            this.Text = "ListAllTask";
            this.Load += new System.EventHandler(this.ListAllTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvViewTaskList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVGridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toastNotificationsManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl DgvViewTaskList;
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
        private DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager toastNotificationsManager1;
    }
}