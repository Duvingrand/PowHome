using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PowHome.Migrations
{
    /// <inheritdoc />
    public partial class CambiodeRequiresdeAnimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_animals_adoption_centers_AdoptionCenterID",
                table: "animals");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_animals_adoption_centers_AdoptionCenterID",
                table: "animals");

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
        }
    }
}
