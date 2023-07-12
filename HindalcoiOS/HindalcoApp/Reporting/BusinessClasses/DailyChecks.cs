using HindalcoiOS.DAL;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.Reporting
{
   public  class DailyChecks
    {
        public string ShiftName { get; set; }
        public DateTime EntryDate { get; set; }
        public int GranulationDrum { get; set; }
        public int DryerDrum { get; set; }
        public int CoolerDrum { get; set; }
        public int GearthGear { get; set; }
        public int FeedingBelt01GB { get; set; }
        public int BoronBeltGB { get; set; }
        public int RMBeltGB { get; set; }
        public int RMElevatorGearBox { get; set; }
        public int GranulationDrumGB { get; set; }
        public int DryerDrumGB { get; set; }
        public int DCBeltGB { get; set; }
        public int CoolerDrumGB { get; set; }
        public int CMBeltGB { get; set; }
        public int CMElevatorGB { get; set; }
        public int RecycleBeltGB { get; set; }
        public int ProductionBeltGB { get; set; }
        public int PackingBeltGB { get; set; }
        public int FeedingBelt01GBSSp { get; set; }
        public int ZNBeltGB { get; set; }
        public int ZNElevatorGB { get; set; }
        public int BottomScrewConveyor { get; set; }
        public int GRElevatorGearBox { get; set; }
        public int TopScrewConveyor { get; set; }
        public int MixerGearBox { get; set; }
        public int DanGearBox { get; set; }
        public int DozzerGearBox { get; set; }
        public int DanChain { get; set; }
        public int FloatingShaft { get; set; }
        public int CouplingNut { get; set; }
        public int Rope { get; set; }
        public int Miscallaneous { get; set; }
        public int FeedingBelt01GBPssp { get; set; }
        public int FeedingBelt02GBPssp { get; set; }
        public int ScreberFan { get; set; }
        public int BallMillIDFan { get; set; }
        public int Mounting { get; set; }
        public int HDPEFlang { get; set; }
        public int HDPEPipe { get; set; }
        public int ServicePmp78 { get; set; }
        public int ServicePmp98 { get; set; }
        public int VerticalPmp03 { get; set; }
        public int VerticalPmp04 { get; set; }
        public int SilicaPmp { get; set; }


        public DataTable LoadItem { set; get; }
        public ServiceDAL DalService { get; set; }
        public DataTable GetShiftChecks(string shiftName, DateTime EntryDate,DateTime EntryDate1, int mode,Guid  IncId)
        {
            DataTable dt = null;
            DalService = new ServiceDAL();
            try
            {
                dt = new DataTable();
                dt = DalService.GetShiftData(shiftName, EntryDate, EntryDate1, mode, IncId);
            }
            catch (Exception Ex)
            {

            }
            return dt;
        }
        public int SetShiftDetails(Reporting.DailyChecks dailyChecks, int mode)
        {
            int retVal = 0;
            DalService = new ServiceDAL();
            try
            {
                DalService = new ServiceDAL();
                retVal = DalService.AddDailyChecks(dailyChecks, mode);
            }
            catch (Exception Ex)
            {
            }
            return retVal;
        }
    }
}
