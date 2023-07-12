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
    public partial class HrManageFrm : XtraForm
    {
        delegate void SetComboBoxCellType(int iRowIndex, string clmname, int iColumnIndex);
        private bool bIsComboBox;
        // private DataTable EmployeeCode = new DataTable();
        //private DataTable LoadMachineDT = null;
        DateTimePicker Set_Date = new DateTimePicker();
        Rectangle _Rectangle;
        public HrManageFrm()
        {
            InitializeComponent();
            this.Text = "Hr Requested Data Info";
            UpdateTextPosition();
            dataGridView1.Controls.Add(Set_Date);
            Set_Date.Visible = false;
            Set_Date.Format = DateTimePickerFormat.Short;
            Set_Date.TextChanged += new EventHandler(Set_date_TextChangedEvnts);
            Set_Date.CloseUp += new EventHandler(DateTimePickerClose);
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
        private void HrManageFrm_Load(object sender, EventArgs e)
        {
            CreateDynamicClm();
            GridSeeting();
        }
        private void CreateDynamicClm()
        {
            try
            {
                //LoadMachineDT = Resources.Instance.GetDataKey("SP_GetEmployeeName");
                DataTable dt = Resources.Instance.GetDataKey("Sp_FetchRequestedData");//"Sp_FetchRequestedData"
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    DataGridViewTextBoxColumn Freezedate = new DataGridViewTextBoxColumn();
                    Freezedate.Name = "actn";
                    Freezedate.HeaderText = "Action";
                    DataGridViewTextBoxColumn Nameoagcy = new DataGridViewTextBoxColumn();
                    Nameoagcy.Name = "ngcy";
                    Nameoagcy.HeaderText = "NameOfAgency";

                    DataGridViewTextBoxColumn NameofTrainer = new DataGridViewTextBoxColumn();
                    NameofTrainer.Name = "Trainer";
                    NameofTrainer.HeaderText = "NameOfTrainer";

                    DataGridViewTextBoxColumn NameofTrainerCode = new DataGridViewTextBoxColumn();
                    NameofTrainerCode.Name = "TrnCode";
                    NameofTrainerCode.HeaderText = "Trainer Code";
                    dataGridView1.Columns.Insert(12, Freezedate);
                    dataGridView1.Columns.Add(Nameoagcy);
                    dataGridView1.Columns.Add(NameofTrainer);
                    dataGridView1.Columns.Add(NameofTrainerCode);
                    dataGridView1.Columns["ngcy"].Visible = false;
                    dataGridView1.Columns["Trainer"].Visible = false;
                    dataGridView1.Columns["TrnCode"].Visible = false;
                    dataGridView1.Columns["Capability"].Visible = false;
                    dataGridView1.Columns["TrnCode"].ReadOnly = true;
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
                dataGridView1.BorderStyle = BorderStyle.Fixed3D;

                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dataGridView1.AllowUserToResizeColumns = false;

                dataGridView1.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                dataGridView1.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;

                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
                dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray;
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
                dataGridView1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                //dataGridView1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.ReadOnly = true);

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DateTimePickerClose(object sender, EventArgs e)
        {
            Set_Date.Visible = false;
        }
        private void Set_date_TextChangedEvnts(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.CurrentCell.Value = Set_Date.Text.ToString();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGridView1.Columns["Training_Start_date"].Index || e.ColumnIndex == dataGridView1.Columns["Training_Completion_Date"].Index)
                {
                    _Rectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    _Rectangle.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                    _Rectangle.Location = new Point(_Rectangle.X, _Rectangle.Y);
                    Set_Date.Visible = true;
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Columns.Contains("Trainer"))
                {
                    SetComboBoxCellType objChangeCellType = new SetComboBoxCellType(ChangeCellToComboBox);
                    if (e.ColumnIndex == this.dataGridView1.Columns["actn"].Index)
                    {
                        this.dataGridView1.BeginInvoke(objChangeCellType, e.RowIndex, "Action", e.ColumnIndex);
                        bIsComboBox = false;
                    }
                    else if (e.ColumnIndex == this.dataGridView1.Columns["Trainer"].Index)
                    {
                        this.dataGridView1.BeginInvoke(objChangeCellType, e.RowIndex, "Trainer", e.ColumnIndex);
                        bIsComboBox = false;
                    }
                    else if (e.ColumnIndex == this.dataGridView1.Columns["Capability"].Index)
                    {
                        this.dataGridView1.BeginInvoke(objChangeCellType, e.RowIndex, "Capability", e.ColumnIndex);
                        bIsComboBox = false;
                    }
                }
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
                    if (ColumnName == "Action")
                    {
                        DataGridViewComboBoxCell dgComboCellPrioty = new DataGridViewComboBoxCell();
                        dgComboCellPrioty.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Name", typeof(string));
                        string[] ArrayList = { "Accept", "Reject" };
                        for (int i = 0; i < ArrayList.Length; i++)
                        {
                            DataRow dr = dt.NewRow();
                            dr["Name"] = ArrayList[i].ToString();
                            dt.Rows.Add(dr);
                        }
                        dgComboCellPrioty.DataSource = dt;
                        dgComboCellPrioty.ValueMember = "Name";
                        dgComboCellPrioty.DisplayMember = "Name";
                        dataGridView1.Rows[iRowIndex].Cells[dataGridView1.CurrentCell.ColumnIndex] = dgComboCellPrioty;
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "Trainer")
                    {
                        DataGridViewComboBoxCell dgComboCell = new DataGridViewComboBoxCell();
                        dgComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgComboCell.DataSource = Resources.Instance._EmpName;
                        dgComboCell.ValueMember = "emp_name";
                        dgComboCell.DisplayMember = "emp_name";
                        dataGridView1.Rows[iRowIndex].Cells[dataGridView1.CurrentCell.ColumnIndex] = dgComboCell;
                        bIsComboBox = true;
                    }
                    if (ColumnName == "Capability")
                    {
                        DataGridViewComboBoxCell dgComboCellPrioty = new DataGridViewComboBoxCell();
                        dgComboCellPrioty.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Name", typeof(string));
                        string[] ArrayList = { "Internal", "Extrenal" };
                        for (int i = 0; i < ArrayList.Length; i++)
                        {
                            DataRow dr = dt.NewRow();
                            dr["Name"] = ArrayList[i].ToString();
                            dt.Rows.Add(dr);
                        }
                        dgComboCellPrioty.DataSource = dt;
                        dgComboCellPrioty.ValueMember = "Name";
                        dgComboCellPrioty.DisplayMember = "Name";
                        dataGridView1.Rows[iRowIndex].Cells[dataGridView1.CurrentCell.ColumnIndex] = dgComboCellPrioty;
                        bIsComboBox = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dataGridView1.Columns["actn"].Index && e.RowIndex >= 0) //check if combobox column
            {
                AddTrainingTtile(e.ColumnIndex, e.RowIndex);
            }
            else if (e.ColumnIndex == this.dataGridView1.Columns["Capability"].Index && e.RowIndex >= 0)
            {
                Disablecolumn(e.ColumnIndex, e.RowIndex);
            }
            else if (e.ColumnIndex == this.dataGridView1.Columns["Trainer"].Index && e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].Cells["TrnCode"].Value = Resources.Instance.EmployeListTR.Select("emp_name='" + dataGridView1.Rows[e.RowIndex].Cells["Trainer"].Value.ToString().Trim() + "'").FirstOrDefault().ItemArray[1].ToString();
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }
        private void Disablecolumn(int columnIndex, int RowsIndex)
        {
            if (dataGridView1.Rows[RowsIndex].Cells[columnIndex].Value.ToString() == "Internal")
            {
                dataGridView1.Columns["ngcy"].ReadOnly = false;
                dataGridView1.Columns["ngcy"].Visible = false;
            }
            else
            {
                dataGridView1.Columns["ngcy"].ReadOnly = true;
                dataGridView1.Columns["ngcy"].Visible = false;
            }
        }
        private void AddTrainingTtile(int columnIndex, int RowsIndex)
        {
            try
            {
                dataGridView1.Rows[RowsIndex].Cells[columnIndex].Value.ToString();
                if (dataGridView1.Rows[RowsIndex].Cells[columnIndex].Value.ToString() == "Accept")
                {
                    dataGridView1.Columns["ngcy"].Visible = true;
                    dataGridView1.Columns["ngcy"].ReadOnly = true;
                    dataGridView1.Columns["Trainer"].Visible = true;
                    dataGridView1.Columns["TrnCode"].Visible = true; ;
                    dataGridView1.Columns["Capability"].Visible = true;
                }
                else
                {
                    dataGridView1.Columns["ngcy"].Visible = false;
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows[0].Cells["actn"].Value.ToString() == "Accept")
            {
                UpdateDataIntoPlanDB("Sp_UpdatePlannedDataFromRequest");
            }
            DefaultSave();
        }
        private void UpdateDataIntoPlanDB(string Prcname)
        {
            string Value = string.Empty;
            int sts = 0;
            try
            {
                Value = dataGridView1.SelectedRows[0].Cells["EmpName"].Value.ToString() + "_" + dataGridView1.SelectedRows[0].Cells["empid"].Value.ToString() + "_" +
                             dataGridView1.SelectedRows[0].Cells["DepartMent"].Value.ToString() + "_" + dataGridView1.SelectedRows[0].Cells["TrainingTitle"].Value.ToString() + "_" +
                             dataGridView1.SelectedRows[0].Cells["TraingType"].Value.ToString() + "_" +
                             dataGridView1.SelectedRows[0].Cells["Training_Start_date"].Value.ToString() + "_" + dataGridView1.SelectedRows[0].Cells["Training_Completion_Date"].Value.ToString() + "_" +
                             dataGridView1.SelectedRows[0].Cells["actn"].Value.ToString() + "_" + dataGridView1.SelectedRows[0].Cells["Capability"].Value.ToString() + "_" +
                             dataGridView1.SelectedRows[0].Cells["Trainer"].Value.ToString() + "_" + dataGridView1.SelectedRows[0].Cells["Duration"].Value.ToString() + "_" +
                             dataGridView1.SelectedRows[0].Cells["Venue"].Value.ToString() + "_" + dataGridView1.SelectedRows[0].Cells["TrnCode"].Value.ToString();
                sts = Resources.Instance.insertMasterrecord(Prcname, "@empname", "@empId", "@dptname", "@title", "@tytpe", "@strdate", "@enddate", "@action", "@cpblity", "@trnname", "@duration", "@Venue", "@trncode", Value);
                if (sts > 0)
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Approval Send Successfully.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Error", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DefaultSave()
        {
            string Value = string.Empty;
            int sts = 0;
            try
            {
                Value = dataGridView1.SelectedRows[0].Cells["EmpName"].Value.ToString() + "_" + dataGridView1.SelectedRows[0].Cells["empid"].Value.ToString() + "_" +
                             dataGridView1.SelectedRows[0].Cells["DepartMent"].Value.ToString() + "_" + dataGridView1.SelectedRows[0].Cells["TrainingTitle"].Value.ToString() + "_" +
                             dataGridView1.SelectedRows[0].Cells["TraingType"].Value.ToString() + "_" +
                             dataGridView1.SelectedRows[0].Cells["Training_Start_date"].Value.ToString() + "_" + dataGridView1.SelectedRows[0].Cells["Training_Completion_Date"].Value.ToString() + "_" +
                             dataGridView1.SelectedRows[0].Cells["actn"].Value.ToString() + "_" + dataGridView1.SelectedRows[0].Cells["Capability"].Value.ToString() + "_" +
                             dataGridView1.SelectedRows[0].Cells["Trainer"].Value.ToString() + "_" + dataGridView1.SelectedRows[0].Cells["Duration"].Value.ToString() + "_" +
                             dataGridView1.SelectedRows[0].Cells["Venue"].Value.ToString() + "_" + dataGridView1.SelectedRows[0].Cells["TrnCode"].Value.ToString();
                sts = Resources.Instance.insertMasterrecord("Sp_UpdateRequestedData", "@empname", "@empId", "@dptname", "@title", "@tytpe", "@strdate", "@enddate", "@action", "@cpblity", "@trnname", "@duration", "@Venue", "@trncode", Value);
                if (sts > 0)
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Approval Send Successfully.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Error", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
