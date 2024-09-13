using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PowHome.Migrations
{
    /// <inheritdoc />
    public partial class EliminationOfSpecie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_animals_species_SpecieID",
                table: "animals");

            migrationBuilder.DropTable(
                name: "species");

            migrationBuilder.DropIndex(
                name: "IX_animals_SpecieID",
                table: "animals");

            migrationBuilder.AddColumn<bool>(
                name: "Specie",
                table: "animals",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specie",
                table: "animals");

            migrationBuilder.CreateTable(
                name: "species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_species", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_animals_SpecieID",
                table: "animals",
                column: "SpecieID");

            migrationBuilder.AddForeignKey(
                name: "FK_animals_species_SpecieID",
                table: "animals",
                column: "SpecieID",
                principalTable: "species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
