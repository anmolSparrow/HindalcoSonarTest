using System;
using System.Collections.Generic;
using System.Text;

namespace SparrowRMS
{
  public  class Safety
    {
        public string taskCode { get; set; }
        public string taskType { get; set; }
        public string taskdeadline { get; set; }
        public string AssignedTo { get; set; }
        public string AssignedBy { get; set; }
        public string actionName { get; set; }
        public string targetDateOfClosure { get; set; }

    }
}
