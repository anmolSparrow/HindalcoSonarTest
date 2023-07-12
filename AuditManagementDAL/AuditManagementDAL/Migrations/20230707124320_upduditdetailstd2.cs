using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuditManagementDAL.Migrations
{
    /// <inheritdoc />
    public partial class upduditdetailstd2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditmanagementstddetail2",
                table: "tbl_auditmanagementstddetail2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditmanagementstddetail2",
                table: "tbl_auditmanagementstddetail2",
                column: "StdDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditmanagementstddetail2",
                table: "tbl_auditmanagementstddetail2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditmanagementstddetail2",
                table: "tbl_auditmanagementstddetail2",
                column: "SafetyStandardId");
        }
    }
}
