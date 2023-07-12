using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.InventoryMgmt
{
    public class ItemStock: IDisposable
    {
        public DataTable LoadItem { set; get; }

        public void Dispose()
        {
           
        }

        public DataTable GetStock()
        {
            DataTable dt = null;
            try
            {
                dt = new DataTable();
                dt = Resources.Instance.GetTotalStock();
            }
            catch (Exception Ex)
            {
                // XtraMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, Ex.Message, ApplicationConstants.MessageDisplay, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }
    }
}
