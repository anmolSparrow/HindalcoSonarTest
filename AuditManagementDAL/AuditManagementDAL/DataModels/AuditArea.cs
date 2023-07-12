using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pomelo.EntityFrameworkCore.MySql;

namespace AuditManagementDAL.DataModels
{
    public class AuditArea
    {
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AuditAreaId { get; set; }
        [Required]
        public string? AreaName { get; set; }
        [Required]
        public string? AreaCode { get; set; }
        public Guid OperationUnitId { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set;}

    }
}
