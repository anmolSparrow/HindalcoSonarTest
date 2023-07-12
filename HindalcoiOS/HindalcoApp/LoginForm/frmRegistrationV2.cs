using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using HindalcoiOS.Form_Collection;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS
{
    public partial class frmRegistration : XtraForm
    {
        public string result;
        public string CallFrmName = string.Empty;
        public bool IsFirstCall = false;
        public frmRegistration()
        {
            InitializeComponent();
        }
        public frmRegistration(string callingfrm)
        {
            CallFrmName = callingfrm;
        }
        public bool IsUniqueEmpId(string userName)
        {
            int idchk = 0;
            Resources.Instance.GetUniqueSrNo("SP_CheckUniqueUserName", "p_UserName", userName, ref idchk);
            if (idchk == 1)
            {
                return true;
            }
            // true if unique
            return false;
        }
        private void BtnRegistration_Click(object sender, EventArgs e)
        {
            int Staus = 0;
            //Insert Registration details in database
            //Validating Input values
            Regex rEmail = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (!rEmail.IsMatch(txtEmail.Text.Trim()) ||
                txtUserName.Text.Trim() == "" ||
                txtPassword.Text.Trim() == "" ||
                // cobRole.SelectedValue.ToString() == "" ||
                cobQuestion.Text.Trim() == "" ||
                txtUserID.Text.Trim() == "" ||
                txtnumber.Text == "" ||
                txtGeolocation.Text == "" ||
                txtAnswer.Text.Trim() == "")
            {
                XtraMessageBox.Show("Fill all the information or Check Email address");
            }
            else
            {
                // accessing spRegister stored procedure and return result
                if (chkemp.Checked)
                {
                    int DeptID = Convert.ToInt32(combDeparment.SelectedValue.ToString());
                    Frm_GlobalEmloyeeHierarchy frm = new Frm_GlobalEmloyeeHierarchy();
                    frm.DepartmentID = DeptID;
                    frm.txtdepartment.Text = combDeparment.Text;
                    frm.txtemail.Text = txtEmail.Text;
                    frm.txtempname.Text = txtUserName.Text;
                    frm.txtmobno.Text = txtnumber.Text;
                    frm.txtGeoLocation.Text = txtGeolocation.Text;
                    frm.txtemplcode.Text = string.Concat("Emp", txtUserID.Text);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        string empCode = frm.txtemplcode.Text;
                        frm.Close();
                        Staus = Resources.Instance.spRegister(txtUserName.Text, Convert.ToInt32(txtUserID.Text), GlobalDeclaration._holdInfo[0].ProjectName, Convert.ToDouble(txtnumber.Text), txtPassword.Text, txtEmail.Text, Convert.ToInt32(cobRole.SelectedValue.ToString()), DeptID, cobQuestion.Text, txtAnswer.Text, "", txtGeolocation.Text, empCode, ref result);
                        if (Staus < 0)
                        {
                            // Result shown in Meassage Box
                            MessageBox.Show(result, ApplicationConstants.MessageDisplay,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RightAlign);
                            txtAnswer.Text = "";
                            txtEmail.Text = "";
                            txtPassword.Text = "";
                            txtProjectName.Text = "";
                            txtUserName.Text = "";
                            txtGeolocation.Text = "";
                            this.Close();
                            //GlobalDeclaration.WriteIniFile("", "", txtProjectName.Text, "");
                        }
                        else
                        {
                            DialogResult = DialogResult.None;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    try
                    {
                        if (IsFirstCall)
                        {
                            ReturnStatus();
                        }
                        else
                        {
                            Staus = Resources.Instance.spRegister(txtUserName.Text, Convert.ToInt32(txtUserID.Text), GlobalDeclaration._holdInfo[0].ProjectName, Convert.ToDouble(txtnumber.Text), txtPassword.Text, txtEmail.Text, Convert.ToInt32(cobRole.SelectedValue.ToString()), Convert.ToInt32(combDeparment.SelectedValue.ToString()), cobQuestion.Text, txtAnswer.Text, "", txtGeolocation.Text, "", ref result);
                        }
                        if (Staus < 0)
                        {
                            // Result shown in Meassage Box
                            MessageBox.Show(result, ApplicationConstants.MessageDisplay,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RightAlign);
                            txtAnswer.Text = "";
                            txtEmail.Text = "";
                            txtPassword.Text = "";
                            txtProjectName.Text = "";
                            txtUserName.Text = "";
                            txtGeolocation.Text = "";
                            this.Close();
                            //GlobalDeclaration.WriteIniFile("", "", txtProjectName.Text, "");
                        }
                        else
                        {
                            DialogResult = DialogResult.None;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ApplicationConstants.MessageDisplay,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign);
                    }
                }
                if (string.IsNullOrEmpty(HindalcoiOS.Properties.Settings.Default.GeoLocation))
                {
                    HindalcoiOS.Properties.Settings.Default.GeoLocation = txtGeolocation.Text;
                }
            }
        }
        private int GetMaxID()
        {
            int docn = 0;
            Random _UserID = new Random();
            return _UserID.Next(101, 120);
            //object count = null;
            //Resources.Instance.GetMaxID("SP_GetMaxID", "@MaxID", ref docn);
            //return docn + 1;
        }
        private void ReturnStatus()
        {

            if (!string.IsNullOrEmpty(IniFile.IniReadValue("DBConfig", "ServerName")))
            {
                string servername = IniFile.IniReadValue("DBConfig", "ServerName");
                //txtDBName.Text = IniFile.IniReadValue("DBConfig", "DBName");
                string password = IniFile.IniReadValue("DBConfig", "Password");
                string UserName = IniFile.IniReadValue("DBConfig", "UserName");
                // = IniFile.IniReadValue("DBConfig", "FolderPath");
                string ScriptPath = string.Concat(IniFile.IniReadValue("DBConfig", "FolderPath"), "\\Images\\");
                var list = Directory.GetFiles(ScriptPath, "*.sql*", SearchOption.AllDirectories).ToList().FirstOrDefault();
                string[] s = (list.ToString()).Split('\\');
                int count = s.Length;
                string Filename = s[count - 1].Split('.')[0];
                using (System.Diagnostics.Process myProcess = new System.Diagnostics.Process())
                {
                    try
                    {

                        myProcess.StartInfo.FileName = Application.StartupPath + "\\DynamicSqlCreation.exe";
                        myProcess.StartInfo.WorkingDirectory = Application.StartupPath;
                        myProcess.StartInfo.Verb = "runs";
                        myProcess.StartInfo.UseShellExecute = false;
                        myProcess.StartInfo.RedirectStandardOutput = true;
                        myProcess.StartInfo.RedirectStandardInput = true;
                        myProcess.StartInfo.RedirectStandardError = true;
                        myProcess.StartInfo.CreateNoWindow = true;
                        myProcess.EnableRaisingEvents = true;
                        myProcess.StartInfo.ErrorDialog = true;
                        myProcess.StartInfo.LoadUserProfile = true;
                        if (string.IsNullOrEmpty(password) && string.IsNullOrEmpty(UserName))
                        {
                            UserName = "TS";
                            password = "TS";
                        }
                        myProcess.StartInfo.Arguments = servername + " " + txtProjectName.Text + " " + UserName + " " + password + " " + ScriptPath;
                        myProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        myProcess.OutputDataReceived += MyProcess_OutputDataReceived;
                        myProcess.EnableRaisingEvents = true;
                        ParentWindow.Log.Info("External .EXE Running....");
                        myProcess.Start();
                        myProcess.BeginOutputReadLine();
                        myProcess.BeginErrorReadLine();
                        ParentWindow.Log.Info("External .EXE Execution Completed.");
                    }
                    catch (Exception Ex)
                    {
                        ParentWindow.Log.Error("External Exe Process Error " + Ex.Message);
                        MessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK,
               MessageBoxIcon.Information,
               MessageBoxDefaultButton.Button1,
               MessageBoxOptions.RightAlign);
                    }
                    finally
                    {
                        //myProcess.Kill();
                        // myProcess.Close();
                        // ParentWindow.Log.Info("External Exe Process Closed ");
                    }
                }
            }
        }
        readonly object lockObject = new object();
        private void MyProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            // myProcess.OutputDataReceived += (sender, args) =>
            // Console.WriteLine("received output: {0}", e.Data);
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        this.rtxtRegistration.AppendText(e.Data + Environment.NewLine);
                        if (e.Data == "Project Creation Done")
                        {
                            DataInsertion();
                        }
                    }));
                }
            }
            catch (Exception Ex)
            {
                ParentWindow.Log.Error("External Exe Aurguments Error " + Ex.Message);
                MessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);
            }
            // richTextBox1.Text = richTextBox1.Text+ "\n"+ e.Data;
        }
        private void DataInsertion()
        {
            try
            {
                ParentWindow.Log.Info("IndustryOS Default User Creation" + DateTime.Now);
                rtxtRegistration.SelectionStart = rtxtRegistration.Text.Length;
                rtxtRegistration.ScrollToCaret();
                Resources.Instance.UpdateConnectring(Resources.Instance.ServerName, txtProjectName.Text, Resources.Instance.DbPassword, Resources.Instance.DbUserName);//Temp Check
                int Staus = Resources.Instance.spRegister(txtUserName.Text, Convert.ToInt32(txtUserID.Text), txtProjectName.Text, Convert.ToDouble(txtnumber.Text), txtPassword.Text, txtEmail.Text, 1, 7, cobQuestion.Text, txtAnswer.Text, "First", txtGeolocation.Text, "", ref result);
                if (Staus < 0)
                {
                    // Result shown in Meassage Box
                    MessageBox.Show(result, "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);
                    GlobalDeclaration.WriteIniFile(Resources.Instance.ServerName, Resources.Instance.DbUserName, txtProjectName.Text, Resources.Instance.DbPassword);
                    GlobalDeclaration.ProjectIniFileUpdate(Resources.Instance.ServerName, Resources.Instance.DbUserName, txtProjectName.Text, Resources.Instance.DbPassword, "", "", "", "");
                    DialogResult = DialogResult.OK;
                    ParentWindow.Log.Info("IndustryOS Default User Created" + DateTime.Now);
                }
                else
                {
                    DialogResult = DialogResult.None;
                }
            }
            catch (Exception Ex)
            {
                ParentWindow.Log.Error(" IndustryOS Default User Creation Error" + Ex.Message);
                MessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK,
                  MessageBoxIcon.Information,
                  MessageBoxDefaultButton.Button1,
                  MessageBoxOptions.RightAlign);
            }
        }
        private void Registration_Load(object sender, EventArgs e)
        {
            try
            {
                if (CallFrmName == "New")
                {
                    cobRole.Visible = false;
                    lblRole.Visible = false;
                    combDeparment.Visible = false;
                    lblDepartment.Visible = false;
                    label5.Location = lblDepartment.Location;
                    cobQuestion.Location = combDeparment.Location;
                    lblAnswer.Location = lblRole.Location;
                    txtAnswer.Location = cobRole.Location;
                    txtGeolocation.Location = new System.Drawing.Point(177, 392);
                    lblGeoLocation.Location = new System.Drawing.Point(45, 396);
                    // this.groupBox1.Location = new System.Drawing.Point(470, 429);
                    txtUserID.Text = GetMaxID().ToString();
                    //if (!IsFirstCall)
                    //{
                    //    DataTable rolDf = Resources.Instance.GetDataKey("Sp_GetRoles");
                    //    if (rolDf.Rows.Count > 0)
                    //    {
                    //        cobRole.Items.Clear();
                    //        cobRole.DataSource = rolDf;
                    //        cobRole.DisplayMember = "RoleName";
                    //        cobRole.ValueMember = "RoleID";
                    //        cobRole.SelectedValue = "";
                    //    }
                    //}
                }
                else
                {
                    lblUserName.Location = lblProjectName.Location;//lblusername
                    txtUserName.Location = txtProjectName.Location;//txtusername
                    lblUserID.Location = new System.Drawing.Point(45, 91);//labelUserID
                    txtUserID.Location = new System.Drawing.Point(177, 89);//txtUserID
                    lblPassword.Location = new System.Drawing.Point(45, 136);//labpassword
                    txtPassword.Location = new System.Drawing.Point(177, 134);//txtpassword
                    lblEmail.Location = new System.Drawing.Point(45, 179);//labeemail
                    txtEmail.Location = new System.Drawing.Point(177, 177);//txtemail
                    lblPhoneNumber.Location = new System.Drawing.Point(45, 221);//labelphoneno
                    txtnumber.Location = new System.Drawing.Point(177, 219);//txtphonenumber
                    lblDepartment.Location = new System.Drawing.Point(45, 261);//labeldepartment
                    combDeparment.Location = new System.Drawing.Point(177, 259);//comdepartment
                    lblRole.Location = new System.Drawing.Point(45, 302);//labelrole
                    cobRole.Location = new System.Drawing.Point(177, 299);//combrole
                    label5.Location = new System.Drawing.Point(45, 351);
                    cobQuestion.Location = new System.Drawing.Point(177, 348);
                    lblAnswer.Location = new System.Drawing.Point(45, 396);
                    txtAnswer.Location = new System.Drawing.Point(177, 392);
                    lblGeoLocation.Location = new System.Drawing.Point(45, 441);
                    txtGeolocation.Location = new System.Drawing.Point(177, 436);
                    chkemp.Location= new System.Drawing.Point(397, 513);
                    lblIsEmp.Location= new System.Drawing.Point(426, 515);
                    lblProjectName.Visible = false;
                    txtProjectName.Visible = false;
                    cobRole.Visible = true;
                    groupBox2.Visible = false;
                    this.Size = new System.Drawing.Size(610, 739);
                    txtGeolocation.Text = HindalcoiOS.Properties.Settings.Default.GeoLocation;
                    //txtGeolocation.ReadOnly = true;
                    chkemp.Visible = true;

                }
                if (!IsFirstCall)
                {
                    DataTable rolDT = Resources.Instance.GetDataKey("Sp_GetDeptMaster");
                    if (rolDT.Rows.Count > 0)
                    {
                        //combDeparment.Items.Clear();
                        combDeparment.DataSource = rolDT;
                        combDeparment.DisplayMember = "DepartName";
                        combDeparment.ValueMember = "DeptId";
                        //foreach (DataRow dr in rolDT.Rows)
                        //{
                        //    combDeparment.Items.Add(dr["DepartName"].ToString());
                        //}
                    }
                    DataTable rolDf = Resources.Instance.GetDataKey("Sp_GetRoles");
                    if (rolDf.Rows.Count > 0)
                    {
                        //cobRole.Items.Clear();
                        cobRole.DataSource = rolDf;
                        cobRole.DisplayMember = "RoleName";
                        cobRole.ValueMember = "RoleID";
                    }
                    int MaxId = 0;
                    Resources.Instance.GetMaxID("SP_GetMaxID", "p_MaxID", ref MaxId);
                    txtUserID.Text = (++MaxId).ToString();
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);
            }
        }

        private void txtnumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }

        private void chkemp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkemp.Checked)
            {
                btnRegistration.Text = "&Go To Employee";
                btnRegistration.Size = new System.Drawing.Size(146, 36);
                btnRegistration.Location = new System.Drawing.Point(227, 563);
            }
            else
            {
                btnRegistration.Text = "&Registor";
                btnRegistration.Size = new System.Drawing.Size(89, 36);
                btnRegistration.Location = new System.Drawing.Point(394, 562);
            }
        }   
    }
}
