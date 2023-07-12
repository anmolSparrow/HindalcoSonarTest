using CADImport;
using DevExpress.Diagram.Core.Native.Generation;
using DevExpress.XtraEditors;
using HindalcoiOS.AuditHind;
using HindalcoiOS.Connector_FRM;
using MySql.Data.MySqlClient;
using SparrowRMS;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames;

namespace HindalcoiOS.Class_Operation
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 0)]
    public struct holdUserInfo
    {
        public string UserName;
        public string UserType;
        public string EmpCode;
        public string DepartmentName;
        public string TrainerName;
        public string UserTeam;
        public int UserId;
        public bool IsActive;
        public string UserRole;
        public string ProjectName;



    }
    public class GlobalDeclaration
    {
        public static Dictionary<DPoint, string> _MyTagDictinary;
        public static Dictionary<string, string> _ActiveMachines = new Dictionary<string, string>();
        public static Dictionary<string, string> _DicMachineNo = new Dictionary<string, string>();
        public static ConcurrentDictionary<string, DPoint> _MachineCordinates = new ConcurrentDictionary<string, DPoint>();
        public static ConcurrentDictionary<string, String> _LineTypeHold = new ConcurrentDictionary<string, string>();
        public static string DbUserName = string.Empty;
        public static string DbPassword = string.Empty;
        public static string ServerName = string.Empty;
        public static DataTable MapColumnDGV = new DataTable();
        public static DataTable MapColumnDVGWithCTRL = new DataTable();
        public static DataTable AddedColumns = new DataTable();
        public static DataTable CAPAtbl;
        public static DataTable freedt;
        public static DataTable MapColumnSafetChkList = new DataTable();
        public static string appGuid =  "c0a76b5a-12ab-45c5-b9d9-d693faa6e7R8";
        public static string UserType = string.Empty;
        public static string UserName = string.Empty;
        public static string RPTPerson = string.Empty;
        public static string PermitType = string.Empty;
        public static int UserId = 0;
        public static int RoleId = 0;
        public static int EventReportId = 0;
        public static List<holdUserInfo> _holdInfo = new List<holdUserInfo>();
        public static DataTable KeyComponentDT = new DataTable();
        public static DPoint mcCordinate = new DPoint();
        public static string MName = string.Empty;
        public static bool FirstLogOut = false;
        public static string MCDMacName = string.Empty;
        public static bool isMachineMaster = false;
        public static bool isOperationUser = false;
        public static bool isEmpMaster = false;
        public static string isEpmCode = string.Empty;
        public static bool isConfigTrue = false;
        public static bool isServiceLog = true;
        public static int ServiceId;
       // public static int ServiceId;
        public static bool LocalOpen = false;
        ////public static Operation.ProductDetails prdDetails = new Operation.ProductDetails();
        public static string dayList = string.Empty;
        public static int dayCount = 0;
        public static string ProdCode = string.Empty;

        public static string IncidentCode = string.Empty;
        public static string plantName = string.Empty;
        public static decimal TotalProduction = 0;
        public static string ProdUnit = string.Empty;
        public static string CalendarMonth = string.Empty;
        public static bool isAdmin = false;
        public static bool isConsumptionFormClosed = false;

        public static string applicationBasePath = AppDomain.CurrentDomain.BaseDirectory;
        public static string applicationManifestPrimary = applicationBasePath + @"Manifest" + @"\" + @"NewManifest" + @"\";
        public static string applicationManifestSecondory = applicationBasePath + @"Manifest" + @"\" + @"OldManifest" + @"\";

        public static ArrayList FinancialYears;
        static GlobalDeclaration()
        {
            _MyTagDictinary = new Dictionary<DPoint, string>();
        }        
        public static string GenerateGlobalDocID(string procedureId, string preText)
        {
            string procureId = string.Empty;
            int randomDigit = 0; //;= helperobj.RandomNumber(1001, 9999);
            //string preText = preText;// "PUR";
            Resources.Instance.GetMaxID(procedureId, "@MaxID", ref randomDigit);
            //if (randomDigit == 0)
            //{
            //    randomDigit = 1;
            //}
            //else
            //    randomDigit += 1;
            //if (!CallingLocation)
            procureId = Convert.ToString(preText + '-' + 00 + randomDigit);
            return procureId;
        }
        public static DataTable GetAllOperationUnits()
        {
            return Resources.Instance.GetOperationUnit();
        }

        public static void ReadIniSetting()
        {
            string text = System.IO.Path.GetFullPath("AppSetting.ini");
            if (File.Exists(text))
            {
                IniFile.SetPath(text);
                if (!string.IsNullOrEmpty(IniFile.IniReadValue("DBConfig", "ServerName")))
                {
                    Resources.Instance.UpdateConnectring(IniFile.IniReadValue("DBConfig", "ServerName"), IniFile.IniReadValue("DBConfig", "DBName"), IniFile.IniReadValue("DBConfig", "Password"), IniFile.IniReadValue("DBConfig", "UserName"));
                    // loginBL.connect(Resources.Instance.connectionsstring);
                }
            }
        }
        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        #region General methods(Milan)
        /// <summary>
        /// Properties for API Token & Expiration Time.
        /// </summary>
        public static string ApiToken { get; set; }
        public static DateTime TokenExpiredOn { get; set; }
        public static void SendMail(string fromMail, string mailTo, string mailCc, string Subject, string msgBody)

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

                mail.From = new MailAddress(FromMailAddress, fromMail);// "support@sparrowrms.in");

            }

            catch

            {

                xmsg = "Configure Proper Credentials in SettingOptions";

                throw new Exception(xmsg);

            }

            //mail.Attachments.Add(stream);





            mail.Subject = Subject;// sfCred.Subject;

            mail.Body = msgBody;



            if (!string.IsNullOrEmpty(mailTo))

            {

                if (mailTo.Contains(","))

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

                if (mailCc.Contains(","))

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

                    //XtraMessageBox.Show("Mail Sent Successfully.");

                }

            }

            catch (Exception Ex)

            {

                //XtraMessageBox.Show("Mail setting/server not working, Configure and try again", "Jubilant Food System!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        public static void HideTabCtrlPagesHeader(SparrowRMSControl.SparrowControl.SparrowTabControl tabControls)

        {

            tabControls.Appearance = TabAppearance.FlatButtons;

            tabControls.ItemSize = new System.Drawing.Size(0, 1);

            tabControls.SizeMode = TabSizeMode.Fixed;



            foreach (TabPage tab in tabControls.TabPages)

            {

                tab.Hide();// = "";

            }

        }

    
        public static string GetUserName(string userId)

        {

            string userName = string.Empty;

            var userCount = Properties.Settings.Default.AllUsers.AsEnumerable().Where(X => X.Field<string>("UserID") == userId).ToList();

            if (userCount.Count > 0)

                userName = Properties.Settings.Default.AllUsers.AsEnumerable().Where(X => X.Field<string>("UserID") == userId).ToList().FirstOrDefault()["UserName"].ToString();

            return userName;

        }

        public static string GetUserId(string userName)

        {

            string userId = string.Empty;

            var userCount = Properties.Settings.Default.AllUsers.AsEnumerable().Where(X => X.Field<string>("UserName") == userName).ToList();

            if (userCount.Count > 0)

                userId = Properties.Settings.Default.AllUsers.AsEnumerable().Where(X => X.Field<string>("UserName") == userName).ToList().FirstOrDefault()["UserID"].ToString();

            return userId;

        }

        public static string CleanURL(string linkUrl)

        {

            if (linkUrl.Contains('"'))

            {

                linkUrl = linkUrl.Replace('"', ' ').Replace("= ", "=").Trim().TrimEnd();

            }

            return linkUrl;

        }

        public static string GetDeptName(int deptId)

        {

            string deptName = string.Empty;

            var deptCount = Properties.Settings.Default.Departments.AsEnumerable().Where(X => X.Field<int>("DeptId") == deptId).ToList();

            if (deptCount.Count > 0)

                deptName = Properties.Settings.Default.Departments.AsEnumerable().Where(X => X.Field<int>("DeptId") == deptId).ToList().FirstOrDefault()["Dept_Name"].ToString();

            return deptName;

        }

        public static int GetDeptId(string deptName)

        {

            int deptId = 0;

            var deptCount = Properties.Settings.Default.Departments.AsEnumerable().Where(X => X.Field<string>("Dept_Name") == deptName).ToList();

            if (deptCount.Count > 0)

                deptId = (int)(Properties.Settings.Default.Departments.AsEnumerable().Where(X => X.Field<string>("Dept_Name") == deptName).ToList().FirstOrDefault()["DeptId"]);

            return deptId;

        }

        public static int DocStatusValueToInt(string EnumValue)

        {

            int iVal;

            iVal = (int)((DocStatus)Enum.Parse(typeof(DocStatus), EnumValue, true));

            return iVal;

        }

        public static string DocStatusEnumIntToValue(int val)

        {

            string sVal;

            sVal = ((DocStatus)val).ToString();// Enum.Parse(typeof(DocStatus), val, true);

            return sVal;

        }

        public static void FinancialYearGenerator()
        {
            int val1 = 20;
            int val2 = 21;

            int startYear = 2020;
            int currYear = 0;
            if (DateTime.Today.Month != 1 && DateTime.Today.Month != 2 && DateTime.Today.Month != 3)
            {
                currYear = DateTime.Today.AddYears(1).Year;
            }
            else
            {
                currYear = DateTime.Today.Year;
            }
            FinancialYears = new ArrayList();
            int yearDiff = currYear - startYear;
            for (int i = 1; i <= yearDiff; i++)
            {
                string str = string.Format("{0}-{1}", val1.ToString(), val2.ToString());
                FinancialYears.Add(str);
                val1 = val2;
                val2 += 1;
            }

        }

        #endregion
        public static void ReadINIData()
        {
            try
            {
                string text = System.IO.Path.GetFullPath("AppSetting.ini");
                IniFile.SetPath(text);
                if (File.Exists(text))
                {
                    IniFile.SetPath(text);
                    if (!string.IsNullOrEmpty(IniFile.IniReadValue("DBConfig", "ServerName")))
                    {

                        //txtServerName.Text = IniFile.IniReadValue(DBSection, "ServerName");
                        //txtDBName.Text = IniFile.IniReadValue(DBSection, "DBName");
                        //txtPassword.Text = IniFile.IniReadValue(DBSection, "Password");
                        //txtUserName.Text = IniFile.IniReadValue(DBSection, "UserName");
                        ////if (!string.IsNullOrEmpty(IniFile.IniReadValue(FTPSectionName, "IPAddress")))
                        ////{
                        ////    TxtFTPAddress.Text = IniFile.IniReadValue(FTPSectionName, "IPAddress");
                        ////    txtFTPFolder.Text = IniFile.IniReadValue(FTPSectionName, "FolderName");
                        ////    txtFTPPassword.Text = IniFile.IniReadValue(FTPSectionName, "Password");
                        ////    txtFtpUserName.Text = IniFile.IniReadValue(FTPSectionName, "UserName");
                        ////    if (!string.IsNullOrEmpty(IniFile.IniReadValue(DBSection, "Server"))|| !string.IsNullOrEmpty(IniFile.IniReadValue(DBSection, "Local")))
                        ////    {
                        ////        chkserver.Checked = bool.Parse(IniFile.IniReadValue(DBSection, "Server"));
                        ////        chklocal.Checked = bool.Parse(IniFile.IniReadValue(DBSection, "Local"));
                        ////    }
                        ////}
                        ////else
                        ////{
                        ////    XtraMessageBox.Show("Your FTP Seeting Not Configured.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ////    return;
                        ////}
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static string ReturnPath()
        {
            string path = string.Empty;
            if (!string.IsNullOrEmpty(IniFile.IniReadValue("DBConfig", "FolderPath")))
                path = IniFile.IniReadValue("DBConfig", "FolderPath");
            return path;
        }
        public static void WriteIniFile(string servername, string userName, string DBName, string Password)
        {
            try
            {
                string Path = string.Empty;
                Path = Application.StartupPath + @"\" + "AppSetting.ini";
                if (!File.Exists(Path))
                {
                    Directory.CreateDirectory(Path);
                }
                IniFile.SetPath(Path);
                if (!string.IsNullOrEmpty(servername) && !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(DBName) && !string.IsNullOrEmpty(Password))
                {
                    IniFile.IniWriteValue("DBConfig", "ServerName", servername);
                    IniFile.IniWriteValue("DBConfig", "UserName", userName);
                    IniFile.IniWriteValue("DBConfig", "DBName", DBName);
                    IniFile.IniWriteValue("DBConfig", "Password", Password);
                    IniFile.IniWriteValue("DBConfig", "DummyDB", DBName);
                }
                else
                {
                    //IniFile.IniWriteValue("DBConfig", "ServerName", servername);
                    IniFile.IniWriteValue("DBConfig", "DummyDB", DBName);
                    IniFile.IniWriteValue("DBConfig", "DBName", DBName);
                }
                /// FTP Setting ------------
                //IniFile.IniWriteValue(FTPSectionName, "IPAddress", TxtFTPAddress.Text);
                //IniFile.IniWriteValue(FTPSectionName, "UserName", txtFtpUserName.Text);
                //IniFile.IniWriteValue(FTPSectionName, "FolderName", txtFTPFolder.Text);
                //IniFile.IniWriteValue(FTPSectionName, "Password", txtFTPPassword.Text);
                //IniFile.IniWriteValue(DBSection, "Local", chklocal.Checked.ToString());
                //IniFile.IniWriteValue(DBSection, "Server", chkserver.Checked.ToString());
                XtraMessageBox.Show("Information Saved Successfully.....", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ProjectIniFileUpdate(string servername, string userName, string DBName, string Password, string folderpath, string filename, string autocadstatus, string fileextention)
        {
            string path = @"\HindalcoApp\HindalcoiOS\HindalcoApp\AppSetting.ini";
            if (File.Exists(path))
            {
                IniFile.SetPath(path);
                if (!string.IsNullOrEmpty(servername))
                {
                    IniFile.IniWriteValue("DBConfig", "ServerName", servername);
                }
                if (!string.IsNullOrEmpty(userName))
                {
                    IniFile.IniWriteValue("DBConfig", "UserName", userName);
                }
                if (!string.IsNullOrEmpty(DBName))
                {
                    IniFile.IniWriteValue("DBConfig", "DBName", DBName);
                    IniFile.IniWriteValue("DBConfig", "DummyDB", DBName);
                }
                if (!string.IsNullOrEmpty(Password))
                {
                    IniFile.IniWriteValue("DBConfig", "Password", Password);
                }
                if (!string.IsNullOrEmpty(folderpath))
                {
                    IniFile.IniWriteValue("DBConfig", "FolderPath", folderpath);
                }
                if (!string.IsNullOrEmpty(filename))
                {
                    IniFile.IniWriteValue("DBConfig", "FileName", filename);
                }
                if (!string.IsNullOrEmpty(autocadstatus))
                {
                    IniFile.IniWriteValue("DBConfig", "AutoCADStatus", autocadstatus);
                }
                if (!string.IsNullOrEmpty(fileextention))
                {
                    IniFile.IniWriteValue("DBConfig", "FileExtension", fileextention);
                }
            }
        }
        public static bool DBCheck()
        {
            try
            {
                string databaseName = string.Empty;
                if (!string.IsNullOrEmpty(IniFile.IniReadValue("DBConfig", "ServerName")))
                {
                    databaseName = IniFile.IniReadValue("DBConfig", "DummyDB").Trim();
                    string connectionString = Resources.Instance.GetConnection; //Resources.Instance.connectionsstring;                                     
                    //nn =nn.Replace(databaseName, "Master").Replace("_Security", "true");
                    // ConnectionString.Replace("DBSource", ".").Replace("_Security", "true");
                    //string local= "Data Source=DBSource; Initial Catalog=master; Integrated Security=_Security;Connect Timeout=50;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultipleActiveResultSets=False";
                    // local = local.Replace("DBSource", ".").Replace("_Security", "true");                   
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        using (var command = new MySqlCommand($"select SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA where SCHEMA_NAME  in('{databaseName}')", connection))
                        {
                            var gg = command.ExecuteScalar();
                            if (gg != null)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }

                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);
                return false;
            }
        }

        /// <summary>
        /// This Is use for Make RC Connector Cordinates using with Drop Destination Machine Cordinates
        /// </summary>
        /// <param name="Cordinates"></param>
        /// <returns></returns>
        public static DPoint _Dpoint(string Cordinates)
        {
            double Xaxix = 592.334;
            double yaxix = 47.4549;
            string[] Val = Cordinates.Split(' ');
            string jj = Val[0].Substring(1);
            double X1 = double.Parse(Val[0].Substring(1));
            double Y1 = double.Parse(Val[1].Substring(1));
            X1 = X1 + Xaxix;
            Y1 = Y1 - yaxix;
            DPoint pos = new DPoint(Math.Round(X1, 4), Math.Round(Y1, 4), 0);
            return pos;
        }
        public static void Splitclm(string value, string tblname)
        {
            try
            {
                if (tblname == "WithNoControls")
                {
                    var str = value.Split(',');
                    foreach (string item in str)
                    {
                        string[] Splirec = item.Split(':');
                        MapColumnDGV.Columns.Add(getColmnName(Splirec[0], Splirec[1]));
                    }
                }
                else if (tblname == "WithNewcontrols")
                {
                    var str = value.Split(',');
                    foreach (string item in str)
                    {
                        string[] Splirec = item.Split(':');
                        MapColumnDVGWithCTRL.Columns.Add(getColmnName(Splirec[0], Splirec[1]));
                    }
                }
                else if (tblname == "SafetyCheckListclm")
                {
                    var str = value.Split(',');
                    foreach (string item in str)
                    {
                        string[] Splirec = item.Split(':');
                        MapColumnSafetChkList.Columns.Add(getColmnName(Splirec[0], Splirec[1]));
                    }
                }
            }
            catch (Exception Ex)
            {

                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //public  static DataTable ExcelToDataTableUsingExcelDataReader(string storePath)
        //{
        //    FileStream stream = File.Open(storePath, FileMode.Open, FileAccess.Read);
        //    string fileExtension = Path.GetExtension(storePath);
        //    IExcelDataReader excelReader = null;
        //    if (fileExtension == ".xls")
        //    {
        //        excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
        //    }
        //    else if (fileExtension == ".xlsx")
        //    {
        //        excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        //    }

        //    // excelReader.IsFirstColumn = true;
        //    DataSet result = excelReader.AsDataSet();
        //    var test = result.Tables[0];
        //    return result.Tables[0];
        //}

        public static DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MachineName", typeof(string));
            dt.Columns.Add("Parameter Name", typeof(string));
            dt.Columns.Add("Unit", typeof(string));
            dt.Columns.Add("Minimum Value", typeof(string));
            dt.Columns.Add("Maximum Value", typeof(string));
            dt.Columns.Add("Operating Value", typeof(string));
            dt.Columns.Add("Rfq", typeof(string));
            dt.Columns.Add("Param Tag", typeof(string));
            dt.Columns.Add("Data Tag", typeof(string));
            dt.Columns.Add("Header Id", typeof(int));
            dt.Columns.Add("Control Type", typeof(string));
            return dt;
        }
        public static DataTable MapColumnCAPA()
        {
            CAPAtbl = new DataTable();
            CAPAtbl.Columns.Add("MachineTag", typeof(string));//Read Only Fields
            CAPAtbl.Columns["MachineTag"].ReadOnly = true;//Read Only Fields

            CAPAtbl.Columns.Add("MachineName", typeof(string));//Read Only Fields
            CAPAtbl.Columns["MachineName"].ReadOnly = true;

            CAPAtbl.Columns.Add("objectitem", typeof(string)); //Read Only Fields
            CAPAtbl.Columns["objectitem"].ReadOnly = true;

            CAPAtbl.Columns.Add("ObjRslt", typeof(string));    //Read Only Fields
            CAPAtbl.Columns["ObjRslt"].ReadOnly = true;

            CAPAtbl.Columns.Add("ObjObserv", typeof(string));  //Read Only Fields
            CAPAtbl.Columns["ObjObserv"].ReadOnly = true;

            CAPAtbl.Columns.Add("Criticality", typeof(string));//Read Only Fields
            CAPAtbl.Columns["Criticality"].ReadOnly = true;

            CAPAtbl.Columns.Add("Elements", typeof(string));
            CAPAtbl.Columns["Elements"].ReadOnly = true;

            CAPAtbl.Columns.Add("immediatecause", typeof(string));
            CAPAtbl.Columns.Add("RootCause", typeof(string));
            CAPAtbl.Columns.Add("CorrectiveAction", typeof(string));
            CAPAtbl.Columns.Add("Reason", typeof(string));
            CAPAtbl.Columns.Add("PreventiveAct", typeof(string));
            CAPAtbl.Columns.Add("Responsibility0", typeof(string));
            CAPAtbl.Columns.Add("Responsibility1", typeof(string));
            CAPAtbl.Columns.Add("Escalation", typeof(string));
            CAPAtbl.Columns.Add("UserName", typeof(string));
            CAPAtbl.Columns["UserName"].ReadOnly = true;
            CAPAtbl.Columns.Add("UserId", typeof(int));
            CAPAtbl.Columns["UserId"].ReadOnly = true;
            CAPAtbl.Columns.Add("EmpCode", typeof(string));
            CAPAtbl.Columns["EmpCode"].ReadOnly = true;
            return CAPAtbl;
        }
        public static IList<string> GetTablenames(DataTableCollection tables)
        {
            var tableList = new List<string>();
            foreach (var table in tables)
            {
                tableList.Add(table.ToString());
            }

            return tableList;
        }

        public static DataColumn getColmnName(string colmnname, string DataType, bool KeepNull = true, Boolean keepUnique = false)
        {
            DataColumn DC = new DataColumn();
            try
            {
                DC.AllowDBNull = KeepNull;
                DC.ColumnName = colmnname.Trim();
                if (DataType.Trim() == "string")
                {
                    DataType = "String";
                }
                DC.DataType = Type.GetType("System." + DataType);
                DC.Unique = keepUnique;
            }
            catch (Exception Ex)
            {

                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return DC;

        }
        public static bool SaveUpdateDicToXml(string Path, Dictionary<string, List<string>> Value1)
        {
            //Stopwatch f = new Stopwatch();
            //f.Start();
            //var openTiming = f.ElapsedMilliseconds;
            bool isStatus;
            try
            {
                XElement Keyxml = new XElement("Dictionary");
                foreach (KeyValuePair<string, List<string>> item in Value1)
                {
                    string Key = item.Key;
                    List<string> cnn = item.Value;
                    var xml = new XElement("Key", new XAttribute("key", Key));
                    for (int i = 0; i < cnn.Count; i++)
                    {
                        string ReceiveValue = cnn[i];
                        var el = new XElement("Value", ReceiveValue);
                        xml.Add(el);
                    }
                    //, new XElement("Connected", cnn.Connecto), new XElement("FromData", cnn.FromData));
                    Keyxml.Add(xml);
                }
                Keyxml.Save(Path);
                isStatus = true;
                //f.Stop();
                //string Time = "Elapsed: " + (f.ElapsedMilliseconds).ToString() + " ms (" + openTiming.ToString() + " ms to open)";
                //Console.WriteLine("List={0}", Time);
            }
            catch (Exception Ex)
            {
                isStatus = false;
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isStatus;
        }
        public static Dictionary<string, List<string>> LoadDicXmlData(string path)
        {
            Dictionary<string, List<string>> _hh = new Dictionary<string, List<string>>();
            XDocument Doc = XDocument.Load(path);
            foreach (XElement item in Doc.Root.Elements())
            {
                string key = item.Attribute("key").Value;
                string Source = string.Empty;
                List<string> _list = new List<string>();
                foreach (var item1 in item.Elements())
                {
                    Source = item1.Value;
                    if (!_list.Contains(Source))
                    {
                        _list.Add(Source);
                    }
                    else
                    {
                        if (_hh.ContainsKey(key))
                        {
                            List<string> _Return = _hh[key];
                            _Return.Add(Source);
                            _hh[key] = _Return;

                        }
                    }
                }
                if (_hh.ContainsKey(key))
                {
                    // List<string> _Return = _hh[key];
                    // _Return.Add(Source);
                    // _hh[key] = _Return;

                }
                else
                {
                    _hh.Add(key, _list);
                }


            }
            return _hh;

        }
        public static bool SaveLineConnectorToXml(string Path, Dictionary<string, Connector> _listconnt)
        {
            bool isStatus;
            //Stopwatch f = new Stopwatch();
            //f.Start();
            //var openTiming = f.ElapsedMilliseconds;
            try
            {
                XElement Keyxml = new XElement("LineConnector");
                foreach (KeyValuePair<string, Connector> item in _listconnt)
                {
                    string Key = item.Key;
                    Connector cnn = item.Value;
                    var xml = new XElement("DataKey", new XElement("Key", Key), new XElement("Connected", cnn.Connecto), new XElement("FromData", cnn.FromData), new XElement("DPoint", cnn.Points), new XElement("FromDPoint", cnn.FromDPoint), new XElement("ToDPoint", cnn.ToDPoint));
                    Keyxml.Add(xml);
                }
                //Keyxml.Save(Path);
                if (System.IO.Path.GetExtension(Path) == ".spr")
                {
                    string cipherText = CryptorEngine.Encrypt(Keyxml.ToString(), true);
                    using (StreamWriter fs = new StreamWriter(Path))
                    {
                        fs.Write(cipherText);
                        fs.Flush();
                        fs.Close();
                        isStatus = true;
                    }
                }
                else
                {
                    Keyxml.Save(Path);
                    isStatus = true;
                }               
                //f.Stop();
                //string Time = "Elapsed: " + (f.ElapsedMilliseconds).ToString() + " ms (" + openTiming.ToString() + " ms to open)";
                //Console.WriteLine("SaveTime={0}", Time);
            }
            catch (Exception Ex)
            {
                isStatus = false;
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isStatus;
        }
        public static void SaveMachineTagXml(string Path, Dictionary<DPoint, string> Tag)
        {
            XElement Keyxml = new XElement("MachineTagInfo");
            foreach (KeyValuePair<DPoint, string> item in Tag)
            {
                DPoint dPoint = item.Key;
                string MachineTag = item.Value;
                var xml = new XElement("TagInfo", new XElement("MachineTag", MachineTag), new XElement("Cordinates", new XAttribute("Xvalue", dPoint.X), new XAttribute("Yvalue", dPoint.Y)));
                Keyxml.Add(xml);
            }
            // Keyxml.Save(Path);
            if (System.IO.Path.GetExtension(Path) == ".spr")
            {
                string cipherText = CryptorEngine.Encrypt(Keyxml.ToString(), true);
                using (StreamWriter fs = new StreamWriter(Path))
                {
                    fs.Write(cipherText);
                    fs.Flush();
                    fs.Close();
                }
            }
            else
            {
                Keyxml.Save(Path);
            }
        }
        public static void SaveMachineInfoXml(string Path, Dictionary<string, string> MachineName, Dictionary<string, DPoint> Cordinate)
        {
            try
            {
                XElement Keyxml = new XElement("MachineInfo");
                foreach (KeyValuePair<string, string> item in MachineName)
                {
                    string Mnname = item.Key;
                    string SysGen = item.Value;
                    DPoint dPoint = Cordinate[Mnname];
                    var xml = new XElement("DataInfo", new XElement("MachineName", Mnname), new XElement("SysGenNo", SysGen), new XElement("Cordinates", new XAttribute("Xvalue", dPoint.X), new XAttribute("Yvalue", dPoint.Y)));
                    Keyxml.Add(xml);
                }
                // Keyxml.Save(Path);
                if (System.IO.Path.GetExtension(Path) == ".spr")
                {
                    string cipherText = CryptorEngine.Encrypt(Keyxml.ToString(), true);
                    using (StreamWriter fs = new StreamWriter(Path))
                    {
                        fs.Write(cipherText);
                        fs.Flush();
                        fs.Close();
                    }
                }
                else
                {
                    Keyxml.Save(Path);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void SaveOffSet(string pth, Dictionary<string, DPoint> offset)
        {
            XElement Keyxml = new XElement("OffSetCordinates");
            foreach (KeyValuePair<string, DPoint> item in offset)
            {
                string tabname = item.Key;
                DPoint dPoint = item.Value;
                var xml = new XElement("TabInfo", new XElement("TabName", tabname), new XElement("OffSetCord", new XAttribute("Xvalue", dPoint.X), new XAttribute("Yvalue", dPoint.Y)));
                Keyxml.Add(xml);
            }
            
            if (System.IO.Path.GetExtension(pth) == ".spr")
            {
                string cipherText = CryptorEngine.Encrypt(Keyxml.ToString(), true);
                using (StreamWriter fs = new StreamWriter(pth))
                {
                    fs.Write(cipherText);
                    fs.Flush();
                    fs.Close();
                }
            }
            else
            {
               Keyxml.Save(pth);
            }
        }
        public static Dictionary<string, Connector> LoadConnectorStruct(string path)
        {
            Dictionary<string, Connector> _ReturnDic = new Dictionary<string, Connector>();
            try
            {

                string cipherTest = string.Empty;
                XmlDocument doc1 = new XmlDocument();
                using (StreamReader sr = new StreamReader(path))
                {
                    cipherTest = sr.ReadToEnd();
                    sr.Close();
                }
                if (Path.GetExtension(path) == ".spr")
                {
                    string decryptedText = CryptorEngine.Decrypt(cipherTest, true);
                    //doc1.Load(@"C:\Users\Public\Documents\AsianPaints\SparrowCAD\NewPoints.xml");
                    //string value = doc1.OuterXml;
                    doc1.LoadXml(decryptedText);
                }
                else
                {
                    doc1.Load(path);
                }
                XDocument doc = XDocument.Parse(doc1.OuterXml);
                foreach (XElement item in doc.Root.Nodes())
                {
                    Connector _Conntor = new Connector();
                    string key = string.Empty;
                    key = item.Element("Key").Value;
                    _Conntor.Connecto = item.Element("Connected").Value;
                    _Conntor.FromData = item.Element("FromData").Value;
                    _Conntor.Points = item.Element("DPoint").Value;
                    _Conntor.FromDPoint = item.Element("FromDPoint").Value;
                    _Conntor.ToDPoint = item.Element("ToDPoint").Value;
                    if (!_ReturnDic.ContainsKey(key))
                        _ReturnDic.Add(key, _Conntor);
                }
                //f.Stop();
                //string Time = "Elapsed: " + (f.ElapsedMilliseconds).ToString() + " ms (" + openTiming.ToString() + " ms to open)";
                //Console.WriteLine("LoadTime={0}", Time);

            }
            catch (Exception Ex)
            {

                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return _ReturnDic;
        }
        public static Dictionary<DPoint, string> LoadMachineTag(string _Path)
        {
            var dict1 = new Dictionary<DPoint, string>();
            string cipherTest = string.Empty;
            XmlDocument doc1 = new XmlDocument();
            using (StreamReader sr = new StreamReader(_Path))
            {
                cipherTest = sr.ReadToEnd();
                sr.Close();
            }
            if (Path.GetExtension(_Path) == ".spr")
            {
                string decryptedText = CryptorEngine.Decrypt(cipherTest, true);
                doc1.LoadXml(decryptedText);
            }
            else
            {
                doc1.Load(_Path);
            }
            XDocument doc = XDocument.Parse(doc1.OuterXml);
            // XDocument doc = XDocument.Load(Path);
            foreach (XElement item in doc.Root.Nodes())
            {
                DPoint dPoint = new DPoint
                {
                    X = double.Parse(item.Element("Cordinates").Attribute("Xvalue").Value),
                    Y = double.Parse(item.Element("Cordinates").Attribute("Yvalue").Value)
                };
                string key = item.Element("MachineTag").Value;
                if (!dict1.ContainsKey(dPoint))
                {
                    dict1.Add(dPoint, key);
                }
            }
            return dict1;
        }
        public static void SaveRCConnectorDic(string Path, Dictionary<DPoint, string> RC)
        {
            XElement Keyxml = new XElement("RCInfo");
            foreach (KeyValuePair<DPoint, string> item in RC)
            {
                DPoint dPoint = item.Key;
                string MachineTag = item.Value;
                var xml = new XElement("RCName", new XElement("Name", MachineTag), new XElement("Cordinates", new XAttribute("Xvalue", dPoint.X), new XAttribute("Yvalue", dPoint.Y)));
                Keyxml.Add(xml);
            }
            //Keyxml.Save(Path);
            if (System.IO.Path.GetExtension(Path) == ".spr")
            {
                string cipherText = CryptorEngine.Encrypt(Keyxml.ToString(), true);
                using (StreamWriter fs = new StreamWriter(Path))
                {
                    fs.Write(cipherText);
                    fs.Flush();
                    fs.Close();
                }
            }
            else
            {
                Keyxml.Save(Path);
            }            
        }
        public static Dictionary<DPoint, string> LoadRCMachines(string filepath)
        {
            var dict1 = new Dictionary<DPoint, string>();
            string cipherTest = string.Empty;
            XmlDocument doc1 = new XmlDocument();
            using (StreamReader sr = new StreamReader(filepath))
            {
                cipherTest = sr.ReadToEnd();
                sr.Close();
            }
            if (Path.GetExtension(filepath) == ".spr")
            {
                string decryptedText = CryptorEngine.Decrypt(cipherTest, true);
                doc1.LoadXml(decryptedText);
            }
            else
            {
                doc1.Load(filepath);
            }
            XDocument doc = XDocument.Parse(doc1.OuterXml);
            foreach (XElement item in doc.Root.Nodes())
            {
                DPoint dPoint = new DPoint
                {
                    X = double.Parse(item.Element("Cordinates").Attribute("Xvalue").Value),
                    Y = double.Parse(item.Element("Cordinates").Attribute("Yvalue").Value)
                };
                string key = item.Element("Name").Value;
                if (!dict1.ContainsKey(dPoint))
                {
                    dict1.Add(dPoint, key);
                }
            }
            return dict1;
        }
        public static Dictionary<string, DPoint> LoadOffSet(string filepath)
        {
            var dict1 = new Dictionary<string, DPoint>();
            string cipherTest = string.Empty;
            XmlDocument doc1 = new XmlDocument();
            using (StreamReader sr = new StreamReader(filepath))
            {
                cipherTest = sr.ReadToEnd();
                sr.Close();
            }
            if (Path.GetExtension(filepath) == ".spr")
            {
                string decryptedText = CryptorEngine.Decrypt(cipherTest, true);
                doc1.LoadXml(decryptedText);
            }
            else
            {
                doc1.Load(filepath);
            }         
            XDocument doc = XDocument.Parse(doc1.OuterXml);
            // XDocument doc = XDocument.Load(Path);
            foreach (XElement item in doc.Root.Nodes())
            {
                DPoint dPoint = new DPoint
                {
                    X = double.Parse(item.Element("OffSetCord").Attribute("Xvalue").Value),
                    Y = double.Parse(item.Element("OffSetCord").Attribute("Yvalue").Value)
                };
                string key = item.Element("TabName").Value;
                if (!dict1.ContainsKey(key))
                {
                    dict1.Add(key, dPoint);
                }
            }
            return dict1;
        }
        public static Tuple<Dictionary<string, string>, Dictionary<string, DPoint>> GetDictionary(string _Path)
        {
            var dict1 = new Dictionary<string, string>();
            var dict2 = new Dictionary<string, DPoint>();
            try
            {
                string MachineName = string.Empty;
                string SysGen = string.Empty;
                string cipherTest = string.Empty;
                XmlDocument doc1 = new XmlDocument();
                using (StreamReader sr = new StreamReader(_Path))
                {
                    cipherTest = sr.ReadToEnd();
                    sr.Close();
                }
                if (Path.GetExtension(_Path) == ".spr")
                {
                    string decryptedText = CryptorEngine.Decrypt(cipherTest, true);
                    //doc1.Load(@"C:\Users\Public\Documents\AsianPaints\SparrowCAD\Trial 11fDxf.xml");
                    //string value = doc1.OuterXml;
                    doc1.LoadXml(decryptedText);

                }
                else
                {
                    doc1.Load(_Path);
                }
                XDocument xdoc = XDocument.Parse(doc1.OuterXml);
                foreach (XElement item in xdoc.Root.Nodes())
                {
                    DPoint dPoint = new DPoint
                    {

                        X = double.Parse(item.Element("Cordinates").Attribute("Xvalue").Value),
                        Y = double.Parse(item.Element("Cordinates").Attribute("Yvalue").Value)
                    };
                    MachineName = item.Element("MachineName").Value;
                    SysGen = item.Element("SysGenNo").Value;
                    if (!dict1.ContainsKey(MachineName))
                    {
                        dict1.Add(MachineName, SysGen);
                        dict2.Add(MachineName, dPoint);
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Tuple.Create(dict1, dict2);
        }
        public static DataTable BindFreezPlanClm()
        {
            freedt = new DataTable();
            freedt.Columns.Add("Maintenancetype", typeof(string));
            freedt.Columns.Add("MachineTag", typeof(string));
            freedt.Columns.Add("MachineName", typeof(string));
            freedt.Columns.Add("frequency", typeof(string));
            freedt.Columns.Add("ShtdownReq", typeof(string));
            freedt.Columns.Add("Resource", typeof(string));
            freedt.Columns.Add("ManPower", typeof(string));
            freedt.Columns.Add("MeterReading", typeof(string));
            return freedt;
        }
        public static DPoint RerurnDpoint(string Cordinate)
        {
            string[] SourceValue = Cordinate.Split(' ');
            double X11 = double.Parse(SourceValue[0].Substring(1));
            double Y11 = double.Parse(SourceValue[1].Substring(1));
            DPoint poSource = new DPoint(X11, Y11, 0);
            return poSource;
        }  
    }
    public class CryptorEngine
    {
        /// <summary>
        /// Encrypt a string using dual encryption method. Return a encrypted cipher Text
        /// </summary>
        /// <param name="toEncrypt">string to be encrypted</param>
        /// <param name="useHashing">use hashing? send to for extra secirity</param>
        /// <returns></returns>
        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            System.Configuration.AppSettingsReader settingsReader = new System.Configuration.AppSettingsReader();
            // Get the key from config file
            string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
            //System.Windows.Forms.MessageBox.Show(key);
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// DeCrypt a string using dual encryption method. Return a DeCrypted clear string
        /// </summary>
        /// <param name="cipherString">encrypted string</param>
        /// <param name="useHashing">Did you use hashing to encrypt this data? pass true is yes</param>
        /// <returns></returns>
        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            System.Configuration.AppSettingsReader settingsReader = new System.Configuration.AppSettingsReader();
            //Get your key from config file to open the lock!
            string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
       
    }
    public static class Iconmapping
    {
        # region Data Fields(public readonly)
        /// <summary>
        /// Mapping from <see cref="NodeClass"/> to corresponding image index.
        /// </summary>
        public static readonly Dictionary<NodeClass, int> OpcNodeClassIconMapping = new Dictionary<NodeClass, int>
        {
            {NodeClass.Unspecified, 0 },
            {NodeClass.ClassType, 1 },
            {NodeClass.ObjectType, 2 },
            {NodeClass.ValueType, 3 }
        };
        #endregion

        #region GetIcon Method (public)

        /// <summary>
        /// Returns corresponding image index for given properties of OPC Node.
        /// </summary>
        /// <param name="nodeClass">NodeClass of the node.</param>
        /// <param name="typeDefinition">TypeDefinition of the node.</param>
        /// <returns>Integer representing index of the selected image.</returns>
        public static int GetIconIndex(NodeClass nodeClass, string typeDefinition)
        {
            return Math.Max(OpcNodeClassIconMapping[nodeClass], GetCustomIconIndex(typeDefinition));
        }
        #endregion

        #region GetIcon Helper Method (private)

        /// <summary>
        /// Returns corresponding image index for given custom type.
        /// </summary>
        /// <param name="typeDefinition">TypeDefinition of the node.</param>
        /// <returns>Integer representing index of the selected image.</returns>
        private static int GetCustomIconIndex(string typeDefinition)
        {
            if (typeDefinition == "FolderType")
            {
                return 9;
            }
            else if (typeDefinition == "ClassType")
            {
                return 10;
            }
            else if (typeDefinition.StartsWith("Points"))
            {
                return 11;
            }
            else if (typeDefinition.StartsWith("Propety"))
            {
                return 8;
            }
            else if (typeDefinition.StartsWith("Value"))
            {
                return 4;
            }
            else
            {
                return -1;
            }
        }

        #endregion
    }

   

    /// <summary>
    /// Represents the NodeClass of an TreeNode object.
    /// </summary>
    public enum NodeClass
    {
        Unspecified = 0,
        ObjectType = 4,
        ClassType = 8,
        ValueType = 16
    }
    public enum RoleType
    {
        Admin = 1,
        User = 2,
        Maintenance = 3,
        Safety = 5,
        Operation = 4,
        Corporate = 10,
        GM = 7,
        REQ = 8,
        DepartmentHead = 11,
        DepartmentUser = 12,
        CommiteeHead = 13,
        CommiteeMember = 14,
        TaskForce = 15,
        CAPAUser = 16
    }
}
