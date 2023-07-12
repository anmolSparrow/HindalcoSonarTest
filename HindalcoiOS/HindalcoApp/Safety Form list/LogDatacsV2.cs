using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.Safety_Form_list
{
    public partial class LogDatacs : XtraForm
    {
        private string MachineTag = string.Empty;
        private string MachineName = string.Empty;
        private string SysGenNo = string.Empty;
        private string MachineLocation = string.Empty;

        public LogDatacs()
        {
            InitializeComponent();
        }
        public LogDatacs(string machinetag, string machinename, string sysgenno, string MachineLoc)
        {
            this.MachineName = machinename;
            this.MachineTag = machinetag;
            this.SysGenNo = sysgenno;
            this.MachineLocation = MachineLoc;
            this.Text = "Near Miss Data Details";
            UpdateTextPosition();
            InitializeComponent();
        }
        private void UpdateTextPosition()
        {
            try
            {
                Graphics g = this.CreateGraphics();
                Double startingPoint = (this.Width / 2) - (g.MeasureString(this.Text.Trim(), this.Font).Width / 2);
                Double widthOfASpace = g.MeasureString(" ", this.Font).Width;
                String tmp = " ";
                Double tmpWidth = 0;

                while ((tmpWidth + widthOfASpace) < startingPoint)
                {
                    tmp += " ";
                    tmpWidth += widthOfASpace;
                }

                this.Text = tmp + this.Text.Trim();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LogDatacs_Load(object sender, EventArgs e)
        {
            try
            {
                List<Control> allControls = GetAllControls(this);
                allControls.ForEach(k => k.Font = new System.Drawing.Font("Segoe UI", 9));
                grpAppInfo.Visible = false;
                grpInfo.Width = grpInfo.Width + grpAppInfo.Width;

                if (!string.IsNullOrEmpty(txtmechinetag.Text))
                    chkApplicable.Visible = false;

                txtmechinetag.Text = this.MachineTag;

                if (NearmissLogPages.SelectedTab.Name == "xtraTabGenInfo")
                    LoadNeaMissData();

                LoadEvetWholeData();
                LoadEmployeeList();
                //comboBox1.SelectedIndex = 0;
            }
            catch(Exception ex)
            {

            }
        }
        private List<Control> GetAllControls(Control container, List<Control> list)
        {
            foreach (Control c in container.Controls)
            {
                if (c.Controls.Count > 0)
                    list = GetAllControls(c, list);
                else
                    list.Add(c);
            }
            return list;
        }

        // private DataTable LoadEmploye = new DataTable();
        private void LoadEmployeeList()
        {
            // DataTable LoadEmploye = Resources.Instance.GetDataKey("SP_GetEmployeeName");
            foreach (DataRow row in Resources.Instance._EmpName.Rows)
            {
                this.cmbChkEmployee.Items.Add(row["emp_name"]);
            }
            this.cmbChkEmployee.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.cmbChkEmployee.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbChkEmployee.Margin = new Padding(3, 10, 3, 10);
            //cmbChkEmployee.Size = new Size(this.Size.Width,(cmbChkEmployee.ItemHeight + 1) * cmbChkEmployee.Items.Count);
            //this.cmbChkEmployee.DataSource = LoadEmploye;
            //cmbChkEmployee.DisplayMember = "emp_name";
            //cmbChkEmployee.ValueMember = "emp_name";
        }
        private List<Control> GetAllControls(Control container)
        {
            return GetAllControls(container, new List<Control>());
        }

        private void chkApplicable_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkApplicable.Checked)
                {
                    grpAppInfo.Visible = true;
                    grpInfo.Width = grpInfo.Width - grpAppInfo.Width;
                    txtmachine.Text = this.MachineName;
                }
                else
                {
                    txtmachine.Text = "";
                    grpAppInfo.Visible = false;
                    grpInfo.Width = grpInfo.Width + grpAppInfo.Width;
                }
            }
            catch (Exception Ex)
            {

                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string value = string.Empty;
                int queryrslt = 0;
                if (NearmissLogPages.SelectedTab.Name == "xtraTabGenInfo")
                {
                    if (chkApplicable.Checked)
                    {

                        if (txtmechinetag.Text == "")
                        {
                            XtraMessageBox.Show("MachineTagNo Should Not be Empty \n Please Enter Value Of MachineTag.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtmechinetag.Focus();
                            return;
                        }
                        if (txtmachine.Text == "")
                        {
                            XtraMessageBox.Show("MachineName Should Not be Empty \n Please Enter Value Of MachineName.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtmachine.Focus();
                            return;
                        }
                        if (txtlocation.Text == "")
                        {
                            XtraMessageBox.Show("Location Should Not be Empty \n Please Enter Value Of Location.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtlocation.Focus();
                            return;
                        }
                        if (txtowner.Text == "")
                        {
                            XtraMessageBox.Show("Owner Should Not be Empty \n Please Enter Value Of Owner.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtowner.Focus();
                            return;
                        }
                        if (txtvendor.Text == "")
                        {
                            XtraMessageBox.Show("Vendor Should Not be Empty \n Please Enter Value Of Vendor.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtvendor.Focus();
                            return;
                        }

                        value = this.MachineTag + "_" + chkApplicable.Checked.ToString() + "_" + dateTimepckEvent.Value.ToString() + "_" + dateTimeevtrpt.Value.ToString() + "_" +
                            this.MachineName + "_" + txtlocation.Text + "_" + txtowner.Text + "_" + txtvendor.Text + "_" + this.SysGenNo + "_" + this.MachineLocation.TrimStart();
                    }
                    else
                    {
                        value = this.MachineTag + "~" + chkApplicable.Checked.ToString() + "~" + dateTimepckEvent.Value.ToString() + "~" + dateTimeevtrpt.Value.ToString() + "~" +
                           this.MachineName + "~" + "" + "~" + "" + "~" + "" + "~" + this.SysGenNo + "~" + this.MachineLocation.TrimStart() + "~" + GlobalDeclaration._holdInfo[0].UserName + "~" + GlobalDeclaration._holdInfo[0].UserId
                           + "~" + GlobalDeclaration._holdInfo[0].EmpCode;

                        //value = this.MachineTag + "_" + chkApplicable.Checked.ToString() + "_" + dateTimepckEvent.Value.ToString() + "_" + dateTimeevtrpt.Value.ToString() + "_" +
                        //    this.MachineName + "_" + "" + "_" + "" + "_" + "" + "_" + this.SysGenNo + "_" + this.MachineLocation.TrimStart() + "_" + GlobalDeclaration._holdInfo[0].UserName + "_" + GlobalDeclaration._holdInfo[0].UserId
                        //    + "_" + GlobalDeclaration._holdInfo[0].EmpCode;
                    }
                    queryrslt = Resources.Instance.InsertNearMissData("Sp_InsertNearMissData", value);
                    if (queryrslt > 0)
                    {
                        XtraMessageBox.Show("Details SuccessFully Save In Db.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        XtraMessageBox.Show("Unable To Insert Data.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (NearmissLogPages.SelectedTab.Name == "xtraTabInjury")
                {
                    if (cmbChkEmployee.Text.ToString() == "")
                    {

                        XtraMessageBox.Show("People Affected Should Not be Empty \n Please Enter Value Of People Affected.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbChkEmployee.Focus();
                        return;
                    }
                    value = this.MachineName + "_" + this.MachineTag + "_" + this.SysGenNo + "_" + cmbChkEmployee.Text.ToString() + "_"
                        + ritchEnterEvnt.Text + "_" + comboBox1.SelectedItem.ToString() + "~" + cmbdynamic.SelectedItem.ToString() + "_" + this.MachineLocation.TrimStart() + "_" + GlobalDeclaration._holdInfo[0].UserName + "_" + GlobalDeclaration._holdInfo[0].UserId + "_" + GlobalDeclaration._holdInfo[0].EmpCode;
                    int Result = Resources.Instance.InsertNearMissGenInfo("Sp_InsertNearInjurdData", "@Machinename", "@machinetag", "@sysgeno", "@pepoleEff", "@enterEvent", "@EventType", "@MCordinate", "@userName", "@userId", "@empCode", value);
                    if (Result > 0)
                    {
                        XtraMessageBox.Show("Details SuccessFully Save In Db.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        XtraMessageBox.Show("Unable To Insert Data.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (NearmissLogPages.SelectedTab.Name == "xtraTabCause")
                {
                    if (ritchimmedaite.Text == "")
                    {
                        XtraMessageBox.Show("Please  Enter Details of immediate cause?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ritchimmedaite.Focus();
                        return;
                    }
                    if (ritchrootcause.Text == "")
                    {

                        XtraMessageBox.Show("Please  Enter Details of Root Casue ?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ritchrootcause.Focus();
                        return;

                    }
                    if (ritchintercause.Text == "")
                    {
                        XtraMessageBox.Show("Please  Enter Details of Intermediate Cause?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ritchintercause.Focus();
                        return;
                    }
                    value = this.MachineName + "_" + this.MachineTag + "_" + this.SysGenNo + "_" + this.MachineLocation.TrimStart() +
                        "_" + rtchRemark.Text + "_" + rtchAssignTo.Text + "_" + rtchActionTaken.Text + "_" + rtchHazard.Text + "_" + ritchimmedaite.Text + "_" + ritchrootcause.Text + "_" + ritchintercause.Text
                        + "_" + GlobalDeclaration._holdInfo[0].UserName + "_" + GlobalDeclaration._holdInfo[0].UserId + "_" + GlobalDeclaration._holdInfo[0].EmpCode;

                    queryrslt = Resources.Instance.InsertNearMissGenInfo("SP_InsertTabAction", "@Machinename", "@machinetag", "@sysgeno",
                        "@Mcordinat", "@Remark", "@AssignTo", "@ActionTaken", "@hazradType", "@ImmedtCause", "@RootCause", "@IntermediateCause", "@userName", "@userId", "@empCode", value);
                    if (queryrslt > 0)
                    {
                        XtraMessageBox.Show("Details SuccessFully Save In Db.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        XtraMessageBox.Show("Unable To Insert Data.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadNeaMissData()
        {
            try
            {
                string Value = string.Empty;
                DataTable dt = null;
                if (GlobalDeclaration.UserType.Equals("U1-Maintenance") || GlobalDeclaration.UserType.Equals("U1-Safety"))
                {
                   //Value = this.MachineTag + "_" + this.MachineName + "_" + this.SysGenNo.ToString() + "_" + this.MachineLocation.TrimStart() + "_" + "0" + "_" + 0 + "_" + "0";
                    Value = this.MachineTag + "~" + this.MachineName + "~" + this.SysGenNo.ToString() + "~" + this.MachineLocation.TrimStart() + "~" + "0" + "~" + 0 + "~" + "0";
                }
                else
                {
                    Value = this.MachineTag + "~" + this.MachineName + "~" + this.SysGenNo.ToString() + "~" + this.MachineLocation.TrimStart();
                    Value = Value + "~" + GlobalDeclaration._holdInfo[0].UserName + "~" + GlobalDeclaration._holdInfo[0].UserId + "~" + GlobalDeclaration._holdInfo[0].EmpCode;
                }
                dt = Resources.Instance.GetDataKey("Sp_FetchNearMissData", "@machineTag", "@machineName", "@sysGenNo", "@Mcord", "@userName", "@userId", "@empCode", Value);
                if (dt.Rows.Count > 0)
                {
                    bool Isapp = Convert.ToBoolean(dt.Rows[0]["IsApplicable"]);
                    if (Isapp)
                    {
                        txtlocation.Text = dt.Rows[0]["Location"].ToString();
                        txtvendor.Text = dt.Rows[0]["Vendor"].ToString();
                        txtowner.Text = dt.Rows[0]["Owner"].ToString();
                        chkApplicable.Checked = Isapp;
                        //txtlocation.ReadOnly = true;
                        //txtvendor.ReadOnly = true;
                        //txtowner.ReadOnly = true;
                        chkApplicable.Enabled = false;
                    }
                    else
                    {
                        dateTimepckEvent.Value = Convert.ToDateTime(dt.Rows[0]["EventDate"].ToString());
                        dateTimeevtrpt.Value = Convert.ToDateTime(dt.Rows[0]["EventReportTime"].ToString());
                        dateTimepckEvent.Enabled = false;
                        dateTimeevtrpt.Enabled = false;

                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ritchType_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtowner_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        DataTable LoadEvnt = new DataTable();
        private void LoadEvetWholeData()
        {
            string value = string.Empty;
            if (GlobalDeclaration.UserType.Equals("U1-Maintenance") || GlobalDeclaration.UserType.Equals("U1-Safety"))
            {
                value = this.MachineName + "~" + this.MachineTag + "~" + this.SysGenNo + "~" + this.MachineLocation.TrimStart();
                LoadEvnt = Resources.Instance.Logdata("Sp_FetchNearMissEvent", "@Machinename", "@machinetag", "@sysgeno", "@Mcordinate", value);
            }
            else
            {
                value = this.MachineName + "~" + this.MachineTag + "~" + this.SysGenNo + "~" + this.MachineLocation.TrimStart()
                + "~" + GlobalDeclaration._holdInfo[0].UserName + "~" + GlobalDeclaration._holdInfo[0].UserId + "~" + GlobalDeclaration._holdInfo[0].EmpCode;
                LoadEvnt = Resources.Instance.Logdata("Sp_FetchNearMissEvent", "@Machinename", "@machinetag", "@sysgeno", "@Mcordinate", "@userName", "@userId", "@empCode", value);
            }

        }
        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            if (NearmissLogPages.SelectedTab.Name == "xtraTabGenInfo")
            {
                LoadNeaMissData();
            }
            else if (NearmissLogPages.SelectedTab.Name == "xtraTabInjury")
            {

                try
                {
                    if (!String.IsNullOrEmpty(cmbChkEmployee.Text)) return;
                    string value = this.MachineName + "~" + this.MachineTag + "~" + this.SysGenNo + "~" + this.MachineLocation.TrimStart() + "~" + GlobalDeclaration._holdInfo[0].UserName + "~" + GlobalDeclaration._holdInfo[0].UserId + "~" + GlobalDeclaration._holdInfo[0].EmpCode;
                    DataTable Dt = Resources.Instance.Logdata("Sp_FetchNearMissInjurdData", "@Machinename", "@machinetag", "@sysgeno", "@Mcordinate", "@userName", "@userId", "@empCode", value);
                    if (Dt.Rows.Count > 0)
                    {
                        cmbChkEmployee.Text = Dt.Rows[0]["PeopleAffect"].ToString();
                        ritchEnterEvnt.Text = Dt.Rows[0]["EnterType"].ToString();
                        if (Dt.Rows[0]["EventType"].ToString().Contains('~'))
                        {

                            comboBox1.SelectedItem = Dt.Rows[0]["EventType"].ToString().Split('~')[0].ToString();
                            cmbdynamic.SelectedItem = Dt.Rows[0]["EventType"].ToString().Split('~')[0].ToString();
                        }
                        ritchEnterEvnt.ReadOnly = true;
                        comboBox1.Enabled = false;
                        cmbdynamic.Enabled = false;
                        cmbChkEmployee.Enabled = false;

                    }
                }
                catch (Exception Ex)
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (NearmissLogPages.SelectedTab.Name == "xtraTabCause")
            {
                try
                {
                    if (ritchimmedaite.Text == string.Empty)
                    {
                        if (LoadEvnt.Rows.Count > 0)
                        {
                            ritchimmedaite.Text = LoadEvnt.Rows[0]["ImmedtCause"].ToString();
                            ritchintercause.Text = LoadEvnt.Rows[0]["IntermediateCause"].ToString();
                            ritchrootcause.Text = LoadEvnt.Rows[0]["RootCause"].ToString();
                            rtchRemark.Text = LoadEvnt.Rows[0]["Remark"].ToString();
                            rtchAssignTo.Text = LoadEvnt.Rows[0]["AssignTo"].ToString();
                            rtchActionTaken.Text = LoadEvnt.Rows[0]["ActionTaken"].ToString();
                            rtchHazard.Text = LoadEvnt.Rows[0]["HazardType"].ToString();
                            //ritchimmedaite.ReadOnly = true;
                            //ritchintercause.ReadOnly = true;
                            //ritchrootcause.ReadOnly = true;
                            //rtchAssignTo.ReadOnly = true;
                            //rtchActionTaken.ReadOnly = true;
                            //rtchHazard.ReadOnly = true;

                        }
                    }
                }
                catch (Exception Ex)
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbEnterEvnt_SelectedValueChanged(object sender, EventArgs e)
        {
            string Value = cmbdynamic.SelectedItem.ToString();
            if (Value == "Other-")
            {
                ritchEnterEvnt.Text = ritchEnterEvnt.Text + " " + Value;
            }
            else
            {
                ritchEnterEvnt.Text = ritchEnterEvnt.Text + " " + Value + ",";
            }
            ritchEnterEvnt.Font = new Font(ritchEnterEvnt.SelectionFont.FontFamily, 12);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbdynamic.Items.Count > 0)
                    cmbdynamic.Items.Clear();
                if (comboBox1.SelectedItem.ToString().TrimEnd() == "Unsafe Act")
                {
                    string[] ArrayList = { "Inadequate guard", "Unguarded hazard", "Safety device is defective",
                    "Tool or equipment defective", "Workstation layout is hazardous","Unsafe lighting","Unsafe ventilation","Lack of needed PPE",
                "Lack of appropriate equipment/ tools","Unsafe clothing","No training or insufficient training","Other-"};
                    for (int i = 0; i < ArrayList.Length; i++)
                    {
                        cmbdynamic.Items.Add(ArrayList[i]);
                    }
                }
                else if (comboBox1.SelectedItem.ToString() == "Unsafe Condition")
                {
                    string[] ArrayList = { "Operating without permission", "Operating at unsafe speed",
                    "Servicing equipment that has power to it", "Making a safety device inoperative" ,"Using defective equipment","Using equipment in an unapproved way",
                "Unsafe lifting","Taking an unsafe position or posture","Distraction, teasing, horseplay","Failure to wear PPE",
                "Failure to use the available equipment/tools","Other-"};
                    for (int i = 0; i < ArrayList.Length; i++)
                    {
                        cmbdynamic.Items.Add(ArrayList[i]);
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbChkEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selindex = cmbChkEmployee.SelectedIndex;
            cmbChkEmployee.SetItemChecked(selindex, true);
        }

        private void btnGnrlInfo_Click(object sender, EventArgs e)
        {
            NearmissLogPages.SelectedIndex = 0;
        }

        private void btnInjuryInfo_Click(object sender, EventArgs e)
        {
            NearmissLogPages.SelectedIndex = 1;
        }

        private void btnCAPA_Click(object sender, EventArgs e)
        {
            NearmissLogPages.SelectedIndex = 2;
        }
    }
}
