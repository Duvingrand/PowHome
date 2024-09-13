using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PowHome.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOfDonations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_money_donations_adoption_centers_AdoptionCenterId",
                table: "money_donations");

            migrationBuilder.AlterColumn<int>(
                name: "AdoptionCenterId",
                table: "money_donations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_money_donations_adoption_centers_AdoptionCenterId",
                table: "money_donations",
                column: "AdoptionCenterId",
                principalTable: "adoption_centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_money_donations_adoption_centers_AdoptionCenterId",
                table: "money_donations");

            migrationBuilder.AlterColumn<int>(
                name: "AdoptionCenterId",
                table: "money_donations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_money_donations_adoption_centers_AdoptionCenterId",
                table: "money_donations",
                column: "AdoptionCenterId",
                principalTable: "adoption_centers",
                principalColumn: "Id");
        }
    }
}
