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
    public partial class HrPlannedTrainingfrm : XtraForm
    {
        delegate void SetComboBoxCellType(int iRowIndex, string clmname, int iColumnIndex);
        private bool bIsComboBox;
        DateTimePicker Set_Date;
        public HrPlannedTrainingfrm()
        {
            InitializeComponent();
            this.Text = "HR Planned Training Details";
            UpdateTextPosition();
            //DgvPlaned.Controls.Add(Set_Date);
            //Set_Date.Visible = false;
            //Set_Date.Format = DateTimePickerFormat.Custom;
            //Set_Date.TextChanged += new EventHandler(Set_date_TextChangedEvnts);
            //Set_Date.CloseUp += new EventHandler(DateTimePickerClose);

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
        private void GridSeeting()
        {
            try
            {
                DgvPlaned.BorderStyle = BorderStyle.Fixed3D;

                DgvPlaned.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                DgvPlaned.AllowUserToResizeColumns = false;

                DgvPlaned.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                DgvPlaned.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;

                DgvPlaned.DefaultCellStyle.SelectionForeColor = Color.Black;
                DgvPlaned.RowsDefaultCellStyle.BackColor = Color.LightGray;
                DgvPlaned.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
                DgvPlaned.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                DgvPlaned.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.ReadOnly = true);

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HrPlannedTrainingfrm_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Resources.Instance.GetDataKey("Sp_FetchHrPlannedData");
                if (dt.Rows.Count > 0)
                {
                    DgvPlaned.DataSource = dt;
                }
                GridSeeting();
                DataGridViewTextBoxColumn Freezedate = new DataGridViewTextBoxColumn();
                Freezedate.Name = "FrzDate";
                Freezedate.HeaderText = "FreezDate";
                DgvPlaned.Columns.Add(Freezedate);
                DgvPlaned.Columns["Venue"].ReadOnly = false;
                DgvPlaned.Columns["Resource"].ReadOnly = false;
                DgvPlaned.Columns["Name_of_Trainer"].ReadOnly = false;
                DgvPlaned.Columns["NameOfAgency"].Visible = false;
                DgvPlaned.Columns["FrzDate"].ReadOnly = false;
                DgvPlaned.Columns["Capability"].ReadOnly = false;
                // DgvPlaned.ReadOnly = false;

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DgvPlaned_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SetComboBoxCellType objChangeCellType = new SetComboBoxCellType(ChangeCellToComboBox);
                if (e.ColumnIndex == this.DgvPlaned.Columns["Capability"].Index)
                {
                    this.DgvPlaned.BeginInvoke(objChangeCellType, e.RowIndex, "Capability", e.ColumnIndex);
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
                    if (ColumnName == "Capability")
                    {
                        DataGridViewComboBoxCell dgComboCell = new DataGridViewComboBoxCell();
                        dgComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Name", typeof(string));
                        string[] ArrayList = { "Internal", "External" };
                        for (int i = 0; i < ArrayList.Length; i++)
                        {
                            DataRow dr = dt.NewRow();
                            dr["Name"] = ArrayList[i].ToString();
                            dt.Rows.Add(dr);
                        }
                        dgComboCell.DataSource = dt;
                        dgComboCell.ValueMember = "Name";
                        dgComboCell.DisplayMember = "Name";
                        DgvPlaned[iColumnIndex, iRowIndex] = dgComboCell;
                        bIsComboBox = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvPlaned_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    switch (DgvPlaned.Columns[e.ColumnIndex].Name)
                    {
                        case "FrzDate":
                        case "Training_Start_date":
                        case "Training_Completion_Date":
                            {
                                if (DgvPlaned.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null) return;
                                Set_Date = new DateTimePicker();  //DateTimePicker 

                                //Adding DateTimePicker control into DataGridView
                                DgvPlaned.Controls.Add(Set_Date);

                                // Intially made it invisible
                                Set_Date.Visible = false;

                                // Setting the format (i.e. 2014-10-10)
                                Set_Date.Format = DateTimePickerFormat.Custom;  //
                                Set_Date.CustomFormat = "yyyy-MM-dd hh:mm:ss";

                                Set_Date.TextChanged += new EventHandler(NextDateTimePicker_OntextChange);

                                // Now make it visible
                                Set_Date.Visible = true;

                                // It returns the retangular area that represents the Display area for a cell
                                Rectangle oRectangle = DgvPlaned.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                                //Setting area for DateTimePicker Control
                                Set_Date.Size = new Size(oRectangle.Width, oRectangle.Height);

                                // Setting Location
                                Set_Date.Location = new Point(oRectangle.X, oRectangle.Y);

                                Set_Date.CloseUp += new EventHandler(NextDateTimePicker_CloseUp);

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
        void NextDateTimePicker_OntextChange(object sender, EventArgs e)
        {
            try
            {
                if (DgvPlaned.Rows.Count > 0)
                    DgvPlaned.CurrentCell.Value = Set_Date.Text.ToString();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void NextDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            Set_Date.Visible = false;
        }

        private void DgvPlaned_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 9 && e.RowIndex > -1) //check if combobox column
                {

                    AddTrainingTtile(e.ColumnIndex, e.RowIndex);
                }
                if (Set_Date != null)
                    Set_Date.Visible = false;

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddTrainingTtile(int columnIndex, int RowsIndex)
        {
            try
            {
                if (DgvPlaned.Rows[RowsIndex].Cells[columnIndex].Value.ToString() == "External")
                {

                    DgvPlaned.Columns["NameOfAgency"].Visible = true;
                    //AddHardwareRFQ vms = new AddHardwareRFQ();
                    //vms.TopMost = true;
                    //vms.Show();
                    DgvPlaned.Rows[RowsIndex].Cells["NameOfAgency"].Value = "VMSTrainer";
                }
                else
                {
                    DgvPlaned.Columns["NameOfAgency"].Visible = false;
                    //XtraMessageBox.Show("Can't Call VMS", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvPlaned_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DgvPlaned.IsCurrentCellDirty)
            {
                DgvPlaned.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvPlaned.SelectedRows.Count > 0)
                {
                    if (DgvPlaned.SelectedRows[0].DefaultCellStyle.ForeColor.Name != Color.LightGreen.Name)
                    {


                        string Value = string.Empty;
                        int sts = 0;
                        Value = DgvPlaned.SelectedRows[0].Cells["SrNo"].Value.ToString() + "_" + DgvPlaned.SelectedRows[0].Cells["EmpName"].Value.ToString() + "_" +
                                DgvPlaned.SelectedRows[0].Cells["DepartMent"].Value.ToString() + "_" +
                                DgvPlaned.SelectedRows[0].Cells["TrainingTitle"].Value.ToString() + "_" + DgvPlaned.SelectedRows[0].Cells["TraingType"].Value.ToString() + "_" +
                                DgvPlaned.SelectedRows[0].Cells["Venue"].Value.ToString() + "_" + DgvPlaned.SelectedRows[0].Cells["Resource"].Value.ToString() + "_" +
                                DgvPlaned.SelectedRows[0].Cells["Name_of_Trainer"].Value.ToString() + "_" + DgvPlaned.SelectedRows[0].Cells["NameOfAgency"].Value.ToString() + "_" +
                                DgvPlaned.SelectedRows[0].Cells["FrzDate"].Value.ToString();
                        sts = Resources.Instance.InsertPlaningInfo("Sp_UpdateHrPlannedData", "@srno", "@empname", "@dptname", "@title", "@tytpe", "@Venue", "@recrc", "@nameoftrn", "@nameofagcy", "@frxDate", Value);
                        if (sts > 0)
                        {
                            XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Approval Send Successfully.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DgvPlaned.SelectedRows[0].DefaultCellStyle.ForeColor = Color.Green;
                        }
                        else
                        {
                            XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Error", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            DgvPlaned.SelectedRows[0].DefaultCellStyle.ForeColor = Color.IndianRed;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "PLease Select Another Color Row For Update.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "PLease Select Any Row First Then Update.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvPlaned_Scroll(object sender, ScrollEventArgs e)
        {
            if (Set_Date != null)
            {
                Set_Date.Visible = false;
            }
        }

        private void DgvPlaned_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Set_Date != null)
                Set_Date.Visible = false;
        }

        //private void DgvPlaned_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{
        //    e.Cancel = true;
        //}
    }
}
