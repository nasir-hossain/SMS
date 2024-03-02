using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Migrations
{
    public partial class script10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IntBatchCount",
                table: "TblCodeGenerator",
                newName: "IntDepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IntDepartmentId",
                table: "TblCodeGenerator",
                newName: "IntBatchCount");
        }
    }
}
