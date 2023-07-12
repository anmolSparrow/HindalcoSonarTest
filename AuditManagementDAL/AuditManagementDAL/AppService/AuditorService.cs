using AuditManagementDAL.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AuditManagementDAL.DataModels
{
    public class AuditorService : IAuditInputModels
    {
        List<AuditAssigned> auditAssigned = new List<AuditAssigned>();
        public AuditorService()
        {
            // Assigned = new AuditAssigned();
            // Assignee = new AuditAssignee();
            // Calendar = new AuditCalendar();
            // AuditeeCAPA=new AuditeeCAPA();
            // AuditorFindings = new AuditorFindings();
            // if (_SingleInstance == null)
            //     _SingleInstance = new ClassDataObj();
            //// return _SingleInstance;
        }

        //public async Task<List<AuditDataModeller.DataModels.AuditAssigned>> GetAuditAssigned()
        //{
        //    try
        //    {
        //        return await auditAssigned.ToList();

        //    }
        //    catch(Exception ex)
        //    {

        //    }

        //}
    }
}
