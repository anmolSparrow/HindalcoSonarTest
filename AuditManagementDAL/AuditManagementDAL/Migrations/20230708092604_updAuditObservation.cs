using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuditManagementDAL.Migrations
{
    /// <inheritdoc />
    public partial class updAuditObservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditobservationdetailsl2",
                table: "tbl_auditobservationdetailsl2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditobservationdetailsl2",
                table: "tbl_auditobservationdetailsl2",
                column: "AuditObsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditobservationdetailsl2",
                table: "tbl_auditobservationdetailsl2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditobservationdetailsl2",
                table: "tbl_auditobservationdetailsl2",
                column: "StdDetailId");
        }
    }
}
