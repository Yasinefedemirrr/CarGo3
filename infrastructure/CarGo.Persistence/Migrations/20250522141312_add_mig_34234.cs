using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarGo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_mig_34234 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Feature",
                table: "CarFeatures");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Feature",
                table: "CarFeatures",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
