using DevExpress.XtraEditors;
using Newtonsoft.Json;
//using Newtonsoft.Json;
using HindalcoiOS.Class_Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SparrowRMS;
using System.Threading;

namespace HindalcoiOS.AuditHind
{

    public partial class AuditCategoryView : XtraForm
    {
        //public event SomeEvents GetValue;
        public AuditCategory AudCategory { get; set; }
        List<DepartmentMaster> deptList = new List<DepartmentMaster>();
      public DataTable DepartmentList { set; get; }
        public AuditCategoryView()
        {
            AudCategory = new AuditCategory();
            InitializeComponent();
            btnAddCate.Text = "Add";
        }

        private async void btnAddCate_Click(object sender, EventArgs e)
        {
            if (ValidateCategoryMaster() == false) return;
            if (btnAddCate.Text == "Add")
            {
               MapControlToObject(AudCategory);
                //put statement to insert---
              await  AddAuditCategory(AudCategory);
            }
            else if (btnAddCate.Text == "Update")
            {
                //
            }
          await  ViewAllAudCategory();
        }
        

        private async void AuditCateMasterView_Load(object sender, EventArgs e)
        {
            AuditHelper.ValidateTokenExpiration();
            //LoadDepartments();
          AuditHelper.LoadDepartmentsToCombo(cmbDept);
            Thread.Sleep(800);
          //await  LoadAllDepartment();
          await  ViewAllAudCategory();
        }

        

        private void dgvViewCateMaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                AudCategory = new AuditCategory();
                AudCategory.AuditCategoryName = dgvViewCateMaster.Rows[e.RowIndex].Cells["CateName"].Value.ToString();
                AudCategory.AuditCategoryCode = dgvViewCateMaster.Rows[e.RowIndex].Cells["CateCode"].Value.ToString();
                AudCategory.DepartmentCode = int.Parse(DepartmentList.AsEnumerable().Where(X => X.Field<string>("Dept_Name") == cmbDept.Text).ToList().FirstOrDefault()["DeptId"].ToString());
                btnAddCate.Text = "Update";
                MapObjectToControl(AudCategory);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCateCancel_Click(object sender, EventArgs e)
        {
            btnAddCate.Text = "Add";
            txtCateName.Text = string.Empty;
            txtCateCode.Text = string.Empty;
            cmbDept.Text = string.Empty;
        }

