using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.AuditHind
{
    public partial class AuditMgmtDetailView : XtraForm
    {
        public AuditManagementDetail AuditManagementDetail { get; set; }
        public Guid auditMgmtDetailId  { get; set; }
        public Guid auditManId { get; set; }
        public string AuditGlobalCode { set; get; }
        public string ImagePath { get; set; }
        public string ParentStatus { get; set; }
        public int DeptId { set; get; }
        public int iCount { set; get; }
        public string UserId { set; get; }

        List<AuditCategory> auditCatgList = new List<AuditCategory>();
        List<AuditMaster> allAudMasters = new List<AuditMaster>();
        List<AuditMaster> auditMasterList = new List<AuditMaster>();

        

        public EventHandler<string> GetValue;
        public AuditMgmtDetailView()
        {
            InitializeComponent();
            //LoadUsersAll();
          txtStatus.Text=  AuditStatus.Prepare.ToString();
        }
        public AuditMgmtDetailView(Guid AuditManId,string serialNo,int deptId)
        {
            AuditManagementDetail = new AuditManagementDetail();
            InitializeComponent();
            auditManId = AuditManId;
            txtSrno.Text = serialNo;
            txtStatus.Text = AuditStatus.Prepare.ToString();
            DeptId = deptId;
            UserId = Properties.Settings.Default.UserID;
        }
        public AuditMgmtDetailView(AuditManagementDetail managementDetail,string adchkpnt,int deptId,string PrStatus)
        {
            AuditManagementDetail = new AuditManagementDetail();
            InitializeComponent();
            cmbAuditChkPnt.Text = adchkpnt;
            DeptId = deptId;
            ParentStatus = PrStatus;
            UserId = Properties.Settings.Default.UserID;
        }
        private void btnUaucPcBox_Click(object sender, EventArgs e)
        {
            ImagePath = browseImageFile();
            //if (string.IsNullOrEmpty(impath)) return;
            //UAUC.SnapImage = System.IO.File.ReadAllBytes(impath);
        }
        private void btnReOpen_Click(object sender, EventArgs e)
        {
            DialogResult drr = MessageBox.Show("Are you Sure ?", "Alert", MessageBoxButtons.YesNo);
            if (drr == DialogResult.Yes)
            {
                if (txtStatus.Text == "Submitted")
                {
                    txtStatus.Text = "Rejected";
                }
            }
        }
        public string browseImageFile()
        {
            string imgPath = string.Empty;
            try
            {
                OpenFileDialog opFileDialog = new OpenFileDialog();
                {
                    opFileDialog.InitialDirectory = @"C:\";
                    opFileDialog.Title = "Browse";
                    opFileDialog.CheckFileExists = true;
                    opFileDialog.CheckPathExists = true;
                    //DefaultExt = "txt",
                    opFileDialog.Filter = "Images(*.Jpeg;*.png;*.jpg;)|*.Jpeg;*.png;*.jpg;";
                    //FilterIndex = 2,
                    //RestoreDirectory = true,
                    opFileDialog.ReadOnlyChecked = false;
                    // ShowReadOnly = true
                }

                if (opFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //if (is_Redirected == true)
                    {
                        PictureBox imageControl = new PictureBox();
                        PcbxAuditMgmt.Image = new Bitmap(opFileDialog.FileName);
                        imgPath = opFileDialog.FileName;
                        PcbxAuditMgmt.SizeMode = PictureBoxSizeMode.StretchImage;

                    }
                    //else
                    //{
                    //    PcbxUauc.Image = new Bitmap(opFileDialog.FileName);
                    //    imgPath = openFileDialog1.FileName;
                    //}
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return imgPath;
        }
        /// <summary>
        /// Save 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    //Auditor Section
        //    if (Properties.Settings.Default.RoleID == 12 && txtStatus.Text == AuditStatus.Prepare.ToString())
        //    {
        //        //if (ValidateCommHeadLogin() == false) return;
        //        DialogResult dr = MessageBox.Show("Are you sure?", "Alert", MessageBoxButtons.YesNo);
        //        if (dr == DialogResult.No) return;
        //        MapControlToObject();
        //        AuditManagementDetail.ObsStatus = AuditStatusValueToInt(AuditStatus.Open.ToString());
        //        AddAuditMgmtDetail(AuditManagementDetail);
        //        txtSrno.Text = AuditStatus.Open.ToString();
        //        //DisableAllControl();
        //        //HideShowActioncontrol();
        //    }
        //}
        private void MapControlToObject()
        {
            //CheckAuditMgmtDetailData(auditManId, AuditCheckPointValToGuid(cmbAuditChkPnt.Text));

            //if (iCount > 0)
            //{
            //    XtraMessageBox.Show("Record already exist!");
            //    return;
            //}

            AuditManagementDetail = null;
            AuditManagementDetail = new AuditManagementDetail();
            AuditManagementDetail.AuditManDetId =Guid.NewGuid();
            AuditManagementDetail.AuditManId = auditManId;

            AuditManagementDetail.SrlNo = txtSrno.Text;
            AuditManagementDetail.CateOfObs = cmbObsCate.Text;
            AuditManagementDetail.DeviaSafetyStd = cmbSafetStdDev.Text;
            //AuditManagementDetail.AuditCheckPoint = cmbAuditChkPnt.Text;
            if (!string.IsNullOrWhiteSpace(cmbAuditChkPnt.Text))
                AuditManagementDetail.AuditMasterId = AuditCheckPointValToGuid(cmbAuditChkPnt.Text);
            //AuditManagementDetail.AuditType = "NA";// cm.Text;
            AuditManagementDetail.NarrationOb = txtNarrObs.Text;
            AuditManagementDetail.RootCauseObsAuditee = !string.IsNullOrEmpty(txtRtCauseObsAuditee.Text)? txtRtCauseObsAuditee.Text:"NA";
            AuditManagementDetail.RootCauseObsAuditor = txtRtCauseObsAuditor.Text;
            AuditManagementDetail.RiskCategory = cmbRiskCate.Text;// (txtAudDept.Text);
            AuditManagementDetail.ResponsPersonId =!string.IsNullOrEmpty(cmbResponsPerson.Text) ?GlobalDeclaration.GetUserId(cmbResponsPerson.Text) : "NA";
            AuditManagementDetail.CorrectiveAction = !string.IsNullOrEmpty(txtCorrAction.Text) ? txtCorrAction.Text : "NA";
            AuditManagementDetail.PreventiveAction = !string.IsNullOrEmpty(txtPrevAction.Text) ? txtPrevAction.Text : "NA";
            AuditManagementDetail.CompletionDate = dtpTrgtCloseDate.Value!=DateTime.MinValue? dtpTrgtCloseDate.Value :DateTime.Today;

            string str = string.Empty; 
            //converting string to array of bytes
            byte[] bytes = Encoding.ASCII.GetBytes(str);
            if (!string.IsNullOrEmpty(ImagePath))
                AuditManagementDetail.UploadedImg = GetByteFromImage(PcbxAuditMgmt.Image); //Convert.FromBase64String(ImagePath);// System.IO.File.ReadAllBytes(ImagePath);
            else
                AuditManagementDetail.UploadedImg = bytes;
            AuditManagementDetail.AuditStatus = (int)AuditStatus.Open;

        }

        public void MapObjectToControl(AuditManagementDetail adMgmtDetail)
        {
           
            auditMgmtDetailId=adMgmtDetail.AuditManDetId;
            auditManId= adMgmtDetail.AuditManId; 
            txtSrno.Text = adMgmtDetail.SrlNo;
            cmbObsCate.Text = adMgmtDetail.CateOfObs;
            cmbSafetStdDev.Text = adMgmtDetail.DeviaSafetyStd;
            ////cmbAuditChkPnt.Text = adMgmtDetail.AuditCheckPoint;
            cmbAuditChkPnt.Text=auditMasterList.Where(a => a.AuditMasterId == adMgmtDetail.AuditMasterId).FirstOrDefault().AuditCheckPoint;

            //adMgmtDetail.AuditType = "NA";
            txtNarrObs.Text = adMgmtDetail.NarrationOb; ;
            txtRtCauseObsAuditee.Text = adMgmtDetail.RootCauseObsAuditee; ;
            txtRtCauseObsAuditor.Text = adMgmtDetail.RootCauseObsAuditor; ;
            cmbRiskCate.Text = adMgmtDetail.RiskCategory; ;// (txtAudDept.Text);
            cmbResponsPerson.Text = adMgmtDetail.ResponsPersonId;
            txtCorrAction.Text = adMgmtDetail.CorrectiveAction; ;
            txtPrevAction.Text = adMgmtDetail.PreventiveAction; ;
            dtpTrgtCloseDate.Value = adMgmtDetail.CompletionDate; ;
            PcbxAuditMgmt.Image = GetImage(adMgmtDetail.UploadedImg) ;
            txtStatus.Text =AuditStatusEnumIntToValue(adMgmtDetail.AuditStatus);
            EnableDisableInputControl();
        }

        public void MapObjectToControl(AuditManagementDetail adMgmtDetail,string adchkpnt)
        {
            auditMgmtDetailId = adMgmtDetail.AuditManDetId;
            auditManId = adMgmtDetail.AuditManId;
            txtSrno.Text = adMgmtDetail.SrlNo;
            cmbObsCate.Text = adMgmtDetail.CateOfObs;
            cmbSafetStdDev.Text = adMgmtDetail.DeviaSafetyStd;
            cmbAuditChkPnt.Text = adchkpnt;

            //adMgmtDetail.AuditType = "NA";
            txtNarrObs.Text = adMgmtDetail.NarrationOb;
            txtNarrObs.Text=adMgmtDetail.NarrationOb;
            txtRtCauseObsAuditee.Text = adMgmtDetail.RootCauseObsAuditee;
            txtRtCauseObsAuditor.Text = adMgmtDetail.RootCauseObsAuditor;
            cmbRiskCate.Text = adMgmtDetail.RiskCategory; // (txtAudDept.Text);
            if(!string.IsNullOrEmpty(adMgmtDetail.ResponsPersonId))
            cmbResponsPerson.Text = GlobalDeclaration.GetUserName(adMgmtDetail.ResponsPersonId); //adMgmtDetail.ResponsPersonId!="NA"? GlobalDeclaration.GetUserName(adMgmtDetail.ResponsPersonId):"NA";
            if (adMgmtDetail.CorrectiveAction=="NA" && Properties.Settings.Default.RoleID==15)
                txtCorrAction.Text = "Write here...";
            else
            txtCorrAction.Text = adMgmtDetail.CorrectiveAction;

            if (adMgmtDetail.PreventiveAction == "NA" && Properties.Settings.Default.RoleID == 15)
                txtPrevAction.Text = "Write here...";
            else
                txtPrevAction.Text = adMgmtDetail.PreventiveAction;
            dtpTrgtCloseDate.Value = adMgmtDetail.CompletionDate;
            if(GetImage(adMgmtDetail.UploadedImg)!=null)
            PcbxAuditMgmt.Image = GetImage(adMgmtDetail.UploadedImg);
            txtStatus.Text = AuditStatusEnumIntToValue(adMgmtDetail.AuditStatus);
            EnableDisableInputControl();
        }
        public void MapControlToObject(AuditManagementDetail adMgmtDetail)
        {
            //adMgmtDetail = null;
            //adMgmtDetail = new AuditManagementDetail();
            adMgmtDetail.AuditManDetId = auditMgmtDetailId;
            adMgmtDetail.AuditManId = auditManId;
            adMgmtDetail.SrlNo = txtSrno.Text;
            adMgmtDetail.CateOfObs = cmbObsCate.Text;//.Value;
            adMgmtDetail.DeviaSafetyStd = cmbSafetStdDev.Text;
            ////adMgmtDetail.AuditCheckPoint = cmbAuditChkPnt.Text;
            adMgmtDetail.AuditMasterId =allAudMasters.Where(a => a.AuditCheckPoint == cmbAuditChkPnt.Text).FirstOrDefault().AuditMasterId;
            //adMgmtDetail.AuditType = "NA";
            adMgmtDetail.NarrationOb = txtNarrObs.Text;
            adMgmtDetail.RootCauseObsAuditee = txtRtCauseObsAuditee.Text;
            adMgmtDetail.RootCauseObsAuditor = txtRtCauseObsAuditor.Text;
            adMgmtDetail.RiskCategory = cmbRiskCate.Text;// (txtAudDept.Text);
            adMgmtDetail.ResponsPersonId = GlobalDeclaration.GetUserId(cmbResponsPerson.Text);
            adMgmtDetail.CorrectiveAction = txtCorrAction.Text;
            adMgmtDetail.PreventiveAction = txtPrevAction.Text;
            adMgmtDetail.CompletionDate = dtpTrgtCloseDate.Value;

            string str = string.Empty;
            byte[] bytes = Encoding.ASCII.GetBytes(str);

            if (GetByteFromImage(PcbxAuditMgmt.Image)!=null)
            adMgmtDetail.UploadedImg = GetByteFromImage(PcbxAuditMgmt.Image);// System.IO.File.ReadAllBytes(ImagePath);
            else
                adMgmtDetail.UploadedImg = bytes;
            adMgmtDetail.AuditStatus = AuditStatusValueToInt(txtStatus.Text);

          }

        
        public async Task<string> CheckAuditMgmtDetailData(Guid AuditManId,Guid AuditMasterId)
        {
            iCount = 0;
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/CheckAuditMgmtDetailData?AuditManId="+ AuditManId + "&AuditMasterId="+AuditMasterId;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await httpClient.GetAsync(url))
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
        private async Task<string> AddAuditMgmtDetail(AuditManagementDetail audMgmtDetail)
        {
            var responseString = string.Empty;
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var myContent = JsonConvert.SerializeObject(audMgmtDetail);
                    var requestContent = new StringContent(myContent, Encoding.UTF8, "application/json");
                    // var content = new FormUrlEncodedContent(auditCalendar);
                    string url = "https://hindalcoams.sparrowios.com/SaveAuditDetailing?Token=" + GlobalDeclaration.ApiToken;
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
                        DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return responseString;
        }
        private async Task<string> UpdateAuditMgmtDetail(AuditManagementDetail audMgmtDetail,string msg)
        {
            var responseString = string.Empty;
            // AuditCalendar auditCalendar=new AuditCalendar();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/" + "UpdateAuditDetailsTbl/" + audMgmtDetail.AuditManDetId+ "?Token="+GlobalDeclaration.ApiToken;
                    url =GlobalDeclaration.CleanURL(url);
                    var myContent = JsonConvert.SerializeObject(audMgmtDetail);
                    var requestContent = new StringContent(myContent, Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync(url, requestContent);
                    responseString = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        Console.WriteLine(response.StatusCode.ToString());
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        MessageBox.Show(msg);
                        DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {



            }
            return responseString;
        }
        private async Task<List<AuditCategory>> GetAllAudCategory()
        {
            //List<AuditCategory> auditCateList = new List<AuditCategory>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/GetAllAuditCategories?Token="+GlobalDeclaration.ApiToken;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    using (var response = await httpClient.GetAsync(GlobalDeclaration.CleanURL(url)))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            auditCatgList = JsonConvert.DeserializeObject<List<AuditCategory>>(apiResponse);
                            //GetAuditCategoryData(auditCateList);
                            foreach (var item in auditCatgList)
                            {
                                cmbSafetStdDev.Items.Add(item.AuditCategoryName);
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
                    return auditCatgList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return auditCatgList;
        }

        public async Task<List<AuditMaster>> GetAudMaster(Guid AuditCategoryId)
        {
            //List<AuditCategory> auditCateList = new List<AuditCategory>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/GetAuditMasterByCategoryId/{AuditCategoryId}?AuditCategorymId="+ AuditCategoryId+ "&Token="+GlobalDeclaration.ApiToken;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    using (var response = await httpClient.GetAsync( GlobalDeclaration.CleanURL(url)))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            auditMasterList = JsonConvert.DeserializeObject<List<AuditMaster>>(apiResponse);
                            //GetAuditCategoryData(auditCateList);
                            if (cmbAuditChkPnt.Items.Count > 0) cmbAuditChkPnt.Items.Clear();
                            foreach (var item in auditMasterList)
                            {
                                cmbAuditChkPnt.Items.Add(item.AuditCheckPoint);
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
                    return auditMasterList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return auditMasterList;
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
                            allAudMasters = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuditMaster>>(apiResponse);
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
                    return allAudMasters;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return allAudMasters;
        }

        public async Task<string> GenerateAutoDocDetail(string AudCode, string AuditRequestType, Guid adManId)
        {
            AuditGlobalCode = string.Empty;
            List<AuditCalender> aDms = new List<AuditCalender>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/GeneratAutoDocumentDetail?AudCode=" + AudCode + "&AudType=" + AuditRequestType + "&AuditManId=" + adManId + "&Token=" + GlobalDeclaration.ApiToken;
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
        private Image GetImage(byte[] bytearr)
        {
            Image i = null;
            System.IO.MemoryStream ms;
            if (bytearr != null)
            {
                ms = new System.IO.MemoryStream(bytearr);
                i = Image.FromStream(ms);
            }
            return i;
        }
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                if (Clipboard.GetData("Text") != null)
                    Clipboard.SetText((string)Clipboard.GetData("Text"), TextDataFormat.Text);
                else
                    e.Handled = true;
            }
        }
        /// <summary>
        /// Save,Submit,Assign,ReAssign,CapaClose
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            AuditHelper.ValidateTokenExpiration();
            //   Auditor Section
            if (Properties.Settings.Default.RoleID == 12)
            {
                if (txtStatus.Text == AuditStatus.Rejected.ToString())
                {
                    if (ValidateAuditorLogin() == false) return;
                    DialogResult dr = MessageBox.Show("Are you sure to submit?", "Alert", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.No) return;
                    MapControlToObject(AuditManagementDetail);
                    AuditManagementDetail.AuditStatus = AuditStatusValueToInt(AuditStatus.Submitted.ToString());
                    await UpdateAuditMgmtDetail(AuditManagementDetail,"Observation submitted successfully");
                    txtStatus.Text = AuditStatus.Submitted.ToString();
                    //DisableAllControl();
                    HideShowActioncontrol();

                }
                if (txtStatus.Text == AuditStatus.Open.ToString())
                {
                    if (ValidateAuditorLogin() == false) return;
                    DialogResult dr = MessageBox.Show("Are you sure to update?", "Alert", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.No) return;

                       MapControlToObject(AuditManagementDetail);
                        AuditManagementDetail.AuditStatus = AuditStatusValueToInt(AuditStatus.Open.ToString());
                        await UpdateAuditMgmtDetail(AuditManagementDetail, "Observation updated successfully");
                        txtStatus.Text = AuditStatus.Open.ToString();
                        //DisableAllControl();
                        HideShowActioncontrol();
                   
                }
                if (txtStatus.Text == AuditStatus.Prepare.ToString())
                {
                    if (ValidateAuditorLogin() == false) return;
                    DialogResult dr = MessageBox.Show("Are you sure to Save?", "Alert", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.No) return;

                    //change on 17/05/23
                    ////await  CheckAuditMgmtDetailData(auditManId, AuditCheckPointValToGuid(cmbAuditChkPnt.Text));

                    if (iCount > 0)
                    {
                        XtraMessageBox.Show("Record already exist!");
                        return;
                    }
                    else
                    {
                       
                        MapControlToObject();
                        await GenerateAutoDocDetail(txtSrno.Text + "/O-", "AuditManagementDetails", auditManId);
                        txtSrno.Text = AuditManagementDetail.SrlNo = AuditGlobalCode;
                        AuditManagementDetail.AuditStatus = AuditStatusValueToInt(AuditStatus.Open.ToString());// AuditStatus.Open.ToString());
                        await  AddAuditMgmtDetail(AuditManagementDetail);
                        txtStatus.Text = AuditStatus.Open.ToString();
                       
                        //DisableAllControl();
                        HideShowActioncontrol();
                    }
                }
            }
            // Auditee (DH) Section
            if (Properties.Settings.Default.RoleID == 11)
            {
                if (txtStatus.Text == AuditStatus.Submitted.ToString()|| txtStatus.Text == AuditStatus.Open.ToString())
                {
                    if (ValidateAuditeeLogin() == false) return;
                    DialogResult dr = MessageBox.Show("Are you sure to Assign?", "Alert", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.No) return;
                    MapControlToObject(AuditManagementDetail);
                    AuditManagementDetail.AuditStatus = AuditStatusValueToInt(AuditStatus.Assigned.ToString());
                    await UpdateAuditMgmtDetail(AuditManagementDetail,"Observation assigned successfully.");
                    txtStatus.Text= AuditStatus.Assigned.ToString();
                   
                }
                if (txtStatus.Text == AuditStatus.CAPAClosed.ToString())
                {
                    DialogResult dr = MessageBox.Show("Are you sure to Reassign?", "Alert", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.No) return;
                    MapControlToObject(AuditManagementDetail);
                    AuditManagementDetail.AuditStatus = AuditStatusValueToInt(AuditStatus.ReAssigned.ToString());
                    UpdateAuditMgmtDetail(AuditManagementDetail, "Observation reassigned successfully.");
                    txtStatus.Text= AuditStatus.ReAssigned.ToString();
                }
            }

            //CAPA User Section(Task Force)
            if (Properties.Settings.Default.RoleID == 15 && (txtStatus.Text == AuditStatus.Assigned.ToString() || txtStatus.Text == AuditStatus.ReAssigned.ToString()))
            {
                if (ValidateCAPAUserLogin() == false) return;
                DialogResult dr = MessageBox.Show("Are you sure to Close?", "Alert", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;
                MapControlToObject(AuditManagementDetail);
                AuditManagementDetail.AuditStatus = AuditStatusValueToInt(AuditStatus.CAPAClosed.ToString());
                UpdateAuditMgmtDetail(AuditManagementDetail, "Observation closed successfully.");
                txtStatus.Text = AuditStatus.CAPAClosed.ToString();
                
            }
            
            HideShowActioncontrol();
            //this.Close();
            DialogResult = DialogResult.OK;
            
            
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            AuditHelper.ValidateTokenExpiration();
            // Auditee (DH) Section
            if (Properties.Settings.Default.RoleID == 11 && txtStatus.Text == AuditStatus.Open.ToString())
            {
                DialogResult dr = MessageBox.Show("Are you sure to reject?", "Alert", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;
                MapControlToObject(AuditManagementDetail);
                AuditManagementDetail.AuditStatus = AuditStatusValueToInt(AuditStatus.Rejected.ToString());
                UpdateAuditMgmtDetail(AuditManagementDetail, "Observation rejected.");
                //DisableAllControl();
                //HideShowActioncontrol();
            }
            HideShowActioncontrol();
        }
        private void HideShowActioncontrol()
        {
            //btnSave.Visible = true;
            btnReject.Visible = true;
            btnReject.Visible = false;
            btnClose.Visible = false;
            btnSubmit.Text = "Submit";
            //btnAuditUpd.Visible = true;

            if (Properties.Settings.Default.RoleID == 7)
            {
                if (txtStatus.Text == AuditStatus.Submitted.ToString() || txtStatus.Text == AuditStatus.Open.ToString())
                {
                    //btnSave.Visible = false;
                    btnSubmit.Visible = false;

                    btnReject.Visible = false;
                    btnClose.Visible = false;
                }
                if (txtStatus.Text == AuditStatus.CAPAClosed.ToString() || txtStatus.Text == AuditStatus.Closed.ToString())
                {
                    //btnSave.Visible = false;
                    btnSubmit.Visible = false;
                    btnReject.Visible = false;
                    btnClose.Visible = false;
                }
                if (txtStatus.Text == AuditStatus.Assigned.ToString() || txtStatus.Text == AuditStatus.ReAssigned.ToString())
                {
                    //btnSave.Visible = false;
                    btnSubmit.Visible = true;
                    btnSubmit.Text = "Close";
                    btnReject.Visible = false;
                    btnClose.Visible = false;
                }
                if (txtStatus.Text == AuditStatus.Rejected.ToString())
                {
                    //btnSave.Visible = false;
                    btnSubmit.Visible = false;
                    btnReject.Visible = false;
                    btnClose.Visible = false;
                }
            }
            if (Properties.Settings.Default.RoleID == 11)// && txtStatus.Text == DocStatus.Prepare.ToString())
            {
                //btnAddObs.Visible = false;
                if (ParentStatus == DocStatus.Accepted.ToString())
                {

                    if (txtStatus.Text == AuditStatus.Submitted.ToString())
                    {
                        //if (ParentStatus == DocStatus.Accepted.ToString())
                        //{
                            btnSubmit.Visible = true;
                            btnSubmit.Text = "Assign";
                            btnReject.Visible = false;
                            btnClose.Visible = true;
                        //}
                        //if (ParentStatus == DocStatus.Submitted.ToString())
                        //{
                        //    btnSubmit.Visible = false;
                        //    //btnSubmit.Text = "Assign";
                        //    btnReject.Visible = false;
                        //    btnClose.Visible = false;
                        //}

                    }
                    if (txtStatus.Text == AuditStatus.Open.ToString())
                    {
                        btnSubmit.Visible = false;
                        //btnSubmit.Text = "Assign";
                        btnReject.Visible = false;
                        btnClose.Visible = false;

                    }
                    if (txtStatus.Text == AuditStatus.CAPAClosed.ToString())
                    {
                        btnSubmit.Visible = true;
                        btnSubmit.Text = "Reassign";
                        btnReject.Visible = false;
                        btnClose.Visible = true;
                    }
                    if (txtStatus.Text == AuditStatus.Assigned.ToString() || txtStatus.Text == AuditStatus.ReAssigned.ToString())
                    {
                        // btnSave.Visible = false;
                        btnSubmit.Visible = false;
                        btnReject.Visible = false;
                        btnClose.Visible = false;
                    }
                    if (txtStatus.Text == AuditStatus.Closed.ToString())
                    {
                        //btnSave.Visible = false;
                        btnSubmit.Visible = false;
                        btnReject.Visible = false;
                        btnClose.Visible = false;
                    }

                    if (txtStatus.Text == AuditStatus.Rejected.ToString())
                    {
                        //btnSave.Visible = false;
                        btnSubmit.Visible = false;
                        btnReject.Visible = false;
                        btnClose.Visible = false;
                    }
                }
                else
                {
                    btnSubmit.Visible = false;
                    //btnSubmit.Text = "Assign";
                    btnReject.Visible = false;
                    btnClose.Visible = false;

                }
            }
            if (Properties.Settings.Default.RoleID == 12)// && txtStatus.Text == DocStatus.Prepare.ToString())
            {
                //btnAddObs.Visible = false;
                if (txtStatus.Text == AuditStatus.Open.ToString())
                {
                    //btnSave.Visible = false;
                    btnSubmit.Visible = true;
                    btnSubmit.Text = "Save";
                    btnReject.Visible = false;
                    btnClose.Visible = false;
                }
                if (txtStatus.Text == AuditStatus.Prepare.ToString()|| txtStatus.Text == AuditStatus.Rejected.ToString())
                {
                    //btnSave.Visible = false;
                    btnSubmit.Visible = true;
                    btnSubmit.Text = "Save";
                    btnReject.Visible = false;
                    btnClose.Visible = false;
                }
                if (txtStatus.Text == AuditStatus.Submitted.ToString() || txtStatus.Text == AuditStatus.Assigned.ToString() || txtStatus.Text == AuditStatus.ReAssigned.ToString()|| txtStatus.Text == AuditStatus.Closed.ToString())
                {
                    //btnSave.Visible = false;
                    btnSubmit.Visible = false;
                    btnSubmit.Text = "Save";
                    btnReject.Visible = false;
                    btnClose.Visible = false;
                }
            }
            if (Properties.Settings.Default.RoleID == 13)
            {
                //btnSave.Visible = false;
                btnSubmit.Visible = false;
                btnReject.Visible = false;
                btnClose.Visible = false;
            }
            if (Properties.Settings.Default.RoleID == 14)
            {
                //btnSave.Visible = false;
                btnSubmit.Visible = false;
                btnReject.Visible = false;
                btnClose.Visible = false;
            }
            
            if (Properties.Settings.Default.RoleID == 15)
            {
                if (txtStatus.Text == AuditStatus.Submitted.ToString())
                {
                    //btnSave.Visible = false;
                    btnSubmit.Visible = false;
                    
                    btnReject.Visible = false;
                    btnClose.Visible = false;
                }
                if (txtStatus.Text == AuditStatus.CAPAClosed.ToString() || txtStatus.Text == AuditStatus.Closed.ToString())
                {
                    //btnSave.Visible = false;
                    btnSubmit.Visible = false;
                    btnReject.Visible = false;
                    btnClose.Visible = false;
                }
                if (txtStatus.Text == AuditStatus.Assigned.ToString() || txtStatus.Text == AuditStatus.ReAssigned.ToString())
                {
                    //btnSave.Visible = false;
                    btnSubmit.Visible = true;
                    btnSubmit.Text = "Close";
                    btnReject.Visible = false;
                    btnClose.Visible = false;
                }
                if (txtStatus.Text == AuditStatus.Rejected.ToString())
                {
                    //btnSave.Visible = false;
                    btnSubmit.Visible = false;
                    btnReject.Visible = false;
                    btnClose.Visible = false;
                }
            }
        }

        private void EnableDisableInputControl()
        {
            //Visibility
            txtRtCauseObsAuditor.Visible = true;
            lblCorrAction.Visible = true;
            lblPrevAction.Visible = true;
            txtCorrAction.Visible = true;
            txtPrevAction.Visible = true;
            dtpTrgtCloseDate.Visible = true;
            cmbResponsPerson.Visible = true;

            //Enability
            txtSrno.Enabled = false;
            ////txtNarrObs.Enabled = false;
            txtNarrObs.ReadOnly = true;
            txtStatus.Enabled = false;
            btnUaucPcBox.Enabled = false;
            cmbSafetStdDev.Enabled = false;
            cmbAuditChkPnt.Enabled = false;
            cmbObsCate.Enabled = false;
            cmbRiskCate.Enabled = false;

            //txtRtCauseObsAuditee.Enabled = false;
            //txtRtCauseObsAuditor.Enabled = false;
            
            txtRtCauseObsAuditee.ReadOnly = true;
            txtRtCauseObsAuditor.ReadOnly = true;
            txtCorrAction.ReadOnly = true;
            txtPrevAction.ReadOnly = true;
            //txtCorrAction.Enabled = false;
            //txtPrevAction.Enabled = false;
            dtpTrgtCloseDate.Enabled = false;
            cmbResponsPerson.Enabled = false;
            
            if (Properties.Settings.Default.RoleID == 11)
            {
                if (txtStatus.Text == AuditStatus.Open.ToString())
                {
                    txtNarrObs.ReadOnly = true;
                    txtCorrAction.Visible = false;
                    txtPrevAction.Visible = false;
                    lblCorrAction.Visible = false;
                    lblPrevAction.Visible = false;
                    dtpTrgtCloseDate.Enabled = false;
                    cmbResponsPerson.Enabled = false;
                    txtRtCauseObsAuditee.ReadOnly = true;
                    //txtRtCauseObsAuditee.Enabled = true;
                }
                if (txtStatus.Text == AuditStatus.Submitted.ToString() )
                {

                    if (ParentStatus == DocStatus.Accepted.ToString())
                    {
                        txtNarrObs.ReadOnly = true;
                        txtCorrAction.Visible = false;
                        txtPrevAction.Visible = false;
                        lblCorrAction.Visible = false;
                        lblPrevAction.Visible = false;
                        dtpTrgtCloseDate.Enabled = true;
                        txtRtCauseObsAuditee.ReadOnly = false;
                        if (txtRtCauseObsAuditee.Text == "NA")
                            txtRtCauseObsAuditee.Text = "write here..";
                        txtRtCauseObsAuditor.ReadOnly = true;
                        cmbResponsPerson.Enabled = true;
                    }
                    if (ParentStatus == DocStatus.Submitted.ToString())
                    {
                        txtNarrObs.ReadOnly = true;
                        txtCorrAction.Visible = false;
                        txtPrevAction.Visible = false;
                        lblCorrAction.Visible = false;
                        lblPrevAction.Visible = false;
                        dtpTrgtCloseDate.Enabled = false;
                        txtRtCauseObsAuditee.ReadOnly = true;
                        txtRtCauseObsAuditor.ReadOnly = true;
                        cmbResponsPerson.Enabled = false;
                    }

                }

                if (txtStatus.Text == AuditStatus.Assigned.ToString() || txtStatus.Text == AuditStatus.ReAssigned.ToString())
                {
                    txtNarrObs.ReadOnly = true;
                    txtCorrAction.Visible = false;
                    txtPrevAction.Visible = false;
                    lblCorrAction.Visible = false;
                    lblPrevAction.Visible = false;
                    dtpTrgtCloseDate.Enabled = true;
                    txtRtCauseObsAuditee.ReadOnly = true;
                    txtRtCauseObsAuditor.ReadOnly = true;
                    cmbResponsPerson.Enabled = false;

                }
                if (txtStatus.Text == AuditStatus.CAPAClosed.ToString())
                {
                    txtNarrObs.ReadOnly = true;
                    txtCorrAction.Visible = true;
                    txtPrevAction.Visible = true;
                    lblCorrAction.Visible = true;
                    lblPrevAction.Visible = true;
                    txtCorrAction.ReadOnly = true;
                    txtPrevAction.ReadOnly= true;
                    dtpTrgtCloseDate.Enabled = true;
                    cmbResponsPerson.Enabled = true;
                }
                
            }
            if (Properties.Settings.Default.RoleID == 12)
            {
               
                if (txtStatus.Text == AuditStatus.Open.ToString() || txtStatus.Text == AuditStatus.Prepare.ToString())
                {
                    //Enability
                    txtNarrObs.Enabled = true;
                    txtNarrObs.ReadOnly = false;
                    txtRtCauseObsAuditor.ReadOnly = false;
                    btnUaucPcBox.Enabled = true;
                    cmbAuditChkPnt.Enabled = true;
                    cmbObsCate.Enabled = true;
                    cmbResponsPerson.Enabled = true;
                    cmbSafetStdDev.Enabled = true;
                    cmbRiskCate.Enabled = true;

                    //Visibility
                    lblRtCauseObsAuditee.Visible = false;
                    txtRtCauseObsAuditee.Visible = false;
                    lblCorrAction.Visible = false;
                    lblPrevAction.Visible = false;
                    lblCorrAction.Visible = false;
                    txtCorrAction.Visible = false;
                    lblPrevAction.Visible = false;
                    txtPrevAction.Visible = false;
                    lblTrgtCloseDate.Visible = false;
                    dtpTrgtCloseDate.Visible = false;
                    lblOffcResponsCorr.Visible = false;
                    cmbResponsPerson.Visible = false;
                }
                
            }
           
            if (Properties.Settings.Default.RoleID == 15)
            {
                if (txtStatus.Text == AuditStatus.Assigned.ToString() || txtStatus.Text == AuditStatus.ReAssigned.ToString())
                {
                    txtCorrAction.Visible = true;
                    txtPrevAction.Visible = true;
                    dtpTrgtCloseDate.Visible = true;
                    cmbResponsPerson.Visible = true;
                    txtNarrObs.ReadOnly = true;
                    txtCorrAction.ReadOnly = false;
                    txtPrevAction.ReadOnly = false;
                    txtRtCauseObsAuditee.ReadOnly = true;
                    txtRtCauseObsAuditor.ReadOnly = true;
                }
                else
                {
                    txtCorrAction.Visible = true;
                    txtPrevAction.Visible = true;
                    dtpTrgtCloseDate.Visible = true;
                    cmbResponsPerson.Visible = true;
                    txtNarrObs.ReadOnly = true;
                    txtCorrAction.ReadOnly = true;
                    txtPrevAction.ReadOnly = true;
                }
            }
            //if (Properties.Settings.Default.RoleID == 14)
            //{
            //    btnSave.Visible = false;
            //    btnSubmit.Visible = false;
            //    btnReject.Visible = false;
            //    btnClose.Visible = false;
            //}
        }
        private Boolean ValidateAuditorLogin()
        {
            bool IsValid = true;

            if (String.IsNullOrWhiteSpace(txtNarrObs.Text))
            {
                XtraMessageBox.Show("Please fill [Narration of Observation] !");
                IsValid = false;
                return IsValid;
            }
            else if (!string.IsNullOrWhiteSpace(txtNarrObs.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(txtNarrObs.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in [Narration of Observation] !");
                    txtNarrObs.Focus();
                    IsValid = false;
                }
            }
            if (String.IsNullOrWhiteSpace(txtRtCauseObsAuditor.Text))
            {
                XtraMessageBox.Show("Please fill  [Root Cause of Observation (Auditor)] !");
                IsValid = false;
                return IsValid;
            }
            else if (!string.IsNullOrWhiteSpace(txtRtCauseObsAuditor.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(txtRtCauseObsAuditor.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in [Root Cause of Observation (Auditor)] !");
                    txtNarrObs.Focus();
                    IsValid = false;
                }
            }

            if (String.IsNullOrWhiteSpace(cmbObsCate.Text))
            {
                XtraMessageBox.Show("Please Select [Observation Category] !");
                IsValid = false;
                return IsValid;
            }
            else if (!string.IsNullOrWhiteSpace(cmbObsCate.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(txtNarrObs.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in [Observation Category] !");
                    txtNarrObs.Focus();
                    IsValid = false;
                }
            }
            if (String.IsNullOrWhiteSpace(cmbSafetStdDev.Text))
            {
                XtraMessageBox.Show("Please Select [Deviation of Safety Standard] !");
                IsValid = false;
                return IsValid;
            }
            else if (!string.IsNullOrWhiteSpace(cmbSafetStdDev.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(txtNarrObs.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in [Deviation of Safety Standard] !");
                    cmbSafetStdDev.Focus();
                    IsValid = false;
                }
            }

             if (String.IsNullOrWhiteSpace(cmbAuditChkPnt.Text))
            {
                XtraMessageBox.Show("!Please fill [Audit Check Points]");
                IsValid = false;
            }
            else if (!string.IsNullOrWhiteSpace(cmbAuditChkPnt.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(cmbAuditChkPnt.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in [Audit Check Points]!");
                    cmbAuditChkPnt.Focus();
                    IsValid = false;
                }
            }

            if (String.IsNullOrWhiteSpace(cmbRiskCate.Text))
            {
                XtraMessageBox.Show("!Please fill [Risk Category]");
                IsValid = false;
            }
            else if (!string.IsNullOrWhiteSpace(cmbRiskCate.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(cmbRiskCate.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in [Risk Category]!");
                    cmbRiskCate.Focus();
                    IsValid = false;
                }
            }

            return IsValid;
        }

        private Boolean ValidateAuditeeLogin()
        {
            bool IsValid = true;

            if (String.IsNullOrWhiteSpace(cmbResponsPerson.Text)|| cmbResponsPerson.Text=="NA")
            {
                XtraMessageBox.Show("Please Select [Auditee] !");
                IsValid = false;
                return IsValid;
            }
            else if (!string.IsNullOrWhiteSpace(cmbResponsPerson.Text)) 
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(cmbResponsPerson.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in [Check Points] !");
                    cmbResponsPerson.Focus();
                    IsValid = false;
                }
            }
            if (String.IsNullOrWhiteSpace(txtRtCauseObsAuditee.Text))
            {
                XtraMessageBox.Show("!Please fill [Root Cause of Observation (Auditee)]");
                IsValid = false;
                txtRtCauseObsAuditee.Focus();
            }
            else if (!string.IsNullOrWhiteSpace(txtRtCauseObsAuditee.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(txtRtCauseObsAuditee.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in [Root Cause of Observation (Auditee)]!");
                    txtRtCauseObsAuditee.Focus();
                    IsValid = false;
                }
            }
            return IsValid;
        }

        private Boolean ValidateCAPAUserLogin()
        {
            bool IsValid = true;

            if (String.IsNullOrWhiteSpace(txtCorrAction.Text))
            {
                XtraMessageBox.Show("Please fill [Corrective Actions] !");
                IsValid = false;
                return IsValid;
            }
            if (!string.IsNullOrWhiteSpace(txtCorrAction.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(txtCorrAction.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in [Corrective Actions] !");
                    txtCorrAction.Focus();
                    IsValid = false;
                }
            }
            if (String.IsNullOrWhiteSpace(txtPrevAction.Text))
            {
                XtraMessageBox.Show("Please fill [Actions to Prevent Reccurance] !");
                IsValid = false;
                return IsValid;
            }
            if (!string.IsNullOrWhiteSpace(txtPrevAction.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(txtPrevAction.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in [Actions to Prevent Reccurance] !");
                    txtPrevAction.Focus();
                    IsValid = false;
                }
            }
            return IsValid;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            AuditHelper.ValidateTokenExpiration(); 
            // Auditee (DH) Section
            if (Properties.Settings.Default.RoleID == 11)
            {
                if (txtStatus.Text == AuditStatus.CAPAClosed.ToString()|| txtStatus.Text == AuditStatus.Submitted.ToString())
                {
                    if(string.IsNullOrWhiteSpace(txtRtCauseObsAuditee.Text) || txtRtCauseObsAuditee.Text=="NA")
                    {
                        MessageBox.Show("Please input you Root cause of observation.");
                        txtRtCauseObsAuditee.Focus();
                        return;
                    }
                    DialogResult dr = MessageBox.Show("Are you sure to close?", "Alert", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.No) return;
                    MapControlToObject(AuditManagementDetail);
                    AuditManagementDetail.AuditStatus = AuditStatusValueToInt(AuditStatus.Closed.ToString());
                    UpdateAuditMgmtDetail(AuditManagementDetail, "Observation closed successfully.");
                    txtStatus.Text = AuditStatus.Closed.ToString();
                    //DisableAllControl();
                    //HideShowActioncontrol();
                }
            }
            HideShowActioncontrol();
        }

        private async void AuditMgmtDetailView_Load(object sender, EventArgs e)
        {
            await  GetAllAudCategory();
            await  GetAllAuditMaster();
            LoadUsers(DeptId);
            LoadAuditMaster();
            EnableDisableInputControl();
            HideShowActioncontrol();
        }

        private void cmbSafetStdDev_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadAuditMaster();
            Guid auditCategoryId = auditCatgList.Where(a => a.AuditCategoryName == cmbSafetStdDev.Text).FirstOrDefault().AuditCategoryId;
            cmbAuditChkPnt.Text = string.Empty;
            GetAudMaster(auditCategoryId);
        }
        private void LoadUsers(int deptId)
        {
            DataTable dt = Properties.Settings.Default.AllUsers;// UAUC.GetAllOperationUnits();
            DataTable dtCAPAUsers = dt;
            if (dtCAPAUsers.AsEnumerable().Where(a => a.Field<int>("RoleID") == 15 && a.Field<int>("DeptID") == deptId).Count() != 0)
            {
                dtCAPAUsers = dtCAPAUsers.AsEnumerable().Where(a => a.Field<int>("RoleID") == 15 && a.Field<int>("DeptID") == deptId).ToList().CopyToDataTable();

                for (int i = 0; i < dtCAPAUsers.Rows.Count; i++)
                {
                    cmbResponsPerson.Items.Add(dtCAPAUsers.Rows[i]["UserName"]);
                }
            }
        }
        public Guid AuditCheckPointValToGuid(string chkVal)
        {
            Guid iVal;
            iVal = auditMasterList.Where(a => a.AuditCheckPoint == chkVal).FirstOrDefault().AuditMasterId;
            return iVal;
        }
        public string AuditCheckPointGuidToVal(Guid chkId)
        {
            string sVal;
            sVal = auditMasterList.Where(a => a.AuditMasterId == chkId).FirstOrDefault().AuditCheckPoint;
            return sVal;
        }
        public static byte[] GetByteFromImage(Image x)
        {
            byte[] byt = null;
            //ImageConverter _imageConverter = new ImageConverter();
            //byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            //return xByte;
            if (x != null)
            {
                MemoryStream ms = new MemoryStream();
                x.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byt = ms.ToArray();
            }
            return byt;
        }
        private void LoadAuditMaster()
        {
            if (!string.IsNullOrWhiteSpace(cmbSafetStdDev.Text))
            {
                Guid auditCategoryId = auditCatgList.Where(a => a.AuditCategoryName == cmbSafetStdDev.Text).FirstOrDefault().AuditCategoryId;
                GetAudMaster(auditCategoryId);
            }
        }

        private void cmbResponsPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.RoleID == 11)
            {
                if ((txtStatus.Text == AuditStatus.Submitted.ToString() || txtStatus.Text == AuditStatus.CAPAClosed.ToString()) && !string.IsNullOrWhiteSpace(cmbResponsPerson.Text) && cmbResponsPerson.Text != "NA")
                    btnClose.Visible = false;
                else if ((txtStatus.Text == AuditStatus.Submitted.ToString()) && cmbResponsPerson.Text == "NA")
                   btnClose.Visible = true;
             }
        }
    }
    public class AuditManagementDetail
    {
        public Guid AuditManDetId { set; get; }
        public string SrlNo { set; get; }
        public Guid AuditManId { set; get; }
        //public string AuditType { set; get; }
        public string DeviaSafetyStd { set; get; }
        //public string AuditCheckPoint { set; get; }
        public Guid AuditMasterId { set; get; }
        public string CateOfObs { set; get; }
        public string RiskCategory { set; get; }
        public string NarrationOb { set; get; }
        public string RootCauseObsAuditor { set; get; }
        public string RootCauseObsAuditee { set; get; }
        public string CorrectiveAction { set; get; }
        public string PreventiveAction { set; get; }
        public string ResponsPersonId { set; get; }
        public DateTime CompletionDate { set; get; }
        public byte[] UploadedImg { set; get; } = null;
        public int AuditStatus { set; get; }
    }

    public enum AuditStatus
    {
        Prepare=0,
        Open=1,
        Submitted=2,
        CAPAClosed=3,
        Assigned=4,
        ReAssigned =5,
        Closed=6,
        Rejected =7
    }
}