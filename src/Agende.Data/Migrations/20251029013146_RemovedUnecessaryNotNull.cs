using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agende.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUnecessaryNotNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "auto_generated_image",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "image_prompt",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "birth_date",
                table: "AspNetUsers",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "birth_date",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "auto_generated_image",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "image_prompt",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
        }
    }
}
