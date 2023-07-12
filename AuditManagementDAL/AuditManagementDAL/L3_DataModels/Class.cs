using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuditManagementDAL.L3_DataModels
{
  public class AuditCalendarStdDetailL3
    {
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid StdDetailId { set; get; }
    public Guid AuditPlanId { set; get; }
    public Guid SafetyStandardId { set; get; }
    public string? StdSrlNo { set; get; }
    public string? AuditorId { set; get; }
    public string? AuditeeId { set; get; }
    public string? UpdatedBy { set; get; }
    public DateTime UpdatedDate { set; get; }
    public string? ActivityLog { set; get; }
    public int Status { set; get; }
  }
}
