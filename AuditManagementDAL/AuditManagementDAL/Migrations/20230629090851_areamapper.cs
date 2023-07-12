using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuditManagementDAL.Migrations
{
    /// <inheritdoc />
    public partial class areamapper : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_AreaStandardMapper",
                columns: table => new
                {
                    StdAreaMapId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SrNo = table.Column<int>(type: "int", nullable: false),
                    SafetyStandardId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AreaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    L2 = table.Column<int>(type: "int", nullable: false),
                    L3 = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_AreaStandardMapper", x => x.StdAreaMapId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_AreaStandardMapper");
        }
    }
}
