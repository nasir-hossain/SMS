using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Migrations
{
    public partial class script_11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "IntUserReferenceId",
                table: "TblUser",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "TblApplicantInfoHeader",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MotherName",
                table: "TblApplicantInfoHeader",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IntUserReferenceId",
                table: "TblUser");

            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "TblApplicantInfoHeader");

            migrationBuilder.DropColumn(
                name: "MotherName",
                table: "TblApplicantInfoHeader");
        }
    }
}
