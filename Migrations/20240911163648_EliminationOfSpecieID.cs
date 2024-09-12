using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PowHome.Migrations
{
    /// <inheritdoc />
    public partial class EliminationOfSpecieID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecieID",
                table: "animals");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecieID",
                table: "animals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
