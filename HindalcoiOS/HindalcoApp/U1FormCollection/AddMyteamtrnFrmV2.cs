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
    public partial class AddMyteamtrnFrm : XtraForm
    {
        delegate void SetComboBoxCellType(int iRowIndex, string clmname, int iColumnIndex);
        private bool bIsComboBox;
        public AddMyteamtrnFrm()
        {
            InitializeComponent();
            this.Text = "Add New My Team Training";
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

        private void AddMyteamtrnFrm_Load(object sender, EventArgs e)
        {
            GridSeeting();
            DefaultDataLoad();
            AddDynmaicCheckBox();
        }
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
        private void AddDynmaicCheckBox()
        {
            for (int i = 0; i < Resources.Instance._EmpName.Rows.Count; i++)
            {

                //this.checkedListBox1.d
                this.checkedListBox1.Items.Add(Resources.Instance._EmpName.Rows[i]["emp_name"]);
            }
            this.checkedListBox1.SelectionMode = SelectionMode.One;
            this.checkedListBox1.Visible = false;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.ColumnWidth = 30;
            this.Controls.Remove(checkedListBox1);

            this.DGVAddtrn.Controls.Add(checkedListBox1);
            this.DGVAddtrn.CellBeginEdit += new DataGridViewCellCancelEventHandler(dataGridView1_CellBeginEdit);
            this.DGVAddtrn.CellEndEdit += new DataGridViewCellEventHandler(dataGridView1_CellEndEdit);
            this.DGVAddtrn.Scroll += new ScrollEventHandler(dataGridView1_Scroll);

        }
        void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
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
                if (this.checkedListBox1.Items.Count > 0)
                {
                    for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
                    {
                        this.checkedListBox1.SetItemChecked(i, false);
                    }

                    checkedListBox1.Visible = true;
                }
            }
            //checkedListBox1.Visible = false;
        }
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ////for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix)
            ////    if (ix != e.Index) checkedListBox1.SetItemChecked(ix, false);
            //if (e.NewValue == CheckState.Checked && checkedListBox1.CheckedItems.Count > 0)
            //{
            //    //checkedListBox1.ItemCheck -= checkedListBox1_ItemCheck;
            //    checkedListBox1.SetItemChecked(checkedListBox1.CheckedIndices[0], false);
            //    //checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;
            //}
        }
        void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    string SelectName = string.Empty;
                    var item = checkedListBox1.CheckedItems;
                    if (item.Count > 0)
                    {
                        for (int i = 0; i < item.Count; i++)
                        {
                            SelectName = SelectName + item[i].ToString() + ",";//item[i].ToString();
                        }
                        SelectName = SelectName.Remove(SelectName.Length - 1, 1);
                        if (!string.IsNullOrEmpty(SelectName))
                        {
                            this.DGVAddtrn.CurrentCell.Value = SelectName;
                            // this.checkedListBox1.Visible = false;                        
                        }
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
                if (DGVAddtrn.CurrentCell == null) return;
                if (DGVAddtrn.CurrentCell.ColumnIndex == 1)
                {
                    if (checkedListBox1.Visible)
                    {
                        Rectangle rec = this.DGVAddtrn.GetCellDisplayRectangle(this.DGVAddtrn.CurrentCell.ColumnIndex, this.DGVAddtrn.CurrentCell.RowIndex, true);
                        checkedListBox1.Location = rec.Location;
                        checkedListBox1.Width = rec.Width;
                        checkedListBox1.Height = DGVAddtrn.Height / 4;
                    }
                }
                checkedListBox1.Visible = false;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadTitile()
        {
            string query = "select  distinct TTitle from ListOfTrainingCodeTBL order by TTitle asc ";
            // TrainTitle = Resources.Instance.InlineQuery(query);
            // EmployeList = Resources.Instance.GetDataKey("SP_GetEmployeeName");
        }
        private void DefaultDataLoad()
        {
            DataTable dt = Resources.Instance.GetDataKey("Sp_FetchMyTeamTrainingStatus", "@empname", "@dptname", "@empid", GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].DepartmentName, GlobalDeclaration._holdInfo[0].UserId);
            if (dt.Rows.Count > 0)
            {
                DgvStatus.DataSource = dt;
                AutoIncreamet = int.Parse(dt.Rows[dt.Rows.Count - 1]["SrNo"].ToString());
            }

        }

        private void DGVAddtrn_CellContentClick(object sender, DataGridViewCellEventArgs e)
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


        }
        private void ChangeCellToComboBox(int iRowIndex, string ColumnName, int iColumnIndex)
        {
            try
            {
                if (bIsComboBox == false)
                {
                    if (ColumnName == "Empname")
                    {
                        // DataGridViewCheckBoxCell dgComboCell = new DataGridViewCheckBoxCell();
                        // dgComboCell.i

                        //DataGridViewComboBoxCell dgComboCell = new DataGridViewComboBoxCell();
                        //dgComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        //dgComboCell.DataSource = EmployeList;
                        //dgComboCell.ValueMember = "emp_name";
                        //dgComboCell.DisplayMember = "emp_name";
                        //DGVAddtrn.Rows[iRowIndex].Cells[DGVAddtrn.CurrentCell.ColumnIndex] = dgComboCell;
                        //bIsComboBox = true;

                    }
                    else if (ColumnName == "Title")
                    {
                        if (DGVAddtrn[iColumnIndex, iRowIndex].Value != null) return;
                        DataGridViewComboBoxCell dgComboCell = new DataGridViewComboBoxCell();
                        dgComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgComboCell.DataSource = Resources.Instance._trainingTitle.Copy();
                        dgComboCell.ValueMember = "TTitle";
                        dgComboCell.DisplayMember = "TTitle";
                        dgComboCell.AutoComplete = true;
                        DGVAddtrn[iColumnIndex, iRowIndex] = dgComboCell;
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
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVAddtrn_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGVAddtrn.IsCurrentCellDirty)
            {
                DGVAddtrn.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DGVAddtrn_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                DepartName(e.ColumnIndex, e.RowIndex);
            }
            else if (e.ColumnIndex == 4 && e.RowIndex >= 0) //check if combobox column
            {

                UpdateTrainigType(e.ColumnIndex, e.RowIndex);
            }
            //else if(e.ColumnIndex==1 && e.RowIndex>=0)
            //{
            //    DepartName(e.ColumnIndex, e.RowIndex);
            //}
        }
        private void DepartName(int columnIndex, int RowsIndex)
        {
            string deptname = string.Empty;
            string FinalValue = string.Empty;
            try
            {
                int ID = 0;
                if (DGVAddtrn.Rows[RowsIndex].Cells[columnIndex].Value != null)
                {
                    string receiceValue = DGVAddtrn.Rows[RowsIndex].Cells[columnIndex].Value.ToString();//trntype
                    string[] dd = receiceValue.Split(',');
                    for (int i = 0; i < dd.Count(); i++)
                    {
                        FinalValue = FinalValue + "," + "'" + dd[i].ToString() + "'";
                    }
                    FinalValue = FinalValue.Substring(1);//"select  ltrim(rtrim(Stuff((Select ', '+ltrim(rtrim(D.Dept_Name)) from tbl_EmployeeDetail E inner join tbl_Department_Master D on E.DeptId=D.DeptId where E.emp_name in ("+ FinalValue +")  FOR XML PATH('')),1,1,' ,'))) as Department";
                    string Query = "select  ltrim(rtrim(Right(ltrim(rtrim(Stuff((Select ', ' + ltrim(rtrim(D.Dept_Name)) from tbl_EmployeeDetail E inner join tbl_Department_Master D on E.DeptId = D.DeptId where E.emp_name in (" + FinalValue + ")  FOR XML PATH('')), 1, 1, ' ,'))),LEN(ltrim(rtrim(Stuff((Select ', ' + ltrim(rtrim(D.Dept_Name)) from tbl_EmployeeDetail E inner join tbl_Department_Master D on E.DeptId = D.DeptId where E.emp_name in (" + FinalValue + ")  FOR XML PATH('')), 1, 1, ' ,'))))-1))) as Department";
                    DataTable gg = Resources.Instance.InlineQuery(Query);
                    string[] Deptsp = gg.Rows[0]["Department"].ToString().Split(',');
                    for (int i = 0; i < Deptsp.Count(); i++)
                    {
                        deptname = deptname + "," + "'" + Deptsp[i].ToString().Trim() + "'";
                    }

                    deptname = deptname.Substring(1).Trim();
                    /// Resources.Instance.InsertMasterKeycom("Sp_GetDepartmentName", receiceValue, "@empName", "@DeptName", out deptname);
                    if (deptname.Contains("'"))
                    {

                        string outputStr = deptname.Replace("'", ""); //deptname.Trim(new char[] { (char)39 });
                        DGVAddtrn.Rows[RowsIndex].Cells["Dptname"].Value = outputStr;
                    }
                    else
                    {
                        DGVAddtrn.Rows[RowsIndex].Cells["Dptname"].Value = deptname;
                    }
                    // gg.Rows[0]["Department"].ToString();
                    string Dpquery = " select ltrim(rtrim(right(STUFF((select ','+ ltrim(rtrim(e.emp_code))  from tbl_EmployeeDetail E inner join tbl_Department_Master D on E.DeptId=D.DeptId where E.emp_name in(" + FinalValue.Trim() + ")  and d.Dept_Name in (" + deptname.Trim() + ") FOR XML PATH('')),1,1,' ,'),LEN(ltrim(rtrim(STUFF((select ','+ ltrim(rtrim(e.emp_code))  from tbl_EmployeeDetail E inner join tbl_Department_Master D on E.DeptId=D.DeptId where E.emp_name in(" + FinalValue + ")  and d.Dept_Name in (" + deptname.Trim() + ")FOR XML PATH('')),1,1,' ,'))))-1))) as EmpId";
                    DataTable Dggg = Resources.Instance.InlineQuery(Dpquery);
                    // Resources.Instance.InsertMasterKeycom("Sp_GetEmployeeIDValue", "@empName", "@DeptName", receiceValue, deptname, "@empid", out ID);
                    DGVAddtrn.Rows[RowsIndex].Cells["empid"].Value = Dggg.Rows[0]["EmpId"].ToString();
                    DGVAddtrn.Columns["empid"].ReadOnly = true;
                    DGVAddtrn.Columns["Dptname"].ReadOnly = true;//vanue
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void UpdateTrainigType(int columnIndex, int RowsIndex)
        {
            string receiceValue = DGVAddtrn.Rows[RowsIndex].Cells[columnIndex].Value.ToString();//trntype
            DataTable dt = Resources.Instance.GetDataKey("Sp_FetchTariningTpe", "@Ttile", receiceValue);
            DGVAddtrn.Rows[RowsIndex].Cells["trntype"].Value = dt.Rows[0]["TrainingType"].ToString();
            DGVAddtrn.Rows[RowsIndex].Cells["trntype"].ReadOnly = true;
            DGVAddtrn.Rows[RowsIndex].Cells["drtion"].Value = dt.Rows[0]["TrainingDuration"].ToString();
            DGVAddtrn.Columns["drtion"].ReadOnly = true;

        }
        int AutoIncreamet = 0;
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
                //////DGVAddtrn.Rows[0].Cells["empname"].Value = GlobalDeclaration._holdInfo[0].UserName;
                /// DGVAddtrn.Rows[0].Cells["empid"].Value = GlobalDeclaration._holdInfo[0].UserId;
                // DGVAddtrn.Rows[0].Cells["Dptname"].Value = GlobalDeclaration._holdInfo[0].DepartmentName;
                DGVAddtrn.Columns["SrNo"].ReadOnly = true;
                DGVAddtrn.Columns["empname"].ReadOnly = false;
                if (!GlobalDeclaration._holdInfo[0].DepartmentName.Equals("HR"))
                {
                    DGVAddtrn.Columns["vanue"].ReadOnly = true;
                    DGVAddtrn.Columns["cpblty"].ReadOnly = true;
                    DGVAddtrn.Columns["frmdate"].ReadOnly = true;
                    DGVAddtrn.Columns["endDate"].ReadOnly = true;
                    DGVAddtrn.Columns["drtion"].ReadOnly = true;
                }
                //DGVAddtrn.Columns["vanue"].ReadOnly = true;
                //DGVAddtrn.Columns["cpblty"].ReadOnly = true;
                //DGVAddtrn.Columns["frmdate"].ReadOnly = true;
                //DGVAddtrn.Columns["endDate"].ReadOnly = true;
                //DGVAddtrn.Columns["drtion"].ReadOnly = true;

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string EmpNameVar = string.Empty;
                string DepNameVar = string.Empty;
                string EmpIdVar = string.Empty;
                int sts = 0;
                int AutoSerNumber = 0;
                if (DGVAddtrn.SelectedRows.Count > 0)
                {
                    string[] EmpSplit = DGVAddtrn.SelectedRows[0].Cells["empname"].Value.ToString().Split(',');
                    string[] EmpId = DGVAddtrn.SelectedRows[0].Cells["empid"].Value.ToString().Split(',');
                    string[] DepName = DGVAddtrn.SelectedRows[0].Cells["Dptname"].Value.ToString().Split(',');
                    if (!GlobalDeclaration._holdInfo[0].DepartmentName.Equals("HR"))
                    {
                        if (EmpSplit.Length > 0 && EmpId.Length > 0 && DepName.Length > 0)
                        {
                            for (int i = 0; i < EmpSplit.Count(); i++)
                            {
                                AutoSerNumber++;
                                EmpNameVar = EmpSplit[i].ToString();
                                DepNameVar = DepName[i].ToString();
                                EmpIdVar = EmpId[i].ToString();
                                string Value = AutoSerNumber.ToString() + "_" + EmpNameVar + "_" +
                                                   EmpIdVar + "_" + DepNameVar + "_" +
                                                   DGVAddtrn.SelectedRows[0].Cells["trntitle"].Value.ToString() + "_" + DGVAddtrn.SelectedRows[0].Cells["trntype"].Value.ToString() + "_" +
                                                   DGVAddtrn.SelectedRows[0].Cells["prvty"].Value.ToString() + "MyTeam" + "_" + GlobalDeclaration._holdInfo[0].UserTeam;
                                sts = Resources.Instance.insertMasteObj("Sp_insertAddNewMyTeamtranData", "@srno", "@empname", "@empid", "@dptname", "@title", "@tytpe", "@prvty", "@sts", "@rptperson", Value);
                            }
                        }
                        else
                        {
                            string Value = DGVAddtrn.SelectedRows[0].Cells["SrNo"].Value.ToString() + "_" + DGVAddtrn.SelectedRows[0].Cells["empname"].Value.ToString() + "_" +
                                                   DGVAddtrn.SelectedRows[0].Cells["empid"].Value.ToString() + "_" + DGVAddtrn.SelectedRows[0].Cells["Dptname"].Value.ToString() + "_" +
                                                   DGVAddtrn.SelectedRows[0].Cells["trntitle"].Value.ToString() + "_" + DGVAddtrn.SelectedRows[0].Cells["trntype"].Value.ToString() + "_" +
                                                   DGVAddtrn.SelectedRows[0].Cells["prvty"].Value.ToString() + "Single" + "_" + GlobalDeclaration._holdInfo[0].UserTeam;
                            sts = Resources.Instance.insertMasteObj("Sp_insertAddNewMyTeamtranData", "@srno", "@empname", "@empid", "@dptname", "@title", "@tytpe", "@prvty", "@sts", "@rptperson", Value);
                        }
                    }
                    else// this for HR When HR have make My Team Training .HR can have Insert Record Into DB
                    {
                        if (EmpSplit.Length > 0 && EmpId.Length > 0 && DepName.Length > 0)
                        {
                            for (int i = 0; i < EmpSplit.Count(); i++)
                            {
                                AutoSerNumber++;
                                EmpNameVar = EmpSplit[i].ToString();
                                DepNameVar = DepName[i].ToString();
                                EmpIdVar = EmpId[i].ToString().Replace("Emp", "");
                                string Value = AutoSerNumber.ToString() + "_" + EmpIdVar + "_" +
                                                   EmpNameVar + "_" + DepNameVar + "_" +
                                                   DGVAddtrn.SelectedRows[0].Cells["trntitle"].Value.ToString() + "_" + DGVAddtrn.SelectedRows[0].Cells["endDate"].Value.ToString() + "_" +
                                                   DGVAddtrn.SelectedRows[0].Cells["frmdate"].Value.ToString() + "_" + DGVAddtrn.SelectedRows[0].Cells["trntype"].Value.ToString() + "_" +
                                                   DGVAddtrn.SelectedRows[0].Cells["prvty"].Value.ToString() + "_" + DGVAddtrn.SelectedRows[0].Cells["vanue"].Value.ToString() + "_" +
                                                   DGVAddtrn.SelectedRows[0].Cells["cpblty"].Value.ToString() + "_" + "MyTeam" + "_" + GlobalDeclaration._holdInfo[0].UserName;
                                sts = Resources.Instance.insertMasterrecord("Sp_insertMyTeamTrnByHR", "@srno", "@empid", "@empname", "@dptname", "@title", "@endDate", "@frmdate", "@tytpe", "@prvty", "@vanue", "@cpblty", "@sts", "@rptperson", Value);
                            }
                        }
                        else
                        {
                            string Value = DGVAddtrn.SelectedRows[0].Cells["SrNo"].Value.ToString() + "_" + DGVAddtrn.SelectedRows[0].Cells["empid"].Value.ToString() + "_" +
                                                   DGVAddtrn.SelectedRows[0].Cells["empname"].Value.ToString() + "_" + DGVAddtrn.SelectedRows[0].Cells["Dptname"].Value.ToString() + "_" +
                                                   DGVAddtrn.SelectedRows[0].Cells["trntitle"].Value.ToString() + "_" + DGVAddtrn.SelectedRows[0].Cells["endDate"].Value.ToString() + "_" +
                                                   DGVAddtrn.SelectedRows[0].Cells["frmdate"].Value.ToString() + "_" +
                                                   DGVAddtrn.SelectedRows[0].Cells["trntype"].Value.ToString() + "_" + DGVAddtrn.SelectedRows[0].Cells["prvty"].Value.ToString() + "_" +
                                                   DGVAddtrn.SelectedRows[0].Cells["vanue"].Value.ToString() + "_" +
                                                   DGVAddtrn.SelectedRows[0].Cells["cpblty"].Value.ToString() + "_" + "Single" + "_" + GlobalDeclaration._holdInfo[0].UserName;
                            sts = Resources.Instance.insertMasterrecord("Sp_insertMyTeamTrnByHR", "@srno", "@empid", "@empname", "@dptname", "@title", "@endDate", "@frmdate", "@tytpe", "@prvty", "@vanue", "@cpblty", "@sts", "@rptperson", Value);
                        }
                    }
                    if (sts > 0)
                    {
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Approval Send Successfully.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DGVAddtrn.ReadOnly = true;
                    }
                    else
                    {
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Error", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        DateTimePicker LastDateTimePicker;
        private void DGVAddtrn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                switch (DGVAddtrn.Columns[e.ColumnIndex].Name)
                {
                    case "frmdate":
                    case "endDate":
                        {
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
                        break;
                }
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

        private void DGVAddtrn_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // e.Cancel = false;
        }

        private void DGVAddtrn_Scroll(object sender, ScrollEventArgs e)
        {
            if (LastDateTimePicker != null)
                LastDateTimePicker.Visible = false;
        }
    }
}
