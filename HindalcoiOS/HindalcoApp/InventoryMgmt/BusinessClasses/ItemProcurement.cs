using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.InventoryMgmt
{
   public class ItemProcurement: IDisposable
    {
        public String DocumentNo { set; get; }
        public DateTime PurchaseDate { set; get; }
        public DateTime DocDate { set; get; }
        public String ItemCode { set; get; }
        public String Item { set; get; }
        public String BatchNo { set; get; }
        public double InputQty { set; get; }
        public double AvailableQty { set; get; }
        public double UnitCost { set; get; }
        public string Unit { set; get; }
        public string UnitCode { set; get; }
        public string Vendor { set; get; }
        public string VendorCode { set; get; }
        public string BillNo { set; get; }
        public InvStatus Status { set; get; }
        public DataTable LoadData { set; get; }
        public DataTable LoadVendor { set; get; }
        public DataTable LoadItem { set; get; }

        public DataTable GetProcurement()
        {
            DataTable dt = null;
            try
            {
                dt = new DataTable();
                dt = Resources.Instance.GetAllProcurement();
            }
            catch (Exception Ex)
            {
               // XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }



        public void SetProcurementValue(ItemProcurement procMent)
        {
           int iStatus =((int)procMent.Status);
            //Resources.Instance.AddProcurement(procMent.DocumentNo,procMent.DocDate,procMent.BillNo,procMent.Item,procMent.ItemCode, procMent.BatchNo,procMent.PurchaseDate,procMent.InputQty,procMent.UnitCost,procMent.Unit,procMent.UnitCode,procMent.Vendor,procMent.VendorCode);
            Resources.Instance.AddProcurement(procMent.DocumentNo, procMent.DocDate, procMent.BillNo,procMent.PurchaseDate,procMent.Vendor, procMent.VendorCode, iStatus);
        }

        public DataTable LoadItemMaster()
        {
            return Resources.Instance.GetItemMaster();
        }
        public DataTable LoadUnitMaster()
        {
            return Resources.Instance.GetUOM();
        }
        public DataTable LoadVendorMaster()
        {
            return Resources.Instance.GetVendorMaster();
        }

        public DataTable LoadProcureData()
        {
            DataTable dt = null;
            dt = new DataTable();
            dt.Columns.Add("Select", typeof(Boolean));
            dt.Columns.Add("PurchaseDate", typeof(DateTime));
            dt.Columns.Add("Item", typeof(string));
            dt.Columns.Add("BatchNo", typeof(string));
            dt.Columns.Add("InputQty", typeof(double));
            dt.Columns.Add("Rate", typeof(double));
            dt.Columns.Add("Unit", typeof(string));
            return dt;
         }
            //public void SetProcurementValue(ItemProcurement procurement)
            //{
            //    DataTable dt = null;
            //    dt = new DataTable();

            //    dt.Columns.Add("Item", typeof(string));
            //    dt.Columns.Add("BatchNo", typeof(string));
            //    dt.Columns.Add("PurchaseDate", typeof(DateTime));
            //    dt.Columns.Add("InputQty", typeof(double));
            //    dt.Columns.Add("Rate", typeof(double));
            //    dt.Columns.Add("Unit", typeof(string));


            //    dt.Rows[0]["PurchaseDate"] = procurement.PurchaseDate;
            //    dt.Rows[0]["Item"] = procurement.Item;
            //    dt.Rows[0]["BatchNo"] = procurement.BatchNo;
            //    dt.Rows[0]["InputQty"] = procurement.InputQty;
            //    dt.Rows[0]["Rate"] = procurement.Rate;
            //    dt.Rows[0]["Unit"] = procurement.Unit;

            //    Resources.Instance.AddProcurement(dt);
            //}
            public void DeleteProcurementData(string DocNo)
            {
                Resources.Instance.DeleteProcurement(DocNo);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public enum InvStatus
    { 
        Prepare=0,
        Open=1,
        Closed=2
    }

}
