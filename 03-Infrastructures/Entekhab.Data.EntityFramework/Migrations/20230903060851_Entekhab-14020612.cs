using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entekhab.Data.EntityFramework.Migrations
{
    public partial class Entekhab14020612 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "HREmployee",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    BasicSalary = table.Column<int>(type: "int", nullable: false),
                    Allowance = table.Column<int>(type: "int", nullable: false),
                    Transportation = table.Column<int>(type: "int", nullable: false),
                    CreatorUserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditorUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EditDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HREmployee", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HREmployee",
                schema: "dbo");
        }
    }
}
