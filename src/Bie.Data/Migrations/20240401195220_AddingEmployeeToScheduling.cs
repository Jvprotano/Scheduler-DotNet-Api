using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bie.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingEmployeeToScheduling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "company_employeers");

            migrationBuilder.RenameColumn(
                name: "scheduled_time",
                table: "schedulings",
                newName: "time");

            migrationBuilder.RenameColumn(
                name: "scheduled_date",
                table: "schedulings",
                newName: "date");

            migrationBuilder.AddColumn<string>(
                name: "employee_id",
                table: "schedulings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "company_employees",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    company_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    is_owner = table.Column<bool>(type: "bit", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company_employees", x => x.id);
                    table.ForeignKey(
                        name: "FK_company_employees_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_company_employees_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_schedulings_employee_id",
                table: "schedulings",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_company_employees_company_id",
                table: "company_employees",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_company_employees_user_id",
                table: "company_employees",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_schedulings_AspNetUsers_employee_id",
                table: "schedulings",
                column: "employee_id",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schedulings_AspNetUsers_employee_id",
                table: "schedulings");

            migrationBuilder.DropTable(
                name: "company_employees");

            migrationBuilder.DropIndex(
                name: "IX_schedulings_employee_id",
                table: "schedulings");

            migrationBuilder.DropColumn(
                name: "employee_id",
                table: "schedulings");

            migrationBuilder.RenameColumn(
                name: "time",
                table: "schedulings",
                newName: "scheduled_time");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "schedulings",
                newName: "scheduled_date");

            migrationBuilder.CreateTable(
                name: "company_employeers",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    company_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_owner = table.Column<bool>(type: "bit", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company_employeers", x => x.id);
                    table.ForeignKey(
                        name: "FK_company_employeers_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_company_employeers_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_company_employeers_company_id",
                table: "company_employeers",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_company_employeers_user_id",
                table: "company_employeers",
                column: "user_id");
        }
    }
}
