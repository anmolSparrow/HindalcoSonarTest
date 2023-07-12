
using CADImport;
using ClosedXML.Excel;
using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using HindalcoiOS.InventoryMgmt;
using SparrowRMS;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
namespace HindalcoiOS.Maintenance
{
    public partial class MaintenanceNRM : DevExpress.XtraEditors.XtraForm
    {
        #region Variable Declaration
        public MaintenanceRMPCL maintenanceRMPCL;
        public EventHandler<string> ClearDic;
        CheckBox HeaderCheckBox = null;
        public DataTable LoadAllUsers { set; get; }
        #endregion

        #region Class Constructor
        public MaintenanceNRM()
        {
            InitializeComponent();
            ////UpdateTextPosition();
            maintenanceRMPCL = new MaintenanceRMPCL();
            // this.Text = "Maintenance";                        

        }
        public bool IsBRKCall { get; set; }

        public string btnStatus { get; set; }
        public MaintenanceNRM(FormStatus frmstatus)
        {
            InitializeComponent();
            UpdateTextPosition();
            maintenanceRMPCL = new MaintenanceRMPCL();
            if (frmstatus == FormStatus.New && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))
            {
                maintenanceRMPCL.InventoryCode = GenerateGlobalDocID("SP_GetConsumpDocID", "CON");
                maintenanceRMPCL.Status = Status.Prepare;
            }
        }
        #endregion

