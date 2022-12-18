using Microsoft.EntityFrameworkCore.Migrations;

namespace CEGES_DataAccess.Migrations
{
    public partial class AnalysteEntreprise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUserEntreprise",
                columns: table => new
                {
                    AnalystesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntreprisesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserEntreprise", x => new { x.AnalystesId, x.EntreprisesId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserEntreprise_AspNetUsers_AnalystesId",
                        column: x => x.AnalystesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserEntreprise_Entreprises_EntreprisesId",
                        column: x => x.EntreprisesId,
                        principalTable: "Entreprises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserEntreprise_EntreprisesId",
                table: "ApplicationUserEntreprise",
                column: "EntreprisesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserEntreprise");
        }
    }
}
