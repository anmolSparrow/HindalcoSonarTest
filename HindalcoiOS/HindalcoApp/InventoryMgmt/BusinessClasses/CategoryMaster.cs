
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.InventoryMgmt
{
   public class CategoryMaster: IDisposable
    {

        public DateTime CreatedDate { set; get; }
        public String CategoryCode { set; get; }
        public String CategoryName { set; get; }

        public String Parent { set; get; }
        public String ParentCode { set; get; }

        public DataTable LoadData { set; get; }

        public void SetCategoryMasterData(CategoryMaster catmaster)
        {
            Resources.Instance.AddCategoryMaster(catmaster.CategoryName,catmaster.CategoryCode,catmaster.Parent,catmaster.ParentCode ,catmaster.CreatedDate);
        }

        public DataTable GetAllCategory()
        {
            return Resources.Instance.GetCategory();
        }

        public void Dispose()
        {
            //this.Dispose(true);
        }
    }

}
