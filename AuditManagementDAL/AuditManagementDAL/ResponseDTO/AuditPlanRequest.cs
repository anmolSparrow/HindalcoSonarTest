namespace AuditManagementDAL.DataModels
{
    public class AuditPlanRequestDTO
    {
        public int DepartmentId { get; set; }
        public string? AuditType { get; set; }
        public string ? AuditYear { get; set; }
        public string? AuditQtr { get; set; }

    }
}
