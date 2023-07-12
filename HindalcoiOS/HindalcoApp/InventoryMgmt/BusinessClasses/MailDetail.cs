using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.InventoryMgmt
{
    public  class MailDetail: IDisposable
    {
        public String MailTo { set; get; }
        public String MailCc { set; get; }
        public string Subject { set; get; }
        public string Body { set; get; }

        public void Dispose()
        {
            
        }
    }
}
