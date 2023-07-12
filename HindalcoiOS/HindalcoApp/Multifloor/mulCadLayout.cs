using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CADImport.CADImportForms;
using CADImport;
using CADImport.FaceModule;
using WeifenLuo.WinFormsUI.Docking;
using CADImport.Professional;
using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using HindalcoiOS.Connector_FRM;
using CADImport.RasterImage;
using System.IO;
using System.Collections.Concurrent;
using HindalcoiOS.Machine_Edit_Form;
using System.Drawing.Imaging;
using System.Collections;
using CADImport.Printing;
using SparrowRMS;
using System.Text.RegularExpressions;
using CADImport.Export;
using HindalcoiOS.Dynamic_Form;
using System.Diagnostics;
using System.Data.OleDb;
using DevExpress.XtraCharts.Native;
using DocumentFormat.OpenXml.Vml.Spreadsheet;

namespace HindalcoiOS.Multifloor
{
    public partial class mulCadLayout : DockContent
    {
        public delegate void SendToPoint(string TabText, DPoint _dPoint, string FileName);
        public delegate void OffsetCalculateStart(string tabText);
        public delegate void OffsetCalculateClick(DPoint _dPoint);

        public OffsetCalculator offset;

        #region Public and Private Dictionary Declaration

        public Dictionary<DPoint, string> _RcConnectorDic = null;
        public Dictionary<string, string> _DeletedMachineDic = null;
        public Dictionary<string, string> _DicMachineNo = null;
        public Dictionary<string, Connector> _listconnt = null;

        public ConcurrentDictionary<string, string> _HoldImagePat = null;
        public ConcurrentDictionary<string, string> _searchImage = null;
        public ConcurrentDictionary<string, Machine_Edit_Data> EditfrmDictionary = null;

        public Dictionary<string, DPoint> _MachineCordinates = null;
        public ConcurrentDictionary<string, String> _LineTypeHold = null;

        public Dictionary<string, List<string>> _UpdateDic = null;
        public ConcurrentDictionary<string, PackageMachine.PackageMachine> _HoldPackageMachine = null;
        public event SomeEvents SomeEvent;
        public event SendToPoint _sendpointToChildfrm;
        public event OffsetCalculateStart _offsetCalculateStart;
        public event OffsetCalculateClick _offsetCalculateClick;
        public EventHandler<string> CadPointDisplay;
        public EventHandler<string> _FormClosed;
        public Dictionary<string, DPoint> offsetDict = new Dictionary<string, DPoint>();
        #endregion

        #region CadImage class Object Declaration
        private Connector connector;
        public CADImage cadImage;
        private ClipRect clipRectangle;
        private MultipleLanguage mlng;
        private EntitiesCreator entCreator;
        private DRect drawingRect;
        private CADMatrix saveDrawMatrix;

        private Point startPoint;
        private Point endPoint;
        public CADProperty cADProperty = null;
        private XMLImporter xmlImporter;
        public CadEntitiesTxt CadEntitiesTxt = null;
        private SortedList settingsLst;
        private SaveSettings svSet;
        //public Image DragfileName = null;
        PackageMachine.PackageMachine package = null;
        Machine_Edit_Data mcd = null;
        public Image DragfileName = null;
        private bool focusLossAllowed = true;

        #endregion

        #region Cad Default Form Declaration
        private CADImport.CADImportForms.GridForm gForm;
        private CADImport.CADImportForms.LayerForm lForm;
        private CADImport.CADImportForms.SHXForm shxFrm;
        private CADImport.Printing.PrintingForm prtForm;
        private CADImport.CADImportForms.SetRasterSizeForm rasterSizeForm;

        #endregion

        #region Enum Type Obj Declaration
        private CreatorType curAddEntityType;
        #endregion

        #region Boolean Type Variables Declaration

        public bool colorDraw,
            dimVisible,
            showLineWeight,
            textVisible,
         PackageFrm,
        IsReloadLine,
        moveMarker,
        Dialog,
            YesDailog,
            holddrag,
            firstloginexit,
            ismachineDragged,
        IsRemoteConnection,
            cntrlDown,
            stopSnap,
            detRMouseDown,
            detMouseDown,
            enableSnap, _IsLineComplete,
            IsReCallPKG,
        selectedEntitiesChanged,
         IsCadLocked = false;
        bool cordcheck = false;

        #endregion

        #region String Type Fields Declaration
        public string LineName = string.Empty;
        private const string FileNameDisplay = "MachineConnector.spr";
        private const string FileNameDisplayLine = "LC.spr";
        private string Source = string.Empty;
        private string Destination = string.Empty;
        private string lngFile;
        private readonly string fileSettingsName;
        public string SetMachineName = string.Empty;
        string ImageName = string.Empty;

        #endregion

        #region Int type Fields Declaration       
        private int RCNumber = 1;
        private int addEntity;
        public int floorCount = 0;
        #endregion

        #region Cad property Declaration
        public CADImport.FaceModule.CADPictureBox EditorCADPictureBox
        {
            get
            {
                return this.cadPictBox;
            }
        }
        public Boolean isIsolated
        {
            get;
            set;
        }
        public string StatusCaption
        {
            get;
            set;
        }

        public string RealPointDisplay
        {
            get;
            set;
        }
        public string LoadCadFileName
        {
            get;
            set;
        }
        public List<mulCadLayout> listofdockcontaint
        {
            get; set;
        }
        #endregion

        #region Class Constructor
        public mulCadLayout(OffsetCalculator calculator)
        {
            InitialCadImportForms();
            InitializeComponent();
            InitParams();
            InitLng();
            fileSettingsName = Application.StartupPath + @"\Settings.txt";
            InitSettings();
            SetAllFormsSettings();
            _UpdateDic = new Dictionary<string, List<string>>();
            _LineTypeHold = new ConcurrentDictionary<string, string>();
            _MachineCordinates = new Dictionary<string, DPoint>();
            EditfrmDictionary = new ConcurrentDictionary<string, Machine_Edit_Data>();
            _searchImage = new ConcurrentDictionary<string, string>();
            _HoldImagePat = new ConcurrentDictionary<string, string>();
            _listconnt = new Dictionary<string, Connector>();
            _DicMachineNo = new Dictionary<string, string>();
            _DeletedMachineDic = new Dictionary<string, string>();
            _RcConnectorDic = new Dictionary<DPoint, string>();
            _HoldPackageMachine = new ConcurrentDictionary<string, PackageMachine.PackageMachine>();
            offset = calculator;
            Protection.Register("PSGFER E&C Pvt. Ltd", "pawan@plant360.org", "284A35D9635818C1E9166E804F94D1746C0D9401B040020C78124913300B708E4330276FD674B49CA86D020F99FD1A98385A1CAE79C35D8C07B9B32EBE45266B", false);
        }
        #endregion

