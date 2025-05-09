using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarGo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenamepricingToCarPricing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pricing",
                table: "CarPricing");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pricing",
                table: "CarPricing",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
