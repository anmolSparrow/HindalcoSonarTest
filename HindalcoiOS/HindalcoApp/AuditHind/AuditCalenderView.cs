using DevExpress.XtraEditors;
using Newtonsoft.Json;
//using Newtonsoft.Json;
using HindalcoiOS.Class_Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;
using SparrowRMS;
using System.Text.RegularExpressions;
using System.Threading;
using System.ComponentModel.DataAnnotations;

namespace HindalcoiOS.AuditHind
{
    public partial class AuditCalenderView : XtraForm
    {
        public AuditCalender auditCalender { get; set; }
        //public DataTable DepartmentList { set; get; }
        //public DataTable LoadAllUsers { set; get; }
        public string UserId { set; get; }
        public int RoleId { set; get; }
        public Guid auditPlanId { get; set; }
        public int iCount { set; get; }
        public Boolean IsValid { set; get; }
        public int PrevTabIndex { set; get; }
        public string AuditGlobalCode { set; get; }
        public AuditCalenderView()
        {
            InitializeComponent();
            auditCalender = new AuditCalender();
            UserId = GlobalDeclaration._holdInfo[0].UserId.ToString();// Properties.Settings.Default.UserID; //GetUserId(GlobalDeclaration.UserName);
            RoleId = Properties.Settings.Default.RoleID;
        }

        #region Controls Handler-----------
        private void btnAuditGen_Click(object sender, EventArgs e)
        {
            GetOptionPopUp();
        }
        private void dgvViewAuditMaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
               AuditHelper.ValidateTokenExpiration();
                ResetControls();
                txtAuditCode.Text = dgvViewAuditPlan.Rows[e.RowIndex].Cells["AuditCode"].Value.ToString();
                dtpCreatedDate.Text = dgvViewAuditPlan.Rows[e.RowIndex].Cells["CreatedDate"].Value.ToString();
                if(dgvViewAuditPlan.Rows[e.RowIndex].Cells["CreatedBy"].Value!=null)
                txtCreatedBy.Text = dgvViewAuditPlan.Rows[e.RowIndex].Cells["CreatedBy"].Value.ToString();
                if (dgvViewAuditPlan.Rows[e.RowIndex].Cells["Auditor"].Value != null)
                    cmbAuditor.Text = dgvViewAuditPlan.Rows[e.RowIndex].Cells["Auditor"].Value.ToString();
                if (dgvViewAuditPlan.Rows[e.RowIndex].Cells["TargetClosDate"].Value != null)
                    dtpTrgtClosDate.Text = dgvViewAuditPlan.Rows[e.RowIndex].Cells["TargetClosDate"].Value.ToString();
                if (dgvViewAuditPlan.Rows[e.RowIndex].Cells["AuditEndDate"].Value != null)
                {
                    dtpAudEndDate.Value = Convert.ToDateTime(dgvViewAuditPlan.Rows[e.RowIndex].Cells["AuditEndDate"].Value.ToString());
                }
                if (dgvViewAuditPlan.Rows[e.RowIndex].Cells["AuditStartDate"].Value != null)
                    dtpAudStartDate.Value = Convert.ToDateTime(dgvViewAuditPlan.Rows[e.RowIndex].Cells["AuditStartDate"].Value.ToString());
                if (dgvViewAuditPlan.Rows[e.RowIndex].Cells["AudMonth"].Value==null)
                {
                    cmbAuditMonth.Text = "NA";
                }
                else
                {
                    cmbAuditMonth.Text = dgvViewAuditPlan.Rows[e.RowIndex].Cells["AudMonth"].Value.ToString();
                }
                txtOpUnit.Text = dgvViewAuditPlan.Rows[e.RowIndex].Cells["OperationUnit"].Value.ToString();
                txtAudDept.Text = dgvViewAuditPlan.Rows[e.RowIndex].Cells["Department"].Value.ToString();
                txtFinQtr.Text = dgvViewAuditPlan.Rows[e.RowIndex].Cells["FinQuarter"].Value.ToString();
                txtAuditType.Text = dgvViewAuditPlan.Rows[e.RowIndex].Cells["AuditType"].Value.ToString();
                if (dgvViewAuditPlan.Rows[e.RowIndex].Cells["Auditee"].Value != null)
                    cmbAuditee.Text = dgvViewAuditPlan.Rows[e.RowIndex].Cells["Auditee"].Value.ToString();
                if (dgvViewAuditPlan.Rows[e.RowIndex].Cells["AuditCommMem"].Value != null)
                    cmbAudCommMem.Text = dgvViewAuditPlan.Rows[e.RowIndex].Cells["AuditCommMem"].Value.ToString();
                txtFinYear.Text = dgvViewAuditPlan.Rows[e.RowIndex].Cells["FinYear"].Value.ToString();
                txtStatus.Text = dgvViewAuditPlan.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                auditPlanId =Guid.Parse( dgvViewAuditPlan.Rows[e.RowIndex].Cells["AuditPlanId"].Value.ToString());
                LoadUsers();
               
                //MapControlToObject(auditCalender);
                if(txtStatus.Text==DocStatus.Prepare.ToString())
                {
                    GetAuditMonths();
                }
                if (RoleId==13)
                EnableControlForCommHead();
                else if (RoleId == 14)
                EnableControlForCommMem();
                HideShowActioncontrol();
                EnableDisableInputControl();
                dtpAudEndDate.Enabled = false;
                Thread.Sleep(1000);
                AuditPlanPages.SelectedIndex = 1;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void AuditCalender_Load(object sender, EventArgs e)
        {
            GlobalDeclaration.HideTabCtrlPagesHeader(AuditPlanPages);
            AuditHelper.ValidateTokenExpiration();
            dtpAudEndDate.Value = new DateTime(new DateTime(DateTime.Now.Year, 04, 01).AddYears(1).Year, 03, 15);
            AuditHelper.LoadDepartmentsToCombo(cmbDept);
            //if (GlobalDeclaration.TokenExpiredOn < DateTime.Now)
            //{
            //    UserModel usrModel = new UserModel();
            //    usrModel.UserName = Properties.Settings.Default.UserName;
            //    usrModel.Uid = int.Parse(Properties.Settings.Default.UserID);
            //    usrModel.Password = Properties.Settings.Default.Password;
            //    await AuditHelper.GetToken(usrModel);
            //}
            ///PopulateData();
            if (RoleId == 11)
            {
                AuditPlanPages.SelectedIndex = 2;
               await GetAuditCalenderDH(UserId);
                PrevTabIndex = AuditPlanPages.SelectedIndex;
            }
            if (RoleId == 13)
            {
                AuditPlanPages.SelectedIndex = 0;
              await  GetAuditCalenderById(UserId);
                PrevTabIndex = AuditPlanPages.SelectedIndex;
            }
            if (RoleId == 14)
            {
                AuditPlanPages.SelectedIndex = 0;
             await  GetAuditCalByAuditCommMem(UserId);
                PrevTabIndex = AuditPlanPages.SelectedIndex;
            }
            HideShowActioncontrol();
            NavigateActionControl();
            AuditHelper.LoadFinYear(chkCmbYear);
            
        }

        private  void btnAudPlan_Click(object sender, EventArgs e)
        {
            AuditPlanPages.SelectedIndex = 0;
            AuditHelper.ValidateTokenExpiration();
            //ValidateToken();
            //if (IsValid == false)
            //{
            //    MessageBox.Show("Invalid Token.");
            //    return;
            //}
            PopulateData();
            PrevTabIndex = 0;

        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            AuditPlanPages.SelectedIndex = PrevTabIndex;
            if(PrevTabIndex==0)
            {
                if (RoleId == 13)
                {
                    AuditPlanPages.SelectedIndex = 0;
                    GetAuditCalenderById(UserId);
                }
                if (RoleId == 14)
                {
                    AuditPlanPages.SelectedIndex = 0;
                    GetAuditCalByAuditCommMem(UserId);
                }
            }
            else if(PrevTabIndex == 2)
            {
                if (RoleId == 11)
                {
                    AuditPlanPages.SelectedIndex = 2;
                    GetAuditCalenderDH(UserId);
                }
            }
            else if (PrevTabIndex == 3)
            {
                PopulateClosedData();
            }
        }
        //private void btnReportAudit_Click(object sender, EventArgs e)
        //{
        //    if (RoleId == 11 && txtStatus.Text == DocStatus.PlanSubmitted.ToString())
        //    {
               
                
        //            if (ValidateAudeteeLogin() == false) return;
        //            DialogResult dr = MessageBox.Show("Are you sure to submit?", "Alert", MessageBoxButtons.YesNo);
        //            if (dr == DialogResult.No) return;
        //            MapControlToObject(auditCalender);
        //            auditCalender.DocStatus = DocStatusValueToInt(DocStatus.PlanSubmitted.ToString());
        //            UpdateAuditCalendar(auditCalender);
        //            DisableAllControl();
        //            HideShowActioncontrol();
        //            //Creating new Audit Management Object
        //            CreateNewAuditMgmt();
        //    }
           
