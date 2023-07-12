using DevExpress.XtraEditors;
using ExcelDataReader;
using HindalcoiOS.Class_Operation;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HindalcoiOS.Audit_frm
{
    public partial class AuditCalendar : XtraForm
    {
        delegate void SetComboBoxCellType(int iRowIndex, string clmname, int iColumnIndex);
        public AuditCalendar()
        {
            try
            {
                InitializeComponent();
                this.Text = "Audit Calendar";
                //UpdateTextPosition();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.StackTrace);
            }
        }
        #region Variable Declarartion     
        DataTable MapColumn = new DataTable();
        private bool bIsComboBox;
        DateTimePicker LastDateTimePicker;
        #endregion       
        private void AuditCalendar_Load(object sender, EventArgs e)
        {
            DisableControl();
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Segoe UI", 10));
            LoadViewCalendar();
            GridSeeting();
            DgvAudit.ColumnWidthChanged += new DataGridViewColumnEventHandler(dataGridView1_ColumnWidthChanged);
        }
        private void LoadViewCalendar()
        {
            MapColumn = Resources.Instance.GetDataKey("Sp_FetchAuditCalendar", "@empCode", GlobalDeclaration._holdInfo[0].EmpCode);
            if (MapColumn.Rows.Count > 0)
            {
                DgvViewCalendar.DataSource = MapColumn;
                //for (int i = 0; i < MapColumn.Rows.Count; i++)
                //{
                //    DataGridViewRow dr = new DataGridViewRow();
                //    DgvViewCalendar.Rows.Add(dr);
                //    int RowsIndex = this.DgvViewCalendar.Rows.Count - 1;
                //    DgvViewCalendar.Rows[RowsIndex].Cells["SrNo"].Value = MapColumn.Rows[i]["SrNo"];
                //    DgvViewCalendar.Rows[RowsIndex].Cells["AuditCode"].Value = MapColumn.Rows[i]["AuditCode"];
                //    DgvViewCalendar.Rows[RowsIndex].Cells["NameofAudit"].Value = MapColumn.Rows[i]["NameofAudit"];
                //    DgvViewCalendar.Rows[RowsIndex].Cells["TypeofAudit"].Value = MapColumn.Rows[i]["TypeofAudit"];
                //    DgvViewCalendar.Rows[RowsIndex].Cells["Area"].Value = MapColumn.Rows[i]["Area"];
                //    DgvViewCalendar.Rows[RowsIndex].Cells["ProcessName"].Value = MapColumn.Rows[i]["ProcessName"];
                //    DgvViewCalendar.Rows[RowsIndex].Cells["Frequency"].Value = MapColumn.Rows[i]["Frequency"];
                //    DgvViewCalendar.Rows[RowsIndex].Cells["LastDate"].Value = MapColumn.Rows[i]["LastDate"];
                //    DgvViewCalendar.Rows[RowsIndex].Cells["NextDate"].Value = MapColumn.Rows[i]["NextDate"];
                //    DgvViewCalendar.Rows[RowsIndex].Cells["Department"].Value = MapColumn.Rows[i]["Department"];
                //    DgvViewCalendar.Rows[RowsIndex].Cells["Individual"].Value = MapColumn.Rows[i]["Individual"];
                //    DgvViewCalendar.Rows[RowsIndex].Cells["AuditOwner"].Value = MapColumn.Rows[i]["AuditOwner"];
                //    DgvViewCalendar.Rows[RowsIndex].Cells["Reviewedby"].Value = MapColumn.Rows[i]["Reviewedby"];
                //    DgvViewCalendar.Rows[RowsIndex].Cells["Approvedby"].Value = MapColumn.Rows[i]["Approvedby"];
                //}
                GridSeeting1();
                //  lastAuditCade = MapColumn.Rows[MapColumn.Rows.Count - 1]["AuditCode"].ToString();
            }
            else
            {
                //DgvViewCalendar.DataSource = BindColum();
                DgvViewCalendar.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.Visible = false);
                GridSeeting1();
            }
            //  TypeOfAuditDT = Resources.Instance.GetDataKey("Sp_FetTypeOfAuditMasterKey");
        }
        private DataTable BindColum()
        {
            MapColumn.Clear();
            MapColumn.Columns.Add("SrNo", typeof(string));
            MapColumn.Columns.Add("AuditCode", typeof(string));
            MapColumn.Columns.Add("NameofAudit", typeof(string));
            MapColumn.Columns.Add("TypeofAudit", typeof(string));
            MapColumn.Columns.Add("Area", typeof(string));
            MapColumn.Columns.Add("ProcessName", typeof(string));
            MapColumn.Columns.Add("Frequency", typeof(string));
            MapColumn.Columns.Add("Lastdateofaudit", typeof(string));
            MapColumn.Columns.Add("Nextdateofaudit", typeof(string));
            MapColumn.Columns.Add("Department", typeof(string));
            MapColumn.Columns.Add("Individual", typeof(string));
            MapColumn.Columns.Add("Auditowner", typeof(string));
            MapColumn.Columns.Add("Reviewedby", typeof(string));
            MapColumn.Columns.Add("Approvedby", typeof(string));

            return MapColumn;
        }
        private void GridSeeting1()
        {
            try
            {
                DgvViewCalendar.BorderStyle = BorderStyle.Fixed3D;
                DgvViewCalendar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                DgvViewCalendar.AllowUserToResizeColumns = false;

                DgvViewCalendar.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


                DgvViewCalendar.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;

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
                DgvAudit.BorderStyle = BorderStyle.Fixed3D;
                DgvAudit.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                DgvAudit.AllowUserToResizeColumns = false;

                DgvAudit.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                DgvAudit.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;

                DgvAudit.DefaultCellStyle.SelectionForeColor = Color.Black;
                DgvAudit.RowsDefaultCellStyle.BackColor = Color.LightGray;
                DgvAudit.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
                DgvAudit.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

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

        void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                Rectangle rtHeader = DgvAudit.DisplayRectangle;
                rtHeader.Height = DgvAudit.ColumnHeadersHeight / 2;
                DgvAudit.Invalidate(rtHeader);
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
                Rectangle rtHeader = DgvAudit.DisplayRectangle;
                rtHeader.Height = DgvAudit.ColumnHeadersHeight / 2;
                DgvAudit.Invalidate(rtHeader);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                int heightOffset = -5;
                int widthOffset = -2;
                int xOffset = 0;
                int yOffset = 13;
                int columnIndex = 9;
                Rectangle headerCellRectangle = DgvAudit.GetCellDisplayRectangle(columnIndex, -1, true);
                int xCord = headerCellRectangle.Location.X + xOffset;
                int yCord = headerCellRectangle.Location.Y - headerCellRectangle.Height + yOffset;
                int mergedHeaderWidth = DgvAudit.Columns[columnIndex].Width + DgvAudit.Columns[columnIndex - 1].Width + widthOffset;
                Rectangle mergedHeaderRect = new Rectangle(xCord, yCord, mergedHeaderWidth, headerCellRectangle.Height + heightOffset);
                Rectangle r1 = DgvAudit.GetCellDisplayRectangle(columnIndex, -1, true);
                int w2 = DgvAudit.GetCellDisplayRectangle(columnIndex + 1, -1, true).Width;
                r1.X += 1;
                r1.Y += 1;
                r1.Width = r1.Width + w2 - 2;
                r1.Height = r1.Height / 2 - 2;
                e.Graphics.FillRectangle(new SolidBrush(DgvAudit.ColumnHeadersDefaultCellStyle.BackColor), mergedHeaderRect);

                StringFormat format = new StringFormat();

                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString("Doer", DgvAudit.ColumnHeadersDefaultCellStyle.Font,
                    new SolidBrush(DgvAudit.ColumnHeadersDefaultCellStyle.ForeColor), r1, format);
                //}
            }
            catch (Exception Ex)
            {

                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void DgvAudit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    if (DgvAudit.Columns[e.ColumnIndex].Name == "LastDate")
                    {
                        LastDateTimePicker = new DateTimePicker();  //DateTimePicker 

                        //Adding DateTimePicker control into DataGridView
                        DgvAudit.Controls.Add(LastDateTimePicker);

                        // Intially made it invisible
                        LastDateTimePicker.Visible = false;

                        // Setting the format (i.e. 2014-10-10)
                        LastDateTimePicker.Format = DateTimePickerFormat.Custom;
                        LastDateTimePicker.CustomFormat = "yyyy-MM-dd hh:mm:ss";

                        LastDateTimePicker.TextChanged += new EventHandler(LastDateTimePicker_OntextChange);

                        // Now make it visible
                        LastDateTimePicker.Visible = true;

                        // It returns the retangular area that represents the Display area for a cell
                        Rectangle oRectangle = DgvAudit.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                        //Setting area for DateTimePicker Control
                        LastDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

                        // Setting Location
                        LastDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);

                        LastDateTimePicker.CloseUp += new EventHandler(LastDateTimePicker_CloseUp);
                    }
                    //else if (DgvAudit.Columns[e.ColumnIndex].Name=="NextDate")
                    //{
                    //    NextDateTimePicker = new DateTimePicker();  //DateTimePicker 

                    //    //Adding DateTimePicker control into DataGridView
                    //    DgvAudit.Controls.Add(NextDateTimePicker);

                    //    // Intially made it invisible
                    //    NextDateTimePicker.Visible = false;

                    //    // Setting the format (i.e. 2014-10-10)
                    //    NextDateTimePicker.Format = DateTimePickerFormat.Custom;  //
                    //    NextDateTimePicker.CustomFormat = "yyyy-MM-dd";

                    //    NextDateTimePicker.TextChanged += new EventHandler(NextDateTimePicker_OntextChange);

                    //    // Now make it visible
                    //    NextDateTimePicker.Visible = true;

                    //    // It returns the retangular area that represents the Display area for a cell
                    //    Rectangle oRectangle = DgvAudit.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                    //    //Setting area for DateTimePicker Control
                    //    NextDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

                    //    // Setting Location
                    //    NextDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);

                    //    NextDateTimePicker.CloseUp += new EventHandler(NextDateTimePicker_CloseUp);
                    //}
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void LastDateTimePicker_OntextChange(object sender, EventArgs e)
        {
            DgvAudit.CurrentCell.Value = LastDateTimePicker.Text.ToString();
        }
        void LastDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            LastDateTimePicker.Visible = false;
        }

        private void addDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (((ToolStripMenuItem)sender).Tag.ToString() == "Add")
                {
                    Addnew();
                }
                else if (((ToolStripMenuItem)sender).Tag.ToString() == "delete")
                {
                    DeleteRow();
                }
                else if (((ToolStripMenuItem)sender).Tag.ToString() == "deleteall")
                {

                    this.DgvAudit.Rows.Clear();
                    this.MapColumn.Clear();
                    ReceiveCount = 0;
                    int delet = Resources.Instance.RemoveEntry("Sp_deleteAuditCalendarRecord", "@auditcode", "", "@requestquery", "All");
                    if (delet > 0)
                    {

                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Delete Rows.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Addnew()
        {
            try
            {
                int Sernumber = 0;
                DataGridViewRow rowadd = new DataGridViewRow();
                DgvAudit.Rows.Insert(0, rowadd);
                DgvAudit.Columns["SrNo"].ReadOnly = true;
                DgvAudit.Rows[0].Cells["AuditCode"].Value = GenerateAuditCode(DgvAudit.Rows.Count, ref Sernumber);
                DgvAudit.Rows[0].Cells["SrNo"].Value = Sernumber;
                DgvAudit.Columns["AuditCode"].ReadOnly = true;
                DgvAudit.Rows[0].Cells["Status"].Value = "New";
                _isFirstLoad = false;
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
                if (DgvAudit.Rows.Count > 0)
                {
                    int index = DgvAudit.SelectedRows[0].Index;
                    string code = this.DgvAudit.SelectedRows[0].Cells["AuditCode"].Value.ToString();
                    this.DgvAudit.Rows.RemoveAt(index);
                    ReceiveCount--;
                    if (MapColumn.Rows.Count > 0)
                    {
                        DataRow[] Dr = MapColumn.Select("[Audit Code]='" + code + "'");
                        if (Dr.Length > 0)
                        {
                            foreach (DataRow item in Dr)
                            {
                                MapColumn.Rows.Remove(item);
                            }
                        }
                    }
                    int delet = Resources.Instance.RemoveEntry("Sp_deleteAuditCalendarRecord", "@auditcode", code, "@requestquery", "single");
                    if (delet > 0)
                    {
                        //ReceiveCount--;
                        //AutoIncreamet--;
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Delete Rows.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                return String.Format("AUD-{0:0000}", numberaudit);
            }
            else if (DgvViewCalendar.Rows.Count >= DgvAudit.Rows.Count)
            {
                Count = DgvViewCalendar.Rows.Count + numberaudit;
                return String.Format("AUD-{0:0000}", Count);
            }
            else
            {
                Count = numberaudit + DgvViewCalendar.Rows.Count;
                return String.Format("AUD-{0:0000}", Count);
            }
        }
        private void DgvAudit_KeyDown(object sender, KeyEventArgs e)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvAudit.Rows.Count > 0)
                {
                    AuditReportInsertion auditReportInsertion = new AuditReportInsertion();
                    int Status = auditReportInsertion.InsertAuditCalen(this.DgvAudit);
                    if (Status > 0)
                    {
                        DgvAudit.Rows.Cast<DataGridViewRow>().ToList().ForEach(f => f.Cells["Status"].Value = "Saved");
                        CopyDatRow();
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Data Save SuccessFully.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _isFirstLoad = true;
                    }
                    else
                    {
                        //XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Data Save UnSuccessFully..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CopyDatRow()
        {
            // if (DgvViewCalendar.Rows.Count <= 0)
            {
                try
                {
                    for (int i = 0; i < DgvAudit.Rows.Count; i++)
                    {
                        //DataGridViewRow dr = new DataGridViewRow();
                        //DgvViewCalendar.Rows.Add(dr);
                        //int RowsIndex = this.DgvViewCalendar.Rows.Count - 1;
                        // DgvViewCalendar.Rows[RowsIndex].Cells["SrNo"].Value = DgvAudit.Rows[i].Cells["SrNo"].Value.ToString();
                        // DgvViewCalendar.Rows[RowsIndex].Cells["AuditCode"].Value = DgvAudit.Rows[i].Cells["AuditCode"].Value.ToString();
                        // DgvViewCalendar.Rows[RowsIndex].Cells["NameofAudit"].Value = DgvAudit.Rows[i].Cells["NameofAudit"].Value.ToString();
                        // DgvViewCalendar.Rows[RowsIndex].Cells["TypeofAudit"].Value = DgvAudit.Rows[i].Cells["TypeofAudit"].Value.ToString();
                        // DgvViewCalendar.Rows[RowsIndex].Cells["Area"].Value =               DgvAudit.Rows[i].Cells["Area"].Value.ToString();
                        // DgvViewCalendar.Rows[RowsIndex].Cells["ProcessName"].Value= DgvAudit.Rows[i].Cells["ProcessName"].Value.ToString();
                        // DgvViewCalendar.Rows[RowsIndex].Cells["Frequency"].Value= DgvAudit.Rows[i].Cells["Frequency"].Value.ToString();
                        // DgvViewCalendar.Rows[RowsIndex].Cells["LastDate"].Value = DgvAudit.Rows[i].Cells["LastDate"].Value.ToString();
                        // DgvViewCalendar.Rows[RowsIndex].Cells["NextDate"].Value = DgvAudit.Rows[i].Cells["NextDate"].Value.ToString();
                        // DgvViewCalendar.Rows[RowsIndex].Cells["Department"].Value = DgvAudit.Rows[i].Cells["Department"].Value.ToString();
                        // DgvViewCalendar.Rows[RowsIndex].Cells["Individual"].Value= DgvAudit.Rows[i].Cells["Individual"].Value.ToString();
                        // DgvViewCalendar.Rows[RowsIndex].Cells["AuditOwner"].Value= DgvAudit.Rows[i].Cells["AuditOwner"].Value.ToString();
                        // DgvViewCalendar.Rows[RowsIndex].Cells["Reviewedby"].Value= DgvAudit.Rows[i].Cells["Reviewedby"].Value.ToString();
                        //DgvViewCalendar.Rows[RowsIndex].Cells["Approvedby"] .Value= DgvAudit.Rows[i].Cells["Approvedby"].Value.ToString();                       

                        DataRow[] Dr = MapColumn.Select("[Audit Code]='" + DgvAudit.Rows[i].Cells["AuditCode"].Value.ToString() + "'");
                        if (Dr.Length > 0)
                        {
                            Dr[0]["Name of Audit"] = DgvAudit.Rows[i].Cells["NameofAudit"].Value.ToString();
                            Dr[0]["Type of Audit"] = DgvAudit.Rows[i].Cells["TypeofAudit"].Value.ToString();
                            Dr[0]["Area"] = DgvAudit.Rows[i].Cells["Area"].Value.ToString();
                            Dr[0]["Process Name"] = DgvAudit.Rows[i].Cells["ProcessName"].Value.ToString();
                            Dr[0]["Frequency"] = DgvAudit.Rows[i].Cells["Frequency"].Value.ToString();
                            Dr[0]["Last Date"] = DgvAudit.Rows[i].Cells["LastDate"].Value.ToString();
                            Dr[0]["Next Date"] = DgvAudit.Rows[i].Cells["NextDate"].Value.ToString();
                            Dr[0]["Department"] = DgvAudit.Rows[i].Cells["Department"].Value.ToString();
                            Dr[0]["Individual"] = DgvAudit.Rows[i].Cells["Individual"].Value.ToString();
                            Dr[0]["Audit Owner"] = DgvAudit.Rows[i].Cells["AuditOwner"].Value.ToString();
                            Dr[0]["Approved by"] = DgvAudit.Rows[i].Cells["Approvedby"].Value.ToString();
                            Dr[0]["Reviewed by"] = DgvAudit.Rows[i].Cells["Reviewedby"].Value.ToString();
                        }
                        else
                        {
                            DataRow dr = MapColumn.NewRow();
                            dr["SrNo"] = DgvAudit.Rows[i].Cells["SrNo"].Value.ToString();
                            dr["Audit Code"] = DgvAudit.Rows[i].Cells["AuditCode"].Value.ToString();
                            dr["Name of Audit"] = DgvAudit.Rows[i].Cells["NameofAudit"].Value.ToString();
                            dr["Type of Audit"] = DgvAudit.Rows[i].Cells["TypeofAudit"].Value.ToString();
                            dr["Area"] = DgvAudit.Rows[i].Cells["Area"].Value.ToString();
                            dr["Process Name"] = DgvAudit.Rows[i].Cells["ProcessName"].Value.ToString();
                            dr["Frequency"] = DgvAudit.Rows[i].Cells["Frequency"].Value.ToString();
                            dr["Last Date"] = DgvAudit.Rows[i].Cells["LastDate"].Value.ToString();
                            dr["Next Date"] = DgvAudit.Rows[i].Cells["NextDate"].Value.ToString();
                            dr["Department"] = DgvAudit.Rows[i].Cells["Department"].Value.ToString();
                            dr["Individual"] = DgvAudit.Rows[i].Cells["Individual"].Value.ToString();
                            dr["Audit Owner"] = DgvAudit.Rows[i].Cells["AuditOwner"].Value.ToString();
                            dr["Reviewed by"] = DgvAudit.Rows[i].Cells["Reviewedby"].Value.ToString();
                            dr["Approved by"] = DgvAudit.Rows[i].Cells["Approvedby"].Value.ToString();
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

        #region Audit Calendar Upload Method Info
        private DataSet ds;
        private void SelectTable()
        {
            var tablename = sheetCombo.SelectedItem.ToString();
            GetValues(ds, tablename);
        }
        public void DisableControl()
        {
            if (GlobalDeclaration.UserType.Equals("U1-Maintenance") || GlobalDeclaration.UserType.Equals("U1-Safety") || GlobalDeclaration.UserType.Equals("U1-Operation"))
            {
                this.groupBox1.Visible = false;
                //* 19/08/22
                ////this.panel3.Height = this.panel3.Height + this.groupBox1.Height;
                ////this.panel3.Location = new Point(3, 280);
            }
        }
        public void GetValues(DataSet dataset, string sheetName)
        {
            try
            {
                if (GlobalDeclaration.UserType.Equals("U1-Maintenance") || GlobalDeclaration.UserType.Equals("U1-Safety") || GlobalDeclaration.UserType.Equals("U1-Operation")) return;
                if (DgvAudit.Columns.Count > 0)
                {
                    DgvAudit.Columns["NextDate"].ReadOnly = true;
                    for (int i = 0; i < dataset.Tables[sheetName].Rows.Count; i++)
                    {
                        DataRow row = dataset.Tables[sheetName].Rows[i];
                        DataGridViewRow dr = new DataGridViewRow();
                        DgvAudit.Rows.Add(dr);
                        int RowsIndex = this.DgvAudit.Rows.Count - 1;
                        int Serialnumber = 0;
                        DgvAudit.Rows[RowsIndex].Cells["AuditCode"].Value = GenerateAuditCode(DgvAudit.Rows.Count, ref Serialnumber);
                        DgvAudit.Rows[RowsIndex].Cells["SrNo"].Value = Serialnumber;
                        DgvAudit.Rows[RowsIndex].Cells["Status"].Value = "New";
                        DgvAudit.Rows[RowsIndex].Cells["NameofAudit"].Value = row["Name of Audit"];
                        DgvAudit.Rows[RowsIndex].Cells["TypeofAudit"].Value = row["Type of Audit"];
                        DgvAudit.Rows[RowsIndex].Cells["Area"].Value = row["Audit Area"];
                        DgvAudit.Rows[RowsIndex].Cells["ProcessName"].Value = row["Process Name"];
                        DgvAudit.Rows[RowsIndex].Cells["Frequency"].Value = row["Frequency"];
                        DgvAudit.Rows[RowsIndex].Cells["LastDate"].Value = row["Last Date Of Audit"];
                        DgvAudit.Rows[RowsIndex].Cells["Department"].Value = row["Department"];
                        DgvAudit.Rows[RowsIndex].Cells["Individual"].Value = row["Individual"];
                        DgvAudit.Rows[RowsIndex].Cells["AuditOwner"].Value = row["Audit Owner"];
                        DgvAudit.Rows[RowsIndex].Cells["Reviewedby"].Value = row["Reviewed by"];
                        DgvAudit.Rows[RowsIndex].Cells["Approvedby"].Value = row["Approved by"];
                    }
                    //Datechange();
                    //DgvMaitenance.CellFormatting += Dgventry_CellFormatting;                              
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true }, "Can't Upload Same Sheet Data, Plese try Another?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    XtraMessageBox.Show("Can't Upload Same Sheet Data, Plese try Another?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (DgvAudit.Columns.Count > 0)
            {
                txtfile.Text = obd.FileName;
                //txtfile.ReadOnly = true;
            }
        }
        #endregion
        private void DgvAudit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 4 && e.RowIndex > -1)
            //{
            //    AreaSelection _area = new AreaSelection();
            //    if (_area.ShowDialog() == DialogResult.OK)
            //    {

            //    }
            //    _area.Dispose();

            //}
        }

        bool _isFirstLoad;
        int ReceiveCount = 0;
        private void DgvAudit_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!_isFirstLoad) return;
                if (DgvAudit.Rows.Count > 0)
                {
                    foreach (DataGridViewRow rw in this.DgvAudit.Rows)
                    {
                        for (int i = 0; i < rw.Cells.Count; i++)
                        {
                            if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                            {
                                return;
                            }
                        }
                    }
                    int coumnindex = this.DgvAudit.CurrentCell.ColumnIndex;
                    int rowsindex = this.DgvAudit.CurrentCell.RowIndex;
                    string updatequery = @"update InternAuditCalendarTBL set " + DgvAudit.Columns[coumnindex].Name.Trim() + "='" + DgvAudit.Rows[e.RowIndex].Cells[coumnindex].Value.ToString() + "' where AuditCode='" + DgvAudit.Rows[e.RowIndex].Cells["AuditCode"].Value.ToString() + "'";
                    int r = Resources.Instance.SaveMaintenenceData(updatequery);
                    if (r > 0)
                    {
                        DataRow[] Dr = MapColumn.Select("[Audit Code]='" + DgvAudit.Rows[e.RowIndex].Cells["AuditCode"].Value.ToString() + "'");
                        if (Dr.Length > 0)
                        {
                            Dr[0]["Name of Audit"] = DgvAudit.Rows[e.RowIndex].Cells["NameofAudit"].Value.ToString();
                            Dr[0]["Type of Audit"] = DgvAudit.Rows[e.RowIndex].Cells["TypeofAudit"].Value.ToString();
                            Dr[0]["Area"] = DgvAudit.Rows[e.RowIndex].Cells["Area"].Value.ToString();
                            Dr[0]["Process Name"] = DgvAudit.Rows[e.RowIndex].Cells["ProcessName"].Value.ToString();
                            Dr[0]["Frequency"] = DgvAudit.Rows[e.RowIndex].Cells["Frequency"].Value.ToString();
                            Dr[0]["Last Date"] = DgvAudit.Rows[e.RowIndex].Cells["LastDate"].Value.ToString();
                            Dr[0]["Next Date"] = DgvAudit.Rows[e.RowIndex].Cells["NextDate"].Value.ToString();
                            Dr[0]["Department"] = DgvAudit.Rows[e.RowIndex].Cells["Department"].Value.ToString();
                            Dr[0]["Individual"] = DgvAudit.Rows[e.RowIndex].Cells["Individual"].Value.ToString();
                            Dr[0]["Audit Owner"] = DgvAudit.Rows[e.RowIndex].Cells["AuditOwner"].Value.ToString();
                            Dr[0]["Approved by"] = DgvAudit.Rows[e.RowIndex].Cells["Approvedby"].Value.ToString();
                            Dr[0]["Reviewed by"] = DgvAudit.Rows[e.RowIndex].Cells["Reviewedby"].Value.ToString();
                        }
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Cell Update SuccessFully..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvAudit_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // e.Cancel = true;
        }
        private void DgvAudit_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SetComboBoxCellType objChangeCellType = new SetComboBoxCellType(ChangeCellToComboBox);
                if (e.ColumnIndex == this.DgvAudit.Columns["TypeofAudit"].Index)
                {
                    this.DgvAudit.BeginInvoke(objChangeCellType, e.RowIndex, "TypeofAudit", e.ColumnIndex);
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DgvAudit.Columns["Area"].Index)
                {
                    this.DgvAudit.BeginInvoke(objChangeCellType, e.RowIndex, "area", e.ColumnIndex);
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DgvAudit.Columns["Frequency"].Index)
                {
                    this.DgvAudit.BeginInvoke(objChangeCellType, e.RowIndex, "Freqncy", e.ColumnIndex);
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DgvAudit.Columns["Individual"].Index)
                {
                    this.DgvAudit.BeginInvoke(objChangeCellType, e.RowIndex, "Individual", e.ColumnIndex);
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DgvAudit.Columns["Department"].Index)
                {
                    this.DgvAudit.BeginInvoke(objChangeCellType, e.RowIndex, "DeptName", e.ColumnIndex);
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DgvAudit.Columns["Auditowner"].Index)
                {
                    this.DgvAudit.BeginInvoke(objChangeCellType, e.RowIndex, "Auditowner", e.ColumnIndex);
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DgvAudit.Columns["Reviewedby"].Index)
                {
                    this.DgvAudit.BeginInvoke(objChangeCellType, e.RowIndex, "Reviewedby", e.ColumnIndex);
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DgvAudit.Columns["Approvedby"].Index)
                {
                    this.DgvAudit.BeginInvoke(objChangeCellType, e.RowIndex, "Approvedby", e.ColumnIndex);
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
                        if (DgvAudit.Rows[iRowIndex].Cells[DgvAudit.CurrentCell.ColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgvCombotypeaudit = new DataGridViewComboBoxCell();
                        dgvCombotypeaudit.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgvCombotypeaudit.DataSource = Resources.Instance.TypeOfAuditDT.Copy();
                        dgvCombotypeaudit.ValueMember = "TypeOfAudit";
                        dgvCombotypeaudit.DisplayMember = "TypeOfAudit";
                        DgvAudit.Rows[iRowIndex].Cells[DgvAudit.CurrentCell.ColumnIndex] = dgvCombotypeaudit;
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "area")
                    {
                        if (DgvAudit.Rows[iRowIndex].Cells[DgvAudit.CurrentCell.ColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell DgvArea = new DataGridViewComboBoxCell();
                        DgvArea.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        DgvArea.DataSource = Resources.Instance.AreaOwner.Copy();
                        DgvArea.ValueMember = "NameOfArea";
                        DgvArea.DisplayMember = "NameOfArea";
                        DgvAudit.Rows[iRowIndex].Cells[DgvAudit.CurrentCell.ColumnIndex] = DgvArea;
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "Freqncy")
                    {
                        if (DgvAudit.Rows[iRowIndex].Cells[DgvAudit.CurrentCell.ColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgComboCellPrioty = new DataGridViewComboBoxCell();
                        dgComboCellPrioty.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Name", typeof(string));
                        string[] ArrayList = { "Daily", "Monthly", "Quaterly", "Half-Yearly", "Yearly" };
                        for (int i = 0; i < ArrayList.Length; i++)
                        {
                            DataRow dr = dt.NewRow();
                            dr["Name"] = ArrayList[i].ToString();
                            dt.Rows.Add(dr);
                        }
                        dgComboCellPrioty.DataSource = dt;
                        dgComboCellPrioty.ValueMember = "Name";
                        dgComboCellPrioty.DisplayMember = "Name";
                        DgvAudit.Rows[iRowIndex].Cells[DgvAudit.CurrentCell.ColumnIndex] = dgComboCellPrioty;
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "Individual")
                    {
                        if (DgvAudit.Rows[iRowIndex].Cells[DgvAudit.CurrentCell.ColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgvComboIDeptName = new DataGridViewComboBoxCell();
                        dgvComboIDeptName.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgvComboIDeptName.DataSource = Resources.Instance._EmpName.Copy();
                        dgvComboIDeptName.ValueMember = "emp_name";
                        dgvComboIDeptName.DisplayMember = "emp_name";
                        DgvAudit.Rows[iRowIndex].Cells[DgvAudit.CurrentCell.ColumnIndex] = dgvComboIDeptName;
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "DeptName")
                    {
                        if (DgvAudit.Rows[iRowIndex].Cells[DgvAudit.CurrentCell.ColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgvComboDeptName = new DataGridViewComboBoxCell();
                        dgvComboDeptName.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgvComboDeptName.DataSource = Resources.Instance.DepartmentMaster.Copy();
                        dgvComboDeptName.ValueMember = "DepartName";
                        dgvComboDeptName.DisplayMember = "DepartName";
                        DgvAudit.Rows[iRowIndex].Cells[DgvAudit.CurrentCell.ColumnIndex] = dgvComboDeptName;
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "Auditowner")
                    {
                        if (DgvAudit.Rows[iRowIndex].Cells[DgvAudit.CurrentCell.ColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgvComboAuditowner = new DataGridViewComboBoxCell();
                        dgvComboAuditowner.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgvComboAuditowner.DataSource = Resources.Instance._EmpName.Copy();
                        dgvComboAuditowner.ValueMember = "emp_name";
                        dgvComboAuditowner.DisplayMember = "emp_name";
                        DgvAudit.Rows[iRowIndex].Cells[DgvAudit.CurrentCell.ColumnIndex] = dgvComboAuditowner;
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "Reviewedby")
                    {
                        if (DgvAudit.Rows[iRowIndex].Cells[DgvAudit.CurrentCell.ColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgvComboReviewedby = new DataGridViewComboBoxCell();
                        dgvComboReviewedby.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgvComboReviewedby.DataSource = Resources.Instance._EmpName.Copy();
                        dgvComboReviewedby.ValueMember = "emp_name";
                        dgvComboReviewedby.DisplayMember = "emp_name";
                        DgvAudit.Rows[iRowIndex].Cells[DgvAudit.CurrentCell.ColumnIndex] = dgvComboReviewedby;
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "Approvedby")
                    {
                        if (DgvAudit.Rows[iRowIndex].Cells[DgvAudit.CurrentCell.ColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgvComboApprovedby = new DataGridViewComboBoxCell();
                        dgvComboApprovedby.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgvComboApprovedby.DataSource = Resources.Instance._EmpName.Copy();
                        dgvComboApprovedby.ValueMember = "emp_name";
                        dgvComboApprovedby.DisplayMember = "emp_name";
                        DgvAudit.Rows[iRowIndex].Cells[DgvAudit.CurrentCell.ColumnIndex] = dgvComboApprovedby;
                        bIsComboBox = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int holdRowIndex = 0;
        private void DgvAudit_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3 && e.RowIndex >= 0)
                {
                    if (DgvAudit.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null) return;
                    string Value = DgvAudit.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    if (Value == "AddMore")
                    {
                        AuditTypeAddFrm NewTypeObj = new AuditTypeAddFrm();
                        NewTypeObj.updateAuditTypeHandler += KeySafetyHandlerEvent;
                        //NewTypeObj.Show();
                        if (NewTypeObj.ShowDialog() == DialogResult.OK)
                        {
                            DgvAudit.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = NewTypeObj.txtAddAudit.Text;
                            NewTypeObj.txtAddAudit.Text = "";
                            NewTypeObj.Close();
                            if (DgvAudit.IsCurrentCellDirty)
                            {
                                DgvAudit.CommitEdit(DataGridViewDataErrorContexts.Commit);
                            }
                        }
                        else
                        {
                            DgvAudit.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Safety";
                        }
                    }
                }
                else if (e.ColumnIndex == 7 && e.RowIndex >= 0)
                {
                    ChangeNextDate(e.RowIndex, e.ColumnIndex);

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void KeySafetyHandlerEvent(object sender, string c)
        {
            try
            {
                //if (TypeOfAuditDT.Rows.Count > 0)
                //    TypeOfAuditDT.Rows.Clear();

                //TypeOfAuditDT = Resources.Instance.GetDataKey("Sp_FetTypeOfAuditMasterKey");
                //holdRowIndex = -1;

                DataRow[] Rows = Resources.Instance.TypeOfAuditDT.Select("TypeOfAudit='" + c + "'");
                if (Rows.Length <= 0)
                {
                    DataRow dataRow = Resources.Instance.TypeOfAuditDT.NewRow();
                    dataRow["TypeofAudit"] = c;
                    Resources.Instance.TypeOfAuditDT.Rows.Add(dataRow);
                }
                //DgvAudit.Rows[holdRowIndex].Cells["TypeofAudit"].ReadOnly = true;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ChangeNextDate(int IRowIndex, int ColomIndex)
        {
            try
            {
                string Value = DgvAudit.Rows[IRowIndex].Cells["Frequency"].Value.ToString();
                string dt = string.Empty;
                DateTime FindValue = DateTime.Now;
                DateTime FinalDate = DateTime.Now;
                switch (Value)
                {
                    case "Daily":
                        dt = Convert.ToDateTime(DgvAudit.Rows[IRowIndex].Cells[ColomIndex].Value.ToString()).ToShortDateString();
                        FinalDate = Convert.ToDateTime(dt);
                        FindValue = Convert.ToDateTime(FinalDate.AddDays(1).ToString("yyyy-MM-dd"));
                        break;
                    case "Monthly":
                        dt = Convert.ToDateTime(DgvAudit.Rows[IRowIndex].Cells[ColomIndex].Value.ToString()).ToShortDateString();
                        FinalDate = Convert.ToDateTime(dt);
                        FindValue = Convert.ToDateTime(FinalDate.AddMonths(1).ToString("yyyy-MM-dd"));
                        break;
                    case "Quaterly":
                        dt = Convert.ToDateTime(DgvAudit.Rows[IRowIndex].Cells[ColomIndex].Value.ToString()).ToShortDateString();
                        FinalDate = Convert.ToDateTime(dt);
                        FindValue = Convert.ToDateTime(FinalDate.AddMonths(3).ToString("yyyy-MM-dd"));
                        break;
                    case "Half-Yearly":
                        dt = Convert.ToDateTime(DgvAudit.Rows[IRowIndex].Cells[ColomIndex].Value.ToString()).ToShortDateString();
                        FinalDate = Convert.ToDateTime(dt);
                        FindValue = Convert.ToDateTime(FinalDate.AddMonths(6).ToString("yyyy-MM-dd"));
                        break;
                    case "Yearly":
                        dt = Convert.ToDateTime(DgvAudit.Rows[IRowIndex].Cells[ColomIndex].Value.ToString()).ToShortDateString();
                        FinalDate = Convert.ToDateTime(dt);
                        FindValue = Convert.ToDateTime(FinalDate.AddYears(1).ToString("yyyy-MM-dd"));
                        break;
                }
                DgvAudit.Rows[IRowIndex].Cells["NextDate"].Value = FindValue;
                DgvAudit.Columns["NextDate"].ReadOnly = true;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void DgvAudit_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DgvAudit.IsCurrentCellDirty)
            {
                DgvAudit.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DgvAudit_Scroll(object sender, ScrollEventArgs e)
        {
            if (LastDateTimePicker != null)
                LastDateTimePicker.Visible = false;
        }
    }
}
