using Microsoft.EntityFrameworkCore.Migrations;

namespace CEGES_DataAccess.Migrations
{
    public partial class SeedEquipement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "Discriminator", "Emissions", "GroupeId", "Nom" },
                values: new object[] { 4, "EquipementConstant", 0.0078m, 1, "Administration" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "Discriminator", "GroupeId", "Maximum", "Minimum", "Nom" },
                values: new object[,]
                {
                    { 38, "EquipementRelatif", 4, 20.853m, 10.637m, "Broyeur humide" },
                    { 37, "EquipementRelatif", 4, 8.286m, 5.58m, "Bains de précipitation" },
                    { 36, "EquipementRelatif", 4, 106.448m, 53.845m, "Pyroépurateur" },
                    { 33, "EquipementRelatif", 4, 11.74m, 4.775m, "Bain broyé" },
                    { 29, "EquipementRelatif", 4, 154.81m, 15.002m, "Four à réduction" },
                    { 28, "EquipementRelatif", 4, 124.5m, 35.4m, "Fabrication d'anodes" },
                    { 27, "EquipementRelatif", 4, 6.518m, 3.171m, "Calcination" },
                    { 25, "EquipementRelatif", 3, 2.984m, 1.441m, "Filtreurs" },
                    { 24, "EquipementRelatif", 3, 22.733m, 12.317m, "Broyeur humide" },
                    { 23, "EquipementRelatif", 3, 9.752m, 6.007m, "Bains de précipitation" },
                    { 22, "EquipementRelatif", 3, 96.239m, 53.189m, "Pyroépurateur" },
                    { 17, "EquipementRelatif", 3, 9.73m, 6.075m, "Bain broyé" },
                    { 13, "EquipementRelatif", 3, 12.55m, 8.98m, "Four à réduction" },
                    { 12, "EquipementRelatif", 3, 400.15m, 12.98m, "Fabrication d'anodes" },
                    { 11, "EquipementRelatif", 3, 6.45m, 1.54m, "Calcination" },
                    { 3, "EquipementRelatif", 1, 1.25m, 0.85m, "Éclairage" },
                    { 2, "EquipementRelatif", 1, 12.8m, 1.57m, "Chauffage" },
                    { 39, "EquipementRelatif", 4, 2.575m, 0.488m, "Filtreurs" },
                    { 41, "EquipementRelatif", 5, 10.226m, 4.611m, "Calcination" },
                    { 42, "EquipementRelatif", 5, 98.4m, 22.8m, "Fabrication d'anodes" },
                    { 49, "EquipementRelatif", 5, 9.138m, 4.89m, "Bains de précipitation" },
                    { 84, "EquipementRelatif", 8, 7.907m, 5.215m, "Bains de précipitation" },
                    { 83, "EquipementRelatif", 8, 108.3m, 50.36m, "Pyroépurateur" },
                    { 79, "EquipementRelatif", 8, 8.03m, 6.379m, "Bain broyé" },
                    { 76, "EquipementRelatif", 8, 122.521m, 28.675m, "Four à réduction" },
                    { 75, "EquipementRelatif", 8, 16.4m, 8.45m, "Fabrication d'anodes" },
                    { 73, "EquipementRelatif", 7, 2.167m, 1.228m, "Filtreurs" },
                    { 72, "EquipementRelatif", 7, 24.073m, 9.74m, "Broyeur humide" },
                    { 71, "EquipementRelatif", 7, 10.667m, 6.196m, "Bains de précipitation" }
                });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "Discriminator", "FacteurConversion", "GroupeId", "Nom", "UniteMesure" },
                values: new object[] { 80, "EquipementLineaire", 0.68m, 8, "Centre de coulée", "coulées" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "Discriminator", "GroupeId", "Maximum", "Minimum", "Nom" },
                values: new object[,]
                {
                    { 64, "EquipementRelatif", 7, 7.848m, 2.359m, "Calcination" },
                    { 61, "EquipementRelatif", 6, 11.053m, 6.106m, "Bains de précipitation" },
                    { 60, "EquipementRelatif", 6, 90.679m, 68.506m, "Pyroépurateur" },
                    { 56, "EquipementRelatif", 6, 11.6m, 4.914m, "Bain broyé" },
                    { 55, "EquipementRelatif", 6, 138.647m, 20.215m, "Four à réduction" },
                    { 54, "EquipementRelatif", 6, 124.54m, 50.1m, "Fabrication d'anodes" },
                    { 53, "EquipementRelatif", 6, 5.317m, 1.315m, "Calcination" },
                    { 51, "EquipementRelatif", 5, 4.879m, 1.451m, "Filtreurs" },
                    { 50, "EquipementRelatif", 5, 20.168m, 10.246m, "Broyeur humide" },
                    { 62, "EquipementRelatif", 6, 3.691m, 1.439m, "Filtreurs" }
                });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "Discriminator", "FacteurConversion", "GroupeId", "Nom", "UniteMesure" },
                values: new object[] { 78, "EquipementLineaire", 0.00034m, 8, "Scies", "unités" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "Discriminator", "FacteurConversion", "GroupeId", "Nom", "UniteMesure" },
                values: new object[,]
                {
                    { 74, "EquipementLineaire", 0.00098m, 8, "Transport ferroviaire", "km" },
                    { 70, "EquipementLineaire", 3.98m, 7, "Concasseur", "t" },
                    { 7, "EquipementLineaire", 0.00000854m, 2, "Leaf 1", "km" },
                    { 6, "EquipementLineaire", 0.000184m, 2, "Yaris 2", "km" },
                    { 5, "EquipementLineaire", 0.000184m, 2, "Yaris 1", "km" },
                    { 1, "EquipementLineaire", 0.000143m, 1, "Four", "pizza(s)" }
                });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "Discriminator", "Emissions", "GroupeId", "Nom" },
                values: new object[,]
                {
                    { 82, "EquipementConstant", 0.547m, 8, "Moulage et refroisissement" },
                    { 81, "EquipementConstant", 0.98m, 8, "Cuves à débrasquer" },
                    { 77, "EquipementConstant", 0.0014m, 8, "Réfection des cuves" },
                    { 69, "EquipementConstant", 1.54m, 7, "Moulage et refroisissement" }
                });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "Discriminator", "FacteurConversion", "GroupeId", "Nom", "UniteMesure" },
                values: new object[] { 8, "EquipementLineaire", 0.00000854m, 2, "Leaf 2", "km" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "Discriminator", "Emissions", "GroupeId", "Nom" },
                values: new object[,]
                {
                    { 68, "EquipementConstant", 8.66m, 7, "Cuves à débrasquer" },
                    { 58, "EquipementConstant", 0.74m, 6, "Moulage et refroisissement" },
                    { 47, "EquipementConstant", 1.98m, 5, "Cuves à débrasquer" },
                    { 44, "EquipementConstant", 0.037m, 5, "Réfection des cuves" },
                    { 35, "EquipementConstant", 2.54m, 4, "Cuves à débrasquer" },
                    { 31, "EquipementConstant", 0.862m, 4, "Réfection des cuves" },
                    { 20, "EquipementConstant", 0.59m, 3, "Moulage et refroisissement" },
                    { 19, "EquipementConstant", 1.25m, 3, "Cuves à débrasquer" },
                    { 15, "EquipementConstant", 0.0154m, 3, "Réfection des cuves" },
                    { 66, "EquipementConstant", 1.24m, 7, "Réfection des cuves" }
                });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "Discriminator", "GroupeId", "Maximum", "Minimum", "Nom" },
                values: new object[] { 85, "EquipementRelatif", 8, 24.9m, 8.98m, "Broyeur humide" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "Discriminator", "FacteurConversion", "GroupeId", "Nom", "UniteMesure" },
                values: new object[,]
                {
                    { 9, "EquipementLineaire", 0.00000854m, 2, "Leaf 3", "km" },
                    { 14, "EquipementLineaire", 0.0987m, 3, "Centrale hydroélectrique", "MWh" },
                    { 67, "EquipementLineaire", 0.87m, 7, "Centre de coulée", "coulées" },
                    { 65, "EquipementLineaire", 0.124m, 7, "Centrale hydroélectrique", "MWh" },
                    { 63, "EquipementLineaire", 0.00098m, 7, "Transport ferroviaire", "km" },
                    { 59, "EquipementLineaire", 6.87m, 6, "Concasseur", "t" },
                    { 57, "EquipementLineaire", 0.85m, 6, "Centre de coulée", "coulées" },
                    { 52, "EquipementLineaire", 0.00098m, 6, "Transport ferroviaire", "km" },
                    { 48, "EquipementLineaire", 4.98m, 5, "Concasseur", "t" },
                    { 46, "EquipementLineaire", 0.23m, 5, "Centre de coulée", "coulées" },
                    { 10, "EquipementLineaire", 0.00098m, 3, "Transport ferroviaire", "km" },
                    { 45, "EquipementLineaire", 0.00087m, 5, "Scies", "unités" },
                    { 40, "EquipementLineaire", 0.00098m, 5, "Transport ferroviaire", "km" },
                    { 34, "EquipementLineaire", 0.68m, 4, "Centre de coulée", "coulées" },
                    { 32, "EquipementLineaire", 0.00048m, 4, "Scies", "unités" },
                    { 30, "EquipementLineaire", 0.0987m, 4, "Centrale hydroélectrique", "MWh" },
                    { 26, "EquipementLineaire", 0.00098m, 4, "Transport ferroviaire", "km" },
                    { 21, "EquipementLineaire", 4.55m, 3, "Concasseur", "t" },
                    { 18, "EquipementLineaire", 0.47m, 3, "Centre de coulée", "coulées" },
                    { 16, "EquipementLineaire", 0.00048m, 3, "Scies", "unités" }
                });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "Discriminator", "FacteurConversion", "GroupeId", "Nom", "UniteMesure" },
                values: new object[] { 43, "EquipementLineaire", 0.0987m, 5, "Centrale hydroélectrique", "MWh" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "Discriminator", "GroupeId", "Maximum", "Minimum", "Nom" },
                values: new object[] { 86, "EquipementRelatif", 8, 3.413m, 1.311m, "Filtreurs" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Equipements",
                keyColumn: "Id",
                keyValue: 86);
        }
    }
}
