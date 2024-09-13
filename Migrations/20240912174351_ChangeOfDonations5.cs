using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PowHome.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOfDonations5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfDonation",
                table: "food_Donations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DayOfDonation",
                table: "food_Donations",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
