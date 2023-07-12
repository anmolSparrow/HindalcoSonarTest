using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using HindalcoiOS.DAL;
using HindalcoiOS.Models;
using SparrowRMS;
//using HindalcoiOS.Class_Operation;
//using SparrowRMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HindalcoiOS.Reporting
{
    public partial class FrmGenericReporting : XtraForm
    {

        #region Properties & Collections

        public EventHandler<string> updateIncidentTbl;
        public EventHandler<string> CADMachineList;

        public IncidentReport IncReport { get; set; }
        public ServiceDAL DalService { get; set; }
        public string EmpCode { get; set; }
        private bool is_EmpAdmin { get; set; }
        public bool isTabChanged { get; set; }
        private string adminCode { get; set; }
        private CADImport.CADImage cadImage;
        public bool isPageReloaded { get; set; }
        private bool isAllValidated { get; set; }
        private int empRoleId { get; set; }
        private int RoleId { get; set; }
        public bool isViewClk { get; set; }
        private bool isPageValidated { get; set; }

        private string isSelfAssigned { get; set; }
        private string isAdminAssigned { get; set; }
        private string ObservedBy { get; set; }

        public string ReportNoVal = string.Empty;
        public bool isEmpGM = false;
        public string DocumentStatus { get; set; }
        ErrorProvider eps = null;
        public Reporting.EmployeeType emplType { get; set; }
        #endregion
        public FrmGenericReporting()
        {
            InitializeComponent();
            IncReport = new IncidentReport();
            DalService = new ServiceDAL();
            eps = new ErrorProvider();
            //IncReport.LoadAllUsers = GlobalDeclaration.GetAllUsers();

        }

        #region "variable Declaration"              
        string eventReportingDate;
        int eventreportingId;
        DataTable dtSafety = new DataTable();
        DataTable dtAreaMaster = null;
        string[] emparr = new string[] { };
        string[] emplarr = new string[] { };
        List<string> TypeArr = new List<string>();
        List<string> ShiftArr = new List<string>();
        string imgPAth = string.Empty;
        DataTable DeptDt = null;
        DataTable IncidentDetails = null;
        DataTable IncidentPreFill = null;
        DataTable UserMaster = null;
        DataTable empType = null;
        string loginid;
        string ReportGm = string.Empty;
        string ReportNo = string.Empty;
        public static string machineTag = string.Empty;
        public static int eventRptId = 0;
        int obtNo = 1001;
        public static string areaName = string.Empty;
        public static string observation = string.Empty;
        public static string criticality = string.Empty;

        #endregion

        #region "Property"

        public bool isRedirect { get; set; }
        public enum ReportToGM
        {
            Yes,
            No
        }
        public enum IncidentStatus
        {
            Prepare = 0,
            Submitted = 1,
            Closed = 2,
            Rejected = 3
        }

        List<string> MessasgeAP = new List<string>();
        #endregion

        #region Method Zone

        private void AddMessage()
        {
            try
            {
                MessasgeAP.Add("Record Saved Successfully");
                MessasgeAP.Add("Record Updated Successfully");
                MessasgeAP.Add("Submitted for Approval");
                MessasgeAP.Add("Approved & Closed");
                MessasgeAP.Add("Oops something went Wrong!.");
                MessasgeAP.Add("Submitted & closed");
                MessasgeAP.Add("Please upload an Image!.");
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetAdminCode()
        {
            try
            {
                adminCode = Resources.Instance.GetAdminEmployeeCode_RMPCL();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ObjectToClassMapper()
        {
            try
            {
                DeptDt = Resources.Instance.GetDepartmentDetailsDataTable(1);
                int DeptId = 0;
                DataRow[] result = DeptDt.Select("Dept_Name='" + txtDepart.Text + "'");
                // Display.
                foreach (DataRow row in result)
                {
                    DeptId = Convert.ToInt32(row[0]);
                }
                IncReport.CorrectiveAction = this.txtCorrectAction.Text;
                IncReport.Description = this.txtDescription.Text;
                IncReport.DepartmentId = DeptId;
                IncReport.EmployeeType = this.cmbEmpType.Text;
                IncReport.ExactLocation = this.txtexLocation.Text;
                IncReport.IncidentDate = Convert.ToDateTime(this.dtpIncidentDate.Value);
                IncReport.IncidentImage = GetByteFromImage(PictIncImg.Image);// imgPAth;

                IncReport.IncidentLocation = this.cmbLocation.Text;
                IncReport.ExactLocation = this.txtexLocation.Text;
                if (btnInciSave.Text == "Save")
                    IncReport.IncidentStatus = IncidentStatus.Prepare.ToString();

                if (btnInciSave.Text == "Submit")
                {
                    cmbStatus.Text= IncidentStatus.Submitted.ToString();
                    IncReport.IncidentStatus = IncidentStatus.Submitted.ToString();
                }

                IncReport.IncidentTime = Convert.ToDateTime(this.dtpIncidentDate.Value);
                IncReport.Hours = this.cmbFromHours.Text;
                IncReport.Minuts = this.cmbFromMinuts.Text;
                IncReport.IncidentType = this.cmbIncidentType.Text;
                IncReport.MachineTag = this.cmbmachineTag.Text;
                IncReport.ObservedBy = GlobalDeclaration._holdInfo[0].EmpCode;// Class_Operation.GlobalDeclaration._holdInfo[0].EmpCode;
                IncReport.OperationUnit = this.cmbOptUnit.Text;
                IncReport.PersonAge = this.txtAge.Text;
                IncReport.PersonInjured = this.txtInjuredPerson.Text;// this.txtReprtedBy.Text;
                IncReport.ReportedBy = this.txtReprtedBy.Text;// this.txtReprtedBy.Text;
                IncReport.DocumentedBy = this.txtDocBy.Text;
                IncReport.ReportDate = Convert.ToDateTime(this.dtpReportDate.Value);
                IncReport.ReportNo = this.txtReportNo.Text;
                IncReport.ReportTime = Convert.ToDateTime(this.dtpReportDate.Value);
                IncReport.Shift = this.cmbShift.Text;
                if (ReportGm == "Yes")
                {
                    IncReport.is_localSaved = "Yes";
                    IncReport.is_Assigned = "Yes";
                    IncReport.AssignedToGM = adminCode;
                    if (IncReport.IncidentStatus == "Closed")
                    {
                        IncReport.ClosureDate = DateTime.Now;
                    }
                }
                else
                {
                    IncReport.is_localSaved = "Yes";
                    IncReport.is_Assigned = "No";
                    IncReport.AssignedToGM = adminCode;
                    if (IncReport.IncidentStatus == "Closed")
                    {
                        IncReport.ClosureDate = DateTime.Now;
                    }
                }
                AddMessage();
                if (btnInciSave.Text == "Save" || btnInciSave.Text == "Submit")
                {
                    int m = DalService.AddIncidentReport(IncReport, 1);
                    if (m > 0)
                    {
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, MessasgeAP[0], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (btnInciSave.Text == "Update")
                {
                    int m = DalService.AddIncidentReport(IncReport, 2);
                    if (m > 0)
                    {
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, MessasgeAP[1], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void GetEmployeType1()
        {
            try
            {
                empType = new DataTable();
                empType = Resources.Instance.GetEmployeeType_RMPCL(1, "", 0);
                cmbRptEmpType.DataSource = empType;
                cmbRptEmpType.DisplayMember = "EmpType";
                cmbRptEmpType.ValueMember = "EmpType";
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void GetEmployeType()
        {
            try
            {
                empType = new DataTable();
                empType = Resources.Instance.GetEmployeeType_RMPCL(1, "", 0);

                foreach (DataRow item in empType.Rows)
                {
                    cmbEmpType.Items.Add(item["EmpType"].ToString());
                    cmbRptEmpType.Items.Add(item["EmpType"].ToString());
                }
                ////cmbEmpType.DataSource = empType;
                ////cmbRptEmpType.DataSource = empType;
                ////cmbEmpType.DisplayMember = "EmpType";
                ////cmbEmpType.ValueMember = "EmpType";
                ////cmbRptEmpType.DisplayMember = "EmpType";
                ////cmbRptEmpType.ValueMember = "EmpType";
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddComboValues()
        {
            try
            {
                GetEmployeType();
                //GetEmployeType1();
                cmbStatus.DataSource = Enum.GetValues(typeof(IncidentStatus));
                cmbRptStat.DataSource = Enum.GetValues(typeof(IncidentStatus));
                cmbStatus.Text = IncidentStatus.Prepare.ToString();
                //cmbOptUnit.SelectedValue = OperationUnit.RMPCL;
                ShiftArr.Add("Shift A");
                ShiftArr.Add("Shift B");
                ShiftArr.Add("Shift C");
                ShiftArr.Add("General Shift");

                //TypeArr.Add("N/A");
                TypeArr.Add("First Aid");
                TypeArr.Add("Medical Treatment");
                TypeArr.Add("Lost Time Injury");
                TypeArr.Add("Property Damage");
                TypeArr.Add("Environmental Injury");
                TypeArr.Add("Dangerous Occurance");

                cmbShift.Items.Clear();
                cmbShift.Items.Add("");
                cmbShift.DataSource = ShiftArr;
                cmbIncidentType.DataSource = TypeArr;
                dtAreaMaster = new DataTable();
                dtAreaMaster = Resources.Instance.GetMachineAreaMaster();
                cmbLocation.Items.Clear();
                //cmbLocation.Items.Add("N/A");
                for (int m = 0; m < dtAreaMaster.Rows.Count; m++)
                {
                    cmbLocation.Items.Add(dtAreaMaster.Rows[m][0].ToString());
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DisableNonAdminControls()
        {
            btnInciClose.Enabled = false;
            //btnSubmit.Enabled = false;
            btnInciSave.Enabled = false;
            btnInciReset.Enabled = false;
        }
        private void HideContols()
        {
            lblCorrectiveAction.Visible = false;
            txtCorrectAction.Visible = false;
            //btnInciClose.Visible = true;
            //btnInciClose.Enabled = false;
            //btnSubmit.Enabled = false;
            //btnSubmit.Visible = true;
            btnInciSave.Visible = true;
            btnInciSave.Enabled = true;
            // btnSaveClose.Text = "Update";
        }
        private void HideContolsUpdate()
        {
            lblCorrectiveAction.Visible = false;
            txtCorrectAction.Visible = false;
            btnInciClose.Visible = false;
            //btnSubmit.Visible = false;
            btnInciSave.Visible = true;
            btnInciReset.Enabled = false;
            //btnSaveClose.Enabled = true;

        }
        private void UnhideControls()
        {
            lblCorrectiveAction.Visible = true;
            txtCorrectAction.Visible = true;
            btnInciClose.Visible = false;
            //btnSubmit.Visible = false;
        }
        private void GenerateReportLabels()
        {
            try
            {
                string RptNo = string.Empty;
                string[] appArr = new string[] { };
                string observNo = Resources.Instance.GetIncidentReportNo_RMPCL("SP_GetIncidentReportNo").ToString();
                if (!string.IsNullOrEmpty(observNo.ToString()))
                {
                    if (observNo != "0")
                    {
                        appArr = observNo.ToString().Split('/');
                        observNo = Convert.ToString(Convert.ToInt32(appArr[2]) + 1);
                    }
                    else
                    {
                        observNo = "1001";
                    }
                    RptNo = "INC" + "/" + DateTime.Now.Year + "/" + observNo;
                    txtReportNo.Text = RptNo;
                }
                else
                {
                    RptNo = "INC" + "/" + DateTime.Now.Year + "/" + 1001;
                    txtReportNo.Text = RptNo;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DisableLoadButton()
        {
            btnApproval.Visible = false;
            if (cmbStatus.Text == IncidentStatus.Prepare.ToString())
            {
                if (Properties.Settings.Default.RoleID != 7)
                {
                    btnInciSave.Enabled = true;
                    btnInciSave.Visible = true;
                    btnBrowse.Visible = true;
                    //btnInciClose.Enabled = false;
                    btnInciClose.Visible = false;
                    btnInciReject.Visible = false;
                    //btnSubmit.Enabled = false;
                    btnInciReset.Visible = false;
                    lblAdminRemarks.Visible = false;
                    txtAdminRemarks.Visible = false;
                    txtDepart.Enabled = false;
                    chkReadyToSubmit.Enabled = true;
                    chkReadyToSubmit.Visible = true;
                    chkReadyToSubmit.Checked = false;
                }
              else  
                {
                    btnApproval.Visible = true;
                    BtnNewReport.Visible = false;
                }
            }
            if (cmbStatus.Text == IncidentStatus.Submitted.ToString())
            {
                if (Properties.Settings.Default.RoleID != 7)
                {
                    btnInciSave.Visible = false;
                    //btnInciClose.Enabled = false;
                    btnInciClose.Visible = false;
                    //btnSubmit.Enabled = false;
                    btnInciReset.Visible = false;
                    btnBrowse.Visible = false;
                    
                    chkReadyToSubmit.Visible = false;
                    lblAdminRemarks.Visible = false;
                    txtAdminRemarks.Visible = false;
                    
                }
                else
                {
                    btnApproval.Visible = true;
                    btnInciSave.Visible = false;
                    //btnInciClose.Enabled = false;
                    btnInciClose.Visible = true;
                    btnInciClose.Enabled = true;
                    btnInciReject.Visible = true;
                    //btnSubmit.Enabled = false;
                    btnInciReset.Visible = false;
                    btnBrowse.Visible = false;
                    chkReadyToSubmit.Visible = false;
                    lblAdminRemarks.Visible = true;
                    txtAdminRemarks.Visible = true;
                    //txtAdminRemarks.Enabled = true;
                }
            }
                if (cmbStatus.Text == IncidentStatus.Closed.ToString())
                {
                if (Properties.Settings.Default.RoleID != 7)
                {
                    btnInciSave.Visible = false;
                    btnInciClose.Visible = false;
                    btnInciReject.Visible = false;
                    btnInciReset.Visible = false;
                    btnBrowse.Visible = false;
                    chkReadyToSubmit.Visible = false;

                    lblAdminRemarks.Visible = true;
                    txtAdminRemarks.Visible = true;
                    lblAdminRemarks.Enabled = false;
                    txtAdminRemarks.Enabled = false;
                }
                else
                {
                    btnInciSave.Visible = false;
                    btnInciClose.Visible = false;
                    btnInciReject.Visible = false;
                    btnInciReset.Visible = false;
                    btnBrowse.Visible = false;
                    chkReadyToSubmit.Visible = false;
                    btnApproval.Visible = true;
                    lblAdminRemarks.Visible = true;
                    txtAdminRemarks.Visible = true;
                    lblAdminRemarks.Enabled = false;
                    txtAdminRemarks.Enabled = false;
                }
                    //btnSubmit.Enabled = false;
                }
            if (cmbStatus.Text == IncidentStatus.Rejected.ToString())
            {
                if (Properties.Settings.Default.RoleID != 7)
                {
                    btnInciSave.Enabled = false;// true;
                    btnInciSave.Visible = false;// true;
                    btnBrowse.Visible = true;
                    //btnInciClose.Enabled = false;
                    btnInciClose.Visible = false;
                    btnInciReject.Visible = false;
                    //btnSubmit.Enabled = false;
                    btnInciReset.Visible = false;

                    lblAdminRemarks.Visible = true;
                    txtAdminRemarks.Visible = true;
                    txtAdminRemarks.Enabled = false;
                    chkReadyToSubmit.Enabled = true;
                    chkReadyToSubmit.Visible = true;
                    chkReadyToSubmit.Checked = false;
                }
                else
                {
                    btnApproval.Visible = true;
                    btnInciClose.Visible = false;
                    btnInciReject.Visible = false;
                }
            }

        }
        private void EnableLoadButton()
        {
            if (cmbStatus.Text == IncidentStatus.Prepare.ToString())
            {
                btnInciSave.Enabled = true;
                //btnInciClose.Enabled = false;
                btnInciClose.Visible = false;
                btnInciReject.Visible = false;
                //btnSubmit.Enabled = false;
                btnInciReset.Visible = false;

                lblAdminRemarks.Visible = false;
                txtAdminRemarks.Visible = false;
            }
            if (cmbStatus.Text == IncidentStatus.Submitted.ToString())
            {
                btnInciSave.Visible = false;
                //btnInciClose.Enabled = false;
                btnInciClose.Visible = false;
                //btnSubmit.Enabled = false;
                btnInciReset.Visible = false;
                btnBrowse.Visible = false;
                chkReadyToSubmit.Visible = false;
                lblAdminRemarks.Visible = false;
                txtAdminRemarks.Visible = false;
            }
        }
        private void NonAdminControls()
        {
            btnInciSave.Enabled = false;
            btnInciClose.Enabled = false;
            //btnSubmit.Enabled = true;
            //btnSubmit.Visible = true;
            btnInciReset.Enabled = true;
        }
        private void AdminControls()
        {

            btnInciSave.Enabled = false;
            btnInciClose.Enabled = false;
            //btnSubmit.Enabled = false;
            //btnSubmit.Visible = false;
            btnInciReset.Enabled = false;
        }
        private void CloseControls()
        {
            btnInciSave.Enabled = false;
            btnInciClose.Enabled = true;
            if (isSelfAssigned == "Yes" || HindalcoiOS.Properties.Settings.Default.RoleID == 7)
            {
                btnInciClose.Visible = true;
                btnInciReject.Visible = true;
                btnInciReject.Enabled = true;
            }
            else if (isAdminAssigned == GlobalDeclaration._holdInfo[0].EmpCode)
            {
                btnInciClose.Visible = true;
            }
            else if (isSelfAssigned == "No" && isAdminAssigned == "" && ObservedBy == GlobalDeclaration._holdInfo[0].UserName)
            {
                btnInciClose.Visible = true;

            }
            else
            {
                btnInciClose.Visible = false;
                btnInciReject.Enabled = false;
            }
            //btnSubmit.Enabled = false;
            //btnInciReset.Enabled = true;
        }
        private void DisableControls()
        {
            btnInciSave.Enabled = false;
            btnInciClose.Enabled = false;
            //btnSubmit.Enabled = false;
            btnInciReset.Enabled = true;
            btnInciClose.Visible = true;
            //btnSubmit.Visible = true;
        }
        private void OnRejectedState()
        {
            btnInciSave.Enabled = false;
            btnInciClose.Enabled = false;
            //btnSubmit.Enabled = true;
            btnInciReset.Enabled = true;
            // btnSubmit.Visible = true;
            //btnSubmit.Visible = true;
        }
        private void LoadEvent()
        {
            try
            {
                ////txtReprtedBy.Text = GlobalDeclaration._holdInfo[0].UserName; 24/03/23
                txtDocBy.Text = GlobalDeclaration._holdInfo[0].UserName;
                txtDepart.Text = GlobalDeclaration._holdInfo[0].DepartmentName;
                cmbmachineTag.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbmachineTag.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbStatus.Text = IncidentStatus.Prepare.ToString();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadCADMachines()
        {
            GlobalDeclaration.genRpt.CADMachineList += GetCADMachineList;
        }

        private void GetCADMachineList(object sender, string value)
        {
            try
            {
                int countm = GlobalDeclaration._MyTagDictinary.Count;
                foreach (var item in GlobalDeclaration._MyTagDictinary)
                {
                    cmbmachineTag.Items.Add(item.Value);
                }
                ////int countm = GlobalDeclaration._ActiveMachines.Count;
                ////foreach (var item in GlobalDeclaration._ActiveMachines)
                ////{
                ////    cmbmachineTag.Items.Add(item.Key);
                ////}
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BindClassObject(DataTable dta)
        {
            try
            {
                IncReport.ReportNo = dta.Rows[0]["ReportNo"].ToString();
                IncReport.ReportDate = Convert.ToDateTime(dta.Rows[0]["ReportDate"].ToString());
                IncReport.ReportTime = Convert.ToDateTime(dta.Rows[0]["ReportTime"].ToString());
                IncReport.EmployeeType = dta.Rows[0]["EmployeeType"].ToString();
                IncReport.Shift = dta.Rows[0]["Shift"].ToString();
                IncReport.IncidentType = dta.Rows[0]["IncidentType"].ToString();
                IncReport.IncidentDate = Convert.ToDateTime(dta.Rows[0]["IncidentDate"].ToString());
                IncReport.Hours = dta.Rows[0]["IncHours"].ToString();
                IncReport.Minuts =dta.Rows[0]["IncMinuts"].ToString();
                IncReport.IncidentTime = Convert.ToDateTime(dta.Rows[0]["IncidentDate"].ToString());
                IncReport.IncidentLocation = dta.Rows[0]["IncidentLocation"].ToString();
                IncReport.ExactLocation = dta.Rows[0]["ExactLocation"].ToString();
                IncReport.Description = dta.Rows[0]["Description"].ToString();
                IncReport.CorrectiveAction = dta.Rows[0]["CorrectiveAction"].ToString();
                IncReport.ObservedBy = dta.Rows[0]["ObservedBy"].ToString();
                IncReport.DocumentedBy = dta.Rows[0]["DocumentedBy"].ToString();
                IncReport.ReportedBy = dta.Rows[0]["ReportedBy"].ToString();
                IncReport.PersonInjured = dta.Rows[0]["PersonInjured"].ToString();
                IncReport.DepartmentId = Convert.ToInt32(dta.Rows[0]["DepartmentId"]);
                IncReport.PersonAge = dta.Rows[0]["PersonAge"].ToString();
                IncReport.MachineTag = dta.Rows[0]["MachineTag"].ToString();
                IncReport.IncidentImage = (byte[])dta.Rows[0]["IncidentImage"];
                IncReport.IncidentStatus = dta.Rows[0]["IncidentStatus"].ToString();
                IncReport.OperationUnit = dta.Rows[0]["OperationUnit"].ToString();
                IncReport.AdminRemarks = dta.Rows[0]["AdminRemarks"].ToString();
                BindClassControls(IncReport);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindClassObjectOld(DataTable dta)
        {
            try
            {
                IncReport.ReportNo = dta.Rows[0][0].ToString();
                IncReport.ReportDate = Convert.ToDateTime(dta.Rows[0][3].ToString());
                IncReport.ReportTime = Convert.ToDateTime(dta.Rows[0][3].ToString());
                IncReport.EmployeeType = dta.Rows[0][4].ToString();
                IncReport.Shift = dta.Rows[0][5].ToString();
                IncReport.IncidentType = dta.Rows[0][6].ToString();
                IncReport.IncidentDate = Convert.ToDateTime(dta.Rows[0][8].ToString());
                IncReport.IncidentTime = Convert.ToDateTime(dta.Rows[0][8].ToString());
                IncReport.IncidentLocation = dta.Rows[0][9].ToString();
                IncReport.ExactLocation = dta.Rows[0][10].ToString();
                IncReport.Description = dta.Rows[0][11].ToString();
                IncReport.CorrectiveAction = dta.Rows[0][12].ToString();
                IncReport.ObservedBy = dta.Rows[0][13].ToString();
                IncReport.PersonInjured = dta.Rows[0][14].ToString();
                IncReport.DepartmentId = Convert.ToInt32(dta.Rows[0][15]);
                IncReport.PersonAge = dta.Rows[0][16].ToString();
                IncReport.MachineTag = dta.Rows[0][17].ToString();
                IncReport.IncidentImage = (byte[])dta.Rows[0]["IncidentImage"];
                IncReport.IncidentStatus = dta.Rows[0][19].ToString();
                IncReport.OperationUnit = dta.Rows[0][20].ToString();
                IncReport.AdminRemarks = dta.Rows[0][25].ToString();
                BindClassControls(IncReport);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReportedIncidentHandler(object sender, string value)
        {
            try
            {
                string ss= Properties.Settings.Default.UserName;
                IncidentDetails = Resources.Instance.GetIncidentReport_RMPCL(GlobalDeclaration._holdInfo[0].EmpCode, "Prepare", 2);
                DBIncidentView.DataSource = IncidentDetails;
                if(empRoleId==7)
                txtAdminRemarks.Text = string.Format("Closed by {0} on {1} Comments: {2}", GlobalDeclaration._holdInfo[0].UserName, DateTime.Now.ToString(), value);
                //cmbStatus.Text = IncidentStatus.Closed.ToString();
                //btnSubmit.Enabled = false;
                //DBIncidentView.Columns["Remarks"].Visible = false;
                // DBIncidentView.Columns["ReportNo"].Visible = false;
            }

            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RejectedReportedIncidentHandler(object sender, string value)
        {
            try
            {
                string ss = Properties.Settings.Default.UserName;
                IncidentDetails = Resources.Instance.GetIncidentReport_RMPCL(GlobalDeclaration._holdInfo[0].EmpCode, "Prepare", 2);
                DBIncidentView.DataSource = IncidentDetails;
                if (empRoleId == 7)
                    txtAdminRemarks.Text = string.Format("Rejected by {0} on {1} Comments: {2}", GlobalDeclaration._holdInfo[0].UserName, DateTime.Now.ToString(), value);
                //cmbStatus.Text = IncidentStatus.Closed.ToString();
                //btnSubmit.Enabled = false;
                //DBIncidentView.Columns["Remarks"].Visible = false;
                // DBIncidentView.Columns["ReportNo"].Visible = false;
            }

            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BindClassControls(IncidentReport IncReport)
        {
            try
            {
                //lblReportNo1.Text = IncReport.ReportNo;
                txtReportNo.Text = IncReport.ReportNo;
                dtpReportDate.Text = IncReport.ReportDate.ToString();
                cmbEmpType.Text = IncReport.EmployeeType;
                cmbShift.Text = IncReport.Shift;
                cmbIncidentType.Text = IncReport.IncidentType;
                dtpIncidentDate.Text = IncReport.IncidentDate.ToString();
                cmbFromHours.Text = IncReport.Hours.ToString();
                cmbFromMinuts.Text = IncReport.Minuts.ToString();
                cmbLocation.Items.Add(IncReport.IncidentLocation);
                cmbLocation.Text = IncReport.IncidentLocation;
                txtexLocation.Text = IncReport.ExactLocation;
                txtDescription.Text = IncReport.Description;
                txtCorrectAction.Text = IncReport.CorrectiveAction;
                txtReprtedBy.Text = IncReport.ReportedBy;// IncReport.PersonInjured;
                txtDocBy.Text = IncReport.DocumentedBy;
                txtInjuredPerson.Text = IncReport.PersonInjured;
                txtAdminRemarks.Text = IncReport.AdminRemarks;

                DeptDt = Resources.Instance.GetDepartmentDetailsDataTable(1);
                int DeptId = 0;
                DataRow[] result = DeptDt.Select("DeptId='" + IncReport.DepartmentId + "'");
                // Display.
                foreach (DataRow row in result)
                {
                    IncReport.DepartmentId = Convert.ToInt32(row[0]);
                    txtDepart.Text = row[1].ToString();
                }
                txtAge.Text = IncReport.PersonAge;
                cmbmachineTag.Text = IncReport.MachineTag;
                //imgPAth = IncReport.IncidentImage;
                //PictIncImg.Load((IncReport.IncidentImage);

                //imgPAth = IncReport.IncidentImage;
                PictIncImg.Image = GetImage(IncReport.IncidentImage);


                if (IncReport.IncidentStatus.ToString() == IncidentStatus.Prepare.ToString())
                {
                    cmbStatus.Text = IncidentStatus.Prepare.ToString();
                }
                else if (IncReport.IncidentStatus.ToString() == IncidentStatus.Submitted.ToString())
                {
                    cmbStatus.Text = IncidentStatus.Submitted.ToString();
                }
                else if ((IncReport.IncidentStatus.ToString() == IncidentStatus.Rejected.ToString()))
                {
                    cmbStatus.Text = IncidentStatus.Rejected.ToString();
                }
                else
                {
                    cmbStatus.Text = IncidentStatus.Closed.ToString();
                }
                cmbOptUnit.Text = IncReport.OperationUnit;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void browseImageFile()
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    InitialDirectory = @"C:\",
                    Title = "Browse",
                    CheckFileExists = true,
                    CheckPathExists = true,
                    Filter = "Images(*.Jpeg;*.png;*.jpg;)|*.Jpeg;*.png;*.jpg;",
                    ReadOnlyChecked = false,
                };
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    PictIncImg.Image = new Bitmap(openFileDialog1.FileName);
                    string fname = Path.GetFileName(openFileDialog1.FileName);
                    imgPAth = openFileDialog1.FileName;
                    if (string.IsNullOrEmpty(imgPAth)) return;
                    string AppPath = Application.StartupPath + "\\" + "IncidentImages";
                    ////if (!Directory.Exists(AppPath))
                    ////{
                    ////    Directory.CreateDirectory(AppPath);
                    ////}
                    imgPAth = openFileDialog1.FileName;
                    //string ext = Path.GetExtension(openFileDialog1.FileName);
                    //string fExt = fname + '.' + ext;
                    //if (!File.Exists(AppPath + "\\" + fExt))
                    //{
                    //    File.Copy(imgPAth, AppPath + "\\" + fExt);
                    //}
                    //else
                    //{
                    //    XtraMessageBox.Show("File already exist", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    PictIncImg.Image = null;
                    //}
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(cmbEmpType.Text))
            {
                lblempT.Visible = true;
                lblempT.Text = "*";
                isPageValidated = false;
                XtraMessageBox.Show("Please Select Employee Type");
                return false;
            }
            else
            {
                lblempT.Visible = false;
                isPageValidated = true;
            }
          if (string.IsNullOrEmpty(cmbIncidentType.Text))
            {
                lblincL.Visible = true;
                lblincL.Text = "*";
                isPageValidated = false;
                XtraMessageBox.Show("Please Select Incident Type");
                return false;
            }
            else
            {
                lblincL.Visible = false;
                isPageValidated = true;
            }
            if (string.IsNullOrEmpty(cmbLocation.Text))
            {
                lblincL.Visible = true;
                lblincL.Text = "*";
                isPageValidated = false;
                XtraMessageBox.Show("Please Select Location");
                return false;
            }
            else
            {
                lblincL.Visible = false;
                isPageValidated = true;
            }

            if (string.IsNullOrEmpty(cmbOptUnit.Text))
            {
                //cmbOptUnit.Focus();
                lblopT.Visible = true;
                lblopT.Text = "*";
                isPageValidated = false;
                XtraMessageBox.Show("Please Select OperationUnit");
                return false;
            }
            else
            {
                lblopT.Visible = false;
                isPageValidated = true;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                lbldecT.Visible = true;
                lbldecT.Text = "*";
                isPageValidated = false;
                XtraMessageBox.Show("Please Fill Description");
                return false;
            }
            else
            {
                lbldecT.Visible = false;
                isPageValidated = true;
            }

            if (PictIncImg.Image == null)
            {
                lblimgT.Visible = true;
                lblimgT.Text = "*";
                isPageValidated = false;
                XtraMessageBox.Show("Please Upload Image");
                return false;
            }
            else
            {
                lblimgT.Visible = false;
                isPageValidated = true;
            }
            if(cmbIncidentType.Text!="Medical Treatment" && cmbIncidentType.Text != "Lost Time Injury" && string.IsNullOrEmpty(txtCorrectAction.Text))
            {
                isPageValidated = false;
                XtraMessageBox.Show("Please Fill Corrective & Preventive Action");
                return false;
            }
            else
            {
                isPageValidated = true;
            }

            ////isPageValidated = false;
            if (PictIncImg.Image != null && txtDescription.Text != null && cmbOptUnit.SelectedIndex != 0 && cmbLocation.SelectedIndex != 0 && cmbIncidentType.SelectedIndex != 0 && cmbEmpType.SelectedIndex != 0)
            {
                isPageValidated = true;
            }
            return isPageValidated;
        }
        private void ResetOnPrepare()
        {
            cmbEmpType.Text = "";
            cmbIncidentType.SelectedIndex = 0;
            cmbLocation.SelectedIndex = 0;
            cmbOptUnit.SelectedIndex = 0;
            cmbShift.SelectedIndex = 0;
            txtAge.Text = "";
            txtDescription.Text = "";
            txtexLocation.Text = "";
            cmbmachineTag.Text = "";
            cmbEmpType.SelectedIndex = 0;
            PictIncImg.Image = null;
            //btnSaveClose.Enabled = false;
            //btnSubmit.Enabled = false;
            //btnSubmitClose.Enabled = true;
        }

        private void UnhideButtonControl()
        {
            btnInciClose.Visible = true;
            //btnSubmit.Visible = true;
        }
        private void UnhideButtonControl(string Rptstatus)
        {
            if (Rptstatus == IncidentStatus.Prepare.ToString())
            {

            }
            btnInciClose.Visible = true;
            //btnSubmit.Visible = true;
        }
        private void FreezeAllControls()
        {
            try
            {
                txtReportNo.Enabled = false;
                txtAge.Enabled = false;
                txtCorrectAction.Enabled = false;
                txtDepart.Enabled = false;
                txtDescription.Enabled = false;
                txtexLocation.Enabled = false;
                cmbmachineTag.Enabled = false;
                txtReprtedBy.Enabled = false;
                txtInjuredPerson.Enabled = false;
                cmbEmpType.Enabled = false;
                cmbIncidentType.Enabled = false;
                cmbLocation.Enabled = false;
                cmbOptUnit.Enabled = false;
                cmbShift.Enabled = false;
                cmbStatus.Enabled = false;
                dtpIncidentDate.Enabled = false;
                cmbFromHours.Enabled = false;
                cmbFromMinuts.Enabled = false;
                dtpReportDate.Enabled = false;
                btnBrowse.Enabled = false;
                txtAdminRemarks.Enabled = false;
                if (Properties.Settings.Default.RoleID == 7)
                {
                    lblAdminRemarks.Visible = true;
                    txtAdminRemarks.Visible = true;
                    //txtAdminRemarks.Enabled = true;
                }
                else
                {
                    lblAdminRemarks.Visible = false;
                    txtAdminRemarks.Visible = false;
                    txtAdminRemarks.Enabled = false;
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UnFreezeAllControls()
        {
            try
            {
                //txtReportNo.Enabled = true;
                txtAge.Enabled = true;
                txtCorrectAction.Enabled = true;
                txtDepart.Enabled = false;
                txtDescription.Enabled = true;
                txtexLocation.Enabled = true;
                cmbmachineTag.Enabled = true;
                // txtPersonName1.Enabled = true;
                cmbEmpType.Enabled = true;
                cmbIncidentType.Enabled = true;
                cmbLocation.Enabled = true;
                cmbOptUnit.Enabled = true;
                cmbShift.Enabled = true;
                cmbStatus.Enabled = false;
                dtpIncidentDate.Enabled = true;
                //dtpIncidentTime.Enabled = true;
                dtpReportDate.Enabled = false;
                // dtpReportTime.Enabled = true;
                btnBrowse.Enabled = true;
                btnInciReset.Enabled = true;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetControls()
        {
            switch (btnNew.Text)
            {
                case "New":
                    btnInciSave.Text = "Save";
                    PictIncImg.Image = null;
                    txtAge.Text = "";
                    txtCorrectAction.Text = "";
                    txtDescription.Text = "";
                    txtexLocation.Text = "";
                    cmbmachineTag.Text = "";
                    cmbEmpType.SelectedIndex = 0;
                    cmbIncidentType.SelectedIndex = 0;
                    cmbLocation.SelectedIndex = 0;
                    cmbOptUnit.SelectedIndex = 0;
                    cmbShift.SelectedIndex = 0;
                    cmbStatus.SelectedIndex = 0;
                    chkReadyToSubmit.Visible = true;
                    chkReadyToSubmit.Checked = false;
                    // dtpIncidentDate.Text = "";
                    //dtpReportDate.Text = "";
                    btnBrowse.Enabled = true;
                    btnInciSave.Enabled = true;
                    btnInciClose.Enabled = false;
                    //btnSubmit.Enabled = false;
                    imgPAth = string.Empty;
                    txtAdminRemarks.Visible = false;
                    lblAdminRemarks.Visible = false;
                    break;
            }
            //switch(btnSaveClose.Text)
            //{ 
            //    case "Save":
            //        btnSaveClose.Text = "Save";
            //        PictIncImg.Image = null;
            //        txtAge.Text = "";
            //        txtCorrectAction.Text = "";
            //        txtDescription.Text = "";
            //        txtexLocation.Text = "";
            //        txtmachineTag.Text = "";
            //        cmbEmpType.SelectedIndex = 0;
            //        cmbIncidentType.SelectedIndex = 0;
            //        cmbLocation.SelectedIndex = 0;
            //        cmbOptUnit.SelectedIndex = 0;
            //        cmbShift.SelectedIndex = 0;
            //        cmbStatus.SelectedIndex = 0;
            //        // dtpIncidentDate.Text = "";
            //        //dtpReportDate.Text = "";
            //        btnBrowse.Enabled = true;
            //        btnSaveClose.Enabled = true;
            //        btnSubmit.Enabled = true;
            //        btnSubmitClose.Enabled = false;
            //        imgPAth = string.Empty;
            //        txtAdminRemarks.Visible = false;
            //        lblAdminRemarks.Visible = false;
            //        break;
            //}
            switch (btnInciSave.Text)
            {
                case "Save":
                    btnInciSave.Text = "Save";
                    PictIncImg.Image = null;
                    txtAge.Text = "";
                    txtCorrectAction.Text = "";
                    txtDescription.Text = "";
                    txtexLocation.Text = "";
                    cmbmachineTag.Text = "";
                    cmbEmpType.SelectedIndex = 0;
                    cmbIncidentType.SelectedIndex = 0;
                    cmbLocation.SelectedIndex = 0;
                    cmbOptUnit.SelectedIndex = 0;
                    cmbShift.SelectedIndex = 0;
                    cmbStatus.SelectedIndex = 0;
                    // dtpIncidentDate.Text = "";
                    //dtpReportDate.Text = "";
                    btnBrowse.Enabled = true;
                    btnInciSave.Enabled = true;
                    btnInciClose.Enabled = true;
                    //btnSubmit.Enabled = false;
                    imgPAth = string.Empty;
                    txtAdminRemarks.Visible = false;
                    lblAdminRemarks.Visible = false;
                    break;

                case "Update":
                    btnInciSave.Text = "Update";
                    PictIncImg.Image = null;
                    txtAge.Text = "";
                    txtCorrectAction.Text = "";
                    txtDescription.Text = "";
                    txtexLocation.Text = "";
                    cmbmachineTag.Text = "";
                    cmbEmpType.SelectedIndex = 0;
                    cmbIncidentType.SelectedIndex = 0;
                    cmbLocation.SelectedIndex = 0;
                    cmbOptUnit.SelectedIndex = 0;
                    cmbShift.SelectedIndex = 0;
                    cmbStatus.SelectedIndex = 0;
                    // dtpIncidentDate.Text = "";
                    //dtpReportDate.Text = "";
                    btnBrowse.Enabled = true;
                    btnInciSave.Enabled = true;
                    btnInciClose.Enabled = false;
                    //btnSubmit.Enabled = false;
                    imgPAth = string.Empty;
                    txtAdminRemarks.Visible = false;
                    lblAdminRemarks.Visible = false;
                    break;
            }
        }

        private void ReloadDetail(string statustext)
        {
            if (statustext == "Save")
                cmbStatus.Text = IncidentStatus.Prepare.ToString();
            if (statustext == "Submit")
            {
                cmbStatus.Text = IncidentStatus.Submitted.ToString();
                FreezeAllControls();
            }
        }

        private void ResetErrorControls()
        {
            lbldecT.Visible = false;
            lblempT.Visible = false;
            lblimgT.Visible = false;
            lblincL.Visible = false;
            lblincL.Visible = false;
            lblopT.Visible = false;
        }
        private void UnsetReadOnly()
        {
            txtAge.Enabled = true;
            txtCorrectAction.Enabled = true;
            txtDescription.Enabled = true;
            txtexLocation.Enabled = true;
            cmbmachineTag.Enabled = true;
            cmbEmpType.Enabled = true;
            cmbIncidentType.Enabled = true;
            cmbLocation.Enabled = true;
            cmbOptUnit.Enabled = true;
            cmbShift.Enabled = true;
            cmbStatus.Enabled = false;
            PictIncImg.Image = null;
        }
        private bool CopyGridData()
        {
            bool isValid = false;
            try
            {

                DBIncidentView.Columns[0].Visible = false;
                DBIncidentView.Columns[1].Visible = false;
                DBIncidentView.SelectAll();
                if (DBIncidentView.Rows.Count > 0)
                {
                    DataObject dataObj = DBIncidentView.GetClipboardContent();
                    if (dataObj != null)
                        Clipboard.SetDataObject(dataObj);
                    isValid = true;
                }
                
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isValid;
        }
        private void getMachineListfromCAD()
        {
            try
            {
                cmbmachineTag.Items.Clear();
                if (GlobalDeclaration._ActiveMachines.Count > 0)
                {
                    for (int i = 0; i < GlobalDeclaration._ActiveMachines.Count; i++)
                    {
                        cmbmachineTag.Items.Add(GlobalDeclaration._ActiveMachines.ElementAt(i).Key);
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void MapOpertionUnit()
        {
            DataTable dt = Resources.Instance.GetOperationUnit();
            cmbOptUnit.Items.Clear();
            foreach (DataRow oUnit in dt.Rows)
            {
                cmbOptUnit.Items.Add(oUnit["OperationUnitName"].ToString());
            }
        }
        #endregion

        #region Handler Section
        private void FrmGenericReporting_Load(object sender, EventArgs e)
        {
            try
            {
                HideIncidentPagesHeader();
                isPageReloaded = false;
                IncidentPages.SelectedIndex = 1;
                InitCmbHours();
                MapOpertionUnit();
                LoadEvent();
                GenerateReportLabels();
                AddComboValues();
                DisableLoadButton();
                //HideContols();
                DisableControlPermanent();
                if (Properties.Settings.Default.RoleID!=7)// && Properties.Settings.Default.RoleID != 1)
                {
                    lblAdminRemarks.Visible = false;
                    txtAdminRemarks.Visible = false;
                }

                GlobalDeclaration.ReadIniSetting();
                GlobalDeclaration.ReadINIData();
                

                GetAdminCode();
                dtpReportDate.Format = DateTimePickerFormat.Custom;
                dtpIncidentDate.Format = DateTimePickerFormat.Custom;
                // dtpIncidentDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                //dtpIncidentDate.Value =Convert.ToDateTime( DateTime.Now.ToString("dd-MM-yyyy"));
                dtpIncidentDate.MaxDate = DateTime.Now;
                dtpReportDate.MaxDate = DateTime.Now;
                dtpViewFRom.MaxDate = DateTime.Now;
                dtpViewTo.MaxDate = DateTime.Now;
                dtpReportDate.CustomFormat = "dd-MMM-yyyy";
                dtpIncidentDate.CustomFormat = "dd-MMM-yyyy";
                dtpViewFRom.CustomFormat = "dd-MMM-yyyy";
                dtpViewTo.CustomFormat = "dd-MMM-yyyy";
                dtpReportDate.Value = DateTime.Now.Date;
                dtpIncidentDate.Value = DateTime.Now.Date;
                dtpViewFRom.Value = DateTime.Now.Date;
                dtpViewTo.Value = DateTime.Now.Date;
                int countm = GlobalDeclaration._ActiveMachines.Count;
                foreach (var item in GlobalDeclaration._MyTagDictinary)//GlobalDeclaration._ActiveMachines)
                {
                    string basicMachine = item.Value;
                    cmbmachineTag.Items.Add(basicMachine);
                }
                timerTicker.Enabled = true;

                if(empRoleId!=7 && empRoleId != 5)
                {
                    BtnNewReport.Location = btnApproval.Location;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        private void btnbrowse_Click(object sender, EventArgs e)
        {
            try
            {
                browseImageFile();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbIncidentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string type1 = TypeArr[1];
                string type2 = TypeArr[2];
                if ((cmbIncidentType.Text == "N/A"))
                {
                    HideContols();
                    ReportGm = ReportToGM.No.ToString();
                }
                if ((cmbIncidentType.Text != type1) || (cmbIncidentType.Text != type2))
                {
                    HideContols();
                    ReportGm = ReportToGM.Yes.ToString();
                }

                if ((cmbIncidentType.Text != type1) && (cmbIncidentType.Text != type2) && (cmbIncidentType.Text != "N/A"))
                {
                    UnhideControls();
                    ReportGm = ReportToGM.Yes.ToString();
                }
                else
                {
                    HideContols();
                    ReportGm = ReportToGM.No.ToString();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        //private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        //    {
        //        e.Handled = true;
        //    }
        //}
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //onTabControlChange();
                
                LoadViewGrid();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void InvokeEmployeeType(object sender, string value)
        {
            GetEmployeType();
        }
        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            try
            {
                bool isImg = false;
                isPageValidated = ValidateForm();
                //if ((imgPAth == string.Empty) || (imgPAth == ""))
                //{
                //    isImg = true;
                //}
                if (isPageValidated == true)
                {
                    AddMessage();
                    //if (imgPAth == "")
                    //{
                    //    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, MessasgeAP[6], "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    isImg = true;
                    //}
                    if ((isPageValidated == true))
                    {
                        if (btnInciSave.Text == "Save" || btnInciSave.Text == "Submit")
                        {
                            ObjectToClassMapper();
                            ReloadDetail(btnInciSave.Text);
                            if (btnInciSave.Text == "Submit")
                            {
                                //UnhideButtonControl();
                                //DisableLoadButton();
                                FreezeAllControls();
                                IncReport.ReportIncidentMail(IncReport);
                            }
                            DisableLoadButton();
                            ////ResetControls();
                            //}
                            // GlobalDeclaration.genRpt.updateIncidentTbl += ReportedIncidentHandler;

                            GlobalDeclaration.genRpt.updateIncidentTbl += ReportedIncidentHandler;
                            if (GlobalDeclaration.genRpt.updateIncidentTbl != null)
                                GlobalDeclaration.genRpt.updateIncidentTbl.Invoke(sender, txtReportNo.Text);
                            //GenerateReportLabels();
                        }



                        //if (btnSaveClose.Text == "Submit")
                        //{
                        //    string message = "Are you sure you want to continue?";
                        //    string title = "Rejection Window";
                        //    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        //    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
                        //    if (result == DialogResult.Yes)
                        //    {
                        //        AddMessage();
                        //        string UpdStatus = string.Empty;
                        //        if (cmbStatus.Text == IncidentStatus.Prepare.ToString())
                        //        {
                        //            UpdStatus = IncidentStatus.Submit.ToString();
                        //        }
                        //        else if (cmbStatus.Text == IncidentStatus.Submit.ToString())
                        //        {
                        //            UpdStatus = IncidentStatus.Closed.ToString();
                        //        }
                        //        int j = Resources.Instance.UpdateIncidentReport_RMPCL(txtReportNo.Text, UpdStatus, DateTime.Now, "");
                        //        if (j > 0)
                        //        {
                        //            XtraMessageBox.Show(MessasgeAP[2], ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        }
                        //        else
                        //        {
                        //            XtraMessageBox.Show(MessasgeAP[4], ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        }
                        //    }
                        //    else
                        //    {
                        //        return;
                        //    }
                        //    GlobalDeclaration.genRpt.updateIncidentTbl += ReportedIncidentHandler;
                        //    if (GlobalDeclaration.genRpt.updateIncidentTbl != null)
                        //        GlobalDeclaration.genRpt.updateIncidentTbl.Invoke(sender, txtReportNo.Text);
                        //    btnSubmitClose.Enabled = false;
                        //}

                        isAllValidated = false;
                    }
                }
                ////else
                ////{
                ////    MessageBox.Show("!Please Select Image to upload");
                ////}
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void DBIncidentView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex > 0)
                {
                    if (IncidentPages.SelectedIndex == 1)
                    {
                        NonAdminControls();
                        string StatusType = this.DBIncidentView.Rows[e.RowIndex].Cells[7].Value.ToString();
                        txtReportNo.Text = this.DBIncidentView.Rows[e.RowIndex].Cells[2].Value.ToString();
                        ReportNo = DBIncidentView.Rows[e.RowIndex].Cells[2].Value.ToString();
                        IncidentPreFill = Resources.Instance.GetIncidentReport_RMPCL(GlobalDeclaration._holdInfo[0].EmpCode, ReportNo.Trim(), 1);
                        BindClassObject(IncidentPreFill);
                        FreezeAllControls();
                        UnhideButtonControl();
                        IncidentPages.SelectedIndex = 0;
                        isSelfAssigned = this.DBIncidentView.Rows[e.RowIndex].Cells[9].Value.ToString();
                        isAdminAssigned = this.DBIncidentView.Rows[e.RowIndex].Cells[10].Value.ToString();
                        ObservedBy = this.DBIncidentView.Rows[e.RowIndex].Cells[11].Value.ToString();
                        GlobalDeclaration.IncidentCode = ReportNo;
                        switch (StatusType)
                        {
                            case "Prepare":
                                if (ObservedBy == GlobalDeclaration._holdInfo[0].UserName)
                                {
                                    NonAdminControls();
                                }
                                else
                                {
                                    //btnSaveClose.Enabled = false;
                                    //btnReset.Enabled = false;
                                    AdminControls();
                                }
                                break;
                            case "Submit":
                                CloseControls();
                                break;
                            case "Closed":
                                DisableControls();
                                break;
                            case "Rejected":
                                OnRejectedState();
                                break;
                        }
                    }
                }
                if (e.ColumnIndex == 1)
                {

                    isRedirect = true;
                    IncidentPages.SelectedIndex = 0;
                    btnInciSave.Enabled = false;
                    btnInciClose.Visible = false;
                    //btnSubmit.Visible = true;
                    cmbStatus.Text = IncidentStatus.Submitted.ToString();
                    ReportNo = DBIncidentView.Rows[e.RowIndex].Cells[2].Value.ToString();
                    IncidentPreFill = Resources.Instance.GetIncidentReport_RMPCL(GlobalDeclaration._holdInfo[0].EmpCode, ReportNo.Trim(), 1);
                    BindClassObject(IncidentPreFill);
                    //btnSubmit.Visible = false;
                    DocumentStatus = this.DBIncidentView.Rows[e.RowIndex].Cells[7].Value.ToString();
                    if (IncidentPreFill.Rows[0]["ObservedBy"].ToString() == GlobalDeclaration._holdInfo[0].EmpCode)
                    {
                        if (DocumentStatus == IncidentStatus.Prepare.ToString())
                        {
                            btnInciSave.Text = "Update";
                            btnInciSave.Visible = true;
                            btnInciSave.Enabled = true;
                            //btnReset.Enabled = false;
                            UnFreezeAllControls();
                        }
                        else
                        {
                            btnInciSave.Enabled = false;
                            btnBrowse.Enabled = false;
                            XtraMessageBox.Show("Cannot update once the Status is" + " " + DocumentStatus, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            FreezeAllControls();
                            HideContolsUpdate();
                        }
                    }
                    else
                    {
                        DisableNonAdminControls();
                        FreezeAllControls();
                        // HideContolsUpdate();
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSubmitClose_Click(object sender, EventArgs e)
        {
            try
            {
                string message = "Are you sure you want to continue?";
                string title = "Rejection Window";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    AddMessage();
                    string UpdStatus = string.Empty;
                    if (cmbStatus.Text == IncidentStatus.Prepare.ToString())
                    {
                        UpdStatus = IncidentStatus.Submitted.ToString();
                    }
                    else if (cmbStatus.Text == IncidentStatus.Submitted.ToString())
                    {
                        UpdStatus = IncidentStatus.Closed.ToString();
                    }
                    int j = Resources.Instance.UpdateIncidentReport_RMPCL(txtReportNo.Text, UpdStatus, DateTime.Now, "");
                    if (j > 0)
                    {
                        XtraMessageBox.Show(MessasgeAP[2], ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show(MessasgeAP[4], ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    return;
                }
                GlobalDeclaration.genRpt.updateIncidentTbl += ReportedIncidentHandler;
                if (GlobalDeclaration.genRpt.updateIncidentTbl != null)
                    GlobalDeclaration.genRpt.updateIncidentTbl.Invoke(sender, txtReportNo.Text);
                //btnSubmit.Enabled = false;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int ii = Properties.Settings.Default.RoleID;
                Reporting.IncidentClosure incClosed = new IncidentClosure();
                incClosed.NewEmpTypeHandler += ReportedIncidentHandler;
                GlobalDeclaration.PermitType = this.txtReportNo.Text;
                incClosed.ShowDialog();
                cmbStatus.Text = IncidentStatus.Closed.ToString();
                DisableLoadButton();
                IncReport.CloseIncidentMail(IncReport);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DBGridSubmit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    isRedirect = true;

                    if (isRedirect == true && IncidentPages.SelectedIndex == 2)
                    {
                        btnInciSave.Enabled = false;
                        btnInciClose.Visible = false;
                        //btnSubmit.Visible = true;
                        cmbStatus.Text = IncidentStatus.Submitted.ToString();
                        //ReportNo = DBGridSubmit.Rows[e.RowIndex].Cells[2].Value.ToString();

                        IncidentPreFill = Resources.Instance.GetIncidentReport_RMPCL(GlobalDeclaration._holdInfo[0].EmpCode, ReportNo.Trim(), 1);
                        BindClassObject(IncidentPreFill);
                        FreezeAllControls();
                        isPageReloaded = false;
                        IncidentPages.SelectedIndex = 0;

                    }
                    else
                    {
                        btnInciSave.Enabled = true;
                        btnInciClose.Visible = false;
                        //btnSubmit.Visible = false;
                    }
                }

                if ((empRoleId == 7) || (empRoleId == 1))
                {
                    //btnSubmit.Visible = false;
                    btnInciSave.Enabled = false;
                }

                if ((empRoleId != 1) || (empRoleId != 7))
                {
                    //btnSubmit.Visible = false;
                    btnInciSave.Enabled = false;
                    btnInciClose.Visible = true;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
        private void txtmachineTag_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable AutoSource = new DataTable();
                AutoSource = Resources.Instance.GetMachineDetailsOrTag();
                string[] postSource = AutoSource
                        .AsEnumerable()
                        .Select<System.Data.DataRow, String>(x => x.Field<String>("MachineTagNo"))
                        .ToArray();

                var source = new AutoCompleteStringCollection();
                source.AddRange(postSource);
                cmbmachineTag.AutoCompleteCustomSource = source;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbMachinetag_TextChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtmachineTag_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                IncidentPages.SelectedIndex = 0;
                // ResetControls();
                ResetOnPrepare();
                UnsetReadOnly();
                // GenerateReportLabels();
                HideContols();
                ResetErrorControls();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void cmbEmpType_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.IncidentPages.SelectedTab.Tag.ToString() == "View")
                {
                    isPageValidated = true;
                }
                if (isPageValidated == false)
                {
                    if (cmbEmpType.Text == "")
                    {
                        e.Cancel = true;
                        cmbEmpType.Focus();
                        eps.SetError(cmbEmpType, "Employee Type is required");
                        isAllValidated = false;
                    }
                    else
                    {
                        e.Cancel = false;
                        eps.SetError(cmbEmpType, null);
                        isAllValidated = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbIncidentType_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.IncidentPages.SelectedTab.Tag.ToString() == "View")
                {
                    isPageValidated = true;
                }
                if (isPageValidated == false)
                {
                    if (cmbIncidentType.Text == "")
                    {
                        e.Cancel = true;
                        cmbIncidentType.Focus();
                        eps.SetError(cmbIncidentType, "Incident Type is required");
                        isAllValidated = false;
                    }
                    else
                    {
                        e.Cancel = false;
                        eps.SetError(cmbIncidentType, null);
                        isAllValidated = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbOptUnit_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.IncidentPages.SelectedTab.Tag.ToString() == "View")
                {
                    isPageValidated = true;
                }
                if (isPageValidated == false)
                {
                    if (cmbOptUnit.Text == "")
                    {
                        e.Cancel = true;
                        cmbOptUnit.Focus();
                        eps.SetError(cmbOptUnit, "Operation Unit is required");
                        isAllValidated = false;
                    }
                    else
                    {
                        e.Cancel = false;
                        eps.SetError(cmbOptUnit, null);
                        isAllValidated = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbLocation_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.IncidentPages.SelectedTab.Tag.ToString() == "View")
                {
                    isPageValidated = true;
                }
                if (isPageValidated == false)
                {
                    if (cmbLocation.Text == "")
                    {
                        e.Cancel = true;
                        cmbLocation.Focus();
                        eps.SetError(cmbLocation, "Incident Location is required");
                        isAllValidated = false;
                    }
                    else
                    {
                        e.Cancel = false;
                        eps.SetError(cmbLocation, null);
                        isAllValidated = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbEmpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbEmpType.Text == "Others")
                {
                    Reporting.EmployeeType empT = new Reporting.EmployeeType();
                    empT.NewEmpTypeHandler += InvokeEmployeeType;
                    empT.ShowDialog();
                }
                else
                {

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUplImgCancel_Click(object sender, EventArgs e)
        {
            try
            {
                PictIncImg.Image = null;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                UnFreezeAllControls();
                ResetControls();
                GenerateReportLabels();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (isPageValidated == false)
                {
                    if (string.IsNullOrEmpty(txtDescription.Text))
                    {
                        e.Cancel = true;
                        //txtDescription.Focus();
                        eps.SetError(txtDescription, "Description is required");
                        isAllValidated = false;
                    }
                    else
                    {
                        e.Cancel = false;
                        eps.SetError(txtDescription, null);
                        isAllValidated = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportExl_Click(object sender, EventArgs e)
        {
            try
            {
               bool IsValid= CopyGridData();
                if (IsValid == false) return;
                Microsoft.Office.Interop.Excel.Application xlexcel;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Microsoft.Office.Interop.Excel.Application();
                xlexcel.Visible = true;
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[2, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                DBIncidentView.Columns[0].Visible = true;
                DBIncidentView.Columns[1].Visible = true;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        private void cmbEmpType_Leave(object sender, EventArgs e)
        {
            try
            {
                eps.Dispose();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbShift_Leave(object sender, EventArgs e)
        {
            try
            {
                eps.Dispose();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbIncidentType_Leave(object sender, EventArgs e)
        {
            try
            {
                eps.Dispose();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbOptUnit_Leave(object sender, EventArgs e)
        {
            try
            {
                eps.Dispose();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                eps.Dispose();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDescription_Leave(object sender, EventArgs e)
        {
            try
            {
                eps.Dispose();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txtDescription.Text.StartsWith("") && (txtDescription.Text.Length > 0))
                {
                    e.Handled = !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(char.IsControl(e.KeyChar)) && !(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar));
                }
                else
                {
                    e.Handled = !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(char.IsControl(e.KeyChar)) && !(char.IsNumber(e.KeyChar));
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmGenericReporting_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //eps.Dispose();

                eps.Clear();
                //this.Close();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void txtmachineTag_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                getMachineListfromCAD();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void UpdateTimeHandler(object sender, string value)
        {
            try
            {
                // dtpIncidentDate.Format = DateTimePickerFormat.Custom;
                //dtpIncidentDate.CustomFormat = "dd-MMM-yyyy hh:mm:tt";
                //dtpIncidentDate.Text = DateTime.Now.AddDays(0).ToString();
            }

            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void timerTicker_Tick(object sender, EventArgs e)
        {
            try
            {
                // GlobalDeclaration.genRpt.updateIncidentTbl += UpdateTimeHandler;
                //if (GlobalDeclaration.genRpt.updateIncidentTbl != null)
                //  GlobalDeclaration.genRpt.updateIncidentTbl.Invoke(sender, "");
                // if (updateIncidentTbl != null)
                //{
                //  this.updateIncidentTbl += UpdateTimeHandler;

                //}
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                Reporting.IncidentRejection IncRejct = new IncidentRejection();
                IncRejct.IncidentRejectioneHandler += RejectedReportedIncidentHandler;
                GlobalDeclaration.PermitType = this.txtReportNo.Text;
                IncRejct.Show();
                cmbStatus.Text = IncidentStatus.Rejected.ToString();
                DisableLoadButton();
                IncReport.RejectIncidentMail(IncReport);


            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btngo_Click(object sender, EventArgs e)
        {
            try
            {
                empRoleId = Resources.Instance.MapAdminRole_RMPCL(GlobalDeclaration._holdInfo[0].EmpCode.ToString());
                if (empRoleId == 1 || empRoleId == 7)
                {

                    

                    if (!string.IsNullOrEmpty(cmbRptEmpType.Text) && !string.IsNullOrEmpty(cmbRptStat.Text))
                    {
                        IncidentDetails = Resources.Instance.GetIncidentBetweenDates_RMPCL(dtpViewFRom.Value, dtpViewTo.Value, cmbRptEmpType.Text, cmbRptStat.Text, GlobalDeclaration._holdInfo[0].EmpCode, 2);
                        IncidentDetails = IncidentDetails.AsEnumerable().Where(X => X.Field<string>("Incident Status") != "Prepare").CopyToDataTable();
                        ////IncidentDetails = IncidentDetails.AsEnumerable().Where(X => X.Field<string>("Incident Status") != "Prepare" && X.Field<string>("Incident Status") != "Rejected").CopyToDataTable();
                    }
                    if (!string.IsNullOrEmpty(cmbRptEmpType.Text) && !string.IsNullOrEmpty(cmbRptStat.Text))
                    {
                        IncidentDetails = Resources.Instance.GetIncidentBetweenDates_RMPCL(dtpViewFRom.Value, dtpViewTo.Value, cmbRptEmpType.Text, cmbRptStat.Text, GlobalDeclaration._holdInfo[0].EmpCode, 1);
                    }
                    else if (string.IsNullOrEmpty(cmbRptEmpType.Text) && string.IsNullOrEmpty(cmbRptStat.Text))
                    {
                        IncidentDetails = Resources.Instance.GetIncidentBetweenDates_RMPCL(dtpViewFRom.Value, dtpViewTo.Value, cmbRptEmpType.Text, cmbRptStat.Text, GlobalDeclaration._holdInfo[0].EmpCode, 7);
                    }
                    else if (string.IsNullOrEmpty(cmbRptEmpType.Text) && !string.IsNullOrEmpty(cmbRptStat.Text))
                    {
                        IncidentDetails = Resources.Instance.GetIncidentBetweenDates_RMPCL(dtpViewFRom.Value, dtpViewTo.Value, cmbRptEmpType.Text, cmbRptStat.Text, GlobalDeclaration._holdInfo[0].EmpCode, 8);
                    }
                    else if (!string.IsNullOrEmpty(cmbRptEmpType.Text) && string.IsNullOrEmpty(cmbRptStat.Text))
                    {
                        IncidentDetails = Resources.Instance.GetIncidentBetweenDates_RMPCL(dtpViewFRom.Value, dtpViewTo.Value, cmbRptEmpType.Text, cmbRptStat.Text, GlobalDeclaration._holdInfo[0].EmpCode, 9);
                    }
                   
                    else
                    {
                        IncidentDetails = Resources.Instance.GetIncidentBetweenDates_RMPCL(dtpViewFRom.Value, dtpViewTo.Value, cmbRptEmpType.Text, cmbRptStat.Text, GlobalDeclaration._holdInfo[0].EmpCode, 4);
                        //IncidentDetails = IncidentDetails.AsEnumerable().Where(X => X.Field<string>("Incident Status") != "Prepare" && X.Field<string>("Incident Status") != "Rejected").CopyToDataTable();
                    }
                    if (IncidentDetails.Rows.Count > 0)
                        IncidentDetails = IncidentDetails.AsEnumerable().Where(X => X.Field<string>("Incident Status") != "Prepare").CopyToDataTable();
                }
                else
                {
                    if (!string.IsNullOrEmpty(cmbRptEmpType.Text) && !string.IsNullOrEmpty(cmbRptStat.Text))
                    {
                        IncidentDetails = Resources.Instance.GetIncidentBetweenDates_RMPCL(dtpViewFRom.Value, dtpViewTo.Value, cmbRptEmpType.Text, cmbRptStat.Text, GlobalDeclaration._holdInfo[0].EmpCode, 1);
                    }
                    else if(string.IsNullOrEmpty(cmbRptEmpType.Text) && string.IsNullOrEmpty(cmbRptStat.Text))
                    {
                        IncidentDetails = Resources.Instance.GetIncidentBetweenDates_RMPCL(dtpViewFRom.Value, dtpViewTo.Value, cmbRptEmpType.Text, cmbRptStat.Text, GlobalDeclaration._holdInfo[0].EmpCode, 4);
                    }
                    else if (string.IsNullOrEmpty(cmbRptEmpType.Text) && !string.IsNullOrEmpty(cmbRptStat.Text))
                    {
                        IncidentDetails = Resources.Instance.GetIncidentBetweenDates_RMPCL(dtpViewFRom.Value, dtpViewTo.Value, cmbRptEmpType.Text, cmbRptStat.Text, GlobalDeclaration._holdInfo[0].EmpCode, 5);
                    }
                    else if (!string.IsNullOrEmpty(cmbRptEmpType.Text) && string.IsNullOrEmpty(cmbRptStat.Text))
                    {
                        IncidentDetails = Resources.Instance.GetIncidentBetweenDates_RMPCL(dtpViewFRom.Value, dtpViewTo.Value, cmbRptEmpType.Text, cmbRptStat.Text, GlobalDeclaration._holdInfo[0].EmpCode, 6);
                    }


                }
                DBIncidentView.DataSource = IncidentDetails;
                DBIncidentView.Columns["ClosureDate"].HeaderText = "Closure Date";
                DBIncidentView.Columns["IsSelfAssigned"].HeaderText = "Is SelfAssigned";
                DBIncidentView.Columns["IsSelfAssigned"].Visible = false;// "Is SelfAssigned";
                DBIncidentView.Columns["Description"].Visible = false;
                this.DBIncidentView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void BtnNewReport_Click(object sender, EventArgs e)
        {
            IncidentPages.SelectedIndex = 0;
            ResetControls();
            InitiateForNew();
            UnFreezeAllControls();
            //ResetControls();
            //GenerateReportLabels();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            IncidentPages.SelectedIndex = 1;
            LoadViewGrid();
        }

        private void HideIncidentPagesHeader()
        {
            IncidentPages.Appearance = TabAppearance.FlatButtons;
            IncidentPages.ItemSize = new Size(0, 1);
            IncidentPages.SizeMode = TabSizeMode.Fixed;

            foreach (TabPage tab in IncidentPages.TabPages)
            {
                tab.Hide();// = "";
            }
        }

        private void DBIncidentView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                if (e.ColumnIndex > 0)
                {
                    if (IncidentPages.SelectedIndex == 1)
                    {
                        ////NonAdminControls();
                        string StatusType = this.DBIncidentView.Rows[e.RowIndex].Cells["Incident Status"].Value.ToString();
                        txtReportNo.Text = ReportNo=this.DBIncidentView.Rows[e.RowIndex].Cells["ReportNo"].Value.ToString();
                        ////ReportNo = DBIncidentView.Rows[e.RowIndex].Cells[2].Value.ToString();
                        IncidentPreFill = Resources.Instance.GetIncidentReport_RMPCL(GlobalDeclaration._holdInfo[0].EmpCode, ReportNo.Trim(), 1);
                        BindClassObject(IncidentPreFill);
                        IncidentPages.SelectedIndex = 0;
                        ////var vvv=this.DBIncidentView.Rows[e.RowIndex].Cells["IsSelfAssigned"].Value.ToString();
                        ////isSelfAssigned = this.DBIncidentView.Rows[e.RowIndex].Cells["IsSelfAssigned"].Value.ToString();
                        ////isAdminAssigned = this.DBIncidentView.Rows[e.RowIndex].Cells[10].Value.ToString();
                        ////ObservedBy = this.DBIncidentView.Rows[e.RowIndex].Cells[11].Value.ToString();
                        GlobalDeclaration.IncidentCode = ReportNo;
                        switch (StatusType)
                        {
                            case "Prepare":
                                if (ObservedBy == GlobalDeclaration._holdInfo[0].UserName)
                                {
                                    //NonAdminControls();
                                    DisableLoadButton();
                                    UnFreezeAllControls();
                                    //FreezeAllControls();
                                }
                                else
                                {
                                    //btnSaveClose.Enabled = false;
                                    //btnReset.Enabled = false;
                                    //AdminControls();
                                    DisableLoadButton();
                                    FreezeAllControls();
                                }
                                break;
                            case "Submitted":
                                //CloseControls();
                                DisableLoadButton();
                                FreezeAllControls();
                                break;
                            case "Closed":
                                //DisableControls();
                                DisableLoadButton();
                                FreezeAllControls();
                                break;
                            case "Rejected":
                                //OnRejectedState();
                                DisableLoadButton();
                                FreezeAllControls();
                                chkReadyToSubmit.Enabled = false;
                                break;
                        }
                        
                        ////UnhideButtonControl();
                    }
                }
                ////if (e.ColumnIndex == 1)
                ////{

                ////    isRedirect = true;
                ////    IncidentPages.SelectedIndex = 0;
                ////    btnInciSave.Enabled = false;
                ////    btnInciClose.Visible = false;
                ////    //btnSubmit.Visible = true;
                ////    cmbStatus.Text = IncidentStatus.Submitted.ToString();
                ////    ReportNo = DBIncidentView.Rows[e.RowIndex].Cells[2].Value.ToString();
                ////    IncidentPreFill = Resources.Instance.GetIncidentReport_RMPCL(GlobalDeclaration._holdInfo[0].EmpCode, ReportNo.Trim(), 1);
                ////    BindClassObject(IncidentPreFill);
                ////    //btnSubmit.Visible = false;
                ////    DocumentStatus = this.DBIncidentView.Rows[e.RowIndex].Cells[7].Value.ToString();
                ////    if (IncidentPreFill.Rows[0]["ObservedBy"].ToString() == GlobalDeclaration._holdInfo[0].EmpCode)
                ////    {
                ////        if (DocumentStatus == IncidentStatus.Prepare.ToString())
                ////        {
                ////            btnInciSave.Text = "Update";
                ////            btnInciSave.Visible = true;
                ////            btnInciSave.Enabled = true;
                ////            //btnReset.Enabled = false;
                ////            UnFreezeAllControls();
                ////        }
                ////        else
                ////        {
                ////            btnInciSave.Enabled = false;
                ////            btnBrowse.Enabled = false;
                ////            XtraMessageBox.Show("Cannot update once the Status is" + " " + DocumentStatus, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ////            FreezeAllControls();
                ////            HideContolsUpdate();
                ////        }
                ////    }
                ////    else
                ////    {
                ////        DisableNonAdminControls();
                ////        FreezeAllControls();
                ////        // HideContolsUpdate();
                ////    }
                ////}
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Image GetImage(byte[] bytearr)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytearr);
            Image i = Image.FromStream(ms);
            return i;
        }
        public static byte[] GetByteFromImage(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }

        private void chkReadyToSubmit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReadyToSubmit.Checked == true)
                btnInciSave.Text = "Submit";
            else
                btnInciSave.Text = "Save";
        }

        private void btnApproval_Click(object sender, EventArgs e)
        {
            IncidentPages.SelectedIndex = 2;
            empRoleId = Resources.Instance.MapAdminRole_RMPCL(GlobalDeclaration._holdInfo[0].EmpCode.ToString());
            if (empRoleId == 1 || empRoleId == 7)
            {
                IncidentDetails = Resources.Instance.GetIncidentBetweenDates_RMPCL(DateTime.Today, DateTime.Today, "All", IncidentStatus.Submitted.ToString(), GlobalDeclaration._holdInfo[0].EmpCode, 3);
                //IncidentDetails = IncidentDetails.AsEnumerable().Where(X => X.Field<string>("Incident Status") != "Prepare" && X.Field<string>("Incident Status") != "Rejected").CopyToDataTable();
            }
            //else
            //{
            //    IncidentDetails = Resources.Instance.GetIncidentBetweenDates_RMPCL(dtpViewFRom.Value, dtpViewTo.Value, cmbRptEmpType.Text, cmbRptStat.Text, GlobalDeclaration._holdInfo[0].EmpCode, 1);
            //}
            DBIncidentApproval.DataSource = IncidentDetails;
            DBIncidentApproval.Columns["ClosureDate"].HeaderText = "Closure Date";
            DBIncidentApproval.Columns["IsSelfAssigned"].HeaderText = "Is SelfAssigned";
            DBIncidentApproval.Columns["IsSelfAssigned"].Visible = false;
            DBIncidentApproval.Columns["Description"].Visible = false;
            this.DBIncidentApproval.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void DBIncidentApproval_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                {
                    if (IncidentPages.SelectedIndex == 2)
                    {
                        string RptNo = DBIncidentApproval.Rows[e.RowIndex].Cells["ReportNo"].Value.ToString();

                        IncidentPreFill = Resources.Instance.GetIncidentReport_RMPCL(GlobalDeclaration._holdInfo[0].EmpCode, RptNo.Trim(), 1);
                        BindClassObject(IncidentPreFill);

                        //IncReport.ReportDate = Convert.ToDateTime(DBIncidentApproval.Rows[e.RowIndex].Cells["ReportDate"].Value.ToString());
                        //IncReport.ReportTime = Convert.ToDateTime(DBIncidentApproval.Rows[e.RowIndex].Cells["ReportTime"].Value.ToString());
                        //IncReport.EmployeeType = DBIncidentApproval.Rows[e.RowIndex].Cells["EmployeeType"].Value.ToString();
                        //IncReport.Shift = DBIncidentApproval.Rows[e.RowIndex].Cells["Shift"].Value.ToString();
                        //IncReport.IncidentType = DBIncidentApproval.Rows[e.RowIndex].Cells["IncidentType"].Value.ToString();
                        //IncReport.IncidentDate = Convert.ToDateTime(DBIncidentApproval.Rows[e.RowIndex].Cells["IncidentDate"].Value.ToString());
                        //IncReport.IncidentTime = Convert.ToDateTime(DBIncidentApproval.Rows[e.RowIndex].Cells["IncidentDate"].Value.ToString());
                        //IncReport.IncidentLocation = DBIncidentApproval.Rows[e.RowIndex].Cells["IncidentLocation"].Value.ToString();
                        //IncReport.ExactLocation = DBIncidentApproval.Rows[e.RowIndex].Cells["ExactLocation"].Value.ToString(); 
                        //IncReport.Description = DBIncidentApproval.Rows[e.RowIndex].Cells["Description"].Value.ToString(); 
                        //IncReport.CorrectiveAction = DBIncidentApproval.Rows[e.RowIndex].Cells["CorrectiveAction"].Value.ToString();
                        //IncReport.ObservedBy = DBIncidentApproval.Rows[e.RowIndex].Cells["ObservedBy"].Value.ToString();
                        //IncReport.PersonInjured = DBIncidentApproval.Rows[e.RowIndex].Cells["PersonInjured"].Value.ToString();
                        //IncReport.DepartmentId = Convert.ToInt32(DBIncidentApproval.Rows[e.RowIndex].Cells["DepartmentId"]);
                        //IncReport.PersonAge = DBIncidentApproval.Rows[e.RowIndex].Cells["PersonAge"].Value.ToString();
                        //IncReport.MachineTag = DBIncidentApproval.Rows[e.RowIndex].Cells["MachineTag"].Value.ToString();
                        //IncReport.IncidentImage = (byte[])DBIncidentApproval.Rows[e.RowIndex].Cells["IncidentImage"].Value;
                        //IncReport.IncidentStatus = DBIncidentApproval.Rows[e.RowIndex].Cells["IncidentStatus"].Value.ToString();
                        //IncReport.OperationUnit = DBIncidentApproval.Rows[e.RowIndex].Cells["OperationUnit"].Value.ToString();
                        //IncReport.AdminRemarks = DBIncidentApproval.Rows[e.RowIndex].Cells["AdminRemarks"].Value.ToString();
                        //BindClassControls(IncReport);


                        ////NonAdminControls();
                        string StatusType = this.DBIncidentApproval.Rows[e.RowIndex].Cells["Incident Status"].Value.ToString();
                        //txtReportNo.Text = this.DBIncidentView.Rows[e.RowIndex].Cells[2].Value.ToString();
                        //ReportNo = DBIncidentView.Rows[e.RowIndex].Cells[2].Value.ToString();
                        ////IncidentPreFill = Resources.Instance.GetIncidentReport_RMPCL(GlobalDeclaration._holdInfo[0].EmpCode, ReportNo.Trim(), 1);
                        //BindClassObject(IncidentPreFill);
                        
                        IncidentPages.SelectedIndex = 0;
                        isSelfAssigned = this.DBIncidentApproval.Rows[e.RowIndex].Cells[9].Value.ToString();
                        isAdminAssigned = this.DBIncidentApproval.Rows[e.RowIndex].Cells[10].Value.ToString();
                        ObservedBy = this.DBIncidentApproval.Rows[e.RowIndex].Cells[11].Value.ToString();
                        GlobalDeclaration.IncidentCode = ReportNo;
                        switch (StatusType)
                        {
                            case "Prepare":
                                if (ObservedBy == GlobalDeclaration._holdInfo[0].UserName)
                                {
                                    NonAdminControls();
                                }
                                else
                                {
                                    //btnSaveClose.Enabled = false;
                                    //btnReset.Enabled = false;
                                    AdminControls();
                                }
                                break;
                            case "Submitted":
                                //CloseControls();
                                //DisableControls();
                                DisableLoadButton();
                                break;
                            case "Closed":
                                DisableControls();
                                break;
                            case "Rejected":
                                OnRejectedState();
                                break;
                        }
                    }
                }
                FreezeAllControls();
                DisableLoadButton();
                //UnhideButtonControl();
            }
            catch (Exception ex)
            {
            }
        }
        private void DisableControlPermanent()
        {
            txtReportNo.Enabled = false;
            dtpReportDate.Enabled = false;
            ////txtReprtedBy.Enabled = false;
            txtDocBy.Enabled = false;
            cmbStatus.Enabled = false;
            txtDepart.Enabled = false;
        }
        private void InitiateForNew()
        {
            MapOpertionUnit();
            LoadEvent();

            GenerateReportLabels();
            //AddComboValues();
            DisableLoadButton();
            //HideContols();
            DisableControlPermanent();
            if (Properties.Settings.Default.RoleID != 7)// && Properties.Settings.Default.RoleID != 1)
            {
                lblAdminRemarks.Visible = false;
                txtAdminRemarks.Visible = false;
            }

            GlobalDeclaration.ReadIniSetting();
            GlobalDeclaration.ReadINIData();
            GetAdminCode();
            dtpReportDate.Format = DateTimePickerFormat.Custom;
            dtpIncidentDate.Format = DateTimePickerFormat.Custom;
            // dtpIncidentDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            //dtpIncidentDate.Value =Convert.ToDateTime( DateTime.Now.ToString("dd-MM-yyyy"));
            dtpIncidentDate.MaxDate = DateTime.Now;
            dtpReportDate.MaxDate = DateTime.Now;
            dtpViewFRom.MaxDate = DateTime.Now;
            dtpViewTo.MaxDate = DateTime.Now;
            dtpReportDate.CustomFormat = "dd-MMM-yyyy";
            dtpIncidentDate.CustomFormat = "dd-MMM-yyyy";
            dtpViewFRom.CustomFormat = "dd-MMM-yyyy";
            dtpViewTo.CustomFormat = "dd-MMM-yyyy";
            dtpReportDate.Value = DateTime.Now.Date;
            dtpIncidentDate.Value = DateTime.Now.Date;
            dtpViewFRom.Value = DateTime.Now.Date;
            dtpViewTo.Value = DateTime.Now.Date;
            int countm = GlobalDeclaration._ActiveMachines.Count;
            //foreach (var item in GlobalDeclaration._ActiveMachines)
            if(cmbmachineTag.Items.Count>0)
            {
                cmbmachineTag.Items.Clear();
            }
            foreach (var item in GlobalDeclaration._MyTagDictinary)
             {
                 cmbmachineTag.Items.Add(item.Value);
             }
            timerTicker.Enabled = false;
        }

        private void LoadViewGrid()
        {
            empRoleId = Resources.Instance.MapAdminRole_RMPCL(GlobalDeclaration._holdInfo[0].EmpCode.ToString());
            if (empRoleId == 1 || empRoleId == 7)
            {
                IncidentDetails = Resources.Instance.GetIncidentBetweenDates_RMPCL(dtpViewFRom.Value, dtpViewTo.Value, cmbRptEmpType.Text, cmbRptStat.Text, GlobalDeclaration._holdInfo[0].EmpCode, 2);
                if (IncidentDetails.Rows.Count > 0)
                    IncidentDetails = IncidentDetails.AsEnumerable().Where(X => X.Field<string>("Incident Status") != "Prepare" && X.Field<string>("Incident Status") != "Rejected").CopyToDataTable();
            }
            else
            {
                IncidentDetails = Resources.Instance.GetIncidentBetweenDates_RMPCL(dtpViewFRom.Value, dtpViewTo.Value, cmbRptEmpType.Text, cmbRptStat.Text, GlobalDeclaration._holdInfo[0].EmpCode, 1);
            }
            
            DBIncidentView.DataSource = IncidentDetails;
            //if (IncidentDetails.Rows.Count>0)
            {
                DBIncidentView.Columns["ClosureDate"].HeaderText = "Closure Date";
                DBIncidentView.Columns["IsSelfAssigned"].HeaderText = "Is SelfAssigned";
            }
            this.DBIncidentView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
       
        }

        private void chkRemoveFilter_CheckedChanged(object sender, EventArgs e)
        {
            if(chkRemoveFilter.Checked==true)
            {
                cmbRptStat.Text = string.Empty;
                cmbRptEmpType.Text = string.Empty;
            }
        }

        private void cmbRptStat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(cmbRptStat.Text))
            {
                chkRemoveFilter.Checked = false;
            }
        }

        private void cmbRptEmpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cmbRptEmpType.Text))
            {
                chkRemoveFilter.Checked = false;
            }
        }

        private void InitCmbHours()
        {
            try
            {
                if (cmbFromHours.Items.Count > 0)
                    cmbFromHours.Items.Clear();
               
                if (cmbFromMinuts.Items.Count > 0)
                    cmbFromMinuts.Items.Clear();
                
                for (int i = 0; i < 24; i++)
                {
                    cmbFromHours.Items.Add(i);
                }
                for (int j = 0; j < 60; j++)
                {
                    cmbFromMinuts.Items.Add(j);
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }






