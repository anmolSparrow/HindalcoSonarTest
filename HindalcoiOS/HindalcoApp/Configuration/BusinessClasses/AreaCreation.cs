
using DevExpress.XtraEditors;
using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.Configuration
{
     public  class AreaCreation
    {
        public DateTime CreatedDate { set; get; }
        public String Name { set; get; }
        public String Code { set; get; }


        public void SetAreaMasterData(AreaCreation areaCreation)
        {
            Resources.Instance.AddAreaMaster(areaCreation.Name, areaCreation.Code, areaCreation.CreatedDate);
        }

        public DataTable GetAllAreas()
        {
            return Resources.Instance.GetArea();
        }
    }
}
