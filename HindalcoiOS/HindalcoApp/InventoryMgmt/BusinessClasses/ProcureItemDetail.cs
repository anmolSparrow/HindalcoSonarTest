using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.InventoryMgmt
{
    public class ProcureItemDetail: IDisposable
    {
        public String DocumentNo { set; get; }
        public String ItemCode { set; get; }
        public String Item { set; get; }
        public String BatchNo { set; get; }
        public double ProcureQty { set; get; }
        public double AvailableQty { set; get; }
        public double UnitCost { set; get; }
        public double TotalCost { set; get; }
        public string Unit { set; get; }
        public string UnitCode { set; get; }

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
        public void SetProcureItemDetailValue(ProcureItemDetail pcItemDetail)
        {
            Resources.Instance.AddProcureItemDetail(pcItemDetail.DocumentNo, pcItemDetail.Item, pcItemDetail.ItemCode, pcItemDetail.UnitCode, pcItemDetail.BatchNo, pcItemDetail.ProcureQty, pcItemDetail.UnitCost, pcItemDetail.TotalCost);
        }
        public DataTable LoadItemMaster()
        {
            return Resources.Instance.GetItemMaster();
        }
        public void DeleteProcurementDetailData(ProcureItemDetail pcItemDetail)
        {
            Resources.Instance.DeleteProcureDetail(pcItemDetail.DocumentNo, pcItemDetail.ItemCode, pcItemDetail.BatchNo);
        }
        public DataTable GetProcureItemDetailByDocNo(ProcureItemDetail pcItemDetail)
        {
            return Resources.Instance.GetProcureItemDetail(pcItemDetail.DocumentNo);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
