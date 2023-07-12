using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using HindalcoiOS.Class_Operation;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Cmp;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.AuditHind
{
    public partial class AuditManagementView : XtraForm
    {
        AuditManagement auditManagement = null;

        //public DataTable DepartmentList { set; get; }
        public string UserId { set; get; }
        public string UserName { set; get; }
        public int RoleId { set; get; }
        public string remarkMsg { set; get; }
        public Guid auditPlanId { get; set; }
        public Guid auditManId { get; set; }
        public string AuditGlobalCode { set; get; }
        public string AuditCheckPoint { set; get; }

        //public string CurrStatus { set; get; }
        public AuditCalender adCalender { set; get; }
        public int iCount { set; get; }
        //public DataTable LoadAllUsers { set; get; }

        List<AuditMaster> audMasters = new List<AuditMaster>();
        
        public AuditManagementView()
        {
            //LoadUsersAll();
            UserName = GlobalDeclaration._holdInfo[0].UserName;
            UserId = GlobalDeclaration._holdInfo[0].UserId.ToString();// Properties.Settings.Default.UserID;
            RoleId = Properties.Settings.Default.RoleID;
            auditManagement = new AuditManagement();
            InitializeComponent();
        }

        #region Controls Handler-------------------
       

        private async void AuditManagementView_Load(object sender, EventArgs e)
        {
            GlobalDeclaration.HideTabCtrlPagesHeader(AuditMgmtPages);
            AuditHelper.ValidateTokenExpiration();
            await GetAllAuditMaster();
            AuditHelper.LoadDepartmentsToCombo(cmbDept);
            //LoadUsersAll();
            DisableControls();
            HideShowActioncontrol();
            PopulateCommonDataToGrid();
            AuditHelper.LoadFinYear(chkCmbYear);

        }

        private void btnDetailData_Click(object sender, EventArgs e)
        {
            AuditMgmtPages.SelectedIndex = 1;
        }

        private void btnViewData_Click(object sender, EventArgs e)
        {
            AuditMgmtPages.SelectedIndex = 0;
            AuditHelper.ValidateTokenExpiration();
            PopulateCommonDataToGrid();
          
        }

         private void btnAssignedData_Click(object sender, EventArgs e)
        {
            AuditMgmtPages.SelectedIndex = 2;
            //GetAssigned data
        }

        private void btnClosedData_Click(object sender, EventArgs e)
        {
            AuditMgmtPages.SelectedIndex = 3;
            //GetClosed data
            AuditHelper.ValidateTokenExpiration();
            PopulateClosedDataToGrid();
        }

       

        private void dgvAsgnData_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    audMgmt = null;
            //    audMgmt = new AuditManagement();
            //    if (e.RowIndex < 0) return;
            //    audMgmt.DocNo = dgvAsgnData.Rows[e.RowIndex].Cells["asgnDocNo"].Value.ToString();
            //    audMgmt.DocDate =DateTime.Parse(dgvAsgnData.Rows[e.RowIndex].Cells["asgnDocDate"].Value.ToString());
            //    audMgmt.DocBy = dgvAsgnData.Rows[e.RowIndex].Cells["asgnDocBy"].Value.ToString();
            //    audMgmt.Auditor = dgvAsgnData.Rows[e.RowIndex].Cells["asgnAuditor"].Value.ToString();
            //    audMgmt.Auditee = dgvAsgnData.Rows[e.RowIndex].Cells["asgnAuditee"].Value.ToString();
            //    audMgmt.Dept = dgvAsgnData.Rows[e.RowIndex].Cells["asgnDept"].Value.ToString();
            //    audMgmt.Area = dgvAsgnData.Rows[e.RowIndex].Cells["asgnArea"].Value.ToString();
            //    audMgmt.AuditType = dgvAsgnData.Rows[e.RowIndex].Cells["asgnAuditType"].Value.ToString();
            //    audMgmt.CateofObs = dgvAsgnData.Rows[e.RowIndex].Cells["asgnObsCategory"].Value.ToString();
            //    audMgmt.NarrationObs = dgvAsgnData.Rows[e.RowIndex].Cells["asgnObsNarration"].Value.ToString();
            //    audMgmt.RootCauseObsAuditor = dgvAsgnData.Rows[e.RowIndex].Cells["asgnObsRootCauseAuditor"].Value.ToString();
            //    audMgmt.RootCauseObsAuditee = dgvAsgnData.Rows[e.RowIndex].Cells["asgnObsRootCauseAuditee"].Value.ToString();
            //    audMgmt.DeviaSafetyStd = dgvAsgnData.Rows[e.RowIndex].Cells["asgnsafetyStdDeviation"].Value.ToString();
            //    audMgmt.Status = dgvAsgnData.Rows[e.RowIndex].Cells["asgnStatus"].Value.ToString();
            //    audMgmt.CorrAction = dgvAsgnData.Rows[e.RowIndex].Cells["asgnCorrectiveActions"].Value.ToString();
            //    audMgmt.OffResponsCorr = dgvAsgnData.Rows[e.RowIndex].Cells["asgnOffResponsCorr"].Value.ToString();
            //    audMgmt.PrevAction = dgvAsgnData.Rows[e.RowIndex].Cells["asgnRecurrPrevAction"].Value.ToString();
            //    audMgmt.OffResponsPrev = dgvAsgnData.Rows[e.RowIndex].Cells["asgnOffResponsPrev"].Value.ToString();
            //    MapObjectToControl(audMgmt);
              
            //    //ViewDept();
            //    AuditMgmtPages.SelectedIndex = 1;
            //}
            //catch (Exception Ex)
            //{
            //    XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }


        private void btnAsgnBack_Click(object sender, EventArgs e)
        {
            AuditMgmtPages.SelectedIndex = 1;
        }

        private void btnViewBack_Click(object sender, EventArgs e)
        {
            AuditMgmtPages.SelectedIndex = 1;
        }

        private void btnClosBack_Click(object sender, EventArgs e)
        {
            AuditMgmtPages.SelectedIndex = 1;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AuditHelper.ValidateTokenExpiration();
                if (RoleId == 7)
                {
                    if (txtStatus.Text == DocStatus.Accepted.ToString())
                    {
                        DialogResult dr = MessageBox.Show("Are you sure to Open?", "Alert", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.No) return;
                        if (dgvAuditMgmtDetail.Rows.Count < 1)
                        {
                            MessageBox.Show("Submission not allowed. Please add atleast single observation.", "Alert", MessageBoxButtons.OK);
                            return;
                        }
                        GetRemarkPopUp();
                        AddRemarks(txtRemarks.Text, "Opened by", remarkMsg);
                        SubmitAuditDetail(dgvAuditMgmtDetail, AuditStatus.Open);
                        MapControlToObject(auditManagement);
                        auditManagement.Status =GlobalDeclaration.DocStatusValueToInt(DocStatus.Open.ToString());
                        await UpdateAuditMgmt(auditManagement, "Audit submitted successfully.");
                        txtStatus.Text = DocStatus.Open.ToString();
                    }
                }


                    if (RoleId == 12)
                     {
                    if (txtStatus.Text == DocStatus.Open.ToString())
                    {
                        DialogResult dr = MessageBox.Show("Are you sure to submit?", "Alert", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.No) return;
                        if (dgvAuditMgmtDetail.Rows.Count < 1)
                        {
                            MessageBox.Show("Submission not allowed. Please add atleast single observation.", "Alert", MessageBoxButtons.OK);
                            return;
                        }
                        GetRemarkPopUp();
                        AddRemarks(txtRemarks.Text, "Submitted by", remarkMsg);
                        SubmitAuditDetail(dgvAuditMgmtDetail,AuditStatus.Submitted);
                        MapControlToObject(auditManagement);
                        auditManagement.Status = GlobalDeclaration.DocStatusValueToInt(DocStatus.Submitted.ToString());
                        await UpdateAuditMgmt(auditManagement, "Audit submitted successfully.");
                        txtStatus.Text = DocStatus.Submitted.ToString();                      
                           

                    }
                    if (txtStatus.Text == DocStatus.Rejected.ToString())
                    {
                        DialogResult dr = MessageBox.Show("Are you sure to submit?", "Alert", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.No) return;
                        if (dgvAuditMgmtDetail.Rows.Count < 1)
                        {
                            MessageBox.Show("Submission not allowed. Please add atleast single observation.", "Alert", MessageBoxButtons.OK);
                            return;
                        }
                        GetRemarkPopUp();
                        AddRemarks(txtRemarks.Text, "Submitted by", remarkMsg);
                        SubmitAuditDetail(dgvAuditMgmtDetail, AuditStatus.Submitted);
                        MapControlToObject(auditManagement);
                        auditManagement.Status = GlobalDeclaration.DocStatusValueToInt(DocStatus.Submitted.ToString());
                        await UpdateAuditMgmt(auditManagement, "Audit submitted successfully.");
                        txtStatus.Text = DocStatus.Submitted.ToString();
                    }
                }

                if (RoleId == 11)
                {

                    if (txtStatus.Text == DocStatus.Accepted.ToString())
                    {
                        DialogResult dr = MessageBox.Show("Are you sure to submit for closure?", "Alert", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.No) return;
                        await CheckAuditMgmtDetailClosureData(auditManId);
                        if (iCount == 0)
                        {
                            MessageBox.Show("Closure not allowed.Please check all detail data for closure?", "Alert", MessageBoxButtons.OK);
                            return;
                        }
                        GetRemarkPopUp();
                        AddRemarks(txtRemarks.Text, "Submitted for Closure by", remarkMsg);
                        MapControlToObject(auditManagement);
                        auditManagement.Status = GlobalDeclaration.DocStatusValueToInt(DocStatus.SubmitForClosure.ToString());
                        UpdateAuditMgmt(auditManagement, "Audit successfully submitted for closure.");
                        txtStatus.Text = DocStatus.SubmitForClosure.ToString();
                        btnSave.Text = "Close";
                        dgvAuditMgmtDetail.Visible = true;
                    }
                    if (txtStatus.Text == DocStatus.Submitted.ToString())
                    {
                        DialogResult dr = MessageBox.Show("Are you sure to Accept?", "Alert", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.No) return;
                        GetRemarkPopUp();
                        AddRemarks(txtRemarks.Text, "Accepted by", remarkMsg);
                        MapControlToObject(auditManagement);
                        auditManagement.Status = GlobalDeclaration.DocStatusValueToInt(DocStatus.Accepted.ToString());
                        UpdateAuditMgmt(auditManagement, "Audit accepted successfully.");
                        txtStatus.Text = DocStatus.Accepted.ToString();
                        btnSave.Text = "Close";
                    }
                    if (txtStatus.Text == DocStatus.HeadRejected.ToString())
                    {
                        DialogResult dr = MessageBox.Show("Are you sure to Resubmit for closure?", "Alert", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.No) return;
                        await CheckAuditMgmtDetailClosureData(auditManId);
                        if (iCount == 0)
                        {
                            MessageBox.Show("Closure not allowed.Please check all detail data for closure?", "Alert", MessageBoxButtons.OK);
                            return;
                        }
                        GetRemarkPopUp();
                        AddRemarks(txtRemarks.Text, "Submitted for Closure by", remarkMsg);
                        MapControlToObject(auditManagement);
                        auditManagement.Status = GlobalDeclaration.DocStatusValueToInt(DocStatus.SubmitForClosure.ToString());
                        UpdateAuditMgmt(auditManagement, "Audit successfully submitted for closure.");
                        txtStatus.Text = DocStatus.SubmitForClosure.ToString();
                        btnSave.Text = "Close";
                        dgvAuditMgmtDetail.Visible = true;
                    }
                    DisableControls();
                }

                if (RoleId == 13 && txtStatus.Text == DocStatus.SubmitForClosure.ToString())
                {
                    DialogResult dr = MessageBox.Show("Are you sure to close?", "Alert", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.No) return;
                    GetRemarkPopUp();
                    AddRemarks(txtRemarks.Text, "Closed by", remarkMsg);
                    MapControlToObject(auditManagement);
                    auditManagement.Status = GlobalDeclaration.DocStatusValueToInt(DocStatus.Closed.ToString());
                    UpdateAuditMgmt(auditManagement, "Audit closed successfully.");
                    auditManagement.AuditEndDate = DateTime.Today;
                    txtStatus.Text = DocStatus.Closed.ToString();
                    await GetAuditCalByPlanId(auditPlanId);
                    adCalender.DocStatus = (int)DocStatus.Closed;
                    adCalender.AuditEndDate = auditManagement.AuditEndDate;
                    UpdateAuditCalendar(adCalender);
                }
                //if (RoleId == 14 && txtStatus.Text == DocStatus.SubmitForClosure.ToString())
                //{
                //    DialogResult dr = MessageBox.Show("Are you sure to submit?", "Alert", MessageBoxButtons.YesNo);
                //    if (dr == DialogResult.No) return;
                //    MapControlToObject(auditManagement);
                //    auditManagement.Status = DocStatusValueToInt(DocStatus.Closed.ToString());
                //    UpdateAuditMgmt(auditManagement);
                //    txtStatus.Text = DocStatus.Closed.ToString();
                //    //btnSave.Text = "Submit";
                //}

                Thread.Sleep(1000);
                if (RoleId == 15)
                {
                    await GetAuditDetailingByCapUserId(auditManId, GlobalDeclaration.UserName);
                }
                else
                    await GetAuditDetailingByManId(auditManId);
                HideShowActioncontrol();
            }
            catch (Exception ex)
            {

            }
        }

        private async void btnReject_Click(object sender, EventArgs e)
        {
            DialogResult drr = MessageBox.Show("Are you sure to reject?", "Alert", MessageBoxButtons.YesNo);
            if (drr == DialogResult.No) return;
            if (drr == DialogResult.Yes)
            {
                GetRemarkPopUp();
                AuditHelper.ValidateTokenExpiration();

                if (RoleId == 11 && txtStatus.Text == DocStatus.Submitted.ToString())
                {
                    if (string.IsNullOrEmpty(txtRemarks.Text))
                    {
                        MessageBox.Show("Please input remarks for rejection.");
                        return;
                    }
                    AddRemarks(txtRemarks.Text, "Rejected by", remarkMsg);
                    SubmitAuditDetail(dgvAuditMgmtDetail, AuditStatus.Open);
                    MapControlToObject(auditManagement);
                    auditManagement.Status = GlobalDeclaration.DocStatusValueToInt(DocStatus.Rejected.ToString());
                    await UpdateAuditMgmt(auditManagement, "Audit rejected.");
                    txtStatus.Text = DocStatus.Rejected.ToString();
                    //Disable Controls--------------------------------------------------------------

                }


                if (RoleId == 13 && txtStatus.Text == DocStatus.SubmitForClosure.ToString())
                {
                    AddRemarks(txtRemarks.Text, "Rejected by", remarkMsg);
                    MapControlToObject(auditManagement);
                    auditManagement.Status = GlobalDeclaration.DocStatusValueToInt(DocStatus.HeadRejected.ToString());
                    UpdateAuditMgmt(auditManagement, "Audit rejected");
                    txtStatus.Text = DocStatus.HeadRejected.ToString();
                    //Disable Controls----------

                }
                Thread.Sleep(500);
                if (RoleId == 15)
                {
                    await GetAuditDetailingByCapUserId(auditManId, GlobalDeclaration.UserName);
                }
                else
                    await GetAuditDetailingByManId(auditManId);
                HideShowActioncontrol();
            }
        }

        #endregion

        #region Methods-----------------

        private async Task<string> UpdateAuditMgmt(AuditManagement audMgmt,string msg)
        {
            var responseString = string.Empty;
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/" + "UpdateAudits" + "?AuditManId=" + audMgmt.AuditManId+ "&Token="+GlobalDeclaration.ApiToken;
                    var myContent = JsonConvert.SerializeObject(audMgmt);
                    var requestContent = new StringContent(myContent, Encoding.UTF8, "application/json");
                    // var content = new FormUrlEncodedContent(auditCalendar);
                    var response = await httpClient.PutAsync(GlobalDeclaration.CleanURL(url), requestContent);
                    responseString = await response.Content.ReadAsStringAsync();
                    //  var createdCompany = JsonSerializer.Deserialize<AuditCategory>(responseString,);
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        Console.WriteLine(response.StatusCode.ToString());
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        Console.WriteLine(msg);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return responseString;
        }

        private async Task<string> UpdateAuditCalendar(AuditCalender auditCalender)
        {
            var responseString = string.Empty;
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/" + "UpdateAuditPlan" + "?AuditPlanId=" + auditCalender.AuditplanId+ "&Token="+GlobalDeclaration.ApiToken;
                    //   string url = "https://hindalcoams.sparrowios.com/" + "UpdateAuditCalendar/";
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
                       // MessageBox.Show("Record submitted successfully.");
                    }
                }
            }
            catch (Exception ex)
            {



            }
            return responseString;
        }

        private async Task<string> DeleteAuditMgmt(AuditManagementTemp adMgmtTemp)
        {
            var responseString = string.Empty;
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/" + "UpdateAuditPlan" + "?AuditPlanId=";// + auditCalender.AuditplanId;
                    //   string url = "https://hindalcoams.sparrowios.com/" + "UpdateAuditCalendar/";
                    var myContent = JsonConvert.SerializeObject(adMgmtTemp);
                    var requestContent = new StringContent(myContent, Encoding.UTF8, "application/json");

                    var response = await httpClient.DeleteAsync(url);
                    responseString = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        Console.WriteLine(response.StatusCode.ToString());
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        // MessageBox.Show("Record submitted successfully.");
                    }
                }
            }
            catch (Exception ex)
            {



            }
            return responseString;
        }

        private async Task<List<AuditCalender>> GetAuditCalByPlanId(Guid AuditPlanId)
        {
            //AuditCalender ams = new AuditCalender();
            //List<string> objList = new List<string>();
            List<AuditCalender> adCals = new List<AuditCalender>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/GetAuditCalenderByPlanId/" + AuditPlanId+ "?Token="+GlobalDeclaration.ApiToken;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync(GlobalDeclaration.CleanURL(url)))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            adCals = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditCalender>>(apiResponse);
                            foreach (AuditCalender item in adCals)
                            {
                                SetAuditCalenderValue(item);
                            }
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
                    return adCals;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return adCals;
        }

        private async Task<List<AuditManagement>> GetAuditManagementByDU(string AuditorId)
        {
            //AuditCalender ams = new AuditCalender();
            //List<string> objList = new List<string>();
            List<AuditManagement> ams = new List<AuditManagement>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/GetAuditManagementByDU?AuditorId=" + AuditorId+ "&Token="+GlobalDeclaration.ApiToken;
                    url = GlobalDeclaration.CleanURL(url);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            // AuditCalender datalist = JsonConvert.DeserializeObject<AuditCalender>(apiResponse);
                            ams = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditManagement>>(apiResponse);
                            BindAuditMgmtViewData(ams);
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

        private async Task<List<AuditManagement>> GetAuditManagementByStatusDU(string AuditorId,int adstatus)
        {
            //AuditCalender ams = new AuditCalender();
            //List<string> objList = new List<string>();
            List<AuditManagement> ams = new List<AuditManagement>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/GetAuditManagementByDU/{CreatedBy}?AuditorId=" + AuditorId +"&Status="+ adstatus+ "&Token="+GlobalDeclaration.ApiToken;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync( GlobalDeclaration.CleanURL(url)))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            // AuditCalender datalist = JsonConvert.DeserializeObject<AuditCalender>(apiResponse);
                            ams = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditManagement>>(apiResponse);
                            BindAuditMgmtClosedData(ams);
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

        private async Task<List<AuditManagement>> GetAuditManagementByDH(string AuditeeId)
        {
            //AuditCalender ams = new AuditCalender();
            //List<string> objList = new List<string>();
            List<AuditManagement> ams = new List<AuditManagement>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/" + "GetAuditManagementByDH" + "?AuditeeId=" + AuditeeId+ "&Token="+GlobalDeclaration.ApiToken;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync(GlobalDeclaration.CleanURL(url)))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            // AuditCalender datalist = JsonConvert.DeserializeObject<AuditCalender>(apiResponse);
                            ams = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditManagement>>(apiResponse);
                            BindAuditMgmtViewData(ams);
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

        private async Task<List<AuditManagement>> GetAuditManagementByStatusDH(string AuditeeId, int adstatus)
        {
            //AuditCalender ams = new AuditCalender();
            //List<string> objList = new List<string>();
            List<AuditManagement> ams = new List<AuditManagement>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url= "https://hindalcoams.sparrowios.com/GetAuditManagementByDH/{CreatedBy}?AuditeeId="+AuditeeId+"&Status="+ adstatus+ "&Token="+GlobalDeclaration.ApiToken;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync(GlobalDeclaration.CleanURL(url)))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            ams = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditManagement>>(apiResponse);
                            BindAuditMgmtClosedData(ams);
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

        private async Task<List<AuditManagement>> GetAuditManagementByCreatedBy(string CreatedById)
        {
            //AuditCalender ams = new AuditCalender();
            //List<string> objList = new List<string>();
            List<AuditManagement> ams = new List<AuditManagement>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/" + "GetAuditManagementCreatedBy" + "?CreatedBy=" + CreatedById+ "&Token="+GlobalDeclaration.ApiToken;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync(GlobalDeclaration.CleanURL(url)))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            // AuditCalender datalist = JsonConvert.DeserializeObject<AuditCalender>(apiResponse);
                            ams = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditManagement>>(apiResponse);
                            BindAuditMgmtViewData(ams);
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

        private async Task<List<AuditManagement>> GetAuditManagementByStatusCreatedby(string CreatedBy, int adstatus)
        {
             List<AuditManagement> ams = new List<AuditManagement>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/GetAuditManagementByCreatedBy/"+ CreatedBy + "?Status="+ adstatus+ "&Token="+GlobalDeclaration.ApiToken;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync(GlobalDeclaration.CleanURL(url)))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            ams = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditManagement>>(apiResponse);
                            BindAuditMgmtClosedData(ams);
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

        private async Task<List<AuditManagement>> GetAuditManagementByAuditCommMem(string CommiteeMemId)
        {
            //AuditCalender ams = new AuditCalender();
            //List<string> objList = new List<string>();
            List<AuditManagement> ams = new List<AuditManagement>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/" + "GetAuditManagementByAuditCommMem" + "?CommiteeMemId=" + CommiteeMemId+ "&Token="+GlobalDeclaration.ApiToken;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync(GlobalDeclaration.CleanURL(url)))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            // AuditCalender datalist = JsonConvert.DeserializeObject<AuditCalender>(apiResponse);
                            ams = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditManagement>>(apiResponse);
                            BindAuditMgmtViewData(ams);
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

        private async Task<List<AuditManagement>> GetAuditMgmtByStatusAuditCommMem(string CommiteeMemId, int adstatus)
        {
            List<AuditManagement> ams = new List<AuditManagement>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/GetAuditManagementByAuditCommMem/{CreatedBy}?CommitteeMemId="+ CommiteeMemId + "&Status="+ adstatus + "&Token=" + GlobalDeclaration.ApiToken;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync(GlobalDeclaration.CleanURL(url)))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            ams = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditManagement>>(apiResponse);
                            BindAuditMgmtClosedData(ams);
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

        private async Task<List<AuditManagement>> GetAuditManagementByCAPAUser(string PersonResponsibleId)
        {
            //AuditCalender ams = new AuditCalender();
            //List<string> objList = new List<string>();
            List<AuditManagement> ams = new List<AuditManagement>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/" + "GetAuditDetailingsByCapaUser" + "?ResponsPersonId=" + PersonResponsibleId + "&Token=" + GlobalDeclaration.ApiToken;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync(GlobalDeclaration.CleanURL(url)))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            // AuditCalender datalist = JsonConvert.DeserializeObject<AuditCalender>(apiResponse);
                            ams = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditManagement>>(apiResponse);
                            BindAuditMgmtViewData(ams);
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

        private async Task<List<AuditManagement>> GetAllAuditManagementByAdminuser()
        {
            //AuditCalender ams = new AuditCalender();
            //List<string> objList = new List<string>();
            List<AuditManagement> ams = new List<AuditManagement>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/GetAllAudits&Token="+GlobalDeclaration.ApiToken;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync(GlobalDeclaration.CleanURL(url)))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            // AuditCalender datalist = JsonConvert.DeserializeObject<AuditCalender>(apiResponse);
                            ams = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditManagement>>(apiResponse);
                            BindAuditMgmtViewData(ams);
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

        private async Task<List<AuditManagementDetail>> GetAuditDetailingByManId(Guid AuditManId)
        {
            List<AuditManagementDetail> addetails = new List<AuditManagementDetail>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    //string url = "https://hindalcoams.sparrowios.com/" + "GetAuditDetailingByManId" + "?AuditManId =" 
                    string url= "https://hindalcoams.sparrowios.com/GetAuditDetailingsByManId/"+ AuditManId+"?Token="+GlobalDeclaration.ApiToken;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync(GlobalDeclaration.CleanURL(url)))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            // AuditCalender datalist = JsonConvert.DeserializeObject<AuditCalender>(apiResponse);
                            addetails = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditManagementDetail>>(apiResponse);
                          BindAuditMgmtDetailData(addetails);
                            
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
                    return addetails;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return addetails;
        }

        /// <summary>
        /// Get Audit Mgmt Detail by Capa Id
        /// </summary>
        /// <param name="capaUserId"></param>
        /// <returns></returns>
        private async Task<List<AuditManagementDetail>> GetAuditDetailingByCapUserId(Guid AuditManId,string capaUserId)
        {
            List<AuditManagementDetail> addetails = new List<AuditManagementDetail>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    //string url = "https://hindalcoams.sparrowios.com/GetAuditMgmtDetailByCapaUserId/"+ capaUserId+"?AuditManid="+ AuditManId+"&Token="+GlobalDeclaration.ApiToken;
                    string url="https://hindalcoams.sparrowios.com/GetAuditMgmtDetailByCapaUserId/"+capaUserId+"?AuditManid="+AuditManId + "&Token="+GlobalDeclaration.ApiToken;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    url= GlobalDeclaration.CleanURL(url);
                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            // AuditCalender datalist = JsonConvert.DeserializeObject<AuditCalender>(apiResponse);
                            addetails = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditManagementDetail>>(apiResponse);
                            BindAuditMgmtDetailData(addetails);

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
                    return addetails;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return addetails;
        }

        private async Task<List<AuditMaster>> GetAllAuditMaster()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/GetAllAuditMasters?Token="+GlobalDeclaration.ApiToken;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync(GlobalDeclaration.CleanURL(url)))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            audMasters = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditMaster>>(apiResponse);
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
                    return audMasters;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return audMasters;
        }

        public async Task<string> GenerateAudMgmtCode(string AudCode,string AuditRequestType,string FinYear)
        {
            //AuditCalender ams = new AuditCalender();
            //List<string> objList = new List<string>();
            string objList = string.Empty;
            List<AuditCalender> aDms = new List<AuditCalender>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/GeneratAutoDocumentPlan?AudCode="+AudCode+"&AuditRequestType="+AuditRequestType+"&FinYear="+ FinYear;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            // AuditCalender datalist = JsonConvert.DeserializeObject<AuditCalender>(apiResponse);
                            objList = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(apiResponse);
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
                    return objList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return objList;
        }
        public async Task<string> GenerateAutoDocDetail(string AudCode, string AuditRequestType, Guid adManId)
        {
            AuditGlobalCode = string.Empty;
            List<AuditCalender> aDms = new List<AuditCalender>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/GeneratAutoDocumentDetail?AudCode="+AudCode+"&AudType="+AuditRequestType+"&AuditManId="+adManId+ "&Token="+GlobalDeclaration.ApiToken;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync(GlobalDeclaration.CleanURL(url)))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            AuditGlobalCode = apiResponse.Replace('"', '=').Replace("=", " ").Trim();
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

        public async Task<string> CheckAuditMgmtDetailClosureData(Guid AuditManId)
        {
            iCount = 0;
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/CheckAuditDetailClosedData/" + AuditManId+ "?Token="+GlobalDeclaration.ApiToken;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync(GlobalDeclaration.CleanURL(url)))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            iCount = int.Parse(apiResponse);
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
                    return iCount.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return iCount.ToString();
        }

        //private async Task<List<AuditManagement>> GetAuditManagementByFinYear(string FinYear)
        //{
        //    List<AuditManagement> ams = new List<AuditManagement>();
        //    try
        //    {
        //        using (var httpClient = new HttpClient())
        //        {
        //            string url = "https://hindalcoams.sparrowios.com/" + "GetAuditManagementByDU" + "?AuditorId=" + FinYear;
        //            httpClient.DefaultRequestHeaders.Accept.Clear();
        //            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //            using (var response = await httpClient.GetAsync(url))
        //            {
        //                if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //                {
        //                    string apiResponse = await response.Content.ReadAsStringAsync();
        //                    // AuditCalender datalist = JsonConvert.DeserializeObject<AuditCalender>(apiResponse);
        //                    ams = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditManagement>>(apiResponse);
        //                    BindAuditMgmtViewData(ams);
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

        private async Task<string> UpdateAuditMgmtDetail(AuditManagementDetail audMgmtDetail)
        {
            var responseString = string.Empty;
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/" + "UpdateAuditDetailsTbl/" + audMgmtDetail.AuditManDetId+ "?Token="+GlobalDeclaration.ApiToken;
                    var myContent = JsonConvert.SerializeObject(audMgmtDetail);
                    var requestContent = new StringContent(myContent, Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync(GlobalDeclaration.CleanURL(url), requestContent);
                    responseString = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        Console.WriteLine(response.StatusCode.ToString());
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                          //DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return responseString;
        }

        private void BindAuditMgmtViewData(List<AuditManagement> audMgmtList)
        {
            try
            {
                if (dgvViewAuditExeData.Rows.Count > 0)
                    dgvViewAuditExeData.Rows.Clear();
                //if (dt.Rows.Count > 0)
                {
                    foreach (var item in audMgmtList)
                    {
                        //if (RoleId == 15 && item.Status == (int)AuditStatus.Closed)
                        //    continue;
                        DataGridViewRow dr = new DataGridViewRow();
                        dgvViewAuditExeData.Rows.Add(dr);
                        int index = dgvViewAuditExeData.Rows.Count - 1;

                        AuditMgmtGridAppearance(dr, GlobalDeclaration.DocStatusEnumIntToValue(item.Status));
                        dgvViewAuditExeData.Rows[index].Cells["AuditplanId"].Value = item.AuditPlanID;
                        dgvViewAuditExeData.Rows[index].Cells["AuditManId"].Value = item.AuditManId;
                        dgvViewAuditExeData.Rows[index].Cells["AuditCode"].Value = item.AuditCode;
                        dgvViewAuditExeData.Rows[index].Cells["CreatedDate"].Value = item.CreatedDate.ToString("dd-MM-yyyy");
                        dgvViewAuditExeData.Rows[index].Cells["OperationUnit"].Value = item.OperationUnit;
                        dgvViewAuditExeData.Rows[index].Cells["Department"].Value =GlobalDeclaration.GetDeptName(item.DepartmentId);
                        dgvViewAuditExeData.Rows[index].Cells["AuditType"].Value = item.AuditType; 
                        dgvViewAuditExeData.Rows[index].Cells["FinYear"].Value = item.FinancialYear;
                        dgvViewAuditExeData.Rows[index].Cells["FinQuarter"].Value = item.FinancialQuarter;
                        dgvViewAuditExeData.Rows[index].Cells["ExpCloseMonth"].Value = item.ExpectedAuditMonth;

                        dgvViewAuditExeData.Rows[index].Cells["Status"].Value =GlobalDeclaration.DocStatusEnumIntToValue(item.Status);
                        dgvViewAuditExeData.Rows[index].Cells["CreatedBy"].Value = GlobalDeclaration.GetUserName(item.CreatedBy);
                        dgvViewAuditExeData.Rows[index].Cells["Auditor"].Value = GlobalDeclaration. GetUserName(item.AuditorId);
                        dgvViewAuditExeData.Rows[index].Cells["Auditee"].Value = GlobalDeclaration. GetUserName(item.AuditeeId);
                        dgvViewAuditExeData.Rows[index].Cells["TargetClosDate"].Value = item.AuditClosureDate.ToString("dd-MM-yyyy"); ;
                        dgvViewAuditExeData.Rows[index].Cells["AuditStartDate"].Value = item.AuditStartDate.ToString("dd-MM-yyyy");
                        dgvViewAuditExeData.Rows[index].Cells["AuditEndDate"].Value = item.AuditEndDate.ToString("dd-MM-yyyy"); ; 
                        dgvViewAuditExeData.Rows[index].Cells["AuditCommMem"].Value = GlobalDeclaration.GetUserName(item.CommiteeMemId);
                        dgvViewAuditExeData.Rows[index].Cells["Remarks"].Value = item.Remarks;// item.AuditEndDate; 
                        dgvViewAuditExeData.Rows[index].Cells["AudUpdateOn"].Value = item.AuditPlanUpdatedDate.ToString("dd-MM-yyyy");
                    }
                    dgvViewAuditExeData.Sort(dgvViewAuditExeData.Columns["AudUpdateOn"], ListSortDirection.Descending);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindAuditMgmtClosedData(List<AuditManagement> audMgmtList)
        {
            try
            {
                if (dgvClosData.Rows.Count > 0)
                    dgvClosData.Rows.Clear();
                {
                    foreach (var item in audMgmtList)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        dgvClosData.Rows.Add(dr);
                        int index = dgvClosData.Rows.Count - 1;
                        dgvClosData.Rows[index].Cells["closAuditplanId"].Value = item.AuditPlanID;
                        dgvClosData.Rows[index].Cells["closAuditManId"].Value = item.AuditManId;
                        dgvClosData.Rows[index].Cells["closAuditCode"].Value = item.AuditCode;
                        dgvClosData.Rows[index].Cells["closCreatedDate"].Value = item.CreatedDate;
                        dgvClosData.Rows[index].Cells["closOperationUnit"].Value = item.OperationUnit;
                        dgvClosData.Rows[index].Cells["closDepartment"].Value = GlobalDeclaration.GetDeptName(item.DepartmentId);
                        dgvClosData.Rows[index].Cells["closAuditType"].Value = item.AuditType;
                        dgvClosData.Rows[index].Cells["closFinYear"].Value = item.FinancialYear;
                        dgvClosData.Rows[index].Cells["closFinQuarter"].Value = item.FinancialQuarter;
                        dgvClosData.Rows[index].Cells["closExpCloseMonth"].Value = item.ExpectedAuditMonth;
                        dgvClosData.Rows[index].Cells["closStatus"].Value = GlobalDeclaration.DocStatusEnumIntToValue(item.Status);
                        dgvClosData.Rows[index].Cells["closCreatedBy"].Value = GlobalDeclaration. GetUserName(item.CreatedBy);
                        dgvClosData.Rows[index].Cells["closAuditor"].Value = GlobalDeclaration.GetUserName(item.AuditorId);
                        dgvClosData.Rows[index].Cells["closAuditee"].Value = GlobalDeclaration.GetUserName(item.AuditeeId);
                        dgvClosData.Rows[index].Cells["closTargetClosDate"].Value = item.AuditClosureDate;
                        dgvClosData.Rows[index].Cells["closAuditStartDate"].Value = item.AuditStartDate;
                        dgvClosData.Rows[index].Cells["closAuditEndDate"].Value = item.AuditEndDate; 
                        dgvClosData.Rows[index].Cells["closAuditCommMem"].Value = GlobalDeclaration.GetUserName(item.CommiteeMemId);
                        dgvClosData.Rows[index].Cells["closRemarks"].Value =  item.Remarks;
                        dgvClosData.Rows[index].Cells["closAudUpdateOn"].Value = item.Remarks;
                    }
                    dgvClosData.Sort(dgvClosData.Columns["closAudUpdateOn"], ListSortDirection.Descending);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BindAuditMgmtDetailData(List<AuditManagementDetail> audMgmtDetailList)
        {
            int icnt = 0;
            try
            {
               
                if (dgvAuditMgmtDetail.Rows.Count > 0)
                    dgvAuditMgmtDetail.Rows.Clear();
                
                //if (dt.Rows.Count > 0)
                {
                    foreach (var item in audMgmtDetailList)
                    {
                        if (RoleId == 15 && (item.AuditStatus != (int)AuditStatus.Assigned && item.AuditStatus != (int)AuditStatus.ReAssigned && item.AuditStatus != (int)AuditStatus.CAPAClosed) && (item.AuditStatus != (int)AuditStatus.Closed && item.ResponsPersonId!="NA"))
                            continue;
                        DataGridViewRow dr = new DataGridViewRow();
                        dgvAuditMgmtDetail.Rows.Add(dr);
                        int index = dgvAuditMgmtDetail.Rows.Count - 1;
                        AuditDetailGridAppearance(dr, AuditStatusEnumIntToValue(item.AuditStatus));
                        dgvAuditMgmtDetail.Rows[index].Cells["SrlNo"].Value = item.SrlNo;
                        dgvAuditMgmtDetail.Rows[index].Cells["ObsCate"].Value = item.CateOfObs;
                        dgvAuditMgmtDetail.Rows[index].Cells["DevSafetyStd"].Value = item.DeviaSafetyStd;
                        if(audMasters!=null)
                        dgvAuditMgmtDetail.Rows[index].Cells["AuditChkPoint"].Value = audMasters.Where(a => a.AuditMasterId == item.AuditMasterId).FirstOrDefault().AuditCheckPoint;
                        dgvAuditMgmtDetail.Rows[index].Cells["ObsNarr"].Value = item.NarrationOb;
                        dgvAuditMgmtDetail.Rows[index].Cells["obsRootCauseAuditee"].Value = item.RootCauseObsAuditee;
                        dgvAuditMgmtDetail.Rows[index].Cells["obsRootCauseAuditor"].Value = item.RootCauseObsAuditor;
                        dgvAuditMgmtDetail.Rows[index].Cells["corrAction"].Value = item.CorrectiveAction;
                        dgvAuditMgmtDetail.Rows[index].Cells["audStatus"].Value = AuditStatusEnumIntToValue(item.AuditStatus);
                        dgvAuditMgmtDetail.Rows[index].Cells["prevAction"].Value = item.PreventiveAction;
                        dgvAuditMgmtDetail.Rows[index].Cells["UploadImg"].Value = item.UploadedImg;
                        dgvAuditMgmtDetail.Rows[index].Cells["complDate"].Value =item.CompletionDate;
                        dgvAuditMgmtDetail.Columns["personResp"].Visible = true;
                        dgvAuditMgmtDetail.Rows[index].Cells["personResp"].Value = GlobalDeclaration.GetUserName(item.ResponsPersonId);
                        //if (string.IsNullOrEmpty(item.ResponsPersonId)) dgvAuditMgmtDetail.Columns["personResp"].Visible = false;
                        dgvAuditMgmtDetail.Rows[index].Cells["AuditManIdDtl"].Value = item.AuditManId;
                        dgvAuditMgmtDetail.Rows[index].Cells["AudMgmtDtlId"].Value = item.AuditManDetId;
                        dgvAuditMgmtDetail.Rows[index].Cells["RiskCate"].Value = item.RiskCategory;

                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }

        //public void MapObjectToControl(AuditManagement admgmt)
        //{
        //    admgmt.AuditCode = txtAuditCode.Text;
        //    admgmt.CreatedDate = dtpCreatedDate.Value;
        //    admgmt.CreatedBy = txtCreatedBy.Text;
        //    admgmt.AuditorId = txtAuditor.Text;
        //    admgmt.AuditeeId = txtAuditee.Text;
        //    admgmt.DepartmentId = GlobalDeclaration.GetDeptId(txtDept.Text);
        //    admgmt.AreaId = txtArea.Text;
        //    admgmt.AuditType = txtAuditType.Text;
        //    admgmt.FinancialYear = txtFinYear.Text;
        //    admgmt.FinancialQuarter = txtFinQtr.Text;
        //    admgmt.OperationUnit = txtOpUnit.Text;
        //    admgmt.AuditClosureDate = dtpTrgtClosDate.Value;
        //    admgmt.AuditStartDate = dtpAudStartDate.Value;
        //    admgmt.Status = GlobalDeclaration.DocStatusValueToInt(txtStatus.Text);
        //    admgmt.AuditEndDate = dtpAudEndDate.Value;
        //    admgmt.CommiteeMemId = txtAudCommMem.Text;
        //    admgmt.ExpectedAuditMonth = cmbAuditMonth.Text;
        //}

        public void MapControlToObject(AuditManagement admgmt)
        {
            admgmt.AuditManId = auditManId;
            admgmt.AuditPlanID = auditPlanId;
            admgmt.AuditCode = txtAuditCode.Text;
            admgmt.CreatedDate = dtpCreatedDate.Value;
            admgmt.CreatedBy = GlobalDeclaration.GetUserId(txtCreatedBy.Text);
            admgmt.AuditorId = GlobalDeclaration.GetUserId(txtAuditor.Text);
            admgmt.AuditeeId = GlobalDeclaration.GetUserId(txtAuditee.Text);
            admgmt.DepartmentId = GlobalDeclaration.GetDeptId(txtDept.Text);
            if (string.IsNullOrWhiteSpace(txtArea.Text))
                admgmt.AreaId = "NA";
            else
                admgmt.AreaId = txtArea.Text;
            admgmt.AuditType = txtAuditType.Text;
            admgmt.FinancialYear = txtFinYear.Text;
            admgmt.FinancialQuarter = txtFinQtr.Text;
            admgmt.OperationUnit = txtOpUnit.Text;
            admgmt.AuditClosureDate = dtpTrgtClosDate.Value;
            admgmt.AuditStartDate = dtpAudStartDate.Value;
            admgmt.Status = GlobalDeclaration.DocStatusValueToInt(txtStatus.Text);
            admgmt.Remarks = txtRemarks.Text;
           
            admgmt.AuditEndDate = dtpAudEndDate.Value;
            admgmt.CommiteeMemId = GlobalDeclaration.GetUserId(txtAudCommMem.Text);
            if (string.IsNullOrWhiteSpace(cmbAuditMonth.Text))
                admgmt.ExpectedAuditMonth = "NA";
            else
                admgmt.ExpectedAuditMonth = cmbAuditMonth.Text;
            admgmt.AuditPlanUpdatedBy = GlobalDeclaration.GetUserId(UserName);
            admgmt.AuditPlanUpdatedDate = DateTime.Today;
        }

        private void HideShowActioncontrol()
        {
            btnDelete.Visible = false;
            btnAddObs.Visible = true;
            btnReject.Visible = true;
            btnSave.Visible = true;
            btnSave.Text = "Submit";

            //btnAuditUpd.Visible = true;

            if (RoleId == 7)// && txtStatus.Text == DocStatus.Prepare.ToString())
            {
                btnAddObs.Visible = false;

                if (txtStatus.Text == DocStatus.Open.ToString())
                {
                    btnSave.Visible = false;
                    btnReject.Visible = false;
                }
                if (txtStatus.Text == DocStatus.SubmitForClosure.ToString())
                {
                    btnSave.Visible = true;
                    btnSave.Text = "Close";
                }
                if (txtStatus.Text == DocStatus.Closed.ToString())
                {
                    btnSave.Visible = false;
                    btnReject.Visible = false;
                    btnSave.Text = "Close";
                }
                if (txtStatus.Text == DocStatus.Accepted.ToString())
                {
                    btnSave.Visible = true;
                    btnReject.Visible = false;
                    btnSave.Text = "Open";
                    
                }
                if (txtStatus.Text == DocStatus.Rejected.ToString())
                {
                    btnSave.Visible = false;
                    btnReject.Visible = false;
                    btnSave.Text = "Close";
                }
            }

            if (RoleId == 13)// && txtStatus.Text == DocStatus.Prepare.ToString())
            {
                btnAddObs.Visible = false;
               
                if (txtStatus.Text == DocStatus.Open.ToString() || txtStatus.Text == DocStatus.HeadRejected.ToString())
                {
                    btnSave.Visible = false;
                    btnReject.Visible = false;
                }
                if (txtStatus.Text == DocStatus.SubmitForClosure.ToString())
                {
                    btnSave.Visible = true;
                    btnSave.Text = "Close";
                }
                if (txtStatus.Text == DocStatus.Submitted.ToString())
                {
                    btnSave.Visible = false;
                    btnReject.Visible = false;
                }
                if (txtStatus.Text == DocStatus.Closed.ToString())
                {
                    btnSave.Visible = false;
                    btnReject.Visible = false;
                    btnSave.Text = "Close";
                }
                if (txtStatus.Text == DocStatus.Accepted.ToString())
                {
                    btnSave.Visible = false;
                    btnReject.Visible = false;
                    btnSave.Text = "Close";
                }
                if (txtStatus.Text == DocStatus.Rejected.ToString())
                {
                    btnSave.Visible = false;
                    btnReject.Visible = false;
                    btnSave.Text = "Close";
                }
            }
            if (RoleId == 11)// && txtStatus.Text == DocStatus.Prepare.ToString())
            {
                btnAddObs.Visible = false;
                if (txtStatus.Text == DocStatus.Open.ToString())
                {
                    btnReject.Visible = false;
                    btnSave.Visible = false;
                }
                if (txtStatus.Text == DocStatus.Submitted.ToString())
                {
                    btnReject.Visible = true;
                    btnSave.Visible = true;
                    btnSave.Text = "Accept";
                }
                //if (txtStatus.Text == DocStatus.Accepted.ToString())
                //{
                //    btnReject.Visible = false;
                //    btnSave.Visible = true;
                //    btnSave.Text = "Close";
                //}
                if (txtStatus.Text == DocStatus.SubmitForClosure.ToString())
                {
                    btnReject.Visible = false;
                    btnSave.Visible = false;
                    btnSave.Text = "Close";
                }
                if (txtStatus.Text == DocStatus.Accepted.ToString() || txtStatus.Text == DocStatus.HeadRejected.ToString())
                {
                    btnReject.Visible = false;
                    btnSave.Visible = true;
                    btnSave.Text = "Close";
                }
                if (txtStatus.Text == DocStatus.Rejected.ToString() || txtStatus.Text == DocStatus.Closed.ToString())
                {
                    btnReject.Visible = false;
                    btnSave.Visible = false;
                    btnSave.Text = "Close";
                }
            }
            if (RoleId == 12)// && txtStatus.Text == DocStatus.Prepare.ToString())
            {
                btnReject.Visible = false;
                if (txtStatus.Text != DocStatus.Open.ToString())
                {
                    btnAddObs.Visible = false;
                    //btnReportAudit.Visible = true;
                }
                if (txtStatus.Text == DocStatus.Submitted.ToString() || txtStatus.Text == DocStatus.Accepted.ToString()|| txtStatus.Text == DocStatus.Closed.ToString() || txtStatus.Text == DocStatus.SubmitForClosure.ToString() || txtStatus.Text == DocStatus.HeadRejected.ToString())
                {
                    btnSave.Visible = false;
                    //btnReportAudit.Visible = true;
                }
                //if (txtStatus.Text == DocStatus.Accepted.ToString())
                //{
                //    btnSave.Visible = false;
                //    //btnReportAudit.Visible = true;
                //}
                //if (txtStatus.Text == DocStatus.Closed.ToString())
                //{
                //    btnSave.Visible = false;
                //    //btnReportAudit.Visible = true;
                //}

            }
            if (RoleId == 14)// && txtStatus.Text == DocStatus.Prepare.ToString())
            {
                btnReject.Visible = false;
                btnAddObs.Visible = false;
                btnSave.Visible = false;
            }
            if (RoleId == 15)// && txtStatus.Text == DocStatus.Prepare.ToString())
            {
                btnReject.Visible = false;
                btnAddObs.Visible = false;
                btnSave.Visible = false;
            }
        }

        #endregion

        private async void btnAddObs_Click(object sender, EventArgs e)
        {
            ////if (txtStatus.Text != DocStatus.Open.ToString()) return;
            ////await GenerateAutoDocDetail(txtAuditCode.Text+"/O-", "AuditManagementDetails", auditManId);
           //// AuditMgmtDetailView audMgmtDetailview = new AuditMgmtDetailView(auditManId, AuditGlobalCode, GlobalDeclaration.GetDeptId(txtDept.Text));
           
            AuditMgmtDetailView audMgmtDetailview = new AuditMgmtDetailView(auditManId,txtAuditCode.Text, GlobalDeclaration.GetDeptId(txtDept.Text));
            audMgmtDetailview.TopMost = true;
            audMgmtDetailview.GetValue += AudMgmtDetailHandlerEvent;

            if (audMgmtDetailview.ShowDialog() == DialogResult.OK)
            {
                XtraMessageBox.Show("Observation Added Successfully.");
                Thread.Sleep(500);
                if (RoleId == 15)
                {
                    GetAuditDetailingByCapUserId(auditManId, UserName);
                }
                else
                    GetAuditDetailingByManId(auditManId);
            }
        }

        private void AudMgmtDetailHandlerEvent(object sender, string value)
        {
            
            if (RoleId == 15)
            {
                GetAuditDetailingByCapUserId(auditManId, UserName);
            }
            else
            GetAuditDetailingByManId(auditManId);
        }
        //private void AudMgmtDetailHandlerEventExt(object sender, string value)
        //{
        //    if (RoleId == 15)
        //    {
        //        GetAuditDetailingByCapUserId(auditManId,UserName);
        //    }
        //    else
        //    GetAuditDetailingByManId(auditManId);
        //}
        private void SetAuditCalenderValue (AuditCalender item)
        {
            adCalender = null;
            adCalender = new AuditCalender();
            adCalender.AuditplanId = item.AuditplanId;
            adCalender.AuditCode = item.AuditCode;
            adCalender.CreatedDate =item.CreatedDate;
            adCalender.CreatedBy = item.CreatedBy;
            adCalender.ExpectedClosureMonth = item.ExpectedClosureMonth;
            adCalender.FinancialYear = item.FinancialYear;
            adCalender.FinancialQuarter = item.FinancialQuarter;
            adCalender.AuditType = item.AuditType;
            adCalender.AuditClosureDate = item.AuditClosureDate;
            adCalender.AuditStartDate = item.AuditStartDate;
            adCalender.AuditEndDate = item.AuditEndDate;
            adCalender.DepartmentId = item.DepartmentId;
            adCalender.OperationUnit = item.OperationUnit;
            adCalender.AuditorId = item.AuditorId;
            adCalender.AuditeeId = item.AuditeeId;
            adCalender.CommitteeMemId = item.CommitteeMemId;
            adCalender.DocStatus = item.DocStatus;
        }
        public void DisableControls()
        {
            txtAuditCode.Enabled = false;
            dtpCreatedDate.Enabled = false;
            txtAudCommMem.Enabled = false;
            txtCreatedBy.Enabled = false;
            txtOpUnit.Enabled = false;
            txtDept.Enabled = false;
            txtArea.Enabled = false;
            txtAuditType.Enabled = false;
            txtAuditor.Enabled = false;
            txtAuditee.Enabled = false;
            txtFinYear.Enabled = false;
            txtFinQtr.Enabled = false;
            dtpAudStartDate.Enabled = false;
            //dtpAudEndDate.Enabled = false;
            cmbAuditMonth.Enabled = false;
            txtStatus.Enabled = false;
            txtRemarks.ReadOnly = true;
            dtpTrgtClosDate.Enabled = false;
            dgvAuditMgmtDetail.Enabled = true;
            dgvAuditMgmtDetail.ReadOnly = false;

            if (RoleId == 11)
            {
                if (txtStatus.Text == DocStatus.Submitted.ToString())
                {
                    dgvAuditMgmtDetail.ReadOnly = true;
                }
                if (txtStatus.Text == DocStatus.Rejected.ToString())
                {
                     txtRemarks.ReadOnly = true;
                }
            }
        }
        private void dgvViewAuditExeData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                AuditHelper.ValidateTokenExpiration();
                if (e.RowIndex < 0) return;
                //ResetControls();
               
                txtAuditCode.Text = dgvViewAuditExeData.Rows[e.RowIndex].Cells["AuditCode"].Value.ToString();
                dtpCreatedDate.Text = dgvViewAuditExeData.Rows[e.RowIndex].Cells["CreatedDate"].Value.ToString();
                if (dgvViewAuditExeData.Rows[e.RowIndex].Cells["CreatedBy"].Value != null)
                    txtCreatedBy.Text = dgvViewAuditExeData.Rows[e.RowIndex].Cells["CreatedBy"].Value.ToString();
                if (dgvViewAuditExeData.Rows[e.RowIndex].Cells["Auditor"].Value != null)
                    txtAuditor.Text = dgvViewAuditExeData.Rows[e.RowIndex].Cells["Auditor"].Value.ToString();
                if (dgvViewAuditExeData.Rows[e.RowIndex].Cells["TargetClosDate"].Value != null)
                {
                    if (dgvViewAuditExeData.Rows[e.RowIndex].Cells["TargetClosDate"].Value.ToString() != DateTime.MinValue.ToString())
                        dtpTrgtClosDate.Value = DateTime.Parse(dgvViewAuditExeData.Rows[e.RowIndex].Cells["TargetClosDate"].Value.ToString());
                    else
                        dtpTrgtClosDate.Value = DateTime.Today;
                }
                 if (dgvViewAuditExeData.Rows[e.RowIndex].Cells["AuditEndDate"].Value != null)
                    dtpAudEndDate.Text = dgvViewAuditExeData.Rows[e.RowIndex].Cells["AuditEndDate"].Value.ToString();
                if (dgvViewAuditExeData.Rows[e.RowIndex].Cells["AuditStartDate"].Value != null)
                    dtpAudStartDate.Text = dgvViewAuditExeData.Rows[e.RowIndex].Cells["AuditStartDate"].Value.ToString();
                if(dgvViewAuditExeData.Rows[e.RowIndex].Cells["ExpCloseMonth"].Value!=null)
                cmbAuditMonth.Text = dgvViewAuditExeData.Rows[e.RowIndex].Cells["ExpCloseMonth"].Value.ToString();
                txtOpUnit.Text = dgvViewAuditExeData.Rows[e.RowIndex].Cells["OperationUnit"].Value.ToString();
                txtDept.Text = dgvViewAuditExeData.Rows[e.RowIndex].Cells["Department"].Value.ToString();
                txtFinQtr.Text = dgvViewAuditExeData.Rows[e.RowIndex].Cells["FinQuarter"].Value.ToString();
                txtAuditType.Text = dgvViewAuditExeData.Rows[e.RowIndex].Cells["AuditType"].Value.ToString();
                if (dgvViewAuditExeData.Rows[e.RowIndex].Cells["Auditee"].Value != null)
                    txtAuditee.Text = dgvViewAuditExeData.Rows[e.RowIndex].Cells["Auditee"].Value.ToString();
                if (dgvViewAuditExeData.Rows[e.RowIndex].Cells["AuditCommMem"].Value != null)
                   txtAudCommMem .Text = dgvViewAuditExeData.Rows[e.RowIndex].Cells["AuditCommMem"].Value.ToString();
                txtFinYear.Text = dgvViewAuditExeData.Rows[e.RowIndex].Cells["FinYear"].Value.ToString();
                txtStatus.Text = dgvViewAuditExeData.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                auditPlanId = Guid.Parse(dgvViewAuditExeData.Rows[e.RowIndex].Cells["AuditPlanId"].Value.ToString());
                auditManId = Guid.Parse(dgvViewAuditExeData.Rows[e.RowIndex].Cells["AuditManId"].Value.ToString());
                if(dgvViewAuditExeData.Rows[e.RowIndex].Cells["Remarks"].Value!=null)
                txtRemarks.Text = dgvViewAuditExeData.Rows[e.RowIndex].Cells["Remarks"].Value.ToString();
                AuditMgmtPages.SelectedIndex = 1;

                //Guid guid = new Guid("f715cecb-9c30-4e6a-afe1-e6e192b21d61");
                if(RoleId==15)
                {
                    GetAuditDetailingByCapUserId(auditManId, UserId);
                }
                else
                GetAuditDetailingByManId(auditManId);
                HideShowActioncontrol();
                DisableControls();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AuditMgmtPages.SelectedIndex = 0;
            AuditHelper.ValidateTokenExpiration();
            PopulateCommonDataToGrid();
        }

        private void dgvAuditMgmtDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                //ResetControls();
                AuditHelper.ValidateTokenExpiration();
                AuditManagementDetail admdtl = new AuditManagementDetail();
                admdtl.SrlNo= dgvAuditMgmtDetail.Rows[e.RowIndex].Cells["SrlNo"].Value.ToString();
                admdtl.CateOfObs = dgvAuditMgmtDetail.Rows[e.RowIndex].Cells["ObsCate"].Value.ToString();
                admdtl.DeviaSafetyStd = dgvAuditMgmtDetail.Rows[e.RowIndex].Cells["DevSafetyStd"].Value.ToString();
                AuditCheckPoint = dgvAuditMgmtDetail.Rows[e.RowIndex].Cells["AuditChkPoint"].Value.ToString();
                admdtl.NarrationOb = dgvAuditMgmtDetail.Rows[e.RowIndex].Cells["ObsNarr"].Value.ToString();
                admdtl.RootCauseObsAuditee = dgvAuditMgmtDetail.Rows[e.RowIndex].Cells["obsRootCauseAuditee"].Value.ToString();
                admdtl.RootCauseObsAuditor = dgvAuditMgmtDetail.Rows[e.RowIndex].Cells["obsRootCauseAuditor"].Value.ToString();
                admdtl.RiskCategory = dgvAuditMgmtDetail.Rows[e.RowIndex].Cells["RiskCate"].Value.ToString();
                if (((byte[])(dgvAuditMgmtDetail.Rows[e.RowIndex].Cells["UploadImg"].Value)).Length>0)
                {
                    admdtl.UploadedImg = (byte[])(dgvAuditMgmtDetail.Rows[e.RowIndex].Cells["UploadImg"].Value);
                }
                admdtl.CorrectiveAction = dgvAuditMgmtDetail.Rows[e.RowIndex].Cells["corrAction"].Value.ToString();
                admdtl.PreventiveAction = dgvAuditMgmtDetail.Rows[e.RowIndex].Cells["prevAction"].Value.ToString();
                if(!string.IsNullOrWhiteSpace(dgvAuditMgmtDetail.Rows[e.RowIndex].Cells["personResp"].Value.ToString()))
                admdtl.ResponsPersonId =GlobalDeclaration.GetUserId(dgvAuditMgmtDetail.Rows[e.RowIndex].Cells["personResp"].Value.ToString());
                admdtl.CompletionDate =DateTime.Parse(dgvAuditMgmtDetail.Rows[e.RowIndex].Cells["complDate"].Value.ToString());
                admdtl.AuditManDetId =Guid.Parse(dgvAuditMgmtDetail.Rows[e.RowIndex].Cells["AudMgmtDtlId"].Value.ToString());
                admdtl.AuditManId =Guid.Parse(dgvAuditMgmtDetail.Rows[e.RowIndex].Cells["AuditManIdDtl"].Value.ToString());
                admdtl.AuditStatus = AuditStatusValueToInt(dgvAuditMgmtDetail.Rows[e.RowIndex].Cells["AudStatus"].Value.ToString());
                CreateAuditMgmtDetailView(admdtl,AuditCheckPoint, GlobalDeclaration.GetDeptId(txtDept.Text),txtStatus.Text);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int AuditStatusValueToInt(string EnumValue)
        {
            int iVal;
            iVal = (int)((AuditStatus)Enum.Parse(typeof(AuditStatus), EnumValue, true));
            return iVal;
        }
        private string AuditStatusEnumIntToValue(int val)
        {
            string sVal;
            sVal = ((AuditStatus)val).ToString();// Enum.Parse(typeof(DocStatus), val, true);
            return sVal;
        }

        public AuditMgmtDetailView CreateAuditMgmtDetailView(AuditManagementDetail admDv,string adChkpnt,int deptid,string prStatus)
        {
            AuditMgmtDetailView auditMgmtDetailView = new AuditMgmtDetailView(admDv,adChkpnt, deptid, prStatus);
            
            auditMgmtDetailView.MapObjectToControl(admDv,adChkpnt);
            auditMgmtDetailView.TopMost = true;
            auditMgmtDetailView.GetValue += AudMgmtDetailHandlerEvent;

            if (auditMgmtDetailView.ShowDialog() == DialogResult.OK)
            {
                //XtraMessageBox.Show("Observation updated successfuly");
                Thread.Sleep(500);
                if (RoleId == 15)
                {
                    GetAuditDetailingByCapUserId(auditManId, UserId);
                }
                else
                {
                    GetAuditDetailingByManId(auditManId);
                }
            }

            return auditMgmtDetailView;
        }
        public bool ValidateAuditDetailToClosure()
        {
            return false;
        }
        //private Image GetImage(byte[] bytearr)
        //{
        //    System.IO.MemoryStream ms = new System.IO.MemoryStream(bytearr);
        //    Image i = Image.FromStream(ms);
        //    return i;
        //}

        public void AuditMgmtGridAppearance(DataGridViewRow dr, string status)
        {
            if (status == DocStatus.Open.ToString())
            {
                if (RoleId == 13 || RoleId == 14 || RoleId == 11)
                {
                    dr.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                if (RoleId == 12)
                {
                    dr.DefaultCellStyle.BackColor = Color.Orange;
                }
            }
           
            if (status == DocStatus.Submitted.ToString())
            {
                if (RoleId == 11)
                {
                    dr.DefaultCellStyle.BackColor = Color.Orange;
                }
                if (RoleId == 12 || RoleId == 13 || RoleId == 14)
                {
                    dr.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
            if (status == DocStatus.Accepted.ToString())
            {
                if (RoleId == 11 || RoleId == 12 || RoleId == 13 || RoleId == 14)
                {
                    dr.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                if (RoleId == 15)
                {
                    dr.DefaultCellStyle.BackColor = Color.Orange;
                }
            }
            if (status == DocStatus.Rejected.ToString())
            {
                if (RoleId == 12 || RoleId == 13 || RoleId == 14 || RoleId == 15)
                {
                    dr.DefaultCellStyle.BackColor = Color.Red;
                }
                if (RoleId == 11)
                {
                    dr.DefaultCellStyle.BackColor = Color.Red;
                }
            }
            if (status == DocStatus.SubmitForClosure.ToString())
            {
                if (RoleId == 13 || RoleId == 14 || RoleId == 11)
                {
                    dr.DefaultCellStyle.BackColor = Color.Gray;
                }
            }
            if (status == DocStatus.Closed.ToString())
            {
                //if (RoleId == 13 || RoleId == 14 || RoleId == 11)
                {
                    dr.DefaultCellStyle.BackColor = Color.Gray;
                }
            }
        }

        public void AuditDetailGridAppearance(DataGridViewRow dr, string status)
        {
            if (status == AuditStatus.Prepare.ToString() || status == AuditStatus.Open.ToString())
            {
                if (RoleId == 13 || RoleId == 14 || RoleId == 11)
                {
                    dr.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                if (RoleId == 12)
                {
                    dr.DefaultCellStyle.BackColor = Color.Orange;
                }
            }

            if (status == AuditStatus.Submitted.ToString())
            {
                if (RoleId == 11)
                {
                    dr.DefaultCellStyle.BackColor = Color.Orange;
                }
                if (RoleId == 12 || RoleId == 13 || RoleId == 14)
                {
                    dr.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
            if (status == AuditStatus.Assigned.ToString() || status == AuditStatus.ReAssigned.ToString())
            {
                if (RoleId == 12 || RoleId == 13 || RoleId == 14 || RoleId == 11)
                {
                    dr.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                if (RoleId == 15)
                {
                    dr.DefaultCellStyle.BackColor = Color.Orange;
                }
            }
            if (status == AuditStatus.CAPAClosed.ToString())
            {
                if (RoleId == 12 || RoleId == 13 || RoleId == 14 || RoleId == 15)
                {
                    dr.DefaultCellStyle.BackColor = Color.LightGray;
                }
                if (RoleId == 11)
                {
                    dr.DefaultCellStyle.BackColor = Color.Orange;
                }
            }
            if (status == DocStatus.Closed.ToString())
            {
                if ( RoleId == 11 || RoleId==12 || RoleId == 15 || RoleId == 13 || RoleId == 14)
                {
                    dr.DefaultCellStyle.BackColor = Color.Gray;
                }
            }
        }

        public void PopulateCommonDataToGrid()
        {
            if (RoleId == 12)// && txtStatus.Text == DocStatus.Open.ToString())
            {
                GetAuditManagementByDU(UserId);
            }
            if (RoleId == 11)// && txtStatus.Text == DocStatus.Open.ToString())
            {
                GetAuditManagementByDH(UserId);
            }
            if (RoleId == 13)// && txtStatus.Text == DocStatus.Open.ToString())
            {
                GetAuditManagementByCreatedBy(UserId);
            }
            if (RoleId == 14)// && txtStatus.Text == DocStatus.Open.ToString())
            {
                GetAuditManagementByAuditCommMem(UserId);
            }
            if (RoleId == 15)// && txtStatus.Text == DocStatus.Open.ToString())
            {
                GetAuditManagementByCAPAUser(UserId);
            }
            if (RoleId == 7)// && txtStatus.Text == DocStatus.Open.ToString())
            {
                GetAllAuditManagementByAdminuser();
            }
        }
        private void SubmitAuditDetail(DataGridView dgView, AuditStatus adstatus)
        {
            for (int i = 0; i <= dgView.Rows.Count-1; i++)
            {
             MapAuditDetailGridToObject(dgView, i,adstatus);
            }
            //return dgView.Rows.Count;
        }

        public async void MapAuditDetailGridToObject(DataGridView dgv,int rowIndex,AuditStatus adstatus)
        {
            try
            {
                if (dgv.Rows[rowIndex].Cells["audStatus"].Value.ToString() == AuditStatus.CAPAClosed.ToString() || dgv.Rows[rowIndex].Cells["audStatus"].Value.ToString() == AuditStatus.Closed.ToString())
                    return;
                AuditManagementDetail adMgmtDetail = null;
                adMgmtDetail = new AuditManagementDetail();
                adMgmtDetail.AuditManDetId = (Guid)dgv.Rows[rowIndex].Cells["AudMgmtDtlId"].Value;
                adMgmtDetail.AuditManId = auditManId;
                adMgmtDetail.SrlNo = dgv.Rows[rowIndex].Cells["SrlNo"].Value.ToString();
                adMgmtDetail.CateOfObs = dgv.Rows[rowIndex].Cells["ObsCate"].Value.ToString();
                adMgmtDetail.DeviaSafetyStd = dgv.Rows[rowIndex].Cells["DevSafetyStd"].Value.ToString();
                adMgmtDetail.AuditMasterId = audMasters.Where(a => a.AuditCheckPoint == dgv.Rows[rowIndex].Cells["AuditChkPoint"].Value.ToString()).FirstOrDefault().AuditMasterId;
                adMgmtDetail.NarrationOb = dgv.Rows[rowIndex].Cells["ObsNarr"].Value.ToString();
                adMgmtDetail.RootCauseObsAuditee = dgv.Rows[rowIndex].Cells["obsRootCauseAuditee"].Value.ToString();
                adMgmtDetail.RootCauseObsAuditor = dgv.Rows[rowIndex].Cells["obsRootCauseAuditor"].Value.ToString();
                adMgmtDetail.RiskCategory = dgv.Rows[rowIndex].Cells["RiskCate"].Value.ToString();
                adMgmtDetail.ResponsPersonId = dgv.Rows[rowIndex].Cells["personResp"].Value.ToString();
                adMgmtDetail.CorrectiveAction = dgv.Rows[rowIndex].Cells["corrAction"].Value.ToString();
                adMgmtDetail.PreventiveAction = dgv.Rows[rowIndex].Cells["prevAction"].Value.ToString();
                adMgmtDetail.CompletionDate = DateTime.Parse(dgv.Rows[rowIndex].Cells["complDate"].Value.ToString());

                string str = string.Empty;
                byte[] bytes = Encoding.ASCII.GetBytes(str);
                if (dgv.Rows[rowIndex].Cells["UploadImg"].Value != null)
                    adMgmtDetail.UploadedImg = (byte[])dgv.Rows[rowIndex].Cells["UploadImg"].Value;// System.IO.File.ReadAllBytes(ImagePath);
                else
                    adMgmtDetail.UploadedImg = bytes;
                adMgmtDetail.AuditStatus = (int)adstatus;// AuditStatus.Submitted;
              await UpdateAuditMgmtDetail(adMgmtDetail);
            }
            catch(Exception ex)
            {

            }
        }

        public void PopulateClosedDataToGrid()
        {
            if (RoleId == 12)
            {
                GetAuditManagementByStatusDU(UserId,(int)DocStatus.Closed);
            }
            if (RoleId == 11)
            {
                GetAuditManagementByStatusDH(UserId, (int)DocStatus.Closed);
            }
            if (RoleId == 13)
            {
                GetAuditManagementByStatusCreatedby(UserId, (int)DocStatus.Closed);
            }
            if (RoleId == 14)
            {
                GetAuditMgmtByStatusAuditCommMem(UserId, (int)DocStatus.Closed);
            }
        }

        private async Task<List<AuditManagement>> FilterAuditMgmtData(string roleName, AuditFilter audFilter)
        {
            List<AuditManagement> ams = new List<AuditManagement>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/GetAuditFilterData/RoleName?roleName=" + roleName + "&Token=" + GlobalDeclaration.ApiToken;
                    url = GlobalDeclaration.CleanURL(url);
                   
                    var myContent = JsonConvert.SerializeObject(audFilter);
                    var requestContent = new StringContent(myContent, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(url, requestContent);
                   
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            ams = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditManagement>>(apiResponse);
                            BindAuditMgmtViewData(ams);
                        }
                        else
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                            {
                                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                                Console.WriteLine(response.StatusCode.ToString());
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

        public void InitiateDXGrid()
        {
            //DGVDetails.Columns.Clear();
            //DGVDetails.DataSource = oHCReport.BindColumn();
            //DGVDetails.InitNewRow += DGVGridview_InitNewRow;
            //if (oHCReport.CallingStatus == CallingStatus.Summary)
            //{
            //    FillSummaryData();
            //}
        }

        //private void DGVGridview_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    try
        //    {
        //        GridView view = sender as GridView;
        //        //if (oHCReport.CallingStatus == CallingStatus.New || oHCReport.CallingStatus == CallingStatus.Summary || oHCReport.CallingStatus == CallingStatus.Upload)
        //        {
        //            view.SetRowCellValue(e.RowHandle, "S.No.", oHCReport.SINO);
        //            view.SetRowCellValue(e.RowHandle, "Employee Code", oHCReport.EmployeeCode);
        //            view.SetRowCellValue(e.RowHandle, "Employee Name", oHCReport.EmployeeName);
        //            view.SetRowCellValue(e.RowHandle, "DOB", oHCReport.DOB);
        //            view.SetRowCellValue(e.RowHandle, "Gender", oHCReport.Gender);
        //            view.SetRowCellValue(e.RowHandle, "Aadhar Number", oHCReport.AadharNumber);
        //            view.SetRowCellValue(e.RowHandle, "Date Of Joining", oHCReport.DOJ);
        //            view.SetRowCellValue(e.RowHandle, "Department", oHCReport.DepartmentName);
        //            view.SetRowCellValue(e.RowHandle, "Employee Type", oHCReport.EmployeeType);
        //            view.SetRowCellValue(e.RowHandle, "Company", oHCReport.CompanyName);
        //            view.SetRowCellValue(e.RowHandle, "Chech-Up Date", oHCReport.CheckUpDate);
        //            view.SetRowCellValue(e.RowHandle, "Health Status", oHCReport.HealthStatus);
        //            view.SetRowCellValue(e.RowHandle, "Remarks", oHCReport.Remark);
        //            if (oHCReport.CallingStatus != CallingStatus.Upload)
        //            {
        //                view.SetRowCellValue(e.RowHandle, "Report", oHCReport.ReportPath);
        //                RepositoryItemPictureEdit pictureEdit = new RepositoryItemPictureEdit();
        //                pictureEdit.SizeMode = PictureSizeMode.Squeeze;
        //                pictureEdit.PictureStoreMode = PictureStoreMode.Image;
        //                DGVGridview.RepositoryItems.Add(pictureEdit);
        //                DGVGridview.OptionsView.RowAutoHeight = true;
        //                DGVGridview.Columns["Photo"].ColumnEdit = pictureEdit;
        //                DGVGridview.Columns["Photo"].OptionsColumn.FixedWidth = true;
        //                DGVGridview.Columns["Photo"].Width = 100;
        //                if (pictureEmp.Image != null && oHCReport.CallingStatus == CallingStatus.New)
        //                {
        //                    view.SetRowCellValue(e.RowHandle, "Photo", pictureEmp.Image);
        //                }
        //                else
        //                {
        //                    view.SetRowCellValue(e.RowHandle, "Photo", oHCReport.GetImageValue);
        //                }
        //            }

        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            AuditFilter auditFilter = null;
            auditFilter = new AuditFilter();
            auditFilter.AuditType = cmbAuditType.Text;
            if (cmbDept.SelectedItem != null)
                auditFilter.DepartmentId = GlobalDeclaration.GetDeptId(cmbDept.SelectedItem.ToString());
            string finYear = string.Empty;
            foreach (var item in chkCmbYear.CheckedItems)
            {
                finYear = finYear + "," + item.ToString();
            }
            finYear = finYear.Remove(0, 1);
            if (string.IsNullOrWhiteSpace(finYear))
            {
                MessageBox.Show("Please check valid financial year");
                return;
            }
            auditFilter.FromYear = finYear;// cmbfromYear.Text;
            auditFilter.ToYear = cmbToYear.Text;
            auditFilter.TableName = "tbl_auditManagement";
            auditFilter.UserId = UserId;
            await FilterAuditMgmtData(GlobalDeclaration._holdInfo[0].UserRole, auditFilter);
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            AuditHelper.ValidateTokenExpiration();
            cmbAuditType.Text = string.Empty;
            chkCmbYear.Text = string.Empty;
            cmbToYear.Text = string.Empty;
            cmbDept.Text = string.Empty;
            PopulateCommonDataToGrid();
        }
        public AuditMessage GetRemarkPopUp()
        {
            AuditMessage audMsg = new AuditMessage();
            audMsg.GetValue += AuditMessageHandlerEvent;
            if (audMsg.ShowDialog() == DialogResult.OK)
            {
                audMsg.Close();
                audMsg.Dispose();
            }     
            return audMsg;
        }
        private void AuditMessageHandlerEvent(params object[] objec)
        {
            remarkMsg = string.Empty;
            remarkMsg = objec[0].ToString();
            //txtRemarks.Text = remarkMsg;
        }
        private void AddRemarks(string defaultMsg,string userinfo,string remarks)
        {
            defaultMsg += String.Format("{0} {1} , Date: {2} ,Comments:  {3}\r\n",userinfo,UserName, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),remarks);
            txtRemarks.Text = defaultMsg;
        }

        private void txtRemarks_TextChanged(object sender, EventArgs e)
        {

        }
        public string GetDisplayName(string enumValue)
        {
            DocStatus docStatus =(DocStatus)GlobalDeclaration.DocStatusValueToInt(enumValue);
            string displayName;
            displayName = docStatus.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault()
                .GetCustomAttribute<DisplayAttribute>()?
                .GetName();
            if (String.IsNullOrEmpty(displayName))
            {
                displayName = enumValue.ToString();
            }
            return displayName;
        }

    }


    public class AuditManagement
    {
        public Guid AuditManId { set; get; }
        public string AuditCode { set; get; }
        public Guid AuditPlanID { set; get; }
        public DateTime CreatedDate { set; get; }
        public string CreatedBy { set; get; }
        public string OperationUnit { set; get; }
        public int DepartmentId { set; get; }
        public string AreaId { set; get; }
        public string AuditType { set; get; }
        public string AuditorId { set; get; }
        public string AuditeeId { set; get; }
        public string FinancialYear { set; get; }
        public string FinancialQuarter { set; get; }
        public DateTime AuditStartDate { set; get; }
        public DateTime AuditEndDate { set; get; }
        public string CommiteeMemId { set; get; }
        public string ExpectedAuditMonth { set; get; }
        public DateTime AuditClosureDate { set; get; }
        public string AuditPlanUpdatedBy { set; get; }
        public DateTime AuditPlanUpdatedDate { set; get; }
        public string Remarks { set; get; }
        public int Status { set; get; }
    }
    public class AuditManagementTemp
    {
        public Guid AuditManId { get; set; }
        public DateTime DateOfDeletion { get; set; }
        public string DeletedByUserName { get; set; }
        public Guid DeletionId { get; set; }
        public int DeptID { get; set; }
        public int GeoTeamId { get; set; }
        public string DeletedIPAddress { get; set; }
    }
}
