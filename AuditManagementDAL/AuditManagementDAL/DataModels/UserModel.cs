using System.ComponentModel.DataAnnotations;

namespace AuditManagementDAL.DataModels
{
    public class UserModel
    {
        [Key]
        [Required]
        public string? UserName { get; set; }
        public string? Password { get; set; } = null;
        [Required]
        public int Uid { get;set; }

    }
}
