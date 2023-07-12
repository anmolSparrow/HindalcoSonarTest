using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using HindalcoiOS.Dynamic_Form;
using SparrowRMS;
using System;
using System.Collections.Concurrent;
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
    public partial class TrainingFrm : XtraForm
    {
        private string sts = string.Empty;
        public string CallingMCDTRN
        {
            get; set;
        }
        delegate void SetComboBoxCellType(int iRowIndex, string clmname, int iColumnIndex);
        public ConcurrentDictionary<string, MapEmployeeRating> _holdEmpRating = new ConcurrentDictionary<string, MapEmployeeRating>();
        private bool bIsComboBox;
        public TrainingFrm(string TtileName)
        {
            InitializeComponent();
            sts = TtileName;
            if (sts == "UpcomingTrainer" || sts == "CloseTraining")
            {
                this.Text = TtileName + " " + "Information";
            }
            else
            {
                this.Text = TtileName + " " + "Training Information";
            }

            UpdateTextPosition();
        }
        private void TrainingFrm_Load(object sender, EventArgs e)
        {
            GridSeeting();
            if (string.IsNullOrEmpty(CallingMCDTRN))
            {
                LoadData(false);
            }
            else
            {
                LoadData(true);
            }

            checkedListBox1.Visible = false;
        }
        public void GenerateDynamicClm(bool _isComp = false)
        {
            try
            {
                if (_isComp)
                {
                    DataGridViewTextBoxColumn _dynmclm = new DataGridViewTextBoxColumn();
                    _dynmclm.Name = "RsltComp";
                    _dynmclm.HeaderText = "Results of Completed Training";
                    DgvLoadDetails.Columns.Add(_dynmclm);
                    for (int i = 0; i < _dataTable.Rows.Count; i++)
                    {
                        DgvLoadDetails.Rows[i].Cells["RsltComp"].Value = _dataTable.Rows[i]["EmployeeRating"];
                    }
                    if (DgvLoadDetails.Rows.Count <= 0)
                    {
                        DgvLoadDetails.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.Visible = false);
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        DataTable _dataTable = null;
        public void LoadData(bool CallLocatopn)
        {
            try
            {
                switch (sts)
                {
                    case "UpComing":
                    case "Pending":
                    case "Complete":
                        if (CallLocatopn)
                        {
                            _dataTable = Resources.Instance.GetDataKey("Sp_FetchTrainingInfo", "@stas", sts, "@empname", CallingMCDTRN);
                        }
                        else
                        {
                            _dataTable = Resources.Instance.GetDataKey("Sp_FetchTrainingInfo", "@stas", sts, "@empname", GlobalDeclaration._holdInfo[0].UserName);
                        }
                        break;
                    case "MyTeamUpcoming":
                    case "MyTeampending":
                    case "MyTeamComplete":
                        if (string.IsNullOrEmpty(GlobalDeclaration._holdInfo[0].UserTeam))
                        {
                            if (sts == "MyTeamComplete")
                            {
                                _dataTable = Resources.Instance.GetDataKey("Sp_FetchMyTeamTrainingInfo", "@stas", "@empname", "@empId", "Complete", GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].UserId);
                            }
                            else
                            {
                                _dataTable = Resources.Instance.GetDataKey("Sp_FetchMyTeamTrainingInfo", "@stas", "@empname", "@empId", sts, GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].UserId);
                            }
                        }
                        else
                        {
                            if (sts == "MyTeamComplete")
                            {
                                _dataTable = Resources.Instance.GetDataKey("Sp_FetchMyTeamTrainingInfo", "@stas", "@empname", "@empId", "MyTeamComplete", GlobalDeclaration._holdInfo[0].UserTeam, GlobalDeclaration._holdInfo[0].UserId);
                            }
                            else
                            {
                                _dataTable = Resources.Instance.GetDataKey("Sp_FetchMyTeamTrainingInfo", "@stas", "@empname", "@empId", sts, GlobalDeclaration._holdInfo[0].UserTeam, GlobalDeclaration._holdInfo[0].UserId);
                            }
                        }
                        break;
                    case "UpComingTrainer":
                        _dataTable = Resources.Instance.GetDataKey("Sp_FetchTrainerCloseInfo", "@tranName", GlobalDeclaration._holdInfo[0].EmpCode, "@sts", sts);
                        createdynamiccolumn(_dataTable);
                        AddDynmaicCheckBox();
                        break;
                    case "CloseTraining":
                        _dataTable = Resources.Instance.GetDataKey("Sp_FetchTrainerCloseInfo", "@tranName", GlobalDeclaration._holdInfo[0].EmpCode, "@sts", sts);
                        break;
                }
                if (!IsClose)
                {
                    if (_dataTable.Rows.Count > 0)
                    {
                        DgvLoadDetails.DataSource = _dataTable;
                        lbrecord.Text = _dataTable.Rows.Count.ToString();
                        lbrecord.Visible = true;
                        //lbrecord.BackColor = Color.Red;
                        lbrecord.ForeColor = Color.Red;
                        if (_dataTable.Columns.Contains("EmployeeRating"))
                        {
                            DgvLoadDetails.Columns["EmployeeRating"].Visible = false;
                        }
                    }
                    else
                    {
                        lbrecord.Text = "No Records Found";
                        lbrecord.Visible = true;
                        // lbrecord.BackColor = Color.Red;
                        lbrecord.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        bool IsClose;
        private void createdynamiccolumn(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    DgvLoadDetails.DataSource = dt;
                    GridSeeting();
                    lbrecord.Text = _dataTable.Rows.Count.ToString();
                    lbrecord.Visible = true;
                    //lbrecord.BackColor = Color.Red;
                    lbrecord.ForeColor = Color.Red;
                    DataGridViewTextBoxColumn _dynmclm = new DataGridViewTextBoxColumn();
                    _dynmclm.Name = "confrm";
                    _dynmclm.HeaderText = "Confirm participants";
                    DgvLoadDetails.Columns.Insert(10, _dynmclm);
                    IsClose = true;
                    DgvLoadDetails.Columns["confrm"].ReadOnly = false;
                    DgvLoadDetails.Columns["Status"].ReadOnly = false;//vanue                   
                    DgvLoadDetails.ReadOnly = false;
                    btnUpdate.Visible = true;
                    checkedListBox1.Visible = true;

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
        private void GridSeeting()
        {
            try
            {
                DgvLoadDetails.BorderStyle = BorderStyle.Fixed3D;
                DgvLoadDetails.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                DgvLoadDetails.AllowUserToResizeColumns = false;
                DgvLoadDetails.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                DgvLoadDetails.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                DgvLoadDetails.DefaultCellStyle.SelectionForeColor = Color.Black;
                DgvLoadDetails.RowsDefaultCellStyle.BackColor = Color.LightGray;
                DgvLoadDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
                DgvLoadDetails.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                DgvLoadDetails.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.ReadOnly = true);

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvLoadDetails_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (IsClose)
                {
                    SetComboBoxCellType objChangeCellType = new SetComboBoxCellType(ChangeCellToComboBox);
                    if (e.ColumnIndex == this.DgvLoadDetails.Columns["Status"].Index)
                    {
                        this.DgvLoadDetails.BeginInvoke(objChangeCellType, e.RowIndex, "sts", e.ColumnIndex);
                        bIsComboBox = false;
                    }
                    else if (e.ColumnIndex == this.DgvLoadDetails.Columns["confrm"].Index)
                    {
                        this.DgvLoadDetails.BeginInvoke(objChangeCellType, e.RowIndex, "confrm", e.ColumnIndex);
                        bIsComboBox = false;
                    }
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<string> listempname()
        {
            List<string> _emp = new List<string>();
            string[] _holdname = null;
            try
            {
                if (_dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < _dataTable.Rows.Count; i++)
                    {
                        if (_dataTable.Rows[i]["EmpName"].ToString().Contains(","))
                        {
                            _holdname = _dataTable.Rows[i]["EmpName"].ToString().Split(',');
                            for (int j = 0; j < _holdname.Length; j++)
                            {
                                if (!_emp.Contains(_holdname[j]))
                                    _emp.Add(_holdname[j]);
                            }
                        }
                        else
                        {
                            if (!_emp.Contains(_dataTable.Rows[i]["EmpName"].ToString()))
                                _emp.Add(_dataTable.Rows[i]["EmpName"].ToString());
                        }

                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return _emp;
        }
        private void ChangeCellToComboBox(int iRowIndex, string ColumnName, int iColumnIndex)
        {
            try
            {
                if (bIsComboBox == false)
                {
                    if (ColumnName == "sts")
                    {
                        if (DgvLoadDetails[iColumnIndex, iRowIndex].Value.ToString() == "Completed") return;
                        DataGridViewComboBoxCell dgComboCell = new DataGridViewComboBoxCell();
                        dgComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Name", typeof(string));
                        string[] ArrayList = { "Not Completed", "Completed" };
                        for (int i = 0; i < ArrayList.Length; i++)
                        {
                            DataRow dr = dt.NewRow();
                            dr["Name"] = ArrayList[i].ToString();
                            dt.Rows.Add(dr);
                        }
                        dgComboCell.DataSource = dt;
                        dgComboCell.ValueMember = "Name";
                        dgComboCell.DisplayMember = "Name";
                        DgvLoadDetails[iColumnIndex, iRowIndex] = dgComboCell;
                        bIsComboBox = true;

                    }
                    else if (ColumnName == "confrm")
                    {
                        //DataGridViewComboBoxCell dgComboCell = new DataGridViewComboBoxCell();
                        //dgComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        //DataTable dt = new DataTable();
                        //dt.Columns.Add("Name", typeof(string));
                        //List<string> _valuehold = listempname();
                        //for (int i = 0; i < _valuehold.Count; i++)
                        //{
                        //    DataRow dr = dt.NewRow();
                        //    dr["Name"] = _valuehold[i].ToString();
                        //    dt.Rows.Add(dr);
                        //}
                        //dgComboCell.DataSource = dt;
                        //dgComboCell.ValueMember = "Name";
                        //dgComboCell.DisplayMember = "Name";
                        //DgvLoadDetails.Rows[iRowIndex].Cells[DgvLoadDetails.CurrentCell.ColumnIndex] = dgComboCell;
                        //bIsComboBox = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DgvLoadDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DgvLoadDetails.IsCurrentCellDirty)
            {
                DgvLoadDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void DgvLoadDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DgvLoadDetails.Columns.Contains("confrm"))
                {
                    if (e.ColumnIndex == DgvLoadDetails.Columns["confrm"].Index && e.RowIndex >= 0)
                    {
                        CallRatingForm(e.ColumnIndex, e.RowIndex);
                    }
                    else if (e.ColumnIndex == DgvLoadDetails.Columns["Status"].Index && e.RowIndex >= 0)
                    {
                        string receiceValue = DgvLoadDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();//trntype
                        if (receiceValue == "Completed")
                        {
                            DgvLoadDetails.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                            DgvLoadDetails.Rows[e.RowIndex].ReadOnly = true;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ConcurrentDictionary<string, MapEmployeeRating> _HoldInfo = null;
        private void CallRatingForm(int ColumnIndex, int RowIndex)
        {
            //string receiceValue = checkedListBox1.SelectedItem.ToString();//
            string receiceValue = DgvLoadDetails.Rows[RowIndex].Cells[ColumnIndex].Value.ToString();//trntype
            string EmployeName = string.Empty;
            try
            {
                if (receiceValue.Contains(','))
                {
                    string[] Receib = receiceValue.Split(',');
                    for (int i = 0; i < Receib.Length; i++)
                    {
                        EmployeName = Receib[i];
                        EmployeeRatingFrm frm = new EmployeeRatingFrm(EmployeName);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            MapEmployeeRating _ration = new MapEmployeeRating();
                            _ration.AddCount = frm.NumberRating;
                            _ration._selectionclr = frm._SetColor;
                            if (_holdEmpRating.ContainsKey(EmployeName))
                            {
                                _holdEmpRating[EmployeName] = _ration;
                            }
                            else
                            {
                                _holdEmpRating.TryAdd(EmployeName, _ration);
                                //DgvLoadDetails.Rows[RowIndex].DefaultCellStyle.ForeColor = Color.Green;

                            }
                            EmployeName = string.Empty;
                            frm.Close();
                            frm.Dispose();
                            frm = null;
                        }
                    }
                }
                else
                {
                    EmployeName = receiceValue;
                    EmployeeRatingFrm frm = new EmployeeRatingFrm(EmployeName);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        MapEmployeeRating _ration = new MapEmployeeRating();
                        _ration.AddCount = frm.NumberRating;
                        _ration._selectionclr = frm._SetColor;
                        if (_holdEmpRating.ContainsKey(EmployeName))
                        {
                            _holdEmpRating[EmployeName] = _ration;
                        }
                        else
                        {
                            _holdEmpRating.TryAdd(EmployeName, _ration);
                            //DgvLoadDetails.Rows[RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                            //DgvLoadDetails.Rows[RowIndex].ReadOnly = true;
                        }

                        EmployeName = string.Empty;
                        frm.Close();
                        frm.Dispose();
                        frm = null;
                    }
                }



            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddDynmaicCheckBox()
        {
            //List<string> _valuehold = listempname();
            //for (int i = 0; i < _valuehold.Count; i++)
            //{
            //    string Name = _valuehold[i];
            //    //this.checkedListBox1.d
            //    this.checkedListBox1.Items.Add(Name);
            //}

            this.checkedListBox1.SelectionMode = SelectionMode.One;
            this.checkedListBox1.Visible = false;
            this.checkedListBox1.CheckOnClick = true;
            this.Controls.Remove(checkedListBox1);

            this.DgvLoadDetails.Controls.Add(checkedListBox1);
            this.DgvLoadDetails.CellBeginEdit += new DataGridViewCellCancelEventHandler(dataGridView1_CellBeginEdit);
            this.DgvLoadDetails.CellEndEdit += new DataGridViewCellEventHandler(dataGridView1_CellEndEdit);
            this.DgvLoadDetails.Scroll += new ScrollEventHandler(dataGridView1_Scroll);

        }
        void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == DgvLoadDetails.Columns["confrm"].Index && e.RowIndex > -1)
                {
                    string[] _holdname = null;
                    // Set Location and size of checkedListBox1.  
                    Rectangle rec = this.DgvLoadDetails.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    checkedListBox1.Location = rec.Location;
                    checkedListBox1.Width = rec.Width;
                    checkedListBox1.Height = this.DgvLoadDetails.Height / 2;
                    //if (this.DGVAddtrn.CurrentCell.Value != null)
                    //    checkedListBox1.Text = this.DGVAddtrn.CurrentCell.Value.ToString();
                    string Calue = DgvLoadDetails.Rows[e.RowIndex].Cells["EmpName"].Value.ToString();
                    if (checkedListBox1.Items.Count > 0)
                        checkedListBox1.Items.Clear();
                    if (Calue.Contains(","))
                    {
                        _holdname = Calue.Split(',');
                        for (int j = 0; j < _holdname.Length; j++)
                        {
                            if (!checkedListBox1.Items.Contains(_holdname[j]))
                                checkedListBox1.Items.Add(_holdname[j]);
                        }
                    }
                    else
                    {
                        if (!checkedListBox1.Items.Contains(Calue))
                            checkedListBox1.Items.Add(Calue);
                    }
                    for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
                    {
                        this.checkedListBox1.SetItemChecked(i, false);
                    }

                    checkedListBox1.Visible = true;

                }
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
                if (e.ColumnIndex == DgvLoadDetails.Columns["confrm"].Index && e.RowIndex > -1)
                {
                    string SelectName = string.Empty;
                    var item = checkedListBox1.CheckedItems;
                    for (int i = 0; i < item.Count; i++)
                    {
                        //SelectName = item[i].ToString();
                        SelectName = SelectName + item[i].ToString() + ",";
                    }
                    if (!string.IsNullOrEmpty(SelectName))
                    {
                        SelectName = SelectName.Remove(SelectName.Length - 1, 1);

                        this.DgvLoadDetails.CurrentCell.Value = SelectName;
                    }
                    this.checkedListBox1.Visible = false;
                }
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
                if (DgvLoadDetails.CurrentCell.ColumnIndex == 1)
                {
                    if (checkedListBox1.Visible == true)
                    {
                        Rectangle rec = this.DgvLoadDetails.GetCellDisplayRectangle(this.DgvLoadDetails.CurrentCell.ColumnIndex, this.DgvLoadDetails.CurrentCell.RowIndex, true);
                        checkedListBox1.Location = rec.Location;
                        checkedListBox1.Width = rec.Width;
                        checkedListBox1.Height = DgvLoadDetails.Height / 4;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string value = string.Empty;
            string Dpt = string.Empty;
            int sts = 0;
            try
            {

                if (DgvLoadDetails.SelectedRows.Count > 0)
                {
                    for (int i = 0; i < DgvLoadDetails.SelectedRows.Count; i++)
                    {
                        if (DgvLoadDetails.SelectedRows[i].Cells["Status"].Value.ToString() == "Completed" && DgvLoadDetails.SelectedRows[i].DefaultCellStyle.ForeColor == Color.Green)
                        {
                            string EmpName = DgvLoadDetails.SelectedRows[i].Cells["confrm"].Value.ToString();
                            string EmployeeRating = string.Empty;
                            if (EmpName.Contains(','))
                            {
                                string[] Receib = EmpName.Split(',');
                                for (int Z = 0; Z < Receib.Length; Z++)
                                {
                                    string ReceivValue = Receib[Z];
                                    MapEmployeeRating strct = _holdEmpRating[ReceivValue];
                                    EmployeeRating = EmployeeRating + "," + strct.AddCount.ToString();
                                }
                                EmployeeRating = EmployeeRating.Substring(1).Trim();
                            }
                            else
                            {
                                MapEmployeeRating strct = _holdEmpRating[EmpName];
                                EmployeeRating = strct.AddCount.ToString();
                            }
                            if (DgvLoadDetails.SelectedRows[i].Cells["Department"].Value.ToString().Contains(',') && EmpName.Contains(',') && EmployeeRating.Contains(','))
                            {
                                EmpName = EmpName.Split(',')[0].ToString();
                                Dpt = DgvLoadDetails.SelectedRows[i].Cells["Department"].Value.ToString().Split(',')[0].ToString();
                                EmployeeRating = "'" + EmployeeRating + "'";
                            }
                            else
                            {
                                Dpt = DgvLoadDetails.SelectedRows[i].Cells["Department"].Value.ToString();
                            }
                            value = EmpName + "~" + Dpt + "~" +
                                     DgvLoadDetails.SelectedRows[i].Cells["TrainingTitle"].Value.ToString() + "~" + DgvLoadDetails.SelectedRows[i].Cells["TraingType"].Value.ToString() + "~" +
                                     DgvLoadDetails.SelectedRows[i].Cells["TrainerName"].Value.ToString() + "~" + DgvLoadDetails.SelectedRows[i].Cells["Status"].Value.ToString() + "~" + EmployeeRating;
                            sts = Resources.Instance.insertMasterrecord("Sp_UpdateTraineeData", "@empname", "@dptname", "@title", "@tytpe", "@trnname", "@sts", "@empRation", value);
                        }
                        else
                        {
                            XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please Change Status First!!!!!!!", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (sts > 0)
                        {
                            DgvLoadDetails.SelectedRows[i].DefaultCellStyle.ForeColor = Color.Orange;
                        }
                    }
                    if (sts > 0)
                    {
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Update Successfully.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        XtraMessageBox.Show("Error", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please Select any Row First for Update Details..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DgvLoadDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
