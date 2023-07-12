using DevExpress.XtraEditors;
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


namespace Hind.AuditMgmt
{

    public partial class CAPALog : XtraForm
    {
        //public event SomeEvents GetValue;
        //public VendorMaster vendorMaster { get; set; }
        public CAPALog()
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

    }
    public class CAPADetail
    {
        public Guid AuditDetailId { get; set; }
        public Guid CAPADetailId { get; set; }
        public string CAPAUserId { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int Status { get; set; }
    }

    //private async Task<List<AuditCalendar>> GetAuditCalendar(int id)
    //{
    //    List<AuditCalendar> ams = new List<AuditCalendar>();
    //    try
    //    {
    //        using (var httpClient = new HttpClient())
    //        {
    //            // string url = "http://localhost:5104/" + "GetAuditById" + "/" + id;
    //            string url = "https://hindalcoams.sparrowios.com/" + "GetAllAudits";
    //            httpClient.DefaultRequestHeaders.Accept.Clear();
    //            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    //            //using (var response = await httpClient.GetAsync("http://103.53.41.149:8001/" + "GetAllAudits"))
    //            using (var response = await httpClient.GetAsync(url))
    //            {
    //                if (response.StatusCode == System.Net.HttpStatusCode.OK)
    //                {
    //                    string apiResponse = await response.Content.ReadAsStringAsync();
    //                    ams = JsonConvert.DeserializeObject<List<AuditCalendar>>(apiResponse);
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