        //    //input code for saving in database
        //}
        private void AuditGenOptionHandlerEvent(params object[] objec)
        {
            string ss = objec[0].ToString();
            GenerateAudit(objec[0].ToString(), objec[1].ToString(), objec[2].ToString(), objec[3].ToString());
            
        }
        private async void btnAuditUpd_Click(object sender, EventArgs e)
        {
           //Commitee head Section
            if (RoleId == 13 && txtStatus.Text==DocStatus.Prepare.ToString())
            {
                if (ValidateCommHeadLogin() == false) return;
                DialogResult dr = MessageBox.Show("Are you certain to save?","", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;
                MapControlToObject();
                auditCalender.DocStatus = GlobalDeclaration.DocStatusValueToInt(DocStatus.Open.ToString());

                await  UpdateAuditCalendar(auditCalender,"Record saved sucessfully");
                txtStatus.Text = DocStatus.Open.ToString();
                DisableAllControl();
                HideShowActioncontrol();
               
            }
            // Auditee (DH) Section
            if (RoleId == 11)
            {
               if(txtStatus.Text == DocStatus.Open.ToString())
                  {
                    if (ValidateAudeteeLogin() == false) return;
                    DialogResult dr = MessageBox.Show("Are you sure to freeze plan?", "", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.No) return;
                    MapControlToObject(auditCalender);
                    auditCalender.DocStatus = GlobalDeclaration.DocStatusValueToInt(DocStatus.Freezed.ToString());
                    UpdateAuditCalendar(auditCalender,"Plan freezed sucessfully");
                    txtStatus.Text = DocStatus.Freezed.ToString();
                    DisableAllControl();
                    HideShowActioncontrol();
                    //Creating new Audit Management Object
                    CreateNewAuditMgmt();
                    //MessageBox.Show("Audit Reported Successfully.");

                }
               
                HideShowActioncontrol();
            }

        }
      
        

        #endregion

        #region Methods-----------------
        public  AuditGenOption GetOptionPopUp()
        {
            AuditGenOption adtGenOption = new AuditGenOption();// (txtProcDocNo.Text);

            adtGenOption.GetValue += AuditGenOptionHandlerEvent;

            if (adtGenOption.ShowDialog() == DialogResult.OK)
            {
                
                adtGenOption.Close();
                adtGenOption.Dispose();
            }
            if (RoleId == 13)// && txtStatus.Text == DocStatus.Open.ToString())
            {
                //GetAuditCalenderById(UserId);
            }
            return adtGenOption;
        }
        public async void GenerateAudit(string audType, string audyear,string audQtr,string ounit)
        {
            int adCount = 0;
            //string audFormat = string.Format("AUD", audyear, audType);
            //DataTable deptList = new DataTable();
            foreach (DataRow dr in Properties.Settings.Default.Departments.Rows)
            {
                AuditCalender audPlan = null;
                //if (CheckAuditCalData(dr["Dept_Name"].ToString(), audType, audyear, audQtr) > 0) continue;
               await CheckAuditCalData(GlobalDeclaration.GetDeptId(dr["Dept_Name"].ToString()), audType, audyear, audQtr);
                if (iCount > 0) continue;
               
                audPlan = new AuditCalender();
                audPlan.AuditplanId = Guid.NewGuid();
                await GenerateGlobalClassCode("AUD", "AuditCalendar", audyear,audType);// "AUDCAL/111/23-24"; //GlobalDeclaration.GenerateGlobalDocID("", "AUDCAL");
                audPlan.AuditCode = AuditGlobalCode;
                audPlan.CreatedDate = DateTime.Today;
                audPlan.CreatedBy = GlobalDeclaration._holdInfo[0].UserId.ToString();
                audPlan.FinancialYear = audyear;
                audPlan.FinancialQuarter = audQtr;
                audPlan.AuditType = audType;
                audPlan.AuditClosureDate = DateTime.Today;
                audPlan.AuditStartDate = DateTime.Today;
                audPlan.AuditEndDate = new DateTime(new DateTime(DateTime.Now.Year, 04, 01).AddYears(1).Year, 03, 15);
                //new DateTime(DateTime.Today.AddYears(1).Year,03,15);
                audPlan.DepartmentId = int.Parse(dr["DeptId"].ToString());
                audPlan.OperationUnit = ounit;
                audPlan.DocStatus =(int) DocStatus.Prepare;
                audPlan.AuditorId = "NA";
                audPlan.AuditeeId = "NA";
                audPlan.CommitteeMemId = "NA";
                audPlan.AuditPlanUpdatedBy = "NA";
                audPlan.AuditPlanUpdatedDate = DateTime.Today;
                audPlan.ExpectedClosureMonth = "NA";
                adCount = +1;
                //insert planning data method;
                if (adCount > 0)
                   await AddAuditCalender(audPlan);
            }

            //Get planning data;
            if (adCount == 0)
                MessageBox.Show("Audit planning already generated for the selected parameters.");
            if (adCount>0)
                MessageBox.Show("Audit plan generated successfully.");
            PopulateData();
            //AuditPlanPages.SelectedIndex = 0;
            ////DialogResult = DialogResult.OK;
        }
       
        private async void CreateNewAuditMgmt()
        {
           await CheckAuditMgmtData(auditPlanId);
            if (iCount > 0)
            {
                XtraMessageBox.Show("Record already exist!");
                return;
            }
                AuditManagement auditMgmt = null;
            auditMgmt = new AuditManagement();
            //Change on 16 May
            ////await GenerateGlobalClassCode("ADMGMT", "AuditManagement", txtFinYear.Text);
            auditMgmt.AuditCode = txtAuditCode.Text; //AuditGlobalCode;
            auditMgmt.AuditManId = Guid.NewGuid();
            auditMgmt.AuditPlanID = auditPlanId;
            auditMgmt.CreatedDate = dtpCreatedDate.Value;
            auditMgmt.AuditType = txtAuditType.Text;
            auditMgmt.ExpectedAuditMonth = cmbAuditMonth.Text;
            auditMgmt.FinancialYear = txtFinYear.Text;
            auditMgmt.FinancialQuarter = txtFinQtr.Text;
            auditMgmt.OperationUnit = txtOpUnit.Text;
            auditMgmt.DepartmentId = GlobalDeclaration.GetDeptId(txtAudDept.Text);
            auditMgmt.CreatedBy =GlobalDeclaration.GetUserId(txtCreatedBy.Text);
            auditMgmt.AreaId = "NA";
            auditMgmt.CommiteeMemId = GlobalDeclaration.GetUserId(cmbAudCommMem.Text);
            auditMgmt.AuditorId = GlobalDeclaration.GetUserId(cmbAuditor.Text);
            auditMgmt.AuditeeId = GlobalDeclaration.GetUserId(cmbAuditee.Text);
            auditMgmt.AuditClosureDate = dtpTrgtClosDate.Value;
            auditMgmt.AuditStartDate = dtpAudStartDate.Value;
            auditMgmt.AuditEndDate = dtpAudEndDate.Value;
            auditMgmt.AuditPlanUpdatedBy = GlobalDeclaration.GetUserId(cmbAuditee.Text);
            auditMgmt.AuditPlanUpdatedDate = DateTime.Today;
            auditMgmt.Status =(int) DocStatus.Open;
            AddAuditMgmt(auditMgmt);
        }


        private async Task<string> AddAuditCalender(AuditCalender audcalender)
        {
            var responseString = string.Empty;
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var myContent = JsonConvert.SerializeObject(audcalender);
                    var requestContent = new StringContent(myContent, Encoding.UTF8, "application/json");
                    // var content = new FormUrlEncodedContent(auditCalendar);
                    string url= "https://hindalcoams.sparrowios.com/SaveAuditPlan?Token="+GlobalDeclaration.ApiToken;
                    var response = await httpClient.PostAsync(GlobalDeclaration.CleanURL(url), requestContent);
                    responseString = await response.Content.ReadAsStringAsync();
                    //  var createdCompany = JsonSerializer.Deserialize<AuditCategory>(responseString,);
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        Console.WriteLine(response.StatusCode.ToString());
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        Console.WriteLine("Record Saved");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return responseString;
        }

        private async Task<List<AuditCalender>> GetAuditCalenderById(string CreatedById)
        {
            List<AuditCalender> ams = new List<AuditCalender>();
            try
            {
                using (var httpClient = new HttpClient())
                {

                    string url ="https://hindalcoams.sparrowios.com/" + "GetAuditPlanById/{CreatedBy}" + "?CreatorId=" + CreatedById + "&Token=" + GlobalDeclaration.ApiToken.ToString();
                    url = GlobalDeclaration.CleanURL(url);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            ams = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditCalender>>(apiResponse);
                            BindAuditCalenderData(ams);
                        }
                        else
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                            {
                                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                                Console.WriteLine(response.StatusCode.ToString());
                            }
                        }
                    }
                    return ams;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return ams;
        }

