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

namespace HindalcoiOS.PermitToWork
{
    public partial class PermitClosure : XtraForm
    {
        #region Declaration
        public event SomeEvents ClosureEvent;
        public string GetMachine { set; get; }
        public string GetArea { set; get; }
        public bool IsIsolated { set; get; }
        #endregion

        public PermitClosure()
        {
            InitializeComponent();
        }
        private void PermitClosure_Load(object sender, EventArgs e)
        {
            HidePTWClosePagesHeader();
            UncheckClosureQuestion();
            chkPtwClosrRemoveIso.Checked = false;
            chkIsoTotRemoved.Enabled = false;
            //// btnIsoRemoved.Visible = true;
            ////if (IsIsolated == false)
            ////btnIsoRemoved.Visible = false;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsIsolated == true && chkIsoTotRemoved.Checked != true)
                    XtraMessageBox.Show("Please check isolation removal for all machines", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (chkcompletion.Checked == true && chkLock.Checked == true && chkTools.Checked == true && chkWorkplace.Checked == true && chkScrap.Checked == true)
                {
                    int a = Resources.Instance.AddPTWClosure(lblPermitCode.Text, System.DateTime.Now, Class_Operation.GlobalDeclaration.UserId.ToString(), "Closed");
                    int b = Resources.Instance.AddPTWStatus(2, lblPermitCode.Text, "Closed");
                    if (a > 0 && b > 0)
                    {
                        if (ClosureEvent != null)
                        {
                            ClosureEvent.Invoke("Closed");
                            DialogResult = DialogResult.OK;
                        }
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Permit closed successfully", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Oops somthing went Wrong!..", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "All options needs to be chosen", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            UncheckClosureQuestion();
        }

        /// <summary>
        /// No required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClosureQts_Click(object sender, EventArgs e)
        {
            PermitClosurePages.SelectedIndex = 0;
        }
        
        /// <summary>
        /// No required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIsoRemoved_Click(object sender, EventArgs e)
        {
            PermitClosurePages.SelectedIndex = 1;
        }

        /// <summary>
        /// No required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJobCompletion_Click(object sender, EventArgs e)
        {
            PermitClosurePages.SelectedIndex = 2;
        }
        private DataTable LoadDataToIsolationGrid(String PermitCode)
        {
            DataTable isolationMachines1 = null;
            isolationMachines1 = Resources.Instance.GetAllIsolatedMachines(PermitCode);
            dgvIsolatedMachineClosure.DataSource = isolationMachines1;
            //dgvIsolatedMachineClosure.Columns["Snapshot"].Visible = false;
            return isolationMachines1;
        }

        private void PermitClosurePages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PermitClosurePages.SelectedTab.Tag.ToString() == "IsolationRemoved")
            {
                LoadDataToIsolationGrid(lblPermitCode.Text);
            }
        }

        private bool IsIsolationRemoved(DataTable dtt)
        {
            chkIsoTotRemoved.Enabled = true;
            bool isComplete = false;
            dtt = LoadDataToIsolationGrid(lblPermitCode.Text);
            int rCount, sCount = 0;
            rCount = dtt.Rows.Count;

            sCount = dtt.AsEnumerable().Where(a => a.Field<string>("Status") == "Removed").Count();
            if (rCount > 0 && rCount == sCount)
            {
                isComplete = true;
                //chkRemoveIsolation.Checked = isComplete;
                chkIsoTotRemoved.Checked = true;
            }
            chkIsoTotRemoved.Enabled = false;
            return isComplete;
        }

        private void CmbSelMAchine_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable IsolationMaster = Resources.Instance.GetMachineConnectionInfo(GetMachine);
                DataTable IsolatedMAchines = Resources.Instance.GetIsolatedMachines(lblPermitCode.Text);
                if (IsolationMaster.Rows.Count == 0) return;
                //if (CmbSelMAchine.SelectedIndex > 0)
                {

                    if (CmbSelMAchine.Text == "N/A")
                    {
                        MachinePanel2.Visible = false;
                        int selindex = CmbSelMAchine.SelectedIndex - 1;
                        lblPtwClosrLocationVal.Text = GetArea;
                        // lblEquipName2.Text = IsolationMaster.Rows[selindex][1].ToString();
                        // lblConnectorType2.Text = IsolationMaster.Rows[selindex][2].ToString();
                    }
                    if (CmbSelMAchine.Text != "N/A")
                    {

                        MachinePanel2.Visible = true;
                        int selindex = CmbSelMAchine.SelectedIndex;
                        lblPtwClosrLocationVal.Text = GetArea;
                        lblPtwClosrEquipVal.Text = IsolationMaster.Rows[selindex][1].ToString();
                        lblPtwClosrConnTypeVal.Text = IsolationMaster.Rows[selindex][2].ToString();

                        DataRow isoDr = LoadDataToIsolationGrid(lblPermitCode.Text).AsEnumerable().SingleOrDefault(a => a.Field<string>("Machine Name") == CmbSelMAchine.Text && a.Field<string>("Permit Code") == lblPermitCode.Text);

                        if (isoDr != null)
                        {

                            chkPtwClosrRemoveIso.CheckState = CheckState.Unchecked; //Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
                            if (isoDr["Status"].ToString() == "Pending" || isoDr["Status"].ToString() == "Completed")
                            {
                                chkPtwClosrRemoveIso.Checked = false;
                            }
                            else
                            {
                                chkPtwClosrRemoveIso.CheckState = CheckState.Checked;
                                chkPtwClosrRemoveIso.Checked = true;
                            }

                            lblPtwClsrLockNoVal.Text = isoDr["Lock No"].ToString();
                            lblPtwClosrContactVal.Text = isoDr["Contact No"].ToString();
                            lblPtwClosrPersonVal.Text = isoDr["Person Name"].ToString();

                            //txtLockNo2.Text = isoDr["Lock No"].ToString();
                            //txtContact2.Text = isoDr["Contact No"].ToString();
                            //txtPersoname2.Text = isoDr["Person Name"].ToString();

                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// No mapping
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReloadIsolatedInfo()
        {
            try
            {
                DataTable IsolationMaster = Resources.Instance.GetMachineConnectionInfo(GetMachine);
                DataTable IsolatedMAchines = Resources.Instance.GetIsolatedMachines(lblPermitCode.Text);

                if (CmbSelMAchine.Text == "N/A")
                {
                    MachinePanel2.Visible = false;
                    int selindex = CmbSelMAchine.SelectedIndex - 1;
                    lblPtwClosrLocationVal.Text = GetArea;
                    // lblEquipName2.Text = IsolationMaster.Rows[selindex][1].ToString();
                    // lblConnectorType2.Text = IsolationMaster.Rows[selindex][2].ToString();
                }
                if (CmbSelMAchine.Text != "N/A")
                {

                    MachinePanel2.Visible = true;
                    int selindex = CmbSelMAchine.SelectedIndex;
                    lblPtwClosrLocationVal.Text = GetArea;
                    lblPtwClosrEquipVal.Text = IsolationMaster.Rows[selindex][1].ToString();
                    lblPtwClosrConnTypeVal.Text = IsolationMaster.Rows[selindex][2].ToString();

                    DataRow isoDr = LoadDataToIsolationGrid(lblPermitCode.Text).AsEnumerable().SingleOrDefault(a => a.Field<string>("Machine Name") == CmbSelMAchine.Text && a.Field<string>("Permit Code") == lblPermitCode.Text);

                    if (isoDr != null)
                    {
                        chkPtwClosrRemoveIso.CheckState = CheckState.Unchecked;
                        if (isoDr["Status"].ToString() == "Pending")
                        {
                            chkPtwClosrRemoveIso.Checked = false;
                        }
                        else
                        {
                            chkPtwClosrRemoveIso.CheckState = CheckState.Checked;
                            chkPtwClosrRemoveIso.Checked = true;
                        }
                        lblPtwClsrLockNoVal.Text = isoDr["Lock No"].ToString();
                        lblPtwClosrContactVal.Text = isoDr["Contact No"].ToString();
                        lblPtwClosrPersonVal.Text = isoDr["Person Name"].ToString();
                    }
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UncheckClosureQuestion()
        {
            chkcompletion.Checked = false;
            chkLock.Checked = false;
            chkTools.Checked = false;
            chkWorkplace.Checked = false;
            chkScrap.Checked = false;
        }

        private void btnIsolateRemove_Click(object sender, EventArgs e)
        {
            if (IsIsolated == false)
            {
                btnClose.Visible = true;
                return;
            }
            dtpRemovalDate.CustomFormat = "dd-MM-yyyy hh:mm";
            DateTime dtpremovedate = Convert.ToDateTime(dtpRemovalDate.Text);
            //int isComplete = 1;
            if (chkPtwClosrRemoveIso.Checked == true)
            {
                //isComplete = 2;
                Resources.Instance.UpdatePTWIsolationDetails(lblPermitCode.Text, lblPtwClosrEquipVal.Text, dtpremovedate, 2);

            }
            else
            {
                XtraMessageBox.Show("Please Check Isolation Removal");
            }

            DataTable datatable = LoadDataToIsolationGrid(lblPermitCode.Text);
            if (IsIsolationRemoved(datatable) == true)
            {
                btnClose.Visible = true;
            }
        }

        private void HidePTWClosePagesHeader()
        {
            PermitClosurePages.Appearance = TabAppearance.FlatButtons;
            PermitClosurePages.ItemSize = new Size(0, 1);
            PermitClosurePages.SizeMode = TabSizeMode.Fixed;

            foreach (TabPage tab in PermitClosurePages.TabPages)
            {
                tab.Hide();// = "";
            }
        }

        private void btnClosQts_Click(object sender, EventArgs e)
        {
            PermitClosurePages.SelectedIndex = 0;
        }

        private void btnIsoRemoved_Click_1(object sender, EventArgs e)
        {
            PermitClosurePages.SelectedIndex = 1;
        }
    }
}
