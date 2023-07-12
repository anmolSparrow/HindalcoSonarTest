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

namespace HindalcoiOS.U1FormCollection
{
    public partial class CloserFrm : XtraForm
    {
        delegate void SetComboBoxCellType(int iRowIndex, string clmname, int iColumnIndex);
        private bool bIsComboBox;
        // private DataTable LoadMachineDT = new DataTable();
        DateTimePicker LastDateTimePicker;
        public bool IsCalling;
        public CloserFrm()
        {
            InitializeComponent();
            this.Text = "Maintenance Closure";
            UpdateTextPosition();
        }
        private void CloserFrm_Load(object sender, EventArgs e)
        {
            if (IsCalling)
            {
                ViewData();

            }
            else
            {
                LoadData();
            }
            GridSeeting();
        }
        private void LoadData()
        {
            // LoadMachineDT = Resources.Instance.GetDataKey("Sp_GetMachineMaster");
            // DgvClosure.DataSource = LoadMachineDT;
            LoadBRkDown();
        }
        public void ViewData()
        {
            try
            {
                DataTable Loaddt = Resources.Instance.GetDataKey("Sp_FetchCloserView", "@userid", "@username", "@empcode", GlobalDeclaration._holdInfo[0].UserId.ToString(),
                       GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].EmpCode);
                if (Loaddt.Rows.Count > 0)
                {
                    for (int i = 0; i < Loaddt.Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        DgvClosure.Rows.Add(dr);
                        int rowidex = this.DgvClosure.Rows.Count - 1;
                        DgvClosure.Rows[rowidex].Cells["MachineTag"].Value = Loaddt.Rows[i]["MachineTag"].ToString();
                        DgvClosure.Rows[rowidex].Cells["MachineName"].Value = Loaddt.Rows[i]["MachineName"].ToString();
                        DgvClosure.Rows[rowidex].Cells["rmark"].Value = Loaddt.Rows[i]["Remark"].ToString();
                        DgvClosure.Rows[rowidex].Cells["actualHr"].Value = Loaddt.Rows[i]["ActualHours"].ToString();
                        DgvClosure.Rows[rowidex].Cells["brkclsure"].Value = Loaddt.Rows[i]["BreakDwnClosure"].ToString();
                        DgvClosure.Rows[rowidex].Cells["reportReview"].Value = Loaddt.Rows[i]["ReportReview"].ToString();
                        DgvClosure.Rows[rowidex].Cells["ReportApprv"].Value = Loaddt.Rows[i]["ReportApprovedBy"].ToString();
                        DgvClosure.Rows[rowidex].Cells["CloseTaskDate"].Value = Loaddt.Rows[i]["CloserDate"];
                        DataGridViewButtonCell dgbtn = null;
                        dgbtn = (DataGridViewButtonCell)(DgvClosure.Rows[i].Cells["task"]);
                        if (dgbtn.Value.ToString() == "Close Task")
                        {
                            dgbtn.UseColumnTextForButtonValue = true;
                            dgbtn.UseColumnTextForButtonValue = false;
                            dgbtn.Value = Loaddt.Rows[i]["Status"].ToString();
                        }
                        DgvClosure.Rows[rowidex].DefaultCellStyle.ForeColor = Color.Green;
                    }
                    DgvClosure.ReadOnly = true;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadBRkDown()
        {
            try
            {
                DataTable Loaddt = Resources.Instance.GetDataKey("Sp_FetchCloserMachineInfo", "@userid", "@username", "@empcode", GlobalDeclaration._holdInfo[0].UserId.ToString(), GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].EmpCode);
                if (Loaddt.Rows.Count > 0)
                {

                    for (int i = 0; i < Loaddt.Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        DgvClosure.Rows.Add(dr);
                        int rowidex = this.DgvClosure.Rows.Count - 1;
                        //if (string.IsNullOrEmpty(Loaddt.Rows[i]["Result"].ToString()))
                        {
                            DgvClosure.Rows[rowidex].Cells["MachineTag"].Value = Loaddt.Rows[i]["MachineTag"].ToString();
                            DgvClosure.Rows[rowidex].Cells["MachineName"].Value = Loaddt.Rows[i]["MachineName"].ToString();
                            DgvClosure.Rows[rowidex].DefaultCellStyle.ForeColor = Color.Red;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GridSeeting()
        {
            try
            {
                DgvClosure.BorderStyle = BorderStyle.Fixed3D;

                DgvClosure.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                DgvClosure.AllowUserToResizeColumns = false;

                DgvClosure.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


                DgvClosure.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;

                DgvClosure.DefaultCellStyle.SelectionForeColor = Color.Black;
                DgvClosure.RowsDefaultCellStyle.BackColor = Color.LightGray;
                DgvClosure.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
                DgvClosure.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateTextPosition()
        {
            try
            {
                Graphics g = this.CreateGraphics();
                Double startingPoint = (this.Width / 4) - (g.MeasureString(this.Text.Trim(), this.Font).Width / 4);
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
        private void DgvClosure_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    if (DgvClosure.Columns[e.ColumnIndex].Name == "task")
                    {
                        DataGridViewButtonCell dgbtn = null;
                        dgbtn = (DataGridViewButtonCell)(DgvClosure.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                        if (dgbtn.Value.ToString() == "Close Task")
                        {
                            dgbtn.UseColumnTextForButtonValue = false;
                            DgvClosure.CurrentCell = DgvClosure.Rows[e.RowIndex].Cells[e.ColumnIndex];
                            DgvClosure.CurrentCell.ReadOnly = false;
                            dgbtn.Value = "Task Completed";
                            DgvClosure.CurrentCell.ReadOnly = true;
                            IsRowAdd = false;
                            DgvClosure.Rows[e.RowIndex].Selected = true;
                            InsertClosureData();// Information Save in DB When Task Completed...........

                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DgvClosure_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (e.RowIndex > -1 && e.ColumnIndex > -1)
                //{
                //    DataGridViewCell cell = DgvClosure.Rows[e.RowIndex].Cells[e.ColumnIndex];
                //    if ((e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4||e.ColumnIndex==5||e.ColumnIndex==6))
                //    {

                //        cell.ReadOnly = false;
                //        DgvClosure.CurrentCell = cell;
                //        DgvClosure.BeginEdit(true);
                //    }
                //    else
                //    {
                //        cell.ReadOnly = true;
                //        DgvClosure.CurrentCell = cell;
                //        DgvClosure.BeginEdit(false);
                //    }

                //}
                if (DgvClosure.Rows.Count > 0)
                {
                    string clmName = string.Empty;
                    if (e.RowIndex > -1 && e.ColumnIndex > -1)
                    {

                        DataGridViewComboBoxCell combo = this.DgvClosure[e.ColumnIndex, e.RowIndex] as DataGridViewComboBoxCell;
                        switch (DgvClosure.Columns[e.ColumnIndex].Name)
                        {
                            case "CloseTaskDate":
                                {
                                    // case "mntCrtDate":
                                    LastDateTimePicker = new DateTimePicker();  //DateTimePicker 

                                    //Adding DateTimePicker control into DataGridView
                                    DgvClosure.Controls.Add(LastDateTimePicker);

                                    // Intially made it invisible
                                    LastDateTimePicker.Visible = false;

                                    // Setting the format (i.e. 2014-10-10)
                                    LastDateTimePicker.Format = DateTimePickerFormat.Custom;  //
                                    LastDateTimePicker.CustomFormat = "yyyy-MM-dd hh:mm:ss";

                                    LastDateTimePicker.TextChanged += new EventHandler(Set_date_TextChangedEvnts);

                                    // Now make it visible
                                    LastDateTimePicker.Visible = true;

                                    // It returns the retangular area that represents the Display area for a cell
                                    Rectangle oRectangle = DgvClosure.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                                    //Setting area for DateTimePicker Control
                                    LastDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

                                    // Setting Location
                                    LastDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);

                                    LastDateTimePicker.CloseUp += new EventHandler(DateTimePickerClose);
                                }
                                break;
                        }
                    }
                }
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
        private void Set_date_TextChangedEvnts(object sender, EventArgs e)
        {
            try
            {
                DgvClosure.CurrentCell.Value = LastDateTimePicker.Text.ToString();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void addTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                switch (int.Parse(((ToolStripMenuItem)sender).Tag.ToString()))
                {
                    case 0:
                        {
                            AddNewRow();
                        }
                        break;
                    case 1:
                        DeleteRow();
                        break;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        bool IsRowAdd;
        private void AddNewRow()
        {
            try
            {
                DataGridViewRow rowadd = new DataGridViewRow();
                DgvClosure.Rows.Insert(0, rowadd);
                IsRowAdd = true;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteRow()
        {
            try
            {
                if (DgvClosure.Rows.Count > 0)
                {
                    if (this.DgvClosure.SelectedRows.Count > 0)
                    {
                        int indes = this.DgvClosure.SelectedRows[0].Index;
                        DgvClosure.Rows.RemoveAt(indes);
                    }
                    else
                    {
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please Select Row First.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DgvClosure_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.A))
            {
                AddNewRow();
            }
            else if (e.KeyData == (Keys.Control | Keys.D) || e.KeyData == Keys.Delete)
            {
                DeleteRow();
            }
        }
        private void DgvClosure_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SetComboBoxCellType objChangeCellType = new SetComboBoxCellType(ChangeCellToComboBox);
                if (e.ColumnIndex == this.DgvClosure.Columns["reportReview"].Index)
                {
                    this.DgvClosure.BeginInvoke(objChangeCellType, e.RowIndex, "RpView", e.ColumnIndex);
                    bIsComboBox = false;

                }
                else if (e.ColumnIndex == this.DgvClosure.Columns["reportApprv"].Index)
                {
                    this.DgvClosure.BeginInvoke(objChangeCellType, e.RowIndex, "rpApp", e.ColumnIndex);
                    bIsComboBox = false;
                }
                //else if (e.ColumnIndex == this.DgvClosure.Columns["MachineName"].Index)
                //{
                //    this.DgvClosure.BeginInvoke(objChangeCellType, e.RowIndex, "machName", e.ColumnIndex);
                //    bIsComboBox = false;
                //}
                //else if (e.ColumnIndex == this.DgvClosure.Columns["MachineTag"].Index)
                //{
                //    this.DgvClosure.BeginInvoke(objChangeCellType, e.RowIndex, "machintag", e.ColumnIndex);
                //    bIsComboBox = false;
                //}
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ChangeCellToComboBox(int iRowIndex, string ColumnName, int iColumnIndex)
        {
            try
            {
                if (bIsComboBox == false)
                {
                    if (ColumnName == "RpView")
                    {
                        if (DgvClosure.Rows[iRowIndex].Cells[DgvClosure.CurrentCell.ColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgComboCell = new DataGridViewComboBoxCell();
                        dgComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgComboCell.DataSource = Resources.Instance._EmpName;
                        dgComboCell.ValueMember = "emp_name";
                        dgComboCell.DisplayMember = "emp_name";
                        DgvClosure.Rows[iRowIndex].Cells[DgvClosure.CurrentCell.ColumnIndex] = dgComboCell;
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "rpApp")
                    {
                        if (DgvClosure.Rows[iRowIndex].Cells[DgvClosure.CurrentCell.ColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgComboCellPrioty = new DataGridViewComboBoxCell();
                        dgComboCellPrioty.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        // dgComboCellPrioty.ReadOnly = false;                        
                        dgComboCellPrioty.DataSource = Resources.Instance._EmpName;
                        dgComboCellPrioty.ValueMember = "emp_name";
                        dgComboCellPrioty.DisplayMember = "emp_name";
                        DgvClosure.Rows[iRowIndex].Cells[DgvClosure.CurrentCell.ColumnIndex] = dgComboCellPrioty;
                        bIsComboBox = true;
                    }
                    //else if (ColumnName == "machName")
                    //{
                    //    if (DgvClosure.Rows[iRowIndex].Cells[DgvClosure.CurrentCell.ColumnIndex].Value != null) return;
                    //    DataGridViewComboBoxCell dgComboCellPrioty = new DataGridViewComboBoxCell();
                    //    dgComboCellPrioty.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                    //    // dgComboCellPrioty.ReadOnly = false;                        
                    //    dgComboCellPrioty.DataSource = LoadMachineDT;
                    //    dgComboCellPrioty.ValueMember = "MachineName";
                    //    dgComboCellPrioty.DisplayMember = "MachineName";
                    //    DgvClosure.Rows[iRowIndex].Cells[DgvClosure.CurrentCell.ColumnIndex] = dgComboCellPrioty;
                    //    bIsComboBox = true;
                    //}
                    //else if (ColumnName == "machintag")
                    //{
                    //    if (DgvClosure.Rows[iRowIndex].Cells[DgvClosure.CurrentCell.ColumnIndex].Value != null) return;
                    //    DataGridViewComboBoxCell dgComboCellPrioty = new DataGridViewComboBoxCell();
                    //    dgComboCellPrioty.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                    //    // dgComboCellPrioty.ReadOnly = false;                        
                    //    dgComboCellPrioty.DataSource = LoadMachineDT.Copy();
                    //    dgComboCellPrioty.ValueMember = "MachineTagNo";
                    //    dgComboCellPrioty.DisplayMember = "MachineTagNo";
                    //    DgvClosure.Rows[iRowIndex].Cells[DgvClosure.CurrentCell.ColumnIndex] = dgComboCellPrioty;
                    //    bIsComboBox = true;
                    //}


                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InsertClosureData()
        {
            try
            {
                if (DgvClosure.SelectedRows[0].Cells["task"].Value.ToString() == "Task Completed")
                {
                    if (DgvClosure.SelectedRows[0].DefaultCellStyle.ForeColor != Color.Green)
                    {
                        string Value = DgvClosure.SelectedRows[0].Cells["rmark"].Value.ToString() + "_" + DgvClosure.SelectedRows[0].Cells["actualHr"].Value.ToString() + "_" +
                                                    DgvClosure.SelectedRows[0].Cells["brkclsure"].Value.ToString() + "_" + DgvClosure.SelectedRows[0].Cells["reportReview"].Value.ToString() + "_" +
                                                    DgvClosure.SelectedRows[0].Cells["ReportApprv"].Value.ToString() + "_" + DgvClosure.SelectedRows[0].Cells["MachineName"].Value.ToString() + "_" +
                                                    DgvClosure.SelectedRows[0].Cells["MachineTag"].Value.ToString() +
                                                    "_" + GlobalDeclaration._holdInfo[0].UserId.ToString() + "_" + GlobalDeclaration._holdInfo[0].UserName + "_" +
                                                    GlobalDeclaration._holdInfo[0].EmpCode + "_" + DgvClosure.SelectedRows[0].Cells["task"].Value.ToString() + "_" + DgvClosure.SelectedRows[0].Cells["CloseTaskDate"].Value;
                        int Satus = Resources.Instance.InsertNearMissGenInfo("Sp_InsertClosureInfo", "@rmark", "@actlHr", "@brkclsure", "@rptRview", "@rptAprv", "@MachineName", "@MachineTag", "@userid", "@username", "@empcode", "@tsksts", "@closerDate", Value);
                        if (Satus > 0)
                        {
                            XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Task Completed and Saved in DB", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DgvClosure.SelectedRows[0].DefaultCellStyle.ForeColor = Color.Green;
                        }
                        else
                        {
                            XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Task Completed but Error during Save", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "selected Row Data Already Updated.? \n  Please try Another row.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please Close Task First.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addTaskToolStripMenuItem(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem(object sender, EventArgs e)
        {

        }
    }
}
