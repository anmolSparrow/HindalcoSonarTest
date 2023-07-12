using System;
using System.Collections.Generic;
using System.Text;

namespace SparrowRMS
{
  public  class IncidentReporting
    {
        public int IncidentRptId { get; set; }
        public string employeeName { get; set; }
        public string  employeeCode { get; set; }
        public int locationId { get; set; }
        public string  locationName { get; set; }
        public string eventDescription { get; set; }
        public string correctiveAction { get; set; }
        public string imageUploaded { get; set; }
        public DateTime eventDate { get; set; }
       // public string EmpSoftcode { get; set; }
    }
}
