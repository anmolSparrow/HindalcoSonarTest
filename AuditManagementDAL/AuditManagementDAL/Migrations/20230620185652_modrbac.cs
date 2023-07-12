using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuditManagementDAL.Migrations
{
    /// <inheritdoc />
    public partial class modrbac : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_modelRBACs",
                columns: table => new
                {
                    RbacId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ModuleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IsRead = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsWrite = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDelete = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsUpdate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_modelRBACs", x => x.RbacId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_modelRBACs");
        }
    }
}
