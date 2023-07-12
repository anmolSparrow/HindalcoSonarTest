using RMPCLApp.DAL;
using System;
using System.Data;

namespace RMPCLApp.Operation.BusinessClasses
{
    public class MonthlyProduction
    {
        public int NoWorkDays { get; set; }
        public string DaysWorked { get; set; }
        public string PlantName { get; set; }
        public decimal MonthlyTarget { get; set; }
        public decimal DailyTarget { get; set; }
        public decimal ClosingStock { get; set; }
        public string MonthlyTargetUnit { get; set; }
        public string DailyTargetUnit { get; set; }
        public string ClosingStockUnit { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public int RoleId { get; set; }
        public string TargetCode { get; set; }
        public string TargetMonth { get; set; }
        public int TargetYear { get; set; }
        public string ProdCode { get; set; }
        public DataTable LoadItem { set; get; }
        public ServiceDAL DalService { get; set; }

        public int SetMonthlyProduction(MonthlyProduction MonthProduction, int mode)
        {
            int retVal = 0;
            try
            {
                DalService = new ServiceDAL();
                retVal = DalService.AddMonthlyProduction(MonthProduction, mode);
            }
            catch (Exception Ex)
            {
            }
            return retVal;
        }

    }
}
