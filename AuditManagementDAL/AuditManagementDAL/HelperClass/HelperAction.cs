using Azure;
using Newtonsoft.Json;
using System.Data;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
namespace AuditManagementDAL.HelperClass
{
    public class HelperAction
    {
      //  private WebRequest _request;
     //  private string _Objname;
          private static string fieldName = string.Empty;
        public string RoleType { get; set; }
        public int RetRoleDeed { get; set; }
        //  public static IConfiguration _Configuration;
        private string ConfStr;
        public HelperAction()///IConfiguration configuration)//(WebRequest request, string objname)
        {
          //  _Configuration = configuration;
            //_request = request;
            //_Objname = objname;
          //  _Configuration = new configuration.GetValue<string>("ConnectionString");
        }
        //public async Task WeRequestHandler()
        //{
        //    try
        //    {
        //        var WebRequest = new HttpClient();
        //        WebRequest.BaseAddress = new Uri("https://hindalcoams.sparrowios.com/");
        //        var WebResponse = WebRequest.GetAsync(_Objname);
        //        WebResponse.Wait();
        //        var result = WebResponse.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var jsonResponse = await result.Content.ReadAsStringAsync();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}
        public DataTable ConvertJsonDesializer(string jsonP)
        {
            DataTable dt = new DataTable();
            try
            {
                var json = jsonP;
                dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }
      public string ReturnEmployeeType(string empType)
        {
            try
            {
                if (empType == "U1-DepartmentHead")
                {
                    fieldName = "AuditeeId";
                }
                if (empType == "U1-DepartmentUser")
                {
                    fieldName = "AuditorId";
                }
                if (empType == "U1-CommiteeHead")
                {
                    fieldName = "CreatedBy";
                }
                if (empType == "U1-CommiteeMember")
                {
                    fieldName = "CommiteeMemId";
                }
            }
            catch (Exception ex)
            {
                WriteToFile(ex.Message + "\n" + ex.StackTrace);
            }
            return fieldName;
        }

        private  string ReturnAuditProfile(string RoleName)
        {
            try
            {
                if (RoleName == "U1-DepartmentHead")
                {
                    RoleType = "tbl_AuditeeResponse";
                    RetRoleDeed = 1;
                }
                if (RoleName == "U1-DepartmentUser")
                {
                    RoleType = "tbl_AuditorResponse";
                    RetRoleDeed = 2;
                }
                if (RoleName == "U1-CommiteeHead")
                {
                    RoleType = "tbl_taskDetails";
                    RetRoleDeed = 0;
                }
                if (RoleName == "U1-CommiteeMember")
                {
                    RoleType = "tbl_taskDetails";
                    RetRoleDeed = 0;
                }
            }
            catch (Exception ex)
            {
                WriteToFile(ex.Message + "\n" + ex.StackTrace);
            }
            return fieldName;
        }
        static void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }

        public string EncryptString(string key, string UName,string Pwd)
        {
            byte[] iv = new byte[16];
            byte[] array=null;
            try
            {
                // var keyobj = _Configuration.GetSection("KeyText");
            
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = iv;

                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                            {
                                streamWriter.Write(UName + "," + Pwd);
                            }
                            array = memoryStream.ToArray();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteToFile(ex.Message + "\n" + ex.StackTrace);
            }

            return Convert.ToBase64String(array);
        }

        public string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);
            StreamReader streamReader=null;
            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = iv;
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            using ( streamReader = new StreamReader((Stream)cryptoStream))
                            {
                                return streamReader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteToFile(ex.Message + "\n" + ex.StackTrace);
            }
            return streamReader.ReadToEnd();

        }

    }
}