        private Boolean ValidateCategoryMaster()
        {
            bool IsValid = true;

            if (String.IsNullOrWhiteSpace(txtCateName.Text))
            {
                XtraMessageBox.Show("Please fill Category Name !");
                IsValid = false;
                return IsValid;
            }
            else if (!string.IsNullOrWhiteSpace(txtCateName.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(txtCateName.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in [CategoryName] !");
                    txtCateName.Focus();
                    IsValid = false;
                    
                }
            }
            else if (String.IsNullOrWhiteSpace(txtCateCode.Text))
            {
                XtraMessageBox.Show("Please fill [CategoryCode].");
                IsValid = false;
            }
            else if (!string.IsNullOrWhiteSpace(txtCateCode.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(txtCateCode.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in [CategoryCode] !");
                    txtCateCode.Focus();
                    IsValid = false;
                }
            }

            if (String.IsNullOrWhiteSpace(cmbDept.Text))
            {
                XtraMessageBox.Show("!Please Select Department");
                IsValid = false;
            }
            else if (!string.IsNullOrWhiteSpace(cmbDept.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(cmbDept.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in [Department]");
                    cmbDept.Focus();
                    IsValid = false;
                }
            }

            return IsValid;
        }
        public void AuditCateView()
        {

        }
        public  void LoadDepartments()
        {
            DepartmentList = Resources.Instance.GetDepartmentList(1);
            foreach (DataRow dr in DepartmentList.Rows)
            {
                cmbDept.Items.Add(dr["Dept_Name"].ToString());
            }
          }

        private void MapControlToObject(AuditCategory auditCategory)
        {
            auditCategory.AuditCategoryId = Guid.NewGuid();
            auditCategory.AuditCategoryName = txtCateName.Text;
            auditCategory.AuditCategoryCode = txtCateCode.Text;
            auditCategory.AuditCreatedDate = DateTime.Today;
            auditCategory.DepartmentCode =int.Parse(DepartmentList.AsEnumerable().Where(X => X.Field<string>("Dept_Name") == cmbDept.Text).ToList().FirstOrDefault()["DeptId"].ToString());
            auditCategory.AuditUpdatedDate = DateTime.Today;
            auditCategory.AuditCreatedBy = GlobalDeclaration.UserName;
            auditCategory.AuditUpdatedBy = GlobalDeclaration.UserName;
        }
        private void MapObjectToControl(AuditCategory auditCategory)
        {
            txtCateName.Text = auditCategory.AuditCategoryName;
            txtCateCode.Text = auditCategory.AuditCategoryCode;
            cmbDept.Text = DepartmentList.AsEnumerable().Where(X => X.Field<int>("DeptId") == auditCategory.DepartmentCode).ToList().FirstOrDefault()["Dept_Name"].ToString();
        }
        private async Task<List<AuditCategory>> ViewAllAudCategory()
        {
            List<AuditCategory> auditCateList = new List<AuditCategory>();
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
                            auditCateList = JsonConvert.DeserializeObject<List<AuditCategory>>(apiResponse);
                            GetAuditCategoryData(auditCateList);
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
                    return auditCateList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return auditCateList;
        }

        //private async Task<List<DepartmentMaster>> LoadAllDepartment()
        //{
        //    List<DepartmentMaster> deptList = new List<DepartmentMaster>();
        //    try
        //    {
        //        using (var httpClient = new HttpClient())
        //        {
        //            string url = "https://hindalcoams.sparrowios.com/" + "GetAllDepartment";
        //            httpClient.DefaultRequestHeaders.Accept.Clear();
        //            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //            using (var response = await httpClient.GetAsync(url))
        //            {
        //                if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //                {
        //                    string apiResponse = await response.Content.ReadAsStringAsync();
        //                    deptList = JsonConvert.DeserializeObject<List<DepartmentMaster>>(apiResponse);
        //                    foreach (var item in deptList)
        //                    {
        //                        cmbDept.Items.Add(item.DepartmentName);
        //                    }
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
        //            return deptList;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }
        //    return deptList;
        //}

        private async Task<string> AddAuditCategory(AuditCategory audCate)
        {
            var responseString = string.Empty;

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var myContent = JsonConvert.SerializeObject(audCate);
                    var requestContent = new StringContent(myContent, Encoding.UTF8, "application/json");
                    // var content = new FormUrlEncodedContent(auditCalendar);
                    string url= "https://hindalcoams.sparrowios.com/SaveAuditCategory?Token="+GlobalDeclaration.ApiToken;
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

        private void GetAuditCategoryData(List<AuditCategory> audCateList)
        {
            try
            {
                //DataTable dt = itemReturn.GetReturn();
                //DataTable dt = itemReturn.GetReturn().AsEnumerable().Where(X => X.Field<int>("Status") == 1).CopyToDataTable();
                if (dgvViewCateMaster.Rows.Count > 0)
                    dgvViewCateMaster.Rows.Clear();
                //if (dt.Rows.Count > 0)
                {
                    foreach (var item in audCateList)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        dgvViewCateMaster.Rows.Add(dr);
                        int index = dgvViewCateMaster.Rows.Count - 1;
                        dgvViewCateMaster.Rows[index].Cells["CateName"].Value = item.AuditCategoryName;
                        dgvViewCateMaster.Rows[index].Cells["CateCode"].Value = item.AuditCategoryCode;
                        //int adcod =int.Parse(item.DepartmentCode.ToString());
                        var deptCount= Properties.Settings.Default.Departments.AsEnumerable().Where(X => X.Field<int>("DeptId") == item.DepartmentCode).ToList();
                        if(deptCount.Count>0)
                        dgvViewCateMaster.Rows[index].Cells["Department"].Value = Properties.Settings.Default.Departments.AsEnumerable().AsEnumerable().Where(X => X.Field<int>("DeptId") == item.DepartmentCode).ToList().FirstOrDefault()["Dept_Name"].ToString();
                        dgvViewCateMaster.Rows[index].Cells["CreatedDate"].Value =  item.AuditCreatedDate;
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

        private void btnUpload_Click(object sender, EventArgs e)
        {

        }
    }

    public class AuditCategory
    {
        public Guid AuditCategoryId { get; set; }
        public string AuditCategoryName { get; set; }
        public string AuditCategoryCode { get; set; }
        public int DepartmentCode { get; set; }
        public DateTime AuditCreatedDate { get; set; }
        public DateTime AuditUpdatedDate { get; set; }
        public string AuditCreatedBy { get; set; }
        public string AuditUpdatedBy { get; set; }

    }

   
}
