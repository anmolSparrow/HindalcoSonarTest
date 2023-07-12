using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuditManagementDAL.L3_DataModels
{
   public class AuditCalenderL3
   {
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid AuditplanId { set; get; }
    public string? AuditCode { set; get; }
    public DateTime CreatedDate { set; get; }
    public string? CreatedById { set; get; }
    public Guid OperationUnitId { set; get; }
    public string? AuditType { set; get; }
    public string? FinancialYear { set; get; }
    public string? FinancialQuarter { set; get; }
    public DateTime AuditClosureDate { set; get; }
    public string? ExpectedClosureMonth { set; get; }
    public DateTime AuditStartDate { set; get; }
    public DateTime AuditEndDate { set; get; }
    public string? ChairpersonID { set; get; }
    public string? ApexMemId { set; get; }
    public string? SafetyHeadId { set; get; }
    public string? OpUnitHeadId { set; get; }
    public string? AuditPlanUpdatedBy { set; get; }
    public DateTime AuditPlanUpdatedDate { set; get; }
    public float SAQScore { set; get; }
    public string? ActivityLog { set; get; }
    public int DocStatus { set; get; }
   
   }
}
