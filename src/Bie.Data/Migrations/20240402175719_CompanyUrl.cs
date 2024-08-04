using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bie.Data.Migrations
{
    /// <inheritdoc />
    public partial class CompanyUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "scheduling_url",
                table: "companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "scheduling_url",
                table: "companies");
        }
    }
}
