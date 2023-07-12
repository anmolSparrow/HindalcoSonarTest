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
    public partial class AddNewTrainingFrm : XtraForm
    {
        #region Global Declaration Variables
        delegate void SetComboBoxCellType(int iRowIndex, string clmname, int iColumnIndex);
        private bool bIsComboBox;
        private bool IsNewRow;
        int AutoIncreamet = 0;
        private string Sts = string.Empty;
        private bool IsHarCalled;
        Rectangle _Rectangle;
        #endregion
        public AddNewTrainingFrm(string Ttiname)
        {
            InitializeComponent();
            Sts = Ttiname;
            if (Sts == "Addtrn")
            {
                this.Text = "Add New Training";
                AddTrainingctx.Enabled = false;
                AddTrainingctx.Visible = false;
            }
            else
            {
                this.Text = "HR Add Others Training";
                AddTrainingctx.Enabled = true;
                AddTrainingctx.Visible = true;
            }
            UpdateTextPosition();
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
        private void AddNewTrainingFrm_Load(object sender, EventArgs e)
        {
            GridSeeting();
            DefaultDataLoad();
        }
        private void DefaultDataLoad()
        {
            try
            {
                string Department = string.Empty;
                string[] ff = GlobalDeclaration._holdInfo[0].DepartmentName.Split(',');
                if (ff.Length > 0)
                {
                    for (int i = 0; i < ff.Length; i++)
                    {
                        Department = Department + "," + "'" + ff[i].ToString().Trim() + "'";
                    }
                    Department = Department.Substring(1).Trim();
                }
                else
                {
                    Department = GlobalDeclaration._holdInfo[0].DepartmentName;
                }
                string Query = @"select ad.SrNo,ad.EmpName,ad.empid,ad.DepartMent,ad.TrainingTitle,ad.TraingType,ad.Duration,ad.Capability,ad.Vanue,  
                                 ad.Priority,ad.TrainingCreationDate,ad.Training_Start_date,ad.Training_Completion_Date,ad.Status from AddNewTrainingTBL ad where    
                                 ad.EmpName=ltrim(rtrim('" + GlobalDeclaration._holdInfo[0].UserName + "')) and  ltrim(rtrim(ad.DepartMent)) in (" + Department.Trim() + ") and  ad.empid=ltrim(rtrim(" + GlobalDeclaration._holdInfo[0].UserId + "))and ad.Status is not null";
                DataTable dt = Resources.Instance.InlineQuery(Query);//Resources.Instance.GetDataKey("Sp_FetchAddTrainingStatus", "@empname",  "@dptname", "@empid", GlobalDeclaration._holdInfo[0].UserName, Department, GlobalDeclaration._holdInfo[0].UserId);
                if (dt.Rows.Count > 0)
                {
                    DgvStatus.DataSource = dt;
                    AutoIncreamet = int.Parse(dt.Rows[dt.Rows.Count - 1]["SrNo"].ToString());
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region HR Others Trainging Event Dec
        DateTimePicker LastDateTimePicker;
        private void DGVAddtrn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (IsHarCalled)
                {
                    if (e.RowIndex > -1 && e.ColumnIndex > -1)
                    {
                        switch (DGVAddtrn.Columns[e.ColumnIndex].Name)
                        {
                            case "frmdate":
                            case "endDate":
                                {
                                    if (IsNewRow)
                                    {
                                        //_Rectangle = DGVAddtrn.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                                        //_Rectangle.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                                        //_Rectangle.Location = new Point(_Rectangle.X, _Rectangle.Y);
                                        //Set_Date.Visible = true;
                                        LastDateTimePicker = new DateTimePicker();  //DateTimePicker 
                                        //Adding DateTimePicker control into DataGridView
                                        DGVAddtrn.Controls.Add(LastDateTimePicker);

                                        // Intially made it invisible
                                        LastDateTimePicker.Visible = false;

                                        // Setting the format (i.e. 2014-10-10)
                                        LastDateTimePicker.Format = DateTimePickerFormat.Custom;
                                        LastDateTimePicker.CustomFormat = "yyyy-MM-dd hh:mm:ss";

                                        LastDateTimePicker.TextChanged += new EventHandler(LastDateTimePicker_OntextChange);

                                        // Now make it visible
                                        LastDateTimePicker.Visible = true;

                                        // It returns the retangular area that represents the Display area for a cell
                                        Rectangle oRectangle = DGVAddtrn.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                                        //Setting area for DateTimePicker Control
                                        LastDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

                                        // Setting Location
                                        LastDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);

                                        LastDateTimePicker.CloseUp += new EventHandler(LastDateTimePicker_CloseUp);
                                    }
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
        void LastDateTimePicker_OntextChange(object sender, EventArgs e)
        {
            DGVAddtrn.CurrentCell.Value = LastDateTimePicker.Text.ToString();
        }
        void LastDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            LastDateTimePicker.Visible = false;
        }
        public void GenerateDynamicClm(bool IsHrCall = false)
        {
            try
            {
                if (IsHrCall)
                {
                    IsHarCalled = IsHrCall;
                    DGVAddtrn.Columns["resorce"].Visible = true;
                    DGVAddtrn.Columns["prvty"].Visible = false;
                    checkedListBox1.Visible = true;
                    if (DGVAddtrn.Rows.Count <= 0)
                    {
                        //DGVAddtrn.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.Visible = false);
                    }

                    for (int i = 0; i < Resources.Instance._EmpName.Rows.Count; i++)
                    {

                        //this.checkedListBox1.d
                        this.checkedListBox1.Items.Add(Resources.Instance._EmpName.Rows[i]["emp_name"]);
                    }

                    this.checkedListBox1.SelectionMode = SelectionMode.One;
                    this.checkedListBox1.Visible = false;
                    this.checkedListBox1.CheckOnClick = true;
                    this.Controls.Remove(checkedListBox1);

                    this.DGVAddtrn.Controls.Add(checkedListBox1);
                    this.DGVAddtrn.CellBeginEdit += new DataGridViewCellCancelEventHandler(dataGridView1_CellBeginEdit);
                    this.DGVAddtrn.CellEndEdit += new DataGridViewCellEventHandler(dataGridView1_CellEndEdit);
                    this.DGVAddtrn.Scroll += new ScrollEventHandler(dataGridView1_Scroll);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (IsHarCalled)
            {
                if (e.ColumnIndex == 1)
                {
                    // Set Location and size of checkedListBox1.  
                    Rectangle rec = this.DGVAddtrn.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    checkedListBox1.Location = rec.Location;
                    checkedListBox1.Width = rec.Width;
                    checkedListBox1.Height = this.DGVAddtrn.Height / 2;
                    //if (this.DGVAddtrn.CurrentCell.Value != null)
                    //    checkedListBox1.Text = this.DGVAddtrn.CurrentCell.Value.ToString();

                    // Unselect all items in the checkedListBox1.  
                    for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
                    {
                        this.checkedListBox1.SetItemChecked(i, false);
                    }

                    checkedListBox1.Visible = true;

                }
            }
        }
        void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (IsHarCalled && IsNewRow)
                {

                    if (e.ColumnIndex == 1)
                    {
                        this.DGVAddtrn.CurrentCell.Value = checkedListBox1.Text;
                        this.checkedListBox1.Visible = false;
                    }
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
                if (IsHarCalled && IsNewRow)
                {
                    if (DGVAddtrn.CurrentCell.ColumnIndex == 1)
                    {
                        if (checkedListBox1.Visible == true)
                        {
                            Rectangle rec = this.DGVAddtrn.GetCellDisplayRectangle(this.DGVAddtrn.CurrentCell.ColumnIndex, this.DGVAddtrn.CurrentCell.RowIndex, true);
                            checkedListBox1.Location = rec.Location;
                            checkedListBox1.Width = rec.Width;
                            checkedListBox1.Height = DGVAddtrn.Height / 4;
                        }
                    }
                    else if (DGVAddtrn.CurrentCell.ColumnIndex == 8 || DGVAddtrn.CurrentCell.ColumnIndex == 9)
                    {
                        if (LastDateTimePicker != null)
                            LastDateTimePicker.Visible = false;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        private void GridSeeting()
        {
            try
            {
                DGVAddtrn.BorderStyle = BorderStyle.Fixed3D;

                DGVAddtrn.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                DGVAddtrn.AllowUserToResizeColumns = false;

                DGVAddtrn.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


                DGVAddtrn.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;

                DGVAddtrn.DefaultCellStyle.SelectionForeColor = Color.Black;
                DGVAddtrn.RowsDefaultCellStyle.BackColor = Color.LightGray;
                DGVAddtrn.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
                DGVAddtrn.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DGVAddtrn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGVAddtrn_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DGVAddtrn_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            SetComboBoxCellType objChangeCellType = new SetComboBoxCellType(ChangeCellToComboBox);
            if (e.ColumnIndex == this.DGVAddtrn.Columns["empname"].Index)
            {
                this.DGVAddtrn.BeginInvoke(objChangeCellType, e.RowIndex, "Empname", e.ColumnIndex);
                bIsComboBox = false;
            }
            else if (e.ColumnIndex == this.DGVAddtrn.Columns["trntitle"].Index)
            {
                this.DGVAddtrn.BeginInvoke(objChangeCellType, e.RowIndex, "Title", e.ColumnIndex);
                bIsComboBox = false;

            }
            else if (e.ColumnIndex == this.DGVAddtrn.Columns["prvty"].Index)
            {
                this.DGVAddtrn.BeginInvoke(objChangeCellType, e.RowIndex, "Prvity", e.ColumnIndex);
                bIsComboBox = false;
            }
            else if (e.ColumnIndex == this.DGVAddtrn.Columns["trnName"].Index)
            {
                this.DGVAddtrn.BeginInvoke(objChangeCellType, e.RowIndex, "trainerName", e.ColumnIndex);
                bIsComboBox = false;
            }
            else if (e.ColumnIndex == this.DGVAddtrn.Columns["cpblty"].Index)
            {
                this.DGVAddtrn.BeginInvoke(objChangeCellType, e.RowIndex, "Capability", e.ColumnIndex);
                bIsComboBox = false;
            }

        }
        private void ChangeCellToComboBox(int iRowIndex, string ColumnName, int iColumnIndex)
        {
            try
            {
                if (bIsComboBox == false)
                {

                    if (ColumnName == "Empname")
                    {
                        if (IsHarCalled)
                        {
                            if (DGVAddtrn[iColumnIndex, iRowIndex].Value != null) return;
                            DataGridViewComboBoxCell dgComboCell = new DataGridViewComboBoxCell();
                            dgComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                            dgComboCell.DataSource = Resources.Instance._EmpName.Copy();
                            dgComboCell.ValueMember = "emp_name";
                            dgComboCell.DisplayMember = "emp_name";
                            DGVAddtrn[iColumnIndex, iRowIndex] = dgComboCell;
                            bIsComboBox = true;
                        }
                    }
                    else if (ColumnName == "trainerName")
                    {
                        if (IsHarCalled)
                        {
                            if (DGVAddtrn[iColumnIndex, iRowIndex].Value != null) return;
                            DataGridViewComboBoxCell dgComboCell = new DataGridViewComboBoxCell();
                            dgComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                            dgComboCell.DataSource = Resources.Instance._EmpName.Copy();
                            dgComboCell.ValueMember = "emp_name";
                            dgComboCell.DisplayMember = "emp_name";
                            DGVAddtrn[iColumnIndex, iRowIndex] = dgComboCell;
                            DGVAddtrn.Columns[iColumnIndex].ReadOnly = false;
                            dgComboCell.DropDownWidth = 110;
                            bIsComboBox = true;
                        }
                    }
                    else if (ColumnName == "Title")
                    {
                        if (DGVAddtrn[iColumnIndex, iRowIndex].Value != null) return;
                        DataGridViewComboBoxCell dgComboCell = new DataGridViewComboBoxCell();
                        dgComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgComboCell.DataSource = Resources.Instance._trainingTitle.Copy();
                        dgComboCell.ValueMember = "TTitle";
                        dgComboCell.DisplayMember = "TTitle";
                        DGVAddtrn[iColumnIndex, iRowIndex] = dgComboCell;
                        dgComboCell.DropDownWidth = 310;
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "Prvity")
                    {
                        if (DGVAddtrn[iColumnIndex, iRowIndex].Value != null) return;
                        DataGridViewComboBoxCell dgComboCellPrioty = new DataGridViewComboBoxCell();
                        dgComboCellPrioty.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Name", typeof(string));
                        string[] ArrayList = { "High", "Medium", "Low" };
                        for (int i = 0; i < ArrayList.Length; i++)
                        {
                            DataRow dr = dt.NewRow();
                            dr["Name"] = ArrayList[i].ToString();
                            dt.Rows.Add(dr);
                        }
                        dgComboCellPrioty.DataSource = dt;
                        dgComboCellPrioty.ValueMember = "Name";
                        dgComboCellPrioty.DisplayMember = "Name";
                        DGVAddtrn[iColumnIndex, iRowIndex] = dgComboCellPrioty;
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "Capability")
                    {
                        if (IsHarCalled)
                        {
                            if (DGVAddtrn[iColumnIndex, iRowIndex].Value != null) return;
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
                            DGVAddtrn[iColumnIndex, iRowIndex] = dgComboCellPrioty;
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

        private void DGVAddtrn_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0) //check if combobox column
            {

                AddTrainingTtile(e.ColumnIndex, e.RowIndex);
            }
            else if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                if (IsHarCalled)
                {
                    UpdateTrainigType(e.ColumnIndex, e.RowIndex);
                }
            }
            else if (e.ColumnIndex == 12 && e.RowIndex >= 0)
            {
                if (IsHarCalled)
                {
                    Capabilitrn(e.ColumnIndex, e.RowIndex);
                }
            }
        }
        private void DGVAddtrn_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGVAddtrn.IsCurrentCellDirty)
            {
                DGVAddtrn.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void AddTrainingTtile(int columnIndex, int RowsIndex)
        {
            try
            {
                string receiceValue = string.Empty;
                receiceValue = DGVAddtrn.Rows[RowsIndex].Cells[columnIndex].Value.ToString();
                DataTable dt = Resources.Instance.GetDataKey("Sp_FetchTariningTpe", "@Ttile", receiceValue);
                DGVAddtrn.Rows[RowsIndex].Cells["trntype"].Value = dt.Rows[0]["TrainingType"].ToString();
                if (IsHarCalled)
                {
                    DGVAddtrn.Rows[RowsIndex].Cells["drtion"].Value = dt.Rows[0]["TrainingDuration"].ToString();
                    DGVAddtrn.Columns["drtion"].ReadOnly = true;
                    //DGVAddtrn.Columns["trntype"].ReadOnly = true;
                }
                DGVAddtrn.Columns["trntype"].ReadOnly = true;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateTrainigType(int columnIndex, int RowsIndex)
        {
            try
            {
                string receiceValue = string.Empty;
                if (IsHarCalled)
                {
                    string Recultstring = string.Empty;
                    int Value = 0;
                    receiceValue = DGVAddtrn.Rows[RowsIndex].Cells[columnIndex].Value.ToString();
                    Resources.Instance.selectMasterKeycom("Sp_GetEmployeeIdUsingOnlyEmpName", receiceValue, "@empName", "@empId", out Value);
                    Resources.Instance.selectMasterDeptKeycom("Sp_GetDepartmentName", receiceValue, "@empName", "@DeptName", out Recultstring);
                    DGVAddtrn.Rows[RowsIndex].Cells["Dptname"].Value = Recultstring;
                    DGVAddtrn.Rows[RowsIndex].Cells["empid"].Value = Value;
                    DGVAddtrn.Rows[RowsIndex].Cells["TrnCode"].Value = TrainerCode(GlobalDeclaration._holdInfo[0].UserName);
                    DGVAddtrn.Columns["empname"].ReadOnly = true;
                    DGVAddtrn.Columns["empid"].ReadOnly = true;
                    DGVAddtrn.Columns["Dptname"].ReadOnly = true;
                    DGVAddtrn.Columns["TrnCode"].ReadOnly = true;

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Capabilitrn(int columnIndex, int RowsIndex)
        {
            string receiceValue = string.Empty;
            receiceValue = DGVAddtrn.Rows[RowsIndex].Cells[columnIndex].Value.ToString();
            if (receiceValue.Trim() == "Internal")
            {
                DGVAddtrn.Columns["trnName"].ReadOnly = false ? true : DGVAddtrn.Columns["trnName"].ReadOnly;
                DGVAddtrn.Columns["trnName"].Visible = true;
            }
            else
            {
                DGVAddtrn.Columns["trnName"].ReadOnly = true;
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

        private void AddNewRow()
        {
            try
            {
                DataGridViewRow rowadd = new DataGridViewRow();
                DGVAddtrn.Rows.Insert(0, rowadd);
                AutoIncreamet++;
                DGVAddtrn.Rows[0].Cells["SrNo"].Value = AutoIncreamet;
                DGVAddtrn.Columns["SrNo"].ReadOnly = true;
                if (!IsHarCalled)
                {
                    DGVAddtrn.Rows[0].Cells["empname"].Value = GlobalDeclaration._holdInfo[0].UserName;
                    DGVAddtrn.Rows[0].Cells["empid"].Value = GlobalDeclaration._holdInfo[0].UserId;
                    DGVAddtrn.Rows[0].Cells["Dptname"].Value = GlobalDeclaration._holdInfo[0].DepartmentName;
                    DGVAddtrn.Rows[0].Cells["TrnCode"].Value = TrainerCode(GlobalDeclaration._holdInfo[0].UserName);
                    DGVAddtrn.Columns["empname"].ReadOnly = true;
                    DGVAddtrn.Columns["empid"].ReadOnly = true;
                    DGVAddtrn.Columns["Dptname"].ReadOnly = true;//vanue
                    DGVAddtrn.Columns["vanue"].ReadOnly = true;
                    DGVAddtrn.Columns["cpblty"].ReadOnly = true;
                    DGVAddtrn.Columns["frmdate"].ReadOnly = true;
                    DGVAddtrn.Columns["endDate"].ReadOnly = true;
                    DGVAddtrn.Columns["drtion"].ReadOnly = true;
                    DGVAddtrn.Rows[0].Cells["TrnCode"].ReadOnly = true;
                }
                else
                {
                    IsNewRow = true;
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string TrainerCode(string TrainerName)
        {
            return Resources.Instance.EmployeListTR.Select("emp_name='" + TrainerName.Trim() + "'").FirstOrDefault().ItemArray[1].ToString();
        }
        private void DeleteRow()
        {
            try
            {
                if (DGVAddtrn.Rows.Count > 0)
                {
                    if (this.DGVAddtrn.SelectedRows.Count > 0)
                    {
                        int indes = this.DGVAddtrn.SelectedRows[0].Index;
                        DGVAddtrn.Rows.RemoveAt(indes);
                        AutoIncreamet--;
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

        private void btnsend_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVAddtrn.SelectedRows.Count > 0)
                {
                    string Value = string.Empty;
                    int sts = 0;
                    if (IsHarCalled)
                    {
                        if (DGVAddtrn.SelectedRows[0].Cells["empname"].Value.ToString().Contains(",")) // this for Multiple Entry Save in MyteamTable
                        {
                            string[] EmpName = DGVAddtrn.SelectedRows[0].Cells["empname"].Value.ToString().Split(',');
                            int srnumber = int.Parse(DGVAddtrn.SelectedRows[0].Cells["SrNo"].Value.ToString());
                            for (int i = 0; i < EmpName.Length; i++)
                            {
                                string EmpNameReceive = EmpName[i].Trim();

                                Value = (srnumber + i).ToString() + "_" + EmpNameReceive + "_" + DGVAddtrn.SelectedRows[0].Cells["empid"].Value.ToString().Split(',')[i] + "_" +
                                         DGVAddtrn.SelectedRows[0].Cells["Dptname"].Value.ToString().Split(',')[i] + "_" + DGVAddtrn.SelectedRows[0].Cells["trntitle"].Value.ToString() + "_" +
                                         DGVAddtrn.SelectedRows[0].Cells["trntype"].Value.ToString() + "_" +
                                         DGVAddtrn.SelectedRows[0].Cells["vanue"].Value.ToString() + "_" + DGVAddtrn.SelectedRows[0].Cells["cpblty"].Value.ToString() + "_" +
                                         DGVAddtrn.SelectedRows[0].Cells["frmdate"].Value.ToString() + "_" + DGVAddtrn.SelectedRows[0].Cells["endDate"].Value.ToString() + "_" +
                                         DGVAddtrn.SelectedRows[0].Cells["drtion"].Value.ToString() + "_" + DGVAddtrn.SelectedRows[0].Cells["resorce"].Value.ToString() + "_" +
                                         DGVAddtrn.SelectedRows[0].Cells["trnName"].Value.ToString() + "_" + DGVAddtrn.SelectedRows[0].Cells["TrnCode"].Value.ToString() + "_" + "MyTeam";
                                sts = Resources.Instance.insertMasterrecord("Sp_InsertMutipleTrainingHR", "@SrNo", "@empname", "@empid", "@Dptname", "@trntitle", "@trntype", "@vanue", "@cpblty", "@frmdate", "@endDate", "@drtion", "@resorce", "@trnName", "@trnCode", "@sts", Value, "h");
                            }
                        }
                        else // this for Single Entry Save In AddNewTrainingTable
                        {
                            Value = DGVAddtrn.SelectedRows[0].Cells["SrNo"].Value.ToString() + "_" + DGVAddtrn.SelectedRows[0].Cells["empname"].Value.ToString() + "_" +
                                   DGVAddtrn.SelectedRows[0].Cells["empid"].Value.ToString() + "_" + DGVAddtrn.SelectedRows[0].Cells["Dptname"].Value.ToString() + "_" +
                                   DGVAddtrn.SelectedRows[0].Cells["trntitle"].Value.ToString() + "_" + DGVAddtrn.SelectedRows[0].Cells["trntype"].Value.ToString() + "_" +
                                   DGVAddtrn.SelectedRows[0].Cells["vanue"].Value.ToString() + "_" + DGVAddtrn.SelectedRows[0].Cells["cpblty"].Value.ToString() + "_" +
                                   DGVAddtrn.SelectedRows[0].Cells["frmdate"].Value.ToString() + "_" + DGVAddtrn.SelectedRows[0].Cells["endDate"].Value.ToString() + "_" +
                                   DGVAddtrn.SelectedRows[0].Cells["drtion"].Value.ToString() + "_" + DGVAddtrn.SelectedRows[0].Cells["resorce"].Value.ToString() + "_" +
                                   DGVAddtrn.SelectedRows[0].Cells["trnName"].Value.ToString() + "_" + DGVAddtrn.SelectedRows[0].Cells["TrnCode"].Value.ToString() + "_" + "NewAdd";
                            sts = Resources.Instance.insertMasterrecord("Sp_InsertMutipleTrainingHR", "@SrNo", "@empname", "@empid", "@Dptname", "@trntitle", "@trntype", "@vanue", "@cpblty", "@frmdate", "@endDate", "@drtion", "@resorce", "@trnName", "@trnCode", "@sts", Value, "h");
                        }
                    }
                    else // this is only For When Indiviual User Login
                    {
                        Value = DGVAddtrn.SelectedRows[0].Cells["SrNo"].Value.ToString() + "_" + DGVAddtrn.SelectedRows[0].Cells["empname"].Value.ToString() + "_" +
                               DGVAddtrn.SelectedRows[0].Cells["empid"].Value.ToString() + "_" + DGVAddtrn.SelectedRows[0].Cells["Dptname"].Value.ToString() + "_" +
                               DGVAddtrn.SelectedRows[0].Cells["trntitle"].Value.ToString() + "_" + DGVAddtrn.SelectedRows[0].Cells["trntype"].Value.ToString() + "_" +
                               DGVAddtrn.SelectedRows[0].Cells["prvty"].Value.ToString() + "_" + DGVAddtrn.SelectedRows[0].Cells["TrnCode"].Value.ToString();
                        sts = Resources.Instance.insertMasteObj("Sp_insertAddNewtranData", "@srno", "@empname", "@empid", "@dptname", "@title", "@tytpe", "@prvty", "@trnCode", Value);
                    }
                    if (sts > 0)
                    {
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Approval Send Successfully.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Error", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please Select Row First Then Send Notification.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
