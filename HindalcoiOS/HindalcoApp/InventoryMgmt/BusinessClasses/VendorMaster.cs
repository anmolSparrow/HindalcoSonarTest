using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.InventoryMgmt
{
   public class VendorMaster: IDisposable
    {
        public DateTime CreatedDate { set; get; }
        public String VendorCode { set; get; }
        public String VendorName { set; get; }
        public string Address { set; get; }
        public string Contact { set; get; }
        public String EmailId { set; get; }
        public String ContactPerson { set; get; }
       
        public DataTable LoadData { set; get; }

        public void SetVendorData(VendorMaster vendorMaster)
        {
            Resources.Instance.AddVendorMaster(vendorMaster.VendorName,vendorMaster.VendorCode,vendorMaster.Contact,vendorMaster.ContactPerson,vendorMaster.EmailId,vendorMaster.CreatedDate,vendorMaster.Address);
        }

        public DataTable LoadVendorMaster()
        {
            return Resources.Instance.GetVendorMaster();
        }

        public void Dispose()
        {
            
        }
    }
}
