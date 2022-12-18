using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CEGES_DataAccess.Migrations
{
    public partial class SeedPeriode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Periodes",
                columns: new[] { "Id", "Debut", "EntrepriseId", "Fin", "Nom" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juillet 2020" },
                    { 30, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Août 2021" },
                    { 29, new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juillet 2021" },
                    { 28, new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juin 2021" },
                    { 27, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mai 2021" },
                    { 26, new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avril 2021" },
                    { 25, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mars 2021" },
                    { 24, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Février 2021" },
                    { 23, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Janvier 2021" },
                    { 22, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Décembre 2020" },
                    { 21, new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2020, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Novembre 2020" },
                    { 20, new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Octobre 2020" },
                    { 19, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2020, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Septembre 2020" },
                    { 18, new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2020, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Août 2020" },
                    { 17, new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2020, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juillet 2020" },
                    { 16, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Octobre 2021" },
                    { 15, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Septembre 2021" },
                    { 14, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Août 2021" },
                    { 13, new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juillet 2021" },
                    { 12, new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juin 2021" },
                    { 11, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mai 2021" },
                    { 10, new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avril 2021" },
                    { 9, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mars 2021" },
                    { 8, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Février 2021" },
                    { 7, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Janvier 2021" },
                    { 6, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Décembre 2020" },
                    { 5, new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Novembre 2020" },
                    { 4, new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Octobre 2020" },
                    { 3, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Septembre 2020" },
                    { 2, new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Août 2020" },
                    { 31, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Septembre 2021" },
                    { 32, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Octobre 2021" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Periodes",
                keyColumn: "Id",
                keyValue: 32);
        }
    }
}
