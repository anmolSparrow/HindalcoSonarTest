using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System.IO;
using SparrowRMS;
using HindalcoiOS.Class_Operation;
using System.Diagnostics;
using System.Threading;
using System.Data.SqlClient;

namespace HindalcoiOS.Form_Collection
{
    public partial class Plant360SplaceScreen : SplashScreen
    {                
        public Plant360SplaceScreen()
        {
            InitializeComponent();
            
        }
        #region Overrides
        int value = 0;
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
            SplashScreenCommand command = (SplashScreenCommand)cmd;
            if (command == SplashScreenCommand.SetProgress)
            {
                 value = (int)arg;                
               progressBarControl1.Position = value;
               // this.Close();
            }
        }

        #endregion
        public enum SplashScreenCommand
        {
            SetProgress,
            Command2,
            Command3
        }

        private void Plant360SplaceScreen_Shown(object sender, EventArgs e)
        {
            //Login loginfrm = new Login();
            //loginfrm.ShowDialog();
            //if (loginfrm.DialogResult == DialogResult.OK)
            //{
            //    loginfrm.Close();
            //}
          // this.Close();
          //  this.Dispose();
        }

        private void Plant360SplaceScreen_Load(object sender, EventArgs e)
        {

            // timer1.Enabled = true;
            // timer1.Start();
            //timer1.Interval = 1000;
            //this.SplashScreenCommand.SetProgress=
            //timer1.Tick += new EventHandler(timer1_Tick);
            FindVersion();
            ReadIniSetting();           
        }
        private void FindVersion()
        {
            try
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                string version = fvi.FileVersion;
                string Name = fvi.ProductVersion;
                labelControl1.Text =string.Format("{0} - Version {1}", labelControl1.Text,Name);
                labelControl1.BackColor = Color.WhiteSmoke;
                //ThreadPool.QueueUserWorkItem(new WaitCallback(CreateFolder));
                // CreateFolder(null);
                Task.Factory.StartNew(() => CreateFolder(null));
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true,StartPosition=FormStartPosition.CenterScreen },Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         
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
                    // loginBL.connect(Resources.Instance.connectionsstring);
                }
            }
        }
        private void CreateFolder(object obj)
        {
            try
            {
                string IniPath = Application.StartupPath + @"\" + "AppSetting.ini";
                string Path = @"C:\Users\Public\Documents\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                if (string.IsNullOrEmpty(IniFile.IniReadValue("DBConfig", "FolderPath")))
                {
                    IniFile.IniWriteValue("DBConfig", "FolderPath", Path);
                    GlobalDeclaration.ProjectIniFileUpdate("", "", "", "", Path, "", "", "");
                }
                string SourcePath = Application.StartupPath + @"\Images";
                string ApplicationPath = Application.StartupPath + @"\Application_Machines";
                string KeyComponentData = Application.StartupPath + @"\KeyComponentData";
                string MCD_FileUploads = Application.StartupPath + @"\MCD_FileUploads";
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
                        DirectoryInfo _KeyComponentData = di.CreateSubdirectory("KeyComponentData");
                        DirectoryInfo _MCD_FileUploads = di.CreateSubdirectory("MCD_FileUploads");
                        DirectoryInfo CadFolder = di.CreateSubdirectory("SparrowCAD");
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
                        foreach (string newPath in Directory.GetFiles(ApplicationPath, "*.*", SearchOption.AllDirectories))
                        {
                            File.Copy(newPath, newPath.Replace(ApplicationPath, AppDic.FullName), true);
                        }
                        foreach (string dirPath in Directory.GetDirectories(KeyComponentData, "*", SearchOption.AllDirectories))
                        {
                            Directory.CreateDirectory(dirPath.Replace(KeyComponentData, _KeyComponentData.FullName));
                        }
                        foreach (string newPath in Directory.GetFiles(KeyComponentData, "*.*", SearchOption.AllDirectories))
                        {
                            File.Copy(newPath, newPath.Replace(KeyComponentData, _KeyComponentData.FullName), true);
                        }
                        foreach (string dirPath in Directory.GetDirectories(MCD_FileUploads, "*", SearchOption.AllDirectories))
                        {
                            Directory.CreateDirectory(dirPath.Replace(MCD_FileUploads, _MCD_FileUploads.FullName));
                        }
                        foreach (string newPath in Directory.GetFiles(MCD_FileUploads, "*.*", SearchOption.AllDirectories))
                        {
                            File.Copy(newPath, newPath.Replace(MCD_FileUploads, _MCD_FileUploads.FullName), true);
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
        public void timer1_Tick(object sender, EventArgs e)
        {
            //if (progressBarControl1.Value != 10)
            //{
            //    progressBarControl1.Value++;
            //}
            //else
            //{
            //    timer1.Stop();
            //    Application.Exit();
            //}
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }
    }
}