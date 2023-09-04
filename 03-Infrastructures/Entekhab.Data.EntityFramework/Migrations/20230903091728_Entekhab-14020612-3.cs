using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entekhab.Data.EntityFramework.Migrations
{
    public partial class Entekhab140206123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Transportation",
                schema: "dbo",
                table: "HREmployee",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "TaxValue",
                schema: "dbo",
                table: "HREmployee",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "OverTime",
                schema: "dbo",
                table: "HREmployee",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "FinalSalary",
                schema: "dbo",
                table: "HREmployee",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "BasicSalary",
                schema: "dbo",
                table: "HREmployee",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Allowance",
                schema: "dbo",
                table: "HREmployee",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Transportation",
                schema: "dbo",
                table: "HREmployee",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "TaxValue",
                schema: "dbo",
                table: "HREmployee",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "OverTime",
                schema: "dbo",
                table: "HREmployee",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "FinalSalary",
                schema: "dbo",
                table: "HREmployee",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "BasicSalary",
                schema: "dbo",
                table: "HREmployee",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Allowance",
                schema: "dbo",
                table: "HREmployee",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
