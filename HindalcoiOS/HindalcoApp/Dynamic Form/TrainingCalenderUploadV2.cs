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

namespace HindalcoiOS.Dynamic_Form
{
    public partial class TrainingCalenderUpload : XtraForm
    {
        delegate void SetComboBoxCellType(int iRowIndex, string clmname, int iColumnIndex);
        private bool bIsComboBox;
        int AutoIncreamet = 0;
        public bool IsCallHr;
        public bool IsNewRowAdd;
        //DataTable EmployeList = null;
        //DataTable EmployeListTR = null;
        // DataTable dDepatName = null;
        private string CallingFormName;
        public TrainingCalenderUpload(string frmName)
        {
            InitializeComponent();
            this.Text = "Training Calender Upload Details";
            UpdateTextPosition();
            CallingFormName = frmName;
        }
        private void TrainingCalenderUpload_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CallingFormName))
                //btnDownLoad.Visible = true;
                GridSeeting();
            //HrcontextMneu.Enabled = false;
            addTrainingToolStripMenuItem.Visible = false;
            // EmployeList = Resources.Instance.GetDataKey("SP_GetEmployeeName");
            // EmployeListTR = Resources.Instance.GetDataKey("SP_GetEmployeeNameForTraining");
            // if (IsCallHr)
            {

                // dDepatName = Resources.Instance.GetDataKey("Sp_FetchDeptMasterLoad");
            }
        }
        private void GridSeeting()
        {
            try
            {
                DgvCalender.BorderStyle = BorderStyle.Fixed3D;

                DgvCalender.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                DgvCalender.AllowUserToResizeColumns = false;

                DgvCalender.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


                DgvCalender.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;

                DgvCalender.DefaultCellStyle.SelectionForeColor = Color.Black;
                DgvCalender.RowsDefaultCellStyle.BackColor = Color.LightGray;
                DgvCalender.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
                DgvCalender.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                DgvCalender.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.Visible = false);

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
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvCalender.Rows.Count > 0)
                {
                    int sts = 0;
                    DataTable dt = GetContentAsDataTable(true);
                    if (dt.Rows.Count > 0)
                    {
                        if (IsCallHr && !string.IsNullOrEmpty(CallingFormName))
                        {
                            XtraMessageBox.Show("Need To discuss for Hr Data Type Sample.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            if (dtSourceMultipleRow.Rows.Count > 0 && IsmutipleRow)
                            {
                                sts = Resources.Instance.SaveMainTenenceData("Sp_InsertMutipleEmployeeTrainingInfo", "@emptblmutiple", dtSourceMultipleRow);
                            }
                            sts = Resources.Instance.SaveMainTenenceData("Sp_InsertEmployeeTrainingInfo", "@emptbl", dt);
                        }
                        //InsertDataInDB();
                        if (sts > 0)
                        {
                            XtraMessageBox.Show("Data Save SuccessFully..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.OK;

                        }
                        else
                        {
                            XtraMessageBox.Show("Data Save UnSuccessFully..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            DialogResult = DialogResult.None;
                        }
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        DataTable dtSourceMultipleRow = null;
        bool IsmutipleRow;
        public DataTable GetContentAsDataTable(bool IgnoreHideColumns = false)
        {
            try
            {
                if (DgvCalender.ColumnCount == 0) return null;
                DataTable dtSource = new DataTable();
                dtSourceMultipleRow = new DataTable();
                foreach (DataGridViewColumn col in DgvCalender.Columns)
                {
                    if (IgnoreHideColumns & !col.Visible) continue;
                    if (col.Name == string.Empty) continue;
                    if (col.Name == "btnagncy") continue;
                    if (col.Name == "Startdate" || col.Name == "EndDate")
                    {
                        dtSource.Columns.Add(col.Name, typeof(DateTime));
                        dtSourceMultipleRow.Columns.Add(col.Name, typeof(DateTime));
                    }
                    else
                    {
                        dtSource.Columns.Add(col.Name);
                        dtSourceMultipleRow.Columns.Add(col.Name);
                    }
                    dtSource.Columns[col.Name].Caption = col.HeaderText;
                    dtSourceMultipleRow.Columns[col.Name].Caption = col.HeaderText;
                }
                dtSourceMultipleRow.Columns.Add("RPTPerson", typeof(string));
                if (dtSource.Columns.Count == 0) return null;

                List<DataGridViewRow> rows1 = new List<DataGridViewRow>(from DataGridViewRow r in DgvCalender.Rows where !r.Cells["EmpName"].Value.ToString().Contains(",") select r);
                List<DataGridViewRow> rows2 = new List<DataGridViewRow>(from DataGridViewRow r in DgvCalender.Rows where r.Cells["EmpName"].Value.ToString().Contains(",") select r);
                foreach (DataGridViewRow row in rows1)
                {
                    DataRow drNewRow = dtSource.NewRow();
                    foreach (DataColumn col in dtSource.Columns)
                    {
                        if (row.Cells[col.ColumnName].Value.ToString() == "InActive")
                        {
                            drNewRow[col.ColumnName] = "NA";
                        }
                        else
                        {

                            drNewRow[col.ColumnName] = row.Cells[col.ColumnName].Value;
                        }
                    }
                    dtSource.Rows.Add(drNewRow);
                }
                if (rows2.Count > 0)
                {
                    IsmutipleRow = true;
                    string Update = string.Empty;
                    foreach (DataGridViewRow row in rows2)
                    {
                        DataRow DrMultiple = dtSourceMultipleRow.NewRow();
                        foreach (DataColumn col in dtSourceMultipleRow.Columns)
                        {
                            if (col.ColumnName == "RPTPerson") continue;
                            if (row.Cells[col.ColumnName].Value.ToString() == "InActive")
                            {
                                DrMultiple[col.ColumnName] = "NA";
                            }
                            else
                            {
                                if (col.ColumnName == "EmpName")
                                {

                                    string[] valuuu = row.Cells[col.ColumnName].Value.ToString().Split(',');
                                    for (int i = 0; i < valuuu.Length; i++)
                                    {
                                        string receiveValue = valuuu[i];
                                        if (Resources.Instance.EmployeListTR.Select("emp_name='" + receiveValue.Trim() + "'").FirstOrDefault().ItemArray[2].ToString() == string.Empty)
                                        {
                                            Update = Update + "," + receiveValue;
                                        }
                                        else
                                        {
                                            string date = Resources.Instance.EmployeListTR.Select("emp_name='" + receiveValue.Trim() + "'").FirstOrDefault().ItemArray[2].ToString();
                                            Update = Update + "," + date;
                                        }
                                    }
                                    Update = Update.Substring(1);
                                    DrMultiple["RPTPerson"] = Update;
                                    DrMultiple[col.ColumnName] = row.Cells[col.ColumnName].Value;
                                }
                                else
                                {
                                    if (col.ColumnName != "RPTPerson")
                                        DrMultiple[col.ColumnName] = row.Cells[col.ColumnName].Value;
                                }
                            }
                        }
                        dtSourceMultipleRow.Rows.Add(DrMultiple);
                    }
                }
                return dtSource;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private void InsertDataInDB() // this method should be call for Add runtime titile and Type
        {
            string GenerateCode = string.Empty;
            try
            {
                int LastNumber = 1;
                if (DgvCalender.Rows.Count > 0)
                {
                    var distinctRows = DgvCalender.Rows.Cast<DataGridViewRow>().Select(x => x.Cells["TraingType"].Value.ToString()).Distinct().ToList();
                    for (int i = 0; i < distinctRows.Count; i++)
                    {
                        string Type = distinctRows[i];
                        DataTable dt = Resources.Instance.InlineQuery("select max(Tcode) as Tcode from ListOfTrainingCodeTBL where Ttype = '" + Type + "' group by Ttype");
                        LastNumber = Convert.ToInt32(dt.Rows[0]["Tcode"].ToString().Substring(4, dt.Rows[0]["Tcode"].ToString().Length - 4));
                        var distictrow = DgvCalender.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["TraingType"].Value.ToString().Equals(Type)).ToList();
                        for (int j = 0; j < distictrow.Count; j++)
                        {
                            GenerateCode = (distictrow[j].Cells["TraingType"].Value.ToString().First() + "000") + ++LastNumber;
                            string data = GenerateCode + "_" + distictrow[j].Cells["TrainingTitle"].Value.ToString() + "_" + distictrow[j].Cells["TraingType"].Value.ToString();
                            string Recultstring = string.Empty;
                            Resources.Instance.InsertMasterrecord("Sp_InsertTrainingCode", "@tcode", "@ttitle", "@ttype", "@returnValue", data, out Recultstring);
                            if (Recultstring.Trim() == "Add Successfully")
                            {
                                //XtraMessageBox.Show(Recultstring, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {

                                string list = distictrow[j].Cells["TrainingTitle"].Value.ToString();
                                XtraMessageBox.Show("this item=  " + list + " \n " + Recultstring + "", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LastNumber--;
                                continue;
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

        private void btncancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;
            this.Close();
        }

        private void btnbrowser_Click(object sender, EventArgs e)
        {
            var obd = openFileDialog1.ShowDialog();
            openFileDialog1.Title = "Please Enter File Name";
            // openFileDialog1.Filter = "Supported files | *.xls; *.xlsx; *.xlsb; *.csv | xls | *.xls | xlsx | *.xlsx | xlsb | *.xlsb | csv | *.csv | All | *.*";           
            if ((obd != DialogResult.OK) || (string.IsNullOrEmpty(openFileDialog1.FileName)))
            {
                return;
            }
            txtfile.Text = this.openFileDialog1.FileName;
        }
        public DataSet ds;
        private void btnLoad_Click(object sender, EventArgs e)
        {
            // Upload Maintenance Excel Sheet  from Drive
            try
            {
                if (!string.IsNullOrEmpty(txtfile.Text))
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
                    var tablenames = GlobalDeclaration.GetTablenames(ds.Tables);
                    sheetCombo.DataSource = tablenames;
                    if (tablenames.Count > 0)
                        sheetCombo.SelectedIndex = 0;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (IsCallHr)
                    AutoIncreamet = int.Parse(DgvCalender.Rows[this.DgvCalender.Rows.Count - 1].Cells["SrNo"].Value.ToString());
            }
        }
        public string SelectTable()
        {
            var tablename = sheetCombo.SelectedItem.ToString();

            //dgventry.AutoGenerateColumns = true;
            //dgventry.DataSource = ds; // dataset
            //dgventry.DataMember = tablename;
            GetValues(ds, tablename);
            return tablename;
        }
        public void GetValues(DataSet dataset, string sheetName)
        {
            try
            {
                string ColumnValue = string.Empty;
                string DeptName = string.Empty;
                if (DgvCalender.Rows.Count > 0) return;
                int uu = dataset.Tables[sheetName].Rows.Count;
                int RowNumberCount = 1;
                for (int i = 0; i < dataset.Tables[sheetName].Rows.Count; i++)
                {
                    DataRow row = dataset.Tables[sheetName].Rows[i];
                    DgvCalender.Rows.Add();
                    if (dataset.Tables[sheetName].Columns.Count > 4)
                    {
                        DgvCalender.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.Visible = true);
                        if (row["Capability(Internal/External)"].ToString() == "External")
                        {

                            // DgvCalender.Columns["btnagncy"].Visible = true;
                            // DgvCalender.Columns["Nameoftrainer"].Visible = false;
                            DgvCalender.Rows[i].Cells["Nameoftrainer"].Value = "InActive";
                        }
                        else
                        {
                            DataGridViewButtonCell dgbtn = null;
                            dgbtn = (DataGridViewButtonCell)(DgvCalender.Rows[i].Cells["btnagncy"]);
                            dgbtn.UseColumnTextForButtonValue = false;
                            dgbtn.Value = "InActive";
                            // DgvCalender.Columns["Nameoftrainer"].Visible = true;
                            DgvCalender.Rows[i].Cells["Nameoftrainer"].Value = row["Name of Trainer"].ToString();
                        }
                        DgvCalender.Rows[i].Cells["SrNo"].Value = AutoIncreamet = RowNumberCount++;
                        if (row["Employee Code"].ToString().Contains(','))
                        {
                            ColumnValue = EmployeeNameUpdate(row["Employee Code"].ToString());
                            DeptName = DeparNameSet(row["Employee Code"].ToString());
                        }
                        else
                        {

                            ColumnValue = Resources.Instance.EmployeListTR.Select("emp_code='" + row["Employee Code"].ToString() + "'").FirstOrDefault().ItemArray[0].ToString();
                            DataRow[] ChecckUt = Resources.Instance.dDepatName.Select("EmpCode='" + row["Employee Code"].ToString() + "'");
                            if (ChecckUt.Length != 0)
                            {
                                DeptName = Resources.Instance.dDepatName.Select("EmpCode='" + row["Employee Code"].ToString() + "'").FirstOrDefault().ItemArray[1].ToString();
                            }
                            else
                            {
                                DeptName = "NA";
                            }
                        }
                        DgvCalender.Rows[i].Cells["EmpName"].Value = ColumnValue;
                        DgvCalender.Rows[i].Cells["Dpt"].Value = DeptName;
                        DgvCalender.Rows[i].Cells["TrainingTitle"].Value = row["Training Title"].ToString();
                        DgvCalender.Rows[i].Cells["TraingType"].Value = row["Training Type"].ToString();
                        DgvCalender.Rows[i].Cells["Startdate"].Value = row["Training Start date"].ToString();
                        DgvCalender.Rows[i].Cells["EndDate"].Value = row["Training Completion Date"].ToString();
                        DgvCalender.Rows[i].Cells["Duration"].Value = row["Duration"].ToString();
                        DgvCalender.Rows[i].Cells["Capability"].Value = row["Capability(Internal/External)"].ToString();
                        DgvCalender.Rows[i].Cells["Vanue"].Value = row["Venue/Location"].ToString();
                        DgvCalender.Rows[i].Cells["Measurement"].Value = row["Effectiveness"].ToString();
                        DgvCalender.Rows[i].Cells["Status"].Value = row["Status"].ToString();
                        DgvCalender.Rows[i].Cells["TrnCode"].Value = TrainerCode(row["Name of Trainer"].ToString(), row["Capability(Internal/External)"].ToString());
                    }
                    //else
                    //{
                    //    DgvCalender.Columns["SrNo"].Visible = true;
                    //    DgvCalender.Columns["TraingType"].Visible = true;
                    //    DgvCalender.Columns["TrainingTitle"].Visible = true;
                    //    DgvCalender.Columns["Capability"].Visible = true;
                    //    DgvCalender.Rows[i].Cells["SrNo"].Value = row["SI.No"].ToString();
                    //    DgvCalender.Rows[i].Cells["TrainingTitle"].Value = row["Training Title"].ToString();
                    //    DgvCalender.Rows[i].Cells["TraingType"].Value = row["Training Type"].ToString();
                    //    DgvCalender.Rows[i].Cells["Capability"].Value = row["Capability"].ToString();
                    //}
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string EmployeeNameUpdate(string Clumn)
        {
            string Update = string.Empty;
            string[] valuuu = Clumn.Split(',');
            for (int i = 0; i < valuuu.Length; i++)
            {
                string receiveValue = valuuu[i];
                string date = Resources.Instance.EmployeListTR.Select("emp_code='" + receiveValue.Trim() + "'").FirstOrDefault().ItemArray[0].ToString();
                Update = Update + "," + date;
            }
            Update = Update.Substring(1);
            return Update;
        }
        private string TrainerCode(string TrainerName, string Capability)
        {
            if (Capability == "External")
            {
                return "DemoTRN";
            }
            else
            {
                return Resources.Instance.EmployeListTR.Select("emp_name='" + TrainerName.Trim() + "'").FirstOrDefault().ItemArray[1].ToString();
            }
        }
        private string DeparNameSet(string Name)
        {
            string Update = string.Empty;
            string[] valuuu = Name.Split(',');
            for (int i = 0; i < valuuu.Length; i++)
            {
                string receiveValue = valuuu[i];
                string date = Resources.Instance.dDepatName.Select("EmpCode='" + receiveValue.Trim() + "'").FirstOrDefault().ItemArray[1].ToString();
                Update = Update + "," + date;
            }
            Update = Update.Substring(1);
            return Update;
        }
        private void DgvCalender_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (IsCallHr && IsNewRowAdd)
                {
                    SetComboBoxCellType objChangeCellType = new SetComboBoxCellType(ChangeCellToComboBox);
                    if (e.ColumnIndex == this.DgvCalender.Columns["TraingType"].Index)
                    {
                        this.DgvCalender.BeginInvoke(objChangeCellType, e.RowIndex, "TType", e.ColumnIndex);
                        bIsComboBox = false;

                    }
                    else if (e.ColumnIndex == this.DgvCalender.Columns["Capability"].Index)
                    {
                        this.DgvCalender.BeginInvoke(objChangeCellType, e.RowIndex, "Capbility", e.ColumnIndex);
                        bIsComboBox = false;
                    }
                    else if (e.ColumnIndex == this.DgvCalender.Columns["EmpName"].Index)
                    {
                        this.DgvCalender.BeginInvoke(objChangeCellType, e.RowIndex, "empname", e.ColumnIndex);
                        bIsComboBox = false;
                    }
                    else if (e.ColumnIndex == this.DgvCalender.Columns["Dpt"].Index)
                    {
                        this.DgvCalender.BeginInvoke(objChangeCellType, e.RowIndex, "DeptName", e.ColumnIndex);
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
                if (bIsComboBox == false && IsCallHr)
                {
                    if (ColumnName == "TType")
                    {
                        if (DgvCalender[iColumnIndex, iRowIndex].Value != null) return;
                        DataGridViewComboBoxCell dgComboCell = new DataGridViewComboBoxCell();
                        dgComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        string query = "select distinct  ltrim(rtrim(TrainingType)) as TraingType from GenericTrainingTitleList";
                        DataTable dt = Resources.Instance.InlineQuery(query);
                        if (dt.Rows.Count > 0)
                        {
                            dgComboCell.DataSource = dt;
                            dgComboCell.ValueMember = "TraingType";
                            dgComboCell.DisplayMember = "TraingType";
                        }
                        DgvCalender[iColumnIndex, iRowIndex] = dgComboCell;
                        bIsComboBox = true;
                    }

                    else if (ColumnName == "Capbility")
                    {
                        if (DgvCalender[iColumnIndex, iRowIndex].Value != null) return;
                        DataGridViewComboBoxCell dgComboCellPrioty = new DataGridViewComboBoxCell();
                        dgComboCellPrioty.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgComboCellPrioty.ReadOnly = false;
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Name", typeof(string));
                        string[] ArrayList = { "Internal", "External" };
                        for (int i = 0; i < ArrayList.Length; i++)
                        {
                            DataRow dr = dt.NewRow();
                            dr["Name"] = ArrayList[i].ToString();
                            dt.Rows.Add(dr);
                        }
                        dgComboCellPrioty.DataSource = dt;
                        dgComboCellPrioty.ValueMember = "Name";
                        dgComboCellPrioty.DisplayMember = "Name";
                        DgvCalender[iColumnIndex, iRowIndex] = dgComboCellPrioty;
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "empname")
                    {
                        if (DgvCalender[iColumnIndex, iRowIndex].Value != null) return;
                        DataGridViewComboBoxCell dgComboCell = new DataGridViewComboBoxCell();
                        dgComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgComboCell.DataSource = Resources.Instance._EmpName;
                        dgComboCell.ValueMember = "emp_name";
                        dgComboCell.DisplayMember = "emp_name";
                        DgvCalender[iColumnIndex, iRowIndex] = dgComboCell;
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "DeptName")
                    {
                        if (DgvCalender[iColumnIndex, iRowIndex].Value != null) return;
                        DataGridViewComboBoxCell dgComboCell = new DataGridViewComboBoxCell();
                        dgComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgComboCell.DataSource = Resources.Instance.dDepatName;
                        dgComboCell.ValueMember = "DepartName";
                        dgComboCell.DisplayMember = "DepartName";
                        DgvCalender[iColumnIndex, iRowIndex] = dgComboCell;
                        bIsComboBox = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void sheetCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectTable();
        }
        private void DgvCalender_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9 && DgvCalender.CurrentCell is DataGridViewButtonCell)
            {
                DataGridViewButtonCell dgbtn = null;
                dgbtn = (DataGridViewButtonCell)(DgvCalender.Rows[e.RowIndex].Cells[e.ColumnIndex]);
                if (dgbtn.Value.ToString() == "Link VMS")
                {
                    //AddHardwareRFQ vms = new AddHardwareRFQ();
                    //vms.TopMost = true;
                    //vms.Show();
                    DgvCalender.Rows[e.RowIndex].Cells["Nameoftrainer"].Value = "VMSTrainer";
                    //if (vms.ShowDialog() == DialogResult.OK)
                    //{
                    //    DgvCalender.Rows[e.RowIndex].Cells["Nameoftrainer"].Value = "VMSTrainer";
                    //}
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true }, "Can't Call VMS", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
        }
        #region Dynamic Call Method From HR Tab
        public void DynamicGridSetting()
        {
            DgvCalender.ReadOnly = false;
            // HrcontextMneu.Visible = true;
            //HrcontextMneu.Enabled = true;
            addTrainingToolStripMenuItem.Visible = true;

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
                if (IsCallHr)
                {
                    DataGridViewRow rowadd = new DataGridViewRow();
                    DgvCalender.Rows.Insert(0, rowadd);
                    AutoIncreamet++;
                    DgvCalender.Rows[0].Cells["SrNo"].Value = AutoIncreamet;
                    DgvCalender.Columns["SrNo"].ReadOnly = true;
                    IsNewRowAdd = true;
                    DgvCalender.ReadOnly = false;
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true }, " Only Hr User Can Have Add!!!?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
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
                // if (IsCallHr)
                {
                    if (DgvCalender.Rows.Count > 0)
                    {
                        if (this.DgvCalender.SelectedRows.Count > 0)
                        {
                            int indes = this.DgvCalender.SelectedRows[0].Index;
                            DgvCalender.Rows.RemoveAt(indes);
                            AutoIncreamet--;
                            IsNewRowAdd = false;
                            DgvCalender.ReadOnly = true;
                        }
                        else
                        {
                            XtraMessageBox.Show(new Form { TopMost = true }, "Please Select Row First.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DgvCalender_KeyDown(object sender, KeyEventArgs e)
        {
            if (IsCallHr)
            {
                if (e.KeyData == (Keys.Control | Keys.A))
                {
                    AddNewRow();
                }
                else if (e.KeyData == (Keys.Control | Keys.D) || e.KeyData == Keys.Delete)
                {
                    DeleteRow();
                }
            }
        }


        #endregion


        #region Hr Call DownnLoad Format
        private DataGridView DgvTraining;
        private System.Windows.Forms.SaveFileDialog dlgSaveEnt;
        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            DgvTraining = new DataGridView();
            try
            {
                //switch (reporttype)
                //{
                //    case "Employee":
                DgvTraining.ColumnCount = 14;
                DgvTraining.Columns[0].Name = "SrNo";
                DgvTraining.Columns[0].HeaderText = "Sl.No";

                DgvTraining.Columns[1].Name = "EmpName";
                DgvTraining.Columns[1].HeaderText = "Employee Code";

                //DgvTraining.Columns[2].Name = "Dpt";
                //DgvTraining.Columns[2].HeaderText = "Department";

                DgvTraining.Columns[2].Name = "TrainingTitle";
                DgvTraining.Columns[2].HeaderText = "Training Title";

                DgvTraining.Columns[3].Name = "TraingType";
                DgvTraining.Columns[3].HeaderText = "Training Type";

                DgvTraining.Columns[4].Name = "Startdate";
                DgvTraining.Columns[4].HeaderText = "Training Start date";
                DgvTraining.Columns[4].ValueType = typeof(DateTime);

                DgvTraining.Columns[5].Name = "EndDate";
                DgvTraining.Columns[5].HeaderText = "Training Completion Date";
                DgvTraining.Columns[5].ValueType = typeof(DateTime);

                DgvTraining.Columns[6].Name = "Duration";
                DgvTraining.Columns[6].HeaderText = "Duration";

                DgvTraining.Columns[7].Name = "Capability";
                DgvTraining.Columns[7].HeaderText = "Capability(Internal/External)";

                DgvTraining.Columns[8].Name = "NameOfAgency";
                DgvTraining.Columns[8].HeaderText = "Name of Agency";

                DgvTraining.Columns[9].Name = "Nameoftrainer";
                DgvTraining.Columns[9].HeaderText = "Name of Trainer";

                DgvTraining.Columns[10].Name = "Venue";
                DgvTraining.Columns[10].HeaderText = "Venue/Location";

                DgvTraining.Columns[11].Name = "Measurement";
                DgvTraining.Columns[11].HeaderText = "Effectiveness";
                DgvTraining.Columns[12].Name = "Status";
                DgvTraining.Columns[12].HeaderText = "Status";

                //    break;
                //default:
                //    DgvTraining.ColumnCount = 4;
                //    DgvTraining.Columns[0].Name = "SrNo";
                //    DgvTraining.Columns[0].HeaderText = "SI.No";
                //    DgvTraining.Columns[1].Name = "TraingType";
                //    DgvTraining.Columns[1].HeaderText = "Training Type";
                //    DgvTraining.Columns[2].Name = "TrainingTitle";
                //    DgvTraining.Columns[2].HeaderText = "Training Title";
                //    DgvTraining.Columns[3].Name = "Capability";
                //    DgvTraining.Columns[3].HeaderText = "Capability";
                //    break;

                DgvTraining.BorderStyle = BorderStyle.Fixed3D;

                DgvTraining.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                DgvTraining.AllowUserToResizeColumns = false;

                DgvTraining.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


                DgvTraining.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;

                DgvTraining.DefaultCellStyle.SelectionForeColor = Color.Black;
                DgvTraining.RowsDefaultCellStyle.BackColor = Color.LightGray;
                DgvTraining.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
                DgvTraining.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);


                // var openTiming = f.ElapsedMilliseconds;
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                //app.Visible = true;           
                worksheet = workbook.Sheets["Sheet1"];
                PopulateDropdown(worksheet);
                worksheet = workbook.ActiveSheet;
                for (int i = 1; i < DgvTraining.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = DgvTraining.Columns[i - 1].HeaderText;
                }
                ((Microsoft.Office.Interop.Excel.Range)worksheet.Rows[1, Type.Missing]).Font.Bold = true;
                ((Microsoft.Office.Interop.Excel.Range)worksheet.Rows[1, Type.Missing]).Font.Size = 11;
                worksheet.Columns.EntireColumn.AutoFit();
                dlgSaveEnt = new SaveFileDialog();
                dlgSaveEnt.Filter = "*.xlsx|*.xlsx|*.csv|*.csv";
                dlgSaveEnt.Title = " HR Training File Name";
                if (dlgSaveEnt.ShowDialog() != DialogResult.OK)
                    return;
                string fname = dlgSaveEnt.FileName;
                if (fname != null)
                {
                    // save the application  

                    workbook.SaveAs(fname, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    XtraMessageBox.Show("Format Save Successfully", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Exit from the application  
                    app.Quit();
                    btnDownLoad.Visible = false;
                }
                // f.Stop();
                //string Time= "Elapsed: " + (f.ElapsedMilliseconds/1000).ToString() + " ms (" + openTiming.ToString() + " ms to open)";
                // MessageBox.Show(Time);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void PopulateDropdown(Microsoft.Office.Interop.Excel._Worksheet oSheet)
        {
            oSheet.Range["B2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, GetEmployeeDwn());
            //oSheet.Range["C2:C50"].Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
            //    Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, GetDeptNameDwn());
            oSheet.Range["D2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
               Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, TraingTypeDownload());
            oSheet.Range["H2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
               Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, CapabilityDownload());
            oSheet.Range["J2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
              Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, EmpNameString());
        }
        private string TraingTypeDownload()
        {
            StringBuilder strBuilder = new StringBuilder();
            try
            {
                // string query = "select distinct  ltrim(rtrim(TrainingType)) as TraingType from GenericTrainingTitleList";
                // DataTable dt = Resources.Instance.InlineQuery(query);
                if (Resources.Instance._TrainingType.Rows.Count > 0)
                {
                    for (int i = 0; i < Resources.Instance._TrainingType.Rows.Count; i++)
                    {
                        string excelVal = Resources.Instance._TrainingType.Rows[i]["TraingType"].ToString();

                        strBuilder.Append(excelVal);

                        strBuilder.Append(",");
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strBuilder.ToString();
        }
        private string CapabilityDownload()
        {
            StringBuilder strBuilder = new StringBuilder();
            try
            {
                string[] capabilty = new string[] { "Internal", "External" };
                for (int i = 0; i < capabilty.Length; i++)
                {
                    string excelVal = capabilty[i];
                    strBuilder.Append(excelVal);

                    strBuilder.Append(",");
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strBuilder.ToString();
        }
        private string GetEmployeeDwn()
        {
            StringBuilder strBuilder = new StringBuilder();
            try
            {
                // DataTable dt = Resources.Instance.GetDataKey("SP_GetEmployeeName");
                if (Resources.Instance.EmployeListTR.Rows.Count > 0)
                {
                    for (int i = 0; i < Resources.Instance.EmployeListTR.Rows.Count; i++)
                    {
                        string excelVal = Resources.Instance.EmployeListTR.Rows[i]["emp_code"].ToString();
                        strBuilder.Append(excelVal);
                        strBuilder.Append(",");
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strBuilder.ToString();
        }
        private string EmpNameString()
        {
            StringBuilder strBuilder = new StringBuilder();
            try
            {
                // DataTable dt = Resources.Instance.GetDataKey("SP_GetEmployeeName");
                if (Resources.Instance._EmpName.Rows.Count > 0)
                {
                    for (int i = 0; i < Resources.Instance._EmpName.Rows.Count; i++)
                    {
                        string excelVal = Resources.Instance._EmpName.Rows[i]["emp_name"].ToString();
                        strBuilder.Append(excelVal);
                        strBuilder.Append(",");
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strBuilder.ToString();
        }
        private string GetDeptNameDwn()
        {
            StringBuilder strBuilder = new StringBuilder();
            try
            {
                //  DataTable dt = Resources.Instance.GetDataKey("Sp_GetDeptMaster");
                if (Resources.Instance.DepartmentMaster.Rows.Count > 0)
                {
                    for (int i = 0; i < Resources.Instance.DepartmentMaster.Rows.Count; i++)
                    {
                        string excelVal = Resources.Instance.DepartmentMaster.Rows[i]["DepartName"].ToString();

                        strBuilder.Append(excelVal);

                        strBuilder.Append(",");
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strBuilder.ToString();
        }
        #endregion
    }
}
