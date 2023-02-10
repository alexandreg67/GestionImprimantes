using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionImprimantes.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Printers_Locations_LocationId",
                table: "Printers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Printers",
                table: "Printers");

            migrationBuilder.RenameTable(
                name: "Printers",
                newName: "Commun");

            migrationBuilder.RenameIndex(
                name: "IX_Printers_LocationId",
                table: "Commun",
                newName: "IX_Commun_LocationId");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Commun",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Adresse",
                table: "Commun",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodePostal",
                table: "Commun",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Commun",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ville",
                table: "Commun",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commun",
                table: "Commun",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commun_Commun_LocationId",
                table: "Commun",
                column: "LocationId",
                principalTable: "Commun",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commun_Commun_LocationId",
                table: "Commun");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commun",
                table: "Commun");

            migrationBuilder.DropColumn(
                name: "Adresse",
                table: "Commun");

            migrationBuilder.DropColumn(
                name: "CodePostal",
                table: "Commun");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Commun");

            migrationBuilder.DropColumn(
                name: "Ville",
                table: "Commun");

            migrationBuilder.RenameTable(
                name: "Commun",
                newName: "Printers");

            migrationBuilder.RenameIndex(
                name: "IX_Commun_LocationId",
                table: "Printers",
                newName: "IX_Printers_LocationId");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Printers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Printers",
                table: "Printers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodePostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDeCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDeModification = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDeSuppression = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Printers_Locations_LocationId",
                table: "Printers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
