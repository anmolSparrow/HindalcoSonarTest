
using CADImport;
using ClosedXML.Excel;
using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HindalcoiOS.Maintenance
{
    public partial class MaintenanceBRK : DevExpress.XtraEditors.XtraForm
    {
        #region Variable Declaration
        public MaintenanceRMPCL maintenanceRMPCL;
        public EventHandler<string> ClearDic;
        CheckBox HeaderCheckBox = null;
        int CheckedCount = 0;
   
        public Point CustomLocation { get; set; }
        #endregion

        #region Constructor Declaration
        public MaintenanceBRK()
        {
            InitializeComponent();
            maintenanceRMPCL = new MaintenanceRMPCL();
            maintenanceRMPCL.brkStatus = BrkStatus.Prepare;
            txtbrkcode.Enabled = false;
            //dtpReportingDate.Value = DateTime.Now;
            //dtpReportingDate.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            dropDownStatus.Enabled = false;
            txtreportedby.Enabled = false;
            maintenanceRMPCL.GetAllUsers();
        }
        #endregion

        #region Method List
        private void AddHeaderCheckBox()
        {
            try
            {
                if (DGVBRKDown.Rows.Count == 0) return;
                HeaderCheckBox = new CheckBox();
                Point headerCellLocation = this.DGVBRKDown.GetCellDisplayRectangle(0,0, true).Location;
                //Place the Header CheckBox in the Location of the Header Cell.
                HeaderCheckBox.Location = new Point(headerCellLocation.X + 3, headerCellLocation.Y + 4);
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
                checkBoxColumn.ReadOnly = false;
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
                XtraMessageBox.Show(Ex.Message,ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvSelectAll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Check to ensure that the row CheckBox is clicked.
            try
            
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                {
                    ////DGVBRKDown.Rows[e.RowIndex].Selected = true;

                    //Loop to verify whether all row CheckBoxes are checked or not.

                    DataGridViewCheckBoxCell checkBox = (DGVBRKDown.SelectedRows[e.ColumnIndex].Cells["checkBoxColumn"] as DataGridViewCheckBoxCell);
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
                XtraMessageBox.Show(Ex.Message,ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ExportProcureLogExcel(this.DGVBRKDown, "BreakDown Summary");
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
                this.grpAllgrid.Visible = true;
                this.grpDetailView.Visible = false;
                this.grpAllgrid.Size = grpDetailView.Size;// new Size(1088, 404);
                //this.grpAllgrid.Dock = DockStyle.Top;
                ////*CustomLocation = this.grpDetailView.Location;
                ////*grpAllgrid.Location = CustomLocation;                 
                btnback.Visible = false;
               // btnclosed.Visible = false;
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
                dtpReportingDate.Value = maintenanceRMPCL.Date = DateTime.Now;
                dtpReportingDate.CustomFormat = "dd-MM-yyyy HH:mm";
                txtreportedby.Text = maintenanceRMPCL.ReportedBy = GlobalDeclaration._holdInfo[0].UserName;
                int randomDigit = 0; //;= helperobj.RandomNumber(1001, 9999);                    
                Resources.Instance.GetMaxID("Sp_GetMaxBRKCodeNumber", "@MaxID", ref randomDigit);//Change by RP                    
                txtbrkcode.Text = maintenanceRMPCL.Breakdowncode = GenerateCode(randomDigit);
                //grpgrid.Visible = true;
                txtxactlocation.Enabled = true;
                rtchcomments.Enabled = true;
                txtarea.Enabled = false;
                btnsubmit.Visible = true;
                grpAllgrid.Visible = false;
                chkmaintenace.Visible = false;
                btnclosed.Visible = false;
               // btnback.Visible = false;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        if (IsMaintenance == 0)
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
                XtraMessageBox.Show(Ex.Message,ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    btnsubmit.Visible = true;
                    grpAllgrid.Visible = false;
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
                DataTable dt = Resources.Instance.GetOperationUnit();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dropdownOP.Items.Add(dt.Rows[i]["OperationUnitName"]);
                }
                    //dropdownOP.DataSource = Enum.GetValues(typeof(OperationPlant));
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
                XtraMessageBox.Show(Ex.Message,ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            btnsubmit.Enabled = false;
            dropdownmachine.Enabled = false;
            dropdownOP.Enabled = false;
            dropDownStatus.Enabled = false;
            rtchcomments.Enabled = false;
            RTCHBRKComments.Enabled = false;
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
            dtpReportingDate.Value = maintenanceRMPCL.Date;
            rtchcomments.Text = maintenanceRMPCL.Others;
            //RTCHBRKComments.Text = maintenanceRMPCL.Comments;
            /// RTCHBRKComments.Visible = true;
            if (!string.IsNullOrEmpty(maintenanceRMPCL.Comments))
            {
                string msg = string.Format("Commented by {0} on {1}:\n{2}", GlobalDeclaration._holdInfo[0].UserName, DateTime.Now.ToString(), maintenanceRMPCL.Comments);
                RTCHBRKComments.Text = RTCHBRKComments.Text + msg;
            }
            txtarea.Enabled = false;
            rtchcomments.Enabled = false;
            txtxactlocation.Enabled = false;
            rtchcomments.Enabled = false;
            txtreportedby.Enabled = false;
            dropdownmachine.Enabled = false;
            dropdownOP.Enabled = false;
            dropdownpriority.Enabled = false;
            dropDownStatus.Enabled = false;
            dtpReportingDate.Enabled = false;
            //btnsumbit.Visible = false;
        }
        private void ControlHide()
        {
            this.grpDetailView.Visible = true;
            ////*this.grpAllgrid.Dock = DockStyle.Bottom;
            ////this.GRPDetailView.Dock = DockStyle.Top;
            ////this.grpDetailView.Size = new Size(1097, 473);
            //////*this.grpDetailView.Location = CustomLocation;
            this.grpAllgrid.Visible = false;
            btnclosed.Visible = false;
            btnback.Visible = true;
            btnback.Location = btnclosed.Location;
            //btnsubmit.Visible = true;
            if (maintenanceRMPCL.brkStatus == BrkStatus.Closed)
            {
                RTCHBRKComments.Visible = true;
                string msg = string.Format("Commented by {0} on {1}:\n{2}",GlobalDeclaration._holdInfo[0].UserName,DateTime.Now.ToString(), maintenanceRMPCL.Comments);
                RTCHBRKComments.Text = RTCHBRKComments.Text + msg;// maintenanceRMPCL.Comments;
                btnsubmit.Visible = false;
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
                btnsubmit.Text = "Maintenance Required";
                maintenanceRMPCL.IsMaintenanceRequired = true;
                btnsubmit.Visible = true;
                //btnsubmit.Size = new Size(204, 30);
                //btnsubmit.Location = chkmaintenace.Location;
                ////chkmaintenace.Location = new Point(583, 362);
            }
            else
            {
                maintenanceRMPCL.IsMaintenanceRequired = false;
                btnsubmit.Text = "Submit";
                btnsubmit.Visible = false;
                ////chkmaintenace.Location = new Point(583, 362);//Done
                ////btnsubmit.Location = new Point(842, 364);

                //chkmaintenace.CheckState = CheckState.Unchecked;
               // chkmaintenace.Visible = true;
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
                    if (!string.IsNullOrEmpty(maintenanceRMPCL.Area))
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
                XtraMessageBox.Show(Ex.Message,ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Dictionary<string, MaintenanceNRM> _FormMNT = new Dictionary<string, MaintenanceNRM>();
        private void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInputs() == false) return;
                if (chkmaintenace.Checked)
                {
                    if (btnsubmit.Text == "Maintenance Required")
                    {
                        if (maintenanceRMPCL.IsLoadBRKMNT == 0) //this conditon for saved Maintenance when is required
                        {
                            if (GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance") || GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Operation"))
                            {
                                MaintenanceNRM maintenanceNRM = null;
                                if (!_FormMNT.ContainsKey(btnsubmit.Text))
                                {
                                    maintenanceNRM = new MaintenanceNRM(FormStatus.New);
                                    maintenanceNRM.ClearDic += ClearDicbrk;
                                    maintenanceNRM.maintenanceRMPCL.FormName = btnsubmit.Text;
                                    _FormMNT.Add(btnsubmit.Text, maintenanceNRM);
                                    maintenanceNRM.maintenanceRMPCL.FormStatus = FormStatus.New;
                                    maintenanceNRM.maintenanceRMPCL.Others = this.rtchcomments.Text;
                                    maintenanceNRM.maintenanceRMPCL.Date = dtpReportingDate.Value;
                                    maintenanceNRM.maintenanceRMPCL.Area = this.txtarea.Text;
                                    maintenanceNRM.maintenanceRMPCL.ExactLocation = this.txtxactlocation.Text;
                                    maintenanceNRM.maintenanceRMPCL.ReportedBy = txtreportedby.Text;
                                    maintenanceNRM.maintenanceRMPCL.Date = dtpReportingDate.Value;
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
                                    maintenanceNRM.btnApproval.Visible = false;
                                    maintenanceNRM.btnReject.Visible = false;
                                    maintenanceNRM.btnback.Visible = false;                                                                                                          
                                    if (DialogResult.Yes == Statusupdate())
                                    {
                                        maintenanceNRM.IsBRKCall = true;
                                        DialogResult dgv = maintenanceNRM.ShowDialog();
                                        if (maintenanceNRM.btnStatus == "Submitted" && dgv == DialogResult.Cancel)
                                        {
                                            maintenanceRMPCL.brkStatus = BrkStatus.Submitted;
                                            DGVBRKDown.SelectedRows[0].Cells["Status"].Value = maintenanceRMPCL.brkStatus;
                                            maintenanceRMPCL.Comments = "BreakDown Document Submitted for Maintenence";
                                            DGVBRKDown.SelectedRows[0].Cells["Remark"].Value = maintenanceRMPCL.Comments;
                                            dropDownStatus.SelectedItem = maintenanceRMPCL.brkStatus;
                                            maintenanceNRM.btnsumbitaprl.Enabled = false;
                                            btnsubmit.Visible = false;
                                            chkmaintenace.Visible = false;
                                            btnsubmit.Enabled = false;
                                            chkmaintenace.Enabled = false;
                                            int result = Resources.Instance.UpdateRMPCLBreakDownRecord(maintenanceRMPCL.Breakdowncode, ((int)maintenanceRMPCL.brkStatus), maintenanceRMPCL.Comments);
                                            //if (result > 0)
                                            //{
                                            //    if (maintenanceNRM.ShowDialog() == DialogResult.Cancel)
                                            //    {
                                            //        chkmaintenace.Enabled = false; btnsubmit.Enabled = false;                                                    //this.Close();                                                }                                            }                                        }

                                            //    }
                                            //}
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
                                    maintenanceNRM = _FormMNT[btnsubmit.Text];
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
                                    maintenanceNRM.returnInventory.Enabled = false;
                                    //maintenanceNRM.returnInventoryToolStripMenuItem.Enabled = false;
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
                            string msg = string.Format("Commented by {0} on {1}:\n{2}", GlobalDeclaration._holdInfo[0].UserName, DateTime.Now.ToString(), maintenanceRMPCL.Comments);
                            RTCHBRKComments.Text = RTCHBRKComments.Text + msg;
                            maintenanceNRM.LoadMachineTag();
                            maintenanceNRM.Show();
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Please Click First On CheckBox",ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    ////if (String.IsNullOrEmpty(txtarea.Text) || String.IsNullOrEmpty(txtxactlocation.Text) || String.IsNullOrEmpty(rtchcomments.Text))
                    ////{
                    ////    XtraMessageBox.Show("Kindly fill all the information", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ////    return;
                    ////}
                    string result = string.Empty;
                    int MNTStaus = 0;
                    if (maintenanceRMPCL.IsMaintenanceRequired)
                    {
                        MNTStaus = 1;
                    }
                    maintenanceRMPCL.brkStatus = BrkStatus.Reported;
                    dropDownStatus.SelectedItem = maintenanceRMPCL.brkStatus;
                    RunTimeBRKCodeDesign();
                    int Staus = Resources.Instance.InsertRMPCLMNT(maintenanceRMPCL.Breakdowncode, maintenanceRMPCL.Date, ((int)maintenanceRMPCL.OperationPlant), ((int)maintenanceRMPCL.brkStatus), maintenanceRMPCL.MachineTag, maintenanceRMPCL.Others==null?"NA": maintenanceRMPCL.Others, ((int)maintenanceRMPCL.Priority), maintenanceRMPCL.ExactLocation, maintenanceRMPCL.Area, maintenanceRMPCL.ReportedBy, MNTStaus, ref result);
                    if (Staus > 0)
                    {
                        // Result shown in Meassage Box
                            MessageBox.Show(result, "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign);
                            DisableControl();
                        
                        maintenanceRMPCL.SubmitBreakdownMail(maintenanceRMPCL);
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                else if (((BrkStatus)DGVBRKDown.Rows[e.RowIndex].Cells["Status"].Value) == BrkStatus.Reported)
                {
                    DGVBRKDown.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.ForestGreen;
                }
                else if (((BrkStatus)DGVBRKDown.Rows[e.RowIndex].Cells["Status"].Value) == BrkStatus.Submitted)
                {
                    DGVBRKDown.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Orange;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ////*if (grpDetailView.Visible)
            {
                this.grpDetailView.Visible = false;
                this.grpAllgrid.Visible = true;
                ////*this.grpAllgrid.Dock = DockStyle.Top;
                ////*this.grpAllgrid.Size = new Size(1097, 373);
                btnback.Visible = false;
                if(Properties.Settings.Default.RoleID==2)
                btnclosed.Visible = true;
                chkmaintenace.Checked = false;
               // chkmaintenace.Location = new Point(583, 362);
                ////btnsubmit.Location = new Point(842, 364);
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
                if (e.ColumnIndex == 0)
                {
                    if (DGVBRKDown.SelectedRows.Count > 0)
                    {
                        maintenanceRMPCL.brkStatus = ((BrkStatus)DGVBRKDown.SelectedRows[e.ColumnIndex].Cells["Status"].Value);
                        maintenanceRMPCL.MachineTag = DGVBRKDown.SelectedRows[e.ColumnIndex].Cells["MachineTag"].Value.ToString();
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

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DGVBRKDown_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                //btnsubmit.Visible = true;
                if (DGVBRKDown.SelectedRows.Count > 0)               
                {
                    maintenanceRMPCL.brkStatus = ((BrkStatus)DGVBRKDown.Rows[e.RowIndex].Cells["Status"].Value);
                    maintenanceRMPCL.MachineTag = DGVBRKDown.Rows[e.RowIndex].Cells["MachineTag"].Value.ToString();
                    maintenanceRMPCL.OperationPlant = ((OperationPlant)DGVBRKDown.Rows[e.RowIndex].Cells["Operationplant"].Value);
                    maintenanceRMPCL.Others = DGVBRKDown.Rows[e.RowIndex].Cells["Others"].Value.ToString();
                    maintenanceRMPCL.ReportedBy = DGVBRKDown.Rows[e.RowIndex].Cells["ReportedBy"].Value.ToString();
                    maintenanceRMPCL.Priority = ((Priority)DGVBRKDown.Rows[e.RowIndex].Cells["Priority"].Value);
                    maintenanceRMPCL.Breakdowncode = DGVBRKDown.Rows[e.RowIndex].Cells["BreakdownCode"].Value.ToString();
                    maintenanceRMPCL.Area = DGVBRKDown.Rows[e.RowIndex].Cells["Area"].Value.ToString();
                    maintenanceRMPCL.Date = DateTime.Parse(DGVBRKDown.Rows[e.RowIndex].Cells["Date"].Value.ToString());
                    maintenanceRMPCL.ExactLocation = DGVBRKDown.Rows[e.RowIndex].Cells["Exactlocation"].Value.ToString();
                    if (dropdownmachine.Items.Contains(maintenanceRMPCL.MachineTag))
                    {
                        //maintenanceRMPCL.MachineTag = dropdownmachine.SelectedItem.ToString();
                        dropdownmachine.SelectedItem = maintenanceRMPCL.MachineTag;
                    }
                    else
                    {
                        maintenanceRMPCL.MachineTag = null;
                    }
                    if (DGVBRKDown.Rows[e.RowIndex].Cells["Remark"].Value == null)
                    {
                        maintenanceRMPCL.Comments = "";
                    }
                    else
                    {
                        maintenanceRMPCL.Comments = DGVBRKDown.Rows[e.RowIndex].Cells["Remark"].Value.ToString();
                    }
                    if (GlobalDeclaration._holdInfo[0].UserRole.Equals("U1-Maintenance") && maintenanceRMPCL.brkStatus == BrkStatus.Reported)
                    {
                        chkmaintenace.Visible = true;
                        chkmaintenace.Enabled = true;
                       // chkmaintenace.Location = btnsubmit.Location;
                        // btnsubmit.Visible = false;
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
                XtraMessageBox.Show(Ex.Message,ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MaintenanceBRK_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (maintenanceRMPCL == null) return;
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
                        //commentsFrm.btnCommSave.Enabled = true;
                        //commentsFrm.btnCommSave.Visible = true;
                        if (commentsFrm.ShowDialog() == DialogResult.OK)
                        {
                            string commts = commentsFrm.txtcomments.Text;
                            commentsFrm.Close();
                            if (DialogResult.OK == UpdateDBRow(maintenanceRMPCL.Breakdowncode, commts, "Task Closed Successfully!!!"))
                            {
                                DGVBRKDown.SelectedRows[0].Cells["Remark"].Value = maintenanceRMPCL.Comments = commts;
                                btnclosed.Enabled = false;
                                //commentsFrm.btnCommSave.Visible = true;
                            }
                        }
                        maintenanceRMPCL.ClosureUpdate(maintenanceRMPCL);
                        maintenanceRMPCL.BreakdownClosureMail(maintenanceRMPCL);

                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message,ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            return XtraMessageBox.Show("Are You Sure to Submit this " + maintenanceRMPCL.Breakdowncode + " for Maintenence!", ApplicationConstants.MessageDisplay, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        private void txtarea_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtarea.Text))
            {
                maintenanceRMPCL.Area = txtarea.Text;
            }
        }


        #endregion

        private void MaintenanceBRK_Load(object sender, EventArgs e)
        {
            
            ////dtpReportingDate.Enabled = false;
            DisableControlPermanent();
        }

        private bool ValidateInputs()
        {
            bool isValid = true;
            if (String.IsNullOrEmpty(dropdownmachine.Text))
            {
                XtraMessageBox.Show("Kindly Select Machine Tag", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
            }
           else if (String.IsNullOrEmpty(txtxactlocation.Text))
            {
                XtraMessageBox.Show("Kindly Fill Exact Location", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
            }
            else if (String.IsNullOrEmpty(txtarea.Text))
            {
                XtraMessageBox.Show("Area is blank! Please check Machine Area", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
            }
            else if (String.IsNullOrEmpty(rtchcomments.Text))
            {
                XtraMessageBox.Show("Kindly Input Other Details", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false; 
            }
            else if (String.IsNullOrEmpty(dropdownOP.Text))
            {
                XtraMessageBox.Show("Kindly Select OperationUnit", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
            }
            return isValid;
        }



        private void DisableControlPermanent()
        {
            dtpReportingDate.Value = DateTime.Now;
            dtpReportingDate.Enabled = false;
            RTCHBRKComments.Enabled = false;
        }

        private void txtarea_Leave_1(object sender, EventArgs e)
        {

        }
    }
}
