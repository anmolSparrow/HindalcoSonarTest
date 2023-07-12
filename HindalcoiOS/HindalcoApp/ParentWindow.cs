#region All NameSpace Declarartion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors.Controls;
using DevExpress.LookAndFeel;
using HindalcoiOS.Form_Collection;
using HindalcoiOS.Class_Operation;
using DevExpress.XtraPrinting;
using HindalcoiOS.Dynamic_Form;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Views.NativeMdi;
using CADImport.CADImportForms;
using CADImport;
using CADImport.RasterImage;
using System.IO;
using CADImport.Export;
using System.Drawing.Imaging;
using DevExpress.XtraEditors;
using CADImport.Professional;
using CADImport.FaceModule;
using DevExpress.Skins;
using System.Threading;
using System.Diagnostics;
using System.Data.SqlClient;
using OfficeOpenXml;
using System.Collections.Concurrent;
using System.Drawing.Drawing2D;
using HindalcoiOS.Machine_Edit_Form;
using HindalcoiOS.PackageMachine;
using System.Text.RegularExpressions;
using HindalcoiOS.Connector_FRM;
using System.Xml.Linq;
using HindalcoiOS.Login_Form;
using System.Data.OleDb;
using ExcelDataReader;
using SparrowRMS;
using HindalcoiOS.Configuration;
using System.Security.Cryptography;
using System.Reflection;
using HindalcoiOS.Multifloor;
using WeifenLuo.WinFormsUI.Docking;
using DevExpress.XtraBars.Docking;
using CADImport.CGM;
using log4net;
using System.Collections.Specialized;
using HindalcoiOS.AuditHind;
#endregion

namespace HindalcoiOS
{
    #region Delegate Declaration
    public delegate void SomeEvents(params object[] args);
    // public delegate void MailEvents(MailDetail mailDetail);
    #endregion
    public enum OffsetCalculationStatus
    {
        Inactive,
        Started,
        FirstClickDone,
        SecondClickDone
    }
    public partial class ParentWindow : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public OffsetCalculator offset;
        private List<mulCadLayout> _ListOffFloor = new List<mulCadLayout>();
        public static readonly ILog Log = LogHelper.GetLogger();
        #region EventHandler Declaration
        public EventHandler<string> OnAfterLogOut;
        public EventHandler<DateTime> RefreshTaskPanel;
        public EventHandler<DateTime> GetTaskPanel;
        public event SomeEvents SomeEvent;
        public PlantLayout PlantLayout;
        #endregion

        #region Dictinary Declaration
        public static int ParameterId;
        private Dictionary<DPoint, string> _RcConnectorDic = new Dictionary<DPoint, string>();
        int RCNumber = 1;
        private Dictionary<string, string> _DeletedMachineDic = new Dictionary<string, string>();
        private Dictionary<string, string> _DicMachineNo = new Dictionary<string, string>();
        private Dictionary<string, Connector> _listconnt = new Dictionary<string, Connector>();
        private ConcurrentDictionary<string, string> _searchImage = new ConcurrentDictionary<string, string>();
        public ConcurrentDictionary<string, string> _HoldImagePat = new ConcurrentDictionary<string, string>();
        private ConcurrentDictionary<string, Machine_Edit_Data> EditfrmDictionary = new ConcurrentDictionary<string, Machine_Edit_Data>();
        private ConcurrentDictionary<string, DPoint> _MachineCordinates = new ConcurrentDictionary<string, DPoint>();
        private ConcurrentDictionary<string, String> _LineTypeHold = new ConcurrentDictionary<string, string>();
        private Dictionary<string, List<string>> _UpdateDic = new Dictionary<string, List<string>>();
        private ConcurrentDictionary<string, PackageMachine.PackageMachine> _HoldPackageMachine = new ConcurrentDictionary<string, PackageMachine.PackageMachine>();
        private string Source = string.Empty;
        private string Destination = string.Empty;
        private bool IsReloadLine;
        Connector connector;
        #endregion

        #region Fields Declaration
        #region integer variable declaraton(public, private and static)       
        int ImgCount = 1;
        private int addEntity;
        private int btnOffset = 8;
        private int entitiesLimit = 0;
        int MechineNumber = 1;
        public static int paraMeterId = 0;
        int addedunit = 0;
        int parameterId = 0;
        int glb_LayerId = 0;
        int machinetyp;
        #endregion       

        #region Private Boolean fields Declaration
        List<string> machineList = new List<string>();
        public static bool isFileFound = true;
        public static bool oldRloaddxf = false;
        public static bool ismachineDragged = false;
        private bool Dialog, YesDailog, firstloginexit;
        private bool isParent = true;
        private bool _IsLineComplete;
        private bool Iscall;
        #endregion

        #region String fileds declaration(public,private and static)   
        public string SetMachineName = string.Empty;
        public static string permitLink, RaiseReview = string.Empty;
        private string TaskTypeClk = string.Empty;
        public static string[] dataunit = new string[] { };
        public static string todayTaskCode;
        string CMBmtype = "";
        string cmbCtype = "";
        string CadFilePath = string.Empty;
        string SystemMachine = string.Empty;
        string SysGenNum = string.Empty;
        string Mvalue = string.Empty;
        string empCode = Class_Operation.GlobalDeclaration._holdInfo[0].EmpCode.ToString();
        string dateObj = DateTime.Now.ToString("yyyy-MM-dd 00:00:00.000");
        #endregion

        #region Private Class instance Declaration                    
        private BarEditItem biStyle;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox riicStyle;
        #endregion

        #region Multi floor config

        private DPoint basePoint, finalPoint;

        private string offsetForm;
        private OffsetCalculationStatus offsetCalculationStatus;

        private Dictionary<string, DPoint> offsetDict = new Dictionary<string, DPoint>();

        #endregion

        #region Data Table Declation
        private DataTable _Trainername = new DataTable();
        DataTable newCopy = new DataTable();
        DataTable MachineSunLayerLoadDt = null;
        DataTable todayTask = new DataTable();
        DataTable UpcomingTask = new DataTable();
        DataTable pendingTask = new DataTable();
        DataTable UpcomingNewTask = new DataTable();
        DataTable usernotification = new DataTable();
        DataTable ftpSessionObj = null;
        #endregion

        #endregion

