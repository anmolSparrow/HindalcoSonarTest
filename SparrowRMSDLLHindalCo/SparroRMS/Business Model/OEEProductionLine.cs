using System;
using System.Collections.Generic;
using System.Text;

namespace SparrowRMS
{
  public  class OEEProductionLine
    {
       // public int activityLogId { get; set; }
        
        public int LineId { get; set; }
        public string productionLine { get; set; }
        public string shift { get; set; }
        public string category { get; set; }
        public decimal productionCapacity { get; set; }
        public decimal unitTime { get; set; }

    }
}
