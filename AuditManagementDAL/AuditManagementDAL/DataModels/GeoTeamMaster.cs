using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditManagementDAL.DataModels
{
    public class GeoTeamMaster
    {
        [Key]
        public int GeoTeamId { get; set; }
        [Required]
        public Guid GeoTeamCode { get; set; }
        [Required]
        public string? GeoTeamName { get; set;}
        public Guid GeoTeamCreatedBy { get; set; }
        public Guid GeoTeamUpatedBy { get; set; }
        public DateTime GeoUpdatedDate { get; set; }

    }
}
