using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.Models
{
    public class NearMissUAUC
    {
        public string ObservationNo { get; set; }
        public DateTime ObservationDate { get; set; }
        public string OperationUnit { get; set; }
        public string SpecificLocation { get; set; }
        public string DocumentedBy { get; set; }
        public string Area { get; set; }
        public string MachineTag { get; set; }
        public string Observation { get; set; }
        public string NearMissStatus { get; set; }
        public string DocumentStatus { get; set; }
        public string ActOrCondition { get; set; }
        public string ObservedBy { get; set; }
        public string Recommendation { get; set; }
        public string ImgPath { get; set; }
        public string AssignedTo { get; set; }
        public string Remarks { get; set; }
        public int is_admin { get; set; }
        public string is_GMCode { get; set; }
        public string AssigneeImgPath { get; set; }
        public string ObserverImgPath { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime GM_Approval_RejectionDate { get; set; }
        public DateTime Reqester_FinalApproval_RejectionDate { get; set; }
        public bool is_AdminClosed { get; set; }
        public string RequestStage { get; set; }
    }
}
