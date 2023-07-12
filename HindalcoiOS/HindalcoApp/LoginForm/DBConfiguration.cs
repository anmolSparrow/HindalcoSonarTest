using HindalcoiOS.Class_Operation;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SparrowRMS;
using System.Configuration;

namespace HindalcoiOS.Login_Form
{
    public partial class DBConfiguration : DevExpress.XtraEditors.XtraForm
    {
        public const string FTPSectionName = "FTPConfiguration";
        public const string DBSection = "DBConfig";
        public  bool CADStatus = false;
       // public const string AppSetting = "ApplicationInfo";
        public DBConfiguration()
        {
            InitializeComponent();
        }
        private void DBConfiguration_Load(object sender, EventArgs e)
        {
           // chklocal.Checked = true;
            //chklocal.Enabled = false;
            ReadINIData();
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            WriteIniFile();
            DialogResult = DialogResult.OK;
        }

        private void UpdateConfig(string key, string value, string fileName)
        {
            var configFile = ConfigurationManager.AppSettings;
            //configFile.AppSettings.Settings[key].Value = value;
            //configFile.Save();
        }
        private void WriteIniFile()
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
                IniFile.IniWriteValue(DBSection, "ServerName", txtServerName.Text);
                IniFile.IniWriteValue(DBSection, "UserName", txtUserName.Text);
                IniFile.IniWriteValue(DBSection, "DBName", txtDBName.Text);
                IniFile.IniWriteValue(DBSection, "Password", txtPassword.Text);
                IniFile.IniWriteValue(DBSection, "DummyDB", txtDBName.Text);
                IniFile.IniWriteValue(DBSection, "AutoCADStatus", CADStatus.ToString());
                if (!string.IsNullOrEmpty(txtPassword.Text)&&!string.IsNullOrEmpty(txtUserName.Text))
                {
                    Resources.Instance.UpdateConnectring(txtServerName.Text, txtDBName.Text, txtPassword.Text, txtUserName.Text);//Run time ConnectionString Change
                    GlobalDeclaration.ProjectIniFileUpdate(txtServerName.Text, txtUserName.Text, txtDBName.Text, txtPassword.Text, "", "", CADStatus.ToString(), "");
                    UpdateConfig("ConnectionString1", txtDBName.Text, "");
                }
                else
                {
                    Resources.Instance.UpdateConnectring(txtServerName.Text, txtDBName.Text, "","");//Run time ConnectionString Change
                }                
                XtraMessageBox.Show("Information Saved Successfully.....", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private  void ReadINIData()
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
                        if (!string.IsNullOrEmpty(IniFile.IniReadValue("DBConfig", "ServerName")))
                        {
                            Resources.Instance.UpdateConnectring(txtServerName.Text, txtDBName.Text, txtPassword.Text, txtUserName.Text);

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
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void ReadIniSetting()
        {
            string text = System.IO.Path.GetFullPath("AppSetting.ini");
            if (File.Exists(text))
            {
                IniFile.SetPath(text);
                if (!string.IsNullOrEmpty(IniFile.IniReadValue("DBConfig", "ServerName")))
                {
                    Resources.Instance.UpdateConnectring(IniFile.IniReadValue("DBConfig", "ServerName"), IniFile.IniReadValue("DBConfig", "DBName"), IniFile.IniReadValue("DBConfig", "Password"), IniFile.IniReadValue("DBConfig", "UserName"));

                }
                //else if(!string.IsNullOrEmpty(IniFile.IniReadValue("FolderConfig", "FTPServer")))
                //{

                //}

            }
        }

        private void chkserver_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void chkserver_CheckStateChanged(object sender, EventArgs e)
        {
            //if (chkserver.Checked)
            //{
            //    if (chklocal.Checked)
            //        chklocal.Checked = false;
            //}

        }

        private void chklocal_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void chklocal_CheckStateChanged(object sender, EventArgs e)
        {
            //if (chklocal.Checked)
            //{
            //    if(chkserver.Checked)
            //        chkserver.Checked = false;
            //}
                
        }

        private void chckAutoCAD_CheckedChanged(object sender, EventArgs e)
        {
            if(chckAutoCAD.Checked)
            {
                CADStatus = true;
            }
            else
            {
                CADStatus = false;
            }
            
        }
    }
}
