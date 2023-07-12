using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CADImport;
using CADImport.CADImportForms;
using CADImport.FaceModule;
using CADImport.Professional;
using CADImport.RasterImage;
using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using HindalcoiOS.Connector_FRM;
using HindalcoiOS.Dynamic_Form;
using HindalcoiOS.Form_Collection;
using HindalcoiOS.Machine_Edit_Form;
using SparrowRMS;

namespace HindalcoiOS.PackageMachine
{
   
    public partial class PackageMachine : XtraForm
    {
        #region Package Machine Constructor
        public PackageMachine()
        {
            this.Text = "Components Machine's";
            UpdateTextPosition();
            InitParams();
            InitialCADImportForms();           
            InitializeComponent();
            InitParamsState();
            
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
                XtraMessageBox.Show(new Form { TopMost = true,StartPosition=FormStartPosition.CenterScreen },Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Property Declarartion
        public EventHandler<string> _Closefrm;
        Machine_Edit_Data mcd = null;
        public ConcurrentDictionary<string, Machine_Edit_Data> EditfrmDictionary = new ConcurrentDictionary<string, Machine_Edit_Data>();
        private Dictionary<string, Connector> _listconnt = new Dictionary<string, Connector>();           
        private bool cntrlDown;
        private bool moveMarker;
        private bool stopSnap;
        private bool detMouseDown;
        private bool enableSnap;
        private bool colorDraw;
        private bool holddrag;
        public CADImport.CADImage cadImage;  
        private CADProperty cADProperty = null;
        private CadEntitiesTxt CadEntitiesTxt = null;
        private CADImport.CADImportForms.SetRasterSizeForm rasterSizeForm;
        private CADImport.CADImportForms.LayerForm lForm;
        private Color DefaultColor = Color.Red;
        private EntitiesCreator entCreator;
        private ClipRect clipRectangle;
        private CADPropertyGrid propGrid;       
        // private OpenFileDialog openFileDialog = null;       
        private CreatorType curAddEntityType;
        private Point startPoint;
        private Point endPoint;
        private int addEntity;
        private int btnOffset = 8;
        private int entitiesLimit = 0;
        private int LineIncreament = 1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox riicStyle;
        public Dictionary<string, string> _DicMachineNo = new Dictionary<string, string>();
        public Dictionary<string, DPoint> _MachineCordinates = new Dictionary<string, DPoint>();
        public Image DragfileName = null;
        public string PackageTag = string.Empty;
        public string SetMachineName = string.Empty;

        private bool selectedEntitiesChanged;

        public string PackageMachineName
        {
            get;set;
        }
        public string LineName
        {
            get;set;
        }
        public ConcurrentDictionary<string, string> _HoldImagePat
        {
            get;
            set;
        }

        #endregion

        #region Event Declaration List
        public EventHandler<string> UpdateMachineInfo;
        public EventHandler<string> _CadMoseCall;
        #endregion

        #region Package Machine Form Load Event
        private void PackageMachine_Load(object sender, EventArgs e)
        {
            CadLisenceConfiguration();
            this.cADProperty.VisibleAreaSize = cadPictBox.Size;     
            CreatLayer();
        }
        private void InitParams()
        {
            cADProperty = new CADProperty();
            this.cADProperty.ImageScale = 1.0f;
            this.cADProperty.ImagePreviousScale = 1.0f;
            colorDraw = true;           
            cntrlDown = false;
            startPoint = Point.Empty;
            endPoint = Point.Empty;
            this.cADProperty.PreviousPosition = PointF.Empty;
        }
        private void InitialCADImportForms()
        {
           
            lForm = new LayerForm();
            lForm.LayerChanged += LForm_LayerChanged;
            rasterSizeForm = new SetRasterSizeForm();
        }
        private void LForm_LayerChanged(object sender, LayerChangedEventArgs e)
        {
            this.cadImage.ClearSelection();
            this.cadImage.ClearMarkers();           
            cadPictBox.Invalidate();
        }
        private void InitParamsState()
        {           
            this.clipRectangle = new ClipRect(this.cadPictBox);
            this.entCreator = new EntitiesCreator(this.cadPictBox, Color.White);
            CadEntitiesTxt = new CadEntitiesTxt();
            this.clipRectangle.MultySelect = true;
            SetAddEntityMode(CreatorType.Undetected);         
            CADImportFace.EntityPropertyGrid = this.propGrid;
            this.cadPictBox.MouseWheel += new MouseEventHandler(CADPictBoxMouseWheel);
            this.cadPictBox.ScrollEvent += new CADImport.FaceModule.ScrollEventHandlerExt(CADPictBoxScroll);
            cADProperty.old_Pos = new PointF();
            cADProperty.sc = 1.0f;
            cADProperty.prev_sc = 1.0f;
            cntrlDown = false;
            addEntity = -1;
            startPoint = Point.Empty;
            endPoint = Point.Empty;
            this.entCreator.EndEntityDraw += new CADImport.CADImportForms.ChangeOptionsEventHandler(this.EndAddEntity);
            this.entCreator.GetRealPointEvent += new CADImport.Professional.GetRealPointEvent(this.GetRealPoint);
        }

        private void CadLisenceConfiguration()
        {
            //Protection.Register("plant360", "Ajay@plant360.org", "A5ABA0A03F45EB9D0C9B6A2417D0600AC79C42495B8F9A06584AEC248225290C68C55283F9240373B55DF71718709016C86753F1BA8D5C98840638B3DF5B867", false);
            bool isTst = Protection.Register("PSGFER E&C Pvt. Ltd", "pawan@plant360.org", "284A35D9635818C1E9166E804F94D1746C0D9401B040020C78124913300B708E4330276FD674B49CA86D020F99FD1A98385A1CAE79C35D8C07B9B32EBE45266B", false);
            this.cadPictBox.AllowDrop = true;
        }
        #endregion

        #region Scale AdjustMent
        private void Shift()
        {
            cADProperty.LeftImagePosition = cADProperty.PreviousPosition.X - (cADProperty.PreviousPosition.X - cADProperty.LeftImagePosition) * cADProperty.ImageScale / cADProperty.ImagePreviousScale;
            cADProperty.TopImagePosition = cADProperty.PreviousPosition.Y - (cADProperty.PreviousPosition.Y - cADProperty.TopImagePosition) * cADProperty.ImageScale / cADProperty.ImagePreviousScale;
            cADProperty.ImagePreviousScale = cADProperty.ImageScale;
        }
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
        #endregion

        #region Draw CAD Image in CadPicBox
        public void DrawCADImage(Graphics gr, Control render)
        {
            if (cadImage == null) return;
            Shift();
            RectangleF tmp =this.cADProperty.ImageRectangleF;
            SetSizePictureBox(new Size((int)tmp.Width, (int)tmp.Height));
            SetPictureBoxPosition(this.cADProperty.Position);
            try
            {
                cadImage.Draw(gr, tmp, render);
            }
            catch
            {
                MessageBox.Show("Unable Draw File..?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region CADPicBox Image Draw Size Set
        private bool SizeEqualSizeImageAndPictBox()
        {
            RectangleF tmp = this.cADProperty.ImageRectangleF;
            return ((tmp.Width <= this.cadPictBox.Size.Width) || (tmp.Height <= this.cadPictBox.Height));
        }
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
                MessageBox.Show(Ex.StackTrace, "plant360 Info.?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Get Pixel or Co-rdination of Draw Image
        public DPoint GetRealPoint(int x, int y, bool useGrid)
        {
            //RectangleF tmpRect = this.cADProperty.ImageRectangleF;
            //return CADConst.GetRealPoint(x, y, this.cadImage, tmpRect);
            return GetRealPoint(x, y, useGrid, true);
        }
        public DPoint GetRealPoint(int x, int y, bool useGrid, bool rounding)
        {
            RectangleF tmpRect = this.cADProperty.ImageRectangleF;
            DPoint realPt = CADConst.GetRealPoint(x, y, this.cadImage, tmpRect, rounding);
            if (useGrid)
                this.cadImage.CorrectByGrid(ref realPt);
            return realPt;
        }
        #endregion

        #region Get RealScal       
        public void ResetScaling()
        {
            this.cADProperty.ImageScale = 1.0f;
            this.cADProperty.ImagePreviousScale = 1.0f;
            this.cADProperty.LeftImagePosition = (cadPictBox.ClientRectangle.Width - this.cADProperty.VisibleAreaSize.Width) / 2.0f;
            this.cADProperty.TopImagePosition = (cadPictBox.ClientRectangle.Height - this.cADProperty.VisibleAreaSize.Height) / 2.0f;
            cadPictBox.Invalidate();
        }
        #endregion

        #region Set CAD Image Formate
        public void SetCADImageOptions(bool loadFirst)
        {
            SetSnapMode();
            cadImage.SelectionMode = SelectionEntityMode.Enabled;
            cadImage.GraphicsOutMode = DrawGraphicsMode.GDIPlus;
            cadImage.ChangeDrawMode(cadImage.GraphicsOutMode, cadPictBox);
            cadImage.IsWithoutMargins = true;
            //cadImage.UseWinEllipse = false;
            //cadImage.IsShowLineWeight = false;
            //this.cadImage.UseDoubleBuffering = true;
            // this.Cursor = Cursors.Default;
            // ObjEntity.cadImage = cadImage;
            // xmlImporter.Image = this.cadImage;
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

            //ObjEntity.cadImage = cadImage;
            this.entCreator.Image = this.cadImage;
            //ribbon.Minimized = true;
        }
        public void DoBlackColor()
        {
            if (cadImage == null) return;
            cadImage.DrawMode = CADDrawMode.Normal;
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
                this.clipRectangle.Color = Color.Red;
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
        }


        #endregion

        #region ZoomIn and ZoomOut
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
            SetPictureBoxPosition(this.cADProperty.Position);
        }
        #endregion

        private void ChangeControlState()
        {
            bool detNullImg = cadImage != null;
            //EnableButton(detNullImg);
        }
        private void CADPictBoxKeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.ControlKey) || (e.KeyCode == Keys.ShiftKey))
                this.cntrlDown = false;
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
        private void cadPictBox_Paint(object sender, PaintEventArgs e)
        {            
            DrawCADImage(e.Graphics, sender as Control);
           //this.Text = RealScale;
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
        public void SetAddEntityMode(CreatorType val)
        {
            int tmpVal = addEntity;
            addEntity = -1;
            int ct = (int)val;
            if (tmpVal != ct)
                addEntity = ct;

        }
        private void EndAddEntity(bool val)
        {
            if (curAddEntityType != CreatorType.Undetected)
            {
                if (_IsLineComplete)
                    AssignLineName(curAddEntityType);

                SetAddEntityMode(curAddEntityType);
                // SetEnableChecked();
                //ChangeControlState();               
            }
            this.detMouseDown = val;
        }       
        private void AssignLineName(CreatorType val)
        {
            try
            {
                if (val == CreatorType.Leader)
                {
                    CADEntity entity = entCreator.Image.Converter.Entities.FindLast(ent => ent.EntType == EntityType.Leader);
                    if (entity != null)
                    {
                        CADLeader leader = entity as CADLeader;
                        leader.LineTypeScale = 3;
                        leader.ArrowScale = 3;
                        leader.ArrowSize = 3;
                        leader.Arrowhead = true;
                        //leader.Color = Color.Red;
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
                        entCreator.Image.Converter.Loads(leader);
                        _IsLineComplete = false;
                        if (_listconnt.ContainsKey(LineName))
                        {
                            //bool containsInt = LineName.Any(char.IsDigit);
                            //if (containsInt)
                            //{
                            //    string receiveValue = _listconnt.AsEnumerable().LastOrDefault().Key;
                            //    receiveValue = receiveValue.Substring(receiveValue.Length - 1);
                            //    int randomNumber = Convert.ToInt32(receiveValue);
                            //    if (randomNumber >= 1)
                            //    {
                            //        leader.LineType.Name = LineName + randomNumber++;
                            //    }
                            //}
                            //else
                            //{                                
                            leader.LineType.Name = LineName + LineIncreament++;
                            // }
                        }
                        connector.Points = leader.DottedSingPoints[1].X + "~" + leader.DottedSingPoints[1].Y;
                        _listconnt.Add(leader.LineType.Name, connector);
                        OpenConnectorform(leader.LineType.Name, leader.DottedSingPoints[1]);
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true,StartPosition=FormStartPosition.CenterScreen },Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        
        private void cadPictBox_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (cadImage == null) return;
            if (e.Button != MouseButtons.Right)
                if (ChangeEntityOnMouseUp(new Point(e.X, e.Y)))
                    cadPictBox.Invalidate();
            detMouseDown = false;
            if (this.clipRectangle.Enabled)
                if ((this.clipRectangle.Type == RectangleType.Zooming))
                    UseClipRect();
            if (selectedEntitiesChanged && !CreateNewEntity)
            {
                this.stopSnap = true;
                cadPictBox.Invalidate();
            }
            if (cadImage != null)
                cadImage.SelectedEntities.PropertyChanged -= new PropertyChangedEventHandler(this.SelectedEntitiesChanged);
            selectedEntitiesChanged = false;

        }

        public void UseClipRect()//commn
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
                #region Professional
#if Professional
				cadImage.MultipleSelectExt(tmpRect, cntrlDown, true);				
#else
                cadImage.MultipleSelect(tmpRect, true, true);
#endif
                #endregion
                return true;
            }
            return false;
        }
        private bool ChangeEntityOnMouseUp(Point pt)
        {
            #region Professional
///#if Professional
			if(cadImage.CurrentMarker != null)
			{
				if(! ChancelMove(pt.X, pt.Y))
				{
					SetNewMarkerPosition();				
					return true;
				}
			}
			else
			{				
				if(! CreateNewEntity)
				{
					if(! ChancelMove(pt.X, pt.Y))
					{
						SetNewEntityPosition();				
						return true;
					}
				}
			}			
			return false;
//#else
        
            #endregion
        }
        public void SetNewEntityPosition()
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
            }
        }//commn
        public void SetNewMarkerPosition()
        {
            if ((this.startPoint.X != 0) || (this.startPoint.Y != 0))
            {
                if (this.endPoint == Point.Empty)
                    this.endPoint = new Point(this.cADProperty.cX, this.cADProperty.cY);
                DPoint p = this.GetRealPoint(this.endPoint.X - this.startPoint.X, this.endPoint.Y - this.startPoint.Y, !this.cadPictBox.Ortho, false);
                cadImage.SetNewEntityMarkerPos(p.X, p.Y, p.Z);
                this.startPoint.X = 0;
                this.startPoint.Y = 0;
                this.endPoint.X = 0;
                this.endPoint.Y = 0;
            }
        }//commn
        public bool ChancelMove(int x, int y) //commn
        {
            if (((Math.Abs(this.cADProperty.cX - x) < 2) && (Math.Abs(this.cADProperty.cY - y) < 2)) ||
                (this.cadImage.SelectEntitiesCount == 0))
            {
                return true;
            }
            return false;
        }

        private void cadPictBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {           
            var CadName = this.cadImage.SelectedEntities.AsEnumerable().FirstOrDefault();
            if (CadName != null && CadName.EntType == EntityType.ImageEnt)
            {
                string MachineName = ((CADImport.CADImageEnt)CadName).ImageDef.FileName;
                SetMachineName= MachineNameSplit(CadName);
                //_CadMoseCall.Invoke(sender, MachineName);
                OpenEditFrm(SetMachineName, _DicMachineNo[SetMachineName]);
                // MessageBox.Show(MachineName);
            }
            else if (CadName != null && CadName.EntType == EntityType.Leader)
            {
                CADLeader cadline = (CADLeader)CadName;
                string ReloadLineName = string.Empty;
                if (CadName.LineType.Name == "ByLayer")
                {
                    if (_listconnt.Count > 0)
                    {
                        ReloadLineName = _listconnt.FirstOrDefault(X => X.Value.Points == cadline.DottedSingPoints[1].X + "~" + cadline.DottedSingPoints[1].Y).Key;
                        cadline.LineType.Name = ReloadLineName;
                    }
                }
                LineName = CadName.LineType.Name;
                if (!string.IsNullOrEmpty(LineName))//LineName=="Electrical Cable"|| LineName=="Pipe"||LineName=="Bus Bar"
                    OpenConnectorform(CadName.LineType.Name, cadline.DottedSingPoints[1]);
            }
        }
        private string MachineNameSplit(object _obj)
        {
            string MachineName = ((CADImport.CADImageEnt)_obj).ImageDef.FileName;
            string[] s = (MachineName.ToString()).Split('\\');
            return s[s.Length - 1].Split('.')[0];
        }
        public void OpenEditFrm( string MachineName, string SysGenNo)
        {
            try
            {
                // first check alrdy sys gen machine name with selected object 
                if (cadImage != null)
                {
                    string MachineType = string.Empty;
                    string MachinSubType = string.Empty;
                    string Value = RemoveIntegers(MachineName);
                    if (_HoldImagePat.Count > 0)
                    {
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
                       // SystemMachine = Value + " " + SysGenNo;
                        mcd.RemoveDicEvetHandeler += RemoveFormDic;
                        EditfrmDictionary.TryAdd(SysGenNo, mcd);
                    }
                    DPoint cordinate = _MachineCordinates[MachineName];
                    mcd.cmblayer.Items.Add(MachinSubType);
                    mcd.cmblayer.SelectedIndex = 0;
                    mcd.MachineSybType = MachinSubType;
                    mcd.cmblayer.ListBackColor = Color.White;
                    mcd.cmblayer.ListTextColor = Color.Black;                 
                    mcd._listconnt = this._listconnt;
                    mcd.cmblocation.Items.Add("X" + cordinate.X + " " + "Y" + cordinate.Y);
                    mcd.cmblocation.SelectedIndex = 0;
                    mcd.cmblocation.Enabled = false;
                    mcd.ReceiveConValue = _UpdateDic;
                    mcd.LineType = LineName;
                    mcd._dropMachineList = this._DicMachineNo;
                    mcd.TopMost = true;
                    mcd.cmblayer.Enabled = true;
                    mcd.Show();
                }
                else
                {
                    XtraMessageBox.Show("Please Draw CAD Object First.?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true,StartPosition=FormStartPosition.CenterScreen },Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RemoveFormDic(object sender, string value)
        {
            try
            {
                //if(MechineNumber>1)
                //MechineNumber--;
                Machine_Edit_Data machine_Edit_Data = EditfrmDictionary[value];
                EditfrmDictionary.TryRemove(value, out machine_Edit_Data);
                //string machne = _DicMachineNo.FirstOrDefault(X => X.Value == value).Key;
                //if (_MachineCordinates.ContainsKey(machne))
                //    _MachineCordinates.Remove(machne);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true,StartPosition=FormStartPosition.CenterScreen },Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CreatLayer()
        {
            try
            {
                if (this.cadImage == null)
                {
                    this.cadImage = new CADImage();
                    this.cadImage.InitialNewImage();
                }
                CADLayer vLayer = new CADLayer();
                vLayer.Name = "MachineLayer";
                vLayer.Visible = true;
                vLayer.Visibility = true;
                vLayer.Frozen = true;
                vLayer.DashStyle = DashStyle.DashDotDot;
                vLayer.Flags = 1;
                vLayer.IsPlotting = true;
                vLayer.Color = Color.Red;
                AddEntity(ConvSection.Layers, vLayer);
                SetPictureBoxLoadState(false, string.Empty);
                SetCADImageOptions(true);
                this.ChangeControlState();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true,StartPosition=FormStartPosition.CenterScreen },Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }        
        }
        public void AddEntity(ConvSection aSection, CADEntity aEntity)
        {
            this.cadImage.Converter.Loads(aEntity);
            this.cadImage.Converter.GetSection(aSection).AddEntity(aEntity);
        }      
        private void SetPictureBoxLoadState(bool val, string name)
        {
            this.cadPictBox.Visible = !val;
            if (val)
            {
                this.Cursor = Cursors.WaitCursor;

            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        #region Cad Image Event List
        private void cadPictBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            selectedEntitiesChanged = false;
            if (cadImage != null)
                cadImage.SelectedEntities.PropertyChanged += new PropertyChangedEventHandler(this.SelectedEntitiesChanged);
            if (e.Button != MouseButtons.Right)
            {
                if (!CreateNewEntity)
                    DisableEntityCreator();
                if (this.cadImage != null)
                    if (cadImage.SelectionMode == SelectionEntityMode.Enabled)
                    {
                        if (SelectEntity(e.X, e.Y))
                            return;
                    }
            }
            //ParentForm.
            // this.ActiveForm.Cursor = Cursors.Hand;
            this.cADProperty.cX = e.X;
            this.cADProperty.cY = e.Y;
            detMouseDown = true;
            if (CreateNewEntity)
                if (EnableNewEntityCreator())
                {
                    return;
                }
            if ((e.Button == MouseButtons.Left) && (!moveMarker))
                this.clipRectangle.EnableRect(RectangleType.Zooming, new Rectangle(e.X, e.Y, 0, 0));

            //AditinalCode
            //c.DoDrif (!holddrag)
            //{
            //    Control c = sender as Control;
            //    agDrop(c, DragDropEffects.Move);
            //}

        }
        bool _IsLineComplete;
        public bool SelectEntity(int x, int y)// New Add
        {
            CADEntity ent = cadImage.SelectExt(x, y, cntrlDown, true);
            if (this.CreateNewEntity)
            {
                if (ent != null && ent.EntType == EntityType.ImageEnt)
                {
                    // GetImageName(ent1, x, y);                        
                    UpdateDic(ent);
                }
                else
                {
                    Destination = string.Empty;
                    Source = string.Empty;
                }

                return false;
            }
            
            moveMarker = false;
            if (cadImage == null)
                return false;
            bool det = this.cadImage.SelectedEntities.Count == 0;                                  
                if (!det)
                {
                    this.stopSnap = true;
                }
            
            return false;
        }
        private void OpenConnectorform(string linetyp, DPoint dPoint) // New Add
        {
            try
            {
                ConnectionPropertyFrm cwp = new ConnectionPropertyFrm();
                cwp.ReceiveFkType = linetyp;
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
                }
                cwp.location = dPoint.X + " " + dPoint.Y;
                cwp.UpdateStrcu(connector);
                cwp.UpdateTabPage();
                if (cwp.ShowDialog() == DialogResult.OK)
                {
                }
                else
                {
                    cwp.Close();
                    cwp.Dispose();
                    cwp = null;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show("OpenConnectorform", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #region Region Decalartion for AlterNative Variables 
        public Dictionary<string, List<string>> _UpdateDic = new Dictionary<string, List<string>>();
        private string Source = string.Empty;
        private string Destination = string.Empty;
        Connector connector;
        private void UpdateDic(CADEntity ent1)
        {
            try
            {
                if (ent1 != null && ent1.EntType == EntityType.ImageEnt)
                {
                    if (string.IsNullOrEmpty(Destination) && ((CADImport.CADImageEnt)ent1).ImageDef != null)
                    {
                        connector = new Connector();
                        string MachineName = ((CADImport.CADImageEnt)ent1).ImageDef.FileName;
                        string[] s = (MachineName.ToString()).Split('\\');
                        MachineName = s[s.Length - 1];
                        Destination = MachineName;
                        connector.Connecto = Destination;
                    }
                    else if (string.IsNullOrEmpty(Source) && ((CADImport.CADImageEnt)ent1).ImageDef != null)
                    {
                        string MachineName = ((CADImport.CADImageEnt)ent1).ImageDef.FileName;
                        string[] s = (MachineName.ToString()).Split('\\');
                        MachineName = s[s.Length - 1];
                        Source = MachineName;
                        if (_UpdateDic.ContainsKey(Destination))
                        {
                            List<string> RetrnList = _UpdateDic[Destination];
                            RetrnList.Add(Source);
                            // _UpdateDic.TryUpdate(Destination, RetrnList, RetrnList);
                            _UpdateDic[Destination] = RetrnList;
                            connector.FromData = Source;
                            // _UpdateDic[Destination] = sss;
                            Destination = string.Empty;
                            Source = string.Empty;
                        }
                        else
                        {
                            List<string> addList = new List<string>();
                            addList.Add(Source);
                            _UpdateDic.Add(Destination, addList);
                            connector.FromData = Source;
                            Destination = string.Empty;
                            Source = string.Empty;
                        }
                        _IsLineComplete = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show("End Point Error(UpdateDic).?", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion  //New Add
        private void SelectedEntitiesChanged(object sender, PropertyChangedEventArgs args)
        {
            selectedEntitiesChanged = true;
        }
        private void DisableEntityCreator()
        {
            if (this.entCreator.Enabled)
                if ((this.entCreator.Type == CreatorType.Pen) || ((this.entCreator.Type == CreatorType.Polyline)
                    && this.entCreator.EndPoly) || (this.entCreator.Type == CreatorType.Point))
                    this.entCreator.Disable();
        }
        private void cadPictBox_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (cadImage == null)
                return;
            if (!this.cadPictBox.Focused)
                this.cadPictBox.Focus();
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
            DPoint vPt = GetRealPoint(e.X, e.Y, true);
            this.Text = string.Format("{0} : {1} : {2}", vPt.X, vPt.Y, vPt.Z);
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
        }
        public bool ChangeEntityOnMouseMove(Point pt)
        {
            #region Professional
//#if Professional
			if(this.cadImage.SelectedEntities.Count != 0)
			{		
				if(this.CreateNewEntity) return true;

                this.cadImage.CorrectByGridAndOrtho(ref pt, this.cADProperty.cX, this.cADProperty.cY, this.cadPictBox.Ortho);

				if(cadImage.CurrentMarker != null)
				{									
					ChangeMarkerPosition(pt.X, pt.Y);
					return true;
				}
				else if (moveMarker)
				{						
					ChangeEntityPositionExt(pt.X, pt.Y);
					return true;					
				}				
			}			
//#endif
            #endregion
            return false;
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
        private void ChangeEntityPositionExt(int x, int y)
        {
            Graphics gr = this.cadPictBox.CreateGraphics();
            this.cadImage.DrawMoveEntityTrace(-this.startPoint.X, -this.startPoint.Y, this.cadPictBox);
            this.cadImage.DrawMoveEntityTrace(x - this.cADProperty.cX, y - this.cADProperty.cY, this.cadPictBox);
            this.startPoint.X = this.cADProperty.cX - x;
            this.startPoint.Y = this.cADProperty.cY - y;
        }
        private bool EnableNewEntityCreator()
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
        public bool CreateNewEntity
        {
            get
            {
                bool isHatch = (CreatorType)addEntity == CreatorType.Hatch;
                if ((this.cadImage == null) && isHatch)
                    return false;
                if (this.cadImage != null)
                    if ((this.cadImage.SelectedEntities.Count == 0) && isHatch)
                        return false;
                return (addEntity != -1);
            }
        }
        private void cadPictBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (!this.cadPictBox.Focused)
                    this.cadPictBox.Focus();
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
                XtraMessageBox.Show(new Form { TopMost = true,StartPosition=FormStartPosition.CenterScreen },Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void MoveEntity(int x1, int y1, int x2, int y2)
        {
            cadImage.ClearSnapTrace();
            DPoint p1 = this.GetRealPoint(x1, y1, !this.cadPictBox.Ortho);
            DPoint p2 = this.GetRealPoint(x1 - x2, y1 - y2, !this.cadPictBox.Ortho);
            cadImage.SetNewPosEntitiesExt(p2.X - p1.X, p2.Y - p1.Y, p2.Z - p1.Z, this.cadPictBox.CreateGraphics());
        }
        private void RemoveEntity()
        {
            try
            {
                CADEntity cad = this.cadImage.SelectedEntities.FirstOrDefault();
                string IconNameRemove = string.Empty;
                DPoint RemoveDic;
                if (cad == null) return;
                if (this.cadImage != null && cad != null && cad.EntType == EntityType.ImageEnt && ((CADImport.CADImageEnt)cad).ImageDef != null)
                {
                    string IconName = string.Empty;
                    IconName = MachineName(cad);
                    string sysname = _DicMachineNo[IconName];
                    DPoint cordinate = _MachineCordinates[IconName];
                    _DicMachineNo.Remove(IconName);
                    _MachineCordinates.Remove(sysname);


                    this.cadImage.RemoveEntity(cad);
                    if (MechineNumber > 1)
                        MechineNumber--;
                    DeleteMachineDataFromDB("X" + cordinate.X + " " + "Y" + cordinate.Y, IconName);
                    IconName = string.Empty;
                    sysname = string.Empty;
                }
                else if (this.cadImage != null && cad != null && cad.EntType == EntityType.Leader)
                {
                    CADLeader cadline = (CADLeader)cad;
                    string ConnectFrom = string.Empty;
                    string LineKey = string.Empty;
                    string ConnectorTo = string.Empty;
                    if (_listconnt.Count > 0)
                    {
                        ConnectFrom = _listconnt.FirstOrDefault(X => X.Value.Points == cadline.DottedSingPoints[1].X + "~" + cadline.DottedSingPoints[1].Y).Value.FromData;
                        ConnectorTo = _listconnt.FirstOrDefault(X => X.Value.Points == cadline.DottedSingPoints[1].X + "~" + cadline.DottedSingPoints[1].Y).Value.Connecto;
                        if (cadline.LineType.Name == "BYLAYER")
                        {
                            if (_listconnt.Count > 0)
                            {
                                LineKey = _listconnt.FirstOrDefault(X => X.Value.Points == cadline.DottedSingPoints[1].X + "~" + cadline.DottedSingPoints[1].Y).Key;
                            }
                        }
                        else
                        {
                            LineKey = cad.LineType.Name;
                        }
                        if (_listconnt.ContainsKey(LineKey))
                            _listconnt.Remove(LineKey);

                        if (LineIncreament > 1)
                            LineIncreament--;
                    }
                    if (_UpdateDic.Count > 0)
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
                    DeleteConnectionProperty(cadline.DottedSingPoints[1].X + " " + cadline.DottedSingPoints[1].Y, LineKey);//dPoint.X + " " + dPoint.Y
                    this.cadImage.RemoveEntity(cad);
                }
                else
                {
                    this.cadImage.RemoveEntity(cad);
                }
                this.ClearSelection();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true,StartPosition=FormStartPosition.CenterScreen },Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteMachineDataFromDB(string points, string name)
        {
            try
            {
                int sts = Resources.Instance.RemoveEntry("Sp_DeleteMachineData", "@Mlocation", points);
                if (sts > 0)
                {
                    XtraMessageBox.Show("Successfully Deleted Information of \n " + name + " from DB.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true,StartPosition=FormStartPosition.CenterScreen },Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteConnectionProperty(string points, string LineName)
        {
            try
            {
                int Sts = Resources.Instance.RemoveEntry("Sp_DeleteConnectionProc", "@Mlocation", "@userName", "@userId", "@empCode", points, GlobalDeclaration._holdInfo[0].UserName, GlobalDeclaration._holdInfo[0].UserId.ToString(), GlobalDeclaration._holdInfo[0].EmpCode);
                if (Sts > 0)
                {
                    XtraMessageBox.Show("Successfully Deleted Information of \n " + LineName + " from DB.", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true,StartPosition=FormStartPosition.CenterScreen },Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string MachineName(object _obj)
        {
            string MachineName = ((CADImport.CADImageEnt)_obj).ImageDef.FileName;
            string[] s = (MachineName.ToString()).Split('\\');
            return s[s.Length - 1].Split('.')[0];
        }
        string DeletePath = string.Empty;
        public int NumberIncreament = 0;
        private void checkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Thread thread = new Thread(() => );
                //thread.Name = "SaveImageThread";
                //thread.Start();
                if (DialogResult.Yes == MessageBox.Show("Are You Sure To Generate PackageMachine.", ApplicationConstants.MessageDisplay, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
                {

                    HindalcoiOS.Dynamic_Form.PackageMachine _packageMachine = new HindalcoiOS.Dynamic_Form.PackageMachine();
                    _packageMachine.TopMost = true;
                    if (!String.IsNullOrEmpty(this.PackageMachineName))
                    {
                        DeletePath = this.PackageMachineName;
                        this.PackageMachineName = RemoveIntegers(this.PackageMachineName);
                        _packageMachine.txtmachine.Text = this.PackageMachineName;
                        //_packageMachine.txtmachine.ReadOnly = true;
                        this.PackageMachineName = this.PackageMachineName + NumberIncreament;
                    }                    
                    if (_packageMachine.ShowDialog() == DialogResult.OK)
                    {
                        if (String.IsNullOrEmpty(this.PackageMachineName))                        
                            this.PackageMachineName = _packageMachine.txtmachine.Text.Trim();

                        string DicPath = Application.StartupPath + "\\PackageMachine\\" + PackageMachineName + ".png";
                        SaveImageAsFormat(DicPath, ImageFormat.Png);
                        if (this.UpdateMachineInfo != null)
                            this.UpdateMachineInfo.Invoke(sender, DicPath);
                    }

                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true,StartPosition=FormStartPosition.CenterScreen },Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string RemoveIntegers(string input)
        {
            string regex = Regex.Replace(input, @"[\d-]", string.Empty);
            return regex.Replace("_", "");
        }
        DRect tmpRect;
        private void SaveImageAsFormat1(string filename, ImageFormat format)
        {

            if (File.Exists(filename))
                File.Delete(filename);
            //DRect tmpRect = new DRect(0, 0, ImageRectangleF.Width, ImageRectangleF.Height);
            if (!this.clipRectangle.Enabled)
            {
                tmpRect = new DRect(0, 0, this.cADProperty.ImageRectangleF.Width, this.cADProperty.ImageRectangleF.Height);
                rasterSizeForm.Image = this.cadImage;
                rasterSizeForm.CurrentSize = tmpRect;
                rasterSizeForm.SaveFileName = filename;               
            }
            int tmpNumberOfPartsInCircle = this.cadImage.NumberOfPartsInCircle;
            cadImage.Painter.Settings.SaveParams();
            cadImage.Painter.Settings.DefaultColor = Color.Black.ToArgb();

            cadImage.Painter.Settings.BackgroundColor = Color.White.ToArgb();
            cadImage.Painter.Settings.IsShowBackground = true;
            try
            {
                this.cadImage.NumberOfPartsInCircle = CADConst.SetNumberOfPartsInCurve(tmpRect);               
                cadImage.SaveToFile(filename, format, tmpRect, rasterSizeForm.ImagePixelFormat);                
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true,StartPosition=FormStartPosition.CenterScreen },Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.cadImage.NumberOfPartsInCircle = tmpNumberOfPartsInCircle;
                cadImage.Painter.Settings.RestoreParams();
            }           
        }
        private void SaveImageAsFormat(string filename, ImageFormat format)
        {            
            DRect tmpRect;
            //DRect tmpRect = new DRect(0, 0, ImageRectangleF.Width, ImageRectangleF.Height);
            if (!this.clipRectangle.Enabled)
            {
                tmpRect = new DRect(0, 0, this.cADProperty.ImageRectangleF.Width, this.cADProperty.ImageRectangleF.Height);

                rasterSizeForm.Image = this.cadImage;
                rasterSizeForm.CurrentSize = tmpRect;
                rasterSizeForm.SaveFileName = filename;
                //if (rasterSizeForm.ShowDialog() == DialogResult.OK)
                //    tmpRect = rasterSizeForm.SizeImage;
                //else
                //    return;
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
                if (this.clipRectangle.Enabled)
                {
                    if ((format == ImageFormat.Emf) || (format == ImageFormat.Wmf))
                        cadImage.ExportToMetafile(filename, tmpRect, this.clipRectangle.ClientRectangle);
                    else
                        cadImage.SaveToFile(filename, format, tmpRect, this.clipRectangle.ClientRectangle, rasterSizeForm.ImagePixelFormat);
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
            //if (dlgSave.FilterIndex > 4 && dlgSave.FilterIndex < 12)
            //{
            //    cadPictBox.Navigator.CADImage.Painter.SaveToImage(cadPictBox.Navigator.CADImage, dlgSave.FileName, format,
            //        cadPictBox.Navigator.ImageRectangle,
            //         Manager.Editor.ClipRectTool.ClientRectangle,
            //        PixelFormat.Format32bppArgb);
            //}
        }
        public void DelePath()
        {
            string Path = Application.StartupPath + "\\PackageMachine\\" + DeletePath + ".png";
            System.IO.FileStream fs;
            try
            {

                if (File.Exists(Path))
                {
                    fs = System.IO.File.Open(Path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                    fs.Close();
                    File.Delete(Path);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true,StartPosition=FormStartPosition.CenterScreen },Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                File.Delete(Path);
            }            
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
        public void loadpanelpng_DragOver(object sender, DragEventArgs e)
        {
           e.Effect = DragDropEffects.All;
        }
        public void cadPictBox_DragDrop(object sender, DragEventArgs e)
        {

            if (PackageTag== "Package")
            {
                XtraMessageBox.Show("Ca'nt Drop Package Machine Icon.\n Please Select Machine Icon", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.PackageTag = string.Empty;
                return;
            }
            else
            {
                RectangleF rectangleF = this.cADProperty.ImageRectangleF;
                Point coor = cadPictBox.PointToClient(new Point(e.X, e.Y));
                DPoint pos = GetRealPoint(coor.X, coor.Y, true);
                AddImageEnt(pos);              
                SetCADImageOptions(false);
                holddrag = true;
                cadImage.SelectionMode = SelectionEntityMode.Enabled;
            }
            // ListObject();
            //readExcelSheet(cmbMachineType.SelectedItem.ToString(), cmbsubtype.SelectedValue.ToString(), ImageName);
        }
        int MechineNumber = 1;       
        private void AddImageEnt(DPoint _Drgpoint)//string path
        {
            try
            {
               
                string FilePath = string.Empty;
                CADImageDef vImageDef = new CADImageDef();              
                string SysGenNo = "PKM-" + "M" + MechineNumber++;
                if (_HoldImagePat.ContainsKey(SetMachineName))
                    FilePath = _HoldImagePat[SetMachineName];
                if (_DicMachineNo.ContainsKey(SetMachineName))
                {
                    string receiveValue = _DicMachineNo.AsEnumerable().LastOrDefault().Value;
                    int randomNumber = Convert.ToInt32(receiveValue.Split('-')[1].Remove(1, 1));              
                    _DicMachineNo.Add(SetMachineName.Split('.')[0] + randomNumber, SysGenNo);
                    vImageDef.FileName = FilePath;// vSetMachineName.Split('.')[0] + randomNumber;
                    _MachineCordinates.Add(SetMachineName.Split('.')[0] + randomNumber, _Drgpoint);                   
                    MechineNumber--;
                    SysGenNo = string.Empty;                   
                }
                else
                {
                    _DicMachineNo.Add(SetMachineName, SysGenNo);
                    vImageDef.FileName = FilePath;//SetMachineName;
                    vImageDef.Color = Color.DarkRed;
                    _MachineCordinates.Add(SetMachineName, _Drgpoint);
                }
                if (new Bitmap(vImageDef.FileName) != null)
                {
                    AddEntToSection(ConvSection.ImageDefs, vImageDef);
                    CADImageEnt vImageEnt = new CADImageEnt();
                    vImageEnt.ImageDef = vImageDef;
                    vImageEnt.UVector = CADConst.XOrtAxis;
                    vImageEnt.VVector = CADConst.YOrtAxis;
                   // vImageEnt.Size = vImageEnt.ImageDef.Size;
                    vImageEnt.Color = Color.DarkRed;
                    vImageEnt.TransparentColor = Color.White;
                    vImageEnt.Point = _Drgpoint;
                    vImageEnt.Width = 5;
                    vImageEnt.Height = 5;
                    if (!PlaceEntity(vImageEnt))
                        this.cadImage.Converter.ImageDefs.Remove(vImageDef);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true,StartPosition=FormStartPosition.CenterScreen },Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool PlaceEntity(CADEntity aEntity)
        {
            return PlaceEntity(aEntity, "");
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

        private void PackageMachine_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_Closefrm!=null)
            {
                _Closefrm.Invoke(sender, this.PackageMachineName);
            }            
        }

        private void AddEntToSection(ConvSection aSection, CADEntity aEntity)
        {
            //CADBlock tempcadBlock = new CADBlock();
            //tempcadBlock.Name = "caption";
            //tempcadBlock.Offset = new DPoint(vPt.X, vPt.Y, vPt.Z);
            //this.cadImage.Converter.Loads(aEntity);
            //this.cadImage.Converter.GetSection(aSection).AddEntity(aEntity);
            //tempcadBlock.AddEntity(aEntity);
            //cadImage.Converter.Loads(tempcadBlock);
            //cadImage.Converter.GetSection(ConvSection.Blocks).AddEntity(tempcadBlock);
            //CADInsert vInsert = new CADInsert();
            //vInsert.Block = tempcadBlock;
            //vInsert.Point = new DPoint(10, 10, 0);

            this.cadImage.Converter.Loads(aEntity);
            this.cadImage.Converter.GetSection(aSection).AddEntity(aEntity);

        }

        #endregion
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
