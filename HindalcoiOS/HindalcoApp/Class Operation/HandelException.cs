using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMPCLApp.Class_Operation
{
   public class HandelException:Exception
    {
        public HandelException()
        {
            
        }
        public override Exception GetBaseException()
        {
            return base.GetBaseException();
        }

    }
}
