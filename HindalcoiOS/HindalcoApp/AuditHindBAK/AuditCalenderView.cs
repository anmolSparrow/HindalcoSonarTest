using DevExpress.XtraEditors;
using RMPCLApp.Class_Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMPCLApp.AuditHind
{
    public partial class AuditCalenderView : XtraForm
    {
        public AuditCalenderView()
        {
            InitializeComponent();
        }

        #region Controls Handler-----------
        private void btnAuditGen_Click(object sender, EventArgs e)
        {
            //GenerateAudit();
            GetOptionPopUp();
        }
        private void dgvViewAuditMaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex < 0) return;

                txtDocNo.Text = dgvViewAuditMaster.Rows[e.RowIndex].Cells["DocNo"].Value.ToString();
                dtpDocDate.Text = dgvViewAuditMaster.Rows[e.RowIndex].Cells["DocDate"].Value.ToString();
                txtDocBy.Text = dgvViewAuditMaster.Rows[e.RowIndex].Cells["DocBy"].Value.ToString();
                cmbAuditor.Text = dgvViewAuditMaster.Rows[e.RowIndex].Cells["AuditTeam"].Value.ToString();
                dtpTrgtDate.Text = dgvViewAuditMaster.Rows[e.RowIndex].Cells["TargetDate"].Value.ToString();
                dtpTentDate.Text = dgvViewAuditMaster.Rows[e.RowIndex].Cells["TentDate"].Value.ToString();
                dtpDateofAudit.Text = dgvViewAuditMaster.Rows[e.RowIndex].Cells["DateofAudit"].Value.ToString();
                cmbAuditMonth.Text = dgvViewAuditMaster.Rows[e.RowIndex].Cells["Month"].Value.ToString();
                cmbDept.Text = dgvViewAuditMaster.Rows[e.RowIndex].Cells["Department"].Value.ToString();
                //cmbArea.Text = dgvViewAuditMaster.Rows[e.RowIndex].Cells["Area"].Value.ToString();
                txtAuditType.Text = dgvViewAuditMaster.Rows[e.RowIndex].Cells["AuditType"].Value.ToString();
                cmbLeadAuditor.Text = dgvViewAuditMaster.Rows[e.RowIndex].Cells["LeadAuditor"].Value.ToString();
                //cmbAuditTeam.Text = dgvViewAuditMaster.Rows[e.RowIndex].Cells["EmailID"].Value.ToString();
                txtStatus.Text = dgvViewAuditMaster.Rows[e.RowIndex].Cells["Status"].Value.ToString();

                //btnAdd.Text = "Update";
                //ViewDept();
                AuditPlanPages.SelectedIndex = 1;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AuditPlanning_Load(object sender, EventArgs e)
        {
            GlobalDeclaration.HideTabCtrlPagesHeader(AuditPlanPages);
        }
        private void btnAudPlan_Click(object sender, EventArgs e)
        {
            AuditPlanPages.SelectedIndex = 0;
        }
        private void btnDetailPlan_Click(object sender, EventArgs e)
        {
            AuditPlanPages.SelectedIndex = 1;
        }
        private void btnReportAudit_Click(object sender, EventArgs e)
        {
            CreateNewAuditReport();

            //input code for saving in database
        }
        private void AuditGenOptionHandlerEvent(params object[] objec)
        {
            string ss = objec[0].ToString();
            GenerateAudit(objec[0].ToString(), objec[1].ToString(), objec[2].ToString());
        }
        private void btnAuditUpd_Click(object sender, EventArgs e)
        {
            UpdateStatus();
        }
        private void btnClosePlan_Click(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        #endregion

        #region Methods-----------------
        public AuditGenOption GetOptionPopUp()
        {
            AuditGenOption adtGenOption = new AuditGenOption();// (txtProcDocNo.Text);

            adtGenOption.GetValue += AuditGenOptionHandlerEvent;

            if (adtGenOption.ShowDialog() == DialogResult.OK)
            {
                adtGenOption.GetValue += AuditGenOptionHandlerEvent;
                adtGenOption.Close();
                adtGenOption.Dispose();
            }
            return adtGenOption;
        }
        public void GenerateAudit(string audType, string audyear,string audQtr)
        {

            DataTable deptList = new DataTable();
            foreach (DataRow dr in deptList.Rows)
            {
                AuditCalender audPlan = null;
                if (CheckAuditData(dr["Name"].ToString(), audType, audyear, audQtr) > 0) continue;

                audPlan = new AuditCalender();
                audPlan.DocNo = "101";
                audPlan.DocDate = DateTime.Today;
                audPlan.CreatedBy = GlobalDeclaration.UserName;
                //audPlan.Month = audMonth;
                audPlan.Year = audyear;
                audPlan.Quarter = audQtr;
                audPlan.AuditType = audType;
                audPlan.TargetDate = DateTime.Today;
                audPlan.TentativeDate = DateTime.Today;
                audPlan.AuditDate = DateTime.Today;
                audPlan.Dept = dr["Name"].ToString();
                audPlan.DeptId = dr["Name"].ToString();
                //audPlan.Area = dr["Name"].ToString();
                //audPlan.AreaId = dr["Name"].ToString();
                audPlan.Auditor = dr["Name"].ToString();
                audPlan.AuditorId = dr["Name"].ToString();
                audPlan.Auditee = dr["Name"].ToString();
                audPlan.AuditeeId = dr["Name"].ToString();
                audPlan.Status = DocStatus.Prepare;

                ////DataGridViewRow Dr = new DataGridViewRow();
                ////dgvViewAuditMaster.Rows.Add(Dr);
                ////int rowsindex = dgvViewAuditMaster.Rows.Count - 1;
                ////dgvViewAuditMaster.Rows[rowsindex].Cells["DocNo"].Value = audPlan.DocNo;
                ////dgvViewAuditMaster.Rows[rowsindex].Cells["DocDate"].Value = audPlan.DocDate;
                ////dgvViewAuditMaster.Rows[rowsindex].Cells["AuditType"].Value = audPlan.AuditType;
                ////dgvViewAuditMaster.Rows[rowsindex].Cells["Month"].Value = audPlan.Month;
                ////dgvViewAuditMaster.Rows[rowsindex].Cells["Year"].Value = audPlan.Year;
                ////dgvViewAuditMaster.Rows[rowsindex].Cells["Quarter"].Value = audPlan.Quarter;
                ////dgvViewAuditMaster.Rows[rowsindex].Cells["Status"].Value = audPlan.Status.ToString();
                ////dgvViewAuditMaster.Rows[rowsindex].Cells["CreatedBy"].Value = audPlan.CreatedBy;
                ////dgvViewAuditMaster.Rows[rowsindex].Cells["Department"].Value = audPlan.Dept;
                //////dgvViewAuditMaster.Rows[rowsindex].Cells["Area"].Value = audPlan.Area;
                ////dgvViewAuditMaster.Rows[rowsindex].Cells["Auditor"].Value = audPlan.Auditor;
                ////dgvViewAuditMaster.Rows[rowsindex].Cells["Auditee"].Value = audPlan.Auditee;
               
                //insert planning data method;
            }
            //Get planning data;
            ViewAuditPlan();
        }
        public void ViewAuditPlan()
        {

        }
        private int CheckAuditData(string dept, string audType, string year, string quarter)
        {
            int icount = 0;
            //getData
            return icount;
        }
        private void UpdateStatus()
        {

        }
        private void CreateNewAuditReport()
        {
            AuditManagement auditMgmt = null;
            auditMgmt = new AuditManagement();
            auditMgmt.DocNo = "101";
            auditMgmt.AuditPlanID = txtDocNo.Text;
            auditMgmt.DocDate = DateTime.Today;
            auditMgmt.AuditType = txtAuditType.Text;
            auditMgmt.Month = cmbAuditMonth.Text;
            auditMgmt.Year = "";
            auditMgmt.Quarter = "Q1";
            auditMgmt.Dept = cmbDept.Text;
            auditMgmt.DocBy = txtDocBy.Text;
            auditMgmt.Area = "";
            auditMgmt.Auditor = "";
            auditMgmt.Auditee = "";
            auditMgmt.CAPAUser = "";
            auditMgmt.CateofObs = "";
            auditMgmt.NarrationObs = "";
            auditMgmt.RootCauseObsAuditor = "";
            auditMgmt.RootCauseObsAuditee = "";
            auditMgmt.CorrAction = "";
            auditMgmt.PrevAction = "";
            auditMgmt.OffResponsPrev = "";
            auditMgmt.OffResponsCorr = "";
            auditMgmt.DateofCompl = DateTime.Today;
            auditMgmt.DeviaSafetyStd = "";
            auditMgmt.Status = DocStatus.Open.ToString();
        }

        private void SetDefaultValue()
        {
            dtpDocDate.Value = DateTime.Today;
            txtDocBy.Text = GlobalDeclaration.UserName;
            txtStatus.Text = DocStatus.Prepare.ToString();
        }
        private void DisblePermanent()
        {
            txtDocNo.Enabled = false;
            txtDocBy.Enabled = false;
            txtStatus.Enabled = false;
            dtpDocDate.Enabled = false;
        }

        #endregion

        private void dgvViewAuditMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    public enum DocStatus
        {
            Prepare = 0,
            Open = 1,
            Closed = 2
        }
        public class AuditCalender
        {
            public string DocNo { set; get; }
            public DateTime DocDate { set; get; }
            public string CreatedBy { set; get; }
            public string AuditType { set; get; }
            public string Dept { set; get; }
            public string DeptId { set; get; }
            //public string Area { set; get; }
            //public string AreaId { set; get; }
            public string Month { set; get; }
            public string Year { set; get; }
            public string Quarter { set; get; }
            public string Auditor { set; get; }
            public string AuditorId { set; get; }
            public string Auditee { set; get; }
            public string AuditeeId { set; get; }
            public DateTime TargetDate { set; get; }
            public DateTime TentativeDate { set; get; }
            public DateTime AuditDate { set; get; }
            public DocStatus Status { set; get; }
        }
    }

