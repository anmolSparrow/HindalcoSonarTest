using AuditManagementDAL.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace AuditManagementDAL.DataModels
{
    //[PrimaryKey(nameof(AuditCategoryId), nameof(AuditCategoryCode))]
    [PrimaryKey(nameof(AuditCategoryCode))]
    public class AuditCategoryDTO
    {
        [Required]
        public string? AuditCategoryName { get; set; }
        [Required]
        public string? AuditCategoryCode { get; set; }
        [Required]
        public int DepartmentCode { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AuditCategoryId { get; set; } = Guid.NewGuid();
        [Required]
        public string? AuditCreatedBy { get; set; }
        [Required]
        public DateTime AuditUpdatedDate { get; set; }
        [Required]
        public string? AuditUpdatedBy { get; set; }
        public DateTime AuditCreatedDate { get; set; }
        public ICollection<DepartmentMaster>? DepartMentMaster { get; }
    }
}
