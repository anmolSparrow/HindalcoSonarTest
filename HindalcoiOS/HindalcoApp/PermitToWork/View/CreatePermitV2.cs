using CADImport;
using DevExpress.DataAccess.ObjectBinding;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using Hind.AuditMgmt;
using log4net;
using HindalcoiOS.AuditHind;
using HindalcoiOS.Class_Operation;
using HindalcoiOS.Connector_FRM;
//using HindalcoiOS.PermitToWork.View;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.PermitToWork
{
    

    public partial class CreatePermit : XtraForm
    {
        public Dictionary<string, Connector_FRM.Connector> _listconnt
        {
            get;
            set;
        }


        //public static readonly ILog Log = LogHelper.GetLogger();
        public event SomeEvents SomeEvent;
        public PPERequired ppeRequired;
        public int UserRoleId;

        public CreatePermit()
        {
            InitializeComponent();
            cmbFromHours.Text = "0";
            cmbToHours.Text = "0";
            cmbFromMinuts.Text = "0";
            cmbToMinuts.Text = "0";
            dtpFromDate.Value = DateTime.Now;
            dtpPermitTo.Value = DateTime.Now;
            ppeRequired = new PPERequired();
            btnPTWDelete.Visible = false;
            LoadAllUsers = GlobalDeclaration.GetAllUsers();
            
            IsSaved = 0;
           UserRoleId= Properties.Settings.Default.RoleID;
            if (HindalcoiOS.Properties.Settings.Default.RoleID == 1 || HindalcoiOS.Properties.Settings.Default.RoleID == 5 || HindalcoiOS.Properties.Settings.Default.RoleID == 7)
            {
                btnPTWDelete.Visible = true;
            }
        }


        #region "Variables Declaration"
        public int IsSaved { set; get; }
        int permitValidity = 0;
        public static string PermitCode = "";
        Label lblBox = new Label();
        TextBox txt1 = new TextBox();
        public static List<object> formObject = new List<object>();
        DataTable IsolationMaster = null;
        DataTable permitStatus = new DataTable();
        DataTable addStatus = new DataTable();
        DataTable addApproveStatus = new DataTable();
        DataTable IsolatedMAchines = new DataTable();
        DataTable PermitGrid = new DataTable();
        DataTable WorkLocation = new DataTable();
        DataTable viewPermit = new DataTable();
        public DataTable LoadAllUsers { set; get; }
        public string dtpfval { set; get; }
        public string dtpTval { set; get; }
        // int yaxis = 0;

        int lastYaxis = 115;
        int Differpoint = 0;
        int PanelYaxis = 0;
        int incYaxis = 0;
        int ButtonYaxis = 0;
        int buttonIncYaxis = 48;

        int isolationchk2;

        int i = 0;
        public static string permitCode;
        string uploadPath;
        public static bool inhouseRedirect = false;
        Boolean isredirected = false;
        public bool capabilitychk = false;
        string Permitstatus = string.Empty;
        DataTable pInhouseDt;
        int reqQty = 0;
        string mcTag = string.Empty;
        #endregion

        private void preInit()
        {
            dtpPermitFrom.Format = DateTimePickerFormat.Custom;
            dtpPermitFrom.CustomFormat = "dd-MM-yyyy hh:ss";// "MM/dd/yyyy hh:mm:ss tt";
            dtpPermitTo.Format = DateTimePickerFormat.Custom;
            dtpPermitTo.CustomFormat = "dd-MM-yyyy hh:ss";// "MM/dd/yyyy hh:mm:ss tt";
            permitCode = txtpermitCode.Text;
            //  tabControl2.TabPages.Remove(tabPage9);
        }
        public int pgIndex = 3;
        public bool IsFromMCD = false;
        private void CreatePermit_Load(object sender, EventArgs e)
        {
            try
            {
                HidePTWPagesHeader();
                btnPTWNewPermit.Visible = true;

                PTWPages.SelectedIndex = pgIndex;
                if (CallingLocation) return;
                PTWPages.TabPages.RemoveByKey("tabClosure");
                SetDefaultDateTime();
                txtarea.Visible = false;
                txtareaName.Visible = false;
                string permitlink = ParentWindow.permitLink;
                lblIsoTotStatus.Visible = false;
                chkIsoTotStatus.Visible = false;
                if (Permitstatus == "") txtPermitStatus.Text = Permitstatus = "Prepare";
                
                this.TopMost = false;
                if (PermitToWork.ViewPermit.frmRedirect == true)
                {
                    DataTable permitDetails = new DataTable();
                    permitDetails = PermitToWork.ViewPermit.peritDetailsData;
                    txtpermitCode.Text = permitDetails.Rows[0][0].ToString();
                    txtrequestdate.Text = permitDetails.Rows[0][1].ToString();
                    txtrequestBy.Text = permitDetails.Rows[0][2].ToString();
                    dtpPermitFrom.Text = permitDetails.Rows[0][3].ToString();
                    dtpPermitTo.Text = permitDetails.Rows[0][4].ToString();
                    cmbPtwBasicArea.Text = permitDetails.Rows[0][5].ToString();
                    //cmbMachineName.Text= permitDetails.Rows[0][6].ToString();
                    cmbApprovedBy.Text = permitDetails.Rows[0][7].ToString();
                    txtdescription.Text = permitDetails.Rows[0][8].ToString();
                    cmbWorkType.Text = permitDetails.Rows[0][9].ToString();
                    cmbCapability.Text = permitDetails.Rows[0][10].ToString();
                    //btnAddBasic.Text = "Update";
                }
                else
                {
                    GeneratePTWId();
                    txtrequestBy.Text = Class_Operation.GlobalDeclaration._holdInfo[0].UserName;
                    txtrequestdate.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm");
                    InitCmbHours();
                    AddColumnsToDT();
                    AddWorkLocationDTColumns();

                    // Isolation------

                    //* Change on 140922---------------------------------------------------------------
                    ////SetValueTocmbPermitCode();

                    List<string> machineList = Resources.Instance.GetMachineTag();//Change by RP
                    int listcnt = machineList.Count;
                    //for (int i = 0; i < listcnt; i++)
                    //{
                        //cmbMachineName.Items.Add(machineList[i]);
                    //}

                    PermitCode = txtpermitCode.Text;
                    //txtpermitCode.Attributes.Add("readonly", "readonly");
                    timerMonitor.Enabled = false;
                    DataTable Areamaster = Resources.Instance.GetMachineAreaMaster(); //Change by RP
                    for (int y = 0; y < Areamaster.Rows.Count; y++)
                    {
                        cmbPtwBasicArea.Items.Add(Areamaster.Rows[y][0]);
                        cmbSplReqAreaName.Items.Add(Areamaster.Rows[y][0]);
                    }
                    //GetApproverFromArea(cmbArea.SelectedText);

                    foreach (var item in GlobalDeclaration._MyTagDictinary)
                    {
                        string MachineTag = item.Value;
                        this.cmbBasicMachineIsolation.Items.Add(MachineTag);
                    }
                    cmbBasicMachineIsolation.Items.Add("Select Cad Layout..");
                    cmbBasicMachineIsolation.Items.Add("NA");


                    if (Class_Operation.GlobalDeclaration.PermitType != "")
                    {
                        lblPermitTypeSelected.Text = Class_Operation.GlobalDeclaration.PermitType;
                    }
                    List<string> permitCodeList = Resources.Instance.GetPTWPermitCode();//Change by RP
                    cmbPermitCode.Items.Clear();
                    cmbPermitCode.Items.Add("");
                    pnlIsoMachine.Visible = false;

                    for (int i = 0; i < permitCodeList.Count; i++)
                    {
                        cmbPermitCode.Items.Add(permitCodeList[i].ToString());
                    }
                }

                DBPtwApproveGrid.CellClick += new DataGridViewCellEventHandler(DBGridPermitList_ComboBoxIndexChanged);
                chkIsolationCompl.Checked = false;
                HidePTWBasic();
                
            }
            catch (Exception Ex)
            {

                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }
        private void DBGridPermitList_ComboBoxIndexChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DBPtwApproveGrid.CurrentCell == null) return;
                if (DBPtwApproveGrid.CurrentCell.ColumnIndex == 6)
                {
                    actionSelected = DBPtwApproveGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    permitcode = DBPtwApproveGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                    //  object selectedValue = DBGridPermitList.CurrentRow.Cells[""].Value
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }

        }
        private void BindDataTable()
        {
            try
            {
                DataRow drRow = PermitGrid.NewRow();
                string code = txtpermitCode.Text;
                drRow[0] = code;
                drRow[1] = txtrequestdate.Text;
                drRow[2] = txtrequestBy.Text;
                drRow[3] = dtpPermitFrom.Value;
                drRow[4] = dtpPermitTo.Value;
                PermitGrid.Rows.Add(drRow);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }
        private void AddColumnsToDT()
        {
            PermitGrid.Columns.Add("PermitCode");
            PermitGrid.Columns.Add("RequestedDate");
            PermitGrid.Columns.Add("RequestedBy");
            PermitGrid.Columns.Add("PermitFrom");
            PermitGrid.Columns.Add("PermitTo");
            //PermitGrid.Columns.Add();
        }
        private void cmbCapability_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCapability.Text == "Out-Source")
            {
                txtPTWBasicVendor.Visible = true;
                lblPTWBasicVendor.Visible = true;
            }
            else //if(cmbCapability.Text == "In-House")
            {
                txtPTWBasicVendor.Visible = false;
                lblPTWBasicVendor.Visible = false;
            }


            //try
            //{
            //    if (cmbCapability.Text == "In-House")
            //    {
            //        PermitToWork.PermitInHouse inhouse = new PermitInHouse();
            //        inhouse.SomeEvent += Inhouse_SomeEvent;
            //        if (DialogResult.OK == inhouse.ShowDialog())
            //        {
            //            inhouse.SomeEvent -= Inhouse_SomeEvent;
            //            inhouse.Close();
            //            inhouse.Dispose();
            //        }
            //        else
            //        {
            //            inhouse.Close();
            //        }

            //    }
            //    else
            //    {
            //        PermitToWork.OutsourcedPermit outSource = new OutsourcedPermit();
            //        outSource.Show();

            //    }
            //}
            //catch (Exception Ex)
            //{
            //    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}
        }
        private void Inhouse_SomeEvent(params object[] objec)
        {
            pInhouseDt = (DataTable)objec[0];
            mcTag = objec[1].ToString();
            reqQty = int.Parse(objec[2].ToString());

        }
        private void PTWBasicPages_SelectedIndexChangedOld(object sender, EventArgs e)
        {
            try
            {
                btnPermitSave.Enabled = true;
                btnPermitSave.Visible = true;
                btnPTWCancel.Visible = true;
                if (PTWBasicPages.SelectedIndex == 0)
                {
                    //PTWBasicPages.SelectedIndex = 0;
                    SplVisibility();
                }
                if (PTWBasicPages.SelectedIndex == 1 || PTWBasicPages.SelectedIndex == 2 || PTWBasicPages.SelectedIndex == 3 || PTWBasicPages.SelectedIndex == 5)
                {
                    //PTWBasicPages.SelectedIndex = 1;
                    //BasicPageMigration();

                    btnPermitSave.Enabled = true;
                    btnPermitSave.Visible = true;
                    btnPTWCancel.Visible = true;
                    int permitValidity = Resources.Instance.GetInHousePermitValidity(txtpermitCode.Text);
                    if (PTWBasicPages.SelectedTab.Text == "View && Save")
                    {
                        viewPermit.Clear();
                        viewPermit.Columns.Clear();
                        ADDcolumnsToView();
                        AddRowsToView();
                    }

                    if (PTWBasicPages.SelectedTab.Text == "Other Hazard")
                    {
                        //int permitValidity = Resources.Instance.GetInHousePermitValidity(txtpermitCode.Text);
                        if (Permitstatus != "Closed" && Permitstatus != "Prepare")// && Permitstatus != "Cancelled")
                        {
                            btnPermitSave.Enabled = false;
                            btnPermitSave.Text = "Save";

                            //button5.Text = "Close Permit";
                        }

                        if (capabilitychk == true && Permitstatus == "Cancelled")
                        {
                            btnPermitSave.Text = "Save";
                            btnPermitSave.Enabled = true;
                        }

                        if (chkReadyToSubmit.Checked == true)  //if (permitValidity == 1)
                        {
                            btnPermitSave.Text = "Submit";
                            // tabControl1.TabPages.Add("tabPage3");
                        }
                        if (permitValidity == 0 && Permitstatus == "")
                        {
                            btnPermitSave.Text = "Save";
                        }

                    }
                    if (PTWBasicPages.SelectedTab.Text == "Isolation")
                    {
                        //FreezeIsolation(false);
                        chkIsoTotStatus.Visible = false;
                        chkIsoTotStatus.Enabled = false;
                        cmbPermitCode.Text = txtpermitCode.Text;
                        cmbMachineIsolation.Text = cmbBasicMachineIsolation.Text;//cmbBasicMachineIsolation.SelectedItem.ToString();

                        if (!string.IsNullOrWhiteSpace(cmbBasicMachineIsolation.Text))//cmbBasicMachineIsolation.Text
                        {
                            ReloadConnectedMachine();
                            LoadDataToIsolationGrid(cmbPermitCode.Text);
                        }

                        //if (Permitstatus == "Prepare" || Permitstatus == "Cancelled") //if (permitValidity == 0)
                        //{
                        //    FreezeBasicIsolation();
                        //    chkIsolationReq.Checked = false;
                        //    //if (cmbSelMachine.Items.Count > 0)
                        //    //    chkIsolationReq.Checked = true;
                        //}
                        if (Permitstatus == "Prepare" || Permitstatus == "Cancelled") //if (permitValidity == 0)
                        {
                            FreezeBasicIsolation();
                            if (cmbSelMachine.Items.Count > 0) chkIsolationReq.Checked = true;
                            EnableOrDisableIsolation(chkIsolationReq.Checked);
                        }
                        else if (Permitstatus == "Approved")
                        {
                            chkIsolationReq.Enabled = false;
                            FreezeIsolation(false);
                            btnPermitSave.Visible = true;
                            btnPTWCancel.Visible = true;
                            DisablePPEDetail();
                        }
                        else if (Permitstatus == "Waiting For Approval")
                        {
                            chkIsolationReq.Enabled = false;
                            FreezeIsolation(false);
                            btnPermitSave.Visible = false;
                            btnPTWCancel.Visible = false;
                            DisablePPEDetail();
                        }
                        else if (Permitstatus == "Closed")
                        {
                            chkIsolationReq.Enabled = false;
                            FreezeIsolation(false);
                            btnPermitSave.Visible = false;
                            btnPTWCancel.Visible = false;
                            DisablePPEDetail();
                        }
                        IsIsolationComplete(txtpermitCode.Text);
                    }
                    if (PTWBasicPages.SelectedTab.Text == "Monitoring")
                    {
                        btnPermitSave.Visible = false;
                        btnPTWCancel.Visible = false;
                        btnNewLEL.Visible = false;

                        if (Permitstatus == "Prepare" || Permitstatus == "Cancelled") //if (permitValidity == 0)
                        {
                            btnPermitSave.Visible = true;
                            btnPTWCancel.Visible = true;
                            btnNewLEL.Visible = true;
                        }


                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }

        private void PTWBasicPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnPermitSave.Enabled = true;
                btnPermitSave.Visible = true;
                btnPTWCancel.Visible = true;
                if (PTWBasicPages.SelectedIndex == 0)
                {
                    //PTWBasicPages.SelectedIndex = 0;
                    SplVisibility();
                }
                if (PTWBasicPages.SelectedIndex == 1 || PTWBasicPages.SelectedIndex == 2 || PTWBasicPages.SelectedIndex == 3 || PTWBasicPages.SelectedIndex == 5)
                {
                    //PTWBasicPages.SelectedIndex = 1;
                    BasicPageMigration();
                }
                  
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }

        private void AddWorkLocationDTColumns()
        {
            WorkLocation.Columns.Add("permitCode");
            WorkLocation.Columns.Add("areaName");
            WorkLocation.Columns.Add("MachineTagNo");
            WorkLocation.Columns.Add("AreaApproverId");
            WorkLocation.Columns.Add("description");
            WorkLocation.Columns.Add("WorkType");
            WorkLocation.Columns.Add("capability");
            WorkLocation.Columns.Add("permitType");
        }
        private void timerMonitor_Tick(object sender, EventArgs e)
        {
            try
            {
                if (timerMonitor.Interval == 2000)
                {
                    bool resp = HazardMonitor.validresp;
                    if (resp == true)
                    {
                        int pointYaxis = Differpoint + lastYaxis;


                        Label lblBox = new Label();
                        lblBox.Location = new Point(4, pointYaxis);
                        lblBox.Text = HazardMonitor.hazardet;

                        TextBox tbtx = new TextBox();
                        tbtx.Size = new Size(135, 23);
                        if (grpMonitorBox1.Controls.Count > 4)
                        {
                            lblBox.Location = new Point(4, (pointYaxis + 35));
                            tbtx.Location = new Point(142, (pointYaxis + 35));
                            pointYaxis = pointYaxis + 35;
                        }
                        else
                        {
                            lblBox.Location = new Point(4, pointYaxis);
                            tbtx.Location = new Point(142, pointYaxis);
                        }
                        this.grpMonitorBox1.Controls.Add(lblBox);
                        this.grpMonitorBox1.Controls.Add(tbtx);
                        lblBox.Visible = true;
                        tbtx.Visible = true;
                        HazardMonitor.validresp = false;
                        lastYaxis = pointYaxis;
                        int finalPanelYaxis = PanelYaxis + incYaxis;
                        grpMonitorBox1.Size = new Size(grpMonitorBox1.Width, grpMonitorBox1.Height + 35);
                        PanelYaxis = finalPanelYaxis;
                        int finalButtonYaxis = ButtonYaxis + buttonIncYaxis;
                        btnNewLEL.Location = new Point(btnNewLEL.Location.X, btnNewLEL.Location.Y + 35);
                        ButtonYaxis = finalButtonYaxis;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }
        private void btnAddOthers_Click(object sender, EventArgs e)
        {
            try
            {
                int permitid = 0;
                Resources.Instance.GetMaxID("SP_GetHazardBasicPermitId", "@MaxID", ref permitid);
                int i = Resources.Instance.AddPermitOtherHazard(txtelechazard.Text, txtfirehazard.Text, txtheight.Text, txtcrushing.Text, txtvibration.Text, txtTemprature.Text, txtnoise.Text, txtradiations.Text, txtvapours.Text, txtdust.Text, txtguideline.Text, txtpermitCode.Text);

                if (i > 0)
                {
                    MessageBox.Show("Record saved Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Oops something went Wrong!..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }
        private void btnAddReq_Click(object sender, EventArgs e)
        {
            try
            {
                string loginId = Login_Form.LoginPanel.userid;

                int permitid = 0;
                Resources.Instance.GetMaxID("SP_GetHazardBasicPermitId", "@MaxID", ref permitid);
                int i = Resources.Instance.AddHazardSpecialRequirement(cmbSplReqAreaName.Text, txtactivity.Text, cmbWorkType.Text, txtdescspec.Text, 1, cmbControlType.Text, txtconsequenceHIRA.Text, txtdesccontrol.Text, txtlikelihoodHIRA.Text, cmbseverityHIRA.Text, Convert.ToInt32(loginId), txtriskHIRA.Text, TxtReqPPE.Text, 1, txtpermitCode.Text);
                if (i > 0)
                {
                    MessageBox.Show("Record saved successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Oops something went wrong!..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }
        public void ADDcolumnsToView()
        {
            viewPermit.Clear();
            viewPermit.Columns.Add("PermitCode");
            viewPermit.Columns.Add("RequestedDate");
            viewPermit.Columns.Add("RequestedBy");
            viewPermit.Columns.Add("PermitFrom");
            viewPermit.Columns.Add("PermitTo");
            // viewPermit.Columns.Add("permitCode");
            viewPermit.Columns.Add("areaName");
            viewPermit.Columns.Add("MachineTagNo");
            viewPermit.Columns.Add("AreaApproverId");
            viewPermit.Columns.Add("description");
            viewPermit.Columns.Add("WorkType");
            viewPermit.Columns.Add("capability");
            viewPermit.Columns.Add("permitType");
        }
        public void AddRowsToView()
        {
            try
            {
                DataRow newView = viewPermit.NewRow();
                newView[0] = txtpermitCode.Text;
                newView[1] = txtrequestdate.Text;
                newView[2] = txtrequestBy.Text;
                newView[3] = dtpPermitFrom.Text;
                newView[4] = dtpPermitTo.Text;
                newView[5] = cmbPtwBasicArea.Text;
                newView[6] = string.Empty;
                newView[7] = cmbApprovedBy.Text;
                newView[8] = txtdescription.Text;
                newView[9] = cmbWorkType.Text;
                newView[10] = cmbCapability.Text;
                newView[11] = Class_Operation.GlobalDeclaration.PermitType;

                viewPermit.Rows.Add(newView);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }
        private void BasicPageMigration()
        {
            try
            {
                Permitstatus = txtPermitStatus.Text;
                btnPermitSave.Enabled = true;
                btnPermitSave.Visible = true;
                btnPTWCancel.Visible = true;
                btnAddHazard.Visible = true;
                btnNewLEL.Visible = true;
                chkIsoTotStatus.Enabled = true;

                EnablePPEDetail();
                int permitValidity = Resources.Instance.GetInHousePermitValidity(txtpermitCode.Text);
                if (PTWBasicPages.SelectedTab.Tag.ToString() =="")// "View && Save")
                {
                    viewPermit.Clear();
                    viewPermit.Columns.Clear();
                    ADDcolumnsToView();
                    AddRowsToView();
                }

                else if (PTWBasicPages.SelectedTab.Tag.ToString() == "OtherHazard")
                {
                    //int permitValidity = Resources.Instance.GetInHousePermitValidity(txtpermitCode.Text);
                    //if (Permitstatus != "Closed" && Permitstatus != "Prepare")// && Permitstatus != "Cancelled")
                    if (Permitstatus != "Prepare")
                    {
                        //btnPermitSave.Enabled = false;
                        btnPermitSave.Visible = false;
                        btnPTWCancel.Visible = false;
                        btnAddHazard.Visible = false;
                        btnNewLEL.Visible = false;
                        btnPermitSave.Text = "Save";
                    }
                    

                    if (capabilitychk == true && Permitstatus == "Cancelled")
                    {
                        btnPermitSave.Text = "Save";
                        btnPermitSave.Enabled = true;
                    }

                    if (chkReadyToSubmit.Checked == true)  //if (permitValidity == 1)
                    {
                        btnPermitSave.Text = "Submit";
                        // tabControl1.TabPages.Add("tabPage3");
                    }
                    if (permitValidity == 0 && Permitstatus == "")
                    {
                        btnPermitSave.Text = "Save";
                    }

                }
                else if (PTWBasicPages.SelectedTab.Tag.ToString() == "PPERequired")
                {
                    if (Permitstatus != "Closed" && Permitstatus != "Prepare")
                    {
                        btnPermitSave.Enabled = false;
                        btnNewLEL.Visible = false;
                        btnPermitSave.Visible = false;
                        btnPTWCancel.Visible = false;
                        btnPermitSave.Text = "Save";
                        DisablePPEDetail();
                    }

                    if (capabilitychk == true && Permitstatus == "Cancelled")
                    {
                        btnPermitSave.Text = "Save";
                        btnPermitSave.Enabled = true;
                        DisablePPEDetail();
                    }
                    if (Permitstatus == "Closed")
                    {
                        btnPermitSave.Visible = false;
                        btnPTWCancel.Visible = false;
                        btnAddHazard.Visible = false;
                        btnPermitSave.Text = "Save";
                        DisablePPEDetail();
                    }

                    if (chkReadyToSubmit.Checked == true)  //if (permitValidity == 1)
                    {
                        btnPermitSave.Text = "Submit";
                        DisablePPEDetail();
                    }
                    if (permitValidity == 0 && Permitstatus == "")
                    {
                        btnPermitSave.Text = "Save";
                    }
                }
                else if (PTWBasicPages.SelectedTab.Tag.ToString() == "Isolation")
                {
                    //FreezeIsolation(false);
                    chkIsoTotStatus.Visible = false;
                    chkIsoTotStatus.Enabled = false;
                    cmbPermitCode.Text = txtpermitCode.Text;
                    cmbMachineIsolation.Text = cmbBasicMachineIsolation.Text;//cmbBasicMachineIsolation.SelectedItem.ToString();

                    if (!string.IsNullOrWhiteSpace(cmbBasicMachineIsolation.Text))//cmbBasicMachineIsolation.Text
                    {
                        ReloadConnectedMachine();
                        LoadDataToIsolationGrid(cmbPermitCode.Text);
                    }

                    if (Permitstatus == "Prepare" || Permitstatus == "Cancelled") //if (permitValidity == 0)
                    {
                        FreezeBasicIsolation();
                        if (cmbSelMachine.Items.Count > 0) chkIsolationReq.Checked = true;

                        if(dgvIsolatedMachine.Rows.Count>0)
                        {
                          int i=  (dgvIsolatedMachine.DataSource as DataTable).AsEnumerable().Where(x => x.Field<string>("PermitCode").ToString() == txtpermitCode.Text).Count();
                            if(i==0)
                            {
                                dgvIsolatedMachine.Rows.Clear();
                            }
                                
                        }
                    }
                    else if (Permitstatus == "Approved")
                    {
                        chkIsolationReq.Enabled = false;
                        FreezeIsolation(false);
                        btnPermitSave.Visible = true;
                        btnPTWCancel.Visible = true;
                        DisablePPEDetail();
                    }
                    else if (Permitstatus == "Waiting For Approval")
                    {
                        chkIsolationReq.Enabled = false;
                        FreezeIsolation(false);
                        btnPermitSave.Visible = false;
                        btnPTWCancel.Visible = false;
                        DisablePPEDetail();
                    }
                    else if (Permitstatus == "Closed")
                    {
                        chkIsolationReq.Enabled = false;
                        FreezeIsolation(false);
                        btnPermitSave.Visible = false;
                        btnPTWCancel.Visible = false;
                        DisablePPEDetail();
                    }
                    IsIsolationComplete(txtpermitCode.Text);
                }
                else if (PTWBasicPages.SelectedTab.Tag.ToString() == "Monitoring")
                {
                    btnPermitSave.Visible = false;
                    btnPTWCancel.Visible = false;
                    btnNewLEL.Visible = false;

                    if (Permitstatus == "Prepare" || Permitstatus == "Cancelled") //if (permitValidity == 0)
                    {
                        btnPermitSave.Visible = true;
                        btnPTWCancel.Visible = true;
                        btnNewLEL.Visible = true;
                    }
                }
                else if (PTWBasicPages.SelectedTab.Tag.ToString() == "SpecialRequirement")
                {
                    btnPermitSave.Enabled = true;
                    //btnPermitSave.Text = "Save";
                    btnPermitSave.Visible = false;
                    btnPTWCancel.Visible = false;
                    DisablePPEDetail();
                    if (Permitstatus == "Prepare" || Permitstatus == "Cancelled")
                    {
                        btnPermitSave.Enabled = true;
                        //btnPermitSave.Text = "Save";
                        btnPermitSave.Visible = true;
                        btnPTWCancel.Visible = true;
                        EnablePPEDetail();
                    }
                   
                }
                if (Permitstatus == "Waiting For Approval" && Properties.Settings.Default.RoleID == 7)
                {
                    btnAddHazard.Visible = false;
                    btnPermitSave.Enabled = true;
                    btnPermitSave.Visible = true;
                    btnPTWCancel.Visible = true;
                    btnPTWCancel.Visible = true;
                    btnPermitSave.Text = "Approve";
                    btnPTWCancel.Text = "Reject";
                }
                chkIsoTotStatus.Enabled = false;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }
        private void RefreshExistingForm()
        {
            cmbMachineIsolation.Items.Clear();
            cmbMachineIsolation.Text = "";
        }
        private void reset()
        {
            lblLocation2.Text = "";
            lblConnectorType2.Text = "";
            lblEquipName2.Text = "";
            chkIsolationCompl.Visible = false;
        }

       public void browseImageFile()
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    InitialDirectory = @"C:\",
                    Title = "Browse For Any Document",
                    CheckFileExists = true,
                    CheckPathExists = true,

                    //DefaultExt = "txt",
                    Filter = "Images(*.Jpeg;*.png;*.jpg;)|*.Jpeg;*.png;*.jpg;",
                    //FilterIndex = 2,
                    //RestoreDirectory = true,
                    ReadOnlyChecked = false,
                    // ShowReadOnly = true
                };

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    lblUplPath.Text = openFileDialog1.FileName;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }


        List<string> actionlist = new List<string>();
        private void PTWPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (PTWPages.SelectedIndex == 0 )
                //{
                //    PTWPages.SelectedIndex = 0;
                //    pgIndex = 0;
                //    PTWBasicPages.SelectedIndex = 0;
                //    RefreshForNewPermit();
                //}


                int permitValidity = Resources.Instance.GetInHousePermitValidity(txtpermitCode.Text);
                string empid = GlobalDeclaration._holdInfo[0].UserId.ToString();
                //if(PTWPages.SelectedTab.Text=="")
                //{
                //    PTWPages.SelectedTab.Text = "View";
                //}
                int ii = PTWPages.SelectedIndex;
                if (PTWPages.SelectedTab.Tag.ToString() == "View")
                {
                    isCheckStatus = false;
                    addStatus.Clear();
                    addStatus.Columns.Clear();
                    addStatus.Columns.Clear();
                    //AddDTColumnsToView();
                   //// string empid = GlobalDeclaration._holdInfo[0].UserId.ToString();
                    // string empid = Resources.Instance.GetEmployeeUserID(Class_Operation.GlobalDeclaration.UserName);
                    if (!String.IsNullOrEmpty(empid))
                    {
                        permitStatus = Resources.Instance.GetPermitStatuco(Convert.ToInt32(empid), 2);
                        //AddRowsToDT();
                        AddRowsToDTView(permitStatus);
                        //DBGridViewPermit.DataSource = addStatus;
                        for (int a = 0; a < DBGridViewPermit.Rows.Count; a++)
                        {
                            string status = DBGridViewPermit.Rows[a].Cells["ptwViewStatus"].Value.ToString();
                            if (status == "Cancelled")
                            {
                                DBGridViewPermit.Rows[a].DefaultCellStyle.BackColor = Color.Red;
                            }
                            else if (status == "Approved")
                            {
                                DBGridViewPermit.Rows[a].DefaultCellStyle.BackColor = Color.LightGreen;
                            }

                            else if (status == "Requested")
                            {
                                DBGridViewPermit.Rows[a].DefaultCellStyle.BackColor = Color.CadetBlue;
                            }
                            else if (status == "Waiting For Approval")
                            {
                                DBGridViewPermit.Rows[a].DefaultCellStyle.BackColor = Color.Orange;
                            }

                            else if (status == "On-Hold")
                            {
                                DBGridViewPermit.Rows[a].DefaultCellStyle.BackColor = Color.Orange;
                            }
                            else if (status == "Closed")
                            {
                                DBGridViewPermit.Rows[a].DefaultCellStyle.BackColor = Color.LightBlue;
                            }
                            else if (status == "Waiting For Supply of Materials")
                            {
                                DBGridViewPermit.Rows[a].DefaultCellStyle.BackColor = Color.Orange;
                            }
                        }

                    }

                }
                if (PTWPages.SelectedTab.Tag.ToString() == "Approval")
                {
                    addApproveStatus.Clear();
                    addApproveStatus.Columns.Clear();
                    AddDTColumnsCase();
                    ////string empid = GlobalDeclaration._holdInfo[0].UserId.ToString();// Need To change for Employee and New User Module
                    if (empid != "")
                    {
                        permitStatus = Resources.Instance.GetPermitStatuco(Convert.ToInt32(empid), 1);
                        //AddRowsToDT();
                        AddRowsToApproval(permitStatus);
                        ////DBPtwApproveGrid.DataSource = addApproveStatus;// addStatus;

                        ////    ApprovalGridEnability();
                        ////    actionlist.Add("Waiting For Approval");
                        ////    actionlist.Add("Approved");
                        ////    actionlist.Add("Cancelled");
                        ////    //actionlist.Add("Closed");

                        ////    int colCount = DBPtwApproveGrid.Columns.Count;
                        ////    for (int i = 0; i < DBPtwApproveGrid.ColumnCount; i++)
                        ////    {
                        ////        if (DBPtwApproveGrid.Columns.Contains("Action"))
                        ////        {
                        ////            DBPtwApproveGrid.Columns.Remove("Action");
                        ////        }
                        ////    }

                        ////    //  DBGridPermitList.Columns.Insert(7, cmbx);
                        ////    for (int s = 0; s < DBPtwApproveGrid.Rows.Count; s++)
                        ////    {
                        ////        DataGridViewComboBoxCell cmbx = new DataGridViewComboBoxCell();

                        ////        cmbx.Items.Clear();
                        ////        for (int a = 0; a < 3; a++)
                        ////        {
                        ////            cmbx.Items.Add(actionlist[a]);
                        ////        }
                        ////string oprtingVal = DBPtwApproveGrid.Rows[s].Cells[8].Value.ToString();
                        ////DBPtwApproveGrid[8, s] = cmbx;
                        ////DBPtwApproveGrid.Columns[8].CellTemplate.Style.BackColor = Color.White;

                        ////    }
                        ////}

                        ////if (DBPtwApproveGrid.Rows.Count == 0)
                        ////{
                        ////    btnupdate.Enabled = false;
                        ////}
                        ////else
                        ////{
                        ////    btnupdate.Enabled = true;
                        ////}
                    }
                }

                    if (PTWPages.SelectedTab.Tag.ToString() == "AllPermits")
                    {

                        //if (addApproveStatus.Rows.Count > 0) return;
                        addApproveStatus.Clear();
                        addApproveStatus.Columns.Clear();
                        AddDTColumnsCase();
                        //string empid = GlobalDeclaration._holdInfo[0].UserId.ToString();// Need To change for Employee and New User Module
                        if (empid != "")
                        {
                            permitStatus = Resources.Instance.GetPermitStatuco(Convert.ToInt32(empid), 2);
                            //AddRowsToDT();
                            dgvAllpermits.DataSource = permitStatus;
                        dgvAllpermits.Refresh();

                        }
                    }


                
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }
        string actionSelected;
        string permitcode;

        private void AddDTColumnsToView()
        {
            addStatus.Columns.Add("Permit Code");
            addStatus.Columns.Add("TypeofPermit");
            addStatus.Columns.Add("Date Requested");
            addStatus.Columns.Add("Created By");
            addStatus.Columns.Add("Area of Work");
            addStatus.Columns.Add("Description");
            addStatus.Columns.Add("Capability");
            addStatus.Columns.Add("ApprovedBy");
            addStatus.Columns.Add("Status");
            // addStatus.Columns.Add("Action");
        }
        private void ApprovalGridEnability()
        {

            DBPtwApproveGrid.Columns["Permit Code"].ReadOnly = true;
            DBPtwApproveGrid.Columns["TypeofPermit"].ReadOnly = true;
            DBPtwApproveGrid.Columns["Date Requested"].ReadOnly = true;
            DBPtwApproveGrid.Columns["Created By"].ReadOnly = true;
            DBPtwApproveGrid.Columns["Area of Work"].ReadOnly = true;
            DBPtwApproveGrid.Columns["Description"].ReadOnly = true;
            // DBGridPermitList.Columns["Status"].ReadOnly = false;
        }
        private void AddDTColumnsCase()
        {
            addApproveStatus.Columns.Add("Select", typeof(Boolean));

            addApproveStatus.Columns.Add("Permit Code");
            addApproveStatus.Columns.Add("TypeofPermit");
            addApproveStatus.Columns.Add("Date Requested");
            addApproveStatus.Columns.Add("Created By");
            addApproveStatus.Columns.Add("Assigned To");
            addApproveStatus.Columns.Add("Area of Work");
            addApproveStatus.Columns.Add("Description");
            // addStatus.Columns.Add("Capability");
            // addStatus.Columns.Add("ApprovedBy");
            addApproveStatus.Columns.Add("Status");
            // addStatus.Columns.Add("Action");
        }
        private void AddRowsToDT()
        {
            try
            {

                for (int i = 0; i < permitStatus.Rows.Count; i++)
                {
                    DataRow newDr = addApproveStatus.NewRow();
                    for (int j = 0; j < permitStatus.Columns.Count; j++)
                    {
                        newDr[j] = permitStatus.Rows[i][j];
                    }
                    addApproveStatus.Rows.Add(newDr);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }

        }
        private void AddRowsToDTView(DataTable dt)
        {
            try
            {
                //DataTable dt = itemProcurement.GetProcurement();
                if (DBGridViewPermit.Rows.Count > 0)
                    DBGridViewPermit.Rows.Clear();

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        DBGridViewPermit.Rows.Add(dr);
                        int index = DBGridViewPermit.Rows.Count - 1;
                        DBGridViewPermit.Rows[index].Cells["ptwViewPermitCode"].Value = dt.Rows[i]["Permit Code"];
                        DBGridViewPermit.Rows[index].Cells["ptwViewTypeofPermit"].Value = dt.Rows[i]["TypeofPermit"];
                        DBGridViewPermit.Rows[index].Cells["ptwViewDateRequested"].Value = dt.Rows[i]["Date Requested"].ToString();
                        DBGridViewPermit.Rows[index].Cells["ptwViewCreatedBy"].Value = dt.Rows[i]["Created By"].ToString();
                        DBGridViewPermit.Rows[index].Cells["ptwViewAreaofWork"].Value = dt.Rows[i]["Area of Work"].ToString();
                        DBGridViewPermit.Rows[index].Cells["ptwViewDescription"].Value = dt.Rows[i]["Description"];
                        DBGridViewPermit.Rows[index].Cells["ptwViewCapability"].Value = dt.Rows[i]["Capability"];
                        DBGridViewPermit.Rows[index].Cells["ptwViewApprovedBy"].Value = dt.Rows[i]["ApprovedBy"].ToString();
                        DBGridViewPermit.Rows[index].Cells["ptwViewStatus"].Value = dt.Rows[i]["Status"].ToString().ToString();
                        DBGridViewPermit.Visible = true;
                    }
                }

                DBGridViewPermit.Sort(DBGridViewPermit.Columns["ptwViewDateRequested"], ListSortDirection.Descending);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }

        }
        private void AddRowsToApproval(DataTable dt)
        {
            try
            {
                //DataTable dt = itemProcurement.GetProcurement();
                if (DBPtwApproveGrid.Rows.Count > 0)
                    DBPtwApproveGrid.Rows.Clear();

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        DBPtwApproveGrid.Rows.Add(dr);
                        int index = DBPtwApproveGrid.Rows.Count - 1;
                        DBPtwApproveGrid.Rows[index].Cells["ptwAppPermitCode"].Value = dt.Rows[i]["Permit Code"];
                        DBPtwApproveGrid.Rows[index].Cells["ptwAppTypeofPermit"].Value = dt.Rows[i]["Permit Type"];
                        DBPtwApproveGrid.Rows[index].Cells["ptwAppDateRequested"].Value = dt.Rows[i]["Date Requested"].ToString();
                        DBPtwApproveGrid.Rows[index].Cells["ptwAppCreatedBy"].Value = dt.Rows[i]["Created By"].ToString();
                        DBPtwApproveGrid.Rows[index].Cells["ptwAppAreaofWork"].Value = dt.Rows[i]["Area of Work"].ToString();
                        DBPtwApproveGrid.Rows[index].Cells["ptwAppDescription"].Value = dt.Rows[i]["Description"];
                        DBPtwApproveGrid.Rows[index].Cells["ptwAppStatus"].Value = dt.Rows[i]["Status"].ToString().ToString();
                        DBPtwApproveGrid.Visible = true;
                    }
                    DBPtwApproveGrid.Sort(DBPtwApproveGrid.Columns["ptwAppDateRequested"], ListSortDirection.Descending);
                }


            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }

        }
        private void hidePanelControls()
        {
            lblIsoLockNo.Visible = false;
            txtIsoLockNo.Visible = false;
            lblIsoPersonName.Visible = false;
            txtIsoPersonName.Visible = false;
            lblcontact2.Visible = false;
            txtIsoContact.Visible = false;
            lblupload2.Visible = false;
            btnIsoSnapUpld.Visible = false;
        }
        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                string permitcode = string.Empty;
                string actionVal = string.Empty;
                int i = 0;
                bool setmsg = false;
                if ((DBPtwApproveGrid.DataSource as DataTable).AsEnumerable().Where(a => a.Field<bool>("Select") == true).Count() == 0)
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please choose an item to update", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataTable fData = (DBPtwApproveGrid.DataSource as DataTable).AsEnumerable().Where(a => a.Field<bool>("Select") == true).CopyToDataTable();

                foreach (DataRow dr in fData.Rows)
                {
                    permitcode = dr["Permit Code"].ToString();
                    actionVal = dr["Status"].ToString();
                    if (dr["Status"].ToString() == "Waiting For Approval")
                    {
                        MessageBox.Show(string.Format("Please change status to Approved for permit [{0}]", permitcode));
                        continue;
                    }
                    {
                        i = Resources.Instance.AddPTWStatus(2, permitcode, actionVal);
                        string str = XtraInputBox.Show("", "Comments", "Write here", MessageBoxButtons.OK);
                        Resources.Instance.UpdatePTWBasicDetails(permitcode, str);
                        setmsg = true;
                    }
                }


                //if (setmsg == false)
                //{
                //    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please choose an item to update", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);

                //}
                setmsg = false;
                if (i > 0)
                {
                    MessageBox.Show("Permit Updated successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (i == -1)
                {
                    MessageBox.Show("Oops Something went wrong!..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }
        private void DBGridPermitList_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var objType = DBPtwApproveGrid.Rows[e.RowIndex].Cells[6].GetType();
                //if(objType.GetType().Name=="DataGridViewTextBoxCell")
                {
                    string valb = DBPtwApproveGrid.Rows[e.RowIndex].Cells[6].Value.ToString();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }
        void PanelOnPaint(object obj, PaintEventArgs pea)
        {
            try
            {
                ControlPaint.DrawBorder(pea.Graphics, this.pnlIsoMachine.ClientRectangle, Color.Green, ButtonBorderStyle.Solid);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }

        }
        void PanelOnPaintFalse(object obj, PaintEventArgs pea)
        {
            try
            {
                ControlPaint.DrawBorder(pea.Graphics, this.pnlIsoMachine.ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }

        }
        private void dtpPermitFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                preInit();
                SetDateValue();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }

        }
        string empId = string.Empty;
        private void cmbPtwBasicArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //cmbPtwBasicArea.Text = cmbPtwBasicArea.Texts;
               //// change on 17 oct--
               ///GetApproverFromArea(cmbPtwBasicArea.Text);
                GetApproverAll();

                //List<string> approvedBy = Resources.Instance.GetAreaApprover(cmbArea.Text);
                //string[] splArr = new string[] { };
                //splArr = approvedBy[0].Split(',');
                //if (approvedBy.Count > 0)
                //{
                //    // string[] name = new string[] { };
                //    cmbApprovedBy.Items.Clear();
                //    cmbApprovedBy.Items.Add("");
                //    for (int i = 0; i < splArr.Length; i++)
                //    {
                //        string name = splArr[i];
                //        // empId = approvedBy[1];
                //        cmbApprovedBy.Items.Add(name);
                //    }
                //}
                //else
                //{
                //    XtraMessageBox.Show(new Form { TopMost = true }, "No Record found!..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }

        private void cmbApprovedBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int indexj = cmbApprovedBy.SelectedIndex;
            //emplDetails = Resources.Instance.GetEmployeeId();
            //empId = emplDetails[indexj].emp_id.ToString();
            try
            {
                empId = Resources.Instance.GetEmployeeIdfromName(cmbApprovedBy.Text).ToString();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }

        private void cmbWorkType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    int permitid = 0;
            //    Resources.Instance.GetMaxID("SP_GetHazardBasicPermitId", "@MaxID", ref permitid);

            //    int i = Resources.Instance.AddNewHazardRequierment(lblBox.Text, txt1.Text, permitid,txtpermitCode.Text, txtMoniterNeed.Text, txtLelUelMeasure.Text);
            //    if (i > 0)
            //    {
            //        MessageBox.Show("Record saved successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Oops something went wrong!..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception Ex)
            //{
            //    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnNewLEL_Click(object sender, EventArgs e)
        {
            PermitToWork.HazardMonitor hzdmnt = new HazardMonitor();
            hzdmnt.Show();
            timerMonitor.Enabled = true;
        }
        /// <summary>
        /// /Not mapped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                string loginId = Login_Form.LoginPanel.userid;
                int permitid = 0;
                Resources.Instance.GetMaxID("SP_GetHazardBasicPermitId", "@MaxID", ref permitid);
                int i = Resources.Instance.AddHazardSpecialRequirement(cmbSplReqAreaName.Text, txtactivity.Text, cmbWorkType.Text, txtdescspec.Text, 1, cmbControlType.Text, txtconsequenceHIRA.Text, txtdesccontrol.Text, txtlikelihoodHIRA.Text, cmbseverityHIRA.Text, Convert.ToInt32(loginId), txtriskHIRA.Text, TxtReqPPE.Text, 1, txtpermitCode.Text);
                if (i > 0)
                {
                    MessageBox.Show("Record saved successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Oops something went wrong!..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }

        private void btnPermitSave_Click(object sender, EventArgs e)
        {
            try
            {
                int isoReq = UpdateIsoRequired();
                int isoComp = UpdateIsoComplete();

                if (btnPermitSave.Text == "Close" && txtPermitStatus.Text == "Approved")
                {
                    PermitClosure pmtClose = new PermitClosure();
                    pmtClose.lblPermitCode.Text = this.txtpermitCode.Text;
                    pmtClose.btnClose.Visible = true;
                    if (isoReq == 1 && isoComp == 1)
                    {
                        string mchnCode = string.Empty;
                        if (cmbBasicMachineIsolation.SelectedItem != null)
                            mchnCode = cmbBasicMachineIsolation.SelectedItem.ToString();
                        else
                            mchnCode = cmbBasicMachineIsolation.Text;
                        pmtClose.IsIsolated = true;
                        pmtClose.chkIsoTotRemoved.Checked = false;
                        pmtClose.GetMachine = mchnCode;
                        pmtClose.GetArea = cmbPtwIsolatedArea.Text;
                        DataTable isoMachine = Resources.Instance.GetMachineConnectionInfo(mchnCode);
                        pmtClose.CmbSelMAchine.DataSource = isoMachine;
                        pmtClose.CmbSelMAchine.DisplayMember = "fromconnection";
                        pmtClose.btnClose.Visible = false;
                    }
                    else
                    {
                        pmtClose.IsIsolated = false;
                    }

                    pmtClose.ClosureEvent += PmtClose_ClosureEvent;
                    if (DialogResult.OK == pmtClose.ShowDialog())
                    {
                        pmtClose.ClosureEvent += PmtClose_ClosureEvent;
                        pmtClose.Close();
                        pmtClose.Dispose();
                    }

                }
                else if ((txtPermitStatus.Text == "Prepare" || txtPermitStatus.Text == "Reject") && chkReadyToSubmit.Checked == true)
                {
                    if (IsSaved == 0) GeneratePTWId();
                    IsSaved = 1;
                    if (isoReq == 1)
                    {
                        if (isoComp == 0)
                        {
                            MessageBox.Show("Isolation not Completed!..", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                   if (!String.IsNullOrWhiteSpace(txtPtwInputComm.Text))
                    {
                        lbxPtwComments.Text = lbxPtwComments.Text + Environment.NewLine + txtPtwInputComm.Text;
                    }

                    if (ValidatePermit() == false) return;
                    SetDateValue();
                    string loginId = Login_Form.LoginPanel.userid;
                    //int empid = Resources.Instance.GetEmployeeIdfromName(cmbApprovedBy.Text);
                    int empid = 0;
                    Resources.Instance.GetUserID("SP_GetUserIDByName", cmbApprovedBy.Text, ref empid);
                    txtrequestdate.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
                    // string loggedUserId = Class_Operation.GlobalDeclaration.UserId.ToString(); // Resources.Instance.GetEmployeeUserID(Class_Operation.GlobalDeclaration.UserName);
                    int i = Resources.Instance.AddPTWBasicDetailsWithWorkLocation(txtpermitCode.Text, Convert.ToDateTime(txtrequestdate.Text).ToString("yyyy-MM-dd hh:mm"),
                        GlobalDeclaration._holdInfo[0].UserId, Convert.ToDateTime(dtpPermitFrom.Text).ToString("yyyy-MM-dd"), Convert.ToDateTime(dtpPermitTo.Text).ToString("yyyy-MM-dd"),
                        cmbFromHours.Text,cmbFromMinuts.Text,cmbToHours.Text,cmbToMinuts.Text,cmbPtwBasicArea.Text, cmbBasicMachineIsolation.Text, empid, txtdescription.Text, cmbWorkType.Text, cmbCapability.Text,
                        txtPTWBasicVendor.Text, Class_Operation.GlobalDeclaration.PermitType, txtPermitStatus.Text, isoReq, isoComp, IsSaved,lbxPtwComments.Text);
                    // inHouse update section---------------------------------------------------------
                    ////permitValidity = Resources.Instance.AddInHousePermit(StoreInhouse.dtt);
                    //Resources.Instance.UpdateInventoryQty(StoreInhouse.mctag, StoreInhouse.InHandQty);

                    // Add New Hazard section----------------------------------------------------------------------------------------------------------
                    int gi = Resources.Instance.AddNewHazardRequierment(lblBox.Text, txt1.Text, txtpermitCode.Text, txtMoniterNeed.Text, txtLelUelMeasure.Text);
                    gi = Resources.Instance.AddPermitOtherHazard(txtelechazard.Text, txtfirehazard.Text, txtheight.Text, txtcrushing.Text, txtvibration.Text, txtTemprature.Text, txtnoise.Text, txtradiations.Text, txtvapours.Text, txtdust.Text, txtguideline.Text, txtpermitCode.Text);

                    // Add special Hazard----------`
                    if (string.IsNullOrEmpty(cmbSplReqAreaName.Text)) cmbSplReqAreaName.Text = "";
                    if (string.IsNullOrEmpty(cmbControlType.Text)) cmbControlType.Text = "";
                    if (string.IsNullOrEmpty(cmbseverityHIRA.Text)) cmbseverityHIRA.Text = "";
                    gi = Resources.Instance.AddHazardSpecialRequirement(cmbSplReqAreaName.Text, txtactivity.Text, cmbWorkType.Text, txtdescspec.Text, 1, cmbControlType.Text, txtconsequenceHIRA.Text, txtdesccontrol.Text, txtlikelihoodHIRA.Text, cmbseverityHIRA.Text, Convert.ToInt32(empid), txtriskHIRA.Text, TxtReqPPE.Text, 1, txtpermitCode.Text);

                    string inhouseStatus = "Waiting For Supply of Materials";
                    if (permitValidity == 1) { int j = Resources.Instance.AddPTWStatus(1, txtpermitCode.Text, inhouseStatus); }

                    else
                    {
                        int j = Resources.Instance.AddPTWStatus(1, txtpermitCode.Text, "Waiting For Approval");
                        txtPermitStatus.Text = "Waiting For Approval";
                    }

                    //*-------------Isolation Section
                    if (isoReq == 1 && (string.IsNullOrWhiteSpace(txtIsoLockNo.Text) || string.IsNullOrWhiteSpace(txtIsoPersonName.Text) || string.IsNullOrWhiteSpace(txtIsoContact.Text)))
                    {
                        MessageBox.Show("Fill all fields in Isolation Details Section", "Alert", MessageBoxButtons.OK);
                        return;
                    }
                    foreach (DataGridViewRow dgvDr in dgvIsolatedMachine.Rows)
                    {
                        Byte[] snapByte = null;
                        if (dgvDr.Cells["ptwIsoSnapImage"].Value != null)
                        {
                            snapByte = GetByteFromImage((Image)dgvDr.Cells["ptwIsoSnapImage"].Value);
                        }
                        Resources.Instance.AddPTWIsolationDetails(dgvDr.Cells["PermitC"].Value.ToString(), System.DateTime.Now, dgvDr.Cells["Location"].Value.ToString(),
                            dgvDr.Cells["MachineName"].Value.ToString(), dgvDr.Cells["ConnectorType"].Value.ToString(), isolationchk2, dgvDr.Cells["LockNo"].Value.ToString(),
                            dgvDr.Cells["PersonName"].Value.ToString(), dgvDr.Cells["ContactNo"].Value.ToString(), dgvDr.Cells["Status"].Value.ToString(), snapByte);
                    }
                    //* PPE Required ---------
                    MapPPEToData();
                    //gi = Resources.Instance.AddPTWIsolationDetails(cmbPermitCode.Text, System.DateTime.Now, lblLocation2.Text, lblEquipName2.Text, lblConnectorType2.Text, isolationchk2, txtLockNo2.Text, txtPersoname2.Text, txtContact2.Text, lblUplPath.Text);

                    if (gi > 0)
                    {
                        MessageBox.Show("Record saved Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Oops something went Wrong!..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    ////LoadDataToIsolationGrid(cmbPermitCode.Text);
                    ////IsIsolationComplete(txtpermitCode.Text);
                    SendMailSubmitToApprovedby();

                }
                else if (txtPermitStatus.Text == "Prepare" && chkReadyToSubmit.Checked == false)
                {

                    if (IsSaved == 0) GeneratePTWId();
                    IsSaved = 1;

                    if (!String.IsNullOrWhiteSpace(txtPtwInputComm.Text))
                    {
                        lbxPtwComments.Text = lbxPtwComments.Text + Environment.NewLine + txtPtwInputComm.Text;
                    }

                    string loginId = Login_Form.LoginPanel.userid;
                    int empid = 0;

                    if (ValidatePermit() == false) return;
                    SetDateValue();
                    Resources.Instance.GetUserID("SP_GetUserIDByName", cmbApprovedBy.Text, ref empid);
                    int i = Resources.Instance.AddPTWBasicDetailsWithWorkLocation(txtpermitCode.Text, Convert.ToDateTime(txtrequestdate.Text).ToString("yyyy-MM-dd hh:mm"), GlobalDeclaration._holdInfo[0].UserId,
                        Convert.ToDateTime(dtpPermitFrom.Text).ToString("yyyy-MM-dd"), Convert.ToDateTime(dtpPermitTo.Text).ToString("yyyy-MM-dd"),
                        cmbFromHours.Text, cmbFromMinuts.Text, cmbToHours.Text, cmbToMinuts.Text, cmbPtwBasicArea.Text, cmbBasicMachineIsolation.Text, empid,
                        txtdescription.Text, cmbWorkType.Text, cmbCapability.Text, txtPTWBasicVendor.Text, Class_Operation.GlobalDeclaration.PermitType, txtPermitStatus.Text, isoReq, isoComp, IsSaved, lbxPtwComments.Text);

                    // Add New Hazard section----------------------------------------------------------------------------------------------------------
                    int gi = Resources.Instance.AddNewHazardRequierment(lblBox.Text, txt1.Text, txtpermitCode.Text, txtMoniterNeed.Text, txtLelUelMeasure.Text);
                    gi = Resources.Instance.AddPermitOtherHazard(txtelechazard.Text, txtfirehazard.Text, txtheight.Text, txtcrushing.Text, txtvibration.Text, txtTemprature.Text, txtnoise.Text, txtradiations.Text, txtvapours.Text, txtdust.Text, txtguideline.Text, txtpermitCode.Text);

                    // inHouse update section------------------------------
                    ////Resources.Instance.AddInHousePermit(pInhouseDt);
                    //Resources.Instance.UpdateInventoryQty(StoreInhouse.mctag, StoreInhouse.InHandQty);
                    pInhouseDt = null;

                    // Add special Hazard----------`
                    if (string.IsNullOrEmpty(cmbSplReqAreaName.Text)) cmbSplReqAreaName.Text = "";
                    if (string.IsNullOrEmpty(cmbControlType.Text)) cmbControlType.Text = "";
                    if (string.IsNullOrEmpty(cmbseverityHIRA.Text)) cmbseverityHIRA.Text = "";
                    gi = Resources.Instance.AddHazardSpecialRequirement(cmbSplReqAreaName.Text, txtactivity.Text, cmbWorkType.Text, txtdescspec.Text, 1, cmbControlType.Text, txtconsequenceHIRA.Text, txtdesccontrol.Text, txtlikelihoodHIRA.Text, cmbseverityHIRA.Text, Convert.ToInt32(empid), txtriskHIRA.Text, TxtReqPPE.Text, 1, txtpermitCode.Text);

                    //*-------------Isolation Section
                    if (chkIsolationReq.Checked == true && chkIsoTotStatus.Checked == false)//(string.IsNullOrWhiteSpace(txtIsoLockNo.Text) || string.IsNullOrWhiteSpace(txtIsoPersonName.Text) || string.IsNullOrWhiteSpace(txtIsoContact.Text)))
                    {
                        MessageBox.Show("Fill all fields in Isolation Details Section", "Alert", MessageBoxButtons.OK);
                        return;
                    }
                    foreach (DataGridViewRow dgvDr in dgvIsolatedMachine.Rows)
                    {
                        if (dgvDr.Cells["Status"].Value.ToString() == "Completed") isolationchk2 = 1;
                        Byte[] snapByte = null;
                        if (dgvDr.Cells["ptwIsoSnapImage"].Value != null)
                        {
                            snapByte = GetByteFromImage((Image)dgvDr.Cells["ptwIsoSnapImage"].Value);
                        }
                        Resources.Instance.AddPTWIsolationDetails(dgvDr.Cells["PermitC"].Value.ToString(), System.DateTime.Now, dgvDr.Cells["Location"].Value.ToString(),
                         dgvDr.Cells["MachineName"].Value.ToString(), dgvDr.Cells["ConnectorType"].Value.ToString(), isolationchk2, dgvDr.Cells["LockNo"].Value.ToString(),
                         dgvDr.Cells["PersonName"].Value.ToString(), dgvDr.Cells["ContactNo"].Value.ToString(), dgvDr.Cells["Status"].Value.ToString(), snapByte);

                        //else
                        //{
                        //    Resources.Instance.AddPTWIsolationDetails(dgvDr.Cells["PermitC"].Value.ToString(), System.DateTime.Now, dgvDr.Cells["Location"].Value.ToString(),
                        //    dgvDr.Cells["MachineName"].Value.ToString(), dgvDr.Cells["ConnectorType"].Value.ToString(), isolationchk2, dgvDr.Cells["LockNo"].Value.ToString(),
                        //    dgvDr.Cells["PersonName"].Value.ToString(), dgvDr.Cells["ContactNo"].Value.ToString(), dgvDr.Cells["Status"].Value.ToString(), );
                        //}
                    }


                    //* PPE Required ---------
                    MapPPEToData();

                    int j = Resources.Instance.AddPTWStatus(1, txtpermitCode.Text, txtPermitStatus.Text);
                    if (gi > 0)
                    {
                        MessageBox.Show("Record saved Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Oops something went Wrong!..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    LoadDataToIsolationGrid(cmbPermitCode.Text);
                    IsIsolationComplete(txtpermitCode.Text);
                    FreezeBasicIsolation();
                }
                else if (txtPermitStatus.Text == "Waiting For Approval")
                {
                    txtPermitStatus.Text = "Approved";
                    int gi = 0;
                    int empid = 0;

                    //Resources.Instance.GetUserID("SP_GetUserIDByName", cmbApprovedBy.Text, ref empid);
                    //int i = Resources.Instance.AddPTWBasicDetailsWithWorkLocation(txtpermitCode.Text, txtrequestdate.Text, GlobalDeclaration._holdInfo[0].UserId, dtpPermitFrom.Text, dtpPermitTo.Text, cmbPtwBasicArea.Text, cmbBasicMachineIsolation.Text, empid, txtdescription.Text, cmbWorkType.Text, cmbCapability.Text, txtPTWBasicVendor.Text, Class_Operation.GlobalDeclaration.PermitType, txtPermitStatus.Text, isoReq, isoComp, IsSaved);
                    i = Resources.Instance.AddPTWStatus(2, txtpermitCode.Text, txtPermitStatus.Text);
                    string str = XtraInputBox.Show("", "Comments", "Write here", MessageBoxButtons.OK);
                    Resources.Instance.UpdatePTWBasicDetails(txtpermitCode.Text, str);
                    SendMailApproveToRequester();

                }

                OnReload();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }
        
        private void PmtClose_ClosureEvent(params object[] objec)
        {
            txtPermitStatus.Text = objec[0].ToString();
            SendMailCloserToRequester();

        }

        private void btnPTWCancel_Click(object sender, EventArgs e)
        {
            if (txtPermitStatus.Text == "Waiting For Approval")
            {
                txtPermitStatus.Text = "Rejected";
                i = Resources.Instance.AddPTWStatus(2, txtpermitCode.Text, txtPermitStatus.Text);
                string str = XtraInputBox.Show("", "Comments", "Write here", MessageBoxButtons.OK);
                Resources.Instance.UpdatePTWBasicDetails(txtpermitCode.Text, str);
                OnReload();
                SendMailRejectToRequester();
            }
            else
            {

                PTWPages.SelectedIndex = 0;
                pgIndex = 0;
                RefreshForNewPermit();
                cleartext();
            }
        }

        private void cleartext()
        {
            txtelechazard.Text = "";
            txtfirehazard.Text = "";
            txtheight.Text = "";
            txtcrushing.Text = "";
            txtvibration.Text = "";
            txtTemprature.Text = "";
            txtnoise.Text = "";
            txtradiations.Text = "";
            txtvapours.Text = "";
            txtdust.Text = "";
            txtguideline.Text = "";

        }
        /// <summary>
        ///  No mapping found
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void chkPermit_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        //{
        //    try
        //    {
        //        this.TopMost = false;
        //        if (chkPermitType.Checked == true)
        //        {
        //            PermitToWork.PermitQuestionnaire questionnaire = new PermitQuestionnaire();
        //            questionnaire.PermitQtsEvent += Questionnaire_PermitQtsEvent;
        //            if (questionnaire.ShowDialog() == DialogResult.OK)
        //            {
        //                questionnaire.PermitQtsEvent -= Questionnaire_PermitQtsEvent;
        //            }
        //            else
        //            {
        //                questionnaire.Close();
        //            }
        //            questionnaire.Close();
        //            questionnaire.Dispose();
        //            //formObject.Add(questionnaire);
        //            // formObject.Add(Resources.Instance);
        //            //questionnaire.Show();

        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                  //Log.Error(Ex.Message);
        //    }

        //}

        private void Questionnaire_PermitQtsEvent(params object[] objec)
        {
            lblPermitTypeSelected.Text = objec[0].ToString();
        }
        /// <summary>
        /// No mapping found
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllControll_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbPtwBasicArea.SelectedText))
            {
                e.Cancel = true;
                cmbPtwBasicArea.Focus();
                ptwErrorProvider.SetError(cmbPtwBasicArea, "Area Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                ptwErrorProvider.SetError(cmbPtwBasicArea, "");
            }
            if (string.IsNullOrWhiteSpace(cmbApprovedBy.SelectedText))
            {
                e.Cancel = true;
                cmbApprovedBy.Focus();
                ptwErrorProvider.SetError(cmbApprovedBy, "Approved By should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                ptwErrorProvider.SetError(cmbApprovedBy, "");
            }
        }

        private void disablecontrols()
        {
            cmbMachineIsolation.Enabled = false;
            cmbPtwIsolatedArea.Enabled = false;
            cmbSelMachine.Enabled = false;
            pnlIsoMachine.Enabled = false;
            //panel4.Enabled = false;
        }
        private void Enablecontrols()
        {
            cmbMachineIsolation.Enabled = true;
            cmbPtwIsolatedArea.Enabled = true;
            cmbSelMachine.Enabled = true;
            pnlIsoMachine.Enabled = true;
            cmbPermitCode.Enabled = true;
            btnIsolateSave.Enabled = true;

            //panel4.Enabled = true;
        }
        private void CreatePermit_MouseHover(object sender, EventArgs e)
        {
            try
            {
                if (Class_Operation.GlobalDeclaration.PermitType != "")
                {
                    lblPermitTypeSelected.Text = Class_Operation.GlobalDeclaration.PermitType;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }
        string permitval = string.Empty;
        /// <summary>
        /// No Mapping
        /// </summary>
        /// <param name="PermitType"></param>
        public void GetPermitType(string PermitType)
        {
            try
            {
                lblPermitTypeSelected.Text = PermitType;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
            // permitval = PermitType;
        }
        /// <summary>
        /// No mapping
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreatePermit_KeyUp(object sender, KeyEventArgs e)
        {
            //if (Class_Operation.GlobalDeclaration.PermitType != "")
            //{
            //    lblPermitTypeSelected.Text = Class_Operation.GlobalDeclaration.PermitType;
            //}
            //  lblPermitTypeSelected.Text = permitval;
        }
        /// <summary>
        /// no mapping
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreatePermit_MouseMove(object sender, MouseEventArgs e)
        {
            //if (Class_Operation.GlobalDeclaration.PermitType != "")
            //{
            //    lblPermitTypeSelected.Text = Class_Operation.GlobalDeclaration.PermitType;
            //}
            // lblPermitTypeSelected.Text = permitval;
        }

        /// <summary>
        /// No Mapping
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {



            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                //Log.Error(Ex.Message);
            }
        }

        //private void chkIsolation2_CheckedChanged_1(object sender, EventArgs e)
        //{
        //    if (chkIsolationCompl.Checked == true)
        //    {
        //        lblIsoLockNo.Visible = true;
        //        txtIsoLockNo.Visible = true;
        //        lblIsoPersonName.Visible = true;
        //        txtIsoPersonName.Visible = true;
        //        lblcontact2.Visible = true;
        //        txtIsoContact.Visible = true;
        //        lblupload2.Visible = true; ;
        //        btnIsoSnapUpld.Visible = true;
        //        isolationchk2 = 1;
        //    }
        //    else
        //    {
        //        lblIsoLockNo.Visible = false;
        //        txtIsoLockNo.Visible = false;
        //        lblIsoPersonName.Visible = false;
        //        txtIsoPersonName.Visible = false;
        //        lblcontact2.Visible = false;
        //        txtIsoContact.Visible = false;
        //        lblupload2.Visible = false;
        //        btnIsoSnapUpld.Visible = false;
        //        isolationchk2 = 0;
        //    }

        //}

        /// <summary>
        /// No Mapping
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPermitCode_SelectedIndexChanged_3(object sender, EventArgs e)
        {
            cmbMachineIsolation.Text = "";
            cmbPtwIsolatedArea.Text = "";
            cmbSelMachine.Text = "";
            chkIsoTotStatus.Checked = false;
            chkIsoTotStatus.Text = "Not Completed";
            chkIsoTotStatus.ForeColor = Color.Red;
            pnlIsoMachine.Visible = false;
            LoadDataToIsolationGrid(cmbPermitCode.Text);
        }

        private void SetcmbPermitCodeDepdendents()
        {
            cmbMachineIsolation.Text = "";
            cmbPtwIsolatedArea.Text = "";
            cmbSelMachine.Text = "";
            chkIsoTotStatus.Checked = false;
            chkIsoTotStatus.Text = "Not Completed";
            chkIsoTotStatus.ForeColor = Color.Red;
            pnlIsoMachine.Visible = false;
            chkIsoTotStatus.Enabled = false;
        }
        private void SetValueTocmbPermitCode()
        {
            cmbPermitCode.Enabled = false;
            cmbPermitCode.Text = txtpermitCode.Text;
            //DataTable dt= dt = Resources.Instance.GetDataKey("Sp_FetchFunTabData", "@SysGenName", "@MCordinate", "@machinename", "@userName", "@userId", "@empCode", this.SysGenMachineNo, this.cmblocation.SelectedItem.ToString(), this.MachineName, "", 0, "");
            //cmbmachineIsolation.Text=""
            SetcmbPermitCodeDepdendents();
        }

        /// <summary>
        /// No Mapping
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbmachineIsolation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var machineLocation = Resources.Instance.MachineDt.AsEnumerable().Where(X => X.Field<string>("MachineTagNo") == cmbMachineIsolation.Text).FirstOrDefault().Field<string>("MachineLocation"); //Resources.Instance.MachineDt.AsEnumerable().Where(X => X.Field<string>("MachineTagNo") == cmbmachineIsolation.Text).FirstOrDefault().ToString();//Resources.Instance.GetMachineLocation(cmbmachineIsolation.Text);
                cmbPtwIsolatedArea.Text = machineLocation;
               // IsolationMaster = Resources.Instance.GetMachineConnectionInfo(cmbMachineIsolation.Text);
                IsolatedMAchines = Resources.Instance.GetIsolatedMachines(cmbPermitCode.Text);
              //  cmbSelMachine.DataSource = IsolationMaster;
                cmbSelMachine.DisplayMember = "fromconnection";
                cmbActivity.ValueMember = "fromconnection";
                LoadDataToIsolationGrid(cmbPermitCode.Text);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }
        /// <summary>
        /// No Mapping
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadConnectedMachine()
        {
            foreach (KeyValuePair<string, Connector> item in this._listconnt)
            {
                string KeyKey = item.Key;
                string MachineNumber = string.Empty;
                //KeyKey = RemoveIntegers(KeyKey);
                Connector sourceMachines = this._listconnt[KeyKey];
                string Conntype = string.Empty;
                var MachineName = Resources.Instance.MachineDt.AsEnumerable().Where(X => X.Field<string>("MachineTagNo") == cmbBasicMachineIsolation.Text).Distinct().ToList();
                if (sourceMachines.Connecto == MachineName[0]["MachineName"].ToString())
                {
                    if (!cmbSelMachine.Items.Contains(sourceMachines.FromData))
                        cmbSelMachine.Items.Add(sourceMachines.FromData);

                }
                else if (sourceMachines.FromData == MachineName[0]["MachineName"].ToString())
                {
                    if (!cmbSelMachine.Items.Contains(sourceMachines.Connecto))
                        cmbSelMachine.Items.Add(sourceMachines.Connecto); //strct.Split('-')[1];

                }
            }
        }
        private void CmbSelMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (CmbSelMAchine.SelectedIndex > 0)
                {
                    lblIsoTotStatus.Visible = true;
                    chkIsoTotStatus.Visible = true;
                    for (int j = 0; j < IsolatedMAchines.Rows.Count; j++)
                    {
                        if (IsolatedMAchines.Rows[j][0].ToString() == cmbSelMachine.Text)
                        {
                            //  this.InvokePaint(this, new PaintEventArgs(this.CreateGraphics(), this.DisplayRectangle));
                            pnlIsoMachine.Paint += new PaintEventHandler(PanelOnPaint);
                            //if(IsIsolationComplete()==true)
                            chkIsoTotStatus.Checked = true;
                            //else
                            //     chkFilledStatus.Checked = false;
                            chkIsoTotStatus.ForeColor = Color.Green;
                            pnlIsoMachine.Enabled = false;

                            chkIsoTotStatus.Text = "Isolation Completed";
                        }
                    }
                    if (IsolatedMAchines.Rows.Count == 0 && cmbSelMachine.Text != "N/A")
                    {
                        chkIsoTotStatus.Checked = false;
                        chkIsoTotStatus.ForeColor = Color.Red;
                        pnlIsoMachine.Enabled = true;
                        pnlIsoMachine.Paint += new PaintEventHandler(PanelOnPaintFalse);
                        chkIsoTotStatus.Text = "Not Completed";
                    }

                    if (cmbSelMachine.Text == "N/A")
                    {

                        pnlIsoMachine.Visible = false;
                        int selindex = cmbSelMachine.SelectedIndex - 1;
                        lblLocation2.Text = cmbPtwIsolatedArea.Text;
                        // lblEquipName2.Text = IsolationMaster.Rows[selindex][1].ToString();
                        // lblConnectorType2.Text = IsolationMaster.Rows[selindex][2].ToString();
                    }
                    if (cmbSelMachine.Text != "N/A")
                    {

                        pnlIsoMachine.Visible = true;
                        int selindex = cmbSelMachine.SelectedIndex;
                        if (!string.IsNullOrWhiteSpace(cmbPtwIsolatedArea.Text))
                            lblLocation2.Text = cmbPtwIsolatedArea.Text;

                        lblEquipName2.Text = IsolationMaster.Rows[selindex][1].ToString();
                        lblConnectorType2.Text = IsolationMaster.Rows[selindex][2].ToString();
                        DataTable isoDtt = GetIsolatedMachines(cmbPermitCode.Text);

                        if (isoDtt == null) return;
                        DataRow isoDr = isoDtt.AsEnumerable().SingleOrDefault(a => a.Field<string>("Machine Name") == cmbSelMachine.Text && a.Field<string>("Permit Code") == cmbPermitCode.Text);

                        if (isoDr != null)
                        {
                            chkIsolationCompl.CheckState =CheckState.Unchecked;
                            if (isoDr["Status"].ToString() == "Pending")
                            {
                                chkIsolationCompl.Checked = false;
                            }
                            else
                            {
                                chkIsolationCompl.CheckState = CheckState.Checked;
                                chkIsolationCompl.Checked = true;
                            }
                            txtIsoLockNo.Text = isoDr["Lock No"].ToString();
                            txtIsoContact.Text = isoDr["Contact No"].ToString();
                            txtIsoPersonName.Text = isoDr["Person Name"].ToString();
                            var vv = isoDr["Snapshot"].ToString();
                            if (!string.IsNullOrWhiteSpace(isoDr["Snapshot"].ToString()))
                                pcbxPTWIsoSnap.Image = GetImage(((byte[])isoDr["Snapshot"]));
                        }
                        else
                        {
                            chkIsolationCompl.CheckState = CheckState.Unchecked;
                            chkIsolationCompl.Checked = false;
                            txtIsoLockNo.Text = string.Empty;
                            txtIsoContact.Text = string.Empty;
                            txtIsoPersonName.Text = string.Empty;
                        }
                        IsIsolationComplete(txtpermitCode.Text);
                    }
                }


            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }

        private void btnIsolateSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateIsolation() == false) return;
                int count = 0;
                if (chkIsolationCompl.Checked == true)
                {
                    isolationchk2 = 1;
                }
                if (cmbSelMachine.Text == "N/A")
                {
                    isolationchk2 = 1;
                }
                int i = 0;



                var Rowsexists = dgvIsolatedMachine.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["MachineName"].Value.ToString() == lblEquipName2.Text).ToArray();//Select(r => r.Index)).First();
                if (Rowsexists.Length > 0)
                {
                    int indx = dgvIsolatedMachine.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["MachineName"].Value.ToString() == lblEquipName2.Text).FirstOrDefault().Index;
                    dgvIsolatedMachine.Rows.RemoveAt(indx);
                }
                //else if (Rowsexists.Length == 0)
                {
                    isCheckStatus = true;
                    AddRowToIsoGrid();
                    count = 1;
                }
                if (Rowsexists.Length == 0)
                {
                    MessageBox.Show("Machine Isolated successfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Rowsexists.Length > 0)
                {
                    MessageBox.Show("Machine Isolation Updated successfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ////if (string.IsNullOrWhiteSpace(txtIsoLockNo.Text) || string.IsNullOrWhiteSpace(txtIsoPersonName.Text) || string.IsNullOrWhiteSpace(txtIsoContact.Text))
                ////{
                ////    MessageBox.Show("Fill all fields in Isolation Details Section", "Alert", MessageBoxButtons.OK);
                ////    return;
                ////}

                //count = Resources.Instance.AddPTWIsolationDetails(cmbPermitCode.Text, System.DateTime.Now, lblLocation2.Text, lblEquipName2.Text, lblConnectorType2.Text , isolationchk2, txtLockNo2.Text, txtPersoname2.Text, txtContact2.Text, lblUplPath.Text);

                ////if (count > 0)
                ////{
                ////    MessageBox.Show("Record added successfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ////    isolationchk2 = 0;
                ////}
                ////else 
                ////{
                ////    MessageBox.Show("Oops something went wrong!..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ////}

                ////LoadDataToIsolationGrid(cmbPermitCode.Text);
                IsIsolationComplete(txtpermitCode.Text);
            }

            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }

        }


        private void chkIsolationReq_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkIsolationReq.Checked == false)
                {
                    //disablecontrols();
                    FreezeIsolation(false);
                }
                else if (chkIsolationReq.Checked == true)
                {
                    //Enablecontrols();
                    FreezeIsolation(true);

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }
        /// <summary>
        /// No mapping
        /// </summary>
        public void IsolationReqChecked()
        {
            try
            {
                if (chkIsolationReq.Checked == false)
                    FreezeIsolation(false);
                else
                    FreezeIsolation(true);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }

        private void btnIsoSnapUpld_Click(object sender, EventArgs e)
        {
            try
            {
                string impath = browseImageFileExt();
                if (!string.IsNullOrEmpty(impath))
                {
                    Byte[] isoSnapImage = System.IO.File.ReadAllBytes(impath);
                    pcbxPTWIsoSnap.Image = GetImage(isoSnapImage);
                }
                //browseImageFile();
                //if (lblUplPath.Text != "")
                //{
                //    string filename = System.IO.Path.GetFileName(lblUplPath.Text);
                //    uploadPath = Application.StartupPath + @"\Isolation\Download" + filename;
                //    // string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                //    if (System.IO.File.Exists(uploadPath))
                //    {
                //        MessageBox.Show("File already exist's", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //    else
                //    {
                //        System.IO.File.Copy(lblUplPath.Text, uploadPath);
                //    }
                //}
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }
        /// <summary>
        /// no mapping
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DBGridViewPermit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                Permitstatus = DBGridViewPermit.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtPermitStatus.Text = Permitstatus;
                if (e.ColumnIndex == 1 && Permitstatus == "Waiting For Supply of Materials")
                {
                    inhouseRedirect = true;
                    PermitCode = DBGridViewPermit.Rows[e.RowIndex].Cells[1].Value.ToString();
                    ////PermitToWork.PermitInHouse newInhouse = new PermitInHouse();
                    ////newInhouse.Show();

                }

                string status = DBGridViewPermit.Rows[e.RowIndex].Cells[9].Value.ToString();
                if (e.ColumnIndex == 1 && status == "Approved")
                {
                    PermitCode = DBGridViewPermit.Rows[e.RowIndex].Cells[1].Value.ToString();
                    PermitClosure closedPmt = new PermitClosure();
                    closedPmt.Show();
                }
                else
                {

                    PermitCode = DBGridViewPermit.Rows[e.RowIndex].Cells[1].Value.ToString();
                    // this.Close();
                    // CreatePermit npmt = new CreatePermit();

                    var frm = Application.OpenForms.Cast<Form>().Where(x => x.Name == "CreatePermit").FirstOrDefault();
                    if (null != frm)
                    {
                        isredirected = true;
                        PTWPages.SelectedTab = PTWPages.TabPages[0];
                        PTWBasicPages.SelectedTab = PTWBasicPages.TabPages[0];
                        this.PTWPages.SelectedTab = pgNewPermit;
                        //this.tabControl2.SelectedTab = tabPage4;
                        // tabControl1.TabPages.Add("tabClosure");
                        frm.Show();
                        OnReload();
                    }
                }
                //BasicPageMigration();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }

        private void OnReloadOLD()
        {
            try
            {
                btnPermitSave.Visible = true;
                lbxPtwComments.Enabled = true;
                DataTable PTWAllData = Resources.Instance.GetAllPTWData(PermitCode);//Change by RP no Need to declare New DataTable Here
                if (PTWAllData.Rows.Count == 0) return;
                ////txtpermitCode.ReadOnly = false;
                txtpermitCode.Text = PTWAllData.Rows[0]["permitCode"].ToString();
                cmbPermitCode.Text = PTWAllData.Rows[0]["permitCode"].ToString();
                txtPermitStatus.Text = PTWAllData.Rows[0]["ActualStatus"].ToString();
               
                string dtpDurFrom = PTWAllData.Rows[0]["durationFrom"].ToString();
                string dtpDurTo = PTWAllData.Rows[0]["durationTo"].ToString();
                if (!string.IsNullOrWhiteSpace(dtpDurFrom) && !string.IsNullOrWhiteSpace(dtpDurTo))
                {
                    DateTime datefrom = Convert.ToDateTime(dtpDurFrom);
                    DateTime dateTo = DateTime.Parse(dtpDurTo);
                    dtpPermitFrom.Text = DateTime.Parse(dtpDurFrom).ToString("dd-MM-yyyy");
                    dtpPermitTo.Text = DateTime.Parse(dtpDurTo).ToString("dd-MM-yyyy");
                }
                dtpPermitFrom.Format = DateTimePickerFormat.Custom;
                dtpPermitFrom.CustomFormat = "dd-MM-yyyy";
                dtpPermitTo.Format = DateTimePickerFormat.Custom;
                dtpPermitTo.CustomFormat = "dd-MM-yyyy";

                cmbFromHours.Text = PTWAllData.Rows[0]["FromHours"].ToString();
                cmbFromMinuts.Text = PTWAllData.Rows[0]["FromMinuts"].ToString();
                cmbToHours.Text = PTWAllData.Rows[0]["ToHours"].ToString();
                cmbToMinuts.Text = PTWAllData.Rows[0]["ToMinuts"].ToString();
                SetDateValue();
                string ss = PTWAllData.Rows[0]["RequestedTime"].ToString();
                txtrequestdate.Text =Convert.ToDateTime(PTWAllData.Rows[0]["RequestedTime"].ToString()).ToString("dd-MM-yyyy HH:mm");
                int uid = Convert.ToInt32(PTWAllData.Rows[0]["RequestedBy"].ToString());
                //string empname = Resources.Instance.GetEmployeeNameByEmpiId(uid);
                txtrequestBy.Text = LoadAllUsers.AsEnumerable().Where(a=>a.Field<string>("UserID")== PTWAllData.Rows[0]["RequestedBy"].ToString()).ToList().FirstOrDefault().Field<string>("UserName");
                //string empname = HindalcoiOS.Class_Operation.GlobalDeclaration.UserName;
                ////txtrequestBy.Text = empname;
                cmbPtwBasicArea.Text = PTWAllData.Rows[0]["areaName"].ToString();
                string sss = PTWAllData.Rows[0]["AreaApproverId"].ToString();
                int appId;
                string empname1 = string.Empty;

                cmbApprovedBy.Text = PTWAllData.Rows[0]["ApproverName"].ToString(); // empname1;
                cmbWorkType.Text = PTWAllData.Rows[0]["WorkType"].ToString();
                capabilitychk = true;
                cmbCapability.Text = PTWAllData.Rows[0]["capability"].ToString();
                txtPTWBasicVendor.Text = PTWAllData.Rows[0]["Vendor"].ToString();
                int lcnt = PTWAllData.Columns.Count;
                lblPermitTypeSelected.Text = PTWAllData.Rows[0]["permitType"].ToString();
                txtdescription.Text = PTWAllData.Rows[0]["wklocDescrip"].ToString();
                txtMoniterNeed.Text = PTWAllData.Rows[0]["MoniterNeed"].ToString();
                txtLelUelMeasure.Text = PTWAllData.Rows[0]["Lelmeasure"].ToString();
                txtelechazard.Text = PTWAllData.Rows[0]["electricalHazard"].ToString();
                txtfirehazard.Text = PTWAllData.Rows[0]["fireHazard"].ToString();
                txtheight.Text = PTWAllData.Rows[0]["fallFromHeight"].ToString();
                txtcrushing.Text = PTWAllData.Rows[0]["crushing"].ToString();
                txtvibration.Text = PTWAllData.Rows[0]["vibration"].ToString();
                txtTemprature.Text = PTWAllData.Rows[0]["ambientemprature"].ToString();
                txtnoise.Text = PTWAllData.Rows[0]["noise"].ToString();
                txtradiations.Text = PTWAllData.Rows[0]["radiations"].ToString();
                txtvapours.Text = PTWAllData.Rows[0]["vapours"].ToString();
                txtdust.Text = PTWAllData.Rows[0]["dust"].ToString();
                txtguideline.Text = PTWAllData.Rows[0]["safetyGuideline"].ToString();
                IsSaved = int.Parse(PTWAllData.Rows[0]["IsSaved"].ToString());
                cmbSplReqAreaName.Text = PTWAllData.Rows[0]["areaName"].ToString();
                txtactivity.Text = PTWAllData.Rows[0]["Activity"].ToString();
                cmbActivity.Text = PTWAllData.Rows[0]["typeOfWork"].ToString();
                txtdescspec.Text = PTWAllData.Rows[0]["safetyGuideline"].ToString();
                //txtconsequence.Text= PTWAllData.Rows[0][21].ToString();
                //txtlikelihoodNoHira.Text= PTWAllData.Rows[0][21].ToString();
                //cmbSeverity.Text= PTWAllData.Rows[0][21].ToString();
                txtRiskNoHira.Text = PTWAllData.Rows[0]["HIRANoControl"].ToString();
                cmbControlType.Text = PTWAllData.Rows[0]["TypeOfControl"].ToString();
                txtconsequenceHIRA.Text = PTWAllData.Rows[0]["consequence"].ToString();
                txtdesccontrol.Text = PTWAllData.Rows[0]["describeControls"].ToString();
                txtlikelihoodHIRA.Text = PTWAllData.Rows[0]["likelihood"].ToString();
                cmbseverityHIRA.Text = PTWAllData.Rows[0]["severity"].ToString();
                txtOwnerId.Text = PTWAllData.Rows[0]["ownerId"].ToString();
                txtriskHIRA.Text = PTWAllData.Rows[0]["riskRating"].ToString();
                TxtReqPPE.Text = PTWAllData.Rows[0]["PPERequired"].ToString();
                cmbBasicMachineIsolation.Text = PTWAllData.Rows[0]["BasicMachineTagNo"].ToString();

                if (PTWAllData.Rows[0]["IsIsolationRequired"].ToString() == "1")
                    chkIsolationReq.Checked = true;
                else if (PTWAllData.Rows[0]["IsIsolationRequired"].ToString() == "0")
                    chkIsolationReq.Checked = false;

                //EnableOrDisableIsolation(chkIsolationReq.Checked);

                chkIsoTotStatus.Enabled = true;
                if (PTWAllData.Rows[0]["IsIsolationComplete"].ToString() == "1")
                    chkIsoTotStatus.Checked = true;
                else if (PTWAllData.Rows[0]["IsIsolationComplete"].ToString() == "0")
                    chkIsoTotStatus.Checked = false;
                chkIsoTotStatus.Enabled = false;
                lbxPtwComments.Items.Clear();
                txtPtwInputComm.Text = string.Empty;// Clear();
                foreach (string comment in PTWAllData.Rows[0]["comments"].ToString().Split(','))
                {
                    lbxPtwComments.Items.Add(comment + Environment.NewLine);
                }
                DataTable ppeDt = Resources.Instance.GetPPERequired(txtpermitCode.Text);
                MapPPEToView(ppeDt);
                ViewAddHazard(txtpermitCode.Text);
                CheckRedirected();

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }

        PrintPermit prtPermit=null;
        private void OnReload()
        {
            try
            {
                btnPermitSave.Visible = true;
                lbxPtwComments.Enabled = true;
                DataTable PTWAllData = Resources.Instance.GetAllPTWData(PermitCode);//Change by RP no Need to declare New DataTable Here
                if (PTWAllData.Rows.Count == 0) return;
                
                prtPermit = new PrintPermit();
                ////txtpermitCode.ReadOnly = false;
                txtpermitCode.Text = prtPermit.PermitCode=PTWAllData.Rows[0]["permitCode"].ToString();
                cmbPermitCode.Text = PTWAllData.Rows[0]["permitCode"].ToString();
                txtPermitStatus.Text = prtPermit.PermitStatus=PTWAllData.Rows[0]["ActualStatus"].ToString();

                string dtpDurFrom = prtPermit.dtpDurFrom = PTWAllData.Rows[0]["durationFrom"].ToString();
                string dtpDurTo = prtPermit.dtpDurTo = PTWAllData.Rows[0]["durationTo"].ToString();
                if (!string.IsNullOrWhiteSpace(dtpDurFrom) && !string.IsNullOrWhiteSpace(dtpDurTo))
                {
                    DateTime datefrom = Convert.ToDateTime(dtpDurFrom);
                    DateTime dateTo = DateTime.Parse(dtpDurTo);
                    dtpPermitFrom.Text =  DateTime.Parse(dtpDurFrom).ToString("dd-MM-yyyy");
                    dtpPermitTo.Text = DateTime.Parse(dtpDurTo).ToString("dd-MM-yyyy");
                }
                dtpPermitFrom.Format = DateTimePickerFormat.Custom;
                dtpPermitFrom.CustomFormat = "dd-MM-yyyy";
                dtpPermitTo.Format = DateTimePickerFormat.Custom;
                dtpPermitTo.CustomFormat = "dd-MM-yyyy";

                cmbFromHours.Text = PTWAllData.Rows[0]["FromHours"].ToString();
                cmbFromMinuts.Text = PTWAllData.Rows[0]["FromMinuts"].ToString();

                cmbToHours.Text = PTWAllData.Rows[0]["ToHours"].ToString();
                cmbToMinuts.Text = PTWAllData.Rows[0]["ToMinuts"].ToString();

                SetDateValue();
                string ss = PTWAllData.Rows[0]["RequestedTime"].ToString();
                txtrequestdate.Text = prtPermit.Requestdate= Convert.ToDateTime(PTWAllData.Rows[0]["RequestedTime"].ToString()).ToString("dd-MM-yyyy HH:mm");
                int uid = Convert.ToInt32(PTWAllData.Rows[0]["RequestedBy"].ToString());
                //string empname = Resources.Instance.GetEmployeeNameByEmpiId(uid);
                txtrequestBy.Text = prtPermit.RequestBy= LoadAllUsers.AsEnumerable().Where(a => a.Field<string>("UserID") == PTWAllData.Rows[0]["RequestedBy"].ToString()).ToList().FirstOrDefault().Field<string>("UserName");
                //string empname = HindalcoiOS.Class_Operation.GlobalDeclaration.UserName;
                ////txtrequestBy.Text = empname;
                cmbPtwBasicArea.Text = prtPermit.BasicArea= PTWAllData.Rows[0]["areaName"].ToString();
                string sss = PTWAllData.Rows[0]["AreaApproverId"].ToString();
                int appId;
                string empname1 = string.Empty;

                cmbApprovedBy.Text = prtPermit.ApprovedBy= PTWAllData.Rows[0]["ApproverName"].ToString(); // empname1;
                cmbWorkType.Text = prtPermit.WorkType= PTWAllData.Rows[0]["WorkType"].ToString();
                capabilitychk = true;
                cmbCapability.Text = prtPermit.Capability=PTWAllData.Rows[0]["capability"].ToString();
                txtPTWBasicVendor.Text = prtPermit.BasicVendor= PTWAllData.Rows[0]["Vendor"].ToString();
                int lcnt = PTWAllData.Columns.Count;
                lblPermitTypeSelected.Text = prtPermit.PermitTypeSelected= PTWAllData.Rows[0]["permitType"].ToString();
                txtdescription.Text =  prtPermit.Description= PTWAllData.Rows[0]["wklocDescrip"].ToString();
                txtMoniterNeed.Text = prtPermit.MoniterNeed= PTWAllData.Rows[0]["MoniterNeed"].ToString();
                txtLelUelMeasure.Text = prtPermit.LelUelMeasure= PTWAllData.Rows[0]["Lelmeasure"].ToString();
                txtelechazard.Text =  PTWAllData.Rows[0]["electricalHazard"].ToString();
                txtfirehazard.Text = prtPermit.Firehazard= PTWAllData.Rows[0]["fireHazard"].ToString();
                txtheight.Text =  PTWAllData.Rows[0]["fallFromHeight"].ToString();
                txtcrushing.Text = prtPermit.Crushing= PTWAllData.Rows[0]["crushing"].ToString();
                txtvibration.Text = prtPermit.Vibration=PTWAllData.Rows[0]["vibration"].ToString();
                txtTemprature.Text = prtPermit.Temprature=PTWAllData.Rows[0]["ambientemprature"].ToString();
                txtnoise.Text = prtPermit.Noise= PTWAllData.Rows[0]["noise"].ToString();
                txtradiations.Text = prtPermit.Radiations= PTWAllData.Rows[0]["radiations"].ToString();
                txtvapours.Text = prtPermit.Vapours=PTWAllData.Rows[0]["vapours"].ToString();
                txtdust.Text = prtPermit.Dust= PTWAllData.Rows[0]["dust"].ToString();
                txtguideline.Text = prtPermit.Guideline= PTWAllData.Rows[0]["safetyGuideline"].ToString();
                IsSaved = int.Parse(PTWAllData.Rows[0]["IsSaved"].ToString());
                cmbSplReqAreaName.Text = prtPermit.SplReqAreaName=PTWAllData.Rows[0]["areaName"].ToString();
                txtactivity.Text = prtPermit.cmbActivity=PTWAllData.Rows[0]["Activity"].ToString();
                cmbActivity.Text = PTWAllData.Rows[0]["typeOfWork"].ToString();
                txtdescspec.Text = prtPermit.Descspec= PTWAllData.Rows[0]["safetyGuideline"].ToString();
                //txtconsequence.Text= PTWAllData.Rows[0][21].ToString();
                //txtlikelihoodNoHira.Text= PTWAllData.Rows[0][21].ToString();
                //cmbSeverity.Text= PTWAllData.Rows[0][21].ToString();
                txtRiskNoHira.Text = prtPermit.RiskNoHira= PTWAllData.Rows[0]["HIRANoControl"].ToString();
                cmbControlType.Text = prtPermit.ControlType= PTWAllData.Rows[0]["TypeOfControl"].ToString();
                txtconsequenceHIRA.Text = prtPermit.ConsequenceHIRA= PTWAllData.Rows[0]["consequence"].ToString();
                txtdesccontrol.Text = PTWAllData.Rows[0]["describeControls"].ToString();
                txtlikelihoodHIRA.Text = prtPermit.LikelihoodHIRA= PTWAllData.Rows[0]["likelihood"].ToString();
                cmbseverityHIRA.Text = prtPermit.SeverityHIRA= PTWAllData.Rows[0]["severity"].ToString();
                txtOwnerId.Text = prtPermit.OwnerId= PTWAllData.Rows[0]["ownerId"].ToString();
                txtriskHIRA.Text = PTWAllData.Rows[0]["riskRating"].ToString();
                TxtReqPPE.Text = prtPermit.ReqPPE= PTWAllData.Rows[0]["PPERequired"].ToString();
                cmbBasicMachineIsolation.Text = PTWAllData.Rows[0]["BasicMachineTagNo"].ToString();

                if (PTWAllData.Rows[0]["IsIsolationRequired"].ToString() == "1")
                    chkIsolationReq.Checked = true;
                else if (PTWAllData.Rows[0]["IsIsolationRequired"].ToString() == "0")
                    chkIsolationReq.Checked = false;

                //EnableOrDisableIsolation(chkIsolationReq.Checked);

                chkIsoTotStatus.Enabled = true;
                if (PTWAllData.Rows[0]["IsIsolationComplete"].ToString() == "1")
                    chkIsoTotStatus.Checked = true;
                else if (PTWAllData.Rows[0]["IsIsolationComplete"].ToString() == "0")
                    chkIsoTotStatus.Checked = false;
                chkIsoTotStatus.Enabled = false;
                lbxPtwComments.Items.Clear();
                txtPtwInputComm.Text = string.Empty;// Clear();
                foreach (string comment in PTWAllData.Rows[0]["comments"].ToString().Split(','))
                {
                    lbxPtwComments.Items.Add(comment + Environment.NewLine);
                }
                prtPermit.PtwComments = lbxPtwComments.Text;
                DataTable ppeDt = Resources.Instance.GetPPERequired(txtpermitCode.Text);
                MapPPEToView(ppeDt);
                ViewAddHazard(txtpermitCode.Text);
                CheckRedirected();
               //// XtraReport3 dd = new XtraReport3();
               ////// dd.DesignerLoaded += Dd_DesignerLoaded;
               //// dd.RequestParameters = true;
               //// DevExpress.XtraReports.Parameters.Parameter pmm = new DevExpress.XtraReports.Parameters.Parameter();
               //// pmm.Value = txtpermitCode.Text;
               //// dd.Parameters.Add(pmm);
               //// dd.DataSource = prtPermit;
               //// dd.ExportToPdf(@"D:\DDBBCKP\Permit.pdf");


            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }

        //private void Dd_DesignerLoaded(object sender, DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs e)
        //{
        //    //DevExpress.XtraReports.Parameters.Parameter pmm = new DevExpress.XtraReports.Parameters.Parameter();
        //    //pmm.Value = txtpermitCode.Text;
        //    //dd.Parameters.Add(pmm);
        //    //dd.DataSource = prtPermit;
        //    //dd.ExportToPdf(@"D:\DDBBCKP\Permit.pdf");
        //}

        //XtraReport1 dd;
        public void OnReload(string permitCode)
        {
            try
            {
                btnPermitSave.Visible = true;

                DataTable PTWAllData = Resources.Instance.GetAllPTWData(permitCode);//Change by RP no Need to declare New DataTable Here
                ////txtpermitCode.ReadOnly = false;
                txtpermitCode.Text = PTWAllData.Rows[0]["permitCode"].ToString(); //PTWAllData.Rows[0][1].ToString();
                cmbPermitCode.Text = PTWAllData.Rows[0]["permitCode"].ToString();
                txtPermitStatus.Text = PTWAllData.Rows[0]["ActualStatus"].ToString();
                dtpPermitFrom.Format = DateTimePickerFormat.Custom;
                dtpPermitFrom.CustomFormat = "dd-MM-yyyy hh:mm";// "MM-dd-yyyy hh:mm:ss tt";
                dtpPermitTo.Format = DateTimePickerFormat.Custom;
                dtpPermitTo.CustomFormat = "dd-MM-yyyy hh:mm";
                string dtpv = PTWAllData.Rows[0]["durationFrom"].ToString(); //PTWAllData.Rows[0][4].ToString();
                string dtpv1 = PTWAllData.Rows[0]["durationTo"].ToString();// PTWAllData.Rows[0][5].ToString();
                if (!string.IsNullOrWhiteSpace(dtpv) && !string.IsNullOrWhiteSpace(dtpv1))
                {
                    DateTime datefrom = DateTime.Parse(dtpv);//, "dd-MM-yyyy hh:mm", null);
                    DateTime dateTo = DateTime.Parse(dtpv1);//, "dd-MM-yyyy hh:mm", null);
                    dtpPermitFrom.Text = datefrom.ToString();
                    dtpPermitTo.Text = dateTo.ToString();
                }
                txtrequestdate.Text = PTWAllData.Rows[0]["RequestedTime"].ToString(); //PTWAllData.Rows[0][2].ToString();
                int uid = Convert.ToInt32(PTWAllData.Rows[0]["RequestedBy"].ToString());// Convert.ToInt32(PTWAllData.Rows[0][3].ToString());
                // string empname = Resources.Instance.GetEmployeeNameByEmpiId(uid);
                string empname = HindalcoiOS.Class_Operation.GlobalDeclaration.UserName;
                txtrequestBy.Text = empname;
                cmbPtwBasicArea.Text = PTWAllData.Rows[0]["areaName"].ToString();// PTWAllData.Rows[0][41].ToString();
                int appId = Convert.ToInt32(PTWAllData.Rows[0]["AreaApproverId"].ToString()); //Convert.ToInt32(PTWAllData.Rows[0][43].ToString());
                string empname1 = Resources.Instance.GetEmployeeNameByEmpiId(appId);
                cmbApprovedBy.Text = empname1;
                cmbWorkType.Text = PTWAllData.Rows[0]["WorkType"].ToString(); //PTWAllData.Rows[0][45].ToString();
                capabilitychk = true;
                cmbCapability.Text = PTWAllData.Rows[0]["capability"].ToString(); //PTWAllData.Rows[0][46].ToString();
                int lcnt = PTWAllData.Columns.Count;
                lblPermitTypeSelected.Text = PTWAllData.Rows[0]["permitType"].ToString();// PTWAllData.Rows[0][47].ToString();
                txtdescription.Text = PTWAllData.Rows[0]["wklocDescrip"].ToString(); //PTWAllData.Rows[0][42].ToString();
                txtMoniterNeed.Text = PTWAllData.Rows[0]["MoniterNeed"].ToString();// PTWAllData.Rows[0][7].ToString();
                txtLelUelMeasure.Text = PTWAllData.Rows[0]["Lelmeasure"].ToString(); //PTWAllData.Rows[0][8].ToString();
                txtelechazard.Text = PTWAllData.Rows[0]["electricalHazard"].ToString();// PTWAllData.Rows[0][11].ToString();
                txtfirehazard.Text = PTWAllData.Rows[0]["fireHazard"].ToString(); //PTWAllData.Rows[0][12].ToString();
                txtheight.Text = PTWAllData.Rows[0]["fallFromHeight"].ToString();// PTWAllData.Rows[0][13].ToString();
                txtcrushing.Text = PTWAllData.Rows[0]["crushing"].ToString(); //PTWAllData.Rows[0][14].ToString();
                txtvibration.Text = PTWAllData.Rows[0]["vibration"].ToString(); //PTWAllData.Rows[0][15].ToString();
                txtTemprature.Text = PTWAllData.Rows[0]["ambientemprature"].ToString(); //PTWAllData.Rows[0][16].ToString();
                txtnoise.Text = PTWAllData.Rows[0]["noise"].ToString(); //PTWAllData.Rows[0][17].ToString();
                txtradiations.Text = PTWAllData.Rows[0]["radiations"].ToString();// PTWAllData.Rows[0][18].ToString();
                txtvapours.Text = PTWAllData.Rows[0]["vapours"].ToString(); //PTWAllData.Rows[0][19].ToString();
                txtdust.Text = PTWAllData.Rows[0]["dust"].ToString(); //PTWAllData.Rows[0][20].ToString();
                txtguideline.Text = PTWAllData.Rows[0]["safetyGuideline"].ToString(); //PTWAllData.Rows[0][21].ToString();

                cmbSplReqAreaName.Text = PTWAllData.Rows[0]["area"].ToString(); //PTWAllData.Rows[0][24].ToString();
                txtactivity.Text = PTWAllData.Rows[0]["activity"].ToString();// PTWAllData.Rows[0][25].ToString();
                cmbActivity.Text = PTWAllData.Rows[0]["typeOfWork"].ToString(); //PTWAllData.Rows[0][26].ToString();
                txtdescspec.Text = PTWAllData.Rows[0]["safetyGuideline"].ToString();// PTWAllData.Rows[0][21].ToString();
                //txtconsequence.Text= PTWAllData.Rows[0][21].ToString();
                //txtlikelihoodNoHira.Text= PTWAllData.Rows[0][21].ToString();
                //cmbSeverity.Text= PTWAllData.Rows[0][21].ToString();
                txtRiskNoHira.Text = PTWAllData.Rows[0]["HIRANoControl"].ToString(); //PTWAllData.Rows[0][28].ToString();
                cmbControlType.Text = PTWAllData.Rows[0]["TypeOfControl"].ToString();// PTWAllData.Rows[0][29].ToString();
                txtconsequenceHIRA.Text = PTWAllData.Rows[0]["consequence"].ToString(); //PTWAllData.Rows[0][30].ToString();
                txtdesccontrol.Text = PTWAllData.Rows[0]["describeControls"].ToString();// PTWAllData.Rows[0][31].ToString();
                txtlikelihoodHIRA.Text = PTWAllData.Rows[0]["likelihood"].ToString();// PTWAllData.Rows[0][32].ToString();
                cmbseverityHIRA.Text = PTWAllData.Rows[0]["severity"].ToString();// PTWAllData.Rows[0][33].ToString();
                txtOwnerId.Text = PTWAllData.Rows[0]["ownerId"].ToString();// PTWAllData.Rows[0][34].ToString();
                txtriskHIRA.Text = PTWAllData.Rows[0]["riskRating"].ToString();// PTWAllData.Rows[0][35].ToString();
                TxtReqPPE.Text = PTWAllData.Rows[0]["PPERequired"].ToString(); //PTWAllData.Rows[0][36].ToString();
                //TxtReqPPE.Text = PTWAllData.Rows[0]["PPERequired"].ToString();
                cmbBasicMachineIsolation.Text = PTWAllData.Rows[0]["BasicMachineTagNo"].ToString();
                //cmbBasicMachineIsolation.SelectedItem = PTWAllData.Rows[0]["BasicMachineTagNo"].ToString();
                if (PTWAllData.Rows[0]["IsIsolationRequired"].ToString() == "1")
                    chkIsolationReq.Checked = true;
                else if (PTWAllData.Rows[0]["IsIsolationRequired"].ToString() == "0")
                    chkIsolationReq.Checked = false;
                if (PTWAllData.Rows[0]["IsIsolationComplete"].ToString() == "1")
                    chkIsoTotStatus.Checked = true;
                else if (PTWAllData.Rows[0]["IsIsolationComplete"].ToString() == "0")
                    chkIsoTotStatus.Checked = false;
                lbxPtwComments.Items.Clear();
                foreach (string comment in PTWAllData.Rows[0]["comments"].ToString().Split(','))
                {
                    lbxPtwComments.Items.Add(comment + Environment.NewLine);
                }


                CheckRedirected();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }

        private void ClearAllPTW()
        {
            try
            {
                btnPermitSave.Visible = true;
                lbxPtwComments.Enabled = true;
                // DataTable PTWAllData = Resources.Instance.GetAllPTWData(PermitCode);//Change by RP no Need to declare New DataTable Here
                ////txtpermitCode.ReadOnly = false;
                cmbPermitCode.Text = string.Empty;
                dtpPermitFrom.Format = DateTimePickerFormat.Custom;
                dtpPermitFrom.CustomFormat = "dd-MM-yyyy";
                dtpPermitTo.Format = DateTimePickerFormat.Custom;
                dtpPermitTo.CustomFormat = "dd-MM-yyyy";
                txtrequestdate.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm");

                string empname = HindalcoiOS.Class_Operation.GlobalDeclaration.UserName;
                txtrequestBy.Text = empname;
                cmbPtwBasicArea.Text = string.Empty;
                txtPTWDsgn.Text = string.Empty;
                chkReadyToSubmit.Checked = false;

                cmbApprovedBy.Text = string.Empty;
                cmbWorkType.Text = string.Empty;
                capabilitychk = true;
                cmbCapability.Text = string.Empty;
                txtPTWBasicVendor.Text = string.Empty;
                lblPermitTypeSelected.Text = string.Empty;
                txtdescription.Text = string.Empty;
                txtMoniterNeed.Text = string.Empty;
                txtLelUelMeasure.Text = string.Empty;
                txtelechazard.Text = string.Empty;
                txtfirehazard.Text = string.Empty;
                txtheight.Text = string.Empty;
                txtcrushing.Text = string.Empty;
                txtvibration.Text = string.Empty;
                txtTemprature.Text = string.Empty;
                txtnoise.Text = string.Empty;
                txtradiations.Text = string.Empty;
                txtvapours.Text = string.Empty;
                txtdust.Text = string.Empty;
                txtguideline.Text = string.Empty;

                cmbSplReqAreaName.Text = string.Empty;
                txtactivity.Text = string.Empty;
                cmbActivity.Text = string.Empty;
                txtdescspec.Text = string.Empty;
                //txtconsequence.Text= PTWAllData.Rows[0][21].ToString();
                //txtlikelihoodNoHira.Text= PTWAllData.Rows[0][21].ToString();
                //cmbSeverity.Text= PTWAllData.Rows[0][21].ToString();
                txtRiskNoHira.Text = string.Empty;
                cmbControlType.Text = string.Empty;
                txtconsequenceHIRA.Text = string.Empty;
                txtdesccontrol.Text = string.Empty;
                txtlikelihoodHIRA.Text = string.Empty;
                cmbseverityHIRA.Text = string.Empty;
                txtOwnerId.Text = string.Empty;
                txtriskHIRA.Text = string.Empty;
                TxtReqPPE.Text = string.Empty;
                //TxtReqPPE.Text = PTWAllData.Rows[0]["PPERequired"].ToString();
                //cmbBasicMachineIsolation.Text = PTWAllData.Rows[0]["BasicMachineTagNo"].ToString();
                cmbBasicMachineIsolation.Text = string.Empty;
                chkIsoTotStatus.Enabled = false;
                lbxPtwComments.Items.Clear();
                if (dgvIsolatedMachine.Rows.Count > 0)
                {
                    //int i = (dgvIsolatedMachine.DataSource as DataTable).AsEnumerable().Where(x => x.Field<string>("PermitCode").ToString() == txtpermitCode.Text).Count();
                    //if (i == 0)
                    {
                        dgvIsolatedMachine.Rows.Clear();
                    }

                }

                CheckRedirected();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public bool CallingLocation = false;

        private void CheckRedirected()
        {
            try
            {
                if (isredirected == true && (txtPermitStatus.Text != "Cancelled" && txtPermitStatus.Text != "Prepare" && txtPermitStatus.Text != "Reject"))
                {
                    cmbSplReqAreaName.Enabled = false;
                    chkPermitType.Enabled = false;
                    txtactivity.Enabled = false;
                    cmbActivity.Enabled = false;
                    txtdescspec.Enabled = false;
                    txtconsequence.Enabled = false;
                    txtlikelihoodNoHira.Enabled = false;
                    cmbSeverity.Enabled = false;
                    txtRiskNoHira.Enabled = false;
                    cmbControlType.Enabled = false;
                    txtconsequenceHIRA.Enabled = false;
                    txtdesccontrol.Enabled = false;
                    txtlikelihoodHIRA.Enabled = false;
                    cmbseverityHIRA.Enabled = false;
                    txtOwnerId.Enabled = false;
                    txtriskHIRA.Enabled = false;
                    TxtReqPPE.Enabled = false;
                    txtelechazard.Enabled = false;
                    txtfirehazard.Enabled = false;
                    txtheight.Enabled = false;
                    txtcrushing.Enabled = false;
                    txtvibration.Enabled = false;
                    txtTemprature.Enabled = false;
                    txtnoise.Enabled = false;
                    txtradiations.Enabled = false;
                    txtvapours.Enabled = false;
                    txtdust.Enabled = false;
                    txtguideline.Enabled = false;
                    lblPermitTypeSelected.Enabled = false;
                    txtdescription.Enabled = false;
                    txtMoniterNeed.Enabled = false;
                    txtLelUelMeasure.Enabled = false;
                    ////txtpermitCode.ReadOnly = true;
                    dtpPermitFrom.Enabled = false;
                    dtpPermitTo.Enabled = false;
                    cmbFromHours.Enabled = false;
                    cmbFromMinuts.Enabled = false;
                    cmbToHours.Enabled = false;
                    cmbToMinuts.Enabled = false;
                    ////txtrequestdate.ReadOnly = true;
                    txtrequestdate.Enabled = false;
                    ////txtrequestBy.ReadOnly = true;
                    cmbPtwBasicArea.Enabled = false;
                    cmbApprovedBy.Enabled = false;
                    cmbWorkType.Enabled = false;
                    cmbCapability.Enabled = false;
                    cmbBasicMachineIsolation.Enabled = false;
                    cmbFromHours.Enabled = false;
                    cmbFromMinuts.Enabled = false;
                    cmbToHours.Enabled = false;
                    cmbToMinuts.Enabled = false;
                    txtareaName.Enabled = false;
                    txtpermitCode.Enabled = false;
                    txtPTWDsgn.Enabled = false;
                    lbxPtwComments.Enabled = false;
                    txtPTWBasicVendor.Enabled = true;
                    lblPTWBasicVendor.Enabled = true;
                    txtPTWBasicVendor.Visible = true;
                    lblPTWBasicVendor.Visible = true;
                    txtPTWBasicVendor.Enabled = false;
                    lblPTWBasicVendor.Enabled = false;
                    dgvAddHazGrid.Enabled = false;
                    SplVisibility();
                }
                else
                {
                    cmbSplReqAreaName.Enabled = true;
                    chkPermitType.Enabled = true;
                    txtactivity.Enabled = true;
                    cmbActivity.Enabled = true;
                    txtdescspec.Enabled = true;
                    txtconsequence.Enabled = true;
                    txtlikelihoodNoHira.Enabled = true;
                    cmbSeverity.Enabled = true;
                    txtRiskNoHira.Enabled = true;
                    cmbControlType.Enabled = true;
                    txtconsequenceHIRA.Enabled = true;
                    txtdesccontrol.Enabled = true;
                    txtlikelihoodHIRA.Enabled = true;
                    cmbseverityHIRA.Enabled = true;
                    txtOwnerId.Enabled = true;
                    txtriskHIRA.Enabled = true;
                    TxtReqPPE.Enabled = true;
                    txtelechazard.Enabled = true;
                    txtfirehazard.Enabled = true;
                    txtheight.Enabled = true;
                    txtcrushing.Enabled = true;
                    txtvibration.Enabled = true;
                    txtTemprature.Enabled = true;
                    txtnoise.Enabled = true;
                    txtradiations.Enabled = true;
                    txtvapours.Enabled = true;
                    txtdust.Enabled = true;
                    txtguideline.Enabled = true;
                    lblPermitTypeSelected.Enabled = true;
                    txtdescription.Enabled = true;
                    txtMoniterNeed.Enabled = true;
                    txtLelUelMeasure.Enabled = true;
                    ////txtpermitCode.ReadOnly = true;
                    dtpPermitFrom.Enabled = true;
                    dtpPermitTo.Enabled = true;
                    ////txtrequestdate.ReadOnly = true;
                    ////txtrequestBy.ReadOnly = true;
                    cmbPtwBasicArea.Enabled = true;
                    cmbApprovedBy.Enabled = true;
                    cmbWorkType.Enabled = true;
                    cmbCapability.Enabled = true;
                    cmbBasicMachineIsolation.Enabled = true;
                    txtPTWDsgn.Enabled = true;
                    txtPTWBasicVendor.Visible = true;
                    lblPTWBasicVendor.Visible = true;
                    dgvAddHazGrid.Enabled = true;
                    SplVisibility();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }
        private void DBGridViewPermit_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                Permitstatus = DBGridViewPermit.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtPermitStatus.Text = Permitstatus;
                if (e.ColumnIndex == 1 && Permitstatus == "Waiting For Supply of Materials")
                {
                    inhouseRedirect = true;
                    PermitCode = DBGridViewPermit.Rows[e.RowIndex].Cells[1].Value.ToString();
                    //PermitToWork.PermitInHouse newInhouse = new PermitInHouse();
                    //newInhouse.Show();

                }

                string status = DBGridViewPermit.Rows[e.RowIndex].Cells[9].Value.ToString();
                //* Change on 06/12/22--- closure from grid is stopped.
                ////if (e.ColumnIndex == 1 && status == "Approved")
                ////{
                ////    PermitCode = DBGridViewPermit.Rows[e.RowIndex].Cells[1].Value.ToString();
                ////    PermitClosure closedPmt = new PermitClosure();
                ////    closedPmt.Show();
                ////}
                ////else
                {

                    PermitCode = DBGridViewPermit.Rows[e.RowIndex].Cells[1].Value.ToString();
                    // this.Close();
                    // CreatePermit npmt = new CreatePermit();

                    var frm = Application.OpenForms.Cast<Form>().Where(x => x.Name == "CreatePermit").FirstOrDefault();
                    if (null != frm)
                    {
                        isredirected = true;
                        PTWPages.SelectedTab = PTWPages.TabPages[0];
                        PTWBasicPages.SelectedTab = PTWBasicPages.TabPages[0];
                        this.PTWPages.SelectedTab = pgNewPermit;
                        frm.Show();
                        OnReload();
                    }
                }
                //BasicPageMigration();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }

        private void CreatePermit_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (HindalcoiOS.Class_Operation.GlobalDeclaration.PermitType != "")
                {
                    lblPermitTypeSelected.Text = Class_Operation.GlobalDeclaration.PermitType;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }

        private void cmbApprovedBy_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateApprovedBy();
        }
        private void ValidateApprovedBy()
        {
            // Check if a Valid Option is Selected
            if (cmbApprovedBy.SelectedItem == null)
            {
                //errorProvider1.SetError(cmbApprovedBy, "Please select Approver.");
                //boolFormValid = false;
                //return;
            }
            //else
            //{
            //    errSummaryBMR.SetError(comboBox2, "");
            //}
        }

        /// <summary>
        /// No mapping Required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPTWNewPermit_Click(object sender, EventArgs e)
        {
            PTWPages.SelectedIndex = 3;
            pgIndex = 0;
            PTWBasicPages.SelectedIndex = 0;
            PTWPages.SelectedTab.Text ="CreatePermit";
            ////this.Close();
            ////CreatePermit createPermit = new CreatePermit();
            ////CheckAllPPE();
            ////createPermit.Show();

            RefreshForNewPermit();
        }

        /// <summary>
        /// No mapping Required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPTWApproval_Click(object sender, EventArgs e)
        {
            PTWPages.SelectedIndex = 1;
            PTWPages.SelectedTab.Text = "Approval";
            BasicPageMigration();
        }
        /// <summary>
        /// No mapping Required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPTWView_Click(object sender, EventArgs e)
        {
            PTWPages.SelectedIndex = 0;
            PTWPages.SelectedTab.Text = "View";
            //BasicPageMigration();
        }
        /// <summary>
        /// No mapping Required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPTWBasicInfo_Click(object sender, EventArgs e)
        {
            PTWBasicPages.SelectedIndex = 0;
            SplVisibility();
        }

        private void btnPTWMonitor_Click(object sender, EventArgs e)
        {
            PTWBasicPages.SelectedIndex = 1;
            BasicPageMigration();
        }

        private void btnPTWSplReq_Click(object sender, EventArgs e)
        {
            PTWBasicPages.SelectedIndex = 2;
            BasicPageMigration();
        }

        private void btnPTWOtherHaz_Click(object sender, EventArgs e)
        {
            PTWBasicPages.SelectedIndex = 3;
            BasicPageMigration();
        }


        int isoMachineCount;
        private void cmbBasicMachineIsolation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsSaved == 1) return;
                RefreshExistingForm();
                switch (cmbBasicMachineIsolation.SelectedItem.ToString())
                {
                    case "NA":
                        break;
                    case "Select Cad Layout..":
                        this.Hide();
                        break;
                    default:
                        {
                            cmbMachineIsolation.Text = cmbBasicMachineIsolation.SelectedItem.ToString();
                            var machineLocation = Resources.Instance.MachineDt.AsEnumerable().Where(X => X.Field<string>("MachineTagNo") == cmbBasicMachineIsolation.SelectedItem.ToString()).FirstOrDefault().Field<string>("MachineLocation"); //Resources.Instance.MachineDt.AsEnumerable().Where(X => X.Field<string>("MachineTagNo") == cmbmachineIsolation.Text).FirstOrDefault().ToString();//Resources.Instance.GetMachineLocation(cmbmachineIsolation.Text);
                            cmbPtwIsolatedArea.Text = machineLocation;
                             IsolationMaster = Resources.Instance.GetMachineConnectionInfo(cmbBasicMachineIsolation.SelectedItem.ToString());
                            IsolatedMAchines = Resources.Instance.GetIsolatedMachines(cmbPermitCode.Text);
                            foreach (DataRow item in IsolationMaster.Rows)
                            {
                                cmbSelMachine.Items.Add(item["fromconnection"]);
                            }
                            //cmbSelMachine.DisplayMember = "fromconnection";                            
                            //cmbSelMachine.DataSource = IsolationMaster;
                            isoMachineCount = IsolationMaster.Rows.Count;                            
                            cmbActivity.ValueMember = "fromconnection";
                        }
                        break;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
            LoadDataToIsolationGrid(txtpermitCode.Text);
        }
        /// <summary>
        /// No mapping
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBasicMachineIsolation_Leave(object sender, EventArgs e)
        {
            int itmCount = GlobalDeclaration._MyTagDictinary.AsEnumerable().Where(X => X.Value == cmbBasicMachineIsolation.Text).ToList().Count();
            if (itmCount == 0)
            {
                XtraMessageBox.Show("Wrong text in Item field! Please rectify");
                cmbBasicMachineIsolation.Focus();
                return;
            }
        }
        public void CallEventfrm_SomeEvent(params object[] args)
        {
            cmbBasicMachineIsolation.SelectedItem = args[1].ToString();
            cmbBasicMachineIsolation.Enabled = false;
            DPoint _points = ((DPoint)args[3]);
            var Area = Resources.Instance.MachineDt.AsEnumerable().Where(X => X.Field<string>("Cadlocation") == "X" + _points.X + " " + "Y" + _points.Y).Select(X => X.Field<string>("MachineLocation")).Distinct().ToList();
            if (Area.Count > 0)
                cmbPtwBasicArea.Text = Area[0].ToString();

        }

        /// <summary>
        /// No mapping
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewIsolation_Click(object sender, EventArgs e)
        {
            PTWBasicPages.SelectedIndex = 4;
        }

        bool isCheckStatus = false;
        private DataTable LoadDataToIsolationGrid(String PermitCode)
        {
            DataTable isolationMachines1 = null;
            try
            {
                if (!isCheckStatus)
                {
                    if (dgvIsolatedMachine.Rows.Count > 0)
                        dgvIsolatedMachine.Rows.Clear();

                    isolationMachines1 = GetIsolatedMachines(PermitCode);// Resources.Instance.GetAllIsolatedMachines(PermitCode);
                    var Rowsexists = dgvIsolatedMachine.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["PermitC"].Value.ToString() == PermitCode).ToArray();
                    if (Rowsexists.Length == 0)
                    {
                        //dgvIsolatedMachine.DataSource = isolationMachines1;
                        for (int i = 0; i < isolationMachines1.Rows.Count; i++)
                        {
                            DataGridViewRow Dr = new DataGridViewRow();
                            dgvIsolatedMachine.Rows.Add(Dr);
                            int rowsindex = dgvIsolatedMachine.Rows.Count - 1;
                            dgvIsolatedMachine.Rows[rowsindex].Cells["PermitC"].Value = isolationMachines1.Rows[i]["Permit Code"];
                            dgvIsolatedMachine.Rows[rowsindex].Cells["IsolationDate"].Value = isolationMachines1.Rows[i]["Isolation Date"];
                            dgvIsolatedMachine.Rows[rowsindex].Cells["RemovalDate"].Value = isolationMachines1.Rows[i]["Removal Date"];
                            dgvIsolatedMachine.Rows[rowsindex].Cells["Location"].Value = isolationMachines1.Rows[i]["Location"];
                            dgvIsolatedMachine.Rows[rowsindex].Cells["MachineName"].Value = isolationMachines1.Rows[i]["Machine Name"];
                            dgvIsolatedMachine.Rows[rowsindex].Cells["ConnectorType"].Value = isolationMachines1.Rows[i]["Connector Type"];
                            dgvIsolatedMachine.Rows[rowsindex].Cells["LockNo"].Value = isolationMachines1.Rows[i]["Lock No"];
                            dgvIsolatedMachine.Rows[rowsindex].Cells["PersonName"].Value = isolationMachines1.Rows[i]["Person Name"];
                            dgvIsolatedMachine.Rows[rowsindex].Cells["ContactNo"].Value = isolationMachines1.Rows[i]["Contact No"];
                            dgvIsolatedMachine.Rows[rowsindex].Cells["Status"].Value = isolationMachines1.Rows[i]["Status"];
                        }
                        dgvIsolatedMachine.Columns["RemovalDate"].Visible = false;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }

            //IsIsolationComplete();
            return isolationMachines1;


        }

        /// <summary>
        /// No mapping
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckAllPPE()
        {
            chkPPEHelmet.Checked = false;
            chkPPESftyGlss.Checked = false;
            chkPPEFaceShld.Checked = false;
            chkPPESftyGoggls.Checked = false;
            chkPPEEarPlugs.Checked = false;
            chkPPEEarMuffs.Checked = false;
            chkPPEDustMusks.Checked = false;
            chkPPEGasMsk.Checked = false;
            chkPPEHndGlvChem.Checked = false;
            chkPPEHndGlvElec.Checked = false;
            chkPPEHndGlvOthers.Checked = false;
            chkPPESftyNet.Checked = false;
            chkPPESftyShoe.Checked = false;
            chkPPEGumBoots.Checked = false;
            chkPPECrawlingNet.Checked = false;
            chkPPEApron.Checked = false;
            chkPPESftyBlt.Checked = false;
            chkPPESCBA.Checked = false;
        }

        /// <summary>
        /// No mapping
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncancel_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// To Visible Save button in different condition--
        /// </summary>
        private void SplVisibility()
        {
            ////lblReadyToSubmit.Visible = true;
            chkReadyToSubmit.Visible = true;
            if(txtPermitStatus.Text == "Prepare")
            {
                if (Properties.Settings.Default.RoleID != 1 && Properties.Settings.Default.RoleID != 5 && Properties.Settings.Default.RoleID != 7)
                {
                    btnPermitSave.Visible = true;
                    btnPTWCancel.Visible = true;
                }
                else
                {
                    btnPTWDelete.Visible = true;
                }
            }

            if (txtPermitStatus.Text != "Prepare" && txtPermitStatus.Text != "Cancelled")
            {
                ////lblReadyToSubmit.Visible = false;
                chkReadyToSubmit.Visible = false;
            }
            if (txtPermitStatus.Text == "Waiting For Approval" || txtPermitStatus.Text == "Closed")
            {
                btnPTWDelete.Visible = false;
                if (Properties.Settings.Default.RoleID == 7 || Properties.Settings.Default.RoleID == 5)
                {
                    btnPermitSave.Visible = true;
                    btnPTWCancel.Visible = true;
                }
                else
                {
                    btnPermitSave.Visible = false;
                    btnPTWCancel.Visible = false;
                    
                }

            }
            if (txtPermitStatus.Text == "Approved")
            {
                btnPTWDelete.Visible = false;
                btnPermitSave.Visible = true;
                btnPTWCancel.Visible = false;
                if (Properties.Settings.Default.RoleID == 7 || Properties.Settings.Default.RoleID == 5)
                {
                    btnPermitSave.Visible = false;
                    btnPTWCancel.Visible = false;
                }
            }
            if (txtPermitStatus.Text == "Rejected")
            {
                btnPTWDelete.Visible = false;
                btnPermitSave.Visible = true;
                btnPTWCancel.Visible = false;
                if (Properties.Settings.Default.RoleID == 7 || Properties.Settings.Default.RoleID == 5)
                {
                    btnPermitSave.Visible = false;
                    btnPTWCancel.Visible = false;
                }
            }
            RenameSaveBtn();
        }
        public void RenameSaveBtn()
        {
            if (txtPermitStatus.Text == "Approved" && (Properties.Settings.Default.RoleID != 7 && Properties.Settings.Default.RoleID != 5))
            {
                btnPermitSave.Text = "Close";
            }
            else if (txtPermitStatus.Text == "Reject" && (Properties.Settings.Default.RoleID != 7 && Properties.Settings.Default.RoleID != 5))
            {
                btnPermitSave.Text = "Save";
                chkReadyToSubmit.Enabled = true;
                chkReadyToSubmit.Visible = true;
                chkReadyToSubmit.Checked = false;
                ////lblReadyToSubmit.Visible = true;
            }

            else if (txtPermitStatus.Text == "Prepare" && chkReadyToSubmit.Checked == true)
            {
                btnPermitSave.Text = "Submit";
            }
            else if (txtPermitStatus.Text == "Waiting For Approval")
            {
                if (Properties.Settings.Default.RoleID == 7 || Properties.Settings.Default.RoleID == 5)
                {
                    btnPermitSave.Text = "Approve";
                    btnPTWCancel.Text = "Reject";
                }
            }
            else
            {
                btnPermitSave.Text = "Save";

            }
        }

       
        private void chkReadyToSubmit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReadyToSubmit.Checked == true)
            {
                btnPermitSave.Text = "Submit";
                btnPTWDelete.Visible = false;
                
            }
            else
            {
                btnPermitSave.Text = "Save";
                btnPTWDelete.Visible = true;
            }
        }
        public bool ValidatePermit()
        {
            Boolean IsValidate = true;

            if (string.IsNullOrWhiteSpace(dtpPermitFrom.Text) && string.IsNullOrWhiteSpace(dtpPermitTo.Text))
            {
                MessageBox.Show("Fill all fields in Basic Details Section", "Alert", MessageBoxButtons.OK);
                IsValidate = false;
                ptwErrorProvider.SetError(dtpPermitFrom, "Permit from should not be left blank!");
                ptwErrorProvider.SetError(dtpPermitTo, "PermitTo should not be left blank!");
            }

            else if(!string .IsNullOrWhiteSpace(dtpPermitFrom.Text) && !string.IsNullOrWhiteSpace(dtpPermitTo.Text))
            {
                dtpPermitFrom.CustomFormat = "dd-MM-yyyy";
                dtpPermitTo.CustomFormat = "dd-MM-yyyy";
                DateTime fdt = DateTime.Parse(DateTime.Parse(dtpPermitFrom.Text).ToShortDateString());
                DateTime tDt = DateTime.Parse(DateTime.Parse(dtpPermitTo.Text).ToShortDateString());
                if (fdt < DateTime.Today || tDt < DateTime.Today)
                {
                    MessageBox.Show("Back Date is not allowed for [From Date]! ", "Alert", MessageBoxButtons.OK);
                    IsValidate = false;
                  
                }
              
                else if (tDt < DateTime.Today)
                {
                    MessageBox.Show("Back Date is not allowed for [To Date]! ", "Alert", MessageBoxButtons.OK);
                    IsValidate = false;
                   
                }
                else if(fdt > tDt)
                {
                    MessageBox.Show("From Date should be less than To Date in Basic Details Section", "Alert", MessageBoxButtons.OK);
                    IsValidate = false;
                }
                else if(fdt==tDt && cmbFromHours.Text==cmbToHours.Text && cmbFromMinuts.Text==cmbToMinuts.Text)
                {
                    MessageBox.Show("Invalid time! Start & end time Should be different", "Alert", MessageBoxButtons.OK);
                    IsValidate = false;
                }
                else if (fdt == tDt && cmbFromHours.Text == cmbToHours.Text && int.Parse(cmbFromMinuts.Text) > int.Parse(cmbToMinuts.Text))
                {
                    MessageBox.Show("Invalid time! Start time Should be less than end time", "Alert", MessageBoxButtons.OK);
                    IsValidate = false;
                }
                else if (string.IsNullOrWhiteSpace(cmbFromHours.Text) || string.IsNullOrWhiteSpace(cmbFromMinuts.Text) || string.IsNullOrWhiteSpace(cmbToHours.Text) || string.IsNullOrWhiteSpace(cmbToHours.Text))
                {
                    MessageBox.Show("Select Hours & Minutes in permit time duration field.!", "Alert", MessageBoxButtons.OK);
                    IsValidate = false;
                }

                else if (fdt == tDt && int.Parse(cmbFromHours.Text)> int.Parse(cmbToHours.Text))
                {
                    MessageBox.Show("Start hours should less that end hours!", "Alert", MessageBoxButtons.OK);
                    IsValidate = false;
                }
                
            }



          else  if (string.IsNullOrEmpty(cmbApprovedBy.Text) || string.IsNullOrEmpty(cmbPtwBasicArea.Text) || string.IsNullOrEmpty(cmbBasicMachineIsolation.Text))
            {
                MessageBox.Show("Fill all fields in Work Location Section", "Alert", MessageBoxButtons.OK);
                IsValidate = false;

            }
           else if (string.IsNullOrEmpty(cmbWorkType.Text) || string.IsNullOrEmpty(cmbCapability.Text) || string.IsNullOrEmpty(txtdescription.Text))
            {
                MessageBox.Show("Fill all fields on Work Description Section", "Alert", MessageBoxButtons.OK);
                IsValidate = false;
            }
           else if (string.IsNullOrWhiteSpace(lblPermitTypeSelected.Text) || lblPermitTypeSelected.Text == "...")
            {
                MessageBox.Show("Select permit type !", "Alert", MessageBoxButtons.OK);
                IsValidate = false;
            }
           


            return IsValidate;
        }

        public void ReloadConnectedMachine()
        {
            if (cmbBasicMachineIsolation.Text == "NA") return;
            if (Resources.Instance.MachineDt.Rows.Count == 0) return;
            var machineLocation = Resources.Instance.MachineDt.AsEnumerable().Where(X => X.Field<string>("MachineTagNo") == cmbMachineIsolation.Text).FirstOrDefault().Field<string>("MachineLocation"); //Resources.Instance.MachineDt.AsEnumerable().Where(X => X.Field<string>("MachineTagNo") == cmbmachineIsolation.Text).FirstOrDefault().ToString();//Resources.Instance.GetMachineLocation(cmbmachineIsolation.Text);
            cmbPtwIsolatedArea.Text = machineLocation;
            
            IsolatedMAchines = Resources.Instance.GetIsolatedMachines(cmbPermitCode.Text);
            IsolationMaster = Resources.Instance.GetMachineConnectionInfo(cmbBasicMachineIsolation.Text);
            if (cmbSelMachine.Items.Count == 0 && !string.IsNullOrEmpty(cmbMachineIsolation.Text) && IsolationMaster!=null)
            {
                foreach (DataRow item in IsolationMaster.Rows)
                {
                    cmbSelMachine.Items.Add(item["fromconnection"]);
                }
                //cmbSelMachine.DataSource = Resources.Instance.GetMachineConnectionInfo(cmbMachineIsolation.Text);
                //cmbSelMachine.DisplayMember = "fromconnection";
                //cmbSelMachine.ValueMember = "fromconnection";
            }
            cmbActivity.ValueMember = "fromconnection";
        }

        private bool IsIsolationComplete(string permitCode)
        {
            bool isComplete = false;
            ////DataTable dtt = LoadDataToIsolationGrid(permitCode);
            ////if ((dtt==null) ||(dtt!=null && dtt.Rows.Count == 0)) return isComplete;
            ///
            int rCount, sCount, rmCount, pCount = 0;
            //rCount = dtt.Rows.Count;
            rCount = cmbSelMachine.Items.Count;
            rmCount = dgvIsolatedMachine.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["Status"].Value.ToString() == "Removed").Count();// dtt.AsEnumerable().Where(a => a.Field<string>("Status") == "Removed").Count();
            pCount = dgvIsolatedMachine.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["Status"].Value.ToString() == "Pending").Count();// dtt.AsEnumerable().Where(a => a.Field<string>("Status") == "Pending").Count();
            sCount = dgvIsolatedMachine.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["Status"].Value.ToString() == "Completed").Count(); //dtt.AsEnumerable().Where(a => a.Field<string>("Status") == "Completed").Count();
            if (rCount > 0 && rCount == sCount)
            {
                isComplete = true;
                chkIsoTotStatus.Enabled = true;
                chkIsoTotStatus.Checked = isComplete;
                ////lblIsolationStatus.Text = "Isolation completed";
                ////lblIsolationStatus.ForeColor = System.Drawing.Color.Green;
                chkIsoTotStatus.Text = "Isolation completed"; 
            }
            else if (pCount <= rCount && rmCount == 0)
            {
                chkIsoTotStatus.Enabled = false;
                chkIsoTotStatus.CheckState = CheckState.Unchecked;
                chkIsoTotStatus.Checked = isComplete;
                ////lblIsolationStatus.Text = "Isolation Pending";
                ////lblIsolationStatus.ForeColor = System.Drawing.Color.Red;
                chkIsoTotStatus.Text = "Isolation Pending";
            }
            if (rmCount > 0)
            {
                if (rCount == rmCount)
                {
                    isComplete = true;
                    chkIsoTotStatus.Enabled = true;
                    chkIsoTotStatus.Checked = true;
                    ////lblIsolationStatus.Text = "Isolation Removed";
                    ////lblIsolationStatus.ForeColor = System.Drawing.Color.Green;
                    chkIsoTotStatus.Text = "Isolation Removed";
                }
                else
                {
                    ////lblIsolationStatus.Text = "Isolation Partially Removed";
                    ////lblIsolationStatus.ForeColor = System.Drawing.Color.Green;
                    chkIsoTotStatus.Text = "Isolation Partially Removed";
                }
            }
            return isComplete;
        }
        /// <summary>
        /// no mapping
        /// </summary>
        /// <param name="permitCode"></param>
        public void IsIsolationCompleteEx(string permitCode)
        {
            int isoCompCount = dgvIsolatedMachine.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["Status"].Value.ToString() == "Isolation Completed").Count();
        }

        private void FreezeIsolation(bool IsFreeze)
        {
            if (IsFreeze == false)
            {
                cmbPermitCode.Enabled = false;
                cmbMachineIsolation.Enabled = false;
                pnlIsoMachine.Enabled = false;
                btnIsolateSave.Enabled = false;
                btnPermitClose.Enabled = false;
                panel4.Enabled = true;
                chkIsoTotStatus.Enabled = true;
                chkIsoTotStatus.Enabled = false;
                cmbPermitCode.Enabled = false;
                cmbPtwIsolatedArea.Enabled = false;
                cmbSelMachine.Enabled = false;
                chkIsolationCompl.Enabled = false;
                txtIsoLockNo.Enabled = false;
                txtIsoContact.Enabled = false;
                txtIsoPersonName.Enabled = false;
                btnIsolateSave.Enabled = false;
                btnIsoSnapUpld.Enabled = false;

            }
            else
            {
                pnlIsoMachine.Enabled = true;
                btnIsolateSave.Enabled = true;
                btnPermitClose.Enabled = true;
                panel4.Enabled = true;
                chkIsolationReq.Enabled = true;
                chkIsolationCompl.Enabled = true;
                cmbSelMachine.Enabled = true;
                txtIsoLockNo.Enabled = true;
                txtIsoContact.Enabled = true;
                txtIsoPersonName.Enabled = true;
                btnIsolateSave.Enabled = true;
                btnIsoSnapUpld.Enabled = true;
            }
        }
        private void FreezeBasicIsolation()
        {
            if (Permitstatus == "Prepare")
            {
                cmbPermitCode.Enabled = false;
                cmbMachineIsolation.Enabled = true;
                cmbPtwIsolatedArea.Enabled = false;
                pnlIsoMachine.Enabled = true;
                chkIsoTotStatus.Enabled = false;
            }
            if (Permitstatus != "Prepare")
            {
                cmbPermitCode.Enabled = false;
                cmbMachineIsolation.Enabled = false;
                cmbPtwIsolatedArea.Enabled = false;
                pnlIsoMachine.Enabled = false;
                chkIsoTotStatus.Enabled = false;
            }
        }

        private void chkPermitType_Click(object sender, EventArgs e)
        {
            try
            {
                this.TopMost = false;
                if (txtPermitStatus.Text != "Prepare") return;
                if (chkPermitType.Checked == true )
                {
                    PermitToWork.PermitQuestionnaire questionnaire = new PermitQuestionnaire();
                    questionnaire.PermitQtsEvent += Questionnaire_PermitQtsEvent;
                    if (DialogResult.OK == questionnaire.ShowDialog())
                    {
                        questionnaire.PermitQtsEvent -= Questionnaire_PermitQtsEvent;
                        questionnaire.Close();
                        questionnaire.Dispose();
                    }
                    else
                    {
                        questionnaire.Close();
                    }
                    //formObject.Add(questionnaire);
                    // formObject.Add(Resources.Instance);
                    //questionnaire.Show();

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }

        private int UpdateIsoRequired()
        {
            int isoValue = 0;
            if (chkIsolationReq.Checked == true)
                isoValue = 1;
            return isoValue;
        }
        private int UpdateIsoComplete()
        {
            int isoValue = 0;
            chkIsoTotStatus.Enabled = true;
            if (chkIsoTotStatus.Checked == true)
                isoValue = 1;
            chkIsoTotStatus.Enabled = false;
            return isoValue;
        }

        private void btnPermitClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// No mapping Required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllPermits_Click(object sender, EventArgs e)
        {
            PTWPages.SelectedIndex = 2;
            PTWPages.SelectedTab.Text = "AllPermits";
        }
        private void GetApproverFromArea(string area)
        {
            if (string.IsNullOrWhiteSpace(area)) return;
            List<string> approvedBy = Resources.Instance.GetAreaApprover(area);
            string[] splArr = new string[] { };
            splArr = approvedBy[0].Split(',');
            if (approvedBy.Count > 0)
            {
                cmbApprovedBy.Items.Clear();
                for (int i = 0; i < splArr.Length; i++)
                {
                    string name = splArr[i];
                    cmbApprovedBy.Items.Add(name);
                }
            }
        }

        private void GetApproverAll()
        {
            if (cmbApprovedBy.Items.Count > 0)
                cmbApprovedBy.Items.Clear();
           DataTable appvrs= Resources.Instance.GetUserDetails_RMPCL(2);
            appvrs= appvrs.AsEnumerable().Where(X => X.Field<int>("RoleID") == 7 || X.Field<int>("RoleID") == 5).CopyToDataTable();
            foreach (DataRow dr in appvrs.Rows)
            {
                cmbApprovedBy.Items.Add(dr["UserName"].ToString());
            }
        }

        private void AddRowToIsoGrid()
        {
            try
            {
                DataGridViewRow rowadd = new DataGridViewRow();
                dgvIsolatedMachine.Rows.Add(rowadd);
                int RowsIndesx = dgvIsolatedMachine.Rows.Count - 1;
                dgvIsolatedMachine.Rows[RowsIndesx].Cells["PermitC"].Value = cmbPermitCode.Text;
                dgvIsolatedMachine.Columns["PermitC"].ReadOnly = true;
                dgvIsolatedMachine.Rows[RowsIndesx].Cells["IsolationDate"].Value = System.DateTime.Now;
                dgvIsolatedMachine.Columns["IsolationDate"].ReadOnly = true;
                dgvIsolatedMachine.Rows[RowsIndesx].Cells["RemovalDate"].Value = DateTime.Now;
                dgvIsolatedMachine.Columns["RemovalDate"].ReadOnly = true;
                dgvIsolatedMachine.Rows[RowsIndesx].Cells["Location"].Value = lblLocation2.Text;
                dgvIsolatedMachine.Columns["Location"].ReadOnly = true;
                dgvIsolatedMachine.Rows[RowsIndesx].Cells["MachineName"].Value = lblEquipName2.Text;
                dgvIsolatedMachine.Columns["MachineName"].ReadOnly = true;
                dgvIsolatedMachine.Rows[RowsIndesx].Cells["ConnectorType"].Value = lblConnectorType2.Text;
                dgvIsolatedMachine.Columns["ConnectorType"].ReadOnly = true;
                dgvIsolatedMachine.Rows[RowsIndesx].Cells["LockNo"].Value = txtIsoLockNo.Text;
                dgvIsolatedMachine.Columns["LockNo"].ReadOnly = true;
                dgvIsolatedMachine.Rows[RowsIndesx].Cells["PersonName"].Value = txtIsoPersonName.Text;
                dgvIsolatedMachine.Columns["PersonName"].ReadOnly = true;
                dgvIsolatedMachine.Rows[RowsIndesx].Cells["ContactNo"].Value = txtIsoContact.Text;
                dgvIsolatedMachine.Columns["ContactNo"].ReadOnly = true;
                //if(chkIsolationCompl.Checked==true)
                dgvIsolatedMachine.Rows[RowsIndesx].Cells["Status"].Value = "Completed";
                //else
                //dgvIsolatedMachine.Rows[RowsIndesx].Cells["Status"].Value = "Pending";
                dgvIsolatedMachine.Rows[RowsIndesx].Cells["ptwIsoSnapImage"].Value = pcbxPTWIsoSnap.Image;
                dgvIsolatedMachine.Columns["Status"].ReadOnly = true;


            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }

        private DataTable GetIsolatedMachines(string permitCode)
        {
            DataTable isoDt = null;
            isoDt = Resources.Instance.GetAllIsolatedMachines(permitCode);
            return isoDt;
        }
       
        /// <summary>
        /// No mapping Required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPTWPPE_Click(object sender, EventArgs e)
        {
            PTWBasicPages.SelectedIndex = 5;
            BasicPageMigration();
        }

        private void btnAddHazard_Click(object sender, EventArgs e)
        {
            OpenAddHazard();
        }
        private void OpenAddHazard()
        {
            AdditionalHazardView addHazView = new AdditionalHazardView(txtpermitCode.Text, true);
            addHazView.GetValue += AdditionalHazardHandlerEvent;
            if (addHazView.ShowDialog() == DialogResult.OK)
            {
                //addHazView.Close();
                //addHazView.Dispose();
            }
            ViewAddHazard(txtpermitCode.Text);
        }
        private void AdditionalHazardHandlerEvent(object[] objs)
        {
            //if (!cmbProcureItem.Items.Contains(value))
            //{
            //    cmbProcureItem.Items.Add(value);
            //    cmbProcureItem.Text = value.ToString();
            //    DialogResult = DialogResult.OK;
            //}
        }
        public void ViewAddHazard(string permitCode)
        {
            if (string.IsNullOrEmpty(permitCode)) return;
            dgvAddHazGrid.DataSource = Resources.Instance.GetAdditionalHazDetail(permitCode);
            dgvAddHazGrid.Columns["CreatedDate"].Visible = false;
            dgvAddHazGrid.Columns["AddHazId"].Visible = false;
        }
        public void MapPPEToData()
        {
            ppeRequired.PermitCode = txtpermitCode.Text;
            ppeRequired.Helmet = chkPPEHelmet.Checked;
            ppeRequired.SafetyGlasses = chkPPESftyGlss.Checked;
            ppeRequired.FaceShield = chkPPEFaceShld.Checked;
            ppeRequired.SafetyGoggles = chkPPESftyGoggls.Checked;
            ppeRequired.EarPlugs = chkPPEEarPlugs.Checked;
            ppeRequired.EarMuffs = chkPPEEarMuffs.Checked;
            ppeRequired.DustMasks = chkPPEDustMusks.Checked;
            ppeRequired.GasMasks = chkPPEGasMsk.Checked;
            ppeRequired.HandGlovesChemicals = chkPPEHndGlvChem.Checked;
            ppeRequired.HandGlovesElectrical = chkPPEHndGlvElec.Checked;
            ppeRequired.HandGlovesOthers = chkPPEHndGlvOthers.Checked;
            ppeRequired.SafetyNet = chkPPESftyNet.Checked;
            ppeRequired.SafetyShoes = chkPPESftyShoe.Checked;
            ppeRequired.GumBoots = chkPPEGumBoots.Checked;
            ppeRequired.CrawlingNet = chkPPECrawlingNet.Checked;
            ppeRequired.Apron = chkPPEApron.Checked;
            ppeRequired.SafetyBelt = chkPPESftyBlt.Checked;
            ppeRequired.SCBA = chkPPESCBA.Checked;
            ppeRequired.SetPPERequiredToData(ppeRequired);

        }

        public void MapPPEToView(DataTable ppeDt)
        {
            if (ppeDt.Rows.Count == 0) return;
            DataRow ppeDr = ppeDt.Rows[0];
            chkPPEHelmet.Checked = Convert.ToBoolean(ppeDr["Helmet"]);
            chkPPESftyGlss.Checked = Convert.ToBoolean(ppeDr["SafetyGlasses"]);
            chkPPEFaceShld.Checked = Convert.ToBoolean(ppeDr["FaceShield"]);
            chkPPESftyGoggls.Checked = Convert.ToBoolean(ppeDr["SafetyGoggles"]);
            chkPPEEarPlugs.Checked = Convert.ToBoolean(ppeDr["EarPlugs"]);
            chkPPEEarMuffs.Checked = Convert.ToBoolean(ppeDr["EarMuffs"]);
            chkPPEDustMusks.Checked = Convert.ToBoolean(ppeDr["DustMasks"]);
            chkPPEGasMsk.Checked = Convert.ToBoolean(ppeDr["GasMasks"]);
            chkPPEHndGlvChem.Checked = Convert.ToBoolean(ppeDr["HandGlovesChemicals"]);
            chkPPEHndGlvElec.Checked = Convert.ToBoolean(ppeDr["HandGlovesElectrical"]);
            chkPPEHndGlvOthers.Checked = Convert.ToBoolean(ppeDr["HandGlovesOthers"]);
            chkPPESftyNet.Checked = Convert.ToBoolean(ppeDr["SafetyNet"]);
            chkPPESftyShoe.Checked = Convert.ToBoolean(ppeDr["SafetyShoes"]);
            chkPPEGumBoots.Checked = Convert.ToBoolean(ppeDr["GumBoots"]);
            chkPPECrawlingNet.Checked = Convert.ToBoolean(ppeDr["CrawlingNet"]);
            chkPPEApron.Checked = Convert.ToBoolean(ppeDr["Apron"]);
            chkPPESftyBlt.Checked = Convert.ToBoolean(ppeDr["SafetyBelt"]);
            chkPPESCBA.Checked = Convert.ToBoolean(ppeDr["SCBA"]);
        }
        public string browseImageFileExt()
        {
            string imgPath = string.Empty;
            try
            {
                OpenFileDialog opFileDialog = new OpenFileDialog();
                {
                    opFileDialog.InitialDirectory = @"C:\";
                    opFileDialog.Title = "Browse";
                    opFileDialog.CheckFileExists = true;
                    opFileDialog.CheckPathExists = true;
                    opFileDialog.Filter = "Images(*.Jpeg;*.png;*.jpg;)|*.Jpeg;*.png;*.jpg;";
                    opFileDialog.ReadOnlyChecked = false;
                }

                if (opFileDialog.ShowDialog() == DialogResult.OK)
                {
                    {
                        PictureBox imageControl = new PictureBox();
                        pcbxPTWIsoSnap.Image = new Bitmap(opFileDialog.FileName);
                        imgPath = opFileDialog.FileName;
                        pcbxPTWIsoSnap.SizeMode = PictureBoxSizeMode.StretchImage;
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
            return imgPath;
        }
        private Image GetImage(byte[] bytearr)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytearr);
            Image i = Image.FromStream(ms);
            return i;
        }
        public byte[] GetByteFromImage(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }
        
        /// <summary>
        /// No mapping
        /// </summary>
        private void EnableIsoCompleteCheck()
        {
            if (chkIsolationReq.Checked == false)
            {
                FreezeIsolation(false);
            }
            else if (chkIsolationReq.Checked == true)
            {
                FreezeIsolation(true);
            }
        }

        /// <summary>
        /// No mapping
        /// </summary>
        private int GetIsolateMachineCount()
        {
            int mCount = 0;
            if (!string.IsNullOrWhiteSpace(cmbBasicMachineIsolation.Text) || (cmbBasicMachineIsolation.SelectedItem != null && !string.IsNullOrWhiteSpace(cmbBasicMachineIsolation.SelectedItem.ToString())))
            {
               // IsolationMaster = Resources.Instance.GetMachineConnectionInfo(cmbBasicMachineIsolation.Text);
                //isoMachineCount = IsolationMaster.Rows.Count;
            }
            return mCount;
        }
        private void DisablePPEDetail()
        {
            chkPPEHelmet.Enabled = false;
            chkPPESftyGlss.Enabled = false;
            chkPPEFaceShld.Enabled = false;
            chkPPESftyGoggls.Enabled = false;
            chkPPEEarPlugs.Enabled = false;
            chkPPEEarMuffs.Enabled = false;
            chkPPEDustMusks.Enabled = false;
            chkPPEGasMsk.Enabled = false;
            chkPPEHndGlvChem.Enabled = false;
            chkPPEHndGlvElec.Enabled = false;
            chkPPEHndGlvOthers.Enabled = false;
            chkPPESftyNet.Enabled = false;
            chkPPESftyShoe.Enabled = false;
            chkPPEGumBoots.Enabled = false;
            chkPPECrawlingNet.Enabled = false;
            chkPPEApron.Enabled = false;
            chkPPESftyBlt.Enabled = false;
            chkPPESCBA.Enabled = false;
        }
        private void EnablePPEDetail()
        {
            chkPPEHelmet.Enabled = true;
            chkPPESftyGlss.Enabled = true;
            chkPPEFaceShld.Enabled = true;
            chkPPESftyGoggls.Enabled = true;
            chkPPEEarPlugs.Enabled = true;
            chkPPEEarMuffs.Enabled = true;
            chkPPEDustMusks.Enabled = true;
            chkPPEGasMsk.Enabled = true;
            chkPPEHndGlvChem.Enabled = true;
            chkPPEHndGlvElec.Enabled = true;
            chkPPEHndGlvOthers.Enabled = true;
            chkPPESftyNet.Enabled = true;
            chkPPESftyShoe.Enabled = true;
            chkPPEGumBoots.Enabled = true;
            chkPPECrawlingNet.Enabled = true;
            chkPPEApron.Enabled = true;
            chkPPESftyBlt.Enabled = true;
            chkPPESCBA.Enabled = true;
        }
        private void RefreshForNewPermit()
        {
            try
            {
                IsSaved = 0;
                txtPtwInputComm.Text = string.Empty;// Clear();
                chkPermitType.CheckState = CheckState.Unchecked;
                lblPermitTypeSelected.Enabled = true;
                lblPermitTypeSelected.Text = "";// string.Empty;
                btnPermitSave.Enabled = true;
                btnPermitSave.Visible = true;
                btnPTWCancel.Visible = true;
                btnAddHazard.Visible = true;
                btnNewLEL.Visible = true;
                btnPTWDelete.Visible = false;
                if (HindalcoiOS.Properties.Settings.Default.RoleID == 1 || HindalcoiOS.Properties.Settings.Default.RoleID == 5 || HindalcoiOS.Properties.Settings.Default.RoleID == 7)
                {
                    btnPTWDelete.Visible = true;
                }
                ////HidePTWBasic();
                if (CallingLocation) return;
                //PTWPages.TabPages.RemoveByKey("tabClosure");
                PTWBasicInitialize();

                //* Isolation Initialization-----------------------------------------------------------------
                chkIsolationReq.Enabled = true;
                chkIsolationReq.Checked = false;
                if (PermitToWork.ViewPermit.frmRedirect == true)
                {
                    DataTable permitDetails = new DataTable();
                    permitDetails = PermitToWork.ViewPermit.peritDetailsData;
                    txtpermitCode.Text = permitDetails.Rows[0][0].ToString();
                    txtrequestdate.Text = permitDetails.Rows[0][1].ToString();
                    txtrequestBy.Text = permitDetails.Rows[0][2].ToString();
                    dtpPermitFrom.Text = permitDetails.Rows[0][3].ToString();
                    dtpPermitTo.Text = permitDetails.Rows[0][4].ToString();
                    cmbPtwBasicArea.Text = permitDetails.Rows[0][5].ToString();
                    //cmbMachineName.Text= permitDetails.Rows[0][6].ToString();
                    cmbApprovedBy.Text = permitDetails.Rows[0][7].ToString();
                    txtdescription.Text = permitDetails.Rows[0][8].ToString();
                    cmbWorkType.Text = permitDetails.Rows[0][9].ToString();
                    cmbCapability.Text = permitDetails.Rows[0][10].ToString();
                }
                else
                {
                    ClearAllPTW();
                    GeneratePTWId();
                   
                    

                    txtrequestBy.Text = Class_Operation.GlobalDeclaration._holdInfo[0].UserName;
                    txtrequestdate.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm");
                    txtPermitStatus.Text = "Prepare";
                    // Isolation------
                    SetValueTocmbPermitCode();

                    List<string> machineList = Resources.Instance.GetMachineTag();//Change by RP
                    int listcnt = machineList.Count;

                    PermitCode = txtpermitCode.Text;
                    timerMonitor.Enabled = false;
                    DataTable Areamaster = Resources.Instance.GetMachineAreaMaster();
                    if (cmbPtwBasicArea.Items.Count > 0) cmbPtwBasicArea.Items.Clear();
                    if (cmbSplReqAreaName.Items.Count > 0) cmbSplReqAreaName.Items.Clear();
                    for (int y = 0; y < Areamaster.Rows.Count; y++)
                    {
                        cmbPtwBasicArea.Items.Add(Areamaster.Rows[y][0]);
                        cmbSplReqAreaName.Items.Add(Areamaster.Rows[y][0]);
                    }
                    if (cmbBasicMachineIsolation.Items.Count > 0) cmbBasicMachineIsolation.Items.Clear();
                    foreach (var item in GlobalDeclaration._MyTagDictinary)
                    {
                        string MachineTag = item.Value;
                        cmbBasicMachineIsolation.Items.Add(MachineTag);
                    }
                    cmbBasicMachineIsolation.Items.Add("Select Cad Layout..");
                    if (Class_Operation.GlobalDeclaration.PermitType != "")
                    {
                        lblPermitTypeSelected.Text = Class_Operation.GlobalDeclaration.PermitType;
                    }
                    List<string> permitCodeList = Resources.Instance.GetPTWPermitCode();//Change by RP
                    cmbPermitCode.Items.Clear();
                    cmbPermitCode.Items.Add("");
                    pnlIsoMachine.Visible = false;

                    //for (int i = 0; i < permitCodeList.Count; i++)
                    //{
                    //    cmbPermitCode.Items.Add(permitCodeList[i].ToString());
                    //}
                }

                DBPtwApproveGrid.CellClick += new DataGridViewCellEventHandler(DBGridPermitList_ComboBoxIndexChanged);
                chkIsolationCompl.Checked = false;
                ViewAddHazard(txtpermitCode.Text);
                //OnReload();
                CheckRedirected();
                HidePTWBasic();//written on 06/12/22
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }
        private void HidePTWBasic()
        {
            txtPTWBasicVendor.Visible = false;
            lblPTWBasicVendor.Visible = false;
            if(UserRoleId==7 || UserRoleId == 1 || UserRoleId == 5)
            {
                btnPTWNewPermit.Visible = false;
                btnPTWView.Visible = false;
                PTWBasicPages.Visible = false;
                PTWPages.SelectedIndex = 1;
                BasicPageMigration();
            }
            else 
            {
                btnPTWApproval.Visible = false;
                if(txtPermitStatus.Text=="Prepare")
                {
                    btnPTWDelete.Visible = true;
                }
                
            }
            ManageHeaderButtonLocation();
        }
        private void PTWBasicInitialize()
        {
            if (string.IsNullOrWhiteSpace(txtPTWBasicVendor.Text))
                txtPTWBasicVendor.Text = "N/A";
            dtpPermitTo.Format = DateTimePickerFormat.Custom;
            dtpPermitTo.CustomFormat = "dd-MM-yyyy";
            dtpPermitFrom.Format = DateTimePickerFormat.Custom;
            dtpPermitFrom.CustomFormat = "dd-MM-yyyy";
            dtpPermitFrom.Value = DateTime.Now;
            dtpPermitTo.Value = DateTime.Now;
            txtarea.Visible = false;
            txtareaName.Visible = false;
            string permitlink = ParentWindow.permitLink;
            lblIsoTotStatus.Visible = false;
            chkIsoTotStatus.Visible = false;
            if (Permitstatus == "") Permitstatus = "Prepare";
            this.TopMost = false;
            InitCmbHours();
        }
        private void dgvAddHazGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            AdditionalHazard addHazard = new AdditionalHazard();
            addHazard.PermitCode = dgvAddHazGrid.Rows[e.RowIndex].Cells["PermitCode"].Value.ToString();
            addHazard.Hazard = dgvAddHazGrid.Rows[e.RowIndex].Cells["Hazard"].Value.ToString();
            addHazard.Remarks = dgvAddHazGrid.Rows[e.RowIndex].Cells["Remarks"].Value.ToString();
            addHazard.AddHazId = int.Parse(dgvAddHazGrid.Rows[e.RowIndex].Cells["AddHazId"].Value.ToString());
            CreateAddHazardView(addHazard);
            ViewAddHazard(txtpermitCode.Text);
        }
        public AdditionalHazardView CreateAddHazardView(AdditionalHazard addHaz)
        {
            AdditionalHazardView addHazView = new AdditionalHazardView(addHaz.PermitCode, false);// (txtProcDocNo.Text);
            addHazView.MapAddHazardToView(addHaz);
            //procureItemDetailView.GetValue += AddItemDetailHandlerEvent;

            if (addHazView.ShowDialog() == DialogResult.OK)
            {
                //ViewProcureDetailData();

            }
            return addHazView;
        }
        private void btnPTWDelete_Click(object sender, EventArgs e)
        {
            DialogResult dgres = XtraMessageBox.Show("Are you sure want to delete ?", "Alert", MessageBoxButtons.YesNo);
            if (dgres == DialogResult.Yes)
            {
                Resources.Instance.DeletePTW(txtpermitCode.Text);
                XtraMessageBox.Show("Permit Deleted Successfully.");
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private bool ValidateIsolation()
        {
            System.Text.RegularExpressions.Regex expr = new System.Text.RegularExpressions.Regex(@"^[0-9]{10}$");
            bool IsValid = true;
            if (string.IsNullOrWhiteSpace(txtIsoLockNo.Text))
            {
                MessageBox.Show("Please fill LockNo!", "Alert", MessageBoxButtons.OK);
                IsValid = false;
            }
          else  if (string.IsNullOrWhiteSpace(txtIsoPersonName.Text))
            {
                MessageBox.Show("Please fill Person!", "Alert", MessageBoxButtons.OK);
                IsValid = false;
            }
          else  if (string.IsNullOrWhiteSpace(txtIsoContact.Text))
            {
                MessageBox.Show("Please fill ContactNo", "Alert", MessageBoxButtons.OK);
                IsValid = false;
            }
           

           else if (!expr.IsMatch(txtIsoContact.Text))
            {
                MessageBox.Show("Invalid Contact Format. Use 10 Digit Mobile No");
                IsValid = false;
                txtIsoContact.Focus();
            }
            return IsValid;
        }
        private int GeneratePTWId()
        {
            string permitStr = string.Empty;
            int ptCode = 0;
            Resources.Instance.GetMaxID("SP_GetHazardBasicPermitId", "@MaxID", ref ptCode);//Change by RP                                                                                         //  Resources.Instance.GetMaxID("SP_GetMaxPermitCode","@MaxID",ref ptCode);
                                                                                           //ptCode++;
            string preText = "PTW";
            //  Resources.Instance.GetMaxID("SP_GetMaxPermitCode","@MaxID",ref MaxPermitCode);//Change by RP
            if (ptCode == 0) ptCode = 1;
            else ptCode++;

            ////txtpermitCode.ReadOnly = false;
            txtpermitCode.Text = Convert.ToString(preText + '-' + 00 + ptCode);
            ////txtpermitCode.ReadOnly = true;

            return ptCode;
        }
        public void SetDefaultDateTime()
        {
            dtpPermitFrom.Value = DateTime.Now;
            dtpPermitTo.Value = DateTime.Now;
            dtpPermitTo.Format = DateTimePickerFormat.Custom;
            dtpPermitTo.CustomFormat = "dd-MM-yyyy";
            dtpPermitFrom.Format = DateTimePickerFormat.Custom;
            dtpPermitFrom.CustomFormat = "dd-MM-yyyy";

        }

        /// <summary>
        /// No mapping
        /// </summary>
        public void LoadIsolation()
        {
            var machineLocation = Resources.Instance.MachineDt.AsEnumerable().Where(X => X.Field<string>("MachineTagNo") == cmbBasicMachineIsolation.Text).FirstOrDefault().Field<string>("MachineLocation"); //Resources.Instance.MachineDt.AsEnumerable().Where(X => X.Field<string>("MachineTagNo") == cmbmachineIsolation.Text).FirstOrDefault().ToString();//Resources.Instance.GetMachineLocation(cmbmachineIsolation.Text);
            cmbPtwIsolatedArea.Text = machineLocation;
           // IsolationMaster = Resources.Instance.GetMachineConnectionInfo(cmbBasicMachineIsolation.Text);
            IsolatedMAchines = Resources.Instance.GetIsolatedMachines(cmbPermitCode.Text);
            //cmbSelMachine.DataSource = IsolationMaster;
           // cmbSelMachine.DisplayMember = "fromconnection";
           // cmbActivity.ValueMember = "fromconnection";
            LoadDataToIsolationGrid(cmbPermitCode.Text);
        }

        private void DBGridPermitList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                Permitstatus = DBPtwApproveGrid.Rows[e.RowIndex].Cells["ptwAppStatus"].Value.ToString();
                txtPermitStatus.Text = Permitstatus;
                //if (e.ColumnIndex == 1 && Permitstatus == "Waiting For Supply of Materials")
                //{
                //    inhouseRedirect = true;
                //    PermitCode = DBGridPermitList.Rows[e.RowIndex].Cells[1].Value.ToString();
                //    PermitToWork.PermitInHouse newInhouse = new PermitInHouse();
                //    newInhouse.Show();

                //}

                string status = DBPtwApproveGrid.Rows[e.RowIndex].Cells["ptwAppStatus"].Value.ToString();
                if (e.ColumnIndex == 1 && status == "Approved")
                {
                    PermitCode = DBPtwApproveGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                    PermitClosure closedPmt = new PermitClosure();
                    closedPmt.Show();
                }
                else
                {

                    PermitCode = DBPtwApproveGrid.Rows[e.RowIndex].Cells["ptwAppPermitCode"].Value.ToString();
                    // this.Close();
                    // CreatePermit npmt = new CreatePermit();

                    var frm = Application.OpenForms.Cast<Form>().Where(x => x.Name == "CreatePermit").FirstOrDefault();
                    if (null != frm)
                    {
                        isredirected = true;
                        PTWPages.SelectedTab = PTWPages.TabPages[0];
                        PTWBasicPages.SelectedTab = PTWBasicPages.TabPages[0];
                        this.PTWPages.SelectedTab = pgNewPermit;
                        frm.Show();
                        OnReload();
                    }
                }
                PTWBasicPages.Visible = true;
                //BasicPageMigration();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }

        }

        private void HidePTWPagesHeader()
        {
            PTWPages.Appearance = TabAppearance.FlatButtons;
            PTWPages.ItemSize = new Size(0, 1);
            PTWPages.SizeMode = TabSizeMode.Fixed;
           
            foreach (TabPage tab in PTWPages.TabPages)
            {
                tab.Hide();// = "";
            }
        }
        private void EnableOrDisableIsolation(bool chkval)
        {
            if (chkval == false)
            {
                FreezeIsolation(false);
            }
            else if (chkval == true)
            {
                FreezeIsolation(true);
            }
        }

        private void dgvIsolatedMachine_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            chkIsolationCompl.CheckState = CheckState.Unchecked;
            if (dgvIsolatedMachine.Rows[e.RowIndex].Cells["Status"].Value.ToString() == "Pending")
            {
                chkIsolationCompl.Checked = false;
            }
            else
            {
                chkIsolationCompl.CheckState = CheckState.Checked;
                chkIsolationCompl.Checked = true;
            }
            cmbSelMachine.Text= dgvIsolatedMachine.Rows[e.RowIndex].Cells["MachineName"].Value.ToString();
            lblLocation2.Text= dgvIsolatedMachine.Rows[e.RowIndex].Cells["Location"].Value.ToString();
            lblEquipName2.Text = dgvIsolatedMachine.Rows[e.RowIndex].Cells["MachineName"].Value.ToString();
            lblConnectorType2.Text = dgvIsolatedMachine.Rows[e.RowIndex].Cells["ConnectorType"].Value.ToString();
            txtIsoLockNo.Text = dgvIsolatedMachine.Rows[e.RowIndex].Cells["LockNo"].Value.ToString(); //isoDr["Lock No"].ToString();
            txtIsoContact.Text = dgvIsolatedMachine.Rows[e.RowIndex].Cells["ContactNo"].Value.ToString(); //isoDr["Contact No"].ToString();
            txtIsoPersonName.Text = dgvIsolatedMachine.Rows[e.RowIndex].Cells["PersonName"].Value.ToString(); //isoDr["Person Name"].ToString();
            pcbxPTWIsoSnap.Image=(Image)dgvIsolatedMachine.Rows[e.RowIndex].Cells["ptwIsoSnapImage"].Value;
            //var vv = isoDr["Snapshot"].ToString();
            //if (!string.IsNullOrWhiteSpace(isoDr["Snapshot"].ToString()))
            //    pcbxPTWIsoSnap.Image = GetImage(((byte[])isoDr["Snapshot"]));
            pnlIsoMachine.Visible = true;
            //txtIsoLockNo.Visible = true;
            //txtIsoContact.Visible = true;
            //txtIsoPersonName.Visible = true;
        }

        private void chkIsoTotStatus_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FilterPTWView(DataTable dt)
        {
            AddRowsToDTView(dt);
            for (int a = 0; a < DBGridViewPermit.Rows.Count; a++)
            {
                string status = DBGridViewPermit.Rows[a].Cells["ptwViewStatus"].Value.ToString();
                if (status == "Cancelled")
                {
                    DBGridViewPermit.Rows[a].DefaultCellStyle.BackColor = Color.Red;
                }
                else if (status == "Approved")
                {
                    DBGridViewPermit.Rows[a].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (status == "Requested")
                {
                    DBGridViewPermit.Rows[a].DefaultCellStyle.BackColor = Color.CadetBlue;
                }
                else if (status == "Waiting For Approval")
                {
                    DBGridViewPermit.Rows[a].DefaultCellStyle.BackColor = Color.Orange;
                }



                else if (status == "On-Hold")
                {
                    DBGridViewPermit.Rows[a].DefaultCellStyle.BackColor = Color.Orange;
                }
                else if (status == "Closed")
                {
                    DBGridViewPermit.Rows[a].DefaultCellStyle.BackColor = Color.LightBlue;
                }
                else if (status == "Waiting For Supply of Materials")
                {
                    DBGridViewPermit.Rows[a].DefaultCellStyle.BackColor = Color.Orange;
                }
            }
        }

        private void sparrowButton1_Click(object sender, EventArgs e)
        {
            string empid = GlobalDeclaration._holdInfo[0].UserId.ToString();
            DataTable dt = Resources.Instance.GetPermitDataPeriodic(Convert.ToInt32(empid), 2, Convert.ToDateTime(dtpFromDate.Text), Convert.ToDateTime(dtpToDate.Text));
            FilterPTWView(dt);
        }

        private void txtPTWViewSearch_TextChanged(object sender, EventArgs e)
         {
            try
            {
                if (DBGridViewPermit.DataSource == null) return;
                (DBGridViewPermit.DataSource as DataTable).DefaultView.RowFilter = string.Format("ptwViewPermitCode like '{0}%' OR ptwViewTypeofPermit like '{0}%' OR ptwViewCreatedBy like '{0}%' OR ptwViewAreaofWork like '{0}%' OR ptwViewApprovedBy like '{0}%' OR ptwViewStatus like '{0}%'", txtPTWViewSearch.Text);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }
        
        public void ManageHeaderButtonLocation()
        {
            if (Properties.Settings.Default.RoleID == 7 || Properties.Settings.Default.RoleID == 5)
            {
               btnPTWAllPermits.Location=btnPTWApproval.Location;
                btnPTWApproval.Location=btnPTWView.Location;
            }

           else
            {
                btnPTWNewPermit.Location = btnPTWApproval.Location;
            }
        }
        private void InitCmbHours()
        {
            try
            {
                if (cmbFromHours.Items.Count > 0)
                    cmbFromHours.Items.Clear();
                if (cmbToHours.Items.Count > 0)
                    cmbToHours.Items.Clear();
                if (cmbFromMinuts.Items.Count > 0)
                    cmbFromMinuts.Items.Clear();
                if (cmbToMinuts.Items.Count > 0)
                    cmbToMinuts.Items.Clear();
                for (int i = 0; i < 24; i++)
                {
                    cmbFromHours.Items.Add(i);
                    cmbToHours.Items.Add(i); 
                }
                for (int j = 0; j < 60; j++)
                {
                      cmbFromMinuts.Items.Add(j);
                      cmbToMinuts.Items.Add(j);
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log.Error(Ex.Message);
            }
        }
        /// <summary>
        /// New Permit submission
        /// </summary>
        public void SendMailSubmitToApprovedby()
        {
            string curruser = GlobalDeclaration._holdInfo[0].UserName;
            string mailTo = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("UserName") == cmbApprovedBy.Text).ToList().FirstOrDefault()["Email"].ToString();
            //string mailToName = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("Email") == mailTo).ToList().FirstOrDefault()["UserName"].ToString();
            string msgBody = string.Format("Hi {0},\n\nA permit {1} valid from {2} to {3} requested by {4} on {5} for {6}.\nKindly review and take appropriate action.\n\nThanks",
                     cmbApprovedBy.Text, txtpermitCode.Text, dtpfval, dtpTval, curruser,txtrequestdate.Text ,cmbPtwBasicArea.Text);
            string subject = string.Format("Permit Submitted for {0}", txtpermitCode.Text);
            GlobalDeclaration.SendMail(curruser, mailTo, null, subject, msgBody);
           //GlobalDeclaration.SendMail(curruser, "milan.s@sparrowrms.in", null, subject, msgBody);
        }


        /// <summary>
        /// permit approval from Approvar to Requester
        /// </summary>
        public void SendMailApproveToRequester()
        {
            string curruser = GlobalDeclaration._holdInfo[0].UserName;
            string mailTo = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("UserName") == txtrequestBy.Text).ToList().FirstOrDefault()["Email"].ToString();
            //string mailToName = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("Email") == mailTo).ToList().FirstOrDefault()["UserName"].ToString();
            string msgBody = string.Format("Hi {0},\n\nA permit {1} valid from {2} to {3} requested by you on {4} for {5} has been approved by {6}.\nKindly proceed with the work.\n\nThanks",
                     txtrequestBy.Text, txtpermitCode.Text, dtpfval, dtpTval, txtrequestdate.Text,cmbPtwBasicArea.Text,cmbApprovedBy.Text);
            string subject = string.Format("Permit Submitted for {0}", txtpermitCode.Text);
            GlobalDeclaration.SendMail(curruser, mailTo, null, subject, msgBody);
           // GlobalDeclaration.SendMail(curruser, "milan.s@sparrowrms.in", null, subject, msgBody);
        }
      
        /// <summary>
        /// Permit rejection from 
        /// </summary>
        public void SendMailRejectToRequester()
        {
            string curruser = GlobalDeclaration._holdInfo[0].UserName;
            string mailTo = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("UserName") == txtrequestBy.Text).ToList().FirstOrDefault()["Email"].ToString();
            //string mailToName = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("Email") == mailTo).ToList().FirstOrDefault()["UserName"].ToString();
            string msgBody = string.Format("Hi {0},\n\nA permit {1} valid from {2} to {3} requested by you on {4} for {5} has been rejected by {6}.\nKindly review and take appropriate action.\n\nThanks",
                     txtrequestBy.Text, txtpermitCode.Text, dtpfval, dtpTval, txtrequestdate.Text, cmbPtwBasicArea.Text, cmbApprovedBy.Text);
            string subject = string.Format("Permit Submitted for {0}", txtpermitCode.Text);
            GlobalDeclaration.SendMail(curruser, mailTo, null, subject, msgBody);
            //GlobalDeclaration.SendMail(curruser, "milan.s@sparrowrms.in", null, subject, msgBody);
        }
        public void SendMailCloserToRequester()
        {
            string curruser = GlobalDeclaration._holdInfo[0].UserName;
            string mailTo = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("UserName") == cmbApprovedBy.Text).ToList().FirstOrDefault()["Email"].ToString();
            //string mailToName = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("Email") == mailTo).ToList().FirstOrDefault()["UserName"].ToString();
            string msgBody = string.Format("Hi {0},\n\nThe permit {1} valid from {2} to {3} requested by {4} on {5} for {6} has been closed.\n\nThanks",
                     cmbApprovedBy.Text, txtpermitCode.Text, dtpfval, dtpTval, txtrequestBy.Text, txtrequestdate.Text, cmbPtwBasicArea.Text);
            string subject = string.Format("Permit Closed for {0}", txtpermitCode.Text);
            GlobalDeclaration.SendMail(curruser, mailTo, null, subject, msgBody);
            //GlobalDeclaration.SendMail(curruser, "milan.s@sparrowrms.in", null, subject, msgBody);
        }

        //private void SendMail(string fromMail, string mailTo, string mailCc, string Subject, string msgBody)
        //{

        //    //string mailTo = null;
        //    string FromMailAddress = string.Empty;
        //    string MailPassword = string.Empty;
        //    //string mailCc = null;
        //    string xmsg = string.Empty;
        //    MailMessage mail;
        //    HindalcoiOS.Configuration.MailConfig mConfig = HindalcoiOS.Configuration.MailConfig.Instance;
        //    mConfig.GetMailConfig();
        //    try
        //    {

        //        mail = new MailMessage();
        //        FromMailAddress = mConfig.MailFrom;// "support@sparrowrms.in";
        //        MailPassword = mConfig.MailPassword;// "Zoq36865";
        //        mail.From = new MailAddress(FromMailAddress, fromMail);// "support@sparrowrms.in");
        //    }
        //    catch
        //    {
        //        xmsg = "Configure Proper Credentials in SettingOptions";
        //        throw new Exception(xmsg);
        //    }
        //    //mail.Attachments.Add(stream);


        //    mail.Subject = Subject;// sfCred.Subject;
        //    mail.Body = msgBody;

        //    if (!string.IsNullOrEmpty(mailTo))
        //    {
        //        if (mailTo.Contains(','))
        //        {
        //            foreach (var address in mailTo.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries))
        //            {
        //                string mailAddress = address.Trim();
        //                mail.To.Add(new MailAddress(mailAddress));
        //            }
        //        }
        //        else
        //        {
        //            string mailAddress = mailTo.Trim();
        //            mail.To.Add(new MailAddress(mailAddress));
        //        }
        //    }

        //    if (!string.IsNullOrEmpty(mailCc))
        //    {
        //        if (mailCc.Contains(','))
        //        {
        //            foreach (var address in mailCc.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries))
        //            {
        //                string mailAddress = address.Trim();
        //                mail.CC.Add(new MailAddress(mailAddress));
        //            }
        //        }
        //        else
        //        {
        //            string mailAddress = mailCc.Trim();
        //            mail.CC.Add(new MailAddress(mailAddress));
        //        }
        //    }

        //    try
        //    {
        //        if (!string.IsNullOrEmpty(mailTo) && !string.IsNullOrEmpty(FromMailAddress))
        //        {
        //            SmtpClient smtp = new SmtpClient();
        //            smtp.Host = mConfig.Host;// "smtp.office365.com";
        //            smtp.EnableSsl = mConfig.MailSSL;// true; 
        //            smtp.Timeout = 200000;
        //            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //            smtp.Port = int.Parse(mConfig.Port); //587;
        //            smtp.UseDefaultCredentials = false;
        //            NetworkCredential nc = new NetworkCredential(FromMailAddress, MailPassword);
        //            smtp.Credentials = nc;
        //            ServicePointManager.ServerCertificateValidationCallback =
        //        delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        //        { return true; };

        //            smtp.Send(mail);
        //            mail.Dispose();
        //            smtp.Dispose();
        //            XtraMessageBox.Show("Mail Sent Successfully.");
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        //XtraMessageBox.Show("Mail setting/server not working, Configure and try again", "Jubilant Food System!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        /// <summary>
        /// jhkwdkwdgkjwwjkgdwjkdkwdgkwgkwgwgdkw
        /// </summary>
        ////////public DataTable GetAllUsers()
        ////////{
        ////////    LoadAllUsers = Resources.Instance.GetUserDetails_RMPCL(2);
        ////////    return LoadAllUsers;
        ////////}

        public void SetDateValue()
        {
             dtpfval = string.Format("{0} {1:00}:{2:00}", dtpFromDate.Value.ToString("dd-MM-yyyy"), int.Parse(cmbFromHours.Text), int.Parse(cmbFromMinuts.Text));
             dtpTval = string.Format("{0} {1:00}:{2:00}", dtpToDate.Value.ToString("dd-MM-yyyy"), int.Parse(cmbToHours.Text), int.Parse(cmbToMinuts.Text));
        }

        private void dtpPermitTo_ValueChanged(object sender, EventArgs e)
        {
            SetDateValue();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {

            ////XtraReport3 dd = new XtraReport3();
            ////ObjectDataSource ods = new ObjectDataSource();
            ////// typeof(PrintPermit);
            ////List<PrintPermit> prntPMT = new List<PrintPermit>();
            ////prntPMT.Add(prtPermit);
            ////ods.BeginInit();
            ////ods.DataSource = prntPMT;
            
            ////ods.DataMember = "prntPMT";
            ////ods.Constructor = new ObjectConstructorInfo();
            ////ods.EndInit();
            ////ods.Fill();

            ////dd.DataSource = ods;
            ////dd.RequestParameters = false;
            ////dd.ExportToPdf(@"D:\DDBBCKP\Permit.pdf");
            //DevExpress.XtraReports.Parameters.Parameter pmm = new DevExpress.XtraReports.Parameters.Parameter();
            //pmm.Value = txtpermitCode.Text;
            //  dd.Parameters.Add(pmm);
            //dd.DataSource = prtPermit;

            //ReportDesignTool dt = new ReportDesignTool(dd);

            // Invoke the standard End-User Designer form, modally.
            //dt.ShowDesignerDialog();

            // Invoke the standard End-User Designer form
            // without the PropertyGrid and ReportExplorer panels.
            //dt.ShowDesigner(UserLookAndFeel.Default, DesignDockPanelType.PropertyGrid |
            //DesignDockPanelType.ReportExplorer);

            // dd.ExportToPdf(@"D:\DDBBCKP\Permit.pdf");


            //XtraReport3 ddd = new XtraReport3();
            //ddd.DataSource = prtPermit;
            //List<PrintPermit> prntPMT = new List<PrintPermit>();
            //prntPMT.Add(prtPermit);
            //ddd.DataMember = "prntPMT";
            ////ReportPrintTool tool = new ReportPrintTool(ddd);
            ////tool.ShowPreview();
            //ddd.RequestParameters = false;
            //ddd.ExportToPdf(@"D:\DDBBCKP\Permit.pdf");
        }

        private void Dd_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            OnReload();
        }

        private void brnAuditMgmt_Click(object sender, EventArgs e)
        {
            AuditCalenderView auditCal = new AuditCalenderView();
            auditCal.Show();
            //DepartmentView auditCal = new DepartmentView();
            //auditCal.Show();
            //AuditCategoryView auditCate = new AuditCategoryView();
            //auditCate.Show();
            //AuditMasterView auditmaster = new AuditMasterView();
            //auditmaster.Show();
        }
    }

    public enum PermitStatus
    {
        Prepare = 0,
        SubmitForApproval = 1

    }

    public class PrintPermit
    {

        public PrintPermit()
        {
            GetReportValues(this);
        }
                //DataTable PTWAllData = Resources.Instance.GetAllPTWData(PermitCode);//Change by RP no Need to declare New DataTable Here
                //if (PTWAllData.Rows.Count == 0) return;
                ////txtpermitCode.ReadOnly = false;
        public string PermitCode { set; get; }
        public string PermitStatus { set; get; }
        public string dtpDurFrom { set; get; }
        public string dtpDurTo { set; get; }
        public string dtpPermitFrom { set; get; }
        public string dtpPermitTo { set; get; }
        public string Requestdate { set; get; }
        public string RequestBy { set; get; }
        public string BasicArea { set; get; }
        public string ApprovedBy { set; get; }
        public string WorkType { set; get; }
        public string Capability { set; get; }
        public string BasicVendor { set; get; }
        public string PermitTypeSelected { set; get; }
        public string Description { set; get; }
        public string MoniterNeed { set; get; }
        public string LelUelMeasure { set; get; }
        public string Telechazard { set; get; }
        public string Firehazard { set; get; }
        public string Height { set; get; }
        public string Crushing { set; get; }
        public string Vibration { set; get; }
        public string Temprature { set; get; }
        public string Noise { set; get; }
        public string Radiations { set; get; }
        public string Vapours { set; get; }
        public string Dust { set; get; }
        public string Guideline { set; get; }
        public string SplReqAreaName { set; get; }
        public string txtactivity { set; get; }
        public string cmbActivity { set; get; }
        public string Descspec { set; get; }
        public string RiskNoHira { set; get; }
        public string ControlType { set; get; }
        public string ConsequenceHIRA { set; get; }
        public string Desccontrol { set; get; }
        public string LikelihoodHIRA { set; get; }
        public string SeverityHIRA { set; get; }
        public string OwnerId { set; get; }
        public string RiskHIRA { set; get; }
        public string ReqPPE { set; get; }
        public string BasicMachineIsolation { set; get; }
        public string PtwComments { set; get; }

        public IEnumerable<PrintPermit> GetReportValues(PrintPermit prtPermit)
        {
            List<PrintPermit> printPermits = new List<PrintPermit>();
                printPermits.Add(prtPermit); 
                   return printPermits;
        }

        public static XtraReport CreateReport()
        {
            var departments = new StaticListLookUpSettings();
            departments.LookUpValues.AddRange(new[]{
                new LookUpValue("Management", "Management"),
                new LookUpValue("Financial", "Financial"),
                new LookUpValue("Sales", "Sales")});

            XtraReport report = new XtraReport()
            {
                Parameters = {
                    new DevExpress.XtraReports.Parameters.Parameter() {
                        Name = "pDepartment",
                        Type = typeof(System.String),
                        ValueSourceSettings = departments,
                        Description = "Department",
                        Value = "Management"
                    },
                    new DevExpress.XtraReports.Parameters.Parameter() {
                        Name = "NumberOfRecords",
                        Type = typeof(System.Int32),
                        Value = 2
                    }
                },
                Bands = {
                    new DetailBand(){
                        HeightF = 25,
                        Controls = {
                            new XRLabel() {
                                Name = "EmployeeName",
                                BoundsF = new RectangleF(0, 0, 200, 25),
                                ExpressionBindings =
                                {
                                    new ExpressionBinding("Text", "[Name]")
                                }
                            },
                            new XRLabel() {
                                Name = "EmployeePosition",
                                BoundsF = new RectangleF(200, 0, 150, 25),
                                ExpressionBindings = {
                                    new ExpressionBinding("Text", "[Position]")
                                }
                            }
                        }
                    }
                }
            };
            ObjectDataSource objectDataSource = new ObjectDataSource();
            objectDataSource.Name = "Employees";
            objectDataSource.DataSource = typeof(PrintPermit);
            objectDataSource.BeginUpdate();
            objectDataSource.DataMember = "GetEmployeeList";
            var parameterNumberOfRecords = new DevExpress.DataAccess.ObjectBinding.Parameter()
            {
                Name = "recordCount",
                Type = typeof(DevExpress.DataAccess.Expression),
                Value = new DevExpress.DataAccess.Expression("?NumberOfRecords", typeof(int))
            };
            objectDataSource.Parameters.Add(parameterNumberOfRecords);
            var parameterDepartment = new DevExpress.DataAccess.ObjectBinding.Parameter()
            {
                Name = "department",
                Type = typeof(DevExpress.DataAccess.Expression),
                Value = new DevExpress.DataAccess.Expression("?pDepartment", typeof(string))
            };
            objectDataSource.Constructor = new ObjectConstructorInfo(parameterDepartment);
            objectDataSource.EndUpdate();
            objectDataSource.Fill();
            report.DataSource = objectDataSource;

            return report;
        }

    }

    internal static class LogHelper
    {
        /// <summary>
                /// Creates a custom logger with given filename.
                /// </summary>
                /// <param name="filename">source file name</param>
                /// <returns>Returns a custom logger for the given source file.</returns>
        public static log4net.ILog GetLogger([CallerFilePath] string filename = "")
        {
            return log4net.LogManager.GetLogger(filename);
        }
    }
}