        #region Get Application Assembly Version
        private void FindVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            string Name = fvi.ProductVersion;
            barverinfo.Caption = version;
            this.Text = this.Text + "-" + Name;
        }
        #endregion

        #region "Global Variable"
        string[] col;
        string machinetype;
        string replHeader = "";
        string imagePath = "";
        string app_Path = "";
        string path = "";
        string arrval = "";
        bool existval = false;
        object columnval;
        #endregion

        #region MainWindow Contructor
        public ParentWindow()
        {
            InitializeComponent();
            offset = new OffsetCalculator();
            Resources.Instance.callMethod();
            LoadDefaultSetting();
            this.WindowState = FormWindowState.Maximized;
            this.IsMdiContainer = true;
            dockPanel3.DefaultFloatWindowSize = new Size(1200, 800);
            // GetKeyComponentDT();
        }
        #endregion

        #region CAD Object Initialization and License File Configuration      
        private void BindColumn()
        {
            try
            {
                DataTable dt = Resources.Instance.CreateCommand();
                //using (SqlConnection cnn = new SqlConnection(Resources.Instance.connectionsstring))
                //{
                //    cnn.Open();
                //    using (SqlDataAdapter sda = new SqlDataAdapter("select ColumnName,TableName from Generic", cnn))
                //    {

                //        sda.SelectCommand.CommandType = CommandType.Text;
                //        dt = new DataTable();
                //        sda.Fill(dt);
                //        sda.Dispose();
                //    }
                //    cnn.Close();
                //    cnn.Dispose();
                //}
                if (dt.Rows.Count > 0 && !GlobalDeclaration.FirstLogOut)
                {
                    GlobalDeclaration.Splitclm(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString());
                    GlobalDeclaration.Splitclm(dt.Rows[1][0].ToString(), dt.Rows[1][1].ToString());
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Connection is Not Established..\n Please Check Network Server", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }
        private void AutoLoadCCAD(bool dlg)
        {
            try
            {
                string FolderPth = string.Empty;
                string FileName = string.Empty;
                string text = System.IO.Path.GetFullPath("AppSetting.ini");
                mulCadLayout _obj = null;
                IniFile.SetPath(text);
                if (File.Exists(text))
                {
                    IniFile.SetPath(text);
                    if (!string.IsNullOrEmpty(IniFile.IniReadValue("DBConfig", "FileName")) && !string.IsNullOrEmpty(IniFile.IniReadValue("DBConfig", "FolderPath")))
                    {
                        FileName = IniFile.IniReadValue("DBConfig", "FileName");
                        FolderPth = IniFile.IniReadValue("DBConfig", "FolderPath");
                    }
                }
                if (dockPanel3.Contents.Count > 0)
                {
                    string Filelocation = GlobalDeclaration.ReturnPath();
                    Filelocation = Path.Combine(Filelocation, "SparrowCAD");
                    for (int i = 0; i < dockPanel3.Contents.Count; i++)
                    {
                        FileName = lst[i];
                        FileName = string.Concat(FolderPth, @"\", "SparrowCAD", @"\", FileName);
                        var dockingpanel = dockPanel3.Contents[i];//.AsEnumerable().Where(X => X.DockHandler.TabText == lst[i].Split('.')[0]).FirstOrDefault();
                        if (dockingpanel.DockHandler.TabText == lst[i].Split('.')[0])
                        {
                            _obj = _ListOffFloor.AsEnumerable().Where(X => X.TabText == dockingpanel.DockHandler.TabText).FirstOrDefault();
                            _obj.SetPictureBoxLoadState(true, string.Empty);
                            if (dlg)
                            {
                                AUtoFileLoadCADThread(_obj, FileName);
                                stBar.Caption = _obj.StatusCaption = FileName;
                            }
                        }
                        int levelcount = i + 1;
                        if (!PlantLayout._FormName.Contains(lst[i].Split('.')[0]))
                        {
                            PlantLayout.AdddynamicCTRL("", levelcount);//"ReloadDocking", dockPanel3.Contents.Count
                            PlantLayout._FormName.Add(lst[i].Split('.')[0]);
                            var floortextbox = PlantLayout.Controls.OfType<TextBox>().ToList();
                            floortextbox[i].Text = lst[i].Split('.')[0];
                            PlantLayout.prevValue = decimal.Parse(PlantLayout.Controls.OfType<TextBox>().Count().ToString());
                        }
                        // OffSet Dic Restore..........
                        string OffsetForm = FileName.Split('.')[0].Split('\\')[6];
                        if (FileName.Split('.')[0].Split('\\')[6] == dockingpanel.DockHandler.TabText)
                        {
                            if (File.Exists(Filelocation + @"\" + FileName.Split('.')[0].Split('\\')[6] + "~OffSet" + ".spr"))
                            {
                                offsetDict = GlobalDeclaration.LoadOffSet(Filelocation + @"\" + FileName.Split('.')[0].Split('\\')[6] + "~OffSet" + ".spr");
                                _ListOffFloor.AsEnumerable().Where(X => X.TabText != offsetForm).FirstOrDefault().offsetDict = offsetDict;

                            }
                        }
                        _ListOffFloor.AsEnumerable().Where(X => X.TabText == lst[i].Split('.')[0]).FirstOrDefault().listofdockcontaint = _ListOffFloor;
                        _ListOffFloor.AsEnumerable().Where(X => X.TabText == lst[i].Split('.')[0]).FirstOrDefault().offsetDict = offsetDict;
                        _ListOffFloor.AsEnumerable().Where(X => X.TabText == lst[i].Split('.')[0]).FirstOrDefault().floorCount = _ListOffFloor.Count;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //SetPictureBoxLoadState(true, string.Empty);
            //if (dlg)
            //{
            //    Thread th = new Thread(new ThreadStart(() => AUtoFileLoadCADThread(FileName)));
            //    th.Name = "AUTOLoadCaDFile";
            //    th.Start();
            //    //th.Abort();
            //    //AUtoFileLoadCADThread(FileName);
            //}
        }
        public void AUtoFileLoadCADThread(mulCadLayout _currentobj, string FileName)
        {
            //if (this.InvokeRequired)
            //{
            //this.Invoke(new MethodInvoker(delegate
            //{
            try
            {
                if (!string.IsNullOrEmpty(FileName))
                {
                    _currentobj.LoadFile(FileName);
                }
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        iClose.Enabled = true;
                    }));
                }
                else
                {
                    iClose.Enabled = true;
                }
                _currentobj.ChangeControlState();
                _currentobj.SomeEvent += ParentWindow_SomeEvent;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Get Default Setting Load       
        private void LoadDefaultSetting()
        {
            try
            {
                this.ribbon.Refresh();
                this.ribbon.AutoSaveLayoutToXml = true;
                RibbonPageCollection rgc = this.ribbon.Pages;
                ribbon.ShowCategoryInCaption = false;
                RoleType Rolestypes = (RoleType)HindalcoiOS.Properties.Settings.Default.RoleID;
                switch (Rolestypes)
                {
                    case RoleType.Admin:
                        {
                            for (int i = 0; i < rgc.Count; i++)
                            {
                                RibbonPage page = rgc[i];
                                if (GlobalDeclaration.FirstLogOut)// After LogAout Process
                                {
                                    page.Visible = true;
                                }
                                switch (page.Name)
                                {
                                    case "ViewRibbon":
                                        {
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "rbnPageGrpInetrNal" || page.Groups[j].Name == "rbnpagegrp" || page.Groups[j].Name == "rbngrpView" || page.Groups[j].Name == "rbnpageGRPEdit" || page.Groups[j].Name == "rbngrpExit")//|| page.Groups[j].Name == "rbnGrpTraing"
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                                else
                                                {
                                                    page.Groups[j].Visible = false;
                                                }
                                            }
                                        }
                                        break;
                                    case "ribbnpageHome":
                                        {
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "rbnPageConnect")
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                            }
                                            //if (GlobalDeclaration.FirstLogOut)// After LogAout Process
                                            //{                                     
                                            //}
                                        }
                                        break;
                                    case "SettingRibbnPage":
                                        {
                                            if (GlobalDeclaration.FirstLogOut)// After LogAout Process
                                            {
                                                for (int j = 0; j < page.Groups.Count; j++)
                                                {
                                                    if (page.Groups[j].Name == "rbnpageAutoSetting")
                                                    {
                                                        for (int M = 0; M < page.Groups[j].ItemLinks.Count; M++)
                                                        {
                                                            page.Groups[j].ItemLinks[M].Visible = true;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        page.Groups[j].Visible = true;
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "rgpHelp":
                                        {
                                            page.Visible = true;
                                        }
                                        break;
                                    case "InvMNG":
                                    case "rbnpageEdit":
                                    case "rbnpageTraining":
                                    case "rbnProdution":
                                    case "MaintenacePage":
                                    case "rbnPageReports":
                                    case "rgnpageNRM":
                                    case "ribbonPage8":
                                    case "ribbonPage5":
                                    case "rbnPageDboard":
                                        {
                                            page.Visible = false;
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    case RoleType.User:
                        {
                            for (int i = 0; i < rgc.Count; i++)
                            {
                                RibbonPage page = rgc[i];
                                if (GlobalDeclaration.FirstLogOut)// After LogAout Process
                                {
                                    page.Visible = true;
                                }

                                switch (page.Name)
                                {
                                    case "ViewRibbon":
                                    case "rbnpageEdit":
                                        {
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "rbnPageGrpInetrNal" || page.Groups[j].Name == "rbnpagegrp" || page.Groups[j].Name == "rbngrpView" || page.Groups[j].Name == "rbnpageGRPEdit" || page.Groups[j].Name == "rbngrpExit")
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                                else
                                                {
                                                    page.Groups[j].Visible = false;
                                                }
                                            }
                                        }
                                        break;
                                    case "ribbnpageHome":
                                        {
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "ribbonPageGroup3" || page.Groups[j].Name == "rbnFileGrp" || page.Groups[j].Name == "rbngrpExit")
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                                else
                                                {
                                                    page.Groups[j].Visible = false;
                                                }
                                            }
                                        }
                                        break;
                                    case "SettingRibbnPage":
                                        {
                                            //page.Visible = true;
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "rbnpageAutoSetting")
                                                {
                                                    for (int M = 0; M < page.Groups[j].ItemLinks.Count; M++)
                                                    {
                                                        if (page.Groups[j].ItemLinks[M].Caption == "Change Password")//||page.Groups[j].ItemLinks[M].Caption == "User Registration" || page.Groups[j].ItemLinks[M].Caption == "Manage User"
                                                        {
                                                            page.Groups[j].ItemLinks[M].Visible = true;
                                                        }
                                                        else
                                                        {
                                                            page.Groups[j].ItemLinks[M].Visible = false;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                            }

                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    case RoleType.Maintenance:
                        {
                            if (GlobalDeclaration.FirstLogOut)// After LogAout Process
                            {
                                this.ribbon.Categories[1].Visible = true;
                            }
                            for (int i = 0; i < rgc.Count; i++)
                            {
                                RibbonPage page = rgc[i];
                                if (GlobalDeclaration.FirstLogOut)// After LogAout Process
                                {
                                    page.Visible = true;
                                }
                                switch (page.Name)
                                {
                                    case "ribbnpageHome":
                                        {
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "ribbonPageGroup3" || page.Groups[j].Name == "rbnFileGrp" || page.Groups[j].Name == "rbngrpExit")
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                                else
                                                {
                                                    page.Groups[j].Visible = false;
                                                }
                                            }
                                        }
                                        break;
                                    case "ViewRibbon":
                                        {
                                            //for (int j = 0; j < page.Groups.Count; j++)
                                            //{
                                            //    if (page.Groups[j].Name == "rbnPageGrpInetrNal" || page.Groups[j].Name == "rbnpagegrp" || page.Groups[j].Name == "rbnGrpTraing" || page.Groups[j].Name == "rbngrpExit" || page.Groups[j].Name == "rbngrpView")
                                            //    {
                                            //        if (page.Groups[j].Name == "rbnGrpTraing")
                                            //        {
                                            //            for (int M = 0; M < page.Groups[j].ItemLinks.Count; M++)
                                            //            {

                                            //                if (page.Groups[j].ItemLinks[M].Caption == "Manage")
                                            //                {
                                            //                    if (GlobalDeclaration._holdInfo[0].DepartmentName == "HR")
                                            //                    {
                                            //                        page.Groups[j].ItemLinks[M].Visible = true;
                                            //                    }
                                            //                    else
                                            //                    {
                                            //                        page.Groups[j].ItemLinks[M].Visible = false;
                                            //                    }
                                            //                }
                                            //                else if (page.Groups[j].ItemLinks[M].Caption == "Add Training")
                                            //                {
                                            //                    for (int z = 0; z < ((DevExpress.XtraBars.BarCustomContainerItem)page.Groups[j].ItemLinks[M].Item).ItemLinks.Count; z++)
                                            //                    {
                                            //                        if (((DevExpress.XtraBars.BarCustomContainerItem)page.Groups[j].ItemLinks[M].Item).ItemLinks[z].Caption == "Training Calendar" || ((DevExpress.XtraBars.BarCustomContainerItem)page.Groups[j].ItemLinks[M].Item).ItemLinks[z].Caption == "Other's Training")
                                            //                        {
                                            //                            if (GlobalDeclaration._holdInfo[0].DepartmentName == "HR")
                                            //                            {
                                            //                                ((DevExpress.XtraBars.BarCustomContainerItem)page.Groups[j].ItemLinks[M].Item).ItemLinks[z].Visible = true;
                                            //                            }
                                            //                            else
                                            //                            {
                                            //                                ((DevExpress.XtraBars.BarCustomContainerItem)page.Groups[j].ItemLinks[M].Item).ItemLinks[z].Visible = false;
                                            //                            }
                                            //                        }

                                            //                    }

                                            //                }
                                            //            }
                                            //        }//HR Wise visible tab
                                            //        page.Groups[j].Visible = true;
                                            //    }
                                            //    else
                                            //    {
                                            //        page.Groups[j].Visible = false;
                                            //    }
                                            //}
                                            page.Visible = true;
                                        }
                                        break;
                                    case "InvMNG":
                                    case "rbnpageEdit":
                                    case "rbnpageTraining":
                                    case "rbnProdution":
                                    case "MaintenacePage":
                                    case "rbnPageReports":
                                    //case "rgnpageNRM":
                                    case "ribbonPage8":
                                    case "ribbonPage5":
                                    case "rbnPageDboard":
                                    case "rpgHelp":
                                    case "SearchRibbon":
                                        {
                                            page.Visible = true;
                                        }
                                        break;
                                    case "SettingRibbnPage":
                                        {
                                            //page.Visible = true;
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "rbnpageAutoSetting")
                                                {
                                                    for (int M = 0; M < page.Groups[j].ItemLinks.Count; M++)
                                                    {
                                                        if (page.Groups[j].ItemLinks[M].Caption == "Change Password")//||page.Groups[j].ItemLinks[M].Caption == "User Registration" || page.Groups[j].ItemLinks[M].Caption == "Manage User"
                                                        {
                                                            page.Groups[j].ItemLinks[M].Visible = true;
                                                        }
                                                        else
                                                        {
                                                            page.Groups[j].ItemLinks[M].Visible = false;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                            }

                                        }
                                        break;
                                    default:
                                        {
                                            page.Visible = false;
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    case RoleType.Safety:
                        {
                            if (GlobalDeclaration.FirstLogOut)// After LogOut Process
                            {

                            }

                            for (int i = 0; i < rgc.Count; i++)
                            {
                                RibbonPage page = rgc[i];
                                if (GlobalDeclaration.FirstLogOut)// After LogOut Process
                                {
                                    page.Visible = true;
                                }
                                switch (page.Name)
                                {
                                    case "ribbnpageHome":
                                        {

                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "ribbonPageGroup3" || page.Groups[j].Name == "rbnFileGrp")
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                                else
                                                {
                                                    page.Groups[j].Visible = false;
                                                }
                                            }
                                        }
                                        break;
                                    case "SearchRibbon":
                                    case "rpgHelp":
                                    case "ViewRibbon":
                                    case "rbnpageEdit":
                                    case "rbnProdution":
                                    case "rbnPageReports":
                                    case "InvMNG":
                                    case "rgnpageNRM":
                                    case "ribbonPage8":
                                    case "rbnPageDboard":
                                        {
                                            page.Visible = true;
                                        }
                                        break;
                                    case "SettingRibbnPage":
                                        {
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "rbnpageAutoSetting")
                                                {
                                                    for (int M = 0; M < page.Groups[j].ItemLinks.Count; M++)
                                                    {
                                                        if (page.Groups[j].ItemLinks[M].Caption == "Change Password")// ||page.Groups[j].ItemLinks[M].Caption == "User Registration" || page.Groups[j].ItemLinks[M].Caption == "Manage User")
                                                        {
                                                            page.Groups[j].ItemLinks[M].Visible = true;
                                                        }
                                                        else
                                                        {
                                                            page.Groups[j].ItemLinks[M].Visible = false;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                            }
                                        }
                                        break;
                                    default:
                                        page.Visible = false;
                                        break;
                                }
                            }
                        }
                        break;
                    case RoleType.Operation:
                        {
                            if (GlobalDeclaration.FirstLogOut)// After LogOut Process
                            {
                                this.ribbon.Categories[1].Visible = true;
                            }
                            for (int i = 0; i < rgc.Count; i++)
                            {
                                RibbonPage page = rgc[i];
                                if (GlobalDeclaration.FirstLogOut)// After LogOut Process
                                {
                                    page.Visible = true;
                                }
                                switch (page.Name)
                                {
                                    case "ribbnpageHome":
                                        {
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "ribbonPageGroup3" || page.Groups[j].Name == "rbnFileGrp")
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                                else
                                                {
                                                    page.Groups[j].Visible = false;
                                                }
                                            }
                                        }
                                        break;
                                    case "InvMNG":
                                    // case "rbnpageEdit":
                                    //case "rbnpageTraining":
                                    case "rbnProdution":
                                    //case "MaintenacePage":
                                    case "rbnPageReports":
                                    //case "rgnpageNRM":
                                    // case "ribbonPage8":
                                    case "ribbonPage5":
                                    case "rbnPageDboard":
                                    case "SearchRibbon":
                                    case "rpgHelp":
                                    case "ViewRibbon":
                                        {
                                            page.Visible = true;
                                        }
                                        break;

                                    case "SettingRibbnPage":
                                        {
                                            if (GlobalDeclaration.FirstLogOut)
                                            {
                                                page.Visible = true;
                                            }
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "rbnpageAutoSetting")
                                                {
                                                    for (int M = 0; M < page.Groups[j].ItemLinks.Count; M++)
                                                    {
                                                        if (page.Groups[j].ItemLinks[M].Caption == "Change Password")// ||page.Groups[j].ItemLinks[M].Caption == "User Registration" || page.Groups[j].ItemLinks[M].Caption == "Manage User")
                                                        {
                                                            page.Groups[j].ItemLinks[M].Visible = true;
                                                        }
                                                        else
                                                        {
                                                            page.Groups[j].ItemLinks[M].Visible = false;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                            }
                                        }
                                        break;
                                    default:
                                        page.Visible = false;
                                        break;
                                }
                            }
                        }
                        break;
                    case RoleType.Corporate:
                        {
                            if (GlobalDeclaration.FirstLogOut)// After LogAout Process
                            {
                                this.ribbon.Categories[1].Visible = true;
                            }
                            for (int i = 0; i < rgc.Count; i++)
                            {
                                RibbonPage page = rgc[i];
                                if (GlobalDeclaration.FirstLogOut)// After LogAout Process
                                {
                                    page.Visible = true;
                                }
                                switch (page.Name)
                                {
                                    case "ViewRibbon":
                                        {
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "rbnPageGrpInetrNal" || page.Groups[j].Name == "rbnpagegrp" || page.Groups[j].Name == "rbngrpView" || page.Groups[j].Name == "rbnpageGRPEdit" || page.Groups[j].Name == "rbngrpExit")//|| page.Groups[j].Name == "rbnGrpTraing"
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                                else
                                                {
                                                    page.Groups[j].Visible = false;
                                                }
                                            }
                                        }
                                        break;
                                    case "ribbnpageHome":
                                        {
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "ribbonPageGroup3" || page.Groups[j].Name == "rbnFileGrp" || page.Groups[j].Name == "rbngrpExit")
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                                else
                                                {
                                                    page.Groups[j].Visible = false;
                                                }
                                            }
                                        }
                                        break;
                                    case "SettingRibbnPage":
                                        {
                                            if (GlobalDeclaration.FirstLogOut)
                                            {
                                                page.Visible = true;
                                            }
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "rbnpageAutoSetting")
                                                {
                                                    for (int M = 0; M < page.Groups[j].ItemLinks.Count; M++)
                                                    {
                                                        if (page.Groups[j].ItemLinks[M].Caption == "Change Password" || page.Groups[j].ItemLinks[M].Caption == "Operation Unit")// ||page.Groups[j].ItemLinks[M].Caption == "User Registration" || page.Groups[j].ItemLinks[M].Caption == "Manage User")
                                                        {
                                                            page.Groups[j].ItemLinks[M].Visible = true;
                                                        }
                                                        else
                                                        {
                                                            page.Groups[j].ItemLinks[M].Visible = false;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                            }
                                        }
                                        break;
                                    case "rgpHelp":
                                        {
                                            page.Visible = true;
                                        }
                                        break;
                                    case "InvMNG":
                                    case "rbnpageEdit":
                                    case "rbnpageTraining":
                                    case "rbnProdution":
                                    case "MaintenacePage":
                                    case "rbnPageReports":
                                    case "rgnpageNRM":
                                    case "ribbonPage8":
                                    case "ribbonPage5":
                                    case "rbnPageDboard":
                                        {
                                            page.Visible = true;
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    case RoleType.CommiteeHead:
                        {
                            if (GlobalDeclaration.FirstLogOut)// After LogAout Process
                            {
                                this.ribbon.Categories[1].Visible = true;
                            }
                            for (int i = 0; i < rgc.Count; i++)
                            {
                                RibbonPage page = rgc[i];
                                if (GlobalDeclaration.FirstLogOut)// After LogAout Process
                                {
                                    page.Visible = true;
                                }
                                switch (page.Name)
                                {
                                    case "ribbnpageHome":
                                        {
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "ribbonPageGroup3" || page.Groups[j].Name == "rbnFileGrp" || page.Groups[j].Name == "rbngrpExit")
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                                else
                                                {
                                                    page.Groups[j].Visible = false;
                                                }
                                            }
                                        }
                                        break;
                                    case "ViewRibbon":
                                        {
                                            //for (int j = 0; j < page.Groups.Count; j++)
                                            //{
                                            //    if (page.Groups[j].Name == "rbnPageGrpInetrNal" || page.Groups[j].Name == "rbnpagegrp" || page.Groups[j].Name == "rbnGrpTraing" || page.Groups[j].Name == "rbngrpExit" || page.Groups[j].Name == "rbngrpView")
                                            //    {
                                            //        if (page.Groups[j].Name == "rbnGrpTraing")
                                            //        {
                                            //            for (int M = 0; M < page.Groups[j].ItemLinks.Count; M++)
                                            //            {

                                            //                if (page.Groups[j].ItemLinks[M].Caption == "Manage")
                                            //                {
                                            //                    if (GlobalDeclaration._holdInfo[0].DepartmentName == "HR")
                                            //                    {
                                            //                        page.Groups[j].ItemLinks[M].Visible = true;
                                            //                    }
                                            //                    else
                                            //                    {
                                            //                        page.Groups[j].ItemLinks[M].Visible = false;
                                            //                    }
                                            //                }
                                            //                else if (page.Groups[j].ItemLinks[M].Caption == "Add Training")
                                            //                {
                                            //                    for (int z = 0; z < ((DevExpress.XtraBars.BarCustomContainerItem)page.Groups[j].ItemLinks[M].Item).ItemLinks.Count; z++)
                                            //                    {
                                            //                        if (((DevExpress.XtraBars.BarCustomContainerItem)page.Groups[j].ItemLinks[M].Item).ItemLinks[z].Caption == "Training Calendar" || ((DevExpress.XtraBars.BarCustomContainerItem)page.Groups[j].ItemLinks[M].Item).ItemLinks[z].Caption == "Other's Training")
                                            //                        {
                                            //                            if (GlobalDeclaration._holdInfo[0].DepartmentName == "HR")
                                            //                            {
                                            //                                ((DevExpress.XtraBars.BarCustomContainerItem)page.Groups[j].ItemLinks[M].Item).ItemLinks[z].Visible = true;
                                            //                            }
                                            //                            else
                                            //                            {
                                            //                                ((DevExpress.XtraBars.BarCustomContainerItem)page.Groups[j].ItemLinks[M].Item).ItemLinks[z].Visible = false;
                                            //                            }
                                            //                        }

                                            //                    }

                                            //                }
                                            //            }
                                            //        }//HR Wise visible tab
                                            //        page.Groups[j].Visible = true;
                                            //    }
                                            //    else
                                            //    {
                                            //        page.Groups[j].Visible = false;
                                            //    }
                                            //}
                                            page.Visible = true;
                                        }
                                        break;
                                    case "InvMNG":
                                    case "rbnpageEdit":
                                        {
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "rbnpageGRPEdit")
                                                {
                                                    for (int M = 0; M < page.Groups[j].ItemLinks.Count; M++)
                                                    {
                                                        if (page.Groups[j].ItemLinks[M].Caption == "Tracker")
                                                        {
                                                            if (Properties.Settings.Default.RoleID == 11 || Properties.Settings.Default.RoleID == 13 || Properties.Settings.Default.RoleID == 14)
                                                            {
                                                                page.Groups[j].ItemLinks[M].Visible = false;
                                                            }
                                                        }

                                                        if (page.Groups[j].ItemLinks[M].Caption == "Audit Calendar")
                                                        {
                                                            if (Properties.Settings.Default.RoleID == 11 || Properties.Settings.Default.RoleID == 13 || Properties.Settings.Default.RoleID == 14)
                                                            {
                                                                page.Groups[j].ItemLinks[M].Visible = true;
                                                            }
                                                        }

                                                        if (page.Groups[j].ItemLinks[M].Caption == "Audit Report")
                                                        {
                                                            if (Properties.Settings.Default.RoleID == 11 || Properties.Settings.Default.RoleID == 13 || Properties.Settings.Default.RoleID == 14)
                                                            {
                                                                page.Groups[j].ItemLinks[M].Visible = true;
                                                            }
                                                        }
                                                        //else
                                                        //{
                                                        //    page.Groups[j].ItemLinks[M].Visible = false;
                                                        //}

                                                        if (page.Groups[j].ItemLinks[M].Caption == "Audit Master")
                                                        {
                                                            if (Properties.Settings.Default.RoleID == 11 || Properties.Settings.Default.RoleID == 13 || Properties.Settings.Default.RoleID == 14)
                                                            {
                                                                page.Groups[j].ItemLinks[M].Visible = true;
                                                            }
                                                        }
                                                        //else
                                                        //{
                                                        //    page.Groups[j].ItemLinks[M].Visible = false;
                                                        //}

                                                        if (page.Groups[j].ItemLinks[M].Caption == "Audit Category")
                                                        {
                                                            if (Properties.Settings.Default.RoleID == 11 || Properties.Settings.Default.RoleID == 13 || Properties.Settings.Default.RoleID == 14)
                                                            {
                                                                page.Groups[j].ItemLinks[M].Visible = true;
                                                            }
                                                        }
                                                        //else
                                                        //{
                                                        //    page.Groups[j].ItemLinks[M].Visible = false;
                                                        //}
                                                    }
                                                }

                                                else
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                            }
                                        }
                                        break;
                                    case "rbnpageTraining":
                                    case "rbnProdution":
                                    case "MaintenacePage":
                                    case "rbnPageReports":
                                    //case "rgnpageNRM":
                                    case "ribbonPage8":
                                    case "ribbonPage5":
                                    case "rbnPageDboard":
                                    case "rpgHelp":
                                    case "SearchRibbon":
                                        {
                                            page.Visible = true;
                                        }
                                        break;
                                    case "SettingRibbnPage":
                                        {
                                            //page.Visible = true;
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "rbnpageAutoSetting")
                                                {
                                                    for (int M = 0; M < page.Groups[j].ItemLinks.Count; M++)
                                                    {
                                                        if (page.Groups[j].ItemLinks[M].Caption == "Change Password")//||page.Groups[j].ItemLinks[M].Caption == "User Registration" || page.Groups[j].ItemLinks[M].Caption == "Manage User"
                                                        {
                                                            page.Groups[j].ItemLinks[M].Visible = true;
                                                        }
                                                        else
                                                        {
                                                            page.Groups[j].ItemLinks[M].Visible = false;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                            }

                                        }
                                        break;
                                    default:
                                        {
                                            page.Visible = false;
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    case RoleType.CommiteeMember:
                        {
                            if (GlobalDeclaration.FirstLogOut)// After LogAout Process
                            {
                                this.ribbon.Categories[1].Visible = true;
                            }
                            for (int i = 0; i < rgc.Count; i++)
                            {
                                RibbonPage page = rgc[i];
                                if (GlobalDeclaration.FirstLogOut)// After LogAout Process
                                {
                                    page.Visible = true;
                                }
                                switch (page.Name)
                                {
                                    case "ribbnpageHome":
                                        {
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "ribbonPageGroup3" || page.Groups[j].Name == "rbnFileGrp" || page.Groups[j].Name == "rbngrpExit")
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                                else
                                                {
                                                    page.Groups[j].Visible = false;
                                                }
                                            }
                                        }
                                        break;
                                    case "ViewRibbon":
                                        {
                                            page.Visible = true;
                                        }
                                        break;
                                    case "InvMNG":
                                    case "rbnpageEdit":
                                        {
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "rbnpageGRPEdit")
                                                {
                                                    for (int M = 0; M < page.Groups[j].ItemLinks.Count; M++)
                                                    {
                                                        if (page.Groups[j].ItemLinks[M].Caption == "Tracker")
                                                        {
                                                            if (Properties.Settings.Default.RoleID == 11 || Properties.Settings.Default.RoleID == 13 || Properties.Settings.Default.RoleID == 14)
                                                            {
                                                                page.Groups[j].ItemLinks[M].Visible = false;
                                                            }
                                                        }

                                                        if (page.Groups[j].ItemLinks[M].Caption == "Audit Calendar")
                                                        {
                                                            if (Properties.Settings.Default.RoleID == 11 || Properties.Settings.Default.RoleID == 13 || Properties.Settings.Default.RoleID == 14)
                                                            {
                                                                page.Groups[j].ItemLinks[M].Visible = true;
                                                            }
                                                        }

                                                        if (page.Groups[j].ItemLinks[M].Caption == "Audit Report")
                                                        {
                                                            if (Properties.Settings.Default.RoleID == 11 || Properties.Settings.Default.RoleID == 13 || Properties.Settings.Default.RoleID == 14)
                                                            {
                                                                page.Groups[j].ItemLinks[M].Visible = true;
                                                            }
                                                        }
                                                        //else
                                                        //{
                                                        //    page.Groups[j].ItemLinks[M].Visible = false;
                                                        //}

                                                        if (page.Groups[j].ItemLinks[M].Caption == "Audit Master")
                                                        {
                                                            if (Properties.Settings.Default.RoleID == 11 || Properties.Settings.Default.RoleID == 13 || Properties.Settings.Default.RoleID == 14)
                                                            {
                                                                page.Groups[j].ItemLinks[M].Visible = true;
                                                            }
                                                        }
                                                        //else
                                                        //{
                                                        //    page.Groups[j].ItemLinks[M].Visible = false;
                                                        //}

                                                        if (page.Groups[j].ItemLinks[M].Caption == "Audit Category")
                                                        {
                                                            if (Properties.Settings.Default.RoleID == 11 || Properties.Settings.Default.RoleID == 13 || Properties.Settings.Default.RoleID == 14)
                                                            {
                                                                page.Groups[j].ItemLinks[M].Visible = true;
                                                            }
                                                        }
                                                        //else
                                                        //{
                                                        //    page.Groups[j].ItemLinks[M].Visible = false;
                                                        //}
                                                    }
                                                }

                                                else
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                            }
                                        }
                                        break;
                                    case "rbnpageTraining":
                                    case "rbnProdution":
                                    case "MaintenacePage":
                                    case "rbnPageReports":
                                    //case "rgnpageNRM":
                                    case "ribbonPage8":
                                    case "ribbonPage5":
                                    case "rbnPageDboard":
                                    case "rpgHelp":
                                    case "SearchRibbon":
                                        {
                                            page.Visible = true;
                                        }
                                        break;
                                    case "SettingRibbnPage":
                                        {
                                            //page.Visible = true;
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "rbnpageAutoSetting")
                                                {
                                                    for (int M = 0; M < page.Groups[j].ItemLinks.Count; M++)
                                                    {
                                                        if (page.Groups[j].ItemLinks[M].Caption == "Change Password")//||page.Groups[j].ItemLinks[M].Caption == "User Registration" || page.Groups[j].ItemLinks[M].Caption == "Manage User"
                                                        {
                                                            page.Groups[j].ItemLinks[M].Visible = true;
                                                        }
                                                        else
                                                        {
                                                            page.Groups[j].ItemLinks[M].Visible = false;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                            }

                                        }
                                        break;
                                    default:
                                        {
                                            page.Visible = false;
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    case RoleType.DepartmentHead:
                        {
                            if (GlobalDeclaration.FirstLogOut)// After LogAout Process
                            {
                                this.ribbon.Categories[1].Visible = true;
                            }
                            for (int i = 0; i < rgc.Count; i++)
                            {
                                RibbonPage page = rgc[i];
                                if (GlobalDeclaration.FirstLogOut)// After LogAout Process
                                {
                                    page.Visible = true;
                                }
                                switch (page.Name)
                                {
                                    case "ribbnpageHome":
                                        {
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "ribbonPageGroup3" || page.Groups[j].Name == "rbnFileGrp" || page.Groups[j].Name == "rbngrpExit")
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                                else
                                                {
                                                    page.Groups[j].Visible = false;
                                                }
                                            }
                                        }
                                        break;
                                    case "ViewRibbon":
                                        {
                                            page.Visible = true;
                                        }
                                        break;
                                    case "InvMNG":
                                    case "rbnpageEdit":
                                        {
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "rbnpageGRPEdit")
                                                {
                                                    for (int M = 0; M < page.Groups[j].ItemLinks.Count; M++)
                                                    {
                                                        if (page.Groups[j].ItemLinks[M].Caption == "Tracker")
                                                        {
                                                            if (Properties.Settings.Default.RoleID == 11 || Properties.Settings.Default.RoleID == 13 || Properties.Settings.Default.RoleID == 14)
                                                            {
                                                                page.Groups[j].ItemLinks[M].Visible = false;
                                                            }
                                                        }

                                                        if (page.Groups[j].ItemLinks[M].Caption == "Audit Calendar")
                                                        {
                                                            if (Properties.Settings.Default.RoleID == 11 || Properties.Settings.Default.RoleID == 13 || Properties.Settings.Default.RoleID == 14)
                                                            {
                                                                page.Groups[j].ItemLinks[M].Visible = true;
                                                            }
                                                        }

                                                        if (page.Groups[j].ItemLinks[M].Caption == "Audit Report")
                                                        {
                                                            if (Properties.Settings.Default.RoleID == 11 || Properties.Settings.Default.RoleID == 13 || Properties.Settings.Default.RoleID == 14)
                                                            {
                                                                page.Groups[j].ItemLinks[M].Visible = true;
                                                            }
                                                        }
                                                        //else
                                                        //{
                                                        //    page.Groups[j].ItemLinks[M].Visible = false;
                                                        //}

                                                        if (page.Groups[j].ItemLinks[M].Caption == "Audit Master")
                                                        {
                                                            if (Properties.Settings.Default.RoleID == 11 || Properties.Settings.Default.RoleID == 13 || Properties.Settings.Default.RoleID == 14)
                                                            {
                                                                page.Groups[j].ItemLinks[M].Visible = true;
                                                            }
                                                        }
                                                        //else
                                                        //{
                                                        //    page.Groups[j].ItemLinks[M].Visible = false;
                                                        //}

                                                        if (page.Groups[j].ItemLinks[M].Caption == "Audit Category")
                                                        {
                                                            if (Properties.Settings.Default.RoleID == 11 || Properties.Settings.Default.RoleID == 13 || Properties.Settings.Default.RoleID == 14)
                                                            {
                                                                page.Groups[j].ItemLinks[M].Visible = true;
                                                            }
                                                        }
                                                        //else
                                                        //{
                                                        //    page.Groups[j].ItemLinks[M].Visible = false;
                                                        //}
                                                    }
                                                }

                                                else
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                            }
                                        }
                                        break;
                                    case "rbnpageTraining":
                                    case "rbnProdution":
                                    case "MaintenacePage":
                                    case "rbnPageReports":
                                    //case "rgnpageNRM":
                                    case "ribbonPage8":
                                    case "ribbonPage5":
                                    case "rbnPageDboard":
                                    case "rpgHelp":
                                    case "SearchRibbon":
                                        {
                                            page.Visible = true;
                                        }
                                        break;
                                    case "SettingRibbnPage":
                                        {
                                            //page.Visible = true;
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "rbnpageAutoSetting")
                                                {
                                                    for (int M = 0; M < page.Groups[j].ItemLinks.Count; M++)
                                                    {
                                                        if (page.Groups[j].ItemLinks[M].Caption == "Change Password")//||page.Groups[j].ItemLinks[M].Caption == "User Registration" || page.Groups[j].ItemLinks[M].Caption == "Manage User"
                                                        {
                                                            page.Groups[j].ItemLinks[M].Visible = true;
                                                        }
                                                        else
                                                        {
                                                            page.Groups[j].ItemLinks[M].Visible = false;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                            }

                                        }
                                        break;
                                    default:
                                        {
                                            page.Visible = false;
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    case RoleType.DepartmentUser:
                        {
                            if (GlobalDeclaration.FirstLogOut)// After LogAout Process
                            {
                                this.ribbon.Categories[1].Visible = true;
                            }
                            for (int i = 0; i < rgc.Count; i++)
                            {
                                RibbonPage page = rgc[i];
                                if (GlobalDeclaration.FirstLogOut)// After LogAout Process
                                {
                                    page.Visible = true;
                                }
                                switch (page.Name)
                                {
                                    case "ribbnpageHome":
                                        {
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "ribbonPageGroup3" || page.Groups[j].Name == "rbnFileGrp" || page.Groups[j].Name == "rbngrpExit")
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                                else
                                                {
                                                    page.Groups[j].Visible = false;
                                                }
                                            }
                                        }
                                        break;
                                    case "ViewRibbon":
                                        {
                                            page.Visible = true;
                                        }
                                        break;
                                    case "InvMNG":
                                    case "rbnpageEdit":
                                        {
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "rbnpageGRPEdit")
                                                {
                                                    for (int M = 0; M < page.Groups[j].ItemLinks.Count; M++)
                                                    {
                                                        if (page.Groups[j].ItemLinks[M].Caption == "Audit Report")
                                                        {
                                                            if (Properties.Settings.Default.RoleID == 11 || Properties.Settings.Default.RoleID == 13 || Properties.Settings.Default.RoleID == 14)
                                                            {
                                                                page.Groups[j].ItemLinks[M].Visible = true;
                                                            }

                                                        }
                                                        else
                                                        {
                                                            page.Groups[j].ItemLinks[M].Visible = false;
                                                        }
                                                        if (page.Groups[j].ItemLinks[M].GalleryBarItemName == "Audit Master")
                                                        {
                                                            if (Properties.Settings.Default.RoleID == 11 || Properties.Settings.Default.RoleID == 13 || Properties.Settings.Default.RoleID == 14)
                                                            {
                                                                page.Groups[j].ItemLinks[M].Visible = true;
                                                            }

                                                        }
                                                        //else
                                                        //{
                                                        //    page.Groups[j].ItemLinks[M].Visible = false;
                                                        //}
                                                        if (page.Groups[j].ItemLinks[M].GalleryBarItemName == "Audit Category")
                                                        {
                                                            if (Properties.Settings.Default.RoleID == 11 || Properties.Settings.Default.RoleID == 13 || Properties.Settings.Default.RoleID == 14)
                                                            {
                                                                page.Groups[j].ItemLinks[M].Visible = true;
                                                            }

                                                        }
                                                        //else
                                                        //{
                                                        //    page.Groups[j].ItemLinks[M].Visible = false;
                                                        //}
                                                    }


                                                }
                                                else
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                            }
                                        }
                                        break;
                                    case "rbnpageTraining":
                                    case "rbnProdution":
                                    case "MaintenacePage":
                                    case "rbnPageReports":
                                    //case "rgnpageNRM":
                                    case "ribbonPage8":
                                    case "ribbonPage5":
                                    case "rbnPageDboard":
                                    case "rpgHelp":
                                    case "SearchRibbon":
                                        {
                                            page.Visible = true;
                                        }
                                        break;
                                    case "SettingRibbnPage":
                                        {
                                            //page.Visible = true;
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "rbnpageAutoSetting")
                                                {
                                                    for (int M = 0; M < page.Groups[j].ItemLinks.Count; M++)
                                                    {
                                                        if (page.Groups[j].ItemLinks[M].Caption == "Change Password")//||page.Groups[j].ItemLinks[M].Caption == "User Registration" || page.Groups[j].ItemLinks[M].Caption == "Manage User"
                                                        {
                                                            page.Groups[j].ItemLinks[M].Visible = true;
                                                        }
                                                        else
                                                        {
                                                            page.Groups[j].ItemLinks[M].Visible = false;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                            }

                                        }
                                        break;
                                    default:
                                        {
                                            page.Visible = false;
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    case RoleType.TaskForce:
                        {
                            if (GlobalDeclaration.FirstLogOut)// After LogAout Process
                            {
                                this.ribbon.Categories[1].Visible = true;
                            }
                            for (int i = 0; i < rgc.Count; i++)
                            {
                                RibbonPage page = rgc[i];
                                if (GlobalDeclaration.FirstLogOut)// After LogAout Process
                                {
                                    page.Visible = true;
                                }
                                switch (page.Name)
                                {
                                    case "ribbnpageHome":
                                        {
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "ribbonPageGroup3" || page.Groups[j].Name == "rbnFileGrp" || page.Groups[j].Name == "rbngrpExit")
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                                else
                                                {
                                                    page.Groups[j].Visible = false;
                                                }
                                            }
                                        }
                                        break;
                                    case "ViewRibbon":
                                        {

                                            page.Visible = true;
                                        }
                                        break;
                                    case "InvMNG":
                                    case "rbnpageEdit":
                                    case "rbnpageTraining":
                                    case "rbnProdution":
                                    case "MaintenacePage":
                                    case "rbnPageReports":
                                    //case "rgnpageNRM":
                                    case "ribbonPage8":
                                    case "ribbonPage5":
                                    case "rbnPageDboard":
                                    case "rpgHelp":
                                    case "SearchRibbon":
                                        {
                                            page.Visible = true;
                                        }
                                        break;
                                    case "SettingRibbnPage":
                                        {
                                            //page.Visible = true;
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "rbnpageAutoSetting")
                                                {
                                                    for (int M = 0; M < page.Groups[j].ItemLinks.Count; M++)
                                                    {
                                                        if (page.Groups[j].ItemLinks[M].Caption == "Change Password")//||page.Groups[j].ItemLinks[M].Caption == "User Registration" || page.Groups[j].ItemLinks[M].Caption == "Manage User"
                                                        {
                                                            page.Groups[j].ItemLinks[M].Visible = true;
                                                        }
                                                        else
                                                        {
                                                            page.Groups[j].ItemLinks[M].Visible = false;
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                            }

                                        }
                                        break;
                                    default:
                                        {
                                            page.Visible = false;
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    case RoleType.CAPAUser:
                        {
                            if (GlobalDeclaration.FirstLogOut)// After LogAout Process
                            {
                                this.ribbon.Categories[1].Visible = true;
                            }
                            for (int i = 0; i < rgc.Count; i++)
                            {
                                RibbonPage page = rgc[i];
                                if (GlobalDeclaration.FirstLogOut)// After LogAout Process
                                {
                                    page.Visible = true;
                                }
                                switch (page.Name)
                                {
                                    case "ribbnpageHome":
                                        {
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "ribbonPageGroup3" || page.Groups[j].Name == "rbnFileGrp" || page.Groups[j].Name == "rbngrpExit")
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                                else
                                                {
                                                    page.Groups[j].Visible = false;
                                                }
                                            }
                                        }
                                        break;
                                    case "ViewRibbon":
                                        {



                                            page.Visible = true;
                                        }
                                        break;
                                    case "InvMNG":
                                    case "rbnpageEdit":
                                        {
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "rbnpageGRPEdit")
                                                {
                                                    for (int M = 0; M < page.Groups[j].ItemLinks.Count; M++)
                                                    {
                                                        if (page.Groups[j].ItemLinks[M].Caption == "Audit Report")
                                                        {
                                                            if (Properties.Settings.Default.RoleID == 11 || Properties.Settings.Default.RoleID == 13 || Properties.Settings.Default.RoleID == 14)
                                                            {
                                                                page.Groups[j].ItemLinks[M].Visible = true;
                                                            }



                                                        }
                                                        else
                                                        {
                                                            page.Groups[j].ItemLinks[M].Visible = false;
                                                        }
                                                        if (page.Groups[j].ItemLinks[M].GalleryBarItemName == "Audit Master")
                                                        {
                                                            if (Properties.Settings.Default.RoleID == 11 || Properties.Settings.Default.RoleID == 13 || Properties.Settings.Default.RoleID == 14)
                                                            {
                                                                page.Groups[j].ItemLinks[M].Visible = true;
                                                            }



                                                        }
                                                        //else
                                                        //{
                                                        //    page.Groups[j].ItemLinks[M].Visible = false;
                                                        //}
                                                        if (page.Groups[j].ItemLinks[M].GalleryBarItemName == "Audit Category")
                                                        {
                                                            if (Properties.Settings.Default.RoleID == 11 || Properties.Settings.Default.RoleID == 13 || Properties.Settings.Default.RoleID == 14)
                                                            {
                                                                page.Groups[j].ItemLinks[M].Visible = true;
                                                            }



                                                        }
                                                        //else
                                                        //{
                                                        //    page.Groups[j].ItemLinks[M].Visible = false;
                                                        //}
                                                    }




                                                }
                                                else
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                            }
                                        }
                                        break;
                                    case "rbnpageTraining":
                                    case "rbnProdution":
                                    case "MaintenacePage":
                                    case "rbnPageReports":
                                    //case "rgnpageNRM":
                                    case "ribbonPage8":
                                    case "ribbonPage5":
                                    case "rbnPageDboard":
                                    case "rpgHelp":
                                    case "SearchRibbon":
                                        {
                                            page.Visible = true;
                                        }
                                        break;
                                    case "SettingRibbnPage":
                                        {
                                            //page.Visible = true;
                                            for (int j = 0; j < page.Groups.Count; j++)
                                            {
                                                if (page.Groups[j].Name == "rbnpageAutoSetting")
                                                {
                                                    for (int M = 0; M < page.Groups[j].ItemLinks.Count; M++)
                                                    {
                                                        if (page.Groups[j].ItemLinks[M].Caption == "Change Password")//||page.Groups[j].ItemLinks[M].Caption == "User Registration" || page.Groups[j].ItemLinks[M].Caption == "Manage User"
                                                        {
                                                            page.Groups[j].ItemLinks[M].Visible = true;
                                                        }
                                                        else
                                                        {
                                                            page.Groups[j].ItemLinks[M].Visible = false;
                                                        }
                                                    }



                                                }
                                                else
                                                {
                                                    page.Groups[j].Visible = true;
                                                }
                                            }



                                        }
                                        break;
                                    default:
                                        {
                                            page.Visible = false;
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                }
                this.brstaticUsername.Caption = string.Format("Login User:{0}  User Type:{1} Department: {2} ", GlobalDeclaration.UserName, GlobalDeclaration.UserType, GlobalDeclaration._holdInfo[0].DepartmentName);
                if (!GlobalDeclaration.FirstLogOut)
                    MachineSunLayerLoadDt = Resources.Instance.GetDataKey("SP_FetchLayerDetails");
                if (MachineSunLayerLoadDt == null)
                    MachineSunLayerLoadDt = Resources.Instance.GetDataKey("SP_FetchLayerDetails");
                ContextMenuItemHideandShow(Rolestypes);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ContextMenuItemHideandShow(RoleType _roletype)
        {
            switch (_roletype)
            {
                case RoleType.Admin:
                    {
                        for (int i = 0; i < _ListOffFloor.Count; i++)
                        {
                            var _cadlayoutformObj = _ListOffFloor[i];
                            this.openEditMenuToolStripMenuItem.Visible = true;
                            this.createPackageMAchineToolStripMenuItem.Visible = true;
                            // this.machineTrainingInfoToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.addBreakDownToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.remoteConnectionToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.liveFeedDataToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.toolStripMenuItem1.Visible = false;
                            _cadlayoutformObj.changeMachineConfigurationToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.inputUtilityIssuesToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.viewConnectionToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.viewReportLineToolStripMenuItem.Visible = false;
                            // this.requestLOTOToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.copyMachineDataToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.getMachineReportToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.machineComplianceToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.generatePTWToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.assignJobToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.machineHistoryToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.reportAnIncidentToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.uploadedDocumentsToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.safetyDocsToolStripMenuItem.Visible = false;
                        }
                    }
                    break;
                case RoleType.User:
                    {
                        for (int i = 0; i < _ListOffFloor.Count; i++)
                        {
                            var _cadlayoutformObj = _ListOffFloor[i];
                            this.openEditMenuToolStripMenuItem.Visible = true;
                            // this.machineTrainingInfoToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.createPackageMAchineToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.addBreakDownToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.remoteConnectionToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.liveFeedDataToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.toolStripMenuItem1.Visible = false;
                            _cadlayoutformObj.changeMachineConfigurationToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.inputUtilityIssuesToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.viewConnectionToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.viewReportLineToolStripMenuItem.Visible = false;
                            // this.requestLOTOToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.copyMachineDataToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.getMachineReportToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.machineComplianceToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.generatePTWToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.assignJobToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.machineHistoryToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.reportAnIncidentToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.uploadedDocumentsToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.safetyDocsToolStripMenuItem.Visible = false;
                            dockPanel2.Visible = false;
                            dockPanel1.Visible = false;
                            this.dockPanel1.Width = 1;
                        }
                    }
                    break;
                case RoleType.Maintenance:
                    {
                        for (int i = 0; i < _ListOffFloor.Count; i++)
                        {
                            var _cadlayoutformObj = _ListOffFloor[i];
                            _cadlayoutformObj.openEditMenuToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.createPackageMAchineToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.addBreakDownToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.remoteConnectionToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.liveFeedDataToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.toolStripMenuItem1.Visible = true;
                            _cadlayoutformObj.changeMachineConfigurationToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.inputUtilityIssuesToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.viewConnectionToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.viewReportLineToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.copyMachineDataToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.getMachineReportToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.machineComplianceToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.generatePTWToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.assignJobToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.machineHistoryToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.reportAnIncidentToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.uploadedDocumentsToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.safetyDocsToolStripMenuItem.Visible = true;
                        }
                        //this.dockPanel2.Visibility= DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                        //this.dockPanel2.Width = 1;
                    }
                    break;
                case RoleType.Safety:
                    {
                        for (int i = 0; i < _ListOffFloor.Count; i++)
                        {
                            var _cadlayoutformObj = _ListOffFloor[i];
                            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                            this.dockPanel1.Width = 1;
                            //this.dockPanel1.Enabled = false;                                       
                            _cadlayoutformObj.openEditMenuToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.createPackageMAchineToolStripMenuItem.Visible = false;
                            // this.machineTrainingInfoToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.addBreakDownToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.remoteConnectionToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.liveFeedDataToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.toolStripMenuItem1.Visible = true;
                            _cadlayoutformObj.changeMachineConfigurationToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.inputUtilityIssuesToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.viewConnectionToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.viewReportLineToolStripMenuItem.Visible = true;
                            // this.requestLOTOToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.copyMachineDataToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.getMachineReportToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.machineComplianceToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.generatePTWToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.assignJobToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.machineHistoryToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.reportAnIncidentToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.uploadedDocumentsToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.safetyDocsToolStripMenuItem.Visible = true;
                        }

                    }
                    break;
                case RoleType.Operation:
                    {
                        for (int i = 0; i < _ListOffFloor.Count; i++)
                        {
                            var _cadlayoutformObj = _ListOffFloor[i];

                            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                            this.dockPanel1.Width = 1;
                            //this.dockPanel1.Enabled = false;
                            _cadlayoutformObj.openEditMenuToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.createPackageMAchineToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.addBreakDownToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.remoteConnectionToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.liveFeedDataToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.toolStripMenuItem1.Visible = true;
                            // this.machineTrainingInfoToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.changeMachineConfigurationToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.inputUtilityIssuesToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.viewConnectionToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.viewReportLineToolStripMenuItem.Visible = true;
                            //  this.requestLOTOToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.copyMachineDataToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.getMachineReportToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.machineComplianceToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.generatePTWToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.assignJobToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.machineHistoryToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.reportAnIncidentToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.uploadedDocumentsToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.safetyDocsToolStripMenuItem.Visible = true;
                        }
                    }
                    break;
                case RoleType.Corporate:
                case RoleType.CommiteeHead:
                case RoleType.CommiteeMember:
                case RoleType.DepartmentHead:
                case RoleType.DepartmentUser:
                case RoleType.TaskForce:
                    {
                        for (int i = 0; i < _ListOffFloor.Count; i++)
                        {
                            var _cadlayoutformObj = _ListOffFloor[i];
                            _cadlayoutformObj.openEditMenuToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.createPackageMAchineToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.addBreakDownToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.remoteConnectionToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.liveFeedDataToolStripMenuItem.Visible = false;
                            _cadlayoutformObj.toolStripMenuItem1.Visible = true;
                            _cadlayoutformObj.changeMachineConfigurationToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.inputUtilityIssuesToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.viewConnectionToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.viewReportLineToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.copyMachineDataToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.getMachineReportToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.machineComplianceToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.generatePTWToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.assignJobToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.machineHistoryToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.reportAnIncidentToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.uploadedDocumentsToolStripMenuItem.Visible = true;
                            _cadlayoutformObj.safetyDocsToolStripMenuItem.Visible = true;
                        }
                        this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                        this.dockPanel1.Width = 1;
                    }
                    break;
            }
        }
        #endregion

        #region CAD Add Entities               
        private List<string> IconList(string FolderName, string Subfolder)
        {
            List<String> filesFound = new List<String>();
            try
            {
                string path = string.Empty;
                if (!string.IsNullOrEmpty(IniFile.IniReadValue("DBConfig", "FolderPath")))
                    path = IniFile.IniReadValue("DBConfig", "FolderPath");
                path = path + "\\" + "Images\\" + FolderName + "\\" + Subfolder;
                if (Directory.Exists(path))
                {

                    var filters = new String[] { "jpeg", "png", "gif", "bmp", "icon", "svg" };
                    string[] files = Directory.GetFiles(path, String.Format("*.{0}", filters));
                    foreach (string filter in filters)
                    {
                        filesFound.AddRange(Directory.GetFiles(path, String.Format("*.{0}", filter)));
                    }
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Selected Sub-Layer-" + FolderName + "\n Does Not Exist In Application Path", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.StackTrace, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return filesFound;
        }
        private void Eventload()
        {
            try
            {
                foreach (Control c in this.loadpanelpng.Controls)
                {
                    c.MouseDown += new MouseEventHandler(c_MouseDown);
                }
                for (int i = 0; i < _ListOffFloor.Count; i++)
                {
                    var frmname = _ListOffFloor[i];
                    frmname.cadPictBox.AllowDrop = true;
                    frmname.cadPictBox.DragOver += new DragEventHandler(loadpanelpng_DragOver);
                }
                this.loadpanelpng.AllowDrop = true;                
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void c_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                Control c = sender as Control;
                for (int i = 0; i < _ListOffFloor.Count; i++)
                {
                    var mulCadLayout = _ListOffFloor[i];
                    mulCadLayout.DragfileName  = ((Button)c).Image;
                    mulCadLayout.SetMachineName = ((Button)c).Text;
                }
                c.DoDragDrop(c, DragDropEffects.Move);
                for (int i = 0; i < _ListOffFloor.Count; i++)
                {
                    var mulCadLayout = _ListOffFloor[i];
                    mulCadLayout.SetMachineName = SetMachineName = string.Empty;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EventUnBibd()
        {
            try
            {
                foreach (Control c in this.loadpanelpng.Controls)
                {
                    c.MouseDown -= new MouseEventHandler(c_MouseDown);
                }
                for (int i = 0; i < _ListOffFloor.Count; i++)
                {
                    var mulCadLayout = _ListOffFloor[i];
                    mulCadLayout.cadPictBox.DragOver -= new DragEventHandler(loadpanelpng_DragOver);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Main Window Event Fire
        private void ParentWindow_Deactivate(object sender, EventArgs e)
        {

        }
        private void ParentWindow_SomeEvent(params object[] args)
        {
            DPoint _points = ((DPoint)args[0]);
            List<string> OpenFormNameList = Application.OpenForms.Cast<Form>().Select(f => f.Name).ToList();
            for (int i = 0; i < OpenFormNameList.Count; i++)
            {
                string FrmName = OpenFormNameList[i];               
            }
        }
        private void batbtnAppsetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (e.Item.Tag == null) return;
                switch (e.Item.Tag.ToString())
                {
                    case "AppSetting":
                        {
                            DBConfiguration SW = new DBConfiguration();
                            if (DialogResult.OK == SW.ShowDialog())
                            {
                                SW.Close();
                            }
                        }
                        break;
                    case "Password":
                        {
                            frmRecoverPassword chgpas = new frmRecoverPassword();
                            chgpas.Show();
                        }
                        break;
                    case "Registration":
                        {
                            frmRegistration reg = new frmRegistration();
                            reg.CallFrmName = "Admin";
                            reg.IsFirstCall = false;
                            reg.Show();
                        }
                        break;
                    case "Manage":
                        {
                            frmManageUsers mngusr = new frmManageUsers();
                            mngusr.Show();
                        }
                        break;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Add Break Down Machine Call
        public void AddBreakDownCall(object sender, EventArgs e)
        {

        }
        #endregion        
        private void ParentWindow_Shown(object sender, EventArgs e)
        {
            FixedColor();
            FindVersion();
        }
        private void brbtnColordrw_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var _cadLayoutGroud = _ListOffFloor.AsEnumerable().Where(X => X.IsActivated == dockPanel3.ActiveDocument.DockHandler.IsActivated).FirstOrDefault();
                if (_cadLayoutGroud == null) return;
                if (_cadLayoutGroud.cadImage == null) return;
                if (e.Item.Tag.ToString() == null) return;
                switch (e.Item.Tag.ToString())
                {
                    case "Normal":
                        _cadLayoutGroud.DoNormalColor();
                        break;
                    case "white":
                        _cadLayoutGroud.White_Click();
                        break;
                    case "Black":
                        _cadLayoutGroud.DoBlackColor();
                        break;
                    case "BlackG":
                        _cadLayoutGroud.Black_Click();
                        break;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void brbtntenper_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var _cadLayoutGroud = _ListOffFloor.AsEnumerable().Where(X => X.IsActivated == dockPanel3.ActiveDocument.DockHandler.IsActivated).FirstOrDefault();
                if (_cadLayoutGroud == null) return;
                if (_cadLayoutGroud.cadImage == null)
                    return;
                float i = _cadLayoutGroud.cADProperty.ImageScale;
                switch (int.Parse(e.Item.Tag.ToString()))
                {
                    case 0:
                        i = 0.1f;
                        break;
                    case 1:
                        i = 0.25f;
                        break;
                    case 2:
                        i = 0.5f;
                        break;
                    case 3:
                        i = 1.0f;
                        break;
                    case 4:
                        i = 2.0f;
                        break;
                    case 5:
                        i = 4.0f;
                        break;
                    case 6:
                        i = 8.0f;
                        break;
                }
                _cadLayoutGroud.ResetScaling();
                _cadLayoutGroud.cADProperty.PreviousPosition = new PointF(_cadLayoutGroud.cadPictBox.ClientRectangle.Width / 2.0f, _cadLayoutGroud.ClientRectangle.Height / 2.0f);
                _cadLayoutGroud.cADProperty.ImageScale = i;
                _cadLayoutGroud.cadPictBox.Invalidate();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dockPanel1_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Ok");
        }
        private void cmbMachineType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                    string TypeNAme = cmbMachineType.SelectedItem.ToString();
                    CMBmtype = cmbMachineType.Text;
                    if (MachineSunLayerLoadDt.Rows.Count > 0)
                    {
                        Iscall = true;
                        DataRow[] Dr = MachineSunLayerLoadDt.Select("LayerName='" + CMBmtype.Trim() + "'");
                        if (Dr.Length > 0)
                        {
                            cmbsubtype.Items.Clear();
                            for (int i = 0; i < Dr.Count(); i++)
                            {
                                cmbsubtype.Items.Add(Dr[i]["SubLayer"]);
                            }
                            cmbsubtype.SelectedIndex = 1;
                        }
                    }
                    else
                    {
                        cmbsubtype.DataSource = null;
                        // cmbsubtype.Items.Clear();
                    }
                
                //if (this.package != null) // This line for Refresh ImagePath Hold Dictorinary when Sublayer Type Change
                //    this.package._HoldImagePat = _HoldImagePat;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Cmbsubtype_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string Subfolder = string.Empty;
                string FolderName = string.Empty;
                if (cmbsubtype.SelectedItem == null || cmbMachineType.SelectedItem == null) return;
                if (Iscall)
                {
                    Subfolder = cmbsubtype.SelectedItem.ToString(); //((System.Data.DataRowView)cmbsubtype.SelectedItem).Row.ItemArray[0].ToString();
                    FolderName = cmbMachineType.SelectedItem.ToString();
                    cmbCtype = cmbsubtype.SelectedItem.ToString();
                    // Iscall = false;                    
                }
                else
                {
                    Subfolder = cmbsubtype.SelectedItem.ToString().Trim();
                    FolderName = cmbMachineType.SelectedItem.ToString();
                }
                if (!string.IsNullOrEmpty(FolderName) && !string.IsNullOrEmpty(Subfolder))
                {
                    List<string> _lisicon = IconList(FolderName, Subfolder);
                    if (loadpanelpng.Controls.Count > 0)
                    {
                        loadpanelpng.Controls.Clear();
                        // _HoldImagePat.Clear();
                        EventUnBibd();
                    }
                    if (_lisicon.Count() > 0)
                    {
                        for (int i = 0; i < _lisicon.Count; i++)
                        {
                            string FilePathName = _lisicon[i];
                            loadpanelpng.AllowDrop = true;
                            System.IO.StreamReader sr = new
                            System.IO.StreamReader(FilePathName);                            
                            Button btn = new Button();
                            btn.Tag = i;
                            var iconame = IconPath(FilePathName);
                            System.Drawing.Image img = System.Drawing.Image.FromFile(FilePathName);
                            btn.Image = img;
                            btn.ImageAlign = ContentAlignment.MiddleRight;
                            btn.TextAlign = ContentAlignment.BottomCenter;
                            btn.FlatStyle = FlatStyle.Popup;
                            btn.Size = new Size(126, 126);
                            btn.ForeColor = System.Drawing.Color.White;
                            btn.BackColor = System.Drawing.Color.LightGray;
                            btn.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            btn.Name = "btn" + iconame.Item2;
                            btn.Text = iconame.Item2;
                            btn.UseCompatibleTextRendering = true;
                            sr.Close();
                            loadpanelpng.Controls.Add(btn);
                            for (int j = 0; j < _ListOffFloor.Count; j++)
                            {
                                var frmname = _ListOffFloor[j];
                                if (!frmname._HoldImagePat.ContainsKey(iconame.Item2))
                                {
                                    frmname._HoldImagePat.TryAdd(iconame.Item2, iconame.Item1);
                                    _HoldImagePat.TryAdd(iconame.Item2, iconame.Item1);
                                }
                                else
                                {
                                    string holdKey = btn.Text + "1";
                                    frmname._HoldImagePat.TryAdd(holdKey, iconame.Item1);
                                    _HoldImagePat.TryAdd(iconame.Item2, iconame.Item1);
                                }
                            }
                        }
                        Eventload();
                        // this Line Package Machine ,If Package Machine Already Open then Pass Laod Dic to PackageMachine Dic
                        //if (package != null)
                        //    package._HoldImagePat = this._HoldImagePat;
                    }
                    else
                    {
                        loadpanelpng.Controls.Clear();
                        EventUnBibd();
                        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "No Icons Found..", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;

                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string txtValue = txtsearch.Text.Trim().ToUpper();
            if (!string.IsNullOrEmpty(txtValue))
            {
                if (loadpanelpng.Controls.Count > 0)
                {
                    Searchctrl(txtsearch.Text.Trim());
                }
            }
        }
        private void Searchctrl(string txtvalue)
        {
            foreach (Control ctrlimg in loadpanelpng.Controls)
            {
                if (ctrlimg.GetType() == typeof(Button))
                {
                    Button ControlSer = (Button)ctrlimg;
                    if (!ControlSer.Text.ToLower().Contains(txtvalue.ToLower()))
                    {
                        ControlSer.Visible = false;
                    }
                    else
                    {
                        ControlSer.Visible = true;
                    }
                }
            }
            this.loadpanelpng.Refresh();
        }
        private void ParentWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string linefilename = string.Empty;
                bool IsStatus = false;
                bool LineStatus = false;
                string FolderPth = IniFile.IniReadValue("DBConfig", "FolderPath");
                string fileextentiontype = IniFile.IniReadValue("DBConfig", "FileExtension").Trim();
                if (fileextentiontype == ".spr")
                {
                    fileextentiontype = ".spr";
                    linefilename = "LC.spr";
                }
                else
                {
                    fileextentiontype = ".xml";
                    linefilename = "LC.xml";
                }
                string fileName = AppDomain.CurrentDomain.BaseDirectory + "CadLayoutInfo.xml";////String.Format(@"{0}\type1.txt", Application.StartupPath);
                if (dockPanel3.Contents.Count > 0)
                {
                    dockPanel3.SaveAsXml(fileName);
                    string ReceiveFileName = string.Empty;
                    var contentlist = dockPanel3.Contents.ToList();
                    for (int i = 0; i < contentlist.Count; i++)
                    {
                        var frmname = contentlist[i];
                        ReceiveFileName = string.Concat(ReceiveFileName, frmname.DockHandler.TabText, ".dxf", "|");
                    }
                    ReceiveFileName = ReceiveFileName.Remove(ReceiveFileName.Length - 1);
                    IniFile.IniWriteValue("DBConfig", "FileName", ReceiveFileName);
                }
                else
                {
                    if (File.Exists(fileName))
                        File.Delete(fileName);

                    string DxfFilename = IniFile.IniReadValue("DBConfig", "FileName");
                    string[] lst = DxfFilename.Split('|');
                    for (int i = 0; i < lst.Length; i++)
                    {
                        string FileName = lst[i];
                        string path = string.Concat(FolderPth, @"\", "SparrowCAD", @"\", FileName);
                        string filenameconnector = string.Concat(FolderPth, @"\", "SparrowCAD", @"\", FileName.Split('.')[0], "Dxf", fileextentiontype);
                        string CadMachineTagList = string.Concat(FolderPth, @"\", "SparrowCAD", @"\", FileName.Split('.')[0], fileextentiontype);
                        if (File.Exists(path))//.Dxf File Delete
                            File.Delete(path);

                        if (File.Exists(filenameconnector))//Dxf.Spr File Delete
                            File.Delete(filenameconnector);

                        if (File.Exists(CadMachineTagList))//.Spr File Delete
                            File.Delete(CadMachineTagList);

                        string lineConnectorFile = string.Concat(FolderPth, @"\", "SparrowCAD", @"\", FileName.Split('.')[0], "~", linefilename);

                        if (File.Exists(lineConnectorFile))// Line Connector File Delete
                            File.Delete(lineConnectorFile);

                        string OffSetFile = string.Concat(FolderPth, @"\", "SparrowCAD", @"\", FileName.Split('.')[0], "~", "OffSet", ".spr");
                        if (File.Exists(OffSetFile))// OffSet File Directory  Delete
                            File.Delete(OffSetFile);
                    }
                    IniFile.IniWriteValue("DBConfig", "FileName", "");
                }
                Resources.Instance.DIsposeDT();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region Ribbon Control Event
        private void ie(object sender, ItemClickEventArgs e)
        {

        }
        private void FixedColor()
        {
            SkinElement element = SkinManager.GetSkinElement(SkinProductId.Ribbon, DevExpress.LookAndFeel.UserLookAndFeel.Default, "FormCaption");
            SkinElement tbelementTabHeaderBackground = SkinManager.GetSkinElement(SkinProductId.Ribbon, DevExpress.LookAndFeel.UserLookAndFeel.Default, "TabHeaderBackground");
            SkinElement tabSkinElement = SkinManager.GetSkinElement(SkinProductId.Ribbon, UserLookAndFeel.Default, "TabPanel");
            element.Color.BackColor = Color.FromArgb(39, 108, 199);
            element.Color.SolidImageCenterColor = Color.FromArgb(39, 108, 199);
            element.Image.Image = null;
            element.Color.SolidImageCenterColor = Color.FromArgb(39, 108, 199);
            element.Color.SolidImageCenterColor = Color.FromArgb(39, 108, 199);
            //tbelementTabHeaderBackground.Color.SolidImageCenterColor = Color.FromArgb(40, 103, 178);
            // tbelementTabHeaderBackground.Color.SolidImageCenterColor = Color.FromArgb(40, 103, 178);
            // tabSkinElement.Color.SolidImageCenterColor = Color.FromArgb(40, 103, 178);
            //tabSkinElement.Color.SolidImageCenterColor = Color.FromArgb(40, 103, 178);
            LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
        }
        private void AddBarItesm()
        {
            this.biStyle = new DevExpress.XtraBars.BarEditItem();
            this.riicStyle = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.riicStyle)).BeginInit();
            this.biStyle.Caption = "Ribbon Style: ";
            this.biStyle.Edit = this.riicStyle;
            this.biStyle.EditWidth = 75;
            this.biStyle.Hint = "Ribbon Style";
            this.biStyle.Id = 106;
            this.biStyle.Name = "biStyle";
            this.biStyle.VisibleInSearchMenu = false;
            //this.biStyle.EditValueChanged += new System.EventHandler(this.biStyle_EditValueChanged);
            this.ribbon.PageHeaderItemLinks.Add(this.biStyle);
            this.riicStyle.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.riicStyle.Appearance.Options.UseFont = true;
            this.riicStyle.AutoHeight = false;
            this.riicStyle.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riicStyle.Name = "riicStyle";
            ((System.ComponentModel.ISupportInitialize)(this.riicStyle)).EndInit();

            this.beScheme = new DevExpress.XtraBars.BarEditItem();
            this.beScheme.Caption = "Color Scheme: ";
            // this.beScheme.Edit = this.repositoryItemComboBox1;
            this.beScheme.EditWidth = 75;
            this.beScheme.Id = 188;
            this.beScheme.Name = "beScheme";
            this.beScheme.EditValueChanged += new System.EventHandler(this.beScheme_EditValueChanged);
        }

        private void biStyle_EditValueChanged(object sender, EventArgs e)
        {
            RibbonControlStyle style = (RibbonControlStyle)biStyle.EditValue;
            ribbon.RibbonStyle = style;
            ribbon.ApplicationButtonDropDownControl = style == RibbonControlStyle.Office2007;// ? (object)pmAppMain : this.backstageViewControl1;
            if (style == RibbonControlStyle.TabletOffice || style == RibbonControlStyle.OfficeUniversal)
            {
                this.barToggleSwitchItem1.Visibility = BarItemVisibility.Always;
            }
            else
            {
                this.barToggleSwitchItem1.Visibility = BarItemVisibility.Never;
            }
            //UpdateSchemeCombo();
            UpdateLookAndFeel();
        }
        void UpdateSchemeCombo()
        {
            RibbonControlStyle style = ribbon.RibbonStyle;
            if (style == RibbonControlStyle.MacOffice || style == RibbonControlStyle.Office2010 || style == RibbonControlStyle.Office2013 || style == RibbonControlStyle.Default)
                beScheme.Visibility = UserLookAndFeel.Default.ActiveSkinName.Contains("Office") ? BarItemVisibility.Always : BarItemVisibility.Never;
            else beScheme.Visibility = BarItemVisibility.Never;
        }
        void CreateDocumentManager()
        {
            DocumentManager dm = new DocumentManager();
            dm.MdiParent = this;
            dm.View = new NativeMdiView();
        }
        private RibbonPageGroup GetTargetGroup(RibbonPage page)
        {
            return page.Groups[0];
        }
        void UpdateLookAndFeel()
        {
            string skinName;
            RibbonControlStyle style = ribbon.RibbonStyle;
            switch (style)
            {
                case RibbonControlStyle.Default:
                    skinName = "Office 2016 Colorful";
                    break;
                case RibbonControlStyle.Office2019:
                    skinName = "Office 2019 Colorful";
                    break;
                case RibbonControlStyle.Office2007:
                    skinName = "Office 2007 Blue";
                    break;
                case RibbonControlStyle.Office2013:
                case RibbonControlStyle.TabletOffice:
                case RibbonControlStyle.OfficeUniversal:
                    skinName = "Office 2013";
                    break;
                case RibbonControlStyle.Office2010:
                case RibbonControlStyle.MacOffice:
                default:
                    skinName = "Office 2010 Blue";
                    break;
            }
            UserLookAndFeel.Default.SetSkinStyle(skinName);
        }
        private void brbtnConnt_ItemClick(object sender, ItemClickEventArgs e)
        {
            string Tage = e.Item.Tag.ToString();
            var _cadLayoutGroud = _ListOffFloor.AsEnumerable().Where(X => X.IsActivated == dockPanel3.ActiveDocument.DockHandler.IsActivated).FirstOrDefault();
            if (_cadLayoutGroud == null) return;
            var CadName = _cadLayoutGroud.cadImage.SelectedEntities.AsEnumerable().FirstOrDefault();
            if (CadName != null)
            {
                if (CadName.EntType == EntityType.Polyline)
                {
                    string MachineName = _cadLayoutGroud.MachineName(CadName);
                    CadName.Selected = true;
                }
                //MC.Show();
            }
            _cadLayoutGroud.ClearSelection();
        }
        private void beScheme_EditValueChanged(object sender, EventArgs e)
        {
            ribbon.ColorScheme = ((RibbonControlColorScheme)beScheme.EditValue);
        }
        private void ribbon_Click(object sender, EventArgs e)
        {

        }
        private void ParentWindow_Load(object sender, EventArgs e)
        {
            try
            {
                PlantLayout = new PlantLayout();
                PlantLayout._FormClosed += LayoutFormRemove;
                Resources.Instance.callMethod();
                this.pmMain.MenuAppearance.MenuBar.BackColor = Color.FromArgb(105, 133, 230);
                //this.accordionContentContainer1.Enabled = false;
                //timerTaskReload.Enabled = true;
                if (isParent == true && RoleType.Admin == (RoleType)HindalcoiOS.Properties.Settings.Default.RoleID)
                {
                    dockPanel2.Visible = false;
                    pnlReload.Visible = false;
                }
                else
                {
                    if (RoleType.Admin != (RoleType)HindalcoiOS.Properties.Settings.Default.RoleID && RoleType.User != (RoleType)HindalcoiOS.Properties.Settings.Default.RoleID)
                    {

                        dockPanel2.Visible = false;
                        pnlReload.Visible = false;
                        Disableopenbutton();
                        // KeySafetyHandlerEvent()
                        //GetUserNotification();
                    }

                }
                DockingXmlLoad();
                HindalcoiOS.AuditHind.AuditHelper.GenerateToken();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            // CreateDocumentManager();
        }
        private void Disableopenbutton()
        {
            ////these disable for all uses except Admin.
            sbiSave.Enabled = false;
            iSave.Enabled = false;
            iSaveAs.Enabled = false;
            idNew.Enabled = false;
            brbtnDelete.Enabled = false;
            brbtnRedo.Enabled = false;
            brbtnUndo.Enabled = false;
        }
        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Dialog)
            {
                switch (XtraMessageBox.Show("Are you sure? \n Do you  want Close App... ?", ApplicationConstants.MessageDisplay, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    //Stay on this form
                    case DialogResult.Yes:
                        {
                           // SaveAsDwg("", false);
                            YesDailog = true;
                            this.Close();
                        }
                        break;
                    default:

                        break;
                }
            }
            else
            {
                switch (XtraMessageBox.Show("Are you sure? \n Do you  want LogOut App.", ApplicationConstants.MessageDisplay, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    //Stay on this form
                    case DialogResult.Yes:
                        {
                            FormCollection fc = Application.OpenForms;//ParentWindow
                            foreach (Form frm in fc)
                            {
                                if (frm.Name != "ParentWindow" && frm.Name != "mulCadLayout")
                                {
                                    MessageBox.Show("Please Close the Open form " + frm.Name + "", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK,
               MessageBoxIcon.Warning,
               MessageBoxDefaultButton.Button1,
               MessageBoxOptions.DefaultDesktopOnly);
                                    return;
                                }
                            }
                            LoginPanel fLogin = new LoginPanel();
                            fLogin.txtEmail.Text = HindalcoiOS.Properties.Settings.Default.Email;
                            GlobalDeclaration._holdInfo.Clear();
                            //fLogin.TopMost = true;
                            if (dockPanel3.Contents.Count > 0)
                            {
                                var currentActiveFormName = _ListOffFloor.AsEnumerable().ToList();//.Where(X => X.IsActivated == dockPanel3.ActiveDocument.DockHandler.IsActivated).FirstOrDefault();
                                foreach (var item in currentActiveFormName)
                                {
                                    item.ClearAllDictionayObject();
                                }
                            }

                            GlobalDeclaration.FirstLogOut = true;
                            if (this.OnAfterLogOut == null)
                                this.OnAfterLogOut += OnAfterLogOutReCall;
                            this.Hide();
                            fLogin.Show();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// this Method Use for when user Logout Existing Object then Re-login again .call default all setting again
        /// </summary>
        /// <param name="sender"> Calling Location</param>
        /// <param name="call"> Parameter value </param>
        public void OnAfterLogOutReCall(object sender, string call)
        {
            this.ribbon.Refresh();
            this.LoadDefaultSetting();
            RoleType roleType = (RoleType)HindalcoiOS.Properties.Settings.Default.RoleID;
            ContextMenuItemHideandShow(roleType);
            if (!string.IsNullOrEmpty(IniFile.IniReadValue("DBConfig", "AutoCADStatus")))
            {
                bool STS = bool.Parse(IniFile.IniReadValue("DBConfig", "AutoCADStatus"));
                if (STS)
                {
                    AutoLoadCCAD(true);
                }
            }
            switch (roleType)
            {
                case RoleType.Admin:
                    {
                        this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                        dockPanel2.Visible = false;
                        pnlReload.Visible = false;
                        sbiSave.Enabled = true;
                    }
                    break;
                case RoleType.User:
                    {
                        this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                        dockPanel2.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                        pnlReload.Visible = false;
                        sbiSave.Enabled = false;
                    }
                    break;
                default:
                    {
                        dockPanel2.Visible = false;
                        pnlReload.Visible = false;
                        Disableopenbutton();
                    }
                    break;
            }                         
        }
        private void iOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (e.Item.Tag == null) return;
                switch (e.Item.Tag.ToString().ToUpper())
                {
                    case "NEW":
                        {
                            if (DialogResult.OK == PlantLayout.ShowDialog())
                            {
                                CreateDockingForm(int.Parse(PlantLayout.NumberOfPlant.ToString()));
                                ContextMenuItemHideandShow((RoleType)HindalcoiOS.Properties.Settings.Default.RoleID);//ContextMenuItemsListHideAndShow
                            }
                        }
                        break;
                    case "OPEN":
                        {
                            if (dockPanel3.Contents.Count > 0)
                            {
                                var obj = _ListOffFloor.AsEnumerable().Where(X => X.TabText == dockPanel3.ActiveDocument.DockHandler.TabText).FirstOrDefault();
                                if (obj == null) return;
                                bool IsLoadStaus = false;
                                string filename = string.Empty;
                                obj.ShowLoadFileDialog(ref IsLoadStaus, ref filename);
                                iClose.Enabled = true;
                                obj.ChangeControlState();   
                                stBar.Caption = obj.StatusCaption;
                                string Filelocation = GlobalDeclaration.ReturnPath();
                                Filelocation = Path.Combine(Filelocation, "SparrowCAD");
                                if (dockPanel3.ActiveDocument.DockHandler.TabText == obj.TabText)
                                {
                                    if (!PlantLayout._FormName.Contains(obj.TabText))
                                    {
                                        int levelcount = 0;
                                        if (PlantLayout.Controls.OfType<TextBox>().Count() == 0)
                                        {
                                            levelcount = 1;
                                        }
                                        else
                                        {
                                            levelcount = PlantLayout.Controls.OfType<TextBox>().Count();
                                            levelcount++;
                                        }
                                        int textboxcout = PlantLayout.Controls.OfType<TextBox>().Count();
                                        PlantLayout.AdddynamicCTRL("", levelcount);//"ReloadDocking", dockPanel3.Contents.Count
                                        var floortextbox = PlantLayout.Controls.OfType<TextBox>().ToList();
                                        floortextbox[textboxcout].Text = dockPanel3.ActiveDocument.DockHandler.TabText;
                                        PlantLayout.prevValue = decimal.Parse(PlantLayout.Controls.OfType<TextBox>().Count().ToString());
                                        PlantLayout._FormName.Add(obj.TabText);
                                    }
                                }
                                //OffSet Restore---------------
                                if (File.Exists(Filelocation + @"\" + obj.TabText + "~OffSet" + ".spr"))
                                {
                                    offsetDict = GlobalDeclaration.LoadOffSet(Filelocation + @"\" + obj.TabText + "~OffSet" + ".spr");
                                    _ListOffFloor.AsEnumerable().Where(X => X.TabText != offsetForm).FirstOrDefault().offsetDict = offsetDict;
                                    //GlobalDeclaration._MyTagDictinary = GlobalDeclaration.LoadMachineTag(Filelocation + @"\" + FileName + "~MTag" + ".dat");
                                }
                                if ((RoleType)HindalcoiOS.Properties.Settings.Default.RoleID == RoleType.Admin
               || (RoleType)HindalcoiOS.Properties.Settings.Default.RoleID == RoleType.User)
                                {
                                    barToggleSwitchItem1.Checked = true;
                                }
                                cmbMachineType.Enabled = true;
                                cmbsubtype.Enabled = true;
                            }
                        }
                        break;
                    case "CLOSE":
                        {
                            // ClearAllDictionayObject();
                            //CallEventfrm callEventfrm = new CallEventfrm();
                            //if(callEventfrm.ShowDialog()==DialogResult.OK)
                            //{
                            //    callEventfrm.Close();
                            //}
                            if (dockPanel3.Contents.Count > 0)
                            {
                                _ListOffFloor.AsEnumerable().Where(X => X.TabText == dockPanel3.ActiveDocument.DockHandler.TabText).FirstOrDefault().ClearAllDictionayObject();
                                cmbMachineType.Enabled = false;
                                cmbsubtype.Enabled = false;
                                loadpanelpng.Controls.Clear();
                            }
                        }
                        break;
                    case "PRINT":
                        {
                            if (dockPanel3.Contents.Count > 0)
                                _ListOffFloor.AsEnumerable().Where(X => X.TabText == dockPanel3.ActiveDocument.DockHandler.TabText).FirstOrDefault().PrintPreview();
                        }
                        break;

                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        string[] lst = null;
        private void DockingXmlLoad()
        {
            try
            {
                string defaultpath = string.Empty;
                if (!string.IsNullOrEmpty(IniFile.IniReadValue("DBConfig", "FileName")))
                {
                    defaultpath = IniFile.IniReadValue("DBConfig", "FileName");
                }
                string filename = Path.Combine(Application.StartupPath, "CadLayoutInfo.xml");
                if (File.Exists(filename))
                {
                    lst = defaultpath.Split('|');
                    DeserializeDockContent ddContent = new DeserializeDockContent(GetContentFromPersistString);
                    dockPanel3.LoadFromXml(filename, ddContent);
                    if (!string.IsNullOrEmpty(IniFile.IniReadValue("DBConfig", "AutoCADStatus")))
                    {
                        bool STS = bool.Parse(IniFile.IniReadValue("DBConfig", "AutoCADStatus"));
                        if (STS)
                        {
                            AutoLoadCCAD(true);
                            if ((RoleType)HindalcoiOS.Properties.Settings.Default.RoleID == RoleType.Admin
               || (RoleType)HindalcoiOS.Properties.Settings.Default.RoleID == RoleType.User)
                            {
                                barToggleSwitchItem1.Checked = true;
                            }
                            cmbMachineType.Enabled = true;
                            cmbsubtype.Enabled = true;
                            cmbMachineType.SelectedIndex = 0;
                            cmbsubtype.SelectedIndex = 1;
                            if (dockPanel3.Contents.Count > 0)//autoload cad layout refill image icon
                            {
                                for (int i = 0; i < dockPanel3.Contents.Count; i++)
                                {
                                    var dockingpanel = dockPanel3.Contents[i];
                                   var layoutobject= _ListOffFloor.AsEnumerable().Where(X => X.TabText == lst[i].Split('.')[0]).FirstOrDefault();
                                    var CadImageEntityCollection = layoutobject.cadImage.Converter.Entities.AsEnumerable().OfType<CADImageEnt>().ToList();
                                    foreach (var item in CadImageEntityCollection)
                                    {
                                        var iconame = IconPath(item.ImageDef.FileName);
                                        if (!layoutobject._HoldImagePat.ContainsKey(iconame.Item1))
                                        {
                                            layoutobject._HoldImagePat.TryAdd(iconame.Item2, iconame.Item1);
                                        }
                                        else
                                        {
                                            layoutobject._HoldImagePat.TryAdd(iconame.Item1 + "1", iconame.Item2);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    ContextMenuItemHideandShow((RoleType)HindalcoiOS.Properties.Settings.Default.RoleID);
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Tuple<string, string> IconPath(string imagepath)
        {
            string FileName = imagepath;
            string[] s = (FileName.ToString()).Split('\\');
            int count = s.Length;
            string iconName = s[count - 1].Split('.')[0];
            return new Tuple<string, string>(FileName, iconName);
        }
        private void brbtnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dockPanel3.Contents.Count > 0)
            {
                //if (!barToggleSwitchItem1.Checked)
                //{
                //    XtraMessageBox.Show("Sorry you can't remove any entities from the layout.\n" +
                //        "please unlock layout first.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                var currentActiveFormName = _ListOffFloor.AsEnumerable().Where(X => X.IsActivated == dockPanel3.ActiveDocument.DockHandler.IsActivated).FirstOrDefault();
                if (currentActiveFormName == null) return;
                if (currentActiveFormName.cadImage == null) return;
                currentActiveFormName.RemoveEntity();
                currentActiveFormName.stopSnap = true;
            }
        }
        private void brbtn_EditSetting(object sender, ItemClickEventArgs e)
        {
            try
            {
                
                if (e.Item.Tag == null) return;
                var _cadLayoutGroud = _ListOffFloor.AsEnumerable().Where(X => X.IsActivated == dockPanel3.ActiveDocument.DockHandler.IsActivated).FirstOrDefault();
                if (_cadLayoutGroud == null) return;
                if (_cadLayoutGroud.cadImage == null) return;
                switch (int.Parse(e.Item.Tag.ToString()))
                {
                    case 0:
                        _cadLayoutGroud.UndoChangeEntity();
                        break;
                    case 1:
                        _cadLayoutGroud.RedoChangeEntity();
                        break;
                    case 2:
                        _cadLayoutGroud.cadImage.CopyEntities();
                        break;
                    case 3:
                        _cadLayoutGroud.cadImage.CutEntities();
                        _cadLayoutGroud.cadPictBox.Invalidate();
                        break;
                    case 4:
                        _cadLayoutGroud.cadImage.PasteEntities();
                        _cadLayoutGroud.cadPictBox.Invalidate();
                        break;
                    case 5:
                        _cadLayoutGroud.RemoveEntity();
                        break;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private IDockContent GetContentFromPersistString(string persistString)
        {
            try
            {
                if (persistString == typeof(mulCadLayout).ToString())
                {
                    mulCadLayout _cadLayoutGroud = new mulCadLayout(offset);
                    _cadLayoutGroud._sendpointToChildfrm += Ground_ConnectorEvnt;
                    _cadLayoutGroud.CadPointDisplay += CadPointDisplay;
                    _cadLayoutGroud._FormClosed += LayoutFormRemove;
                    _cadLayoutGroud._offsetCalculateClick += OffsetCalculationClickEvent;
                    _cadLayoutGroud._offsetCalculateStart += OffsetCalculationStartEvent;
                    _cadLayoutGroud.TabText = lst[_ListOffFloor.Count].Split('.')[0];                   
                    _ListOffFloor.Add(_cadLayoutGroud);                    
                    return _cadLayoutGroud;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(persistString);
            }
            throw new Exception();
        }
        private void LayoutFormRemove(object sender, string formName)
        {
            try
            {
                if (_ListOffFloor.Count == 0) return;
                var frmname = _ListOffFloor.AsEnumerable().Where(X => X.TabText == formName).FirstOrDefault();
                if (_ListOffFloor.Count > 0 && frmname != null)
                {
                    _ListOffFloor.Remove(frmname);
                    if(_ListOffFloor.AsEnumerable().Where(X => X.TabText != formName).FirstOrDefault()!=null) 
                    _ListOffFloor.AsEnumerable().Where(X => X.TabText != formName).FirstOrDefault().floorCount = _ListOffFloor.Count;
                    if (sender as NumericUpDown != null)
                    {
                        var docfrmname = dockPanel3.Contents.AsEnumerable().Where(X => X.DockHandler.TabText == formName).FirstOrDefault();
                        docfrmname.DockHandler.Close();
                    }
                    else
                    {
                        var ctrl = PlantLayout.Controls.OfType<TextBox>().Where(X => X.Text == formName).FirstOrDefault();
                        if (ctrl == null) return;
                        PlantLayout.textlocation = PlantLayout.textlocation - (PlantLayout.numericUpDown1.Location.Y + 4);
                        string frmnmalast = ctrl.Name.Substring(ctrl.Name.Length - 1);
                        var ctrllbl = PlantLayout.Controls.OfType<Label>().Where(X => X.Text == "Floor Number-" + int.Parse(frmnmalast)).FirstOrDefault();
                        PlantLayout.labellocationdiff = PlantLayout.labellocationdiff - (PlantLayout.lblfloor.Location.Y + 4);
                        PlantLayout.Controls.Remove(ctrllbl);
                        PlantLayout.Controls.Remove(ctrl);
                        PlantLayout._FormName.Remove(formName);
                        if (_ListOffFloor.Count == 0)
                        {
                            var txtboxlist = PlantLayout.Controls.OfType<TextBox>().ToList();
                            for (int i = 0; i < txtboxlist.Count; i++)
                            {
                                if (!string.IsNullOrEmpty(txtboxlist[i].Text))
                                {
                                    PlantLayout.Controls.Remove(PlantLayout.Controls.OfType<Label>().Where(X => X.Text == "Floor Number-" + i).FirstOrDefault());
                                    PlantLayout.Controls.Remove(PlantLayout.Controls.OfType<TextBox>().Where(X => X.Text == txtboxlist[i].Text).FirstOrDefault());
                                }
                            }
                        }
                        PlantLayout.numericUpDown1.Value = PlantLayout.prevValue = decimal.Parse(PlantLayout.Controls.OfType<TextBox>().Count().ToString());
                        // PlantLayout.labellocationdiff = 43;
                        // PlantLayout.textlocation = 44;
                    }
                }
                if (_ListOffFloor.Count == 0)
                {
                    this.cmbsubtype.Enabled = false;
                    this.cmbMachineType.Enabled = false;
                    if (loadpanelpng.Controls.Count > 0)
                        loadpanelpng.Controls.Clear();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(
                      Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CadPointDisplay(object sender, string e)
        {
            xyCordinate.Caption = e;
        }
        private void CreateDockingForm(int frmNumber)
        {
            try
            {
                for (int i = 0; i < frmNumber; i++)
                {
                    Control ctrl = PlantLayout.Controls.OfType<TextBox>().ToList()[i];
                    if (_ListOffFloor.AsEnumerable().Where(X => X.TabText == ctrl.Text).Count() == 0)
                    {
                        mulCadLayout _cadLayoutGroud = new mulCadLayout(offset);
                        _cadLayoutGroud._sendpointToChildfrm += Ground_ConnectorEvnt;
                        _cadLayoutGroud._offsetCalculateClick += OffsetCalculationClickEvent;
                        _cadLayoutGroud._offsetCalculateStart += OffsetCalculationStartEvent;
                        _cadLayoutGroud.CadPointDisplay += CadPointDisplay;
                        _cadLayoutGroud._FormClosed += LayoutFormRemove;
                        _cadLayoutGroud.TabText = ctrl.Text;
                        _cadLayoutGroud.floorCount = frmNumber;
                        _cadLayoutGroud._HoldImagePat = _HoldImagePat;
                        _cadLayoutGroud.Show(dockPanel3, DockState.Document);
                        _ListOffFloor.Add(_cadLayoutGroud);
                        _ListOffFloor.AsEnumerable().Where(X => X.TabText == ctrl.Text).FirstOrDefault().listofdockcontaint = _ListOffFloor;
                        _ListOffFloor.AsEnumerable().Where(X => X.TabText == ctrl.Text).FirstOrDefault().offsetDict = offsetDict;

                    }
                    else
                    {
                        _ListOffFloor[i].floorCount = frmNumber;

                    }                    
                }
                if(loadpanelpng.Controls.Count>0)
                {
                    Eventload();
                }
                
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OffsetCalculationStartEvent(string tabText)
        {
            if ((offsetCalculationStatus == OffsetCalculationStatus.Inactive) && (tabText != _ListOffFloor[0].TabText))
            {
                offsetCalculationStatus = OffsetCalculationStatus.Started;
                offsetForm = tabText;
                _ListOffFloor[0].DockState = DockState.Float;
            }
            else
            {
                XtraMessageBox.Show("Offset Calculation not required for this layout", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void OffsetCalculationClickEvent(DPoint point)
        {
            switch (offsetCalculationStatus)
            {
                case OffsetCalculationStatus.Inactive:
                    XtraMessageBox.Show("This Shouldn't have happened");
                    break;
                case OffsetCalculationStatus.Started:
                    basePoint = point;
                    offsetCalculationStatus = OffsetCalculationStatus.FirstClickDone;
                    var previousForm = _ListOffFloor[0];
                    previousForm.DockState = DockState.Document;
                    var obj = _ListOffFloor.AsEnumerable().Where(X => X.TabText == offsetForm).FirstOrDefault();

                    obj.DockState = DockState.Float;
                    break;
                case OffsetCalculationStatus.FirstClickDone:
                    finalPoint = point;
                    if (!offsetDict.ContainsKey(offsetForm))
                    {
                        offsetDict.Add(offsetForm, DPoint.Offset(finalPoint, basePoint, false));
                    }
                    else
                    {
                        offsetDict[offsetForm] = DPoint.Offset(finalPoint, basePoint, false);
                    }
                    offsetCalculationStatus = OffsetCalculationStatus.Inactive;
                    var newForm = _ListOffFloor.AsEnumerable().Where(X => X.TabText == offsetForm).FirstOrDefault();
                    newForm.DockState = DockState.Document;
                    XtraMessageBox.Show("Offset Calculated");
                    _ListOffFloor.AsEnumerable().Where(X => X.TabText != offsetForm).FirstOrDefault().offsetDict = offsetDict;
                    _ListOffFloor.AsEnumerable().Where(X => X.TabText != offsetForm).FirstOrDefault().listofdockcontaint = _ListOffFloor;
                    break;
            }
        }
        private void Ground_ConnectorEvnt(string tabText, DPoint _dPoint, string filename)
        {
            try
            {
                if (offsetDict.Count == 0) return;
                var parentfrmname = _ListOffFloor.AsEnumerable().Where(X => X.DockHandler.TabText == tabText).FirstOrDefault();
                string firstTabText = parentfrmname.TabText;
                var baseTabText = _ListOffFloor[0].TabText;
                string iconname = string.Empty;
                if (parentfrmname != null)
                {
                    foreach (var entry in _ListOffFloor)
                    {
                        if ((entry.TabText == baseTabText) || (offsetDict.ContainsKey(entry.TabText)))
                        {
                            DPoint newPoint;
                            if (entry.TabText == parentfrmname.TabText)
                            {
                                if (entry._MachineCordinates.ContainsValue(_dPoint))
                                    iconname = entry._MachineCordinates.FirstOrDefault(X => X.Value == _dPoint).Key.ToString();
                                continue;
                            }
                            else if (entry.TabText == baseTabText)
                            {
                                //entry.DragfileName = parentfrmname.DragfileName;
                                newPoint = DPoint.Offset(_dPoint, offsetDict[firstTabText], false);
                                // entry.DragDropImage(newPoint, filename, iconname, _dPoint);
                            }
                            else
                            {
                                //entry.DragfileName = parentfrmname.DragfileName;
                                if (firstTabText != baseTabText)
                                {
                                    newPoint = DPoint.Offset(_dPoint, offsetDict[firstTabText], false);
                                }
                                else
                                {
                                    newPoint = _dPoint;
                                }
                                newPoint = DPoint.Offset(newPoint, offsetDict[entry.TabText], true);
                            }
                            entry.DragDropImage(newPoint, filename, iconname);                            
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // MessageBox.Show(_dPoint.X + " : " + _dPoint.Y);
        }
        private void ZoomIn_ZoomOut(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (dockPanel3.Contents.Count > 0)
                {
                    var currentActiveFormName = _ListOffFloor.AsEnumerable().Where(X => X.TabText == dockPanel3.ActiveDocument.DockHandler.TabText).FirstOrDefault();
                    if (currentActiveFormName.cadImage == null) return;
                    if (e.Item.Tag == null) return;
                    switch (e.Item.Tag.ToString().ToUpper())
                    {
                        case "ZOOM IN":
                            currentActiveFormName.DoZoomIn();
                            break;
                        case "ZOOM OUT":
                            currentActiveFormName.DoZoomOut();
                            break;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ribbon_BeforeApplicationButtonContentControlShow(object sender, EventArgs e)
        {
            //if (backstageViewControl1.SelectedTab == printTabItem)
        }
        private void sbiSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Tag == null) return;
            if (dockPanel3.Contents.Count > 0)
            {
                var currentActiveFormName = _ListOffFloor.AsEnumerable().Where(X => X.TabText == dockPanel3.ActiveDocument.DockHandler.TabText).FirstOrDefault();
                switch (e.Item.Tag.ToString().ToUpper())
                {
                    case "SAVE":
                        currentActiveFormName.SaveAsDwg("", false);
                        break;
                    case "SAVEAS":
                        currentActiveFormName.SaveAsImage(dlgSaveImg);
                        string ReceiveFileName = Path.GetFileNameWithoutExtension(dlgSaveImg.FileName);
                        string FilePth = GlobalDeclaration.ReturnPath();
                        FilePth = Path.Combine(FilePth, "SparrowCAD");
                        if (offsetDict.Count > 0)
                        {
                            if (offsetDict.ContainsKey(dockPanel3.ActiveDocument.DockHandler.TabText))
                            {
                                string finam = Path.Combine(FilePth, ReceiveFileName + "~OffSet" + ".spr");
                                if (File.Exists(finam))
                                {
                                    File.Delete(finam);
                                }
                                GlobalDeclaration.SaveOffSet(finam, offsetDict);
                            }
                        }
                        else //Only for Delete Exits File When There Is no Machine Draw on CAd Layout
                        {
                            string finam = Path.Combine(FilePth, ReceiveFileName + "~OffSet" + ".spr");
                            if (File.Exists(finam))
                            {
                                File.Delete(finam);
                            }
                        }
                        break;
                }
            }
        }
        #endregion       

        #region Open Machine Edit Window Event Call
        private void UniversalCallEventFire(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Tag == null) return;
            switch (e.Item.Tag.ToString())
            {
                case "AddEqmnt":
                    // FrmMachineMetaInfo frm = new FrmMachineMetaInfo();
                    //frm.Show();
                    break;
                case "EditEquiment":
                    break;
                case "AddData":
                    break;
                case "EditData":
                    {
                        if (dockPanel3.Contents.Count > 0)
                        {
                            var currentActiveFormName = _ListOffFloor.AsEnumerable().Where(X => X.IsActivated == dockPanel3.ActiveDocument.DockHandler.IsActivated).FirstOrDefault();

                            currentActiveFormName.EditDatafrm(sender, e);
                        }
                    }
                    break;
                case "View":
                    break;
                case "Drawing":
                    break;
                case "Notes":
                    break;

                case "Capex":
                    break;
                case "Complete":
                    break;
            }
            if ((RoleType)HindalcoiOS.Properties.Settings.Default.RoleID!= RoleType.Admin && (RoleType)HindalcoiOS.Properties.Settings.Default.RoleID!=RoleType.User)
            {
                //ReLoadTaskPanel();
                //GetTaskSchedule();
            }

        }
        #endregion
        private void brbtnViewClick_Event(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Tag == null) return;
            switch (e.Item.Tag.ToString())
            {

                case "EmpHierarchy":
                    {
                        Frm_GlobalEmloyeeHierarchy iLock = new Frm_GlobalEmloyeeHierarchy();
                        iLock.Show();
                        break;
                    }
              
                case "doc":
                    {
                        FileDocumentsFrm _File = new FileDocumentsFrm();
                        _File.Show();
                    }
                    break;
                case "stdrd":
                    break;
                case "ara":
                    {
                        //AreaSelection _Are = new AreaSelection();
                        //_Are.Show();
                        //if (_Are.ShowDialog() == DialogResult.OK)
                        //{
                        //    _Are.Close();
                        //    _Are = null;
                        //}
                    }
                    break;
                case "Maintenance":
                    {
                        //PopulateDataGridviewMaaintaince();
                        FormatDownloader down = new FormatDownloader();
                        if (down.ShowDialog() == DialogResult.OK)
                        {
                            down.Dispose();
                            down.Close();
                        }
                    }
                    break;

                case "EmployeeMaster":
                    {

                        Configuration.EmployeeMasterFrm empMaster = new Configuration.EmployeeMasterFrm();
                        empMaster.ShowDialog();
                    }

                    break;
            }
            if ((RoleType) HindalcoiOS.Properties.Settings.Default.RoleID != RoleType.Admin && (RoleType) HindalcoiOS.Properties.Settings.Default.RoleID != RoleType.User)
            {
                //ReLoadTaskPanel();
                //GetTaskSchedule();
            }

        }
        void loadpanelpng_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        #region Arvind Sharma Method Call
        /// <summary>
        /// Read Excel Sheet from Drive
        /// </summary>
        /// <param name="foldername"> Pass Name of Folder</param>
        /// <param name="subtype"> Pass SubName of Folder </param>
        /// <param name="filename"> Pass Icon Name Folder</param>
        //private void readExcelSheet(string foldername, string subtype, string filename)
        //{
        //    try
        //    {
        //        //  string retval = Resources.Instance.CreateTableObject(filename[1], dataTable);
        //        String[] spearator = { "\\", "." };
        //        //string app_Path = Application.StartupPath + @"\" + foldername + "\"" + filename;
        //        // string app_Path = Application.StartupPath + @"\Sheets\" + foldername+@"\"+filename;
        //        if (filename.Contains("_"))
        //        {
        //            app_Path = Application.StartupPath + @"\" + foldername + @"\" + "Iconscopy" + @"\";//+ filename + ".xlsx";
        //        }
        //        else
        //        {
        //            app_Path = Application.StartupPath + @"\Images\" + foldername + @"\" + subtype + @"\";// + filename + ".xlsx";
        //        }
        //        //if ((subtype == null) || (subtype == ""))
        //        //{
        //        //    app_Path = Application.StartupPath + @"\Images\" + foldername + @"\" + filename+ ".xlsx";
        //        //}


        //        if (filename.Contains("_"))
        //        {
        //            //app_Path= RemoveIntegers(app_Path);
        //            filename = RemoveIntegers(filename);
        //            app_Path = app_Path + filename + ".xlsx";
        //        }
        //        else
        //        {
        //            app_Path = app_Path + filename + ".xlsx";

        //        }
        //        if (!File.Exists(app_Path))
        //        {
        //            isFileFound = false;
        //            MessageBox.Show("File not found!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        else
        //        {
        //            var package = new ExcelPackage(new FileInfo(app_Path));
        //            ExcelWorksheet workSheet = package.Workbook.Worksheets[1];

        //            headerlist = Resources.Instance.GetMchineHeader();
        //            int rcount = workSheet.Dimension.End.Row;
        //            int colcnt = workSheet.Dimension.End.Column;

        //            // object cellValue = workSheet.Cells[i, j].Value;
        //            string[,] strarr = new string[rcount, colcnt];
        //            int a = 0; int b = 0;
        //            for (int k = 2; k <= workSheet.Dimension.End.Row; k++)
        //            {
        //                for (int m = 2; m <= workSheet.Dimension.End.Column; m++)
        //                {
        //                    if (workSheet.Cells[k, m].Value == null)
        //                    {
        //                        string replaceval = "-";
        //                        arrval = arrval + replaceval + ",";
        //                        strarr[a, b] = arrval;
        //                    }
        //                    else
        //                    {
        //                        arrval = arrval + workSheet.Cells[k, m].Value.ToString() + ",";
        //                        strarr[a, b] = arrval;
        //                    }
        //                    if (m == workSheet.Dimension.End.Column)
        //                    {
        //                        //arrval = "";
        //                        //a = a + 1;
        //                        arrval = "";
        //                        a = a + 1;
        //                        //  b = b + 1;
        //                        break;

        //                    }
        //                }
        //            }

        //            List<string> lst = strarr.Cast<string>().ToList();
        //            lst = lst.Where(x => x != null).ToList();
        //            string[] quarter = lst[0].Split(new Char[] { ',' }, 10);
        //            string parameter1 = "";
        //            int y = 0;
        //            string header = quarter[0].ToString();
        //            string empspc = "," + "-" + "," + "-" + "," + "-" + "," + "-" + "," + "-" + "," + "-" + "," + "-" + "," + "-" + ",";
        //            int itemrnbge = 0; int p = 0;
        //            if (header == headerlist[y].header_name)
        //            {
        //                while (header != headerlist[y + 1].header_name)
        //                {
        //                    string headername = headerlist[y + 1].header_name;
        //                    string concat = headername + empspc;
        //                    int item = lst.FindIndex(x => x == concat);
        //                    //itemrnbge = item - itemrnbge;
        //                    string[] operators = new string[] { " ", "-", "(", ")", "/", "\\", "°" };
        //                    for (p = itemrnbge; p < item - 1; p++)
        //                    {
        //                        string[] commaseperated = lst[p + 1].Split(new Char[] { ',' }, 10);
        //                        string paramval = commaseperated[0].Trim().ToString();
        //                        string unitval = commaseperated[1].Trim().ToString();
        //                        string maxval = commaseperated[3].ToString();
        //                        string minval = commaseperated[2].ToString();
        //                        string dtype = commaseperated[5].Trim().ToString();
        //                        string rfq = commaseperated[4].Trim();
        //                        if (rfq == "-")
        //                        {
        //                            rfq = "0";
        //                        }
        //                        else
        //                        {
        //                            rfq = "1";
        //                        }
        //                        string controltype = commaseperated[6].Trim().ToString();
        //                        if (controltype == null)
        //                        {
        //                            controltype = "-";
        //                        }
        //                        string paramtype = commaseperated[7].Trim().ToString();
        //                        if (paramtype == null)
        //                        {
        //                            paramtype = "-";
        //                        }
        //                        string dtatype = commaseperated[8].Trim().ToString();
        //                        if (dtatype == "-")
        //                        {
        //                            dtatype = "-";
        //                        }
        //                        parameter1 = lst[p + 1] + headerlist[y].header_id;
        //                        LSTSREAM.Add(parameter1);
        //                        string rvalue = "";
        //                        for (int j = 0; j < operators.Length - 1; j++)
        //                        {

        //                            if (paramval.Contains(operators[j]))
        //                            {
        //                                rvalue = paramval.Replace(operators[j], "_");
        //                                paramval = rvalue;

        //                            }
        //                            else
        //                            {
        //                                //  rvalue = paramval;
        //                                //  replHeader = paramval;
        //                            }
        //                        }
        //                        replHeader = paramval.Trim();

        //                        paramlist.Add(paramval.Trim());
        //                        string removedstr = "";
        //                        removedstr = replHeader.Replace("_", " ");
        //                        unitlist.Add(unitval);
        //                        maxlis.Add(maxval);
        //                        minlist.Add(minval);
        //                        controlType.Add(controltype);
        //                        paramTag.Add(paramtype);
        //                        dataTag.Add(dtatype);
        //                        rfqlist.Add(rfq);

        //                        addunit.Add(unitval + "," + minval + "," + maxval + "," + rfq + "," + "" + controltype + "," + paramtype + "," + dtatype);
        //                        if ((dtype == "") || (dtype == "-"))
        //                        {
        //                            dtype = "string";
        //                        }
        //                        data_type.Add(dtype);
        //                        headerlst.Add(headerlist[y].header_id.ToString());
        //                    }
        //                    itemrnbge = p;
        //                    y = y + 1;
        //                    header = headerlist[y].header_name;
        //                    if (y == headerlist.Count - 1)
        //                    {
        //                        break;
        //                    }
        //                }
        //            }
        //            DataTable paramtable = new DataTable();
        //            DataTable datatable = new DataTable();
        //            DataTable dt1 = new DataTable();
        //            DataTable dt2 = new DataTable();
        //            paramtable = ConvertListToDataTable(paramlist);
        //            datatable = ConvertListToDataTable(data_type);
        //            dt1 = GetColumnNames(paramtable);
        //            int count = paramtable.Rows.Count;
        //            dt2 = GetColumnNames(datatable);
        //            int tablecount = Resources.Instance.GetTableCount("tbl_tempObj");
        //            DataTable datset = new DataTable();
        //            DataTable paramset = new DataTable();
        //            DataTable dt3 = new DataTable();
        //            if (tablecount == 0)
        //            {
        //                // uploadImage();
        //                // openFileDialog1.Dispose();
        //                if (existval == false)
        //                {
        //                    int retobj = Resources.Instance.CreateTableTemp("tempObj", dt1, dt2, 1, filename);
        //                    int k = Resources.Instance.InsertSQL("tbl_Parameter", dt1, SystemMachine, imagePath);
        //                    if (SystemMachine.Contains(" "))
        //                    {
        //                        SystemMachine = SystemMachine.Replace(" ", "_");
        //                    }
        //                    int parameterId = 0;
        //                    if (k > 0)
        //                    {
        //                        parameterId = Resources.Instance.GetMaxParameterId(SystemMachine);
        //                    }
        //                    ParameterId = parameterId;
        //                    DataTable mytable = GlobalDeclaration.CreateTable();
        //                    for (int u = 0; u < paramlist.Count; u++)
        //                    {
        //                        mytable.Rows.Add(parameterId.ToString(), maxlis[u].ToString(), minlist[u].ToString(), unitlist[u].ToString(), rfqlist[u].ToString(), "0", paramlist[u].ToString(), paramTag[u].ToString(), dataTag[u].ToString(), headerlst[u].ToString(), controlType[u].ToString());
        //                    }
        //                    addedunit = Resources.Instance.AddUnit(mytable);
        //                    unitlist.Clear();
        //                    minlist.Clear();
        //                    maxlis.Clear();
        //                    rfqlist.Clear();
        //                    LSTSREAM.Clear();
        //                    paramTag.Clear();
        //                    dataTag.Clear();
        //                    headerlst.Clear();
        //                    paramlist.Clear();
        //                    dt1.Clear();
        //                    dt1.Dispose();
        //                    dt2.Clear();
        //                    dt2.Dispose();
        //                    paramtable.Clear();
        //                    datatable.Clear();
        //                    datset.Clear();
        //                    paramset.Clear();
        //                    data_type.Clear();
        //                }
        //            }

        //            else
        //            {
        //                int j = Resources.Instance.droptemp();
        //                if (j > 0)
        //                {
        //                    Resources.Instance.DropTableSecond();
        //                }
        //                string firsttemp = "tbl_secondaryTempTable";
        //                string secondtemp = "tbl_Parameter";
        //                int retobj1 = Resources.Instance.createSecondaryTable("secondaryTempTable", dt1, dt2, 1, filename);
        //                newCopy.Merge(dt1);
        //                datalist = Resources.Instance.CheckSeconaryTable(firsttemp, secondtemp);
        //                datset = ConvertListToDataTable(datalist);
        //                dt1 = GetColumnNames(datset);
        //                if (dt1.Columns.Count > 1)
        //                {
        //                    //  uploadImage();
        //                    //openFileDialog1.Dispose();
        //                    if (existval == false)
        //                    {
        //                        Resources.Instance.CreateTableTemp("parameter", dt1, dt2, 2, filename);
        //                        int z = Resources.Instance.DropTableSecond();
        //                        int k = Resources.Instance.InsertSQL("tbl_Parameter", dt1, SystemMachine, imagePath.Trim());
        //                        if (SystemMachine.Contains(" "))
        //                        {
        //                            SystemMachine = SystemMachine.Replace(" ", "_");
        //                        }
        //                        if (k > 0)
        //                        {
        //                            parameterId = Resources.Instance.GetMaxParameterId(SystemMachine);
        //                        }
        //                        ParameterId = parameterId;
        //                        DataTable mytable = GlobalDeclaration.CreateTable();
        //                        for (int u = 0; u < paramlist.Count; u++)
        //                        {
        //                            mytable.Rows.Add(parameterId.ToString(), maxlis[u].ToString(), minlist[u].ToString(), unitlist[u].ToString(), rfqlist[u].ToString(), "0", paramlist[u].ToString(), paramTag[u].ToString(), dataTag[u].ToString(), headerlst[u].ToString(), controlType[u].ToString());
        //                        }
        //                        addedunit = Resources.Instance.AddUnit(mytable);
        //                        unitlist.Clear();
        //                        minlist.Clear();
        //                        maxlis.Clear();
        //                        rfqlist.Clear();
        //                        LSTSREAM.Clear();
        //                        paramTag.Clear();
        //                        dataTag.Clear();
        //                        headerlst.Clear();
        //                        paramlist.Clear();
        //                        dt1.Clear();
        //                        dt1.Dispose();
        //                        dt2.Clear();
        //                        dt2.Dispose();
        //                        paramtable.Clear();
        //                        datatable.Clear();
        //                        data_type.Clear();
        //                        // int o = Resources.Instance.DropTableSecond();
        //                    }

        //                }
        //                else
        //                {

        //                    //Resources.Instance.CreateTableTemp("parameter", newCopy, dt2, 2, filename);
        //                    int z = Resources.Instance.DropTableSecond();
        //                    int k = Resources.Instance.InsertSQL("tbl_Parameter", newCopy, SystemMachine, imagePath.Trim());
        //                    if (SystemMachine.Contains(" "))
        //                    {
        //                        SystemMachine = SystemMachine.Replace(" ", "_");
        //                    }
        //                    if (k > 0)
        //                    {
        //                        parameterId = Resources.Instance.GetMaxParameterId(SystemMachine);
        //                    }
        //                    ParameterId = parameterId;
        //                    DataTable mytable = GlobalDeclaration.CreateTable();
        //                    for (int u = 0; u < paramlist.Count; u++)
        //                    {
        //                        mytable.Rows.Add(parameterId.ToString(), maxlis[u].ToString(), minlist[u].ToString(), unitlist[u].ToString(), rfqlist[u].ToString(), "0", paramlist[u].ToString(), paramTag[u].ToString(), dataTag[u].ToString(), headerlst[u].ToString(), controlType[u].ToString());
        //                    }
        //                    addedunit = Resources.Instance.AddUnit(mytable);
        //                    unitlist.Clear();
        //                    minlist.Clear();
        //                    maxlis.Clear();
        //                    rfqlist.Clear();
        //                    LSTSREAM.Clear();
        //                    paramTag.Clear();
        //                    dataTag.Clear();
        //                    headerlst.Clear();
        //                    paramlist.Clear();
        //                    dt1.Clear();
        //                    dt1.Dispose();
        //                    dt2.Clear();
        //                    dt2.Dispose();
        //                    paramtable.Clear();
        //                    datatable.Clear();
        //                    data_type.Clear();
        //                }
        //            }
        //            ///###############   Needs to discuss regarding sublayer type for any category of machine ################################
        //            //------------------------------------------------------------------------------------------------------------------------
        //            //------------------------------------------------------------------------------------------------------------------------

        //            if (addedunit > 0)
        //            {
        //                SystemMachine = SystemMachine.Replace(" ", "_");
        //                int i = Resources.Instance.AddDraggedMachineList(filename, SystemMachine.ToString(), Convert.ToDecimal(dragPoint.X), Convert.ToDecimal(dragPoint.Y), fileName, CMBmtype, cmbCtype);

        //                machineList.Add(filename);
        //            }
        //            else
        //            {
        //                //  MessageBox.Show("There was an Error during upload.");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //  Resources.Instance.DropTableSecond(); //------>>>> on error drop the secondary temporary table as this creates a overhead
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        int j = Resources.Instance.droptemp();
        //        if (j > 0)
        //        {
        //            Resources.Instance.DropTableSecond();
        //        }
        //    }
        //}
        #region Audit Event Call
        private void brbtnAuditcl_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Tag == null) return;//|| this.cadImage == null
            // var CadName = this.cadImage.SelectedEntities.AsEnumerable().FirstOrDefault();
            //if (CadName!= null)
            //{
            //if (CadName.EntType == EntityType.ImageEnt)
            {
                switch (e.Item.Tag.ToString())
                {
                    case "auditcld":
                        {
                            HindalcoiOS.AuditHind.AuditCalenderView _auditclfrm = new HindalcoiOS.AuditHind.AuditCalenderView();
                            //_auditclfrm.TopMost = true;
                            //_auditclfrm.Show();
                            if (_auditclfrm.ShowDialog() == DialogResult.OK)
                            {
                                this.Close();
                            }
                        }
                        break;
                    case "auditrpt":
                        {
                            HindalcoiOS.AuditHind.AuditManagementView auditReport = new HindalcoiOS.AuditHind.AuditManagementView();
                            //auditReport.TopMost = true;
                            //auditReport.Show();
                            if (auditReport.ShowDialog() == DialogResult.OK)
                            {
                                this.Close();
                            }
                        }
                        break;              
                    case "AuditMaster":
                        {
                            HindalcoiOS.AuditHind.AuditMasterView auditMasterView = new HindalcoiOS.AuditHind.AuditMasterView();
                            //TopMost = true;
                            //auditMasterView.Show();
                            if (auditMasterView.ShowDialog() == DialogResult.OK)
                            {
                                this.Close();
                            }
                        }
                        break;
                    case "AuditCategory":
                        {
                            HindalcoiOS.AuditHind.AuditCategoryView auditCateView = new HindalcoiOS.AuditHind.AuditCategoryView();
                            //TopMost = true;
                            //auditCateView.Show();
                            if (auditCateView.ShowDialog() == DialogResult.OK)
                            {
                                this.Close();
                            }
                        }
                        break;
                }
                if ((RoleType)HindalcoiOS.Properties.Settings.Default.RoleID != RoleType.Admin && (RoleType)HindalcoiOS.Properties.Settings.Default.RoleID != RoleType.User)
                {
                    //ReLoadTaskPanel();
                    //GetTaskSchedule();
                }

            }
            //}
            //else
            //{
            //    XtraMessageBox.Show("Please Drop Machine First.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}


        }
        #endregion
        private string LineName = string.Empty;
        private void btbtnline_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (_ListOffFloor.Count == 0) return;
                if (e.Item.Tag == null) return;
                var _cadLayoutGroud = _ListOffFloor.AsEnumerable().Where(X => X.IsActivated == dockPanel3.ActiveDocument.DockHandler.IsActivated).FirstOrDefault();
                if (_cadLayoutGroud == null) return;
                if (_cadLayoutGroud.cadImage == null)
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please Upload CAD File. Then Try Again", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                switch (Convert.ToInt32(e.Item.Tag))
                {
                    case 1:
                    case 2:
                    case 5:
                    case 4:
                    case 3:
                        {
                            if (Convert.ToInt32(e.Item.Tag) == 1 || Convert.ToInt32(e.Item.Tag) == 2 || Convert.ToInt32(e.Item.Tag) == 3 || Convert.ToInt32(e.Item.Tag) == 5)
                            {
                                _cadLayoutGroud.LineName = e.Item.Caption;
                                _cadLayoutGroud.SetAddEntityMode(CreatorType.Polyline);
                            }
                            break;
                        }
                    case 6:
                        {
                            _cadLayoutGroud.PrintPreview();
                        }
                        break;
                    case 8:
                        {
                            _cadLayoutGroud.SetAddEntityMode(CreatorType.Circle);
                        }
                        break;
                    case 11:
                        {
                            _cadLayoutGroud.SetAddEntityMode(CreatorType.Hatch);
                        }
                        break;
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show("btbtnline_ItemClick");
            }
        }
        public DataTable ConvertListToDataTable(List<string> list)
        {
            // New table.
            DataTable table = new DataTable();
            for (int i = 0; i < 1; i++)
            {
                table.Columns.Add();
            }
            // Add rows.
            foreach (var array in list)
            {
                table.Rows.Add(array);
            }
            return table;
        }
        private DataTable GetColumnNames(DataTable dt)
        {
            string[] name = new string[] { };
            DataTable dts = new DataTable();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = dt.Rows[i][0].ToString();
                bool cont = dts.Columns.Contains(dc.ColumnName);
                if (cont == true)
                {
                    dc.ColumnName = dt.Rows[i][0].ToString() + "_" + i;
                }
                dts.Columns.Add(dc);
            }
            return dts;
        }
        #endregion

        #region U1 User Event Fire List      

        private void ReLoadTaskPanel()
        {
            this.dockPanel2.Controls.Add(pnlReload);
            // this.cadPictBox.Controls.Add(dockPanel2);
            dockPanel2.Visible = true;
            pnlReload.Visible = true;
        }
        private void GetUserNotification()
        {
            var todaytime = System.DateTime.Now;
            var todasytime = todaytime.Date.ToString("yyyy-MM-dd");
            DateTime dtObj = Convert.ToDateTime(todasytime);
            string[] obx = dtObj.ToString().Split(' ');
            // string[] obx = dtObj.ToString().Split(' ');
            usernotification = Resources.Instance.GetUserNotification(Convert.ToDateTime(dtObj), GlobalDeclaration._holdInfo[0].EmpCode);
            for (int i = 0; i < 1; i++)
            {
                notifyMessage.ShowBalloonTip(5000, usernotification.Rows[i][2].ToString(), usernotification.Rows[i][1].ToString(), ToolTipIcon.None);
            }

        }
        private void u1freezbrBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (e.Item.Tag == null) return;
                switch (e.Item.Tag.ToString())
                {
                  
                    case "dwnld":
                        FormatDownloader down = new FormatDownloader();
                        if (down.ShowDialog() == DialogResult.OK)
                        {
                            down.Dispose();
                            down.Close();
                        }
                        break;
                }

                if ((RoleType)HindalcoiOS.Properties.Settings.Default.RoleID != RoleType.Admin && (RoleType)HindalcoiOS.Properties.Settings.Default.RoleID != RoleType.User)
                {
                    ReLoadTaskPanel();
                    // GetTaskSchedule();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lblUp_Click(object sender, EventArgs e)
        {
            try
            {
                listBox5.Items.Clear();
                TaskTypeClk = "UpcomingType";
                for (int i = 0; i < UpcomingTask.Rows.Count; i++)
                {
                    listBox5.Items.Add(i + 1 + ")" + " " + UpcomingTask.Rows[i][3].ToString());
                    listBox5.ForeColor = Color.Red;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void lblPend_Click(object sender, EventArgs e)
        {
            try
            {
                listBox5.Items.Clear();
                TaskTypeClk = "PendingType";
                int a = 0;
                int b = 0;
                int c = 0;
                // int totalCount = pendingTask.Rows.Count + todayTask.Rows.Count;
                for (a = 0; a < pendingTask.Rows.Count; a++)
                {
                    listBox5.Items.Add(a + 1 + ")" + " " + pendingTask.Rows[a][1].ToString());
                    listBox5.ForeColor = Color.Red;
                }
                for (b = 0; b < todayTask.Rows.Count; b++)
                {
                    c = a + b + 1;
                    listBox5.Items.Add(c + ")" + " " + todayTask.Rows[b][1].ToString());
                    listBox5.ForeColor = Color.Red;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void brbtnlgs_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (e.Item.Tag == null) return;
                switch (e.Item.Tag.ToString())
                {                   
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       

        #region Upload FreezPlan Report From Local Drive
        private DataGridView dataGridView1 = new DataGridView();
        private void PopulateDataGridView()
        {
            // Set the column header names.
            dataGridView1.ColumnCount = 12;
            dataGridView1.Columns[0].Name = "Priority";
            dataGridView1.Columns[1].Name = "MaintenanceType";
            dataGridView1.Columns[2].Name = "MachineTag";
            dataGridView1.Columns[3].Name = "MachineName";
            dataGridView1.Columns[4].Name = "Frequency";
            dataGridView1.Columns[5].Name = "MaintScheduled";
            dataGridView1.Columns[6].Name = "ActivityDetails";
            dataGridView1.Columns[7].Name = "ShtdwnReq";
            dataGridView1.Columns[8].Name = "Resource";
            dataGridView1.Columns[9].Name = "AdditionalManPower";
            dataGridView1.Columns[10].Name = "MeterReading";
            dataGridView1.Columns[11].Name = "UnitsName";
            //dataGridView1.Columns[12].Name = "Team";
            //dataGridView1.Columns[13].Name = "Datetime";
            // Adjust the row heights so that all content is visible.
            dataGridView1.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }
        private void PopulateDataGridviewMaaintaince()
        {
            try
            {
                DataGridView dataGridView1 = new DataGridView();
                dataGridView1.ColumnCount = 5;
                dataGridView1.Columns[0].Name = "ActivityDetail";
                dataGridView1.Columns[0].HeaderText = "Activity Detail";
                dataGridView1.Columns[1].Name = "Frequency";
                dataGridView1.Columns[1].HeaderText = "Frequency";
                dataGridView1.Columns[2].Name = "OutIn";
                dataGridView1.Columns[2].HeaderText = "Outsourced/Inhouse";
                dataGridView1.Columns[3].Name = "SDRequired";
                dataGridView1.Columns[3].HeaderText = "Shut Down Required";
                dataGridView1.Columns[4].Name = "MWeek";
                dataGridView1.Columns[4].HeaderText = "Maintenance Scheduled in Week";
                dataGridView1.AutoResizeRows(
                   DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
                dlgSaveEnt = new SaveFileDialog();
                dlgSaveEnt.Filter = "*.xlsx|*.xlsx|*.csv|*.csv";
                dlgSaveEnt.Title = "Maintenance File Name";
                if (dlgSaveEnt.ShowDialog() != DialogResult.OK)
                    return;
                string fname = dlgSaveEnt.FileName;
                if (fname != null)
                {
                    Microsoft.Office.Interop.Excel._Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook workbook = XcelApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                    worksheet = workbook.Sheets["Sheet1"];
                    worksheet = workbook.ActiveSheet;
                    worksheet.Name = "Maintenance Format";
                    worksheet.Application.ActiveWindow.SplitRow = 1;
                    // worksheet.Application.ActiveWindow.FreezePanes = true;
                    for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                    {
                        worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                        worksheet.Cells[1, i].Font.NAME = "Calibri";
                        worksheet.Cells[1, i].Font.Bold = true;
                        worksheet.Cells[1, i].Interior.Color = Color.Wheat;
                        worksheet.Cells[1, i].Font.Size = 12;
                    }
                    worksheet.Columns.AutoFit();
                    worksheet.StandardWidth = 116;
                    workbook.SaveAs(fname);
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Format Save Successfully", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // XcelApp.Visible = true;
                    XcelApp.UserControl = true;
                    workbook.Close(true, Type.Missing, Type.Missing);
                    XcelApp.Quit();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void DownLoadFromat()
        {
            try
            {
                //Stopwatch f = new Stopwatch();
                //    f.Start();
                PopulateDataGridView();
                // var openTiming = f.ElapsedMilliseconds;
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                //app.Visible = true;           
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].Name;
                }
              ((Microsoft.Office.Interop.Excel.Range)worksheet.Rows[1, Type.Missing]).Font.Bold = true;
                worksheet.Columns.EntireColumn.AutoFit();
                // save the application 
                dlgSaveEnt = new SaveFileDialog();
                dlgSaveEnt.Filter = "*.xlsx|*.xlsx|*.csv|*.csv";
                dlgSaveEnt.Title = "Please Enter FreezFileName";
                if (dlgSaveEnt.ShowDialog() != DialogResult.OK)
                    return;
                string fname = dlgSaveEnt.FileName;
                if (fname != null)
                {
                    workbook.SaveAs(fname, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Format Download Successfully", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Exit from the application  
                    app.Quit();
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
        #endregion

        #endregion

        #region Inventory Master Add Event Fire
        private void brbtnInvtMst_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        #endregion

        #region Training Calender Download and Upload

        private DataGridView DgvTraining;
        private System.Windows.Forms.SaveFileDialog dlgSaveEnt;
        private void BindTraingClm(string reporttype)
        {
            DgvTraining = new DataGridView();
            try
            {

                switch (reporttype)
                {
                    case "Employee":
                        DgvTraining.ColumnCount = 13;
                        DgvTraining.Columns[0].Name = "SrNo";
                        DgvTraining.Columns[0].HeaderText = "Sl.No";

                        DgvTraining.Columns[1].Name = "EmpName";
                        DgvTraining.Columns[1].HeaderText = "Employee Code";

                        //DgvTraining.Columns[2].Name = "Dpt";
                        //DgvTraining.Columns[2].HeaderText = "Department";

                        DgvTraining.Columns[2].Name = "TraingType";
                        // DgvTraining.Columns[2].ValueType = typeof(string);
                        DgvTraining.Columns[2].HeaderText = "Training Type";

                        DgvTraining.Columns[3].Name = "TrainingTitle";
                        // DgvTraining.Columns[3].ValueType = typeof(string);
                        DgvTraining.Columns[3].HeaderText = "Training Title";
                        DgvTraining.Columns[3].Width = 116;

                        DgvTraining.Columns[4].Name = "Startdate";
                        DgvTraining.Columns[4].HeaderText = "Training Start date";

                        DgvTraining.Columns[5].Name = "EndDate";
                        DgvTraining.Columns[5].HeaderText = "Training Completion Date";

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

                        break;
                    default:
                        DgvTraining.ColumnCount = 4;
                        DgvTraining.Columns[0].Name = "SrNo";
                        DgvTraining.Columns[0].HeaderText = "SI.No";
                        DgvTraining.Columns[1].Name = "TraingType";
                        DgvTraining.Columns[1].HeaderText = "Training Type";
                        DgvTraining.Columns[2].Name = "TrainingTitle";
                        DgvTraining.Columns[2].HeaderText = "Training Title";
                        DgvTraining.Columns[3].Name = "Capability";
                        DgvTraining.Columns[3].HeaderText = "Capability";
                        break;
                }
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

                dlgSaveEnt = new SaveFileDialog();
                dlgSaveEnt.Filter = "*.xlsx|*.xlsx|*.csv|*.csv";
                dlgSaveEnt.Title = "Training File Name";
                if (dlgSaveEnt.ShowDialog() != DialogResult.OK)
                    return;
                string fname = dlgSaveEnt.FileName;
                if (fname != null)
                {
                    Microsoft.Office.Interop.Excel._Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook workbook = XcelApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                    worksheet = workbook.Sheets["Sheet1"];
                    worksheet = workbook.ActiveSheet;
                    //worksheet.Name = "Training Calendar";
                    worksheet.Application.ActiveWindow.SplitRow = 1;
                    worksheet.Application.ActiveWindow.FreezePanes = true;
                    for (int i = 1; i < DgvTraining.Columns.Count + 1; i++)
                    {
                        worksheet.Cells[1, i] = DgvTraining.Columns[i - 1].HeaderText;
                        worksheet.Cells[1, i].Font.NAME = "Calibri";
                        worksheet.Cells[1, i].Font.Bold = true;
                        worksheet.Cells[1, i].Interior.Color = Color.Wheat;
                        worksheet.Cells[1, i].Font.Size = 12;
                    }
                    PopulateDropdown(worksheet, reporttype);
                    worksheet.Columns.AutoFit();
                    worksheet.StandardWidth = 116;
                    workbook.SaveAs(fname);
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Format Save Successfully", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    XcelApp.Visible = true;
                    XcelApp.UserControl = true;
                    workbook.Close(true, Type.Missing, Type.Missing);
                    XcelApp.Quit();
                    ReleaseObject(worksheet);
                    ReleaseObject(workbook);
                    ReleaseObject(XcelApp);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                XtraMessageBox.Show("Exception Occured while releasing object " + ex.Message, "Error");
            }
            finally
            {
                GC.Collect();
            }
        }


        private void PopulateDropdown(Microsoft.Office.Interop.Excel._Worksheet oSheet)
        {
            oSheet.Range["B2:B100"].Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing, Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, GetEmployee());

            //oSheet.Range["C2:C100"].Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
            //    Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, GetDeptName());
            oSheet.Range["E2:E100"].Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
               Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, TraingType());
            oSheet.Range["I2:I100"].Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
               Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, Capability());
        }

        private void PopulateDropdown(Microsoft.Office.Interop.Excel._Worksheet oSheet, string ReportType)
        {
            try
            {
                if (ReportType == "Employee")
                {
                    var EmpNameCode = oSheet.Range["B2"].EntireColumn;
                    EmpNameCode.Validation.Delete();
                    EmpNameCode.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                       Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, GetEmployee());
                    EmpNameCode.ShowErrors();

                    var trntype = oSheet.Range["C2"].EntireColumn;
                    trntype.Validation.Delete();
                    trntype.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing, Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, TraingType());

                    //  var trntitle = oSheet.Range["D2"].EntireColumn;
                    //  trntitle.Validation.Delete();
                    //  trntitle.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Microsoft.Office.Interop.Excel.XlDVAlertStyle.xlValidAlertInformation,
                    //Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, TrainingTtitle());

                    var empreport = oSheet.Range["J2"].EntireColumn;
                    empreport.Validation.Delete();
                    empreport.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                      Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, EmpNameString());

                    var CAPlty = oSheet.Range["H2"].EntireColumn;
                    CAPlty.Validation.Delete();
                    CAPlty.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                      Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, Capability());

                    var Statuss = oSheet.Range["M2"].EntireColumn;
                    Statuss.Validation.Delete();
                    Statuss.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                      Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, StatusCimplete());
                }
                else
                {
                    oSheet.Range["B2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                                         Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, TraingType(), Type.Missing);
                    oSheet.Range["C2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Microsoft.Office.Interop.Excel.XlDVAlertStyle.xlValidAlertStop,
                        Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, TrainingTtitle());

                    oSheet.Range["D2"].EntireColumn.Validation.Add(Microsoft.Office.Interop.Excel.XlDVType.xlValidateList, Type.Missing,
                       Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlBetween, Capability());
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw;
            }
        }

        private string TrainingTtitle()
        {
            StringBuilder strBuilder = new StringBuilder();
            try
            {
                if (Resources.Instance._trainingTitle.Rows.Count > 0)
                {
                    for (int i = 0; i < Resources.Instance._trainingTitle.Rows.Count; i++)
                    {
                        string excelVal = Resources.Instance._trainingTitle.Rows[i]["TTitle"].ToString();

                        strBuilder.Append(excelVal);
                        strBuilder.Append(",");
                        //break;
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strBuilder.ToString();
        }

        private string TraingType()
        {
            StringBuilder strBuilder = new StringBuilder();
            try
            {
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

        private string Capability()
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

        private string GetEmployee()
        {
            StringBuilder strBuilder = new StringBuilder();
            try
            {
                if (Resources.Instance._EmpCode.Rows.Count > 0)
                {
                    for (int i = 0; i < Resources.Instance._EmpCode.Rows.Count; i++)
                    {
                        string excelVal = Resources.Instance._EmpCode.Rows[i]["emp_code"].ToString();
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
        private string StatusCimplete()
        {
            StringBuilder strBuilder = new StringBuilder();
            try
            {
                string[] capabilty = new string[] { "Completed", "Not Completed" };
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
        private string EmpNameString()
        {
            StringBuilder strBuilder = new StringBuilder();
            string gg = string.Empty;
            try
            {
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
        private string GetDeptName()
        {
            StringBuilder strBuilder = new StringBuilder();
            try
            {
                DataTable dt = Resources.Instance.GetDataKey("Sp_GetDeptMaster");
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string excelVal = dt.Rows[i]["DepartName"].ToString();

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

        //priva
        private void brbtnuploadtr_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Tag == null) return;
            switch (e.Item.Tag.ToString())
            {
                case "upd":
                    TrainingCalenderUpload _upload = new TrainingCalenderUpload(string.Empty);
                    _upload.TopMost = true;
                    _upload.Show();
                    break;
                case "selct":
                    TrainingListForm trt = new TrainingListForm();
                    trt.Show();
                    break;
            }
        }
        public delegate void ExampleCallback(string Name);
        private void brbtnDownloadTra_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Tag == null) return;
            string ReportType = string.Empty;
            switch (e.Item.Tag.ToString())
            {
                case "employee":
                    ReportType = "Employee";
                    break;
                case "List":
                    ReportType = "list";
                    break;
            }
            BindTraingClm(ReportType);
            //  Thread thread = new Thread(BindTraingClm());
            // thread.Start(ReportType);
        }
        #endregion

        #region U1 User Training List Event
        private void brbtnupcmp_ItemClick(object sender, ItemClickEventArgs e) // mytraining
        {
            if (e.Item.Tag == null) return;
            string ReportType = string.Empty;
            switch (e.Item.Tag.ToString())
            {
                case "upcomp":
                    ReportType = "UpComing";
                    Callform(ReportType, false);
                    break;
                case "pnding":
                    ReportType = "Pending";
                    Callform(ReportType, false);
                    break;
                case "comple":
                    ReportType = "Complete";
                    Callform(ReportType, true);
                    //_IsStatus = true;
                    break;
            }
            //Callform(ReportType);

        }
        private void brbtnmyUp_ItemClick(object sender, ItemClickEventArgs e) // myteam traing Event
        {
            if (e.Item.Tag == null) return;
            string ReportType = string.Empty;
            switch (e.Item.Tag.ToString())
            {
                case "myup":
                    ReportType = "MyTeamUpcoming";
                    Callform(ReportType, false);
                    break;
                case "mypending":
                    ReportType = "MyTeampending";
                    Callform(ReportType, false);
                    break;
                case "mycomp":
                    ReportType = "MyTeamComplete";
                    Callform(ReportType, true);
                    break;
            }

        }
        private void brbtnAddtrn_ItemClick(object sender, ItemClickEventArgs e) // Add training Event
        {
            try
            {
                if (e.Item.Tag == null) return;
                string ReportType = string.Empty;
                switch (e.Item.Tag.ToString())
                {
                    case "Addtrn":
                        ReportType = "Addtrn";
                        Callform(ReportType);
                        break;
                    case "Teamtrn":
                        ReportType = "AddMyteam";
                        Callform(ReportType);
                        break;
                    case "other":
                        ReportType = "HrOther";
                        Callform(ReportType, true);
                        break;
                    case "trnCel":
                        TrainingCalenderUpload _upload = new TrainingCalenderUpload("CallHr");
                        _upload.IsCallHr = true;
                        _upload.TopMost = true;
                        _upload.Show();
                        _upload.DynamicGridSetting();
                        break;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void brbtnManagetrainer(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Tag == null) return;
            string ReportType = string.Empty;

            switch (e.Item.Tag.ToString())
            {
                case "planed":
                    ReportType = "PlanedMng";
                    break;
                case "request":
                    ReportType = "RequestMng";
                    break;
            }
            Callform(ReportType);

        }
        private void brbtnDashBoard(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Tag == null) return;
            string ReportType = string.Empty;
            switch (e.Item.Tag.ToString())
            {
                case "logs":
                    ReportType = "LogDs";
                    break;
                case "stsds":
                    ReportType = "StsDs";
                    break;
            }
            Callform(ReportType);
        }
        private void brbtnuptrane_ItemClick(object sender, ItemClickEventArgs e) // Trainee Events
        {
            if (e.Item.Tag == null) return;
            string ReportType = string.Empty;
            switch (e.Item.Tag.ToString())
            {
                case "uptrnee":
                    ReportType = "UpComingTrainer";
                    Callform(ReportType, false);
                    break;
                case "closetrnee":
                    ReportType = "CloseTraining";
                    Callform(ReportType, false);
                    break;
            }
            // Callform(ReportType);
        }
        private void Callform(string formname, bool _Issts = false)
        {
            try
            {
               
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //private void changeMachineConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Operations.ChangeMachineConfig chngConfig = new Operations.ChangeMachineConfig();
        //    chngConfig.Show();
        //}

        private void timerTaskReload_Tick(object sender, EventArgs e)
        {
            timerTaskReload.Enabled = false;
            if (timerTaskReload.Interval >= 25000)
            {
                //if (!GlobalDeclaration.UserType.Equals("Admin"))
                //{
                //    //ReLoadTaskPanel();
                //  GetTaskSchedule();
                //}

            }
        }

        private void notifyMessage_Click(object sender, EventArgs e)
        {

            // int a=Resources.Instance.UpdateUserNotification()
        }
        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //int selIndex = listBox5.SelectedIndex;
                //if (selIndex > 0)
                //{
                //    selIndex = selIndex - 1;
                //}
                //else if (selIndex == -1)
                //{ }
                //else
                //{
                //    todayTaskCode = todayTask.Rows[selIndex][1].ToString();
                //    Safety_Task.SafetyMaster newSfty = new Safety_Task.SafetyMaster();
                //    newSfty.Show();
                //}
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void copyMachineDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addKeyComponetDT(string filePath)
        {
            try
            {
                String excelConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=Excel 12.0;Persist Security Info=False;HDR=Yes;\"";
                OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                GlobalDeclaration.KeyComponentDT = new DataTable("KeyCompDt");
                OleDbDataAdapter adptr = new OleDbDataAdapter("SELECT [EQUPT CODE],[Static Equipment],[KeyValue] FROM [Sheet1$]", excelConnectionString);
                adptr.Fill(GlobalDeclaration.KeyComponentDT);
                excelConnection.Close();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetKeyComponentDT()
        {
            String dir_path = Application.StartupPath + @"\" + @"KeyComponentData";
            String file_path = Application.StartupPath + @"\" + @"KeyComponentData" + @"\" + "Key component.xlsx";
            if (Directory.Exists(dir_path))
            {
                GlobalDeclaration.KeyComponentDT = ExcelToDataTableUsingExcelDataReader(file_path);
            }
            else
            {
                Directory.CreateDirectory(dir_path);
                GlobalDeclaration.KeyComponentDT = ExcelToDataTableUsingExcelDataReader(file_path);
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

        DPoint cordinate = new DPoint();
        public DPoint coordiante
        {
            get { return coordiante; }
            set { coordiante = cordinate; }

        }
        private void uploadedDocumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //MachineHistory.McdUploadedFile uplFile = new MachineHistory.McdUploadedFile(Mvalue);
            //uplFile.Show();

        }

        public Boolean isIsolated
        {
            get;
            set;
        }
        private void dockPanel2_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void lblUpTask_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalTask_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            CommonLogOut();
        }

        #endregion

        #region U1 User Safety Event List
        private void Safety_ClickEvent(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (e.Item.Tag == null) return;
                switch (e.Item.Tag.ToString())
                {
                    case "machine":
                        {
                            if (dockPanel3.Contents.Count > 0)
                            {
                                var currentActiveFormName = _ListOffFloor.AsEnumerable().Where(X => X.IsActivated == dockPanel3.ActiveDocument.DockHandler.IsActivated).FirstOrDefault();
                                if (currentActiveFormName.cadImage != null)
                                {
                                    GlobalSearch frm = new GlobalSearch();
                                    frm.SelectedNode._listconnt = currentActiveFormName._listconnt;
                                    frm.SelectedNode.TagList = currentActiveFormName._DicMachineNo;
                                    frm.SelectedNode._McordList = currentActiveFormName._MachineCordinates;
                                    frm.SelectedNode._MachinePathHold = currentActiveFormName._HoldImagePat;
                                    //frm.SelectedNode.
                                    frm.SelectedNode.AuditDataTable = Resources.Instance.GetDataKey("Sp_GetAuditReportList");
                                    frm.SelectedNode.TaskDataTable = Resources.Instance.GetDataKey("Sp_GetTaskForGlobalSerach");
                                    frm.SelectedNode.GetpermitCode = Resources.Instance.GetDataKey("SP_GetPTWPermitCode");
                                    frm.SelectedNode.PermitIsolation = Resources.Instance.GetDataKey("Sp_GetIsolationPermitCode");
                                    frm.Show();
                                }
                                else
                                {
                                    XtraMessageBox.Show("Please Load Cad File First!!!!!", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                        break;

                    

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region  #Start region "Ftp Version Comparison"
        public string Encrypt(string clearText)
        {
            string EncryptionKey = "abc123";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        private void BGWorkerThreadUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {


                //Thread readExceltoDatatable = new Thread(() => WriteAppPathtoTextFile(".txt"));
                //readExceltoDatatable.Start();
                //Thread.Sleep(5000);
                //int sum = 0;
                //for (int a = 0; a < 100; a++)
                //{
                //    Thread.Sleep(1000);
                //    BGWorkerThreadUpdate.ReportProgress(a);
                //    sum = sum + a;
                //    if (BGWorkerThreadUpdate.CancellationPending)
                //    {
                //        e.Cancel = true;
                //        BGWorkerThreadUpdate.ReportProgress(0);
                //        return;
                //    }
                //}
                //e.Result = isthreadSuccess;
                //BGWorkerThreadUpdate.ReportProgress(100);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, Class_Operation.ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BGWorkerThreadUpdate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                //progressBar1.Value = e.ProgressPercentage;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, Class_Operation.ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BGWorkerThreadUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                {
                    //  lblProgress.Text = "Process was cancelled";
                }
                else if (e.Error != null)
                {
                    //  lblProgress.Text = "There was an error running the process. The thread aborted";
                }
                else
                {
                    //   lblProgress.Text = "Process completed Successfully";
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, Class_Operation.ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static Version GetVersionFromAssemblyFullName(string strAssemblyPath)
        {
            string strVersion = AssemblyName.GetAssemblyName(strAssemblyPath).FullName.Split(",".ToCharArray())[1].Split("=".ToCharArray())[1];
            return new Version(strVersion);
        }
        private void WriteAppPathtoTextFile(string appExtension)
        {
            try
            {
                ftpSessionObj = Resources.Instance.GetFtpConnection_RMPCL();
                //  string FilePth = GlobalDeclaration.ReturnPath()+@"\";
                //   System.Diagnostics.Debugger.Launch();
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string Filname = "DownloaderSetting" + appExtension;
                string fullPath = AppDomain.CurrentDomain.BaseDirectory + @"\" + Filname;
                string CopyToPath = appPath + @"\" + "AutoUpdater" + @"\" + @"TempFolder" + @"\";
                if (File.Exists(fullPath))
                {
                    // File.Delete(fullPath);
                    using (FileStream fs1 = new FileStream(fullPath, FileMode.Open))
                    {
                        fs1.SetLength(0);
                        fs1.Close();
                    }
                    using (FileStream fs = new FileStream(fullPath, FileMode.Append))
                    {
                        char[] value = (appPath + @"\" + Filname).ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(value), 0, value.Length);
                        byte[] newLine = Encoding.Default.GetBytes(Environment.NewLine);
                        fs.Write(newLine, 0, newLine.Length);

                        char[] copypath = (CopyToPath).ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(copypath), 0, copypath.Length);
                        byte[] newLine1 = Encoding.Default.GetBytes(Environment.NewLine);
                        fs.Write(newLine1, 0, newLine1.Length);

                        char[] appPath1 = (appPath).ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(appPath), 0, appPath.Length);
                        byte[] newLine2 = Encoding.Default.GetBytes(Environment.NewLine);
                        fs.Write(newLine2, 0, newLine2.Length);

                        char[] ftpProto = ftpSessionObj.Rows[0][0].ToString().ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(ftpSessionObj.Rows[0][0].ToString()), 0, ftpProto.Length);

                        byte[] newLine3 = Encoding.Default.GetBytes(Environment.NewLine);
                        fs.Write(newLine3, 0, newLine3.Length);

                        char[] ftpHost = ftpSessionObj.Rows[0][1].ToString().ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(ftpSessionObj.Rows[0][1].ToString()), 0, ftpHost.Length);

                        byte[] newLine4 = Encoding.Default.GetBytes(Environment.NewLine);
                        fs.Write(newLine4, 0, newLine4.Length);
                        char[] ftpUserName = ftpSessionObj.Rows[0][2].ToString().ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(ftpSessionObj.Rows[0][2].ToString()), 0, ftpUserName.Length);

                        byte[] newLine5 = Encoding.Default.GetBytes(Environment.NewLine);
                        fs.Write(newLine5, 0, newLine5.Length);
                        char[] ftpUserPwd = ftpSessionObj.Rows[0][3].ToString().ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(ftpSessionObj.Rows[0][3].ToString()), 0, ftpUserPwd.Length);

                        byte[] newLine6 = Encoding.Default.GetBytes(Environment.NewLine);
                        fs.Write(newLine6, 0, newLine6.Length);
                        char[] ftpUserDecPwd = ftpSessionObj.Rows[0][4].ToString().ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(ftpSessionObj.Rows[0][4].ToString()), 0, ftpUserDecPwd.Length);

                        byte[] newLine7 = Encoding.Default.GetBytes(Environment.NewLine);
                        fs.Write(newLine7, 0, newLine7.Length);
                        char[] applicationManifestPrimary = GlobalDeclaration.applicationManifestPrimary.ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(applicationManifestPrimary), 0, applicationManifestPrimary.Length);

                        byte[] newLine8 = Encoding.Default.GetBytes(Environment.NewLine);
                        fs.Write(newLine8, 0, newLine8.Length);
                        char[] applicationManifestSecondory = GlobalDeclaration.applicationManifestSecondory.ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(applicationManifestSecondory), 0, applicationManifestSecondory.Length);

                        string ProcName = System.AppDomain.CurrentDomain.FriendlyName;
                        byte[] newLine9 = Encoding.Default.GetBytes(Environment.NewLine);
                        fs.Write(newLine9, 0, newLine9.Length);
                        char[] ProcName1 = ProcName.ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(ProcName1), 0, ProcName1.Length);
                    }
                    if (File.Exists(fullPath))
                    {
                        if (File.Exists(appPath + @"\" + "AutoUpdater" + @"\" + @"net5.0" + @"\" + Filname))
                        {
                            File.Delete(appPath + @"\" + "AutoUpdater" + @"\" + @"net5.0" + @"\" + Filname);
                        }
                        if (Directory.Exists(GlobalDeclaration.applicationBasePath + "Manifest"))
                        {
                            Directory.CreateDirectory(GlobalDeclaration.applicationBasePath + "Manifest");
                            Directory.CreateDirectory(GlobalDeclaration.applicationBasePath + "AutoUpdater");
                            Directory.CreateDirectory(GlobalDeclaration.applicationBasePath + "Manifest" + @"\" + @"NewManifest");
                        }
                        if (Directory.Exists(GlobalDeclaration.applicationBasePath + "Manifest"))
                        {
                            Directory.CreateDirectory(GlobalDeclaration.applicationBasePath + "Manifest" + @"\" + @"OldManifest");
                        }
                    }
                }
                else
                {

                    using (FileStream fs1 = new FileStream(fullPath, FileMode.Create))
                    {
                        fs1.SetLength(0);
                        fs1.Close();
                    }
                    using (FileStream fs = File.Create(fullPath))
                    {
                        char[] value = (appPath + @"\" + Filname).ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(value), 0, value.Length);
                        byte[] newLine = Encoding.Default.GetBytes(Environment.NewLine);
                        fs.Write(newLine, 0, newLine.Length);

                        char[] copypath = (CopyToPath).ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(copypath), 0, copypath.Length);
                        byte[] newLine1 = Encoding.Default.GetBytes(Environment.NewLine);
                        fs.Write(newLine1, 0, newLine1.Length);

                        char[] appPath1 = (appPath).ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(appPath), 0, appPath.Length);
                        byte[] newLine2 = Encoding.Default.GetBytes(Environment.NewLine);
                        fs.Write(newLine2, 0, newLine2.Length);

                        char[] ftpProto = ftpSessionObj.Rows[0][0].ToString().ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(ftpSessionObj.Rows[0][0].ToString()), 0, ftpProto.Length);

                        byte[] newLine3 = Encoding.Default.GetBytes(Environment.NewLine);
                        fs.Write(newLine3, 0, newLine3.Length);

                        char[] ftpHost = ftpSessionObj.Rows[0][1].ToString().ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(ftpSessionObj.Rows[0][1].ToString()), 0, ftpHost.Length);

                        byte[] newLine4 = Encoding.Default.GetBytes(Environment.NewLine);
                        fs.Write(newLine4, 0, newLine4.Length);
                        char[] ftpUserName = ftpSessionObj.Rows[0][2].ToString().ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(ftpSessionObj.Rows[0][2].ToString()), 0, ftpUserName.Length);

                        byte[] newLine5 = Encoding.Default.GetBytes(Environment.NewLine);
                        fs.Write(newLine5, 0, newLine5.Length);
                        char[] ftpUserPwd = ftpSessionObj.Rows[0][3].ToString().ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(ftpSessionObj.Rows[0][3].ToString()), 0, ftpUserPwd.Length);

                        byte[] newLine6 = Encoding.Default.GetBytes(Environment.NewLine);
                        fs.Write(newLine6, 0, newLine6.Length);
                        char[] ftpUserDecPwd = ftpSessionObj.Rows[0][4].ToString().ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(ftpSessionObj.Rows[0][4].ToString()), 0, ftpUserDecPwd.Length);

                        byte[] newLine7 = Encoding.Default.GetBytes(Environment.NewLine);
                        fs.Write(newLine7, 0, newLine7.Length);
                        char[] applicationManifestPrimary = GlobalDeclaration.applicationManifestPrimary.ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(applicationManifestPrimary), 0, applicationManifestPrimary.Length);

                        byte[] newLine8 = Encoding.Default.GetBytes(Environment.NewLine);
                        fs.Write(newLine8, 0, newLine8.Length);
                        char[] applicationManifestSecondory = GlobalDeclaration.applicationManifestSecondory.ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(applicationManifestSecondory), 0, applicationManifestSecondory.Length);


                        string ProcName = System.AppDomain.CurrentDomain.FriendlyName;
                        byte[] newLine9 = Encoding.Default.GetBytes(Environment.NewLine);
                        fs.Write(newLine9, 0, newLine9.Length);
                        char[] ProcName1 = ProcName.ToCharArray();
                        fs.Write(Encoding.UTF8.GetBytes(ProcName1), 0, ProcName1.Length);
                        //  File.Copy(fullPath, appPath + @"\" + "AutoUpdater" + @"\" + @"net5.0" + @"\" + Filname);
                    }
                }
                if (File.Exists(appPath + @"\" + "AutoUpdater" + @"\" + @"net5.0" + @"\" + Filname))
                {
                    File.Delete(appPath + @"\" + "AutoUpdater" + @"\" + @"net5.0" + @"\" + Filname);
                }
                File.Copy(fullPath, appPath + @"\" + "AutoUpdater" + @"\" + @"net5.0" + @"\" + Filname);
                string AppAutoPath = Convert.ToString(Application.StartupPath + @"\" + "AutoUpdater" + @"\" + @"net5.0" + @"\" + "AutoUpdaterAPI.exe");
                string updaterPath = AppAutoPath;
                Process.Start(updaterPath);
                // XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Checking for updates. This may take some time.", Class_Operation.ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, Class_Operation.ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion  #Start region "Ftp Version Comparison"
        private void barButtonItem163_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (e.Item.Tag == null) return;
                switch (e.Item.Tag.ToString())
                {
                    case "AppSetting":
                        {
                            DBConfiguration SW = new DBConfiguration();
                            if (DialogResult.OK == SW.ShowDialog())
                            {
                                SW.Close();
                            }
                        }
                        break;
                    case "Password":
                        {
                            frmRecoverPassword chgpas = new frmRecoverPassword();
                            chgpas.Show();
                        }
                        break;
                    case "Registration":
                        {
                            frmRegistration reg = new frmRegistration();
                            reg.CallFrmName = "Admin";
                            reg.IsFirstCall = false;
                            reg.Show();
                        }
                        break;
                    case "Manage":
                        {
                            frmManageUsers mngusr = new frmManageUsers();
                            mngusr.Show();
                        }
                        break;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void barToggleSwitchItem1_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            try
            {
                bool isstatus = false;
                if (_ListOffFloor.Count == 0) return;
                if (e.Item.Tag == null) return;
                var _cadLayoutGroud = _ListOffFloor.AsEnumerable().Where(X => X.IsActivated == dockPanel3.ActiveDocument.DockHandler.IsActivated).FirstOrDefault();
                if (_cadLayoutGroud == null) return;
                if (_cadLayoutGroud.cadImage == null)
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please Upload CAD File. Then Try Again", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (barToggleSwitchItem1.Checked)
                {
                    isstatus = false;
                }
                else
                {
                    isstatus = true;
                }
                // CadLocked(isstatus, _cadLayoutGroud);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void CadLocked(bool islocked,mulCadLayout _cadLayoutGroud)
        {
            if (_cadLayoutGroud.cadImage == null) return;
            if ((RoleType)HindalcoiOS.Properties.Settings.Default.RoleID == RoleType.Admin
                  || (RoleType)HindalcoiOS.Properties.Settings.Default.RoleID == RoleType.User)
            {
                if (islocked)
                {
                    _cadLayoutGroud.IsCadLocked = true;
                }
                else
                {
                    _cadLayoutGroud.IsCadLocked = false;
                }
                foreach (CADLayer layer in _cadLayoutGroud.cadImage.Converter.Layers)
                {
                    if (islocked)
                    {
                        layer.Locked = true;
                    }
                    else
                    {
                        layer.Locked = false;
                    }
                    _cadLayoutGroud.cadImage.Converter.Loads(layer);
                }
            }
        }

        private void DbarToggleSwitchItem_CheckedChanged(object sender, ItemClickEventArgs e)
        {

        }
        private void TaskCalendar1_DateTimeChanged(object sender, EventArgs e)
        {
            try
            {
                if (RefreshTaskPanel != null)
                    RefreshTaskPanel.Invoke(sender, Convert.ToDateTime(TaskCalendar1.DateTime));
                // this.RefreshTaskPanel = this.TaskPanelHandlerEvent;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void lblTod_Click(object sender, EventArgs e)
        {
            try
            {
                listBox5.Items.Clear();
                TaskTypeClk = "TodaysType";
                for (int i = 0; i < todayTask.Rows.Count; i++)
                {
                    listBox5.Items.Add(i + 1 + ")" + " " + todayTask.Rows[i][3].ToString());
                    listBox5.ForeColor = Color.Red;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void U1IncidentReport(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (_ListOffFloor.Count == 0) return;
                if (e.Item.Tag == null) return;
                var _cadLayoutGroud = _ListOffFloor.AsEnumerable().Where(X => X.IsActivated == dockPanel3.ActiveDocument.DockHandler.IsActivated).FirstOrDefault();
                if (_cadLayoutGroud == null) return;
                if (_cadLayoutGroud.cadImage == null)
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please Upload CAD File. Then Try Again", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                switch (e.Item.Tag.ToString())
                {
                    
                    //case "MonthlyProduction":
                    //    {
                    //        Operation.MonthlyProductionTarget incRpt = new Operation.MonthlyProductionTarget();
                    //        incRpt.Show();
                    //    }
                    //    break;
                                                                    
                    case "checkforUpdate":
                        {
                            //System.Diagnostics.Debugger.Launch();
                            //XtraMessageBox.Show("OK Print", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK);
                            //if (!BGWorkerThreadUpdate.IsBusy)
                            //{
                            //    BGWorkerThreadUpdate.RunWorkerAsync(1000);
                            string fileExt = ".txt";
                            if (File.Exists(GlobalDeclaration.ReturnPath() + @"\" + @"AppSetting" + fileExt))
                            {
                                File.Delete(GlobalDeclaration.ReturnPath() + @"\" + @"AppSetting" + fileExt);
                            }
                            //Thread readExceltoDatatable = new Thread(() => WriteAppPathtoTextFile(".txt"));
                            //readExceltoDatatable.Start();
                            WriteAppPathtoTextFile(".txt");
                        }
                        break;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void hideContainerRight_Click(object sender, EventArgs e)
        {

        }
        private void CommonLogOut()
        {

            if (Dialog)
            {
                switch (XtraMessageBox.Show("Are you sure? \n Do you  want Close App... ?", ApplicationConstants.MessageDisplay, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    //Stay on this form
                    case DialogResult.Yes:
                        {
                            //SaveAsDwg("", false);
                            YesDailog = true;
                            this.Close();
                        }
                        break;
                    default:

                        break;
                }
            }
            else
            {
                switch (XtraMessageBox.Show("Are you sure? \n Do you  want LogOut App.", ApplicationConstants.MessageDisplay, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    //Stay on this form
                    case DialogResult.Yes:
                        {
                            // SaveLayout();
                            // SaveAsDwg("", false);
                            // firstloginexit = true;
                            // this.Close();
                            FormCollection fc = Application.OpenForms;//ParentWindow
                            foreach (Form frm in fc)
                            {
                                if (frm.Name != "ParentWindow")
                                {
                                    MessageBox.Show("Please Close Open Form First.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK,
               MessageBoxIcon.Warning,
               MessageBoxDefaultButton.Button1,
               MessageBoxOptions.DefaultDesktopOnly);
                                    return;
                                }
                            }
                            LoginPanel fLogin = new LoginPanel();
                            fLogin.txtEmail.Text = HindalcoiOS.Properties.Settings.Default.Email;
                            GlobalDeclaration._holdInfo.Clear();
                            //fLogin.TopMost = true;
                            //
                            if (dockPanel3.Contents.Count > 0)
                            {
                                var currentActiveFormName = _ListOffFloor.AsEnumerable().Where(X => X.IsActivated == dockPanel3.ActiveDocument.DockHandler.IsActivated).FirstOrDefault();
                                currentActiveFormName.ClearAllDictionayObject();
                            }
                            GlobalDeclaration.FirstLogOut = true;
                            if (this.OnAfterLogOut == null)
                                this.OnAfterLogOut += OnAfterLogOutReCall;
                            this.Hide();
                            fLogin.Show();
                        }
                        break;
                    default:
                        break;
                }

            }
        }
        private Dictionary<string, object> _FormMNT = new Dictionary<string, object>();
        private void brbtnNRMButton_ItemClick(object sender, ItemClickEventArgs e)// Mormal Maintenance Event Fire
        {
            try
            {

                if (_ListOffFloor.Count == 0) return;
                if (e.Item.Tag == null) return;
                var _cadLayoutGroud = _ListOffFloor.AsEnumerable().Where(X => X.IsActivated == dockPanel3.ActiveDocument.DockHandler.IsActivated).FirstOrDefault();
                if (_cadLayoutGroud == null) return;
                if (_cadLayoutGroud.cadImage == null)
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please Upload CAD File. Then Try Again", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void brkbtnOHCbutton_ItemClik(object sender, ItemClickEventArgs e)
        {
            try
            {

                if (_ListOffFloor.Count == 0) return;
                if (e.Item.Tag == null) return;
                var _cadLayoutGroud = _ListOffFloor.AsEnumerable().Where(X => X.IsActivated == dockPanel3.ActiveDocument.DockHandler.IsActivated).FirstOrDefault();
                if (_cadLayoutGroud == null) return;
                if (_cadLayoutGroud.cadImage == null)
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please Upload CAD File. Then Try Again", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                switch (e.Item.Tag.ToString())
                {
                   
                  
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearDic(object Sender, string frmname)
        {
            if (_FormMNT.ContainsKey(frmname))
            {
                
            }
            //if(_FrmBRKDWN.ContainsKey(frmname))
            //{
            //    _FrmBRKDWN.Remove(frmname);
            //}
        }
        private void brbtnBRKbutton_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (_ListOffFloor.Count == 0) return;
                if (e.Item.Tag == null) return;
                var _cadLayoutGroud = _ListOffFloor.AsEnumerable().Where(X => X.IsActivated == dockPanel3.ActiveDocument.DockHandler.IsActivated).FirstOrDefault();
                if (_cadLayoutGroud == null) return;
                if (_cadLayoutGroud.cadImage == null)
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please Upload CAD File. Then Try Again", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }               

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void barBtnItemMaster_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                AddNewItemMaster();

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnMGMTINV_ItemClick(object sender, ItemClickEventArgs e)
        {

            try
            {
               
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void machineHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void barBtnOperationUnit_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (_ListOffFloor.Count == 0) return;
            //if (e.Item.Tag == null) return;
            //var _cadLayoutGroud = _ListOffFloor.AsEnumerable().Where(X => X.IsActivated == dockPanel3.ActiveDocument.DockHandler.IsActivated).FirstOrDefault();
            //if (_cadLayoutGroud == null) return;
            //if (_cadLayoutGroud.cadImage == null)
            //{
            //    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please Upload CAD File. Then Try Again", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            switch (e.Item.Tag.ToString())
            {
                case "OperationUnit":
                    {
                        AddNewOperationUnit();
                    }
                    break;
                case "Mail":// Call Mail Configuration Window
                    {
                        MailConfigView mLView = new MailConfigView();
                        mLView.Show();
                    }
                    break;
                case "GNCONFIG":// Call Mail Configuration Window
                    {
                        GeneralConfigView gnConview = new GeneralConfigView();
                        gnConview.Show();
                    }
                    break;
            }

        }
        private void AddNewItemMaster()
        {
           
        }
        private async void barDashboardcall_ItemClick(object sender, ItemClickEventArgs e)
        {
            GeneralConfig mConfig = GeneralConfig.Instance;
            mConfig.GetGeneralConfig();
            var uri = AuditHind.AuditHelper.CreateUriWithQuery(new Uri(mConfig.DashboardUrl), AuditHind.AuditHelper.UrlToken).ToString();
            //var uri = "https://hindalcodashboard.sparrowios.com/dashboard/app/?Token=EJXxOWVr782zCHaWsAWTs0YSmLM8Zf4IBowu/fRebaA=&Uid=138";
            if (!string.IsNullOrEmpty(uri))
                System.Diagnostics.Process.Start(uri);

            //if (!string.IsNullOrEmpty(mConfig.DashboardUrl))
            //    System.Diagnostics.Process.Start(mConfig.DashboardUrl);
        }

        private void AddNewOperationUnit()
        {
            OperationUnitView oUnitView = new OperationUnitView();
            //oUnitView.GetValue += ItemMasterHandlerEvent;
            if (oUnitView.ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                //itemMaster.Close();
                //itemMaster.Dispose();
                //itemMaster = null;
            }
        }
        private void ItemMasterHandlerEvent(params object[] obj)
        {

        }

    }


    public class UserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; } = null;
        public int Uid { get; set; }
    }
}