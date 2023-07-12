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
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
//using System.Net.Http.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HindalcoiOS.AuditHind
{

    public partial class DepartmentView : XtraForm
    {
        //public event SomeEvents GetValue;
        public DepartmentMaster Dept { get; set; }
        List<OperationUnit> ounits = new List<OperationUnit>();
        public DepartmentView()
        {
            Dept = new DepartmentMaster();
            InitializeComponent();
            btnAdd.Text = "Add";
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateDept() == false) return;
            //MapControlToObject(Dept);
            if (btnAdd.Text == "Add")
            {
                //put statement to insert
                MapControlToObject(Dept);
                
              await  AddDept(Dept);
            }
            else if (btnAdd.Text == "Update")
            {
                MapControlToObject(Dept);
            }
            await ViewAllDept();
        }

        private async Task<List<DepartmentMaster>> ViewAllDept()
        {
            List<DepartmentMaster> ams = new List<DepartmentMaster>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/" + "GetAllDepartment";
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            ams = JsonConvert.DeserializeObject<List<DepartmentMaster>>(apiResponse);
                            GetDepartmentData(ams);
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

        private async Task<List<OperationUnit>> ViewAllOperationUnit()
        {
            //List<OperationUnit> ams = new List<OperationUnit>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = "https://hindalcoams.sparrowios.com/" + "GetOperationUnit";
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            ounits = JsonConvert.DeserializeObject<List<OperationUnit>>(apiResponse);
                            foreach (var item in ounits)
                            {
                                cmbOpUnit.Items.Add(item.OperationUnitName);
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
                    return ounits;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return ounits;
        }

        private async Task<string> AddDept(DepartmentMaster deptmaster)
        {
            var responseString = string.Empty;

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var myContent = JsonConvert.SerializeObject(deptmaster);
                    var requestContent = new StringContent(myContent, Encoding.UTF8, "application/json");
                    // var content = new FormUrlEncodedContent(auditCalendar);
                    var response = await httpClient.PostAsync("https://hindalcoams.sparrowios.com/SaveDepartment", requestContent);
                    responseString = await response.Content.ReadAsStringAsync();
                    //  var createdCompany = JsonSerializer.Deserialize<AuditCategory>(responseString,);
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        Console.WriteLine(response.StatusCode.ToString());
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Created)
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

        private async void Department_Load(object sender, EventArgs e)
        {
         await ViewAllOperationUnit();
           if (cmbOpUnit.Items.Count > 0)
            {
                //LoadOperationUnits();
              await  ViewAllDept();
            }
        }

        private void dgvViewDeptMaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                Dept = null;
                Dept = new DepartmentMaster();
                Dept.DepartmentName = dgvViewDeptMaster.Rows[e.RowIndex].Cells["DeptName"].Value.ToString();
                Dept.DepartmentCode = dgvViewDeptMaster.Rows[e.RowIndex].Cells["DeptCode"].Value.ToString();
                Dept.OperationUnitCode = dgvViewDeptMaster.Rows[e.RowIndex].Cells["OperationUnit"].Value.ToString();
                MapObjectToControl(Dept);
                btnAdd.Text = "Update";
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Text = "Add";
            txtDeptCode.Text = string.Empty;
            txtDeptName.Text = string.Empty;
        }

        private Boolean ValidateDept()
        {
            bool IsValid = true;

            if (String.IsNullOrWhiteSpace(txtDeptName.Text))
            {
                XtraMessageBox.Show("Please fill Department Name !");
                IsValid = false;
                return IsValid;
            }
            else if (!string.IsNullOrWhiteSpace(txtDeptName.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(txtDeptName.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in Department Name !");
                    txtDeptName.Focus();
                    IsValid = false;

                }
            }
            else if (String.IsNullOrWhiteSpace(txtDeptCode.Text))
            {
                XtraMessageBox.Show("!Please fill [Department Code]");
                IsValid = false;
            }
            else if (!string.IsNullOrWhiteSpace(txtDeptCode.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(txtDeptCode.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in [Department Code]!");
                    txtDeptCode.Focus();
                    IsValid = false;
                }
            }
            if (String.IsNullOrWhiteSpace(cmbOpUnit.Text))
            {
                XtraMessageBox.Show("!Please Select [Operation Unit]");
                IsValid = false;
            }
            else if (!string.IsNullOrWhiteSpace(cmbOpUnit.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(cmbOpUnit.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in [OperationUnit]");
                    cmbOpUnit.Focus();
                    IsValid = false;
                }
            }

            return IsValid;
        }

        private void MapControlToObject(DepartmentMaster deptMaster)
        {
            //deptMaster.DeptId = 111;
            deptMaster.DepartmentName = txtDeptName.Text;
            deptMaster.DepartmentCode = txtDeptCode.Text;
            deptMaster.CreatedDate = DateTime.Today;
            deptMaster.OperationUnitCode = ounits.Where(a => a.OperationUnitName == cmbOpUnit.Text).FirstOrDefault().OperationUnitCode;
            //ams.Select(a => a.OperationUnitName == cmbOpUnit.Text).FirstOrDefault(a => a.OperationUnitCode);//.ToList().FirstOrDefault()["OperationUnitCode"].ToString();
            //deptMaster.OperationUnitId = GlobalDeclaration.GetAllOperationUnits().AsEnumerable().Where(X => X.Field<string>("OperationUnitName") == cmbOpUnit.Text).ToList().FirstOrDefault()["OperationUnitCode"].ToString();
            deptMaster.CreatedBy = GlobalDeclaration.UserName;
        }
        private void MapObjectToControl(DepartmentMaster deptMaster)
        {
            txtDeptName.Text = deptMaster.DepartmentName;
            txtDeptCode.Text = deptMaster.DepartmentCode;
            cmbOpUnit.Text = cmbOpUnit.Text;
            //GlobalDeclaration.GetAllOperationUnits().AsEnumerable().Where(X => X.Field<string>("OperationUnitCode") == deptMaster.OperationUnitId).ToList().FirstOrDefault()["OperationUnitName"].ToString();
            //cmbOpUnit.Text = deptMaster.OperationUnitId;
        }

        //private void LoadOperationUnits()
        //{
        //    if (cmbOpUnit.Items.Count > 0)
        //        cmbOpUnit.Items.Clear();
        //    DataTable dt = GlobalDeclaration.GetAllOperationUnits();
        //    if (dt.Rows.Count == 0) return;
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        cmbOpUnit.Items.Add(dt.Rows[i]["OperationUnitName"]);
        //    }
        //}

        private void GetDepartmentData(List<DepartmentMaster> ams)
        {
            try
            {
                //DataTable dt = itemReturn.GetReturn();
                //DataTable dt = itemReturn.GetReturn().AsEnumerable().Where(X => X.Field<int>("Status") == 1).CopyToDataTable();
                if (dgvViewDeptMaster.Rows.Count > 0)
                    dgvViewDeptMaster.Rows.Clear();
                //if (dt.Rows.Count > 0)
                {
                    foreach (var item in ams)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        dgvViewDeptMaster.Rows.Add(dr);
                        int index = dgvViewDeptMaster.Rows.Count - 1;
                        dgvViewDeptMaster.Rows[index].Cells["DeptName"].Value = item.DepartmentName;
                        dgvViewDeptMaster.Rows[index].Cells["DeptCode"].Value = item.DepartmentCode;
                        dgvViewDeptMaster.Rows[index].Cells["CreatedDate"].Value = item.CreatedDate;

                        dgvViewDeptMaster.Rows[index].Cells["OperationUnit"].Value = ounits.Where(a => a.OperationUnitCode == item.OperationUnitCode).FirstOrDefault().OperationUnitName;
                        //dgvReturnGrid.Rows[index].Cells["ReturnDocumentDate"].Value = ((DateTime)dt.Rows[i]["DocumentDate"]).ToString("dd-MM-yyyy");// dt.Rows[i]["DocumentDate"];
                        //dgvReturnGrid.Rows[index].Cells["ReturnStatus"].Value = ((InvStatus)(int.Parse(dt.Rows[i]["Status"].ToString()))).ToString();
                        //dgvReturnGrid.Sort(dgvReturnGrid.Columns["ReturnDocumentDate"], ListSortDirection.Descending);
                        //dgvReturnGrid.Visible = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //public ReturnMessageInfo Add(DepartmentView deptView)
        //{
        //    ReturnMessageInfo result = new ReturnMessageInfo();
        //    try
        //    {
        //        using (WebClient webClient = new WebClient())
        //        {
        //            webClient.BaseAddress = "";// StaticItems.EndPoint;
        //            var url = "City/CityAddUpdate";
        //            webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
        //            webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
        //            string data = JsonConvert.SerializeObject(city);
        //            var response = webClient.UploadString(url, data);
        //            result = JsonConvert.DeserializeObject<ReturnMessageInfo>(response);
        //            return result;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //private async void btnAdd_Click(object sender, EventArgs e)
        //{
        //    //if (ValidateVendorMaster() == false) return;
        //    //MapVendorMasterToData();
        //    //ViewVendorMaster();
        //    //this.GetValue.Invoke(this.txtVendorName.Text);
        //    if (btnAdd.Text == "Add")
        //    {
        //        //////////await  GetAuditCalendar(145);
        //        ////AddAuditCalendar();


        //        //AuditManagementDAL.DataModels.DepartmentMaster deptMaster = new AuditManagementDAL.DataModels.DepartmentMaster();

        //        ////Department dept = new Department();
        //        //deptMaster.DepartmentId = 111;
        //        //deptMaster.DepartmentName = txtDeptName.Text;
        //        //deptMaster.DepartmentCode = txtDeptCode.Text;
        //        //deptMaster.CreatedDate = DateTime.Today;
        //        //deptMaster.CreatedBy = 222; //GlobalDeclaration.UserName;

        //        //var WebRequest = new HttpClient();
        //        //WebRequest.BaseAddress = new Uri("http://103.53.41.202:11198/SaveDepartment");
        //        ////var WebResponse = WebRequest.GetAsync(deptMaster);
        //        ////WebResponse.Wait();
        //        ////var result = WebResponse.Result;
        //        //JsonContent content = JsonContent.Create(deptMaster);
        //        //WebRequest.PostAsync("http://103.53.41.202:11198/SaveDepartment", content);

        //        ////if (result.IsSuccessStatusCode)
        //        ////{
        //        ////    var jsonResponse = result.Content.ReadAsStringAsync();
        //        ////}
        //        //put statement to insert---
        //    }
        //    else if(btnAdd.Text == "Update")
        //    {
        //        //
        //    }
        //    ViewDept();
        //}
    }

    public class DepartmentMaster
    {
        public Guid DepartmentId { set; get; }
        public string DepartmentName { set; get; }
        public string DepartmentCode { set; get; }
        public string OperationUnitCode { set; get; }
        public DateTime CreatedDate { set; get; }
        public string CreatedBy { set; get; }
    }
    public class OperationUnit
    {

        //public DateTime CreatedDate { set; get; }
        public String OperationUnitName { set; get; }
        public String OperationUnitCode { set; get; }

    }
}
