using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuditManagementDAL.Migrations
{
    /// <inheritdoc />
    public partial class updamgt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_auditCommittee_tbl_auditPlan_AuditplanId",
                table: "tbl_auditCommittee");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_departmentMaster_tbl_auditPlan_AuditplanId",
                table: "tbl_departmentMaster");

            migrationBuilder.DropTable(
                name: "tbl_auditPlan");

            migrationBuilder.DropIndex(
                name: "IX_tbl_departmentMaster_AuditplanId",
                table: "tbl_departmentMaster");

            migrationBuilder.DropIndex(
                name: "IX_tbl_auditCommittee_AuditplanId",
                table: "tbl_auditCommittee");

            migrationBuilder.DropColumn(
                name: "AuditplanId",
                table: "tbl_departmentMaster");

            migrationBuilder.DropColumn(
                name: "AuditplanId",
                table: "tbl_auditCommittee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AuditplanId",
                table: "tbl_departmentMaster",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "AuditplanId",
                table: "tbl_auditCommittee",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_auditPlan",
                columns: table => new
                {
                    AuditplanId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AuditAreaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AuditClosureDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditPlanUpdatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditPlanUpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuditType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditeeId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuditorId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CommitteeMemId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DocStatus = table.Column<int>(type: "int", nullable: true),
                    ExpectedClosureMonth = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FinancialQuarter = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FinancialYear = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OperationUnit = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_auditPlan", x => x.AuditplanId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_departmentMaster_AuditplanId",
                table: "tbl_departmentMaster",
                column: "AuditplanId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_auditCommittee_AuditplanId",
                table: "tbl_auditCommittee",
                column: "AuditplanId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_auditCommittee_tbl_auditPlan_AuditplanId",
                table: "tbl_auditCommittee",
                column: "AuditplanId",
                principalTable: "tbl_auditPlan",
                principalColumn: "AuditplanId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_departmentMaster_tbl_auditPlan_AuditplanId",
                table: "tbl_departmentMaster",
                column: "AuditplanId",
                principalTable: "tbl_auditPlan",
                principalColumn: "AuditplanId");
        }
    }
}
