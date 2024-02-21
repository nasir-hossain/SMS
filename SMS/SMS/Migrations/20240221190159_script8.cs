using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Migrations
{
    public partial class script8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DteCloseDate",
                table: "TblApplicantInfoHeader",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IntCloseBy",
                table: "TblApplicantInfoHeader",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DteCloseDate",
                table: "TblApplicantInfoHeader");

            migrationBuilder.DropColumn(
                name: "IntCloseBy",
                table: "TblApplicantInfoHeader");
        }
    }
}
