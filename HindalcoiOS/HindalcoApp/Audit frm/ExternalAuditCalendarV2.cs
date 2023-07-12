using DevExpress.XtraEditors;
using ExcelDataReader;
using HindalcoiOS.Class_Operation;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.Audit_frm
{
    public partial class ExternalAuditCalendar : XtraForm
    {
        delegate void SetComboBoxCellType(int iRowIndex, string clmname, int iColumnIndex);
        public ExternalAuditCalendar()
        {
            this.Text = "External Audit Report Presentation";
            InitializeComponent();
            UpdateTextPosition();
        }
        DateTimePicker fromDate;
        DateTimePicker Todate;
        //DataTable TypeOfAuditDT = new DataTable();    
        private bool bIsComboBox;
        DataTable MapColumn = new DataTable();
        private void ExternalAuditCalendar_Load(object sender, EventArgs e)
        {
            DisableControl();
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Segoe UI", 9));
            DGVAuditCal.ColumnWidthChanged += new DataGridViewColumnEventHandler(DGVAuditCal_ColumnWidthChanged);
            GridSeeting();
            LoadViewCalendar();
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
        private void LoadViewCalendar()
        {
            MapColumn = Resources.Instance.GetDataKey("Sp_FetchExternalAuditCalendar", "@empCode", GlobalDeclaration._holdInfo[0].EmpCode);
            if (MapColumn.Rows.Count > 0)
            {
                //AutoIncreamet = MapColumn.Rows.Count;
                DgvViewCalendar.DataSource = MapColumn;
                GridSeeting1();
            }
            else
            {
                //if (MapColumn.Columns.Count > 0)
                //{
                //    DgvViewCalendar.DataSource = MapColumn;                   
                //}
                //else
                //{
                //    DgvViewCalendar.DataSource = BindColum();
                //}
                DgvViewCalendar.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.Visible = false);
                GridSeeting1();
            }
            // TypeOfAuditDT = Resources.Instance.GetDataKey("Sp_FetTypeOfAuditMasterKey");       
        }
        private DataTable BindColum()
        {

            MapColumn.Columns.Add("SrNo", typeof(string));
            MapColumn.Columns.Add("AuditCode", typeof(string));
            MapColumn.Columns.Add("NameofAudit", typeof(string));
            MapColumn.Columns.Add("TypeofAudit", typeof(string));
            MapColumn.Columns.Add("ProcessName", typeof(string));
            MapColumn.Columns.Add("Area", typeof(string));
            MapColumn.Columns.Add("FromDate", typeof(string));
            MapColumn.Columns.Add("ToTate", typeof(string));
            MapColumn.Columns.Add("ThirdPartyName", typeof(string));
            MapColumn.Columns.Add("Department", typeof(string));
            MapColumn.Columns.Add("Individual", typeof(string));
            MapColumn.Columns.Add("Auditowner", typeof(string));
            MapColumn.Columns.Add("Remark", typeof(string));
            return MapColumn;
        }
        private void GridSeeting1()
        {
            try
            {
                DgvViewCalendar.BorderStyle = BorderStyle.Fixed3D;
                DgvViewCalendar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                DgvViewCalendar.AllowUserToResizeColumns = false;
                DgvViewCalendar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                DgvViewCalendar.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                DgvViewCalendar.DefaultCellStyle.SelectionForeColor = Color.Black;
                DgvViewCalendar.RowsDefaultCellStyle.BackColor = Color.LightGray;
                DgvViewCalendar.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
                DgvViewCalendar.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

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
                DGVAuditCal.BorderStyle = BorderStyle.Fixed3D;
                DGVAuditCal.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                DGVAuditCal.AllowUserToResizeColumns = false;

                DGVAuditCal.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                DGVAuditCal.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;

                DGVAuditCal.DefaultCellStyle.SelectionForeColor = Color.Black;
                DGVAuditCal.RowsDefaultCellStyle.BackColor = Color.LightGray;
                DGVAuditCal.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
                DGVAuditCal.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<Control> GetAllControls(Control container, List<Control> list)
        {
            foreach (Control c in container.Controls)
            {
                if (c.Controls.Count > 0)
                    list = GetAllControls(c, list);
                else
                    list.Add(c);
            }
            return list;
        }
        private List<Control> GetAllControls(Control container)
        {
            return GetAllControls(container, new List<Control>());
        }
        void DGVAuditCal_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                Rectangle rtHeader = DGVAuditCal.DisplayRectangle;
                rtHeader.Height = DGVAuditCal.ColumnHeadersHeight / 2;
                DGVAuditCal.Invalidate(rtHeader);
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
                if (this.DGVAuditCal.Rows.Count > 0)
                {
                    AuditReportInsertion auditReportInsertion = new AuditReportInsertion();
                    int Status = auditReportInsertion.InsertAuditCalendExternal(this.DGVAuditCal);
                    if (Status > 0)
                    {
                        DGVAuditCal.Rows.Cast<DataGridViewRow>().ToList().ForEach(f => f.Cells["Status"].Value = "Saved");
                        CopyDatRow();
                        XtraMessageBox.Show("Data Save SuccessFully..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // XtraMessageBox.Show("Data Save UnSuccessFully..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Please Fill Data First.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CopyDatRow()
        {
            {
                try
                {
                    for (int i = 0; i < DGVAuditCal.Rows.Count; i++)
                    {
                        DataRow[] Dr = MapColumn.Select("AuditCode='" + DGVAuditCal.Rows[i].Cells["AuditCode"].Value.ToString() + "'");
                        if (Dr.Length > 0)
                        {
                            Dr[0]["NameofAudit"] = DGVAuditCal.Rows[i].Cells["NameofAudit"].Value.ToString();
                            Dr[0]["TypeofAudit"] = DGVAuditCal.Rows[i].Cells["TypeofAudit"].Value.ToString();
                            Dr[0]["Area"] = DGVAuditCal.Rows[i].Cells["Area"].Value.ToString();
                            Dr[0]["ProcessName"] = DGVAuditCal.Rows[i].Cells["ProcessName"].Value.ToString();
                            Dr[0]["FromDate"] = DGVAuditCal.Rows[i].Cells["Fdate"].Value.ToString();
                            Dr[0]["ToDate"] = DGVAuditCal.Rows[i].Cells["TDate"].Value.ToString();
                            Dr[0]["ThirdPartyName"] = DGVAuditCal.Rows[i].Cells["ThirdPartyName"].Value.ToString();
                            Dr[0]["Department"] = DGVAuditCal.Rows[i].Cells["Department"].Value.ToString();
                            Dr[0]["Individual"] = DGVAuditCal.Rows[i].Cells["Individual"].Value.ToString();
                            Dr[0]["AuditOwner"] = DGVAuditCal.Rows[i].Cells["AuditOwner"].Value.ToString();
                            Dr[0]["Remark"] = DGVAuditCal.Rows[i].Cells["Remark"].Value.ToString();
                        }
                        else
                        {
                            DataRow dr = MapColumn.NewRow();
                            dr["SrNo"] = DGVAuditCal.Rows[i].Cells["SrNo"].Value.ToString();
                            dr["AuditCode"] = DGVAuditCal.Rows[i].Cells["AuditCode"].Value.ToString();
                            dr["NameofAudit"] = DGVAuditCal.Rows[i].Cells["NameofAudit"].Value.ToString();
                            dr["TypeofAudit"] = DGVAuditCal.Rows[i].Cells["TypeofAudit"].Value.ToString();
                            dr["Area"] = DGVAuditCal.Rows[i].Cells["Area"].Value.ToString();
                            dr["ProcessName"] = DGVAuditCal.Rows[i].Cells["ProcessName"].Value.ToString();
                            dr["FromDate"] = DGVAuditCal.Rows[i].Cells["Fdate"].Value.ToString();
                            dr["ToDate"] = DGVAuditCal.Rows[i].Cells["TDate"].Value.ToString();
                            dr["ThirdPartyName"] = DGVAuditCal.Rows[i].Cells["ThirdPartyName"].Value.ToString();
                            dr["Department"] = DGVAuditCal.Rows[i].Cells["Department"].Value.ToString();
                            dr["Individual"] = DGVAuditCal.Rows[i].Cells["Individual"].Value.ToString();
                            dr["AuditOwner"] = DGVAuditCal.Rows[i].Cells["AuditOwner"].Value.ToString();
                            dr["Remark"] = DGVAuditCal.Rows[i].Cells["Remark"].Value.ToString();
                            MapColumn.Rows.Add(dr);
                        }
                    }
                    if (DgvViewCalendar.DataSource == null)
                        DgvViewCalendar.DataSource = MapColumn;
                    DgvViewCalendar.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.Visible = true);
                }
                catch (Exception Ex)
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tabExternalaudit_Click(object sender, EventArgs e)
        {
            //if (int.Parse(tabExternalaudit.SelectedTabPage.Tag.ToString()) == 0)
            //{

            //}
        }

        private void addDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Tag.ToString() == "Add")
            {
                Addnew();
            }
            else if (((ToolStripMenuItem)sender).Tag.ToString() == "delete")
            {
                if (DGVAuditCal.Rows.Count > 0)
                {
                    DeleteRow();
                }
            }
            else if (((ToolStripMenuItem)sender).Tag.ToString() == "deleteall")
            {
                DGVAuditCal.Rows.Clear();
                int delet = Resources.Instance.RemoveEntry("Sp_deleteExternalAuditCalendarRecord", "@auditcode", "A2020501~001", "@requestquery", "Multiple");
            }
        }
        private void Addnew()
        {
            try
            {
                int Sernumber = 0;
                DataGridViewRow rowadd = new DataGridViewRow();
                DGVAuditCal.Rows.Insert(0, rowadd);
                DGVAuditCal.Columns["SrNo"].ReadOnly = true;
                DGVAuditCal.Rows[0].Cells["AuditCode"].Value = GenerateAuditCode(DGVAuditCal.Rows.Count, ref Sernumber);
                DGVAuditCal.Rows[0].Cells["SrNo"].Value = Sernumber;
                DGVAuditCal.Rows[0].Cells["Status"].Value = "New";
                DGVAuditCal.Columns["AuditCode"].ReadOnly = true;
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
                if (DGVAuditCal.Rows.Count > 0)
                {
                    if (DGVAuditCal.SelectedRows[0].Cells["Status"].Value.ToString() == "New")
                    {
                        int index = DGVAuditCal.SelectedRows[0].Index;
                        string code = this.DGVAuditCal.SelectedRows[0].Cells["AuditCode"].Value.ToString();
                        this.DGVAuditCal.Rows.RemoveAt(index);
                        if (MapColumn.Rows.Count > 0)
                        {
                            DataRow[] Dr = MapColumn.Select("AuditCode='" + code + "'");
                            if (Dr.Length > 0)
                            {
                                foreach (DataRow item in Dr)
                                {
                                    MapColumn.Rows.Remove(item);
                                }
                                int delet = Resources.Instance.RemoveEntry("Sp_deleteExternalAuditCalendarRecord", "@auditcode", code, "@requestquery", "single");
                                if (delet > 0)
                                {
                                    //ReceiveCount--;
                                    //AutoIncreamet--;
                                    XtraMessageBox.Show("Delete Rows.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }

                    }
                    // Delete also row from DB
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private string GenerateAuditCode(int numberaudit, ref int Count)
        {
            if (DgvViewCalendar.Rows.Count == 0)
            {
                Count = numberaudit;
                return String.Format("ExAUD-{0:0000}", numberaudit);
            }
            else if (DgvViewCalendar.Rows.Count >= DGVAuditCal.Rows.Count)
            {
                Count = DgvViewCalendar.Rows.Count + numberaudit;
                return String.Format("ExAUD-{0:0000}", Count);
            }
            else
            {
                Count = numberaudit + DgvViewCalendar.Rows.Count;
                return String.Format("ExAUD-{0:0000}", Count);
            }

        }
        private void DGVAuditCal_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    DeleteRow();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVAuditCal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // if (DGVAuditCal.Rows.Count < 0) return;
                if (e.ColumnIndex == 6 && e.RowIndex > -1)
                {
                    fromDate = new DateTimePicker();  //DateTimePicker 

                    //Adding DateTimePicker control into DataGridView
                    DGVAuditCal.Controls.Add(fromDate);

                    // Intially made it invisible
                    fromDate.Visible = false;

                    // Setting the format (i.e. 2014-10-10)
                    fromDate.Format = DateTimePickerFormat.Short;  //

                    fromDate.TextChanged += new EventHandler(fromDate_OntextChange);

                    // Now make it visible
                    fromDate.Visible = true;

                    // It returns the retangular area that represents the Display area for a cell
                    Rectangle oRectangle = DGVAuditCal.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                    //Setting area for DateTimePicker Control
                    fromDate.Size = new Size(oRectangle.Width, oRectangle.Height);

                    // Setting Location
                    fromDate.Location = new Point(oRectangle.X, oRectangle.Y);

                    fromDate.CloseUp += new EventHandler(fromDate_CloseUp);
                }
                else if (e.ColumnIndex == 7)
                {
                    Todate = new DateTimePicker();  //DateTimePicker 

                    //Adding DateTimePicker control into DataGridView
                    DGVAuditCal.Controls.Add(Todate);

                    // Intially made it invisible
                    Todate.Visible = false;

                    // Setting the format (i.e. 2014-10-10)
                    Todate.Format = DateTimePickerFormat.Short;  //

                    Todate.TextChanged += new EventHandler(Todate_OntextChange);

                    // Now make it visible
                    Todate.Visible = true;

                    // It returns the retangular area that represents the Display area for a cell
                    Rectangle oRectangle = DGVAuditCal.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                    //Setting area for DateTimePicker Control
                    Todate.Size = new Size(oRectangle.Width, oRectangle.Height);

                    // Setting Location
                    Todate.Location = new Point(oRectangle.X, oRectangle.Y);

                    Todate.CloseUp += new EventHandler(Todate_CloseUp);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void fromDate_OntextChange(object sender, EventArgs e)
        {
            DGVAuditCal.CurrentCell.Value = fromDate.Text.ToString();
        }
        void fromDate_CloseUp(object sender, EventArgs e)
        {
            fromDate.Visible = false;
        }
        void Todate_OntextChange(object sender, EventArgs e)
        {
            if (DGVAuditCal.Rows.Count > 0)
                DGVAuditCal.CurrentCell.Value = Todate.Text.ToString();
        }
        void Todate_CloseUp(object sender, EventArgs e)
        {
            Todate.Visible = false;
        }

        private void DGVAuditCal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8 && e.RowIndex > -1)
            {
                string EmpName = DGVAuditCal.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (!string.IsNullOrEmpty(EmpName))
                {
                    MessageBox.Show("Party Details Pending");
                }
            }
        }

        private void DGVAuditCal_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVAuditCal.Rows.Count > 0)
            {
                foreach (DataGridViewRow rw in this.DGVAuditCal.Rows)
                {
                    for (int i = 0; i < rw.Cells.Count; i++)
                    {
                        if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                        {
                            return;
                        }
                    }
                }
                int coumnindex = this.DGVAuditCal.CurrentCell.ColumnIndex;
                int rowsindex = this.DGVAuditCal.CurrentCell.RowIndex;
                //   string upp = @"Update InternAuditReportTBL set " + DgvReport.Columns[colnindex].Name + " ='" + DgvReport.Rows[e.RowIndex].Cells[colnindex].Value.ToString() + "' where Machinetag='" + DgvReport.Rows[e.RowIndex].Cells["cmbMachinetag"].Value.ToString()+"";
                string updatequery = @"update ExternalAuditCalenTBL set " + DGVAuditCal.Columns[coumnindex].HeaderText.Trim().Replace(" ", string.Empty) + "='" + DGVAuditCal.Rows[e.RowIndex].Cells[coumnindex].Value.ToString() + "' where AuditCode='" + DGVAuditCal.Rows[e.RowIndex].Cells["AuditCode"].Value.ToString() + "'";
                int r = Resources.Instance.SaveMaintenenceData(updatequery);
                if (r > 0)
                {
                    DataRow[] Dr = MapColumn.Select("AuditCode='" + DGVAuditCal.Rows[e.RowIndex].Cells["AuditCode"].Value.ToString() + "'");
                    if (Dr.Length > 0)
                    {
                        Dr[0]["NameofAudit"] = DGVAuditCal.Rows[e.RowIndex].Cells["NameofAudit"].Value.ToString();
                        Dr[0]["TypeofAudit"] = DGVAuditCal.Rows[e.RowIndex].Cells["TypeofAudit"].Value.ToString();
                        Dr[0]["Area"] = DGVAuditCal.Rows[e.RowIndex].Cells["Area"].Value.ToString();
                        Dr[0]["ProcessName"] = DGVAuditCal.Rows[e.RowIndex].Cells["ProcessName"].Value.ToString();
                        Dr[0]["FromDate"] = DGVAuditCal.Rows[e.RowIndex].Cells["Fdate"].Value.ToString();
                        Dr[0]["ToDate"] = DGVAuditCal.Rows[e.RowIndex].Cells["TDate"].Value.ToString();
                        Dr[0]["ThirdPartyName"] = DGVAuditCal.Rows[e.RowIndex].Cells["ThirdPartyName"].Value.ToString();
                        Dr[0]["Department"] = DGVAuditCal.Rows[e.RowIndex].Cells["Department"].Value.ToString();
                        Dr[0]["Individual"] = DGVAuditCal.Rows[e.RowIndex].Cells["Individual"].Value.ToString();
                        Dr[0]["AuditOwner"] = DGVAuditCal.Rows[e.RowIndex].Cells["AuditOwner"].Value.ToString();
                        Dr[0]["Remark"] = DGVAuditCal.Rows[e.RowIndex].Cells["Remark"].Value.ToString();
                    }
                    XtraMessageBox.Show("Cell Update SuccessFully..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void btnViewReport_Click(object sender, EventArgs e)
        {

        }

        private void DGVAuditCal_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SetComboBoxCellType objChangeCellType = new SetComboBoxCellType(ChangeCellToComboBox);
                if (e.ColumnIndex == this.DGVAuditCal.Columns["TypeofAudit"].Index)
                {
                    this.DGVAuditCal.BeginInvoke(objChangeCellType, e.RowIndex, "TypeofAudit", e.ColumnIndex);
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DGVAuditCal.Columns["Area"].Index)
                {
                    this.DGVAuditCal.BeginInvoke(objChangeCellType, e.RowIndex, "area", e.ColumnIndex);
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DGVAuditCal.Columns["Individual"].Index)
                {
                    this.DGVAuditCal.BeginInvoke(objChangeCellType, e.RowIndex, "Individual", e.ColumnIndex);
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DGVAuditCal.Columns["Department"].Index)
                {
                    this.DGVAuditCal.BeginInvoke(objChangeCellType, e.RowIndex, "DeptName", e.ColumnIndex);
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DGVAuditCal.Columns["AuditOwner"].Index)
                {
                    this.DGVAuditCal.BeginInvoke(objChangeCellType, e.RowIndex, "Auditowner", e.ColumnIndex);
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
                    if (ColumnName == "TypeofAudit")
                    {
                        if (DGVAuditCal.Rows[iRowIndex].Cells[DGVAuditCal.CurrentCell.ColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgvCombotypeaudit = new DataGridViewComboBoxCell();
                        dgvCombotypeaudit.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgvCombotypeaudit.DataSource = Resources.Instance.TypeOfAuditDT.Copy();
                        dgvCombotypeaudit.ValueMember = "TypeOfAudit";
                        dgvCombotypeaudit.DisplayMember = "TypeOfAudit";
                        DGVAuditCal.Rows[iRowIndex].Cells[DGVAuditCal.CurrentCell.ColumnIndex] = dgvCombotypeaudit;
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "area")
                    {
                        if (DGVAuditCal.Rows[iRowIndex].Cells[DGVAuditCal.CurrentCell.ColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell AreaFill = new DataGridViewComboBoxCell();
                        AreaFill.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        AreaFill.DataSource = Resources.Instance.AreaOwner.Copy();
                        AreaFill.ValueMember = "NameOfArea";
                        AreaFill.DisplayMember = "NameOfArea";
                        DGVAuditCal.Rows[iRowIndex].Cells[DGVAuditCal.CurrentCell.ColumnIndex] = AreaFill;
                        bIsComboBox = true;

                    }
                    else if (ColumnName == "Individual")
                    {
                        if (DGVAuditCal.Rows[iRowIndex].Cells[DGVAuditCal.CurrentCell.ColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgvComboIDeptName = new DataGridViewComboBoxCell();
                        dgvComboIDeptName.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgvComboIDeptName.DataSource = Resources.Instance._EmpName.Copy();
                        dgvComboIDeptName.ValueMember = "emp_name";
                        dgvComboIDeptName.DisplayMember = "emp_name";
                        DGVAuditCal.Rows[iRowIndex].Cells[DGVAuditCal.CurrentCell.ColumnIndex] = dgvComboIDeptName;
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "DeptName")
                    {
                        if (DGVAuditCal.Rows[iRowIndex].Cells[DGVAuditCal.CurrentCell.ColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgvComboDeptName = new DataGridViewComboBoxCell();
                        dgvComboDeptName.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgvComboDeptName.DataSource = Resources.Instance.DepartmentMaster.Copy(); ;
                        dgvComboDeptName.ValueMember = "DepartName";
                        dgvComboDeptName.DisplayMember = "DepartName";
                        DGVAuditCal.Rows[iRowIndex].Cells[DGVAuditCal.CurrentCell.ColumnIndex] = dgvComboDeptName;
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "Auditowner")
                    {
                        if (DGVAuditCal.Rows[iRowIndex].Cells[DGVAuditCal.CurrentCell.ColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgvComboAuditowner = new DataGridViewComboBoxCell();
                        dgvComboAuditowner.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgvComboAuditowner.DataSource = Resources.Instance._EmpName.Copy();
                        dgvComboAuditowner.ValueMember = "emp_name";
                        dgvComboAuditowner.DisplayMember = "emp_name";
                        DGVAuditCal.Rows[iRowIndex].Cells[DGVAuditCal.CurrentCell.ColumnIndex] = dgvComboAuditowner;
                        bIsComboBox = true;
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVAuditCal_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                string Value = DGVAuditCal.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (Value == "AddMore")
                {
                    AuditTypeAddFrm NewTypeObj = new AuditTypeAddFrm();
                    NewTypeObj.updateAuditTypeHandler += KeySafetyHandlerEvent;
                    if (NewTypeObj.ShowDialog() == DialogResult.OK)
                    {
                        DGVAuditCal.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = NewTypeObj.txtAddAudit.Text;
                        NewTypeObj.txtAddAudit.Text = "";
                        NewTypeObj.Close();
                        if (DGVAuditCal.IsCurrentCellDirty)
                        {
                            DGVAuditCal.CommitEdit(DataGridViewDataErrorContexts.Commit);
                        }
                    }
                    else
                    {
                        DGVAuditCal.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Safety";
                    }
                }
            }
        }
        private void KeySafetyHandlerEvent(object sender, string e)
        {
            try
            {
                // TypeOfAuditDT = Resources.Instance.GetDataKey("Sp_FetTypeOfAuditMasterKey");
                DataRow[] Rows = Resources.Instance.TypeOfAuditDT.Select("TypeOfAudit='" + e + "'");
                if (Rows.Length <= 0)
                {
                    DataRow dataRow = Resources.Instance.TypeOfAuditDT.NewRow();
                    dataRow["TypeofAudit"] = e;
                    Resources.Instance.TypeOfAuditDT.Rows.Add(dataRow);
                }
                //DataRow dataRow;
                //dataRow= TypeOfAuditDT.NewRow();
                //dataRow["TypeofAudit"] = e;
                //TypeOfAuditDT.Rows.Add(dataRow);
                //DgvAudit.Rows[holdRowIndex].Cells["TypeofAudit"].Value = e;
                //DgvAudit.Rows[holdRowIndex].Cells["TypeofAudit"].ReadOnly = true;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void DGVAuditCal_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGVAuditCal.IsCurrentCellDirty)
            {
                DGVAuditCal.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        #region ExterNalAudit Calendar Upload Method Info
        private DataSet ds;
        private void SelectTable()
        {
            var tablename = sheetCombo.SelectedItem.ToString();
            //dgventry.AutoGenerateColumns = true;
            //dgventry.DataSource = ds; // dataset
            //dgventry.DataMember = tablename;
            GetValues(ds, tablename);
        }
        public void DisableControl()
        {
            if (GlobalDeclaration.UserType.Equals("U1--Maintenance") || GlobalDeclaration.UserType.Equals("U1-Safety") || GlobalDeclaration.UserType.Equals("U1-Operation"))
            {
                this.groupBox1.Visible = false;
                this.tabExternalaudit.Location = new Point(12, 295);
            }
        }
        public void GetValues(DataSet dataset, string sheetName)
        {

            if (GlobalDeclaration.UserType.Equals("U1-Maintenance") || GlobalDeclaration.UserType.Equals("U1-Safety") || GlobalDeclaration.UserType.Equals("U1-Operation")) return;
            int uu = dataset.Tables[sheetName].Rows.Count;
            if (DGVAuditCal.Columns.Count > 0)
            {
                //DGVAuditCal.Columns["NextDate"].ReadOnly = true;
                for (int i = 0; i < dataset.Tables[sheetName].Rows.Count; i++)
                {
                    DataRow row = dataset.Tables[sheetName].Rows[i];
                    DataGridViewRow dr = new DataGridViewRow();
                    DGVAuditCal.Rows.Add(dr);
                    int serialnumber = 0;
                    int RowsIndex = this.DGVAuditCal.Rows.Count - 1;
                    DGVAuditCal.Rows[RowsIndex].Cells["AuditCode"].Value = GenerateAuditCode(this.DGVAuditCal.Rows.Count, ref serialnumber);
                    DGVAuditCal.Rows[RowsIndex].Cells["SrNo"].Value = serialnumber;
                    DGVAuditCal.Rows[RowsIndex].Cells["NameofAudit"].Value = row["Name of Audit"];
                    DGVAuditCal.Rows[RowsIndex].Cells["TypeofAudit"].Value = row["Type of Audit"];
                    DGVAuditCal.Rows[RowsIndex].Cells["Area"].Value = row["Audit Area"];
                    DGVAuditCal.Rows[RowsIndex].Cells["ProcessName"].Value = row["Process Name"];
                    //DGVAuditCal.Rows[RowsIndex].Cells["Frequency"].Value = row["Frequency"];
                    //DGVAuditCal.Rows[RowsIndex].Cells["LastDate"].Value = row["Last Date Of Audit"];
                    DGVAuditCal.Rows[RowsIndex].Cells["Department"].Value = row["Department"];
                    DGVAuditCal.Rows[RowsIndex].Cells["Individual"].Value = row["Individual"];
                    DGVAuditCal.Rows[RowsIndex].Cells["AuditOwner"].Value = row["Audit Owner"];
                    DGVAuditCal.Rows[RowsIndex].Cells["Status"].Value = "New";
                    //DGVAuditCal.Rows[RowsIndex].Cells["Reviewedby"].Value = row["Reviewed by"];
                    //DGVAuditCal.Rows[RowsIndex].Cells["Approvedby"].Value = row["Approved by"];
                }
                //Datechange();
                //DgvMaitenance.CellFormatting += Dgventry_CellFormatting;                              
            }
            else
            {
                XtraMessageBox.Show(new Form { TopMost = true }, "Can't Upload Same Data Sheet, Plese try Another?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void sheetCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectTable();
        }
        private List<string> FileContainer = new List<string>();
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtfile.Text))
            {
                var stream = new FileStream(txtfile.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);

                ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    UseColumnDataType = false,
                    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = firstRowNamesCheckBox.Checked
                    }
                });
                string[] FileSplit = this.txtfile.Text.Split('\\');
                if (!FileContainer.Contains(FileSplit[FileSplit.Length - 1]))
                {
                    FileContainer.Add(FileSplit[FileSplit.Length - 1]);
                    var tablenames = GlobalDeclaration.GetTablenames(ds.Tables);
                    sheetCombo.DataSource = tablenames;
                    if (tablenames.Count > 0)
                        sheetCombo.SelectedIndex = 0;
                }
                else
                {
                    XtraMessageBox.Show("Can't Upload Same Data Sheet, Plese try Another?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }
        private void btnbrowser_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtfile.Text))
                txtfile.Text = "";
            OpenFileDialog obd = new OpenFileDialog();
            obd.Filter = "Supported files | *.xls; *.xlsx; *.xlsb; *.csv | xls | *.xls | xlsx | *.xlsx | xlsb | *.xlsb | csv | *.csv | All | *.*";
            DialogResult dlgRes = obd.ShowDialog(this);
            if ((dlgRes != DialogResult.OK) || (string.IsNullOrEmpty(obd.FileName)))
            {
                return;
            }
            if (DGVAuditCal.Columns.Count > 0)
            {
                txtfile.Text = obd.FileName;
                //txtfile.ReadOnly = true;
            }
        }
        #endregion


      
        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // ExternalAuditCalendar
        //    // 
        //    this.ClientSize = new System.Drawing.Size(298, 260);
        //    this.Name = "ExternalAuditCalendar";
        //    this.ResumeLayout(false);

        //}
    }

