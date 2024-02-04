using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Migrations
{
    public partial class new4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TblApplicantAcademicInfo");

            migrationBuilder.DropColumn(
                name: "Scale",
                table: "TblApplicantAcademicInfo");

            migrationBuilder.RenameColumn(
                name: "Nationality",
                table: "TblApplicantInfoHeader",
                newName: "StrNationality");

            migrationBuilder.RenameColumn(
                name: "PassingYear",
                table: "TblApplicantAcademicInfo",
                newName: "IntPassingYear");

            migrationBuilder.AddColumn<string>(
                name: "StrScale",
                table: "TblApplicantAcademicInfo",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StrScale",
                table: "TblApplicantAcademicInfo");

            migrationBuilder.RenameColumn(
                name: "StrNationality",
                table: "TblApplicantInfoHeader",
                newName: "Nationality");

            migrationBuilder.RenameColumn(
                name: "IntPassingYear",
                table: "TblApplicantAcademicInfo",
                newName: "PassingYear");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TblApplicantAcademicInfo",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Scale",
                table: "TblApplicantAcademicInfo",
                type: "bigint",
                nullable: true);
        }
    }
}
