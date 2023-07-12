using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.InventoryMgmt
{
    public class ItemReturn: IDisposable
    {
        public String DocumentNo { set; get; }
        public DateTime DocumentDate { set; get; }
        public String ReferenceNo { set; get; }
        public InvStatus Status { set; get; }
        public String Item { set; get; }
        public String ItemCode { set; get; }
        public double ReturnQty { set; get; }
        public double UnitCost { set; get; }
        public double TotalCost { set; get; }
        public string Remarks { set; get; }
        public string UnitCode { set; get; }
        public string ConsumptionType { set; get; }


        public DataTable GetReturn()
        {
            DataTable dt = null;
            try
            {
                dt = new DataTable();
                dt = Resources.Instance.GetAllReturn();
            }
            catch (Exception Ex)
            {
                // XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        public void SetReturnValue(ItemReturn itemReturn)
        {
            int iStatus = ((int)itemReturn.Status);
            //Resources.Instance.AddReturn(itemReturn.DocumentNo, itemReturn.DocumentDate, itemReturn.ReferenceNo, itemReturn.Item, itemReturn.ItemCode, itemReturn.UnitCode, itemReturn.ReturnQty, itemReturn.UnitCost, itemReturn.TotalCost, itemReturn.ConsumptionType, itemReturn.Remarks);
            Resources.Instance.AddReturn(itemReturn.DocumentNo, itemReturn.DocumentDate, itemReturn.ReferenceNo,itemReturn.ConsumptionType, itemReturn.Remarks,iStatus);
        }
        public void DeleteReturnData(string DocNo)
        {
            Resources.Instance.DeleteReturn(DocNo);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

    
