using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditManagementDAL.DataModels
{
    public class AuditMasterDTO
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AuditMasterId { get; set; } = Guid.NewGuid();
        [Required]
        public string? AuditCheckPoint{ get; set;}
        [Required]
        public string? AuditCategoryId { get; set;  }
        public string? AuditRemarks { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        public string? AuditCreatedBy { get; set;}
        public DateTime AuditUpdatedDate { get; set; }
        public string? AuditUpdatedBy { get; set; }

    }
}
