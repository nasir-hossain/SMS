using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblApplicantAcademicInfo",
                columns: table => new
                {
                    IntId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntApplicantHeaderId = table.Column<long>(type: "bigint", nullable: false),
                    StrInstitutionName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PassingYear = table.Column<long>(type: "bigint", nullable: false),
                    NumResult = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Scale = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblApplicantAcademicInfo", x => x.IntId);
                });

            migrationBuilder.CreateTable(
                name: "TblApplicantInfoHeader",
                columns: table => new
                {
                    IntId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StrRegistrationCode = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    StrFirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    StrLastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    StrFullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DteDoB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StrGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntFirstDepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    IntOptionalDepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    IntSemesterId = table.Column<long>(type: "bigint", nullable: false),
                    StrEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrFatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrFatherEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrFatherContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DteActionDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StrAttachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumTotakMark = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsPassed = table.Column<bool>(type: "bit", nullable: true),
                    IsForPostGraduate = table.Column<bool>(type: "bit", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsClose = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblApplicantInfoHeader", x => x.IntId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblApplicantAcademicInfo");

            migrationBuilder.DropTable(
                name: "TblApplicantInfoHeader");
        }
    }
}
