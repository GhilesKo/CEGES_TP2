using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CEGES_DataAccess.Migrations
{
    public partial class MesuresEtPeriodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Periodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Debut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mesures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipementId = table.Column<int>(type: "int", nullable: false),
                    PeriodeId = table.Column<int>(type: "int", nullable: false),
                    Valeur = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mesures_Equipement_EquipementId",
                        column: x => x.EquipementId,
                        principalTable: "Equipement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mesures_Periodes_PeriodeId",
                        column: x => x.PeriodeId,
                        principalTable: "Periodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mesures_EquipementId",
                table: "Mesures",
                column: "EquipementId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesures_PeriodeId",
                table: "Mesures",
                column: "PeriodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mesures");

            migrationBuilder.DropTable(
                name: "Periodes");
        }
    }
}
