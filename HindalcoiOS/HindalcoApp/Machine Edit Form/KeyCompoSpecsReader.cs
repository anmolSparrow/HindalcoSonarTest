using DevExpress.XtraEditors;
using ExcelDataReader;
using OfficeOpenXml;
using RMPCLApp.Class_Operation;
using RMPCLApp.Form_Collection;
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
using System.Xml;

namespace RMPCLApp.Machine_Edit_Form
{
    public partial class KeyCompoSpecsReader : Form
    {
        #region "Variable declaration"
        DataTable SpecsDT = new DataTable();
        DataTable GenralDT = new DataTable();
        DataTable SpecificDT = new DataTable();
        DataTable globalDt = new DataTable();
        DataTable tabset = new DataTable();
        DataTable tabset1 = new DataTable();
        DataGridViewComboBoxCell cmbunit = new DataGridViewComboBoxCell();
        DataGridViewComboBoxCell cmbunit1 = new DataGridViewComboBoxCell();
        string parametername = "";
        #endregion
        int currentTab = 0; int rowindex = 0;
        bool isExists = false;
        private string _Machinename;
        private string _MacName;
        public static string[] dataunit = new string[] { };
        public static string[] dataunit1 = new string[] { };
        List<string> dataUnit = new List<string>();
        List<string> LSTSREAM = new List<string>();
        List<string> paramlist = new List<string>();
        List<string> unitlist = new List<string>();
        List<string> maxlis = new List<string>();
        List<string> minlist = new List<string>();
        List<string> data_type = new List<string>();
        List<string> headerlst = new List<string>();
        List<string> controlType = new List<string>();
        List<string> paramTag = new List<string>();
        List<string> dataTag = new List<string>();
        List<string> addunit = new List<string>();
        List<string> rfqlist = new List<string>();
        List<string> headerarr = new List<string>();
        string app_Path;
        string replHeader = "";
        string arrval = "";
        public static bool isFileFound = true;
        DataTable mytable = GlobalDeclaration.CreateTable();
        List<string> matchedArr = new List<string>();
        int param_id = 0;
        public KeyCompoSpecsReader(string MachineName,string macName)
        {
            this._MacName = macName;
            this._Machinename = MachineName;
            InitializeComponent();
        }

        private void AddGeneralColumns()
        {
            GenralDT.Columns.Add("Parameter",typeof(string));
            GenralDT.Columns.Add("Unit", typeof(string));
            GenralDT.Columns.Add("Min Val.", typeof(string));
            GenralDT.Columns.Add("Max Val.", typeof(string));
            //GenralDT.Columns.Add("", typeof(string));
            //GenralDT.Columns.Add("", typeof(string));

        }

        private void AddGeneralColumnsHeader()
        {
            tabset1.Columns.Add("Parameter", typeof(string));
            tabset1.Columns.Add("Unit", typeof(string));
            tabset1.Columns.Add("Min Val.", typeof(string));
            tabset1.Columns.Add("Max Val.", typeof(string));
            tabset1.Columns.Add("NotAvailable", typeof(bool));
            tabset1.Columns.Add("NotApplicable", typeof(bool));

        }
        private void AddSpecificColumns()
        {
            SpecificDT.Columns.Add("Parameter", typeof(string));
            SpecificDT.Columns.Add("Unit", typeof(string));
            SpecificDT.Columns.Add("Min Val.", typeof(string));
            SpecificDT.Columns.Add("Max Val.", typeof(string));
            //GenralDT.Columns.Add("", typeof(string));
            //GenralDT.Columns.Add("", typeof(string));

        }

