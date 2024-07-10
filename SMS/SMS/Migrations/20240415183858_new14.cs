using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Migrations
{
    public partial class new14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblCourse",
                columns: table => new
                {
                    IntId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StrCourseName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    StrCourseCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IntDepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    NumCredit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumCourseFee = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCourse", x => x.IntId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblCourse");
        }
    }
}
