using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.Login_Form
{
    public partial class LoginPanel : XtraForm
    {
        #region Variable Declaration
        public const string DBSection = "DBConfig";
        private int appid = 0;
        public static string userid;
        private string Result = string.Empty;
        private string ProjectName = string.Empty;
        private string DeptName = string.Empty;
        private string UserName = string.Empty;
        private string RoleName = string.Empty;
        private string GeoLocation = string.Empty;
        private string EmpCode = string.Empty;
        private int UserID = 0;
        public bool CADStatus = false;
        #endregion
        public LoginPanel()
        {
            InitializeComponent();
            this.lblVersion.Text = "@Copyright 2022 HindalcoiOS";
            this.Focus();
        }
        void setCurrentTab(int index)
        {
            //switch(bunifuPages1.SelectedIndex)
            //{
            //    case 0:
            //        indicator. = bunifuButton1.Right - bunifuButton1.Width;
            //        break;
            //}
        }

        //private void bunifuPages1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    setCurrentTab(LginTabCtrl.SelectedIndex);

        //}

        //private void bunifuButton1_Click(object sender, EventArgs e)
        //{
        //    LginTabCtrl.SelectedIndex = 0;
        //}

        //private void bunifuButton2_Click(object sender, EventArgs e)
        //{
        //    LginTabCtrl.SelectedIndex = 1;
        //    if (LginTabCtrl.SelectedTab.Tag.ToString() == "DB")
        //    {
        //        if (string.IsNullOrEmpty(txtDBName.Text))
        //        {
        //            ReadINIData();
        //        }
        //    }
        //}

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            //WriteIniFile();
            GlobalDeclaration.WriteIniFile(txtServerName.Text, txtUserName.Text, txtDBName.Text, txtPassword.Text);
            CADStatus = chckAutoCAD.Checked == true?true:false;
            
            IniFile.IniWriteValue(DBSection, "AutoCADStatus", CADStatus.ToString());
            GlobalDeclaration.ProjectIniFileUpdate(txtServerName.Text, txtUserName.Text, txtDBName.Text, txtPassword.Text, "", "", CADStatus.ToString(), "");
            if (!string.IsNullOrEmpty(txtPassword.Text) && !string.IsNullOrEmpty(txtUserName.Text))
            {
                Resources.Instance.UpdateConnectring(txtServerName.Text, txtDBName.Text, txtPassword.Text, txtUserName.Text);//Run time ConnectionString Change
            }
            else
            {
                Resources.Instance.UpdateConnectring(txtServerName.Text, txtDBName.Text, "", "");//Run time ConnectionString Change
            }
           // UpdateConfig("ConnectionString1", txtDBName.Text, txtServerName.Text, txtUserName.Text, txtPassword.Text);
        }
       
        public void ReadINIData()
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

                        txtServerName.Text = IniFile.IniReadValue(DBSection, "ServerName");
                        txtDBName.Text = IniFile.IniReadValue(DBSection, "DBName");
                        txtPassword.Text = IniFile.IniReadValue(DBSection, "Password");
                        txtUserName.Text = IniFile.IniReadValue(DBSection, "UserName");
                        if (!string.IsNullOrEmpty(IniFile.IniReadValue("DBConfig", "AutoCADStatus")))
                        {
                            chckAutoCAD.Checked = CADStatus = bool.Parse(IniFile.IniReadValue(DBSection, "AutoCADStatus"));
                        }
                        //if (!string.IsNullOrEmpty(IniFile.IniReadValue(FTPSectionName, "IPAddress")))
                        //{
                        //    TxtFTPAddress.Text = IniFile.IniReadValue(FTPSectionName, "IPAddress");
                        //    txtFTPFolder.Text = IniFile.IniReadValue(FTPSectionName, "FolderName");
                        //    txtFTPPassword.Text = IniFile.IniReadValue(FTPSectionName, "Password");
                        //    txtFtpUserName.Text = IniFile.IniReadValue(FTPSectionName, "UserName");
                        //    if (!string.IsNullOrEmpty(IniFile.IniReadValue(DBSection, "Server"))|| !string.IsNullOrEmpty(IniFile.IniReadValue(DBSection, "Local")))
                        //    {
                        //        chkserver.Checked = bool.Parse(IniFile.IniReadValue(DBSection, "Server"));
                        //        chklocal.Checked = bool.Parse(IniFile.IniReadValue(DBSection, "Local"));
                        //    }
                        //}
                        //else
                        //{
                        //    XtraMessageBox.Show("Your FTP Seeting Not Configured.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    return;
                        //}
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void WriteIniFile()
        //{
        //    try
        //    {
        //        string Path = string.Empty;
        //        Path = Application.StartupPath + @"\" + "AppSetting.ini";
        //        if (!File.Exists(Path))
        //        {
        //            Directory.CreateDirectory(Path);
        //        }
        //        IniFile.SetPath(Path);
        //        IniFile.IniWriteValue(DBSection, "ServerName", txtServerName.Text);
        //        IniFile.IniWriteValue(DBSection, "UserName", txtUserName.Text);
        //        IniFile.IniWriteValue(DBSection, "DBName", txtDBName.Text);
        //        IniFile.IniWriteValue(DBSection, "Password", txtPassword.Text);
        //        /// FTP Setting ------------
        //        //IniFile.IniWriteValue(FTPSectionName, "IPAddress", TxtFTPAddress.Text);
        //        //IniFile.IniWriteValue(FTPSectionName, "UserName", txtFtpUserName.Text);
        //        //IniFile.IniWriteValue(FTPSectionName, "FolderName", txtFTPFolder.Text);
        //        //IniFile.IniWriteValue(FTPSectionName, "Password", txtFTPPassword.Text);
        //        //IniFile.IniWriteValue(DBSection, "Local", chklocal.Checked.ToString());
        //        //IniFile.IniWriteValue(DBSection, "Server", chkserver.Checked.ToString());
        //        XtraMessageBox.Show("Information Saved Successfully.....", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    catch (Exception Ex)
        //    {
        //        XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LginTabCtrl_Click(object sender, EventArgs e)
        {
            //if (((DevExpress.XtraTab.XtraTabControl)sender).SelectedTabPage.Tag.ToString() == "DB")
                if (((SparrowRMSControl.SparrowControl.SparrowTabControl)sender).SelectedTab.Tag.ToString() == "DB")
                {
                if (string.IsNullOrEmpty(txtDBName.Text))
                {
                    ReadINIData();
                }
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
               
                ReadINIData();
                Regex rEmail = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
                if (!rEmail.IsMatch(txtEmail.Text.Trim()) ||
                    txtupwd.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Enter Correct Email-ID and Password.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail.Focus();
                    txtupwd.Focus();
                    return;
                }
                string ff = Resources.Instance.GetConnection;
                Resources.Instance.SP_AuthenticationLogin(txtEmail.Text, txtupwd.Text, ref ProjectName, ref DeptName, ref Result, ref RoleName, ref UserName, ref UserID, ref GeoLocation, ref EmpCode);
                // Resources.Instance.SP_AuthenticationLogin(txtEmail.Text, txtupwd.Text, ref ProjectName, ref DeptName, ref Result, ref RoleName, ref UserName, ref UserID);
               // XtraMessageBox.Show(Result.ToString(), ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (Result == "Logged In Successfully!")//Logged In Successfully
                {
                    holdUserInfo _strcu = new holdUserInfo();
                    GlobalDeclaration.UserName = _strcu.UserName = UserName;
                    _strcu.DepartmentName = DeptName;
                    _strcu.UserId = UserID;
                    _strcu.EmpCode = EmpCode;
                    _strcu.UserRole = _strcu.UserType = GlobalDeclaration.UserType = RoleName;
                    _strcu.ProjectName = ProjectName;
                    userid = UserID.ToString();
                    GlobalDeclaration._holdInfo.Add(_strcu);
                    int RoleId = 0;
                    Resources.Instance.GetMaxID("GetUserGuid", "p_RoleID", UserID, ref RoleId);
                    //foreach (DataRow dr in Resources.Instance.GetOperationUnit().Rows)
                    //{
                    //    //DataTable dttt=Resources.Instance.GetOperationUnit();
                    //    IList<String>_ilist=  new List<String>();
                    //    _ilist.Add(dr["OperationUnitName"].ToString());
                        HindalcoiOS.Properties.Settings.Default.OperationUnits= Resources.Instance.GetOperationUnit();// = Resources.Instance.GetOperationUnit();
                    //}
                    HindalcoiOS.Properties.Settings.Default.RoleID = RoleId;
                    //Store User Name temporary
                    HindalcoiOS.Properties.Settings.Default.UserLog = UserName;
                    HindalcoiOS.Properties.Settings.Default.Save();
                    //Store Email Id temporary
                    HindalcoiOS.Properties.Settings.Default.Email = txtEmail.Text;
                    HindalcoiOS.Properties.Settings.Default.Save();
                    // Store GeoLocation temporary
                    HindalcoiOS.Properties.Settings.Default.GeoLocation = GeoLocation;
                    HindalcoiOS.Properties.Settings.Default.Save();
                    HindalcoiOS.Properties.Settings.Default.Departments= Resources.Instance.GetDataKey("Sp_GetDeptMaster");
                    HindalcoiOS.Properties.Settings.Default.AllUsers = Resources.Instance.GetUserDetails_RMPCL(2);
                    // Load Finantial year list
                    GlobalDeclaration.FinancialYearGenerator();
                    if (GlobalDeclaration.FirstLogOut)
                    {
                        //var form=Application.OpenForms["Reporting"+"\"+IncidentReportUA"];
                        var form = new ParentWindow();
                        if (((HindalcoiOS.ParentWindow)form).OnAfterLogOut != null)
                            ((HindalcoiOS.ParentWindow)form).OnAfterLogOut.Invoke(sender, this.Name);
                        GlobalDeclaration.FirstLogOut = false;
                        this.Close();
                        form.Show();
                        ((HindalcoiOS.ParentWindow)form).OnAfterLogOut -= ((HindalcoiOS.ParentWindow)form).OnAfterLogOutReCall;
                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                        // this.Close();
                        //var form = new ParentWindow();
                        //form.Show();

                    }
                    //DialogResult = DialogResult.OK;
                }
                else
                {
                    XtraMessageBox.Show(Result.ToString(), ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                AuditHind.AuditHelper.GetUrlToken(txtupwd.Text);
                //Thread.Sleep(1000);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsNumber(string str)
        {
            int outvalue;
            bool value = int.TryParse(str, out outvalue);
            return value;
        }
        private void Txtuid_MouseDown(object sender, MouseEventArgs e)
        {
            // validateLogin();
        }
        private void txtupwd_KeyDown(object sender, KeyEventArgs e)
        {
            // validateLogin();
        }
        private void validateLogin()
        {
            //if (ApplicationType.SelectedText == "")
            //{
            //    lbltype.Visible = true;
            //    lbluid.Visible = false;
            //    lblupwd.Visible = false;
            //}

            //if (txtuid.Text == "")
            //{
            //    lbltype.Visible = false;
            //    lbluid.Visible = true;
            //    lblupwd.Visible = false;
            //}
            //if (txtupwd.Text == "")
            //{
            //    lbltype.Visible = false;
            //    lbluid.Visible = false;
            //    lblupwd.Visible = true;
            //}

        }

        private void ApplicationType_Properties_EditValueChanged(object sender, EventArgs e)
        {

        }

        //private void ApplicationType_SelectedIndexChanged(object sender, EventArgs e)
        //{          
        //    try
        //    {
        //        DataRow[] Dr = dataTable.Select("UType='" + ApplicationType.SelectedText.Trim() + "'");
        //        if (Dr.Length > 0)
        //        {            
        //            appid = int.Parse(Dr[0]["UTypeId"].ToString());
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void btnforget_Click(object sender, EventArgs e)
        {
            frmRecoverPassword recpass = new frmRecoverPassword();
            recpass.TopMost = true;
            recpass.Focus();
            //recpass.GetValue += ItemMasterHandlerEvent;
            if (recpass.ShowDialog() == DialogResult.OK)
            {
                recpass.Close();
                recpass.Dispose();
            }
            //recpass.Show();
        }

        private void LoginPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GlobalDeclaration.FirstLogOut)
            {
                Application.Exit();
            }
        }
        
        private void FindVersion()
        {
            try
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                string version = fvi.FileVersion;
                string Name = fvi.ProductVersion;
                lblVersion.Text = lblVersion.Text + " -Version " + " " + Name;
                lblVersion.BackColor = Color.WhiteSmoke;
                //ThreadPool.QueueUserWorkItem(new WaitCallback(CreateFolder));
                // CreateFolder(null);
                ////Task.Factory.StartNew(() => CreateFolder(null));
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginPanel_Load(object sender, EventArgs e)
        {
            //FindVersion();
            HideLoginPagesHeader();
        }
        
        private void CreateFolder(object obj)
        {
            try
            {
                string IniPath = Application.StartupPath + @"\" + "AppSetting.ini";
                string Path = @"C:\Users\Public\Documents\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                if (string.IsNullOrEmpty(IniFile.IniReadValue("DBConfig", "FolderPath")))
                    IniFile.IniWriteValue("DBConfig", "FolderPath", Path);
                string SourcePath = Application.StartupPath + @"\Images";
                if (!File.Exists(IniPath))
                {
                    //Directory.CreateDirectory(Path);
                    File.Create(Path);
                }
                IniFile.SetPath(IniPath);
                if (!Directory.Exists(Path))
                {
                    Directory.CreateDirectory(Path);
                    DirectoryInfo di = new DirectoryInfo(Path);
                    if (di.Exists == true)
                    {
                        DirectoryInfo dis = di.CreateSubdirectory("Images");
                        DirectoryInfo AppDic = di.CreateSubdirectory("Application_Machines");
                        DirectoryInfo dir = new DirectoryInfo(SourcePath);
                        DirectoryInfo[] dirs = dir.GetDirectories();
                        foreach (string dirPath in Directory.GetDirectories(SourcePath, "*", SearchOption.AllDirectories))
                        {
                            Directory.CreateDirectory(dirPath.Replace(SourcePath, dis.FullName));
                        }
                        foreach (string newPath in Directory.GetFiles(SourcePath, "*.*", SearchOption.AllDirectories))
                        {
                            File.Copy(newPath, newPath.Replace(SourcePath, dis.FullName), true);
                        }
                    }
                }

            }
            catch (IOException Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void chckAutoCAD_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox.Checked)
            {
                CADStatus = true;
            }
            else
            {
                CADStatus = false;
            }
        }

        private void LginTabCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LginTabCtrl.SelectedTab.Tag.ToString() == "DB")
            {
                if (string.IsNullOrEmpty(txtDBName.Text))
                {
                    ReadINIData();
                }
            }
        }
        private void HideLoginPagesHeader()
        {
            LginTabCtrl.Appearance = TabAppearance.FlatButtons;
            LginTabCtrl.ItemSize = new Size(0, 1);
            LginTabCtrl.SizeMode = TabSizeMode.Fixed;

            foreach (TabPage tab in LginTabCtrl.TabPages)
            {
                tab.Hide();// = "";
            }
        }

        private void btnTabLogin_Click(object sender, EventArgs e)
        {
            LginTabCtrl.SelectedIndex = 0;
        }

        private void btnDataConfig_Click(object sender, EventArgs e)
        {
            LginTabCtrl.SelectedIndex = 1;
        }
    }
}