        private void KeyCompoSpecsReader_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = this._Machinename;
                readExcelSheet(this.Text);
                tabindexvalchanged(0);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        bool fileExist = false;
        DataGridView dbview = new DataGridView();
        private void ReUsabaleAction()
        {
            try
            {
                string machineData = GlobalDeclaration.ReturnPath() + @"\" + "KeyComponentData"+@"\"+"KeyComponentsUserData" + @"\" + GlobalDeclaration.MCDMacName + "_" + tabControl1.SelectedTab.Tag.ToString() + ".xml";
                if (File.Exists(machineData))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(machineData);
                    // dbview .DataSource = ds.Tables[0];
                    isExists = true;
                    dbview.Enabled = true;
                    dbview.Visible = true;
                    dbview.Width = 1250;
                    dbview.Height = 760;
                    dbview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    DBGridGeneral.Visible = false;
                    tabset1.Clear();
                    tabset1.Columns.Clear();
                    tabset.Clear();
                    tabset.Columns.Clear();
                    tabset = XMLToDataTable(machineData);
                    DTHeader();
                    for (int i = 0; i < tabset.Rows.Count; i++)
                    {
                        DataRow newDr = tabset1.NewRow();
                        newDr[0] = tabset.Rows[i][0].ToString();
                        newDr[1] = tabset.Rows[i][1];
                        newDr[2] = tabset.Rows[i][2];
                        newDr[3] = tabset.Rows[i][3];
                        newDr[4] = tabset.Rows[i][4];
                        newDr[5] = tabset.Rows[i][5];
                        newDr[6] = tabset.Rows[i][6];
                        newDr[7] = tabset.Rows[i][7];
                        newDr[8] = tabset.Rows[i][8];
                        newDr[9] = tabset.Rows[i][9];
                        newDr[10] = tabset.Rows[i][10];
                        newDr[11] = tabset.Rows[i][11];
                        newDr[12] = tabset.Rows[i][13];
                        tabset1.Rows.Add(newDr);
                    }
                    dbview.DataSource = tabset1;
                    tabControl1.SelectedTab.Controls.Add(dbview);
                    dbview.Columns["Data_Tag"].Visible = false;
                    dbview.Columns["Param_Tag"].Visible = false;
                    dbview.Columns["Header_Id"].Visible = false;
                    //dbview.Columns["Control Type"].Visible = false;
                    dbview.Columns["Rfq"].Visible = false;
                    dbview.Columns["RFQ"].Visible = true;
                    dbview.Columns["MachineName"].Visible = false;
                    dbview.Columns["Control_Type"].Visible = false;
                    dbview.AllowUserToAddRows = false;
                    dbview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    for (int a = 0; a < dbview.Columns.Count; a++)
                    {
                        dbview.Columns[a].SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    // tabset1.Columns.Clear();
                   getcontroltypeReload();
                }
                else
                {
                    //btnsavespecs.Enabled = true;
                    DBGridGeneral.Enabled = true;
                    DBGridGeneral.Visible = true;
                    if (tabControl1.SelectedTab.Text == "General")
                    {
                        currentTab = currentTab + 1;
                    }
                    else
                    {
                        currentTab = currentTab + 2;
                    }
                    tabset = mytable.AsEnumerable().Where(r => r.Field<int>("Header Id") == currentTab).CopyToDataTable();
                    int rowindex = 0;
                    foreach (DataRow rows in tabset.Rows)
                    {
                        string paramname = rows.Field<string>("Parameter Name");
                        string objectype = rows.Field<string>("Unit");
                        string paramtag1 = rows.Field<string>("Param Tag");
                        tabset.Rows[rowindex][1] = paramname.ToString() + " " + paramtag1;
                        DBGridGeneral.AutoGenerateColumns = true;
                        DBGridGeneral.AllowUserToAddRows = false;
                        DBGridGeneral.Columns.Clear();
                        DBGridGeneral.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        rowindex = rowindex + 1;
                    }
                    if (currentTab != 1)
                    {
                        tabset.Rows.RemoveAt(0);
                    }
                    DBGridGeneral.DataSource = tabset;
                    if (mytable.Rows.Count > 1)
                    {
                        DBGridGeneral.Columns["Data Tag"].Visible = false;
                        DBGridGeneral.Columns["Param Tag"].Visible = false;
                        DBGridGeneral.Columns["Header Id"].Visible = false;
                        DBGridGeneral.Columns["Control Type"].Visible = false;
                        DBGridGeneral.Columns["Rfq"].Visible = false;
                        DBGridGeneral.Columns["MachineName"].Visible = false;
                        columnsAsReadOnly();
                        tabControl1.SelectedTab.Controls.Add(this.DBGridGeneral);
                        getcontroltype();
                        addrows();
                    }
                    else
                    {
                        MessageBox.Show("No Record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DBGridGeneral_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
                string Value = DBGridGeneral.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (Value == "AddNew")
                {
                    rowindex = e.RowIndex;
                    AddNewUnitFrm mainlyt = new AddNewUnitFrm(tabset, parametername, dataUnit, param_id);
                    // mainlyt.updateComboUnit += GetSpecificationUnitEvent;
                    mainlyt.Show();
                }

            }
        }

        private static bool OtherUnit = false;
        private void getcontroltypeReload()
        {
            try
            {
                for (int s = 0; s < dbview.RowCount; s++)
                {

                    var controltype = dbview.Rows[s].Cells[12].Value;
                    // string typeofcontrol = tabset.Tables[0].Rows[i].Field<string>("control_type");
                    switch (controltype)
                    {
                        case "cmbbox":
                            {
                                cmbunit.Value = "TypeOfControl";
                                char[] splitterbox = new char[] { '/' };
                                if (dbview.Rows[s].Cells[3].Value.ToString() != "")
                                {
                                    string tagvalue = dbview.Rows[s].Cells[8].Value.ToString();
                                    dataunit = tagvalue.Split(splitterbox);
                                    //  dataUnit.Add(dataunit[0]);
                                }
                                else
                                {
                                    cmbunit.Items.Add("Select");
                                }

                                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                                string oprtingVal = dbview.Rows[s].Cells[5].Value.ToString();
                                dbview.Rows[s].Cells[5].Value = "";
                                dbview[5, s] = comboCell;
                                //dbview.Rows[s].Cells[3].Value = "";
                                //dbview[3, s] = comboCell;
                                // comboCell.Items.Add("Select");
                                comboCell.Items.AddRange(dataunit);

                                // comboCell.ReadOnly=true;
                                // dbview.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dbview_DataGridViewEditingControlShowingEventHandler);
                                parametername = dbview[2, s].Value.ToString();
                                OtherUnit = true;

                                for (int a = 0; a < dataunit.Count(); a++)
                                {
                                    //if (oprtingVal != dataunit.GetValue(a).ToString())
                                    //{
                                    if (!comboCell.Items.Contains(oprtingVal))
                                    {
                                        //Once CustomerId is matched, select the Country in ComboBoxCell.
                                        //comboCell.Value = oprtingVal;
                                        comboCell.Items.Add(oprtingVal);
                                        comboCell.Value = oprtingVal;
                                    }
                                    else
                                    {
                                        comboCell.Value = oprtingVal;
                                    }
                                    // }
                                }

                                comboCell.Items.Add("AddNew");
                                // dbview[5, s].Value = dbview.Rows[s].Cells[5].Value;
                                break;

                            }
                        case "checkbox":
                            {
                                // cmbunit.Value = "TypeOfcheck";
                                DataGridViewCheckBoxCell chkboxcell = new DataGridViewCheckBoxCell();
                                // chkboxcell.Selected = true;
                                dbview[3, s] = chkboxcell;
                                chkboxcell.Value = false;
                                dbview.DefaultCellStyle.DataSourceNullValue = 0;
                                //dataGridView1.CellMouseClick += new DataGridViewCellEventHandler(dataGridView1_CheckBoxCheckChange);
                                //  dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
                                OtherUnit = true;
                                break;
                            }

                        case "staticdata":
                            {

                                this.dbview.Rows[s].ReadOnly = true;
                                OtherUnit = true;
                                this.dbview.Rows[s].Cells[3].Value = string.Empty;
                                break;
                            }

                        case "staticdata1":
                            {

                                this.dbview.Rows[s].ReadOnly = true;
                                OtherUnit = true;
                                this.dbview.Rows[s].Cells[3].Value = string.Empty;
                                break;
                            }

                        case "multiunit":
                            {
                                parametername = dbview[1, s].Value.ToString();
                                string datatag = dbview[7, s].Value.ToString();
                                dbview.Rows[s].Cells[1].Value = parametername + " " + datatag;
                                cmbunit.Value = "typemultiunit";
                                char[] splitterbox = new char[] { '/' };
                                string[] splitterbox1 = new string[] { "OR" };

                                if (dbview.Rows[s].Cells[2].Value.ToString() == "-")
                                {
                                    string tagvalue = dbview.Rows[s].Cells[8].Value.ToString();
                                    dataunit = tagvalue.Split(splitterbox);
                                }
                                else
                                {
                                    string tagvalue = dbview.Rows[s].Cells[2].Value.ToString();
                                    dataunit = tagvalue.Split(splitterbox1, StringSplitOptions.None);
                                }

                                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                                // dataGridView1.Rows[s].Cells[3].Value = "";
                                string oprtingVal = dbview.Rows[s].Cells[2].Value.ToString();
                                this.dbview.Rows[s].Cells[2].Value = string.Empty;
                                dbview[2, s] = comboCell;
                                comboCell.Items.Add("Select");
                                comboCell.Items.AddRange(dataunit);
                                OtherUnit = true;

                                for (int a = 0; a < dataunit.Count(); a++)
                                {
                                    if (oprtingVal == dataunit.GetValue(a).ToString())
                                    {
                                        //Once CustomerId is matched, select the Country in ComboBoxCell.
                                        comboCell.Value = oprtingVal;
                                    }
                                }
                                break;
                            }

                        case "description":
                            {
                                DataGridViewTextBoxCell txtbxcl = new DataGridViewTextBoxCell();
                                txtbxcl.Value = "";
                                dbview.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                                //dataGridView1.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                                dbview.AutoResizeRow(s, DataGridViewAutoSizeRowMode.AllCellsExceptHeader);
                                dbview.AutoResizeColumn(3);
                                //this.dbview.Rows[s].Cells[4].Value = string.Empty;
                                OtherUnit = true;
                                this.dbview.Rows[s].Cells[3].Value = string.Empty;
                                break;

                            }

                        case "multiinput":
                            {
                                DataGridViewTextBoxCell txtbxcl1 = new DataGridViewTextBoxCell();
                                dbview.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                                this.dbview.Rows[s].Cells[3].Value = string.Empty;
                                OtherUnit = true;
                                break;
                            }

                            //case "-":
                            //    {
                            //        this.dbview.Rows[s].Cells[3].Value = string.Empty;
                            //        this.dbview.Rows[s].Cells[3].Value = tabset1.Rows[s][3].ToString();
                            //        break;
                            //    }

                    }
                    if (this.dbview.Rows[s].Cells[1].Value.ToString().Contains("_"))
                    {
                        string oldValue = dbview.Rows[s].Cells[1].Value.ToString();
                        if (oldValue.Contains("_"))
                        {
                            oldValue = oldValue.Replace("_", " ");
                        }
                        this.dbview.Rows[s].Cells[1].Value = oldValue;
                    }
                    //if (dbview.Rows[s].Cells[1].Value.ToString() == tabname)
                    //{
                    //    this.dbview.Rows[s].Visible = false;
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //private void readExcelSheet(string filename)
        //{
        //    try
        //    {
        //        if (filename.Contains("_"))
        //        {
        //            filename = filename.Split('_')[0];
        //        }
        //        string app_Path = Application.StartupPath + @"\KeyComponentData\" + @"SpecsData" + @"\" + filename + ".xlsx";
        //        if (!File.Exists(app_Path))
        //        {
        //            XtraMessageBox.Show("File not found!", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        else
        //        {
        //          SpecsDT= ExcelToDataTableUsingExcelDataReader(app_Path);
        //        }

        //    }
        //    catch (Exception Ex)
        //    {
        //        XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}



        private void readExcelSheet(string filename)
        {
            try
            {
                if (filename.Contains("_"))
                {
                    filename = filename.Split('_')[0];
                }

                app_Path = Application.StartupPath + @"\KeyComponentData\" + @"SpecsData" + @"\" + filename + ".xlsx";
               // app_Path = GlobalDeclaration.ReturnPath() + @"\Images\" + foldername + @"\" + subtype + @"\" + filename + ".xlsx";
                if (!File.Exists(app_Path))
                {
                    isFileFound = false;
                    XtraMessageBox.Show("File not found!", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var package = new ExcelPackage(new FileInfo(app_Path));
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                    List<GetMachineHeader> headerlist = Resources.Instance.GetMchineHeader();
                    int rcount = workSheet.Dimension.End.Row;
                    int colcnt = workSheet.Dimension.End.Column;

                    // object cellValue = workSheet.Cells[i, j].Value;
                    string[,] strarr = new string[rcount, colcnt];
                    int a = 0; int b = 0;
                    for (int k = 2; k <= workSheet.Dimension.End.Row; k++)
                    {
                        for (int m = 2; m <= workSheet.Dimension.End.Column; m++)
                        {
                            if (workSheet.Cells[k, m].Value == null)
                            {
                                string replaceval = "-";
                                arrval = arrval + replaceval + ",";
                                strarr[a, b] = arrval;
                            }
                            else
                            {
                                arrval = arrval + workSheet.Cells[k, m].Value.ToString() + ",";
                                strarr[a, b] = arrval;
                            }
                            if (m == workSheet.Dimension.End.Column)
                            {
                                //arrval = "";
                                //a = a + 1;
                                arrval = "";
                                a = a + 1;
                                //  b = b + 1;
                                break;

                            }
                        }
                    }
                    List<string> lst = strarr.Cast<string>().ToList();
                    lst = lst.Where(x => x != null).ToList();
                    string[] quarter = lst[0].Split(new Char[] { ',' }, 10);
                    string parameter1 = "";
                    int y = 0;
                    string header = quarter[0].ToString();
                    //string nexthead=","+
                    string empspc = "," + "-" + "," + "-" + "," + "-" + "," + "-" + "," + "-" + "," + "-" + "," + "-" + "," + "-" + ",";
                    int itemrnbge = 0; int p = 0; int differ = 0;

                    List<string> headerArr = new List<string>();
                    headerArr.Add(tabControl1.TabPages[0].Text);
                    headerArr.Add(tabControl1.TabPages[1].Text);
                    //if (header == headerlist[y].header_name)
                    //{

                    bool isFirstMatch = false;
                    while (y<headerArr.Count)
                    {
                    string headername = tabControl1.TabPages[1].Text;
                    string concat = headername + empspc;
                   
                    int item = lst.FindIndex(x => x.Trim() == concat.Trim());
                    //itemrnbge = item - itemrnbge;
                    string[] operators = new string[] { " ", "-", "(", ")", "/", "\\", "°" };
                    if(isFirstMatch==true)
                    {
                        item = lst.Count;
                    }
                    for (p = itemrnbge; p < item -1; p++)
                    {
                        isFirstMatch = true;
                        string[] commaseperated = lst[p + 1].Split(new Char[] { ',' }, 10);
                        string paramval = commaseperated[0].Trim().ToString();
                        string unitval = commaseperated[1].Trim().ToString();
                        string maxval = commaseperated[3].ToString();
                        string minval = commaseperated[2].ToString();
                        string dtype = commaseperated[5].Trim().ToString();
                        string rfq = commaseperated[4].Trim();
                        if (rfq == "-")
                        {
                            rfq = "0";
                        }
                        else
                        {
                            rfq = "1";
                        }
                        string controltype = commaseperated[6].Trim().ToString();
                        if (controltype == null)
                        {
                            controltype = "-";
                        }
                        string paramtype = commaseperated[7].Trim().ToString();
                        if (paramtype == null)
                        {
                            paramtype = "-";
                        }
                        string dtatype = commaseperated[8].Trim().ToString();
                        if (dtatype == "-")
                        {
                            dtatype = "-";
                        }
                        parameter1 = lst[p + 1] + headerlist[y].header_id;
                        LSTSREAM.Add(parameter1);
                        replHeader = paramval.Trim();
                        paramlist.Add(paramval.Trim());
                        string removedstr = "";
                        removedstr = replHeader.Replace("_", " ");
                        unitlist.Add(unitval);
                        maxlis.Add(maxval);
                        minlist.Add(minval);
                        controlType.Add(controltype);
                        paramTag.Add(paramtype);
                        dataTag.Add(dtatype);
                        rfqlist.Add(rfq);
                        headerlst.Add(headerlist[y].header_id.ToString());
                        mytable.Rows.Add(this.Text.Trim(), paramlist[p].ToString(), unitlist[p].ToString(), minlist[p].ToString(), maxlis[p].ToString(), "0", rfqlist[p].ToString(), paramTag[p].ToString(), dataTag[p].ToString(), Convert.ToInt32(headerlst[p].ToString()), controlType[p].ToString());
                            }

                            itemrnbge = p;
                            differ = item - itemrnbge;
                            y = y + 1;

                            int startHeaderindex = lst.FindIndex(x => x == header + empspc);
                            string nextHeadername = headerlist[y].header_name;
                            int endHeaderindex = lst.FindIndex(x => x == nextHeadername + empspc);
                            differ = endHeaderindex - startHeaderindex;
                            //if (differ > 1)
                            //{
                            //    headerarr.Add(headerlist[y].header_name);
                            //}
                            //else
                            //{
                            //    headerarr.Remove(headerlist[y - 1].header_name);
                            //    headerarr.Add(headerlist[y].header_name);
                            //}

                            //  headerarr.RemoveAt(6);
                        //    header = headerlist[y].header_name;
                        //    if (y == headerlist.Count - 1)
                        //    {
                        //        break;
                        //    }

                        //}
                        //headerarr.Add("General");
                        //matchedArr = headerarr;
                        //machineDs.Tables.Add(mytable);
                        //machineDs.WriteXml(Application.StartupPath + @"\" + "DraggedMachine" + ".xml");
                 }

                }

            }
            catch (Exception ex)
            {
                //  Resources.Instance.DropTableSecond(); //------>>>> on error drop the secondary temporary table as this creates a overhead
                MessageBox.Show(ex.Message);
            }

        }
        public DataTable ExcelToDataTableUsingExcelDataReader(string storePath)
        {
            FileStream stream = File.Open(storePath, FileMode.Open, FileAccess.Read);
            string fileExtension = Path.GetExtension(storePath);
            IExcelDataReader excelReader = null;
            if (fileExtension == ".xls")
            {
                excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
            }
            else if (fileExtension == ".xlsx")
            {
                excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            }
            // excelReader.IsFirstColumn = true;
            DataSet result = excelReader.AsDataSet();
            var test = result.Tables[0];
            return result.Tables[0];
        }

        bool istransferGen = false;
        bool istransferSpec = false;

        private void tabindexvalchanged(int currentTab)
        {
            try
            {
                ReUsabaleAction();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string machineData = GlobalDeclaration.ReturnPath() + @"\" + "KeyComponentData"+@"\"+"KeyComponentsUserData" + @"\" + GlobalDeclaration.MCDMacName + "_"  + tabControl1.SelectedTab.Text.ToString() + ".xml";
            int selind = tabControl1.SelectedIndex;
            if (File.Exists(machineData))
            {
                tabindexvalchanged(selind);
                DataSet ds = new DataSet();
                ds.ReadXml(machineData);
                DBGridGeneral.DataSource = ds.Tables[0];
                isExists = true;
                DBGridGeneral.Columns["Data Tag"].Visible = false;
                DBGridGeneral.Columns["Param Tag"].Visible = false;
                DBGridGeneral.Columns["Header Id"].Visible = false;
                DBGridGeneral.Columns["Control Type"].Visible = false;
                DBGridGeneral.Columns["Rfq"].Visible = false;
                DBGridGeneral.Columns["RFQ"].Visible = false;
                DBGridGeneral.Columns["MachineName"].Visible = false;
               }
            else
            {
                currentTab = 0;
                tabindexvalchanged(selind);
            }
        }
           
        private void addrows()
        {
            try
            {
                //  if (!GlobalDeclaration.UserType.Equals("U1-Maintenance") || GlobalDeclaration.UserType.Equals("U1-Safety")) return;

                DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
                dgvCmb.ValueType = typeof(bool);
                dgvCmb.Name = "RFQ";
                dgvCmb.HeaderText = "RFQ";
                DataGridViewCheckBoxColumn dgisavail = new DataGridViewCheckBoxColumn();
                dgisavail.ValueType = typeof(bool);
                dgisavail.Name = "NotAvailable";
                dgisavail.HeaderText = "NotAvailable";
                DataGridViewCheckBoxColumn dgisapplcbl = new DataGridViewCheckBoxColumn();
                dgisapplcbl.ValueType = typeof(bool);
                dgisapplcbl.Name = "NotApplicable";
                dgisapplcbl.HeaderText = "NotApplicable";
            //dataGridView1.Columns.Add(dgvCmb);
            //dataGridView1.Columns.Add(dgisavail);
            //dataGridView1.Columns.Add(dgisapplcbl);
                DBGridGeneral.Columns.Insert(9, dgvCmb);
                DBGridGeneral.Columns.Insert(10, dgisavail);
                DBGridGeneral.Columns.Insert(11, dgisapplcbl);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void columnsAsReadOnly()
        {
            for (int i = 0; i < 2; i++)
            {
                DBGridGeneral.Columns[i].ReadOnly = true;
            }
        }
        public DataTable XMLToDataTable(string YourFilePath)
        {
            DataTable table = new DataTable("XMLTABLE");
            try
            {
                var xmlContent = File.ReadAllText(YourFilePath);
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(xmlContent.Replace("'", "&apos;").Replace("&", "&amp;"));
                xDoc.Save(YourFilePath);
                //All XML Document Content
                //XmlElement root = xDoc.DocumentElement;
                string RootNode = xDoc.DocumentElement.Name;
                string RootChildNode = xDoc.DocumentElement.LastChild.Name;
                DataSet lstNode = new DataSet();
                lstNode.ReadXml(YourFilePath);
                table = lstNode.Tables[RootChildNode];

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return table;
        }

        private void DTHeader()
        {
            // tabset1.Columns.Add("ParameterId");
            tabset1.Columns.Add("MachineName", typeof(string));
            tabset1.Columns.Add("Parameter Name");
            //tabset1.Columns.Add("Unit1");
            tabset1.Columns.Add("Unit");
            tabset1.Columns.Add("Minimum Value");
            tabset1.Columns.Add("Maximum Value");
            tabset1.Columns.Add("Operating Value");
            tabset1.Columns.Add("param_tag");
            tabset1.Columns.Add("data_tag");
            tabset1.Columns.Add("header_id");
            tabset1.Columns.Add("RFQ", typeof(bool));
            tabset1.Columns.Add("NotAvailable", typeof(bool));
            tabset1.Columns.Add("NotApplicable", typeof(bool));
            tabset1.Columns.Add("Control_Type", typeof(string));

        }

        //private void getControlTypeReload(DataGridView dbgrid)
        //{
        //    try
        //    {
        //        Boolean ifconOR = false;
        //        string[] dataunit = new string[] { };
        //        int m = 0;
        //        for (int s = 0; s < dbgrid.Rows.Count; s++)
        //        {
        //            if (SpecsDT.Rows[s][0].ToString() == "Specific Parameter")
        //            {
        //                for (int b = 0; b < s; b++)
        //                {
        //                    SpecsDT.Rows.RemoveAt(b);
        //                }
        //            }
        //                var controltype = SpecsDT.Rows[s][1];
        //                if (controltype.ToString().Contains("OR"))
        //                {
        //                    ifconOR = true;
        //                }
        //                // string typeofcontrol = tabset.Tables[0].Rows[i].Field<string>("control_type");
        //                if (ifconOR == true)
        //                {
        //                    cmbunit.Value = "TypeOfControl";
        //                    string[] splitterbox = new string[] { "OR" };
        //                    if (SpecsDT.Rows[s][1].ToString() != "")
        //                    {
        //                        string tagvalue = SpecsDT.Rows[s][1].ToString();
        //                        //dataunit = tagvalue.Split(new[] { "OR" }, StringSplitOptions.None).ToString();
        //                        dataunit = tagvalue.Split(new string[] { "OR" }, StringSplitOptions.None);

        //                        //  dataUnit.Add(dataunit[0]);
        //                    }
        //                    else
        //                    {
        //                        cmbunit.Items.Add("");
        //                    }
        //                    DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
        //                    dbgrid.Rows[s].Cells[1].Value = "";
        //                    dbgrid[1, s] = comboCell;
        //                    comboCell.Items.Add("");
        //                    comboCell.Items.AddRange(dataunit);
        //                    //comboCell.Items.Add("AddNew");
        //                    parametername = dbgrid[1, s].Value.ToString();
        //                    // string[] combined = dataunit.Concat(dataunit1).ToArray();
        //                    // comboCell.Items.AddRange(combined);
        //                    // break;
        //                    ifconOR = false;
        //                }
        //            }



        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(new Form { TopMost = true }, ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


        private void getcontroltype()
        {
            try
            {
                for (int s = 0; s < DBGridGeneral.RowCount; s++)
                {
                    var controltype = DBGridGeneral.Rows[s].Cells[10].Value;
                    // string typeofcontrol = tabset.Tables[0].Rows[i].Field<string>("control_type");
                    switch (controltype)
                    {
                        case "cmbbox":
                            {
                                cmbunit.Value = "TypeOfControl";
                                char[] splitterbox = new char[] { '/' };
                                if (DBGridGeneral.Rows[s].Cells[1].Value.ToString() != "")
                                {
                                    Array.Clear(dataunit, 0, dataunit.Length);
                                    string tagvalue = DBGridGeneral.Rows[s].Cells[8].Value.ToString();
                                    dataunit = tagvalue.Split(splitterbox);

                                    //  dataUnit.Add(dataunit[0]);
                                }
                                else
                                {
                                    cmbunit.Items.Add("");
                                }
                                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                                DBGridGeneral.Rows[s].Cells[5].Value = "";
                                DBGridGeneral[5, s] = comboCell;
                                comboCell.Items.Clear();
                                comboCell.Items.Add("");
                                comboCell.Items.AddRange(dataunit);
                                comboCell.Items.Add("AddNew");
                                // comboCell.ReadOnly=true;
                                //  DBGridView.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(DBGridView_EditingControlShowing);
                                //  dbview.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dbview_DataGridViewEditingControlShowingEventHandler);
                                //  DBGridView.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dbview_DataGridViewEditingControlShowingEventHandler);
                                //    DBGridView.CellValueChanged += new DataGridViewCellEventHandler(DBGridView_CellValueChanged_1);
                                //  DBGridView.CurrentCellDirtyStateChanged += new EventHandler(DBGridView_CurrentCellDirtyStateChanged_1);

                                parametername = DBGridGeneral[1, s].Value.ToString();
                                // string[] combined = dataunit.Concat(dataunit1).ToArray();
                                // comboCell.Items.AddRange(combined);
                                break;
                            }
                        case "checkbox":
                            {
                                // cmbunit.Value = "TypeOfcheck";
                                DataGridViewCheckBoxCell chkboxcell = new DataGridViewCheckBoxCell();
                                // chkboxcell.Selected = true;
                                DBGridGeneral[2, s] = chkboxcell;
                                chkboxcell.Value = false;
                                DBGridGeneral.DefaultCellStyle.DataSourceNullValue = 0;
                                //dataGridView1.CellMouseClick += new DataGridViewCellEventHandler(dataGridView1_CheckBoxCheckChange);
                                //dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
                                break;
                            }

                        case "staticdata":
                            {
                                this.DBGridGeneral.Rows[s].ReadOnly = true;
                                this.DBGridGeneral.Rows[s].Cells[4].Value = string.Empty;
                                using (Font font = new Font(DBGridGeneral.DefaultCellStyle.Font.FontFamily, 9, FontStyle.Bold))
                                {
                                    DBGridGeneral.Rows[s].Cells["Parameter Name"].Style.Font = font;
                                }
                                break;
                            }

                        case "staticdata1":
                            {

                                this.DBGridGeneral.Rows[s].ReadOnly = true;
                                this.DBGridGeneral.Rows[s].Cells[4].Value = string.Empty;
                                using (Font font = new Font(DBGridGeneral.DefaultCellStyle.Font.FontFamily, 9, FontStyle.Bold))
                                {
                                    DBGridGeneral.Rows[s].Cells["Parameter Name"].Style.Font = font;
                                }
                                break;
                                // break;
                            }

                        case "multiunit":
                            {
                                parametername = DBGridGeneral[1, s].Value.ToString();
                                string datatag = DBGridGeneral[1, s].Value.ToString();
                                //DBGridView.Rows[s].Cells[0].Value = parametername + " " + datatag;
                                cmbunit.Value = "typemultiunit";
                                char[] splitterbox = new char[] { '/' };
                                string[] splitterbox1 = new string[] { "OR" };
                                if (DBGridGeneral.Rows[s].Cells[2].Value.ToString() == "-")
                                {
                                    string tagvalue = DBGridGeneral.Rows[s].Cells[2].Value.ToString();
                                    dataunit = tagvalue.Split(splitterbox);
                                }
                                else
                                {
                                    string tagvalue = DBGridGeneral.Rows[s].Cells[2].Value.ToString();
                                    dataunit = tagvalue.Split(splitterbox1, StringSplitOptions.None);
                                }
                                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                                // dataGridView1.Rows[s].Cells[3].Value = "";
                                this.DBGridGeneral.Rows[s].Cells[2].Value = string.Empty;
                                DBGridGeneral[2, s] = comboCell;
                                comboCell.Items.Add("");
                                comboCell.Items.AddRange(dataunit);
                                break;
                            }

                        case "description":
                            {
                                DataGridViewTextBoxCell txtbxcl = new DataGridViewTextBoxCell();
                                txtbxcl.Value = "";
                                DBGridGeneral.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                                DBGridGeneral.AutoResizeRow(s, DataGridViewAutoSizeRowMode.AllCellsExceptHeader);
                                DBGridGeneral.AutoResizeColumn(4);
                                this.DBGridGeneral.Rows[s].Cells[4].Value = string.Empty;
                                break;
                            }

                        case "multiinput":
                            {
                                DataGridViewTextBoxCell txtbxcl1 = new DataGridViewTextBoxCell();
                                DBGridGeneral.Columns[5].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                                this.DBGridGeneral.Rows[s].Cells[5].Value = string.Empty;
                                break;
                            }

                        case "-":
                            {
                                this.DBGridGeneral.Rows[s].Cells[5].Value = DBGridGeneral.Rows[s].Cells[3].Value.ToString();
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CopyToDataTable();
                DataSet machineDs = new DataSet();
                DataSet machinereload = new DataSet();
                machineDs.Tables.Clear();
                machineDs.Tables.Add(globalDt);
                string tabname = tabControl1.SelectedTab.Tag.ToString();
                string Path = GlobalDeclaration.ReturnPath() + @"\" + "KeyComponentData"+@"\"+"KeyComponentsUserData";
                if (!Directory.Exists(Path))
                {
                    Directory.CreateDirectory(Path);
                }
                string nameoffile = this.Text.Trim() + "_" + tabname;
                machineDs.WriteXml(Path + @"\" +GlobalDeclaration.MCDMacName+"_"+tabname+".xml");
                machineDs.Tables.Remove(globalDt);
                MessageBox.Show("Record saved successfully!..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
             catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CopyToDataTable()
        {
            try
            {
                globalDt.Columns.Clear();
                globalDt.Rows.Clear();
                //Adding the Columns.
                foreach (DataGridViewColumn column in DBGridGeneral.Columns)
                {
                    globalDt.Columns.Add(column.HeaderText, column.ValueType);
                }
                
                for (int i = 0; i < DBGridGeneral.Rows.Count; i++)
                {
                    globalDt.Rows.Add();
                    for (int j = 0; j < globalDt.Columns.Count; j++)
                    {
                        int bitval = 0;
                        var objType = DBGridGeneral.Rows[i].Cells[j];
                        if (objType.GetType().Name == "DataGridViewCheckBoxCell")
                        {
                            //  DataGridViewCheckBoxCell cb = new DataGridViewCheckBoxCell();
                            if (objType.Value != null)
                            {
                                if ((bool)objType.Value == false)
                                {
                                    //        if ((bool)dataGridView1.Rows[m].Cells[k].Value == true)
                                    ////if ((bool)objType.g == true)

                                    bitval = 0;
                                    globalDt.Rows[i][j] = DBGridGeneral.Rows[i].Cells[j].Value.ToString().Trim();
                                }
                                else
                                {
                                    bitval = 1;
                                    globalDt.Rows[i][j] = DBGridGeneral.Rows[i].Cells[j].Value.ToString().Trim();
                                }


                                // dt1.Rows[m][k] = bitval;
                            }
                            else
                            {
                                bitval = 0;
                                globalDt.Rows[i][j] = bitval;

                            }
                        }
                        else
                        {
                           if (objType.GetType().Name == "DataGridViewComboBoxCell")
                            {
                                string cell5 = DBGridGeneral.Rows[i].Cells[5].Value.ToString();
                                // string cell8= DBGridView.Rows[i].Cells[8].Value.ToString();

                            }
                            globalDt.Rows[i][j] = DBGridGeneral.Rows[i].Cells[j].Value.ToString();
                            //}

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void DBGridGeneral_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
                string Value = DBGridGeneral.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (Value == "AddNew")
                {
                    rowindex = e.RowIndex;
                    AddNewUnitFrm mainlyt = new AddNewUnitFrm(tabset, parametername, dataUnit, param_id);
                    // mainlyt.updateComboUnit += GetSpecificationUnitEvent;
                    mainlyt.Show();
                }

            }
        }

        private void DBGridGeneral_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            string dbcell = DBGridGeneral.CurrentCell.GetType().ToString();
            if (dbcell == "System.Windows.Forms.DataGridViewComboBoxCell")
            {
                if (e.ColumnIndex == 5 && e.RowIndex == rowindex)
                {
                    char[] splitterbox = new char[] { '/' };
                    string tagvalue = DBGridGeneral.Rows[rowindex].Cells[8].Value.ToString();
                    dataunit1 = tagvalue.Split(splitterbox);
                    DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                    DBGridGeneral.Rows[rowindex].Cells[5].Value = "";
                    DBGridGeneral[5, rowindex] = comboCell;
                    comboCell.Items.Add("");
                    // comboCell.Items.AddRange(dataunit);
                    // parametername = DBGridView[1, s].Value.ToString();
                    if (dataunit.Length > 0)
                    {
                        string[] combined = dataunit.Concat(dataunit1).ToArray();
                        comboCell.Items.AddRange(combined);
                        dataunit = combined;
                    }
                    else
                    {
                        comboCell.Items.AddRange(dataunit1);
                    }
                    comboCell.Items.Add("AddNew");
                    //dataunit=combi
                    // break;
                }
            }
        }
    }
}
