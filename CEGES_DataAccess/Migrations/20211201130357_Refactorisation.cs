using Microsoft.EntityFrameworkCore.Migrations;

namespace CEGES_DataAccess.Migrations
{
    public partial class Refactorisation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mesures_Equipement_EquipementId",
                table: "Mesures");

            migrationBuilder.DropTable(
                name: "Equipement");

            migrationBuilder.CreateTable(
                name: "Equipements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupeId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emissions = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    FacteurConversion = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    UniteMesure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Minimum = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    Maximum = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipements_Groupes_GroupeId",
                        column: x => x.GroupeId,
                        principalTable: "Groupes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipements_GroupeId",
                table: "Equipements",
                column: "GroupeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mesures_Equipements_EquipementId",
                table: "Mesures",
                column: "EquipementId",
                principalTable: "Equipements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mesures_Equipements_EquipementId",
                table: "Mesures");

            migrationBuilder.DropTable(
                name: "Equipements");

            migrationBuilder.CreateTable(
                name: "Equipement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupeId = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emissions = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    FacteurConversion = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    UniteMesure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Maximum = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true),
                    Minimum = table.Column<decimal>(type: "decimal(20,10)", precision: 20, scale: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipement_Groupes_GroupeId",
                        column: x => x.GroupeId,
                        principalTable: "Groupes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipement_GroupeId",
                table: "Equipement",
                column: "GroupeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mesures_Equipement_EquipementId",
                table: "Mesures",
                column: "EquipementId",
                principalTable: "Equipement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
