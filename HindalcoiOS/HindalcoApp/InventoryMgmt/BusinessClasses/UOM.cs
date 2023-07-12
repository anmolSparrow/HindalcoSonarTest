using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.InventoryMgmt
{
   public class UOM: IDisposable
    {
        public DateTime CreatedDate { set; get; }
        public String UnitCode { set; get; }
        public String UnitName { set; get; }

        public void SetUnitData(UOM Uom)
        {
            Resources.Instance.AddUOM(Uom.UnitCode,Uom.UnitName,CreatedDate);
        }

        public DataTable GetAllUOM()
        {
           return  Resources.Instance.GetUOM();
        }
        public void DeleteUOMMasterToData(string UnitCode)
        {
            Resources.Instance.DeleteUOM(UnitCode);
        }

        public void Dispose()
        {
            
        }
    }
}
