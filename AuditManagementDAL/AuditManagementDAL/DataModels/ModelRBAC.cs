using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuditManagementDAL.DataModels
{
    public class ModelRBAC
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RbacId { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public Guid? ModuleId { get; set; }
        public bool IsRead { get; set; }
        public bool IsWrite { get; set; }
        public bool IsDelete { get; set; }
        public bool IsUpdate { get; set; }
        [Required]
        public DateTime createdDate { get; set; }
    }
}
