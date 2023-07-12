using System;
using System.Collections.Generic;
using System.Text;

namespace SparrowRMS
{
  public  class EmployeeDetail
    {
        public int emp_id { get; set; }
        public string emp_code { get; set; }
        public int GeoTeamId { get; set; }
        public string emp_name { get; set; }
        public int DeptId { get; set; }
        public string emailId { get; set; }
        public int contact { get; set; }
        public string ReportsToEmployeeCode { get; set; }
        public DateTime DOJ { get; set; }
        public string EmpSoftcode { get; set; }
    }
}