        private async Task<List<AuditCalender>> GetAuditCalenderByAuditType(string auditType)
        {
            //AuditCalender ams = new AuditCalender();
            List<string> objList = new List<string>();
            List<AuditCalender> ams = new List<AuditCalender>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/GetAuditCalenderByAuditType/" + auditType;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            ams = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditCalender>>(apiResponse);
                            BindAuditCalenderData(ams);
                        }
                        else
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                            {
                                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                                Console.WriteLine(response.StatusCode.ToString());
                            }
                        }
                    }
                    return ams;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return ams;
        }

        private async Task<List<AuditCalender>> GetAuditCalenderByDept(string auditType)
        {
            //AuditCalender ams = new AuditCalender();
            List<string> objList = new List<string>();
            List<AuditCalender> ams = new List<AuditCalender>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/GetAuditCalenderByAuditType/" + auditType;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            ams = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditCalender>>(apiResponse);
                            BindAuditCalenderData(ams);
                        }
                        else
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                            {
                                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                                Console.WriteLine(response.StatusCode.ToString());
                            }
                        }
                    }
                    return ams;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return ams;
        }

        //private async Task<List<AuditCalender>> GetAuditCalenderByFinYear(string finYear)
        //{
        //    //AuditCalender ams = new AuditCalender();
        //    List<string> objList = new List<string>();
        //    List<AuditCalender> ams = new List<AuditCalender>();
        //    try
        //    {
        //        using (var httpClient = new HttpClient())
        //        {
        //            string url = "https://hindalcoams.sparrowios.com/GetAuditCalenderByFinYear/" + finYear;
        //            httpClient.DefaultRequestHeaders.Accept.Clear();
        //            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //            using (var response = await httpClient.GetAsync(url))
        //            {
        //                if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //                {
        //                    string apiResponse = await response.Content.ReadAsStringAsync();
        //                    ams = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditCalender>>(apiResponse);
        //                    BindAuditCalenderData(ams);
        //                }
        //                else
        //                {
        //                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        //                    {
        //                        response.StatusCode = System.Net.HttpStatusCode.NotFound;
        //                        Console.WriteLine(response.StatusCode.ToString());
        //                    }
        //                }
        //            }
        //            return ams;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }
        //    return ams;
        //}
        //private async Task<List<AuditCalender>> GetAuditCalenderByIdExt(string CreatedById)
        //{
        //    //AuditCalender ams = new AuditCalender();
        //    List<string> objList = new List<string>();
        //    List<AuditCalender> ams = new List<AuditCalender>();
        //    try
        //    {
        //        using (var httpClient = new HttpClient())
        //        {
        //            string url = "https://hindalcoams.sparrowios.com/" + "GetAuditPlanById/{CreatedBy}" + "?CreatorId=" + CreatedById;
        //            httpClient.DefaultRequestHeaders.Accept.Clear();
        //            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //            using (var response = await httpClient.GetAsync(url))
        //            {
        //                if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //                {
        //                    string apiResponse = await response.Content.ReadAsStringAsync();
        //                    ams = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditCalender>>(apiResponse);
        //                    BindAuditCalenderData(ams);
        //                    //DialogResult = DialogResult.OK;
        //                }
        //                else
        //                {
        //                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        //                    {
        //                        response.StatusCode = System.Net.HttpStatusCode.NotFound;
        //                        Console.WriteLine(response.StatusCode.ToString());
        //                    }
        //                }
        //            }
        //            return ams;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }
        //    return ams;
        //}

        private async Task<List<AuditCalender>> GetAuditCalenderByDHStatus(string AuditeeId, int status)
        {
            List<AuditCalender> ams = new List<AuditCalender>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/GetAuditCalendarDH?AuditeeId=" + AuditeeId + "&DocStatus=" + status+ "&Token="+GlobalDeclaration.ApiToken;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync(GlobalDeclaration.CleanURL(url)))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            // AuditCalender datalist = JsonConvert.DeserializeObject<AuditCalender>(apiResponse);
                            ams = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditCalender>>(apiResponse);
                            BindAuditCalClosedData(ams);
                        }
                        else
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                            {
                                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                                Console.WriteLine(response.StatusCode.ToString());
                            }
                        }
                    }
                    return ams;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return ams;
        }

        private async Task<List<AuditCalender>> GetAuditCalenderCreatedByStatus(string CreatedById, int status)
        {
           List<AuditCalender> ams = new List<AuditCalender>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/GetAuditcalDataCreatedByStatus/{CreatedBy}?CreatorId="+ CreatedById + "&Status=" + status+ "&Token="+GlobalDeclaration.ApiToken;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync(GlobalDeclaration.CleanURL(url)))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            ams = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditCalender>>(apiResponse);
                            BindAuditCalClosedData(ams);
                        }
                        else
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                            {
                                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                                Console.WriteLine(response.StatusCode.ToString());
                            }
                        }
                    }
                    return ams;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return ams;
        }

        private async Task<List<AuditCalender>> GetAuditCalenderDH(string AuditeeId)
        {
            //AuditCalender ams = new AuditCalender();
            List<string> objList = new List<string>();
           List<AuditCalender> aDms = new List<AuditCalender>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/GetAuditCalendarDHExt?AuditeeId=" + AuditeeId+ "&Token="+GlobalDeclaration.ApiToken;
                    url= GlobalDeclaration.CleanURL(url);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            // AuditCalender datalist = JsonConvert.DeserializeObject<AuditCalender>(apiResponse);
                            aDms = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditCalender>>(apiResponse);
                            BindAuditCalAssignedData(aDms);
                        }
                        else
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                            {
                                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                                Console.WriteLine(response.StatusCode.ToString());
                            }
                        }
                    }
                    return aDms;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return aDms;
        }

        private async Task<List<AuditCalender>> GetAuditCalByAuditCommMem(string CommitteeMemId)
        {
            //AuditCalender ams = new AuditCalender();
            List<string> objList = new List<string>();
            List<AuditCalender> aDms = new List<AuditCalender>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/GetAuditCalByAuditCommMem?CommiteeMemId=" + CommitteeMemId+ "&Token="+GlobalDeclaration.ApiToken;
                    url = GlobalDeclaration.CleanURL(url);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            // AuditCalender datalist = JsonConvert.DeserializeObject<AuditCalender>(apiResponse);
                            aDms = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditCalender>>(apiResponse);
                            BindAuditCalenderData(aDms);
                        }
                        else
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                            {
                                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                                Console.WriteLine(response.StatusCode.ToString());
                            }
                        }
                    }
                    return aDms;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return aDms;
        }

        private async Task<List<AuditCalender>> GetAuditCalenderByCommMemIdStatus(string CommitteeMenId, int status)
        {
            List<AuditCalender> ams = new List<AuditCalender>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/GetAuditcalDataCommMemStatus/{CreatedBy}?CommitteeMenId="+ CommitteeMenId + "&Status=" + status+ "&Token="+GlobalDeclaration.ApiToken;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync(GlobalDeclaration.CleanURL(url)))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            ams = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditCalender>>(apiResponse);
                            BindAuditCalClosedData(ams);
                        }
                        else
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                            {
                                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                                Console.WriteLine(response.StatusCode.ToString());
                            }
                        }
                    }
                    return ams;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return ams;
        }

        private async Task<string> UpdateAuditCalendar(AuditCalender auditCalender,string msg)
        {
            var responseString = string.Empty;
            // AuditCalendar auditCalendar=new AuditCalendar();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/" + "UpdateAuditPlan" + "?AuditPlanId=" + auditCalender.AuditplanId+ "&Token="+GlobalDeclaration.ApiToken;
                    var myContent = JsonConvert.SerializeObject(auditCalender);
                    var requestContent = new StringContent(myContent, Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync(GlobalDeclaration.CleanURL(url), requestContent);
                    responseString = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        Console.WriteLine(response.StatusCode.ToString());
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        MessageBox.Show(msg);// "Record submitted successfully.");
                    }
                }
            }
            catch (Exception ex)
            {



            }
            return responseString;
        }

        private async Task<string> AddAuditMgmt(AuditManagement auditMgmt)
        {
            var responseString = string.Empty;
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var myContent = JsonConvert.SerializeObject(auditMgmt);
                    var requestContent = new StringContent(myContent, Encoding.UTF8, "application/json");
                    string url = "https://hindalcoams.sparrowios.com/SaveAuditManagement?Token=" + GlobalDeclaration.ApiToken;

                    var response = await httpClient.PostAsync(GlobalDeclaration.CleanURL(url), requestContent);
                    responseString = await response.Content.ReadAsStringAsync();
    
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        Console.WriteLine(response.StatusCode.ToString());
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        Console.WriteLine("Audit Reported Successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return responseString;
        }

        public async Task<string> GenerateGlobalClassCode(string AudCode, string AuditRequestType, string FinYear,string audType)
        {
            //AuditCalender ams = new AuditCalender();
            //List<string> objList = new List<string>();
            AuditGlobalCode = string.Empty;
            List<AuditCalender> aDms = new List<AuditCalender>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/GeneratAutoDocumentPlan?AudCode="+AudCode+"&AuditRequestType="+AuditRequestType+"&FinYear="+FinYear+"&AudType="+ audType+ "&Token="+GlobalDeclaration.ApiToken;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync(GlobalDeclaration.CleanURL(url)))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            // AuditCalender datalist = JsonConvert.DeserializeObject<AuditCalender>(apiResponse);
                            AuditGlobalCode = apiResponse;//.Replace('"','=').Replace("="," ").Trim();
                            
                        }
                        else
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                            {
                                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                                Console.WriteLine(response.StatusCode.ToString());
                            }
                        }
                    }
                    return AuditGlobalCode;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return AuditGlobalCode;
        }

        public async Task<string> CheckAuditCalData(int deptId, string audType, string year, string quarter)
        {
            //AuditCalender ams = new AuditCalender();
            //List<string> objList = new List<string>();
            iCount = 0;
            List<AuditCalender> aDms = new List<AuditCalender>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/CheckAuditData/{DepartmentId}?DepartmentId="+deptId+"&AuditType="+audType+"&AuditYear="+year+"&AuditQuarter="+quarter+ "&Token="+GlobalDeclaration.ApiToken;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync(GlobalDeclaration.CleanURL(url)))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            // AuditCalender datalist = JsonConvert.DeserializeObject<AuditCalender>(apiResponse);
                            iCount =int.Parse(apiResponse);
                            //BindAuditCalAssignedData(aDms);
                        }
                        else
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                            {
                                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                                Console.WriteLine(response.StatusCode.ToString());
                            }
                        }
                    }
                    return AuditGlobalCode;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return AuditGlobalCode;
        }

        public async Task<string> CheckAuditMgmtData(Guid AuditPlanId)
        {
            //AuditCalender ams = new AuditCalender();
            //List<string> objList = new List<string>();
            iCount = 0;
            List<AuditCalender> aDms = new List<AuditCalender>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/CheckAuditMgmt?AuditPlanId="+AuditPlanId.ToString()+ "&Token="+GlobalDeclaration.ApiToken;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync(GlobalDeclaration.CleanURL(url)))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            // AuditCalender datalist = JsonConvert.DeserializeObject<AuditCalender>(apiResponse);
                            iCount = int.Parse(apiResponse);
                            //BindAuditCalAssignedData(aDms);
                        }
                        else
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                            {
                                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                                Console.WriteLine(response.StatusCode.ToString());
                            }
                        }
                    }
                    return AuditGlobalCode;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return AuditGlobalCode;
        }

        private async Task<List<AuditCalender>> FilterAuditCalenderData(string roleName,AuditFilter audFilter)
        {
            List<AuditCalender> ams = new List<AuditCalender>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/GetAuditFilterData/RoleName?roleName="+roleName+"&Token="+GlobalDeclaration.ApiToken;
                    url = GlobalDeclaration.CleanURL(url);
                    //httpClient.DefaultRequestHeaders.Accept.Clear();
                    //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var myContent = JsonConvert.SerializeObject(audFilter);
                    var requestContent = new StringContent(myContent, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(url, requestContent);
                    //response = await response.Content.ReadAsStringAsync();

                   // using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            ams = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditCalender>>(apiResponse);
                            BindAuditCalenderData(ams);
                        }
                        else
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                            {
                                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                                if(dgvViewAuditPlan.Rows.Count>0)
                                dgvViewAuditPlan.Rows.Clear();
                                Console.WriteLine(response.StatusCode.ToString());
                            }
                        }
                    }
                    return ams;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return ams;
        }

        private void BindAuditCalenderData(List<AuditCalender> audCalList)
        {
            try
            {
                if (dgvViewAuditPlan.Rows.Count > 0)
                    dgvViewAuditPlan.Rows.Clear();
                //if (dt.Rows.Count > 0)
                {
                    //System.Windows.Forms.ProgressBar progressBar = new System.Windows.Forms.ProgressBar();
                    progressBar.Maximum = audCalList.Count / 10;
                    progressBar.Step = 1;
                    //progressBar.PointToScreen=
                    foreach (var item in audCalList)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        dgvViewAuditPlan.Rows.Add(dr);
                        AuditCalAppearance(dr, GlobalDeclaration.DocStatusEnumIntToValue(item.DocStatus));
                        int index = dgvViewAuditPlan.Rows.Count - 1;
                        dgvViewAuditPlan.Rows[index].Cells["AuditplanId"].Value = item.AuditplanId;
                        dgvViewAuditPlan.Rows[index].Cells["AuditCode"].Value = item.AuditCode;
                        dgvViewAuditPlan.Rows[index].Cells["CreatedDate"].Value = item.CreatedDate.ToString("dd-MMM-yyyy");
                        dgvViewAuditPlan.Rows[index].Cells["OperationUnit"].Value = item.OperationUnit;
                        dgvViewAuditPlan.Rows[index].Cells["Department"].Value = GlobalDeclaration.GetDeptName(item.DepartmentId);
                        dgvViewAuditPlan.Rows[index].Cells["AuditType"].Value = item.AuditType;
                        dgvViewAuditPlan.Rows[index].Cells["FinYear"].Value = item.FinancialYear;
                        dgvViewAuditPlan.Rows[index].Cells["FinQuarter"].Value = item.FinancialQuarter;
                        dgvViewAuditPlan.Rows[index].Cells["Status"].Value = GlobalDeclaration.DocStatusEnumIntToValue(item.DocStatus);
                        dgvViewAuditPlan.Rows[index].Cells["CreatedBy"].Value = GlobalDeclaration.GetUserName(item.CreatedBy);
                        dgvViewAuditPlan.Rows[index].Cells["Auditor"].Value = GlobalDeclaration.GetUserName(item.AuditorId);
                        dgvViewAuditPlan.Rows[index].Cells["Auditee"].Value = GlobalDeclaration.GetUserName(item.AuditeeId);
                        dgvViewAuditPlan.Rows[index].Cells["AuditCommMem"].Value = GlobalDeclaration.GetUserName(item.CommitteeMemId);
                        dgvViewAuditPlan.Rows[index].Cells["TargetClosDate"].Value = item.AuditClosureDate.ToString("dd-MMM-yyyy");
                        dgvViewAuditPlan.Rows[index].Cells["AuditStartDate"].Value = item.AuditStartDate.ToString("dd-MMM-yyyy");
                        dgvViewAuditPlan.Rows[index].Cells["AuditEndDate"].Value = item.AuditEndDate.ToString("dd-MMM-yyyy");
                        dgvViewAuditPlan.Rows[index].Cells["AudMonth"].Value = item.ExpectedClosureMonth;
                        dgvViewAuditPlan.Rows[index].Cells["AuditUpdatedOn"].Value = item.AuditPlanUpdatedDate.ToString("dd-MMM-yyyy");
                        progressBar.PerformStep();
                    }
                    dgvViewAuditPlan.Sort(dgvViewAuditPlan.Columns["AuditUpdatedOn"], ListSortDirection.Descending);
                    progressBar.Hide();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindAuditCalAssignedData(List<AuditCalender> audCalList)
        {
            try
            {
                 if (dgvAsgnAuditPlan.Rows.Count > 0)
                    dgvAsgnAuditPlan.Rows.Clear();
                //if (dt.Rows.Count > 0)
                {
                    foreach (var item in audCalList)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        dgvAsgnAuditPlan.Rows.Add(dr);
                        AuditCalAppearance(dr, GlobalDeclaration.DocStatusEnumIntToValue(item.DocStatus));
                        int index = dgvAsgnAuditPlan.Rows.Count - 1;
                        dgvAsgnAuditPlan.Rows[index].Cells["asgnAuditplanId"].Value = item.AuditplanId;
                        dgvAsgnAuditPlan.Rows[index].Cells["asgnAuditCode"].Value = item.AuditCode;
                        dgvAsgnAuditPlan.Rows[index].Cells["asgnCreatedDate"].Value = item.CreatedDate.ToString("dd-MMM-yyyy");
                        dgvAsgnAuditPlan.Rows[index].Cells["asgnOperationUnit"].Value = item.OperationUnit;
                        dgvAsgnAuditPlan.Rows[index].Cells["asgnDepartment"].Value = GlobalDeclaration.GetDeptName(item.DepartmentId);
                        dgvAsgnAuditPlan.Rows[index].Cells["asgnAuditType"].Value = item.AuditType;
                        dgvAsgnAuditPlan.Rows[index].Cells["asgnFinYear"].Value = item.FinancialYear;
                        dgvAsgnAuditPlan.Rows[index].Cells["asgnFinQuarter"].Value = item.FinancialQuarter;
                        dgvAsgnAuditPlan.Rows[index].Cells["asgnStatus"].Value = GlobalDeclaration.DocStatusEnumIntToValue(item.DocStatus);
                        dgvAsgnAuditPlan.Rows[index].Cells["asgnCreatedBy"].Value = GlobalDeclaration.GetUserName(item.CreatedBy);
                        dgvAsgnAuditPlan.Rows[index].Cells["asgnAuditor"].Value = GlobalDeclaration.GetUserName(item.AuditorId);
                        dgvAsgnAuditPlan.Rows[index].Cells["asgnAuditee"].Value = GlobalDeclaration.GetUserName(item.AuditeeId);
                        dgvAsgnAuditPlan.Rows[index].Cells["asgnTargetClosDate"].Value = item.AuditClosureDate.ToString("dd-MMM-yyyy");
                        dgvAsgnAuditPlan.Rows[index].Cells["asgnAuditStartDate"].Value = item.AuditStartDate.ToString("dd-MMM-yyyy");
                        dgvAsgnAuditPlan.Rows[index].Cells["asgnAuditEndDate"].Value = item.AuditEndDate.ToString("dd-MMM-yyyy");
                        dgvAsgnAuditPlan.Rows[index].Cells["asgnAuditCommMem"].Value = GlobalDeclaration.GetUserName(item.CommitteeMemId);
                        dgvAsgnAuditPlan.Rows[index].Cells["asgnAudMonth"].Value = item.ExpectedClosureMonth;
                    }
                    dgvAsgnAuditPlan.Sort(dgvAsgnAuditPlan.Columns["asgnCreatedDate"], ListSortDirection.Descending);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindAuditCalClosedData(List<AuditCalender> audCalList)
        {
            try
            {
                if (dgvClosedAuditPlan.Rows.Count > 0)
                    dgvClosedAuditPlan.Rows.Clear();
                //if (dt.Rows.Count > 0)
                {
                    foreach (var item in audCalList)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        dgvClosedAuditPlan.Rows.Add(dr);
                        int index = dgvClosedAuditPlan.Rows.Count - 1;
                        dgvClosedAuditPlan.Rows[index].Cells["closAuditplanId"].Value = item.AuditplanId;
                        dgvClosedAuditPlan.Rows[index].Cells["closAuditCode"].Value = item.AuditCode;
                        dgvClosedAuditPlan.Rows[index].Cells["closCreatedDate"].Value = item.CreatedDate.ToString("dd-MMM-yyyy"); ;
                        dgvClosedAuditPlan.Rows[index].Cells["closOperationUnit"].Value = item.OperationUnit;
                        dgvClosedAuditPlan.Rows[index].Cells["closDepartment"].Value = GlobalDeclaration.GetDeptName(item.DepartmentId);
                        dgvClosedAuditPlan.Rows[index].Cells["closAuditType"].Value = item.AuditType;
                        dgvClosedAuditPlan.Rows[index].Cells["closFinYear"].Value = item.FinancialYear;
                        dgvClosedAuditPlan.Rows[index].Cells["closFinQuarter"].Value = item.FinancialQuarter;
                        dgvClosedAuditPlan.Rows[index].Cells["closStatus"].Value = GlobalDeclaration.DocStatusEnumIntToValue(item.DocStatus);
                        dgvClosedAuditPlan.Rows[index].Cells["closCreatedBy"].Value = GlobalDeclaration.GetUserName(item.CreatedBy);
                        dgvClosedAuditPlan.Rows[index].Cells["closAuditor"].Value = GlobalDeclaration.GetUserName(item.AuditorId);
                        dgvClosedAuditPlan.Rows[index].Cells["closAuditee"].Value = GlobalDeclaration.GetUserName(item.AuditeeId);
                        //dgvClosedAuditPlan.Rows[index].Cells["closCreatedBy"].Value = GetUserName(item.CreatedBy);
                        dgvClosedAuditPlan.Rows[index].Cells["closTargetClosDate"].Value = item.AuditClosureDate.ToString("dd-MMM-yyyy");
                        dgvClosedAuditPlan.Rows[index].Cells["closAuditStartDate"].Value = item.AuditStartDate.ToString("dd-MMM-yyyy");
                        dgvClosedAuditPlan.Rows[index].Cells["closAuditEndDate"].Value = item.AuditEndDate.ToString("dd-MMM-yyyy");
                        dgvClosedAuditPlan.Rows[index].Cells["closAuditCommMem"].Value = GlobalDeclaration.GetUserName(item.CommitteeMemId);
                        dgvClosedAuditPlan.Rows[index].Cells["closAudMonth"].Value = item.ExpectedClosureMonth;
                        dgvClosedAuditPlan.Rows[index].Cells["closAudUpdatedOn"].Value = item.AuditPlanUpdatedDate.ToString("dd-MMM-yyyy");

                    }
                    dgvClosedAuditPlan.Sort(dgvClosedAuditPlan.Columns["closAudUpdatedOn"], ListSortDirection.Descending);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PopulateData()
        {
            if (RoleId == 11)
            {
                AuditPlanPages.SelectedIndex = 2;
                GetAuditCalenderDH(UserId);
                PrevTabIndex = AuditPlanPages.SelectedIndex;
            }
            if (RoleId == 13)
            {
                AuditPlanPages.SelectedIndex = 0;
                GetAuditCalenderById(UserId);
                PrevTabIndex = AuditPlanPages.SelectedIndex;
            }
            if (RoleId == 14)
            {
                AuditPlanPages.SelectedIndex = 0;
                GetAuditCalByAuditCommMem(UserId);
                PrevTabIndex = AuditPlanPages.SelectedIndex;
            }
        }

        public void PopulateClosedData()
        {
            if (RoleId == 11)
            {
                GetAuditCalenderByDHStatus(UserId, (int)DocStatus.Closed);
                AuditPlanPages.SelectedIndex = 3;
                PrevTabIndex = AuditPlanPages.SelectedIndex;
            }
            if (RoleId == 13)
            {
                AuditPlanPages.SelectedIndex = 3;
                GetAuditCalenderCreatedByStatus(UserId, (int)DocStatus.Closed);
                PrevTabIndex = AuditPlanPages.SelectedIndex;
            }
            if (RoleId == 14)
            {
                AuditPlanPages.SelectedIndex = 3;
                GetAuditCalenderByCommMemIdStatus(UserId, (int)DocStatus.Closed);
                PrevTabIndex = AuditPlanPages.SelectedIndex;
            }
        }

        
       
        private void EnableDisableInputControl()
        {
            cmbAuditor.Visible = false;
            lblAuditor.Visible = false;
            if (RoleId == 13)
            {
                if (txtStatus.Text == DocStatus.Prepare.ToString() || txtStatus.Text == DocStatus.Open.ToString())
                {
                    lblAuditor.Visible = false;
                    cmbAuditor.Visible = false;
                }
                else
                {
                    lblAuditor.Visible = true;
                    if (!string.IsNullOrWhiteSpace(cmbAuditor.Text))
                    {
                        cmbAuditor.Visible = true;
                        lblAuditor.Visible = true;
                    }
                    cmbAuditor.Enabled = false;
                    cmbAuditee.Enabled = false;
                    dtpAudStartDate.Enabled = false;
                    dtpTrgtClosDate.Enabled = false;
                    cmbAuditMonth.Enabled = false;
                    cmbAudCommMem.Enabled = false;
                }
                //if (txtStatus.Text == DocStatus.Open.ToString())// || txtStatus.Text == DocStatus.Open.ToString())
                //{
                //    lblAuditor.Visible = false;
                //    cmbAuditor.Visible = false;
                //}
                //else
                //{
                //    lblAuditor.Visible = true;
                //    cmbAuditor.Visible = true;
                //    cmbAuditor.Enabled = false;
                //    cmbAuditee.Enabled = false;
                //    cmbAuditMonth.Enabled = false;
                //    cmbAudCommMem.Enabled = false;
                //}
            }
            if (RoleId == 11)// && txtStatus.Text == DocStatus.Prepare.ToString())
            {
                cmbAuditor.Visible = true;
                lblAuditor.Visible = true;
                lblAudCommMem.Visible = true;
                if (txtStatus.Text == DocStatus.Open.ToString())
                {
                    dtpAudEndDate.Enabled = false;
                    cmbAudCommMem.Enabled = false;
                }
                if (txtStatus.Text == DocStatus.Freezed.ToString()|| txtStatus.Text == DocStatus.Closed.ToString() || txtStatus.Text == DocStatus.Submitted.ToString())
                {
                    cmbAuditor.Enabled = false;
                    cmbAudCommMem.Enabled = false;
                }
            }
            if (RoleId == 14)
            {
                if (!string.IsNullOrWhiteSpace(cmbAuditor.Text))
                {
                    cmbAuditor.Visible = true;
                    lblAuditor.Visible = true;
                }
            }
        }

        private void MapControlToObject(AuditCalender audCalender)
        {
            //audCalender = null;
            //audCalender = new AuditCalender();
            auditCalender.AuditplanId = auditPlanId;
            audCalender.AuditCode = txtAuditCode.Text;
            audCalender.CreatedDate = dtpCreatedDate.Value;
            audCalender.CreatedBy = GlobalDeclaration.GetUserId(txtCreatedBy.Text) ;
            audCalender.ExpectedClosureMonth = cmbAuditMonth.Text;
            audCalender.FinancialYear = txtFinYear.Text;
            audCalender.FinancialQuarter = txtFinQtr.Text;
            audCalender.AuditType = txtAuditType.Text;
            audCalender.AuditClosureDate = dtpTrgtClosDate.Value;
            audCalender.AuditStartDate = dtpAudStartDate.Value;
            audCalender.AuditEndDate = dtpAudEndDate.Value;
            audCalender.DepartmentId = GlobalDeclaration.GetDeptId(txtAudDept.Text);
            audCalender.OperationUnit = txtOpUnit.Text;
            if (string.IsNullOrEmpty(cmbAuditor.Text))
               audCalender.AuditorId = "NA";
            else
            audCalender.AuditorId = GlobalDeclaration.GetUserId(cmbAuditor.Text);
            if (string.IsNullOrEmpty(cmbAuditee.Text))
                audCalender.AuditeeId = "NA";
            else
                audCalender.AuditeeId = GlobalDeclaration.GetUserId(cmbAuditee.Text);
            //audCalender.AuditorId = cmbAuditor.Text;
            if (string.IsNullOrEmpty(cmbAudCommMem.Text))
                audCalender.CommitteeMemId = "NA";
            else
                audCalender.CommitteeMemId = GlobalDeclaration.GetUserId(cmbAudCommMem.Text);
                audCalender.AuditPlanUpdatedBy = GlobalDeclaration.GetUserId(GlobalDeclaration.UserName);
            auditCalender.AuditPlanUpdatedDate = DateTime.Today;
            audCalender.DocStatus = GlobalDeclaration.DocStatusValueToInt(txtStatus.Text);
        }

        private void MapControlToObject()
        {
            auditCalender = null;
            auditCalender = new AuditCalender();
            auditCalender.AuditplanId = auditPlanId;
            auditCalender.AuditCode = txtAuditCode.Text;
            auditCalender.CreatedDate = dtpCreatedDate.Value;
            auditCalender.CreatedBy = GlobalDeclaration.GetUserId(txtCreatedBy.Text);
            auditCalender.ExpectedClosureMonth = cmbAuditMonth.Text;
            auditCalender.FinancialYear = txtFinYear.Text;
            auditCalender.FinancialQuarter = txtFinQtr.Text;
            auditCalender.AuditType = txtAuditType.Text;
            auditCalender.AuditClosureDate = dtpTrgtClosDate.Value;
            auditCalender.AuditStartDate = dtpAudStartDate.Value;
            auditCalender.AuditEndDate = dtpAudEndDate.Value;
            auditCalender.DepartmentId = GlobalDeclaration.GetDeptId(txtAudDept.Text);
            auditCalender.OperationUnit = txtOpUnit.Text;
            if (string.IsNullOrEmpty(cmbAuditor.Text))
                auditCalender.AuditorId = "NA";
            else
                auditCalender.AuditorId = GlobalDeclaration.GetUserId(cmbAuditor.Text);
            if (string.IsNullOrEmpty(cmbAuditee.Text))
                auditCalender.AuditeeId = "NA";
            else
                auditCalender.AuditeeId = GlobalDeclaration.GetUserId(cmbAuditee.Text);
            auditCalender.AuditorId = cmbAuditor.Text;
            if (string.IsNullOrEmpty(cmbAudCommMem.Text))
                auditCalender.CommitteeMemId = "NA";
            else
                auditCalender.CommitteeMemId = GlobalDeclaration.GetUserId(cmbAudCommMem.Text);
            auditCalender.DocStatus = GlobalDeclaration.DocStatusValueToInt(txtStatus.Text);
            auditCalender.AuditPlanUpdatedDate = DateTime.Today;
        }
       

        public void LoadDepartments()
        {
            //DepartmentList = Properties.Settings.Default.Departments;
            foreach (DataRow dr in Properties.Settings.Default.Departments.Rows)
            {
                cmbDept.Items.Add(dr["Dept_Name"].ToString());
            }
        }

        private void LoadUsers()
        {
            DataTable dt = Properties.Settings.Default.AllUsers;// GlobalDeclaration.GetAllUsers() ;

            //Auditee User
            if (txtStatus.Text == DocStatus.Prepare.ToString())
            {
                if(cmbAuditee.Items.Count>0)
                {
                    cmbAuditee.Items.Clear();
                }
                DataTable dtAuditees = dt;
                if (dtAuditees.AsEnumerable().Where(a => a.Field<int>("RoleID") == 11 && a.Field<int>("DeptID") == GlobalDeclaration.GetDeptId(txtAudDept.Text)).Count() != 0)
                {
                    dtAuditees = dtAuditees.AsEnumerable().Where(a => a.Field<int>("RoleID") == 11 && a.Field<int>("DeptID") == GlobalDeclaration.GetDeptId(txtAudDept.Text)).ToList().CopyToDataTable();
                    for (int i = 0; i < dtAuditees.Rows.Count; i++)
                    {
                        cmbAuditee.Items.Add(dtAuditees.Rows[i]["UserName"]);
                    }
                }
            }
            
            // Auditor User-------------------------------------
            DataTable dtAuditors = dt;
            if (txtAuditType.Text == "L1")
            {
                if(dtAuditors.AsEnumerable().Where(a => a.Field<int>("RoleID") == 12 && a.Field<int>("DeptID") == GlobalDeclaration.GetDeptId(txtAudDept.Text)).ToList().Count!=0)
                dtAuditors = dtAuditors.AsEnumerable().Where(a => a.Field<int>("RoleID") == 12 && a.Field<int>("DeptID") == GlobalDeclaration.GetDeptId(txtAudDept.Text)).ToList().CopyToDataTable();
            }
            else if (txtAuditType.Text == "L2")
            {
                dtAuditors = dtAuditors.AsEnumerable().Where(a => a.Field<int>("RoleID") == 12 && a.Field<int>("DeptID") != GlobalDeclaration.GetDeptId(txtAudDept.Text)).ToList().CopyToDataTable();
            }
            if (cmbAuditor.Items.Count > 0)
            {
                cmbAuditor.Items.Clear();
            }
            for (int i = 0; i < dtAuditors.Rows.Count; i++)
             {
               cmbAuditor.Items.Add(dtAuditors.Rows[i]["UserName"]);
             }


            // CommiteeMember User-------------------------------------   
            DataTable dtAudCommMems = dt;
            dtAudCommMems = dtAudCommMems.AsEnumerable().Where(a => a.Field<int>("RoleID") == 14).ToList().CopyToDataTable();
            if (cmbAudCommMem.Items.Count > 0)
            {
                cmbAudCommMem.Items.Clear();
            }
            for (int i = 0; i < dtAudCommMems.Rows.Count; i++)
            {
                cmbAudCommMem.Items.Add(dtAudCommMems.Rows[i]["UserName"]);
            }
            
        }
        
        private void GetAuditMonths()
        {
            List<string> months = new List<string>();
            if(txtFinQtr.Text=="Q1")
            {
                months.Clear();
                months.Add("April");
                months.Add("May");
                months.Add("June");
            }
            if (txtFinQtr.Text == "Q2")
            {
                months.Clear();
                months.Add("July");
                months.Add("August");
                months.Add("September");
            }
            if (txtFinQtr.Text == "Q3")
            {
                months.Clear();
                months.Add("October");
                months.Add("November");
                months.Add("December");
            }
            if (txtFinQtr.Text == "Q4")
            {
                months.Clear();
                months.Add("January");
                months.Add("February");
                months.Add("March");
            }
           //if(cmbAuditMonth.Items.Count>0)
           // {
           //     cmbAuditMonth.Items.Clear();
           // }
            cmbAuditMonth.DataSource = null;
            cmbAuditMonth.DataSource = months;
            //return months;
        }
        #endregion

        private void btnAssigned_Click(object sender, EventArgs e)
        {
            AuditHelper.ValidateTokenExpiration();
            PopulateData();
            AuditPlanPages.SelectedIndex = 2;
            PrevTabIndex = 2;
        }
       
        private void HideShowActioncontrol()
        {
            btnAssigned.Visible = true;
            btnAuditUpd.Visible = true;
            btnAuditUpd.Text = "Update";

            if (RoleId == 13)
            {
                btnAssigned.Visible = false;
                btnReportAudit.Visible = false;
                if (txtStatus.Text == DocStatus.Prepare.ToString())
                {
                    btnAuditUpd.Visible = true;
                    //btnAuditUpd.Text = "Save";

                }
                if (txtStatus.Text == DocStatus.Open.ToString() || txtStatus.Text == DocStatus.Freezed.ToString()|| txtStatus.Text == DocStatus.Submitted.ToString() || txtStatus.Text == DocStatus.Closed.ToString())
                {
                    btnAuditUpd.Visible = false;
                }
            }
            if (RoleId == 11)// && txtStatus.Text == DocStatus.Prepare.ToString())
            {

                btnViewPlan.Visible = false;
                if (txtStatus.Text == DocStatus.Freezed.ToString())
                {
                    btnAuditUpd.Visible = false;
                    btnAuditUpd.Text = "Submit Plan";
                    //btnReportAudit.Visible = true;
                }
                if (txtStatus.Text == DocStatus.Submitted.ToString()|| txtStatus.Text == DocStatus.Closed.ToString())
                {
                    btnAuditUpd.Visible = false;
                    btnReportAudit.Visible = false;
                }
                if (txtStatus.Text == DocStatus.Open.ToString())
                {
                    btnAuditUpd.Visible = true;
                    btnAuditUpd.Text = "Assign";
                    btnReportAudit.Visible = false;
                }
            }
            if (RoleId == 14)// && txtStatus.Text == DocStatus.Prepare.ToString())
            {
                btnAssigned.Visible = false;
                btnReportAudit.Visible = false;
                btnGenAudit.Visible = false;
                btnAuditUpd.Visible = false;
            }
        }

        private void dgvAsgnAuditPlan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                //auditCalender = null;
                //auditCalender = new AuditCalender();

                txtAuditCode.Text = dgvAsgnAuditPlan.Rows[e.RowIndex].Cells["asgnAuditCode"].Value.ToString();
                dtpCreatedDate.Text = dgvAsgnAuditPlan.Rows[e.RowIndex].Cells["asgnCreatedDate"].Value.ToString();
                if (dgvAsgnAuditPlan.Rows[e.RowIndex].Cells["asgnCreatedBy"].Value != null)
                    txtCreatedBy.Text = dgvAsgnAuditPlan.Rows[e.RowIndex].Cells["asgnCreatedBy"].Value.ToString();
                if (dgvAsgnAuditPlan.Rows[e.RowIndex].Cells["asgnAuditor"].Value != null)
                    cmbAuditor.Text = dgvAsgnAuditPlan.Rows[e.RowIndex].Cells["asgnAuditor"].Value.ToString();
                if (dgvAsgnAuditPlan.Rows[e.RowIndex].Cells["asgnTargetClosDate"].Value != null)
                    dtpTrgtClosDate.Text = dgvAsgnAuditPlan.Rows[e.RowIndex].Cells["asgnTargetClosDate"].Value.ToString();
                if (dgvAsgnAuditPlan.Rows[e.RowIndex].Cells["asgnAuditEndDate"].Value != null)
                    dtpAudEndDate.Text = dgvAsgnAuditPlan.Rows[e.RowIndex].Cells["asgnAuditEndDate"].Value.ToString();
                if (dgvAsgnAuditPlan.Rows[e.RowIndex].Cells["asgnAuditStartDate"].Value != null)
                    dtpAudStartDate.Text = dgvAsgnAuditPlan.Rows[e.RowIndex].Cells["asgnAuditStartDate"].Value.ToString();

                cmbAuditMonth.Text = dgvAsgnAuditPlan.Rows[e.RowIndex].Cells["asgnAudMonth"].Value.ToString();
                txtOpUnit.Text = dgvAsgnAuditPlan.Rows[e.RowIndex].Cells["asgnOperationUnit"].Value.ToString();
                txtAudDept.Text = dgvAsgnAuditPlan.Rows[e.RowIndex].Cells["asgnDepartment"].Value.ToString();
                txtFinYear.Text = dgvAsgnAuditPlan.Rows[e.RowIndex].Cells["asgnFinYear"].Value.ToString();
                txtFinQtr.Text = dgvAsgnAuditPlan.Rows[e.RowIndex].Cells["asgnFinQuarter"].Value.ToString();
                txtAuditType.Text = dgvAsgnAuditPlan.Rows[e.RowIndex].Cells["asgnAuditType"].Value.ToString();
                if (dgvAsgnAuditPlan.Rows[e.RowIndex].Cells["asgnAuditee"].Value != null)
                    cmbAuditee.Text = dgvAsgnAuditPlan.Rows[e.RowIndex].Cells["asgnAuditee"].Value.ToString();
                if (dgvAsgnAuditPlan.Rows[e.RowIndex].Cells["asgnAuditCommMem"].Value != null)
                    cmbAudCommMem.Text = dgvAsgnAuditPlan.Rows[e.RowIndex].Cells["asgnAuditCommMem"].Value.ToString();
                txtStatus.Text = dgvAsgnAuditPlan.Rows[e.RowIndex].Cells["asgnStatus"].Value.ToString();
                auditPlanId = Guid.Parse(dgvAsgnAuditPlan.Rows[e.RowIndex].Cells["asgnAuditPlanId"].Value.ToString());

                AuditPlanPages.SelectedIndex = 1;
                LoadUsers();
                EnableControlForAuditee();
                HideShowActioncontrol();
                EnableDisableInputControl();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClosed_Click(object sender, EventArgs e)
        {
            PrevTabIndex = 3;
            AuditHelper.ValidateTokenExpiration();
            PopulateClosedData();
            
        }

        private void dgvClosedAuditPlan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                //auditCalender = null;
                //auditCalender = new AuditCalender();
                AuditHelper.ValidateTokenExpiration();
                txtAuditCode.Text = dgvClosedAuditPlan.Rows[e.RowIndex].Cells["closAuditCode"].Value.ToString();
                dtpCreatedDate.Text = dgvClosedAuditPlan.Rows[e.RowIndex].Cells["closCreatedDate"].Value.ToString();
                if (dgvClosedAuditPlan.Rows[e.RowIndex].Cells["closCreatedBy"].Value != null)
                    txtCreatedBy.Text = dgvClosedAuditPlan.Rows[e.RowIndex].Cells["closCreatedBy"].Value.ToString();
                if (dgvClosedAuditPlan.Rows[e.RowIndex].Cells["closAuditor"].Value != null)
                    cmbAuditor.Text = dgvClosedAuditPlan.Rows[e.RowIndex].Cells["closAuditor"].Value.ToString();
                if (dgvClosedAuditPlan.Rows[e.RowIndex].Cells["closTargetClosDate"].Value != null)
                    dtpTrgtClosDate.Text = dgvClosedAuditPlan.Rows[e.RowIndex].Cells["closTargetClosDate"].Value.ToString();
                if (dgvClosedAuditPlan.Rows[e.RowIndex].Cells["closAuditEndDate"].Value != null)
                    dtpAudEndDate.Text = dgvClosedAuditPlan.Rows[e.RowIndex].Cells["closAuditEndDate"].Value.ToString();
                if (dgvClosedAuditPlan.Rows[e.RowIndex].Cells["closAuditStartDate"].Value != null)
                    dtpAudStartDate.Text = dgvClosedAuditPlan.Rows[e.RowIndex].Cells["closAuditStartDate"].Value.ToString();
                cmbAuditMonth.Text = dgvClosedAuditPlan.Rows[e.RowIndex].Cells["closAudMonth"].Value.ToString();
                txtAudDept.Text = dgvClosedAuditPlan.Rows[e.RowIndex].Cells["closDepartment"].Value.ToString();
                txtOpUnit.Text = dgvClosedAuditPlan.Rows[e.RowIndex].Cells["closOperationUnit"].Value.ToString();
                txtFinQtr.Text = dgvClosedAuditPlan.Rows[e.RowIndex].Cells["closFinQuarter"].Value.ToString();
                txtAuditType.Text = dgvClosedAuditPlan.Rows[e.RowIndex].Cells["closAuditType"].Value.ToString();
                if (dgvClosedAuditPlan.Rows[e.RowIndex].Cells["closAuditee"].Value != null)
                    cmbAuditee.Text = dgvClosedAuditPlan.Rows[e.RowIndex].Cells["closAuditee"].Value.ToString();
                txtFinYear.Text = dgvClosedAuditPlan.Rows[e.RowIndex].Cells["closFinYear"].Value.ToString();
                txtStatus.Text = dgvClosedAuditPlan.Rows[e.RowIndex].Cells["closStatus"].Value.ToString();
                cmbAudCommMem.Text = dgvClosedAuditPlan.Rows[e.RowIndex].Cells["closAuditCommMem"].Value.ToString();
                auditPlanId = Guid.Parse(dgvClosedAuditPlan.Rows[e.RowIndex].Cells["closAuditPlanId"].Value.ToString());
                btnAuditUpd.Visible = false;
                //btnAdd.Text = "Update";
                //ViewDept();
                AuditPlanPages.SelectedIndex = 1;
                DisableAllControl();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Boolean ValidateCommHeadLogin()
        {
            bool IsValid = true;

            if (String.IsNullOrWhiteSpace(cmbAuditee.Text)|| cmbAuditee.Text=="NA")
            {
                XtraMessageBox.Show("Please Select [Auditee] !");
                IsValid = false;
                return IsValid;
            }
            else if (!string.IsNullOrWhiteSpace(cmbAuditee.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(cmbAuditee.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in [Check Points] !");
                    cmbAuditee.Focus();
                    IsValid = false;

                }
            }
            else if (String.IsNullOrWhiteSpace(cmbAuditMonth.Text)|| cmbAuditMonth.Text == "NA")
            {
                XtraMessageBox.Show("!Please fill [Expected Month of Audit]");
                IsValid = false;
            }
            else if (!string.IsNullOrWhiteSpace(cmbAuditMonth.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(cmbAuditMonth.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in [Expected Month of Audit]!");
                    cmbAuditMonth.Focus();
                    IsValid = false;
                }
            }
            return IsValid;
        }

        private Boolean ValidateAudeteeLogin()
        {
            bool IsValid = true;

            if (String.IsNullOrWhiteSpace(cmbAuditor.Text)|| cmbAuditor.Text == "NA")
            {
                XtraMessageBox.Show("Please Select [Auditor].");
                IsValid = false;
                return IsValid;
            }
            else if (!string.IsNullOrWhiteSpace(cmbAuditor.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(cmbAuditor.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in [Check Points] !");
                    cmbAuditor.Focus();
                    IsValid = false;
                }
            }
            else if (String.IsNullOrWhiteSpace(cmbAuditMonth.Text) || cmbAuditMonth.Text == "NA")
            {
                XtraMessageBox.Show("!Please fill [Expected Month of Audit]");
                IsValid = false;
            }
            else if (!string.IsNullOrWhiteSpace(cmbAuditMonth.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(cmbAuditMonth.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in [Expected Month of Audit]!");
                    cmbAuditMonth.Focus();
                    IsValid = false;
                }
            }
            return IsValid;
        }
        public void NavigateActionControl()
        {
            if (RoleId == 11)
            {
                btnClosed.Location = btnAssigned.Location;
                btnAssigned.Location = btnViewPlan.Location;
            }
           else if (RoleId == 13 || RoleId == 14)
            {
                btnClosed.Location = btnAssigned.Location;
                //btnAssigned.Location = btnViewPlan.Location;
            }
        }
        private void DisableAllControl()
        {
            txtAuditCode.Enabled = false;
            dtpCreatedDate.Enabled = false;
            txtCreatedBy.Enabled = false;
            cmbAuditMonth.Enabled = false;
            txtFinYear.Enabled = false;
            txtFinQtr.Enabled = false;
            txtAuditType.Enabled = false;
            dtpTrgtClosDate.Enabled = false;
            dtpAudStartDate.Enabled = false;
            dtpAudEndDate.Enabled = false;
            txtAudDept.Enabled = false;
            txtOpUnit.Enabled = false;
            cmbAuditor.Enabled = false;
            cmbAuditee.Enabled = false;
            cmbAudCommMem.Enabled = false;
            txtStatus.Enabled = false;
        }
        private void EnableControlForAuditee()
        {
            txtAuditCode.Enabled = false;
            dtpCreatedDate.Enabled = false;
            txtCreatedBy.Enabled = false;
            cmbAuditMonth.Enabled = false;
            txtFinYear.Enabled = false;
            txtFinQtr.Enabled = false;
            txtAuditType.Enabled = false;
            dtpTrgtClosDate.Enabled = false;
            dtpAudStartDate.Enabled = false;
            //dtpAudEndDate.Enabled = false;
            txtAudDept.Enabled = false;
            txtOpUnit.Enabled = false;
            cmbAuditor.Enabled = true;
            cmbAuditee.Enabled = false;
            cmbAudCommMem.Enabled = true;
            txtStatus.Enabled = false;
        }

        private void EnableControlForCommHead()
        {
            txtAuditCode.Enabled = false;
            dtpCreatedDate.Enabled = false;
            txtCreatedBy.Enabled = false;
            cmbAuditMonth.Enabled = true;
            txtFinYear.Enabled = false;
            txtFinQtr.Enabled = false;
            txtAuditType.Enabled = false;
            dtpTrgtClosDate.Enabled = true;
            dtpAudStartDate.Enabled = true;
            dtpAudEndDate.Enabled = true;
            txtAudDept.Enabled = false;
            txtOpUnit.Enabled = false;
            cmbAuditor.Enabled = true;
            cmbAuditee.Enabled = true;
            cmbAudCommMem.Enabled = true;
            txtStatus.Enabled = false;
        }

        private void EnableControlForCommMem()
        {
            txtAuditCode.Enabled = false;
            dtpCreatedDate.Enabled = false;
            txtCreatedBy.Enabled = false;
            cmbAuditMonth.Enabled = false;
            txtFinYear.Enabled = false;
            txtFinQtr.Enabled = false;
            txtAuditType.Enabled = false;
            dtpTrgtClosDate.Enabled = true;
            dtpAudStartDate.Enabled = true;
            dtpAudEndDate.Enabled = true;
            txtAudDept.Enabled = false;
            txtOpUnit.Enabled = false;
            cmbAuditor.Enabled = false;
            cmbAuditee.Enabled = false;
            cmbAudCommMem.Enabled = false;
            txtStatus.Enabled = false;
        }

        private void ResetControls()
        {
            txtAuditCode.Text = string.Empty;
            dtpCreatedDate.Text = string.Empty;
            txtCreatedBy.Text = string.Empty;
            cmbAuditMonth.Text = string.Empty;
            txtFinYear.Text = string.Empty;
            txtFinQtr.Text = string.Empty;
            txtAuditType.Text = string.Empty;
            dtpTrgtClosDate.Text = string.Empty;
            dtpAudStartDate.Text = string.Empty;
            dtpAudEndDate.Text = string.Empty;
            txtAudDept.Text = string.Empty;
            txtOpUnit.Text = string.Empty;
            cmbAuditor.Text = string.Empty;
            cmbAuditee.Text = string.Empty;
            cmbAudCommMem.Text = string.Empty;
            txtStatus.Text = string.Empty;
        }

        private void sparrowButton1_Click(object sender, EventArgs e)
        {
            CreateNewAuditMgmt();
        }
        /// <summary>
        /// Submit Plan to create Audit management
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnReportAudit_Click(object sender, EventArgs e)
        {
            if (txtStatus.Text == DocStatus.Freezed.ToString())
            {
                if (ValidateAudeteeLogin() == false) return;
                DialogResult dr = MessageBox.Show("Are you sure to submit plan?", "Alert", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;
                MapControlToObject(auditCalender);
                auditCalender.DocStatus = GlobalDeclaration.DocStatusValueToInt(DocStatus.Submitted.ToString());
                UpdateAuditCalendar(auditCalender,"Plan submitted sucessfully.");
                txtStatus.Text = DocStatus.Submitted.ToString();
                //DisableAllControl();
                //HideShowActioncontrol();
                //Creating new Audit Management Object
                CreateNewAuditMgmt();
                MessageBox.Show("Audit Reported Successfully.");
            }
        }
       
        private void dtpAudStartDate_ValueChanged(object sender, EventArgs e)
        {
            //dtpAudEndDate.Value = dtpAudStartDate.Value;
        }

        public void AuditCalAppearance(DataGridViewRow dr,string status)
        {
            if(status==DocStatus.Prepare.ToString())
            {
               if(RoleId==13)
                {
                    dr.DefaultCellStyle.BackColor = Color.Orange;
                }
                if (RoleId == 14)
                {
                    dr.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
            if (status == DocStatus.Open.ToString())
            {
                if (RoleId == 13 || RoleId == 14)
                {
                    dr.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                if (RoleId == 11)
                {
                    dr.DefaultCellStyle.BackColor = Color.Orange;
                }
            }
            if (status == DocStatus.Submitted.ToString())
            {
                if (RoleId == 13 || RoleId == 14 || RoleId == 11)
                {
                    dr.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
            if (status == DocStatus.Freezed.ToString())
            {
                if (RoleId == 13 || RoleId == 14 || RoleId == 11)
                {
                    dr.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
            if (status == DocStatus.Closed.ToString())
            {
                if (RoleId == 13 || RoleId == 14 || RoleId == 11)
                {
                    dr.DefaultCellStyle.BackColor = Color.Gray;
                }

            }

        }

        
       //public void LoadFinYear()
       // {
       //     chkCmbYear.Items.Add("16-17");
       //     chkCmbYear.Items.Add("17-18");
       //     chkCmbYear.Items.Add("18-19");
       //     chkCmbYear.Items.Add("19-20");
       //     chkCmbYear.Items.Add("20-21"); 
       //     chkCmbYear.Items.Add("21-22");
       //     chkCmbYear.Items.Add("22-23");
       //     chkCmbYear.Items.Add("23-24");
       //     chkCmbYear.Items.Add("24-25");
       //     chkCmbYear.Items.Add("25-26");
       //     chkCmbYear.Items.Add("26-27");
       //     chkCmbYear.Items.Add("27-28");
       //     chkCmbYear.Items.Add("28-29");
       //     chkCmbYear.Items.Add("29-30");
       // }
       
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            AuditFilter auditFilter = null;
            auditFilter = new AuditFilter();
            auditFilter.AuditType = cmbAuditType.Text;
            if(cmbDept.SelectedItem!=null)
            auditFilter.DepartmentId = GlobalDeclaration.GetDeptId(cmbDept.SelectedItem.ToString());
            string finYear=string.Empty;
            if (chkCmbYear.CheckedItems.Count > 0)
            {
                foreach (var item in chkCmbYear.CheckedItems)
                {
                    finYear = finYear + "," + item.ToString();
                }
                finYear = finYear.Remove(0, 1);
            }
            else
            {
                finYear = DateTime.Now.Year.ToString().Substring(2, 2) + "-" + DateTime.Now.AddYears(1).Year.ToString().Substring(2, 2);
            }
            if(string.IsNullOrWhiteSpace(finYear))
            {
                MessageBox.Show("Please check valid financial year");
                return;
            }
            auditFilter.FromYear = finYear;// cmbfromYear.Text;
            auditFilter.ToYear = cmbToYear.Text;
            auditFilter.TableName = "tbl_auditPlan";
            auditFilter.UserId = UserId;
            await FilterAuditCalenderData(GlobalDeclaration._holdInfo[0].UserRole, auditFilter);
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
           cmbAuditType.Text=string.Empty;
            //cmbfromYear.Text = string.Empty;
           chkCmbYear.Text = string.Empty;
           cmbToYear.Text = string.Empty;
           cmbDept.Text = string.Empty;
           PopulateData();
        
        }
    }
    public enum DocStatus
        {
            Prepare = 0,
            Open = 1,
            Submitted=2,
            Freezed = 3,
            PlaSubmitted =4,
            Closed = 5,
            Rejected=6,
            [Display(Name = "Submit For Closure")]
            SubmitForClosure =7,
            Accepted=8,
            [Display(Name = "Rejected")]
            HeadRejected =9
        }
    public class AuditCalender
        {
            public Guid AuditplanId { set; get; }
            public string AuditCode { set; get; }
            public DateTime CreatedDate { set; get; }
            public string CreatedBy { set; get; }
            public string OperationUnit { set; get; }
            public string AuditType { set; get; }
            public string FinancialYear { set; get; }
            public string FinancialQuarter { set; get; }
            public int DepartmentId { set; get; }
            public string AuditeeId { set; get; }
            public DateTime AuditClosureDate { set; get; }
            public string ExpectedClosureMonth { set; get; }
            public DateTime AuditStartDate { set; get; }
            public DateTime AuditEndDate { set; get; }
            public string AuditorId { set; get; }
            public string CommitteeMemId { set; get; }
            public string AuditPlanUpdatedBy { set; get; }
            public DateTime AuditPlanUpdatedDate { set; get; }
            public int DocStatus { set; get; }
    }
    public class UserJObject
    {
        public string uname  { get; set; }
        public int Uid  { get; set; }
    }
    public class AuditFilter
    {
        public string FromYear { get; set; }
        public string ToYear { get; set; }
        public string AuditType { get; set; }
        public int DepartmentId { get; set; }
        public string UserId { get; set; }
        public string TableName { get; set; }
    }

   public class ienumAudit
    {
        public IEnumerable<AuditCalender> auditCalenders { get; set; }
    }
  }

