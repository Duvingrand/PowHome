using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PowHome.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOfDonations4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_food_Donations_adoption_centers_AdoptionCenterId",
                table: "food_Donations");

            migrationBuilder.DropForeignKey(
                name: "FK_food_Donations_products_ProductId",
                table: "food_Donations");

            migrationBuilder.DropForeignKey(
                name: "FK_food_Donations_users_UserId",
                table: "food_Donations");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "food_Donations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "food_Donations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AdoptionCenterId",
                table: "food_Donations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_food_Donations_adoption_centers_AdoptionCenterId",
                table: "food_Donations",
                column: "AdoptionCenterId",
                principalTable: "adoption_centers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_food_Donations_products_ProductId",
                table: "food_Donations",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_food_Donations_users_UserId",
                table: "food_Donations",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_food_Donations_adoption_centers_AdoptionCenterId",
                table: "food_Donations");

            migrationBuilder.DropForeignKey(
                name: "FK_food_Donations_products_ProductId",
                table: "food_Donations");

            migrationBuilder.DropForeignKey(
                name: "FK_food_Donations_users_UserId",
                table: "food_Donations");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "food_Donations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "food_Donations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdoptionCenterId",
                table: "food_Donations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_food_Donations_adoption_centers_AdoptionCenterId",
                table: "food_Donations",
                column: "AdoptionCenterId",
                principalTable: "adoption_centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_food_Donations_products_ProductId",
                table: "food_Donations",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_food_Donations_users_UserId",
                table: "food_Donations",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
