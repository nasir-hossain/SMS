using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Migrations
{
    public partial class _12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApproveDate",
                table: "TblApplicantInfoHeader",
                newName: "DteApproveDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DteApproveDate",
                table: "TblApplicantInfoHeader",
                newName: "ApproveDate");
        }
    }
}
