using System.ComponentModel.DataAnnotations;

namespace AuditManagementDAL.DataModels
{
    public class OperationUnitDTO
    {
        [Key]
        [Required]
        public Guid OperationUnitCode { get; set; }
        public string? OperationUnitName { get; set;}
    }
}
