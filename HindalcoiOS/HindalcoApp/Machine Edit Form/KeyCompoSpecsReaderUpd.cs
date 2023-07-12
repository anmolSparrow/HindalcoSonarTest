using DevExpress.XtraEditors;
using ExcelDataReader;
using RMPCLApp.Class_Operation;
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
    public partial class KeyCompoSpecsReader : DevExpress.XtraEditors.XtraForm
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
        private string _Machinename;
        private string _MacName;

        public KeyCompoSpecsReader()
        {
            InitializeComponent();
        }
        public KeyCompoSpecsReader(string MachineName, string macName)
        {
            this._MacName = macName;
            this._Machinename = MachineName;
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void SpecificParameterPage_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void KeyCompoSpecesReaderForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'industryOSCoralLiteDataSet.WorkLocation' table. You can move, or remove it, as needed.
           // this.workLocationTableAdapter.Fill(this.industryOSCoralLiteDataSet.WorkLocation);

        }
        private void AddGeneralColumns()
        {
            if (GenralDT.Columns.Count== 0)
            {
                GenralDT.Columns.Add("Parameter", typeof(string));
                GenralDT.Columns.Add("Unit", typeof(string));
                GenralDT.Columns.Add("Min Val.", typeof(string));
                GenralDT.Columns.Add("Max Val.", typeof(string));
            }
            //GenralDT.Columns.Add("", typeof(string));
            //GenralDT.Columns.Add("", typeof(string));

        }

        private void AddGeneralColumnsHeader()
        {
            if (tabset1.Columns["Parameter"] == null)
                tabset1.Columns.Add("Parameter", typeof(string));
            if (tabset1.Columns["Unit"] == null)
                tabset1.Columns.Add("Unit", typeof(string));
            if (tabset1.Columns["Min Val."] == null)
                tabset1.Columns.Add("Min Val.", typeof(string));
            if (tabset1.Columns["Max Val."] == null)
                tabset1.Columns.Add("Max Val.", typeof(string));
            if (tabset1.Columns["NotAvailable"] == null)
                tabset1.Columns.Add("NotAvailable", typeof(bool));
            if (tabset1.Columns["NotApplicable"] == null)
                tabset1.Columns.Add("NotApplicable", typeof(bool));

        }
        private void AddSpecificColumns()
        {
            if (SpecificDT.Columns.Count == 0)
            {
                SpecificDT.Columns.Add("Parameter", typeof(string));
                SpecificDT.Columns.Add("Unit", typeof(string));
                SpecificDT.Columns.Add("Min Val.", typeof(string));
                SpecificDT.Columns.Add("Max Val.", typeof(string));
            }
            //GenralDT.Columns.Add("", typeof(string));
            //GenralDT.Columns.Add("", typeof(string));

        }

        private void KeyCompoSpecsReader_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = this._Machinename;
                readExcelSheet(this.Text);
                reloadTab("General");

                if (fileExist == false)
                {
                    //  readExcelSheet(this.Text);
                    // List<string> headerList = new List<string>();
                    // headerList.Add("General");
                    // headerList.Add("Specific Parameter");
                    AddGeneralColumns();
                    //AddSpecificColumns();
                    for (int q = 3; q < SpecsDT.Rows.Count; q++)
                    {
                        if (SpecsDT.Rows[q][0].ToString() != "Specific Parameter")
                        {
                            DataRow dtRow = GenralDT.NewRow();
                            {
                                dtRow[0] = SpecsDT.Rows[q][0].ToString();
                                dtRow[1] = SpecsDT.Rows[q][1].ToString();
                                dtRow[2] = SpecsDT.Rows[q][2].ToString();
                                dtRow[3] = SpecsDT.Rows[q][3].ToString();
                                GenralDT.Rows.Add(dtRow);
                            }
                        }
                        else
                        {
                            //DataRow dtRow = SpecificDT.NewRow();
                            //{
                            //    dtRow[0] = SpecsDT.Rows[q][0].ToString();
                            //    dtRow[1] = SpecsDT.Rows[q][1].ToString();
                            //    dtRow[2] = SpecsDT.Rows[q][2].ToString();
                            //    dtRow[3] = SpecsDT.Rows[q][3].ToString();
                            //    SpecificDT.Rows.Add(dtRow);
                            //}

                            break;
                        }

                    }
                    DBGridGeneral.DataSource = GenralDT;
                    addrows(DBGridGeneral);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        bool fileExist = false;
        DataGridView dbview = new DataGridView();
        private void ReUsabaleAction(string tabname)
        {
            string machineData = Application.StartupPath + @"\" + "KeyComponentData" + @"\" + "KeyComponentsUserData" + @"\" + this._MacName.Trim() + "_" + tabControl1.SelectedTab.Tag.ToString() + ".xml";
            if (File.Exists(machineData))
            {
                fileExist = true;
                DataSet ds = new DataSet();
                ds.ReadXml(machineData);
                // dbview .DataSource = ds.Tables[0];
                //  isExists = true;
                dbview.Enabled = true;
                dbview.AllowUserToAddRows = false;

                // dbview.Visible = false;
                dbview.Visible = true;
                dbview.Width = 1250;
                dbview.Height = 760;
                dbview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                //DBGridView.Visible = false;
                tabset1.Clear();
                tabset1.Columns.Clear();
                tabset.Clear();
                tabset.Columns.Clear();
                tabset = XMLToDataTable(machineData);
                AddGeneralColumnsHeader();
                for (int i = 0; i < tabset.Rows.Count; i++)
                {
                    DataRow newDr = tabset1.NewRow();
                    if (string.IsNullOrEmpty(tabset.Rows[i][0].ToString())) continue;
                    newDr[0] = tabset.Rows[i][0].ToString();
                    newDr[1] = tabset.Rows[i][1];
                    newDr[2] = tabset.Rows[i][2];
                    newDr[3] = tabset.Rows[i][3];
                    newDr[4] = tabset.Rows[i][4];
                    newDr[5] = tabset.Rows[i][5];
                    tabset1.Rows.Add(newDr);
                }

                tabControl1.SelectedTab.Controls.Add(dbview);
                //for(int g=0;g< dbview.Columns.Count;g++)
                //{
                //    dbview.Columns.RemoveAt(g);
                //}
                if (tabname == "General")
                {
                    DBGridGeneral.Visible = true;
                    DBGridSpecific.Visible = false;
                    DBGridGeneral.DataSource = tabset1;
                    getControlTypeReload(DBGridGeneral);
                }
                else
                {
                    DBGridGeneral.Visible = false;
                    DBGridSpecific.Visible = true;

                    DBGridSpecific.DataSource = tabset1;
                    //getControlTypeReload(DBGridSpecific);
                }

                //DBGridGeneral.AllowUserToAddRows = false;
                //DBGridGeneral.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //for (int a = 0; a < DBGridGeneral.Columns.Count; a++)
                //{
                //    DBGridGeneral.Columns[a].SortMode = DataGridViewColumnSortMode.NotSortable;
                //}
                // tabset1.Columns.Clear();




                //  
            }
            else
            {
                fileExist = false;
            }
            //else
            //{
            //    DBGridView.Enabled = true;
            //    DBGridView.Visible = true;
            //    currentTab = currentTab + 1;
            //    tabset = mytable.AsEnumerable().Where(r => r.Field<int>("Header Id") == currentTab).CopyToDataTable();
            //    int rowindex = 0;
            //    foreach (DataRow rows in tabset.Rows)
            //    {
            //        string paramname = rows.Field<string>("Parameter Name");
            //        string objectype = rows.Field<string>("Unit");
            //        string paramtag1 = rows.Field<string>("Param Tag");
            //        tabset.Rows[rowindex][1] = paramname.ToString() + " " + paramtag1;
            //        DBGridView.AutoGenerateColumns = true;
            //        DBGridView.AllowUserToAddRows = false;
            //        DBGridView.Columns.Clear();
            //        DBGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //        rowindex = rowindex + 1;
            //    }
            //    if (currentTab != 1)
            //    {
            //        tabset.Rows.RemoveAt(0);
            //    }
            //    DBGridView.DataSource = tabset;
            //    if (mytable.Rows.Count > 1)
            //    {
            //        DBGridView.Columns["Data Tag"].Visible = false;
            //        DBGridView.Columns["Param Tag"].Visible = false;
            //        DBGridView.Columns["Header Id"].Visible = false;
            //        DBGridView.Columns["Control Type"].Visible = false;
            //        DBGridView.Columns["Rfq"].Visible = false;
            //        DBGridView.Columns["MachineName"].Visible = false;
            //        columnsAsReadOnly();
            //        tabControl1.SelectedTab.Controls.Add(this.DBGridView);
            //        getcontroltype();
            //        addrows();
            //    }
            //    else
            //    {
            //        MessageBox.Show("No Record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
        }




        private void reloadTab(string tabName)
        {
            //SpecsDT.Rows.Clear();
            //SpecsDT.Columns.Clear();
            //GenralDT.Columns.Clear();
            //GenralDT.Rows.Clear();
            try
            {
                //  this.Text = this._Machinename;
                //  readExcelSheet(this.Text);
                switch (tabName)
                {
                    case "General":
                        {
                            ReUsabaleAction(tabName);
                            break;
                        }
                    case "Specific Parameter":
                        {
                            ReUsabaleAction(tabName);
                            break;
                        }
                }
                //  ReUsabaleAction();
                if (fileExist == false)
                {
                    // readExcelSheet(this.Text);
                    if (tabName == "General")
                    {
                        // DBGridGeneral.DataSource = "";                      
                        AddGeneralColumns();
                        if (GenralDT.Rows.Count > 0) return;
                        // AddSpecificColumns();
                        if(SpecsDT.Rows[3][0].ToString() != "Specific Parameter")
                        {
                            for (int i = 3; i < SpecsDT.Rows.Count; i++)
                            {
                                DataRow dtRow = GenralDT.NewRow();
                                {
                                    dtRow[0] = SpecsDT.Rows[i][0].ToString();
                                    dtRow[1] = SpecsDT.Rows[i][1].ToString();
                                    dtRow[2] = SpecsDT.Rows[i][2].ToString();
                                    dtRow[3] = SpecsDT.Rows[i][3].ToString();
                                    GenralDT.Rows.Add(dtRow);
                                }
                            }                            
                        }                       
                        DBGridGeneral.DataSource = GenralDT;
                        DBGridGeneral.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                        addrows(DBGridGeneral);
                    }
                    else
                    {
                        //AddGeneralColumns();
                        AddSpecificColumns();
                        if (SpecificDT.Rows.Count > 0) return;
                        if (SpecsDT.Rows[4][1].ToString() == "Specific Parameter")
                        {
                            for (int i = 4; i < SpecsDT.Rows.Count; i++)
                            {
                                DataRow dtRow = SpecificDT.NewRow();
                                {
                                    dtRow[0] = SpecsDT.Rows[i][0].ToString();
                                    dtRow[1] = SpecsDT.Rows[i][1].ToString();
                                    dtRow[2] = SpecsDT.Rows[i][2].ToString();
                                    dtRow[3] = SpecsDT.Rows[i][3].ToString();
                                    SpecificDT.Rows.Add(dtRow);
                                }
                            }
                        }
                        //for(int o=0;o<SpecificDT.Columns.Count;o++)
                        //{
                        //    DataGridViewColumn dcol = new DataGridViewColumn();
                        //    dcol.Name= SpecificDT.Rows[0][o].ToString();
                        //    dcol.CellTemplate.Value=dcol;
                        //    dbview.Columns.Insert(o, dcol);
                        //}
                        DBGridSpecific.DataSource = SpecificDT;
                        DBGridSpecific.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                        addrows(DBGridSpecific);
                        //tabControl1.SelectedTab.Controls.Add(DBGridSpecific);                                                                      
                        getControlTypeReload(DBGridSpecific);
                        //tabControl1.TabPages[1].Show();
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void readExcelSheet(string filename)
        {
            try
            {
                if (filename.Contains("_"))
                {
                    filename = filename.Split('_')[0];
                }
                string app_Path = Application.StartupPath + @"\KeyComponentData\" + @"SpecsData" + @"\" + filename + ".xlsx";
                if (!File.Exists(app_Path))
                {
                    XtraMessageBox.Show("File not found!", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    SpecsDT = ExcelToDataTableUsingExcelDataReader(app_Path);
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "General")
            {
                reloadTab(tabControl1.SelectedTab.Text);
                // columnsAsReadOnly(DBGridGeneral);
                getControlType(DBGridGeneral);
                istransferGen = true;
                //  ReUsabaleAction();
            }
            if (tabControl1.SelectedTab.Text == "Specific Parameter")
            {
                reloadTab(tabControl1.SelectedTab.Text);
                //columnsAsReadOnly(DBGridSpecific);
                getControlType(DBGridSpecific);
                istransferSpec = true;
                //  ReUsabaleAction();
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
            tabset1.Columns.Add("Parameter", typeof(string));
            tabset1.Columns.Add("Unit");
            tabset1.Columns.Add("Min Val.", typeof(string));
            tabset1.Columns.Add("Max Val.", typeof(string));
            tabset1.Columns.Add("NotAvailable", typeof(bool));
            tabset1.Columns.Add("NotApplicable", typeof(bool));
            tabset1.Columns.Add("Control_Type", typeof(string));

        }


        private void addrows(DataGridView dbGridName)
        {
            try
            {
                //  if (!GlobalDeclaration.UserType.Equals("U1-Maintenance") || GlobalDeclaration.UserType.Equals("U1-Safety")) return;
                DataGridViewCheckBoxColumn dgisavail = new DataGridViewCheckBoxColumn();
                dgisavail.ValueType = typeof(bool);
                dgisavail.Name = "NotAvailable";
                dgisavail.HeaderText = "NotAvailable";
                
                DataGridViewCheckBoxColumn dgisapplcbl = new DataGridViewCheckBoxColumn();
                dgisapplcbl.ValueType = typeof(bool);
                dgisapplcbl.Name = "NotApplicable";
                dgisapplcbl.HeaderText = "NotApplicable";

                if (dbGridName.Columns.Count == 4)
                {
                    dbGridName.Columns.Insert(4, dgisavail);
                    dbGridName.Columns.Insert(5, dgisapplcbl);
                }
                else
                {

                }
                    
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void columnsAsReadOnly(DataGridView dbView)
        {
            for (int i = 0; i < 1; i++)
            {
                dbView.Columns[i].ReadOnly = true;
            }
        }


        private void getControlTypeReload(DataGridView dbgrid)
        {
            try
            {
                Boolean ifconOR = false;
                string[] dataunit = new string[] { };
                int m = 0;
                for (int s = 0; s < dbgrid.Rows.Count-1; s++)
                {
                    if (s>=14)
                   {
                        continue;
                    }
                    if (!string.IsNullOrEmpty(SpecsDT.Rows[s][0].ToString()) && SpecsDT.Rows[s][0].ToString() == "Specific Parameter")
                    {
                        for (int b = 0; b < s; b++)
                        {
                            SpecsDT.Rows.RemoveAt(b);
                        }
                    }
                    var controltype = SpecsDT.Rows[s][1];
                    if (controltype.ToString().Contains("OR"))
                    {
                        ifconOR = true;
                    }
                    // string typeofcontrol = tabset.Tables[0].Rows[i].Field<string>("control_type");
                    if (ifconOR == true)
                    {
                        cmbunit.Value = "TypeOfControl";
                        string[] splitterbox = new string[] { "OR" };
                        if (SpecsDT.Rows[s][1].ToString() != "")
                        {
                            string tagvalue = SpecsDT.Rows[s][1].ToString();
                            //dataunit = tagvalue.Split(new[] { "OR" }, StringSplitOptions.None).ToString();
                            dataunit = tagvalue.Split(new string[] { "OR" }, StringSplitOptions.None);

                            //  dataUnit.Add(dataunit[0]);
                        }
                        else
                        {
                            cmbunit.Items.Add("");
                        }
                        DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                        dbgrid.Rows[s].Cells[1].Value = "";
                        dbgrid[1, s] = comboCell;
                        comboCell.Items.Add("");
                        comboCell.Items.AddRange(dataunit);
                        //comboCell.Items.Add("AddNew");
                        parametername = dbgrid[1, s].Value.ToString();
                        // string[] combined = dataunit.Concat(dataunit1).ToArray();
                        // comboCell.Items.AddRange(combined);
                        // break;
                        ifconOR = false;
                    }
                }



            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
        }


        private void getControlType(DataGridView dbgrid)
        {
            try
            {
                Boolean ifconOR = false;
                string[] dataunit = new string[] { };
                for (int s = 0; s < dbgrid.RowCount; s++)
                {
                    var controltype = dbgrid.Rows[s].Cells[1].Value;
                    if (controltype!=null && controltype.ToString().Contains("OR"))
                    {
                        ifconOR = true;
                    }
                    // string typeofcontrol = tabset.Tables[0].Rows[i].Field<string>("control_type");
                    if (ifconOR == true)
                    {
                        cmbunit.Value = "TypeOfControl";
                        string[] splitterbox = new string[] { "OR" };
                        if (dbgrid.Rows[s].Cells[1].Value.ToString() != "")
                        {
                            string tagvalue = dbgrid.Rows[s].Cells[1].Value.ToString();
                            //dataunit = tagvalue.Split(new[] { "OR" }, StringSplitOptions.None).ToString();
                            dataunit = tagvalue.Split(new string[] { "OR" }, StringSplitOptions.None);

                            //  dataUnit.Add(dataunit[0]);
                        }
                        else
                        {
                            cmbunit.Items.Add("");
                        }
                        DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                        dbgrid.Rows[s].Cells[1].Value = "";
                        dbgrid[1, s] = comboCell;
                        comboCell.Items.Add("");
                        comboCell.Items.AddRange(dataunit);
                        //comboCell.Items.Add("AddNew");
                        parametername = dbgrid[1, s].Value.ToString();
                        // string[] combined = dataunit.Concat(dataunit1).ToArray();
                        // comboCell.Items.AddRange(combined);
                        // break;
                        ifconOR = false;
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
                if (tabControl1.SelectedIndex == 0)
                {
                    CopyToDataTable(DBGridGeneral);
                }
                else
                {
                    CopyToDataTable(DBGridSpecific);
                }
                DataSet machineDs = new DataSet();
                DataSet machinereload = new DataSet();
                machineDs.Tables.Clear();
                machineDs.Tables.Add(globalDt);
                string tabname = tabControl1.SelectedTab.Tag.ToString();
                string Path = Application.StartupPath + @"\" + "KeyComponentData" + @"\" + "KeyComponentsUserData";
                if (!Directory.Exists(Path))
                {
                    Directory.CreateDirectory(Path);
                }
                string nameoffile = this._MacName + "_" + tabname;
                machineDs.WriteXml(Application.StartupPath + @"\" + "KeyComponentData" + @"\" + "KeyComponentsUserData" + @"\" + nameoffile + ".xml");
                machineDs.Tables.Remove(globalDt);
                MessageBox.Show("Record saved successfully!..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void CopyToDataTable(DataGridView dbgrid)
        {
            try
            {
                globalDt.Columns.Clear();
                globalDt.Rows.Clear();
                //Adding the Columns.
                foreach (DataGridViewColumn column in dbgrid.Columns)
                {
                    globalDt.Columns.Add(column.HeaderText, column.ValueType);
                }

                for (int i = 0; i < dbgrid.Rows.Count; i++)
                {
                    globalDt.Rows.Add();
                    for (int j = 0; j < globalDt.Columns.Count; j++)
                    {
                        int bitval = 0;
                        var objType = dbgrid.Rows[i].Cells[j];
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
                                    globalDt.Rows[i][j] = dbgrid.Rows[i].Cells[j].Value.ToString().Trim();
                                }
                                else
                                {
                                    bitval = 1;
                                    globalDt.Rows[i][j] = dbgrid.Rows[i].Cells[j].Value.ToString().Trim();
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
                            //if (j == DBGridView.Columns.Count - 1)
                            //{
                            //    globalDt.Rows[i][j] = tabText;
                            //}
                            //else
                            //{
                            if (objType.GetType().Name == "DataGridViewComboBoxCell")
                            {
                                string cell5 = dbgrid.Rows[i].Cells[1].Value.ToString();
                                // string cell8= DBGridView.Rows[i].Cells[8].Value.ToString();

                            }
                            globalDt.Rows[i][j] = dbgrid.Rows[i].Cells[j].Value.ToString();
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
    }
}
