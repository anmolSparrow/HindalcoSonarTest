using DevExpress.XtraEditors;
using Newtonsoft.Json;
using RMPCLApp.Class_Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Hind.AuditMgmt
{

    public partial class DepartmentView : XtraForm
    {
        //public event SomeEvents GetValue;
        //public VendorMaster vendorMaster { get; set; }
        public DepartmentView()
        {
            //vendorMaster = new VendorMaster();
            InitializeComponent();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            //if (ValidateVendorMaster() == false) return;
            //MapVendorMasterToData();
            //ViewVendorMaster();
            //this.GetValue.Invoke(this.txtVendorName.Text);
            if (btnAdd.Text == "Add")
            {
                //////////await  GetAuditCalendar(145);
                AddAuditCalendar();


                //AuditManagementDAL.DataModels.DepartmentMaster deptMaster = new AuditManagementDAL.DataModels.DepartmentMaster();

                ////Department dept = new Department();
                //deptMaster.DepartmentId = 111;
                //deptMaster.DepartmentName = txtDeptName.Text;
                //deptMaster.DepartmentCode = txtDeptCode.Text;
                //deptMaster.CreatedDate = DateTime.Today;
                //deptMaster.CreatedBy = 222; //GlobalDeclaration.UserName;

                //var WebRequest = new HttpClient();
                //WebRequest.BaseAddress = new Uri("http://103.53.41.202:11198/SaveDepartment");
                ////var WebResponse = WebRequest.GetAsync(deptMaster);
                ////WebResponse.Wait();
                ////var result = WebResponse.Result;
                //JsonContent content = JsonContent.Create(deptMaster);
                //WebRequest.PostAsync("http://103.53.41.202:11198/SaveDepartment", content);

                ////if (result.IsSuccessStatusCode)
                ////{
                ////    var jsonResponse = result.Content.ReadAsStringAsync();
                ////}
                //put statement to insert---
            }
            else if(btnAdd.Text == "Update")
            {
                //
            }
            ViewDept();
        }
        private async Task<List<AuditCalendar>> GetAuditCalendar(int id)
        {
            List<AuditCalendar> ams = new List<AuditCalendar>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    // string url = "http://localhost:5104/" + "GetAuditById" + "/" + id;
                    string url = "https://hindalcoams.sparrowios.com/" + "GetAllAudits";
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //using (var response = await httpClient.GetAsync("http://103.53.41.149:8001/" + "GetAllAudits"))
                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            ams = JsonConvert.DeserializeObject<List<AuditCalendar>>(apiResponse);
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

        private async Task<string> AddAuditCalendar()
        {
            var responseString = string.Empty;
            // AuditCalendar auditCalendar=new AuditCalendar();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var auditCalendar = new AuditCalendar
                    {
                        AuditType = "Regular",
                        AuditCalendarId = 4,
                        AuditCategory = "Admin",
                        AuditName = "Level1",
                        AuditStart = DateTime.Now,
                        AreaCode = "ECR/008/787",
                        DeptId = 119,
                        DocumentDate = DateTime.Now,
                        DocumentedBy = "Ram Kumar"
                    };



                    var myContent = JsonConvert.SerializeObject(auditCalendar);
                    var requestContent = new StringContent(myContent, Encoding.UTF8, "application/json");
                    // var content = new FormUrlEncodedContent(auditCalendar);
                    var response = await httpClient.PostAsync("https://hindalcoams.sparrowios.com/SaveAudit", requestContent);
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



            }
            return responseString;
        }

        private void Department_Load(object sender, EventArgs e)
        {
            btnAdd.Text = "Add";
            ViewDept();
        }

        private void txtVendorEmail_Leave(object sender, EventArgs e)
        {
            //System.Text.RegularExpressions.Regex expr = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            //if (!expr.IsMatch(txtVendorEmail.Text))
            //{
            //    MessageBox.Show("invalid Email Format");
            //    txtVendorEmail.Focus();
            //}


        }

        private void txtVendorContact_Leave(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.Regex expr = new System.Text.RegularExpressions.Regex(@"^[0-9]{10}$");

            //if (!expr.IsMatch(txtVendorContact.Text))
            //{
            //    MessageBox.Show("Invalid Contact Format. Use 10 Digit Mobile No");
            //    //txtVendorContact.Focus();
            //}
        }

        private void dgvViewDeptMaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                txtDeptName.Text = dgvViewDeptMaster.Rows[e.RowIndex].Cells["DeptName"].Value.ToString();
                txtDeptCode.Text = dgvViewDeptMaster.Rows[e.RowIndex].Cells["DeptCode"].Value.ToString();
                //txtVendorContact.Text = dgvViewVendorMaster.Rows[e.RowIndex].Cells["Contact"].Value.ToString();
                //txtVendorEmail.Text = dgvViewVendorMaster.Rows[e.RowIndex].Cells["EmailID"].Value.ToString();
                //txtVendorContPerson.Text = dgvViewVendorMaster.Rows[e.RowIndex].Cells["ContactPerson"].Value.ToString();
                //txtVendorAddress.Text = dgvViewVendorMaster.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                 btnAdd.Text = "Update";
                ViewDept();
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

            await GetAuditCalendar(145);
        }

        public void ViewDept()
        {

        }

        private Boolean ValidateVendorMaster()
        {
            bool IsValid = true;

            if (String.IsNullOrWhiteSpace(txtDeptName.Text))
            {
                XtraMessageBox.Show("Please fill Vendor Name !");
                IsValid = false;
                return IsValid;
            }
            else if (!string.IsNullOrWhiteSpace(txtDeptName.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(txtDeptName.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in Vendor Name !");
                    txtDeptName.Focus();
                    IsValid = false;
                    
                }
            }
            else if (String.IsNullOrWhiteSpace(txtDeptCode.Text))
            {
                XtraMessageBox.Show("!Please fill VendorCode");
                IsValid = false;
            }
            else if (!string.IsNullOrWhiteSpace(txtDeptCode.Text))
            {
                var regex = new Regex(@"[^a-zA-Z0-9\s]-");
                if (regex.IsMatch(txtDeptCode.ToString()))
                {
                    XtraMessageBox.Show("Invalid character in VendorCode!");
                    txtDeptCode.Focus();
                    IsValid = false;
                }
            }
            //if (String.IsNullOrWhiteSpace(txtVendorContact.Text))
            //{
            //    XtraMessageBox.Show("!Please fill Contact");
            //    IsValid = false;
            //}
            //else if (!string.IsNullOrWhiteSpace(txtVendorContact.Text))
            //{
            //    var regex = new Regex(@"^[0-9]{10}$");
            //    if (regex.IsMatch(txtVendorContact.ToString()))
            //    {
            //        XtraMessageBox.Show("Invalid Contact Format. Use 10 Digit Mobile No!");
            //        txtVendorContact.Focus();
            //        IsValid = false;
            //    }
            //}
            //else if (String.IsNullOrWhiteSpace(txtVendorContPerson.Text))
            //{
            //    XtraMessageBox.Show("!Please fill Contact-Person");
            //    IsValid = false;
            //}
            //else if (!string.IsNullOrWhiteSpace(txtVendorContPerson.Text))
            //{
            //    var regex = new Regex(@"[^a-zA-Z0-9\s]-");
            //    if (regex.IsMatch(txtVendorContPerson.ToString()))
            //    {
            //        XtraMessageBox.Show("Invalid character in Contact-Person!");
            //        txtVendorContPerson.Focus();
            //        IsValid = false;
            //    }
            //}
            //else if (String.IsNullOrWhiteSpace(txtVendorEmail.Text))
            //{
            //    XtraMessageBox.Show("!Please fill Email");
            //    IsValid = false;
            //}
            //else if (!string.IsNullOrWhiteSpace(txtVendorEmail.Text))
            //{
            //    var regex = new Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            //    if (regex.IsMatch(txtVendorEmail.Text))
            //    {
            //        XtraMessageBox.Show("Invalid Email Format!");
            //        txtVendorEmail.Focus();
            //        IsValid = false;
            //    }
            //}
            //else if (String.IsNullOrWhiteSpace(txtVendorAddress.Text))
            //{
            //    XtraMessageBox.Show("!Please fill Address");
            //    IsValid = false;
            //}
            //else if (!string.IsNullOrWhiteSpace(txtVendorAddress.Text))
            //{
            //    var regex = new Regex(@"[^a-zA-Z0-9\s]-/");
            //    if (regex.IsMatch(txtVendorAddress.ToString()))
            //    {
            //        XtraMessageBox.Show("Invalid character in Address!");
            //        txtVendorAddress.Focus();
            //        IsValid = false;
            //    }
            //}
            return IsValid;
        }

        public List<DepartmentView> DepartmentViewGet()
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = "https://www.c-sharpcorner.com/blogs/consume-webapi-using-webclient-in-c-sharp";// StaticItems.EndPoint;
                    var json = webClient.DownloadString("City/CityGetForDDL");
                    var list = JsonConvert.DeserializeObject<List<DepartmentView>>(json);
                    return list.ToList();
                }
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }

        //public ReturnMessageInfo CitySave(DepartmentView deptView)
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


    }
    public class Department
    {
        public int DeptId { set; get; }
        public string DeptName { set; get; }
        public string DeptCode { set; get; }
        //public string OperationUnit { set; get; }
        public DateTime CreatedDate { set; get; }
        public string CreatedBy { set; get; }
    }
    public class AuditCalendar
    {
        public int AuditCalendarId { get; set; }
        public DateTime AuditStart { get; set; }
        public DateTime ExpectedDate { get; set; }
        public string AuditName { get; set; }
        public string AreaCode { get; set; }
        public int DeptId { get; set; }
        public DateTime DocumentDate { get; set; }
        public string AuditCategory { get; set; }
        public string AuditType { get; set; }
        public string DocumentedBy { get; set; }



    }
}