        #region Cad Method Collection
        /// <summary>
        /// Fields Initialization
        /// </summary>
        private void InitParams()
        {
            try
            {
                cADProperty = new CADProperty();
                CadEntitiesTxt = new CadEntitiesTxt();
                colorDraw = true;
                dimVisible = true;
                showLineWeight = true;
                textVisible = true;
                cntrlDown = false;
                startPoint = Point.Empty;
                endPoint = Point.Empty;
                CadEntitiesTxt = new CadEntitiesTxt();
                this.clipRectangle = new ClipRect(this.cadPictBox);
                this.clipRectangle.MultySelect = true;
                SetAddEntityMode(CreatorType.Undetected);
                this.entCreator = new EntitiesCreator(this.cadPictBox, Color.White);
                this.cadPictBox.MouseWheel += new MouseEventHandler(CADPictBoxMouseWheel);
                this.cadPictBox.ScrollEvent += new CADImport.FaceModule.ScrollEventHandlerExt(CADPictBoxScroll);
                cADProperty.old_Pos = new PointF();
                cADProperty.sc = 1.0f;
                cADProperty.prev_sc = 1.0f;
                cntrlDown = false;
                addEntity = -1;
                this.entCreator.EndEntityDraw += new CADImport.CADImportForms.ChangeOptionsEventHandler(this.EndAddEntity);
                this.entCreator.GetRealPointEvent += new CADImport.Professional.GetRealPointEvent(this.GetRealPoint);
                enableSnap = true;
                startPoint = Point.Empty;
                endPoint = Point.Empty;
                this.cADProperty.VisibleAreaSize = cadPictBox.Size;
                this.enableSnap = true;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(
                    Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        ///  Memory Allocate to Cad Form
        /// </summary>
        private void InitialCadImportForms()
        {
            try
            {
                gForm = new GridForm();
                lForm = new LayerForm();
                lForm.LayerChanged += LForm_LayerChanged;
                prtForm = new CADImport.Printing.PrintingForm();
                prtForm.LayerForm = lForm;
                shxFrm = new SHXForm();
                rasterSizeForm = new SetRasterSizeForm();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(
                    Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SetAllFormsLanguageSettings()
        {
            try
            {
                this.entCreator.OptionsForm.MultipleLanguagesPath = mlng.Path;
                this.entCreator.OptionsForm.LngFileName = lngFile;
                this.lForm.MultipleLanguagesPath = mlng.Path;
                this.lForm.LngFileName = lngFile;
                this.prtForm.MultipleLanguagesPath = mlng.Path;
                this.prtForm.LngFileName = lngFile;
#if protect
			this.regFrm.MultipleLanguagesPath = mlng.Path;
			this.regFrm.LngFileName = lngFile;	
#endif
                this.rasterSizeForm.MultipleLanguagesPath = mlng.Path;
                this.rasterSizeForm.LngFileName = lngFile;
                this.shxFrm.MultipleLanguagesPath = mlng.Path;
                this.shxFrm.LngFileName = lngFile;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(
                    Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void InitSettings()
        {
            //Load settings
            try
            {
                svSet = new SaveSettings(fileSettingsName);
                settingsLst = svSet.LoadOptions();
                if (settingsLst != null)
                {
                    string key = ApplicationConstants.languagepath;
                    if (settingsLst.ContainsKey(key))
                        this.mlng.Path = Convert.ToString(settingsLst[key]);
                }
                else
                {
                    this.mlng.Path = CADConst.lngPathDefault;
                }
                if (settingsLst == null)
                    CreateNewSettingsList();
                else
                    SetSettings();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(
                    Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DoExtentsForPrint()
        {
            this.cadImage.ClearSelection();
            this.cadImage.ClearMarkers();
            this.cadImage.GetExtents();
        }
        public void PrintPreview()
        {
            this.prtForm.TypePage = DrawingSize.Fit;
            printPrevDlg.Document = prtForm.Print(false);
            printPrevDlg.ShowDialog();
            if (printPrevDlg.Document != null)
                printPrevDlg.Document.Dispose();
        }
        private void CustomPrintPreview()
        {
            DoExtentsForPrint();
            prtForm.ShowDialog();
        }
        public void SetSettings()
        {
            try
            {
                if (settingsLst == null) return;
                string tmp;
                int cn = 0;
                //Language path
                string key = ApplicationConstants.languagepath;
                if (settingsLst.ContainsKey(key))
                {
                    this.mlng.Path = Convert.ToString(settingsLst[key]);
                    this.entCreator.OptionsForm.LngDir = this.mlng.Path;
                }
                //Language
                key = ApplicationConstants.languagestr;
                if (settingsLst.ContainsKey(key))
                    lngFile = (string)settingsLst[key];
                mlng.LoadLNG(lngFile);
                this.Text = mlng.SetLanguage(this.Controls, this.Menu, this.Text);
                //Language ID
                key = ApplicationConstants.languageIDstr;
                if (settingsLst.ContainsKey(key))
                    //this.curLngInd = Convert.ToByte(settingsLst[key]);
                    //BackgroundColor
                    key = ApplicationConstants.backcolorstr;
                tmp = ApplicationConstants.blackstr;
                if (settingsLst.ContainsKey(key))
                    tmp = Convert.ToString(settingsLst[key]);
                if (tmp.ToUpper() == ApplicationConstants.blackstr)
                    this.Black_Click();
                else
                    this.White_Click();
                //Show entity panel
                key = ApplicationConstants.showentitystr;
                if (settingsLst.ContainsKey(key))
                    tmp = Convert.ToString(settingsLst[key]);
                //if (tmp.ToUpper() == ApplicationConstants.truestr)
                //{
                //    this.spltPictBox.Visible = true;
                //    this.trvPanel.Visible = true;
                //}
                //else
                //{
                //    this.spltPictBox.Visible = false;
                //    this.trvPanel.Visible = false;
                //}
                //Color drawing
                key = ApplicationConstants.colordrawstr;
                if (settingsLst.ContainsKey(key))
                    tmp = Convert.ToString(settingsLst[key]);
                if (tmp.ToUpper() == ApplicationConstants.truestr)
                    this.colorDraw = true;
                else this.colorDraw = false;
                //SHXPathCount
                key = ApplicationConstants.shxpathcnstr;
                if (settingsLst.ContainsKey(key))
                    cn = Convert.ToInt32(settingsLst[key]);
                //SHXPaths
                for (int i = 0; i < cn; i++)
                {
                    key = string.Format("SHXPath_{0}", (i + 1));
                    if (settingsLst.ContainsKey(key))
                        this.shxFrm.AddPath(Convert.ToString(settingsLst[key]));
                }
                //First start
                key = ApplicationConstants.installstr;
                if (settingsLst.ContainsKey(key))
                {
                    if (cadImage.Converter.SHXSettings.SearchSHXPaths)
                    {
                        this.shxFrm.lstDir.Items.Clear();
                        this.shxFrm.lstPath.Clear();
                        //ArrayList vPaths = new ArrayList();
                        List<string> vPaths = new List<string>();
                        CADConst.FindAutoCADSHXPaths(vPaths);
                        for (int i = 0; i < vPaths.Count; i++)
                        {
                            tmp = (string)vPaths[i];
                            this.shxFrm.lstDir.Items.Add(tmp);
                            this.shxFrm.lstPath.Add(tmp, string.Empty);
                            cadImage.Converter.SHXSettings.SHXSearchPaths += tmp + ApplicationConstants.sepstr3;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(
                    Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #region protect
#if protect
			//License
			key = "Type_license";
			if(settingsLst.ContainsKey(key))
			{
				tmp = (string)settingsLst[key];
					Protection.LicenseType = LicenseType.Register;
			}
#endif
            #endregion
        }
        public bool SelectEntity(int x, int y)
        {
            try
            {
                moveMarker = false;
                if (cadImage == null)
                    return false;
                CADEntity ent = cadImage.SelectExt(x, y, cntrlDown, true);
                if (this.CreateNewEntity)
                {
                    if (ent != null && ent.EntType == EntityType.ImageEnt)
                    {
                        UpdateDic(ent);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(Source) && !string.IsNullOrEmpty(Destination))
                        {
                            Destination = string.Empty;
                            Source = string.Empty;
                        }
                    }
                    return false;
                }
                // var linetypeent = this.cadImage.SelectedEntities.AsEnumerable().FirstOrDefault();//cadImage.SelectedEntities[0]
                //else if (this.cadImage != null && ent != null && ent.EntType == EntityType.Leader)
                //{
                //    CADLeader cadline = (CADLeader)ent;
                //    connector = _listconnt[cadline.LineType.Name];
                //}
                bool det = this.cadImage.SelectedEntities.Count == 0;
                if (ent != null && !IsCadLocked) // this code for make marker on selected entity
                {
                    moveMarker = true;
                    this.stopSnap = true;
                }// End for marker
                if (!det)
                {
                    this.cadImage.ClearMarkers();
                    if (ent != null && ent.EntType == EntityType.ImageEnt)
                    {
                        if (GlobalDeclaration._MyTagDictinary.ContainsKey(((CADImport.CADImageEnt)ent).Point))
                        {
                            //((CADImport.CADImageEnt)ent).Color = Color.Green;
                            this.cadImage.ClearMarkers();
                            //this.cadImage.SelectedEntities.FirstOrDefault().Color = Color.Green;                            
                            if (((CADImport.CADImageEnt)ent).ImageDef != null)
                            {
                                string MachineTag = GlobalDeclaration._MyTagDictinary[((CADImport.CADImageEnt)ent).Point];
                                string Machinename = _MachineCordinates.FirstOrDefault(X => X.Value == ((CADImport.CADImageEnt)ent).Point).Key.ToString();
                                if (SomeEvent != null)
                                {
                                    SomeEvent.Invoke(((CADImport.CADImageEnt)ent).Point, MachineTag, Machinename);
                                    //SomeEvent -= ParentWindow_SomeEvent;
                                }
                            }
                        }
                        else
                        {

                        }
                    }
                    this.stopSnap = true;
                }
                if (!IsCadLocked)
                    menuItemLine_Click();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        /// <summary>
        /// Leader line cordinates find
        /// </summary>
        private void menuItemLine_Click()
        {
            if (cadImage == null) return;
            var CadName = this.cadImage.SelectedEntities.AsEnumerable().FirstOrDefault();
            if (CadName == null) return;
            //########## When Entity Move Coordinates Update into MachineCordinates Dictionary
            if (CadName.EntType == EntityType.ImageEnt && ((CADImport.CADImageEnt)CadName).ImageDef != null)
            {
                DPoint newpoints = UpdateCord(((CADImport.CADImageEnt)CadName).Point);
                if (_MachineCordinates.ContainsValue(newpoints) && this.cadImage.SelectedEntities.Count == 1)
                {
                    ImageName = _MachineCordinates.FirstOrDefault(X => X.Value == newpoints).Key;
                }
            }
        }
        private void UpdateDic(CADEntity ent1)// DPoint dPoint
        {
            try
            {

                if (ent1 != null && ent1.EntType == EntityType.ImageEnt)
                {
                    if (string.IsNullOrEmpty(Source) && ((CADImport.CADImageEnt)ent1).ImageDef != null)
                    {
                        //   DPoint Linecorssource = _MachineCordinates[MachineName(ent1)];                       
                        DPoint newpoints = UpdateCord(((CADImport.CADImageEnt)ent1).Point);
                        if (_MachineCordinates.ContainsValue(newpoints))
                        {
                            Source = _MachineCordinates.FirstOrDefault(X => X.Value == newpoints).Key.ToString();
                            connector = new Connector();
                            connector.FromData = Source;
                            connector.FromDPoint = "X" + newpoints.X + " " + "Y" + newpoints.Y;
                        }
                    }
                    else if (string.IsNullOrEmpty(Destination) && ((CADImport.CADImageEnt)ent1).ImageDef != null)
                    {
                        // DPoint Linecordestination = _MachineCordinates[MachineName(ent1)];
                        DPoint newpoints = UpdateCord(((CADImport.CADImageEnt)ent1).Point);
                        if (_MachineCordinates.ContainsValue(newpoints))
                        {
                            Destination = _MachineCordinates.FirstOrDefault(X => X.Value == newpoints).Key.ToString();// MachineName(ent1);                    
                            if (_UpdateDic.ContainsKey(Source))
                            {
                                List<string> RetrnList = _UpdateDic[Source];
                                RetrnList.Add(Destination);
                                _UpdateDic[Source] = RetrnList;
                                connector.Connecto = Destination;
                                connector.ToDPoint = "X" + newpoints.X + " " + "Y" + newpoints.Y;
                                Destination = string.Empty;
                                Source = string.Empty;
                            }
                            else
                            {
                                List<string> addList = new List<string>();
                                addList.Add(Destination);
                                _UpdateDic.Add(Source, addList);
                                connector.Connecto = Destination;
                                connector.ToDPoint = "X" + newpoints.X + " " + "Y" + newpoints.Y;
                                Destination = string.Empty;
                                Source = string.Empty;
                            }
                            _IsLineComplete = true;
                        }
                    }
                    // this.cadImage.ClearSelection();
                    this.cadImage.ClearMarkers();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show("Error in Connector", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DisableEntityCreator()
        {
            if (this.entCreator.Enabled)
                if ((this.entCreator.Type == CreatorType.Pen) || ((this.entCreator.Type == CreatorType.Polyline)
                                                                  && this.entCreator.EndPoly) || (this.entCreator.Type == CreatorType.Point))
                    this.entCreator.Disable();
        }
        private void SetAllFormsSettings()
        {
            this.SetAllFormsLanguageSettings();
            //this.entCreator.OptionsForm.ChangeLngPath += new CADImport.CADImportForms.ChangeLngPathEventHandler(ReloadLNG);
            this.entCreator.OptionsForm.ChangeLanguage += new CADImport.CADImportForms.ChangeLanguageEventHandler(ChangeLanguage);
        }
        public void ChangeLanguage(string val, int index)
        {
            //curLngInd = index;
            lngFile = val + ApplicationConstants.lngextstr;
            SetAllFormsLanguageSettings();
            //SetLNG();
            this.ChangeControlState();
        }
        //private void AddImageEnt(DPoint _Drgpoint,ref string filename)//string path
        //{
        //    try
        //    {
        //         _Drgpoint.X = _Drgpoint.X - 500;
        //        _Drgpoint.Y = _Drgpoint.Y - 500;
        //        if (!PackageFrm)
        //        {
        //            string FilePath = string.Empty;
        //            string DeleteName = string.Empty;
        //            string vl = string.Empty;
        //            bool Check = false;
        //            int randomNumber1 = 0;                 
        //            if (_HoldImagePat.Count == 0) return;
        //            filename = SetMachineName;
        //            FilePath = _HoldImagePat[SetMachineName];
        //            CADImageDef vImageDef = new CADImageDef();
        //            string SysGenNo = string.Empty;
        //            if (_DicMachineNo.ContainsKey(SetMachineName.Split('.')[0]))
        //            {
        //                var count = _DicMachineNo[SetMachineName.Split('.')[0]].Count();
        //                for (int i = 0; i <= _DicMachineNo.Count; i++)
        //                {
        //                    vl = string.Concat(SetMachineName.Split('.')[0], "_", i);
        //                    if (_DeletedMachineDic.ContainsKey(vl))
        //                    {
        //                        SysGenNo = _DeletedMachineDic[vl];
        //                        Check = true;
        //                        _DeletedMachineDic.Remove(vl);
        //                        break;
        //                    }
        //                    else
        //                    {
        //                        if (_DicMachineNo.ContainsKey(vl))
        //                        {
        //                            randomNumber1 = i;
        //                        }

        //                    }

        //                }
        //                if (Check)
        //                {
        //                    DeleteName = vl;
        //                }
        //                else
        //                {
        //                    DeleteName = SetMachineName.Split('.')[0] + "_" + ++randomNumber1;
        //                    if (_DeletedMachineDic.ContainsKey(DeleteName))
        //                    {
        //                        SysGenNo = _DeletedMachineDic[DeleteName];
        //                        _DeletedMachineDic.Remove(DeleteName);
        //                    }
        //                    else
        //                    {
        //                        SysGenNo = "M" + "-" + MechineNumber;
        //                    }
        //                }

        //                _DicMachineNo.Add(DeleteName, SysGenNo);
        //                _MachineCordinates.Add(DeleteName, _Drgpoint);
        //                randomNumber1 = 0;
        //                SetMachineName = SetMachineName.Split('.')[0];
        //                vImageDef.FileName = FilePath;// vSetMachineName.Split('.')[0] + randomNumber;                                               
        //                SysGenNo = string.Empty;
        //                DeleteName = string.Empty;
        //                Check = false;
        //                vl = string.Empty;
        //                //IsDuplicateIcon = true;                       
        //                //return;
        //            }
        //            else
        //            {
        //                vImageDef.FileName = FilePath;
        //                vImageDef.Color = Color.DarkRed;
        //                if (_DeletedMachineDic.ContainsKey(SetMachineName.Split('.')[0]))
        //                {
        //                    SysGenNo = _DeletedMachineDic[SetMachineName.Split('.')[0]];
        //                    _DeletedMachineDic.Remove(SetMachineName.Split('.')[0]);
        //                }
        //                else
        //                {
        //                    SysGenNo = "M" + "-" + MechineNumber;
        //                }
        //                _DicMachineNo.Add(SetMachineName.Split('.')[0], SysGenNo);

        //                _MachineCordinates.Add(SetMachineName.Split('.')[0], _Drgpoint);
        //            }
        //            if (new Bitmap(vImageDef.FileName) != null)
        //            {
        //                AddEntToSection(ConvSection.ImageDefs, vImageDef);
        //                CADImageEnt vImageEnt = new CADImageEnt();
        //                vImageEnt.ImageDef = vImageDef;
        //                vImageEnt.UVector = CADConst.XOrtAxis;
        //                vImageEnt.VVector = CADConst.YOrtAxis;
        //                vImageEnt.Size = vImageEnt.ImageDef.Size;
        //                vImageEnt.Color = Color.DarkRed;
        //                vImageEnt.TransparentColor = Color.White;                      
        //                vImageEnt.Point = _Drgpoint;
        //                //Debug.Print("Drop Points X" + _Drgpoint.X);
        //                //Debug.Print("Drop Points Y" + _Drgpoint.Y);
        //                vImageEnt.Height = 146;
        //                vImageEnt.Width = 1000;
        //                if (!PlaceEntity(vImageEnt))
        //                    this.cadImage.Converter.ImageDefs.Remove(vImageDef);
        //                // btnAddGradientHatch_Click();
        //            }
        //            MechineNumber++;
        //            SetMachineName = string.Empty;
        //        }
        //        else
        //        {
        //            DropPackageMachine(_Drgpoint);
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        MechineNumber--;
        //        XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
       
        public void DropPackageMachine(DPoint _Drgpoint)
        {
            try
            {
                DPoint ReCallPoint;
                string FilePath = string.Empty;
                if (DragfileName == null) return;
                CADImageDef vImageDef = new CADImageDef();
                string SysGenNo = "PKG" + "-" + "001";
                if (_HoldImagePat.ContainsKey(this.package.PackageMachineName))
                    FilePath = _HoldImagePat[this.package.PackageMachineName];

                vImageDef.FileName = FilePath;
                if (!IsReCallPKG)
                {
                    if (!_DicMachineNo.ContainsKey(SetMachineName.Split('.')[0]))
                    {
                        _DicMachineNo.Add(SetMachineName.Split('.')[0], SysGenNo);
                        _MachineCordinates.Add(SetMachineName.Split('.')[0], _Drgpoint);
                    }
                    if (!_HoldPackageMachine.ContainsKey(SetMachineName.Split('.')[0]))
                    {
                        _HoldPackageMachine.TryAdd(this.package.PackageMachineName, this.package);
                    }
                }
                if (new Bitmap(vImageDef.FileName) != null)
                {
                    AddEntToSection(ConvSection.ImageDefs, vImageDef);
                    CADImageEnt vImageEnt = new CADImageEnt();
                    vImageEnt.ImageDef = vImageDef;
                    vImageEnt.UVector = CADConst.XOrtAxis;
                    vImageEnt.VVector = CADConst.YOrtAxis;
                    vImageEnt.Size = vImageEnt.ImageDef.Size;
                    vImageEnt.Color = Color.DarkRed;
                    vImageEnt.TransparentColor = Color.White;
                    if (!IsReCallPKG)
                    {
                        vImageEnt.Point = _Drgpoint;
                    }
                    else
                    {
                        // string FileName = RemoveIntegers(SetMachineName.Split('.')[0]);
                        vImageEnt.Point = _MachineCordinates[SetMachineName.Split('.')[0]];  // Re-Call Points Draw....
                    }
                    vImageEnt.Height = 146;
                    vImageEnt.Width = 1000;
                    if (!PlaceEntity(vImageEnt))
                        this.cadImage.Converter.ImageDefs.Remove(vImageDef);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool PlaceEntity(CADEntity aEntity, string aLayoutName)
        {
            CADLayout vLayout;
            if (aLayoutName == "")
                vLayout = this.cadImage.Layouts[0];
            else
                vLayout = this.cadImage.Converter.LayoutByName(aLayoutName);

            if (vLayout == null) return false;
            this.cadImage.Converter.Loads(aEntity);
            vLayout.AddEntity(aEntity);
            this.cadPictBox.Invalidate();
            SetMachineName = string.Empty;
            return true;
        }
        private bool PlaceEntity(CADEntity aEntity)
        {
            return PlaceEntity(aEntity, "");
        }
        private void AddEntToSection(ConvSection aSection, CADEntity aEntity)
        {

            this.cadImage.Converter.Loads(aEntity);
            this.cadImage.Converter.GetSection(aSection).AddEntity(aEntity);
        }
        public void SetAddEntityMode(CreatorType val)
        {
            try
            {
                if (this.package != null)
                {
                    this.package.LineName = LineName;
                    this.package.SetAddEntityMode(val);
                }
                else
                {
                    int tmpVal = addEntity;
                    addEntity = -1;
                    int ct = (int)val;
                    if (tmpVal != ct)
                        addEntity = ct;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("SetAddEntityMode");
            }
        }
        private void EndAddEntity(bool val)
        {
            try
            {
                if (curAddEntityType != CreatorType.Undetected)
                {
                    if (_IsLineComplete)
                        AssignLineName(curAddEntityType);

                    SetAddEntityMode(curAddEntityType);
                    //SetEnableChecked();
                    ChangeControlState();
                }
                this.detMouseDown = val;
            }
            catch (Exception Ex)
            {
                MessageBox.Show("EndAddEntity");
            }
        }
        private bool EnableNewEntityCreator()
        {
            try
            {
                CreatorType seltp = (CreatorType)addEntity;
                if (seltp != CreatorType.Undetected)
                {
                    this.entCreator.EnableCreator(seltp);
                    curAddEntityType = seltp;
                    return true;
                }
                return false;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "EnableNewEntityCreator", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool ChangeEntityOnMouseMove(Point pt)
        {
            #region Professional
            //#if Professional
            if (this.cadImage.SelectedEntities.Count != 0)
            {
                if (this.CreateNewEntity) return true;

                this.cadImage.CorrectByGridAndOrtho(ref pt, this.cADProperty.cX, this.cADProperty.cY, this.cadPictBox.Ortho);

                if (cadImage.CurrentMarker != null)
                {
                    if (!IsCadLocked)
                    {
                        ChangeMarkerPosition(pt.X, pt.Y);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (moveMarker)// this conditon for move the entity from current drop position to new drop position
                {
                    if (!IsCadLocked)
                    {
                        ChangeEntityPositionExt(pt.X, pt.Y);//this conditon for move the entity from current drop position to new drop position
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            // #endif
            #endregion
            return false;
        }
        /// <summary>
        ///  this is for update cordinates dictionary while moving the current entity position 
        /// </summary>
        public void SetNewEntityPosition()
        {

            try
            {
                if (RoleType.Admin == (RoleType)HindalcoiOS.Properties.Settings.Default.RoleID)
                {
                    if ((this.startPoint.X != 0) || (this.startPoint.Y != 0))
                    {
                        if (this.endPoint == Point.Empty)
                            this.endPoint = new Point(this.cADProperty.cX, this.cADProperty.cY);
                        DPoint p = this.GetRealPoint(this.endPoint.X - this.startPoint.X, this.endPoint.Y - this.startPoint.Y, !this.cadPictBox.Ortho, false);
                        cadImage.SetNewPosEntitiesExt(p.X, p.Y, p.Z, this.cadPictBox.CreateGraphics());
                        this.startPoint.X = 0;
                        this.startPoint.Y = 0;
                        this.endPoint.X = 0;
                        this.endPoint.Y = 0;
                        CADEntity CadName = this.cadImage.SelectedEntities.AsEnumerable().FirstOrDefault();
                        if (CadName != null && CadName.EntType == EntityType.ImageEnt)
                        {
                            if (this.cadImage.SelectedEntities.Count == 1 && !string.IsNullOrEmpty(ImageName))
                            {
                                DPoint newpoints = UpdateCord(((CADImport.CADImageEnt)CadName).Point);
                                _MachineCordinates[ImageName] = newpoints;
                                ImageName = string.Empty;
                                ImageName = null;
                                this.cadImage.ClearSelection();
                                this.cadImage.ClearMarkers();
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {

                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SetNewMarkerPosition()
        {
            try
            {
                if (this.cadImage == null) return;
                if ((this.startPoint.X != 0) || (this.startPoint.Y != 0))
                {
                    if (this.endPoint == Point.Empty)
                        this.endPoint = new Point(this.cADProperty.cX, this.cADProperty.cY);
                    DPoint p = this.GetRealPoint(this.endPoint.X - this.startPoint.X, this.endPoint.Y - this.startPoint.Y,
                        !this.cadPictBox.Ortho, false);
                    cadImage.SetNewEntityMarkerPos(p.X, p.Y, p.Z);
                    this.startPoint.X = 0;
                    this.startPoint.Y = 0;
                    this.endPoint.X = 0;
                    this.endPoint.Y = 0;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void UseClipRect()
        {
            if ((this.clipRectangle.ClientRectangle.Width <= 10) ||
                (this.clipRectangle.ClientRectangle.Height <= 10))
                return;
            MultipleSelect();
        }
        private bool MultipleSelect()
        {
            if (cadImage.SelectionMode == SelectionEntityMode.Enabled)
            {
                int l = this.clipRectangle.ClientRectangle.Left;
                int t = this.clipRectangle.ClientRectangle.Top;
                DPoint pt1 = this.GetRealPoint(l, t, false);
                DPoint pt2 = this.GetRealPoint(this.clipRectangle.ClientRectangle.Right, this.clipRectangle.ClientRectangle.Bottom, false);
                DRect tmpRect = new DRect(pt1.X, pt1.Y, pt2.X, pt2.Y);
                return true;
            }
            return false;
        }
        public bool ChancelMove(int x, int y)
        {
            if (((Math.Abs(this.cADProperty.cX - x) < 2) && (Math.Abs(this.cADProperty.cY - y) < 2)) ||
                (this.cadImage.SelectEntitiesCount == 0))
            {
                return true;
            }
            return false;
        }
        private void ChangeEntityPositionExt(int x, int y)
        {
            Graphics gr = this.cadPictBox.CreateGraphics();
            this.cadImage.DrawMoveEntityTrace(-this.startPoint.X, -this.startPoint.Y, this.cadPictBox);
            this.cadImage.DrawMoveEntityTrace(x - this.cADProperty.cX, y - this.cADProperty.cY, this.cadPictBox);
            this.startPoint.X = this.cADProperty.cX - x;
            this.startPoint.Y = this.cADProperty.cY - y;
        }
        private void ChangeMarkerPosition(int x, int y)
        {
            Graphics gr = this.cadPictBox.CreateGraphics();
            //repaint old
            if ((this.startPoint.X != 0) || (this.startPoint.Y != 0))
            {
                this.cadImage.DrawChangeEntity(this.startPoint.X, this.startPoint.Y, this.cadPictBox);
            }
            else
            {
                endPoint.X = x;
                endPoint.Y = y;
            }
            //paint new
            this.cadImage.DrawChangeEntity((this.cADProperty.cX - x), (this.cADProperty.cY - y), this.cadPictBox);
            this.startPoint.X = (this.cADProperty.cX - x);
            this.startPoint.Y = (this.cADProperty.cY - y);
        }
        public string MachineName(object _obj)
        {
            string MachineName = ((CADImport.CADImageEnt)_obj).ImageDef.FileName;
            string[] s = (MachineName.ToString()).Split('\\');
            return s[s.Length - 1].Split('.')[0];
        }
        private bool ChangeEntityOnMouseUp(Point pt)
        {
            bool Is_Sts = false;
            try
            {
                if (cadImage.CurrentMarker != null)
                {
                    if (!ChancelMove(pt.X, pt.Y))
                    {
                        if (!IsCadLocked)
                        {
                            SetNewMarkerPosition();
                            Is_Sts = true;
                        }
                        else
                        {
                            Is_Sts = false;
                        }
                        return Is_Sts;
                    }
                }
                else
                {
                    if (!CreateNewEntity)
                    {
                        if (!ChancelMove(pt.X, pt.Y))
                        {
                            if (!IsCadLocked)
                            {
                                SetNewEntityPosition();
                                Is_Sts = true;
                            }
                            else
                            {
                                Is_Sts = false;
                            }
                            return Is_Sts;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Is_Sts;
        }
        public void RemoveEntity()
        {
            try
            {
                if (RoleType.Admin == (RoleType)HindalcoiOS.Properties.Settings.Default.RoleID)
                {
                    CADEntity cad = this.cadImage.SelectedEntities.FirstOrDefault();
                    bool IsameConnectMacgine = false;
                    string IconNameRemove = string.Empty;
                    bool isFileDEleted = false;
                    DPoint RemoveDic;
                    if (cad == null) return;

                    #region Remove Image From CadLayout
                    if (this.cadImage != null && cad != null && cad.EntType == EntityType.ImageEnt && ((CADImport.CADImageEnt)cad).ImageDef != null)
                    {
                        DPoint _DrgpointReceivePoints = UpdateCord(((CADImport.CADImageEnt)cad).Point);
                        string IconName = string.Empty;
                        IconName = MachineName(cad);
                        #region Package Mechine Delete Package Machine From Dictionary....
                        //if (_HoldPackageMachine.ContainsKey(IconName))
                        //{
                        //    PackageMachine.PackageMachine ff = null;
                        //    _HoldPackageMachine.TryRemove(IconName, out ff);
                        //    IconName = RemoveIntegers(IconName);
                        //    IsReCallPKG = false;
                        //}
                        //else
                        //{
                        //    IconName = MachineName(cad);
                        //}   
                        #endregion

                        #region Remove Related Connector from the Connected Machine
                        if (_MachineCordinates.ContainsValue(_DrgpointReceivePoints))
                        {
                            List<string> Dic = _UpdateDic.Keys.ToList();
                            for (int i = 0; i < Dic.Count; i++)
                            {
                                try
                                {
                                    string keyvale = Dic[i];
                                    List<string> _listCount = _UpdateDic[keyvale];
                                    string ListIcon = _MachineCordinates.FirstOrDefault(X => X.Value == _DrgpointReceivePoints).Key.ToString();
                                    if (_listCount.Contains(ListIcon) || keyvale == ListIcon)
                                    {
                                        List<string> FirList = _listconnt.Keys.ToList();
                                        for (int m = 0; m < FirList.Count; m++)
                                        {
                                            string dd = FirList[m];
                                            string fromcnn = _listconnt[dd].FromData;
                                            string Toconn = _listconnt[dd].Connecto;
                                            if (fromcnn == ListIcon || Toconn == ListIcon)
                                            {
                                                if (IsRemoteConnection)
                                                {
                                                    List<string> obh = _listconnt.Keys.ToList();
                                                    for (int j = 0; j < obh.Count; j++)
                                                    {
                                                        string KeyList = obh[j];
                                                        Connector ff = _listconnt[KeyList];
                                                        if (dd == KeyList)
                                                        {
                                                            _listconnt.Remove(KeyList);
                                                            List<string> _list = _UpdateDic[ff.Connecto];
                                                            if (_list.Count > 1)
                                                            {
                                                                _list.Remove(ff.FromData);
                                                            }
                                                            else
                                                            {
                                                                _list.Remove(ff.FromData);
                                                                _UpdateDic.Remove(ff.Connecto);
                                                            }
                                                            break;
                                                        }
                                                    }
                                                }
                                                else
                                                {

                                                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Can't Remove Machine.\n Please Remove Connection First Then Remove Machine", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    return;

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
                        }
                        #endregion

                        #region Remove Machine From Cad Layout

                        if (IconName.Contains("RC"))
                        {
                            _RcConnectorDic.Remove(_DrgpointReceivePoints);
                            RCNumber = _RcConnectorDic.Count;
                            RemoveRemoteConnectionData("X" + _DrgpointReceivePoints.X + " " + "Y" + _DrgpointReceivePoints.Y, "RC");
                        }
                        else
                        {
                            // ########### Image Delete From layout and Dictinary######################
                            if (_MachineCordinates.ContainsValue(_DrgpointReceivePoints))
                            {
                                string KeyValue = _MachineCordinates.FirstOrDefault(X => X.Value == _DrgpointReceivePoints).Key.ToString();
                                string Value = string.Empty;
                                if (_DicMachineNo.ContainsKey(KeyValue))
                                {
                                    Value = _DicMachineNo[KeyValue];
                                    _DicMachineNo.Remove(KeyValue);
                                    GlobalDeclaration._MyTagDictinary.Remove(_DrgpointReceivePoints);
                                    string delmachine = KeyValue + "_" + Value;
                                    DeleteFileMCD(delmachine);
                                    _MachineCordinates.Remove(KeyValue);
                                    DeleteMachineDataFromDB("X" + _DrgpointReceivePoints.X + " " + "Y" + _DrgpointReceivePoints.Y, KeyValue);
                                }
                            }
                        }
                        this.cadImage.RemoveEntity(cad);
                        IconName = string.Empty;
                        #endregion
                    }
                    #endregion

                    #region Leader Line Remove 
                    else if (this.cadImage != null && cad != null && (cad.EntType == EntityType.Polyline || cad.EntType == EntityType.Leader))
                    {
                        string ConnectFrom = string.Empty;
                        string LineKey = string.Empty;
                        string ConnectorTo = string.Empty;
                        if (_listconnt.Count > 0)
                        {
                            CADPolyLine cadline = (CADPolyLine)cad;
                            DPoint LatestCord = UpdateCord(cadline.DottedSingPoints[1]);
                            if (cad.EntType == EntityType.Polyline)
                            {
                                ConnectFrom = _listconnt.FirstOrDefault(X => X.Value.Points == LatestCord.X + "~" + LatestCord.Y).Value.FromData;
                                ConnectorTo = _listconnt.FirstOrDefault(X => X.Value.Points == LatestCord.X + "~" + LatestCord.Y).Value.Connecto;
                                if (cadline.LineType.Name == null)
                                {
                                    this.cadImage.RemoveEntity(cad);
                                    return;
                                }
                                if (IsReloadLine && cadline.LineType.Name.ToUpper() == "BYLAYER")
                                {
                                    if (_listconnt.Count > 0)
                                    {
                                        LineKey = _listconnt.FirstOrDefault(X => X.Value.Points == LatestCord.X + "~" + LatestCord.Y).Key;
                                    }
                                }
                                else
                                {
                                    LineKey = cad.LineType.Name;
                                }
                            }
                            //else if(cad.EntType == EntityType.Polyline)//Poly Line Check
                            //{
                            //    CADPolyLine pline = (CADPolyLine)cad;
                            //    ConnectFrom = _listconnt.FirstOrDefault(X => X.Value.Points == pline.DottedSingPoints[1].X + "~" + pline.DottedSingPoints[1].Y).Value.FromData;
                            //    ConnectorTo = _listconnt.FirstOrDefault(X => X.Value.Points == pline.DottedSingPoints[1].X + "~" + pline.DottedSingPoints[1].Y).Value.Connecto;
                            //    if (IsReloadLine && pline.LineType.Name.ToUpper() == "BYLAYER")
                            //    {
                            //        if (_listconnt.Count > 0)
                            //        {
                            //            LineKey = _listconnt.FirstOrDefault(X => X.Value.Points == pline.DottedSingPoints[1].X + "~" + pline.DottedSingPoints[1].Y).Key;
                            //        }
                            //    }
                            //    else
                            //    {
                            //        LineKey = cad.LineType.Name;
                            //    }
                            //}

                            if (!string.IsNullOrEmpty(LineKey))
                            {
                                if (_listconnt.ContainsKey(LineKey))
                                    _listconnt.Remove(LineKey);
                            }
                            else
                            {
                                this.cadImage.RemoveEntity(cad);
                            }

                            //if (LineIncreament > 1)
                            //    LineIncreament--;
                            DeleteConnectionProperty(LatestCord.X + " " + LatestCord.Y, LineKey);//dPoint.X + " " + dPoint.Y
                        }
                        if (_UpdateDic.Count > 0)
                        {
                            if (ConnectorTo != null)
                            {
                                if (_UpdateDic.ContainsKey(ConnectorTo))
                                {
                                    List<string> _list = _UpdateDic[ConnectorTo];
                                    if (_list.Count > 1)
                                    {
                                        _list.Remove(ConnectFrom);
                                    }
                                    else
                                    {
                                        _list.Remove(ConnectFrom);
                                        _UpdateDic.Remove(ConnectorTo);
                                    }
                                }
                                if (_UpdateDic.Count == 1)
                                {
                                    _UpdateDic.Clear();
                                }
                            }
                        }
                        this.cadImage.RemoveEntity(cad);
                    }
                    #endregion

                    #region PloyLine Delete
                    else if (this.cadImage != null && cad != null && (cad.EntType == EntityType.Polyline))
                    {
                        this.cadImage.RemoveEntity(cad);
                    }
                    #endregion

                    #region Remove Text From CadLayour
                    else if (this.cadImage != null && cad != null && cad.EntType == EntityType.Text && ((CADImport.CADText)cad).Text != null)
                    {
                        this.cadImage.RemoveEntity(cad);
                    }
                    #endregion
                    #region Circle Remove from layout
                    else if (this.cadImage != null && cad != null && cad.EntType == EntityType.Circle && ((CADImport.CADCircle)cad).EntName == "Circle")
                    {
                        this.cadImage.RemoveEntity(cad);
                    }
                    #endregion
                    #region Hatch Remove from layout
                    else if (this.cadImage != null && cad != null && cad.EntType == EntityType.Hatch && ((CADImport.CADHatch)cad).EntName == "Hatch")
                    {
                        this.cadImage.RemoveEntity(cad);
                    }
                    #endregion
                    this.ClearSelection();
                    this.cadImage.RefreshCurrentLayout();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RemoveRemoteConnectionData(string points, string name)
        {
            int sts = Resources.Instance.RemoveEntry("SP_RemoveRemoteConnection", "p_RcCordinate", points);
            if (sts > 0)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Successfully Deleted Information of \n " + name + " from DB.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void DeleteMachineDataFromDB(string points, string name)
        {
            try
            {
                int sts = Resources.Instance.RemoveEntry("Sp_DeleteMachineData", "p_Mlocation", points);
                if (sts > 0)
                {
                    XtraMessageBox.Show("Successfully Deleted Information of \n " + name + " from DB.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteFileMCD(string Delfilename)
        {
            string Path = Application.StartupPath + @"\" + "Application_Machines";
            if (Directory.Exists(Path))
            {
                DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(Path);
                FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + Delfilename + "*.*");
                foreach (FileInfo foundFile in filesInDir)
                {
                    foundFile.Delete();

                }
            }
        }

        private void DeleteConnectionProperty(string points, string LineName)
        {
            try
            {
                int Sts = Resources.Instance.RemoveEntry("Sp_DeleteConnectionProc", "p_Mlocation", "p_userName", "p_userId", "p_empCode", points, GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].UserId.ToString(), GlobalDeclaration._holdInfo[0].EmpCode);
                if (Sts > 0)
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Successfully Deleted Information of \n " + LineName + " from DB.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool CreateNewEntity
        {
            get
            {
                try
                {
                    bool isHatch = (CreatorType)addEntity == CreatorType.Hatch;
                    bool _ILeadre = (CreatorType)addEntity == CreatorType.Leader;
                    if (_ILeadre)
                    {

                    }
                    if ((this.cadImage == null) && isHatch)
                        return false;
                    if (this.cadImage != null)
                        if ((this.cadImage.SelectedEntities.Count == 0) && isHatch)
                            return false;
                    return (addEntity != -1);
                }
                catch (Exception)
                {
                    MessageBox.Show("CreateNewEntity");
                    return false;
                }
            }

        }
        public void CreateNewSettingsList()
        {
            string tmp;
            settingsLst = new SortedList();
            //Language path
            settingsLst.Add(ApplicationConstants.languagepath, this.mlng.Path);
            //Language
            settingsLst.Add(ApplicationConstants.languagestr, lngFile);
            ////Language ID
            //settingsLst.Add(ApplicationConstants.languageIDstr, this.curLngInd);
            //BackgroundColor
            if (cadPictBox.BackColor == Color.Black)
                tmp = ApplicationConstants.blackstr2;
            else tmp = ApplicationConstants.whitestr;
            settingsLst.Add(ApplicationConstants.backcolorstr, tmp);
            //Show entity panel
            //settingsLst.Add(ApplicationConstants.showentitystr, this.trvPanel.Visible);
            //Color drawing
            settingsLst.Add(ApplicationConstants.colordrawstr, this.colorDraw);
            //SHXPathCount
            int cn = this.shxFrm.lstDir.Items.Count;
            settingsLst.Add(ApplicationConstants.shxpathcnstr, this.shxFrm.lstDir.Items.Count);
            //SHXPaths
            for (int i = 0; i < cn; i++)
            {
                settingsLst.Add(string.Format("SHXPath_{0}", (i + 1)), this.shxFrm.lstDir.Items[i]);
            }

            #region protect
#if protect
			//License

#else
            settingsLst.Add("Type license", "register");
#endif
            #endregion
        }
        public void ClearSelection()
        {
            this.entCreator.Disable();
            this.stopSnap = true;
            if (this.cadImage == null)
                return;
            this.cadImage.ClearSelection();
            this.cadImage.ClearMarkers();
            this.cadImage.RefreshCurrentLayout();
            this.cadPictBox.Invalidate();
          
        }
        public void LoadAllMachines(string FileName)
        {
            try
            {
                string Filelocation = GlobalDeclaration.ReturnPath();
                Filelocation = Path.Combine(Filelocation, "SparrowCAD");
                if (this.cadImage == null)
                    return;
                var ImageDef = this.cadImage.CurrentLayout.Entities.AsEnumerable().Where(X => X.EntType == EntityType.ImageEnt).ToList();
                if (ImageDef.Count > 0)
                {
                    for (int i = 0; i < ImageDef.Count; i++)
                    {
                        CADEntity Ent = ImageDef[i];
                        string MachinePath = ((CADImport.CADImageEnt)Ent).ImageDef.FileName;
                        string MachineName = this.MachineName(Ent);
                        if (!_HoldImagePat.ContainsKey(MachineName))
                        {
                            _HoldImagePat.TryAdd(MachineName, MachinePath);
                        }
                    }
                    string FName = string.Concat(FileName, "Dxf");
                    string fileextentiontype = IniFile.IniReadValue("DBConfig", "FileExtension").Trim();
                    if (fileextentiontype == ".spr")
                        fileextentiontype = ".xml";
                    if (File.Exists(string.Concat(Filelocation, @"\", FName, fileextentiontype)))
                    {
                        LoadMachineFromXML(string.Concat(Filelocation, @"\", FName, fileextentiontype));
                    }
                    if (File.Exists(string.Concat(Filelocation, @"\", FileName, fileextentiontype)))
                    {
                        _UpdateDic = SerializationXml.DeSerialize(string.Concat(Filelocation, @"\", FileName, fileextentiontype)).Map_list;
                        if (fileextentiontype == ".xml")
                            _listconnt = GlobalDeclaration.LoadConnectorStruct(string.Concat(Filelocation, @"\", FileName, "~", "LC", fileextentiontype));
                        else
                            _listconnt = GlobalDeclaration.LoadConnectorStruct(string.Concat(Filelocation, @"\", FileName, "~", FileNameDisplayLine));
                        IsReloadLine = true;
                        //LineIncreament = _listconnt.Count;
                    }
                    if (File.Exists(string.Concat(Filelocation, @"\", FileName, "~MTag", fileextentiontype)))
                    {
                        GlobalDeclaration._MyTagDictinary = GlobalDeclaration.LoadMachineTag(string.Concat(Filelocation, @"\", FileName, "~MTag", fileextentiontype));
                    }
                    if (File.Exists(string.Concat(Filelocation, @"\", FileName, "~RC", fileextentiontype)))
                    {
                        _RcConnectorDic = GlobalDeclaration.LoadRCMachines(Filelocation + @"\" + FileName + "~RC" + fileextentiontype);
                        RCNumber = _RcConnectorDic.Count;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadMachineFromXML(string path)
        {
            try
            {
                var Diclist = GlobalDeclaration.GetDictionary(path);
                _DicMachineNo = Diclist.Item1;
                this._MachineCordinates = Diclist.Item2;
            }
            catch (Exception Ex)
            {

                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void MoveEntity(int x1, int y1, int x2, int y2)
        {
            cadImage.ClearSnapTrace();
            DPoint p1 = this.GetRealPoint(x1, y1, !this.cadPictBox.Ortho);
            DPoint p2 = this.GetRealPoint(x1 - x2, y1 - y2, !this.cadPictBox.Ortho);
            cadImage.SetNewPosEntitiesExt(p2.X - p1.X, p2.Y - p1.Y, p2.Z - p1.Z, this.cadPictBox.CreateGraphics());
        }
        private void RemoveFormDic(object sender, string value)
        {
            try
            {
                Machine_Edit_Data machine_Edit_Data = EditfrmDictionary[value];
                EditfrmDictionary.TryRemove(value, out machine_Edit_Data);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// clear all the existing object and container
        /// </summary>
        public void ClearAllDictionayObject()
        {
            try
            {
                if (cadImage != null)
                {
                    cadImage.Dispose();
                    cadImage = null;
                    Destination = string.Empty;
                    Source = string.Empty;
                    this.entCreator.Image = null;
                    this.cadPictBox.Invalidate();
                    _HoldImagePat.Clear();
                    _DicMachineNo.Clear();
                    _UpdateDic.Clear();
                    _HoldPackageMachine.Clear();
                    EditfrmDictionary.Clear();
                    _MachineCordinates.Clear();
                    _LineTypeHold.Clear();
                    _listconnt.Clear();
                    _DeletedMachineDic.Clear();
                    RCNumber = 1;
                    IsReloadLine = false;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(
                    Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void InitLng()
        {
            try
            {
                mlng = new MultipleLanguage(this.GetType());
                //Save value of NoName elements

                if (this.ContextMenu != null)
                    mlng.SaveNameMenuItem(this.ContextMenu.MenuItems);
                mlng.SaveNameNoNameElement(this.Controls);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(
                    Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// CadImage object assign to print form
        /// </summary>
        private void InitialNewPrintPages()
        {
            this.prtForm.Image = this.cadImage;
            this.prtForm.CreateNewPages();
        }
        /// <summary>
        /// Cad File Position Set
        /// </summary>
        private void Shift()
        {
            cADProperty.LeftImagePosition = cADProperty.PreviousPosition.X - (cADProperty.PreviousPosition.X - cADProperty.LeftImagePosition) * cADProperty.ImageScale / cADProperty.ImagePreviousScale;
            cADProperty.TopImagePosition = cADProperty.PreviousPosition.Y - (cADProperty.PreviousPosition.Y - cADProperty.TopImagePosition) * cADProperty.ImageScale / cADProperty.ImagePreviousScale;
            cADProperty.ImagePreviousScale = cADProperty.ImageScale;
        }
        /// <summary>
        /// Fixed Zoom position of Loaded Cad File
        /// </summary>
        /// <param name="value"></param>
        private void Zoom(float value)
        {
            if (cadImage == null) return;
            cADProperty.ImageScale = cADProperty.ImageScale * value;
            if (cADProperty.ImageScale < 0.005f)
                cADProperty.ImageScale = 0.005f;
            this.cadPictBox.Invalidate();
            this.stopSnap = true;
            this.entCreator.Disable();
        }
        /// <summary>
        ///  Draw Cad Image on CadPicture Box
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="render"></param>
        public void DrawCADImage(Graphics gr, Control render)
        {
            Shift();
            RectangleF tmp = cADProperty.ImageRectangleF;
            SetSizePictureBox(new Size((int)tmp.Width, (int)tmp.Height));
            SetPictureBoxPosition(this.cADProperty.Position);
            try
            {
                cadImage.Draw(gr, tmp, render);
            }
            catch
            {
                XtraMessageBox.Show("Unable Draw File..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Make same size of CadImage and Picture box
        /// </summary>
        /// <returns></returns>
        private bool SizeEqualSizeImageAndPictBox()
        {
            RectangleF tmp = this.cADProperty.ImageRectangleF;
            return ((tmp.Width <= this.cadPictBox.Size.Width) || (tmp.Height <= this.cadPictBox.Height));
        }
        /// <summary>
        /// Set Cad Picture Box Size 
        /// </summary>
        /// <param name="sz"></param>
        public void SetSizePictureBox(Size sz)
        {
            try
            {
                if ((((cADProperty.pos.X < 0) || (cADProperty.pos.Y < 0)) ||
                     ((cADProperty.pos.X + sz.Width > this.cadPictBox.Width) ||
                      (cADProperty.pos.Y + sz.Height > this.cadPictBox.Height))) && (SizeEqualSizeImageAndPictBox()))
                {
                    if (cADProperty.pos.X < 0)
                        sz.Width = (int)(this.cadPictBox.Width - cADProperty.pos.X);
                    if (cADProperty.pos.Y < 0)
                        sz.Height = (int)(this.cadPictBox.Height - cADProperty.pos.Y);
                    if (cADProperty.pos.X + sz.Width > this.cadPictBox.Width)
                        sz.Width = (int)(this.cadPictBox.Width + cADProperty.pos.X);
                    if (cADProperty.pos.Y + sz.Height > this.cadPictBox.Height)
                        sz.Height = (int)(this.cadPictBox.Height + cADProperty.pos.Y);
                }

                this.cadPictBox.SetVirtualSizeNoInvalidate(sz);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.StackTrace, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Get the real points from the Layout whenever you click  on the layout 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="useGrid"></param>
        /// <returns></returns>
        public DPoint GetRealPoint(int x, int y, bool useGrid)
        {
            //RectangleF tmpRect = this.cADProperty.ImageRectangleF;
            //return CADConst.GetRealPoint(x, y, this.cadImage, tmpRect);
            return GetRealPoint(x, y, useGrid, true);
        }
        /// <summary>
        /// Get the real points from the Layout whenever you click  on the layout 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="useGrid"></param>
        /// <param name="rounding"></param>
        /// <returns></returns>
        public DPoint GetRealPoint(int x, int y, bool useGrid, bool rounding)
        {

            RectangleF tmpRect = this.cADProperty.ImageRectangleF;
            DPoint realPt = CADConst.GetRealPoint(x, y, this.cadImage, tmpRect, rounding);
            if (useGrid)
                this.cadImage.CorrectByGrid(ref realPt);
            return realPt;
        }
        /// <summary>
        /// Reset Cad Scale
        /// </summary>
        public void ResetScaling()
        {
            this.cADProperty.ImageScale = 1.0f;
            this.cADProperty.ImagePreviousScale = 1.0f;
            this.cADProperty.LeftImagePosition = (cadPictBox.ClientRectangle.Width - this.cADProperty.VisibleAreaSize.Width) / 2.0f;
            this.cADProperty.TopImagePosition = (cadPictBox.ClientRectangle.Height - this.cADProperty.VisibleAreaSize.Height) / 2.0f;
            cadPictBox.Invalidate();
        }
        /// <summary>
        ///  Open the Dialogbox for the select CAD File 
        /// </summary>
        /// <param name="dlg">Pass the Boolean Value</param>
        public void ShowLoadFileDialog(ref bool dlg, ref string filenameref)
        {
            try
            {
                SetPictureBoxLoadState(true, string.Empty);
                DialogResult dlgRes = dlgOpenfile.ShowDialog(this);
                if ((dlgRes != DialogResult.OK) || (string.IsNullOrEmpty(dlgOpenfile.FileName)))
                {
                    SetPictureBoxLoadState(false, dlgOpenfile.FileName);
                    return;
                }
                filenameref = dlgOpenfile.FileName;
                LoadFile(dlgOpenfile.FileName);
                SomeEvent += ParentWindow_SomeEvent;
                dlg = true;
                //Thread th = new Thread(new ThreadStart(LoadFile));
                //th.Name = "LoadCaDFile";
                //th.Start();

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void SetCadImageOptions(bool loadFirst)
        {
            try
            {
                SetSnapMode();
                cadImage.SelectionMode = SelectionEntityMode.Enabled;
                cadImage.GraphicsOutMode = DrawGraphicsMode.GDIPlus;
                cadImage.ChangeDrawMode(cadImage.GraphicsOutMode, cadPictBox);
                cadImage.IsWithoutMargins = true;
                ObjEntity.cadImage = cadImage;
                this.prtForm.Image = this.cadImage;
                //xmlImporter.Image = this.cadImage;
                // txtImporter.Image = this.cadImage;
                if (cadPictBox.BackColor == Color.White)
                    White_Click();
                else
                    Black_Click();
                ViewLayouts();
                if (this.colorDraw == false)
                    DoBlackColor();

                if (loadFirst)
                    DoResize();

                // ObjEntity.cadImage = cadImage;
                this.entCreator.Image = this.cadImage;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            // ribbon.Minimized = true;
        }

        public void DoBlackColor()
        {
            if (cadImage == null) return;
            cadImage.DrawMode = CADDrawMode.Gray;
            this.colorDraw = false;
            cadPictBox.Invalidate();
        }
        public void White_Click()
        {
            cadPictBox.BackColor = Color.White;
            if (this.cadImage != null)
                this.cadImage.BackgroundColor = Color.White;
            if (cadImage != null)
                cadImage.DefaultColor = Color.Black;
            if (this.clipRectangle != null)
                this.clipRectangle.Color = Color.Black;
        }
        public void Black_Click()
        {
            cadPictBox.BackColor = Color.Black;
            if (this.cadImage != null)
                this.cadImage.BackgroundColor = Color.Black;
            // this.trvEntity.BackColor = Color.Black;
            // this.trvEntity.ForeColor = Color.White;
            if (cadImage != null)
                cadImage.DefaultColor = Color.White;
            if (this.clipRectangle != null)
                this.clipRectangle.Color = Color.White;
        }
        public void ViewLayouts()
        {
            if (cadImage == null)
                return;
            cadImage.SetCurrentLayout(cadImage.DefaultLayoutIndex);
        }
        public void SetSnapMode()
        {
            if (this.cadImage != null)
                this.cadImage.EnableSnap = this.enableSnap;
        }
        public void DoResize()
        {
            if (cadImage == null)
                return;
            float wh = (float)(cadImage.AbsWidth / cadImage.AbsHeight);
            float new_wh = (float)this.cadPictBox.ClientRectangle.Width / (float)cadPictBox.ClientRectangle.Height;
            if (cadImage is CADRasterImage)
                cADProperty.visibleArea = new SizeF((float)cadImage.AbsWidth, (float)cadImage.AbsHeight);
            else
                cADProperty.visibleArea = cadPictBox.Size;
            if (new_wh > wh)
                cADProperty.visibleArea.Width = cADProperty.visibleArea.Height * wh;
            else
            {
                if (new_wh < wh)
                    cADProperty.visibleArea.Height = cADProperty.visibleArea.Width / wh;
                else
                    cADProperty.visibleArea = cadPictBox.Size;
            }
            this.cADProperty.LeftImagePosition = (cadPictBox.ClientRectangle.Width - cADProperty.visibleArea.Width) / 2.0f;
            cADProperty.TopImagePosition = (cadPictBox.ClientRectangle.Height - cADProperty.visibleArea.Height) / 2.0f;
            cadPictBox.Invalidate();
        }
        private void SetPictureBoxPosition(PointF value)
        {
            int w1, h1;
            if (value.X > 0)
                w1 = 0;
            else
                w1 = (int)Math.Abs(value.X);
            if (w1 > this.cadPictBox.VirtualSize.Width)
                w1 = this.cadPictBox.VirtualSize.Width;
            if (value.Y > 0)
                h1 = 0;
            else
                h1 = (int)Math.Abs(value.Y);
            if (h1 > this.cadPictBox.VirtualSize.Height)
                h1 = this.cadPictBox.VirtualSize.Height;
            this.cadPictBox.SetPositionNoInvalidate(new Point(w1, h1));
            // this.dockPanel2.Height = h1;
        }
        public void SetPictureBoxLoadState(bool val, string name)
        {
            try
            {
                this.cadPictBox.Visible = !val;
                if (val)
                {
                    this.Cursor = Cursors.WaitCursor;
                    StatusCaption = ApplicationConstants.loadfilestr;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    StatusCaption = (name != string.Empty) ? name : LoadCadFileName;//Path.GetFileName(fileName) + ApplicationConstants.sepstr;               
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void DoNormalColor()
        {
            if (cadImage == null)
                return;
            cadImage.DrawMode = CADDrawMode.Normal;
            this.colorDraw = true;
            cadPictBox.Invalidate();
        }
        public void DoZoomOut()
        {
            if (cadImage == null) return;
            this.cADProperty.PreviousPosition = new PointF(this.cadPictBox.ClientRectangle.Width / 2.0f, this.cadPictBox.ClientRectangle.Height / 2.0f);
            this.cADProperty.sc = this.cADProperty.sc / 2.0f;
            this.cadPictBox.Invalidate();
            this.stopSnap = false;
            SetPictureBoxPosition(this.cADProperty.Position);
        }
        public void DoZoomIn()
        {
            //if (cadImage == null) return;

            //this.cADProperty.PreviousPosition = new PointF(this.cadPictBox.ClientRectangle.Width / 2.0f, this.cadPictBox.ClientRectangle.Height / 2.0f);
            //this.cADProperty.ImageScale = this.cADProperty.ImageScale / 2.0f;
            //this.cadPictBox.Invalidate();

            if (cadImage == null)
                return;
            this.cADProperty.PreviousPosition = new PointF(cadPictBox.ClientRectangle.Width / 2.0f, cadPictBox.ClientRectangle.Height / 2.0f);
            this.cADProperty.ImageScale = this.cADProperty.ImageScale * 2.0f;
            cadPictBox.Invalidate();
            this.stopSnap = false;
            if (this.cADProperty.ImageScale <= 1024)
            {
                SetPictureBoxPosition(this.cADProperty.Position);
            }
            else
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Reached Maximum Zoom Level!.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void ChangeControlState()
        {
            bool detNullImg = cadImage != null;
            //EnableButton(detNullImg);
        }
        public void UndoChangeEntity()
        {
            this.cadImage.Undo();
            this.cadPictBox.Invalidate();
        }
        public void RedoChangeEntity()
        {
            this.cadImage.Redo();
            this.cadPictBox.Invalidate();
        }
        public string RemoveIntegers(string input)
        {
            string regex = Regex.Replace(input, @"[\d-]", string.Empty);
            return regex.Replace("_", "");
        }
        public Bitmap LoadBitmap(string path)
        {
            //Open file in read only mode
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            //Get a binary reader for the file stream
            using (BinaryReader reader = new BinaryReader(stream))
            {
                //copy the content of the file into a memory stream
                var memoryStream = new MemoryStream(reader.ReadBytes((int)stream.Length));
                //make a new Bitmap object the owner of the MemoryStream
                return new Bitmap(memoryStream);
            }
        }
        public void SetCADImageOptions(bool loadFirst)
        {
            SetSnapMode();
            cadImage.SelectionMode = SelectionEntityMode.Enabled;
            cadImage.GraphicsOutMode = DrawGraphicsMode.GDIPlus;
            cadImage.ChangeDrawMode(cadImage.GraphicsOutMode, cadPictBox);
            cadImage.IsWithoutMargins = true;
            ObjEntity.cadImage = cadImage;
            this.prtForm.Image = this.cadImage;
            //xmlImporter.Image = this.cadImage;
            // txtImporter.Image = this.cadImage;
            if (cadPictBox.BackColor == Color.White)
                White_Click();
            else
                Black_Click();
            ViewLayouts();
            if (this.colorDraw == false)
                DoBlackColor();

            if (loadFirst)
                DoResize();

            // ObjEntity.cadImage = cadImage;
            this.entCreator.Image = this.cadImage;
            // ribbon.Minimized = true;
        }
        #region Save Image into Drive

        public void SaveAsImage(SaveFileDialog dlgSaveImg)
        {
            dlgSaveImg.FileName = this.TabText;
            if (cadImage == null)
                return;
            if (dlgSaveImg.ShowDialog() != DialogResult.OK)
                return;
            if (dlgSaveImg.FileName == null)
                return;
            string filename = dlgSaveImg.FileName;
            if (filename != null)
            {
                List<string> filterext = new List<string>(dlgSaveImg.Filter.Split('|'));
                List<string> exts = new List<string>(filterext[dlgSaveImg.FilterIndex * 2 - 1].Split(','));
                if (exts.Count > 0)
                {
                    string ext = Path.GetExtension(exts[0]);
                    string fileext = Path.GetExtension(filename);
                    if (exts.Count > 1)
                        for (int i = 0; i < exts.Count; i++)
                            if (Path.GetExtension(exts[i]).ToLower() == fileext.ToLower())
                                ext = Path.GetExtension(exts[i]);
                    filename = (ext.ToLower() == fileext.ToLower() ? filename : filename += ext);
                }
            }
            FileFormat fileformat = CADConst.GetFileFotmat(Path.GetExtension(filename));
            switch (fileformat)
            {
                case FileFormat.Dxf:
                    SaveAsDxf(filename);
                    break;
                case FileFormat.Plt:
                case FileFormat.Hgl:
                case FileFormat.Hg:
                case FileFormat.Hpg:
                case FileFormat.Plo:
                case FileFormat.Hp:
                case FileFormat.Hp1:
                case FileFormat.Hp2:
                case FileFormat.Hp3:
                case FileFormat.Hpgl:
                case FileFormat.Hpgl2:
                case FileFormat.Hpp:
                case FileFormat.Gl:
                case FileFormat.Gl2:
                case FileFormat.Prn:
                case FileFormat.Spl:
                case FileFormat.Rtl:
                case FileFormat.Pcl:
                    CADToHPGL hpgl = new CADToHPGL(cadImage);
                    try
                    {
                        hpgl.SaveToFile(filename);
                    }
                    finally
                    {
                        hpgl.Dispose();
                        hpgl = null;
                    }
                    break;
                case FileFormat.Pdf:
                    CADToPDF pdf = new CADToPDF(cadImage);
                    try
                    {
                        pdf.SaveToFile(filename);
                    }
                    finally
                    {
                        pdf.Dispose();
                        pdf = null;
                    }
                    break;
                case FileFormat.Cgm:
                    CADToCGM cgm = new CADToCGM(cadImage);
                    try
                    {
                        cgm.SaveToFile(filename);
                    }
                    finally
                    {
                        cgm.Dispose();
                        cgm = null;
                    }
                    break;
                case FileFormat.Bmp:
                    SaveImageAsFormat(filename, ImageFormat.Bmp);
                    break;
                case FileFormat.Jpg:
                case FileFormat.Jpeg:
                    SaveImageAsFormat(filename, ImageFormat.Jpeg);
                    break;
                case FileFormat.Tif:
                case FileFormat.Tiff:
                    SaveImageAsFormat(filename, ImageFormat.Tiff);
                    break;
                case FileFormat.Gif:
                    SaveImageAsFormat(filename, ImageFormat.Gif);
                    break;
                case FileFormat.Png:
                    SaveImageAsFormat(filename, ImageFormat.Png);
                    break;
                case FileFormat.Emf:
                    SaveImageAsFormat(filename, ImageFormat.Emf);
                    break;
                case FileFormat.Wmf:
                    SaveImageAsFormat(filename, ImageFormat.Wmf);
                    break;
                case FileFormat.Dwg:
                    SaveImageAsFormat(filename, ImageFormat.Wmf);
                    break;
            }
        }

        private void SaveAsDxf(string fName)
        {
            try
            {
                string linefilename = string.Empty;
                bool IsStatus = false;
                bool LineStatus = false;
                string ReceiveFileName = Path.GetFileNameWithoutExtension(fName);
                SerializationXml serializationXml = null;
                string FilePth = GlobalDeclaration.ReturnPath();
                FilePth = Path.Combine(FilePth, "SparrowCAD");
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
                if (cadImage == null) return;
                if (cadImage is CADRasterImage)
                {
                    return;
                }
                if (this._UpdateDic.Count > 0 && this._listconnt.Count > 0)
                {
                    serializationXml = new SerializationXml();
                    serializationXml.Map_list = this._UpdateDic;
                    if (File.Exists(string.Concat(FilePth, @"\", ReceiveFileName, linefilename)))
                    {
                        File.Delete(string.Concat(FilePth, @"\", ReceiveFileName, linefilename));
                    }
                    if (fileextentiontype == ".spr")
                    {
                        if (File.Exists((FilePth + @"\" + ReceiveFileName + "~" + FileNameDisplayLine)))
                        {
                            File.Delete((FilePth + @"\" + ReceiveFileName + "~" + FileNameDisplayLine));
                        }
                        LineStatus = GlobalDeclaration.SaveLineConnectorToXml(FilePth + @"\" + ReceiveFileName + "~" + FileNameDisplayLine, this._listconnt);
                    }
                    else
                    {
                        if (File.Exists((FilePth + @"\" + ReceiveFileName + "~" + linefilename)))
                        {
                            File.Delete((FilePth + @"\" + ReceiveFileName + "~" + linefilename));
                        }
                        LineStatus = GlobalDeclaration.SaveLineConnectorToXml(FilePth + @"\" + ReceiveFileName + "~" + linefilename, this._listconnt);
                    }
                    IsStatus = SerializationXml.Serialize(FilePth + @"\" + ReceiveFileName + ".xml", serializationXml);
                    if (IsStatus && LineStatus)
                    {
                        //var watch = new System.Diagnostics.Stopwatch();
                        //watch.Start();
                        CADImport.Export.DirectCADtoDXF.CADtoDXF vExp = new CADImport.Export.DirectCADtoDXF.CADtoDXF(cadImage);
                        vExp.SaveToFile(fName);
                        string finam = Path.Combine(FilePth, ReceiveFileName + ".dxf");
                        vExp.SaveToFile(finam);
                        serializationXml = null;
                        if (DialogResult.OK == XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Cad Layout Save in .Dxf format Successfull.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information))
                        {
                            //string ExistingFileName = IniFile.IniReadValue("DBConfig", "FileName");
                            //if (string.IsNullOrEmpty(ExistingFileName))
                            //    IniFile.IniWriteValue("DBConfig", "FileName", ReceiveFileName + ".dxf");
                            //else
                            //{
                            //    //ReceiveFileName = string.Concat(ExistingFileName, ReceiveFileName, ".dxf", "|");
                            //    // ReceiveFileName = ReceiveFileName.Remove(ReceiveFileName.Length - 1);
                            //    IniFile.IniWriteValue("DBConfig", "FileName", ReceiveFileName + ".dxf");
                            //}
                            multiplefilesave(ReceiveFileName);
                        }

                    }
                }
                else
                {
                    if (File.Exists((FilePth + @"\" + ReceiveFileName + ".xml")))
                    {
                        File.Delete((FilePth + @"\" + ReceiveFileName + ".xml"));
                    }
                    //if (File.Exists((FilePth + @"\" + ReceiveFileName + "~" + FileNameDisplayLine)))
                    //{
                    //    File.Delete((FilePth + @"\" + ReceiveFileName + "~" + FileNameDisplayLine));
                    //}
                    CADImport.Export.DirectCADtoDXF.CADtoDXF vExp = new CADImport.Export.DirectCADtoDXF.CADtoDXF(cadImage);
                    vExp.SaveToFile(fName);
                    string finam = Path.Combine(FilePth, ReceiveFileName + ".dxf");
                    vExp.SaveToFile(finam);
                    if (DialogResult.OK == XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Cad Layout Save in .Dxf format Successfull.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information))
                    {
                        multiplefilesave(ReceiveFileName);
                    }
                }
                if (this._DicMachineNo.Count > 0 && this._MachineCordinates.Count > 0)
                {
                    string finam = string.Concat(FilePth, @"\", ReceiveFileName, "Dxf", fileextentiontype);
                    if (File.Exists(finam))
                    {
                        File.Delete(finam);
                    }
                    GlobalDeclaration.SaveMachineInfoXml(finam, this._DicMachineNo, this._MachineCordinates);
                }
                else // Only for Delete Exits File When There Is no Machine Draw on CAd Layout
                {
                    string finam = string.Concat(FilePth, @"\", ReceiveFileName, "Dxf", fileextentiontype);
                    if (File.Exists(finam))
                    {
                        File.Delete(finam);
                    }
                }
                if (GlobalDeclaration._MyTagDictinary.Count > 0)
                {
                    string finam = string.Concat(FilePth, @"\", ReceiveFileName, "~MTag", fileextentiontype);
                    if (File.Exists(finam))
                    {
                        File.Delete(finam);
                    }
                    GlobalDeclaration.SaveMachineTagXml(finam, GlobalDeclaration._MyTagDictinary);
                }
                else //Only for Delete Exits File When There Is no Machine Draw on CAd Layout
                {
                    string finam = string.Concat(FilePth, @"\", ReceiveFileName, "~MTag", fileextentiontype);
                    if (File.Exists(finam))
                    {
                        File.Delete(finam);
                    }
                }
                if (_RcConnectorDic.Count > 0)
                {
                    string finam = string.Concat(FilePth, @"\", ReceiveFileName, "~RC", fileextentiontype);
                    if (File.Exists(finam))
                    {
                        File.Delete(finam);
                    }
                    GlobalDeclaration.SaveRCConnectorDic(finam, _RcConnectorDic);
                }
                else //Only for Delete Exits File When There Is no RC  Machine Draw on CAd Layout
                {
                    string finam = string.Concat(FilePth, @"\", ReceiveFileName, "~RC", fileextentiontype);
                    if (File.Exists(finam))
                    {
                        File.Delete(finam);
                    }
                }
                IniFile.IniWriteValue("DBConfig", "FileExtension", ".xml");
                GlobalDeclaration.ProjectIniFileUpdate("", "", "", "", "", "", "", ".xml");
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void multiplefilesave(string ReceiveFileName)
        {
            try
            {
                if (!string.IsNullOrEmpty(IniFile.IniReadValue("DBConfig", "FileName")))
                {
                    string multiplefilename = IniFile.IniReadValue("DBConfig", "FileName");
                    string multifile = string.Empty;
                    if (!string.IsNullOrEmpty(multiplefilename))
                    {
                        //if (multiplefilename.Split('.')[0] != ReceiveFileName)
                        //{
                        //    if (multiplefilename.Contains("|"))
                        //    {
                        //        IniFile.IniWriteValue("DBConfig", "FileName", "");
                        //        multiplefilename = multiplefilename.Split('|')[0];
                        //    }
                        //    multifile = string.Concat(ReceiveFileName, ".dxf");
                        //    multifile = string.Concat(multiplefilename, "|", multifile);
                        //    IniFile.IniWriteValue("DBConfig", "FileName", multifile);
                        //}
                        //else
                        //{
                        if (multiplefilename.Contains("|"))
                        {
                            IniFile.IniWriteValue("DBConfig", "FileName", "");
                            multiplefilename = multiplefilename.Split('|')[0];
                            multifile = string.Concat(ReceiveFileName, ".dxf");
                            multifile = string.Concat(multiplefilename, "|", multifile);
                            IniFile.IniWriteValue("DBConfig", "FileName", multifile);
                            GlobalDeclaration.ProjectIniFileUpdate("", "", "", "", "", multifile, "", "");
                        }
                        else
                        {
                            multifile = ReceiveFileName;
                            IniFile.IniWriteValue("DBConfig", "FileName", multifile + ".dxf");
                            GlobalDeclaration.ProjectIniFileUpdate("", "", "", "", "", multifile + ".dxf", "", "");
                        }

                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SaveAsDwg(string fName, bool IsCallSave)
        {
            try
            {
                string FileNameDisplay = string.Empty;
                string FileName = string.Empty;
                MemoryStream strm = new System.IO.MemoryStream();
                if (IsCallSave)
                {
                    if (cadImage == null) return;
                    if (cadImage is CADRasterImage)
                    {
                        return;
                    }
                    FileNameDisplay = fName;
                }
                else
                {
                    string FilePath = this.cadImage.Converter.Source;
                    string[] s = (FilePath).Split('\\');
                    FileName = s[s.Length - 1];
                    if (FilePath != null)
                    {
                        FileNameDisplay = Application.StartupPath + @"\" + FileName.Trim();
                    }
                }
                bool Status = CADImport.Export.CADtoDWG.SaveAsDWG(cadImage, FileName);
                if (Status && !IsCallSave)
                {
                    FileNameDisplay = string.Empty;
                    FileName = string.Empty;
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "File Save SuccessFully.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Error In File.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveImageAsFormat(string filename, ImageFormat format)
        {
            DRect tmpRect;
            if (!this.cadPictBox.Enabled)
            {
                tmpRect = new DRect(0, 0, this.cADProperty.ImageRectangleF.Width, this.cADProperty.ImageRectangleF.Height);

                rasterSizeForm.Image = this.cadImage;
                rasterSizeForm.CurrentSize = tmpRect;
                rasterSizeForm.SaveFileName = filename;
                if (rasterSizeForm.ShowDialog() == DialogResult.OK)
                    tmpRect = rasterSizeForm.SizeImage;
                else
                    return;
            }
            else
            {
                tmpRect = new DRect(this.cADProperty.LeftImagePosition, this.cADProperty.TopImagePosition, this.cADProperty.LeftImagePosition + this.cADProperty.ImageRectangleF.Width, this.cADProperty.TopImagePosition + this.cADProperty.ImageRectangleF.Height);
            }

            int tmpNumberOfPartsInCircle = this.cadImage.NumberOfPartsInCircle;
            cadImage.Painter.Settings.SaveParams();
            cadImage.Painter.Settings.DefaultColor = Color.Black.ToArgb();
            if ((format == ImageFormat.Emf) || (format == ImageFormat.Wmf))
            {
                cadImage.Painter.Settings.BackgroundColor = Color.Transparent.ToArgb();
                cadImage.Painter.Settings.IsShowBackground = false;
            }
            else
            {
                cadImage.Painter.Settings.BackgroundColor = Color.White.ToArgb();
                cadImage.Painter.Settings.IsShowBackground = true;
            }

            try
            {
                this.cadImage.NumberOfPartsInCircle = CADConst.SetNumberOfPartsInCurve(tmpRect);
                if (this.cadPictBox.Enabled)
                {
                    if ((format == ImageFormat.Emf) || (format == ImageFormat.Wmf))
                        cadImage.ExportToMetafile(filename, tmpRect, this.cadPictBox.ClientRectangle);
                    else
                        cadImage.SaveToFile(filename, format, tmpRect, this.cadPictBox.ClientRectangle, rasterSizeForm.ImagePixelFormat);
                }
                else
                {
                    if ((format == ImageFormat.Emf) || (format == ImageFormat.Wmf))
                        cadImage.ExportToMetafile(filename, tmpRect);
                    else
                        cadImage.SaveToFile(filename, format, tmpRect, rasterSizeForm.ImagePixelFormat);
                }
            }
            finally
            {
                this.cadImage.NumberOfPartsInCircle = tmpNumberOfPartsInCircle;
                cadImage.Painter.Settings.RestoreParams();
            }
        }
        #endregion
        public void ClearImage()
        {
            if (cadImage != null)
            {
                cadImage.Dispose();
                cadImage = null;
                Destination = string.Empty;
                Source = string.Empty;
                this.entCreator.Image = null;
                //iClose.Enabled = false;
                this.cadPictBox.Invalidate();
                _HoldImagePat.Clear();
                _DicMachineNo.Clear();
                _UpdateDic.Clear();
                _HoldPackageMachine.Clear();
                EditfrmDictionary.Clear();
                _MachineCordinates.Clear();
                _LineTypeHold.Clear();
                _listconnt.Clear();
            }
            this.cADProperty.ImageScale = 1.0f;
            this.cADProperty.ImagePreviousScale = 1.0f;
            this.cADProperty.Position = new PointF();
        }

        public void LoadFile(string fileName) // Mutiple Time CadFile Edit and Open RajendraGola
        {
            //if (this.InvokeRequired)
            //{
            //this.Invoke(new MethodInvoker(delegate
            //{
            if (!string.IsNullOrEmpty(fileName))
            {
                LoadCadFileName = fileName;
                ClearImage();
                this.cadImage = CADImage.CreateImageByExtension(LoadCadFileName);
                if (this.cadImage is CADRasterImage)
                    (this.cadImage as CADRasterImage).Control = this.cadPictBox;

                if (this.cadImage == null)
                {
                    SetPictureBoxLoadState(false, string.Empty);
                    return;
                }

                CADImage.CodePage = System.Text.Encoding.Default.CodePage;
            }
            if (this.cadImage != null)
            {

                this.CadEntitiesTxt.Image = this.cadImage;
                cadImage = CADImage.CreateImageByExtension(LoadCadFileName);
                cadImage.LoadFromFile(LoadCadFileName);
            }
            CADImport.CADImage.LastLoadedFilePath = Path.GetDirectoryName(fileName);
            SetCadImageOptions(false);
            SetPictureBoxLoadState(false, LoadCadFileName);
            DoNormalColor();
            // }));
            //}
            if (GlobalDeclaration.UserType.Equals("U1-Maintenance") || GlobalDeclaration.UserType.Equals("U1-Safety") ||
                GlobalDeclaration.UserType.Equals("U1-Operation"))
            {
                foreach (CADLayer layer in cadImage.Converter.Layers)
                {
                    layer.Locked = true;
                    cadImage.Converter.Loads(layer);
                }
                //string ReceiveFileName = Path.GetFileNameWithoutExtension(fileName);
                //LoadAllMachines(ReceiveFileName); this is for only U1 user but its should be any one user. u1 user have rights to add and delete machine in already save DXF file.
            }
            string ReceiveFileName = Path.GetFileNameWithoutExtension(LoadCadFileName);
            LoadAllMachines(ReceiveFileName);
        }

        /// <summary>
        /// Line Draw on Cad
        /// </summary>
        /// <param name="val">pass the line type</param>
        private void AssignLineName(CreatorType val)
        {
            try
            {
                if (val == CreatorType.Polyline)
                {
                    CADEntity entity = entCreator.Image.Converter.Entities.FindLast(ent => ent.EntType == EntityType.Polyline);
                    if (entity != null)
                    {
                        //CADLeader leader = entity as CADLeader;
                        CADPolyLine leader = entity as CADPolyLine;
                        leader.LineTypeScale = 1;
                        leader.LineWeight = 0.5;
                        if (LineName == "Electrical Cable")
                        {
                            leader.Color = Color.DarkBlue;
                            leader.LineType.Name = LineName;
                        }
                        else if (LineName == "Pipe")
                        {
                            leader.Color = Color.DarkRed;
                            leader.LineType.Name = LineName;

                        }
                        else if (LineName == "Bus Bar")
                        {
                            leader.Color = Color.DarkGreen;
                            leader.LineType.Name = LineName;
                        }
                        else if (LineName == "Coupling")
                        {
                            leader.Color = Color.Purple;
                            leader.LineType.Name = LineName;
                        }

                        entCreator.Image.Converter.Loads(leader);
                        _IsLineComplete = false;
                        if (_listconnt.ContainsKey(LineName))
                        {
                            var randomnumber = new Random();
                            int _min = 0;
                            int _max = 1000;
                            leader.LineType.Name = LineName + randomnumber.Next(_min, _max);
                        }
                        DPoint LatestCord = UpdateCord(leader.DottedSingPoints[1]);
                        connector.Points = LatestCord.X + "~" + LatestCord.Y;
                        _listconnt.Add(leader.LineType.Name, connector);
                        OpenConnectorform(leader.LineType.Name, LatestCord);
                    }
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region CadPicture Box Event List

        private void LForm_LayerChanged(object sender, LayerChangedEventArgs e)
        {
            this.cadImage.ClearSelection();
            this.cadImage.ClearMarkers();
            InitialNewPrintPages();
        }

        private void mulCadLayout_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_FormClosed != null)
            {
                _FormClosed.Invoke(sender, this.TabText);
            }
        }
        private void calculateoffsetStripItem_Click(object sender, EventArgs e)
        {
            this._offsetCalculateStart.Invoke(this.TabText);
        }
        private void cadPictBox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.cadImage == null) return;
                // cadImage.SelectionMode = SelectionEntityMode.Enabled;
                var CadName = this.cadImage.SelectedEntities.AsEnumerable().FirstOrDefault();
                if (CadName != null)
                {
                    if (CadName.EntType == EntityType.ImageEnt)
                    {
                        CadName.Selected = true;
                        CadName.Color = Color.Red;
                        CadName.Visibility = true;
                        this.cadImage.Selector.DoSelectEntity(CadName);
                    }
                }

                if (Control.ModifierKeys == Keys.Control)
                {
                    DPoint point = GetRealPoint(e.X, e.Y, true);
                    Console.WriteLine(point.X + "   " + point.Y);
                    this._offsetCalculateClick.Invoke(GetRealPoint(e.X, e.Y, true));
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cadPictBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (cadImage != null)
                {
                    // this.selectedEntitiesChanged = true;
                    var CadName = this.cadImage.SelectedEntities.AsEnumerable().FirstOrDefault();//cadImage.SelectedEntities[0]                    
                    if (CadName != null && CadName.EntType == EntityType.ImageEnt)
                    {
                        #region Normal Machine Open
                        if (((CADImport.CADImageEnt)CadName).ImageDef == null) return;
                        string MachinePath = ((CADImport.CADImageEnt)CadName).ImageDef.FileName;
                        string[] s = (MachinePath.ToString()).Split('\\');
                        string RCName = s[s.Count() - 1].Split('.')[0];
                        if (!RCName.Contains("RC"))
                        {
                            DirectoryInfo info = new DirectoryInfo(MachinePath);
                            string MachineType = info.Parent.Name;
                            string machinesubtype = info.Parent.Parent.Name;
                            if (!string.IsNullOrEmpty(MachineType) && !string.IsNullOrEmpty(machinesubtype))
                            {
                                EditDatafrm(sender, e);
                            }
                        }
                        else
                        {
                            DPoint _points = ((CADImport.CADImageEnt)CadName).Point;
                            if (_RcConnectorDic.ContainsKey(_points))
                            {
                                PackageMachine.Remote_Connection _RC = new PackageMachine.Remote_Connection(_points, true);
                                _RC.txtCordinate.Visible = false;
                                _RC.TopMost = true;
                                _RC.ConnectorEvnt += Connector_Event;
                                _RC.txtsource.Visible = false;
                                _RC.lblSearch.Visible = false;
                                _RC.lblsource.Visible = false;
                                _RC.DgvRC.Visible = false;
                                _RC.DGVLoadRC.Visible = true;
                                _RC.DGVLoadRC.Location = new Point(6, 27);
                                _RC.DGVLoadRC.Size = new Size(888, 325);
                                _RC.btnConnection.Visible = false;
                                _RC.btnAdd.Visible = false;
                                _RC.cmbsearch.Visible = false;
                                _RC.Show();
                            }
                        }
                        #endregion
                    }
                    else if (CadName != null && (CadName.EntType == EntityType.Leader || CadName.EntType == EntityType.Polyline))
                    {
                        CADPolyLine cadline = (CADPolyLine)CadName;
                        //CADLineType findLType = cadImage.Converter.LTypeByName(cadline.LineTypeName);
                        string ReloadLineName = string.Empty;
                        if (CadName.LineType.Name == null) return;
                        DPoint LatestCord = UpdateCord(cadline.DottedSingPoints[1]);
                        if (_listconnt.Count > 0)
                        {
                            ReloadLineName = _listconnt.FirstOrDefault(X => X.Value.Points == LatestCord.X + "~" + LatestCord.Y).Key;
                            if (ReloadLineName == null) return;
                            cadline.LineType.Name = ReloadLineName;
                        }
                        LineName = CadName.LineType.Name;
                        if (!string.IsNullOrEmpty(LineName))//LineName=="Electrical Cable"|| LineName=="Pipe"||LineName=="Bus Bar"
                            OpenConnectorform(CadName.LineType.Name, LatestCord);
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OpenConnectorform(string linetyp, DPoint dPoint, string RemoteName = "", object obj = null)
        {
            try
            {
                IsRemoteConnection = false;// this flag should be false becoz when All RC Machine Remove Done. and  if user Drop any new  .Png Connection With Leader Line. 
                ConnectionPropertyFrm cwp = new ConnectionPropertyFrm();
                cwp.RCConnector = RemoteName;
                if (!string.IsNullOrEmpty(RemoteName) && obj != null)
                {
                    connector = ((Connector)obj);
                    DPoint pos = GlobalDeclaration._Dpoint(connector.ToDPoint);
                    cwp.RCCordinate = "X" + pos.X + " " + "Y" + pos.Y;
                }
                else
                {
                    connector = _listconnt[linetyp];
                }
                cwp.ReceiveFkType = linetyp = RemoveIntegers(linetyp);
                switch (linetyp)
                {
                    case "Electrical Cable":
                        cwp.txtCableLocation.Text = dPoint.X + " " + dPoint.Y;
                        break;
                    case "Pipe":
                        cwp.txtLocation.Text = dPoint.X + " " + dPoint.Y;
                        break;
                    case "Bus Bar":
                        cwp.txtbuslocation.Text = dPoint.X + " " + dPoint.Y;
                        break;
                    case "Coupling":
                        cwp.txtCoupLocation.Text = dPoint.X + " " + dPoint.Y;
                        break;
                }
                cwp.location = dPoint.X + " " + dPoint.Y;
                cwp.UpdateStrcu(connector);
                cwp.UpdateTabPage();
                if (cwp.ShowDialog() == DialogResult.OK)
                {
                    this.cadImage.ClearSelection();
                    cwp.RCCordinate = string.Empty;
                    cwp.RCConnector = string.Empty;
                    cwp.ReceiveFkType = string.Empty;
                    cwp.Close();
                    cwp.Dispose();
                }
                else
                {
                    //cwp.Close();
                    //cwp.Dispose();
                    //cwp = null;                    
                    this.cadImage.ClearSelection();
                    cwp.RCCordinate = string.Empty;
                    cwp.RCConnector = string.Empty;
                }
                if (!string.IsNullOrEmpty(RemoteName))
                {
                    var form = Application.OpenForms["Remote_Connection"];
                    if (form != null)
                        form.Show();
                }
                //this.cadImage.ClearSelection();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OpenEditFrm(object sender, string MachineName, string SysGenNo, DPoint cordinate)
        {
            try
            {
                // first check alrdy sys gen machine name with selected object 
                if (cadImage != null)
                {
                    string MachineType = string.Empty;
                    string MachinSubType = string.Empty;

                    if (_HoldImagePat.Count > 0)
                    {
                        string Value = MachineName.Split('~')[0];

                        if (MachineName.Contains("_"))
                            Value = RemoveIntegers(MachineName);

                        string MachinePah = _HoldImagePat[Value];
                        DirectoryInfo info = new DirectoryInfo(MachinePah);
                        MachineType = info.Parent.Name;
                        MachinSubType = info.Parent.Parent.Name;
                    }
                    if (EditfrmDictionary.ContainsKey(SysGenNo))
                    {
                        mcd = EditfrmDictionary[SysGenNo];
                    }
                    else
                    {
                        mcd = new Machine_Edit_Data(MachineName.Split('~')[0], SysGenNo, MachineName);
                        mcd.RemoveDicEvetHandeler += RemoveFormDic;
                        mcd._SendToPointForMulCadLayoutFrm += DropMachineFromMCDForm_ConnectorEvnt;
                        mcd.offsetDict = offsetDict;
                        EditfrmDictionary.TryAdd(SysGenNo, mcd);
                    }
                    mcd.cmblayer.Items.Add(MachinSubType);
                    mcd.cmblayer.SelectedIndex = 0;
                    mcd.MachineSybType = MachinSubType;
                    mcd.MachinType = MachineType;
                    mcd.cmblayer.Enabled = false;
                    mcd._listconnt = this._listconnt;
                    mcd._Cordinates = cordinate;
                    mcd.cmblocation.Items.Add("X" + cordinate.X + " " + "Y" + cordinate.Y);
                    mcd.cmblocation.SelectedIndex = 0;
                    mcd.cmblocation.Enabled = false;
                    mcd.ReceiveConValue = _UpdateDic;
                    mcd.LineType = LineName;
                    mcd._dropMachineList = this._DicMachineNo;
                    mcd.TopMost = false;
                    mcd.Show();
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please Draw CAD Object First.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cadPictBox_Paint(object sender, PaintEventArgs e)
        {
            if (cadImage == null)
                return;
            DrawCADImage(e.Graphics, sender as Control);
            //stBar.Panels[1].Text = RealScale;
        }
        private void CADPictBoxMouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Delta < 0)
                Zoom(0.7f);
            else
                Zoom(1.3f);
            this.Shift();
            SetPictureBoxPosition(this.cADProperty.Position); // temp close method 
        }
        private void cadPictBox_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            detRMouseDown = false;
            // cadPictBox.Cursor = Cursors.Default;
            //  cadPictBox.Invalidate();            
            if (cadImage == null) return;
            if (e.Button != MouseButtons.Right)
                if (ChangeEntityOnMouseUp(new Point(e.X, e.Y)))
                    cadPictBox.Invalidate();

            detMouseDown = false;
            if (this.clipRectangle.Enabled)
                if ((this.clipRectangle.Type == RectangleType.Zooming))
                    UseClipRect();
            if (selectedEntitiesChanged && !CreateNewEntity)// 
            {
                this.stopSnap = true;
                cadPictBox.Invalidate();
            }
            //if (cadImage != null)
            //    cadImage.SelectedEntities.PropertyChanged -= new PropertyChangedEventHandler(this.SelectedEntitiesChanged);
            selectedEntitiesChanged = false;
        }
        private void cadPictBox_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (cadImage == null) return;
            //if (!this.cadPictBox.Focused)
            //    this.cadPictBox.Focus();
            //if (detRMouseDown)
            //{
            //    this.cADProperty.cX -= (this.cADProperty.cX - e.X);
            //    this.cADProperty.cY -= (this.cADProperty.cY - e.Y);
            //    this.cADProperty.cX = e.X;
            //    this.cADProperty.cY = e.Y;
            //    cadPictBox.Invalidate();
            //    SetPictureBoxPosition(this.cADProperty.Position);
            //}
            if ((!stopSnap) && (!this.clipRectangle.Enabled) && (this.cadPictBox.ClientRectangle.Contains(e.X, e.Y)))
            {
                RectangleF tmpRect = this.cADProperty.ImageRectangleF;
                cadImage.DrawSnapTrace(e.X, e.Y, this.cadPictBox, tmpRect);
            }
            else
            {
                this.cadImage.RefreshSnapTrace(this.cadPictBox);
                this.stopSnap = false;
            }
            this.cADProperty.PreviousPosition = new PointF(e.X, e.Y);
            //  DPoint vPt= GetRealPoint(e.X, e.Y, true);
            RealPointDisplay = string.Format("{0} : {1} : {2}", GetRealPoint(e.X, e.Y, true).X, GetRealPoint(e.X, e.Y, true).Y, GetRealPoint(e.X, e.Y, true).Z);
            if (detMouseDown)
            {
                if (e.Button != MouseButtons.Right)
                    if (ChangeEntityOnMouseMove(new Point(e.X, e.Y)))
                        return;
                if ((!this.clipRectangle.Enabled) && (!this.CreateNewEntity))
                {
                    this.cADProperty.LeftImagePosition -= (this.cADProperty.cX - e.X);
                    this.cADProperty.TopImagePosition -= (this.cADProperty.cY - e.Y);
                    cadPictBox.Invalidate();
                }
                this.cADProperty.cX = e.X;
                this.cADProperty.cY = e.Y;
            }

            if (CadPointDisplay != null)
            {
                CadPointDisplay.Invoke(sender, RealPointDisplay);
            }

        }
        private void cadPictBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                selectedEntitiesChanged = false;
                if (cadImage != null)
                    cadImage.SelectedEntities.PropertyChanged += new PropertyChangedEventHandler(this.SelectedEntitiesChanged);
                if (e.Button != MouseButtons.Right)
                {
                    if (!this.CreateNewEntity)
                        DisableEntityCreator();

                    if (this.cadImage != null)
                        if (cadImage.SelectionMode == SelectionEntityMode.Enabled)
                        {
                            if (SelectEntity(e.X, e.Y))
                                return;
                        }
                }
                else if (e.Button == MouseButtons.Right && Control.ModifierKeys != Keys.Shift)
                {
                    if (this.cadImage.SelectedEntities.Count > 0)
                    {
                        var CadName = this.cadImage.SelectedEntities[0];//.AsEnumerable().FirstOrDefault();
                        if (CadName != null)
                        {
                            if (CadName.EntType == EntityType.ImageEnt)
                            {
                                contextMenuStrip1.Show(e.X, e.Y);
                                this.selectedEntitiesChanged = false;
                            }
                        }
                    }
                }
                else if (e.Button == MouseButtons.Right && Control.ModifierKeys == Keys.Shift)
                {
                    OffSetCalculatorMenu.Show(e.X, e.Y);
                    cadImage.SelectionMode = SelectionEntityMode.Enabled;
                    this.selectedEntitiesChanged = false;
                }
                this.cADProperty.cX = e.X;
                this.cADProperty.cY = e.Y;
                detMouseDown = true;
                if (this.CreateNewEntity)
                    if (EnableNewEntityCreator())
                    {
                        return;
                    }
                if ((e.Button == MouseButtons.Left) && (!moveMarker))
                    this.clipRectangle.EnableRect(RectangleType.Zooming, new Rectangle(e.X, e.Y, 0, 0));
            }
            catch (Exception)
            {
                MessageBox.Show("Mouse Down Event");
            }
        }
        private void CADPictBoxKeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.ControlKey) || (e.KeyCode == Keys.ShiftKey))
                this.cntrlDown = false;
        }
        private void CADPictBoxScroll(object sender, CADImport.FaceModule.ScrollEventArgsExt e)
        {
            if ((e.NewValue == 0) && (e.OldValue == 0))
                e.NewValue = -5;
            if (e.ScrollOrientation == CADImport.FaceModule.ScrollOrientation.VerticalScroll)
                this.cADProperty.TopImagePosition -= (e.NewValue - e.OldValue);
            if (e.ScrollOrientation == CADImport.FaceModule.ScrollOrientation.HorizontalScroll)
                this.cADProperty.LeftImagePosition -= (e.NewValue - e.OldValue);
            this.cadPictBox.Invalidate();
        }
        private void cadPictBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (!this.cadPictBox.Focused)
                //    this.cadPictBox.Focus();
                int cn = 2;
                if (e.Shift)
                    cn = 5;
                switch (e.KeyCode)
                {
                    case Keys.Add:
                        {
                            DoZoomIn();
                            // Zoom(1.3f);
                            // this.Shift();
                            // SetPictureBoxPosition(this.cADProperty.Position);
                            // 

                        }
                        break;
                    case Keys.Subtract:
                        {
                            DoZoomOut();
                            // Zoom(0.8f);
                            //  this.Shift();
                            // SetPictureBoxPosition(this.cADProperty.Position);
                        }
                        break;
                    case Keys.Up:
                        MoveEntity(0, cn, 0, cn);
                        break;
                    case Keys.Down:
                        MoveEntity(0, -cn, 0, -cn);
                        break;
                    case Keys.Left:
                        MoveEntity(cn, 0, cn, 0);
                        break;
                    case Keys.Right:
                        MoveEntity(-cn, 0, -cn, 0);
                        break;
                    case Keys.Escape:
                        ClearSelection();
                        break;
                    case Keys.Enter:
                        this.entCreator.EndEntity();
                        break;
                    case Keys.ControlKey:
                    case Keys.ShiftKey:
                        this.cntrlDown = true;
                        break;
                    case Keys.Delete:
                        RemoveEntity();
                        break;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SelectedEntitiesChanged(object sender, PropertyChangedEventArgs args)
        {
            selectedEntitiesChanged = true;
        }
        public void EditDatafrm(Object sender, EventArgs e)
        {
            try
            {
                if (cadImage == null) return;
                var CadName = this.cadImage.SelectedEntities.AsEnumerable().FirstOrDefault();
                if (CadName != null)
                {
                    if (CadName.EntType == EntityType.ImageEnt)
                    {
                        DPoint _Pont = ((CADImport.CADImageEnt)CadName).Point;
                        DPoint newpoints = UpdateCord(_Pont);
                        if (_MachineCordinates.ContainsValue(newpoints))
                        {
                            string Mvalue = _MachineCordinates.FirstOrDefault(X => X.Value == newpoints).Key.ToString();
                            //SetMachineName = MachineName(CadName);                        
                            if (!PackegeMachineInfo(CadName))
                                OpenEditFrm(sender, Mvalue, _DicMachineNo[Mvalue], newpoints);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ClearSelection();
        }       
        private void cadPictBox_DragDrop(object sender, DragEventArgs e)
        {
            RectangleF rectangleF = this.cADProperty.ImageRectangleF;
            Point coor = cadPictBox.PointToClient(new Point(e.X, e.Y));
            DPoint pos = GetRealPoint(coor.X, coor.Y, false);//
            string filename = string.Empty;
            AddImageEnt(pos, ref filename);
            ismachineDragged = true;
            IsRemoteConnection = false;// this flag use for Remote Conection. when All RC  Remove Done  then it should be false because if user Add New Image Connection With Leader Line 
            SetCADImageOptions(false);
            cadImage.SelectionMode = SelectionEntityMode.Enabled;
            if (_sendpointToChildfrm != null)
            {
                pos.X = pos.X - 500;
                pos.Y = pos.Y - 500;
                pos = UpdateCord(pos);
                var layoutobject = listofdockcontaint.AsEnumerable().Where(X => X.TabText != TabText).FirstOrDefault();
                if (layoutobject != null)
                {
                    DialogResult dialogResult = XtraMessageBox.Show("Do you want to extend this machine on another floor.", ApplicationConstants.MessageDisplay, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult != DialogResult.Yes) { return; }
                    _sendpointToChildfrm.Invoke(this.TabText, pos, filename);
                }
            }
        }
        public void DragDropImage(DPoint _dPoint, string FileName, string Iocnname)
        {
            SetMachineName = FileName;
            string refstring = string.Empty;
            AddImageEnt(_dPoint, ref refstring, Iocnname);
            SetCADImageOptions(false);
        }
        public void DragDropImage(DPoint _dPoint, string FileName)
        {
            SetMachineName = FileName;
            string refstring = string.Empty;
            AddImageEnt(_dPoint, ref refstring);
            SetCADImageOptions(false);
        }
        private void AddImageEnt(DPoint _Drgpoint, ref string filename, string Iocnname = "")//string path
        {
            try
            {
                _Drgpoint.X = _Drgpoint.X - 500;
                _Drgpoint.Y = _Drgpoint.Y - 500;
                string SysGenNo = string.Empty;
                string uniquegenerate = string.Empty;
                string _assignmachinename = string.Empty;
                _Drgpoint = UpdateCord(_Drgpoint);
                if (!PackageFrm)
                {
                    string FilePath = string.Empty;
                    //if (DragfileName == null) return;
                    if (_HoldImagePat.Count == 0) return;
                    filename = SetMachineName;
                    FilePath = _HoldImagePat[SetMachineName];
                    CADImageDef vImageDef = new CADImageDef();
                    if (string.IsNullOrEmpty(Iocnname))
                    {

                        uniquegenerate = Guid.NewGuid().ToString().Substring(0, 6);
                        _assignmachinename = SetMachineName.Split('.')[0] + "~" + uniquegenerate;
                        SysGenNo = "M" + "-" + uniquegenerate;
                    }
                    else
                    {
                        _assignmachinename = Iocnname;
                        SysGenNo = "M" + "-" + Iocnname.Split('~')[1];
                    }
                    vImageDef.FileName = FilePath;
                    vImageDef.Color = Color.DarkRed;
                    _MachineCordinates.Add(_assignmachinename, _Drgpoint);
                    _DicMachineNo.Add(_assignmachinename, SysGenNo);
                    Bitmap bmpTmp;
                    if (!System.IO.File.Exists(vImageDef.FileName)) return;
                    try
                    {
                        bmpTmp = new Bitmap(vImageDef.FileName);
                        AddEntToSection(ConvSection.ImageDefs, vImageDef);
                        CADImageEnt vImageEnt = new CADImageEnt();
                        vImageEnt.ImageDef = vImageDef;
                        vImageEnt.UVector = CADConst.XOrtAxis;
                        vImageEnt.VVector = CADConst.YOrtAxis;
                        vImageEnt.Size = new DPoint(bmpTmp.Width, bmpTmp.Height, 0);  //vImageEnt.ImageDef.Size;                       
                        vImageEnt.Color = CADConst.clNone;
                        vImageEnt.TransparentColor = Color.White;
                        vImageEnt.Point = _Drgpoint;
                        vImageEnt.Height = 146;
                        vImageEnt.Width = 1000;
                        if (!PlaceEntity(vImageEnt))
                            this.cadImage.Converter.ImageDefs.Remove(vImageDef);
                    }
                    catch (Exception Ex)
                    {
                        XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    SetMachineName = string.Empty;
                }
                else
                {
                    DropPackageMachine(_Drgpoint);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        public void DropMachineFromMCDForm_ConnectorEvnt(string tabText, DPoint _dPoint, string filename)
        {
            if (_sendpointToChildfrm != null)
            {
                _sendpointToChildfrm.Invoke(this.TabText, _dPoint, filename);
            }
        }
        #region ==> Parent Window Event List
        private void ParentWindow_SomeEvent(params object[] args)
        {
            DPoint _points = ((DPoint)args[0]);
            List<string> OpenFormNameList = Application.OpenForms.Cast<Form>().Select(f => f.Name).ToList();
            for (int i = 0; i < OpenFormNameList.Count; i++)
            {
                string FrmName = OpenFormNameList[i];
                switch (FrmName)
                {                                    
                    case "ExternalAuditReport":
                        break;
                }
            }
        }

        #endregion
        void DrawImage_Event(params object[] args)
        {
            try
            {
                string FilePath = string.Empty;
                if (!string.IsNullOrEmpty(IniFile.IniReadValue("DBConfig", "FolderPath")))
                    FilePath = IniFile.IniReadValue("DBConfig", "FolderPath");
                FilePath = FilePath + "\\" + "Images\\RCConnector\\" + "RC.png";
                List<DPoint> dPoint = ((List<DPoint>)args[0]);
                for (int i = 0; i < dPoint.Count; i++)//((DataGridView)args[1]).Rows
                {
                    DPoint ReCallPoint = UpdateCord(dPoint[i]);
                    CADImageDef vImageDef = new CADImageDef();
                    string MachineName = "RC" + "-" + RCNumber++;
                    vImageDef.FileName = FilePath;
                    if (!_RcConnectorDic.ContainsKey(ReCallPoint))
                    {
                        _RcConnectorDic.Add(ReCallPoint, MachineName);
                        if (new Bitmap(vImageDef.FileName) != null)
                        {
                            AddEntToSection(ConvSection.ImageDefs, vImageDef);
                            CADImageEnt vImageEnt = new CADImageEnt();
                            vImageEnt.ImageDef = vImageDef;
                            vImageEnt.UVector = CADConst.XOrtAxis;
                            vImageEnt.VVector = CADConst.YOrtAxis;
                            vImageEnt.Size = vImageEnt.ImageDef.Size;
                            vImageEnt.Color = Color.DarkRed;
                            vImageEnt.TransparentColor = Color.White;
                            vImageEnt.Point = ReCallPoint;
                            // vImageEnt.Height = 50;
                            //vImageEnt.Width = 400;
                            if (!PlaceEntity(vImageEnt))
                                this.cadImage.Converter.ImageDefs.Remove(vImageDef);
                        }
                    }
                }

            }
            catch (Exception Ex)
            {
                RCNumber--;
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Connector_Event(params object[] args)
        {
            try
            {
                string LineName = args[0].ToString();
                if (_MachineCordinates.ContainsKey(((Connector)args[1]).FromData))
                {
                    DPoint _RemoteConn = _MachineCordinates[((Connector)args[1]).FromData];
                    // _listconnt.Add(LineName, ((Connector)args[1]));
                    OpenConnectorform(LineName, _RemoteConn, args[2].ToString(), ((Connector)args[1]));
                    IsRemoteConnection = true;
                }
                IsRemoteConnection = true;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private DPoint UpdateCord(DPoint _old)
        {
            DPoint newpoints = new DPoint();
            newpoints.X = Convert.ToDouble(String.Format("{0:0.0}", _old.X));
            newpoints.Y = Convert.ToDouble(String.Format("{0:0.0}", _old.Y));
            return newpoints;
        }

        private void openEditMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (cadImage != null)
            //    
            string CallEvent = ((System.Windows.Forms.ToolStripItem)sender).Tag.ToString();
            if (cadImage != null)
            {
                var CadName = this.cadImage.SelectedEntities.AsEnumerable().FirstOrDefault();
                if (CadName != null)
                {
                    this.cadImage.ClearSelection();
                    this.cadImage.ClearMarkers();
                    if (CadName.EntType == EntityType.ImageEnt)
                    {
                        DPoint _DrgpointReceivePoints = ((CADImport.CADImageEnt)CadName).Point;
                        DPoint newpoints = UpdateCord(_DrgpointReceivePoints);
                        if (!_MachineCordinates.ContainsValue(newpoints)) return;
                        string KeyValue = _MachineCordinates.FirstOrDefault(X => X.Value == newpoints).Key.ToString();
                        switch (CallEvent)
                        {
                            case "RC":
                                {
                                    PackageMachine.Remote_Connection _RC = new PackageMachine.Remote_Connection(_DrgpointReceivePoints, false);
                                    _RC.ConnectorEvnt += Connector_Event;
                                    _RC.DrawImage += DrawImage_Event;
                                    _RC.txtsource.Text = KeyValue;//MachineName(CadName);
                                    _RC._Mcordinates = _MachineCordinates;
                                    //DPoint cordinate = _MachineCordinates[_RC.txtsource.Text];
                                    //_RC.SourceCordinate = _DrgpointReceivePoints;
                                    _RC.txtCordinate.Text = "X" + _DrgpointReceivePoints.X + " " + "Y" + _DrgpointReceivePoints.Y;
                                    _RC.SysGenNumber = _DicMachineNo[_RC.txtsource.Text];
                                    if (_RC.ShowDialog() == DialogResult.OK)
                                    {
                                        _RC.Close();
                                        _RC.Dispose();
                                    }
                                    else
                                    {
                                        this.cadImage.ClearSelection();
                                    }
                                }
                                break;
                            case "OpenEdit":
                                {
                                    EditDatafrm(sender, e);
                                }
                                break;
                            case "PackageMachine":
                                {
                                    if (package == null)
                                    {
                                        package = new PackageMachine.PackageMachine();
                                        //RecallPackageMachine(package);
                                    }
                                    else
                                    {

                                        //Control c = this.loadpanelpng.Controls[this.loadpanelpng.Controls.Count - 1];
                                        //this.loadpanelpng.Controls.Remove(c);
                                        //_HoldPackageMachine.TryRemove(package.PackageMachineName, out package);
                                        //this.package.Dispose();
                                        //this.package = null;
                                        RecallPackageMachine(package, false);
                                        //package = new PackageMachine.PackageMachine();
                                    }
                                }
                                break;                           
                            case "ChangeMachine":
                                {
                                    //Operations.ChangeMachineConfig chngConfig = new Operations.ChangeMachineConfig();
                                    //chngConfig.Show();
                                }
                                break;
                            case "InputUtility":
                                {

                                }
                                break;
                            case "ViewConnection":
                                {
                                    DPoint _Pont = UpdateCord(((CADImport.CADImageEnt)CadName).Point);
                                    if (_MachineCordinates.ContainsValue(_Pont))
                                    {
                                        string Mvalue = _MachineCordinates.FirstOrDefault(X => X.Value == _Pont).Key.ToString();
                                        cordinate = _MachineCordinates[Mvalue];
                                        GlobalDeclaration.mcCordinate = cordinate;
                                        GlobalDeclaration.MName = Mvalue;
                                        //MachineHistory.MachineConnection mConnect = new MachineHistory.MachineConnection(Mvalue);
                                        //mConnect._listconnt = this._listconnt;
                                        //mConnect.Show();
                                    }
                                    //MachineHistory.MachineConnection mConnect = new MachineHistory.MachineConnection(Mvalue);
                                    //mConnect._listconnt = this._listconnt;
                                    //mConnect.Show();
                                }
                                break;
                            case "ViewLine":
                                {

                                }
                                break;
                            case "RequestLOTO":
                                {

                                }
                                break;
                            case "CopyMachine":
                                {
                                    List<string> machineList = getMachineCopy(this.SetMachineName);
                                    //Form_Collection.Frm_CopyMAchineData copyDt = new Form_Collection.Frm_CopyMAchineData(Mvalue + "_" + _DicMachineNo[Mvalue], machineList);
                                    //copyDt.Show();
                                }
                                break;
                            case "GetMachine":
                                {

                                }
                                break;
                            case "MachineCOMP":
                                {

                                }
                                break;
                           
                            case "AssignJob":
                                {

                                }
                                break;
                            case "MachineHistory":
                                {

                                }
                                break;
                            case "ReportIncident":
                                {
                                    DPoint _Pont = ((CADImport.CADImageEnt)CadName).Point;
                                    string Mvalue = _MachineCordinates.FirstOrDefault(X => X.Value == _Pont).Key.ToString();
                                    cordinate = _MachineCordinates[Mvalue];
                                    GlobalDeclaration.mcCordinate = cordinate;
                                    GlobalDeclaration.MName = Mvalue;
                                    //Reporting.EventReporting evntRpt = new Reporting.EventReporting();
                                    //evntRpt.Show();
                                }
                                break;
                            case "UploadDoc":
                                {
                                    DPoint _Pont = UpdateCord(((CADImport.CADImageEnt)CadName).Point);
                                    if (_MachineCordinates.ContainsValue(_Pont))
                                    {
                                        string Mvalue = _MachineCordinates.FirstOrDefault(X => X.Value == _Pont).Key.ToString();
                                        cordinate = _MachineCordinates[Mvalue];
                                        GlobalDeclaration.mcCordinate = cordinate;
                                        GlobalDeclaration.MName = Mvalue;
                                        //MachineHistory.McdUploadedFile uplFile = new MachineHistory.McdUploadedFile(Mvalue);
                                        //uplFile.Show();
                                    }
                                    //MachineHistory.McdUploadedFile uplFile = new MachineHistory.McdUploadedFile(Mvalue);
                                    //uplFile.Show();
                                }
                                break;
                            case "SafetyDock":
                                {

                                }
                                break;
                            case "LiveData":
                                {
                                    //MachineDataFeed _MachinFrm = new MachineDataFeed();
                                    //_MachinFrm.Machinename = KeyValue;
                                    //_MachinFrm.serverURLTextBox.Text = IniFile.IniReadValue("OPCServer", "ServerIP");
                                    //_MachinFrm.Show();
                                }
                                break;

                            default:
                                break;
                        }

                    }
                }
            }
        }
        public void Color_Click()
        {
            //if (dlgcolordialog.ShowDialog() == DialogResult.OK)
            //{
            //    //this.cadPictureBox1. = dlgcolordialog.Color;
            //    if (this.cadImage != null)
            //        this.cadImage.DefaultColor = dlgcolordialog.Color;
            //}
        }
        private void sendeventfrm(string sysgenname, string machinename)
        {
            //FormCollection fc = Application.OpenForms;
            //string rcvname = fc["Input_Property"].Name;
            //if(rcvname== "Input_Property")
            //{
            try
            {
                if (Application.OpenForms.OfType<Input_Property>().Count() == 1)
                {
                    Application.OpenForms.OfType<Input_Property>().First().Close();
                    Application.OpenForms.OfType<Input_Property>().First().Dispose();

                    Input_Property input_Property = new Input_Property(sysgenname, machinename);
                    // input_Property.ReceiveConValue = this._UpdateDic;
                    input_Property.ShowDialog();
                }
                else if (Application.OpenForms.OfType<OutPut_Property>().Count() == 1)
                {
                    Application.OpenForms.OfType<OutPut_Property>().First().Close();
                    Application.OpenForms.OfType<OutPut_Property>().First().Dispose();

                    OutPut_Property outPut = new OutPut_Property(machinename, sysgenname);
                    if (this._UpdateDic.Count > 0)
                        // outPut.ReceiveConValue = this._UpdateDic;
                        outPut.ShowDialog();
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // }
        }
        private bool PackegeMachineInfo(CADEntity cAD)
        {
            try
            {
                string ent = MachineName(cAD);
                if (this._HoldPackageMachine.Count > 0 && this._HoldPackageMachine.ContainsKey(ent))
                {

                    if (this._HoldPackageMachine.ContainsKey(ent.Trim()))
                    {
                        string buttontext = RemoveIntegers(ent);
                        //Control c = this.loadpanelpng.Controls["btn" + buttontext];
                        //this.loadpanelpng.Controls.Remove(c);
                        ////this.cadImage.RemoveEntity(cAD);
                        //RecallPackageMachine(this._HoldPackageMachine[ent.Trim()], true);
                        _HoldPackageMachine.TryRemove(ent, out this.package);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception Ex)
            {
                RCNumber--;
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #region Create Package Machine Event Fire       
        private void RecallPackageMachine(PackageMachine.PackageMachine Returnobj, bool ReCall)
        {
            try
            {
                if (ReCall)
                {
                    string Path = string.Empty;
                    if (_HoldImagePat.ContainsKey(Returnobj.PackageMachineName))
                        _HoldImagePat.TryRemove(Returnobj.PackageMachineName, out Path);
                    IsReCallPKG = ReCall;
                    PackageFrm = false;
                    Returnobj.NumberIncreament++;
                }
                Returnobj.cadPictBox.DragOver += Returnobj.loadpanelpng_DragOver;
                Returnobj._HoldImagePat = _HoldImagePat;
                Returnobj.UpdateMachineInfo += UpdatePackageMachine;
                Returnobj._CadMoseCall += ChildCallEvent;
                Returnobj._Closefrm += ClosePackageFrm;
                // Returnobj.cadPictBox.DragOver += new DragEventHandler(this.loadpanelpng_DragOver);
                Returnobj.TopMost = true;
                Returnobj.Show();
                PackageFrm = false;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChildCallEvent(object sender, string e)
        {
            if (this.package != null)
            {
                //this.package.OpenEditFrm(e, this.package._DicMachineNo[e], cmbMachineType.SelectedItem.ToString());
            }
        }
        private void ClosePackageFrm(object sender, string txt)
        {
            if (this.package != null)
            {
                if (_HoldPackageMachine.Count > 0)
                    _HoldPackageMachine.TryRemove(txt, out this.package);

                this.package.Dispose();
                this.package = null;
            }
        }
        private void UpdatePackageMachine(object sender, string e)
        {
            try
            {
                if (package != null)
                {
                    string[] s = (e.ToString()).Split('\\');
                    int count = s.Length;
                    Button btn = new Button();
                    btn.Image = LoadBitmap(e);
                    btn.ImageAlign = ContentAlignment.MiddleCenter;
                    btn.TextAlign = ContentAlignment.MiddleCenter;
                    btn.FlatStyle = FlatStyle.Standard;
                    btn.Size = new Size(147, 132);
                    btn.Name = "btn" + this.package.PackageMachineName;
                    btn.Text = RemoveIntegers(this.package.PackageMachineName);// s[count - 1].Split('.')[0];
                    btn.Tag = "Package";
                    btn.UseCompatibleTextRendering = true;
                    //this.loadpanelpng.Controls.Add(btn);
                    this.cadPictBox.AllowDrop = true;
                    //this.loadpanelpng.AllowDrop = true;
                    // Control c = this.loadpanelpng.Controls[this.loadpanelpng.Controls.Count - 1];
                    // c.MouseDown += new MouseEventHandler(c_MouseDown);
                    PackageFrm = true;
                    package.UpdateMachineInfo -= UpdatePackageMachine;
                    this.package._CadMoseCall -= ChildCallEvent;
                    if (!_HoldPackageMachine.ContainsKey(this.package.PackageMachineName))
                    {
                        _HoldPackageMachine.TryAdd(this.package.PackageMachineName, this.package);
                    }
                    else
                    {
                        _HoldPackageMachine.TryUpdate(this.package.PackageMachineName, this.package, this.package);
                    }
                    if (!_HoldImagePat.ContainsKey(this.package.PackageMachineName))
                    {
                        _HoldImagePat.TryAdd(this.package.PackageMachineName, e);
                    }

                    //this.package.cadImage.Dispose();
                    //this.package.DelePath();
                    //this.package.Dispose();
                    //this.package.Close();
                    this.package.Hide();
                    //this.package.DelePath();
                    //this.package.Dispose();
                    // this.package = null;
                    //File.Delete(e);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string Mvalue = string.Empty;
        private List<string> getMachineCopy(string SetMachineName)
        {
            string[] divArr = new string[] { };
            List<string> lstArr = new List<string>();
            var CadName = this.cadImage.SelectedEntities.AsEnumerable().FirstOrDefault();
            // var divArr = string.Empty;
            if (CadName != null)
            {
                if (CadName.EntType == EntityType.ImageEnt)
                {
                    DPoint _Pont = UpdateCord(((CADImport.CADImageEnt)CadName).Point);
                    Mvalue = _MachineCordinates.FirstOrDefault(X => X.Value == _Pont).Key.ToString();
                    divArr = Mvalue.Split('_');
                }
            }
            for (int i = 0; i < _DicMachineNo.Count; i++)
            {
                if (_DicMachineNo.ContainsKey(divArr[0])) // Check if word already exist in dictionary update the count  
                {
                    string elementVal = _DicMachineNo.ElementAt(i).Key;
                    if (elementVal.Contains(divArr[0]))
                    {
                        lstArr.Add(elementVal + "_" + _DicMachineNo[elementVal]);
                    }
                }
                //var result = _DicMachineNo.GroupBy(x => divArr[0]).ToDictionary(x => x.Key, x => x.Count());
                //return _DicMachineNo;

            }
            return lstArr;
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
        DPoint cordinate = new DPoint();
        #endregion
    }
}
