using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Migrations
{
    public partial class script5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ApproveDate",
                table: "TblApplicantInfoHeader",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IntApproveBy",
                table: "TblApplicantInfoHeader",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApproveDate",
                table: "TblApplicantInfoHeader");

            migrationBuilder.DropColumn(
                name: "IntApproveBy",
                table: "TblApplicantInfoHeader");
        }
    }
}
