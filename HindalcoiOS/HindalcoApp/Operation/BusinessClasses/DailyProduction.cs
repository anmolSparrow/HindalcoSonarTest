using HindalcoiOS.DAL;
using System;
using System.Data;

namespace HindalcoiOS.Operation.BusinessClasses
{
    public class DailyProduction
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


        public int SetDailyProduction(DailyProduction MonthProduction, int mode)
        {
            int retVal = 0;
            try
            {
                DalService = new ServiceDAL();
                retVal = DalService.AddDailyProductionDetails(MonthProduction, mode);
            }
            catch (Exception Ex)
            {
            }
            return retVal;
        }

        public int DropDailyProductionTempData(DateTime DateFilledFrom,string PlantName)
        {
            int retVal = 0;
            try
            {
                DalService = new ServiceDAL();
                retVal = DalService.DropDailyProdTempData(DateFilledFrom, PlantName);
            }
            catch (Exception Ex)
            {
            }
            return retVal;
        }

        public int DropDailyGridProductionTempData(string ProdCode, string PlantName)
        {
            int retVal = 0;
            try
            {
                DalService = new ServiceDAL();
                retVal = DalService.DropDailyGridProductionTempData(ProdCode, PlantName);
            }
            catch (Exception Ex)
            {
            }
            return retVal;
        }

        public int DropDailyProductionData(string DProdCode)
        {
            int retVal = 0;
            try
            {
                DalService = new ServiceDAL();
                retVal = DalService.DropDailyProductionData(DProdCode);
            }
            catch (Exception Ex)
            {
            }
            return retVal;
        }

    }
}
