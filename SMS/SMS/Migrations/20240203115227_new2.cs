using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Migrations
{
    public partial class new2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StrFatherContact",
                table: "TblApplicantInfoHeader");

            migrationBuilder.DropColumn(
                name: "StrFatherEmail",
                table: "TblApplicantInfoHeader");

            migrationBuilder.DropColumn(
                name: "StrFatherName",
                table: "TblApplicantInfoHeader");

            migrationBuilder.RenameColumn(
                name: "NumTotakMark",
                table: "TblApplicantInfoHeader",
                newName: "NumTotalMark");

            migrationBuilder.AlterColumn<string>(
                name: "StrGender",
                table: "TblApplicantInfoHeader",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "StrEmail",
                table: "TblApplicantInfoHeader",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "StrContactNumber",
                table: "TblApplicantInfoHeader",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "StrAddress",
                table: "TblApplicantInfoHeader",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nationality",
                table: "TblApplicantInfoHeader",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<long>(
                name: "Scale",
                table: "TblApplicantAcademicInfo",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "TblApplicantAcademicInfo",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "StrBoard",
                table: "TblApplicantAcademicInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StrRegistrationNumber",
                table: "TblApplicantAcademicInfo",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StrBoard",
                table: "TblApplicantAcademicInfo");

            migrationBuilder.DropColumn(
                name: "StrRegistrationNumber",
                table: "TblApplicantAcademicInfo");

            migrationBuilder.RenameColumn(
                name: "NumTotalMark",
                table: "TblApplicantInfoHeader",
                newName: "NumTotakMark");

            migrationBuilder.AlterColumn<string>(
                name: "StrGender",
                table: "TblApplicantInfoHeader",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "StrEmail",
                table: "TblApplicantInfoHeader",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "StrContactNumber",
                table: "TblApplicantInfoHeader",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "StrAddress",
                table: "TblApplicantInfoHeader",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Nationality",
                table: "TblApplicantInfoHeader",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<string>(
                name: "StrFatherContact",
                table: "TblApplicantInfoHeader",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StrFatherEmail",
                table: "TblApplicantInfoHeader",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StrFatherName",
                table: "TblApplicantInfoHeader",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<long>(
                name: "Scale",
                table: "TblApplicantAcademicInfo",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "TblApplicantAcademicInfo",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}
