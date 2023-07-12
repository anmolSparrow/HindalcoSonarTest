﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuditManagementDAL.Migrations
{
    /// <inheritdoc />
    public partial class updauditobs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditObservationDetailsL2",
                table: "tbl_auditObservationDetailsL2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditObservationDetailsL2",
                table: "tbl_auditObservationDetailsL2",
                column: "StdDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_auditObservationDetailsL2",
                table: "tbl_auditObservationDetailsL2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_auditObservationDetailsL2",
                table: "tbl_auditObservationDetailsL2",
                column: "AuditObsId");
        }
    }
}
