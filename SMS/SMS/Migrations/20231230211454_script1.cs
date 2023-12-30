using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Migrations
{
    public partial class script1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblRole",
                columns: table => new
                {
                    IntId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StrRoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRole", x => x.IntId);
                });

            migrationBuilder.CreateTable(
                name: "TblUser",
                columns: table => new
                {
                    IntId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StrFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DteLastActionDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IntActionBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUser", x => x.IntId);
                });

            migrationBuilder.CreateTable(
                name: "TblUserRole",
                columns: table => new
                {
                    IntId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntUserId = table.Column<long>(type: "bigint", nullable: false),
                    IntRoleId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUserRole", x => x.IntId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblRole");

            migrationBuilder.DropTable(
                name: "TblUser");

            migrationBuilder.DropTable(
                name: "TblUserRole");
        }
    }
}
