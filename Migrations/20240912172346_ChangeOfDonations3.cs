using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PowHome.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOfDonations3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_money_donations_adoption_centers_AdoptionCenterId",
                table: "money_donations");

            migrationBuilder.DropForeignKey(
                name: "FK_money_donations_users_UserId",
                table: "money_donations");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "money_donations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_money_donations_users_UserId",
                table: "money_donations",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_money_donations_adoption_centers_AdoptionCenterId",
                table: "money_donations");

            migrationBuilder.DropForeignKey(
                name: "FK_money_donations_users_UserId",
                table: "money_donations");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "money_donations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_money_donations_users_UserId",
                table: "money_donations",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
