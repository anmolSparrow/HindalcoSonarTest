using HindalcoiOS.Class_Operation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
namespace HindalcoiOS.AuditHind
{
  public static class AuditHelper
    {
        public static void ValidateTokenExpiration()
        {
            if (GlobalDeclaration.TokenExpiredOn < DateTime.Now)
            {
                GenerateToken();
            }
        }
        public static  async void GenerateToken()
        {
            UserModel usrModel = new UserModel();
            usrModel.UserName = Properties.Settings.Default.UserName;
            usrModel.Uid = int.Parse(Properties.Settings.Default.UserID);
            usrModel.Password = Properties.Settings.Default.Password;
            await GetToken(usrModel);
        }
        public static async Task<string> GetToken(UserModel userModel)
        {
            var token = string.Empty;
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var myContent = JsonConvert.SerializeObject(userModel);
                    var requestContent = new StringContent(myContent, Encoding.UTF8, "application/json");
                    // var content = new FormUrlEncodedContent(auditCalendar);
                    var response = await httpClient.PostAsync("https://hindalcoams.sparrowios.com/GenerateToken", requestContent);
                    token = await response.Content.ReadAsStringAsync();

                    GlobalDeclaration.ApiToken = token;
                    GlobalDeclaration.TokenExpiredOn = DateTime.Now.AddSeconds(1200);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return token;
        }
        public static string UrlToken { get; set; }
        public static async Task<string> GetUrlToken(string pwd)
        {
            var token = string.Empty;
            try
            {
                UserEncryption userEncryp =new UserEncryption ();
                userEncryp.UserName = GlobalDeclaration.UserName;
                userEncryp.Password = pwd;
                userEncryp.Key = "sparrow@9621##0901$06062023$!@12";
                using (var httpClient = new HttpClient())
                {
                    var myContent = JsonConvert.SerializeObject(userEncryp);
                    var requestContent = new StringContent(myContent, Encoding.UTF8, "application/json");
                    // var content = new FormUrlEncodedContent(auditCalendar);
                    var response = await httpClient.PostAsync("https://hindalcoams.sparrowios.com/GetUserEncryptionData", requestContent);
                    UrlToken = await response.Content.ReadAsStringAsync();
               }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return token;
        }


        
        public static void LoadFinYear(CheckComboBoxTest.CheckedComboBox chkCmbYear)
        {
            foreach (string item in GlobalDeclaration.FinancialYears)
            {
                chkCmbYear.Items.Add(item.ToString());
            }
        }
       
        public static void LoadDepartmentsToCombo(SparrowRMSControl.SparrowControl.SparrowComboBox cmb)
        {
            foreach (DataRow dr in Properties.Settings.Default.Departments.Rows)
            {
                cmb.Items.Add(dr["Dept_Name"].ToString());
            }
        }

        public static Uri CreateUriWithQuery(Uri uri, string value)
        {
            var queryStr = new StringBuilder();
            // presumes that if there's a Query set, it starts with a ?
            var str = string.IsNullOrWhiteSpace(uri.Query) ?
                      "" : uri.Query.Substring(1) + "&";

             queryStr.Append("Token=" + value + "&Uid=" + GlobalDeclaration._holdInfo[0].UserId);
                
           
            // query string will be encoded by building a new Uri instance
            // clobbers the existing Query if it exists
            return new UriBuilder(uri)
            {
                Query = queryStr.ToString()
            }.Uri;
        }

        
    }
   

    public  class NameValueCollection : Dictionary<string, string>
    {
    }


    public class UserEncryption
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string  Key { get; set; }
    }
}
