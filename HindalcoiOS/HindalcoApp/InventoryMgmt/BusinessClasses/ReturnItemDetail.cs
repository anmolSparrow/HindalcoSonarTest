using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.InventoryMgmt
{
   public class ReturnItemDetail: IDisposable
    {
        public String DocumentNo { set; get; }
        public String ReferenceNo { set; get; }
        public String Item { set; get; }
        public String ItemCode { set; get; }
        public double ReturnQty { set; get; }
        public String BatchNo { set; get; }
        public string Unit { set; get; }
        public string UnitCode { set; get; }
        public double UnitCost { set; get; }
        public double TotalCost { set; get; }
        public DataTable LoadItem { set; get; }
        public DataTable LoadBatch { set; get; }
        public string RefNo { set; get; }

        public DataTable GetConsumption()
        {
            DataTable dt = null;
            try
            {
                dt = new DataTable();
                //dt = Resources.Instance.GetAllProcurement();
            }
            catch (Exception Ex)
            {
                // XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }
        public void SetReturnItemDetailValue(ReturnItemDetail returnItemDetail)
        {
            Resources.Instance.AddReturnItemDetail(returnItemDetail.DocumentNo, returnItemDetail.ReferenceNo, returnItemDetail.Item, returnItemDetail.ItemCode, returnItemDetail.BatchNo, returnItemDetail.Unit, returnItemDetail.UnitCode, returnItemDetail.ReturnQty, returnItemDetail.UnitCost, returnItemDetail.TotalCost);
        }
        public DataTable LoadItemMaster()
        {
            return Resources.Instance.GetItemMaster();
        }
        public DataTable LoadItemMaster(string RefNo)
        {
            return Resources.Instance.GetConsumedItemDetailwithRefNo(RefNo);
        }
        public DataTable GetAllBatch(string itemCode)
        {
            DataTable dt = null;
            try
            {
                dt = new DataTable();
                dt = Resources.Instance.GetSingleItemStock(itemCode);
            }
            catch (Exception Ex)
            {
                // XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }
        public void DeleteReturnDetailData(ReturnItemDetail rtItemDetail)
        {
            Resources.Instance.DeleteReturnDetail(rtItemDetail.DocumentNo, rtItemDetail.ItemCode, rtItemDetail.BatchNo);
        }
        public  Double GetBillWiseConsumedItemQty(string referenceNo, string itemCode, string batchno)
        {
            double totQty = 0;
            double Result = 0;
            totQty= Resources.Instance.GetBillWiseConsumedItemQty(referenceNo, itemCode, batchno,out Result );
            return totQty;
        }

        public void Dispose()
        {
            
        }
    }
}
