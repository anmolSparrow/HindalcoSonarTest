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
    public partial class PlanningFrm : XtraForm
    {
        delegate void SetComboBoxCellType(int iRowIndex, string clmname, int iColumnIndex);
        private bool bIsComboBox;
        private bool IsRowAdd;
        DateTimePicker LastDateTimePicker;
        Rectangle _Rectangle;
        public bool IsCalling;
        public PlanningFrm()
        {
            InitializeComponent();
            this.Text = "Maintenance Planning";
            UpdateTextPosition();
        }
        private void PlanningFrm_Load(object sender, EventArgs e)
        {
            if (IsCalling)
            {
                ViewData();
                btnSave.Visible = false;
            }
            else
            {
                Loadinfo();
                FetchBrkDownData();
            }
            GridSeeting();
        }
        private void grpPlanning_Enter(object sender, EventArgs e)
        {

        }
        private void GridSeeting()
        {
            try
            {
                DgvPlaning.BorderStyle = BorderStyle.Fixed3D;

                DgvPlaning.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                DgvPlaning.AllowUserToResizeColumns = false;

                DgvPlaning.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                DgvPlaning.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;

                DgvPlaning.DefaultCellStyle.SelectionForeColor = Color.Black;
                DgvPlaning.RowsDefaultCellStyle.BackColor = Color.LightGray;
                DgvPlaning.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
                DgvPlaning.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //DataTable EmployeList = new DataTable();       
        private void Loadinfo()
        {
            // EmployeList = Resources.Instance.GetDataKey("SP_GetEmployeeName");            
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
        public void ViewData()
        {
            try
            {
                DataTable _dataTable = Resources.Instance.GetDataKey("Sp_FetchViewPlaingData", "@userid", "@username", "@empcode",
            GlobalDeclaration._holdInfo[0].UserId.ToString(), GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].EmpCode);
                if (_dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < _dataTable.Rows.Count; i++)
                    {
                        DataGridViewRow rowadd = new DataGridViewRow();
                        DgvPlaning.Rows.Add(rowadd);
                        int index = DgvPlaning.Rows.Count - 1;
                        DgvPlaning.Rows[index].Cells["SrNo"].Value = _dataTable.Rows[i]["SrNo"].ToString();
                        DgvPlaning.Rows[index].Cells["MachineTag"].Value = _dataTable.Rows[i]["MachineTag"].ToString();
                        DgvPlaning.Rows[index].Cells["MachineName"].Value = _dataTable.Rows[i]["MachineName"].ToString();
                        DgvPlaning.Rows[index].Cells["mntCrtDate"].Value = _dataTable.Rows[i]["CloserDate"];
                        DgvPlaning.Rows[index].Cells["Outsource"].Value = _dataTable.Rows[i]["Outsrc"];
                        DgvPlaning.Rows[index].Cells["shqReq"].Value = _dataTable.Rows[i]["ShtDwnReq"];
                        DgvPlaning.Rows[index].Cells["Team"].Value = _dataTable.Rows[i]["EmployeeName"];
                        DgvPlaning.Rows[index].Cells["expcttime"].Value = _dataTable.Rows[i]["ExpctTime"];
                        DgvPlaning.Rows[index].Cells["Strdate"].Value = _dataTable.Rows[i]["StartDate"];
                        DgvPlaning.Rows[index].Cells["enddate"].Value = _dataTable.Rows[i]["EndDate"];
                        DgvPlaning.Rows[index].DefaultCellStyle.ForeColor = Color.Green;

                    }
                    DgvPlaning.ReadOnly = true;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FetchBrkDownData()
        {
            try
            {
                DataTable _dataTable = Resources.Instance.GetDataKey("Sp_FetchBrkDwnMachineInfo", "@userid", "@username", "@empcode",
                GlobalDeclaration._holdInfo[0].UserId.ToString(), GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].EmpCode);
                if (_dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < _dataTable.Rows.Count; i++)
                    {
                        //if (string.IsNullOrEmpty(_dataTable.Rows[i]["Result"].ToString()))
                        {
                            DataGridViewRow rowadd = new DataGridViewRow();
                            DgvPlaning.Rows.Add(rowadd);
                            int index = DgvPlaning.Rows.Count - 1;
                            DgvPlaning.Rows[index].Cells["SrNo"].Value = _dataTable.Rows[i]["SrNo"].ToString();
                            DgvPlaning.Rows[index].Cells["MachineTag"].Value = _dataTable.Rows[i]["MachineTagNo"].ToString();
                            DgvPlaning.Rows[index].Cells["MachineName"].Value = _dataTable.Rows[i]["MachineName"].ToString();
                            DgvPlaning.Rows[index].Cells["mntCrtDate"].Value = DateTime.Now.ToString();
                            DgvPlaning.Rows[index].Cells["mntCrtDate"].ReadOnly = true;
                            DgvPlaning.Rows[index].Cells["SrNo"].ReadOnly = true;
                            DgvPlaning.Rows[index].DefaultCellStyle.ForeColor = Color.Red;// It Take More Time We have to chnage this way 
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvPlaning.SelectedRows.Count > 0)
                {
                    if (DgvPlaning.SelectedRows[0].DefaultCellStyle.ForeColor != Color.Green)
                    {
                        try
                        {
                            foreach (DataGridViewRow rw in this.DgvPlaning.SelectedRows)
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
                            AuditReportInsertion _insert = new AuditReportInsertion();
                            int Status = _insert.InsertFreezPlaingInfo(this.DgvPlaning);
                            if (Status > 0)
                            {
                                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Insert Done", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DgvPlaning.SelectedRows[0].DefaultCellStyle.ForeColor = Color.Green;
                                DgvPlaning.SelectedRows[0].ReadOnly = true;
                            }
                            else
                            {
                                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Error in Insertion", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception Ex)
                        {
                            XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "This Infomation Already Exists In Db,\n Please select Another Row From Grid.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please Select Row First.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DgvPlaning_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (DgvPlaning.Rows.Count > 0)
                {
                    string clmName = string.Empty;
                    if ((e.ColumnIndex == 8 || e.ColumnIndex == 9) && e.RowIndex > -1)
                    {


                        // case "mntCrtDate":
                        LastDateTimePicker = new DateTimePicker();  //DateTimePicker 

                        //Adding DateTimePicker control into DataGridView
                        DgvPlaning.Controls.Add(LastDateTimePicker);

                        // Intially made it invisible
                        LastDateTimePicker.Visible = false;

                        // Setting the format (i.e. 2014-10-10)
                        LastDateTimePicker.Format = DateTimePickerFormat.Custom;  //
                        LastDateTimePicker.CustomFormat = "yyyy-MM-dd hh:mm:ss";

                        LastDateTimePicker.TextChanged += new EventHandler(Set_date_TextChangedEvnts);

                        // Now make it visible
                        LastDateTimePicker.Visible = true;

                        // It returns the retangular area that represents the Display area for a cell
                        Rectangle oRectangle = DgvPlaning.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                        //Setting area for DateTimePicker Control
                        LastDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

                        // Setting Location
                        LastDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);

                        LastDateTimePicker.CloseUp += new EventHandler(DateTimePickerClose);


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
                if (DgvPlaning.Rows.Count > 0)
                    DgvPlaning.CurrentCell.Value = LastDateTimePicker.Text.ToString();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void DgvReport_EditingControlShowing(Object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            System.Windows.Forms.ComboBox cmb = e.Control as System.Windows.Forms.ComboBox;
            if (DgvPlaning.CurrentCell.ColumnIndex == 0 && e.Control is System.Windows.Forms.ComboBox)
            {

                if (cmb != null)
                {
                    cmb.SelectedIndexChanged -= new
                 EventHandler(cb_SelectedIndexChanged);
                    cmb.SelectedIndexChanged += new
                    EventHandler(cb_SelectedIndexChanged);
                }

            }
            //MessageBox.Show(Indesc);
        }
        void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((System.Windows.Forms.ComboBox)sender).SelectedItem != null)
            {
                if (((System.Windows.Forms.ComboBox)sender).SelectedItem.ToString() == "OutSource")
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "VMS Module Activated", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }


        private void addRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                switch (int.Parse(((ToolStripMenuItem)sender).Tag.ToString()))
                {
                    case 0:
                        {
                            //AddNewRow();
                        }
                        break;
                    case 1:

                        break;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddNewRow()
        {
            try
            {
                DataGridViewRow rowadd = new DataGridViewRow();
                DgvPlaning.Rows.Insert(0, rowadd);
                DgvPlaning.Rows[0].Cells["mntCrtDate"].Value = DateTime.Now.ToString();
                DgvPlaning.Rows[0].Cells["mntCrtDate"].ReadOnly = true;
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
                if (DgvPlaning.Rows.Count > 0)
                {
                    int indes = this.DgvPlaning.SelectedRows[0].Index;
                    DgvPlaning.Rows.RemoveAt(indes);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvPlaning_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void DgvPlaning_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.A))
            {
                //AddNewRow();
            }
            else if (e.KeyData == (Keys.Control | Keys.D) || e.KeyData == Keys.Delete)
            {
                //DeleteRow();
            }

        }

        private void DgvPlaning_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                //if (LastDateTimePicker != null)
                //    LastDateTimePicker.Visible = false;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvPlaning_Scroll(object sender, ScrollEventArgs e)
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

        private void DgvPlaning_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SetComboBoxCellType objChangeCellType = new SetComboBoxCellType(ChangeCellToComboBox);
                if (e.ColumnIndex == this.DgvPlaning.Columns["team"].Index)
                {
                    this.DgvPlaning.BeginInvoke(objChangeCellType, e.RowIndex, "team", e.ColumnIndex);
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DgvPlaning.Columns["Outsource"].Index)
                {
                    this.DgvPlaning.BeginInvoke(objChangeCellType, e.RowIndex, "Outsource", e.ColumnIndex);
                    bIsComboBox = false;
                }


                else if (e.ColumnIndex == this.DgvPlaning.Columns["shqReq"].Index)
                {
                    this.DgvPlaning.BeginInvoke(objChangeCellType, e.RowIndex, "shqReq", e.ColumnIndex);
                    bIsComboBox = false;
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

                    if (ColumnName == "team")
                    {
                        if (DgvPlaning.Rows[iRowIndex].Cells[DgvPlaning.CurrentCell.ColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgComboCell = new DataGridViewComboBoxCell();
                        dgComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgComboCell.DataSource = Resources.Instance._EmpName;
                        dgComboCell.ValueMember = "emp_name";
                        dgComboCell.DisplayMember = "emp_name";
                        DgvPlaning.Rows[iRowIndex].Cells[DgvPlaning.CurrentCell.ColumnIndex] = dgComboCell;
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "Outsource")
                    {
                        if (DgvPlaning.Rows[iRowIndex].Cells[DgvPlaning.CurrentCell.ColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgComboCellPrioty = new DataGridViewComboBoxCell();
                        dgComboCellPrioty.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgComboCellPrioty.Items.Add("Inhouse");
                        dgComboCellPrioty.Items.Add("Outsource");
                        dgComboCellPrioty.Items.Add("AMC");
                        // dgComboCellPrioty.ReadOnly = false;                        
                        DgvPlaning.Rows[iRowIndex].Cells[DgvPlaning.CurrentCell.ColumnIndex] = dgComboCellPrioty;
                        bIsComboBox = true;

                    }
                    else if (ColumnName == "shqReq")
                    {
                        if (DgvPlaning.Rows[iRowIndex].Cells[DgvPlaning.CurrentCell.ColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgComboCellPrioty = new DataGridViewComboBoxCell();
                        dgComboCellPrioty.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgComboCellPrioty.Items.Add("Yes");
                        dgComboCellPrioty.Items.Add("No");
                        // dgComboCellPrioty.ReadOnly = false;                        
                        DgvPlaning.Rows[iRowIndex].Cells[DgvPlaning.CurrentCell.ColumnIndex] = dgComboCellPrioty;
                        bIsComboBox = true;
                    }


                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
