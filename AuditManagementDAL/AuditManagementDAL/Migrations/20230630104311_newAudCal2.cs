using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuditManagementDAL.Migrations
{
    /// <inheritdoc />
    public partial class newAudCal2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditCalendarStdDetailL2",
                table: "tbl_auditCalendarStdDetailL2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditCalendarStdDetailL2",
                table: "tbl_auditCalendarStdDetailL2",
                column: "StdDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditCalendarStdDetailL2",
                table: "tbl_auditCalendarStdDetailL2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditCalendarStdDetailL2",
                table: "tbl_auditCalendarStdDetailL2",
                column: "SafetyStandardId");
        }
    }
}
