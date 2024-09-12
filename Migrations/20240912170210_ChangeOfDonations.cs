using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PowHome.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOfDonations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_adoption_centers_donations_DonationsId",
                table: "adoption_centers");

            migrationBuilder.DropTable(
                name: "donations");

            migrationBuilder.DropIndex(
                name: "IX_adoption_centers_DonationsId",
                table: "adoption_centers");

            migrationBuilder.DropColumn(
                name: "DonationsId",
                table: "adoption_centers");

            migrationBuilder.CreateTable(
                name: "food_Donations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DayOfDonation = table.Column<DateOnly>(type: "date", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    AdoptionCenterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_food_Donations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_food_Donations_adoption_centers_AdoptionCenterId",
                        column: x => x.AdoptionCenterId,
                        principalTable: "adoption_centers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_food_Donations_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_food_Donations_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "money_donations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(type: "double", nullable: false),
                    DayOfDonation = table.Column<DateOnly>(type: "date", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AdoptionCenterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_money_donations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_money_donations_adoption_centers_AdoptionCenterId",
                        column: x => x.AdoptionCenterId,
                        principalTable: "adoption_centers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_money_donations_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_food_Donations_AdoptionCenterId",
                table: "food_Donations",
                column: "AdoptionCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_food_Donations_ProductId",
                table: "food_Donations",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_food_Donations_UserId",
                table: "food_Donations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_money_donations_AdoptionCenterId",
                table: "money_donations",
                column: "AdoptionCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_money_donations_UserId",
                table: "money_donations",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "food_Donations");

            migrationBuilder.DropTable(
                name: "money_donations");

            migrationBuilder.AddColumn<int>(
                name: "DonationsId",
                table: "adoption_centers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "donations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "double", nullable: false),
                    DayOfDonation = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_donations_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_adoption_centers_DonationsId",
                table: "adoption_centers",
                column: "DonationsId");

            migrationBuilder.CreateIndex(
                name: "IX_donations_UserId",
                table: "donations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_adoption_centers_donations_DonationsId",
                table: "adoption_centers",
                column: "DonationsId",
                principalTable: "donations",
                principalColumn: "Id");
        }
    }
}
