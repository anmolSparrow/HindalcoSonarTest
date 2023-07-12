using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuditManagementDAL.Migrations
{
    /// <inheritdoc />
    public partial class updatabname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_auditCommittee_tbl_auditPlan_AuditplanId",
                table: "tbl_auditCommittee");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_auditManagement_tbl_auditManagementDetails_AuditManageme~",
                table: "tbl_auditManagement");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_auditMaster_tbl_auditManagementDetails_AuditManagementDe~",
                table: "tbl_auditMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_department_Master_tbl_auditCategory_AuditCategoryCode",
                table: "tbl_department_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_department_Master_tbl_auditPlan_AuditplanId",
                table: "tbl_department_Master");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_operationUnit_tbl_department_Master_DepartmentMasterDepa~",
                table: "tbl_operationUnit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersCredential",
                table: "UsersCredential");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_taskDetails",
                table: "tbl_taskDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_operationUnit",
                table: "tbl_operationUnit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_moduleMaster",
                table: "tbl_moduleMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_modelRBACs",
                table: "tbl_modelRBACs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_department_Master",
                table: "tbl_department_Master");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditPlanHistory",
                table: "tbl_auditPlanHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditPlan",
                table: "tbl_auditPlan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_AuditorResponse",
                table: "tbl_AuditorResponse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditorFindings",
                table: "tbl_auditorFindings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditObservationDetailsL2",
                table: "tbl_auditObservationDetailsL2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditMaster",
                table: "tbl_auditMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditMangementHistory",
                table: "tbl_auditMangementHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditManagementStdDetaiL2",
                table: "tbl_auditManagementStdDetaiL2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditManagementL2",
                table: "tbl_auditManagementL2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditManagementDetailsHistory",
                table: "tbl_auditManagementDetailsHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditManagementDetails",
                table: "tbl_auditManagementDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditManagement",
                table: "tbl_auditManagement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditExecutionPlan",
                table: "tbl_auditExecutionPlan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditExecutionHistory",
                table: "tbl_auditExecutionHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_AuditeeResponse",
                table: "tbl_AuditeeResponse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditCommittee",
                table: "tbl_auditCommittee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditCategory",
                table: "tbl_auditCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditCAPA",
                table: "tbl_auditCAPA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditCalenderL2",
                table: "tbl_auditCalenderL2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditCalendarStdDetailL2",
                table: "tbl_auditCalendarStdDetailL2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditCalendarHistory",
                table: "tbl_auditCalendarHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditCalendar",
                table: "tbl_auditCalendar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditAssignee",
                table: "tbl_auditAssignee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditAssigned",
                table: "tbl_auditAssigned");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditArea",
                table: "tbl_auditArea");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_AreaStandardMapper",
                table: "tbl_AreaStandardMapper");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_areaWiseUsers",
                table: "areaWiseUsers");

            migrationBuilder.RenameTable(
                name: "UsersCredential",
                newName: "userscredential");

            migrationBuilder.RenameTable(
                name: "tbl_taskDetails",
                newName: "tbl_taskdetails");

            migrationBuilder.RenameTable(
                name: "tbl_operationUnit",
                newName: "tbl_operationunit");

            migrationBuilder.RenameTable(
                name: "tbl_moduleMaster",
                newName: "tbl_modulemaster");

            migrationBuilder.RenameTable(
                name: "tbl_modelRBACs",
                newName: "tbl_modelrBACs");

            migrationBuilder.RenameTable(
                name: "tbl_department_Master",
                newName: "tbl_department_master");

            migrationBuilder.RenameTable(
                name: "tbl_auditPlanHistory",
                newName: "tbl_auditplanhistory");

            migrationBuilder.RenameTable(
                name: "tbl_auditPlan",
                newName: "tbl_auditplan");

            migrationBuilder.RenameTable(
                name: "tbl_AuditorResponse",
                newName: "tbl_auditorresponse");

            migrationBuilder.RenameTable(
                name: "tbl_auditorFindings",
                newName: "tbl_auditorfindings");

            migrationBuilder.RenameTable(
                name: "tbl_auditObservationDetailsL2",
                newName: "tbl_auditobservationdetailsl2");

            migrationBuilder.RenameTable(
                name: "tbl_auditMaster",
                newName: "tbl_auditmaster");

            migrationBuilder.RenameTable(
                name: "tbl_auditMangementHistory",
                newName: "tbl_auditmangementhistory");

            migrationBuilder.RenameTable(
                name: "tbl_auditManagementStdDetaiL2",
                newName: "tbl_auditmanagementstddetail2");

            migrationBuilder.RenameTable(
                name: "tbl_auditManagementL2",
                newName: "tbl_auditmanagementl2");

            migrationBuilder.RenameTable(
                name: "tbl_auditManagementDetailsHistory",
                newName: "tbl_auditmanagementdetailshistory");

            migrationBuilder.RenameTable(
                name: "tbl_auditManagementDetails",
                newName: "tbl_auditmanagementdetails");

            migrationBuilder.RenameTable(
                name: "tbl_auditManagement",
                newName: "tbl_auditmanagement");

            migrationBuilder.RenameTable(
                name: "tbl_auditExecutionPlan",
                newName: "tbl_auditexecutionplan");

            migrationBuilder.RenameTable(
                name: "tbl_auditExecutionHistory",
                newName: "tbl_auditexecutionhistory");

            migrationBuilder.RenameTable(
                name: "tbl_AuditeeResponse",
                newName: "tbl_auditeeresponse");

            migrationBuilder.RenameTable(
                name: "tbl_auditCommittee",
                newName: "tbl_auditcommittee");

            migrationBuilder.RenameTable(
                name: "tbl_auditCategory",
                newName: "tbl_auditcategory");

            migrationBuilder.RenameTable(
                name: "tbl_auditCAPA",
                newName: "tbl_auditcapa");

            migrationBuilder.RenameTable(
                name: "tbl_auditCalenderL2",
                newName: "tbl_auditcalenderl2");

            migrationBuilder.RenameTable(
                name: "tbl_auditCalendarStdDetailL2",
                newName: "tbl_auditcalendarstddetaill2");

            migrationBuilder.RenameTable(
                name: "tbl_auditCalendarHistory",
                newName: "tbl_auditcalendarhistory");

            migrationBuilder.RenameTable(
                name: "tbl_auditCalendar",
                newName: "tbl_auditcalendar");

            migrationBuilder.RenameTable(
                name: "tbl_auditAssignee",
                newName: "tbl_auditassignee");

            migrationBuilder.RenameTable(
                name: "tbl_auditAssigned",
                newName: "tbl_auditassigned");

            migrationBuilder.RenameTable(
                name: "tbl_auditArea",
                newName: "tbl_auditarea");

            migrationBuilder.RenameTable(
                name: "tbl_AreaStandardMapper",
                newName: "tbl_areastandardmapper");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "roles");

            migrationBuilder.RenameTable(
                name: "areaWiseUsers",
                newName: "areawiseusers");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_operationUnit_DepartmentMasterDepartmentId",
                table: "tbl_operationunit",
                newName: "IX_tbl_operationunit_DepartmentMasterDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_department_Master_AuditplanId",
                table: "tbl_department_master",
                newName: "IX_tbl_department_master_AuditplanId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_department_Master_AuditCategoryCode",
                table: "tbl_department_master",
                newName: "IX_tbl_department_master_AuditCategoryCode");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_auditMaster_AuditManagementDetailsAuditManDetId",
                table: "tbl_auditmaster",
                newName: "IX_tbl_auditmaster_AuditManagementDetailsAuditManDetId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_auditManagement_AuditManagementDetailsAuditManDetId",
                table: "tbl_auditmanagement",
                newName: "IX_tbl_auditmanagement_AuditManagementDetailsAuditManDetId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_auditCommittee_AuditplanId",
                table: "tbl_auditcommittee",
                newName: "IX_tbl_auditcommittee_AuditplanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userscredential",
                table: "userscredential",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_taskdetails",
                table: "tbl_taskdetails",
                column: "TaskCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_operationunit",
                table: "tbl_operationunit",
                column: "OperationUnitCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_modulemaster",
                table: "tbl_modulemaster",
                column: "ModuleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_modelrBACs",
                table: "tbl_modelrBACs",
                column: "RbacId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_department_master",
                table: "tbl_department_master",
                column: "DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditplanhistory",
                table: "tbl_auditplanhistory",
                column: "DeletionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditplan",
                table: "tbl_auditplan",
                column: "AuditplanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditorresponse",
                table: "tbl_auditorresponse",
                column: "TaskCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditorfindings",
                table: "tbl_auditorfindings",
                column: "AssigneeFindId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditobservationdetailsl2",
                table: "tbl_auditobservationdetailsl2",
                column: "StdDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditmaster",
                table: "tbl_auditmaster",
                column: "AuditMasterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditmangementhistory",
                table: "tbl_auditmangementhistory",
                column: "DeletionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditmanagementstddetail2",
                table: "tbl_auditmanagementstddetail2",
                column: "SafetyStandardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditmanagementl2",
                table: "tbl_auditmanagementl2",
                column: "AuditManId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditmanagementdetailshistory",
                table: "tbl_auditmanagementdetailshistory",
                column: "DeletionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditmanagementdetails",
                table: "tbl_auditmanagementdetails",
                column: "AuditManDetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditmanagement",
                table: "tbl_auditmanagement",
                column: "AuditManId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditexecutionplan",
                table: "tbl_auditexecutionplan",
                column: "AuditExecutionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditexecutionhistory",
                table: "tbl_auditexecutionhistory",
                column: "DeletionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditeeresponse",
                table: "tbl_auditeeresponse",
                column: "TaskCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditcommittee",
                table: "tbl_auditcommittee",
                column: "CommitteeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditcategory",
                table: "tbl_auditcategory",
                column: "AuditCategoryCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditcapa",
                table: "tbl_auditcapa",
                column: "CapaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditcalenderl2",
                table: "tbl_auditcalenderl2",
                column: "AuditplanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditcalendarstddetaill2",
                table: "tbl_auditcalendarstddetaill2",
                column: "StdDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditcalendarhistory",
                table: "tbl_auditcalendarhistory",
                column: "DeletionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditcalendar",
                table: "tbl_auditcalendar",
                column: "AuditCalendarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditassignee",
                table: "tbl_auditassignee",
                column: "AssigneeFindId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditassigned",
                table: "tbl_auditassigned",
                column: "AssignedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditarea",
                table: "tbl_auditarea",
                column: "AuditAreaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_areastandardmapper",
                table: "tbl_areastandardmapper",
                column: "StdAreaMapId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_areawiseusers",
                table: "areawiseusers",
                column: "AreaWiseId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_auditcommittee_tbl_auditplan_AuditplanId",
                table: "tbl_auditcommittee",
                column: "AuditplanId",
                principalTable: "tbl_auditplan",
                principalColumn: "AuditplanId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_auditmanagement_tbl_auditmanagementdetails_AuditManageme~",
                table: "tbl_auditmanagement",
                column: "AuditManagementDetailsAuditManDetId",
                principalTable: "tbl_auditmanagementdetails",
                principalColumn: "AuditManDetId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_auditmaster_tbl_auditmanagementdetails_AuditManagementDe~",
                table: "tbl_auditmaster",
                column: "AuditManagementDetailsAuditManDetId",
                principalTable: "tbl_auditmanagementdetails",
                principalColumn: "AuditManDetId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_department_master_tbl_auditcategory_AuditCategoryCode",
                table: "tbl_department_master",
                column: "AuditCategoryCode",
                principalTable: "tbl_auditcategory",
                principalColumn: "AuditCategoryCode");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_department_master_tbl_auditplan_AuditplanId",
                table: "tbl_department_master",
                column: "AuditplanId",
                principalTable: "tbl_auditplan",
                principalColumn: "AuditplanId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_operationunit_tbl_department_master_DepartmentMasterDepa~",
                table: "tbl_operationunit",
                column: "DepartmentMasterDepartmentId",
                principalTable: "tbl_department_master",
                principalColumn: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_auditcommittee_tbl_auditplan_AuditplanId",
                table: "tbl_auditcommittee");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_auditmanagement_tbl_auditmanagementdetails_AuditManageme~",
                table: "tbl_auditmanagement");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_auditmaster_tbl_auditmanagementdetails_AuditManagementDe~",
                table: "tbl_auditmaster");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_department_master_tbl_auditcategory_AuditCategoryCode",
                table: "tbl_department_master");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_department_master_tbl_auditplan_AuditplanId",
                table: "tbl_department_master");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_operationunit_tbl_department_master_DepartmentMasterDepa~",
                table: "tbl_operationunit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userscredential",
                table: "userscredential");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_taskdetails",
                table: "tbl_taskdetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_operationunit",
                table: "tbl_operationunit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_modulemaster",
                table: "tbl_modulemaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_modelrBACs",
                table: "tbl_modelrBACs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_department_master",
                table: "tbl_department_master");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditplanhistory",
                table: "tbl_auditplanhistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditplan",
                table: "tbl_auditplan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditorresponse",
                table: "tbl_auditorresponse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditorfindings",
                table: "tbl_auditorfindings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditobservationdetailsl2",
                table: "tbl_auditobservationdetailsl2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditmaster",
                table: "tbl_auditmaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditmangementhistory",
                table: "tbl_auditmangementhistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditmanagementstddetail2",
                table: "tbl_auditmanagementstddetail2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditmanagementl2",
                table: "tbl_auditmanagementl2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditmanagementdetailshistory",
                table: "tbl_auditmanagementdetailshistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditmanagementdetails",
                table: "tbl_auditmanagementdetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditmanagement",
                table: "tbl_auditmanagement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditexecutionplan",
                table: "tbl_auditexecutionplan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditexecutionhistory",
                table: "tbl_auditexecutionhistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditeeresponse",
                table: "tbl_auditeeresponse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditcommittee",
                table: "tbl_auditcommittee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditcategory",
                table: "tbl_auditcategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditcapa",
                table: "tbl_auditcapa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditcalenderl2",
                table: "tbl_auditcalenderl2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditcalendarstddetaill2",
                table: "tbl_auditcalendarstddetaill2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditcalendarhistory",
                table: "tbl_auditcalendarhistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditcalendar",
                table: "tbl_auditcalendar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditassignee",
                table: "tbl_auditassignee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditassigned",
                table: "tbl_auditassigned");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditarea",
                table: "tbl_auditarea");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_areastandardmapper",
                table: "tbl_areastandardmapper");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_areawiseusers",
                table: "areawiseusers");

            migrationBuilder.RenameTable(
                name: "userscredential",
                newName: "UsersCredential");

            migrationBuilder.RenameTable(
                name: "tbl_taskdetails",
                newName: "tbl_taskDetails");

            migrationBuilder.RenameTable(
                name: "tbl_operationunit",
                newName: "tbl_operationUnit");

            migrationBuilder.RenameTable(
                name: "tbl_modulemaster",
                newName: "tbl_moduleMaster");

            migrationBuilder.RenameTable(
                name: "tbl_modelrBACs",
                newName: "tbl_modelRBACs");

            migrationBuilder.RenameTable(
                name: "tbl_department_master",
                newName: "tbl_department_Master");

            migrationBuilder.RenameTable(
                name: "tbl_auditplanhistory",
                newName: "tbl_auditPlanHistory");

            migrationBuilder.RenameTable(
                name: "tbl_auditplan",
                newName: "tbl_auditPlan");

            migrationBuilder.RenameTable(
                name: "tbl_auditorresponse",
                newName: "tbl_AuditorResponse");

            migrationBuilder.RenameTable(
                name: "tbl_auditorfindings",
                newName: "tbl_auditorFindings");

            migrationBuilder.RenameTable(
                name: "tbl_auditobservationdetailsl2",
                newName: "tbl_auditObservationDetailsL2");

            migrationBuilder.RenameTable(
                name: "tbl_auditmaster",
                newName: "tbl_auditMaster");

            migrationBuilder.RenameTable(
                name: "tbl_auditmangementhistory",
                newName: "tbl_auditMangementHistory");

            migrationBuilder.RenameTable(
                name: "tbl_auditmanagementstddetail2",
                newName: "tbl_auditManagementStdDetaiL2");

            migrationBuilder.RenameTable(
                name: "tbl_auditmanagementl2",
                newName: "tbl_auditManagementL2");

            migrationBuilder.RenameTable(
                name: "tbl_auditmanagementdetailshistory",
                newName: "tbl_auditManagementDetailsHistory");

            migrationBuilder.RenameTable(
                name: "tbl_auditmanagementdetails",
                newName: "tbl_auditManagementDetails");

            migrationBuilder.RenameTable(
                name: "tbl_auditmanagement",
                newName: "tbl_auditManagement");

            migrationBuilder.RenameTable(
                name: "tbl_auditexecutionplan",
                newName: "tbl_auditExecutionPlan");

            migrationBuilder.RenameTable(
                name: "tbl_auditexecutionhistory",
                newName: "tbl_auditExecutionHistory");

            migrationBuilder.RenameTable(
                name: "tbl_auditeeresponse",
                newName: "tbl_AuditeeResponse");

            migrationBuilder.RenameTable(
                name: "tbl_auditcommittee",
                newName: "tbl_auditCommittee");

            migrationBuilder.RenameTable(
                name: "tbl_auditcategory",
                newName: "tbl_auditCategory");

            migrationBuilder.RenameTable(
                name: "tbl_auditcapa",
                newName: "tbl_auditCAPA");

            migrationBuilder.RenameTable(
                name: "tbl_auditcalenderl2",
                newName: "tbl_auditCalenderL2");

            migrationBuilder.RenameTable(
                name: "tbl_auditcalendarstddetaill2",
                newName: "tbl_auditCalendarStdDetailL2");

            migrationBuilder.RenameTable(
                name: "tbl_auditcalendarhistory",
                newName: "tbl_auditCalendarHistory");

            migrationBuilder.RenameTable(
                name: "tbl_auditcalendar",
                newName: "tbl_auditCalendar");

            migrationBuilder.RenameTable(
                name: "tbl_auditassignee",
                newName: "tbl_auditAssignee");

            migrationBuilder.RenameTable(
                name: "tbl_auditassigned",
                newName: "tbl_auditAssigned");

            migrationBuilder.RenameTable(
                name: "tbl_auditarea",
                newName: "tbl_auditArea");

            migrationBuilder.RenameTable(
                name: "tbl_areastandardmapper",
                newName: "tbl_AreaStandardMapper");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "areawiseusers",
                newName: "areaWiseUsers");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_operationunit_DepartmentMasterDepartmentId",
                table: "tbl_operationUnit",
                newName: "IX_tbl_operationUnit_DepartmentMasterDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_department_master_AuditplanId",
                table: "tbl_department_Master",
                newName: "IX_tbl_department_Master_AuditplanId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_department_master_AuditCategoryCode",
                table: "tbl_department_Master",
                newName: "IX_tbl_department_Master_AuditCategoryCode");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_auditmaster_AuditManagementDetailsAuditManDetId",
                table: "tbl_auditMaster",
                newName: "IX_tbl_auditMaster_AuditManagementDetailsAuditManDetId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_auditmanagement_AuditManagementDetailsAuditManDetId",
                table: "tbl_auditManagement",
                newName: "IX_tbl_auditManagement_AuditManagementDetailsAuditManDetId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_auditcommittee_AuditplanId",
                table: "tbl_auditCommittee",
                newName: "IX_tbl_auditCommittee_AuditplanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersCredential",
                table: "UsersCredential",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_taskDetails",
                table: "tbl_taskDetails",
                column: "TaskCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_operationUnit",
                table: "tbl_operationUnit",
                column: "OperationUnitCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_moduleMaster",
                table: "tbl_moduleMaster",
                column: "ModuleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_modelRBACs",
                table: "tbl_modelRBACs",
                column: "RbacId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_department_Master",
                table: "tbl_department_Master",
                column: "DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditPlanHistory",
                table: "tbl_auditPlanHistory",
                column: "DeletionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditPlan",
                table: "tbl_auditPlan",
                column: "AuditplanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_AuditorResponse",
                table: "tbl_AuditorResponse",
                column: "TaskCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditorFindings",
                table: "tbl_auditorFindings",
                column: "AssigneeFindId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditObservationDetailsL2",
                table: "tbl_auditObservationDetailsL2",
                column: "StdDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditMaster",
                table: "tbl_auditMaster",
                column: "AuditMasterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditMangementHistory",
                table: "tbl_auditMangementHistory",
                column: "DeletionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditManagementStdDetaiL2",
                table: "tbl_auditManagementStdDetaiL2",
                column: "SafetyStandardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditManagementL2",
                table: "tbl_auditManagementL2",
                column: "AuditManId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditManagementDetailsHistory",
                table: "tbl_auditManagementDetailsHistory",
                column: "DeletionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditManagementDetails",
                table: "tbl_auditManagementDetails",
                column: "AuditManDetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditManagement",
                table: "tbl_auditManagement",
                column: "AuditManId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditExecutionPlan",
                table: "tbl_auditExecutionPlan",
                column: "AuditExecutionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditExecutionHistory",
                table: "tbl_auditExecutionHistory",
                column: "DeletionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_AuditeeResponse",
                table: "tbl_AuditeeResponse",
                column: "TaskCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditCommittee",
                table: "tbl_auditCommittee",
                column: "CommitteeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditCategory",
                table: "tbl_auditCategory",
                column: "AuditCategoryCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditCAPA",
                table: "tbl_auditCAPA",
                column: "CapaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditCalenderL2",
                table: "tbl_auditCalenderL2",
                column: "AuditplanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditCalendarStdDetailL2",
                table: "tbl_auditCalendarStdDetailL2",
                column: "StdDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditCalendarHistory",
                table: "tbl_auditCalendarHistory",
                column: "DeletionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditCalendar",
                table: "tbl_auditCalendar",
                column: "AuditCalendarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditAssignee",
                table: "tbl_auditAssignee",
                column: "AssigneeFindId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditAssigned",
                table: "tbl_auditAssigned",
                column: "AssignedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditArea",
                table: "tbl_auditArea",
                column: "AuditAreaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_AreaStandardMapper",
                table: "tbl_AreaStandardMapper",
                column: "StdAreaMapId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_areaWiseUsers",
                table: "areaWiseUsers",
                column: "AreaWiseId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_auditCommittee_tbl_auditPlan_AuditplanId",
                table: "tbl_auditCommittee",
                column: "AuditplanId",
                principalTable: "tbl_auditPlan",
                principalColumn: "AuditplanId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_auditManagement_tbl_auditManagementDetails_AuditManageme~",
                table: "tbl_auditManagement",
                column: "AuditManagementDetailsAuditManDetId",
                principalTable: "tbl_auditManagementDetails",
                principalColumn: "AuditManDetId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_auditMaster_tbl_auditManagementDetails_AuditManagementDe~",
                table: "tbl_auditMaster",
                column: "AuditManagementDetailsAuditManDetId",
                principalTable: "tbl_auditManagementDetails",
                principalColumn: "AuditManDetId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_department_Master_tbl_auditCategory_AuditCategoryCode",
                table: "tbl_department_Master",
                column: "AuditCategoryCode",
                principalTable: "tbl_auditCategory",
                principalColumn: "AuditCategoryCode");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_department_Master_tbl_auditPlan_AuditplanId",
                table: "tbl_department_Master",
                column: "AuditplanId",
                principalTable: "tbl_auditPlan",
                principalColumn: "AuditplanId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_operationUnit_tbl_department_Master_DepartmentMasterDepa~",
                table: "tbl_operationUnit",
                column: "DepartmentMasterDepartmentId",
                principalTable: "tbl_department_Master",
                principalColumn: "DepartmentId");
        }
    }
}
