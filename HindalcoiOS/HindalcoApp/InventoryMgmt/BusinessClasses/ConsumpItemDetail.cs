using DevExpress.XtraEditors;
using HindalcoiOS.Class_Operation;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HindalcoiOS.InventoryMgmt
{
    public class ConsumpItemDetail: IDisposable
    {
        public String DocumentNo { set; get; }
        public String ReferenceNo { set; get; }
        public String Item { set; get; }
        public String ItemCode { set; get; }
        public double ConsumedQty { set; get; }
        public String BatchNo { set; get; }
        public string Unit { set; get; }
        public string UnitCode { set; get; }
        public double UnitCost { set; get; }
        public double TotalCost { set; get; }
        public DataTable LoadItem { set; get; }
        public DataTable LoadBatch { set; get; }
        public DataTable GetConsumption()
        {
            DataTable dt = null;
            try
            {
                dt = new DataTable();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }
        public void SetConsumptionItemDetailValue(ConsumpItemDetail consumItemDetail)
        {
            Resources.Instance.AddConsumpItemDetail(consumItemDetail.DocumentNo,consumItemDetail.ReferenceNo, consumItemDetail.Item, consumItemDetail.ItemCode, consumItemDetail.BatchNo, consumItemDetail.Unit, consumItemDetail.UnitCode, consumItemDetail.ConsumedQty, consumItemDetail.UnitCost, consumItemDetail.TotalCost);
        }
        public DataTable LoadItemMaster()
        {
            return Resources.Instance.GetItemMaster();
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
                XtraMessageBox.Show(Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }
        public void DeleteConsumeDetailData(ConsumpItemDetail consumpDetail)
        {
            Resources.Instance.DeleteConsumpDetail(consumpDetail.DocumentNo, consumpDetail.ItemCode, consumpDetail.BatchNo);
        }

        public void Dispose()
        {
            
        }
    }
}
