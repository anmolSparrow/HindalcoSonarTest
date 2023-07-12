using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using HindalcoiOS.Form_Collection;
using System.Threading;
using System.Drawing;
using HindalcoiOS.Machine_Edit_Form;
using HindalcoiOS.Safety_Form_list;
using HindalcoiOS.Class_Operation;
using HindalcoiOS.Dynamic_Form;
using HindalcoiOS.Connector_FRM;
using HindalcoiOS.Login_Form;

namespace HindalcoiOS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            SetProcessDPIAware();
            // DevExpress.Skins.SkinManager.EnableFormSkins();
            //WindowsFormsSettings.DefaultLookAndFeel.SkinMaskColor = Color.Blue; //DefaultRibbonControlStyle.Office2019;
            //UserLookAndFeel.Default.SetSkinStyle("DevExpress Light Style");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BonusSkins.Register();

            string sese = GlobalDeclaration.appGuid;
            //Application.Run(new MaintenanceFrm("",""));
            //string abc = @"SparrowRMS\HindalcoiOS\Protection";
            //TempLicencing.Licenseactivator scr = new TempLicencing.Licenseactivator();
            //System.Configuration.AppSettingsReader settingsReader = new System.Configuration.AppSettingsReader();
            //string key = (string)settingsReader.GetValue("CadKey", typeof(string));
            //bool logic = scr.Algorithm(key, abc);
            //if (logic== true)
            {
                Mutex mutex = new Mutex(false, GlobalDeclaration.appGuid);
                if (!mutex.WaitOne(0, false))
                {
                    XtraMessageBox.Show("Application already running", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                GC.Collect();
                SplashScreenManager.ShowForm((Form)null, typeof(Plant360SplaceScreen), true, true);
                for (int i = 1; i <= 100; i++)
                {
                    SplashScreenManager.Default.SendCommand(Plant360SplaceScreen.SplashScreenCommand.SetProgress, i);
                    Thread.Sleep(25);
                }
                SplashScreenManager.CloseForm(false);
                if (!GlobalDeclaration.DBCheck())
                {
                    try
                    {
                        using (frmRegistration reg = new frmRegistration())
                        {
                            reg.CallFrmName = "New";
                            reg.IsFirstCall = true;
                            if (reg.ShowDialog() == DialogResult.OK)
                            {
                                reg.Close();
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                    catch (Exception Ex)
                    {
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                using (LoginPanel fLogin = new LoginPanel())
                {
                    fLogin.TopMost = true;
                    //fLogin.Focus();
                    if (fLogin.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            Application.Run(new ParentWindow());
                        }
                        catch (Exception Ex)
                        {
                            XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        Application.Exit();
                    }
                } 
            }
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public extern static IntPtr SetProcessDPIAware();
    }
}
