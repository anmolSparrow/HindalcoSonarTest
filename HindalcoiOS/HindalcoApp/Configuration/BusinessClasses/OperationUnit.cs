using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.Configuration
{
    public class OperationUnit:IDisposable
    {

        public DateTime CreatedDate { set; get; }
        public String OperationUnitName { set; get; }
        public String OperationUnitCode { set; get; }

        public void SetOperationUnitToData(OperationUnit oUnit)
        {
            Resources.Instance.AddOperationUnit(oUnit.OperationUnitCode,oUnit.OperationUnitName,oUnit.CreatedDate);
        }
        public DataTable GetAllOperationUnit()
        {
            return Resources.Instance.GetOperationUnit();
        }

        public void Dispose()
        {
            
        }
    }
}
