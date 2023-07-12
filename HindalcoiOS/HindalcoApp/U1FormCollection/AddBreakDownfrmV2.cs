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
    public partial class AddBreakDownfrm : XtraForm
    {
        delegate void SetComboBoxCellType(int iRowIndex, string clmname);
        bool bIsComboBox = false;
        public bool IsCalling;
        public AddBreakDownfrm()
        {
            InitializeComponent();
            this.Text = "Basic Details";
            UpdateTextPosition();
        }
        int serialNumber = 1;
        private bool IsLoad;

        public bool CallLocation
        {
            get;
            set;
        }
        public string MachineCordibate
        {
            get;
            set;
        }
        private void AddBreakDownfrm_Load(object sender, EventArgs e)
        {
            if (IsCalling)
            {
                ViewData();
                btnsave.Visible = false;
            }
            else
            {
                LoaddataInfo();
            }
            ContextAddBRk.Enabled = true;// this is On by suraj saha
            GridSeeting();
            // checkedListBox1.Visible = false;
            // DgvBrk.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void GridSeeting()
        {
            try
            {
                DgvBrk.BorderStyle = BorderStyle.Fixed3D;
                DgvBrk.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                DgvBrk.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                DgvBrk.AllowUserToResizeColumns = false;

                DgvBrk.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.AutoSize;


                DgvBrk.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;

                // Set the selection background color for all the cells.
                // DgvBrk.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                DgvBrk.DefaultCellStyle.SelectionForeColor = Color.Black;

                // Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default
                // value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
                //DgvStatus.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty;

                // Set the background color for all rows and for alternating rows. 
                // The value for alternating rows overrides the value for all rows. 
                DgvBrk.RowsDefaultCellStyle.BackColor = Color.LightGray;
                DgvBrk.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
                // Dgv Column sorting
                foreach (DataGridViewColumn column in DgvBrk.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
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

        private void ViewData()
        {
            try
            {
                DataTable _dataTable = Resources.Instance.GetDataKey("Sp_FetchViewnMachineInfo", "@userid", "@username", "@empcode",
                                        GlobalDeclaration._holdInfo[0].UserId.ToString(), GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].EmpCode);
                if (_dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < _dataTable.Rows.Count; i++)
                    {
                        DataGridViewRow rowadd = new DataGridViewRow();
                        DgvBrk.Rows.Add(rowadd);
                        int index = DgvBrk.Rows.Count - 1;
                        DgvBrk.Rows[index].Cells["SrNo"].Value = _dataTable.Rows[i]["SrNo"].ToString();
                        DgvBrk.Rows[index].Cells["BreifDesc"].Value = _dataTable.Rows[i]["BriefDesc"].ToString();
                        DgvBrk.Rows[index].Cells["equipmentTag"].Value = _dataTable.Rows[i]["MachineTagNo"].ToString();
                        DgvBrk.Rows[index].Cells["equipmentname"].Value = _dataTable.Rows[i]["MachineName"].ToString();
                        DgvBrk.Rows[index].Cells["Mreading"].Value = _dataTable.Rows[i]["MeterReading"].ToString();
                        DgvBrk.Rows[index].Cells["LDate"].Value = _dataTable.Rows[i]["LastDateOfBrek"];
                        DgvBrk.Rows[index].DefaultCellStyle.ForeColor = Color.Green;
                    }
                    DgvBrk.ReadOnly = true;

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoaddataInfo()
        {
            try
            {
                //Sp_FetchMaintenanceDataLatest
                DataTable _dataTable = Resources.Instance.GetDataKey("Sp_FetchBrkDwnMachineInfo", "@userid", "@username", "@empcode",
                    GlobalDeclaration._holdInfo[0].UserId.ToString(), GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].EmpCode);
                if (_dataTable.Rows.Count > 0)
                {
                    IsLoad = true;
                    //serialNumber = _dataTable.Rows.Count;
                    for (int i = 0; i < _dataTable.Rows.Count; i++)
                    {
                        DataGridViewRow rowadd = new DataGridViewRow();
                        DgvBrk.Rows.Add(rowadd);
                        int index = DgvBrk.Rows.Count - 1;
                        DgvBrk.Rows[index].Cells["SrNo"].Value = serialNumber++;//_dataTable.Rows[i]["SrNo"].ToString();
                        DgvBrk.Rows[index].Cells["BreifDesc"].Value = _dataTable.Rows[i]["BriefDesc"].ToString();
                        DgvBrk.Rows[index].Cells["equipmentTag"].Value = _dataTable.Rows[i]["MachineTagNo"].ToString();
                        DgvBrk.Rows[index].Cells["equipmentname"].Value = _dataTable.Rows[i]["MachineName"].ToString();
                        DgvBrk.Rows[index].Cells["Mreading"].Value = _dataTable.Rows[i]["MeterReading"].ToString();
                        if (string.IsNullOrEmpty(_dataTable.Rows[i]["LastDateOfBrek"].ToString()))
                        {
                            DgvBrk.Rows[index].Cells["LDate"].Value = "NA";
                            DgvBrk.Rows[index].DefaultCellStyle.ForeColor = Color.Red;
                        }
                        else
                        {
                            DgvBrk.Rows[index].Cells["LDate"].Value = _dataTable.Rows[i]["LastDateOfBrek"].ToString();
                            DgvBrk.Rows[index].DefaultCellStyle.ForeColor = Color.Green;
                        }
                        DgvBrk.Rows[index].Cells["BreifDesc"].ReadOnly = true;
                        DgvBrk.Rows[index].Cells["EquipmentTag"].ReadOnly = true;
                        DgvBrk.Rows[index].Cells["equipmentname"].ReadOnly = true;
                        DgvBrk.Rows[index].Cells["LDate"].ReadOnly = true;
                        DgvBrk.Rows[index].Cells["Mreading"].ReadOnly = true;
                    }
                    IsLoad = true;
                }
                ReadavleColum();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        DataTable MachineDt = null;
        public void ReadavleColum()
        {
            try
            {

                MachineDt = Resources.Instance.GetDataKey("Sp_Loadachines");

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void addDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                switch (int.Parse(((ToolStripMenuItem)sender).Tag.ToString()))
                {
                    case 0:
                        {
                            DataGridViewRow rowadd = new DataGridViewRow();
                            DgvBrk.Rows.Add(rowadd);
                            int index = DgvBrk.Rows.Count - 1;
                            DgvBrk.Rows[index].Cells["SrNo"].Value = serialNumber++;
                            // DgvBrk.Rows[index].Cells["LDate"].Value = DateTime.Now;
                            DgvBrk.Rows[index].Cells["LDate"].ReadOnly = true;
                            IsLoad = false;
                            DgvBrk.Rows[index].DefaultCellStyle.ForeColor = Color.Red;
                            break;
                        }
                    case 1:
                        {
                            if (DgvBrk.Rows.Count > 0)
                            {
                                DgvBrk.Rows.RemoveAt(DgvBrk.SelectedRows[0].Index);
                                serialNumber--;
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
        public void CallingBreakDownEvent()
        {
            try
            {
                if (CallLocation)
                {
                    if (MachineDt != null)
                    {
                        DataRow[] DrRow = MachineDt.Select("Cadlocation='" + MachineCordibate + "'");
                        if (DrRow.Length > 0)
                        {
                            DataGridViewRow rowadd = new DataGridViewRow();
                            DgvBrk.Rows.Add(rowadd);
                            //serialNumber = DgvBrk.Rows.Count;
                            int index = DgvBrk.Rows.Count - 1;
                            string MachineName = DrRow[0]["MachineName"].ToString();
                            this.Text = this.Text + " " + MachineName;
                            string Mtag = DrRow[0]["MachineTagNo"].ToString();
                            DataTable dtime = Resources.Instance.LastDateReturn("sp_GetBrakDownDate", "@MTag", Mtag);
                            DgvBrk.Rows[index].Cells["SrNo"].Value = serialNumber++;
                            DgvBrk.Rows[index].Cells["equipmentname"].Value = MachineName;
                            DgvBrk.Rows[index].Cells["EquipmentTag"].Value = Mtag;
                            DgvBrk.Rows[index].Cells["EquipmentTag"].ReadOnly = true;
                            if (dtime.Rows.Count > 0)
                            {
                                DgvBrk.Rows[index].Cells["LDate"].Value = dtime.Rows[0]["datevalue"];
                                DgvBrk.Rows[index].Cells["LDate"].ReadOnly = true;
                            }
                            else
                            {
                                DgvBrk.Rows[index].Cells["LDate"].Value = "NA";
                            }
                            DgvBrk.Rows[index].DefaultCellStyle.ForeColor = Color.Red;
                            IsLoad = false;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DgvBrk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    DataGridViewCell cell = DgvBrk.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if (e.ColumnIndex == DgvBrk.Columns["BreifDesc"].Index)
                    {

                        cell.ReadOnly = false;
                        DgvBrk.CurrentCell = cell;
                        DgvBrk.BeginEdit(true);

                    }
                    else
                    {
                        //cell.ReadOnly = true;
                        //DgvBrk.CurrentCell = cell;
                        //DgvBrk.BeginEdit(false);
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {

                if (DgvBrk.SelectedRows.Count > 0)
                {
                    string Value = DgvBrk.SelectedRows[0].Cells["BreifDesc"].Value.ToString() + "_" + DgvBrk.SelectedRows[0].Cells["EquipmentTag"].Value.ToString() + "_" +
                                  DgvBrk.SelectedRows[0].Cells["equipmentname"].Value.ToString() + "_" + GlobalDeclaration._holdInfo[0].UserId + "_" + GlobalDeclaration._holdInfo[0].UserName + "_" +
                              GlobalDeclaration._holdInfo[0].EmpCode + "_" + DgvBrk.SelectedRows[0].Cells["Mreading"].Value.ToString();

                    int value = Resources.Instance.AddBreakrecord("Sp_InsertBrkInfor", "@BreifDesc", "@MachineTagNo", "@MName", "@empid", "@empname", "@empcode", "@mReading", Value);
                    if (value > 0)
                    {
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Save Successfully", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DgvBrk.SelectedRows[0].DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Error in Data", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please Select Row First.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvBrk_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                if (DgvBrk.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    SetMachineName(e.ColumnIndex, e.RowIndex);
                }
            }
        }
        private void SetMachineName(int columnIndex, int RowsIndex)
        {
            try
            {
                string deptname = string.Empty;
                string FinalValue = string.Empty;
                if (MachineDt != null)
                {
                    if (!IsLoad)
                    {
                        if (DgvBrk.Rows[RowsIndex].Cells[columnIndex].Value != null)
                        {
                            string receiceValue = DgvBrk.Rows[RowsIndex].Cells[columnIndex].Value.ToString();//trntype                   
                            DataRow[] Updaye = MachineDt.Select("MachineTagNo='" + receiceValue + "'");
                            if (Updaye.Length > 0)
                            {
                                DgvBrk.Rows[RowsIndex].Cells["equipmentname"].Value = Updaye[0]["MachineName"];
                                DataTable dtime = Resources.Instance.LastDateReturn("sp_GetBrakDownDate", "@MTag", receiceValue);
                                if (dtime.Rows.Count > 0)
                                {
                                    DgvBrk.Rows[RowsIndex].Cells["LDate"].Value = dtime.Rows[0]["datevalue"];
                                    DgvBrk.Rows[RowsIndex].Cells["LDate"].ReadOnly = true;
                                }
                                else
                                {
                                    DgvBrk.Rows[RowsIndex].Cells["LDate"].Value = "NA";
                                    DgvBrk.Rows[RowsIndex].Cells["LDate"].ReadOnly = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvBrk_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SetComboBoxCellType objChangeCellType = new SetComboBoxCellType(ChangeCellToComboBox);
                if (e.ColumnIndex == this.DgvBrk.Columns["equipmentTag"].Index)
                {

                    this.DgvBrk.BeginInvoke(objChangeCellType, e.RowIndex, "Eqi");
                    bIsComboBox = false;
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
                    if (ColumnName == "Eqi")
                    {
                        if (DgvBrk.Rows[iRowIndex].Cells[DgvBrk.CurrentCell.ColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgComboCellPrioty = new DataGridViewComboBoxCell();
                        dgComboCellPrioty.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgComboCellPrioty.ReadOnly = false;
                        dgComboCellPrioty.DataSource = MachineDt;
                        dgComboCellPrioty.ValueMember = "MachineTagNo";
                        dgComboCellPrioty.DisplayMember = "MachineTagNo";
                        DgvBrk.Rows[iRowIndex].Cells[DgvBrk.CurrentCell.ColumnIndex] = dgComboCellPrioty;
                        bIsComboBox = true;
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsave_Click_1(object sender, EventArgs e)
        {

        }
    }
}
