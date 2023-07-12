using DevExpress.XtraEditors;
using RMPCLApp.Class_Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using SparrowRMS;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMPCLApp.Form_Collection
{
    public partial class Frm_GlobalEmloyeeHierarchy : XtraForm
    {
        public Frm_GlobalEmloyeeHierarchy()
        {
            InitializeComponent();
        }
        #region "variable declaration"
        int i = 0;        
        public int DepartmentID
        {
            get;
            set;
        }
        List<Department_Master> departmodel = null;
        List<Employment_Type> empltypemodel = null;
        List<GeoTeam_Master> geolocatmodel = null;
        List<EmployeeDetail> employeeModel = null;
        DataTable reportsTo = null;
        DataTable Geolocation = null;
        DataTable DepartHead = null;
        DataTable Department = null;
        DataTable EmployType = null;
        DataTable AddEmpData = new DataTable();             
        bool isAddmoreEnable = false;
        bool isExists = false;
        string geocode = ""; string repCode = "";
        string reportmgr;
        List<int> empList = new List<int>();
        List<string> empCodeList = new List<string>();
        public static string empCode = "";
        public static string empemail = "";
        public static string empContact = "";
        public static string empName = "";
        string uploadPath = string.Empty;
        int DllId = 0;
        bool contains = false;
        string ReplicationCode = string.Empty;
        int deptid = 0;
        int empid = 0;
        string geoteam = string.Empty;
        string empname = string.Empty;
        string deptname = string.Empty;
        int GeoTeamId = 0;        
        #endregion
        #region "TextBox Events"
        #region "MessageBox"
        private void showMessage()
        {
            if (i > 0)
            {
                MessageBox.Show("Record saved Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Oops something went wrong!.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region "TabControl Events"
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
           //txtlocation.Text = RMPCLApp.Properties.Settings.Default.GeoLocation;
            if (tabControl1.SelectedIndex == 0)
            {
                flowLayoutPanel1.Visible = false;
                DBGridEmp.Visible = false;
                btnadd.Enabled = false;
               

            }
            else
            {
                flowLayoutPanel1.Visible = true;
                DBGridEmp.Visible = true;
                btnadd.Enabled = true;
            }
            if(tabControl1.SelectedTab.Text== "Add Department Head")
            {
                 DepartHead = Resources.Instance.GetDepartmentHeadAll();
                DgvDepartHead.DataSource = DepartHead;
                DgvDepartHead.Columns["DeptId"].Visible = false;
                DgvDepartHead.Columns["emp_id"].Visible = false;
                txtTeamHead.Text = txtGeoLocation.Text;
                txtTeamDept.Text = txtdepartment.Text;

                List<string> deptEmp = new List<string>();
                deptEmp = Resources.Instance.GetDepartmentWiseEmployee(DepartmentID);
                for (int i = 0; i < deptEmp.Count; i++)
                {
                    cmbEmploySelect.Items.Add(deptEmp[i]);
                }
            }
            if (tabControl1.SelectedTab.Text != "Employee Details")
            {
                btnsave.Enabled = false;

            }
            if (tabControl1.SelectedTab.Text == "Employee Details" || tabControl1.SelectedTab.Text  =="Add Department Head")
            {
                //ResetFunction();
                btncancel.Enabled = true;               
                DataTable AddEmpData = Resources.Instance.GetEmployeeList(4);
                DBGridEmp.DataSource = AddEmpData;
                DBGridEmp.Columns["emp_id"].Visible = false;
                DBGridEmp.Columns["RPTPerson"].Visible = false;// this line Add by Rp for MyTeam Traing Data Filter 
                string userid = Login_Form.LoginPanel.userid;
                empCodeList=Resources.Instance.GetUserCreatedAction(userid);
                btnsave.Enabled = true;
                cmbemptype.Items.Insert(0, "Select");                             
                // departmodel = Resources.Instance.GetDepartmentDetails(1);
                 empltypemodel = Resources.Instance.GetEmploymentDetails(3);
                 geolocatmodel = Resources.Instance.GetGeoLocationDetails(2);
                int i = 0;
                cmbemptype.Items.Clear();
                for (i = 0; i < empltypemodel.Count; i++)
                {
                    cmbemptype.Items.Add(empltypemodel[i].employ_Type.ToString());
                }

                //for (i = 0; i < geolocatmodel.Count; i++)
                //{
                //   // txtGeoLocate.Text= geolocatmodel[i].GeoTeam_Name.ToString();
                //}
                this.Enabled = true;
                btnsave.Enabled = true;
                 reportsTo = Resources.Instance.GetEmployeeName();
                // cmbreportmgr.DataSource = reportsTo.Columns[e;
                this.cmbreportmgr.Items.Clear();
                foreach (DataRow row in reportsTo.Rows)
                {
                    this.cmbreportmgr.Items.Add(row["emp_name"]);
                }
                this.cmbreportmgr.AutoCompleteMode = AutoCompleteMode.Suggest;
                this.cmbreportmgr.AutoCompleteSource = AutoCompleteSource.ListItems;

                for (int o = 0; o < DBGridEmp.Rows.Count - 1; o++)
                {
                    for (int m = 0; m < empCodeList.Count ; m++)
                    {
                        if (empCodeList[m] == DBGridEmp.Rows[o].Cells[2].Value.ToString())
                        {
                            var objType = DBGridEmp.Rows[o].Cells[0];
                            DBGridEmp.Rows[o].ReadOnly = true;
                            if (objType.GetType().Name == "DataGridViewButtonCell")
                            {
                                var cell = DBGridEmp[0, o] = new DataGridViewTextBoxCell();
                                cell.Value = "Add User"; // ignored if this column is databound

                                cell.ReadOnly = true;
                                cell.Style.BackColor = Color.White;
                                empList.Add(o);

                            }
                        }
                    }
                }
            }
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
          //  AddEmpData.Columns.Add("emp_id");
            AddEmpData.Columns.Add("emp_code");
            AddEmpData.Columns.Add("GeoTeamId");
            AddEmpData.Columns.Add("emp_name");
            AddEmpData.Columns.Add("DeptId");
            AddEmpData.Columns.Add("emailId");
            AddEmpData.Columns.Add("contact");
            AddEmpData.Columns.Add("ReportsToEmployeeCode");
            AddEmpData.Columns.Add("DOJ");
            AddEmpData.Columns.Add("EmpSoftcode");
            AddEmpData.Columns.Add("RPTPerson");// this column add by Rp for myTeam Person
            //   AddEmpData.Columns.Add("auto_invent_id");
            DataRow dataInvRow = AddEmpData.NewRow();
            AddEmpData.Rows.Add(dataInvRow);
            dataInvRow[0] = txtemplcode.Text;
            int geoindex = 0;
            for (int g = 0; g < geolocatmodel.Count; g++)
            {
                //if (txtLocation.Text.Trim() == geolocatmodel[g].ToString())
                //{
                //    geoindex = g;
                //}
            }
            dataInvRow[1] = geolocatmodel[geoindex].GeoTeamId;
            dataInvRow[2] = txtempname.Text;
            dataInvRow[3] = departmodel[0].DeptId;
            dataInvRow[4] = txtemail.Text;
            dataInvRow[5] = txtmobno.Text;
            string managerName="";
            for(int a=0;a<lstreportmgr.Items.Count-1;a++)
            {
                managerName = managerName+"," + lstreportmgr.Items[a].ToString();
            }
           
            dataInvRow[6] = managerName;
            dataInvRow[7] = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            dataInvRow[8] = txtsoftcode.Text;
           // AddEmpData.Rows.Add(dataInvRow);
            if (btnadd.Text == "Add")
            {
                //########### add datatable to addinventory function #############
               int insVal = Resources.Instance.AddEmployeeDetails(AddEmpData);
                if (insVal > 0)
                {
                    MessageBox.Show("Record Added Succesfully");
                    AddEmpData = Resources.Instance.GetEmployeeList(4);
                    DBGridEmp.DataSource = AddEmpData;
                   DBGridEmp.Columns["emp_id"].Visible = false;
                }
            }
        }

        private void Frm_GlobalEmloyeeHierarchy_Load(object sender, EventArgs e)
        {
           
            btnUpdEmplType.Enabled = false;
            Department = Resources.Instance.GetDepartmentDetailsDataTable(1);
            EmployType = Resources.Instance.GetEmploymentDetailsDataTable(3);
            DgvEmplType.DataSource = EmployType;
            DgvEmplType.Columns["emplmentTypeId"].Visible = false;
            //    DGVGeoLocation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvEmplType.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
           
            for (int a = 0; a < DgvEmplType.Columns.Count; a++)
            {
                DgvEmplType.Columns[a].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            this.Enabled = true;
            btnsave.Enabled = true;
            DataTable reportsTo = Resources.Instance.GetEmployeeName();
            // cmbreportmgr.DataSource = reportsTo.Columns[e;
            foreach (DataRow row in reportsTo.Rows)
            {
                this.cmbreportmgr.Items.Add(row["emp_name"]);
            }
            this.cmbreportmgr.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.cmbreportmgr.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        bool isAdded = true;
        private void btnaddmore_Click(object sender, EventArgs e)
        {
            try
            {
                isAddmoreEnable = true;
                //isAdded = true;
                this.lstreportmgr.Visible = true;
                // lstreportmgr.Items.Add(cmbreportmgr.Text);
                    txtreportmangr.Text = "";
                string firststr = "";
                string EmpGeoCode = string.Empty;
                repCode = "";
                for (int a = 0; a < lstreportmgr.Items.Count; a++)
                {
                    // reportmgr = cmbreportmgr.Text;
                    reportmgr = lstreportmgr.Items[a].ToString();
                    DataTable geoid = Resources.Instance.GetGeoLocationForEmployee(reportmgr);
                    geocode = geoid.Rows[0][2].ToString();//+geoid.Rows[b][1].ToString();
                   // EmpGeoCode = geocode;
                    //geocode = geocode.Substring(0, 1);
                    geocode = repCode+" " + geocode;//+ geoid.Rows[0][1].ToString();
                    repCode = geocode;
                  
                }
               txtsoftcode.Text= txtemplcode.Text + repCode.Replace(" ", "");

                if (string.IsNullOrEmpty(GlobalDeclaration.RPTPerson))  //This Line Add by RP (purpose of this line Filter  Myteam traing Reporting person only first Step)
                    GlobalDeclaration.RPTPerson = reportmgr;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void txtlocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 9)
            //{
            //    tabControl1.SelectedIndex = 1;
            //}
        }

        private void txtdepartment_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 9)
            //{
            //    tabControl1.SelectedIndex = 2;
            //}
        }

        private void txtemploytype_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 9)
            //{
            //    tabControl1.SelectedIndex = 3;
            //}
        }

        private void txtreportmangr_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string[] postSource = reportsTo
                            .AsEnumerable()
                            .Select<System.Data.DataRow, String>(x => x.Field<String>("emp_name"))
                            .ToArray();
                var source = new AutoCompleteStringCollection();
                source.AddRange(postSource);
                txtreportmangr.AutoCompleteCustomSource = source;
                txtreportmangr.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtreportmangr.AutoCompleteSource = AutoCompleteSource.CustomSource;
                string selDept = txtdepartment.Text;
                selDept = selDept.Substring(0, 1);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            txtsoftcode.Focus();
        }

      
        private void txtreportmangr_MouseLeave(object sender, EventArgs e)
        {
            if (lstreportmgr.Items.Count == 0 && isAddmoreEnable == false)
            {
                DataTable geoid = Resources.Instance.GetGeoLocationForEmployee(txtreportmangr.Text);
                for (int a = 0; a < geoid.Rows.Count; a++)
                {
                    int geoTeamId = Convert.ToInt32(geoid.Rows[a][0].ToString());
                    string geoTeamName = geolocatmodel[geoTeamId].GeoTeam_Name;
                }
            }
        }

        private void cmbreportmgr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstreportmgr.Items.Contains(cmbreportmgr.Text))
            {
                MessageBox.Show("Reporting Manager already added", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                lstreportmgr.Items.Add(cmbreportmgr.Text);
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void ResetAll()
        {
           // txtdepartment.Text = "";
            txtemail.Text = "";
            txtemplcode.Text = "";
           // txtemploytype.Text = "";
            txtempname.Text = "";
           // txtlocation.Text = "";
            txtmobno.Text = "";
            txtsoftcode.Text = "";
            cmbemptype.Text = "Select";
            cmbreportmgr.Text = "Select";

        }

        private void btnEmployement_Click(object sender, EventArgs e)
        {
            contains = EmployType.AsEnumerable().Any(row => txtemployement.Text == row.Field<String>("employ_type"));
            if (contains)
            {
                MessageBox.Show("Employement Type already Exists", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
               // txtemployement.Text = "";//
                txtemployement.Focus();
                isExists = true;
            }
            if (txtemployement.Text != "" && contains == false && isExists == false)
            {
                i = Resources.Instance.AddEmploymentHistory(txtemployement.Text, 3);
                showMessage();
              //  txtemployement.Text = "";
                tabControl1.SelectedIndex = 0;
                DataTable EmployType = Resources.Instance.GetEmploymentDetailsDataTable(3);
                DgvEmplType.DataSource = EmployType;
                DgvEmplType.Columns["emplmentTypeId"].Visible = false;
                DgvEmplType.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            }
            if(txtemployement.Text=="")
            {
                MessageBox.Show("Emolyement type cannot be left blank.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            isExists = false;
        }


        private void InsertionMethod()
        {
            AddEmpData.Columns.Clear();
            AddEmpData.Rows.Clear();
            AddEmpData.Columns.Add("emp_code");
            AddEmpData.Columns.Add("GeoTeamId");
            AddEmpData.Columns.Add("emp_name");
            AddEmpData.Columns.Add("DeptId");
            AddEmpData.Columns.Add("emailId");
            AddEmpData.Columns.Add("contact");
            AddEmpData.Columns.Add("ReportsToEmployeeCode");
            AddEmpData.Columns.Add("DOJ");
            AddEmpData.Columns.Add("EmpSoftcode");
            AddEmpData.Columns.Add("RPTPerson");// this Column Add by AP for MyTeam Person
            //   AddEmpData.Columns.Add("auto_invent_id");
            DataRow dataInvRow = AddEmpData.NewRow();
            AddEmpData.Rows.Add(dataInvRow);
            dataInvRow[0] = txtemplcode.Text;
            int geoindex = 0;
            //for (int g = 0; g < geolocatmodel.Count; g++)
            //{
            //    //if(txtLocation.Text.Trim()==geolocatmodel[g].ToString())
            //    //{
            //    //    geoindex = g;
            //    //}
            //}
            dataInvRow[1] = geolocatmodel[geoindex].GeoTeamId;
            dataInvRow[2] = txtempname.Text;
            int deptid = 0;
            dataInvRow[3] = DepartmentID;
            dataInvRow[4] = txtemail.Text;
            dataInvRow[5] = txtmobno.Text;
            string managerName = "";
            for (int a = 0; a < lstreportmgr.Items.Count; a++)
            {
                managerName = lstreportmgr.Items[a].ToString() + "," + managerName;
            }

            dataInvRow[6] = managerName;
            dataInvRow[7] = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            dataInvRow[8] = txtsoftcode.Text;
            dataInvRow["RPTPerson"] = GlobalDeclaration.RPTPerson;
            // AddEmpData.Rows.Add(dataInvRow);
            if (btnadd.Text == "Save")
            {
                //########### add datatable to addinventory function #############
                int insVal = Resources.Instance.AddEmployeeDetails(AddEmpData);
                if (insVal > 0)
                {
                    MessageBox.Show("Record Added Succesfully");
                    AddEmpData = Resources.Instance.GetEmployeeList(4);
                    DBGridEmp.DataSource = AddEmpData;
                    DBGridEmp.Columns["RPTPerson"].Visible = false;// This Line Add by RP For myTeam Person
                    GlobalDeclaration.RPTPerson = string.Empty;
                    ResetFunction();
                }
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            //  AddEmpData.Columns.Add("emp_id");
            try
            {

                DialogResult res = MessageBox.Show("Are you sure you want to Continue", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    InsertionMethod();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    DialogResult = DialogResult.None;
                }


            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DBGridEmp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;
                if (senderGrid.CurrentCell.ColumnIndex == 0)
                {
                    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.ColumnIndex == 0 && !empList.Contains(e.RowIndex))
                    // if (e.ColumnIndex==0 && e.GetType().Name.ToString()=="DataGridViewButtonCell")
                    {
                        empCode = DBGridEmp.Rows[e.RowIndex].Cells[2].Value.ToString();
                        empemail = DBGridEmp.Rows[e.RowIndex].Cells[6].Value.ToString();
                        empContact = DBGridEmp.Rows[e.RowIndex].Cells[7].Value.ToString();
                        empName = DBGridEmp.Rows[e.RowIndex].Cells[4].Value.ToString();
                        //Form_Collection.ForgotPassword fgtpwd = new ForgotPassword();
                        //fgtpwd.Show();
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DBGridEmp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chkDelete_CheckedChanged(object sender, EventArgs e)
        {
            if (lstreportmgr.SelectedIndex == -1 && chkDelete.Checked==true)
            {
                MessageBox.Show("Please select Employee from the List", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chkDelete.Checked = false;
            }
            else
            {
                if (chkDelete.Checked == true)
                {
                    string empname = lstreportmgr.Text;
                    DataTable geoid = Resources.Instance.GetGeoLocationForEmployee(empname);
                    geocode = geoid.Rows[0][2].ToString();
                    txtsoftcode.Text = txtsoftcode.Text.Replace(geocode, "");
                    // chkDelete.Checked = false;
                    lstreportmgr.Items.Remove(empname);
                    // repCode = repCode.Replace(geocode, "");
                    repCode = "";
                    chkDelete.Checked = false;
                  //  cmbreportmgr.Text = "";
                }
                
            }
           
           // lstreportmgr.SelectedIndex = 0;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            ResetFunction();
        }

        private void ResetFunction()
        {
            repCode = "";
            lstreportmgr.Items.Clear();
            cmbemptype.Text = "";
            cmbreportmgr.Text = "";
            txtemail.Text = "";
            txtemplcode.Text = "";
            txtemployement.Text = "";
            txtempname.Text = "";
            txtmobno.Text = "";
            txtreportmangr.Text = "";
            txtsoftcode.Text = "";

        }
        bool isvalidemail = false;
        private void txtemail_Leave(object sender, EventArgs e)
        {
            if (txtemail.Text != "")
            {
                IsValidEmail(txtemail.Text);
            }
            else
            {
                MessageBox.Show("Email cannot be blank!.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

      private void IsValidEmail(string strIn)
        {
            bool isEmail = Regex.IsMatch(txtemail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
       if(isEmail==true)
            {

            }
            else
            {
                MessageBox.Show("Not a valid email.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtemail.Text = "";
                txtemail.Focus();
            }
        
        }

        private void txtmobno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

       
        private void txtmobno_Leave(object sender, EventArgs e)
        {
          if(txtmobno.Text.Length<10)
            {
                MessageBox.Show("Enter valid Mobile No.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            browseImageFile();
            string filename = System.IO.Path.GetFileName(lblUpload.Text);
                   
        }

        public void READExcel(string path)
        {
            //Instance reference for Excel Application
            Microsoft.Office.Interop.Excel.Application objXL = null;
            //Workbook refrence
            Microsoft.Office.Interop.Excel.Workbook objWB = null;
            DataSet ds = new DataSet();
            try
            {
                //Instancing Excel using COM services
                objXL = new Microsoft.Office.Interop.Excel.Application();
                //Adding WorkBook
                objWB = objXL.Workbooks.Open(lblUpload.Text);
                foreach (Microsoft.Office.Interop.Excel.Worksheet objSHT in objWB.Worksheets)
                {
                    int rows = objSHT.UsedRange.Rows.Count;
                    int cols = objSHT.UsedRange.Columns.Count;

                    int noofrow = 1;
                    AddEmpData.Columns.Clear();
                    AddEmpData.Clear();
                    for (int c = 1; c <= cols; c++)
                    {
                        string colname = objSHT.Cells[1, c].Text;
                        AddEmpData.Columns.Add(colname);
                        noofrow = 2;
                    }
                    //END
                    for (int r = noofrow; r <= rows; r++)
                    {
                        DataRow dr = AddEmpData.NewRow();
                        for (int c = 1; c <= cols; c++)
                        {
                            dr[c - 1] = objSHT.Cells[r, c].Text;
                        }
                        AddEmpData.Rows.Add(dr);
                    }
                    ds.Tables.Add(AddEmpData);
                }
                int addUser = Resources.Instance.AddEmployeeDetails(AddEmpData);
                if (addUser > 0)
                {
                    XtraMessageBox.Show(new Form { TopMost = true }, "Employee Uploaded Successfully.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true }, "Oops something went wrong!..", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // MessageBox.Show("Oops something went wrong!..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                //Closing workbook
                objWB.Close();
                //Closing excel application
                objXL.Quit();

            }
            catch (Exception ex)
            {
                objWB.Saved = true;
                //Closing work book
                objWB.Close();
                //Closing excel application
                objXL.Quit();
                //Response.Write("Illegal permission");
            }

        }
        public void browseImageFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse For Any Document",
                CheckFileExists = true,
                CheckPathExists = true,

                //DefaultExt = "txt",
                Filter = "Excel Files (*.xlsx;*.xls)|*.xlsx;*.xls",
                //FilterIndex = 2,
                //RestoreDirectory = true,
                ReadOnlyChecked = false,
                // ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lblUpload.Text = openFileDialog1.FileName;
                lblUpload.Visible = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string[] extension = (uploadPath.ToString()).Split('.');
            //   ImportToDataTable(uploadPath, extension[1],"YES");
            Thread readExceltoDatatable = new Thread(() => READExcel(lblUpload.Text));
            readExceltoDatatable.Start();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int deptIndex = 0;
            int deptId = departmodel[deptIndex].DeptId;
            List<string> deptEmp = new List<string>();
            deptEmp = Resources.Instance.GetDepartmentWiseEmployee(DepartmentID);
            for(int i=0;i<deptEmp.Count;i++)
            {
                cmbEmploySelect.Items.Add(deptEmp[i]);
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
          //  int deptIndex = ;
            int deptId = DepartmentID;
            int geoindex = 0;
            for (int g = 0; g < geolocatmodel.Count; g++)
            {
                //if (txtLocation.Text.Trim() == geolocatmodel[g].ToString())
                //{
                //    geoindex = g;
                //}
            }
            
            int GeoTeamId = geolocatmodel[geoindex].GeoTeamId;

            int empIndex = cmbEmploySelect.SelectedIndex;
            employeeModel = Resources.Instance.GetEmployeeId();
            int empId = employeeModel[empIndex].emp_id;
            if (btnAddHead.Text == "Save")
            {

                int i = Resources.Instance.AddDepartmentHead(deptId, empId, GeoTeamId, "Head");
                if (i > 0)
                {
                    MessageBox.Show("Head Assigned successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DepartHead = Resources.Instance.GetDepartmentHeadAll();
                    DgvDepartHead.DataSource = DepartHead;
                }
                else
                {
                    MessageBox.Show("Oops something went wrong!..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
               
                int a = Resources.Instance.UpdateDepartHead(deptid, empid, 1);
                if (a > 0)
                {
                    MessageBox.Show("Record updated successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Oops something went wrong!..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
       
        private void btnUpdEmplType_Click(object sender, EventArgs e)
        {
            try
            {
                int a = Resources.Instance.UpdateEmployeeDetails(txtemployement.Text, DllId, 3);
                if (a > 0)
                {
                    MessageBox.Show("Record updated successfully!..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable EmployType = Resources.Instance.GetEmploymentDetailsDataTable(3);
                    DgvEmplType.DataSource = EmployType;
                }
                else
                {
                    MessageBox.Show("Oops something went wrong!..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DgvEmplType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0 && e.RowIndex != -1)
                {
                    txtemployement.Text = DgvEmplType.Rows[e.RowIndex].Cells[3].Value.ToString();
                    btnUpdEmplType.Enabled = true;
                    DllId = Convert.ToInt32(DgvEmplType.Rows[e.RowIndex].Cells[2].Value.ToString());
                }
                if(e.ColumnIndex==1 && e.RowIndex != -1)
                {
                    int a = Resources.Instance.DropEmployeeDetails(DgvEmplType.Rows[e.RowIndex].Cells[3].Value.ToString(), 3);
                    if (a > 0)
                    {
                        MessageBox.Show("Employement Type Deleted successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Oops something went wrong!..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                    DataTable EmployType = Resources.Instance.GetEmploymentDetailsDataTable(3);
                    DgvEmplType.DataSource = EmployType;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtlocation_Leave(object sender, EventArgs e)
        {
            // contains = Geolocation.AsEnumerable().Any(row => txtlocation.Text == row.Field<String>("GeoTeam_Name"));
            //if(contains)
            //{
            //    MessageBox.Show("Geo Location already Exists", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtlocation.Text = "";
            //    txtlocation.Focus();
            //}
        }

      
        private void txtemployement_Leave(object sender, EventArgs e)
        {
            try
            {
                contains = EmployType.AsEnumerable().Any(row => txtemployement.Text == row.Field<String>("employ_type"));
                if (contains)
                {
                    MessageBox.Show("Employement Type already Exists", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtemployement.Text = "";
                    txtemployement.Focus();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void DgvDepartHead_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==0)
            {
               // btnAddHead.Text = "Update";
               // deptid = Convert.ToInt32(DgvDepartHead.Rows[e.RowIndex].Cells[1].Value);
               // empid = Convert.ToInt32(DgvDepartHead.Rows[e.RowIndex].Cells[2].Value);
               // GeoTeamId=  Convert.ToInt32(DgvDepartHead.Rows[e.RowIndex].Cells[3].Value);
                                
               //var georesult = geolocatmodel.Find(x => x.GeoTeamId == GeoTeamId);
               // geoteam = georesult.GeoTeam_Name;
               // var deptresult= departmodel.Find(x => x.DeptId == deptid);
               // deptname = deptresult.Dept_Name;
               // var empresult = employeeModel.Find(x => x.emp_id == empid);
               // empname = empresult.emp_name;
               // cmbDeptSelect.SelectedItem = deptname;
            }
        }

        private void DGVGeoLocation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DGVGeoLocation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
#endregion