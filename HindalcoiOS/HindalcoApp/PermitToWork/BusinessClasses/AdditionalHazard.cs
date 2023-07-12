using SparrowRMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.PermitToWork
{
   public class AdditionalHazard
    {
        public int AddHazId { get; set; }
        public string Hazard { get; set; }
        public string Remarks { get; set; }
        public string PermitCode { get; set; }
        public DateTime CreatedDate { get; set; }

        public void SetAdditionalHazard(AdditionalHazard addHazard)
        {
            Resources.Instance.AddAdditionalHazard(addHazard.PermitCode, addHazard.Hazard, addHazard.Remarks,addHazard.CreatedDate);
        }
        public void DeleteAdditionalHazard(AdditionalHazard addHazard)
        {
            Resources.Instance.DeleteAdditionalHazard(addHazard.AddHazId);
        }

    }
}
