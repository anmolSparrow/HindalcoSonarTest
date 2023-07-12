using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.Models
{
  public  class DailyProduction
    {
        public string DProdCode { get; set; }
        public string PlantName { get; set; }
        public string ProdName { get; set; }
        public string ProdCode { get; set; }
        public decimal OpeningStock { get; set; }
        public decimal DailyTarget { get; set; }
        public decimal ActualProd { get; set; }
        public decimal ProdDispatched { get; set; }
        public decimal ClosingStock { get; set; }
        public string EmpCode { get; set; }
        public int RoleId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DateFilledFor { get; set; }
        public DateTime UpdateDate { get; set; }
        public string ActualProdUnit { get; set; }
        public string PrdoDispatchedUnit { get; set; }
    }
}
