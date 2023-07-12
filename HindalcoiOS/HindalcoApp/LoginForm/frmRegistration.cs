using System;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DevExpress.XtraEditors;
using System.Data;
using RMPCLApp.Class_Operation;
using System.Diagnostics;
using System.Threading;
using SparrowRMS;
using RMPCLApp.Form_Collection;
using System.IO;

namespace RMPCLApp
{
    public partial class frmRegistration : XtraForm
    {
        // Declare Result variable as string
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
                    frm.txtemplcode.Text= string.Concat("Emp", txtUserID.Text);
                    if (frm.ShowDialog() == DialogResult.OK)                    
                    {
                        string empCode = frm.txtemplcode.Text;
                        frm.Close();
                        XtraMessageBox.Show(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12}",txtUserName.Text, Convert.ToInt32(txtUserID.Text), GlobalDeclaration._holdInfo[0].ProjectName, Convert.ToDouble(txtnumber.Text), txtPassword.Text, txtEmail.Text, Convert.ToInt32(cobRole.SelectedValue.ToString()), DeptID, cobQuestion.Text, txtAnswer.Text, "", txtGeolocation.Text, empCode));
                        Staus = Resources.Instance.spRegister(txtUserName.Text, Convert.ToInt32(txtUserID.Text), GlobalDeclaration._holdInfo[0].ProjectName, Convert.ToDouble(txtnumber.Text), txtPassword.Text, txtEmail.Text, Convert.ToInt32(cobRole.SelectedValue.ToString()), DeptID, cobQuestion.Text, txtAnswer.Text, "", txtGeolocation.Text, empCode,ref result);
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
                            //XtraMessageBox.Show(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12}", txtUserName.Text, Convert.ToInt32(txtUserID.Text), GlobalDeclaration._holdInfo[0].ProjectName, Convert.ToDouble(txtnumber.Text), txtPassword.Text, txtEmail.Text, Convert.ToInt32(cobRole.SelectedValue.ToString()), DeptID, cobQuestion.Text, txtAnswer.Text, "", txtGeolocation.Text, empCode));
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
                RMPCLApp.Properties.Settings.Default.GeoLocation = txtGeolocation.Text;
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
                string ScriptPath= IniFile.IniReadValue("DBConfig", "FolderPath");
                ScriptPath= ScriptPath+ @"\Images\ProjectScriptRMPCL.sql";
                if (Directory.Exists(ScriptPath))
                {
                    ScriptPath = ScriptPath + @"\Images\ProjectScriptRMPCL.sql";
                }
                else
                {
                    ScriptPath = Application.StartupPath + @"\Images\ProjectScriptRMPCL.sql";
                }
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
                        myProcess.StartInfo.Arguments = servername + " " + txtProjectName.Text + " " + UserName + " " + password+" "+ ScriptPath;
                        myProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        myProcess.OutputDataReceived += MyProcess_OutputDataReceived;
                        myProcess.EnableRaisingEvents = true;                       
                        myProcess.Start();
                        myProcess.BeginOutputReadLine();
                        myProcess.BeginErrorReadLine();
                       // var processExited = myProcess.WaitForExit(40000);
                        //if (processExited == false) // we timed out...
                        //{
                        //    myProcess.Kill();
                        //}
                        //else
                        //{

                        //}
                        //while (!myProcess.StandardOutput.EndOfStream)-
                        //{
                        // Console.WriteLine(output);
                        //    //richTextBox1.Text = richTextBox1.Text+ "\n"+myProcess.StandardOutput.ReadLine();
                        //}                                              
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK,
               MessageBoxIcon.Information,
               MessageBoxDefaultButton.Button1,
               MessageBoxOptions.RightAlign);
                    }
                    finally
                    {
                        //myProcess.Kill();
                        myProcess.Close();                        
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
                    this.Invoke(new MethodInvoker(
                        new Action(() =>
                        this.richTextBox1.AppendText(e.Data + Environment.NewLine)                          
                        )));                  
                    if (e.Data == "Project Creation Done...")
                    {
                        this.Invoke(new MethodInvoker(
                         new Action(() =>
                         DataInsertion()
                         )));
                    }
                }
                else
                {
                    this.richTextBox1.AppendText(e.Data + Environment.NewLine);
                }
            }
            catch (Exception Ex)
            {
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
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();               
                Resources.Instance.UpdateConnectring(Resources.Instance.ServerName, txtProjectName.Text, Resources.Instance.DbPassword, Resources.Instance.DbUserName);//Temp Check
             
                int Staus = Resources.Instance.spRegister(txtUserName.Text, Convert.ToInt32(txtUserID.Text), txtProjectName.Text, Convert.ToDouble(txtnumber.Text), txtPassword.Text, txtEmail.Text, 1, 7, cobQuestion.Text, txtAnswer.Text,"First",txtGeolocation.Text, "",ref result);
                if (Staus < 0)
                {
                    // Result shown in Meassage Box
                    MessageBox.Show(result, "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);
                    DialogResult = DialogResult.OK;
                    GlobalDeclaration.WriteIniFile(Resources.Instance.ServerName, Resources.Instance.DbUserName, txtProjectName.Text, Resources.Instance.DbPassword);
                }
                else
                {
                    DialogResult = DialogResult.None;
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
        private void Registration_Load(object sender, EventArgs e)
        {
            try
            {               
                if (CallFrmName == "New")
                {
                    cobRole.Visible = false;
                    label4.Visible = false;
                    combDeparment.Visible = false;
                    label9.Visible = false;

                    label6.Location = label4.Location;
                    txtAnswer.Location = cobRole.Location;

                    label5.Location = label9.Location;
                    cobQuestion.Location = combDeparment.Location;

                   
                    txtGeolocation.Location = new System.Drawing.Point(128, 384);
                    lblGeoLocation.Location = new System.Drawing.Point(12, 390);
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
                    label1.Location = label7.Location;//lblusername
                    txtUserName.Location = txtProjectName.Location;//txtusername
                    label8.Location = new System.Drawing.Point(12, 132);//labelUserID
                    txtUserID.Location = new System.Drawing.Point(128, 128);//txtUserID

                    label2.Location = new System.Drawing.Point(12, 174);//labpassword
                    txtPassword.Location = new System.Drawing.Point(128, 170);//txtpassword

                    label3.Location = new System.Drawing.Point(12, 216);//labeemail
                    txtEmail.Location = new System.Drawing.Point(128, 170);//txtemail


                    lblPhoneNumber.Location = new System.Drawing.Point(12, 258);//labelphoneno
                    txtnumber.Location = new System.Drawing.Point(128, 254);//txtphonenumber

                    label9.Location = new System.Drawing.Point(12, 302);//labeldepartment
                    combDeparment.Location = new System.Drawing.Point(128, 296);//comdepartment

                    label4.Location = new System.Drawing.Point(12, 346);//labelrole
                    cobRole.Location = new System.Drawing.Point(128, 340);//combrole

                    label5.Location = new System.Drawing.Point(12, 390);
                    cobQuestion.Location = new System.Drawing.Point(128, 384);

                    label6.Location = new System.Drawing.Point(12, 430);
                    txtAnswer.Location = new System.Drawing.Point(128, 428);

                    lblGeoLocation.Location = new System.Drawing.Point(12, 472);
                    txtGeolocation.Location = new System.Drawing.Point(128, 470);

                    label7.Visible = false;
                    txtProjectName.Visible = false;
                    cobRole.Visible = true;
                    groupBox2.Visible = false;
                    this.Size = new System.Drawing.Size(510, 639);
                    txtGeolocation.Text = RMPCLApp.Properties.Settings.Default.GeoLocation;
                    txtGeolocation.ReadOnly = true;
                    chkemp.Visible = true;                   

                }
                if (!IsFirstCall)
                {
                    DataTable rolDT = Resources.Instance.GetDataKey("Sp_GetDeptMaster");
                    if (rolDT.Rows.Count > 0)
                    {
                        combDeparment.Items.Clear();
                        combDeparment.DataSource = rolDT;
                        combDeparment.DisplayMember = "DepartName";
                        combDeparment.ValueMember = "DeptId";                        
                    }
                    DataTable rolDf = Resources.Instance.GetDataKey("Sp_GetRoles");
                    if (rolDf.Rows.Count > 0)
                    {
                        cobRole.Items.Clear();
                        cobRole.DataSource = rolDf;
                        cobRole.DisplayMember = "RoleName";
                        cobRole.ValueMember = "RoleID";                        
                    }
                    int MaxId = 0;
                     Resources.Instance.GetMaxID("SP_GetMaxID", "@MaxID", ref MaxId);
                    txtUserID.Text =(++MaxId).ToString();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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
