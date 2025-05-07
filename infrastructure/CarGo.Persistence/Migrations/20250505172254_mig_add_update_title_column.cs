using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarGo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_update_title_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Blogs",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        
    }
}