        #region Event List
        private void MaintenanceNRM_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(DialogResult== DialogResult.None || DialogResult== DialogResult.Cancel)
            this.ClearDic.Invoke(sender, maintenanceRMPCL.FormName);
        }
        private void MaintenanceNRM_Load(object sender, EventArgs e)
        {
            HidetabcontrolMNTHeader();
            DisableControlPermanent();
            GetAllUsers();
            //btnclosed.Visible = false;
            //textBox1.DataBindings.Add("Text", maintenanceRMPCL, "MachineTag"); this is way to bind property into text box                                                             
        }
        private void btnAddWorker_Click(object sender, EventArgs e)
        {
            try
            {
                //if (this.Height >= 786)
                //{
                //    this.Height = this.Height - (tabcontrolMNT.Height + 28);
                //}
                //else
                //{
                //    this.Height = this.Height + (tabcontrolMNT.Height + 28);
                //}
                tabcontrolMNT.SelectedIndex = 0;
                if (maintenanceRMPCL.FormStatus == FormStatus.Summary || maintenanceRMPCL.FormStatus == FormStatus.Closed)
                {
                    if (DGVWorker.Rows.Count > 0) return;
                    UploadWorker(true);
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                                    ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInvertory_Click(object sender, EventArgs e)
        {
            try
            {
                //if (this.Height >= 786)
                //{
                //    this.Height = this.Height - (tabcontrolMNT.Height + 28);
                //}
                //else
                //{
                //    this.Height = this.Height + (tabcontrolMNT.Height + 28);
                //}
                tabcontrolMNT.SelectedIndex = 1;
                if (maintenanceRMPCL.FormStatus == FormStatus.Summary || (maintenanceRMPCL.Status == Status.Closed) || (maintenanceRMPCL.Status == Status.Pending))
                {
                    if (DGVInventory.Rows.Count > 0) return;
                    UploadInventroryGrid();
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void addWorkerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (((ToolStripMenuItem)sender).Tag.ToString() == "Add")
                {
                    if ((maintenanceRMPCL.FormStatus == FormStatus.New || maintenanceRMPCL.FormStatus == FormStatus.Summary) && (maintenanceRMPCL.Status == Status.Submitted || maintenanceRMPCL.Status == Status.Reported || maintenanceRMPCL.Status == Status.Prepare|| maintenanceRMPCL.Status == Status.Open|| maintenanceRMPCL.Status == Status.Pending) && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        DGVWorker.Rows.Add(dr);
                        int index = DGVWorker.Rows.Count - 1;
                        DGVWorker.Rows[index].Cells["MaintenanceCode"].Value = maintenanceRMPCL.MaintenanceCode;
                        DGVWorker.Rows[index].Cells["StatusW"].Value = "New";
                        DGVWorker.Enabled = true;
                    }
                }
                else if (((ToolStripMenuItem)sender).Tag.ToString() == "Remove")
                {
                    if ((maintenanceRMPCL.FormStatus == FormStatus.New || maintenanceRMPCL.FormStatus == FormStatus.Summary) && (maintenanceRMPCL.Status == Status.Submitted || maintenanceRMPCL.Status == Status.Reported|| maintenanceRMPCL.Status == Status.Open || maintenanceRMPCL.Status == Status.Prepare) && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))
                    {
                        if (DGVWorker.SelectedRows.Count > 0)
                        {
                            DGVWorker.Rows.RemoveAt(DGVWorker.SelectedRows[0].Index);

                        }
                    }
                }
                else if (((ToolStripMenuItem)sender).Tag.ToString() == "AddINV")
                {
                    if ((maintenanceRMPCL.FormStatus == FormStatus.New || maintenanceRMPCL.FormStatus == FormStatus.Summary) && (maintenanceRMPCL.Status == Status.Submitted || maintenanceRMPCL.Status == Status.Open|| maintenanceRMPCL.Status == Status.Prepare) && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))
                    {
                        // maintenanceRMPCL.Status == Status.Open Extra Add(in case when Status Is Open then User Can Also Add Invertory and Worker
                        if (maintenanceRMPCL.Status == Status.Submitted || maintenanceRMPCL.Status == Status.Reported || maintenanceRMPCL.Status == Status.Open|| maintenanceRMPCL.Status == Status.Prepare)
                        {

                            if (dropdownAssignTo.SelectedItem == null)//New Line Add for Fill the Assign Person Name into DropDown
                            {
                                XtraMessageBox.Show("Please Assign The User For Execution This Task!!",
                                        ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                dropdownAssignTo.Focus();
                                return;
                            }
                            if(maintenanceRMPCL.InventoryCode == null)
                            maintenanceRMPCL.InventoryCode = GenerateGlobalDocID("SP_GetConsumpDocID", "CON");
                            AddMoreInventory();
                        }
                    }
                    // this below condition for add more inventory when inventory created by BreakDown Window
                    else if ((maintenanceRMPCL.FormStatus == FormStatus.New|| maintenanceRMPCL.FormStatus == FormStatus.Summary) && (maintenanceRMPCL.Status == Status.Pending|| maintenanceRMPCL.Status == Status.Reported) && (maintenanceRMPCL.MaintenanceCode.Contains("BRK-")))
                    {
                        if(maintenanceRMPCL.MaintenanceCode.Contains("BRK-") && maintenanceRMPCL.InventoryCode==null)
                        {
                            maintenanceRMPCL.InventoryCode = GenerateGlobalDocID("SP_GetConsumpDocID", "CON");
                           // IsBRKCall = true;// this is for Add Inventory when uer add from maintenence Summary screen
                        }
                        AddMoreInventory();
                    }
                }
                else if (((ToolStripMenuItem)sender).Tag.ToString() == "RemoveINV")
                {
                    if ((maintenanceRMPCL.FormStatus == FormStatus.New || maintenanceRMPCL.FormStatus == FormStatus.Summary) && (maintenanceRMPCL.Status == Status.Open || maintenanceRMPCL.Status == Status.Submitted|| maintenanceRMPCL.Status == Status.Prepare || maintenanceRMPCL.Status == Status.Reported) && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))
                    {
                        if (DGVInventory.SelectedRows == null) return;
                            string itmcd = DGVInventory.SelectedRows[0].Cells["itemCode"].Value.ToString();
                            string itmBatchNo=DGVInventory.SelectedRows[0].Cells["BatchNo"].Value.ToString();
                        
                        DeleteConsumption(maintenanceRMPCL.MaintenanceCode, maintenanceRMPCL.InventoryCode, itmcd,itmBatchNo);
                        if (DGVInventory.SelectedRows.Count > 0)
                        {
                           DGVInventory.Rows.RemoveAt(DGVInventory.SelectedRows[0].Index);
                        }
                        
                    }
                }
                else if (((ToolStripMenuItem)sender).Tag.ToString() == "ReturnINV")
                {
                    if (DGVInventory.Rows.Count > 0 && DGVInventory.SelectedRows.Count > 0)
                    {
                        if (maintenanceRMPCL.Status != Status.Closed && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))
                        {
                            if (string.IsNullOrEmpty(maintenanceRMPCL.InventoryReturnCode))
                                maintenanceRMPCL.InventoryReturnCode = GenerateGlobalDocID("SP_GetReturnDocID", "RET");
                            // By Milan To stop DocNo Doubling-----
                            int icount = 0;
                            icount = Resources.Instance.IsReturnExit(maintenanceRMPCL.InventoryReturnCode, out icount);
                            if (icount == 0)
                            {
                                maintenanceRMPCL.InventoryReturnCode = GenerateGlobalDocID("SP_GetReturnDocID", "RET");
                            }
                            string Docunumber = DGVInventory.SelectedRows[0].Cells["DocumentNo"].Value.ToString();
                            ItemReturnDetails(DGVInventory.SelectedRows[0].Index, Docunumber);
                            //ItemReturnDetails(DGVInventory.SelectedRows[0].Index, maintenanceRMPCL.InventoryReturnCode);
                            //string Docunumber = DGVInventory.SelectedRows[0].Cells["DocumentNo"].Value.ToString();
                            ReturnItemDetailView returnItemDetail = new ReturnItemDetailView(maintenanceRMPCL.InventoryReturnCode, maintenanceRMPCL.MaintenanceCode, true,true);
                            returnItemDetail.Selecteditem = DGVInventory.SelectedRows[0].Cells["ItemName"].Value;
                            if (returnItemDetail.ShowDialog() == DialogResult.OK)
                            {
                                // By Milan To stop DocNo Doubling-----
                                ////ItemReturnDetails(DGVInventory.SelectedRows[0].Index, returnItemDetail.returnItemDetail.DocumentNo);// Docunumber);
                                ItemReturnDetails(DGVInventory.SelectedRows[0].Index, Docunumber);
                                returnItemDetail.Close();
                                returnItemDetail.Dispose();
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddMoreInventory()
        {
            try
            {
                if (!string.IsNullOrEmpty(maintenanceRMPCL.InventoryCode))
                {
                    //* By Milan to stop DocNo doubling--------------
                    int icount = 0;
                    icount = Resources.Instance.IsConsumptionExit(maintenanceRMPCL.InventoryCode, out icount);
                    string _conDocNo = string.Empty;
                    if (icount == 0)
                    {
                        _conDocNo = GenerateGlobalDocID("SP_GetConsumpDocID", "CON");
                        maintenanceRMPCL.InventoryCode = _conDocNo;
                    }
                   

                    ItemConsuptionDetails();
                    //ConsumpItemDetailView consumpItemDetailView = new ConsumpItemDetailView(_conDocNo, maintenanceRMPCL.MaintenanceCode, true, true);
                   ConsumpItemDetailView consumpItemDetailView = new ConsumpItemDetailView(maintenanceRMPCL.InventoryCode, maintenanceRMPCL.MaintenanceCode, true,true);
                    consumpItemDetailView.mapInventory += Connector_Event;
                    consumpItemDetailView.StartPosition = FormStartPosition.CenterScreen;
                    if (consumpItemDetailView.ShowDialog() == DialogResult.OK)
                    {
                        //ViewConsumptionDetailData();

                        ////ItemConsuptionDetails();
                        LoadInvertory(Resources.Instance.GetConsumedItemDetail(maintenanceRMPCL.InventoryCode, maintenanceRMPCL.MaintenanceCode));
                        consumpItemDetailView.Dispose();
                        SaveParentFrmData(true);
                    }
                    consumpItemDetailView.Close();
                    consumpItemDetailView.Dispose();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveParentFrmData(bool IsInventriCall)
        {
            try
            {
                if (IsInventriCall && DGVInventory.Rows.Count > 0 && IsBRKCall)
                {
                    int Staus = 0;
                    string result = string.Empty;
                    if (string.IsNullOrEmpty(rtchtext.Text))
                    {
                        XtraMessageBox.Show("Please fill decsription details!!!!!!",
                                     ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        rtchtext.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(txtArea.Text) && dropdownmachinetag.Text != "NA")
                    {
                        XtraMessageBox.Show("Please fill area details !",
                                 ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtArea.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(txtExtactlocation.Text))
                    {
                        XtraMessageBox.Show("Please fill Exactlocation details !",
                                 ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtExtactlocation.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(dropdownAssignTo.SelectedItem.ToString()))
                    {
                        XtraMessageBox.Show("Please Assign The User For Execution This Task!!",
                                ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dropdownAssignTo.Focus();
                        return;
                    }
                    //if (maintenanceRMPCL.Status == Status.Prepare && WorkingHour() >= 7200 && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))//Add Also Current User
                    //{
                    //    if (string.IsNullOrEmpty(dropdownAssignTo.SelectedItem.ToString()))
                    //    {
                    //        XtraMessageBox.Show("Please Assign The User For Execution This Task!!",
                    //                ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //        dropdownAssignTo.Focus();
                    //        return;
                    //    }
                    //    /// Waiting for appraval request...
                    //    maintenanceRMPCL.Status = Status.ForApporval;
                    //    dropdownstatus.SelectedItem = maintenanceRMPCL.Status;
                    //    if (string.IsNullOrEmpty(rtchcomments.Text))
                    //    {
                    //        maintenanceRMPCL.Comments = "";
                    //    }
                    //    //Save in DB
                    //}
                    //else if (maintenanceRMPCL.Status == Status.Prepare && WorkingHour() < 7200 && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))// Add Current User
                    //{
                    //    if (string.IsNullOrEmpty(dropdownAssignTo.SelectedItem.ToString()))
                    //    {
                    //        XtraMessageBox.Show("Please Assign The User For Execution This Task!!",
                    //                ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //        dropdownAssignTo.Focus();
                    //        return;
                    //    }
                    //    //Insert in DB When Self Appproval...
                    //    maintenanceRMPCL.Status = Status.Open;
                    //    dropdownstatus.SelectedItem = maintenanceRMPCL.Status;
                    //    if (string.IsNullOrEmpty(rtchcomments.Text))
                    //    {
                    //        maintenanceRMPCL.Comments = "";
                    //    }
                    //}
                    //else if (maintenanceRMPCL.Status == Status.Prepare && WorkingHour() == 0 && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Operation")) //Add Current User Condition
                    //{
                    //    maintenanceRMPCL.Status = Status.Submitted;
                    //    dropdownstatus.SelectedItem = maintenanceRMPCL.Status;
                    //    if (dropdownAssignTo.SelectedItem == null)
                    //    {
                    //        maintenanceRMPCL.AssignTo = maintenanceRMPCL.ReportedBy;
                    //        //Update Data in DB  when  maintenance request send by non maintenance user to Maintenance user..
                    //    }
                    //    if (string.IsNullOrEmpty(rtchcomments.Text))
                    //    {
                    //        maintenanceRMPCL.Comments = "";
                    //    }
                    //}
                    //else if (maintenanceRMPCL.Status == Status.Submitted && WorkingHour() < 7200 && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))
                    //{
                    //    if (string.IsNullOrEmpty(dropdownAssignTo.SelectedItem.ToString()))
                    //    {
                    //        XtraMessageBox.Show("Please Assign The User For Execution This Task!!",
                    //                ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //        dropdownAssignTo.Focus();
                    //        return;
                    //    }
                    //    // After  Geting From Non Maintenance user  then sumbit
                    //    maintenanceRMPCL.Status = Status.Pending;
                    //    dropdownstatus.SelectedItem = maintenanceRMPCL.Status;
                    //}
                    //else if (maintenanceRMPCL.Status == Status.Submitted && WorkingHour() >= 7200 && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))
                    //{
                    //    if (string.IsNullOrEmpty(dropdownAssignTo.SelectedItem.ToString()))
                    //    {
                    //        XtraMessageBox.Show("Please Assign The User For Execution This Task!!",
                    //                ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //        dropdownAssignTo.Focus();
                    //        return;
                    //    }
                    //    // after getting request from nonmanintenance user then assign time if time getting more than equal 2 hour.
                    //    maintenanceRMPCL.Status = Status.Pending;
                    //    dropdownstatus.SelectedItem = maintenanceRMPCL.Status;
                    //}
                    //else if ((maintenanceRMPCL.Status == Status.Pending || maintenanceRMPCL.Status == Status.Rejected) && !maintenanceRMPCL.MaintenanceCode.Contains("BRK-"))// Update Record
                    //{
                    //    maintenanceRMPCL.Status = Status.Pending;
                    //    dropdownstatus.SelectedItem = maintenanceRMPCL.Status;
                    //    Staus = Resources.Instance.UpdateMaintenaceRMPCLRecord(maintenanceRMPCL.MaintenanceCode, WorkingHour(), ((int)maintenanceRMPCL.Status), maintenanceRMPCL.AssignTo, ref result);
                    //}
                    if (maintenanceRMPCL.Status == Status.Submitted || maintenanceRMPCL.Status == Status.Open || maintenanceRMPCL.Status == Status.Reported) // Insert Record
                    {//Kal check karna hai
                        if (maintenanceRMPCL.Status == Status.Reported)
                        {
                            if (maintenanceRMPCL.MaintenanceCode.Contains("BRK-") && (WorkingHour() >= 7200) && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))// When request Came from Brk From
                            {
                                maintenanceRMPCL.Status = Status.ForApporval;
                                dropdownstatus.SelectedItem = maintenanceRMPCL.Status;
                                maintenanceRMPCL.Comments = "";
                            }
                            else if (maintenanceRMPCL.MaintenanceCode.Contains("BRK-") && (WorkingHour() <= 7200) && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))
                            {
                                maintenanceRMPCL.Status = Status.Pending;
                                dropdownstatus.SelectedItem = maintenanceRMPCL.Status;
                                maintenanceRMPCL.Comments = "";
                            }
                            Staus = Resources.Instance.InsertRMPCLMNT(maintenanceRMPCL.MaintenanceCode, maintenanceRMPCL.Date, ((int)maintenanceRMPCL.OperationPlant), ((int)maintenanceRMPCL.Status), maintenanceRMPCL.MachineTag, maintenanceRMPCL.Others, ((int)maintenanceRMPCL.Priority), maintenanceRMPCL.ExactLocation, WorkingHour(), maintenanceRMPCL.Area, maintenanceRMPCL.ReportedBy, maintenanceRMPCL.Description, maintenanceRMPCL.Comments, maintenanceRMPCL.AssignTo, ref result);
                        }
                    }
                    //// this condition for add more inventory if inventory added from BreakDown Form or window
                    else if (maintenanceRMPCL.MaintenanceCode.Contains("BRK-") && maintenanceRMPCL.Status == Status.Pending)
                    {
                        Staus = Resources.Instance.UpdateMaintenaceRMPCLRecord(maintenanceRMPCL.MaintenanceCode, WorkingHour(), ((int)maintenanceRMPCL.Status), maintenanceRMPCL.AssignTo, ref result);
                    }
                    if (Staus > 0)
                    {
                        // Result shown in Meassage Box
                        MessageBox.Show(result, "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign);
                        btnStatus = "Submitted";
                        //DialogResult = DialogResult.OK;
                        if (DGVInventory.Rows.Count > 0)
                        {
                            AuditReportInsertion auditReportInsertion = new AuditReportInsertion();
                            string MSG = auditReportInsertion.InsertMNTInventory(DGVInventory, maintenanceRMPCL.MaintenanceCode, "Maintenance");
                            if (!string.IsNullOrEmpty(MSG))
                            {
                                DGVInventory.Rows.Cast<DataGridViewRow>().ToList().ForEach(f => f.Cells["StatusI"].Value = "Saved");
                                MessageBox.Show(MSG, "Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RightAlign);
                                //DialogResult = DialogResult.OK;
                                btnStatus = "Submitted";
                            }
                        }
                        if (DGVWorker.Rows.Count > 0)
                        {
                            AuditReportInsertion auditReportInsertion = new AuditReportInsertion();
                            string MSG = auditReportInsertion.InsertMNTWorkers(DGVWorker, maintenanceRMPCL.MaintenanceCode);
                            if (!string.IsNullOrEmpty(MSG))
                            {
                                DGVWorker.Rows.Cast<DataGridViewRow>().ToList().ForEach(f => f.Cells["StatusW"].Value = "Saved");
                                MessageBox.Show(MSG, "Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.RightAlign);
                                //DialogResult = DialogResult.OK;
                                btnStatus = "Submitted";
                            }
                        }
                        if (DGVRequestDetails.SelectedRows.Count > 0)
                        {
                            if (((Status)DGVRequestDetails.SelectedRows[0].Cells["Statuss"].Value) == Status.Submitted)
                            {
                                DGVRequestDetails.Rows.Clear();
                                Loaddata();
                            }
                        }
                    }
                    DisableControl();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                                    ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnsumbitaprl_Click(object sender, EventArgs e)
        {
            try
            {
                int Staus = 0;
                string result = string.Empty;
                if (string.IsNullOrEmpty(rtchtext.Text))
                {
                    XtraMessageBox.Show("Please fill decsription details!!!!!!",ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    rtchtext.Focus();
                    return;
                }                
                if (string.IsNullOrEmpty(txtArea.Text) && dropdownmachinetag.Text != "NA")
                {
                    XtraMessageBox.Show("Please fill area details !",
                             ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtArea.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtExtactlocation.Text))
                {
                    XtraMessageBox.Show("Please fill Exactlocation details !",
                             ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtExtactlocation.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtothers.Text) && dropdownmachinetag.Text == "NA")
                {
                    XtraMessageBox.Show("Please fill others details !",
                             ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtothers.Focus();
                    return;
                }
                if (maintenanceRMPCL.Status == Status.Prepare && WorkingHour() >= 7200 && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))//Add Also Current User
                {
                    if (dropdownAssignTo.SelectedItem == null)
                    {
                        XtraMessageBox.Show("Please Assign The User For Execution This Task!!",
                                ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dropdownAssignTo.Focus();
                        return;
                    }
                    /// Waiting for appraval request...
                    maintenanceRMPCL.Status = Status.ForApporval;
                    dropdownstatus.SelectedItem = maintenanceRMPCL.Status;
                    if (string.IsNullOrEmpty(rtchcomments.Text))
                    {
                        maintenanceRMPCL.Comments = "";
                    }
                    //Save in DB
                    Staus = Resources.Instance.InsertRMPCLMNT(maintenanceRMPCL.MaintenanceCode, maintenanceRMPCL.Date, ((int)maintenanceRMPCL.OperationPlant), ((int)maintenanceRMPCL.Status), maintenanceRMPCL.MachineTag, maintenanceRMPCL.Others, ((int)maintenanceRMPCL.Priority), maintenanceRMPCL.ExactLocation, WorkingHour(), maintenanceRMPCL.Area, maintenanceRMPCL.ReportedBy, maintenanceRMPCL.Description, maintenanceRMPCL.Comments, maintenanceRMPCL.AssignTo, ref result);
                    SendMailToMaintGM();
                }
                else if (maintenanceRMPCL.Status == Status.Prepare && WorkingHour() < 7200 && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))// Add Current User
                {
                    if (string.IsNullOrEmpty(dropdownAssignTo.Text))//.SelectedItem.ToString()))
                    {
                        XtraMessageBox.Show("Please Assign The User For Execution This Task!!",
                                ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dropdownAssignTo.Focus();
                        return;
                    }
                    //Insert in DB When Self Appproval...
                    maintenanceRMPCL.Status = Status.Open;
                    dropdownstatus.SelectedItem = maintenanceRMPCL.Status;
                    if (string.IsNullOrEmpty(rtchcomments.Text))
                    {
                        maintenanceRMPCL.Comments = "";
                    }
                    // New Line Add for Self Approval Statge and New Entry Insertion In DB Edit by RP (12-11-2022)
                    Staus = Resources.Instance.InsertRMPCLMNT(maintenanceRMPCL.MaintenanceCode, maintenanceRMPCL.Date, ((int)maintenanceRMPCL.OperationPlant), ((int)maintenanceRMPCL.Status), maintenanceRMPCL.MachineTag, maintenanceRMPCL.Others, ((int)maintenanceRMPCL.Priority), maintenanceRMPCL.ExactLocation, WorkingHour(), maintenanceRMPCL.Area, maintenanceRMPCL.ReportedBy, maintenanceRMPCL.Description, maintenanceRMPCL.Comments, maintenanceRMPCL.AssignTo, ref result);

                    SendMailSubmitToAssigned();
                
                }
                else if (maintenanceRMPCL.Status == Status.Prepare && WorkingHour() == 0 && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Operation")) //Add Current User Condition
                {
                    maintenanceRMPCL.Status = Status.Submitted;
                    dropdownstatus.SelectedItem = maintenanceRMPCL.Status;
                    if (dropdownAssignTo.SelectedItem == null)
                    {
                        maintenanceRMPCL.AssignTo = maintenanceRMPCL.ReportedBy;
                        //Update Data in DB  when  maintenance request send by non maintenance user to Maintenance user..
                    }
                    if (string.IsNullOrEmpty(rtchcomments.Text))
                    {
                        maintenanceRMPCL.Comments = "";
                    }
                }
                else if (maintenanceRMPCL.Status == Status.Submitted && WorkingHour() < 7200 && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))
                {

                    if (string.IsNullOrEmpty(dropdownAssignTo.SelectedItem.ToString()))
                    {
                        XtraMessageBox.Show("Please Assign The User For Execution This Task!!",
                                ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dropdownAssignTo.Focus();
                        return;
                    }
                    // After  Geting From Non Maintenance user  then sumbit
                    maintenanceRMPCL.Status = Status.Pending;
                    dropdownstatus.SelectedItem = maintenanceRMPCL.Status;
                }
                else if (maintenanceRMPCL.Status == Status.Submitted && WorkingHour() >= 7200 && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))
                {
                    if (string.IsNullOrEmpty(dropdownAssignTo.SelectedItem.ToString()))
                    {
                        XtraMessageBox.Show("Please Assign The User For Execution This Task!!",
                                ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dropdownAssignTo.Focus();
                        return;
                    }
                    // after getting request from nonmanintenance user then assign time if time getting more than equal 2 hour.
                    maintenanceRMPCL.Status = Status.Pending;
                    dropdownstatus.SelectedItem = maintenanceRMPCL.Status;
                }
                else if (maintenanceRMPCL.Status == Status.Pending || maintenanceRMPCL.Status == Status.Rejected)// Update Record
                {
                    if (maintenanceRMPCL.MaintenanceCode.Contains("BRK-") && (WorkingHour() >= 7200)&& GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))// When request Came from Brk From
                    {
                        maintenanceRMPCL.Status = Status.ForApporval;
                        dropdownstatus.SelectedItem = maintenanceRMPCL.Status;
                    }
                    //this is used for resumbit for approval  by Self creatde user without ny updation in exsiting Data
                    else if ((WorkingHour() >= 7200) && maintenanceRMPCL.Status == Status.Rejected && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))
                    {
                        maintenanceRMPCL.Status = Status.ForApporval;
                        dropdownstatus.SelectedItem = maintenanceRMPCL.Status;
                    }
                    else
                    {
                        maintenanceRMPCL.Status = Status.Pending;
                        dropdownstatus.SelectedItem = maintenanceRMPCL.Status;
                    }
                    Staus = Resources.Instance.UpdateMaintenaceRMPCLRecord(maintenanceRMPCL.MaintenanceCode, WorkingHour(), ((int)maintenanceRMPCL.Status), maintenanceRMPCL.AssignTo, ref result);
                }
                else if ((maintenanceRMPCL.Status == Status.Open && maintenanceRMPCL.FormStatus == FormStatus.Summary))
                {
                    //if(maintenanceRMPCL.Status == Status.Open && maintenanceRMPCL.AssignTo!= GlobalDeclaration._holdInfo[0].UserName)
                    //{
                    //    Staus = Resources.Instance.InsertRMPCLMNT(maintenanceRMPCL.MaintenanceCode, maintenanceRMPCL.Date, ((int)maintenanceRMPCL.OperationPlant), ((int)maintenanceRMPCL.Status), maintenanceRMPCL.MachineTag, maintenanceRMPCL.Others, ((int)maintenanceRMPCL.Priority), maintenanceRMPCL.ExactLocation, WorkingHour(), maintenanceRMPCL.Area, maintenanceRMPCL.ReportedBy, maintenanceRMPCL.Description, maintenanceRMPCL.Comments, maintenanceRMPCL.AssignTo, ref result);
                    //}
                    //else
                    //{
                        
                    //}
                    Staus = Resources.Instance.UpdateMaintenaceRMPCLRecord(maintenanceRMPCL.MaintenanceCode, WorkingHour(), ((int)maintenanceRMPCL.Status), maintenanceRMPCL.AssignTo, ref result);

                }
                else if (maintenanceRMPCL.Status == Status.Submitted || maintenanceRMPCL.Status == Status.Open || maintenanceRMPCL.Status == Status.Reported) // Insert Record
                {
                    if (maintenanceRMPCL.Status == Status.Reported)
                    {
                        if (maintenanceRMPCL.MaintenanceCode.Contains("BRK-") && (WorkingHour() >= 7200) && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))// When request Came from Brk From
                        {
                            maintenanceRMPCL.Status = Status.ForApporval;
                            dropdownstatus.SelectedItem = maintenanceRMPCL.Status;
                            maintenanceRMPCL.Comments = "";
                        }
                        else
                        {
                            maintenanceRMPCL.Status = Status.Pending;
                            dropdownstatus.SelectedItem = maintenanceRMPCL.Status;
                            maintenanceRMPCL.Comments = "";
                        }
                        Staus = Resources.Instance.InsertRMPCLMNT(maintenanceRMPCL.MaintenanceCode, maintenanceRMPCL.Date, ((int)maintenanceRMPCL.OperationPlant), ((int)maintenanceRMPCL.Status), maintenanceRMPCL.MachineTag, maintenanceRMPCL.Others, ((int)maintenanceRMPCL.Priority), maintenanceRMPCL.ExactLocation, WorkingHour(), maintenanceRMPCL.Area, maintenanceRMPCL.ReportedBy, maintenanceRMPCL.Description, maintenanceRMPCL.Comments, maintenanceRMPCL.AssignTo, ref result);
                    }                   
                }
                if (Staus > 0)
                {

                    // Result shown in Meassage Box
                    MessageBox.Show(result, "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                    btnStatus = "Submitted";

                    if (DGVInventory.Rows.Count > 0)
                    {
                        AuditReportInsertion auditReportInsertion = new AuditReportInsertion();
                        string MSG = auditReportInsertion.InsertMNTInventory(DGVInventory, maintenanceRMPCL.MaintenanceCode, "Maintenance");
                        if (!string.IsNullOrEmpty(MSG))
                        {
                            DGVInventory.Rows.Cast<DataGridViewRow>().ToList().ForEach(f => f.Cells["StatusI"].Value = "Saved");
                            MessageBox.Show(MSG, "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign);
                            //DialogResult = DialogResult.OK;
                            btnStatus = "Submitted";

                        }
                    }
                    if (DGVWorker.Rows.Count > 0)
                    {
                        AuditReportInsertion auditReportInsertion = new AuditReportInsertion();
                        string MSG = auditReportInsertion.InsertMNTWorkers(DGVWorker, maintenanceRMPCL.MaintenanceCode);
                        if (!string.IsNullOrEmpty(MSG))
                        {
                            DGVWorker.Rows.Cast<DataGridViewRow>().ToList().ForEach(f => f.Cells["StatusW"].Value = "Saved");
                            MessageBox.Show(MSG, "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign);
                            // DialogResult = DialogResult.OK;
                            btnStatus = "Submitted";
                        }
                    }
                    if (DGVRequestDetails.SelectedRows.Count > 0)
                    {
                        if (((Status)DGVRequestDetails.SelectedRows[0].Cells["Statuss"].Value) == Status.Submitted)
                        {
                            DGVRequestDetails.Rows.Clear();
                            Loaddata();
                        }
                    }
                }
                DisableControl();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dropdownmachinetag_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                maintenanceRMPCL.MachineTag = dropdownmachinetag.SelectedItem.ToString();
                if (dropdownmachinetag.SelectedItem.ToString() == "NA" || dropdownmachinetag.Text == "NA")
                {
                    maintenanceRMPCL.Area = txtArea.Text = string.Empty;
                    txtArea.Enabled = false;
                    txtothers.Enabled = true;                    
                    //if (string.IsNullOrEmpty(txtArea.Text))
                        
                }
                else
                {
                    txtArea.Text = maintenanceRMPCL.Area = AddMachineArea();
                    txtArea.Enabled = false;
                    txtothers.Enabled = false;
                    maintenanceRMPCL.Others = txtothers.Text = "";
                    // dropdownmachinetag.Enabled = false;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                                       ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Approve button Event Fire
        private void btnApproval_Click(object sender, EventArgs e)
        {
            try
            {
                if (maintenanceRMPCL.Status == Status.ForApporval && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-GM"))
                {
                    if (DGVRequestDetails.SelectedRows.Count > 0)
                    {                        
                        CommentsFrm commentsFrm = new CommentsFrm();
                        if (DialogResult.OK == commentsFrm.ShowDialog())
                        {
                            maintenanceRMPCL.Status = Status.Approved;
                            dropdownstatus.SelectedItem = maintenanceRMPCL.Status;
                            DGVRequestDetails.SelectedRows[0].Cells["Statuss"].Value = maintenanceRMPCL.Status;
                            DGVRequestDetails.SelectedRows[0].DefaultCellStyle.BackColor = Color.LimeGreen;
                            DGVRequestDetails.SelectedRows[0].ReadOnly = true;
                            string commts = commentsFrm.txtcomments.Text;
                            commentsFrm.Close();
                            if (DialogResult.OK == UpdateDBRow(DGVRequestDetails.SelectedRows[0].Cells["MCode"].Value.ToString(), commts, "Task Approved Successfully!!"))
                            {
                                DGVRequestDetails.SelectedRows[0].Cells["Remark"].Value = maintenanceRMPCL.Comments = commts;
                                btnApproval.Enabled = false;
                                btnReject.Enabled = false;
                                btnApproval.Enabled = false;
                                SendMailApproveToMaint();
                            }
                        }
                    }
                    // maintenanceRMPCL.Status = Status.Approved;
                    // dropdownstatus.SelectedItem = maintenanceRMPCL.Status;

                }
                else if (maintenanceRMPCL.Status == Status.Submitted && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))
                {
                    maintenanceRMPCL.Status = Status.Pending;
                    dropdownstatus.SelectedItem = maintenanceRMPCL.Status;
                    DGVRequestDetails.SelectedRows[0].Cells["Statuss"].Value = maintenanceRMPCL.Status;
                    DGVRequestDetails.SelectedRows[0].DefaultCellStyle.BackColor = Color.Yellow;
                }
                //else if (maintenanceRMPCL.Status==Status)
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                                         ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public DialogResult UpdateDBRow(string MNTCode, string comments, string msg)
        {
            int result = Resources.Instance.UpdateRMPCLRemarkRecord(MNTCode, ((int)maintenanceRMPCL.Status), comments);
            if (result > 0)
            {
                return XtraMessageBox.Show(msg, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                return DialogResult.None;
            }
        }
        //Reject Event Fire
        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                if (maintenanceRMPCL.Status == Status.ForApporval && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-GM"))
                {
                  
                    CommentsFrm commentsFrm = new CommentsFrm();
                    if (commentsFrm.ShowDialog() == DialogResult.OK)
                    {
                        maintenanceRMPCL.Status = Status.Rejected;
                        dropdownstatus.SelectedItem = maintenanceRMPCL.Status;
                        DGVRequestDetails.SelectedRows[0].Cells["Statuss"].Value = maintenanceRMPCL.Status;
                        DGVRequestDetails.SelectedRows[0].DefaultCellStyle.BackColor = Color.IndianRed;
                        DGVRequestDetails.SelectedRows[0].ReadOnly = true;
                        this.DGVRequestDetails.Refresh();
                        string commts = commentsFrm.txtcomments.Text;
                        commentsFrm.Close();
                        if (DialogResult.OK == UpdateDBRow(DGVRequestDetails.SelectedRows[0].Cells["MCode"].Value.ToString(), commts, "Task Rejected!!!"))
                        {
                            DGVRequestDetails.SelectedRows[0].Cells["Remark"].Value = maintenanceRMPCL.Comments = commts;
                            btnReject.Enabled = false;
                            btnApproval.Enabled = false;
                            SendMailRejectToMaint();
                        }

                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                                         ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtexpectedtime_Leave(object sender, EventArgs e)
        {
            try
            {

                if (numericHour.Value == 0) return;
                if (numericHour.Value > 0 && numericMinutes.Value == 0)
                {
                    if (WorkingHour() >= 7200)
                    {
                        if (DialogResult.OK == XtraMessageBox.Show("Need Approval For This !",
                            ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning))
                        {
                            btnsumbitaprl.Enabled = true;
                            btnsumbitaprl.Text = "Sumbit For Approval";
                        }
                    }
                    else
                    {
                        btnsumbitaprl.Enabled = true;
                        btnsumbitaprl.Text = "Submit Document";
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                               ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void txtexpectedtimeInmutes_Leave(object sender, EventArgs e)
        {
            try
            {
                if (numericHour.Value == 0) return;
                if (numericHour.Value > 0 && numericMinutes.Value >= 0)
                {
                    if (WorkingHour() >= 7200)
                    {
                        if (DialogResult.OK == XtraMessageBox.Show("Need Approval For This!",
                            ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning))
                        {
                            btnsumbitaprl.Enabled = true;
                            btnsumbitaprl.Text = "Sumbit For Approval";
                        }
                    }
                    else
                    {
                        btnsumbitaprl.Enabled = true;
                        btnsumbitaprl.Text = "Submit Document";
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                               ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void DGVRequestDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DGVRequestDetails.SelectedRows.Count > 0)
                {
                    maintenanceRMPCL.Status = ((Status)DGVRequestDetails.SelectedRows[0].Cells["Statuss"].Value);
                    if (maintenanceRMPCL.Status == Status.ForApporval && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-GM"))
                    {
                        btnReject.Visible = true;
                        btnApproval.Visible = true;
                        btnclosed.Visible = false;
                        btnReject.Enabled = true;
                        btnApproval.Enabled = true;
                        //tabcontrolMNT.Visible = true;
                        //tabcontrolMNT.SelectedIndex = 0;
                    }
                    else if (maintenanceRMPCL.Status == Status.Approved && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-GM"))// Approved Done All Form will be freezed
                    {
                        btnReject.Visible = false;
                        btnApproval.Visible = false;
                        btnclosed.Visible = false;
                    }
                    else if ((maintenanceRMPCL.Status == Status.Open || maintenanceRMPCL.Status == Status.Pending || maintenanceRMPCL.Status == Status.Approved) && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))
                    {
                        btnclosed.Visible = true;
                        btnReject.Visible = false;
                        btnApproval.Visible = false;
                        btnclosed.Enabled = true;
                        //if (DGVWorker.Rows.Count > 0 && DGVInventory.Rows.Count>0)// Also add inverntry Condition
                        //{
                        //    tabcontrolMNT.Visible = true;
                        //    tabcontrolMNT.SelectedIndex = 0;
                        //}
                    }
                    else
                    {
                        btnclosed.Visible = false;
                        btnclosed.Enabled = false;
                    }
                    //else if (maintenanceRMPCL.Status== Status.Pending && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))
                    //{
                    //    btnclosed.Visible = true;
                    //    btnReject.Visible = false;
                    //    btnApproval.Visible = false;
                    //}
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnback_Click(object sender, EventArgs e)
        {
            //if (mntpanel.Visible && Inventory.Visible)
            {
                if (maintenanceRMPCL.FormStatus == FormStatus.MachineInfo || (maintenanceRMPCL.FormStatus == FormStatus.Closed && maintenanceRMPCL.Status == Status.Closed))
                {
                    btnclosed.Visible = false; ;
                }
                else if (maintenanceRMPCL.Status == Status.ForApporval && maintenanceRMPCL.FormStatus == FormStatus.Summary&& !GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))
                {
                    btnclosed.Visible = false;
                    btnApproval.Visible = true;
                    btnReject.Visible = true;
                }
                else if ((maintenanceRMPCL.Status == Status.Open || maintenanceRMPCL.Status == Status.Pending) && maintenanceRMPCL.FormStatus == FormStatus.Summary)
                {
                    btnclosed.Visible = true;
                }

                if (!string.IsNullOrEmpty(maintenanceRMPCL.InventoryReturnCode))
                    maintenanceRMPCL.InventoryReturnCode = string.Empty;// this for Return Item

                ControlHide();
            }
        }
        private void btnclosed_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVRequestDetails.SelectedRows.Count > 0)
                {
                    if ((maintenanceRMPCL.Status == Status.Open || maintenanceRMPCL.Status == Status.Pending || maintenanceRMPCL.Status == Status.Approved) && (GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance") || GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-GM")))
                    {                     
                        CommentsFrm commentsFrm = new CommentsFrm();
                        if (commentsFrm.ShowDialog() == DialogResult.OK)
                        {
                            maintenanceRMPCL.Status = Status.Closed;
                            maintenanceRMPCL.ReportedBy = DGVRequestDetails.SelectedRows[0].Cells["ReportedBy"].Value.ToString();
                            maintenanceRMPCL.Date =Convert.ToDateTime( DGVRequestDetails.SelectedRows[0].Cells["MaintenanceDate"].Value);
                            DGVRequestDetails.SelectedRows[0].Cells["Statuss"].Value = maintenanceRMPCL.Status;
                            DGVRequestDetails.SelectedRows[0].DefaultCellStyle.BackColor = Color.LightGray;
                            DGVRequestDetails.SelectedRows[0].ReadOnly = true;
                            string commts = string .Format("Comments- {0};\n Commented By- {1};\n{2};", commentsFrm.txtcomments.Text, GlobalDeclaration._holdInfo[0].UserName,DateTime.Now.ToString());
                            commentsFrm.Close();
                            if (DialogResult.OK == UpdateDBRow(DGVRequestDetails.SelectedRows[0].Cells["MCode"].Value.ToString(), commts, "Task Closed Successfully!!!")) ;
                            {
                                DGVRequestDetails.SelectedRows[0].Cells["Remark"].Value = maintenanceRMPCL.Comments = commts;
                                btnclosed.Enabled = false;
                                if (DGVRequestDetails.SelectedRows[0].Cells["MCode"].Value.ToString().Contains("BRK"))
                                {
                                    int sts = Resources.Instance.RemoveEntry("SP_CloseBRKDown", "@BrkCode", DGVRequestDetails.SelectedRows[0].Cells["MCode"].Value.ToString());
                                }
                                int timeDure = WorkingHour();
                                if(timeDure >=7200)
                                {
                                    SendMailClosureToGM();
                                }
                                else 
                                {
                                    SendMailClosureToMaint();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void DGVRequestDetails_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DGVRequestDetails.SelectedRows.Count > 0)
                {
                    ClearProprety();
                    maintenanceRMPCL.Status = ((Status)DGVRequestDetails.SelectedRows[0].Cells["Statuss"].Value);
                    maintenanceRMPCL.MachineTag = DGVRequestDetails.SelectedRows[0].Cells["MachineTag"].Value.ToString();
                    maintenanceRMPCL.OperationPlant = ((OperationPlant)DGVRequestDetails.SelectedRows[0].Cells["OperationPlant"].Value);
                    maintenanceRMPCL.Others = DGVRequestDetails.SelectedRows[0].Cells["Others"].Value.ToString();
                    maintenanceRMPCL.ReportedBy = DGVRequestDetails.SelectedRows[0].Cells["ReportedBy"].Value.ToString();
                    maintenanceRMPCL.Priority = ((Priority)DGVRequestDetails.SelectedRows[0].Cells["Priority"].Value);
                    maintenanceRMPCL.MaintenanceCode = DGVRequestDetails.SelectedRows[0].Cells["MCode"].Value.ToString();
                    maintenanceRMPCL.Area = DGVRequestDetails.SelectedRows[0].Cells["Area"].Value.ToString();
                    maintenanceRMPCL.Date = DateTime.Parse(DGVRequestDetails.SelectedRows[0].Cells["MaintenanceDate"].Value.ToString());
                    maintenanceRMPCL.ExactLocation = DGVRequestDetails.SelectedRows[0].Cells["ExactLocation"].Value.ToString();
                    maintenanceRMPCL.Description = DGVRequestDetails.SelectedRows[0].Cells["Description"].Value.ToString();
                    if (maintenanceRMPCL.FormStatus == FormStatus.Summary && maintenanceRMPCL.Status != Status.Submitted)
                    {
                        maintenanceRMPCL.AssignTo = DGVRequestDetails.SelectedRows[0].Cells["AssignTo"].Value.ToString();
                        string timedata = DGVRequestDetails.SelectedRows[0].Cells["EstimatedTime"].Value.ToString();
                        maintenanceRMPCL.TimeInHr = Convert.ToDecimal(timedata.Split(':')[0]);
                        maintenanceRMPCL.TimeInMinutes = Convert.ToDecimal(timedata.Split(':')[1]);
                        if (DGVRequestDetails.SelectedRows[0].Cells["Remark"].Value == null)
                        {
                            maintenanceRMPCL.Comments = "";
                        }
                        else
                        {
                            maintenanceRMPCL.Comments = DGVRequestDetails.SelectedRows[0].Cells["Remark"].Value.ToString();
                        }
                        if (GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance") && maintenanceRMPCL.Status != Status.Reported)
                        {
                            btnclosed.Visible = false;
                            btnsumbitaprl.Enabled = false;
                            if (DGVWorker.Rows.Count <= 0)
                                UploadWorker(false);
                            if (DGVInventory.Rows.Count <= 0)
                                UploadInventroryGrid();
                        }
                        else if (GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-GM") && maintenanceRMPCL.Status == Status.ForApporval)
                        {
                            btnsumbitaprl.Enabled = false;
                            //btnAddWorker.Enabled = false;// this disable for when direct maintenance save via maintenance window and GM login
                            //btnInvertory.Enabled = false;//this disable for when direct maintenance save via maintenance window and GM login
                            btnAddWorker.Enabled = true;
                            btnInvertory.Enabled = true;
                            btnReject.Visible = false;
                            btnApproval.Visible = false;
                        }
                        else if (GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-GM") && maintenanceRMPCL.Status == Status.Approved)// Approved Done All Form will be freezed
                        {
                            grpMaintenance.Enabled = false;
                            DGVInventory.Enabled = false;
                            DGVWorker.Enabled = false;
                            btnsumbitaprl.Enabled = false;
                            btnAddWorker.Enabled = false;
                            btnInvertory.Enabled = false;
                            btnReject.Visible = false;
                            btnApproval.Visible = false;
                        }

                        //else if (GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance") && maintenanceRMPCL.Status == Status.Reported)
                        //{
                        //    dropdownAssignTo.Enabled = true;
                        //    numericHour.Enabled = true;
                        //    numericMinutes.Enabled = true;
                        //    btnsumbitaprl.Enabled = true;
                        //}
                        MapPropertyDataInCTRL();
                    }
                    else if (maintenanceRMPCL.FormStatus == FormStatus.Closed && maintenanceRMPCL.Status == Status.Closed)
                    {
                        string timedata = DGVRequestDetails.SelectedRows[0].Cells["EstimatedTime"].Value.ToString();
                        maintenanceRMPCL.AssignTo = DGVRequestDetails.SelectedRows[0].Cells["AssignTo"].Value.ToString();
                        maintenanceRMPCL.Comments = DGVRequestDetails.SelectedRows[0].Cells["Remark"].Value.ToString();
                        maintenanceRMPCL.TimeInHr = Convert.ToDecimal(timedata.Split(':')[0]);
                        maintenanceRMPCL.TimeInMinutes = Convert.ToDecimal(timedata.Split(':')[1]);
                        btnsumbitaprl.Enabled = false;
                        btnAddWorker.Enabled = true;
                        btnInvertory.Enabled = true;
                        MapPropertyDataInCTRL();
                        if (DGVWorker.Rows.Count <= 0)
                            UploadWorker(false);
                        if (DGVInventory.Rows.Count <= 0)
                            UploadInventroryGrid();
                    }
                    else if (maintenanceRMPCL.FormStatus == FormStatus.Summary && maintenanceRMPCL.Status == Status.Submitted && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Operation"))
                    {
                        maintenanceRMPCL.AssignTo = DGVRequestDetails.SelectedRows[0].Cells["AssignTo"].Value.ToString();
                        btnsumbitaprl.Enabled = false;
                        btnAddWorker.Enabled = false;
                        btnInvertory.Enabled = false;
                        MapPropertyDataInCTRL();
                    }
                    else if (maintenanceRMPCL.FormStatus == FormStatus.Summary && maintenanceRMPCL.Status == Status.Submitted && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))
                    {
                        maintenanceRMPCL.TimeInHr = 0;
                        maintenanceRMPCL.TimeInMinutes = 0;
                        if (DGVWorker.Rows.Count > 0)
                        {
                            DGVWorker.Rows.Clear();
                            UploadWorker(false);
                        }
                        if (DGVInventory.Rows.Count > 0)
                        {
                            DGVInventory.Rows.Clear();
                        }
                        SumbitDetails();
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                                    ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void DGVInventory_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DGVInventory.SelectedRows.Count > 0 && maintenanceRMPCL.FormStatus == FormStatus.New)
                {
                    ConsumpItemDetail consDetail = new ConsumpItemDetail();
                    consDetail.Item = DGVInventory.SelectedRows[0].Cells["ItemName"].Value.ToString();
                    consDetail.BatchNo = DGVInventory.SelectedRows[0].Cells["BatchNo"].Value.ToString();
                    consDetail.ItemCode = DGVInventory.SelectedRows[0].Cells["ItemCode"].Value.ToString();
                    consDetail.ConsumedQty = double.Parse(DGVInventory.SelectedRows[0].Cells["Quantity"].Value.ToString());
                    consDetail.UnitCost = double.Parse(DGVInventory.SelectedRows[0].Cells["Unit"].Value.ToString());
                    consDetail.UnitCode = DGVInventory.SelectedRows[0].Cells["UnitCode"].Value.ToString();
                    consDetail.TotalCost = double.Parse(DGVInventory.SelectedRows[0].Cells["TotalCost"].Value.ToString());
                    consDetail.DocumentNo = DGVInventory.SelectedRows[0].Cells["DocumentNo"].Value.ToString();
                    consDetail.ReferenceNo = DGVInventory.SelectedRows[0].Cells["ReferenceNo"].Value.ToString();
                    CreateConsumpDetailView(consDetail, DGVInventory.SelectedRows[0].Index);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void DGVRequestDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (DGVRequestDetails.Rows[e.RowIndex].Cells["Statuss"].Value == null) return;
                if (((Status)DGVRequestDetails.Rows[e.RowIndex].Cells["Statuss"].Value) == Status.Approved)
                {
                    DGVRequestDetails.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LimeGreen;
                }
                else if (((Status)DGVRequestDetails.Rows[e.RowIndex].Cells["Statuss"].Value) == Status.Pending)
                {
                    DGVRequestDetails.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(247, 93, 89);
                }
                else if (((Status)DGVRequestDetails.Rows[e.RowIndex].Cells["Statuss"].Value) == Status.Submitted)
                {
                    DGVRequestDetails.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(67, 198, 219);
                }
                else if (((Status)DGVRequestDetails.Rows[e.RowIndex].Cells["Statuss"].Value) == Status.Rejected)
                {
                    DGVRequestDetails.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(246, 40, 23);
                }
                else if (((Status)DGVRequestDetails.Rows[e.RowIndex].Cells["Statuss"].Value) == Status.ForApporval)
                {
                    DGVRequestDetails.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
                else if (((Status)DGVRequestDetails.Rows[e.RowIndex].Cells["Statuss"].Value) == Status.Open)
                {
                    DGVRequestDetails.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 203, 164);
                }
                else if (((Status)DGVRequestDetails.Rows[e.RowIndex].Cells["Statuss"].Value) == Status.Closed)
                {
                    DGVRequestDetails.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void dropdownstatus_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dropdownstatus.SelectedItem.ToString()) && maintenanceRMPCL.FormStatus == FormStatus.New)
                maintenanceRMPCL.Status = ((Status)dropdownstatus.SelectedItem);
            ////if (maintenanceRMPCL.Status == Status.Prepare)
            ////{
            ////    dropdownstatus.ForeColor = Color.FromArgb(254, 216, 177);
            ////}
            ////else if (maintenanceRMPCL.Status == Status.Open)
            ////{
            ////    dropdownstatus.ForeColor = Color.FromArgb(255, 203, 164);
            ////}
            ////else if (maintenanceRMPCL.Status == Status.Submitted)
            ////{
            ////    dropdownstatus.ForeColor = Color.FromArgb(67, 198, 219);
            ////}
            ////else if (maintenanceRMPCL.Status == Status.Closed)
            ////{
            ////    dropdownstatus.ForeColor = Color.DarkGray;
            ////}
            ////else if (maintenanceRMPCL.Status == Status.ForApporval)
            ////{
            ////    dropdownstatus.ForeColor = Color.White;
            ////}
            ////else if (maintenanceRMPCL.Status == Status.Approved)
            ////{
            ////    dropdownstatus.ForeColor = Color.LimeGreen;
            ////}
            ////else if (maintenanceRMPCL.Status == Status.Pending)
            ////{
            ////    dropdownstatus.ForeColor = Color.FromArgb(247, 93, 89);
            ////}
        }
        private void dropdownOP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dropdownOP.SelectedItem.ToString()) && maintenanceRMPCL.FormStatus == FormStatus.New && maintenanceRMPCL.FormName != "Maintenance Required")
                maintenanceRMPCL.OperationPlant = ((OperationPlant)dropdownOP.SelectedItem);
        }
        private void dropdownpriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dropdownpriority.SelectedItem.ToString()) && maintenanceRMPCL.FormStatus == FormStatus.New && maintenanceRMPCL.FormName != "Maintenance Required")
                maintenanceRMPCL.Priority = ((Priority)dropdownpriority.SelectedItem);
        }
        private void txtExtactlocation_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtExtactlocation.Text))
            {
                maintenanceRMPCL.ExactLocation = txtExtactlocation.Text;
            }
        }
        private void txtArea_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtArea.Text))
            {
                maintenanceRMPCL.Area = txtArea.Text;
            }
        }
        private void txtothers_TextChange(object sender, EventArgs e)
        {
            //if (!System.Text.RegularExpressions.Regex.IsMatch(txtothers.Text, "[^0-9]"))
            //{
            //    XtraMessageBox.Show("Please enter only Char.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtothers.Text = txtothers.Text.Remove(txtothers.Text.Length - 1);
            //}
        }
        private void txtothers_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void txtothers_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtothers.Text))
            {
                maintenanceRMPCL.Others = txtothers.Text;
            }
        }
        private void rtchtext_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rtchtext.Text))
            {
                maintenanceRMPCL.Description = rtchtext.Text;
            }
        }
        private void dropdownAssignTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dropdownAssignTo.SelectedItem.ToString()))
            {
                maintenanceRMPCL.AssignTo = dropdownAssignTo.SelectedItem.ToString();
            }
        }
        #endregion

        #region Method List
        private void UploadInventroryGrid()
        {
            DataTable dt = Resources.Instance.GetDataKey("Sp_GetMNTInventroySummary", "@MNTCode", maintenanceRMPCL.MaintenanceCode);
            if(DGVInventory.Rows.Count>0)
            DGVInventory.Rows.Clear();
            loadInvertorySummary(dt);

        }
        public void ClearProprety()
        {
            txtArea.Text = maintenanceRMPCL.Area = string.Empty;
            txtExtactlocation.Text = maintenanceRMPCL.ExactLocation = string.Empty;
            txtmntcode.Text = maintenanceRMPCL.MaintenanceCode = string.Empty;
            txtothers.Text = maintenanceRMPCL.Others = string.Empty;
            txtReportedby.Text = maintenanceRMPCL.ReportedBy = string.Empty;
            dropdownmachinetag.SelectedItem = maintenanceRMPCL.MachineTag = string.Empty;
            rtchtext.Text = maintenanceRMPCL.Description = string.Empty;
            rtchcomments.Text = maintenanceRMPCL.Comments = string.Empty;
            //dropdownAssignTo.Items.Clear();
            numericHour.Value = maintenanceRMPCL.TimeInHr = 0;
            numericMinutes.Value = maintenanceRMPCL.TimeInMinutes = 0;
            DGVInventory.Rows.Clear();
            DGVWorker.Rows.Clear();

        }
        public ConsumpItemDetailView CreateConsumpDetailView(ConsumpItemDetail consumpDetail, int RowIndex)
        {
            ConsumpItemDetailView consumpItemDetailView = new ConsumpItemDetailView(consumpDetail.DocumentNo, consumpDetail.ReferenceNo, false,true);// (txtProcDocNo.Text);
            try
            {
                consumpItemDetailView.MapConsumedDetailView(consumpDetail);
                if (consumpItemDetailView.ShowDialog() == DialogResult.OK)
                {
                    ViewConsumptionDetailData(consumpDetail.DocumentNo, consumpDetail.ReferenceNo, RowIndex);
                    consumpItemDetailView.Close();
                    consumpItemDetailView.Dispose();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                                         ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return consumpItemDetailView;
        }
        private void UploadWorker(bool sts)
        {
            DataTable dtW = Resources.Instance.GetDataKey("Sp_GetMNTWorkerDetails", "@MNTCode", maintenanceRMPCL.MaintenanceCode);
            loadWorkerSummary(dtW, sts);
        }
        private void ViewConsumptionDetailData(string DocNumber, string RefNo, int RowIndex)
        {
            try
            {
                DataTable Dt = Resources.Instance.GetConsumedItemDetail(DocNumber, RefNo);
                if (Dt.Rows.Count > 0)
                {
                    var query = from DataGridViewRow row in DGVInventory.Rows
                                where row.Cells["DocumentNo"].Value.ToString().Equals(DocNumber) && row.Cells["ReferenceNo"].Value.Equals(RefNo)
                                select row;
                    if (query.Count() > 0)
                    {
                        DGVInventory.Rows[RowIndex].Cells["Quantity"].Value = Dt.Rows[0]["ConsumedQty"];
                        DGVInventory.Rows[RowIndex].Cells["Unit"].Value = Dt.Rows[0]["UnitCost"];
                        DGVInventory.Rows[RowIndex].Cells["TotalCost"].Value = Dt.Rows[0]["TotalCost"];
                        DGVInventory.Rows[RowIndex].Cells["ItemName"].Value = Dt.Rows[0]["Item"];
                        DGVInventory.Rows[RowIndex].Cells["ItemCode"].Value = Dt.Rows[0]["ItemCode"];
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                                           ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void ViewReturnsDetailData(string DocNumber, string RefNo, int RowIndex)
        {
            try
            {
                DataTable Dt = Resources.Instance.GetReturnItemDetail(maintenanceRMPCL.InventoryReturnCode, RefNo);
                if (Dt.Rows.Count > 0)
                {
                    var query = from DataGridViewRow row in DGVInventory.Rows
                                where row.Cells["DocumentNo"].Value.ToString().Equals(DocNumber) && row.Cells["ReferenceNo"].Value.Equals(RefNo)
                                select row;
                    if (query.Count() > 0)
                    {
                        double oldQty = double.Parse(DGVInventory.Rows[RowIndex].Cells["Quantity"].Value.ToString());
                        var Qty = Dt.Rows[0]["ReturnQty"];
                        double CurrentQty = double.Parse(Qty.ToString());
                        DGVInventory.Rows[RowIndex].Cells["Quantity"].Value = oldQty - CurrentQty;
                        DGVInventory.Rows[RowIndex].Cells["Unit"].Value = Dt.Rows[0]["UnitCost"];
                        DGVInventory.Rows[RowIndex].Cells["TotalCost"].Value = Dt.Rows[0]["TotalCost"];
                        DGVInventory.Rows[RowIndex].Cells["ItemName"].Value = Dt.Rows[0]["Item"];
                        DGVInventory.Rows[RowIndex].Cells["ItemCode"].Value = Dt.Rows[0]["ItemCode"];
                        string result = string.Empty;
                        int Sts = Resources.Instance.UpdateMaintenaceRMPCLReturnINVRecord(maintenanceRMPCL.MaintenanceCode, DocNumber,
                            DGVInventory.Rows[RowIndex].Cells["BatchNo"].Value.ToString(), int.Parse(DGVInventory.Rows[RowIndex].Cells["Quantity"].Value.ToString()), double.Parse(Dt.Rows[0]["UnitCost"].ToString()), double.Parse(Dt.Rows[0]["TotalCost"].ToString()), ref result);

                        if (Sts > 0)
                        {
                            MessageBox.Show(result, "Information",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information,
                       MessageBoxDefaultButton.Button1,
                       MessageBoxOptions.RightAlign);                            
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void LoadInvertory(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    //if (DGVInventory.Rows.Count > 0)
                    //    DGVInventory.Rows.Clear();
                    if (DGVInventory.Rows.Count > 0)
                    {
                        DGVInventory.Rows.Clear();
                        int sts=Resources.Instance.RemoveEntry("SP_DeleteInventoryItems", "@InventoryCode", maintenanceRMPCL.InventoryCode, "@MaintenanceCode", maintenanceRMPCL.MaintenanceCode);
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        DGVInventory.Rows.Add(dr);
                        int index = DGVInventory.Rows.Count - 1;
                        DGVInventory.Rows[index].Cells["DocumentNo"].Value = dt.Rows[i]["DocumentNo"];
                        DGVInventory.Rows[index].Cells["ReferenceNo"].Value = dt.Rows[i]["ReferenceNo"];
                        DGVInventory.Rows[index].Cells["ItemName"].Value = dt.Rows[i]["Item"];
                        DGVInventory.Rows[index].Cells["Make"].Value = dt.Rows[i]["Make"];
                        DGVInventory.Rows[index].Cells["Model"].Value = dt.Rows[i]["Model"];
                        DGVInventory.Rows[index].Cells["Quantity"].Value = dt.Rows[i]["ConsumedQty"];
                        DGVInventory.Rows[index].Cells["Unit"].Value = dt.Rows[i]["UnitCost"];
                        DGVInventory.Rows[index].Cells["TotalCost"].Value = dt.Rows[i]["TotalCost"];
                        DGVInventory.Rows[index].Cells["BatchNo"].Value = dt.Rows[i]["BatchNo"];
                        DGVInventory.Rows[index].Cells["ItemCode"].Value = dt.Rows[i]["ItemCode"];
                        DGVInventory.Rows[index].Cells["UnitCode"].Value = dt.Rows[i]["UnitCode"];
                        DGVInventory.Rows[index].Cells["StatusI"].Value = "New";
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                                     ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ItemConsuptionDetails()
        {
            try
            {
                ItemConsumption itemConsumption = new ItemConsumption();
                itemConsumption.DocumentNo =maintenanceRMPCL.InventoryCode;
                itemConsumption.ReferenceNo = maintenanceRMPCL.MaintenanceCode;
                itemConsumption.DocumentDate = maintenanceRMPCL.Date;
                itemConsumption.ConsumptionType = "Maintenance";
                if (string.IsNullOrEmpty(maintenanceRMPCL.Others))
                {
                    maintenanceRMPCL.Others = "NA";
                }
                itemConsumption.Remarks = maintenanceRMPCL.Others;
                itemConsumption.Status = InvStatus.Closed;
                itemConsumption.SetConsumptionValue(itemConsumption);
                LoadInvertory(Resources.Instance.GetConsumedItemDetail(maintenanceRMPCL.InventoryCode, maintenanceRMPCL.MaintenanceCode));//Check IT
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ItemReturnDetails(int RowIndex, string Docnumber)
        {
            try
            {
                ItemReturn itemReturn = new ItemReturn();
                itemReturn.DocumentNo =  maintenanceRMPCL.InventoryReturnCode;
                itemReturn.ReferenceNo = maintenanceRMPCL.MaintenanceCode;
                itemReturn.DocumentDate = maintenanceRMPCL.Date;
                itemReturn.ConsumptionType = "Maintenance";
                itemReturn.Remarks = maintenanceRMPCL.Others;
                itemReturn.Status = InvStatus.Closed;
                itemReturn.SetReturnValue(itemReturn);
                ViewReturnsDetailData(Docnumber, maintenanceRMPCL.MaintenanceCode, RowIndex);//Check IT
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GenerateGlobalDocID(string procedureId, string preText)
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
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadMachineTag(bool IsBRK = false, string BRKCode = "")
        {
            try
            {
                if (maintenanceRMPCL.FormStatus == FormStatus.New && !IsBRK && String.IsNullOrEmpty(BRKCode))
                {
                    //this.Height = this.Height - (tabcontrolMNT.Height + 28);
                    RebindDataSource();
                    dropdownstatus.SelectedItem = maintenanceRMPCL.Status;
                    DatePickerMNTDate.Value = maintenanceRMPCL.Date = DateTime.Now;
                    txtReportedby.Text = maintenanceRMPCL.ReportedBy = GlobalDeclaration._holdInfo[0].UserName;
                    DGVRequestDetails.Visible = false;
                    GenerateMNTCode(IsBRK, BRKCode);
                }
                else if (IsBRK && !string.IsNullOrEmpty(BRKCode))
                {
                    RebindDataSource();
                    txtmntcode.Text = maintenanceRMPCL.MaintenanceCode = BRKCode;
                    txtReportedby.Text = maintenanceRMPCL.ReportedBy;
                    txtArea.Text = maintenanceRMPCL.Area;
                    DatePickerMNTDate.Value = maintenanceRMPCL.Date;
                    txtothers.Text = maintenanceRMPCL.Others;
                    txtExtactlocation.Text = maintenanceRMPCL.ExactLocation;
                    DGVRequestDetails.Visible = false;
                    dropdownOP.Enabled = false;
                    dropdownmachinetag.Enabled = false;
                    dropdownpriority.Enabled = false;
                    txtExtactlocation.Enabled = false;
                    txtothers.Enabled = false;
                }
                else if (maintenanceRMPCL.FormStatus == FormStatus.Summary)// maintenanceRMPCL.Status == Status.ForApporval)
                {
                    AddHeaderCheckBox();
                    Loaddata();
                    ControlHide();
                }
                else if (maintenanceRMPCL.FormStatus == FormStatus.Closed)
                {
                    AddHeaderCheckBox();
                    GetClosedRecord();
                    ControlHide();
                    // this comments by RP
                    //txtmntcode.Enabled = false;
                    //txtReportedby.Enabled = false;
                    //rtchcomments.Enabled = false;
                    btnAddWorker.Enabled = false;
                    btnInvertory.Enabled = false;
                    btnReject.Visible = false;
                    btnApproval.Visible = false;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                                  ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void GenerateMNTCode(bool IsBRK = false, string BRKCode = "")
        {
            if (!IsBRK && BRKCode == String.Empty)
            {
                int randomDigit = 0; //;= helperobj.RandomNumber(1001, 9999);                                        
                Resources.Instance.GetMaxID("Sp_GetMaxCodeNumber", "@MaxID", ref randomDigit);//Change by RP
                //if (randomDigit == 0)
                //    randomDigit = 1;
                //else
                //    randomDigit++;
                txtmntcode.Text = maintenanceRMPCL.MaintenanceCode = GenerateCode(randomDigit);
            }
        }
        private void AddHeaderCheckBox()
        {
            try
            {
                HeaderCheckBox = new CheckBox();
                Point headerCellLocation = this.DGVRequestDetails.GetCellDisplayRectangle(0, -1, true).Location;
                //Place the Header CheckBox in the Location of the Header Cell.
                HeaderCheckBox.Location = new Point(headerCellLocation.X + 0, headerCellLocation.Y + 2);
                HeaderCheckBox.BackColor = Color.White;
                HeaderCheckBox.Size = new Size(18, 18);
                //Assign Click event to the Header CheckBox.
                HeaderCheckBox.Click += new System.EventHandler(HeaderCheckBox_Clicked);
                DGVRequestDetails.Controls.Add(HeaderCheckBox);

                //Add a CheckBox Column to the DataGridView at the first position.
                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                checkBoxColumn.HeaderText = "";
                checkBoxColumn.Width = 30;
                checkBoxColumn.Name = "checkBoxColumn";
                DGVRequestDetails.Columns.Insert(0, checkBoxColumn);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                                     ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Assign Click event to the DataGridView Cell.
        }
        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            try
            {
                DGVRequestDetails.EndEdit();
                CheckedCount = 0;
                //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
                foreach (DataGridViewRow row in DGVRequestDetails.Rows)
                {
                    DataGridViewCheckBoxCell checkBox = (row.Cells["checkBoxColumn"] as DataGridViewCheckBoxCell);
                    checkBox.Value = HeaderCheckBox.Checked;
                    if (Convert.ToBoolean(checkBox.Value))
                    {
                        CheckedCount++;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                                     ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int CheckedCount = 0;
        private void dgvSelectAll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Check to ensure that the row CheckBox is clicked.
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                {

                    //Loop to verify whether all row CheckBoxes are checked or not.

                    DataGridViewCheckBoxCell checkBox = (DGVRequestDetails.SelectedRows[0].Cells["checkBoxColumn"] as DataGridViewCheckBoxCell);
                    if (Convert.ToBoolean(DGVRequestDetails.SelectedRows[0].Cells["checkBoxColumn"].EditedFormattedValue) == false)
                    {
                        CheckedCount++;
                        checkBox.Value = true;
                    }
                    else
                    {
                        CheckedCount--;
                        checkBox.Value = false;
                    }
                    if (CheckedCount == DGVRequestDetails.Rows.Count)
                    {
                        HeaderCheckBox.Checked = true;
                    }
                    else if (CheckedCount < DGVRequestDetails.Rows.Count)
                    {
                        HeaderCheckBox.Checked = false;
                    }
                    //foreach (DataGridViewRow row in DGVRequestDetails.Rows)
                    //{
                    //}

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                                     ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            ExportProcureLogExcel(this.DGVRequestDetails, lblmntdate.Text);

        }
        private void ExportProcureLogExcel(DataGridView dgv, string fileName)
        {
            try
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    if (column.Name == "checkBoxColumn") continue;
                    dt.Columns.Add(column.HeaderText);
                }
                var Rows = dgv.Rows.Cast<DataGridViewRow>().Where(X => Convert.ToBoolean(X.Cells["checkBoxColumn"].Value) == true).ToList();
                for (int i = 0; i < Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["Maintenance Code"] = Rows[i].Cells["MCode"].Value;
                    dr["Maintenance Date"] = Rows[i].Cells["MaintenanceDate"].Value;
                    dr["Operation Plant"] = Rows[i].Cells["OperationPlant"].Value;
                    dr["Status"] = Rows[i].Cells["Statuss"].Value;
                    dr["Machine Tag"] = Rows[i].Cells["MachineTag"].Value;
                    dr["Others"] = Rows[i].Cells["Others"].Value;
                    dr["Priority"] = Rows[i].Cells["Priority"].Value;
                    dr["Exact Location"] = Rows[i].Cells["ExactLocation"].Value;
                    dr["Estimated Time"] = Rows[i].Cells["EstimatedTime"].Value;
                    dr["Area"] = Rows[i].Cells["Area"].Value;
                    dr["Reported By"] = Rows[i].Cells["ReportedBy"].Value;
                    dr["Assign To"] = Rows[i].Cells["AssignTo"].Value;
                    dr["Description"] = Rows[i].Cells["Description"].Value;
                    dr["Remark"] = Rows[i].Cells["Remark"].Value;
                    dt.Rows.Add(dr);
                }
                //Exporting to Excel
                if (dt.Rows.Count > 0)
                {
                    string folderPath = "C:\\Excel\\";
                    SaveFileDialog directchoosedlg = new SaveFileDialog();
                    directchoosedlg.FileName = fileName;
                    if (directchoosedlg.ShowDialog() == DialogResult.OK)
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "Sheet1");
                            string fPath = directchoosedlg.FileName + ".xlsx"; //folderPath + "\\" + fileName + ".xlsx";
                            if (File.Exists(fPath))
                            {
                                DialogResult dgres = XtraMessageBox.Show("File already exists! Are you want to replace?", "Alert", MessageBoxButtons.YesNo);
                                if (dgres == DialogResult.Yes)
                                {
                                    wb.SaveAs(fPath);
                                    XtraMessageBox.Show("Report Downloaded Successfully.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                    return;
                            }
                            else
                            {
                                wb.SaveAs(fPath);
                                XtraMessageBox.Show("Report Downloaded Successfully.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void GetClosedRecord()
        {
            try
            {
                DataTable dt = null;
                //if (GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-GM"))
                {
                    dt = Resources.Instance.GetDataKey("Sp_GetRMPClosedRecord");
                    LoadDataGridView(dt);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                                    ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ControlHide()
        {
            grpMaintenance.Visible = false;
            tabcontrolMNT.Visible = false;
            DGVRequestDetails.Size = grpMaintenance.Size;
            DGVRequestDetails.Location = grpMaintenance.Location;
            DGVRequestDetails.Visible = true;
            btnback.Visible = false;
        }
        public void Loaddata()
        {
            DataTable dt = null;
            try
            {
                if (GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))
                {
                    dt = Resources.Instance.GetDataKey("Sp_GetRMPCLGMNTUsersercord", "@UserName", GlobalDeclaration._holdInfo[0].UserName);
                    LoadDataGridView(dt);
                }
                else if (GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance") && maintenanceRMPCL.FormStatus == FormStatus.Summary)
                {
                    dt = Resources.Instance.GetDataKey("Sp_GetRMPCLGREQUsercord");
                    LoadDataGridView(dt);
                }
                else if (GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Operation"))// Non Maintenance User Data
                {
                    dt = Resources.Instance.GetDataKey("Sp_GetRMPCLGREQUsercord");
                    LoadDataGridView(dt);
                }
                else if (GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-GM"))
                {
                    dt = Resources.Instance.GetDataKey("Sp_GetRMPCLGMUserRecord");
                    LoadDataGridView(dt);
                    if (DGVRequestDetails.Rows.Count > 0)
                    {
                        this.btnApproval.Visible = true;
                        this.btnReject.Visible = true;
                        this.btnclosed.Visible = false;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                                            ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void loadInvertorySummary(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        DGVInventory.Rows.Add(dr);
                        int index = DGVInventory.Rows.Count - 1;
                        DGVInventory.Rows[index].Cells["DocumentNo"].Value = maintenanceRMPCL.InventoryCode = dt.Rows[i]["DocNo"].ToString();
                        DGVInventory.Rows[index].Cells["ItemName"].Value = dt.Rows[i]["ItemName"];
                        DGVInventory.Rows[index].Cells["Make"].Value = dt.Rows[i]["Make"].ToString();
                        DGVInventory.Rows[index].Cells["Model"].Value = dt.Rows[i]["Model"].ToString();
                        DGVInventory.Rows[index].Cells["Quantity"].Value = dt.Rows[i]["UnitConsumed"];
                        DGVInventory.Rows[index].Cells["Unit"].Value = dt.Rows[i]["UnitCost"];
                        DGVInventory.Rows[index].Cells["TotalCost"].Value = dt.Rows[i]["TotalCost"].ToString();
                        DGVInventory.Rows[index].Cells["ReferenceNo"].Value = dt.Rows[i]["ReferenceNo"];
                        DGVInventory.Rows[index].Cells["BatchNo"].Value = dt.Rows[i]["BatchNo"];
                        DGVInventory.Rows[index].Cells["ItemCode"].Value = dt.Rows[i]["ItemCode"];
                        DGVInventory.Rows[index].Cells["UnitCode"].Value = dt.Rows[i]["UnitCode"];
                        DGVInventory.Rows[index].Cells["StatusI"].Value = "Saved";
                        DGVInventory.Visible = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void loadWorkerSummary(DataTable dt, bool sts)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        DGVWorker.Rows.Add(dr);
                        int index = DGVWorker.Rows.Count - 1;
                        DGVWorker.Rows[index].Cells["WorkerName"].Value = dt.Rows[i]["WorkerName"];
                        DGVWorker.Rows[index].Cells["MaintenanceCode"].Value = dt.Rows[i]["MaintenanceCode"];
                        DGVWorker.Rows[index].Cells["StatusW"].Value = "Saved";
                    }
                    if (sts)
                    {
                        DGVWorker.Visible = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadDataGridView(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        DGVRequestDetails.Rows.Add(dr);
                        int index = DGVRequestDetails.Rows.Count - 1;
                        DGVRequestDetails.Rows[index].Cells["MCode"].Value = dt.Rows[i]["MaintenanceCode"];
                        DGVRequestDetails.Rows[index].Cells["MaintenanceDate"].Value = Convert.ToDateTime(dt.Rows[i]["MaintenanaceDate"]);
                        DGVRequestDetails.Rows[index].Cells["OperationPlant"].Value = Enum.ToObject(typeof(OperationPlant), int.Parse(dt.Rows[i]["OperationPant"].ToString()));
                        DGVRequestDetails.Rows[index].Cells["Statuss"].Value = Enum.ToObject(typeof(Status), int.Parse(dt.Rows[i]["Status"].ToString()));
                        DGVRequestDetails.Rows[index].Cells["MachineTag"].Value = dt.Rows[i]["MachineTag"];
                        DGVRequestDetails.Rows[index].Cells["Others"].Value = dt.Rows[i]["Others"];
                        DGVRequestDetails.Rows[index].Cells["Priority"].Value = Enum.ToObject(typeof(Priority), int.Parse(dt.Rows[i]["Priority"].ToString()));
                        DGVRequestDetails.Rows[index].Cells["ExactLocation"].Value = dt.Rows[i]["ExactLocation"];
                        DGVRequestDetails.Rows[index].Cells["Area"].Value = dt.Rows[i]["Area"];
                        DGVRequestDetails.Rows[index].Cells["ReportedBy"].Value = dt.Rows[i]["ReportedBy"];
                        DGVRequestDetails.Rows[index].Cells["Description"].Value = dt.Rows[i]["Description"];
                        if (GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Operation"))
                        {
                            if (!string.IsNullOrEmpty(dt.Rows[i]["EstimatedTime"].ToString()) && !string.IsNullOrEmpty(dt.Rows[i]["Comments"].ToString()))
                            {
                                DGVRequestDetails.Rows[index].Cells["EstimatedTime"].Value = GetHour(int.Parse(dt.Rows[i]["EstimatedTime"].ToString()));
                                DGVRequestDetails.Rows[index].Cells["Remark"].Value = dt.Rows[i]["Comments"];
                            }
                            else
                            {
                                DGVRequestDetails.Rows[index].Cells["EstimatedTime"].Value = "0:0";
                                DGVRequestDetails.Rows[index].Cells["Remark"].Value = "";
                            }
                            if (!string.IsNullOrEmpty(dt.Rows[i]["AssignTo"].ToString()))
                            {
                                DGVRequestDetails.Rows[index].Cells["AssignTo"].Value = dt.Rows[i]["AssignTo"];
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(dt.Rows[i]["EstimatedTime"].ToString()))
                            {
                                DGVRequestDetails.Rows[index].Cells["EstimatedTime"].Value = "0:0";
                            }
                            else
                            {
                                DGVRequestDetails.Rows[index].Cells["EstimatedTime"].Value = GetHour(int.Parse(dt.Rows[i]["EstimatedTime"].ToString()));
                            }
                            if (!string.IsNullOrEmpty(dt.Rows[i]["Comments"].ToString()))
                            {
                                DGVRequestDetails.Rows[index].Cells["Remark"].Value = dt.Rows[i]["Comments"];
                            }
                            if (!string.IsNullOrEmpty(dt.Rows[i]["AssignTo"].ToString()))
                            {
                                DGVRequestDetails.Rows[index].Cells["AssignTo"].Value = dt.Rows[i]["AssignTo"];
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string GetHour(int second)
        {

            double hour = second / 3600.00;
            double FinalHour = Math.Floor(hour);
            decimal d = new decimal(Convert.ToDouble(hour));
            d = d % 1;
            decimal minutes = Math.Round((d * 60));
            string value = FinalHour + ":" + minutes;
            return value;
        }
        private void showcontroll()
        {
            DGVRequestDetails.Location = new Point(1028, 547);
            DGVRequestDetails.Size = new Size(10, 10);
            DGVRequestDetails.Visible = false;
            btnback.Visible = true;
            btnback.Location = btnclosed.Location;
            tabcontrolMNT.Visible = true;
            mntpanel.Visible = true;
            Inventory.Visible = true;
            grpMaintenance.Visible = true;

        }
        /// <summary>
        /// Disable All control after approval send 
        /// </summary>
        private void DisableControl()
        {
            txtArea.Enabled = false;
            numericHour.Enabled = false;
            numericMinutes.Enabled = false;
            txtothers.Enabled = false;
            txtExtactlocation.Enabled = false;
            DGVWorker.Enabled = false;
            btnsumbitaprl.Enabled = false;
            dropdownmachinetag.Enabled = false;
            dropdownOP.Enabled = false;
            dropdownstatus.Enabled = false;
            rtchtext.Enabled = false;
            dropdownAssignTo.Enabled = false;
            dropdownpriority.Enabled = false;
            if (!maintenanceRMPCL.MaintenanceCode.Contains("BRK-"))
            {
                btnInvertory.Enabled = false;
                btnAddWorker.Enabled = false;
                DGVInventory.Enabled = false;
                DGVWorker.Enabled = false;
                addWorkerToolStripMenuItem.Enabled = false;
                removeWorkerToolStripMenuItem.Enabled = false;
            }
            else if (GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance") && maintenanceRMPCL.AssignTo== GlobalDeclaration._holdInfo[0].UserName)
            {// Assign User also can Add Inventory
                DGVInventory.Enabled = true;
                DGVWorker.Enabled = true;
                addWorkerToolStripMenuItem.Enabled = true;
                removeWorkerToolStripMenuItem.Enabled = true;
            }
        }
        private void BRKDisable()
        {
            if (maintenanceRMPCL.MaintenanceCode.Contains("BRK-") && maintenanceRMPCL.Status== Status.Pending)
            {
                btnInvertory.Enabled = false;
                btnAddWorker.Enabled = false;
                DGVInventory.Enabled = false;
                DGVWorker.Enabled = false;
                addWorkerToolStripMenuItem.Enabled = false;
                removeWorkerToolStripMenuItem.Enabled = false;
            }
        }
        private string AddMachineArea()
        {
            string receiceValue = maintenanceRMPCL.MachineTag;
            DPoint dPoint = GlobalDeclaration._MyTagDictinary.AsEnumerable().Where(X => X.Value == receiceValue).FirstOrDefault().Key;
            var area = Resources.Instance.MachineDt.AsEnumerable().Where(X => X.Field<string>("Cadlocation") == "X" + dPoint.X + " " + "Y" + dPoint.Y).Select(X => X.Field<string>("MachineLocation")).Distinct().ToList();
            return area[0].ToString();
        }
        public int WorkingHour()
        {
            decimal totalsecoud = 0;
            maintenanceRMPCL.TimeInHr = numericHour.Value;
            maintenanceRMPCL.TimeInMinutes = numericMinutes.Value;
            if (maintenanceRMPCL.TimeInHr > 0 && maintenanceRMPCL.TimeInMinutes >= 0)
            {
                totalsecoud = (maintenanceRMPCL.TimeInHr * 3600) + (maintenanceRMPCL.TimeInMinutes * 60);
            }
            return decimal.ToInt32(totalsecoud);
        }
        private void MapPropertyDataInCTRL()
        {
            try
            {
                RebindDataSource();
                txtArea.Text = maintenanceRMPCL.Area;
                txtExtactlocation.Text = maintenanceRMPCL.ExactLocation;
                txtmntcode.Text = maintenanceRMPCL.MaintenanceCode;
                txtothers.Text = maintenanceRMPCL.Others;
                txtReportedby.Text = maintenanceRMPCL.ReportedBy;
                dropdownmachinetag.SelectedItem = maintenanceRMPCL.MachineTag;
                dropdownOP.SelectedItem = maintenanceRMPCL.OperationPlant;
                dropdownpriority.SelectedItem = maintenanceRMPCL.Priority;
                dropdownstatus.SelectedItem = maintenanceRMPCL.Status;
                DatePickerMNTDate.Value = maintenanceRMPCL.Date;
                rtchtext.Text = maintenanceRMPCL.Description;
                rtchcomments.Text = maintenanceRMPCL.Comments;
                dropdownAssignTo.SelectedItem = maintenanceRMPCL.AssignTo;
                numericHour.Value = maintenanceRMPCL.TimeInHr;
                numericMinutes.Value = maintenanceRMPCL.TimeInMinutes;
                if (maintenanceRMPCL.Status == Status.Rejected)
                {
                    txtArea.Enabled = false;
                    numericHour.Enabled = true;
                    rtchtext.Enabled = false;
                    numericMinutes.Enabled = true;
                    txtExtactlocation.Enabled = false;
                    txtothers.Enabled = false;
                    txtExtactlocation.Enabled = false;
                    dropdownmachinetag.Enabled = false;
                    dropdownOP.Enabled = false;
                    dropdownpriority.Enabled = false;
                    dropdownstatus.Enabled = false;
                    DatePickerMNTDate.Enabled = false;
                    dropdownAssignTo.Enabled = false;
                    addWorkerToolStripMenuItem.Enabled = false;
                    removeWorkerToolStripMenuItem.Enabled = false;

                }
                else
                {
                    txtArea.Enabled = false;
                    numericHour.Enabled = false;
                    rtchtext.Enabled = false;
                    numericMinutes.Enabled = false;
                    txtExtactlocation.Enabled = false;
                    txtothers.Enabled = false;
                    txtExtactlocation.Enabled = false;
                    dropdownmachinetag.Enabled = false;
                    dropdownOP.Enabled = false;
                    dropdownpriority.Enabled = false;
                    dropdownstatus.Enabled = false;
                    DatePickerMNTDate.Enabled = false;
                    dropdownAssignTo.Enabled = false;
                    //addWorkerToolStripMenuItem.Enabled = false;
                    //removeWorkerToolStripMenuItem.Enabled = false;
                }
                if ((maintenanceRMPCL.Status == Status.Reported || maintenanceRMPCL.Status == Status.Pending || maintenanceRMPCL.Status == Status.Open || maintenanceRMPCL.Status == Status.Rejected || maintenanceRMPCL.Status == Status.Submitted) && maintenanceRMPCL.FormStatus == FormStatus.Summary)
                {
                    returnInventory.Enabled = true;
                    addWorkerToolStripMenuItem.Enabled = true;
                    removeWorkerToolStripMenuItem.Enabled = true;
                    AddInverntroy.Enabled = true;
                    Removeinventory.Enabled = true;
                    btnsumbitaprl.Enabled = true;
                    if (maintenanceRMPCL.Status == Status.Open && maintenanceRMPCL.AssignTo == GlobalDeclaration._holdInfo[0].UserName)
                    {
                        btnAddWorker.Enabled = true;
                        btnInvertory.Enabled = true;
                    }
                }                
                else
                {
                    returnInventory.Enabled = false;
                    addWorkerToolStripMenuItem.Enabled = false;
                    removeWorkerToolStripMenuItem.Enabled = false;
                    AddInverntroy.Enabled = false;
                    Removeinventory.Enabled = false;
                }
                showcontroll();

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                                     ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SumbitDetails()
        {
            txtArea.Text = maintenanceRMPCL.Area;
            txtExtactlocation.Text = maintenanceRMPCL.ExactLocation;
            txtmntcode.Text = maintenanceRMPCL.MaintenanceCode;
            txtothers.Text = maintenanceRMPCL.Others;
            txtReportedby.Text = maintenanceRMPCL.ReportedBy;
            RebindDataSource();
            dropdownmachinetag.SelectedItem = maintenanceRMPCL.MachineTag;
            dropdownOP.SelectedItem = maintenanceRMPCL.OperationPlant;
            dropdownpriority.SelectedItem = maintenanceRMPCL.Priority;
            dropdownstatus.SelectedItem = maintenanceRMPCL.Status;
            DatePickerMNTDate.Value = maintenanceRMPCL.Date;
            rtchtext.Text = maintenanceRMPCL.Description;
            rtchcomments.Text = maintenanceRMPCL.Comments;
            numericHour.Value = maintenanceRMPCL.TimeInHr;
            numericMinutes.Value = maintenanceRMPCL.TimeInMinutes;
            addWorkerToolStripMenuItem.Enabled = true;
            removeWorkerToolStripMenuItem.Enabled = true;
            AddInverntroy.Enabled = true;
            Removeinventory.Enabled = true;
            if (maintenanceRMPCL.Status == Status.Open || maintenanceRMPCL.Status == Status.Pending || maintenanceRMPCL.Status == Status.Submitted)
            {
                returnInventory.Enabled = true;
                addWorkerToolStripMenuItem.Enabled = true;
                removeWorkerToolStripMenuItem.Enabled = true;
                AddInverntroy.Enabled = true;
                Removeinventory.Enabled = true;
            }
            else
            {
                returnInventory.Enabled = false;
                addWorkerToolStripMenuItem.Enabled = false;
                removeWorkerToolStripMenuItem.Enabled = false;
                AddInverntroy.Enabled = false;
                Removeinventory.Enabled = false;
            }
            rtchtext.Enabled = false;
            txtArea.Enabled = false;
            txtExtactlocation.Enabled = false;
            txtothers.Enabled = false;
            dropdownmachinetag.Enabled = false;
            dropdownOP.Enabled = false;
            dropdownpriority.Enabled = false;
            dropdownstatus.Enabled = false;
            DatePickerMNTDate.Enabled = false;
            dropdownAssignTo.Enabled = true;
            numericHour.Enabled = true;
            numericMinutes.Enabled = true;
            btnsumbitaprl.Enabled = true;
            showcontroll();

        }
        private void RebindDataSource()
        {
            try
            {
                dropdownOP.DataSource = Enum.GetValues(typeof(OperationPlant));
                dropdownpriority.DataSource = Enum.GetValues(typeof(Priority));
                dropdownstatus.DataSource = Enum.GetValues(typeof(Status));
                if (this.dropdownmachinetag.Items.Count == 0)
                {
                    foreach (var item in GlobalDeclaration._MyTagDictinary)
                    {
                        string MachineTag = item.Value;
                        this.dropdownmachinetag.Items.Add(MachineTag);
                    }
                    this.dropdownmachinetag.Items.Add("NA");
                }
                DataTable dt = Resources.Instance.GetDataKey("SP_GetRMPCLMNTUsers");
                if (dropdownAssignTo.Items.Count == 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dropdownAssignTo.Items.Add(dt.Rows[i]["UserName"].ToString());
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                                     ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GenerateCode(int maxnumber)
        {
            return String.Format("{0}-{1:0000}", "MNT", maxnumber + 1);
        }
        public void LoadMachineInfo(string machinetag)
        {
            try
            {
                DataTable dt = null;
                dt = Resources.Instance.GetDataKey("Sp_GetRMPCompMachineRecord", "@machinetag", machinetag);
                if (dt.Rows.Count > 0)
                {
                    LoadDataGridView(dt);
                    DGVRequestDetails.ReadOnly = true;
                    GetClosedRecord();
                    ControlHide();
                    btnReject.Visible = false;
                    btnApproval.Visible = false;
                }
                if (DGVWorker.Rows.Count > 0)
                {
                    btnAddWorker.Enabled = true;
                    btnInvertory.Enabled = true;
                    addWorkerToolStripMenuItem.Visible = false;
                }
                else
                {
                    btnAddWorker.Enabled = false;
                    btnInvertory.Enabled = false;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateInvertory()
        {
            if (DGVInventory.Rows.Count > 0)
            {
                AuditReportInsertion auditReportInsertion = new AuditReportInsertion();
                string MSG = auditReportInsertion.InsertMNTInventory(DGVInventory, maintenanceRMPCL.MaintenanceCode, "Maintenance");
                if (!string.IsNullOrEmpty(MSG))
                {
                    DGVInventory.Rows.Cast<DataGridViewRow>().ToList().ForEach(f => f.Cells["StatusI"].Value = "Saved");
                    MessageBox.Show(MSG, "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                    DialogResult = DialogResult.OK;

                }
            }
            if (DGVWorker.Rows.Count > 0)
            {
                AuditReportInsertion auditReportInsertion = new AuditReportInsertion();
                string MSG = auditReportInsertion.InsertMNTWorkers(DGVWorker, maintenanceRMPCL.MaintenanceCode);
                if (!string.IsNullOrEmpty(MSG))
                {
                    DGVWorker.Rows.Cast<DataGridViewRow>().ToList().ForEach(f => f.Cells["StatusW"].Value = "Saved");
                    MessageBox.Show(MSG, "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);
                    DialogResult = DialogResult.OK;
                }
            }
        }
        #endregion

        #region EventCall From Other Form

        void Connector_Event(params object[] args)
        {
        }

        #endregion

        private void DGVWorker_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (DGVWorker.CurrentCell.ColumnIndex == 0) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {

                e.Handled = true;
                XtraMessageBox.Show("String format Allow Only",
                                     ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void tabcontrolMNT_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               
                if (tabcontrolMNT.SelectedIndex == 0)
                {
                    if (maintenanceRMPCL.FormStatus == FormStatus.Summary || maintenanceRMPCL.FormStatus == FormStatus.Closed)
                    {
                        if (DGVWorker.Rows.Count > 0) return;
                        UploadWorker(true);
                    }
                }
                if (tabcontrolMNT.SelectedIndex == 1)
                {
                    if (maintenanceRMPCL.FormStatus == FormStatus.Summary || (maintenanceRMPCL.Status == Status.Closed) || (maintenanceRMPCL.Status == Status.Pending))
                    {
                        if (DGVInventory.Rows.Count > 0) return;
                        UploadInventroryGrid();
                    }
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                                    ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void HidetabcontrolMNTHeader()
        {
            tabcontrolMNT.Appearance = TabAppearance.FlatButtons;
            tabcontrolMNT.ItemSize = new Size(0, 1);
            tabcontrolMNT.SizeMode = TabSizeMode.Fixed;

            foreach (TabPage tab in tabcontrolMNT.TabPages)
            {
                tab.Hide();// = "";
            }
        }
        private void DisableControlPermanent()
        {
            txtmntcode.Enabled = false;
            dropdownstatus.Enabled = false;
            txtArea.Enabled = false;
            txtReportedby.Enabled = false;
            DatePickerMNTDate.Enabled = false;
        }
        
        public void DeleteConsumption(string MaintCode,string conDocNo,string itemCode,string BatchNo)
        {
            int iCount=Resources.Instance.DeleteConsumpDetail(conDocNo, itemCode,BatchNo);

            DataTable dt = Resources.Instance.GetConsumedItemDetail(conDocNo, MaintCode);
            if(dt.Rows.Count==0)
            {
                Resources.Instance.DeleteConsumption(conDocNo);
            }
            XtraMessageBox.Show("Consumption remove successfully.");
        }

        /// <summary>
        /// New Maintenance Request Submitted less than 2 hrs
        /// </summary>
        public void SendMailSubmitToAssigned()
        {
            string curruser = GlobalDeclaration._holdInfo[0].UserName;

            string mailTo = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("UserName") ==maintenanceRMPCL.AssignTo).ToList().FirstOrDefault()["Email"].ToString();
            //string mailToName = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("Email") == mailTo).ToList().FirstOrDefault()["UserName"].ToString();
            string msgBody = string.Format("Hi {0},\n\nA maintenance request {1} has been reported by {2} on {3} for Operation Plant {4}.\nKindly review and take appropriate action.\n\nThanks",
                     maintenanceRMPCL.AssignTo, maintenanceRMPCL.MaintenanceCode,curruser,maintenanceRMPCL.Date,maintenanceRMPCL.OperationPlant);
            string subject = string.Format("Maintenance Submitted for {0}", MaintenanceCode);
            GlobalDeclaration.SendMail(curruser, mailTo, null, subject, msgBody);
            //GlobalDeclaration.SendMail(curruser, "milan.s@sparrowrms.in", null, subject, msgBody);
        }

        /// <summary>
        /// Maintenance more than 2 hours (For approval from GM)
        /// </summary>
        public void SendMailToMaintGM()
        {
            string curruser = GlobalDeclaration._holdInfo[0].UserName;

            string mailTo = LoadAllUsers.AsEnumerable().Where(X => X.Field<int>("RoleID") == 7).ToList().FirstOrDefault()["Email"].ToString();
            string mailToName = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("Email") == mailTo).ToList().FirstOrDefault()["UserName"].ToString();
            string msgBody = string.Format("Hi {0},\n\nA maintenance request {1} has been reported by {2} on {3} for Operation Plant {4} is assigned to {5} which may take more than 2 hours.\nKindly review and take appropriate action.\n\nThanks",
                     mailToName, maintenanceRMPCL.MaintenanceCode, maintenanceRMPCL.ReportedBy, maintenanceRMPCL.Date, maintenanceRMPCL.OperationPlant,maintenanceRMPCL.AssignTo);
            string subject = string.Format("Maintenance Submitted for {0}", maintenanceRMPCL.MaintenanceCode);
            GlobalDeclaration.SendMail(curruser, mailTo, null, subject, msgBody);
            //GlobalDeclaration.SendMail(curruser, "milan.s@sparrowrms.in", null, subject, msgBody);
        }

        /// <summary>
        /// GP Sharma Approved
        /// </summary>
        public void SendMailApproveToMaint()
        {
            string curruser = GlobalDeclaration._holdInfo[0].UserName;

            string mailTo = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("UserName") == maintenanceRMPCL.AssignTo).ToList().FirstOrDefault()["Email"].ToString();
            //string mailToName = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("Email") == mailTo).ToList().FirstOrDefault()["UserName"].ToString();
            string msgBody = string.Format("Hi {0},\n\nA maintenance request {1} reported by {2} on {3} for Operation Plant {4} has been approved and assigend to you.\nKindly review and take appropriate action.\n\nThanks.",
                     maintenanceRMPCL.AssignTo, maintenanceRMPCL.MaintenanceCode, maintenanceRMPCL.ReportedBy, maintenanceRMPCL.Date, maintenanceRMPCL.OperationPlant);
            string subject = string.Format("Maintenance Approved for {0}", maintenanceRMPCL.MaintenanceCode);
            GlobalDeclaration.SendMail(curruser, mailTo, null, subject, msgBody);
            //GlobalDeclaration.SendMail(curruser, "milan.s@sparrowrms.in", null, subject, msgBody);
        }

        /// <summary>
        /// GP Sharma Rejects
        /// </summary>
        public void SendMailRejectToMaint()
        {
            string curruser = GlobalDeclaration._holdInfo[0].UserName;

            string mailTo = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("UserName") == maintenanceRMPCL.AssignTo).ToList().FirstOrDefault()["Email"].ToString();
            //string mailToName = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("Email") == mailTo).ToList().FirstOrDefault()["UserName"].ToString();
            string msgBody = string.Format("Hi {0},\n\nA maintenance request {1} reported by you on {2} for Operation Plant {3} has been rejected.\nKindly review and take appropriate action.\n\nThanks.",
                     maintenanceRMPCL.AssignTo, maintenanceRMPCL.MaintenanceCode,maintenanceRMPCL.Date, maintenanceRMPCL.OperationPlant);
            string subject = string.Format("Maintenance rejected for {0}", maintenanceRMPCL.MaintenanceCode);
            GlobalDeclaration.SendMail(curruser, mailTo, null, subject, msgBody);
            //GlobalDeclaration.SendMail(curruser, "milan.s@sparrowrms.in", null, subject, msgBody);
        }

        /// <summary>
        /// Maintainance closed by Maintenance User 2hs +
        /// </summary>
        public void SendMailClosureToGM()
        {
            string curruser = GlobalDeclaration._holdInfo[0].UserName;

            string mailTo = LoadAllUsers.AsEnumerable().Where(X => X.Field<int>("RoleID") == 7).ToList().FirstOrDefault()["Email"].ToString();
            string mailToName = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("Email") == mailTo).ToList().FirstOrDefault()["UserName"].ToString();
            string msgBody = string.Format("Hi {0},\n\nA maintenance request {1} reported by {2} on {3} for Operation Plant {4} has been closed.\n\nThanks",
                     mailToName, maintenanceRMPCL.MaintenanceCode, maintenanceRMPCL.ReportedBy, maintenanceRMPCL.Date, maintenanceRMPCL.OperationPlant);
            string subject = string.Format("Maintenance Closed for {0}", MaintenanceCode);
            GlobalDeclaration.SendMail(curruser, mailTo, null, subject, msgBody);
            //GlobalDeclaration.SendMail(curruser, "milan.s@sparrowrms.in", null, subject, msgBody);
        }

        /// <summary>
        /// Maintainance closed less than 2 hrs
        /// </summary>
        public void SendMailClosureToMaint()
        {
            string curruser = GlobalDeclaration._holdInfo[0].UserName;

            string mailTo = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("UserName") == maintenanceRMPCL.ReportedBy).ToList().FirstOrDefault()["Email"].ToString();
            //string mailToName = LoadAllUsers.AsEnumerable().Where(X => X.Field<string>("Email") == mailTo).ToList().FirstOrDefault()["UserName"].ToString();
            string msgBody = string.Format("Hi {0},\n\nA maintenance request {1} has been reported by you on {2} for Operation Plant {3} has been closed.\n\nThanks",
                     maintenanceRMPCL.ReportedBy, maintenanceRMPCL.MaintenanceCode, maintenanceRMPCL.Date, maintenanceRMPCL.OperationPlant);
            string subject = string.Format("Maintenance Closed for {0}", MaintenanceCode);
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

        public DataTable GetAllUsers()
        {
            LoadAllUsers = Resources.Instance.GetUserDetails_RMPCL(2);
            return LoadAllUsers;
        }
    }
}
