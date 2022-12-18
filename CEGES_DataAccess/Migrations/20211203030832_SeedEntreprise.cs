using Microsoft.EntityFrameworkCore.Migrations;

namespace CEGES_DataAccess.Migrations
{
    public partial class SeedEntreprise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Entreprises",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 1, "Pizza Pizza" });

            migrationBuilder.InsertData(
                table: "Entreprises",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 2, "Aluminium du Québec" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Entreprises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Entreprises",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
