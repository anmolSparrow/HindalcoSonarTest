using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuditManagementDAL.Migrations
{
    /// <inheritdoc />
    public partial class areawiseUpd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "areaWiseUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "areaWiseUsers",
                columns: table => new
                {
                    AreaWiseId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AuditAreaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DeptId = table.Column<int>(type: "int", nullable: false),
                    EmpCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsUserActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    OperationUnitId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserEmailUserEmail = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_areaWiseUsers", x => x.AreaWiseId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
