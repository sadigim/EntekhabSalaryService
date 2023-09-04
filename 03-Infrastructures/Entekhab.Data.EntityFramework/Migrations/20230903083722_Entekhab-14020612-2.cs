using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entekhab.Data.EntityFramework.Migrations
{
    public partial class Entekhab140206122 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FinalSalary",
                schema: "dbo",
                table: "HREmployee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OverTime",
                schema: "dbo",
                table: "HREmployee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaxValue",
                schema: "dbo",
                table: "HREmployee",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalSalary",
                schema: "dbo",
                table: "HREmployee");

            migrationBuilder.DropColumn(
                name: "OverTime",
                schema: "dbo",
                table: "HREmployee");

            migrationBuilder.DropColumn(
                name: "TaxValue",
                schema: "dbo",
                table: "HREmployee");
        }
    }
}
