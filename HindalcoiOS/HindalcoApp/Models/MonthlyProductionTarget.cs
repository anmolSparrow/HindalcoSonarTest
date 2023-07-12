using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.Models
{
   public  class MonthlyProduction
    {
        public int TargetId { get; set; }
        public int NoWorkDays { get; set; }
        public string DaysWorked { get; set; }
        public string PlantName { get; set; }
        public decimal MonthlyTarget { get; set; }
        public decimal DailyTarget { get; set; }
        public decimal ClosingStock { get; set; }
        public string MonthlyTargetUnit { get; set; }
        public string DailyTargetUnit { get; set; }
        public string ClosingStockUnit { get; set; }
        public string CreatedBy { get; set; }
        public int RoleId { get; set; }
        public string TargetCode { get; set; }
        public string TargetMonth { get; set; }
        public int TargetYear { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ProdCode { get; set; }

    }
}
