using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.Models
{
  public  class DailyConsumption
    {
        public string DProdCode { get; set; }
        public string PlantName { get; set; }
        public string DConsumCode { get; set; }
        public decimal ElectricityConsumed { get; set; }
        public string ElectricityUnit { get; set; }
        public decimal ElectricityRate { get; set; }
        public decimal CoalConsumed { get; set; }
        public string CoalUnit { get; set; }
        public decimal CoalRate { get; set; }
        public decimal TotalProduction { get; set; }
        public string TotalUnit { get; set; }
        public decimal PowerTrip { get; set; }
        public string PowerTripUnit { get; set; }
        public decimal MaintenanceTime { get; set; }
        public string MaintenanceTimeUnit { get; set; }
        public decimal TotalRunningTime { get; set; }
        public string TotalRunningTimeUnit { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
