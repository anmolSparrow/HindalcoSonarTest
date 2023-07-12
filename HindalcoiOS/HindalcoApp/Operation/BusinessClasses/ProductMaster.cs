using HindalcoiOS.DAL;
using SparrowRMS;
using System;
using System.Data;

namespace HindalcoiOS.Operation.BusinessClasses
{
    public class ProductMaster
    {
        public string PlantName { get; set; }
        public string ProdCode { get; set; }
        public string ProdName { get; set; }
        public string UniqCode { get; set; }
        public DateTime DateAdded { get; set; }
        public string CreatedBy { get; set; }
        public int RoleId { get; set; }

        public DataTable LoadItem { set; get; }
        public ServiceDAL DalService { get; set; }

        public int IsActive { get; set; }
        public DateTime DeactivatedFrom { get; set; }
        public DateTime DeactivatedTo { get; set; }
        public DataTable GetProductDetails()
        {
            DataTable dt = null;
            try
            {
                dt = new DataTable();
                dt = Resources.Instance.GetProductMaster_RMPCL("", "", "", DateTime.Now, "", "", 0, 2,0,DateTime.Now,DateTime.Now);
            }
            catch (Exception Ex)
            {

            }
            return dt;
        }

        public DataTable GetUnitMaster(string UnitName, int mode)
        {
            DataTable dt = null;
            try
            {
                dt = new DataTable();
                dt = Resources.Instance.GetUnitMaster_RMPCL(UnitName, mode);
            }
            catch (Exception Ex)
            {

            }
            return dt;
        }

        public DataTable GetDailyProductProduced(DateTime dateTime)
        {
            DataTable dt = null;
            try
            {
                dt = new DataTable();
                DalService = new ServiceDAL();
                dt = DalService.GetDailyProductProduced(dateTime);
            }
            catch (Exception Ex)
            {

            }
            return dt;
        }

        public DataTable GetProductDataPlantWise(string PlantName, string ProdCode, string ProdName, DateTime DateAdded, string UniqCode, string CreatedBy, int RoleId, int mode,int IsActive,DateTime DeactivatedFrom,DateTime DeactivatedTo)
        {
            DataTable dt = null;
            try
            {
                dt = new DataTable();
                dt = Resources.Instance.GetProductMaster_RMPCL(PlantName, ProdCode, ProdName, DateAdded, UniqCode, CreatedBy, RoleId, mode,IsActive,DeactivatedFrom,DeactivatedTo);
            }
            catch (Exception Ex)
            {

            }
            return dt;
        }
        public int SetProductDetails(ProductMaster prodMaster, int mode)    
        {
            int retVal = 0;
            try
            {
                DalService = new ServiceDAL();
                retVal = DalService.AddProductMaster(prodMaster, mode);
            }
            catch (Exception Ex)
            {
            }
            return retVal;
        }
    }
}
