
using CADImport;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using ExcelDataReader;
using OfficeOpenXml;
using HindalcoiOS.Class_Operation;
using HindalcoiOS.Connector_FRM;
using HindalcoiOS.Form_Collection;
using HindalcoiOS.Machine_Edit_Form;
using HindalcoiOS.Safety_Form_list;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using HindalcoiOS.Multifloor;
using DocumentFormat.OpenXml.Office2010.CustomUI;

namespace HindalcoiOS.Machine_Edit_Form
{
    public partial class Machine_Edit_Data : XtraForm
    {

        #region Delegate declaration
        delegate void SetComboBoxCellType(int iRowIndex, string clmname, int iColumnIndex);
        delegate void SetComboBoxCellTypeReult(int iRowIndex, string clmname, int iColumnIndex);
        delegate void SetComboBoxCellTypeCAPA(int iRowIndex, string clmname, int iColumnIndex);
        public delegate void SendToPointForMulCadLayoutFrm(string Tabtext, DPoint _dPoint, string FileName);
        #endregion

        #region Local Veriable declaration  
        List<string> Tabinserted = new List<string>();
        string[] filesArr = new string[] { };
        private string tabText = "";
        private bool _IsUpdateCell;
        private bool IsMultiCheckExist;
        private bool _IsUpdateCellCAPA;
        private bool _NewRowAdd;
        private bool _NewEmployeList;
        public bool _IsAlrdyCheck;
        private bool _IsDataStatus;
        // DataTable _GlobalCAPAtbl = null; 
        string machineName = string.Empty;
        DataGridView DgvCAPATab = null;
        MachineEditKeyComponent frm = null;
        KeySafetyComponent keycmp = null;
        DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
        DataTable addinventory = new DataTable();
        DataTable updinventory = new DataTable();
        DataTable InputInfoDt = new DataTable();
        DataTable tabset = new DataTable();
        DataTable getdata = new DataTable();
        DataTable addEnvironment = new DataTable();
        DataTable globalDt = new DataTable();
        DataGridViewComboBoxCell cmbunit = new DataGridViewComboBoxCell();
        List<string> SameMachineDrop = new List<string>();// This list Manage for Same Machine Drop Another Floor
        DataTable getDTS = null;
        int insVal = 0; int rowindex = 0;
        public int floorCount = 0;
        bool parentFile = false;
        bool isExists = false;
        int autoinventid = 0;
        int currentTab = 0;
        private int ReceiveCount, ResultRecordCount = 0;
        int healthenvid;
        int param_id = 0;
        //public static string[] dataunit = new string[] { };
        int countcoldb;
        private string MachineName = string.Empty;
        private string SysGenMachineNo = string.Empty;
        private string ConnectionMachineName = string.Empty;
        string initialColName = "";
        string newColName = "";
        public EventHandler<string> RemoveDicEvetHandeler;
        public static string[] dataunit = new string[] { };
        public static string[] dataunit1 = new string[] { };
        string parametername = "";
        List<string> dataUnit = new List<string>();
        bool is_specificationTab = false;
        DateTimePicker LastDateTimePicker;
        string cmdMaintemnce = @"insert into MaintennaceTBL(S.No,clmMachineTag,clmMachineName,ItemActivity,cmbitmactvty,Date_of_Last_Maintenance,cmboutsorce,ShtdwnReq,cmbexpct,Deviations,cmbresponce,cmbRsult,Observation_(visual_only),Observation_(Numeric/test etc.),criticality,Upload,Input,Identified_Risk,Special_tools,PPE_List) values";
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
        private string UplFilePath1 = string.Empty;
        private string UplFilePath2 = string.Empty;
        private string UplFilePath3 = string.Empty;
        public static bool isFileFound = true;
        public Dictionary<string, DPoint> offsetDict = new Dictionary<string, DPoint>();
        public event SendToPointForMulCadLayoutFrm _SendToPointForMulCadLayoutFrm;
        DataTable mytable = GlobalDeclaration.CreateTable();
        List<string> matchedArr = new List<string>();
        bool isSpecLoad = false;
        DataTable dts = new DataTable();
        #endregion

        #region Global Property Decalation
        public Dictionary<string, List<string>> ReceiveConValue
        {
            get;
            set;
        }
        public Dictionary<string, Connector> _listconnt
        {
            get;
            set;
        }
        public string LineType
        {
            get; set;
        }

        public Dictionary<string, string> _dropMachineList
        {
            get; set;
        }
        public string MachineSybType
        {
            get; set;
        }

        public string MachinType
        {
            get; set;
        }
        public DPoint _Cordinates
        {
            get;
            set;
        }        
        public List<mulCadLayout> listofdockcontaint
        {
            get; set;
        }
        public string TabText
        {
            get;set;
        }
        #endregion

