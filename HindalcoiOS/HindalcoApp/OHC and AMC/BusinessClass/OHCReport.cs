using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using HindalcoiOS.InventoryMgmt;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.OHC_AMC
{
    public class OHCReport: IDisposable
    {
        private bool disposed;
        /// <summary>
        /// Destructor
        /// </summary>
        ~OHCReport()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// The dispose method that implements IDisposable.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The virtual dispose method that allows
        /// classes inherithed from this one to dispose their resources.
        /// </summary>
        /// <param name="disposing"></param>        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources here.
                }
                // Dispose unmanaged resources here.
            }
            disposed = true;
        }

        public int SINO
        {
            get;
            set;
        }
        public string EmployeeCode
        {
            get;set;
        }
        public string EmployeeName
        {
            get;set;
        }
        public string EmailID
        {
            get;set;
        }
        public int PhoneNumber
        {
            get;set;
        }
        public string EmployeeType
        {
            get;set;
        }
        public DateTime DOB
        {
            get;set;
        }
        public Gender Gender
        {
            get;set;
        }
        public long AadharNumber
        {
            get;set;
        }
        public DateTime DOJ
        {
            get;
            set;
        }      
        public string CompanyName
        {
            get;set;
        }
        public DateTime CheckUpDate
        {
            get;set;
        }
        public string DepartmentName
        {
            get;set;
        }
        public HealthStatus HealthStatus
        {
            get;set;
        }        
        public string Remark
        {
            get;set;
        }
        public  CallingStatus CallingStatus
        {
            get; set;
        }
        public byte[] FileBytes
        {
            get;set;
        }
        public string FormName
        {
            get;set;
        }  
        public byte[] ImageByte
        {
            get;set;
        }
        public string ReportPath
        {
            get;set;
        }
        public Image GetImageValue
        {
            get;set;
        }
        public void clearAllProt()
        {
            this.SINO = 0;
            this.EmployeeCode = string.Empty;
            this.EmployeeName = string.Empty;
            this.DOB = DateTime.Now;
            this.DOJ = DateTime.Now;
            this.AadharNumber = 0;
            this.CompanyName = string.Empty;
            this.DepartmentName = string.Empty;
            this.EmployeeType = string.Empty;
            this.ReportPath = string.Empty;
            this.Remark = string.Empty;
            this.Gender = 0;
            this.HealthStatus = 0;
            this.ImageByte = null;
            this.FileBytes = null;
            this.GetImageValue = null;

        }
        public DataTable BindColumn()
        {
            DataTable dt = new DataTable("EmployeeData");
            dt.Columns.Add("S.No.", typeof(int));
            dt.Columns.Add("Employee Code", typeof(string));
            dt.Columns.Add("Employee Name", typeof(string));
            dt.Columns.Add("DOB", typeof(DateTime));
            dt.Columns.Add("Gender", typeof(string));
            dt.Columns.Add("Aadhar Number", typeof(long));
            dt.Columns.Add("Date Of Joining", typeof(DateTime));
            dt.Columns.Add("Department", typeof(string));
            dt.Columns.Add("Employee Type", typeof(string));
            dt.Columns.Add("Company", typeof(string));
            dt.Columns.Add("Chech-Up Date", typeof(DateTime));
            dt.Columns.Add("Health Status", typeof(string));
            dt.Columns.Add("Remarks", typeof(string));
            dt.Columns.Add("Report", typeof(string));
            dt.Columns.Add("Photo", typeof(Image));
            return dt;
        }
        public Image GetImage(byte[] bytearr)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytearr);
            Image i = Image.FromStream(ms);
            return i;
        }       
        public byte[] GetBytes(string filetype, string filename)
        {
            // Open file to read using file path
            FileStream FS = new FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            // Add filestream to binary reader
            BinaryReader BR = new BinaryReader(FS);

            // get total byte length of the file
            long allbytes = new FileInfo(filename).Length;
            FileBytes = BR.ReadBytes((Int32)allbytes);
            // close all instances
            FS.Close();
            FS.Dispose();
            BR.Close();
            return FileBytes;
        }
        public byte[] SaveImage(object value)
        {
            Image image = (Image)value;
            byte[] imageData = null;
            using (var ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                imageData = ms.ToArray();
            }
            return imageData;
        }
        public int SaveData(OHCReport oHCReport,int Sts)
        {
            int rslt = 0;
            try
            {
                //string mailbody=string.Format("Hi {0},\n\nA new UA/UC {1} for area location {2} has been submitted on {3}.\nKindly review and take appropriate action.\n\nThanks",
                //  null,  oHCReport.);
                if (Sts == 0)
                {
                    // For Insertion Command Execute
                    rslt = Resources.Instance.InsertRMPClOHC(oHCReport.SINO, oHCReport.EmployeeCode, oHCReport.EmployeeName, oHCReport.DOB,
                           ((int)oHCReport.Gender), oHCReport.AadharNumber, oHCReport.DOJ,
                           oHCReport.DepartmentName, oHCReport.EmployeeType, oHCReport.CompanyName, oHCReport.CheckUpDate, ((int)oHCReport.HealthStatus), oHCReport.ImageByte, oHCReport.Remark, oHCReport.FileBytes, oHCReport.ReportPath, 0);
                }
                else
                {
                    // For Update Command Execute
                    rslt = Resources.Instance.InsertRMPClOHC(oHCReport.SINO, oHCReport.EmployeeCode, oHCReport.EmployeeName, oHCReport.DOB,
                          ((int)oHCReport.Gender), oHCReport.AadharNumber, oHCReport.DOJ,
                          oHCReport.DepartmentName, oHCReport.EmployeeType, oHCReport.CompanyName, oHCReport.CheckUpDate, ((int)oHCReport.HealthStatus), oHCReport.ImageByte, oHCReport.Remark, oHCReport.FileBytes, oHCReport.ReportPath, 1);
                }
               
            }
            catch (Exception Ex)
            {
                rslt = 0;
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return rslt;
        }
        public int DeleteRecord(OHCReport oHCReport)
        {
            int rslt = 0;
            try
            {
                rslt = Resources.Instance.DeleteEmployeeOHC(oHCReport.AadharNumber, oHCReport.EmployeeCode);
            }
            catch (Exception Ex)
            {
                rslt = 0;
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return rslt;
        }
        public DataTable GetRecord()
        {
            return Resources.Instance.GetDataKey("SP_GetAllEmployeeData");
        }       
        public  bool IsValidName(string input)
        {
            if (input.Length == 0)
            {
                return false;
            }
            for (int i = 0; i < input.Length; i++)
            {
                //MessageBox.Show(input[i].ToString());
                if ((!(Char.IsLetter(input[i]))) && (!(Char.IsWhiteSpace(input[i]))))
                {
                    return false;
                }

            }
            return true;
        }
        public bool IsUniqueEmpId(string  id)
        {
            int idchk = 0;
            Resources.Instance.GetUniqueSrNo("SP_CheckUniqueEmpCode", "@EmpCode", id, ref idchk);
            if (idchk == 1)
            {
                return true;
            }
            else
            {
                // true if unique 
                return false;
            }
           
        }
        public  bool IsValidId(string input)
        {
            if (!Regex.IsMatch(input, @"^\d{12}$"))
            {
               // XtraMessageBox.Show("Invalid Aadhar Number.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;

        }
        public DataTable GetEmpType()
        {
            return Resources.Instance.EmployeementType;
        }
        public void ReloadPDF(string EmpName,byte[] filebyte)
        {
            FileStream FS = null;
            string filepath =  @"C:\Users\Public\Downloads\";
            string FileName = EmpName + ".pdf";
            filepath = Path.Combine(filepath, FileName);
            //Assign File path create file
            FS = new FileStream(filepath, System.IO.FileMode.Create);

            //Write bytes to create file
            FS.Write(filebyte, 0, filebyte.Length);

            //Close FileStream instance
            FS.Close();
            // Open fila after write 

            //Create instance for process class
            Process Proc = new Process();

            //assign file path for process
            Proc.StartInfo.FileName = filepath;
            Proc.Start();
        }

        private void SendMail(string fromMail, string mailTo, string mailCc, string Subject, string msgBody, Attachment stream)
        {

            //string mailTo = null;
            string FromMailAddress = string.Empty;
            string MailPassword = string.Empty;
            //string mailCc = null;
            string xmsg = string.Empty;
            MailMessage mail;
            HindalcoiOS.Configuration.MailConfig mConfig = HindalcoiOS.Configuration.MailConfig.Instance;
            mConfig.GetMailConfig();
            try
            {

                mail = new MailMessage();
                FromMailAddress = mConfig.MailFrom;// "support@sparrowrms.in";
                MailPassword = mConfig.MailPassword;// "Zoq36865";
                mail.From = new MailAddress(FromMailAddress, FromMailAddress);// "support@sparrowrms.in");
            }
            catch
            {
                xmsg = "Configure Proper Credentials in SettingOptions";
                throw new Exception(xmsg);
            }
            mail.Attachments.Add(stream);

            
            mail.Subject = Subject;// sfCred.Subject;
            mail.Body = msgBody;

            if (!string.IsNullOrEmpty(mailTo))
            {
                if (mailTo.Contains(','))
                {
                    foreach (var address in mailTo.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        string mailAddress = address.Trim();
                        mail.To.Add(new MailAddress(mailAddress));
                    }
                }
                else
                {
                    string mailAddress = mailTo.Trim();
                    mail.To.Add(new MailAddress(mailAddress));
                }
            }

            if (!string.IsNullOrEmpty(mailCc))
            {
                if (mailCc.Contains(','))
                {
                    foreach (var address in mailCc.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        string mailAddress = address.Trim();
                        mail.CC.Add(new MailAddress(mailAddress));
                    }
                }
                else
                {
                    string mailAddress = mailCc.Trim();
                    mail.CC.Add(new MailAddress(mailAddress));
                }
            }

            try
            {
                if (!string.IsNullOrEmpty(mailTo) && !string.IsNullOrEmpty(FromMailAddress))
                {
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = mConfig.Host;// "smtp.office365.com";
                    smtp.EnableSsl = mConfig.MailSSL;// true; 
                    smtp.Timeout = 200000;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Port = int.Parse(mConfig.Port); //587;
                    smtp.UseDefaultCredentials = false;
                    NetworkCredential nc = new NetworkCredential(FromMailAddress, MailPassword);
                    smtp.Credentials = nc;
                    ServicePointManager.ServerCertificateValidationCallback =
                delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                { return true; };

                    smtp.Send(mail);
                    mail.Dispose();
                    smtp.Dispose();
                    XtraMessageBox.Show("Report Sent Successfully.");
                }
            }
            catch (Exception Ex)
            {
                //XtraMessageBox.Show("Mail setting/server not working, Configure and try again", "Jubilant Food System!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    public enum Gender
    {
        Male=0,
        Female=1
    }
    public enum CompanyName
    {
        RMPCL=0
    }
    public enum HealthStatus
    {
        Good = 0,
        Excellent = 1,
        Poor = 2,
        [Display(Name = "Seriously Sick")]
        Sick = 3
    }
    public enum CallingStatus
    {
        New=0,
        Upload=1,
        Summary=2
    }
}
