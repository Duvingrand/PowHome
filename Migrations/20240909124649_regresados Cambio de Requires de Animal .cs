using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PowHome.Migrations
{
    /// <inheritdoc />
    public partial class regresadosCambiodeRequiresdeAnimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_animals_adoption_centers_AdoptionCenterID",
                table: "animals");

            migrationBuilder.DropForeignKey(
                name: "FK_animals_species_SpecieID",
                table: "animals");

            migrationBuilder.AlterColumn<int>(
                name: "SpecieID",
                table: "animals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "animals",
                keyColumn: "Breed",
                keyValue: null,
                column: "Breed",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Breed",
                table: "animals",
                type: "varchar(225)",
                maxLength: 225,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(225)",
                oldMaxLength: 225,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "BirthDate",
                table: "animals",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdoptionCenterID",
                table: "animals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_animals_adoption_centers_AdoptionCenterID",
                table: "animals",
                column: "AdoptionCenterID",
                principalTable: "adoption_centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_animals_species_SpecieID",
                table: "animals",
                column: "SpecieID",
                principalTable: "species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_animals_adoption_centers_AdoptionCenterID",
                table: "animals");

            migrationBuilder.DropForeignKey(
                name: "FK_animals_species_SpecieID",
                table: "animals");

            migrationBuilder.AlterColumn<int>(
                name: "SpecieID",
                table: "animals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Breed",
                table: "animals",
                type: "varchar(225)",
                maxLength: 225,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(225)",
                oldMaxLength: 225)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "BirthDate",
                table: "animals",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<int>(
                name: "AdoptionCenterID",
                table: "animals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_animals_adoption_centers_AdoptionCenterID",
                table: "animals",
                column: "AdoptionCenterID",
                principalTable: "adoption_centers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_animals_species_SpecieID",
                table: "animals",
                column: "SpecieID",
                principalTable: "species",
                principalColumn: "Id");
        }
    }
}
