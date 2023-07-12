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
    public partial class ActionableFrm : XtraForm
    {
        delegate void SetComboBoxCellType(int iRowIndex, int ColumnIndex, string clmname);
        private bool bIsComboBox;
        private bool _IsUpdateCellCAPA;
        public bool IsCalling;
        private DataTable EmployeeCode = new DataTable();
        public ActionableFrm()
        {
            InitializeComponent();
            this.Text = "Actionable Information";
            UpdateTextPosition();
        }

        private void ActionableFrm_Load(object sender, EventArgs e)
        {
            if (IsCalling)
            {
                ViewData();
                GrpActinale.Visible = false;
                Xtrtblctrl.Visible = true;
                btncreateCapa.Visible = false;
                Size sixe = new Size(this.Size.Width, this.Size.Height - (GrpActinale.Size.Height + btncreateCapa.Height));
                this.Size = sixe;
                Xtrtblctrl.Location = GrpActinale.Location;
                btnSave.Visible = false;
            }
            else
            {
                Xtrtblctrl.Visible = false;
                HightAdjust(false);
            }
            GridSeeting();
        }
        private void HightAdjust(bool Sts)
        {
            EmployeeCode = Resources.Instance.GetDataKey("SP_GetEmployeeName");
            if (Sts)
            {
                Size sixe = new Size(this.Size.Width, this.Size.Height + (Xtrtblctrl.Size.Height + btncreateCapa.Height));
                this.Size = sixe;
            }
            else
            {
                Size sixe = new Size(this.Size.Width, this.Size.Height - (Xtrtblctrl.Size.Height + btncreateCapa.Height));
                this.Size = sixe;
            }
        }
        private void GridSeeting()
        {
            try
            {
                DgvSafetyJob.BorderStyle = BorderStyle.Fixed3D;

                DgvSafetyJob.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                DgvSafetyJob.AllowUserToResizeColumns = false;

                DgvSafetyJob.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


                DgvSafetyJob.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;

                // Set the selection background color for all the cells.
                // DgvBrk.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                DgvSafetyJob.DefaultCellStyle.SelectionForeColor = Color.Black;

                // Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default
                // value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
                //DgvStatus.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty;

                // Set the background color for all rows and for alternating rows. 
                // The value for alternating rows overrides the value for all rows. 
                DgvSafetyJob.RowsDefaultCellStyle.BackColor = Color.LightGray;
                DgvSafetyJob.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
                DgvSafetyJob.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvSafetyJob.SelectedRows.Count > 0)
                {
                    if (DgvSafetyJob.SelectedRows[0].DefaultCellStyle.ForeColor != Color.Green)
                    {
                        string value = DgvSafetyJob.SelectedRows[0].Cells["MachineTag"].Value.ToString() + "~" +
                            DgvSafetyJob.SelectedRows[0].Cells["MachineName"].Value.ToString() + "~" + DgvSafetyJob.SelectedRows[0].Cells["ObjRslt"].Value.ToString() +
                            "~" + DgvSafetyJob.SelectedRows[0].Cells["Criticality"].Value.ToString() + "~" + DgvSafetyJob.SelectedRows[0].Cells["Immdcause"].Value.ToString() +
                            "~" + DgvSafetyJob.SelectedRows[0].Cells["RootCause"].Value.ToString() + "~" + DgvSafetyJob.SelectedRows[0].Cells["CorrectiveAction"].Value.ToString() +
                            "~" + DgvSafetyJob.SelectedRows[0].Cells["Reason"].Value.ToString() + "~" + DgvSafetyJob.SelectedRows[0].Cells["PreventiveAct"].Value.ToString() +
                            "~" + DgvSafetyJob.SelectedRows[0].Cells["Responsibility0"].Value.ToString() + "~" +
                            DgvSafetyJob.SelectedRows[0].Cells["Responsibility1"].Value.ToString() +
                            "~" + DgvSafetyJob.SelectedRows[0].Cells["Escalation"].Value.ToString() + "~" + GlobalDeclaration._holdInfo[0].UserName + "~" +
                             GlobalDeclaration._holdInfo[0].UserId.ToString() + "~" + GlobalDeclaration._holdInfo[0].EmpCode;
                        int Sts = Resources.Instance.insertMasterrecord("Sp_UpdateBreakDownColumn", "@MachineTagNo", "@MachineName", "@Result", "@Criticality", "@ImmediateCause", "@RootCause", "@CAction", "@Reason", "@PAction", "@Responsibility0", "@Responsibility1", "@Escalation", "@empid", "@empname", "@empcode", value);
                        if (Sts > 0)
                        {
                            XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Information Save Successfully.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DgvSafetyJob.SelectedRows[0].DefaultCellStyle.ForeColor = Color.Green;
                        }
                        else
                        {
                            XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Error in Information?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, " This Information Already Save.\n Please Try Another?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DgvSafetyJob_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                switch (e.ColumnIndex)
                {

                }
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
                DataTable _dataTable = Resources.Instance.GetDataKey("Sp_FetchViewBrkDwnMachineInfo", "@userid", "@username", "@empcode",
                      GlobalDeclaration._holdInfo[0].UserId.ToString(), GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].EmpCode);
                if (_dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < _dataTable.Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        DgvSafetyJob.Rows.Add(dr);
                        int rowidex = this.DgvSafetyJob.Rows.Count - 1;
                        DgvSafetyJob.Rows[rowidex].Cells["MachineTag"].Value = _dataTable.Rows[i]["MachineTagNo"].ToString();
                        DgvSafetyJob.Rows[rowidex].Cells["MachineName"].Value = _dataTable.Rows[i]["MachineName"].ToString();
                        DgvSafetyJob.Rows[rowidex].Cells["ObjObserv"].Value = _dataTable.Rows[i]["BriefDesc"].ToString();
                        DgvSafetyJob.Rows[rowidex].Cells["ObjRslt"].Value = _dataTable.Rows[i]["Result"].ToString();
                        DgvSafetyJob.Rows[rowidex].Cells["Immdcause"].Value = _dataTable.Rows[i]["Immdcause"].ToString();
                        DgvSafetyJob.Rows[rowidex].Cells["Criticality"].Value = _dataTable.Rows[i]["Criticality"].ToString();
                        DgvSafetyJob.Rows[rowidex].Cells["RootCause"].Value = _dataTable.Rows[i]["RootCause"].ToString();
                        DgvSafetyJob.Rows[rowidex].Cells["CorrectiveAction"].Value = _dataTable.Rows[i]["CorrectiveAction"].ToString();
                        DgvSafetyJob.Rows[rowidex].Cells["Reason"].Value = _dataTable.Rows[i]["Reason"].ToString();
                        DgvSafetyJob.Rows[rowidex].Cells["PreventiveAct"].Value = _dataTable.Rows[i]["PreventiveAct"].ToString();
                        DgvSafetyJob.Rows[rowidex].Cells["Responsibility0"].Value = _dataTable.Rows[i]["Responsibility0"].ToString();
                        DgvSafetyJob.Rows[rowidex].Cells["Responsibility1"].Value = _dataTable.Rows[i]["Responsibility1"].ToString();
                        DgvSafetyJob.Rows[rowidex].Cells["Escalation"].Value = _dataTable.Rows[i]["Escalation"].ToString();
                        DgvSafetyJob.Rows[rowidex].DefaultCellStyle.ForeColor = Color.Green;
                    }
                    DgvSafetyJob.ReadOnly = true;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadCapaData()
        {
            try
            {
                DataTable _dataTable = Resources.Instance.GetDataKey("Sp_FetchPlaningMachineInfo", "@userid", "@username", "@empcode",
                GlobalDeclaration._holdInfo[0].UserId.ToString(), GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].EmpCode);
                if (_dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < _dataTable.Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        DgvSafetyJob.Rows.Add(dr);
                        int rowidex = this.DgvSafetyJob.Rows.Count - 1;
                        // if (string.IsNullOrEmpty(_dataTable.Rows[i]["Result"].ToString()))
                        {
                            DgvSafetyJob.Rows[rowidex].Cells["MachineTag"].Value = _dataTable.Rows[i]["MachineTag"].ToString();
                            DgvSafetyJob.Rows[rowidex].Cells["MachineName"].Value = _dataTable.Rows[i]["MachineName"].ToString();
                            DgvSafetyJob.Rows[rowidex].Cells["ObjObserv"].Value = _dataTable.Rows[i]["BriefDesc"].ToString();
                        }
                        //else
                        //{
                        //    DgvSafetyJob.Rows[rowidex].Cells["MachineTag"].Value = _dataTable.Rows[i]["MachineTagNo"].ToString();
                        //    DgvSafetyJob.Rows[rowidex].Cells["MachineName"].Value = _dataTable.Rows[i]["MachineName"].ToString();
                        //    DgvSafetyJob.Rows[rowidex].Cells["ObjObserv"].Value = _dataTable.Rows[i]["BriefDesc"].ToString();
                        //    DgvSafetyJob.Rows[rowidex].Cells["ObjRslt"].Value = _dataTable.Rows[i]["Result"].ToString();
                        //    DgvSafetyJob.Rows[rowidex].Cells["Immdcause"].Value = _dataTable.Rows[i]["Immdcause"].ToString();
                        //    DgvSafetyJob.Rows[rowidex].Cells["Criticality"].Value = _dataTable.Rows[i]["Criticality"].ToString();
                        //    DgvSafetyJob.Rows[rowidex].Cells["RootCause"].Value = _dataTable.Rows[i]["RootCause"].ToString();
                        //    DgvSafetyJob.Rows[rowidex].Cells["CorrectiveAction"].Value = _dataTable.Rows[i]["CorrectiveAction"].ToString();
                        //    DgvSafetyJob.Rows[rowidex].Cells["Reason"].Value = _dataTable.Rows[i]["Reason"].ToString();
                        //    DgvSafetyJob.Rows[rowidex].Cells["PreventiveAct"].Value = _dataTable.Rows[i]["PreventiveAct"].ToString();
                        //    DgvSafetyJob.Rows[rowidex].Cells["Responsibility0"].Value = _dataTable.Rows[i]["Responsibility0"].ToString();
                        //    DgvSafetyJob.Rows[rowidex].Cells["Responsibility1"].Value = _dataTable.Rows[i]["Responsibility1"].ToString();
                        //    DgvSafetyJob.Rows[rowidex].Cells["Escalation"].Value = _dataTable.Rows[i]["Escalation"].ToString();
                        //    DgvSafetyJob.Rows[rowidex].DefaultCellStyle.ForeColor = Color.Green;
                        //    DgvSafetyJob.Rows[rowidex].ReadOnly = true;

                        //}
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvCAPATab_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

            }
            catch (Exception Ex)
            {

                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DgvCAPATab_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SetComboBoxCellType objChangeCellType = new SetComboBoxCellType(ChangeCellToComboBox);
                if (e.ColumnIndex == this.DgvSafetyJob.Columns["ObjRslt"].Index)
                {
                    this.DgvSafetyJob.BeginInvoke(objChangeCellType, e.RowIndex, e.ColumnIndex, "ObjRslt");
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DgvSafetyJob.Columns["Criticality"].Index)
                {
                    this.DgvSafetyJob.BeginInvoke(objChangeCellType, e.RowIndex, e.ColumnIndex, "Criticality");
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DgvSafetyJob.Columns["Responsibility0"].Index)
                {
                    this.DgvSafetyJob.BeginInvoke(objChangeCellType, e.RowIndex, e.ColumnIndex, "Res0");
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DgvSafetyJob.Columns["Responsibility1"].Index)
                {
                    this.DgvSafetyJob.BeginInvoke(objChangeCellType, e.RowIndex, e.ColumnIndex, "Res1");
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DgvSafetyJob.Columns["Escalation"].Index)
                {
                    this.DgvSafetyJob.BeginInvoke(objChangeCellType, e.RowIndex, e.ColumnIndex, "Esc");
                    bIsComboBox = false;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ChangeCellToComboBox(int iRowIndex, int iColumnIndex, string ColumnName)
        {
            try
            {
                if (bIsComboBox == false)
                {
                    if (ColumnName == "ObjRslt")
                    {
                        if (DgvSafetyJob.Rows[iRowIndex].Cells[iColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgvResult = new DataGridViewComboBoxCell();
                        dgvResult.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        DataTable RiskDt = new DataTable();
                        RiskDt.Columns.Add("Name", typeof(string));
                        string[] ArrayList = { "Ok", "Not Ok" };
                        for (int i = 0; i < ArrayList.Length; i++)
                        {
                            DataRow dr = RiskDt.NewRow();
                            dr["Name"] = ArrayList[i].ToString();
                            RiskDt.Rows.Add(dr);
                        }
                        dgvResult.DataSource = RiskDt;
                        dgvResult.ValueMember = "Name";
                        dgvResult.DisplayMember = "Name";
                        DgvSafetyJob[iColumnIndex, iRowIndex] = dgvResult;
                        dgvResult.Dispose();
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "Criticality")
                    {
                        if (DgvSafetyJob.Rows[iRowIndex].Cells[iColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgvcriti = new DataGridViewComboBoxCell();
                        dgvcriti.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        DataTable RiskDt = new DataTable();
                        RiskDt.Columns.Add("Name", typeof(string));
                        string[] ArrayList = { "High", "Low", "Medium" };
                        for (int i = 0; i < ArrayList.Length; i++)
                        {
                            DataRow dr = RiskDt.NewRow();
                            dr["Name"] = ArrayList[i].ToString();
                            RiskDt.Rows.Add(dr);
                        }
                        dgvcriti.DataSource = RiskDt;
                        dgvcriti.ValueMember = "Name";
                        dgvcriti.DisplayMember = "Name";
                        DgvSafetyJob[iColumnIndex, iRowIndex] = dgvcriti;
                        dgvcriti.Dispose();
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "Res0")
                    {
                        if (DgvSafetyJob[iColumnIndex, iRowIndex].Value != null) return;
                        DataGridViewComboBoxCell dgComboCell = new DataGridViewComboBoxCell();
                        dgComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgComboCell.DataSource = EmployeeCode;
                        dgComboCell.ValueMember = "emp_name";
                        dgComboCell.DisplayMember = "emp_name";
                        DgvSafetyJob[iColumnIndex, iRowIndex] = dgComboCell;
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "Res1")
                    {
                        if (DgvSafetyJob[iColumnIndex, iRowIndex].Value != null) return;
                        DataGridViewComboBoxCell dgComboCellPrioty = new DataGridViewComboBoxCell();
                        dgComboCellPrioty.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        // dgComboCellPrioty.ReadOnly = false;                        
                        dgComboCellPrioty.DataSource = EmployeeCode.Copy();
                        dgComboCellPrioty.ValueMember = "emp_name";
                        dgComboCellPrioty.DisplayMember = "emp_name";
                        DgvSafetyJob[iColumnIndex, iRowIndex] = dgComboCellPrioty;
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "Esc")
                    {
                        if (DgvSafetyJob[iColumnIndex, iRowIndex].Value != null) return;
                        DataGridViewComboBoxCell dgvchkbox = new DataGridViewComboBoxCell();
                        dgvchkbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        // dgvchkbox.ReadOnly = false;
                        dgvchkbox.DataSource = EmployeeCode.Copy();
                        dgvchkbox.ValueMember = "emp_name";
                        dgvchkbox.DisplayMember = "emp_name";
                        DgvSafetyJob[iColumnIndex, iRowIndex] = dgvchkbox;
                        bIsComboBox = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvCAPATab_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    //DataGridViewCell cell = DgvSafetyJob.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    //if (e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3|| e.ColumnIndex == 4|| e.ColumnIndex == 5|| e.ColumnIndex == 6|| e.ColumnIndex == 7)
                    //{

                    //    cell.ReadOnly = false;
                    //    DgvCAPATab.CurrentCell = cell;
                    //    DgvCAPATab.BeginEdit(true);

                    //}
                    //else
                    //{
                    //    cell.ReadOnly = true;
                    //    DgvCAPATab.CurrentCell = cell;
                    //    DgvCAPATab.BeginEdit(false);
                    //}
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Xtrtblctrl_Click(object sender, EventArgs e)
        {
            if (int.Parse(Xtrtblctrl.SelectedTab.Tag.ToString()) == 0)
            {
            }
        }

        private void btncreateCapa_Click(object sender, EventArgs e)
        {
            try
            {
                int _Tag = Convert.ToInt32(((Button)sender).Tag);
                switch (_Tag)
                {
                    case 0:
                        {
                            if (DgvSafetyJob.Rows.Count > 0) return;
                            HightAdjust(true);
                            Xtrtblctrl.Visible = true;
                            LoadCapaData();
                        }
                        break;

                    case 5:
                        {
                            if (DgvSafetyJob.SelectedRows.Count > 0)
                            {
                                InventoryAddDetails invt = new InventoryAddDetails(DgvSafetyJob.SelectedRows[0].Cells["MachineTag"].Value.ToString());
                                invt.TopMost = true;
                                if (invt.ShowDialog() == DialogResult.OK)
                                {

                                }
                            }
                            else
                            {
                                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please Select Row First For Inventory.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        break;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
