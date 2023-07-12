
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.InventoryMgmt
{
   public class ItemMaster: IDisposable
    {

        public DateTime CreatedDate { set; get; }
        public String ItemCode { set; get; }
        public String ItemName { set; get; }
        public string Unit { set; get; }
        public string UnitCode { set; get; }
        public String Category { set; get; }
        public String CategoryCode { set; get; }
        public string SubCategory { set; get; }
        public string SubCategoryCode { set; get; }
        public String Make { set; get; }
        public String Model { set; get; }
        public double ThresholdLimit { set; get; }
        public DataTable LoadData { set; get; }
        public DataTable LoadCategory { set; get; }

        public void SetItemMasterData(ItemMaster itemmaster)
        {
            //Resources.Instance.AddItemMaster(itemmaster.ItemCode,itemmaster.ItemName,itemmaster.Unit, itemmaster.UnitCode, itemmaster.CreatedDate);
             Resources.Instance.AddItemMaster(itemmaster.ItemCode, itemmaster.ItemName, itemmaster.Unit, itemmaster.UnitCode,itemmaster.Category,itemmaster.CategoryCode,
                itemmaster.Make,itemmaster.Model,itemmaster.ThresholdLimit, itemmaster.CreatedDate);
        }

        public DataTable GetAllItems()
        {
            return Resources.Instance.GetItemMaster();
        }
        public DataTable LoadUnit()
        {
            return Resources.Instance.GetUOM();
        }
        public DataTable GetAllCategory()
        {
            return Resources.Instance.GetCategory();
        }
        public DataTable GetAllSubCategory(string permitCode)
        {
            return Resources.Instance.GetSubCategory(permitCode);
        }
        public void SaveUnit(ItemMaster itemMaster)
        {
            Resources.Instance.AddUOM(itemMaster.Unit, itemMaster.UnitCode, DateTime.Today);
        }
        public void SaveCategory(ItemMaster itemMaster)
        {
            Resources.Instance.AddCategoryMaster(itemMaster.Category, itemMaster.CategoryCode,"Primary", "Primary", DateTime.Today);
        }
        public void SaveSubCategory(ItemMaster itemMaster)
        {
            Resources.Instance.AddCategoryMaster(itemMaster.SubCategory, itemMaster.SubCategoryCode,Category,CategoryCode, DateTime.Today);
        }
        public void DeleteItemMasterToData(string  itemCode)
        {
            Resources.Instance.DeleteItemMaster(itemCode);

        }
        public DataTable CheckItemOnTranData(string itemCode)
        {
          return  Resources.Instance.CheckItemOnTran(itemCode);

        }

        public void Dispose()
        {
            
        }
    }

}
