
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.InventoryMgmt
{
    public class ItemConsumption: IDisposable
    {
        public String DocumentNo { set; get; }
        public DateTime DocumentDate { set; get; }
        public String ReferenceNo { set; get; }
        public String ConsumptionType { set; get; }
        public InvStatus Status { set; get; }
        public String Item { set; get; }
        public String ItemCode { set; get; }
        public double ConsumedQty { set; get; }
        public double UnitCost { set; get; }
        public double TotalCost { set; get; }
        public string UnitCode { set; get; }
        public string Remarks { set; get; }
        public DataTable LoadItem { set; get; }


        public DataTable GetConsumption()
        {
            DataTable dt = null;
            try
            {  
                dt = new DataTable();
                dt = Resources.Instance.GetAllConsumption();
            }
            catch (Exception Ex)
            {
                // XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        public void SetConsumptionValue(ItemConsumption itemConsump)
        {
            int iStatus = ((int)itemConsump.Status);
            //Resources.Instance.AddConsumption(itemConsump.DocumentNo, itemConsump.DocumentDate, itemConsump.ReferenceNo, itemConsump.Item, itemConsump.ItemCode, itemConsump.UnitCode, itemConsump.ConsumedQty, itemConsump.ConsumptionType, itemConsump.UnitCost, itemConsump.TotalCost,itemConsump.Remarks);
            Resources.Instance.AddConsumption(itemConsump.DocumentNo, itemConsump.DocumentDate, itemConsump.ReferenceNo,itemConsump.ConsumptionType,itemConsump.Remarks,iStatus);
        }

        public DataTable LoadItemMaster()
        {
            return Resources.Instance.GetItemMaster();
        }
        public void DeleteConsumptionData(string DocNo)
        {
            Resources.Instance.DeleteConsumption(DocNo);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    
}
