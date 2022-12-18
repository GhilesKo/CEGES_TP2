using Microsoft.EntityFrameworkCore.Migrations;

namespace CEGES_DataAccess.Migrations
{
    public partial class Equipements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupeId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emissions = table.Column<decimal>(type: "decimal(10,10)", precision: 10, scale: 10, nullable: true),
                    UniteMesure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacteurConversion = table.Column<decimal>(type: "decimal(10,10)", precision: 10, scale: 10, nullable: true),
                    Minimum = table.Column<decimal>(type: "decimal(10,10)", precision: 10, scale: 10, nullable: true),
                    Maximum = table.Column<decimal>(type: "decimal(10,10)", precision: 10, scale: 10, nullable: true)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipement");
        }
    }
}
