using Microsoft.EntityFrameworkCore.Migrations;

namespace CEGES_DataAccess.Migrations
{
    public partial class SeedGroupe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Groupes",
                columns: new[] { "Id", "EntrepriseId", "Nom" },
                values: new object[,]
                {
                    { 1, 1, "Restaurant" },
                    { 2, 1, "Livraison" },
                    { 3, 2, "Baie-Comeau" },
                    { 4, 2, "Arvida" },
                    { 5, 2, "Alma" },
                    { 6, 2, "Kitimat" },
                    { 7, 2, "Sept-Îles" },
                    { 8, 2, "Deschambeault" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Groupes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groupes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Groupes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Groupes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Groupes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Groupes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Groupes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Groupes",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
