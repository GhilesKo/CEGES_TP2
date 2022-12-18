using Microsoft.EntityFrameworkCore.Migrations;

namespace CEGES_DataAccess.Migrations
{
    public partial class PeriodeEntreprise_PrecisionMesure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EntrepriseId",
                table: "Periodes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "Periodes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Periodes_EntrepriseId",
                table: "Periodes",
                column: "EntrepriseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Periodes_Entreprises_EntrepriseId",
                table: "Periodes",
                column: "EntrepriseId",
                principalTable: "Entreprises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Periodes_Entreprises_EntrepriseId",
                table: "Periodes");

            migrationBuilder.DropIndex(
                name: "IX_Periodes_EntrepriseId",
                table: "Periodes");

            migrationBuilder.DropColumn(
                name: "EntrepriseId",
                table: "Periodes");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "Periodes");
        }
    }
}
