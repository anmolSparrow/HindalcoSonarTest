using ClosedXML.Excel;
using DevExpress.XtraEditors;
using iTextSharp.text;
using iTextSharp.text.pdf;
using HindalcoiOS.Class_Operation;
using HindalcoiOS.DAL;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HindalcoiOS.Reporting
{
    public partial class DailyGeneralCheck : DevExpress.XtraEditors.XtraForm
    {
        public ServiceDAL DalService { get; set; }
        private bool isDTPSearch { get; set; }
        public Reporting.DailyChecks ModelDailyCehcks { get; set; }

        public DailyGeneralCheck()
        {
            DalService = new ServiceDAL();
            ModelDailyCehcks = new Reporting.DailyChecks();
            InitializeComponent();
        }

        #region Property Section
        private string shiftName { get; set; }
        private int GranulationDrum { get; set; }
        private int DryerDrum { get; set; }
        private int CoolerDrum { get; set; }
        private int GearthGear { get; set; }
        private int FeedingBelt01GB { get; set; }
        private int BoronBeltGB { get; set; }
        private int RMBeltGB { get; set; }
        private int RMElevatorGearBox { get; set; }
        private int GranulationDrumGB { get; set; }
        private int DryerDrumGB { get; set; }
        private int DCBeltGB { get; set; }
        private int CoolerDrumGB { get; set; }
        private int CMBeltGB { get; set; }
        private int CMElevatorGB { get; set; }
        private int RecycleBeltGB { get; set; }
        private int ProductionBeltGB { get; set; }
        private int PackingBeltGB { get; set; }
        private int FeedingBelt01GBSSp { get; set; }
        private int ZNBeltGB { get; set; }
        private int ZNElevatorGB { get; set; }
        private int BottomScrewConveyor { get; set; }
        private int GRElevatorGearBox { get; set; }
        private int TopScrewConveyor { get; set; }
        private int MixerGearBox { get; set; }
        private int DanGearBox { get; set; }
        private int DozzerGearBox { get; set; }
        private int DanChain { get; set; }
        private int FloatingShaft { get; set; }
        private int CouplingNut { get; set; }
        private int Rope { get; set; }
        private int Miscallaneous { get; set; }
        private int FeedingBelt01GBPssp { get; set; }
        private int FeedingBelt02GBPssp { get; set; }
        private int ScreberFan { get; set; }
        private int BallMillIDFan { get; set; }
        private int Mounting { get; set; }
        private int HDPEFlang { get; set; }
        private int HDPEPipe { get; set; }
        private int ServicePmp78 { get; set; }
        private int ServicePmp98 { get; set; }
        private int VerticalPmp03
        {
            get; set;
        }

        private int VerticalPmp04 { get; set; }
        private int SilicaPmp { get; set; }
        private string IncId { get; set; }

        private string[] shiftFrom = new string[3];
        private string[] shiftTo = new string[3];
        DataTable DTView = null;
        private bool isRdbSelected { get; set; }
        DataTable shiftData = new DataTable();
        #endregion
        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbShiftA.Checked == true)
                {
                    shiftName = rdbShiftA.Text;
                }
                if (rdbShiftB.Checked == true)
                {
                    shiftName = rdbShiftB.Text;
                }
                if (rdbShiftC.Checked == true)
                {
                    shiftName = rdbShiftC.Text;
                }
                if (chkCompGDrum.Checked == true)
                {
                    GranulationDrum = 1;
                }
                else
                {
                    GranulationDrum = 0;
                }

                if (chkCompCoolDrum.Checked == true)
                {
                    CoolerDrum = 1;
                }
                else
                {
                    CoolerDrum = 0;
                }

                if (chkCompDryDrum.Checked == true)
                {
                    DryerDrum = 1;
                }
                else
                {
                    DryerDrum = 0;
                }

                if (chkGSSPFeeBelt01.Checked == true)
                {
                    FeedingBelt01GB = 1;
                }
                else
                {
                    FeedingBelt01GB = 0;
                }

                if (chkGSSPBoronBelt.Checked == true)
                {
                    BoronBeltGB = 1;
                }
                else
                {
                    BoronBeltGB = 0;
                }

                if (chkGSSPRMBelt.Checked == true)
                {
                    RMBeltGB = 1;
                }
                else
                {
                    RMBeltGB = 0;
                }


                if (chkGSSPRmElGBox.Checked == true)
                {
                    RMElevatorGearBox = 1;
                }
                else
                {
                    RMElevatorGearBox = 0;
                }

                if (chkGSSPGrenuDrmGB.Checked == true)
                {
                    GranulationDrumGB = 1;
                }
                else
                {
                    GranulationDrumGB = 0;
                }

                if (chkGSSPDryDRumGB.Checked == true)
                {
                    DryerDrumGB = 1;
                }
                else
                {
                    DryerDrumGB = 0;
                }

                if (chkGSSPDCBeltGB.Checked == true)
                {
                    DCBeltGB = 1;
                }
                else
                {
                    DCBeltGB = 0;
                }

                if (chkGSSPCoolDrmGB.Checked == true)
                {
                    CoolerDrumGB = 1;
                }
                else
                {
                    CoolerDrumGB = 0;
                }

                if (chkGSSPCMBeltGB.Checked == true)
                {
                    CMBeltGB = 1;
                }
                else
                {
                    CMBeltGB = 0;
                }

                if (chkGSSPCMEleGB.Checked == true)
                {
                    CMElevatorGB = 1;
                }
                else
                {
                    CMElevatorGB = 0;
                }

                if (chkGSSPRecyclBelGB.Checked == true)
                {
                    RecycleBeltGB = 1;
                }
                else
                {
                    RecycleBeltGB = 0;
                }

                if (chkOPSSPBelt01GB.Checked == true)
                {
                    FeedingBelt01GBPssp = 1;
                }
                else
                {
                    FeedingBelt01GBPssp = 0;
                }

                if (chkOPSSPB02GB.Checked == true)
                {
                    FeedingBelt02GBPssp = 1;
                }
                else
                {
                    FeedingBelt02GBPssp = 0;
                }

                if (chkGSSPPrdBeltGB.Checked == true)
                {
                    ProductionBeltGB = 1;
                }
                else
                {
                    ProductionBeltGB = 0;
                }

                if (chkGSSPPackBeltGB.Checked == true)
                {
                    PackingBeltGB = 1;
                }
                else
                {
                    PackingBeltGB = 0;
                }

                if (chkOSSPFeedBltGB.Checked == true)
                {
                    FeedingBelt01GBSSp = 1;
                }
                else
                {
                    FeedingBelt01GBSSp = 0;
                }

                if (chkOSSPZNBeltGB.Checked == true)
                {
                    ZNBeltGB = 1;
                }
                else
                {
                    ZNBeltGB = 0;
                }

                if (chkOSSPZNElvtGB.Checked == true)
                {
                    ZNElevatorGB = 1;
                }
                else
                {
                    ZNElevatorGB = 0;
                }

                if (chkOSSPBottomScrCon.Checked == true)
                {
                    BottomScrewConveyor = 1;
                }
                else
                {
                    BottomScrewConveyor = 0;
                }

                if (chkOSSPGRElvtGB.Checked == true)
                {
                    GRElevatorGearBox = 1;
                }
                else
                {
                    GRElevatorGearBox = 0;
                }

                if (chkOSSPTopScrCon.Checked == true)
                {
                    TopScrewConveyor = 1;
                }
                else
                {
                    TopScrewConveyor = 0;
                }

                if (chkOSSPMixGB.Checked == true)
                {
                    MixerGearBox = 1;
                }
                else
                {
                    MixerGearBox = 0;
                }

                if (chkOSSPDANGB.Checked == true)
                {
                    DanGearBox = 1;
                }
                else
                {
                    DanGearBox = 0;
                }

                if (chkOSSPDozzerGB.Checked == true)
                {
                    DozzerGearBox = 1;
                }
                else
                {
                    DozzerGearBox = 0;
                }

                if (chkOSSPDANChain.Checked == true)
                {
                    DanChain = 1;
                }
                else
                {
                    DanChain = 0;
                }

                if (chkCraneFloaShaft.Checked == true)
                {
                    FloatingShaft = 1;
                }
                else
                {
                    FloatingShaft = 0;
                }

                if (chkCraneCoupNut.Checked == true)
                {
                    CouplingNut = 1;
                }
                else
                {
                    CouplingNut = 0;
                }

                if (chkCraneRope.Checked == true)
                {
                    Rope = 1;
                }
                else
                {
                    Rope = 0;
                }

                if (chkCraneMissc.Checked == true)
                {
                    Miscallaneous = 1;
                }
                else
                {
                    Miscallaneous = 0;
                }

                if (chkVibrScrFan.Checked == true)
                {
                    ScreberFan = 1;
                }
                else
                {
                    ScreberFan = 0;
                }

                if (chkVibrBMillFan.Checked == true)
                {
                    BallMillIDFan = 1;
                }
                else
                {
                    BallMillIDFan = 0;
                }

                if (chkLeakMount.Checked == true)
                {
                    Mounting = 1;
                }
                else
                {
                    Mounting = 0;
                }

                if (chkLeakHDflang.Checked == true)
                {
                    HDPEFlang = 1;
                }
                else
                {
                    HDPEFlang = 0;
                }

                if (chkLeakHDPipe.Checked == true)
                {
                    HDPEPipe = 1;
                }
                else
                {
                    HDPEPipe = 0;
                }

                if (chkLeakPmp78.Checked == true)
                {
                    ServicePmp78 = 1;
                }
                else
                {
                    ServicePmp78 = 0;
                }

                if (chkLeakpmp98.Checked == true)
                {
                    ServicePmp98 = 1;
                }
                else
                {
                    ServicePmp98 = 0;
                }

                if (chkLeakvpmp03.Checked == true)
                {
                    VerticalPmp03 = 1;
                }
                else
                {
                    VerticalPmp03 = 0;
                }

                if (chkLeakvpmp04.Checked == true)
                {
                    VerticalPmp04 = 1;
                }
                else
                {
                    VerticalPmp04 = 0;
                }

                if (chkLeakSilpmp.Checked == true)
                {
                    SilicaPmp = 1;
                }
                else
                {
                    SilicaPmp = 0;
                }

                if (rdbShiftA.Checked == true)
                {
                    isRdbSelected = true;
                }
                else
                {
                    isRdbSelected = false;
                }

                if (rdbShiftB.Checked == true)
                {
                    isRdbSelected = true;
                }
                else
                {
                    isRdbSelected = false;
                }
                if (rdbShiftC.Checked == true)
                {
                    isRdbSelected = true;
                }
                else
                {
                    isRdbSelected = false;
                }


                if ((lblShiftFrom.Text == "") && (lblShiftTo.Text == "") && isRdbSelected == false)
                {
                    XtraMessageBox.Show("Empty entries not allowed", ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ObjectToClassMapper();
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ObjectToClassMapper()
        {
            try
            {
                ModelDailyCehcks.ShiftName = shiftName;
                ModelDailyCehcks.EntryDate = DateTime.Now;
                ModelDailyCehcks.GranulationDrum = 1;
                ModelDailyCehcks.CoolerDrum = CoolerDrum;
                ModelDailyCehcks.DryerDrum = DryerDrum;
                ModelDailyCehcks.FeedingBelt01GB = FeedingBelt01GB;
                ModelDailyCehcks.BoronBeltGB = BoronBeltGB;
                ModelDailyCehcks.RMBeltGB = RMBeltGB;
                ModelDailyCehcks.RMElevatorGearBox = RMElevatorGearBox;
                ModelDailyCehcks.GranulationDrumGB = GranulationDrumGB;
                ModelDailyCehcks.DryerDrumGB = DryerDrumGB;
                ModelDailyCehcks.DCBeltGB = DCBeltGB;
                ModelDailyCehcks.CoolerDrumGB = CoolerDrumGB;
                ModelDailyCehcks.CMBeltGB = CMBeltGB;
                ModelDailyCehcks.CMElevatorGB = CMElevatorGB;
                ModelDailyCehcks.RecycleBeltGB = RecycleBeltGB;
                ModelDailyCehcks.FeedingBelt01GBPssp = FeedingBelt01GBPssp;
                ModelDailyCehcks.FeedingBelt02GBPssp = FeedingBelt02GBPssp;
                ModelDailyCehcks.ProductionBeltGB = ProductionBeltGB;
                ModelDailyCehcks.PackingBeltGB = PackingBeltGB;
                ModelDailyCehcks.FeedingBelt01GBSSp = FeedingBelt01GBSSp;
                ModelDailyCehcks.ZNBeltGB = ZNBeltGB;
                ModelDailyCehcks.ZNElevatorGB = ZNElevatorGB;
                ModelDailyCehcks.BottomScrewConveyor = BottomScrewConveyor;
                ModelDailyCehcks.GRElevatorGearBox = GRElevatorGearBox;
                ModelDailyCehcks.TopScrewConveyor = TopScrewConveyor;
                ModelDailyCehcks.MixerGearBox = MixerGearBox;
                ModelDailyCehcks.DanGearBox = DanGearBox;
                ModelDailyCehcks.DozzerGearBox = DozzerGearBox;
                ModelDailyCehcks.DanChain = DanChain;
                ModelDailyCehcks.FloatingShaft = FloatingShaft;
                ModelDailyCehcks.CouplingNut = CouplingNut;
                ModelDailyCehcks.CouplingNut = CouplingNut;
                ModelDailyCehcks.Rope = Rope;
                ModelDailyCehcks.Miscallaneous = Miscallaneous;
                ModelDailyCehcks.ScreberFan = ScreberFan;
                ModelDailyCehcks.BallMillIDFan = BallMillIDFan;
                ModelDailyCehcks.Mounting = Mounting;
                ModelDailyCehcks.HDPEFlang = HDPEFlang;
                ModelDailyCehcks.HDPEPipe = HDPEPipe;
                ModelDailyCehcks.ServicePmp78 = ServicePmp78;
                ModelDailyCehcks.ServicePmp98 = ServicePmp98;
                ModelDailyCehcks.VerticalPmp03 = VerticalPmp03;
                ModelDailyCehcks.VerticalPmp04 = VerticalPmp04;
                ModelDailyCehcks.SilicaPmp = SilicaPmp;
                int m = ModelDailyCehcks.SetShiftDetails(ModelDailyCehcks, 1);
                if (m > 0)
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Record saved successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetControls();
                }
                else
                {
                    XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Oops somehting went Wrong!.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetControls()
        {
            chkCompCoolDrum.Checked = false;
            chkCompDryDrum.Checked = false;
            chkCompGDrum.Checked = false;
            chkCraneCoupNut.Checked = false;
            chkCraneFloaShaft.Checked = false;
            chkCraneMissc.Checked = false;
            chkCraneRope.Checked = false;
            chkGreeEathGear.Checked = false;
            chkGSSPBoronBelt.Checked = false;
            chkGSSPCMBeltGB.Checked = false;
            chkGSSPCMEleGB.Checked = false;
            chkGSSPCoolDrmGB.Checked = false;
            chkGSSPDCBeltGB.Checked = false;
            chkGSSPDryDRumGB.Checked = false;
            chkGSSPFeeBelt01.Checked = false;
            chkGSSPGrenuDrmGB.Checked = false;
            chkGSSPPackBeltGB.Checked = false;
            chkGSSPPrdBeltGB.Checked = false;
            chkGSSPRecyclBelGB.Checked = false;
            chkGSSPRMBelt.Checked = false;
            chkGSSPRmElGBox.Checked = false;
            chkLeakHDflang.Checked = false;
            chkLeakHDPipe.Checked = false;
            chkLeakMount.Checked = false;
            chkLeakPmp78.Checked = false;
            chkLeakpmp98.Checked = false;
            chkLeakSilpmp.Checked = false;
            chkLeakvpmp03.Checked = false;
            chkLeakvpmp04.Checked = false;
            chkOPSSPB02GB.Checked = false;
            chkOPSSPBelt01GB.Checked = false;
            chkOSSPBottomScrCon.Checked = false;
            chkOSSPDANChain.Checked = false;
            chkOSSPDANGB.Checked = false;
            chkOSSPDozzerGB.Checked = false;
            chkOSSPFeedBltGB.Checked = false;
            chkOSSPGRElvtGB.Checked = false;
            chkOSSPMixGB.Checked = false;
            chkOSSPTopScrCon.Checked = false;
            chkOSSPZNBeltGB.Checked = false;
            chkOSSPZNElvtGB.Checked = false;
            chkVibrBMillFan.Checked = false;
            chkVibrScrFan.Checked = false;
            rdbShiftA.Checked = false;
            rdbShiftB.Checked = false;
            rdbShiftC.Checked = false;
        }

        private void DailyGeneralCheck_Load(object sender, EventArgs e)
        {
            HideJSAInputPagesHeader();
            ResetCheckBoxs();
            try
            {
                isDTPSearch = false;
                shiftFrom[0] = "7:00 AM";
                shiftFrom[1] = "3:00 PM";
                shiftFrom[2] = "11:00 PM";

                shiftTo[0] = "2:59 PM";
                shiftTo[1] = "10:59 PM";
                shiftTo[2] = "6:59 AM";
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShiftRadioCheck()
        {
            try
            {
                if (rdbShiftA.Checked == true)
                {
                    lblShiftFrom.Text = shiftFrom[0];
                    lblShiftTo.Text = shiftTo[0];
                }

                if (rdbShiftB.Checked == true)
                {
                    lblShiftFrom.Text = shiftFrom[1];
                    lblShiftTo.Text = shiftTo[1];
                }

                if (rdbShiftC.Checked == true)
                {
                    lblShiftFrom.Text = shiftFrom[2];
                    lblShiftTo.Text = shiftTo[2];
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void rdbShiftA_CheckedChanged(object sender, EventArgs e)
        {
            ShiftRadioCheck();
        }

        private void DailyGnrlCheckPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.DailyGnrlCheckPages.SelectedIndex == 0)
                {
                    this.btnSaveClose.Visible = true;
                }
                else
                {
                    this.btnSaveClose.Visible = false;
                    this.btnExportXls.Visible = true;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SetShift();
                isDTPSearch = true;
                Guid GId = Guid.NewGuid();
                if (isDTPSearch == false)
                {
                    shiftData = ModelDailyCehcks.GetShiftChecks(shiftName, dtpDateFrom.Value, dtpDateTo.Value, 1, GId);
                }
                if ((isDTPSearch == true) && (!string.IsNullOrEmpty(shiftName)))
                {
                    if (shiftName == "Shift A" || shiftName == "Shift B" || shiftName == "Shift C")
                    {
                        shiftData = ModelDailyCehcks.GetShiftChecks(shiftName, dtpDateFrom.Value, dtpDateTo.Value, 2, GId);
                    }
                    if (shiftName == "Shift AB")// || shiftName == "Shift B" || shiftName == "Shift C")
                    {
                        shiftData = ModelDailyCehcks.GetShiftChecks(shiftName, dtpDateFrom.Value, dtpDateTo.Value, 5, GId);
                    }
                    if (shiftName == "Shift AC")// || shiftName == "Shift B" || shiftName == "Shift C")
                    {
                        shiftData = ModelDailyCehcks.GetShiftChecks(shiftName, dtpDateFrom.Value, dtpDateTo.Value, 6, GId);
                    }
                    if (shiftName == "Shift BC")// || shiftName == "Shift B" || shiftName == "Shift C")
                    {
                        shiftData = ModelDailyCehcks.GetShiftChecks(shiftName, dtpDateFrom.Value, dtpDateTo.Value, 7, GId);
                    }
                    if (shiftName == "Shift ABC")// || shiftName == "Shift B" || shiftName == "Shift C")
                    {
                        shiftData = ModelDailyCehcks.GetShiftChecks(shiftName, dtpDateFrom.Value, dtpDateTo.Value, 8, GId);
                    }
                }

                if ((isDTPSearch == true) && (string.IsNullOrEmpty(shiftName)))
                {
                    shiftData = ModelDailyCehcks.GetShiftChecks("", dtpDateFrom.Value, dtpDateTo.Value, 3, GId);
                }
                if (string.IsNullOrEmpty(shiftName))
                {
                    shiftData = ModelDailyCehcks.GetShiftChecks("", dtpDateFrom.Value, dtpDateTo.Value, 3, GId);
                }

                this.DGVDailyChecks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                this.DGVDailyChecks.DataSource = shiftData;
                this.DGVDailyChecks.Columns["incId"].Visible = false;
                this.DGVDailyChecks.Columns["ShiftName"].HeaderText = "Shift Name";
                this.DGVDailyChecks.Columns["EntryDate"].HeaderText = "Entry Date";
                this.DGVDailyChecks.Columns["EntryDate1"].Visible = false;// "Entry Date";
                this.DGVDailyChecks.Columns["FeedingBelt01GBPssp1"].Visible = false;
                this.DGVDailyChecks.Columns["FeedingBelt01GBSSp1"].Visible = false;
                this.DGVDailyChecks.Columns["GranulationDrum1"].Visible = false;
                this.DGVDailyChecks.Columns["ShiftName1"].Visible = false;

                //this.DGVDailyChecks.Columns["GranulationDrum"].HeaderText = "Granulation Drum";
                //this.DGVDailyChecks.Columns["DryerDrum"].HeaderText = "Dryer Drum";
                //this.DGVDailyChecks.Columns["CoolerDrum"].HeaderText = "Cooler Drum";
                //this.DGVDailyChecks.Columns["GearthGear"].HeaderText = "Gearth Gear";
                //this.DGVDailyChecks.Columns["FeedingBelt01GB"].HeaderText = "Feeding Belt-01GB";
                //this.DGVDailyChecks.Columns["BoronBeltGB"].HeaderText = "Boron Belt-GB";
                //this.DGVDailyChecks.Columns["RMBeltGB"].HeaderText = "RM Belt-GB";
                //this.DGVDailyChecks.Columns["RMElevatorGearBox"].HeaderText = "RM Elevator-GearBox";
                //this.DGVDailyChecks.Columns["GranulationDrumGB"].HeaderText = "Granulation Drum-GB";
                //this.DGVDailyChecks.Columns["DryerDrumGB"].HeaderText = "Dryer Drum-GB";
                //this.DGVDailyChecks.Columns["CoolerDrumGB"].HeaderText = "Cooler Drum-GB";
                //this.DGVDailyChecks.Columns["CMBeltGB"].HeaderText = "CM Belt-GB";
                //this.DGVDailyChecks.Columns["CMElevatorGB"].HeaderText = "CM Elevator-GB";
                //this.DGVDailyChecks.Columns["RecycleBeltGB"].HeaderText = "Recycle Belt-GB";
                //this.DGVDailyChecks.Columns["ProductionBeltGB"].HeaderText = "Production Belt-GB";
                //this.DGVDailyChecks.Columns["PackingBeltGB"].HeaderText = "Packing Belt-GB";
                //this.DGVDailyChecks.Columns["FeedingBelt01GBSSp"].HeaderText = "Feeding Belt-01GBSSp";
                //this.DGVDailyChecks.Columns["ZNBeltGB"].HeaderText = "ZN Belt-GB";
                //this.DGVDailyChecks.Columns["ZNElevatorGB"].HeaderText = "ZN Elevator-GB";
                //this.DGVDailyChecks.Columns["BottomScrewConveyor"].HeaderText = "Bottom Screw-Conveyor";
                //this.DGVDailyChecks.Columns["GRElevatorGearBox"].HeaderText = "GRElevator Gear-Box";
                //this.DGVDailyChecks.Columns["TopScrewConveyor"].HeaderText = "Top Screw-Conveyor";
                //this.DGVDailyChecks.Columns["MixerGearBox"].HeaderText = "Mixer Gear-Box";
                //this.DGVDailyChecks.Columns["DanGearBox"].HeaderText = "Dan Gear-Box";
                //this.DGVDailyChecks.Columns["DozzerGearBox"].HeaderText = "Dozzer Gear-Box";
                //this.DGVDailyChecks.Columns["DanChain"].HeaderText = "Dan Chain";
                //this.DGVDailyChecks.Columns["FloatingShaft"].HeaderText = "Floating Shaft";
                //this.DGVDailyChecks.Columns["CouplingNut"].HeaderText = "Coupling Nut";
                //this.DGVDailyChecks.Columns["Rope"].HeaderText = "Rope";
                //this.DGVDailyChecks.Columns["Miscallaneous"].HeaderText = "Miscallaneous";
                //this.DGVDailyChecks.Columns["FeedingBelt01GBPssp"].HeaderText = "Feeding Belt-01GBPssp";
                //this.DGVDailyChecks.Columns["FeedingBelt02GBPssp"].HeaderText = "Feeding Belt-02GBPssp";
                //this.DGVDailyChecks.Columns["ScreberFan"].HeaderText = "Screber Fan";
                //this.DGVDailyChecks.Columns["BallMillIDFan"].HeaderText = "Ball Mill-ID Fan";
                //this.DGVDailyChecks.Columns["Mounting"].HeaderText = "Mounting";
                //this.DGVDailyChecks.Columns["HDPEFlang"].HeaderText = "HDPE Flang";
                //this.DGVDailyChecks.Columns["HDPEPipe"].HeaderText = "HDPE Pipe";
                //this.DGVDailyChecks.Columns["ServicePmp78"].HeaderText = "Service Pmp-78";
                //this.DGVDailyChecks.Columns["ServicePmp98"].HeaderText = "Service Pmp-98";
                //this.DGVDailyChecks.Columns["VerticalPmp03"].HeaderText = "Vertical Pmp-03";
                //this.DGVDailyChecks.Columns["VerticalPmp04"].HeaderText = "Vertical Pmp-04";
                //this.DGVDailyChecks.Columns["SilicaPmp"].HeaderText = "Silica Pmp";
                //this.DGVDailyChecks.Columns["DocumentedBy"].HeaderText = "Documented By";
                //--------------------------------------------------------------------------
                this.DGVDailyChecks.Columns["DCbeltGB"].Visible = false;
                this.DGVDailyChecks.Columns["GranulationDrum"].Visible = false;
                this.DGVDailyChecks.Columns["DryerDrum"].Visible = false;
                this.DGVDailyChecks.Columns["CoolerDrum"].Visible = false;
                this.DGVDailyChecks.Columns["GearthGear"].Visible = false;
                this.DGVDailyChecks.Columns["FeedingBelt01GB"].Visible = false;
                this.DGVDailyChecks.Columns["BoronBeltGB"].Visible = false;
                this.DGVDailyChecks.Columns["RMBeltGB"].Visible = false;
                this.DGVDailyChecks.Columns["RMElevatorGearBox"].Visible = false;
                this.DGVDailyChecks.Columns["GranulationDrumGB"].Visible = false;
                this.DGVDailyChecks.Columns["DryerDrumGB"].Visible = false;
                this.DGVDailyChecks.Columns["CoolerDrumGB"].Visible = false;
                this.DGVDailyChecks.Columns["CMBeltGB"].Visible = false;
                this.DGVDailyChecks.Columns["CMElevatorGB"].Visible = false;
                this.DGVDailyChecks.Columns["RecycleBeltGB"].Visible = false;
                this.DGVDailyChecks.Columns["ProductionBeltGB"].Visible = false;
                this.DGVDailyChecks.Columns["PackingBeltGB"].Visible = false;
                this.DGVDailyChecks.Columns["FeedingBelt01GBSSp"].Visible = false; ;
                this.DGVDailyChecks.Columns["ZNBeltGB"].Visible = false;
                this.DGVDailyChecks.Columns["ZNElevatorGB"].Visible = false;
                this.DGVDailyChecks.Columns["BottomScrewConveyor"].Visible = false;
                this.DGVDailyChecks.Columns["GRElevatorGearBox"].Visible = false;
                this.DGVDailyChecks.Columns["TopScrewConveyor"].Visible = false;
                this.DGVDailyChecks.Columns["MixerGearBox"].Visible = false;
                this.DGVDailyChecks.Columns["DanGearBox"].Visible = false;
                this.DGVDailyChecks.Columns["DozzerGearBox"].Visible = false;
                this.DGVDailyChecks.Columns["DanChain"].Visible = false;
                this.DGVDailyChecks.Columns["FloatingShaft"].Visible = false;
                this.DGVDailyChecks.Columns["CouplingNut"].Visible = false;
                this.DGVDailyChecks.Columns["Rope"].Visible = false;
                this.DGVDailyChecks.Columns["Miscallaneous"].Visible = false;
                this.DGVDailyChecks.Columns["FeedingBelt01GBPssp"].Visible = false;
                this.DGVDailyChecks.Columns["FeedingBelt02GBPssp"].Visible = false;
                this.DGVDailyChecks.Columns["ScreberFan"].Visible = false;
                this.DGVDailyChecks.Columns["BallMillIDFan"].Visible = false;
                this.DGVDailyChecks.Columns["Mounting"].Visible = false;
                this.DGVDailyChecks.Columns["HDPEFlang"].Visible = false;
                this.DGVDailyChecks.Columns["HDPEPipe"].Visible = false;
                this.DGVDailyChecks.Columns["ServicePmp78"].Visible = false;
                this.DGVDailyChecks.Columns["ServicePmp98"].Visible = false;
                this.DGVDailyChecks.Columns["VerticalPmp03"].Visible = false;
                this.DGVDailyChecks.Columns["VerticalPmp04"].Visible = false;
                this.DGVDailyChecks.Columns["SilicaPmp"].Visible = false;

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetShift()
        {
            if (chkBtn1.Checked == true && chkBtn2.Checked == false && chkBtn3.Checked == false)
            {
                shiftName = "Shift A";
            }
            if (chkBtn2.Checked == true && chkBtn1.Checked == false && chkBtn3.Checked == false)
            {
                shiftName = "Shift B";
            }
            if (chkBtn3.Checked == true && chkBtn1.Checked == false && chkBtn2.Checked == false)
            {
                shiftName = "Shift C";
            }
            if (chkBtn1.Checked == true && chkBtn2.Checked == true && chkBtn3.Checked == false)
            {
                shiftName = "Shift AB";
            }
            if (chkBtn1.Checked == true && chkBtn2.Checked == false && chkBtn3.Checked == true)
            {
                shiftName = "Shift AC";
            }
            if (chkBtn1.Checked == false && chkBtn2.Checked == true && chkBtn3.Checked == true)
            {
                shiftName = "Shift AB";
            }
            if (chkBtn1.Checked == true && chkBtn2.Checked == true && chkBtn3.Checked == true)
            {
                shiftName = "Shift ABC";
            }
        }

        private void dtpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                isDTPSearch = true;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpDateTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                isDTPSearch = true;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rdbShiftB_CheckedChanged(object sender, EventArgs e)
        {
            ShiftRadioCheck();
        }

        private void rdbShiftC_CheckedChanged(object sender, EventArgs e)
        {
            ShiftRadioCheck();
        }

        private void DGVDailyChecks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    IncId = this.DGVDailyChecks.Rows[e.RowIndex].Cells["IncId"].Value.ToString();
                    Guid InciId = Guid.Empty;
                    InciId = Guid.Parse(IncId);
                   // ModelDailyCehcks = null;
                    DTView = ModelDailyCehcks.GetShiftChecks("", dtpDateFrom.Value, dtpDateTo.Value, 4, InciId);
                    ReBIndViewControls();
                    ((Control)this.ObserverTab).Enabled = false;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReBIndViewControls()
        {
            try
            {
                ModelDailyCehcks.GranulationDrum = Convert.ToInt32(DTView.Rows[0]["GranulationDrum"]);
                ModelDailyCehcks.DryerDrum = Convert.ToInt32(DTView.Rows[0]["DryerDrum"]);
                ModelDailyCehcks.CoolerDrum = Convert.ToInt32(DTView.Rows[0]["CoolerDrum"]);
                ModelDailyCehcks.GearthGear = Convert.ToInt32(DTView.Rows[0]["GearthGear"]);
                ModelDailyCehcks.FeedingBelt01GB = Convert.ToInt32(DTView.Rows[0]["FeedingBelt01GB"]);
                ModelDailyCehcks.BoronBeltGB = Convert.ToInt32(DTView.Rows[0]["BoronBeltGB"]);
                ModelDailyCehcks.RMBeltGB = Convert.ToInt32(DTView.Rows[0]["RMBeltGB"]);
                ModelDailyCehcks.RMElevatorGearBox = Convert.ToInt32(DTView.Rows[0]["RMElevatorGearBox"]);
                ModelDailyCehcks.GranulationDrumGB = Convert.ToInt32(DTView.Rows[0]["GranulationDrumGB"]);
                ModelDailyCehcks.DryerDrumGB = Convert.ToInt32(DTView.Rows[0]["DryerDrumGB"]);
                ModelDailyCehcks.DCBeltGB = Convert.ToInt32(DTView.Rows[0]["DCBeltGB"]);
                ModelDailyCehcks.CoolerDrumGB = Convert.ToInt32(DTView.Rows[0]["CoolerDrumGB"]);
                ModelDailyCehcks.CMBeltGB = Convert.ToInt32(DTView.Rows[0]["CMBeltGB"]);
                ModelDailyCehcks.CMElevatorGB = Convert.ToInt32(DTView.Rows[0]["CMElevatorGB"]);
                ModelDailyCehcks.RecycleBeltGB = Convert.ToInt32(DTView.Rows[0]["RecycleBeltGB"]);
                ModelDailyCehcks.ProductionBeltGB = Convert.ToInt32(DTView.Rows[0]["ProductionBeltGB"]);
                ModelDailyCehcks.PackingBeltGB = Convert.ToInt32(DTView.Rows[0]["PackingBeltGB"]);
                ModelDailyCehcks.FeedingBelt01GBSSp = Convert.ToInt32(DTView.Rows[0]["FeedingBelt01GBSSp"]);
                ModelDailyCehcks.ZNBeltGB = Convert.ToInt32(DTView.Rows[0]["ZNBeltGB"]);
                ModelDailyCehcks.ZNElevatorGB = Convert.ToInt32(DTView.Rows[0]["ZNElevatorGB"]);
                ModelDailyCehcks.BottomScrewConveyor = Convert.ToInt32(DTView.Rows[0]["BottomScrewConveyor"]);
                ModelDailyCehcks.GRElevatorGearBox = Convert.ToInt32(DTView.Rows[0]["GRElevatorGearBox"]);
                ModelDailyCehcks.TopScrewConveyor = Convert.ToInt32(DTView.Rows[0]["TopScrewConveyor"]);
                ModelDailyCehcks.MixerGearBox = Convert.ToInt32(DTView.Rows[0]["MixerGearBox"]);
                ModelDailyCehcks.DanGearBox = Convert.ToInt32(DTView.Rows[0]["DanGearBox"]);
                ModelDailyCehcks.DozzerGearBox = Convert.ToInt32(DTView.Rows[0]["DozzerGearBox"]);
                ModelDailyCehcks.DanChain = Convert.ToInt32(DTView.Rows[0]["DanChain"]);
                ModelDailyCehcks.FloatingShaft = Convert.ToInt32(DTView.Rows[0]["FloatingShaft"]);
                ModelDailyCehcks.CouplingNut = Convert.ToInt32(DTView.Rows[0]["CouplingNut"]);
                ModelDailyCehcks.Rope = Convert.ToInt32(DTView.Rows[0]["Rope"]);
                ModelDailyCehcks.Miscallaneous = Convert.ToInt32(DTView.Rows[0]["Miscallaneous"]);
                ModelDailyCehcks.FeedingBelt01GBPssp = Convert.ToInt32(DTView.Rows[0]["FeedingBelt01GBPssp"]);
                ModelDailyCehcks.FeedingBelt02GBPssp = Convert.ToInt32(DTView.Rows[0]["FeedingBelt02GBPssp"]);
                ModelDailyCehcks.ScreberFan = Convert.ToInt32(DTView.Rows[0]["ScreberFan"]);
                ModelDailyCehcks.BallMillIDFan = Convert.ToInt32(DTView.Rows[0]["BallMillIDFan"]);
                ModelDailyCehcks.Mounting = Convert.ToInt32(DTView.Rows[0]["Mounting"]);
                ModelDailyCehcks.HDPEFlang = Convert.ToInt32(DTView.Rows[0]["HDPEFlang"]);
                ModelDailyCehcks.HDPEPipe = Convert.ToInt32(DTView.Rows[0]["HDPEPipe"]);
                ModelDailyCehcks.ServicePmp78 = Convert.ToInt32(DTView.Rows[0]["ServicePmp78"]);
                ModelDailyCehcks.ServicePmp98 = Convert.ToInt32(DTView.Rows[0]["ServicePmp98"]);
                ModelDailyCehcks.VerticalPmp03 = Convert.ToInt32(DTView.Rows[0]["VerticalPmp03"]);
                ModelDailyCehcks.VerticalPmp04 = Convert.ToInt32(DTView.Rows[0]["VerticalPmp04"]);
                ModelDailyCehcks.SilicaPmp = Convert.ToInt32(DTView.Rows[0]["SilicaPmp"]);
                ModelDailyCehcks.ShiftName = DTView.Rows[0]["ShiftName"].ToString();
                CheckBoxRecheck();
                DailyGnrlCheckPages.Enabled = true;
                DailyGnrlCheckPages.SelectedIndex = 0;
                btnSaveClose.Enabled = false;
                btnSaveClose.Enabled = true;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void UncheckBox()
        {
            rdbShiftA.Checked = false;
            rdbShiftB.Checked = false;
            rdbShiftC.Checked = false;
            chkCompGDrum.Checked = false;
            chkCompDryDrum.Checked = false;
            chkCompCoolDrum.Checked = false;
            chkGreeEathGear.Checked = false;
            chkGSSPFeeBelt01.Checked = false;
            chkGSSPBoronBelt.Checked = false;
            chkGSSPRMBelt.Checked = false;
            chkGSSPRmElGBox.Checked = false;
            chkGSSPGrenuDrmGB.Checked = false;
            chkGSSPDryDRumGB.Checked = false;
            chkGSSPDCBeltGB.Checked = false;
            chkGSSPCoolDrmGB.Checked = false;
            chkGSSPCMBeltGB.Checked = false;
            chkGSSPCMEleGB.Checked = false;
            chkGSSPRecyclBelGB.Checked = false;
            chkGSSPPrdBeltGB.Checked = false;
            chkGSSPPackBeltGB.Checked = false;
            chkOSSPFeedBltGB.Checked = false;
            chkOSSPZNBeltGB.Checked = false;
            chkOSSPZNElvtGB.Checked = false;
            chkOSSPBottomScrCon.Checked = false;
            chkOSSPGRElvtGB.Checked = false;
            chkOSSPTopScrCon.Checked = false;
            chkOSSPMixGB.Checked = false;
            chkOSSPDANGB.Checked = false;
            chkOSSPDozzerGB.Checked = false;
            chkOSSPDANChain.Checked = false;
            chkCraneFloaShaft.Checked = false;
            chkCraneCoupNut.Checked = false;
            chkCraneRope.Checked = false;
            chkCraneMissc.Checked = false;
            chkOPSSPBelt01GB.Checked = false;
            chkOPSSPB02GB.Checked = false;
            chkVibrScrFan.Checked = false;
            chkVibrBMillFan.Checked = false;
            chkLeakMount.Checked = false;
            chkLeakHDflang.Checked = false;
            chkLeakHDPipe.Checked = false;
            chkLeakPmp78.Checked = false;
            chkLeakpmp98.Checked = false;
            chkLeakvpmp03.Checked = false;
            chkLeakvpmp04.Checked = false;
            chkLeakSilpmp.Checked = false;

        }
        private void CheckBoxRecheck()
        {
            try
            {
                UncheckBox();
                if (ModelDailyCehcks.ShiftName == rdbShiftA.Text)
                {
                    rdbShiftA.Checked = true;
                }
                if (ModelDailyCehcks.ShiftName == rdbShiftB.Text)
                {
                    rdbShiftB.Checked = true;
                }
                if (ModelDailyCehcks.ShiftName == rdbShiftC.Text)
                {
                    rdbShiftC.Checked = true;
                }

                if (ModelDailyCehcks.GranulationDrum == 1)
                {
                    chkCompGDrum.Checked = true; 
                }
                else
                {
                    chkCompGDrum.Checked = false;
                }
                if (ModelDailyCehcks.DryerDrum == 1)
                {
                    chkCompDryDrum.Checked = true;
                }
                else
                {
                    chkCompDryDrum.Checked = false;
                }
                if (ModelDailyCehcks.CoolerDrum == 1)
                {
                    chkCompCoolDrum.Checked = true;
                }
                else
                {
                    chkCompCoolDrum.Checked = false;
                }

                if (ModelDailyCehcks.GearthGear == 1)
                {
                    chkGreeEathGear.Checked = true;
                }
                else
                {
                    chkGreeEathGear.Checked = false;
                }

                if (ModelDailyCehcks.FeedingBelt01GB == 1)
                {
                    chkGSSPFeeBelt01.Checked = true;
                }
                else
                {
                    chkGSSPFeeBelt01.Checked = false;
                }

                if (ModelDailyCehcks.BoronBeltGB == 1)
                {
                    chkGSSPBoronBelt.Checked = true;
                }
                else
                {
                    chkGSSPBoronBelt.Checked = false;
                }

                if (ModelDailyCehcks.RMBeltGB == 1)
                {
                    chkGSSPRMBelt.Checked = true;
                }
                else
                {
                    chkGSSPRMBelt.Checked = false;
                }

                if (ModelDailyCehcks.RMElevatorGearBox == 1)
                {
                    chkGSSPRmElGBox.Checked = true;
                }
                else
                {
                    chkGSSPRmElGBox.Checked = false;
                }

                if (ModelDailyCehcks.GranulationDrumGB == 1)
                {
                    chkGSSPGrenuDrmGB.Checked = true;
                }
                else
                {
                    chkGSSPGrenuDrmGB.Checked = false;
                }

                if (ModelDailyCehcks.DryerDrumGB == 1)
                {
                    chkGSSPDryDRumGB.Checked = true;
                }
                else
                {
                    chkGSSPDryDRumGB.Checked = false;
                }

                if (ModelDailyCehcks.DCBeltGB == 1)
                {
                    chkGSSPDCBeltGB.Checked = true;
                }
                else
                {
                    chkGSSPDCBeltGB.Checked = false;
                }

                if (ModelDailyCehcks.CoolerDrumGB == 1)
                {
                    chkGSSPCoolDrmGB.Checked = true;
                }

                else
                {
                    chkGSSPCoolDrmGB.Checked = false;
                }
                if (ModelDailyCehcks.CMBeltGB == 1)
                {
                    chkGSSPCMBeltGB.Checked = true;
                }
                else
                {
                    chkGSSPCMBeltGB.Checked = false;
                }

                if (ModelDailyCehcks.CMElevatorGB == 1)
                {
                    chkGSSPCMEleGB.Checked = true;
                }
                else
                {
                    chkGSSPCMEleGB.Checked = false;
                }

                if (ModelDailyCehcks.RecycleBeltGB == 1)
                {
                    chkGSSPRecyclBelGB.Checked = true;
                }
                else
                {
                    chkGSSPRecyclBelGB.Checked = false;
                }

                if (ModelDailyCehcks.ProductionBeltGB == 1)
                {
                    chkGSSPPrdBeltGB.Checked = true;
                }
                else
                {
                    chkGSSPPrdBeltGB.Checked = false;
                }

                if (ModelDailyCehcks.PackingBeltGB == 1)
                {
                    chkGSSPPackBeltGB.Checked = true;
                }
                else
                {
                    chkGSSPPackBeltGB.Checked = false;
                }


                if (ModelDailyCehcks.FeedingBelt01GB == 1)
                {
                    chkOSSPFeedBltGB.Checked = true;
                }
                else
                {
                    chkOSSPFeedBltGB.Checked = false;
                }

                if (ModelDailyCehcks.ZNBeltGB == 1)
                {
                    chkOSSPZNBeltGB.Checked = true;
                }
                else
                {
                    chkOSSPZNBeltGB.Checked = false;
                }
                if (ModelDailyCehcks.ZNElevatorGB == 1)
                {
                    chkOSSPZNElvtGB.Checked = true;
                }
                else
                {
                    chkOSSPZNElvtGB.Checked = false;
                }

                if (ModelDailyCehcks.BottomScrewConveyor == 1)
                {
                    chkOSSPBottomScrCon.Checked = true;
                }
                else
                {
                    chkOSSPBottomScrCon.Checked = false;
                }

                if (ModelDailyCehcks.GRElevatorGearBox == 1)
                {
                    chkOSSPGRElvtGB.Checked = true;
                }
                else
                {
                    chkOSSPGRElvtGB.Checked = false;
                }

                if (ModelDailyCehcks.TopScrewConveyor == 1)
                {
                    chkOSSPTopScrCon.Checked = true;
                }
                else
                {
                    chkOSSPTopScrCon.Checked = false;
                }

                if (ModelDailyCehcks.MixerGearBox == 1)
                {
                    chkOSSPMixGB.Checked = true;
                }
                else
                {
                    chkOSSPMixGB.Checked = false;
                }

                if (ModelDailyCehcks.DanGearBox == 1)
                {
                    chkOSSPDANGB.Checked = true;
                }
                else
                {
                    chkOSSPDANGB.Checked = false;
                }

                if (ModelDailyCehcks.DozzerGearBox == 1)
                {
                    chkOSSPDozzerGB.Checked = true;
                }
                else
                {
                    chkOSSPDozzerGB.Checked = false;
                }

                if (ModelDailyCehcks.DanChain == 1)
                {
                    chkOSSPDANChain.Checked = true;
                }
                else
                {
                    chkOSSPDANChain.Checked = false;
                }

                if (ModelDailyCehcks.FloatingShaft == 1)
                {
                    chkCraneFloaShaft.Checked = true;
                }
                else
                {
                    chkCraneFloaShaft.Checked = false;
                }
                if (ModelDailyCehcks.CouplingNut == 1)
                {
                    chkCraneCoupNut.Checked = true;
                }
                else
                {
                    chkCraneCoupNut.Checked = false;
                }
                if (ModelDailyCehcks.Rope == 1)
                {
                    chkCraneRope.Checked = true;
                }
                else
                {
                    chkCraneRope.Checked = false;
                }
                if (ModelDailyCehcks.Miscallaneous == 1)
                {
                    chkCraneMissc.Checked = true;
                }
                else
                {
                    chkCraneMissc.Checked = false;
                }

                if (ModelDailyCehcks.FeedingBelt01GBPssp == 1)
                {
                    chkOPSSPBelt01GB.Checked = true;
                }
                else
                {
                    chkOPSSPBelt01GB.Checked = false;
                }

                if (ModelDailyCehcks.FeedingBelt02GBPssp == 1)
                {
                    chkOPSSPB02GB.Checked = true;
                }
                else
                {
                    chkOPSSPB02GB.Checked = false;
                }
                if (ModelDailyCehcks.ScreberFan == 1)
                {
                    chkVibrScrFan.Checked = true;
                }
                else
                {
                    chkVibrScrFan.Checked = false;
                }
                if (ModelDailyCehcks.BallMillIDFan == 1)
                {
                    chkVibrBMillFan.Checked = true;
                }
                else
                {
                    chkVibrBMillFan.Checked = false;
                }

                if (ModelDailyCehcks.Mounting == 1)
                {
                    chkLeakMount.Checked = true;
                }
                else
                {
                    chkLeakMount.Checked = false;
                }

                if (ModelDailyCehcks.HDPEFlang == 1)
                {
                    chkLeakHDflang.Checked = true;
                }
                else
                {
                    chkLeakHDflang.Checked = false;
                }

                if (ModelDailyCehcks.HDPEPipe == 1)
                {
                    chkLeakHDPipe.Checked = true;
                }
                else
                {
                    chkLeakHDPipe.Checked = false;
                }

                if (ModelDailyCehcks.ServicePmp78 == 1)
                {
                    chkLeakPmp78.Checked = true;
                }
                else
                {
                    chkLeakPmp78.Checked = false;
                }

                if (ModelDailyCehcks.ServicePmp98 == 1)
                {
                    chkLeakpmp98.Checked = true;
                }
                else
                {
                    chkLeakpmp98.Checked = false;
                }
                if (ModelDailyCehcks.VerticalPmp03 == 1)
                {
                    chkLeakvpmp03.Checked = true;
                }
                else
                {
                    chkLeakvpmp03.Checked = false;
                }

                if (ModelDailyCehcks.VerticalPmp04 == 1)
                {
                    chkLeakvpmp04.Checked = true;
                }
                else
                {
                    chkLeakvpmp04.Checked = false;
                }

                if (ModelDailyCehcks.SilicaPmp == 1)
                {
                    chkLeakSilpmp.Checked = true;
                }
                else
                {
                    chkLeakSilpmp.Checked = false;
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetCheckBoxs()
        {
            try
            {
                    rdbShiftA.Checked = false;
                    rdbShiftB.Checked = false;
                    rdbShiftC.Checked = false;
                    chkCompGDrum.CheckState = CheckState.Unchecked;
                    chkCompDryDrum.Checked = false;
                    chkCompCoolDrum.Checked = false;            
                    chkGreeEathGear.Checked = false;
                    chkGSSPFeeBelt01.Checked = false;
                    chkGSSPBoronBelt.Checked = false;
                    chkGSSPRMBelt.Checked = false;
                    chkGSSPRmElGBox.Checked = false;
                    chkGSSPGrenuDrmGB.Checked = false;
                    chkGSSPDryDRumGB.Checked = false;
                    chkGSSPDCBeltGB.Checked = false;
                    chkGSSPCoolDrmGB.Checked = false;
                    chkGSSPCMBeltGB.Checked = false;
                    chkGSSPCMEleGB.Checked = false;
                    chkGSSPRecyclBelGB.Checked = false;
                    chkGSSPPrdBeltGB.Checked = false;
                    chkGSSPPackBeltGB.Checked = false;
                    chkOSSPFeedBltGB.Checked = false;
                    chkOSSPZNBeltGB.Checked = false;
                    chkOSSPZNElvtGB.Checked = false;
                    chkOSSPBottomScrCon.Checked = false;
                    chkOSSPGRElvtGB.Checked = false;
                    chkOSSPTopScrCon.Checked = false;
                    chkOSSPMixGB.Checked = false;
                     chkOSSPDANGB.Checked = false;
                    chkOSSPDozzerGB.Checked = false;
                    chkOSSPDANChain.Checked = false;
                    chkCraneFloaShaft.Checked = false;
                    chkCraneCoupNut.Checked = false;
                    chkCraneRope.Checked = false;
                    chkCraneMissc.Checked = false;
                    chkOPSSPBelt01GB.Checked = false;
                    chkOPSSPB02GB.Checked = false;
                     chkVibrScrFan.Checked = false;
                    chkVibrBMillFan.Checked = false;
                    chkLeakMount.Checked = false;
                    chkLeakHDflang.Checked = false;
                    chkLeakHDPipe.Checked = false;
                    chkLeakPmp78.Checked = false;
                    chkLeakpmp98.Checked = false;
                    chkLeakvpmp03.Checked = false;
                    chkLeakvpmp04.Checked = false;
                    chkLeakSilpmp.Checked = false;
               

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CopyGridData()
        {
            try
            {
                DGVDailyChecks.Columns[0].Visible = false;
                DGVDailyChecks.SelectAll();
                DataObject dataObj = DGVDailyChecks.GetClipboardContent();
                if (dataObj != null)
                    Clipboard.SetDataObject(dataObj);
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportDailyGnrlCheckExcel(DGVDailyChecks, "Daily General Check");
                //CopyGridData();
                //Microsoft.Office.Interop.Excel.Application xlexcel;
                //Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                //Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                //object misValue = System.Reflection.Missing.Value;
                //xlexcel = new Microsoft.Office.Interop.Excel.Application();
                //xlexcel.Visible = true;
                //xlWorkBook = xlexcel.Workbooks.Add(misValue);
                //xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                //Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[2, 1];
                //CR.Select();
                //xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                //DGVDailyChecks.Columns[0].Visible = true;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                ResetCheckBoxes();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetCheckBoxes()
        {
            rdbShiftA.Checked = false;
            rdbShiftB.Checked = false;
            rdbShiftC.Checked = false;
            chkCompCoolDrum.Checked = false;
            chkCompDryDrum.Checked = false;
            chkCompGDrum.Checked = false;
            chkCraneCoupNut.Checked = false;
            chkCraneFloaShaft.Checked = false;
            chkCraneMissc.Checked = false;
            chkCraneRope.Checked = false;
            chkGreeEathGear.Checked = false;
            chkGSSPBoronBelt.Checked = false;
            chkGSSPCMBeltGB.Checked = false;
            chkGSSPCMEleGB.Checked = false;
            chkGSSPCoolDrmGB.Checked = false;
            chkGSSPDCBeltGB.Checked = false;
            chkGSSPDryDRumGB.Checked = false;
            chkGSSPFeeBelt01.Checked = false;
            chkGSSPGrenuDrmGB.Checked = false;
            chkGSSPPackBeltGB.Checked = false;
            chkGSSPPrdBeltGB.Checked = false;
            chkGSSPRecyclBelGB.Checked = false;
            chkGSSPRMBelt.Checked = false;
            chkGSSPRmElGBox.Checked = false;
            chkLeakHDflang.Checked = false;
            chkLeakHDPipe.Checked = false;
            chkLeakMount.Checked = false;
            chkLeakPmp78.Checked = false;
            chkLeakpmp98.Checked = false;
            chkLeakSilpmp.Checked = false;
            chkLeakvpmp03.Checked = false;
            chkLeakvpmp04.Checked = false;
            chkOPSSPB02GB.Checked = false;
            chkOPSSPBelt01GB.Checked = false;
            chkOSSPBottomScrCon.Checked = false;
            chkOSSPDANChain.Checked = false;
            chkOSSPDANGB.Checked = false;
            chkOSSPDozzerGB.Checked = false;
            chkOSSPFeedBltGB.Checked = false;
            chkOSSPGRElvtGB.Checked = false;
            chkOSSPMixGB.Checked = false;
            chkOSSPTopScrCon.Checked = false;
            chkOSSPZNBeltGB.Checked = false;
            chkOSSPZNElvtGB.Checked = false;
            chkVibrBMillFan.Checked = false;
            chkVibrScrFan.Checked = false;
            lblShiftFrom.Text = "";
            lblShiftTo.Text = "";
        }
        private iTextSharp.text.Font fontTinyItalic = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL, BaseColor.GRAY);
        private iTextSharp.text.Font fontTiny = FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL, BaseColor.GRAY);

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            try
            {
                DownloadInPdf(DGVDailyChecks);
            //    using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF files|*.pdf" })
            //    {
            //        if (sfd.ShowDialog() == DialogResult.OK)
            //        {
            //            Document doc = new Document(iTextSharp.text.PageSize.A4, 113, 180, 35, 25);
            //            PdfWriter pdfWriter = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
            //            doc.Open();
            //            PdfContentByte pdfContent = pdfWriter.DirectContent;
            //            iTextSharp.text.Rectangle rectangle = new iTextSharp.text.Rectangle(doc.PageSize);
            //            //customized border sizes
            //            //rectangle.Left += doc.LeftMargin + 5;
            //            //rectangle.Right += doc.RightMargin + 5;
            //            //rectangle.Top += doc.TopMargin + 5;
            //            //rectangle.Bottom += doc.BottomMargin + 5;

                //            pdfContent.SetColorStroke(BaseColor.WHITE);//setting the color of the border to white
                //            //pdfContent.Rectangle(rectangle.Left, rectangle.Bottom, rectangle.Width, rectangle.Height);
                //            pdfContent.Stroke();
                //            //setting font type, font size and font color
                //            iTextSharp.text.Font headerFont = iTextSharp.text.FontFactory.GetFont(FontFactory.TIMES_ROMAN, 16, BaseColor.LIGHT_GRAY);
                //            Paragraph p = new Paragraph();
                //            p.Alignment = Element.ALIGN_CENTER;//adjust the alignment of the heading
                //            p.Add(new Chunk("Daily Shift Checks", headerFont));//adding a heading to the PDF
                //            doc.Add(p);//adding component to the document
                //            iTextSharp.text.Font font = iTextSharp.text.FontFactory.GetFont(FontFactory.TIMES_ROMAN, 7, BaseColor.WHITE);
                //            //creating pdf table
                //            PdfPTable table = new PdfPTable(shiftData.Columns.Count);
                //            for (int j = 0; j < shiftData.Columns.Count; j++)
                //            {
                //                PdfPCell cell = new PdfPCell(); //create object from the pdfpcell
                //                cell.BackgroundColor = BaseColor.LIGHT_GRAY;//set color of cells
                //                cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED_ALL;
                //                cell.AddElement(new Chunk(shiftData.Columns[j].ToString().ToUpper(), fontTinyItalic));
                //                table.AddCell(cell);
                //                // table.Rows[j].
                //            }
                //            //adding rows from gridview to table
                //            for (int i = 0; i < shiftData.Rows.Count; i++)
                //            {
                //                table.WidthPercentage = 225;//set width of the table
                //                                            //  table.DefaultCell.BackgroundColor = BaseColor.YELLOW;

                //                for (int j = 0; j < shiftData.Columns.Count; j++)
                //                {
                //                    if (shiftData.Rows[i][j] != null)
                //                        table.AddCell(new Phrase(shiftData.Rows[i][j].ToString(), fontTiny));
                //                }
                //            }
                //            //adding table to document
                //            doc.Add(table);
                //            doc.Close();
                //            MessageBox.Show("You have successfully exported the file.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        }
                //    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbViewShiftA_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbShiftA.Checked)
                {
                    rdbShiftA.Checked = true;
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkBtn1.Checked == true)
                {
                    chkBtn1.Checked = false;
                }
                if (chkBtn2.Checked == true)
                {
                    chkBtn2.Checked = false;
                }
                if (chkBtn3.Checked == true)
                {
                    chkBtn3.Checked = false;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbViewShiftB_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbShiftB.Checked == true)
                {
                    rdbShiftB.Checked = true;
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbViewShiftC_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbShiftC.Checked == true)
                {
                    rdbShiftC.Checked = true;
                }

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbViewShiftA_Click(object sender, EventArgs e)
        {
            try
            {
                rdbShiftA.Checked = true;

            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbViewShiftB_Click(object sender, EventArgs e)
        {
            try
            {
                rdbShiftB.Checked = true;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbViewShiftC_Click(object sender, EventArgs e)
        {
            try
            {
                rdbShiftC.Checked = true;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HideJSAInputPagesHeader()
        {
            DailyGnrlCheckPages.Appearance = TabAppearance.FlatButtons;
            DailyGnrlCheckPages.ItemSize = new Size(0, 1);
            DailyGnrlCheckPages.SizeMode = TabSizeMode.Fixed;

            foreach (TabPage tab in DailyGnrlCheckPages.TabPages)
            {
                tab.Hide();// = "";
            }
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            DailyGnrlCheckPages.SelectedIndex = 0;
            ResetCheckBoxs();
            gbxSafetyComponets.Enabled = true;
            pnlShifSelect.Enabled = true;
            pnlTimeRange.Enabled = true;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DailyGnrlCheckPages.SelectedIndex = 1;
        }

        private void DGVDailyChecks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    IncId = this.DGVDailyChecks.Rows[e.RowIndex].Cells["IncId"].Value.ToString();
                    Guid InciId = Guid.Empty;
                    InciId = Guid.Parse(IncId);
                    DTView = ModelDailyCehcks.GetShiftChecks("", dtpDateFrom.Value, dtpDateTo.Value, 4, InciId);
                    ReBIndViewControls();
                    ////((Control)this.ObserverTab).Enabled = false;
                    gbxSafetyComponets.Enabled = false;
                    pnlShifSelect.Enabled = false;
                    pnlTimeRange.Enabled = false;
                }
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            private void ExportDailyGnrlCheckExcel(DataGridView dgv, string fileName)
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = dgv.DataSource as DataTable;
                    //Exporting to Excel
                    if (dt.Rows.Count > 0)
                    {
                        string folderPath = "C:\\Excel\\";
                        SaveFileDialog directchoosedlg = new SaveFileDialog();
                        directchoosedlg.FileName = fileName;

                        if (directchoosedlg.ShowDialog() == DialogResult.OK)
                        {
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                wb.Worksheets.Add(dt, "Sheet1");
                                string fPath = directchoosedlg.FileName + ".xlsx"; //folderPath + "\\" + fileName + ".xlsx";
                                if (File.Exists(fPath))
                                {
                                    DialogResult dgres = XtraMessageBox.Show("File already exists! Are you want to replace?", "Alert", MessageBoxButtons.YesNo);
                                    if (dgres == DialogResult.Yes)
                                    {
                                        wb.SaveAs(fPath);
                                        XtraMessageBox.Show("Report Downloaded Successfully.");
                                    }
                                    else
                                        return;
                                }
                                else
                                {
                                    wb.SaveAs(fPath);
                                    XtraMessageBox.Show("Report Downloaded Successfully.");
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

        private void DownloadInPdf(DataGridView dgv)
        {
            if (dgv.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Daily Safety Check.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dgv.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dgv.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dgv.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pdfTable.AddCell(cell.Value.ToString());
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }
    }
  }
    



