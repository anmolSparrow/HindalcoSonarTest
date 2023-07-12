using Bunifu.UI.WinForms;
using CADImport;
using ClosedXML.Excel;
using DevExpress.XtraEditors;
using RMPCLApp.Class_Operation;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RMPCLApp.Maintenance
{
    public partial class MaintenanceBRK : DevExpress.XtraEditors.XtraForm
    {
        #region Variable Declaration
        public  MaintenanceRMPCL maintenanceRMPCL;
        public EventHandler<string> ClearDic;
        CheckBox HeaderCheckBox = null;
        int CheckedCount = 0;
        #endregion

        #region Constructor Declaration
        public MaintenanceBRK()
        {
            InitializeComponent();
            maintenanceRMPCL = new MaintenanceRMPCL();
            maintenanceRMPCL.brkStatus = BrkStatus.Prepare;
        }
        #endregion

        #region Method List
        private void AddHeaderCheckBox()
        {
            try
            {
                HeaderCheckBox = new CheckBox();
                Point headerCellLocation = this.DGVBRKDown.GetCellDisplayRectangle(0, -1, true).Location;
                //Place the Header CheckBox in the Location of the Header Cell.
                HeaderCheckBox.Location = new Point(headerCellLocation.X + 3, headerCellLocation.Y +4);
                HeaderCheckBox.BackColor = Color.White;
                HeaderCheckBox.Size = new Size(20, 20);
                //Assign Click event to the Header CheckBox.
                HeaderCheckBox.Click += new System.EventHandler(HeaderCheckBox_Clicked);
                DGVBRKDown.Controls.Add(HeaderCheckBox);

                //Add a CheckBox Column to the DataGridView at the first position.
                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                checkBoxColumn.HeaderText = "";
                checkBoxColumn.Width = 10;
                checkBoxColumn.Name = "checkBoxColumn";
                DGVBRKDown.Columns.Insert(0, checkBoxColumn);
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
                DGVBRKDown.EndEdit();
                CheckedCount = 0;
                //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
                foreach (DataGridViewRow row in DGVBRKDown.Rows)
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
        private void dgvSelectAll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Check to ensure that the row CheckBox is clicked.
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                {

                    //Loop to verify whether all row CheckBoxes are checked or not.

                    DataGridViewCheckBoxCell checkBox = (DGVBRKDown.SelectedRows[0].Cells["checkBoxColumn"] as DataGridViewCheckBoxCell);
                    if (Convert.ToBoolean(DGVBRKDown.SelectedRows[0].Cells["checkBoxColumn"].EditedFormattedValue) == false)
                    {
                        CheckedCount++;
                        checkBox.Value = true;
                    }
                    else
                    {
                        CheckedCount--;
                        checkBox.Value = false;
                    }
                    if (CheckedCount == DGVBRKDown.Rows.Count)
                    {
                        HeaderCheckBox.Checked = true;
                    }
                    else if (CheckedCount < DGVBRKDown.Rows.Count)
                    {
                        HeaderCheckBox.Checked = false;
                    }
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
            ExportProcureLogExcel(this.DGVBRKDown, "BreakDown Summary");
        }
        private void ExportProcureLogExcel(BunifuDataGridView dgv, string fileName)
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
                    dr["Reporting Date"] = Rows[i].Cells["Date"].Value;
                    dr["Breakdown Code"] = Rows[i].Cells["BreakdownCode"].Value;
                    dr["Operation Plant"] = Rows[i].Cells["OperationPlant"].Value;
                    dr["Status"] = Rows[i].Cells["Status"].Value;
                    dr["Machine Tag"] = Rows[i].Cells["MachineTag"].Value;
                    dr["Others Details"] = Rows[i].Cells["Others"].Value;
                    dr["Priority"] = Rows[i].Cells["Priority"].Value;
                    dr["Exact Location"] = Rows[i].Cells["ExactLocation"].Value;            
                    dr["Area"] = Rows[i].Cells["Area"].Value;
                    dr["Reported By"] = Rows[i].Cells["ReportedBy"].Value;
                    dr["Comment"] = Rows[i].Cells["Remark"].Value;
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
        public void LoadSummaryData()
        {
            try
            {
                RebindDataSource();
                DataTable dt = null;
                dt = Resources.Instance.GetDataKey("Sp_GetRMPCLBRKSummaryRecord");
                LoadBRKDownHistory(dt);
                this.grpgrid.Visible = true;
                this.GRPDetailView.Visible = false;
                this.grpgrid.Dock = DockStyle.Top;
                this.grpgrid.Size = new Size(1097, 473);
                //this.grpgrid.Location = this.GRPDetailView.Location;
                btnback.Visible = false;
                AddHeaderCheckBox();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GenerateCode(int maxnumber)
        {
            return String.Format("{0}-{1:0000}", "BRK", maxnumber + 1);
        }
        public void CreateNewBrkDown()
        {
            try
            {
                RebindDataSource();
                dropDownStatus.SelectedItem = maintenanceRMPCL.brkStatus;
                datetimepicker.Value = maintenanceRMPCL.Date = DateTime.Now;
                txtreportedby.Text = maintenanceRMPCL.ReportedBy = GlobalDeclaration._holdInfo[0].UserName;
                int randomDigit = 0; //;= helperobj.RandomNumber(1001, 9999);                    
                Resources.Instance.GetMaxID("Sp_GetMaxBRKCodeNumber", "@MaxID", ref randomDigit);//Change by RP                    
                txtbrkcode.Text = maintenanceRMPCL.Breakdowncode = GenerateCode(randomDigit);
                //grpgrid.Visible = true;
                txtxactlocation.Enabled = true;
                rtchcomments.Enabled = true;
                txtarea.Enabled = false;
                btnsumbit.Visible = true;
                grpgrid.Visible = false;
                chkmaintenace.Visible = false;
                btnclosed.Visible = false;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                                           ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void GetBrkSummaryData()
        {
            DataTable dt = null;
            if (GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-GM"))
            {
                dt = Resources.Instance.GetDataKey("Sp_GetRMPClosedRecord");
                LoadBRKDownHistory(dt);
            }

        }
        public void LoadBRKDownHistory(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        DGVBRKDown.Rows.Add(dr);
                        int index = DGVBRKDown.Rows.Count - 1;
                        DGVBRKDown.Rows[index].Cells["BreakdownCode"].Value = dt.Rows[i]["BreakDownCode"];
                        DGVBRKDown.Rows[index].Cells["Date"].Value = Convert.ToDateTime(dt.Rows[i]["BreakDownDate"]);
                        DGVBRKDown.Rows[index].Cells["Operationplant"].Value = Enum.ToObject(typeof(OperationPlant), int.Parse(dt.Rows[i]["OperationPant"].ToString()));
                        DGVBRKDown.Rows[index].Cells["Status"].Value = Enum.ToObject(typeof(BrkStatus), int.Parse(dt.Rows[i]["Status"].ToString()));
                        DGVBRKDown.Rows[index].Cells["MachineTag"].Value = dt.Rows[i]["MachineTag"];
                        DGVBRKDown.Rows[index].Cells["Others"].Value = dt.Rows[i]["Others"];
                        DGVBRKDown.Rows[index].Cells["Priority"].Value = Enum.ToObject(typeof(Priority), int.Parse(dt.Rows[i]["Priority"].ToString()));
                        DGVBRKDown.Rows[index].Cells["Exactlocation"].Value = dt.Rows[i]["ExactLocation"];
                        DGVBRKDown.Rows[index].Cells["Area"].Value = dt.Rows[i]["Area"];
                        DGVBRKDown.Rows[index].Cells["ReportedBy"].Value = dt.Rows[i]["ReportedBy"];
                        if (!string.IsNullOrEmpty(dt.Rows[i]["Comments"].ToString()))
                        {                           
                            DGVBRKDown.Rows[index].Cells["Remark"].Value = dt.Rows[i]["Comments"];
                        }
                        else
                        {
                            DGVBRKDown.Rows[index].Cells["Remark"].Value = "";
                        }
                        int IsMaintenance = 0;
                        int.TryParse(dt.Rows[i]["IsMaintenanceRequired"].ToString(), out IsMaintenance);
                        if(IsMaintenance==0)
                        {
                            chkmaintenace.Checked = false;
                            maintenanceRMPCL.IsMaintenanceRequired = false;
                        }
                        else
                        {
                            chkmaintenace.Checked = true;
                            maintenanceRMPCL.IsMaintenanceRequired = true;
                            maintenanceRMPCL.IsLoadBRKMNT = 1;
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
        public void CreateBRKDownFrommRightLick()
        {
            try
            {
                if (!string.IsNullOrEmpty(maintenanceRMPCL.MachineTag))
                {
                    RebindDataSource();
                    RunTimeBRKCodeDesign();
                    txtreportedby.Text = maintenanceRMPCL.ReportedBy = GlobalDeclaration._holdInfo[0].UserName;                    
                    txtarea.Text = maintenanceRMPCL.Area;
                    txtxactlocation.Enabled = true;
                    rtchcomments.Enabled = true;
                    txtarea.Enabled = false;
                    btnsumbit.Visible = true;
                    grpgrid.Visible = false;
                    //GRPDetailView.Visible = false;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                                           ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void RunTimeBRKCodeDesign()
        {
            int randomDigit = 0; //;= helperobj.RandomNumber(1001, 9999);                    
            Resources.Instance.GetMaxID("Sp_GetMaxBRKCodeNumber", "@MaxID", ref randomDigit);//Change by RP                    
            txtbrkcode.Text = maintenanceRMPCL.Breakdowncode = GenerateCode(randomDigit);
        }
        public void RebindDataSource()
        {
            try
            {
                dropdownOP.DataSource = Enum.GetValues(typeof(OperationPlant));
                dropdownpriority.DataSource = Enum.GetValues(typeof(Priority));
                dropDownStatus.DataSource = Enum.GetValues(typeof(BrkStatus));
                if (this.dropdownmachine.Items.Count == 0)
                {
                    foreach (var item in GlobalDeclaration._MyTagDictinary)
                    {
                        string MachineTag = item.Value;
                        this.dropdownmachine.Items.Add(MachineTag);
                    }
                    this.dropdownmachine.Items.Add("NA");
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                                        ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string AddMachineArea()
        {
            string receiceValue = maintenanceRMPCL.MachineTag;
            DPoint dPoint = GlobalDeclaration._MyTagDictinary.AsEnumerable().Where(X => X.Value == receiceValue).FirstOrDefault().Key;
            var area = Resources.Instance.MachineDt.AsEnumerable().Where(X => X.Field<string>("Cadlocation") == "X" + dPoint.X + " " + "Y" + dPoint.Y).Select(X => X.Field<string>("MachineLocation")).Distinct().ToList();
            return area[0].ToString();
        }
        private void DisableControl()
        {
            txtarea.Enabled = false;
            rtchcomments.Enabled = false;
            txtxactlocation.Enabled = false;
            chkmaintenace.Enabled = false;
            btnsumbit.Enabled = false;
            dropdownmachine.Enabled = false;
            dropdownOP.Enabled = false;
            dropDownStatus.Enabled = false;
            rtchcomments.Enabled = false;
            dropdownpriority.Enabled = false;
        }
        private void MapTextValue()
        {
            RebindDataSource();
            txtarea.Text = maintenanceRMPCL.Area;
            txtxactlocation.Text = maintenanceRMPCL.ExactLocation;
            txtbrkcode.Text = maintenanceRMPCL.Breakdowncode;
            txtreportedby.Text = maintenanceRMPCL.ReportedBy;          
            dropdownmachine.SelectedItem = maintenanceRMPCL.MachineTag;
            dropdownOP.SelectedItem = maintenanceRMPCL.OperationPlant;
            dropdownpriority.SelectedItem = maintenanceRMPCL.Priority;
            dropDownStatus.SelectedItem = maintenanceRMPCL.brkStatus;
            datetimepicker.Value = maintenanceRMPCL.Date;
            rtchcomments.Text = maintenanceRMPCL.Others;
            RTCHBRKComments.Text = maintenanceRMPCL.Comments;
            txtarea.Enabled = false;
            rtchcomments.Enabled = false;
            txtxactlocation.Enabled = false;
            rtchcomments.Enabled = false;
            txtreportedby.Enabled = false;
            dropdownmachine.Enabled = false;
            dropdownOP.Enabled = false;
            dropdownpriority.Enabled = false;
            dropDownStatus.Enabled = false;
            datetimepicker.Enabled = false;
            //btnsumbit.Visible = false;
        }
        private void ControlHide()
        {            
            this.GRPDetailView.Visible = true;
            this.grpgrid.Dock = DockStyle.Bottom;
            this.GRPDetailView.Dock = DockStyle.Top;
            this.GRPDetailView.Size = new Size(1097, 373);
            this.grpgrid.Visible = false;
            btnclosed.Visible = false;
            btnback.Visible = true;
            btnback.Location = btnclosed.Location;
            if (maintenanceRMPCL.brkStatus == BrkStatus.Closed)
            {
                RTCHBRKComments.Visible = true;
                RTCHBRKComments.Text = maintenanceRMPCL.Comments;
                //btnsumbit.Location = chkmaintenace.Location;
                //chkmaintenace.Location = RTCHBRKComments.Location;
                
            }
            //if (chkmaintenace.Checked)
            //{
            //    btnsumbit.Visible = true;
            //    maintenanceRMPCL.IsMaintenanceRequired = true;
            //}
            //else
            //{
            //    chkmaintenace.Enabled = false;
            //    maintenanceRMPCL.IsMaintenanceRequired = false;
            //}
        }
        #endregion

        #region Event List
        private void chkmaintenace_CheckedChanged(object sender, EventArgs e)
        {
            if (chkmaintenace.Checked)
            {
                btnsumbit.Text = "Maintenance Required";
                maintenanceRMPCL.IsMaintenanceRequired = true;
                btnsumbit.Visible = true;
                btnsumbit.Location = chkmaintenace.Location;
                chkmaintenace.Location = new Point(563, 313);
            }
            else
            {
                maintenanceRMPCL.IsMaintenanceRequired = false;
                btnsumbit.Text = "Submit";// "Sumbit";
                btnsumbit.Visible = false;
                chkmaintenace.Location = new Point(818, 313);
                btnsumbit.Location = new Point(818, 354);
            }
        }
        private void dropdownmachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dropdownmachine.SelectedItem == null) return;
                maintenanceRMPCL.MachineTag = dropdownmachine.SelectedItem.ToString();
                if (dropdownmachine.SelectedItem.ToString() == "NA")
                {
                    txtarea.Enabled = true;
                    if (string.IsNullOrEmpty(maintenanceRMPCL.Area))
                        maintenanceRMPCL.Area = txtarea.Text = "";
                }
                else
                {
                    txtarea.Text = maintenanceRMPCL.Area = AddMachineArea();
                    txtarea.Enabled = false;
                    // dropdownmachinetag.Enabled = false;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                                          ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Dictionary<string, MaintenanceNRM> _FormMNT = new Dictionary<string, MaintenanceNRM>();
        private void btnsumbit_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkmaintenace.Checked)
                {
                    if (btnsumbit.Text == "Maintenance Required")
                    {
                        if (maintenanceRMPCL.IsLoadBRKMNT == 0) //this conditon for saved Maintenance when is required
                        {
                            if (GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance") || GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Operation"))
                            {
                                MaintenanceNRM maintenanceNRM = null;
                                if (!_FormMNT.ContainsKey(btnsumbit.Text))
                                {
                                    maintenanceNRM = new MaintenanceNRM(FormStatus.New);
                                    maintenanceNRM.ClearDic += ClearDicbrk;
                                    maintenanceNRM.maintenanceRMPCL.FormName = btnsumbit.Text;
                                    _FormMNT.Add(btnsumbit.Text, maintenanceNRM);
                                    maintenanceNRM.maintenanceRMPCL.FormStatus = FormStatus.New;
                                    maintenanceNRM.maintenanceRMPCL.Others = this.rtchcomments.Text;
                                    maintenanceNRM.maintenanceRMPCL.Date = datetimepicker.Value;
                                    maintenanceNRM.maintenanceRMPCL.Area = this.txtarea.Text;
                                    maintenanceNRM.maintenanceRMPCL.ExactLocation = this.txtxactlocation.Text;
                                    maintenanceNRM.maintenanceRMPCL.ReportedBy = txtreportedby.Text;
                                    maintenanceNRM.maintenanceRMPCL.Date = datetimepicker.Value;
                                    maintenanceNRM.LoadMachineTag(true, maintenanceRMPCL.Breakdowncode);
                                    maintenanceNRM.maintenanceRMPCL.Status = Class_Operation.Status.Reported;
                                    maintenanceNRM.dropdownstatus.SelectedItem = maintenanceNRM.maintenanceRMPCL.Status;
                                    maintenanceNRM.maintenanceRMPCL.OperationPlant = ((OperationPlant)dropdownOP.SelectedItem);
                                    maintenanceNRM.dropdownOP.SelectedItem = maintenanceNRM.maintenanceRMPCL.OperationPlant;
                                    maintenanceNRM.maintenanceRMPCL.Priority = ((Priority)dropdownpriority.SelectedItem);
                                    maintenanceNRM.dropdownpriority.SelectedItem = maintenanceNRM.maintenanceRMPCL.Priority;
                                    maintenanceNRM.dropdownmachinetag.SelectedItem = this.dropdownmachine.SelectedItem;
                                    maintenanceNRM.dropdownmachinetag.Enabled = false;
                                    maintenanceNRM.dropdownOP.Enabled = false;
                                    maintenanceNRM.dropdownpriority.Enabled = false;
                                    maintenanceNRM.txtExtactlocation.Enabled = false;
                                    maintenanceNRM.txtothers.Enabled = false;
                                    if (DialogResult.Yes == Statusupdate())
                                    {
                                        maintenanceRMPCL.brkStatus = BrkStatus.Submitted;
                                        DGVBRKDown.SelectedRows[0].Cells["Status"].Value = maintenanceRMPCL.brkStatus;
                                        maintenanceRMPCL.Comments = "BreakDown Document Submitted for Maintenence User";
                                        DGVBRKDown.SelectedRows[0].Cells["Remark"].Value = maintenanceRMPCL.Comments;
                                        int result = Resources.Instance.UpdateRMPCLBreakDownRecord(maintenanceRMPCL.Breakdowncode, ((int)maintenanceRMPCL.brkStatus), maintenanceRMPCL.Comments);
                                        if (result > 0)
                                        {
                                            if (maintenanceNRM.ShowDialog() == DialogResult.OK)
                                            {
                                                this.Close();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        maintenanceNRM.ClearProprety();
                                        maintenanceNRM.Close();
                                        maintenanceNRM.Dispose();
                                        maintenanceNRM = null;
                                        return;
                                    }
                                    //if (maintenanceNRM.ShowDialog() == DialogResult.OK)
                                    //{
                                    //    maintenanceNRM.Close();
                                    //    maintenanceNRM.Dispose();
                                    //}
                                }
                                else
                                {
                                    maintenanceNRM = _FormMNT[btnsumbit.Text];
                                    maintenanceNRM.Show();
                                }
                                if (GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))
                                {
                                    maintenanceNRM.numericHour.Visible = true;
                                    maintenanceNRM.numericMinutes.Visible = true;
                                }
                                else if (GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Operation"))
                                {
                                    maintenanceNRM.numericHour.Visible = false;
                                    maintenanceNRM.numericMinutes.Visible = false;
                                    maintenanceNRM.lblexpectedtime.Visible = false;
                                    maintenanceNRM.lblAssignTo.Visible = false;
                                    maintenanceNRM.dropdownAssignTo.Visible = false;
                                    maintenanceNRM.btnAddWorker.Enabled = false;
                                    maintenanceNRM.btnInvertory.Enabled = false;
                                    maintenanceNRM.removeWorkerToolStripMenuItem.Enabled = false;
                                    maintenanceNRM.addWorkerToolStripMenuItem.Enabled = false;
                                    maintenanceNRM.AddInverntroy.Enabled = false;
                                    maintenanceNRM.Removeinventory.Enabled = false;
                                    maintenanceNRM.returnInventoryToolStripMenuItem.Enabled = false;
                                    //maintenanceNRM.lblAssignTo.Location = maintenanceNRM.lblreportedby.Location;
                                    //maintenanceNRM.dropdownAssignTo.Location = maintenanceNRM.txtReportedby.Location;
                                    maintenanceNRM.lblreportedby.Location = maintenanceNRM.lblexpectedtime.Location;
                                    maintenanceNRM.txtReportedby.Location = (maintenanceNRM.numericHour.Location);
                                }

                            }

                        }
                        else // This Condition for  Save Load Maintenace BRK
                        {
                            MaintenanceNRM maintenanceNRM = new MaintenanceNRM();
                            if (GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance") || GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Operation"))
                            {
                                maintenanceNRM.btnApproval.Visible = false;
                                maintenanceNRM.btnReject.Visible = false;
                                maintenanceNRM.btnclosed.Visible = false;
                            }
                            //else if (GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Operation"))
                            //{
                            //    maintenanceNRM.btnApproval.Visible = false;
                            //    maintenanceNRM.btnReject.Visible = false;
                            //    maintenanceNRM.btnclosed.Visible = false;
                            //}
                            else if (GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-GM"))
                            {
                                maintenanceNRM.btnApproval.Visible = true;
                                maintenanceNRM.btnReject.Visible = true;
                                maintenanceNRM.btnclosed.Visible = false;
                            }
                            maintenanceNRM.maintenanceRMPCL.CallingLocation = true;
                            maintenanceNRM.maintenanceRMPCL.FormStatus = FormStatus.Summary;
                            maintenanceNRM.LoadMachineTag();
                            maintenanceNRM.Show();
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Please Click First On CheckBox",
                                        ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    if (String.IsNullOrEmpty(txtarea.Text)&& String.IsNullOrEmpty(txtxactlocation.Text) && String.IsNullOrEmpty(rtchcomments.Text))
                    {
                        XtraMessageBox.Show("Kindly fill all the information", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string result = string.Empty;
                    int MNTStaus = 0;
                    if (maintenanceRMPCL.IsMaintenanceRequired)
                    {
                        MNTStaus = 1;
                    }
                    maintenanceRMPCL.brkStatus = BrkStatus.Reported;
                    dropDownStatus.SelectedItem = maintenanceRMPCL.brkStatus;
                    RunTimeBRKCodeDesign();
                    int Staus = Resources.Instance.InsertRMPCLMNT(maintenanceRMPCL.Breakdowncode, maintenanceRMPCL.Date, ((int)maintenanceRMPCL.OperationPlant), ((int)maintenanceRMPCL.brkStatus), maintenanceRMPCL.MachineTag, maintenanceRMPCL.Others, ((int)maintenanceRMPCL.Priority), maintenanceRMPCL.ExactLocation, maintenanceRMPCL.Area, maintenanceRMPCL.ReportedBy, MNTStaus, ref result);
                    if (Staus > 0)
                    {

                        // Result shown in Meassage Box
                        MessageBox.Show(result, "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign);
                        DisableControl();
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                                           ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearDicbrk(object Sender, string frmname)
        {
            if (_FormMNT.ContainsKey(frmname))
            {
                _FormMNT.Remove(frmname);
            }            
        }
        private void DGVBRKDown_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (((BrkStatus)DGVBRKDown.Rows[e.RowIndex].Cells["Status"].Value) == BrkStatus.Closed)
                {
                    DGVBRKDown.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkGray;
                }
                else if (((BrkStatus)DGVBRKDown.Rows[e.RowIndex].Cells["Status"].Value) == BrkStatus.Closed)
                {
                    DGVBRKDown.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.ForestGreen;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                                                ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtbrkcode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbrkcode.Text))
            {
                maintenanceRMPCL.Breakdowncode = txtbrkcode.Text;
            }
        }

        private void dropdownOP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dropdownOP.SelectedItem.ToString()) && maintenanceRMPCL.FormStatus == FormStatus.New)
                maintenanceRMPCL.OperationPlant = ((OperationPlant)dropdownOP.SelectedItem);
        }

        private void dropdownpriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dropdownpriority.SelectedItem.ToString()) && maintenanceRMPCL.FormStatus == FormStatus.New)
                maintenanceRMPCL.Priority = ((Priority)dropdownpriority.SelectedItem);
        }

        private void rtchcomments_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rtchcomments.Text))
            {
                maintenanceRMPCL.Others = rtchcomments.Text;
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            if (GRPDetailView.Visible)
            {
                this.GRPDetailView.Visible = false;
                this.grpgrid.Visible = true;
                this.grpgrid.Dock = DockStyle.Top;
                this.grpgrid.Size = new Size(1097, 373);                
                btnback.Visible = false;
                btnclosed.Visible = true;
            }
        }
        private void txtxactlocation_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtxactlocation.Text))
            {
                maintenanceRMPCL.ExactLocation = txtxactlocation.Text;
            }
        }
        private void DGVBRKDown_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DGVBRKDown.SelectedRows.Count > 0)
                {
                    maintenanceRMPCL.brkStatus = ((BrkStatus)DGVBRKDown.SelectedRows[0].Cells["Status"].Value);
                    maintenanceRMPCL.MachineTag= DGVBRKDown.SelectedRows[0].Cells["MachineTag"].Value.ToString();
                    if (maintenanceRMPCL.brkStatus == BrkStatus.Reported && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))
                    {
                        maintenanceRMPCL.Breakdowncode = DGVBRKDown.SelectedRows[0].Cells["BreakdownCode"].Value.ToString();
                        btnclosed.Visible = true;
                        btnclosed.Enabled = true;
                    }
                    else
                    {
                        btnclosed.Visible = false;
                        btnclosed.Enabled = false;
                    }
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                                              ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DGVBRKDown_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DGVBRKDown.SelectedRows.Count > 0)
                {
                    
                    maintenanceRMPCL.brkStatus = ((BrkStatus)DGVBRKDown.SelectedRows[0].Cells["Status"].Value);
                    maintenanceRMPCL.MachineTag = DGVBRKDown.SelectedRows[0].Cells["MachineTag"].Value.ToString();
                    maintenanceRMPCL.OperationPlant = ((OperationPlant)DGVBRKDown.SelectedRows[0].Cells["Operationplant"].Value);
                    maintenanceRMPCL.Others = DGVBRKDown.SelectedRows[0].Cells["Others"].Value.ToString();
                    maintenanceRMPCL.ReportedBy = DGVBRKDown.SelectedRows[0].Cells["ReportedBy"].Value.ToString();
                    maintenanceRMPCL.Priority = ((Priority)DGVBRKDown.SelectedRows[0].Cells["Priority"].Value);
                    maintenanceRMPCL.Breakdowncode = DGVBRKDown.SelectedRows[0].Cells["BreakdownCode"].Value.ToString();
                    maintenanceRMPCL.Area = DGVBRKDown.SelectedRows[0].Cells["Area"].Value.ToString();
                    maintenanceRMPCL.Date = DateTime.Parse(DGVBRKDown.SelectedRows[0].Cells["Date"].Value.ToString());
                    maintenanceRMPCL.ExactLocation = DGVBRKDown.SelectedRows[0].Cells["Exactlocation"].Value.ToString();
                    if (dropdownmachine.Items.Contains(maintenanceRMPCL.MachineTag))
                    {
                        //maintenanceRMPCL.MachineTag = dropdownmachine.SelectedItem.ToString();
                        dropdownmachine.SelectedItem = maintenanceRMPCL.MachineTag;
                    }
                    else
                    {
                        maintenanceRMPCL.MachineTag = null;
                    }
                    if (DGVBRKDown.SelectedRows[0].Cells["Remark"].Value == null)
                    {
                        maintenanceRMPCL.Comments = "";
                    }
                    else
                    {
                        maintenanceRMPCL.Comments = DGVBRKDown.SelectedRows[0].Cells["Remark"].Value.ToString();
                    }
                    if (GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance") && maintenanceRMPCL.brkStatus == BrkStatus.Reported)
                    {
                        chkmaintenace.Visible = true;
                        chkmaintenace.Enabled = true;
                    }
                    else
                    {
                        chkmaintenace.Visible = false;
                        chkmaintenace.Enabled = false;
                    }
                    MapTextValue();
                    ControlHide();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,
                                            ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MaintenanceBRK_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.ClearDic.Invoke(sender, maintenanceRMPCL.FormName);
        }

        private void btnclosed_Click(object sender, EventArgs e)
        {
            try
            {
                string result = string.Empty;
                if (DGVBRKDown.SelectedRows.Count > 0)
                {
                    if (maintenanceRMPCL.brkStatus == BrkStatus.Reported && GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance"))
                    {
                        maintenanceRMPCL.brkStatus = BrkStatus.Closed;
                        DGVBRKDown.SelectedRows[0].Cells["Status"].Value = maintenanceRMPCL.brkStatus;
                        DGVBRKDown.SelectedRows[0].DefaultCellStyle.BackColor = Color.LightGray;
                        DGVBRKDown.SelectedRows[0].ReadOnly = true;
                        CommentsFrm commentsFrm = new CommentsFrm();
                        if (commentsFrm.ShowDialog() == DialogResult.OK)
                        {
                            string commts = commentsFrm.txtcomments.Text;
                            commentsFrm.Close();
                            if (DialogResult.OK == UpdateDBRow(maintenanceRMPCL.Breakdowncode, commts, "Task Closed Successfully!!!"))
                            {
                                DGVBRKDown.SelectedRows[0].Cells["Remark"].Value = maintenanceRMPCL.Comments = commts;
                                btnclosed.Enabled = false;
                            }
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
        public DialogResult UpdateDBRow(string MNTCode, string comments, string msg)
        {
            int result = Resources.Instance.UpdateRMPCLBreakDownRecord(maintenanceRMPCL.Breakdowncode, ((int)maintenanceRMPCL.brkStatus), comments);
            if (result > 0)
            {
                return XtraMessageBox.Show(msg, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                return DialogResult.None;
            }
        }
        public DialogResult Statusupdate()
        {
            return XtraMessageBox.Show("Are You Sure to Submit this "+maintenanceRMPCL.Breakdowncode+" for Maintenence!", ApplicationConstants.MessageDisplay, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        private void txtarea_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtarea.Text))
            {
                maintenanceRMPCL.Area = txtarea.Text;
            }
        }

        #endregion       
    }
}