        #region Class Contructor
        public Machine_Edit_Data(string machinename, string SysGenMachNo, string _connectorName)
        {
            InitializeComponent();
            this.MachineName = machinename;
            this.SysGenMachineNo = SysGenMachNo;
            this.ConnectionMachineName = _connectorName;
            this.Text = machinename + "_" + SysGenMachineNo;

            //UpdateTextPosition();

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
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public Machine_Edit_Data()
        {
            InitializeComponent();
        }
        private void LockAllTextFields()
        {
            if (GlobalDeclaration.UserType.Equals("U1-Maintenance") || GlobalDeclaration.UserType.Equals("U1-Safety"))
            {

            }
        }
        #endregion
        
        private void Machine_Edit_Data_Load(object sender, EventArgs e)
        {
            try
            {
                HideMCDPagesHeader();
                HideSpecificationPagesHeader();
                List<Control> allControls = GetAllControls(this);
                allControls.ForEach(k => k.Font = new System.Drawing.Font("Segoe UI", 9));

                //cmboprator.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //cmboprator.AutoCompleteSource = AutoCompleteSource.ListItems;
                //cmbowner.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //cmbowner.AutoCompleteSource = AutoCompleteSource.ListItems;
                //cmbMaintenanc.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //cmbMaintenanc.AutoCompleteSource = AutoCompleteSource.ListItems;
                //cmbprocessown.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //cmbprocessown.AutoCompleteSource = AutoCompleteSource.ListItems;
                HideCTRL();
                CmbPriceUnit.SelectedIndex = 1;// 0;
                LoadKeyCompoNente();
                //  LoadData();
                //  LoadEmployeeList();
                LoadFunctionEleMentData();
                this.checkedListBox1.Visible = false;
                if (!isExists)
                {

                    Thread threadReadExcel = new Thread(() =>
                    {
                        readExcelSheet(this.MachineSybType, this.MachinType, this.MachineName);
                    });
                    threadReadExcel.Start();
                }
                if (floorCount > 1)
                {
                    chkmultifloor.Visible = true;
                    lblextedmachine.Visible = true;
                    foreach (KeyValuePair<string, DPoint> entry in offsetDict)
                    {
                        var formname = entry.Key;
                        string parentformname = string.Empty;
                        if (formname != TabText)
                        {
                            if (!chkmultifloor.Items.Contains(formname))
                            {
                                chkmultifloor.Items.Add(formname);
                            }
                        }
                    }
                    if (listofdockcontaint != null)
                    {
                        var layoutobject = listofdockcontaint.AsEnumerable().Where(X => X.TabText != TabText).FirstOrDefault();
                        if (layoutobject != null)
                        {
                            if (layoutobject.cadImage.Converter.Entities.Count > 0)
                            {
                                var CadImageEntityCollection = layoutobject.cadImage.Converter.Entities.AsEnumerable().OfType<CADImageEnt>().ToList();
                                foreach (var item in CadImageEntityCollection)
                                {
                                    string FileName = item.ImageDef.FileName.Split('\\')[item.ImageDef.FileName.Split('\\').Length - 1].Split('.')[0];
                                    if (FileName == this.MachineName)
                                    {
                                        if (!chkmultifloor.Items.Contains(layoutobject.TabText))
                                        {
                                            chkmultifloor.Items.Add(layoutobject.TabText);
                                        }
                                        chkmultifloor.SetItemCheckState(0, CheckState.Checked);
                                        chkmultifloor.Enabled = false;
                                        chkmultifloor.Visible = true;
                                        lblextedmachine.Visible = true;
                                        break;
                                    }
                                    else
                                    {
                                        chkmultifloor.Visible = false;
                                        lblextedmachine.Visible = false;
                                    }
                                }
                            }
                        }
                    }
                    if (IsMultiCheckExist)//Multifoor muchine drop and exist in DB check
                    {
                        chkmultifloor.SetItemCheckState(0, CheckState.Checked);
                        chkmultifloor.Enabled = false;
                    }

                }
            }
            catch (Exception Ex)
            {

                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void HideCTRL()
        {

            btnSpecification.Location = btnMainDesignParam.Location;
            btnHierarchy.Location = btnInvSpares.Location;
            btnUpld.Location = new Point(734, 12);
        }
        public string MachineNamefind(object _obj)
        {
            string MachineName = ((CADImport.CADImageEnt)_obj).ImageDef.FileName;
            string[] s = (MachineName.ToString()).Split('\\');
            return s[s.Length - 1].Split('.')[0];
        }
        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            MCDpages.SelectedIndex = 1;

        }

        void setCurrentTab(int index)
        {
            //switch(bunifuPages1.SelectedIndex)
            //{
            //    case 0:
            //        indicator. = bunifuButton1.Right - bunifuButton1.Width;
            //        break;
            //}
        }

        private void MCDPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            //setCurrentTab(MCDpages.SelectedIndex);
           
            LoadDataEvent(sender, e);

        }

        #region Migration Button

        ////private void bunifuButton1_Click(object sender, EventArgs e)
        ////{
        ////    MCDpages.SelectedIndex = 0;

        ////}

        ////private void bunifuButton3_Click(object sender, EventArgs e)
        ////{
        ////    MCDpages.SelectedIndex = 2;
        ////}

        ////private void bunifuButton4_Click(object sender, EventArgs e)
        ////{
        ////    MCDpages.SelectedIndex = 3;
        ////}

        ////private void bunifuButton5_Click(object sender, EventArgs e)
        ////{
        ////    MCDpages.SelectedIndex = 4;
        ////}

        ////private void bunifuButton6_Click(object sender, EventArgs e)
        ////{
        ////    MCDpages.SelectedIndex = 5;
        ////}

        ////private void bunifuButton7_Click(object sender, EventArgs e)
        ////{
        ////    MCDpages.SelectedIndex = 6;
        ////}

        ////private void btntabmaintenenace_Click(object sender, EventArgs e)
        ////{
        ////    MCDpages.SelectedIndex = 7;
        ////}


        ////private void bunifuButton10_Click(object sender, EventArgs e)
        ////{
        ////    MCDpages.SelectedIndex = 8;
        ////}

        ////private void bunifuButton11_Click(object sender, EventArgs e)
        ////{
        ////    MCDpages.SelectedIndex = 9;
        ////}

        ////private void bunifuButton12_Click(object sender, EventArgs e)
        ////{
        ////    MCDpages.SelectedIndex = 10;
        ////}
        #endregion

        private void bunifuPages2_SelectedIndexChanged(object sender, EventArgs e)
        {
            setCurrentTab(MCDpages.SelectedIndex);

        }

        #region Migration Button
        ////private void bunifuButton25_Click(object sender, EventArgs e)
        ////{
        ////    SpecificationPages.SelectedIndex = 0;
        ////    //btnSpecification.Focus();
        ////    //btnGenrl.Focus();

        ////    //((System.Windows.Forms.TabControl)sender).SelectedTab.Focus();
        ////}

        ////private void bunifuButton26_Click(object sender, EventArgs e)
        ////{
        ////    SpecificationPages.SelectedIndex = 1;
        ////    //SpecificationPages.SelectedTab.Tag = "Process";
        ////    //btnSpecification.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
        ////    //btnProcesParam.Focus();

        ////}

        ////private void bunifuButton27_Click(object sender, EventArgs e)
        ////{
        ////    SpecificationPages.SelectedIndex = 2;
        ////}

        ////private void bunifuButton28_Click(object sender, EventArgs e)
        ////{
        ////    SpecificationPages.SelectedIndex = 3;
        ////}

        ////private void bunifuButton29_Click(object sender, EventArgs e)
        ////{
        ////    SpecificationPages.SelectedIndex = 4;
        ////}

        ////private void bunifuButton30_Click(object sender, EventArgs e)
        ////{
        ////    SpecificationPages.SelectedIndex = 5;
        ////}

        ////private void bunifuButton31_Click(object sender, EventArgs e)
        ////{
        ////    SpecificationPages.SelectedIndex = 6;
        ////}

        ////private void bunifuButton46_Click(object sender, EventArgs e)
        ////{
        ////    //tabmaintenenace.SelectedIndex = 0;
        ////}

        ////private void bunifuButton47_Click(object sender, EventArgs e)
        ////{
        ////    //tabmaintenenace.SelectedIndex = 1;
        ////}
        #endregion

        #region Form Load Event
        //private void Machine_Edit_Data_Load(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        List<Control> allControls = GetAllControls(this);
        //        allControls.ForEach(k => k.Font = new System.Drawing.Font("Segoe UI", 9));

        //        //cmbSafetyComp.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //        //cmbSafetyComp.AutoCompleteSource = AutoCompleteSource.ListItems;
        //        //cmbcomponent.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //        //cmbcomponent.AutoCompleteSource = AutoCompleteSource.ListItems;                

        //        cmboprator.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //        cmboprator.AutoCompleteSource = AutoCompleteSource.ListItems;
        //        cmbowner.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //        cmbowner.AutoCompleteSource = AutoCompleteSource.ListItems;
        //        cmbMaintenanc.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //        cmbMaintenanc.AutoCompleteSource = AutoCompleteSource.ListItems;
        //        cmbprocessown.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //        cmbprocessown.AutoCompleteSource = AutoCompleteSource.ListItems;
        //        CmbPriceUnit.SelectedIndex = 0;
        //        LoadKeyCompoNente();
        //        //  LoadData();
        //        //  LoadEmployeeList();
        //        LoadFunctionEleMentData();
        //        this.checkedListBox1.Visible = false;
        //        if (!isExists)
        //        {
        //                readExcelSheet(this.MachineSybType, this.MachinType, this.MachineName);
        //            });
        //            threadReadExcel.Start();
        //        }
        //    }

        //            Thread threadReadExcel = new Thread(() =>
        //            {
        //    catch (Exception Ex)
        //    {

        //        XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void readExcelSheet(string foldername, string subtype, string filename)
        {
            try
            {
                if (filename.Contains("_"))
                {
                    filename = filename.Split('_')[0];
                }
                app_Path = GlobalDeclaration.ReturnPath() + @"\Images\" + foldername + @"\" + subtype + @"\" + filename + ".xlsx";
                if (!File.Exists(app_Path))
                {
                    isFileFound = false;
                    XtraMessageBox.Show("File not found!", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                    using (var package = new ExcelPackage(new FileInfo(app_Path)))
                    {
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
                        if (header == headerlist[y].header_name)
                        {
                            while (header != headerlist[y + 1].header_name)
                            {

                                string headername = headerlist[y + 1].header_name;
                                string concat = headername + empspc;
                                //string nextHeader
                                int item = lst.FindIndex(x => x == concat);
                                //itemrnbge = item - itemrnbge;
                                string[] operators = new string[] { " ", "-", "(", ")", "/", "\\", "°" };
                                for (p = itemrnbge; p < item - 1; p++)
                                {
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
                                if (differ > 1)
                                {
                                    headerarr.Add(headerlist[y].header_name);
                                }
                                else
                                {
                                    headerarr.Remove(headerlist[y - 1].header_name);
                                    headerarr.Add(headerlist[y].header_name);
                                }

                                //  headerarr.RemoveAt(6);
                                header = headerlist[y].header_name;
                                if (y == headerlist.Count - 1)
                                {
                                    break;
                                }

                            }
                            headerarr.Add("General");
                            matchedArr = headerarr;
                            //machineDs.Tables.Add(mytable);
                            //machineDs.WriteXml(Application.StartupPath + @"\" + "DraggedMachine" + ".xml");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //  Resources.Instance.DropTableSecond(); //------>>>> on error drop the secondary temporary table as this creates a overhead
                MessageBox.Show(ex.Message);
            }

        }
        #endregion

        #region Method Collection       
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
        private void AddEmployee(int iRowIndex)
        {
            if (_NewEmployeList)
            {
                DataGridViewComboBoxCell dgComboCell = new DataGridViewComboBoxCell();
                dgComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                dgComboCell.DataSource = Resources.Instance._EmpName;
                dgComboCell.ValueMember = "emp_name";
                dgComboCell.DisplayMember = "emp_name";
                DgvMaitenance.Rows[iRowIndex].Cells[2] = dgComboCell;
                _NewEmployeList = false;

            }
        }

        private DataSet ds;
        private void btnLoad_Click(object sender, EventArgs e)
        {
            // Upload Maintenance Excel Sheet  from Drive
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
                var tablenames = GlobalDeclaration.GetTablenames(ds.Tables);
                sheetCombo.DataSource = tablenames;

                if (tablenames.Count > 0)
                    sheetCombo.SelectedIndex = 0;
            }
        }
        private void InsertHierachytabData()
        {
            try
            {
                if (cmboprator.SelectedValue != null && cmbowner.SelectedValue != null && cmbprocessown.SelectedValue != null && cmbMaintenanc.SelectedValue != null)
                {
                    // string nnnn = this.Text.Replace(this.MachineName, "").TrimStart();
                    string Value = cmboprator.SelectedValue.ToString() + "~" + cmbowner.SelectedValue.ToString() + "~" + cmbprocessown.SelectedValue.ToString() + "~" + cmbMaintenanc.SelectedValue.ToString() + "~" +
                        this.cmblocation.SelectedItem.ToString() + "~" +
                        GlobalDeclaration._holdInfo[0].UserName + "~" + GlobalDeclaration._holdInfo[0].UserId + "~" + GlobalDeclaration._holdInfo[0].EmpCode;



                    int i = Resources.Instance.insertMasterrecord("Sp_InsertHierachyInfo", "p_oprtor", "p_owner", "p_procOwner", "p_maintenaceOwn", "p_Mcordinates", "p_userName", "p_userId", "p_empCode", Value);
                    if (i > 0)
                    {
                        XtraMessageBox.Show(new Form { TopMost = true }, "Details Insert Successfully", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show(new Form { TopMost = true }, "Error in Insertion", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadEmployeeList()
        {

            // LoadEmploye = Resources.Instance.GetDataKey("SP_GetEmployeeName");
            // _UnitMaster = Resources.Instance.GetDataKey("Sp_GetUnitMaster");
        }
        private void LoadHierarchyData()
        {
            try
            {
                if (cmboprator.SelectedItem == null) return;
                DataTable _cm = Resources.Instance.GetDataKey("Sp_FetchHirerchayData", "p_Mcordinates", cmblocation.SelectedItem.ToString());
                if (_cm.Rows.Count > 0)
                {
                    for (int i = 0; i < _cm.Rows.Count; i++)
                    {
                        cmboprator.Items.Add(_cm.Rows[0]["Op"]);
                        cmbowner.Items.Add(_cm.Rows[0]["OW"].ToString());
                        cmbprocessown.Items.Add(_cm.Rows[0]["PO"].ToString().Trim());
                        cmbMaintenanc.Items.Add(_cm.Rows[0]["MO"].ToString().Trim());
                        cmboprator.SelectedIndex = 0;
                        cmbMaintenanc.SelectedIndex = 0;
                        cmbprocessown.SelectedIndex = 0;
                        cmbowner.SelectedIndex = 0;

                    }
                    cmboprator.Enabled = false;
                    cmbowner.Enabled = false;
                    cmbprocessown.Enabled = false;
                    cmbMaintenanc.Enabled = false;
                }
                else
                {
                    if (cmboprator.DataSource != null) return;
                    if (cmboprator.SelectedItem == null)
                    {
                        if (Resources.Instance._EmpName.Rows.Count > 0)
                        {
                            //cmboprator.DataSource = Resources.Instance._EmpName.Copy();
                            //cmbowner.DataSource = Resources.Instance._EmpName.Copy();
                            //cmbprocessown.DataSource = Resources.Instance._EmpName.Copy();
                            //cmbMaintenanc.DataSource = Resources.Instance._EmpName.Copy();
                            //cmboprator.DisplayMember = Resources.Instance._EmpName.Columns["emp_name"].ColumnName;
                            //cmbowner.DisplayMember = Resources.Instance._EmpName.Columns["emp_name"].ColumnName;
                            //cmbprocessown.DisplayMember = Resources.Instance._EmpName.Columns["emp_name"].ColumnName;
                            //cmbMaintenanc.DisplayMember = Resources.Instance._EmpName.Columns["emp_name"].ColumnName;

                            //cmboprator.ValueMember = Resources.Instance._EmpName.Columns["emp_name"].ColumnName;
                            //cmbowner.ValueMember = Resources.Instance._EmpName.Columns["emp_name"].ColumnName;
                            //cmbprocessown.ValueMember = Resources.Instance._EmpName.Columns["emp_name"].ColumnName;
                            //cmbMaintenanc.ValueMember = Resources.Instance._EmpName.Columns["emp_name"].ColumnName;
                            //cmboprator.SelectedIndex = -1;
                            //cmbowner.SelectedIndex = -1;
                            //cmbprocessown.SelectedIndex = -1;
                            //cmbMaintenanc.SelectedIndex = -1;

                            cmboprator.DataSource = Resources.Instance._EmpName.Copy();
                            cmbowner.DataSource = Resources.Instance._EmpName.Copy();
                            cmbprocessown.DataSource = Resources.Instance._EmpName.Copy();
                            cmbMaintenanc.DataSource = Resources.Instance._EmpName.Copy();
                            //////foreach (DataRow dr in Resources.Instance._EmpName.Copy().Rows)
                            //////{
                            //////    cmboprator.Items.Add(dr["emp_name"].ToString());
                            //////    cmbowner.Items.Add(dr["emp_name"].ToString());
                            //////    cmbprocessown.Items.Add(dr["emp_name"].ToString());
                            //////    cmbMaintenanc.Items.Add(dr["emp_name"].ToString());
                            //////}

                            cmboprator.DisplayMember = Resources.Instance._EmpName.Columns["emp_name"].ColumnName;
                            cmbowner.DisplayMember = Resources.Instance._EmpName.Columns["emp_name"].ColumnName;
                            cmbprocessown.DisplayMember = Resources.Instance._EmpName.Columns["emp_name"].ColumnName;
                            cmbMaintenanc.DisplayMember = Resources.Instance._EmpName.Columns["emp_name"].ColumnName;

                            cmboprator.ValueMember = Resources.Instance._EmpName.Columns["emp_name"].ColumnName;
                            cmbowner.ValueMember = Resources.Instance._EmpName.Columns["emp_name"].ColumnName;
                            cmbprocessown.ValueMember = Resources.Instance._EmpName.Columns["emp_name"].ColumnName;
                            cmbMaintenanc.ValueMember = Resources.Instance._EmpName.Columns["emp_name"].ColumnName;
                            cmboprator.SelectedIndex = -1;
                            cmbowner.SelectedIndex = -1;
                            cmbprocessown.SelectedIndex = -1;
                            cmbMaintenanc.SelectedIndex = -1;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddIneventoryHeader()
        {
            addinventory.Columns.Clear();
            addinventory.Rows.Clear();
            var mtgno = addinventory.Columns.Add("Machine_tag_no");
            mtgno.ColumnName = "Machine TagNo";

            var itmmn = addinventory.Columns.Add("item_name");
            itmmn.ColumnName = "Item Name";
            addinventory.Columns.Add("stock_in_hand");
            addinventory.Columns.Add("unit");
            addinventory.Columns.Add("date_of_entry");
            addinventory.Columns.Add("model_no");
            addinventory.Columns.Add("minimum_stock_trigger_lvl");
            addinventory.Columns.Add("oem_name");
            addinventory.Columns.Add("last_ordered_data");
            addinventory.Columns.Add("min_lead_time");
            //addinventory.Columns.Add("machine_tag_no");
            //addinventory.Columns.Add("item_name");
            //addinventory.Columns.Add("stock_in_hand");
            //addinventory.Columns.Add("unit");
            //addinventory.Columns.Add("date_of_entry");
            //addinventory.Columns.Add("model_no");
            //addinventory.Columns.Add("minimum_stock_trigger_lvl");
            //addinventory.Columns.Add("oem_name");
            //addinventory.Columns.Add("last_ordered_data");
            //addinventory.Columns.Add("min_lead_time");


        }

        //bcol.HeaderText = "Edit ";
        //bcol.Text = "Edit";
        //bcol.Name = "btnClickMe";
        //bcol.UseColumnTextForButtonValue = true;
        //// DbGridInventory.Columns.Add(bcol);
        //DgvInventory.Columns.Insert(0, bcol);

        //DataGridViewButtonColumn DeleCol = new DataGridViewButtonColumn();
        //DeleCol.HeaderText = "Delete ";
        //DeleCol.Text = "Delete";
        //DeleCol.Name = "btnDelete";
        //DeleCol.UseColumnTextForButtonValue = true;
        //// DbGridInventory.Columns.Add(bcol);
        //DgvInventory.Columns.Insert(1, DeleCol);

        #endregion

        #region All Button Event Fire List

        private void btnAddManually_Click(object sender, EventArgs e)
        {
            try
            {
                if (frm == null)
                {
                    frm = new MachineEditKeyComponent(this.MachineName);
                    frm.updatekeyValueHandler += ChlidEvetHander;
                    if (Resources.Instance.KeyDt != null)
                        frm.LoadData();
                }
                // frm.MdiParent = this;
                frm.ShowDialog();
                frm.Close();
                frm.Dispose();
                frm = null;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void btnOutput_Click(object sender, EventArgs e)
        {
            try
            {
                OutPut_Property outPut = new OutPut_Property(this.ConnectionMachineName, this.SysGenMachineNo);
                if (this._listconnt.Count > 0)
                {
                    outPut._listconnt = _listconnt;
                }
                if (DialogResult.OK == outPut.ShowDialog())
                {
                    outPut._listconnt.Clear();

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error); throw;
            }
            ////btnFunction.Focus();
        }

        private void btnAddmore_Click(object sender, EventArgs e)
        {
            try
            {
                if (keycmp == null)
                {
                    keycmp = new KeySafetyComponent(this.MachineName);
                    keycmp.updatekeySafetyHandler += KeySafetyHandlerEvent;
                    if (keycmp != null)
                        keycmp.LoadData(Resources.Instance.Safetydt);
                }
                keycmp.ShowDialog();
                keycmp.Close();
                keycmp.Dispose();
                keycmp = null;
            }
            catch (Exception Ex)
            {

                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btninpute_Click(object sender, EventArgs e)
        {
            try
            {
                Input_Property IP = new Input_Property(this.SysGenMachineNo, this.ConnectionMachineName);
                if (this._listconnt.Count > 0)
                {
                    // IP.ReceiveConValue = this.ReceiveConValue;
                    IP._listconnt = _listconnt;
                }
                if (DialogResult.OK == IP.ShowDialog())
                {
                    IP._listconnt.Clear();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error); throw;
            }
            ////btnFunction.Focus();
        }
        private void btnupdat_Click(object sender, EventArgs e)
        {
            try
            {
                UniversalTabevent(sender, e);
                if (GlobalDeclaration.UserType.Equals("Admin") || GlobalDeclaration.UserType.Equals("U0-User"))
                {
                    if (!string.IsNullOrEmpty(txttagno.Text) && !string.IsNullOrEmpty(txtlocationmanual.Text))
                    {
                        string valueslist = this.ConnectionMachineName.Replace('~', '_') + "~" + txttagno.Text + "~" + this.SysGenMachineNo + "~" +
                            this.cmblocation.SelectedItem.ToString() + "~" + txtlocationmanual.Text + "~" + GlobalDeclaration._holdInfo[0].UserName + "~"
                            + GlobalDeclaration._holdInfo[0].UserId.ToString() + "~" + GlobalDeclaration._holdInfo[0].EmpCode;

                        int i = Resources.Instance.insertMasterrecord("Sp_InsertMasterData", "p_machineName", "p_machinatag", "p_sysgenname", "p_cadlocation", "p_machlocation", "p_userName", "p_userID", "p_empCode", valueslist);
                        DataRow[] Update = Resources.Instance.MachineDt.Select("MachineTagNo='" + txttagno.Text + "' and MachineName='" + this.ConnectionMachineName.Replace('~', '_') + "' and CadLocation='" + this.cmblocation.SelectedItem.ToString() + "'");
                        if (Update.Length > 0) return;
                        DataRow dr = Resources.Instance.MachineDt.NewRow();
                        dr["MachineTagNo"] = txttagno.Text;
                        dr["MachineName"] = this.ConnectionMachineName.Replace('~', '_');
                        dr["CadLocation"] = this.cmblocation.SelectedItem.ToString();
                        Resources.Instance.MachineDt.Rows.Add(dr);
                        //if (i > 0)
                        //{
                        //    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Machine Info Save.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnPriceTenstive_Click(object sender, EventArgs e)
        {
            try
            {
                Tentive_Price T_price = new Tentive_Price(this.SysGenMachineNo, this.MachineName, this.txttagno.Text);
                T_price.TopMost = true;
                if (T_price.ShowDialog() == DialogResult.OK)
                {
                    T_price.MachineName = "";
                    T_price.MachineTag = "";
                    T_price.SysGenNo = "";
                    T_price.Close();
                }
            }
            catch (Exception Ex)
            {

                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ////this.btnFunction.Focus();
            ////this.btnFunction.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            ////this.btnPriceTenstive.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;


        }

        ////private void UpdateInventoryHeader()
        ////{
        ////    updinventory.Columns.Clear();
        ////    updinventory.Rows.Clear();
        ////    updinventory.Columns.Add("machine_tag_no");
        ////    updinventory.Columns.Add("item_name");
        ////    updinventory.Columns.Add("stock_in_hand");
        ////    updinventory.Columns.Add("unit");
        ////    updinventory.Columns.Add("date_of_entry");
        ////    updinventory.Columns.Add("model_no");
        ////    updinventory.Columns.Add("minimum_stock_trigger_lvl");
        ////    updinventory.Columns.Add("oem_name");
        ////    updinventory.Columns.Add("last_ordered_data");
        ////    updinventory.Columns.Add("min_lead_time");
        ////    updinventory.Columns.Add("auto_invent_id");
        ////}

        private void btnbrowser_Click(object sender, EventArgs e)
        {
            var obd = openFileDialog1.ShowDialog();
            // openFileDialog1.Filter = "Supported files | *.xls; *.xlsx; *.xlsb; *.csv | xls | *.xls | xlsx | *.xlsx | xlsb | *.xlsb | csv | *.csv | All | *.*";           
            if ((obd != DialogResult.OK) || (string.IsNullOrEmpty(openFileDialog1.FileName)))
            {
                return;
            }
            // if (dgventry.Columns.Count > 0)
            {
                txtfile.Text = openFileDialog1.FileName;
            }
        }
        private void btndohazop_Click(object sender, EventArgs e)
        {
            //frmDoHazop hazopfrm = new frmDoHazop();
            //hazopfrm.Show();
        }

        private void btnshowprevious_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region All Other Event List

        void ChlidEvetHander(object sender, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (listKeyComp.Items.Contains(value))
                {
                    XtraMessageBox.Show(new Form { TopMost = true }, "Already Exists", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    listKeyComp.Items.Add(value);
                    DataRow[] Update = Resources.Instance.KeyDt.Select("KeyName='" + value + "'");
                    if (Update.Length > 0) return;
                    DataRow dr = Resources.Instance.KeyDt.NewRow();
                    dr["KeyName"] = value;
                    Resources.Instance.KeyDt.Rows.Add(dr);
                }
            }
            else
            {
                XtraMessageBox.Show(new Form { TopMost = true }, "Can not Add Blank Key", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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

        private void KeySafetyHandlerEvent(object sender, string value)
        {
            try
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (listSafetyComp.Items.Contains(value))
                    {
                        XtraMessageBox.Show(new Form { TopMost = true }, "Alreday Exists", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        listSafetyComp.Items.Add(value);
                        DataRow[] dataRows = Resources.Instance.Safetydt.Select("KeySafetyItem='" + value + "'");
                        if (dataRows.Length > 0) return;
                        DataRow dr = Resources.Instance.Safetydt.NewRow();
                        dr["KeySafetyItem"] = value;
                        Resources.Instance.Safetydt.Rows.Add(dr);
                    }
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true }, "Can not Add Blank Key", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void UnveralEvetCall(object sender, EventArgs e)
        {
            string tage = ((SparrowRMSControl.SparrowControl.SparrowButton)sender).Tag.ToString();
            //string tage = ((Button)sender).Tag.ToString();
            switch (tage)
            {
                case "LogData":
                    UpdateLogData();
                    break;
                case "DoDont":
                    UpdateDoDntsFrmData();
                    break;
                case "Safety":
                    SafetyCheckList();
                    break;
                case "Hzard":
                    break;
                case "JSA":
                    UpdateJRAfrmValue();
                    break;
                case "Loto":
                    break;
                case "Compliance":
                    break;
                case "SOP":
                    UpdateSOPData();
                    break;
                case "Report":
                    break;
            }
        }
        private void cmbkeycomponets_SelectedIndexChanged(object sender, EventArgs e)
        {
            // We Have Copy or Access or Fill Data From KeyComponect Tab or Copy data from KeyCompoent Table DropDown Value
        }

        private void UniversalTabevent(object sender, EventArgs e)
        {
            try
            {
                if (GlobalDeclaration.UserType.Equals("Admin") || GlobalDeclaration.UserType.Equals("U0-User"))
                {
                    string value = string.Empty;
                    int result = 0;
                    switch (MCDpages.SelectedTab.Tag.ToString())
                    {
                        case "FuntionTb":
                            {
                                if (txttagno.Text == "")
                                {
                                    XtraMessageBox.Show(new Form { TopMost = true }, "MachineTagNo Should Not be Empty \n Please Enter Value Of MachineTag", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txttagno.Focus();
                                    return;

                                }
                                if ( string.IsNullOrEmpty(cmblayer.Text)) //(cmblayer.SelectedItem.ToString() == "")
                                {
                                    XtraMessageBox.Show(new Form { TopMost = true }, "Layer Should Not be Empty \n Please Enter Value Of MachineLayer", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    cmblayer.Focus();
                                    return;
                                }
                                if (string.IsNullOrEmpty(cmblocation.Text)) //(cmblocation.SelectedItem.ToString() == "")
                                {
                                    XtraMessageBox.Show(new Form { TopMost = true }, "Location Should Not be Empty \n Please Enter Value Of Location", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    cmblocation.Focus();
                                    return;
                                }
                                if (txtlifetime.Text == "")
                                {
                                    XtraMessageBox.Show(new Form { TopMost = true }, "Expected Life time Should Not be Empty \n Please Enter Value Of Expected Life time", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtlifetime.Focus();
                                    return;
                                }
                                if (string.IsNullOrEmpty(CmbLifeTimeUnit.Text)) //(CmbLifeTimeUnit.SelectedItem.ToString() == "")
                                {
                                    XtraMessageBox.Show(new Form { TopMost = true }, "Please select Expected Life time.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    CmbLifeTimeUnit.Focus();
                                    return;
                                }
                                if (txtprice.Text == "")
                                {
                                    XtraMessageBox.Show(new Form { TopMost = true }, "Purchase Price Should Not be Empty \n Please Enter Value Of Purchase Price", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtprice.Focus();
                                    return;
                                }
                                if (txtlocationmanual.Text == "")
                                {
                                    XtraMessageBox.Show(new Form { TopMost = true }, "Please Fill Machine Location", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtlocationmanual.Focus();
                                    return;
                                }
                                value = txttagno.Text + "+" + cmblayer.SelectedItem.ToString() + "+" + CmbPriceUnit.SelectedItem.ToString() + "+" + cmbStatus.SelectedItem.ToString() + "+" + cmblocation.SelectedItem.ToString() + "+" + datepickInstallation.Value.ToString() +
                                   "+" + datepckYear.Value.ToString() + "+" + txtlifetime.Text + "-" + CmbLifeTimeUnit.SelectedItem.ToString() + "+" + txtprice.Text
                                   + "+" + this.SysGenMachineNo + "+" + this.txtlocationmanual.Text + "+"
                                   + GlobalDeclaration._holdInfo[0].UserName + "+" + GlobalDeclaration._holdInfo[0].UserId.ToString() + "+" + GlobalDeclaration._holdInfo[0].EmpCode;
                                if (GlobalDeclaration.UserType.Equals("Admin") || GlobalDeclaration.UserType.Equals("U0-User"))
                                {
                                    result = Resources.Instance.InsertRecord("Sp_InsertFuntionElemnetData", value);
                                    if (result > 0)
                                    {
                                        if (!GlobalDeclaration._MyTagDictinary.ContainsKey(_Cordinates))
                                            GlobalDeclaration._MyTagDictinary.Add(_Cordinates, txttagno.Text);
                                        XtraMessageBox.Show(new Form { TopMost = true }, "Details SuccessFully Save In Db", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        result = 0;

                                    }
                                    else
                                    {
                                        XtraMessageBox.Show(new Form { TopMost = true }, "Unable To Insert Data", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    }
                                }
                            }
                            break;
                        case "KeyCompTab":
                            {
                                if (txttagno.Text == "")
                                {
                                    XtraMessageBox.Show(new Form { TopMost = true }, "MachineTagNo Should Not be Empty \n Please Enter Value Of MachineTag", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    // txttagno.Focus();
                                    return;
                                }
                                if (dgvmachine.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dgvmachine.Rows.Count; i++)
                                    {
                                        value = this.MachineName + "~" + txttagno.Text + "~" + this.dgvmachine.Rows[i].Cells["Machine"].Value.ToString() + "~" + this.dgvmachine.Rows[i].Cells["Location"].Value.ToString().Trim() + "~" + this.dgvmachine.Rows[i].Cells["Type"].Value.ToString() + "~" + this.cmblocation.SelectedItem.ToString() + "~" + GlobalDeclaration._holdInfo[0].EmpCode;
                                        result = Resources.Instance.InsertRecordKeyComTab("Sp_InsertKeyComponentsData", value);
                                    }
                                    if (result > 0)
                                    {
                                        XtraMessageBox.Show(new Form { TopMost = true }, "Details SuccessFully Save In Db", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        result = 0;
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show(new Form { TopMost = true }, "Unable To Insert Data", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //return;
                                    }
                                }
                                if (listKeyComp.Items.Count > 0)
                                    UpdateKeyCompData();

                                if (listSafetyComp.Items.Count > 00)
                                    UpdateSafetyKey();
                            }
                            break;
                        case "DesignTab":
                            {

                            }
                            break;
                        case "InventoryTab":
                            {

                            }
                            break;
                        case "SafetyTab":
                            {
                                if (txtSpecificPPEs.Text == "")
                                {
                                    XtraMessageBox.Show(new Form { TopMost = true }, "SpecificPPE Should Not be Empty \n Please Enter Value Of SpecificPPE", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtSpecificPPEs.Focus();
                                    return;
                                }
                                value = this.SysGenMachineNo + "_" + txttagno.Text + "_" + cmbCriticalDvice.SelectedItem + "_" + txtSpecificPPEs.Text + "_" + GlobalDeclaration._holdInfo[0].EmpCode;
                                result = Resources.Instance.InsertSafetyMaster("Sp_InsertSafetData", value);
                                if (result > 0)
                                {
                                    XtraMessageBox.Show(new Form { TopMost = true }, "Details SuccessFully Save In Db", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                                else
                                {
                                    XtraMessageBox.Show(new Form { TopMost = true }, "Unable To Insert Data", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                            break;
                        case "EnvTab":
                            {

                            }
                            break;
                        case "maintenanceTab":
                            {
                                if (_NewRowAdd && (!GlobalDeclaration.UserType.Equals("U1-Maintenance") || !GlobalDeclaration.UserType.Equals("U1-Safety")))
                                {
                                    SaveMaintenanceData();
                                }
                                else
                                {
                                    SaveMaintenanceData();
                                }
                            }
                            break;
                        case "OwnTab":
                            {
                                InsertHierachytabData();
                            }
                            break;
                        case "paramsRab":
                            {

                            }
                            break;
                        case "ComplRequeTab":
                            {

                            }
                            break;
                        case "standardTab":
                            {
                                //addStandard.Clear();
                                //addStandard.Rows.Clear();
                                //addStandard.Columns.Clear();
                                //bindStandardDBGrid();
                            }
                            break;

                        case "HazopTab":
                            {
                                //addStandard.Clear();
                                //addStandard.Rows.Clear();
                                //addStandard.Columns.Clear();
                                //bindStandardDBGrid();
                            }
                            break;

                        default:
                            {

                                break;
                            }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateKeyCompData()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ComponentsName", typeof(string));
                dt.Columns.Add("MachineName", typeof(string));
                dt.Columns.Add("MachineTag", typeof(string));
                dt.Columns.Add("UserName", typeof(string));
                dt.Columns.Add("UserId", typeof(int));
                dt.Columns.Add("MachineCordinate", typeof(string));
                dt.Columns.Add("EmpCode", typeof(string));
                DataRow dr = null;
                for (int i = 0; i < listKeyComp.Items.Count; i++)
                {
                    dr = dt.NewRow();
                    string Name = listKeyComp.Items[i].ToString();
                    dr["ComponentsName"] = Name;
                    dr["MachineName"] = this.MachineName;
                    dr["MachineTag"] = txttagno.Text;
                    dr["UserName"] = GlobalDeclaration._holdInfo[0].UserName;
                    dr["UserId"] = GlobalDeclaration._holdInfo[0].UserId;
                    dr["MachineCordinate"] = cmblocation.SelectedItem.ToString();
                    dr["EmpCode"] = GlobalDeclaration._holdInfo[0].EmpCode;
                    dt.Rows.Add(dr);
                }
                int I = Resources.Instance.SaveMainTenenceData("Sp_InsertKeyComponentsMaster", "p_KeyTBL", dt);
                dt.Clear();
                dt.Dispose();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void MachineEditDataUpd_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (RemoveDicEvetHandeler != null)
                    RemoveDicEvetHandeler.Invoke(sender, this.SysGenMachineNo);
                ParentWindow.ismachineDragged = false;
                //if (XtraMessageBox.Show(new Form { TopMost = true },"Do you want Exit Application.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) ;
                //{
                //}
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtSpecificPPEs_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void LoadDataEvent(object sender, EventArgs e)
        {
            string tabval = MCDpages.SelectedTab.Tag.ToString();
            switch (tabval)
            {
                case "FuntionTb":
                    {
                        //_IsAlrdyCheck = true;
                        //_IsDataStatus = false;
                        LoadFunctionEleMentData();
                        if (GlobalDeclaration.UserType.Equals("U1-Maintenance") || GlobalDeclaration.UserType.Equals("U1-Safety"))
                        {
                            ////txttagno.ReadOnly = true;
                            cmblayer.Enabled = false;
                            cmblocation.Enabled = false;
                            ////txtlifetime.ReadOnly = true;
                            CmbLifeTimeUnit.Enabled = false;
                            ////txtprice.ReadOnly = true;
                            ////txtlocationmanual.ReadOnly = true;
                        }
                    }
                    break;
                case "SpecificationTab":
                    {
                        btnupdat.Enabled = true;
                        btnsavespecs.Enabled = true;
                        string machineData = GlobalDeclaration.ReturnPath() + @"\" + "Application_Machines" + @"\" + this.Text.Trim() + "_" + MCDpages.SelectedTab.Tag.ToString() + ".xml";
                        if (File.Exists(machineData))
                        {
                            DataSet ds = new DataSet();
                            ds.ReadXml(machineData);
                            DBGridView.DataSource = ds.Tables[0];
                            isExists = true;
                            DBGridView.Columns["Data Tag"].Visible = false;
                            DBGridView.Columns["Param Tag"].Visible = false;
                            DBGridView.Columns["Header Id"].Visible = false;
                            DBGridView.Columns["Control Type"].Visible = false;
                            DBGridView.Columns["Rfq"].Visible = false;
                            DBGridView.Columns["RFQ"].Visible = false;
                            DBGridView.Columns["MachineName"].Visible = false;
                        }
                        tabindexvalchanged(1);
                    }
                    break;
                case "maintenanceTab":
                    {
                        // _IsAlrdyCheck = false;s
                        // _IsDataStatus = true;

                        IsUploadMaintenceData();

                        //if (GlobalDeclaration._MyTagDictinary.Count > 0)
                        //{
                        //    // InputInfoDt = Resources.Instance.GetDataKey("Sp_FetchMaintenaceInputeMaster");
                        //    // MachineDt = Resources.Instance.GetDataKey("Sp_Loadachines");
                        //    if (this.checkedListBox1.Items.Count > 0) return;
                        //    foreach (KeyValuePair<DPoint, string> item in GlobalDeclaration._MyTagDictinary)
                        //    {
                        //        string MachineTag = item.Value;
                        //        this.checkedListBox1.Items.Add(MachineTag);
                        //    }
                        //    this.checkedListBox1.SelectionMode = SelectionMode.One;
                        //    this.checkedListBox1.Visible = false;
                        //    this.checkedListBox1.CheckOnClick = true;
                        //    this.checkedListBox1.FormattingEnabled = true;
                        //    this.checkedListBox1.ColumnWidth = 15;
                        //    this.Controls.Remove(checkedListBox1);
                        //    this.DgvMaitenance.Controls.Add(checkedListBox1);
                        //    this.DgvMaitenance.CellBeginEdit += new DataGridViewCellCancelEventHandler(dataGridView1_CellBeginEdit);
                        //    this.DgvMaitenance.CellEndEdit += new DataGridViewCellEventHandler(dataGridView1_CellEndEdit);
                        //    this.DgvMaitenance.Scroll += new ScrollEventHandler(dataGridView1_Scroll);
                        //}
                        if (GlobalDeclaration.UserType.Equals("U1-Maintenance") || GlobalDeclaration.UserType.Equals("U1-Safety"))
                        {
                            DgvMaitenance.ReadOnly = true;
                            DgvResult.ReadOnly = true;
                            cntmenuGrid.Visible = false;
                            ContestResult.Visible = true;
                            btnbrowser.Enabled = false;
                            btnLoad.Enabled = false;
                        }
                        //DataTable dt = Resources.Instance.GetDataKey("Sp_FetchMaintenaceInputeMaster");
                        //if()
                        //if (!IsUploadMaintenceData())
                        //{
                        //    // bindGrid();
                        //}

                    }
                    break;
                case "OwnTab":
                    {
                        LoadHierarchyData();
                    }
                    break;
                case "tabPageUpl":
                    {
                        lblareakm.Text = txtlocationmanual.Text;
                        DataTable dts = new DataTable();
                        if (txttagno.Text != "")
                        {
                            string desiredPath = Application.StartupPath + @"\MCD_FileUploads" + @"\" + txttagno.Text;
                            if (Directory.Exists(desiredPath))
                            {

                            }
                            dts = Resources.Instance.GetMachineUploadedDocs(txttagno.Text, "", "", "", "", System.DateTime.Now, 2);
                            DataTable dtFilesArr = new DataTable();
                            if (Directory.Exists(desiredPath))
                            {
                                string[] AllfilesArr = Directory.GetFiles(desiredPath, "*", SearchOption.AllDirectories);
                                if (AllfilesArr.Length > 0)
                                {
                                    for (int d = 0; d < AllfilesArr.Length; d++)
                                    {
                                        dtFilesArr.Columns.Add("Files" + "_" + d);
                                        dts.Columns.Add("Files" + "_" + d);
                                    }
                                    //DataRow drRow = dtFilesArr.NewRow();
                                    //for (int z = 0; z < dtFilesArr.Columns.Count; z++)
                                    //{
                                    //    drRow[z] = AllfilesArr[z];
                                    //}
                                    //dtFilesArr.Rows.Add(drRow);
                                    //dts.Merge(dtFilesArr);
                                    DBGridViewMAchineDocs.DataSource = dts;
                                    DBGridViewMAchineDocs.Columns["RefId"].Visible = false;
                                    int y = 0;
                                    columnList.Add("");
                                    columnList.Add("");
                                    columnList.Add("");
                                    columnList.Add("");
                                    columnList.Add("");
                                    columnList.Add("");
                                    columnList.Add("");
                                    for (int x = 7; x < dts.Columns.Count; x++)
                                    {
                                        DataGridViewButtonCell btnCol = new DataGridViewButtonCell();
                                        btnCol.Value = "View";
                                        DBGridViewMAchineDocs.Rows[0].Cells[x].Value = "";
                                        DBGridViewMAchineDocs[x, 0] = btnCol;
                                        DBGridViewMAchineDocs.Rows[0].Cells[x].Value = "View";
                                        //  dts.Rows[0][x] = AllfilesArr[y];
                                        columnList.Add(AllfilesArr[y]);
                                        y = y + 1;
                                    }
                                }
                            }
                        }
                    }
                    break;
                case "KeyCompTab":
                    {
                        LoadKeyCompentMachineLoad();
                        LoadKeyCompoNente();
                        if (GlobalDeclaration.UserType.Equals("U1-Maintenance") || GlobalDeclaration.UserType.Equals("U1-Safety"))
                        {
                            dgvmachine.ReadOnly = true;
                            grpKeyCompents.Enabled = false;
                            grpSafetyCmp.Enabled = false;
                            grpKeyCompents.Enabled = false;
                            listKeyComp.Enabled = false;
                            listSafetyComp.Enabled = false;
                            btndeletekey.Enabled = false;
                            btnsafetyDelete.Enabled = false;
                            btnAddManually.Enabled = false;
                            btnAddmore.Enabled = false;
                        }
                    }
                    break;
                case "DesignTab":
                    {
                        parentFile = ParentWindow.isFileFound;
                        if (parentFile == true)
                        {
                            getMainDesignData();
                            parentFile = false;
                        }
                    }
                    break;
                case "InventoryTab":
                    {
                        //addinventory.Clear();
                        //addinventory.Columns.Clear();
                        //addinventory.Rows.Clear();

                        // addColumnsDBGrid();
                        getDTS = Resources.Instance.GetMachineNameTagging();
                        txttaggedMachine.Text = txttagno.Text;
                        txttaggedMachine.Enabled = false;
                        //ProtoTypeInventory newinv = new ProtoTypeInventory();
                        //newinv.Show();
                        //_IsAlrdyCheck = true;
                        //_IsDataStatus = false;
                    }
                    break;
                case "SafetyTab":
                    {

                        //_IsAlrdyCheck = true;
                        //_IsDataStatus = false;
                    }
                    break;
                case "EnvTab":
                    {
                        bindGridCol();
                    }
                    break;
                case "paramsRab":
                    {
                        //_IsAlrdyCheck = true;
                        //_IsDataStatus = false;
                    }
                    break;
                case "ComplRequeTab":
                    {
                        //_IsAlrdyCheck = true;
                        //_IsDataStatus = false;
                    }
                    break;
                case "standardTab":
                    {
                        //_IsAlrdyCheck = true;
                        //_IsDataStatus = false;
                        //bindStandardDBGrid();
                    }
                    break;
                case "HazopTab":
                    {
                        //_IsAlrdyCheck = true;
                        //_IsDataStatus = false;

                    }
                    break;

                case "UploaderDoc":
                    {
                        //string machineName = this.Text;
                        //if (machineName.Contains(" "))
                        //{
                        //    machineName = machineName.Replace(" ", "_");
                        //}
                        //GetUploadedDocsMachineWise(txttagno.Text);
                    }
                    break;
            }
        }

        ////private void GetCopiedMachineData()
        ////{
        ////    try
        ////    {
        ////        string ApplicablemachinePAth = GlobalDeclaration.ReturnPath() + @"\" + "Application_Machines" + @"\";
        ////        string machineList = GlobalDeclaration.ReturnPath() + @"\" + "Application_Machines" + @"\" + "CopyData" + ".xml";
        ////        if (File.Exists(machineList))
        ////        {
        ////            DataSet ds = new DataSet();
        ////            ds.ReadXml(machineList);
        ////            // string[] files = Directory.GetFiles(ApplicablemachinePAth);

        ////            DirectoryInfo files = new DirectoryInfo(GlobalDeclaration.ReturnPath() + @"\" + "Application_Machines");//Assuming Test is your Folder
        ////            FileInfo[] Files = files.GetFiles("*.xml"); //Getting Text files
        ////            string str = "";
        ////            List<string> splitFiles = new List<string>();
        ////            //foreach (FileInfo file in Files)
        ////            //{
        ////            //    splitFiles.Add(file.Name);
        ////            //}

        ////            for (int j = 0; j < Files.Length; j++)
        ////            {
        ////                string fileIn = Files[j].Name.ToString();
        ////                string replFile = fileIn.Replace("{}", "");
        ////                string[] splFile = replFile.ToString().Split('_');
        ////                //  string repBrac=
        ////                splitFiles.Add(splFile[0].ToString());

        ////            }
        ////            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        ////            {
        ////                string machineName = ds.Tables[0].Rows[i].Field<string>("MachineName");
        ////                string[] splArr = this.Text.Trim().ToString().Split('_');
        ////                if (splitFiles.Contains(splArr[0]))
        ////                {
        ////                    reloadFileArr();
        ////                    break;
        ////                }
        ////            }
        ////        }
        ////    }
        ////    catch (Exception Ex)
        ////    {
        ////        XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
        ////    }

        ////}


        private void reloadFileArr()
        {
            string machineData = GlobalDeclaration.ReturnPath() + @"\" + "Application_Machines" + @"\" + this.Text.Trim() + "_" + MCDpages.SelectedTab.Text + ".xml";

            if (File.Exists(machineData))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(machineData);
                DBGridView.DataSource = ds.Tables[0];
                isExists = true;
                DBGridView.Columns["Data Tag"].Visible = false;
                DBGridView.Columns["Param Tag"].Visible = false;
                DBGridView.Columns["Header Id"].Visible = false;
                DBGridView.Columns["Control Type"].Visible = false;
                DBGridView.Columns["Rfq"].Visible = false;
                DBGridView.Columns["RFQ"].Visible = false;
                DBGridView.Columns["MachineName"].Visible = false;


                //for (int a = 0; a < tabControl1.TabCount; a++)
                //{
                //    for (int j = 0; j < headerarr.Count; j++)
                //    {
                //        if (headerarr[j] == tabControl1.TabPages[a].Text)
                //        {


                //        }
                //        else
                //        {
                //            tabControl1.TabPages.Remove(tabControl1.TabPages[a]);
                //        }
                //    }

                //}
            }
            else
            {
                currentTab = 0;

                //for (int a = 0; a < tabControl1.TabCount; a++)
                //{
                //    for (int j = 0; j < headerarr.Count; j++)
                //    {
                //        if (headerarr[a] == tabControl1.TabPages[a].Text)
                //        {


                //        }
                //        else
                //        {
                //            TabPage tabname = tabControl1.TabPages[a]; 
                //            tabControl1.TabPages.Remove(tabname);
                //            //tabControl1.Controls.Remove(tabname);
                //        }
                //    }

                // }
                isSpecLoad = true;

                tabindexvalchanged(currentTab);
            }
        }
        //private void GetUploadedDocsMachineWise(string machineTag)
        //{
        //    uploaderDocs = Resources.Instance.GetUploadedDocsMachineWise("", "", "", "", machineTag, 2);
        //    if (uploaderDocs.Rows.Count > 0)
        //    {
        //        lblUpl1.Text = uploaderDocs.Rows[0][2].ToString();
        //        lblUpl1.ReadOnly = true;
        //        lblUpl2.Text = uploaderDocs.Rows[0][3].ToString();
        //        lblUpl2.ReadOnly = true;
        //        lblUpl3.Text = uploaderDocs.Rows[0][4].ToString();
        //        lblUpl3.ReadOnly = true;
        //    }

        //}
        private void getMainDesignData()
        {
            GetMainDesignData();
        }
        private void GetMainDesignData()
        {
            try
            {

                btnsavespecs.Enabled = true;
                DBGridView.Enabled = true;
                DBGridView.Visible = true;
                DBGridDesignParam.Visible = false;
                currentTab = currentTab + 1;
                tabset = mytable.AsEnumerable().Where(r => r.Field<int>("Header Id") == 7).CopyToDataTable();
                int rowindex = 0;
                foreach (DataRow rows in tabset.Rows)
                {
                    string paramname = rows.Field<string>("Parameter Name");
                    string objectype = rows.Field<string>("Unit");
                    string paramtag1 = rows.Field<string>("Param Tag");
                    tabset.Rows[rowindex][6] = paramname.ToString() + " " + paramtag1;
                    DBGridView.AutoGenerateColumns = true;
                    DBGridView.AllowUserToAddRows = false;
                    DBGridView.Columns.Clear();
                    //DBGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    //DBGridView.AllowCustomTheming = true;
                    rowindex = rowindex + 1;
                }

                tabset.Rows.RemoveAt(0);
                DBGridView.DataSource = tabset;
                if (mytable.Rows.Count > 1)
                {
                    DBGridView.Columns["Data Tag"].Visible = false;
                    DBGridView.Columns["Param Tag"].Visible = false;
                    DBGridView.Columns["Header Id"].Visible = false;
                    DBGridView.Columns["Control Type"].Visible = false;
                    DBGridView.Columns["Rfq"].Visible = false;
                    DBGridView.Columns["MachineName"].Visible = false;
                    for (int a = 0; a < DBGridView.Columns.Count; a++)
                    {
                        DBGridView.Columns[a].SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    columnsAsReadOnly();
                    MCDpages.SelectedTab.Controls.Add(this.DBGridView);
                    getcontroltype();
                    addrows();
                }
                else
                {
                    MessageBox.Show("No Record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnmaintechklist_Click(object sender, EventArgs e)
        {
            if (_dropMachineList.Count > 0 && _dropMachineList != null)
            {
              
            }
        }

        private void txttagno_TextChanged(object sender, EventArgs e)
        {
            txttaggedMachine.Text = txttagno.Text;

        }


        private void datagridHealthEnviron_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }




        private void datagridHealthEnviron_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            string machinetag = datagridHealthEnviron.Rows[rowindex].Cells[8].Value.ToString();
            if (e.ColumnIndex == 0)
            {


                getdata = Resources.Instance.getHealthEnvironmentData(machinetag, 2);
                txtsuplChem.Text = datagridHealthEnviron.Rows[rowindex].Cells[2].Value.ToString();
                txtcleaningchem.Text = datagridHealthEnviron.Rows[rowindex].Cells[3].Value.ToString();
                txtcleaningmat.Text = datagridHealthEnviron.Rows[rowindex].Cells[4].Value.ToString();
                cmbEmission.Text = datagridHealthEnviron.Rows[rowindex].Cells[5].Value.ToString();
                cmbDischarge.Text = datagridHealthEnviron.Rows[rowindex].Cells[6].Value.ToString();
                cmbwaste.Text = datagridHealthEnviron.Rows[rowindex].Cells[7].Value.ToString();
                btnAddEnv.Text = "Update";

                txtmachinetagenv.Text = datagridHealthEnviron.Rows[rowindex].Cells[8].Value.ToString();
                //txtmachinetagenv.ReadOnly = true;
            }

            else if (e.ColumnIndex == 1)
            {
                int i = Resources.Instance.DropEnvironmentData(machinetag);
                if (i > 0)
                {
                    MessageBox.Show("Record Deleted", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Unable to Delete!..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                bindGridCol();
            }
        }


        private void SheetComboSelectedIndexChanged(object sender, EventArgs e)
        {
            SelectTable();
        }
        #endregion

        #region Maintenanace Data Grid Event And Method 

        bool bIsComboBox = false;
        private void tabmaintenenace_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(tabmaintenenace.SelectedTabPage.Tag.ToString()) == 1)
                {
                    if (_NewRowAdd && (!GlobalDeclaration.UserType.Equals("U1-Maintenance") || !GlobalDeclaration.UserType.Equals("U1-Safety")))
                    {
                        AddResult();
                    }
                    else
                    {
                        AddResult();
                    }

                    //tabmaintenenace.TabPages[2].PageEnabled = false;
                    _IsUpdateCell = true;
                    _IsUpdateCellCAPA = false;
                }
                else if (int.Parse(tabmaintenenace.SelectedTabPage.Tag.ToString()) == 2)
                {
                    //tabmaintenenace.TabPages[2].PageEnabled = false;
                    _IsUpdateCell = true;
                    _IsUpdateCellCAPA = false;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddResult()
        {
            try
            {
                if (DgvMaitenance.Rows.Count > 0)
                {
                    if (DgvMaitenance.SelectedRows.Count > 0)
                    {
                        for (int i = 0; i < DgvMaitenance.SelectedRows.Count; i++)
                        {
                            if (DgvMaitenance.Rows[i].Cells["MachineTag"].Value == null)
                            {
                                XtraMessageBox.Show(new Form { TopMost = true }, "Machine Tag Blank . Please Fill Machine Tag First", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            string MTag = DgvMaitenance.Rows[i].Cells["MachineTag"].Value.ToString();
                            string Acitvoty = DgvMaitenance.Rows[i].Cells["Activity"].Value.ToString();
                            var Rows = DgvResult.Rows.Cast<DataGridViewRow>().Where(X => X.Cells["Mtag"].Value.ToString() == MTag && X.Cells["objactivity"].Value.ToString() == Acitvoty).ToList();
                            if (Rows.Count > 0)
                            {
                                foreach (DataGridViewRow rw in Rows)
                                {
                                    rw.Cells["Mtag"].Value = MTag;
                                    rw.Cells["objactivity"].Value = Acitvoty;
                                }
                            }
                            else
                            {
                                DataGridViewRow drresult = new DataGridViewRow();
                                DgvResult.Rows.Insert(0, drresult);
                                DgvResult.Rows[0].Cells["Mtag"].Value = MTag;
                                DgvResult.Rows[0].Cells["objactivity"].Value = Acitvoty;
                            }
                            //objactivity
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void addRowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (((ToolStripMenuItem)sender).Tag.ToString() == "Add")
                {
                    DataGridViewRow dr = new DataGridViewRow();
                    DgvMaitenance.Rows.Add(dr);
                    int index = DgvMaitenance.Rows.Count - 1;
                    DgvMaitenance.Rows[index].Cells["SrNo"].Value = SerialNumber++;
                    DgvMaitenance.Columns["SrNo"].ReadOnly = true;
                    DgvMaitenance.Rows[index].Cells["Mdate"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                    DgvMaitenance.Columns["Mdate"].ReadOnly = true;
                    DgvMaitenance.Rows[index].Cells["MachineTag"].Value = txttagno.Text;
                    DgvMaitenance.Columns["MachineTag"].ReadOnly = true;
                    DgvMaitenance.Rows[index].Cells["Status"].Value = "New";
                    _IsUpdateCell = false;
                    _NewRowAdd = true;
                    AddEmployee(index);
                }
                else
                {
                    if (DgvMaitenance.Rows.Count > 0)
                    {
                        if (DgvMaitenance.SelectedRows.Count > 0)
                        {
                            if (DgvMaitenance.SelectedRows[0].Cells["MachineTag"].Value == null)
                            {
                                DgvMaitenance.Rows.RemoveAt(DgvMaitenance.SelectedRows[0].Index);
                                if (sheetCombo.SelectedItem != null)
                                    _SheetName.Remove(sheetCombo.SelectedItem.ToString());
                                SerialNumber--;
                                return;
                            }
                            if (DgvMaitenance.SelectedRows.Count > 0)
                            {
                                string Machtah = DgvMaitenance.SelectedRows[0].Cells["MachineTag"].Value.ToString();
                                DgvMaitenance.Rows.RemoveAt(DgvMaitenance.SelectedRows[0].Index);
                                if (sheetCombo.SelectedItem != null)
                                    _SheetName.Remove(sheetCombo.SelectedItem.ToString());

                                SerialNumber--;
                                Resources.Instance.RemoveEntry("Sp_DeleteMaintenenceBasicDetails", "p_tagNo", "p_MachineName", "p_Cadlocation", txttagno.Text, this.MachineName, this.cmblocation.SelectedItem.ToString(), "hh");
                            }
                            else
                            {
                                XtraMessageBox.Show(new Form { TopMost = true }, "Please Select Any Row First From Basic Detail Tab.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show(new Form { TopMost = true }, "Please Select Any Row First From Result Tab?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                    }
                    else
                    {
                        XtraMessageBox.Show(new Form { TopMost = true }, "No Row Remain for Delete", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void AddRows(object sender, EventArgs e)
        {
            try
            {
                if (((ToolStripMenuItem)sender).Tag.ToString() == "Add")
                {
                    if (DgvResult.Rows.Count > 0)
                    {
                        if (DgvResult.SelectedRows.Count > 0)
                        {
                            if (DgvResult.SelectedRows[0].Cells["Mtag"] != null)
                            {
                                DgvResult.ReadOnly = false;
                                DataGridViewRow dr = new DataGridViewRow();
                                DgvResult.Rows.Add(dr);
                                int index = DgvResult.Rows.Count - 1;
                                DgvResult.Rows[index].Cells["Mtag"].Value = DgvResult.SelectedRows[0].Cells["Mtag"].Value;
                                DgvResult.Rows[index].Cells["objactivity"].Value = DgvResult.SelectedRows[0].Cells["objactivity"].Value;
                                DgvResult.Rows[index].Cells["StatusR"].Value = DgvResult.SelectedRows[0].Cells["Status"].Value;
                                DgvResult.Rows[index].Cells["Mtag"].ReadOnly = true;
                                DgvResult.Rows[index].Cells["objactivity"].ReadOnly = true;
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show(new Form { TopMost = true }, "Please select row from basic tab details.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(new Form { TopMost = true }, "Please select row from basic tab details", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    try
                    {
                        if (DgvResult.SelectedRows.Count > 0)
                        {
                            if (DgvResult.SelectedRows[0].Cells["Rsult"].Value != null)
                            {
                                if (DgvResult.SelectedRows[0].Cells["Mtag"].Value == null) return;
                                string machintag = DgvResult.SelectedRows[0].Cells["Mtag"].Value.ToString();
                                string MachineName = this.MachineName;
                                if (DgvResult.SelectedRows[0].Cells["Rsult"].Value == null) return;
                                string Rslt = DgvResult.SelectedRows[0].Cells["Rsult"].Value.ToString();
                                if (DgvResult.SelectedRows[0].Cells["Element"].Value == null) return;
                                string Elments = DgvResult.SelectedRows[0].Cells["Element"].Value.ToString();
                                DgvResult.Rows.RemoveAt(DgvResult.SelectedRows[0].Index);
                                if (GlobalDeclaration.CAPAtbl == null) return;
                                if (GlobalDeclaration.CAPAtbl.Rows.Count > 0)
                                {

                                    GlobalDeclaration.CAPAtbl.AsEnumerable().Where(X => X.Field<string>("MachineTag").Equals(machintag)
                                    && X.Field<string>("ObjRslt").Equals(Rslt) && X.Field<string>("Elements").Equals(Elments))
                                       .ToList().ForEach(X => X.Delete());
                                    GlobalDeclaration.CAPAtbl.AcceptChanges();
                                    machintag = string.Empty;
                                    MachineName = string.Empty;
                                    Rslt = string.Empty;
                                    Elments = string.Empty;
                                    int Stat = Resources.Instance.RemoveEntry("Sp_DeletResultDataCapa", "p_mtag", "p_Elemets", machintag, Elments);
                                    if (Stat > 0)
                                    {
                                        XtraMessageBox.Show(new Form { TopMost = true }, "Record Deleted From Db?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                DgvResult.Rows.RemoveAt(DgvResult.SelectedRows[0].Index);
                            }
                        }
                    }
                    catch (Exception Ex)
                    {
                        XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        //{
        //    try
        //    {
        //        if (e.ColumnIndex == 1)
        //        {

        //            Rectangle rec = this.DgvMaitenance.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
        //            checkedListBox1.Location = rec.Location;
        //            checkedListBox1.Width = rec.Width;
        //            checkedListBox1.Height = this.DgvMaitenance.Height / 2;

        //            for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
        //            {
        //                this.checkedListBox1.SetItemChecked(i, false);
        //            }

        //            checkedListBox1.Visible = true;
        //        }
        //        this.DgvMaitenance.Columns["MachineTag"].ReadOnly = false;
        //    }
        //    catch (Exception Ex)
        //    {
        //        XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (e.ColumnIndex == 1)
        //        {
        //            string SelectName = string.Empty;
        //            var item = checkedListBox1.CheckedItems;
        //            if (item.Count > 0)
        //            {
        //                for (int i = 0; i < item.Count; i++)
        //                {
        //                    SelectName = SelectName + item[i].ToString() + ",";//item[i].ToString();
        //                }
        //                SelectName = SelectName.Remove(SelectName.TrimEnd().Length - 1, 1);
        //                if (!string.IsNullOrEmpty(SelectName))
        //                {
        //                    this.DgvMaitenance.CurrentCell.Value = SelectName;
        //                    //this.DgvMaitenance.SelectedCells[1].Value = SelectName;
        //                    //this.DgvMaitenance.Columns["MachineTag"].ReadOnly = true;
        //                    //this.checkedListBox1.Visible = false;
        //                }
        //            }
        //        }
        //        this.checkedListBox1.Visible = false;
        //    }
        //    catch (Exception Ex)
        //    {
        //        XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        //{
        //    try
        //    {
        //        if (DgvMaitenance.Rows.Count > 0)
        //        {
        //            if (DgvMaitenance.CurrentCell.ColumnIndex == 1)
        //            {
        //                if (checkedListBox1.Visible)
        //                {
        //                    Rectangle rec = this.DgvMaitenance.GetCellDisplayRectangle(this.DgvMaitenance.CurrentCell.ColumnIndex, this.DgvMaitenance.CurrentCell.RowIndex, true);
        //                    checkedListBox1.Location = rec.Location;
        //                    checkedListBox1.Width = rec.Width;
        //                    checkedListBox1.Height = DgvMaitenance.Height / 4;
        //                }
        //                //checkedListBox1.Visible = false;
        //            }
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        private void dgventry_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                LastDateTimePicker = new DateTimePicker();  //DateTimePicker 

                //Adding DateTimePicker control into DataGridView
                DgvMaitenance.Controls.Add(LastDateTimePicker);

                // Intially made it invisible
                LastDateTimePicker.Visible = false;

                // Setting the format (i.e. 2014-10-10)
                LastDateTimePicker.Format = DateTimePickerFormat.Custom;  //
                LastDateTimePicker.CustomFormat = "yyyy-MM-dd";

                LastDateTimePicker.TextChanged += new System.EventHandler(LastDateTimePicker_OntextChange);

                // Now make it visible
                LastDateTimePicker.Visible = true;

                // It returns the retangular area that represents the Display area for a cell
                Rectangle oRectangle = DgvMaitenance.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control
                LastDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location
                LastDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);

                LastDateTimePicker.CloseUp += new System.EventHandler(LastDateTimePicker_CloseUp);

            }
        }
        private void DgvMaitenance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void LastDateTimePicker_OntextChange(object sender, EventArgs e)
        {
            DgvMaitenance.CurrentCell.Value = LastDateTimePicker.Text.ToString();
        }
        void LastDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            LastDateTimePicker.Visible = false;
        }
        private void DgvMaitenance_Scroll(object sender, ScrollEventArgs e)
        {
            if (LastDateTimePicker != null)
                LastDateTimePicker.Visible = false;

            checkedListBox1.Visible = false;
        }
        private void dgventry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DgvResult.Rows.Count > 0)
                {
                    if (e.ColumnIndex == 14)
                    {
                        if (ValidatePrevMaintainance(e.RowIndex) == false) return;
                        //if (DgvResult.Rows[e.RowIndex].Cells["Rsult"] == null || DgvResult.Rows[e.RowIndex].Cells["Deviations"] == null)
                        //{
                        //    XtraMessageBox.Show("Please fill Result Or Deviations column");
                        //    return;
                        //}

                        DgvResult.Rows[e.RowIndex].Selected = true;
                        if (DgvResult.Rows[e.RowIndex].Cells["Rsult"].Value.ToString() == "Not Ok" || DgvResult.Rows[e.RowIndex].Cells["Deviations"].Value.ToString() == "Not In Range")
                        {

                            XtraTabPage xtraTabPage = null;
                            if (tabmaintenenace.TabPages.Count == 2)
                            {
                                //tabmaintenenace.TabPages.Add("CAPA");
                                //var obj = tabmaintenenace.TabPages[2];
                                //obj.Name= "CAPA";
                                //obj.Tag = 2;
                                xtraTabPage = tabmaintenenace.TabPages.Add("CAPA");
                                xtraTabPage.Name = "CAPA";
                                xtraTabPage.Tag = 2;
                                DgvCAPATab = new DataGridView();
                                DgvCAPATab.DataSource = GlobalDeclaration.MapColumnCAPA();
                                DgvCAPATab.AllowUserToResizeColumns = false;
                                DgvCAPATab.AllowUserToAddRows = false;
                                DgvCAPATab.AllowUserToOrderColumns = false;
                                DgvCAPATab.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                                DgvCAPATab.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                                DgvCAPATab.Dock = DockStyle.Fill;
                                xtraTabPage.Controls.Add(DgvCAPATab);
                                DgvCAPATab.CellEndEdit += DgvCAPATab_CellEndEdit;
                                this.FontSet(false);
                                xtraTabPage.Show();

                            }
                            else
                            {
                                //xtraTabPage.Show();
                                tabmaintenenace.TabPages[2].PageEnabled = true;
                                tabmaintenenace.TabPages[2].Show();

                            }
                            DynamicAddCtrl(true);
                        }
                    }
                    else if (e.ColumnIndex == this.DgvResult.Columns["upload"].Index)
                    {
                        XtraMessageBox.Show(new Form { TopMost = true }, "Save  Report", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    //else
                    //{
                    //    if (dgventry.Rows.Count > 0)
                    //    {

                    //        int colnindex = dgventry.CurrentCell.ColumnIndex;
                    //        string upp = @"Update MaintennaceTBL set " + dgventry.Columns[colnindex].Name + " ='" + dgventry.Rows[e.RowIndex].Cells[colnindex].Value.ToString() + "' where clmMachineName='" + dgventry.Rows[e.RowIndex].Cells["clmMachineName"].Value.ToString() + "' or clmMachineTag='" + dgventry.Rows[e.RowIndex].Cells["clmMachineTag"].Value.ToString() + "'";
                    //        MessageBox.Show(upp);
                    //    }
                    //}
                }
            }
            catch (Exception Ex)
            {

                XtraMessageBox.Show(new Form { TopMost = true }, Ex.StackTrace, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DgvMaitenance_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            var row = DgvMaitenance.Rows[e.RowIndex];
            if (DgvMaitenance.Columns[e.ColumnIndex].Name == "expct")
            {
                var cell = DgvMaitenance.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (null != cell)
                {
                    object value = cell.Value;
                    if (value != null)
                    {
                        if (IsNumber(value.ToString()))
                        {

                        }
                        else
                        {
                            XtraMessageBox.Show(new Form { TopMost = true }, "Expected Time only Contain Number Only.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            DgvMaitenance.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                            return;
                        }
                    }
                }
            }

        }
        private bool IsNumber(string str)
        {
            int outvalue;
            bool value = int.TryParse(str, out outvalue);
            return value;
        }
        private void dgventry_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SetComboBoxCellType objChangeCellType = new SetComboBoxCellType(ChangeCellToComboBox);
                if (e.ColumnIndex == this.DgvMaitenance.Columns["Team"].Index)
                {
                    this.DgvMaitenance.BeginInvoke(objChangeCellType, e.RowIndex, "itmactvty", e.ColumnIndex);
                    bIsComboBox = false;

                }
                else if (e.ColumnIndex == this.DgvMaitenance.Columns["Frequency"].Index)
                {
                    this.DgvMaitenance.BeginInvoke(objChangeCellType, e.RowIndex, "Frequency", e.ColumnIndex);
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DgvMaitenance.Columns["ShtdwnReq"].Index)
                {
                    this.DgvMaitenance.BeginInvoke(objChangeCellType, e.RowIndex, "ShtdwnReq", e.ColumnIndex);
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DgvMaitenance.Columns["outsorce"].Index)
                {
                    this.DgvMaitenance.BeginInvoke(objChangeCellType, e.RowIndex, "outsorce", e.ColumnIndex);
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DgvMaitenance.Columns["Units"].Index)
                {
                    this.DgvMaitenance.BeginInvoke(objChangeCellType, e.RowIndex, "Units", e.ColumnIndex);
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DgvMaitenance.Columns["InputInfo"].Index)
                {
                    this.DgvMaitenance.BeginInvoke(objChangeCellType, e.RowIndex, "Info", e.ColumnIndex);
                    bIsComboBox = false;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DgvResult_cellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SetComboBoxCellTypeReult objChangeCellTypeResult = new SetComboBoxCellTypeReult(ChangeCellToComboBoxResult);
                if (e.ColumnIndex == this.DgvResult.Columns["responce"].Index)
                {
                    this.DgvResult.BeginInvoke(objChangeCellTypeResult, e.RowIndex, "responce", e.ColumnIndex);
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DgvResult.Columns["Rsult"].Index)
                {
                    this.DgvResult.BeginInvoke(objChangeCellTypeResult, e.RowIndex, "Rsult", e.ColumnIndex);
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DgvResult.Columns["Deviations"].Index)
                {
                    this.DgvResult.BeginInvoke(objChangeCellTypeResult, e.RowIndex, "Deviations", e.ColumnIndex);
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DgvResult.Columns["criticality"].Index)
                {
                    this.DgvResult.BeginInvoke(objChangeCellTypeResult, e.RowIndex, "criticality", e.ColumnIndex);
                    bIsComboBox = false;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DgvCAPATab_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SetComboBoxCellTypeCAPA objChangeCellTypeResult = new SetComboBoxCellTypeCAPA(ChangeCellComboBoxCAPA);
                if (e.ColumnIndex == this.DgvResult.Columns["Responsibility0"].Index)
                {
                    this.DgvCAPATab.BeginInvoke(objChangeCellTypeResult, e.RowIndex, "Responsibility0", e.ColumnIndex);
                    bIsComboBox = false;
                }
                else if (e.ColumnIndex == this.DgvResult.Columns["Responsibility1"].Index)
                {
                    this.DgvCAPATab.BeginInvoke(objChangeCellTypeResult, e.RowIndex, "Responsibility1", e.ColumnIndex);
                    bIsComboBox = false;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ChangeCellComboBoxCAPA(int iRowIndex, string ColumnName, int iColumnIndex)
        {
            try
            {
                if (bIsComboBox == false)
                {
                    if (ColumnName == "Responsibility0")
                    {
                        if (DgvCAPATab.Rows[iRowIndex].Cells[iColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell DgvResponsivility = new DataGridViewComboBoxCell();
                        DgvResponsivility.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                        DgvResponsivility.DataSource = Resources.Instance._EmpName;
                        DgvResponsivility.ValueMember = "emp_name";
                        DgvResponsivility.DisplayMember = "emp_name";
                        DgvCAPATab[iColumnIndex, iRowIndex] = DgvResponsivility;
                        DgvResponsivility.Dispose();
                        bIsComboBox = true;

                    }
                    if (ColumnName == "Responsibility1")
                    {
                        if (DgvCAPATab.Rows[iRowIndex].Cells[iColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell DgvResponsivility = new DataGridViewComboBoxCell();
                        DgvResponsivility.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                        DgvResponsivility.DataSource = Resources.Instance._EmpName.Copy();
                        DgvResponsivility.ValueMember = "emp_name";
                        DgvResponsivility.DisplayMember = "emp_name";
                        DgvCAPATab[iColumnIndex, iRowIndex] = DgvResponsivility;
                        DgvResponsivility.Dispose();
                        bIsComboBox = true;

                    }
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        DataTable LoadEmploye = new DataTable();
        private void ChangeCellToComboBoxResult(int iRowIndex, string ColumnName, int iColumnIndex)
        {
            try
            {
                if (bIsComboBox == false)
                {
                    if (ColumnName == "responce")
                    {
                        if (DgvResult.Rows[iRowIndex].Cells[iColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgvResponce = new DataGridViewComboBoxCell();
                        dgvResponce.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                        DataTable RiskDt = new DataTable();
                        RiskDt.Columns.Add("Name", typeof(string));
                        string[] ArrayList = { "Visual", "Numeric" };
                        for (int i = 0; i < ArrayList.Length; i++)
                        {
                            DataRow dr = RiskDt.NewRow();
                            dr["Name"] = ArrayList[i].ToString();
                            RiskDt.Rows.Add(dr);
                        }
                        dgvResponce.DataSource = RiskDt;
                        dgvResponce.ValueMember = "Name";
                        dgvResponce.DisplayMember = "Name";
                        DgvResult[iColumnIndex, iRowIndex] = dgvResponce;
                        dgvResponce.Dispose();
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "Rsult")
                    {
                        if (DgvResult.Rows[iRowIndex].Cells[iColumnIndex].Value != null) return;
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
                        DgvResult[iColumnIndex, iRowIndex] = dgvResult;
                        dgvResult.Dispose();
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "Deviations")
                    {
                        if (DgvResult.Rows[iRowIndex].Cells[iColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgvResultDeviation = new DataGridViewComboBoxCell();
                        dgvResultDeviation.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        DataTable RiskDt = new DataTable();
                        RiskDt.Columns.Add("Name", typeof(string));
                        string[] ArrayList = { "InRange", "Not In Range" };
                        for (int i = 0; i < ArrayList.Length; i++)
                        {
                            DataRow dr = RiskDt.NewRow();
                            dr["Name"] = ArrayList[i].ToString();
                            RiskDt.Rows.Add(dr);
                        }
                        dgvResultDeviation.DataSource = RiskDt;
                        dgvResultDeviation.ValueMember = "Name";
                        dgvResultDeviation.DisplayMember = "Name";
                        DgvResult[iColumnIndex, iRowIndex] = dgvResultDeviation;
                        dgvResultDeviation.Dispose();
                        bIsComboBox = true;
                    }
                    else if (ColumnName == "criticality")
                    {
                        if (DgvResult.Rows[iRowIndex].Cells[iColumnIndex].Value != null) return;
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
                        DgvResult[iColumnIndex, iRowIndex] = dgvcriti;
                        dgvcriti.Dispose();
                        bIsComboBox = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangeCellToComboBox(int iRowIndex, string ColumnName, int iColumnIndex)
        {
            try
            {
                if (bIsComboBox == false)
                {
                    if (ColumnName == "itmactvty")
                    {
                        if (DgvMaitenance.Rows[iRowIndex].Cells[DgvMaitenance.CurrentCell.ColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgComboCell = new DataGridViewComboBoxCell();
                        dgComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgComboCell.DataSource = Resources.Instance._EmpName;
                        dgComboCell.ValueMember = "emp_name";
                        dgComboCell.DisplayMember = "emp_name";
                        DgvMaitenance[iColumnIndex, iRowIndex] = dgComboCell;
                        bIsComboBox = true;
                        dgComboCell.Dispose();

                    }
                    else if (ColumnName == "Units")
                    {
                        //string val = DgvMaitenance.Rows[iRowIndex].Cells[DgvMaitenance.CurrentCell.ColumnIndex].Value.ToString();
                        //if (!string.IsNullOrEmpty(val)) return;
                        if (DgvMaitenance.Rows[iRowIndex].Cells[DgvMaitenance.CurrentCell.ColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgUnits = new DataGridViewComboBoxCell();
                        dgUnits.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgUnits.DataSource = Resources.Instance._UnitMaster;
                        dgUnits.ValueMember = "UnitName";
                        dgUnits.DisplayMember = "UnitName";
                        DgvMaitenance[iColumnIndex, iRowIndex] = dgUnits;
                        bIsComboBox = true;
                        dgUnits.Dispose();
                    }
                    else if (ColumnName == "Frequency")
                    {
                        string val = DgvMaitenance.Rows[iRowIndex].Cells[DgvMaitenance.CurrentCell.ColumnIndex].Value.ToString();
                        //if (!string.IsNullOrEmpty(val)) return;
                        //if (DgvMaitenance.Rows[iRowIndex].Cells[DgvMaitenance.CurrentCell.ColumnIndex].Value != null) return;
                        DataTable RiskDt = new DataTable();
                        RiskDt.Columns.Add("Name", typeof(string));
                        string[] ArrayList = { "Daily", "Weekly", "Monthly", "Quarterly", "Half Yearly", "Year" };
                        for (int i = 0; i < ArrayList.Length; i++)
                        {
                            DataRow dr = RiskDt.NewRow();
                            dr["Name"] = ArrayList[i].ToString();
                            RiskDt.Rows.Add(dr);
                        }
                        DataGridViewComboBoxCell dgvfreqncy = new DataGridViewComboBoxCell();
                        dgvfreqncy.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgvfreqncy.DataSource = RiskDt;
                        dgvfreqncy.ValueMember = "Name";
                        dgvfreqncy.DisplayMember = "Name";
                        DgvMaitenance[iColumnIndex, iRowIndex] = dgvfreqncy;
                        dgvfreqncy.Dispose();
                    }
                    else if (ColumnName == "ShtdwnReq")
                    {
                        string val = DgvMaitenance.Rows[iRowIndex].Cells[DgvMaitenance.CurrentCell.ColumnIndex].Value.ToString();
                        if (!string.IsNullOrEmpty(val)) return;
                        //if (DgvMaitenance.Rows[iRowIndex].Cells[DgvMaitenance.CurrentCell.ColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgvshtdwnreq = new DataGridViewComboBoxCell();
                        dgvshtdwnreq.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgvshtdwnreq.Items.Add("Yes");
                        dgvshtdwnreq.Items.Add("No");
                        DgvMaitenance[iColumnIndex, iRowIndex] = dgvshtdwnreq;
                        dgvshtdwnreq.Dispose();
                    }
                    else if (ColumnName == "outsorce")
                    {
                        string val = DgvMaitenance.Rows[iRowIndex].Cells[DgvMaitenance.CurrentCell.ColumnIndex].Value.ToString();
                        if (!string.IsNullOrEmpty(val)) return;
                        //if (DgvMaitenance.Rows[iRowIndex].Cells[DgvMaitenance.CurrentCell.ColumnIndex].Value != null )
                        DataGridViewComboBoxCell dgvOutsource = new DataGridViewComboBoxCell();
                        dgvOutsource.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        dgvOutsource.Items.Add("InHouse");
                        dgvOutsource.Items.Add("OutSource");
                        DgvMaitenance[iColumnIndex, iRowIndex] = dgvOutsource;
                        dgvOutsource.Dispose();
                    }
                    else if (ColumnName == "Info")
                    {
                        //if (DgvMaitenance.Rows[iRowIndex].Cells[DgvMaitenance.CurrentCell.ColumnIndex].Value != null) return;
                        DataGridViewComboBoxCell dgvOutsource = new DataGridViewComboBoxCell();
                        dgvOutsource.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        InputInfoDt = Resources.Instance.GetDataKey("Sp_FetchMaintenaceInputeMaster");
                        dgvOutsource.DataSource = InputInfoDt;
                        dgvOutsource.DisplayMember = "InputName";
                        dgvOutsource.ValueMember = "InputName";
                        DgvMaitenance[iColumnIndex, iRowIndex] = dgvOutsource;
                        dgvOutsource.Dispose();
                    }
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvMaitenance_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 13 && e.RowIndex >= 0)
                {
                    string Value = DgvMaitenance.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    if (Value == "Add More")
                    {
                      
                    }
                }
                if (e.ColumnIndex == 8 && e.RowIndex >= 0)
                {
                    string Value = DgvMaitenance.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    if (Value == "Add New")
                    {
                        //Form_Collection.AddNewGenericUnit genunit = new AddNewGenericUnit(null, "", null, 0);
                        //genunit.updateComboUnit += UpdateUnitList;
                        //if (genunit.ShowDialog() == DialogResult.OK)
                        //{
                        //    DgvMaitenance.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = genunit.txtName.Text;
                        //    genunit.txtName.Text = "";
                        //    genunit.Close();
                        //    genunit.Dispose();
                        //    if (DgvMaitenance.IsCurrentCellDirty)
                        //    {
                        //        DgvMaitenance.CommitEdit(DataGridViewDataErrorContexts.Commit);
                        //    }
                        //}
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void UpdateUnitList(object sender, string value)
        {
            DataRow[] Update = Resources.Instance._UnitMaster.Select("UnitName='" + value + "'");
            if (Update.Length > 0) return;
            DataRow dr = Resources.Instance._UnitMaster.NewRow();
            dr["UnitName"] = value;
            Resources.Instance._UnitMaster.Rows.Add(dr);
        }
        private void DGVResult_CellValueChnaged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (int.Parse(tabmaintenenace.SelectedTabPage.Tag.ToString()) == 2)
                {
                    if (e.ColumnIndex == 2 && e.RowIndex >= 0)
                    {
                        string Value = DgvResult.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        if (Value == "Visual")
                        {
                            //if(DgvResult.Rows[e.RowIndex].Cells["observationN"].Value)
                            DgvResult.Columns["observationN"].Visible = false ? true : false;
                            ///DgvResult.Rows[e.RowIndex].Cells["observationV"].Value = true;
                            DgvResult.Columns["Rsult"].Visible = true;// false ? true : false;
                            DgvResult.Columns["Vmin"].Visible = false ? true : false;
                            DgvResult.Columns["Vmax"].Visible = false ? true : false;
                            DgvResult.Columns["Deviations"].Visible = false ? true : false;
                            DgvResult.Rows[e.RowIndex].Cells["observationN"].Value = "NA";
                            DgvResult.Rows[e.RowIndex].Cells["observationN"].ReadOnly = true;
                            DgvResult.Rows[e.RowIndex].Cells["Vmin"].Value = "NA";
                            DgvResult.Rows[e.RowIndex].Cells["Vmin"].ReadOnly = true;
                            DgvResult.Rows[e.RowIndex].Cells["Vmax"].Value = "NA";
                            DgvResult.Rows[e.RowIndex].Cells["Vmax"].ReadOnly = true;
                            DgvResult.Rows[e.RowIndex].Cells["Deviations"].Value = "NA";
                            DgvResult.Rows[e.RowIndex].Cells["Deviations"].ReadOnly = true;
                            DgvResult.Rows[e.RowIndex].Cells["Rsult"].Value = null;
                        }
                        else if (Value == "Numeric")
                        {
                            DgvResult.Columns["observationV"].Visible = false ? true : false;
                            DgvResult.Columns["Rsult"].Visible = false;
                            DgvResult.Rows[e.RowIndex].Cells["observationV"].Value = "NA";
                            DgvResult.Rows[e.RowIndex].Cells["observationV"].ReadOnly = true;
                            DgvResult.Rows[e.RowIndex].Cells["Rsult"].Value = "NA";
                            DgvResult.Rows[e.RowIndex].Cells["Rsult"].ReadOnly = true;

                            DgvResult.Columns["observationN"].Visible = true;
                            DgvResult.Columns["Vmin"].Visible = true;
                            DgvResult.Columns["Vmax"].Visible = true;
                            DgvResult.Columns["Deviations"].Visible = true;
                            DgvResult.Rows[e.RowIndex].Cells["observationN"].ReadOnly = false;
                            DgvResult.Rows[e.RowIndex].Cells["Vmin"].ReadOnly = false;
                            //DgvResult.Rows[e.RowIndex].Cells["Vmax"].ReadOnly = false;
                            DgvResult.Rows[e.RowIndex].Cells["Deviations"].ReadOnly = false;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DGVResult_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DgvResult.IsCurrentCellDirty)
            {
                DgvMaitenance.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void ImputeTypeMaintenenceEvent(object sender, string value)
        {
            InputInfoDt = Resources.Instance.GetDataKey("Sp_FetchMaintenaceInputeMaster");
        }
        private void DgvMaitenance_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DgvMaitenance.IsCurrentCellDirty)
            {
                DgvMaitenance.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void DynamicAddCtrl(bool _IsNewLoad)
        {
            if (_IsNewLoad)
            {
                FillCAPAGrid();
            }
            else
            {
                XtraTabPage xtraTabPage = null;
                if (tabmaintenenace.TabPages.Count == 2)
                {
                    //xtraTabPage = tabmaintenenace.TabPages.Add("CAPA");
                    //xtraTabPage.Name = "CAPA";
                    //xtraTabPage.Tag = 2;
                    DgvCAPATab = new DataGridView();
                    DgvCAPATab.DataSource = GlobalDeclaration.MapColumnCAPA();
                    DgvCAPATab.AllowUserToResizeColumns = false;
                    DgvCAPATab.AllowUserToAddRows = false;
                    DgvCAPATab.AllowUserToOrderColumns = false;
                    DgvCAPATab.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    DgvCAPATab.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                    DgvCAPATab.Dock = DockStyle.Fill;
                    xtraTabPage.Controls.Add(DgvCAPATab);
                    DgvCAPATab.CellEndEdit += DgvCAPATab_CellEndEdit;
                    DgvCAPATab.CellEnter += DgvCAPATab_CellEnter;
                    xtraTabPage.Show();
                }
                else
                {
                    ////xtraTabPage.Show();
                    //tabmaintenenace.TabPages[1].PageEnabled = true;
                    tabmaintenenace.TabPages[1].Show();

                }
            }

        }
        private void DgvCAPATab_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!_IsUpdateCellCAPA) return;
                if (GlobalDeclaration.CAPAtbl.Rows.Count > 0)
                {

                    int colnindex = DgvCAPATab.CurrentCell.ColumnIndex;
                    string upp = @"Update MaintennaceCAPATBL set " + DgvCAPATab.Columns[colnindex].Name + " ='" + DgvCAPATab.Rows[e.RowIndex].Cells[colnindex].Value.ToString() + "' where clmMachineName='" + DgvCAPATab.Rows[e.RowIndex].Cells["MachineName"].Value.ToString() + "' or clmMachineTag='" + DgvCAPATab.Rows[e.RowIndex].Cells["MachineTag"].Value.ToString() + "'";
                    int r = Resources.Instance.SaveMaintenenceData(upp, "CAPA");
                    if (r > 0)
                    {
                        XtraMessageBox.Show(new Form { TopMost = true }, "CAPACell Update SuccessFully..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception Ex)
            {

                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void dgventry_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (GlobalDeclaration.UserType.Equals("U1-Maintenance") || GlobalDeclaration.UserType.Equals("U1-Safety"))
                {
                    if (!_IsUpdateCell) return; // this flag should be also true when user fetch data as per machine means LoadTime
                    if (DgvMaitenance.Rows.Count > 0)
                    {
                        int colnindex = DgvMaitenance.CurrentCell.ColumnIndex;
                        var ddd = DgvMaitenance.Rows[e.RowIndex].Cells[colnindex];
                        if (ddd.Value != null)
                        {
                            var update = DgvMaitenance.Rows[e.RowIndex].Cells[colnindex];
                            var machinename = DgvMaitenance.Rows[e.RowIndex].Cells["MachineName"];
                            //dgventry.Columns["MachineTag"].Visible = true;
                            var tag = DgvMaitenance.Rows[e.RowIndex].Cells["MachineTag"];
                            if (update.Value != null && tag.Value != null && machinename.Value != null)
                            {
                                string upp = @"Update MaintennaceTBL set " + DgvMaitenance.Columns[colnindex].Name + " ='" + DgvMaitenance.Rows[e.RowIndex].Cells[colnindex].Value.ToString() + "' where MachineName='" + DgvMaitenance.Rows[e.RowIndex].Cells["MachineName"].Value.ToString() + "' or MachineTag='" + DgvMaitenance.Rows[e.RowIndex].Cells["MachineTag"].Value.ToString() + "'";
                                int r = Resources.Instance.SaveMaintenenceData(upp);
                                if (r > 0)
                                {
                                    XtraMessageBox.Show(new Form { TopMost = true }, "Cell Update SuccessFully..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FillCAPAGrid()
        {
            try
            {
                if (DgvResult.SelectedRows.Count > 0)
                {
                    string machintag = DgvResult.SelectedRows[0].Cells["Mtag"].Value.ToString();
                    string MachineName = this.MachineName;
                    string Rslt = DgvResult.SelectedRows[0].Cells["Rsult"].Value.ToString();
                    string Elments = DgvResult.SelectedRows[0].Cells["Element"].Value.ToString();
                    DataRow[] Update = GlobalDeclaration.CAPAtbl.Select("MachineTag='" + machintag + "' and ObjRslt='" + Rslt + "' and Elements='" + Elments + "'");
                    if (Update.Length > 0)
                    {
                        GlobalDeclaration.CAPAtbl.Columns["objectitem"].ReadOnly = false;
                        GlobalDeclaration.CAPAtbl.Columns["ObjObserv"].ReadOnly = false;
                        GlobalDeclaration.CAPAtbl.Columns["ObjRslt"].ReadOnly = false;
                        GlobalDeclaration.CAPAtbl.Columns["Criticality"].ReadOnly = false;
                        GlobalDeclaration.CAPAtbl.Columns["Elements"].ReadOnly = false;
                        foreach (DataRow row in Update)
                        {
                            row["objectitem"] = DgvResult.SelectedRows[0].Cells["objactivity"].Value.ToString();
                            row["ObjObserv"] = DgvResult.SelectedRows[0].Cells["observationV"].Value.ToString();
                            row["ObjRslt"] = DgvResult.SelectedRows[0].Cells["Rsult"].Value.ToString();
                            row["Criticality"] = DgvResult.SelectedRows[0].Cells["criticality"].Value.ToString();
                            row["Elements"] = DgvResult.SelectedRows[0].Cells["Element"].Value.ToString();
                        }
                        GlobalDeclaration.CAPAtbl.Columns["objectitem"].ReadOnly = true;
                        GlobalDeclaration.CAPAtbl.Columns["ObjObserv"].ReadOnly = true;
                        GlobalDeclaration.CAPAtbl.Columns["ObjRslt"].ReadOnly = true;
                        GlobalDeclaration.CAPAtbl.Columns["Criticality"].ReadOnly = true;
                        GlobalDeclaration.CAPAtbl.Columns["Elements"].ReadOnly = true;
                        GlobalDeclaration.CAPAtbl.Columns["UserName"].ReadOnly = true;
                        GlobalDeclaration.CAPAtbl.Columns["UserId"].ReadOnly = true;
                        GlobalDeclaration.CAPAtbl.Columns["EmpCode"].ReadOnly = true;
                        _IsUpdateCellCAPA = true;
                    }
                    else
                    {
                        DataRow dr = GlobalDeclaration.CAPAtbl.NewRow();
                        dr["MachineTag"] = machintag;// futher it should be chnage when CAD Selected Entities Find 
                        dr["MachineName"] = MachineName;//// futher it should be chnage when CAD Selected Entities Find 
                        dr["objectitem"] = DgvResult.SelectedRows[0].Cells["objactivity"].Value.ToString();
                        dr["ObjObserv"] = DgvResult.SelectedRows[0].Cells["observationV"].Value.ToString();
                        dr["ObjRslt"] = DgvResult.SelectedRows[0].Cells["Rsult"].Value.ToString();
                        dr["Criticality"] = DgvResult.SelectedRows[0].Cells["criticality"].Value.ToString();
                        dr["Elements"] = Elments;
                        dr["UserName"] = GlobalDeclaration._holdInfo[0].UserName;
                        dr["UserId"] = GlobalDeclaration._holdInfo[0].UserId;
                        dr["EmpCode"] = GlobalDeclaration._holdInfo[0].EmpCode;
                        GlobalDeclaration.CAPAtbl.Columns["UserName"].ReadOnly = true;
                        GlobalDeclaration.CAPAtbl.Columns["UserId"].ReadOnly = true;
                        GlobalDeclaration.CAPAtbl.Columns["EmpCode"].ReadOnly = true;
                        GlobalDeclaration.CAPAtbl.Rows.Add(dr);
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void FontSet(bool is_New)
        {
            using (Font font = new Font("Segoe UI", 9))
            {
                if (is_New)
                {
                    for (int i = 0; i < DgvMaitenance.Columns.Count - 1; i++)
                    {
                        DgvMaitenance.Columns[i].DefaultCellStyle.Font = font;
                    }
                    DgvMaitenance.AutoResizeColumns();
                    DgvMaitenance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {
                    for (int i = 0; i < DgvCAPATab.Columns.Count - 1; i++)
                    {
                        DgvCAPATab.Columns[i].DefaultCellStyle.Font = font;
                    }
                    DgvCAPATab.AutoResizeColumns();
                    DgvCAPATab.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }

            }
        }

        //public string RandomString(int size, bool lowerCase)
        //{
        //    StringBuilder builder = new StringBuilder();
        //    Random random = new Random();
        //    char ch;
        //    for (int i = 0; i < size; i++)
        //    {
        //        ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
        //        builder.Append(ch);
        //    }
        //    if (lowerCase)
        //        return builder.ToString().ToLower();
        //    return builder.ToString();
        //}

        string maindate;
        string assignedTo;

        //private void AddNewTask()
        //{
        //    string taskcode1 = RandomString(7, false);
        //    string taskStatus = "Open";
        //    getdata.Clear();
        //    getdata = Resources.Instance.GetGeoLocationForEmployee(assignedTo);
        //    string empCode = getdata.Rows[0][2].ToString();
        //    string description = "Maintenance work for machine " + this.txttagno.Text + " is required on" + " " + maindate;
        //    int cdata = Resources.Instance.AddSafetyTask(taskcode1, "Routine", description, "", "", Convert.ToDateTime(maindate), empCode, GlobalDeclaration._holdInfo[0].EmpCode, "Not Started");
        //    int j = Resources.Instance.AddTaskSafetyTagEvent(taskcode1, empCode, DateTime.Now.ToString("dd-MM-yyyy"), "", taskStatus, "MyTask", 1);
        //    int c = Resources.Instance.AddUserNotification(description, "Plant360", empCode, taskcode1, Convert.ToDateTime(maindate), 0);
        //    if (GlobalDeclaration._holdInfo[0].EmpCode == empCode)
        //    {
        //        notifyMessage.ShowBalloonTip(1000, "Plant360", "Maintenance work for machine " + this.txttagno.Text + " is required on" + " " + maindate, ToolTipIcon.None);
        //        notifyMessage.Text = "";
        //    }


        //}

        // string CMDCAPA = @"insert into MaintennaceCAPATBL(clmMachineTag,clmMachineName,objectitem,ObjRslt,criticality,ObjObserv,Immdcause,RootCause,CorrectiveAction,Reason,PreventiveAct,Responsibility0,Responsibility1,Escalation,CAPA_SRNO) Values";
        private void SaveMaintenanceData()
        {
            try
            {
                if (DgvMaitenance.Rows.Count > 0)
                {
                    foreach (DataGridViewRow rw in this.DgvMaitenance.Rows)
                    {
                        for (int i = 0; i < rw.Cells.Count; i++)
                        {
                            if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                            {
                                XtraMessageBox.Show(new Form { TopMost = true }, "Please Fill Basic  Details Entry..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                    string cmdMaintemnce = @"insert into MaintennaceTBL(SrNo,MachineTag,MachineName,Activity,Team,Dlast,Mdate,Frequency,MReading,Units,outsorce,Mshedule,ShtdwnReq,ExpectTime,InputInfo,Special_tools,PPE_List,MaintenaceMachineList,UserName,UserId,EmpCode) values";
                    string query = string.Empty;
                    for (int i = 0; i < DgvMaitenance.Rows.Count; i++)
                    {
                        if (DgvMaitenance.Rows[i].Cells["Status"].Value.ToString() == "New")
                        {
                            query = query + "(" + DgvMaitenance.Rows[i].Cells["SrNo"].Value + ",'" + this.txttagno.Text + "','" + this.MachineName + "','"
                                + DgvMaitenance.Rows[i].Cells["Activity"].Value.ToString() + "','" + DgvMaitenance.Rows[i].Cells["Team"].Value.ToString() + "' ,'"
                                + DgvMaitenance.Rows[i].Cells["Dlast"].Value.ToString() + "','" + DgvMaitenance.Rows[i].Cells["Mdate"].Value.ToString() + "','"
                                + DgvMaitenance.Rows[i].Cells["Frequency"].Value.ToString() + "','" + DgvMaitenance.Rows[i].Cells["MReading"].Value.ToString() + "','"
                                + DgvMaitenance.Rows[i].Cells["Units"].Value.ToString() + "','" + DgvMaitenance.Rows[i].Cells["outsorce"].Value.ToString() + "','"
                                + DgvMaitenance.Rows[i].Cells["Mshedule"].Value.ToString() + "','" + DgvMaitenance.Rows[i].Cells["ShtdwnReq"].Value.ToString() + "','"
                                + DgvMaitenance.Rows[i].Cells["expct"].Value.ToString() + "','" + DgvMaitenance.Rows[i].Cells["InputInfo"].Value.ToString() + "','"
                                + DgvMaitenance.Rows[i].Cells["Stools"].Value.ToString() + "','" + DgvMaitenance.Rows[i].Cells["PPElist"].Value.ToString() + "','"
                                + DgvMaitenance.Rows[i].Cells["MachineTag"].Value.ToString() + "','"
                                 + GlobalDeclaration._holdInfo[0].UserName + "','" + GlobalDeclaration._holdInfo[0].UserId + "','" + GlobalDeclaration._holdInfo[0].EmpCode + "'),";
                            maindate = DgvMaitenance.Rows[i].Cells["Mdate"].Value.ToString();
                            assignedTo = DgvMaitenance.Rows[i].Cells["Team"].Value.ToString();
                            // AddNewTask();
                        }
                    }
                    if (!string.IsNullOrEmpty(query))
                    {
                        cmdMaintemnce = cmdMaintemnce + query.Remove(query.Length - 1, 1);
                        int Status = Resources.Instance.SaveMaintenenceData(cmdMaintemnce);
                        if (Status > 0)
                        {
                            _IsUpdateCellCAPA = true;
                            //     ReceiveCount = Resources.Instance.GetDataKey("Sp_FetchMaintenanceDataLatest", "@tagNo", "@MachineName", "@Cadlocation", "@username", "@userId", "@empCode", txttagno.Text,
                            //this.MachineName, this.cmblocation.SelectedItem.ToString(), "", 0, "").Rows.Count;
                            XtraMessageBox.Show(new Form { TopMost = true }, "Data Save SuccessFully", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DgvMaitenance.Rows.Cast<DataGridViewRow>().ToList().ForEach(f => f.Cells["Status"].Value = "Saved");
                        }
                        else
                        {
                            XtraMessageBox.Show(new Form { TopMost = true }, "Data Save UnSuccessFully", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        cmdMaintemnce = string.Empty;
                    }
                }
                if (DgvResult.Rows.Count > 0)
                {
                    string cmdMaintemnceResult = @"insert into MaintenanceResultData(Activity,responce,Element,ValueMin,ValueMax,observationV,Rsult,observationN,Deviations,Remark,criticality,Identified_Risk,MaintenaceMachineList,UserName,UserId,EmpCode,FreezStatusRslt) values";
                    string query = string.Empty;
                    foreach (DataGridViewRow rw in this.DgvResult.Rows)
                    {
                        for (int i = 0; i < rw.Cells.Count; i++)
                        {

                            if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                            {
                                XtraMessageBox.Show(new Form { TopMost = true }, "Please Fill All Result Tab Details Entry..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                    if (DgvResult.Rows.Count > 0)
                    {
                        for (int i = 0; i < DgvResult.Rows.Count; i--)
                        {
                            if (DgvResult.Rows[i].Cells["StatusR"].Value.ToString() == "New")
                            {
                                query = query + "('" + DgvResult.Rows[i].Cells["objactivity"].Value.ToString() + "','"
                                + DgvResult.Rows[i].Cells["responce"].Value.ToString() + "','" + DgvResult.Rows[i].Cells["Element"].Value.ToString() + "','"
                                + DgvResult.Rows[i].Cells["Vmin"].Value.ToString() + "','" + DgvResult.Rows[i].Cells["Vmax"].Value.ToString() + "','"
                                + DgvResult.Rows[i].Cells["observationV"].Value.ToString() + "','" + DgvResult.Rows[i].Cells["Rsult"].Value.ToString() + "','"
                                + DgvResult.Rows[i].Cells["observationN"].Value.ToString() + "','" + DgvResult.Rows[i].Cells["Deviations"].Value.ToString() + "','"
                                + DgvResult.Rows[i].Cells["Remark"].Value.ToString() + "','" + DgvResult.Rows[i].Cells["criticality"].Value.ToString() + "','"
                                 + DgvResult.Rows[i].Cells["Idrisk"].Value.ToString() + "','" + DgvResult.Rows[i].Cells["Mtag"].Value.ToString() + "','"
                                 + GlobalDeclaration._holdInfo[0].UserName + "','" + GlobalDeclaration._holdInfo[0].UserId + "','" + GlobalDeclaration._holdInfo[0].EmpCode + "','" + "" + "'),";
                            }
                        }
                        if (DgresultCheck == "Blank")
                        {
                            for (int i = 0; i < DgvResult.Rows.Count; i++)
                            {
                                if (DgvResult.Rows[i].Cells["StatusR"].Value.ToString() == "New")
                                {
                                    query = query + "('" + DgvResult.Rows[i].Cells["objactivity"].Value.ToString() + "','"
                                    + DgvResult.Rows[i].Cells["responce"].Value.ToString() + "','" + DgvResult.Rows[i].Cells["Element"].Value.ToString() + "','"
                                    + DgvResult.Rows[i].Cells["Vmin"].Value.ToString() + "','" + DgvResult.Rows[i].Cells["Vmax"].Value.ToString() + "','"
                                    + DgvResult.Rows[i].Cells["observationV"].Value.ToString() + "','" + DgvResult.Rows[i].Cells["Rsult"].Value.ToString() + "','"
                                    + DgvResult.Rows[i].Cells["observationN"].Value.ToString() + "','" + DgvResult.Rows[i].Cells["Deviations"].Value.ToString() + "','"
                                    + DgvResult.Rows[i].Cells["Remark"].Value.ToString() + "','" + DgvResult.Rows[i].Cells["criticality"].Value.ToString() + "','"
                                     + DgvResult.Rows[i].Cells["Idrisk"].Value.ToString() + "','" + DgvResult.Rows[i].Cells["Mtag"].Value.ToString() + "','"
                                     + GlobalDeclaration._holdInfo[0].UserName + "','" + GlobalDeclaration._holdInfo[0].UserId + "','" + GlobalDeclaration._holdInfo[0].EmpCode + "','" + "" + "'),";
                                }
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(query))
                    {
                        cmdMaintemnceResult = cmdMaintemnceResult + query.Remove(query.Length - 1, 1);
                        int Status = Resources.Instance.SaveMaintenenceData(cmdMaintemnceResult);
                        if (Status > 0)
                        {
                            //Resources.Instance.GetMaxID("Sp_GetResultRecordCount", "@MaxID", ref ResultRecordCount);
                            XtraMessageBox.Show(new Form { TopMost = true }, "Result Tab Data Save SuccessFully..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DgresultCheck = string.Empty;
                            DgvResult.Rows.Cast<DataGridViewRow>().ToList().ForEach(f => f.Cells["StatusR"].Value = "Saved");
                        }
                        else
                        {
                            XtraMessageBox.Show(new Form { TopMost = true }, " Error in Result Tab Data", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                if (DgvCAPATab != null)
                {
                    if (DgvCAPATab.Rows.Count > 0)
                    {
                        int Status = Resources.Instance.SaveMainTenenceData("Sp_InsertCAPADATA", "@CAPAtbl", GlobalDeclaration.CAPAtbl);
                        if (Status > 0)
                        {
                            XtraMessageBox.Show(new Form { TopMost = true }, "Data Save SuccessFully..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show(new Form { TopMost = true }, "Data Save UnSuccessFully..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                cmdMaintemnce = string.Empty;
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        string DgresultCheck = string.Empty;
        private bool IsUploadMaintenceData()
        {
            try
            {
                if (DgvMaitenance.Rows.Count == 0)
                {
                    DataTable _GlobalCAPAtbl = null;
                    DataTable _BasicDetails = null;
                    int CheckOutCAPA = 0;
                    CheckOutCAPA = Resources.Instance.CheckCAPADATA("Sp_CheckCAPARecord", "p_count");
                    Resources.Instance.GetMaxID("Sp_GetResultRecordCount", "p_MaxID", ref ResultRecordCount);
                    if (GlobalDeclaration.UserType.Equals("U1-Maintenance") || GlobalDeclaration.UserType.Equals("U1-Safety") || GlobalDeclaration.UserType.Equals("U1-Operation"))
                    {
                        _GlobalCAPAtbl = Resources.Instance.GetDataKey("Sp_FetchMaintenanceDataLatest", "p_tagNo", "p_MachineName", "p_Cadlocation", "p_username", "p_userId", "p_empCode", txttagno.Text,
                       this.MachineName, this.cmblocation.SelectedItem.ToString(), "", 0, "");
                        _BasicDetails = Resources.Instance.GetDataKey("Sp_FetchMaintenenceBasicDetails", "p_tagNo", "p_MachineName", "p_Cadlocation", "p_username", "p_userId", "p_empCode", txttagno.Text,
                       this.MachineName, this.cmblocation.SelectedItem.ToString(), "", 0, "");
                    }
                    else
                    {
                        _GlobalCAPAtbl = Resources.Instance.GetDataKey("Sp_FetchMaintenanceDataLatest", "p_tagNo", "p_MachineName", "p_Cadlocation", "p_username", "p_userId", "p_empCode", txttagno.Text,
                       this.MachineName, this.cmblocation.SelectedItem.ToString(), GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].UserId, GlobalDeclaration._holdInfo[0].EmpCode);
                        _BasicDetails = Resources.Instance.GetDataKey("Sp_FetchMaintenenceBasicDetails", "p_tagNo", "p_MachineName", "p_Cadlocation", "p_username", "p_userId", "p_empCode", txttagno.Text,
                       this.MachineName, this.cmblocation.SelectedItem.ToString(), "", 0, "");
                    }

                    if (_GlobalCAPAtbl.Rows.Count > 0 && _BasicDetails.Rows.Count > 0)
                    {
                        ReceiveCount = SerialNumber = _GlobalCAPAtbl.Rows.Count;
                        _IsDataStatus = true;
                        if (CheckOutCAPA > 0)
                            DynamicAddCtrl(false);
                        for (int i = 0; i < _BasicDetails.Rows.Count; i++)
                        {
                            DataGridViewRow dr = new DataGridViewRow();
                            DgvMaitenance.Rows.Add(dr);
                            DgvMaitenance.Rows[i].Cells["SrNo"].Value = _GlobalCAPAtbl.Rows[i]["SrNo"].ToString();
                            DgvMaitenance.Rows[i].Cells["MachineTag"].Value = _GlobalCAPAtbl.Rows[i]["MachineTag"].ToString();
                            DgvMaitenance.Rows[i].Cells["Activity"].Value = _GlobalCAPAtbl.Rows[i]["Activity"].ToString();
                            DgvMaitenance.Rows[i].Cells["Team"].Value = _GlobalCAPAtbl.Rows[i]["Team"].ToString();
                            DgvMaitenance.Rows[i].Cells["Dlast"].Value = Convert.ToDateTime(_GlobalCAPAtbl.Rows[i]["Dlast"].ToString());
                            DgvMaitenance.Rows[i].Cells["Mdate"].Value = Convert.ToDateTime(_GlobalCAPAtbl.Rows[i]["Mdate"].ToString());
                            DgvMaitenance.Rows[i].Cells["Frequency"].Value = _GlobalCAPAtbl.Rows[i]["Frequency"].ToString();
                            DgvMaitenance.Rows[i].Cells["MReading"].Value = _GlobalCAPAtbl.Rows[i]["MReading"].ToString();
                            DgvMaitenance.Rows[i].Cells["Units"].Value = _GlobalCAPAtbl.Rows[i]["Units"].ToString();
                            DgvMaitenance.Rows[i].Cells["outsorce"].Value = _GlobalCAPAtbl.Rows[i]["outsorce"].ToString();
                            DgvMaitenance.Rows[i].Cells["Mshedule"].Value = _GlobalCAPAtbl.Rows[i]["Mshedule"].ToString();
                            DgvMaitenance.Rows[i].Cells["ShtdwnReq"].Value = _GlobalCAPAtbl.Rows[i]["ShtdwnReq"].ToString();
                            DgvMaitenance.Rows[i].Cells["expct"].Value = _GlobalCAPAtbl.Rows[i]["ExpectTime"].ToString();
                            DgvMaitenance.Rows[i].Cells["InputInfo"].Value = _GlobalCAPAtbl.Rows[i]["InputInfo"].ToString();
                            DgvMaitenance.Rows[i].Cells["Stools"].Value = _GlobalCAPAtbl.Rows[i]["Special_tools"].ToString();
                            DgvMaitenance.Rows[i].Cells["PPElist"].Value = _GlobalCAPAtbl.Rows[i]["PPE_List"].ToString();
                            DgvMaitenance.Rows[i].Cells["Status"].Value = "Saved";
                        }
                        for (int i = 0; i < _GlobalCAPAtbl.Rows.Count; i++)
                        {


                            // ----------------------------DgvREsult Data Bind-------------
                            DgresultCheck = _GlobalCAPAtbl.Rows[i]["responce"].ToString();
                            if (_GlobalCAPAtbl.Rows[i]["responce"].ToString() == "Blank" || _GlobalCAPAtbl.Rows[i]["responce"].ToString() == "Blank") continue;
                            DataGridViewRow Result = new DataGridViewRow();
                            DgvResult.Rows.Add(Result);
                            DgvResult.Rows[i].Cells["Mtag"].Value = _GlobalCAPAtbl.Rows[i]["MachineTag"].ToString();
                            DgvResult.Rows[i].Cells["objactivity"].Value = _GlobalCAPAtbl.Rows[i]["Activity"].ToString();
                            DgvResult.Rows[i].Cells["responce"].Value = _GlobalCAPAtbl.Rows[i]["responce"].ToString();
                            DgvResult.Rows[i].Cells["Element"].Value = _GlobalCAPAtbl.Rows[i]["Element"].ToString();
                            DgvResult.Rows[i].Cells["Vmin"].Value = _GlobalCAPAtbl.Rows[i]["ValueMin"].ToString();
                            DgvResult.Rows[i].Cells["Vmax"].Value = _GlobalCAPAtbl.Rows[i]["ValueMax"].ToString();
                            DgvResult.Rows[i].Cells["observationV"].Value = _GlobalCAPAtbl.Rows[i]["observationV"].ToString();
                            DgvResult.Rows[i].Cells["Rsult"].Value = _GlobalCAPAtbl.Rows[i]["Rsult"].ToString();
                            DgvResult.Rows[i].Cells["observationN"].Value = _GlobalCAPAtbl.Rows[i]["observationN"].ToString();
                            DgvResult.Rows[i].Cells["Deviations"].Value = _GlobalCAPAtbl.Rows[i]["Deviations"].ToString();
                            DgvResult.Rows[i].Cells["Remark"].Value = _GlobalCAPAtbl.Rows[i]["Remark"].ToString();
                            DgvResult.Rows[i].Cells["criticality"].Value = _GlobalCAPAtbl.Rows[i]["criticality"].ToString();
                            DgvResult.Rows[i].Cells["Idrisk"].Value = _GlobalCAPAtbl.Rows[i]["Identified_Risk"].ToString();
                            DgvResult.Rows[i].Cells["StatusR"].Value = "Saved";
                            if (tabmaintenenace.TabPages.Count == 3)
                            {
                                if (_GlobalCAPAtbl.Rows[i]["immediatecause"].ToString() == "Blank" || _GlobalCAPAtbl.Rows[i]["RootCause"].ToString() == "Blank" || _GlobalCAPAtbl.Rows[i]["CorrectiveAction"].ToString() == "Blank") continue;
                                DataRow drCAPA = GlobalDeclaration.CAPAtbl.NewRow();
                                drCAPA["MachineTag"] = txttagno.Text;
                                drCAPA["MachineName"] = this.MachineName;//// futher it should be chnage when CAD Selected Entities Find 
                                drCAPA["objectitem"] = _GlobalCAPAtbl.Rows[i]["Activity"].ToString();
                                drCAPA["ObjObserv"] = _GlobalCAPAtbl.Rows[i]["observationV"].ToString();
                                drCAPA["ObjRslt"] = _GlobalCAPAtbl.Rows[i]["Rsult"].ToString();
                                drCAPA["Criticality"] = _GlobalCAPAtbl.Rows[i]["criticality"].ToString();
                                drCAPA["immediatecause"] = _GlobalCAPAtbl.Rows[i]["immediatecause"].ToString();
                                drCAPA["RootCause"] = _GlobalCAPAtbl.Rows[i]["RootCause"].ToString();
                                drCAPA["CorrectiveAction"] = _GlobalCAPAtbl.Rows[i]["CorrectiveAction"].ToString();
                                drCAPA["Reason"] = _GlobalCAPAtbl.Rows[i]["Reason"].ToString();
                                drCAPA["PreventiveAct"] = _GlobalCAPAtbl.Rows[i]["PreventiveAct"].ToString();
                                drCAPA["Responsibility0"] = _GlobalCAPAtbl.Rows[i]["Responsibility0"].ToString();
                                drCAPA["Responsibility1"] = _GlobalCAPAtbl.Rows[i]["Responsibility1"].ToString();
                                drCAPA["Escalation"] = _GlobalCAPAtbl.Rows[i]["Escalation"].ToString();
                                drCAPA["Elements"] = _GlobalCAPAtbl.Rows[i]["Element"].ToString();
                                drCAPA["UserName"] = GlobalDeclaration._holdInfo[0].UserName;
                                drCAPA["UserId"] = GlobalDeclaration._holdInfo[0].UserId;
                                drCAPA["EmpCode"] = GlobalDeclaration._holdInfo[0].EmpCode;
                                GlobalDeclaration.CAPAtbl.Rows.Add(drCAPA);
                            }
                        }
                    }
                    else
                    {
                        _IsDataStatus = false;
                    }
                }
                else
                {
                    _IsDataStatus = true;


                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return _IsDataStatus;
        }
        private void SelectTable()
        {
            var tablename = sheetCombo.SelectedItem.ToString();

            //dgventry.AutoGenerateColumns = true;
            //dgventry.DataSource = ds; // dataset
            //dgventry.DataMember = tablename;

            GetValues(ds, tablename);
        }
        List<string> _SheetName = new List<string>();
        int SerialNumber = 1;
        public void GetValues(DataSet dataset, string sheetName)
        {
            try
            {
                if (GlobalDeclaration.UserType.Equals("U1-Maintenance") || GlobalDeclaration.UserType.Equals("U1-Safety") || GlobalDeclaration.UserType.Equals("U1-Operation")) return;
                if (!string.IsNullOrEmpty(this.txttagno.Text))
                {
                    if (!_SheetName.Contains(sheetName))
                    {
                        int uu = dataset.Tables[sheetName].Rows.Count;
                        if (DgvMaitenance.Columns.Count > 0)
                        {
                            _NewRowAdd = true;
                            DgvMaitenance.Columns["Mdate"].ReadOnly = true;
                            DgvMaitenance.Columns["MachineTag"].ReadOnly = true;
                            for (int i = 0; i < dataset.Tables[sheetName].Rows.Count; i++)
                            {
                                DataRow row = dataset.Tables[sheetName].Rows[i];
                                DataGridViewRow dr = new DataGridViewRow();
                                DgvMaitenance.Rows.Add(dr);
                                int Indexm = DgvMaitenance.Rows.Count - 1;
                                DgvMaitenance.Rows[Indexm].Cells["SrNo"].Value = SerialNumber++;
                                DgvMaitenance.Rows[Indexm].Cells["Activity"].Value = row["Activity Detail"].ToString();
                                DgvMaitenance.Rows[Indexm].Cells["Frequency"].Value = row["Frequency"].ToString();
                                DgvMaitenance.Rows[Indexm].Cells["outsorce"].Value = row["Outsourced/Inhouse"].ToString();
                                DgvMaitenance.Rows[Indexm].Cells["ShtdwnReq"].Value = row["Shut Down Required"].ToString();
                                DgvMaitenance.Rows[Indexm].Cells["Mshedule"].Value = row["Maintenance Scheduled InWeek"].ToString();
                                DgvMaitenance.Rows[Indexm].Cells["Mdate"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                                DgvMaitenance.Rows[Indexm].Cells["Status"].Value = "New";
                                DgvMaitenance.Rows[Indexm].Cells["MachineTag"].Value = txttagno.Text;
                            }
                            //Datechange();
                            //DgvMaitenance.CellFormatting += Dgventry_CellFormatting;
                        }
                        _SheetName.Add(sheetName);
                    }
                    else
                    {
                        XtraMessageBox.Show(new Form { TopMost = true }, "Can't Upload Same Sheet Data, Plese try Another?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true }, "Please Fill MachineTag First. In Function Tab?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DgvMaitenance_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion


        #region Method Collection
        private void UpdateLogData()
        {
            LogDatacs _logdata = new LogDatacs(txttagno.Text, this.MachineName, this.SysGenMachineNo, this.cmblocation.SelectedItem.ToString());
            _logdata.TopMost = true;
            _logdata.ShowDialog();
        }
        private void UpdateDoDntsFrmData()
        {
            SafetyDontsFrm _safetyDontsFrm = new SafetyDontsFrm();
            _safetyDontsFrm.TopMost = true;
            _safetyDontsFrm.Show();
        }
        private void SafetyCheckList()
        {
            SafetyChecklist safetyChecklist = new SafetyChecklist(this.cmblocation.SelectedItem.ToString());//One
            safetyChecklist.TopMost = true;
            safetyChecklist.Show();
        }
        private void UpdateJRAfrmValue()
        {
            JSAInput _JSAInput = new JSAInput(this.txttagno.Text, this.cmblocation.SelectedItem.ToString());
            _JSAInput.TopMost = true;
            _JSAInput.Show();

        }
        private void UpdateSOPData()
        {
            ListSOP _ListSOP = new ListSOP();
            _ListSOP.TopMost = true;
            _ListSOP.Show();
        }
        /// <summary>
        /// Fill Record In CAPA Table
        /// </summary>


        private int value(string rslt)
        {
            int rsltvalue = 0;
            if (rslt.Equals("Ok"))
            {
                rsltvalue = 1;
            }
            return rsltvalue;
        }
        #endregion

        //#region "Standard Tab event"

        //private void bindStandardDBGrid()
        //{
        //    //DataTable invntry = new DataTable();
        //    //############## Add Column #################
        //    //addStandard.Columns.Add("Category/Vertical");
        //    //addStandard.Columns.Add("Selection and Design");
        //    //addStandard.Columns.Add("Operation");
        //    //addStandard.Columns.Add("Maintenance");
        //    //addStandard.Columns.Add("EHS");

        //    //############ end  add of column ################
        //    addStandard = Resources.Instance.GetStandardUsedMasterData(0, 1);
        //    DbStandardGrid.DataSource = addStandard;
        //    DbStandardGrid.Columns["standard_id"].Visible = false;
        //    DataGridViewTextBoxColumn colothers = new DataGridViewTextBoxColumn();
        //    colothers.HeaderText = "Add";
        //    colothers.CellTemplate.Value = "ADD";
        //    colothers.Name = "Add";
        //    colcount = addStandard.Columns.Count;
        //    //  bcol.UseColumnTextForButtonValue = true;
        //    //if (DbStandardGrid.Rows.Count > 0)
        //    //{
        //    //    bcol.UseColumnTextForButtonValue = true;
        //    DbStandardGrid.Columns.Insert(colcount, colothers);
        //    //}

        //    int rowsval = addStandard.Rows.Count - 1;
        //    int standardval = Convert.ToInt32(addStandard.Rows[rowsval][0]);
        //    DataTable dataTable = (DataTable)DbStandardGrid.DataSource;
        //    DataRow drToAdd = dataTable.NewRow();
        //    drToAdd["Standard_id"] = standardval;
        //    drToAdd["category/vertical"] = "Add";
        //    drToAdd["Selection and Design"] = "";
        //    drToAdd["Operation"] = "";
        //    drToAdd["maintenance"] = "";
        //    drToAdd["EHS"] = "";

        //    dataTable.Rows.Add(drToAdd);
        //    dataTable.AcceptChanges();
        //    DbStandardGrid.Rows[incRowindex].ReadOnly = true;
        //    countcoldb = Resources.Instance.CountStandardColumns("tbl_StandardUsedMaster", "dbo", "Plant360DB_dev");
        //    DbStandardGrid.Columns[countcoldb].ReadOnly = true;
        //    DbStandardGrid.AllowUserToAddRows = false;

        //}



        //private void DbStandardGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    DataGridViewColumn newColumn = DbStandardGrid.Columns[e.ColumnIndex];
        //    string reversecolname = "";
        //    if (e.ColumnIndex == colcount || e.ColumnIndex == colcount + 1)
        //    {
        //        AddnewColumn addnew = new AddnewColumn();

        //        addnew.Show();
        //        this.Activate();
        //        addnew.TopMost = true;
        //        string colmnname = AddnewColumn.columnName;
        //        if (colmnname != null)
        //        {
        //            DataGridViewTextBoxColumn txbt = new DataGridViewTextBoxColumn();
        //            DataGridViewTextBoxColumn txboldCol = new DataGridViewTextBoxColumn();
        //            // DataGridViewTextBoxCell t1bxt = new DataGridViewTextBoxCell();
        //            //   t1bxt.Selected = true;
        //            txbt.Name = "newColumn";
        //            txbt.CellTemplate.Value = string.Empty;


        //            txboldCol.Name = "newColumn";
        //            txboldCol.CellTemplate.Value = string.Empty;
        //            txboldCol.HeaderText = "Add";
        //            // DbStandardGrid.Columns.Add(t1bxt);
        //            txbt.HeaderText = colmnname;
        //            initialColName = DbStandardGrid.Columns[e.ColumnIndex].HeaderText;
        //            newColName = colmnname;
        //            reversecolname = initialColName;
        //            initialColName = newColName;
        //            newColName = reversecolname;
        //            DbStandardGrid.Columns.RemoveAt(e.ColumnIndex);
        //            DbStandardGrid.Columns.Insert(e.ColumnIndex, txbt);
        //            DbStandardGrid.Columns.Insert(e.ColumnIndex + 1, txboldCol);

        //            // DbStandardGrid.Columns.Insert(e.ColumnIndex + 1, initialColName);
        //            txbt.HeaderText = newColName;
        //            // DbStandardGrid.Columns.Add(txbt);
        //            DbStandardGrid.Columns[incColindex].ReadOnly = true;
        //            int upcolstatus = Resources.Instance.AlterTableStandardMaster("tbl_StandardUsedMaster", initialColName);
        //            countcoldb = Resources.Instance.CountStandardColumns("tbl_StandardUsedMaster", "dbo", "Plant360DB_dev");
        //            if (upcolstatus >= 0)
        //            {
        //                MessageBox.Show("New column added", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                DbStandardGrid.Columns[e.ColumnIndex].HeaderText = initialColName;
        //                incColindex = countcoldb + 1;
        //            }
        //        }

        //        // _isColumnTextAdded = true;
        //    }
        //}

        //private void DbStandardGrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    DataGridViewRow newColumn = DbStandardGrid.Rows[e.RowIndex];
        //    string reverserowname = "";
        //    //string reversecolname = "";
        //    if (e.RowIndex == incRowindex)
        //    {
        //        AddnewColumn addnew = new AddnewColumn();
        //        addnew.Show();
        //        this.Activate();
        //        addnew.TopMost = true;
        //        string colmnname = AddnewColumn.columnName;
        //        if (colmnname != null)
        //        {
        //            int rowsval = addStandard.Rows.Count - 1;
        //            int standardval = Convert.ToInt32(addStandard.Rows[rowsval][0]);
        //            DataTable dataTable = (DataTable)DbStandardGrid.DataSource;
        //            DataRow drToAdd = dataTable.NewRow();
        //            drToAdd["Standard_id"] = standardval;
        //            drToAdd["category/vertical"] = colmnname;
        //            drToAdd["Selection and Design"] = "";
        //            drToAdd["Operation"] = "";
        //            drToAdd["maintenance"] = "";
        //            drToAdd["EHS"] = "";


        //            initialColName = DbStandardGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
        //            newColName = colmnname;
        //            reverserowname = initialColName;
        //            initialColName = newColName;
        //            newColName = reverserowname;
        //            DbStandardGrid.Rows[e.RowIndex].Cells[1].Value = reverserowname;
        //            dataTable.Rows.InsertAt(drToAdd, rowsval);
        //            // dataTable.Rows.InsertAt(drToAdd, rowsval+1);
        //            dataTable.AcceptChanges();


        //            //newRow.Table.Rows[incRowindex][1] = colmnname;
        //            //DbStandardGrid.Rows[incRowindex].Cells[1].Value= initialColName;
        //            //DbStandardGrid.Rows.Add(newRow);
        //            incRowindex = e.RowIndex + 1;
        //        }
        //        // _isColumnTextAdded = true;
        //    }
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    //DataTable dataTable = (DataTable)DbStandardGrid.DataSource;
        //    //// DataTable newdata = new DataTable();
        //    ////dataTable.Columns.RemoveAt(1);
        //    ////dataTable.Columns.RemoveAt(0);
        //    //dataTable.Rows.RemoveAt(DbStandardGrid.Rows.Count - 1);
        //    //MessageBox.Show("Record Added Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}

        //#endregion


        #region "KeyComponentReader Arvind"


        #endregion

        #region "Specification Tab Event"
        private void tabindexvalchanged(int currentTab)
        {
            try
            {
                ReUsabaleAction(currentTab);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool reloaded = false;


        private void RemoveTabPages()
        {

            bool foundTab = false;
            for (int match = 0; match < SpecificationPages.TabCount; match++)
            {
                for (int m = 0; m < matchedArr.Count; m++)
                {
                    string tabText = SpecificationPages.TabPages[match].Text;
                    if (matchedArr[m].Trim() == tabText.Trim())
                    {
                        foundTab = true;
                        break;
                        //notFound = false;
                    }
                    else
                    {
                        // notFound = true;
                        foundTab = false;
                    }
                }

                if (foundTab == false)
                {
                    SpecificationPages.TabPages.RemoveAt(match);
                }
            }
        }
        private void ReUsabaleAction(int tabIndex)
        {

            try
            {
                //tabIndex = SpecificationPages.SelectedIndex;
                if (SpecificationPages.SelectedTab.Tag == null) return;

                string machineData = GlobalDeclaration.ReturnPath() + @"\" + "Application_Machines" + @"\" + this.Text.Trim() + "_" + SpecificationPages.SelectedTab.Tag.ToString() + ".xml";
                if (File.Exists(machineData))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(machineData);
                    // dbview .DataSource = ds.Tables[0];
                    isExists = true;
                    dbview.Enabled = true;
                    dbview.Visible = true;
                    //dbview.AllowCustomTheming = true;
                    this.dbview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
                    this.dbview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;

                    this.dbview.ColumnHeadersHeight = 40;
                    //this.dbview.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
                    //this.dbview.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
                    //this.dbview.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
                    //this.dbview.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
                    //this.dbview.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
                    //this.dbview.CurrentTheme.BackColor = System.Drawing.Color.White;
                    //this.dbview.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
                    //this.dbview.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
                    //this.dbview.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //this.dbview.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
                    //this.dbview.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
                    //this.dbview.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
                    //this.dbview.CurrentTheme.Name = null;
                    //this.dbview.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
                    //this.dbview.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
                    //this.dbview.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
                    //this.dbview.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
                    //this.dbview.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
                    //this.dbview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    //this.dbview.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    dbview.Width = 1250;
                    dbview.Height = 760;

                    DBGridView.Visible = false;
                    tabset1.Clear();
                    tabset1.Columns.Clear();
                    tabset.Clear();
                    tabset.Columns.Clear();
                    tabset = XMLToDataTable(machineData);
                    DTHeader();
                    if (tabset != null)
                    {
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
                            newDr[12] = tabset.Rows[i][12];
                            tabset1.Rows.Add(newDr);
                        }
                    }
                    dbview.DataSource = tabset1;
                    SpecificationPages.SelectedTab.Controls.Add(dbview);
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

                    btnsavespecs.Enabled = true;
                    DBGridView.Enabled = true;
                    DBGridView.Visible = true;
                    currentTab = currentTab + 1;
                    if (tabset.Rows.Count > 0)
                    {
                        tabset.Rows.Clear();
                        tabset.Columns.Clear();
                    }
                    //var dataRow = mytable.AsEnumerable().Where(r => r.Field<int>("Header Id") == currentTab);
                    //mytable.AsEnumerable().Contains()
                    //DataTable dt = dataRow.CopyToDataTable<DataRow>();
                    //tabIndex = tabIndex + 1;
                    if (mytable.AsEnumerable().Where(r => r.Field<int>("Header Id") == tabIndex).ToList().Count > 0)
                    {
                        tabset = mytable.AsEnumerable().Where(r => r.Field<int>("Header Id") == tabIndex).CopyToDataTable();
                        int rowindex = 0;
                        foreach (DataRow rows in tabset.Rows)
                        {
                            string paramname = rows.Field<string>("Parameter Name");
                            string objectype = rows.Field<string>("Unit");
                            string paramtag1 = rows.Field<string>("Param Tag");
                            tabset.Rows[rowindex][1] = paramname.ToString() + " " + paramtag1;
                            DBGridView.AutoGenerateColumns = true;
                            DBGridView.AllowUserToAddRows = false;
                            DBGridView.Columns.Clear();
                            DBGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                            rowindex = rowindex + 1;
                        }

                        //if (currentTab != 1)
                        //{
                        //    tabset.Rows.RemoveAt(0);
                        //}
                        DBGridView.DataSource = tabset;
                        if (tabset.Rows.Count > 1)
                        {
                            if (DBGridView.Rows.Count > 0)
                            {
                                DBGridView.Columns["Data Tag"].Visible = false;
                                DBGridView.Columns["Param Tag"].Visible = false;
                                DBGridView.Columns["Header Id"].Visible = false;
                                DBGridView.Columns["Control Type"].Visible = false;
                                DBGridView.Columns["Rfq"].Visible = false;
                                DBGridView.Columns["MachineName"].Visible = false;
                                columnsAsReadOnly();
                                SpecificationPages.SelectedTab.Controls.Add(this.DBGridView);
                                getcontroltype();
                                addrows();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No Record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                #endregion
                //All XML Document Content
                //XmlElement root = xDoc.DocumentElement;
                string RootNode = xDoc.DocumentElement.Name;
                string RootChildNode = string.Empty;
                if (xDoc.DocumentElement.LastChild != null)
                {
                    RootChildNode = xDoc.DocumentElement.LastChild.Name;
                }
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
                DBGridView.Columns.Insert(9, dgvCmb);
                DBGridView.Columns.Insert(10, dgisavail);
                DBGridView.Columns.Insert(11, dgisapplcbl);
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
                DBGridView.Columns[i].ReadOnly = true;
            }
        }

        private void getcontroltype()
        {
            try
            {
                for (int s = 0; s < DBGridView.RowCount; s++)
                {
                    var controltype = DBGridView.Rows[s].Cells[10].Value;
                    // string typeofcontrol = tabset.Tables[0].Rows[i].Field<string>("control_type");
                    switch (controltype)
                    {
                        case "cmbbox":
                            {
                                cmbunit.Value = "TypeOfControl";
                                char[] splitterbox = new char[] { '/' };
                                if (DBGridView.Rows[s].Cells[1].Value.ToString() != "")
                                {
                                    string tagvalue = DBGridView.Rows[s].Cells[8].Value.ToString();
                                    dataunit = tagvalue.Split(splitterbox);

                                    //  dataUnit.Add(dataunit[0]);
                                }
                                else
                                {
                                    cmbunit.Items.Add("");
                                }
                                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                                DBGridView.Rows[s].Cells[5].Value = "";
                                DBGridView[5, s] = comboCell;
                                comboCell.Items.Add("");
                                comboCell.Items.AddRange(dataunit);
                                comboCell.Items.Add("AddNew");
                                // comboCell.ReadOnly=true;
                                //  DBGridView.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(DBGridView_EditingControlShowing);
                                //  dbview.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dbview_DataGridViewEditingControlShowingEventHandler);
                                //  DBGridView.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dbview_DataGridViewEditingControlShowingEventHandler);
                                //    DBGridView.CellValueChanged += new DataGridViewCellEventHandler(DBGridView_CellValueChanged_1);
                                //  DBGridView.CurrentCellDirtyStateChanged += new EventHandler(DBGridView_CurrentCellDirtyStateChanged_1);

                                parametername = DBGridView[1, s].Value.ToString();
                                // string[] combined = dataunit.Concat(dataunit1).ToArray();
                                // comboCell.Items.AddRange(combined);
                                break;
                            }
                        case "checkbox":
                            {
                                // cmbunit.Value = "TypeOfcheck";
                                DataGridViewCheckBoxCell chkboxcell = new DataGridViewCheckBoxCell();
                                // chkboxcell.Selected = true;
                                DBGridView[2, s] = chkboxcell;
                                chkboxcell.Value = false;
                                DBGridView.DefaultCellStyle.DataSourceNullValue = 0;
                                //dataGridView1.CellMouseClick += new DataGridViewCellEventHandler(dataGridView1_CheckBoxCheckChange);
                                //dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
                                break;
                            }

                        case "staticdata":
                            {
                                this.DBGridView.Rows[s].ReadOnly = true;
                                this.DBGridView.Rows[s].Cells[4].Value = string.Empty;
                                using (Font font = new Font(DBGridView.DefaultCellStyle.Font.FontFamily, 9, FontStyle.Bold))
                                {
                                    DBGridView.Rows[s].Cells["Parameter Name"].Style.Font = font;
                                }
                                break;
                            }

                        case "staticdata1":
                            {

                                this.DBGridView.Rows[s].ReadOnly = true;
                                this.DBGridView.Rows[s].Cells[4].Value = string.Empty;
                                using (Font font = new Font(DBGridView.DefaultCellStyle.Font.FontFamily, 9, FontStyle.Bold))
                                {
                                    DBGridView.Rows[s].Cells["Parameter Name"].Style.Font = font;
                                }
                                break;
                                // break;
                            }

                        case "multiunit":
                            {
                                parametername = DBGridView[1, s].Value.ToString();
                                string datatag = DBGridView[1, s].Value.ToString();
                                //DBGridView.Rows[s].Cells[0].Value = parametername + " " + datatag;
                                cmbunit.Value = "typemultiunit";
                                char[] splitterbox = new char[] { '/' };
                                string[] splitterbox1 = new string[] { "OR" };
                                if (DBGridView.Rows[s].Cells[2].Value.ToString() == "-")
                                {
                                    string tagvalue = DBGridView.Rows[s].Cells[2].Value.ToString();
                                    dataunit = tagvalue.Split(splitterbox);
                                }
                                else
                                {
                                    string tagvalue = DBGridView.Rows[s].Cells[2].Value.ToString();
                                    dataunit = tagvalue.Split(splitterbox1, StringSplitOptions.None);
                                }
                                DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                                // dataGridView1.Rows[s].Cells[3].Value = "";
                                this.DBGridView.Rows[s].Cells[2].Value = string.Empty;
                                DBGridView[2, s] = comboCell;
                                comboCell.Items.Add("");
                                comboCell.Items.AddRange(dataunit);
                                break;
                            }

                        case "description":
                            {
                                DataGridViewTextBoxCell txtbxcl = new DataGridViewTextBoxCell();
                                txtbxcl.Value = "";
                                DBGridView.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                                DBGridView.AutoResizeRow(s, DataGridViewAutoSizeRowMode.AllCellsExceptHeader);
                                DBGridView.AutoResizeColumn(4);
                                this.DBGridView.Rows[s].Cells[4].Value = string.Empty;
                                break;
                            }

                        case "multiinput":
                            {
                                DataGridViewTextBoxCell txtbxcl1 = new DataGridViewTextBoxCell();
                                DBGridView.Columns[5].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                                this.DBGridView.Rows[s].Cells[5].Value = string.Empty;
                                break;
                            }

                        case "-":
                            {
                                this.DBGridView.Rows[s].Cells[5].Value = DBGridView.Rows[s].Cells[3].Value.ToString();
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
        //private void DBGridView_ComboBoxIndexChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (e.ColumnIndex == 5 && e.RowIndex >= 0)
        //        {
        //            string objval = "AddNew";
        //            string ComboText = DBGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        //            if (ComboText.Trim() == objval.Trim())
        //            {
        //                int rowno = e.RowIndex;
        //                // dataUnit.Add(tabset.Rows[rowno][8].ToString());
        //                dataUnit.AddRange(dataunit);
        //                //  AddNewGenericUnit mainlyt = new AddNewGenericUnit(tabset, parametername, dataUnit, param_id);
        //                //  mainlyt.updateComboUnit += GetSpecificationUnitEvent;
        //                //  mainlyt.Show();
        //            }
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //}
        //private void dbview_ComboBoxIndexChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        string objval = "AddNew";
        //        string ComboText = DBGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        //        if (ComboText.Trim() == objval.Trim())
        //        {
        //            int rowno = e.RowIndex;
        //            dataUnit.Add(tabset.Rows[rowno][8].ToString());
        //            //  AddNewGenericUnit mainlyt = new AddNewGenericUnit(tabset, parametername, dataUnit, param_id);
        //            //  mainlyt.TopMost = true;
        //            //   mainlyt.Show();
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //}



        #region "Environment Tab"
        private void btnAddEnv_Click_1(object sender, EventArgs e)
        {
            try
            {
                string tagno = txtmachinetagenv.Text;
                //  bool istrue = false;
                if (txtmachinetagenv.Text == "")
                {
                    MessageBox.Show("Enter Machine Tag No.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // istrue = true;
                }
                if (tagno != "" && btnAddEnv.Text == "Add")
                {
                    int cntval = Resources.Instance.AddHealthEnvironment(txtsuplChem.Text, txtcleaningchem.Text, txtcleaningmat.Text, cmbEmission.Text, cmbDischarge.Text, cmbwaste.Text, tagno, 0, 1);
                    addEnvironment.Clear();
                    addEnvironment.Columns.Clear();
                    addEnvironment.Rows.Clear();
                    MessageBox.Show("Record Saved Succesfully");
                    bindGridCol();

                }
                else if (btnAddEnv.Text == "Update")
                {
                    healthenvid = Convert.ToInt32(getdata.Rows[rowindex][7]);
                    insVal = Resources.Instance.AddHealthEnvironment(txtsuplChem.Text, txtcleaningchem.Text, txtcleaningmat.Text, cmbEmission.Text, cmbDischarge.Text, cmbwaste.Text, tagno, healthenvid, 2);
                    if (insVal > 0)
                    {
                        MessageBox.Show("Record Updated Succesfully");
                    }

                    if (insVal > 0)
                    {
                        DataTable getdata = new DataTable();
                        getdata = Resources.Instance.getHealthEnvironmentData("", 1);
                        datagridHealthEnviron.DataSource = getdata;
                        ////if (btnEnvironment.Text == "Update")
                        ////{
                        ////    datagridHealthEnviron.Columns["healthEnvId"].Visible = false;
                        ////}
                    }
                    else
                    {
                        MessageBox.Show("Oops something went Wrong..!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void bindGridCol()
        {
            try
            {
                //DataTable invntry = new DataTable();
                //############## Add Column #################
                addEnvironment.Columns.Clear();
                addEnvironment.Columns.Add("Supplement Chemicals");
                addEnvironment.Columns.Add("Cleaning Chemicals");
                addEnvironment.Columns.Add("Clean Materials");
                addEnvironment.Columns.Add("Emission");
                addEnvironment.Columns.Add("Discharge");
                addEnvironment.Columns.Add("Waste Generation");
                addEnvironment.Columns.Add("MachineTagNo");

                //############ end  add of column ################
                if ((GlobalDeclaration.UserType.Equals("U1-Maintenance")) || (GlobalDeclaration.UserType.Equals("U1-Safety")) || (GlobalDeclaration.UserType.Equals("U1Operation")))
                {
                    addEnvironment = Resources.Instance.getHealthEnvironmentData("", 1);
                }
                else
                {
                    addEnvironment = Resources.Instance.getHealthEnvironmentData(txttagno.Text, 2);
                }

                datagridHealthEnviron.DataSource = addEnvironment;
                datagridHealthEnviron.Columns["health_EnvId"].Visible = false;
                //datagridHealthEnviron.Columns["MachineTagNo"].HeaderText= "Machine Tag No.";
                datagridHealthEnviron.AllowUserToAddRows = false;

                if (txttagno.Text != "")
                {
                    txtmachinetagenv.Text = txttagno.Text;

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
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

        //private void HideColumns()
        //{
        //    dbview.Columns["ParameterId"].Visible = false;
        //    dbview.Columns["Unit1"].Visible = false;
        //    dbview.Columns["param_tag"].Visible = false;
        //    dbview.Columns["data_tag"].Visible = false;
        //    dbview.Columns["header_id"].Visible = false;
        //    //DBGridView.Columns[""].Visible = false;
        //    //DBGridView.Columns[""].Visible = false;
        //}

        DataTable tabset1 = new DataTable();
        DataGridView dbview = new DataGridView();
        //dbview.AllowCustomTheming = true;
        //DataGridView dbview = new DataGridView();

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

        DataTable Dtcopy = null;
        DataTable Dtcopy1 = null;
        private void CopyDataToDTXML()
        {
            Dtcopy = new DataTable();
            Dtcopy1 = new DataTable();
            Dtcopy.Columns.Add("MachineName");
            Dtcopy.Columns.Add("IsCopied");

            Dtcopy1.Columns.Add("MachineName");
            Dtcopy1.Columns.Add("IsCopied");
            DataRow DrRow = Dtcopy.NewRow();
            DrRow[0] = this.Text.Trim();
            DrRow[1] = 1;
            Dtcopy.Rows.Add(DrRow);
            DataSet DsCopy = new DataSet();
            DsCopy.Tables.Add(Dtcopy);
            if (File.Exists(Application.StartupPath + @"\" + "Application_Machines" + @"\" + "CopyData" + ".xml"))
            {
                DsCopy.ReadXml(Application.StartupPath + @"\" + "Application_Machines" + @"\" + "CopyData" + ".xml");
            }
            DsCopy.WriteXml(Application.StartupPath + @"\" + "Application_Machines" + @"\" + "CopyData" + ".xml");
            DsCopy.Tables.Remove(Dtcopy);
        }


        //private void dbview_DataGridViewEditingControlShowingEventHandler(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    try
        //    {
        //        System.Windows.Forms.ComboBox combo = e.Control as System.Windows.Forms.ComboBox;
        //        if (combo != null)
        //        {
        //            //  combo.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
        //            // combo.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //}

        //private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string objval = "AddNew";
        //    string ComboText = DBGridView.CurrentCell.EditedFormattedValue.ToString();
        //    if (ComboText.Trim() == objval.Trim())
        //    {
        //        int rowno = DBGridView.CurrentCell.RowIndex;
        //        dataUnit.Add(tabset.Rows[rowno][8].ToString());
        //        // AddNewGenericUnit mainlyt = new AddNewGenericUnit(tabset, parametername, dataUnit, param_id);
        //        // mainlyt.TopMost = true;
        //        // mainlyt.Show();
        //    }
        //}

        //void DBGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        //{
        //    if (DBGridView.IsCurrentCellDirty)
        //    {
        //        // This fires the cell value changed handler below
        //        DBGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
        //    }
        //}

        //private void DBGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    // My combobox column is the second one so I hard coded a 1, flavor to taste
        //    DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)DBGridView.Rows[e.RowIndex].Cells[1];
        //    if (cb.Value != null)
        //    {
        //        // do stuff
        //        //   dataGridView1.Invalidate();
        //    }
        //}

        #endregion

        #region Load All Tab Data
        private void LoadFunctionEleMentData()
        {
            try
            {
                string tabval = MCDpages.SelectedTab.Tag.ToString();
                if (tabval == "FuntionTb")
                {
                    if (txttagno.Text == string.Empty)
                    {
                        DataTable dt = null;                       
                        if (GlobalDeclaration.UserType.Equals("U1-Maintenance") || GlobalDeclaration.UserType.Equals("U1-Safety") || GlobalDeclaration.UserType.Equals("U1-Operation"))
                        {
                            dt = Resources.Instance.GetDataKey("Sp_FetchFunTabData", "p_SysGenName", "p_MCordinate", "p_machinename", "p_userName", "p_userId", "p_empCode", this.SysGenMachineNo, this.cmblocation.SelectedItem.ToString(), this.ConnectionMachineName.Replace('~', '_'), "", 0, "");
                        }
                        else
                        {
                            dt = Resources.Instance.GetDataKey("Sp_FetchFunTabData", "p_SysGenName", "p_MCordinate", "p_machinename", "p_userName", "p_userId", "p_empCode", this.SysGenMachineNo, this.cmblocation.SelectedItem.ToString(), this.ConnectionMachineName.Replace('~', '_'), GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].UserId, GlobalDeclaration._holdInfo[0].EmpCode);
                        }
                        if (dt.Rows.Count > 0)
                        {
                            txttagno.Text = dt.Rows[0]["TagNao"].ToString();
                            cmblayer.SelectedItem = dt.Rows[0]["Layer"].ToString();
                            cmblayer.ListBackColor = Color.White;
                            cmblayer.ListTextColor = Color.Black;
                            cmbStatus.SelectedItem = dt.Rows[0]["Status"].ToString();
                            cmblocation.SelectedItem = dt.Rows[0]["location"].ToString();
                            CmbPriceUnit.SelectedItem = dt.Rows[0]["PriceUnit"].ToString();
                            txtlocationmanual.Text = dt.Rows[0]["MachineLocation"].ToString();
                            datepickInstallation.Value = Convert.ToDateTime(dt.Rows[0]["DateOfInst"].ToString());
                            datepckYear.Value = Convert.ToDateTime(dt.Rows[0]["DatePurchase"].ToString());
                            txtlifetime.Text = dt.Rows[0]["ExpLifeTime"].ToString().Split('-')[0];
                            CmbLifeTimeUnit.SelectedItem = dt.Rows[0]["ExpLifeTime"].ToString().Split('-')[1];
                            txtprice.Text = dt.Rows[0]["PurchasePrice"].ToString();

                            if(int.Parse((dt.Rows[0]["IsMultifloor"]).ToString())==1)
                            {
                                IsMultiCheckExist = true;                             
                            }
                            else
                            {
                                IsMultiCheckExist = false;
                            }                          
                            if (GlobalDeclaration.UserType.Equals("Admin") || GlobalDeclaration.UserType.Equals("U0-User"))
                            {
                                ////txttagno.ReadOnly = false;
                                ////txtlocationmanual.ReadOnly = false;
                                ////txtlifetime.ReadOnly = false;
                                ////txtprice.ReadOnly = false;
                                datepckYear.Enabled = false;
                                CmbLifeTimeUnit.Enabled = false;
                                CmbPriceUnit.Enabled = false;
                                datepickInstallation.Enabled = false;
                            }
                            else
                            {
                                ////txttagno.ReadOnly = true;
                                ////txtlocationmanual.ReadOnly = true;
                                ////txtlifetime.ReadOnly = true;
                                ////txtprice.ReadOnly = true;
                                datepckYear.Enabled = false;
                                CmbLifeTimeUnit.Enabled = false;
                                CmbPriceUnit.Enabled = false;
                                datepickInstallation.Enabled = false;
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadKeyCompentMachineLoad()
        {
            try
            {
                // if (this.ReceiveConValue == null) return;
                if (this.dgvmachine.Rows.Count > 0) return;
                // if (this.ReceiveConValue.Count > 0)//&& !string.IsNullOrEmpty(this.MachineName)
                {
                    foreach (KeyValuePair<string, Connector> item in this._listconnt)
                    {
                        string KeyKey = item.Key;
                        string MachineNumber = string.Empty;
                        //KeyKey = RemoveIntegers(KeyKey);
                        Connector sourceMachines = this._listconnt[KeyKey];
                        string Conntype = string.Empty;
                        if (sourceMachines.Connecto == this.ConnectionMachineName)
                        {
                            bool IExists = dgvmachine.Rows.Cast<DataGridViewRow>().Any(r => r.Cells["Machine"].Value.Equals(sourceMachines.FromData));
                            if (!IExists)
                            {
                                Conntype = "Input";
                                MachineNumber = GlobalDeclaration._MyTagDictinary.AsEnumerable().Where(X => X.Key == GlobalDeclaration.RerurnDpoint(sourceMachines.FromDPoint)).FirstOrDefault().Value;
                                DataGridViewRow rowadd = new DataGridViewRow();
                                dgvmachine.Rows.Insert(0, rowadd);
                                dgvmachine.Rows[0].Cells["Machine"].Value = sourceMachines.FromData.Split('~')[0];
                                dgvmachine.Rows[0].Cells["Machine"].ReadOnly = true;
                                dgvmachine.Rows[0].Cells["MachineNumber"].Value = MachineNumber;
                                dgvmachine.Rows[0].Cells["Type"].Value = RemoveIntegers(KeyKey);// change line for add integor number
                                dgvmachine.Rows[0].Cells["Location"].Value = sourceMachines.FromDPoint;
                                dgvmachine.Rows[0].Cells["Fillow"].Value = Conntype;
                                rowadd.ReadOnly = true;                               

                            }
                        }
                        else if (sourceMachines.FromData == this.ConnectionMachineName)
                        {
                            bool IExists = dgvmachine.Rows.Cast<DataGridViewRow>().Any(r => r.Cells["Machine"].Value.Equals(sourceMachines.Connecto));
                            if (!IExists)
                            {
                                Conntype = "Output";
                                MachineNumber = GlobalDeclaration._MyTagDictinary.AsEnumerable().Where(X => X.Key == GlobalDeclaration.RerurnDpoint(sourceMachines.ToDPoint)).FirstOrDefault().Value;
                                DataGridViewRow rowadd = new DataGridViewRow();
                                dgvmachine.Rows.Insert(0, rowadd);
                                dgvmachine.Rows[0].Cells["Machine"].Value = sourceMachines.Connecto.Split('~')[0]; //strct.Split('-')[1];
                                dgvmachine.Rows[0].Cells["Machine"].ReadOnly = true;
                                dgvmachine.Rows[0].Cells["MachineNumber"].Value = MachineNumber;
                                dgvmachine.Rows[0].Cells["Type"].Value = KeyKey;
                                dgvmachine.Rows[0].Cells["Location"].Value = sourceMachines.ToDPoint;
                                dgvmachine.Rows[0].Cells["Fillow"].Value = Conntype;
                                rowadd.ReadOnly = true;
                            }
                        }


                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string RemoveIntegers(string input)
        {
            return Regex.Replace(input, @"[\d-]", string.Empty);
        }
        #endregion

        #region Safety Key Delete Insertion Fetch

        private void LoadKeyCompoNente()
        {
            try
            {
                DataTable dt = null;
                if (listKeyComp.Items.Count > 0) return;
                if (GlobalDeclaration.UserType.Equals("U1-Maintenance") || GlobalDeclaration.UserType.Equals("U1-Safety") || GlobalDeclaration.UserType.Equals("U1-Operation"))
                {
                    dt = Resources.Instance.GetDataKey("Sp_FetchKeyComponentsMaster", "p_Mname", "p_MCordinate", "p_username", "p_userid", "p_empCode", this.MachineName, this.cmblocation.SelectedItem.ToString(), "", "0", "");
                }
                else
                {
                    dt = Resources.Instance.GetDataKey("Sp_FetchKeyComponentsMaster", "p_Mname", "p_MCordinate", "p_username", "p_userid", "p_empCode", this.MachineName, this.cmblocation.SelectedItem.ToString(), GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].UserId.ToString(), GlobalDeclaration._holdInfo[0].EmpCode);
                }

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        listKeyComp.Items.Add(dt.Rows[i]["ComponentsName"].ToString());
                    }
                }
                if (GlobalDeclaration.UserType.Equals("U1-Maintenance") || GlobalDeclaration.UserType.Equals("U1-Safety") || GlobalDeclaration.UserType.Equals("U1-Operation"))
                {
                    dt = Resources.Instance.GetDataKey("Sp_FetchSafetKeyComponentsMaster", "p_Mname", "p_MCordinate", "p_username", "p_userid", "p_empCode", this.MachineName, this.cmblocation.SelectedItem.ToString(), "", "0", "");
                }
                else
                {
                    dt = Resources.Instance.GetDataKey("Sp_FetchSafetKeyComponentsMaster", "p_Mname", "p_MCordinate", "p_username", "p_userid", "p_empCode", this.MachineName, this.cmblocation.SelectedItem.ToString(), GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].UserId.ToString(), GlobalDeclaration._holdInfo[0].EmpCode);
                }

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        listSafetyComp.Items.Add(dt.Rows[i]["SafetyComponentsName"].ToString());
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateSafetyKey()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("SafetyComponentsName", typeof(string));
                dt.Columns.Add("MachineName", typeof(string));
                dt.Columns.Add("MachineTag", typeof(string));
                dt.Columns.Add("UserName", typeof(string));
                dt.Columns.Add("UserId", typeof(int));
                dt.Columns.Add("MachineCordinate", typeof(string));
                dt.Columns.Add("EmpCode", typeof(string));

                DataRow dr = null;
                for (int i = 0; i < listSafetyComp.Items.Count; i++)
                {
                    dr = dt.NewRow();
                    string Name = listSafetyComp.Items[i].ToString();
                    dr["SafetyComponentsName"] = Name;
                    dr["MachineName"] = this.MachineName;
                    dr["MachineTag"] = txttagno.Text;
                    dr["UserName"] = GlobalDeclaration._holdInfo[0].UserName;
                    dr["UserId"] = GlobalDeclaration._holdInfo[0].UserId;
                    dr["MachineCordinate"] = cmblocation.SelectedItem.ToString();
                    dr["EmpCode"] = GlobalDeclaration._holdInfo[0].EmpCode;
                    dt.Rows.Add(dr);
                }
                int I = Resources.Instance.SaveMainTenenceData("Sp_SafetyKeyComponentsMaster", "p_SaftyKeyTBL", dt);
                dt.Clear();
                dt.Dispose();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btndeletekey_Click(object sender, EventArgs e)
        {
            try
            {
                if (listKeyComp.SelectedItem != null)
                {
                    if (GlobalDeclaration.UserType.Equals("U1-Maintenance") || GlobalDeclaration.UserType.Equals("U1-Safety")) return;

                    string InlineQuery = " delete from KeyComponentsMaster where ComponentsName='" + listKeyComp.SelectedItem.ToString() + "' and UserName='" + GlobalDeclaration._holdInfo[0].UserName + "' and UserId=" + GlobalDeclaration._holdInfo[0].UserId + " ";
                    int status = Resources.Instance.InlineDeleteQuery(InlineQuery);
                    listKeyComp.Items.Remove(listKeyComp.SelectedItem);
                    //btndeletekey.Visible = false;
                    //btndeletekey.Enabled = false;
                    if (status > 0)
                    {

                        XtraMessageBox.Show(new Form { TopMost = true }, "Key Deleted Successfully.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //-------------------------------------------------------------------------
        private void btnsafetyDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (listSafetyComp.SelectedItem != null)
                {
                    if (GlobalDeclaration.UserType.Equals("U1-Maintenance") || GlobalDeclaration.UserType.Equals("U1-Safety")) return;

                    string InlineQuery = " delete from SafetyKeyComponentsMaster where SafetyComponentsName='" + listSafetyComp.SelectedItem.ToString() + "'";
                    int status = Resources.Instance.InlineDeleteQuery(InlineQuery);
                    listSafetyComp.Items.Remove(listSafetyComp.SelectedItem);
                    //btnsafetyDelete.Visible = false;
                    //btnsafetyDelete.Enabled = false;
                    if (status > 0)
                    {
                        XtraMessageBox.Show(new Form { TopMost = true }, "Key Deleted Successfully.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void listKeyComp_SelectedValueChanged(object sender, EventArgs e)
        {
            // btndeletekey.Visible = true;
            //btndeletekey.Enabled = true;
        }

        private void listSafetyComp_SelectedValueChanged(object sender, EventArgs e)
        {
            //btnsafetyDelete.Visible = false;
            //btnsafetyDelete.Enabled = false;
        }
        #endregion

        private void btnsavespecs_Click_1(object sender, EventArgs e)
        {
            try
            {
                CopyToDataTable();
                DataSet machineDs = new DataSet();
                DataSet machinereload = new DataSet();
                machineDs.Tables.Clear();
                machineDs.Tables.Add(globalDt);
                string tabname = SpecificationPages.SelectedTab.Tag.ToString();
                string Path = GlobalDeclaration.ReturnPath() + @"\" + "Application_Machines";
                if (!Directory.Exists(Path))
                {
                    Directory.CreateDirectory(Path);
                }
                string nameoffile = this.Text.Trim() + "_" + tabname;
                machineDs.WriteXml(GlobalDeclaration.ReturnPath() + @"\" + "Application_Machines" + @"\" + nameoffile + ".xml");
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
                string machineData = GlobalDeclaration.ReturnPath() + @"\" + "Application_Machines" + @"\" + this.Text.Trim() + "_" + SpecificationPages.SelectedTab.Tag.ToString() + ".xml";
                if (!File.Exists(machineData))
                {
                    foreach (DataGridViewColumn column in DBGridView.Columns)
                    {
                        globalDt.Columns.Add(column.HeaderText, column.ValueType);
                    }
                    //globalDt.Columns.Remove("Header Id");
                    // globalDt.Columns.Add("headerName");
                    // globalDt.Columns.Remove("Rfq");
                    // globalDt.Columns.Remove("Param Tag");
                    // globalDt.Columns.Remove("Data Tag");
                    // DBGridView.Columns.Remove("Header Id");
                    // DBGridView.Columns.Remove("Rfq");
                    // DBGridView.Columns.Remove("Param Tag");
                    // DBGridView.Columns.Remove("Data Tag");
                    //   DBGridView.Columns.Remove("Rfq");
                    //Adding the Rows.
                    for (int i = 0; i < DBGridView.Rows.Count; i++)
                    {
                        globalDt.Rows.Add();
                        for (int j = 0; j < globalDt.Columns.Count; j++)
                        {
                            int bitval = 0;
                            var objType = DBGridView.Rows[i].Cells[j];
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
                                        globalDt.Rows[i][j] = DBGridView.Rows[i].Cells[j].Value.ToString().Trim();
                                    }
                                    else
                                    {
                                        bitval = 1;
                                        globalDt.Rows[i][j] = DBGridView.Rows[i].Cells[j].Value.ToString().Trim();
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
                                    string cell5 = DBGridView.Rows[i].Cells[5].Value.ToString();
                                    // string cell8= DBGridView.Rows[i].Cells[8].Value.ToString();

                                }
                                globalDt.Rows[i][j] = DBGridView.Rows[i].Cells[j].Value.ToString();
                                //}

                            }

                        }
                    }
                }

                if (File.Exists(machineData))
                {
                    foreach (DataGridViewColumn column in dbview.Columns)
                    {
                        globalDt.Columns.Add(column.HeaderText, column.ValueType);
                    }
                    for (int i = 0; i < dbview.Rows.Count; i++)
                    {
                        globalDt.Rows.Add();
                        for (int j = 0; j < globalDt.Columns.Count; j++)
                        {
                            int bitval = 0;
                            var objType = dbview.Rows[i].Cells[j];
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
                                        globalDt.Rows[i][j] = dbview.Rows[i].Cells[j].Value.ToString().Trim();
                                    }
                                    else
                                    {
                                        bitval = 1;
                                        globalDt.Rows[i][j] = dbview.Rows[i].Cells[j].Value.ToString().Trim();
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
                                    string cell5 = dbview.Rows[i].Cells[5].Value.ToString();
                                }
                                globalDt.Rows[i][j] = dbview.Rows[i].Cells[j].Value.ToString();
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        //private void cmboprator_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}
        //private void timer1_Tick(object sender, EventArgs e)
        //{

        //}


        //int rowIndex = 0;
        private void DBGridView_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
                string Value = DBGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (Value == "AddNew")
                {
                    rowindex = e.RowIndex;
                    // AddNewGenericUnit mainlyt = new AddNewGenericUnit(tabset, parametername, dataUnit, param_id);
                    // mainlyt.updateComboUnit += GetSpecificationUnitEvent;
                    // mainlyt.Show();
                }

            }
        }

        //private void DBGridView_CurrentCellDirtyStateChanged_1(object sender, EventArgs e)
        //{

        //}

        private void DBGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            string dbcell = DBGridView.CurrentCell.GetType().ToString();
            if (dbcell == "System.Windows.Forms.DataGridViewComboBoxCell")
            {
                if (e.ColumnIndex == 5 && e.RowIndex == rowindex)
                {
                    char[] splitterbox = new char[] { '/' };
                    string tagvalue = DBGridView.Rows[rowindex].Cells[8].Value.ToString();
                    dataunit1 = tagvalue.Split(splitterbox);
                    DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                    DBGridView.Rows[rowindex].Cells[5].Value = "";
                    DBGridView[5, rowindex] = comboCell;
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

        private void txttagno_TabIndexChanged(object sender, EventArgs e)
        {

            // No need to check because tag no set automatically

            ////int SearchTag = Resources.Instance.SearchMachineTag(txttagno.Text);
            ////if (SearchTag > 0)
            ////{
            ////    lblTagMsg.Visible = true;
            ////    lblTagMsg.Text = "Machine Code already taken";
            ////    lblTagMsg.ForeColor = Color.Red;
            ////    //timer1.Enabled = true;
            ////}
            ////else
            ////{
            ////    lblTagMsg.Visible = true;
            ////    lblTagMsg.Text = "Machine code available";
            ////    lblTagMsg.ForeColor = Color.Green;
            ////}
        }

        private void txttagno_Leave(object sender, EventArgs e)
        {
            // No need to check because tag no set automatically
            //int SearchTag = Resources.Instance.SearchMachineTag(txttagno.Text);
            //if (SearchTag > 0)
            //{
            //    lblTagMsg.Visible = true;
            //    lblTagMsg.Text = "Machine Code already taken";
            //    lblTagMsg.ForeColor = Color.Red;
            //    //timer1.Enabled = true;
            //}
            //else
            //{
            //    lblTagMsg.Visible = true;
            //    lblTagMsg.Text = "Machine code available";
            //    lblTagMsg.ForeColor = Color.Green;
            //}
        }

        private void btnCopyData_Click(object sender, EventArgs e)
        {
            try
            {
                CopyDataToDTXML();
                XtraMessageBox.Show(new Form { TopMost = true }, "Data Copied Successfully", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        List<string> filearrlist = new List<string>();
        private void btnupload_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Multiselect = true;
                var obd = openFileDialog1.ShowDialog();
                openFileDialog1.Title = "Please Select Files to upload. You can select multiple files";
                string fname = openFileDialog1.FileName;
                if ((obd != DialogResult.OK) || (string.IsNullOrEmpty(openFileDialog1.FileName)))
                {
                    return;
                }
                string gg = Path.GetExtension(fname);

                filesArr = openFileDialog1.FileNames;
                for (int m = 0; m < filesArr.Length; m++)
                {
                    string k = filesArr[m].ToString();
                    string[] fnlame = k.Split('\\');
                    filearrlist.Add(fnlame[fnlame.Length - 1]);
                }
                if (!string.IsNullOrEmpty(gg))
                {
                    lblExt.Text = gg;
                    lblUplDate.Text = DateTime.Now.ToString();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        List<string> columnList = new List<string>();
        private void btnUploadFiles_Click(object sender, EventArgs e)
        {
            try
            {
                if (txttagno.Text != "")
                {
                    string desiredPath = Application.StartupPath + @"\MCD_FileUploads" + @"\" + txttagno.Text;
                    string path = desiredPath + @"\";
                    bool isuploadSxc = false;
                    if (Directory.Exists(desiredPath))
                    {

                    }
                    else
                    {
                        Directory.CreateDirectory(desiredPath);
                    }
                    for (int i = 0; i < filesArr.Length; i++)
                    {
                        if (File.Exists(path + filearrlist[i]))
                        {

                        }
                        else if (File.Exists(path + filesArr[i]))
                        {

                        }
                        else
                        {
                            File.Copy(filesArr[i], path + filearrlist[i]);
                            isuploadSxc = true;
                        }
                    }
                    if (isuploadSxc == true)
                    {
                        int insrt = Resources.Instance.AddUploadedMachineDocs(txttagno.Text, txtFileName.Text, lblExt.Text, lblareakm.Text, txtremark.Text, System.DateTime.Now, 1);
                        if (insrt > 0)
                        {
                            XtraMessageBox.Show(new Form { TopMost = true }, "File uploaded successfully", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dts = Resources.Instance.GetMachineUploadedDocs(txttagno.Text, "", "", "", "", System.DateTime.Now, 2);

                            DataTable dtFilesArr = new DataTable();
                            string[] AllfilesArr = Directory.GetFiles(desiredPath, "*", SearchOption.AllDirectories);
                            for (int i = 0; i < AllfilesArr.Length; i++)
                            {
                                dtFilesArr.Columns.Add("Files" + "_" + i);
                                dts.Columns.Add("Files" + "_" + (i + 1));
                            }
                            for (int z = 0; z < dts.Rows.Count; z++)
                            {
                                int m = 0;
                                for (int x = 7; x < dts.Columns.Count; x++)
                                {
                                    dts.Rows[0][x] = AllfilesArr[m];
                                    m = m + 1;
                                }

                            }
                            DBGridViewMAchineDocs.DataSource = dts;
                            DBGridViewMAchineDocs.Columns["RefId"].Visible = false;
                            int y = 0;
                            columnList.Add("");
                            columnList.Add("");
                            columnList.Add("");
                            columnList.Add("");
                            columnList.Add("");
                            columnList.Add("");
                            columnList.Add("");
                            for (int x = 7; x < dts.Columns.Count; x++)
                            {
                                DataGridViewButtonCell btnCol = new DataGridViewButtonCell();
                                btnCol.Value = "View";
                                DBGridViewMAchineDocs.Rows[0].Cells[x].Value = "";
                                DBGridViewMAchineDocs[x, 0] = btnCol;
                                DBGridViewMAchineDocs.Rows[0].Cells[x].Value = "View";
                                //  dts.Rows[0][x] = AllfilesArr[y];
                                columnList.Add(AllfilesArr[y]);
                                y = y + 1;
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show(new Form { TopMost = true }, "Oops something went wrong!", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(new Form { TopMost = true }, "Oops something went wrong!", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true }, "Machine Tag  required!", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DBGridViewMAchineDocs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex > 6)
                {
                    System.Diagnostics.Process.Start(columnList[e.ColumnIndex]);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        private void MachineEditDataUpd_Click(object sender, EventArgs e)
        {

        }

        private void SpecificationPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selTab = SpecificationPages.SelectedTab.Tag.ToString();
            int lindex = 0;
            if (selTab == "General")
            {
                currentTab = 0;
                lindex = 1;
            }
            if (selTab == "Process")// "Process Parameter")
            {
                currentTab = 1;
                lindex = 2;
            }
            if (selTab == "Mechanical")// "Mechanical / Electrical / Instrumentation Data")
            {
                currentTab = 2;
                lindex = 3;
            }
            if (selTab == "Nozzles")// "Nozzles And Connections Details/Schedule")
            {
                currentTab = 3;
                lindex = 4;
            }
            if (selTab == "Physical")
            {
                currentTab = 4;
                lindex = 5;
            }
            if (selTab == "Compliance")
            {
                currentTab = 5;
                lindex = 6;
            }

            if (selTab == "Design")
            {
                currentTab = 6;
                lindex = 7;
            }
            tabindexvalchanged(lindex);
        }

        //private void DgvMaitenance_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        //{

        //}

        private void txtMachineAutoSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {

                //dts.Clear();
                string[] postSource = getDTS
                            .AsEnumerable()
                            .Select<System.Data.DataRow, String>(x => x.Field<String>("item_name"))
                            .ToArray();

                var source = new AutoCompleteStringCollection();
                source.AddRange(postSource);
                ////txtMachineAutoSearch.AutoCompleteCustomSource = source;
                ////txtMachineAutoSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                ////txtMachineAutoSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }

            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private void GetInventorTaggedData(int Aid)
        {
            try
            {
                DataTable invTable = new DataTable();
                invTable = Resources.Instance.GetInventorTaggedData(Aid);
                DgvTaggedList.DataSource = invTable;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTaggInvt_Click(object sender, EventArgs e)
        {
            try
            {
                int aid = 0;
                DataRow[] result = getDTS.Select("item_name='" + txtMachineAutoSearch.Text + "'");
                foreach (DataRow row in result)
                {
                    aid = Convert.ToInt32(row["auto_invent_id"]);
                }
                int a = Resources.Instance.AddInventoryTaggedMachine(aid, txttaggedMachine.Text);
                if (a > 0)
                {
                    MessageBox.Show("Machine Tagged Succesfully");
                }
                else
                {
                    MessageBox.Show("Oops something went wrong!.");
                }
                //cleardataTable();
                txtMachineAutoSearch.Text = "";
                txttaggedMachine.Text = "";
                GetInventorTaggedData(aid);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void datepickInstallation_ValueChanged(object sender, EventArgs e)
        {

        }

        private void sheetComboSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public Boolean ValidatePrevMaintainance(int rowIndex)
        {

            bool IsValid = true;
            if (DgvResult.Rows[rowIndex].Cells["Rsult"].Value == null)
            {
                XtraMessageBox.Show("Please fill Result");
                IsValid = false;

            }
            else if (DgvResult.Rows[rowIndex].Cells["Deviations"].Value == null)
            {
                XtraMessageBox.Show("Please fill Deviations");
                IsValid = false;
            }
            else if (DgvResult.Rows[rowIndex].Cells["observationV"].Value == null)
            {
                XtraMessageBox.Show("Please fill Observation (Visual Only)");
                IsValid = false;
            }
            else if (DgvResult.Rows[rowIndex].Cells["criticality"].Value == null)
            {
                XtraMessageBox.Show("Please fill Criticality");
                IsValid = false;
            }
            else if (DgvResult.Rows[rowIndex].Cells["Element"].Value == null)
            {
                XtraMessageBox.Show("Please fill Elements");
                IsValid = false;
            }
            return IsValid;
        }

        private void btnFunction_Click(object sender, EventArgs e)
        {
            MCDpages.SelectedIndex = 0;
        }

        private void btnKeyComponent_Click(object sender, EventArgs e)
        {
            MCDpages.SelectedIndex = 1;
        }

        private void btnMainDesignParam_Click(object sender, EventArgs e)
        {
            //MCDpages.SelectedIndex = 2;
        }

        private void btnInvSpares_Click(object sender, EventArgs e)
        {
            //MCDpages.SelectedIndex = 3;
        }

        private void btnSpecification_Click(object sender, EventArgs e)
        {
            MCDpages.SelectedIndex = 2;
        }

        private void btnSafety_Click(object sender, EventArgs e)
        {
            //MCDpages.SelectedIndex = 5;
        }

        private void btnEnvironment_Click(object sender, EventArgs e)
        {
            //MCDpages.SelectedIndex = 6;
        }

        private void btntabmaintenenace_Click(object sender, EventArgs e)
        {
            //MCDpages.SelectedIndex = 7;
        }

        private void btnHierarchy_Click(object sender, EventArgs e)
        {
            MCDpages.SelectedIndex = 3;
        }

        private void btnHazop_Click(object sender, EventArgs e)
        {
            //MCDpages.SelectedIndex = 9;
        }

        private void btnUpld_Click(object sender, EventArgs e)
        {
            MCDpages.SelectedIndex = 4;
        }
        private void groupBox1_Move(object sender, EventArgs e)
        {
            //cmblayer.Enabled = false;
        }

        private void txttagno__TextChanged(object sender, EventArgs e)
        {

        }

        private void HideMCDPagesHeader()
        {
            MCDpages.Appearance = TabAppearance.FlatButtons;
            MCDpages.ItemSize = new Size(0, 1);
            MCDpages.SizeMode = TabSizeMode.Fixed;

            foreach (TabPage tab in MCDpages.TabPages)
            {
                tab.Hide();// = "";
            }
        }

        private void bunifuButton25_Click(object sender, EventArgs e)
        {
            SpecificationPages.SelectedIndex = 0;
        }

        private void btnProcesParam_Click(object sender, EventArgs e)
        {
            SpecificationPages.SelectedIndex = 1;
        }

        private void btnMachineElecInstu_Click(object sender, EventArgs e)
        {
            SpecificationPages.SelectedIndex = 2;
        }

        private void btnNozzles_Click(object sender, EventArgs e)
        {
            SpecificationPages.SelectedIndex = 3;
        }

        private void btnPhysicalParam_Click(object sender, EventArgs e)
        {
            SpecificationPages.SelectedIndex = 4;
        }

        private void btnComplience_Click(object sender, EventArgs e)
        {
            SpecificationPages.SelectedIndex = 5;
        }

        private void btnDesignData_Click(object sender, EventArgs e)
        {
            SpecificationPages.SelectedIndex = 6;
        }

        private void chkmultifloor_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkmultifloor.CheckedItems.Count != 0)
                {
                    if (_SendToPointForMulCadLayoutFrm != null)
                    {
                        if (chkmultifloor.CheckedItems != null)
                        {
                            if (offsetDict.Count > 0)
                            {
                                if (!SameMachineDrop.Contains(this.MachineName))
                                {
                                    string firstTabText = chkmultifloor.SelectedItem.ToString();
                                    _SendToPointForMulCadLayoutFrm.Invoke(firstTabText, _Cordinates, this.MachineName);
                                }
                                Resources.Instance.UpdateMultifoorCheck(txttagno.Text, cmblocation.SelectedItem.ToString(), 1);// Multiple Machine Data Hold                               
                            }
                        }
                    }
                }
                else
                {
                    Resources.Instance.UpdateMultifoorCheck(txttagno.Text, cmblocation.SelectedItem.ToString(), 0);// Update multiple Check Value..
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void HideSpecificationPagesHeader()
        {
            SpecificationPages.Appearance = TabAppearance.FlatButtons;
            SpecificationPages.ItemSize = new Size(0, 1);
            SpecificationPages.SizeMode = TabSizeMode.Fixed;

            foreach (TabPage tab in SpecificationPages.TabPages)
            {
                tab.Hide();// = "";
            }
        }
    }
}

