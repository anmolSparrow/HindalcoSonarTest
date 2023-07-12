using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuditManagementDAL.DataModels
{
    public class AreaStandardMapper
    {
        [Required]
        public int SrNo { set; get; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StdAreaMapId { set; get; }
        [Required]
        public Guid SafetyStandardId { set; get; }
        [Required]
        public Guid AreaId { set; get; }
        public int L2 { set; get; }
        public int L3 { set; get; }
        public string? CreatedBy { set; get; }
        public string? UpdatedBy { set; get; }
        public DateTime UpdatedDate { set; get; }
    }
}
