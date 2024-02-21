using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Migrations
{
    public partial class script7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DteApproveDate",
                table: "TblApplicantInfoHeader");

            migrationBuilder.DropColumn(
                name: "IntClosseBy",
                table: "TblApplicantInfoHeader");

            migrationBuilder.RenameColumn(
                name: "DteCloseDate",
                table: "TblApplicantInfoHeader",
                newName: "ApproveDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApproveDate",
                table: "TblApplicantInfoHeader",
                newName: "DteCloseDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "DteApproveDate",
                table: "TblApplicantInfoHeader",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IntClosseBy",
                table: "TblApplicantInfoHeader",
                type: "bigint",
                nullable: true);
        }
    }
}
