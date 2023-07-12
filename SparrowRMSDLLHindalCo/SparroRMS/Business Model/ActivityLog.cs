using System;
using System.Collections.Generic;
using System.Text;
namespace SparrowRMS
{
    public class ActivityLog
    {
        // public int activityLogId { get; set; }

        public int activityDetailsId { get; set; }
        public int activityLogId { get; set; }
        public int UserId { get; set; }
        public int DeptId { get; set; }
        public DateTime activitydate { get; set; }

    }
}
