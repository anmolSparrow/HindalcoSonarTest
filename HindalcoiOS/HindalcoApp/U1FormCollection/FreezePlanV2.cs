using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace HindalcoiOS.U1FormCollection
{
    public partial class FreezePlan : XtraForm
    {
        #region Global Declaration Dynamic Column Add In DataGridview
        delegate void SetComboBoxCellType(int iRowIndex, string clmname);

        public EventHandler<DataSet> _UploadReport;
        bool bIsComboBox = false;
        string UploadCL = string.Empty;
        bool IsRowEdit = false;
        DateTimePicker LastDateTimePicker;
        #endregion
        public FreezePlan()
        {
            InitializeComponent();
        }

        private void FreezePlan_Load(object sender, EventArgs e)
        {
            //DGVfreeze.DataSource = GlobalDeclaration.BindFreezPlanClm();
            //BindDyNamicClm();
            checkedListBox1.Visible = false;
            this._UploadReport += UploadEventFire;
            LoadUnit();
            LoadMaintenaceData();
            GridSeeting();
        }
        private void GridSeeting()
        {
            try
            {
                DGVfreeze.BorderStyle = BorderStyle.Fixed3D;

                DGVfreeze.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                DGVfreeze.AllowUserToResizeColumns = false;

                DGVfreeze.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                DGVfreeze.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;

                DGVfreeze.DefaultCellStyle.SelectionForeColor = Color.Black;
                DGVfreeze.RowsDefaultCellStyle.BackColor = Color.LightGray;
                DGVfreeze.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
                DGVfreeze.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadUnit()
        {
            // units = Resources.Instance.GetDataKey("Sp_FetchUnitMaster");
            // EmployeList = Resources.Instance.GetDataKey("SP_GetEmployeeName");
            MultiselectionAdditinalMan();
            //if (this.checkedListBox1.Items.Count > 0) return;
            //foreach (var item in GlobalDeclaration._MyTagDictinary)
            //{
            //    string MachineTag = item.Value;
            //    this.checkedListBox1.Items.Add(MachineTag);
            //}
            //this.checkedListBox1.SelectionMode = SelectionMode.One;
            //this.checkedListBox1.Visible = false;
            //this.checkedListBox1.CheckOnClick = true;
            //this.checkedListBox1.FormattingEnabled = true;
            //this.checkedListBox1.ColumnWidth = 15;
            //this.Controls.Remove(checkedListBox1);
            //this.DGVfreeze.Controls.Add(checkedListBox1);
            //this.DGVfreeze.CellBeginEdit += new DataGridViewCellCancelEventHandler(dataGridView1_CellBeginEdit);
            //this.DGVfreeze.CellEndEdit += new DataGridViewCellEventHandler(dataGridView1_CellEndEdit);
            //this.DGVfreeze.Scroll += new ScrollEventHandler(dataGridView1_Scroll);
        }
        private void LoadMaintenaceData()
        {
            try
            {
                // DGVfreeze.DataSource = loaddata();
                // BindDyNamicClm();               
                DataTable dt = null;
                //int ReceiveCount = Resources.Instance.CheckCAPADATA("Sp_CheckFreezePlanRecord", "@count");
                // if (ReceiveCount > 0)
                // {
                //     dt = Resources.Instance.GetDataKey("Sp_FetchFreeZPlanU1Data", "@userId", "@username", "@empcode",
                //         GlobalDeclaration._holdInfo[0].UserId.ToString(), GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].EmpCode);
                // }
                //else
                // {
                dt = Resources.Instance.GetDataKey("SP_FetchMaintenaceU1");
                // }
                if (dt == null) return;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        DGVfreeze.Rows.Add(dr);
                        int rowidex = this.DGVfreeze.Rows.Count - 1;
                        //DGVfreeze.Rows[rowidex].Cells["Priority"].Value = dt.Rows[i]["Priority"].ToString();
                        DGVfreeze.Rows[rowidex].Cells["MachineTag"].Value = dt.Rows[i]["MachineTag"].ToString();
                        DGVfreeze.Rows[rowidex].Cells["MachineName"].Value = dt.Rows[i]["MachineName"].ToString();
                        DGVfreeze.Rows[rowidex].Cells["Freequency"].Value = dt.Rows[i]["Frequency"].ToString();
                        DGVfreeze.Rows[rowidex].Cells["ShtdwnReq"].Value = dt.Rows[i]["ShtdwnReq"].ToString();
                        DGVfreeze.Rows[rowidex].Cells["Resource"].Value = dt.Rows[i]["Resource"].ToString();
                        DGVfreeze.Rows[rowidex].Cells["UnitsName"].Value = dt.Rows[i]["UnitsName"].ToString();
                        DGVfreeze.Rows[rowidex].Cells["MType"].Value = "PM";
                        DGVfreeze.Rows[rowidex].Cells["MReading"].Value = dt.Rows[i]["MeterReading"].ToString();
                        DGVfreeze.Rows[rowidex].Cells["AdditonalManpower"].Value = dt.Rows[i]["Team"].ToString();
                        DGVfreeze.Rows[rowidex].Cells["ActivityDetails"].Value = dt.Rows[i]["AdditonalManpower"].ToString();
                        DGVfreeze.Rows[rowidex].Cells["MaintScheduled"].Value = dt.Rows[i]["MaintenenceSchudule"].ToString();
                        //if (dt.Rows[i]["MaintenanceType"].ToString() == "Blank" || dt.Rows[i]["MaintenenceSchudule"].ToString() == "Blank" || dt.Rows[i]["Setdate"].ToString() == "") continue;
                        //DGVfreeze.Rows[rowidex].Cells["MaintScheduled"].Value = dt.Rows[i]["MaintenenceSchudule"].ToString();
                        //DGVfreeze.Rows[rowidex].Cells["DateTime"].Value = dt.Rows[i]["Setdate"].ToString();
                        //DGVfreeze.Rows[rowidex].Cells["Team"].Value = dt.Rows[i]["Fteam"].ToString();
                        //DGVfreeze.Rows[rowidex].Cells["AdditonalManpower"].Value = dt.Rows[i]["AdditonalManpower1"].ToString();
                        //DGVfreeze.Rows[rowidex].Cells["Priority"].Value = dt.Rows[i]["PriorityUp"];
                        //DataGridViewButtonCell dgbtn = null;
                        //dgbtn = (DataGridViewButtonCell)(DGVfreeze.Rows[i].Cells["btnClickMe"]);
                        //if (dgbtn.Value.ToString() == "Click FreezeData")
                        //{
                        //    dgbtn.UseColumnTextForButtonValue = true;
                        //    dgbtn.UseColumnTextForButtonValue = false;
                        //    dgbtn.Value = dt.Rows[i]["FreezStatus"].ToString();                           
                        //    DGVfreeze.Rows[rowidex].Cells["Priority"].ReadOnly = false;
                        //    DGVfreeze.Rows[rowidex].Cells["AdditonalManpower"].ReadOnly = true;
                        //    DGVfreeze.Rows[rowidex].Cells["MaintScheduled"].ReadOnly = true;
                        //    DGVfreeze.Rows[rowidex].Cells["Priority"].ReadOnly = true;
                        //}
                    }
                    //AddDynamicRow();
                    readOluGrid(null);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void readOluGrid(object obj)
        {
            if (obj == null)
            {
                DGVfreeze.Columns["MType"].ReadOnly = true;
                DGVfreeze.Columns["MReading"].ReadOnly = true;
                DGVfreeze.Columns["MachineTag"].ReadOnly = true;
                DGVfreeze.Columns["MachineName"].ReadOnly = true;
                DGVfreeze.Columns["Freequency"].ReadOnly = true;
                DGVfreeze.Columns["ShtdwnReq"].ReadOnly = true;
                DGVfreeze.Columns["Resource"].ReadOnly = true;
                DGVfreeze.Columns["AdditonalManpower"].ReadOnly = true;

                #region this is for when dataGridview Alrdy Filled in thase Unit Field will be unediatable(28-11-2022)
                addDataToolStripMenuItem.Enabled = false;
                deleteDataToolStripMenuItem.Enabled = false;
                DGVfreeze.Columns["UnitsName"].ReadOnly = true; ; 
                #endregion
            }
            else
            {
                UploadCL = obj.ToString();
                DGVfreeze.Columns["MType"].ReadOnly = false;
                DGVfreeze.Columns["MReading"].ReadOnly = false;
                DGVfreeze.Columns["MachineTag"].ReadOnly = false;
                DGVfreeze.Columns["MachineName"].ReadOnly = false;
                DGVfreeze.Columns["Freequency"].ReadOnly = false;
                DGVfreeze.Columns["ShtdwnReq"].ReadOnly = false;
                DGVfreeze.Columns["Resource"].ReadOnly = false;
                DGVfreeze.Columns["AdditonalManpower"].ReadOnly = false;
                

            }
        }

        private void AddDynamicRow(int Index)
        {
            try
            {
                int weekNum = 0;
                string Frqncy = string.Empty;

                DateTime dt = Convert.ToDateTime(DGVfreeze.Rows[Index].Cells["DateTime"].Value);
                Frqncy = DGVfreeze.Rows[Index].Cells["Freequency"].Value.ToString();
                if (dt != null && dt != default(DateTime))
                {
                    string weenumner = Weeknumber(Frqncy, dt);
                    DataGridViewRow dr = new DataGridViewRow();
                    DGVfreeze.Rows.Add(dr);
                    int rowidex = this.DGVfreeze.Rows.Count - 1;
                    DGVfreeze.Rows[rowidex].Cells["Priority"].Value = DGVfreeze.Rows[Index].Cells["Priority"].Value.ToString();
                    DGVfreeze.Rows[rowidex].Cells["MachineTag"].Value = DGVfreeze.Rows[Index].Cells["MachineTag"].Value.ToString();
                    DGVfreeze.Rows[rowidex].Cells["MachineName"].Value = DGVfreeze.Rows[Index].Cells["MachineName"].Value.ToString();
                    DGVfreeze.Rows[rowidex].Cells["Freequency"].Value = DGVfreeze.Rows[Index].Cells["Freequency"].Value.ToString();
                    DGVfreeze.Rows[rowidex].Cells["ShtdwnReq"].Value = DGVfreeze.Rows[Index].Cells["ShtdwnReq"].Value.ToString();
                    DGVfreeze.Rows[rowidex].Cells["Resource"].Value = DGVfreeze.Rows[Index].Cells["Resource"].Value.ToString();
                    DGVfreeze.Rows[rowidex].Cells["UnitsName"].Value = DGVfreeze.Rows[Index].Cells["UnitsName"].Value.ToString();
                    DGVfreeze.Rows[rowidex].Cells["MType"].Value = DGVfreeze.Rows[Index].Cells["MType"].Value.ToString();
                    DGVfreeze.Rows[rowidex].Cells["MReading"].Value = DGVfreeze.Rows[Index].Cells["MReading"].Value.ToString();
                    DGVfreeze.Rows[rowidex].Cells["AdditonalManpower"].Value = DGVfreeze.Rows[Index].Cells["AdditonalManpower"].Value.ToString();
                    DGVfreeze.Rows[rowidex].Cells["ActivityDetails"].Value = DGVfreeze.Rows[Index].Cells["ActivityDetails"].Value.ToString();
                    DGVfreeze.Rows[rowidex].Cells["MaintScheduled"].Value = weenumner;
                    //DataGridViewButtonCell dgbtn = null;
                    //dgbtn = (DataGridViewButtonCell)(DGVfreeze.Rows[rowidex].Cells["btnClickMe"]);                       
                    DGVfreeze.Rows[rowidex].DefaultCellStyle.ForeColor = Color.SeaGreen;
                    ColumnVisible(false);
                    string value = DGVfreeze.SelectedRows[0].Cells["MachineTag"].Value.ToString() + "~" + DGVfreeze.SelectedRows[0].Cells["MachineName"].Value.ToString() + "~"
                               + DGVfreeze.SelectedRows[0].Cells["ActivityDetails"].Value.ToString() + "~" + DateTime.Now + "~" + GlobalDeclaration._holdInfo[0].UserId + "~" +
                               GlobalDeclaration._holdInfo[0].UserName + "~" + GlobalDeclaration._holdInfo[0].EmpCode + "~" + "Freezes" + "~" + weenumner;
                    int Status = Resources.Instance.UpdateFreezPlan("Sp_UpdateFreezPlan", value);// Resources.Instance.InsertFreeZplan(value, "Sp_InsertFreePlan");

                }



            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        public string Weeknumber(string Frq, DateTime dt)
        {
            int weekNum = 0;
            string Vaue = string.Empty;
            try
            {
                CultureInfo ciCurr = CultureInfo.CurrentCulture;
                DateTime getdt = DateTime.Now;
                switch (Frq)
                {
                    case "Daily":
                        getdt = dt.AddDays(1);
                        weekNum = getdt.Day;
                        Vaue = weekNum + "Days";
                        break;
                    case "Weekly":
                        getdt = dt.AddDays(7);
                        weekNum = (int)(getdt).DayOfWeek;
                        Vaue = weekNum + "Week";
                        break;
                    case "Month":
                    case "Monthly":
                    case "Months":
                        getdt = dt.AddMonths(1);
                        weekNum = ciCurr.Calendar.GetWeekOfYear(getdt, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
                        Vaue = weekNum + "Week";
                        break;
                    case "Quarterly":
                        getdt = dt.AddMonths(3);
                        weekNum = ciCurr.Calendar.GetWeekOfYear(getdt, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
                        Vaue = weekNum + "Week";
                        break;
                    case "Half Yearly":
                        getdt = dt.AddMonths(6);
                        weekNum = ciCurr.Calendar.GetWeekOfYear(getdt, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
                        Vaue = weekNum + "Week";
                        break;
                    case "Year":
                        getdt = new DateTime(dt.Year, 12, 31);
                        weekNum = ciCurr.Calendar.GetWeekOfYear(getdt, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
                        Vaue = weekNum + "Week";
                        break;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Vaue;
        }
        List<string> _SheetName = new List<string>();
        private void MultiselectionAdditinalMan()
        {
            try
            {
                this.checkedListBox1.Items.Add("Not Required");
                for (int i = 0; i < Resources.Instance._EmpName.Rows.Count; i++)
                {
                    this.checkedListBox1.Items.Add(Resources.Instance._EmpName.Rows[i]["emp_name"]);
                }
                this.checkedListBox1.SelectionMode = SelectionMode.One;
                this.checkedListBox1.Visible = false;
                this.checkedListBox1.CheckOnClick = true;
                this.checkedListBox1.FormattingEnabled = true;
                this.checkedListBox1.ColumnWidth = 90;
                this.Controls.Remove(checkedListBox1);
                this.DGVfreeze.Controls.Add(checkedListBox1);
                this.DGVfreeze.CellBeginEdit += new DataGridViewCellCancelEventHandler(dataGridView1_CellBeginEdit);
                this.DGVfreeze.CellEndEdit += new DataGridViewCellEventHandler(dataGridView1_CellEndEdit);
                this.DGVfreeze.Scroll += new ScrollEventHandler(dataGridView1_Scroll);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (DGVfreeze.Columns[e.ColumnIndex].Name == "AdditonalManpower" || DGVfreeze.Columns[e.ColumnIndex].Name == "Team")
                {

                    //if (DGVfreeze.Rows[e.RowIndex].Cells["btnClickMe"].Value.ToString() == "Freezed") return;
                    Rectangle rec = this.DGVfreeze.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    checkedListBox1.Location = rec.Location;
                    checkedListBox1.Width = rec.Width;
                    checkedListBox1.Height = this.DGVfreeze.Height / 2;
                    for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
                    {
                        this.checkedListBox1.SetItemChecked(i, false);
                    }
                    checkedListBox1.Visible = true;
                }
                checkedListBox1.Visible = true;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DGVfreeze.Columns[e.ColumnIndex].Name == "AdditonalManpower" || DGVfreeze.Columns[e.ColumnIndex].Name == "Team")
                {
                    string SelectName = string.Empty;
                    var item = checkedListBox1.CheckedItems;
                    if (item.Count == 0)
                    {
                        if (this.checkedListBox1.Visible)
                            this.checkedListBox1.Visible = false;
                        return;
                    }
                    for (int i = 0; i < item.Count; i++)
                    {
                        SelectName = SelectName + item[i].ToString() + ",";//item[i].ToString();
                    }
                    SelectName = SelectName.Remove(SelectName.TrimEnd().Length - 1, 1);
                    if (!string.IsNullOrEmpty(SelectName))
                    {
                        this.DGVfreeze.CurrentCell.Value = SelectName;
                        //this.DgvMaitenance.Columns["MachineTag"].ReadOnly = true;
                        this.checkedListBox1.Visible = false;
                    }
                }
                this.checkedListBox1.Visible = false;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (DGVfreeze.Rows.Count > 0)
                {
                    if (DGVfreeze.CurrentCell == null) return;
                    if (DGVfreeze.Columns[DGVfreeze.CurrentCell.ColumnIndex].Name == "AdditonalManpower" || DGVfreeze.Columns[DGVfreeze.CurrentCell.ColumnIndex].Name == "Team")
                    {
                        if (checkedListBox1.Visible == true)
                        {
                            Rectangle rec = this.DGVfreeze.GetCellDisplayRectangle(this.DGVfreeze.CurrentCell.ColumnIndex, this.DGVfreeze.CurrentCell.RowIndex, true);
                            checkedListBox1.Location = rec.Location;
                            checkedListBox1.Width = rec.Width;
                            checkedListBox1.Height = DGVfreeze.Height / 2;
                        }

                    }
                    checkedListBox1.Visible = false;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void UploadEventFire(object sender, DataSet ds)
        {
            try
            {
                if (!_SheetName.Contains(sender.ToString()))
                {
                    readOluGrid(sender);
                    if (DGVfreeze.Columns.Count <= 0)
                    {
                        for (int b = 0; b < ds.Tables[sender.ToString()].Columns.Count; b++)
                        {
                            DataGridViewColumn dgc = new DataGridViewColumn();
                            dgc.HeaderText = ds.Tables[sender.ToString()].Columns[b].ColumnName;
                            DGVfreeze.Columns.Add(dgc);
                        }
                    }
                    for (int i = 0; i < ds.Tables[sender.ToString()].Rows.Count; i++)
                    {
                        DataRow row = ds.Tables[sender.ToString()].Rows[i];
                        DataGridViewRow dr = new DataGridViewRow();
                        DGVfreeze.Rows.Add(dr);
                        int rowidex = this.DGVfreeze.Rows.Count - 1;
                        DGVfreeze.Rows[rowidex].Cells["Priority"].Value = row["Priority"].ToString();
                        //DGVfreeze.Rows[rowidex].Cells["MachineTag"].Value = row["Machine Tag"].ToString();
                        DGVfreeze.Rows[rowidex].Cells["MachineName"].Value = row["Machine Name"].ToString();
                        DGVfreeze.Rows[rowidex].Cells["Freequency"].Value = row["Frequency"].ToString();
                        DGVfreeze.Rows[rowidex].Cells["ShtdwnReq"].Value = row["Shut Down Required"].ToString();
                        DGVfreeze.Rows[rowidex].Cells["Resource"].Value = row["Resource"].ToString();
                        DGVfreeze.Rows[rowidex].Cells["UnitsName"].Value = row["Units Name"].ToString();
                        DGVfreeze.Rows[rowidex].Cells["MType"].Value = "PM";
                        DGVfreeze.Rows[rowidex].Cells["MaintScheduled"].Value = row["Maintenance Scheduled In Week"].ToString();
                        DGVfreeze.Rows[rowidex].Cells["ActivityDetails"].Value = row["Activity Details"].ToString();
                        DGVfreeze.Rows[rowidex].Cells["MReading"].Value = row["Meter Reading"].ToString();
                        // DGVfreeze.Rows.Add(dr);
                    }
                    ColumnVisible(false);
                    if (ds.Tables[sender.ToString()].Rows.Count > 0)
                        _SheetName.Add(sender.ToString());

                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Can't Upload Same Sheet Data, Plese try Another?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // }) ;                   
                // thread.Start();
                //else
                //{
                //    DGVfreeze.DataSource = ds.Tables[sender.ToString()];
                //    BindDyNamicClm();
                //}
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVfreeze_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 15 && DGVfreeze.CurrentCell is DataGridViewButtonCell)
                {
                    string MachineTag = DGVfreeze.Rows[e.RowIndex].Cells["MachineTag"].Value.ToString();
                    InventoryAddDetails invt = new InventoryAddDetails(MachineTag);
                    invt.TopMost = true;
                    if (invt.ShowDialog() == DialogResult.OK)
                    {
                        string ItemNam = invt.ItemName;
                        string UnitName = invt.UnitName;
                    }
                }
                if (this.checkedListBox1.Visible)
                    this.checkedListBox1.Visible = false;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (int.Parse(((ToolStripMenuItem)sender).Tag.ToString()))
            {
                case 0:
                    {
                        //DataGridViewRow rowadd = new DataGridViewRow();
                        //DGVfreeze.Rows.Insert(0, rowadd);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void DGVfreeze_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    switch (DGVfreeze.Columns[e.ColumnIndex].Name)
                    {
                        case "btnClickMe":
                            {

                                int index = e.RowIndex;
                                DGVfreeze.Rows[index].Selected = true;
                                int rowscount = DGVfreeze.SelectedRows.Count;
                                //foreach (DataGridViewRow rw in this.DGVfreeze.SelectedRows[0])
                                //{
                                //    for (int i = 0; i < rw.Cells.Count; i++)
                                //    {
                                //        if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                                //        {
                                //            XtraMessageBox.Show(new Form { TopMost = true }, "Please Fill All Details First.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //            return;
                                //        }
                                //    }
                                //}
                                DataGridViewButtonCell dgbtn = null;
                                dgbtn = (DataGridViewButtonCell)(DGVfreeze.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                                if (dgbtn.Value.ToString() == "Click FreezeData")
                                {
                                    dgbtn.UseColumnTextForButtonValue = true;
                                    DGVfreeze.CurrentCell = DGVfreeze.Rows[e.RowIndex].Cells[e.ColumnIndex];
                                    DGVfreeze.CurrentCell.ReadOnly = false;
                                    dgbtn.UseColumnTextForButtonValue = false;
                                    dgbtn.Value = "Freezed";
                                    IsRowEdit = true;
                                    DGVfreeze.CurrentCell.ReadOnly = true;
                                    ColumnVisible(true);
                                    DGVfreeze.Rows[e.RowIndex].Cells["MaintScheduled"].ReadOnly = true;
                                    DGVfreeze.Rows[e.RowIndex].Cells["AdditonalManpower"].ReadOnly = true;
                                }
                                break;
                            }
                        case "Datetime":
                            {
                                if (DGVfreeze.Rows[e.RowIndex].Cells["btnClickMe"].Value.ToString() == "Freezed")
                                {
                                    LastDateTimePicker = new DateTimePicker();  //DateTimePicker 

                                    //Adding DateTimePicker control into DataGridView
                                    DGVfreeze.Controls.Add(LastDateTimePicker);

                                    // Intially made it invisible
                                    LastDateTimePicker.Visible = false;

                                    // Setting the format (i.e. 2014-10-10)
                                    LastDateTimePicker.Format = DateTimePickerFormat.Custom;  //
                                    LastDateTimePicker.CustomFormat = "yyyy-MM-dd";

                                    LastDateTimePicker.TextChanged += new EventHandler(Set_date_TextChangedEvnts);

                                    // Now make it visible
                                    LastDateTimePicker.Visible = true;

                                    // It returns the retangular area that represents the Display area for a cell
                                    Rectangle oRectangle = DGVfreeze.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                                    //Setting area for DateTimePicker Control
                                    LastDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

                                    // Setting Location
                                    LastDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);

                                    LastDateTimePicker.CloseUp += new EventHandler(DateTimePickerClose);
                                }
                                break;
                            }
                        case "MachineName":
                            {
                                //DataTable dt = Resources.Instance.GetDataKey("Sp_GetInformation", "@machineName", this.DGVfreeze.CurrentCell.Value.ToString());

                            }
                            break;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ColumnVisible(bool Sts)
        {
            if (Sts)
            {
                DGVfreeze.Columns["Datetime"].Visible = true;
                DGVfreeze.Columns["Team"].Visible = true;
                DGVfreeze.Columns["btnInvent"].Visible = true;
            }
            else
            {
                DGVfreeze.Columns["Datetime"].Visible = false;
                DGVfreeze.Columns["Team"].Visible = false;
                DGVfreeze.Columns["btnInvent"].Visible = false;
            }

        }
        private void Set_date_TextChangedEvnts(object sender, EventArgs e)
        {
            try
            {
                DGVfreeze.CurrentCell.Value = LastDateTimePicker.Text.ToString();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DGVfreeze_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // this.DGVfreeze.ReadOnly = true;
                // IsRowEdit = false;
                //if (invetory != null && SetDate != null && AddTeam != null)
                //{
                //    //if (e.ColumnIndex == DGVfreeze.Columns[e.ColumnIndex].Index)
                //    //{
                //    //    SetDate.Visible = false;
                //    //}
                //    AddTeam.Visible = false;
                //    invetory.Visible = false;
                //}
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkstr(string yourstring)
        {
            int t = 3;
            string fff = "fhljyromncbaslsp";
            char[] a = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            while (t > 0)
            {
                char[] s = fff.ToCharArray();
                int count = 0;
                Array.Sort(s);
                for (int i = 0; i < 26; i++)
                {
                    for (int j = 0; j < s.Length; j++)
                    {
                        if (a[i] == s[j])
                        {
                            count++;
                            break;
                        }
                    }
                }
                if (count == 26)
                {
                    MessageBox.Show("Yes");
                }
                else
                {
                    MessageBox.Show("No");
                }
                t--;
            }
        }


        private void DGVfreeze_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (DGVfreeze.Rows[e.RowIndex].Cells["Priority"].Value == null) return;
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                if (DGVfreeze.Rows[e.RowIndex].Cells["Priority"].Value.ToString() == "High")
                {
                    style.BackColor = Color.Red;
                    //style.ForeColor = Color.Red;
                }
                else if (DGVfreeze.Rows[e.RowIndex].Cells["Priority"].Value.ToString() == "Low")
                {
                    style.BackColor = Color.Blue;

                    //style.ForeColor = Color.Blue;
                }
                else if (DGVfreeze.Rows[e.RowIndex].Cells["Priority"].Value.ToString() == "Urgent")
                {
                    style.BackColor = Color.Green;
                    //style.ForeColor = Color.Green;
                }
                else if (DGVfreeze.Rows[e.RowIndex].Cells["Priority"].Value.ToString() == "Medium")
                {
                    style.BackColor = Color.DarkBlue;
                    //style.ForeColor = Color.DarkBlue;

                }
                else if (DGVfreeze.Rows[e.RowIndex].Cells["Priority"].Value.ToString() == "Non essential")
                {
                    style.BackColor = Color.Black;
                    // style.ForeColor = Color.Black;
                }
                DGVfreeze.Rows[e.RowIndex].Cells["Priority"].Style = style;

                if (DGVfreeze.Rows[e.RowIndex].Cells["btnClickMe"].Value == null) return;
                if (DGVfreeze.Rows[e.RowIndex].Cells["btnClickMe"].Value.ToString() == "Freezed" && DGVfreeze.Rows[e.RowIndex].Cells["DateTime"].Value != null)
                {
                    //style.ForeColor = Color.Green;
                    DGVfreeze.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVfreeze_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DGVfreeze.Rows[e.RowIndex].Cells["btnClickMe"].Value == null) return;
                if (DGVfreeze.Rows[e.RowIndex].Cells["btnClickMe"].Value.ToString() == "Freezed") return;
                SetComboBoxCellType objChangeCellType = new SetComboBoxCellType(ChangeCellToComboBox);
                if (e.ColumnIndex == this.DGVfreeze.Columns["Priority"].Index)
                {
                    if (DGVfreeze.Rows[e.RowIndex].Cells["btnClickMe"].Value.ToString() == "Click FreezeData")
                    {
                        if (DGVfreeze.Rows[e.RowIndex].Cells["Priority"].Value != null) return;
                        this.DGVfreeze.BeginInvoke(objChangeCellType, e.RowIndex, "Prioty");
                        bIsComboBox = false;
                    }
                }
                else if (e.ColumnIndex == this.DGVfreeze.Columns["UnitsName"].Index)
                {
                    if (DGVfreeze.Rows[e.RowIndex].Cells["btnClickMe"].Value.ToString() == "Click FreezeData")
                    {
                        if (DGVfreeze.Rows[e.RowIndex].Cells["UnitsName"].Value != null) return;
                        this.DGVfreeze.BeginInvoke(objChangeCellType, e.RowIndex, "Unit");
                        bIsComboBox = false;
                    }
                }
                else if (e.ColumnIndex == this.DGVfreeze.Columns["Resource"].Index)
                {

                    this.DGVfreeze.BeginInvoke(objChangeCellType, e.RowIndex, "Resource");
                    bIsComboBox = false;

                }
                else if (e.ColumnIndex == this.DGVfreeze.Columns["MachineTag"].Index)
                {
                    if (DGVfreeze.Rows[e.RowIndex].Cells["btnClickMe"].Value.ToString() == "Click FreezeData")
                    {
                        if (DGVfreeze.Rows[e.RowIndex].Cells["MachineTag"].Value != null) return;
                        this.DGVfreeze.BeginInvoke(objChangeCellType, e.RowIndex, "MachineTag");
                        bIsComboBox = false;
                    }
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ChangeCellToComboBox(int iRowIndex, string ColumnName)
        {
            try
            {
                if (bIsComboBox == false)
                {
                    if (ColumnName == "Prioty")
                    {
                        //if (DGVfreeze.Rows[iRowIndex].Cells[DGVfreeze.CurrentCell.ColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgComboCellPrioty = new DataGridViewComboBoxCell();
                        dgComboCellPrioty.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgComboCellPrioty.ReadOnly = false;
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Name", typeof(string));
                        string[] ArrayList = { "Urgent", "High", "Medium", "Low", "Non essential" };
                        for (int i = 0; i < ArrayList.Length; i++)
                        {
                            DataRow dr = dt.NewRow();
                            dr["Name"] = ArrayList[i].ToString();
                            dt.Rows.Add(dr);
                        }
                        dgComboCellPrioty.DataSource = dt;
                        dgComboCellPrioty.ValueMember = "Name";
                        dgComboCellPrioty.DisplayMember = "Name";
                        DGVfreeze.Rows[iRowIndex].Cells[DGVfreeze.CurrentCell.ColumnIndex] = dgComboCellPrioty;
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "Unit")
                    {
                        //if (DGVfreeze.Rows[iRowIndex].Cells[DGVfreeze.CurrentCell.ColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell _units = new DataGridViewComboBoxCell();
                        _units.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        _units.DataSource = Resources.Instance._UnitMaster.Copy();
                        _units.ValueMember = "UnitName";
                        _units.DisplayMember = "UnitName";
                        DGVfreeze.Rows[iRowIndex].Cells[DGVfreeze.CurrentCell.ColumnIndex] = _units;
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "MachineTag")
                    {
                        //foreach (var item in GlobalDeclaration._MyTagDictinary)
                        //{
                        //    string MachineTag = item.Value;
                        //    this.checkedListBox1.Items.Add(MachineTag);
                        //}
                        DataGridViewComboBoxCell dgComboCellPrioty = new DataGridViewComboBoxCell();
                        dgComboCellPrioty.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgComboCellPrioty.ReadOnly = false;
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Name", typeof(string));
                        foreach (var item in GlobalDeclaration._MyTagDictinary)
                        {
                            string MachineTag = item.Value;
                            DataRow dr = dt.NewRow();
                            dr["Name"] = MachineTag;
                            dt.Rows.Add(dr);
                        }
                        dgComboCellPrioty.DataSource = dt;
                        dgComboCellPrioty.ValueMember = "Name";
                        dgComboCellPrioty.DisplayMember = "Name";
                        DGVfreeze.Rows[iRowIndex].Cells[DGVfreeze.CurrentCell.ColumnIndex] = dgComboCellPrioty;
                        bIsComboBox = true;
                    }
                    if (UploadCL == "Maintenance U1")
                    {
                        if (ColumnName == "Resource")
                        {
                            if (DGVfreeze.Rows[iRowIndex].Cells[DGVfreeze.CurrentCell.ColumnIndex].Value != null) return;
                            DataGridViewComboBoxCell dgvchkbox = new DataGridViewComboBoxCell();
                            dgvchkbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                            DataTable dt = new DataTable();
                            dt.Columns.Add("Name", typeof(string));
                            string[] ArrayList = { "InHouse", "OutSource" };
                            for (int i = 0; i < ArrayList.Length; i++)
                            {
                                DataRow dr = dt.NewRow();
                                dr["Name"] = ArrayList[i].ToString();
                                dt.Rows.Add(dr);
                            }
                            dgvchkbox.DataSource = dt;
                            dgvchkbox.ValueMember = "Name";
                            dgvchkbox.DisplayMember = "Name";
                            DGVfreeze.Rows[iRowIndex].Cells[DGVfreeze.CurrentCell.ColumnIndex] = dgvchkbox;
                            bIsComboBox = true;
                        }
                    }


                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnupdate_Click(object sender, EventArgs e)
        {

            try
            {
                this.TopMost = false;
                if (DGVfreeze.SelectedRows.Count > 0)
                {
                    DataGridViewRow dgvrrows = DGVfreeze.SelectedRows[0];

                    if (dgvrrows != null)
                    {
                        //SetDate.Visible = true;
                        //AddTeam.Visible = true;
                        //invetory.Visible = true;
                        InsertDataInDB();
                    }
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please Select Freezed Row...", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        }

        private DataGridView dataGridView1 = new DataGridView();
        // Creates the columns and loads the data.
        private void PopulateDataGridView()
        {
            // Set the column header names.
            dataGridView1.ColumnCount = 12;
            dataGridView1.Columns[0].Name = "Priority";
            dataGridView1.Columns[1].Name = "MaintenanceType";
            dataGridView1.Columns[2].Name = "MachineTag";
            dataGridView1.Columns[3].Name = "MachineName";
            dataGridView1.Columns[4].Name = "Freequency";
            dataGridView1.Columns[5].Name = "MaintScheduled";
            dataGridView1.Columns[6].Name = "ActivityDetails";
            dataGridView1.Columns[7].Name = "ShtdwnReq";
            dataGridView1.Columns[8].Name = "Resource";
            dataGridView1.Columns[9].Name = "AdditionalManPower";
            dataGridView1.Columns[10].Name = "MeterReading";
            dataGridView1.Columns[11].Name = "UnitsName";
            // Adjust the row heights so that all content is visible.
            dataGridView1.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }


        private void InsertDataInDB()

        {
            try
            {
                if (DGVfreeze.SelectedRows[0].Cells["btnClickMe"].Value.ToString() == "Freezed" && (this.DGVfreeze.SelectedRows[0].DefaultCellStyle.ForeColor != Color.LightGreen || this.DGVfreeze.SelectedRows[0].DefaultCellStyle.ForeColor != Color.Yellow))
                {
                    if (this.DGVfreeze.SelectedRows[0].Cells["AdditonalManpower"].Value == null || this.DGVfreeze.SelectedRows[0].Cells["Team"].Value == null)
                    {
                        this.DGVfreeze.SelectedRows[0].Cells["AdditonalManpower"].Value = "Not Required";
                        this.DGVfreeze.SelectedRows[0].Cells["Team"].Value = "Not Required";
                    }
                    foreach (DataGridViewRow rw in this.DGVfreeze.SelectedRows)
                    {
                        for (int i = 0; i < rw.Cells.Count; i++)
                        {
                            if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                            {
                                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please Fill All  Details First?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                    AuditReportInsertion _audit = new AuditReportInsertion();
                    int Status = _audit.InsertFreeZPlanData(true, this.DGVfreeze);
                    if (Status > 0)
                    {
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Insert Done.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.DGVfreeze.SelectedRows[0].DefaultCellStyle.ForeColor = Color.LightGreen;
                        AddDynamicRow(this.DGVfreeze.SelectedRows[0].Index);
                        this.DGVfreeze.Rows.RemoveAt(this.DGVfreeze.SelectedRows[0].Index);


                    }
                    else
                    {
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Error during Insert.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Information Still not Freezed, Please Freez Data First.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void DGVfreeze_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (LastDateTimePicker != null)
                    LastDateTimePicker.Visible = false;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DateTimePickerClose(object sender, EventArgs e)
        {
            LastDateTimePicker.Visible = false;
        }
        private void DGVfreeze_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (LastDateTimePicker != null)
                    LastDateTimePicker.Visible = false;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVfreeze_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void FreezePlan_FormClosing(object sender, FormClosingEventArgs e)
        {
            // this.Close();
            // this.Dispose();           
        }
    }
}
