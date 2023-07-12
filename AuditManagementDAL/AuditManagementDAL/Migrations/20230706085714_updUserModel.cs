using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuditManagementDAL.Migrations
{
    /// <inheritdoc />
    public partial class updUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_UserModel",
                table: "tbl_UserModel");

            migrationBuilder.RenameTable(
                name: "tbl_UserModel",
                newName: "tbl_usermodel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_usermodel",
                table: "tbl_usermodel",
                column: "UserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_usermodel",
                table: "tbl_usermodel");

            migrationBuilder.RenameTable(
                name: "tbl_usermodel",
                newName: "tbl_UserModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_UserModel",
                table: "tbl_UserModel",
                column: "UserName");
        }
    }
}
