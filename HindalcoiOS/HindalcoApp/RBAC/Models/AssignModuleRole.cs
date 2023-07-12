using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.RBAC
{
    public class AssignModuleRole
    {
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public bool IsRead { get; set; }
        public bool IsWrite { get; set; }
        public bool IsDelete { get; set; }
        public bool IsUpdate { get; set; }
    }
}
