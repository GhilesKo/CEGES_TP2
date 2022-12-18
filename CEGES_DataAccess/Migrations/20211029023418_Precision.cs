using Microsoft.EntityFrameworkCore.Migrations;

namespace CEGES_DataAccess.Migrations
{
    public partial class Precision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Equipement");

            migrationBuilder.AlterColumn<decimal>(
                name: "Minimum",
                table: "Equipement",
                type: "decimal(20,10)",
                precision: 20,
                scale: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,10)",
                oldPrecision: 10,
                oldScale: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Maximum",
                table: "Equipement",
                type: "decimal(20,10)",
                precision: 20,
                scale: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,10)",
                oldPrecision: 10,
                oldScale: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FacteurConversion",
                table: "Equipement",
                type: "decimal(20,10)",
                precision: 20,
                scale: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,10)",
                oldPrecision: 10,
                oldScale: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Emissions",
                table: "Equipement",
                type: "decimal(20,10)",
                precision: 20,
                scale: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,10)",
                oldPrecision: 10,
                oldScale: 10,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Minimum",
                table: "Equipement",
                type: "decimal(10,10)",
                precision: 10,
                scale: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,10)",
                oldPrecision: 20,
                oldScale: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Maximum",
                table: "Equipement",
                type: "decimal(10,10)",
                precision: 10,
                scale: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,10)",
                oldPrecision: 20,
                oldScale: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FacteurConversion",
                table: "Equipement",
                type: "decimal(10,10)",
                precision: 10,
                scale: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,10)",
                oldPrecision: 20,
                oldScale: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Emissions",
                table: "Equipement",
                type: "decimal(10,10)",
                precision: 10,
                scale: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,10)",
                oldPrecision: 20,
                oldScale: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Equipement",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
