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
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using HindalcoiOS.Models;

namespace HindalcoiOS.AuditHind
{

    public partial class AuditMasterView : XtraForm
    {
        //public event SomeEvents GetValue;
        public AuditMaster auditMaster { get; set; }
        List<AuditCategory> auditCatgList = new List<AuditCategory>();
        public AuditMasterView()
        {
            auditMaster = new AuditMaster();
            InitializeComponent();
            btnSave.Text = "Add";
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateAuditMaster() == false) return;
            if (btnSave.Text == "Add")
            {
                MapControlToObject(auditMaster);
              await  AddAudMaster(auditMaster);
                //put statement to insert---
            }
            else if (btnSave.Text == "Update")
            {
                //
            }
          await ViewAllAuditMaster();
        }
        

        private async void AuditMasterView_Load(object sender, EventArgs e)
        {
            GlobalDeclaration.HideTabCtrlPagesHeader(AuditMasterPages);
           await  GetAllAudCategory();
            //LoadAuditCategory();
           await ViewAllAuditMaster();
        }
        
        private void btnView_Click(object sender, EventArgs e)
        {
            ViewAllAuditMaster();
            SetDefaultView();
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            AuditMasterPages.SelectedIndex = 1;
        }

        private void dgvViewAuditMaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                txtCheckPoint.Text = dgvViewAuditMaster.Rows[e.RowIndex].Cells["CheckPoint"].Value.ToString();
                txtRemarks.Text = dgvViewAuditMaster.Rows[e.RowIndex].Cells["Remarks"].Value.ToString();
                cmbCategory.Text = dgvViewAuditMaster.Rows[e.RowIndex].Cells["AuditCategory"].Value.ToString();
                btnSave.Text = "Update";
                //ViewVendorMaster();
                AuditMasterPages.SelectedIndex = 1;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Add";
            txtCheckPoint.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            cmbCategory.Text = string.Empty;
        }

        private Boolean ValidateAuditMaster()
        {
            bool IsValid = true;

            if (String.IsNullOrWhiteSpace(txtCheckPoint.Text))
            {
                XtraMessageBox.Show("Please fill [Check Points] !");
                IsValid = false;
                return IsValid;
            }
            else if (!string.IsNullOrWhiteSpace(txtCheckPoint.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(txtCheckPoint.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in [Check Points] !");
                    txtCheckPoint.Focus();
                    IsValid = false;
                    
                }
            }
            else if (String.IsNullOrWhiteSpace(txtRemarks.Text))
            {
                XtraMessageBox.Show("!Please fill Description");
                IsValid = false;
            }
            else if (!string.IsNullOrWhiteSpace(txtRemarks.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(txtRemarks.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in Description!");
                    txtRemarks.Focus();
                    IsValid = false;
                }
            }

            if (String.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                XtraMessageBox.Show("!Please Select Category");
                IsValid = false;
            }
            
            return IsValid;
        }
        //public void AuditMasterDataView()
        //{

        //}
        //public void LoadAuditCategory()
        //{
        //    DataTable catelist = new DataTable();
        //    foreach (DataRow dr in catelist.Rows)
        //    {
        //        cmbCategory.Items.Add(dr["CateName"].ToString());
        //    }
        //}

        private void SetDefaultView()
        {
            
            AuditMasterPages.SelectedIndex = 0;
        }
        private void MapControlToObject(AuditMaster AudMaster)
        {
            AudMaster.AuditMasterId = Guid.NewGuid();
            AudMaster.AuditCheckPoint = txtCheckPoint.Text;
            AudMaster.AuditRemarks = txtRemarks.Text;
            AudMaster.CreatedDate = DateTime.Today;
            AudMaster.AuditCategoryId = auditCatgList.Where(a => a.AuditCategoryName == cmbCategory.Text).FirstOrDefault().AuditCategoryId;
            AudMaster.AuditCreatedBy = GlobalDeclaration.UserName;
            AudMaster.AuditUpdatedDate = DateTime.Today;
            AudMaster.AuditUpdatedBy = GlobalDeclaration.UserName;
        }
        private void MapObjectToControl(AuditMaster audMaster)
        {
            txtCheckPoint.Text = audMaster.AuditCheckPoint;
            txtRemarks.Text = auditMaster.AuditRemarks;
            ////cmbCategory.Text = audMaster.AuditCategoryId;
        }
        private async Task<List<AuditMaster>> ViewAllAuditMaster()
        {
            List<AuditMaster> auditMasters = new List<AuditMaster>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/GetAllAuditMasters?Token="+GlobalDeclaration.ApiToken;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    using (var response = await httpClient.GetAsync(CleanURL(url)))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            auditMasters = JsonConvert.DeserializeObject<List<AuditMaster>>(apiResponse);
                            BindAuditMasterToGrid(auditMasters);

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
                    return auditMasters;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return auditMasters;
        }

        private async Task<string> AddAudMaster(AuditMaster audMaster)
        {
            var responseString = string.Empty;
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var myContent = JsonConvert.SerializeObject(audMaster);
                    var requestContent = new StringContent(myContent, Encoding.UTF8, "application/json");
                    // var content = new FormUrlEncodedContent(auditCalendar);
                    string url = "https://hindalcoams.sparrowios.com/SaveAuditMaster?Token=" + GlobalDeclaration.ApiToken;

                    var response = await httpClient.PostAsync(CleanURL(url), requestContent);
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
                    using (var response = await httpClient.GetAsync(CleanURL(url)))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            auditCatgList = JsonConvert.DeserializeObject<List<AuditCategory>>(apiResponse);
                            //GetAuditCategoryData(auditCateList);
                            if (cmbCategory.Items.Count > 0)
                                cmbCategory.Items.Clear();
                            foreach (var item in auditCatgList)
                            {
                                cmbCategory.Items.Add(item.AuditCategoryName);
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

        private void BindAuditMasterToGrid(List<AuditMaster> ams)
        {
            try
            {
                //DataTable dt = itemReturn.GetReturn();
                //DataTable dt = itemReturn.GetReturn().AsEnumerable().Where(X => X.Field<int>("Status") == 1).CopyToDataTable();
                if (dgvViewAuditMaster.Rows.Count > 0)
                    dgvViewAuditMaster.Rows.Clear();
                //if (dt.Rows.Count > 0)
                {
                    foreach (var item in ams)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        dgvViewAuditMaster.Rows.Add(dr);
                        int index = dgvViewAuditMaster.Rows.Count - 1;
                        dgvViewAuditMaster.Rows[index].Cells["CheckPoint"].Value = item.AuditCheckPoint;
                        dgvViewAuditMaster.Rows[index].Cells["Remarks"].Value = item.AuditRemarks;
                        dgvViewAuditMaster.Rows[index].Cells["CreatedDate"].Value = item.CreatedDate;
                        if(auditCatgList.Where(a => a.AuditCategoryId == item.AuditCategoryId).FirstOrDefault()!=null)
                        dgvViewAuditMaster.Rows[index].Cells["AuditCategory"].Value = auditCatgList.Where(a => a.AuditCategoryId == item.AuditCategoryId).FirstOrDefault().AuditCategoryName;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string CleanURL(string linkUrl)
        {
            if (linkUrl.Contains('"'))
            {
                linkUrl = linkUrl.Replace('"', ' ').Replace("= ", "=").Trim().TrimEnd();
            }
            return linkUrl;
        }

        private async void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection econ = ExcelConn(GetFilePath());
                string Query = string.Format("Select [CHECKPOINT],[OBSERVATION],[CATEGORY] FROM [{0}]", "Sheet1$");
                OleDbDataAdapter da = new OleDbDataAdapter(Query, econ);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count == 0)
                {
                    XtraMessageBox.Show("Sheet Contains No Data!");
                    return;
                }
                int count = 0;
               
               
                foreach (DataRow dr in dt.Rows)
                {
                    auditMaster = new AuditMaster();
                    auditMaster.AuditCheckPoint = dr["CHECKPOINT"].ToString();
                    auditMaster.AuditRemarks = dr["OBSERVATION"].ToString();
                    //if(dr["CATEGORY"].ToString()=="Hand tools")
                    //{

                    //}
                    auditMaster.AuditCategoryId =auditCatgList.AsEnumerable().Where(X => X.AuditCategoryCode == dr["CATEGORY"].ToString()).ToList().FirstOrDefault().AuditCategoryId;
                    auditMaster.CreatedDate = DateTime.Today;
                    auditMaster.AuditCreatedBy = GlobalDeclaration._holdInfo[0].UserId.ToString();
                    await AddAudMaster(auditMaster);
                    count++;
                }
                XtraMessageBox.Show(string.Format("{0} Audit Master Uploaded Successfully", count));
              
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static OleDbConnection ExcelConn(string FilePath)
        {
            OleDbConnection Econ = null;
            string constr = string.Format(@"provider=microsoft.jet.oledb.4.0;data source={0};extended properties=" + "\"excel 8.0;hdr=yes;\"", FilePath);
            Econ = new OleDbConnection(constr);
            return Econ;
        }
        public string GetFilePath()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";// "xLsx Files (*.xlsx)|*.xlsx|*.xls";
            ofd.FilterIndex = 1;
            ofd.Multiselect = false;
            ofd.ShowDialog();
            return ofd.FileName;
        }
    }
    public class AuditMaster
    {
        public Guid AuditMasterId { set; get; }
        public string AuditCheckPoint { set; get; }
        //public Guid AuditCheckPointId { set; get; }
        public Guid AuditCategoryId { set; get; }
        public string AuditRemarks { set; get; }
        public DateTime CreatedDate { set; get; }
        public string AuditCreatedBy { get; set; }
        public DateTime AuditUpdatedDate { get; set; }
        public string AuditUpdatedBy { get; set; }
    }
}
