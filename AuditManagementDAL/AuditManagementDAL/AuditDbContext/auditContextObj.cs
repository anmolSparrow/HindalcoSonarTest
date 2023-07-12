using AuditManagementDAL.DataModels;
using Microsoft.EntityFrameworkCore;

namespace AuditManagementDAL.AuditDbContext
{
    public class auditContextObj : DbContext
    {
        public auditContextObj(DbContextOptions<auditContextObj> options)
        : base(options) { }
        public DbSet<AuditAssigned> tbl_auditassigned => Set<AuditAssigned>();
        public DbSet<AuditAssignee> tbl_auditassignee => Set<AuditAssignee>();
        public DbSet<AuditCalendar> tbl_auditcalendar => Set<AuditCalendar>();
        public DbSet<AuditeeCAPA> tbl_auditcapa => Set<AuditeeCAPA>();
        public DbSet<AuditorFindings> tbl_auditorfindings => Set<AuditorFindings>();
        public DbSet<AuditCategory> tbl_auditcategory => Set<AuditCategory>();
        public DbSet<AuditPlan> tbl_auditplan => Set<AuditPlan>();
        public DbSet<AuditCommitee> tbl_auditcommittee => Set<AuditCommitee>();
        public DbSet<AuditArea> tbl_auditarea => Set<AuditArea>();
        public DbSet<AuditExecutionPlan> tbl_auditexecutionplan => Set<AuditExecutionPlan>();
        public DbSet<DepartmentMaster> tbl_department_master => Set<DepartmentMaster>();
        public DbSet<UserModel> tbl_usermodel => Set<UserModel>();
        public DbSet<AuditMaster> tbl_auditmaster => Set<AuditMaster>();
        public DbSet<OperationUnit> tbl_operationunit => Set<OperationUnit>();
        public DbSet<AuditManagement> tbl_auditmanagement => Set<AuditManagement>();
        public DbSet<AuditManagementDetails> tbl_auditmanagementdetails => Set<AuditManagementDetails>();
        public DbSet<AuditCalendarHistory> tbl_auditcalendarhistory => Set<AuditCalendarHistory>();
        public DbSet<AuditManagementHistory> tbl_auditmangementhistory => Set<AuditManagementHistory>();
        public DbSet<AuditPlanHistory> tbl_auditplanhistory => Set<AuditPlanHistory>();
        public DbSet<AuditManagementDetHistory> tbl_auditmanagementdetailshistory => Set<AuditManagementDetHistory>();
        public DbSet<AuditExecPlanHistory> tbl_auditexecutionhistory => Set<AuditExecPlanHistory>();
        public DbSet<TaskDetails> tbl_taskdetails => Set<TaskDetails>();
        public DbSet<AuditeeResponse> tbl_auditeeresponse => Set<AuditeeResponse>();
        public DbSet<AuditorResponse> tbl_auditorresponse => Set<AuditorResponse>();
        public DbSet<ModuleMaster> tbl_modulemaster => Set<ModuleMaster>();
        public DbSet<Roles> roles => Set<Roles>();
        public DbSet<ModelRBAC> tbl_modelrBACs => Set<ModelRBAC>();
        public DbSet<UsersCredential> userscredential=> Set<UsersCredential>();
        public DbSet<AreaWiseUser> areawiseusers => Set<AreaWiseUser>();
        public DbSet<AuditManagementL2> tbl_auditmanagementl2 => Set<AuditManagementL2>();
        public DbSet<AuditManagementStdDetaiL2> tbl_auditmanagementstddetail2 =>Set<AuditManagementStdDetaiL2>();
        public DbSet<AuditCalenderL2> tbl_auditcalenderl2 => Set<AuditCalenderL2>();
        public DbSet<AuditCalendarStdDetailL2> tbl_auditcalendarstddetaill2 => Set<AuditCalendarStdDetailL2>();
        public DbSet<AuditObservationDetailL2> tbl_auditobservationdetailsl2 => Set<AuditObservationDetailL2>();
        public DbSet<AreaStandardMapper> tbl_areastandardmapper => Set<AreaStandardMapper>();

    }
}
