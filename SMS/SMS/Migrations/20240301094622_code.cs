using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Migrations
{
    public partial class code : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblCodeGenerator",
                columns: table => new
                {
                    IntId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StrType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntSemesterId = table.Column<long>(type: "bigint", nullable: false),
                    IntBatchCount = table.Column<long>(type: "bigint", nullable: false),
                    IntSerialCount = table.Column<long>(type: "bigint", nullable: false),
                    DteLastActionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCodeGenerator", x => x.IntId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblCodeGenerator");
        }
    }
}
