using HindalcoiOS.DAL;
using System;
using System.Data;
using SparrowRMS;

namespace HindalcoiOS.Operation.BusinessClasses
{
    public class DailyProductionTmpTbl
    {
        public string DProdCode { get; set; }
        public string PlantName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DateFilledFor { get; set; }
        public string ProdName { get; set; }
        public string ProdCode { get; set; }
        public decimal OpeningStock { get; set; }
        public decimal DailyTarget { get; set; }
        public decimal ActualProd { get; set; }
        public decimal ProdDispatched { get; set; }
        public decimal ClosingStock { get; set; }
        public string EmpCode { get; set; }
        public int RoleId { get; set; }
        public DateTime UpdateDate { get; set; }
        public string ActualProdUnit { get; set; }
        public string PrdoDispatchedUnit { get; set; }
        public DataTable LoadItem { set; get; }
        public ServiceDAL DalService { get; set; }


        public int SetDailyProduction(DailyProductionTmpTbl MonthProduction, int mode)
        {
            int retVal = 0;
            try
            {
                DalService = new ServiceDAL();
                retVal = DalService.AddDailyProductionTmpTbl(MonthProduction, mode);
            }
            catch (Exception Ex)
            {
            }
            return retVal;
        }

        public DataTable GetDailyProductionTempTbl(string DProdCode, string PlantName, string ProdName, string ProdCode, decimal OpeningStock, decimal DailyTarget, decimal ActualProd,
            decimal ProdDispatched, decimal ClosingStock, string EmpCode, int RoleId, DateTime CreatedDate, DateTime DateFilledFor, DateTime UpdateDate, string ActualProdUnit, string PrdoDispatchedUnit, int mode)
        {
            DataTable dt = null;
            try
            {
                dt = new DataTable();
                dt = Resources.Instance.GetDailyProductionTempTbl_RMPCL(DProdCode, PlantName, ProdName, ProdCode, OpeningStock, DailyTarget, ActualProd, ProdDispatched, ClosingStock, EmpCode, RoleId, CreatedDate, DateFilledFor, UpdateDate, ActualProdUnit, PrdoDispatchedUnit, mode);
            }
            catch (Exception Ex)
            {

            }
            return dt;
        }

    }
}
