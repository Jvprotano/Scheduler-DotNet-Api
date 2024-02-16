using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bie.Data.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "companies_owners");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "scheduled_date",
                table: "schedulings",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "scheduled_time",
                table: "schedulings",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<DateTime>(
                name: "inactive_date",
                table: "companies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "company_employeers",
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

            migrationBuilder.CreateTable(
                name: "employee_services",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    employee_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    service_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_services", x => x.id);
                    table.ForeignKey(
                        name: "FK_employee_services_AspNetUsers_employee_id",
                        column: x => x.employee_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employee_services_companies_services_offered_service_id",
                        column: x => x.service_id,
                        principalTable: "companies_services_offered",
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

            migrationBuilder.CreateIndex(
                name: "IX_employee_services_employee_id",
                table: "employee_services",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_services_service_id",
                table: "employee_services",
                column: "service_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "company_employeers");

            migrationBuilder.DropTable(
                name: "employee_services");

            migrationBuilder.DropColumn(
                name: "scheduled_time",
                table: "schedulings");

            migrationBuilder.DropColumn(
                name: "inactive_date",
                table: "companies");

            migrationBuilder.AlterColumn<DateTime>(
                name: "scheduled_date",
                table: "schedulings",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.CreateTable(
                name: "companies_owners",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    company_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies_owners", x => x.id);
                    table.ForeignKey(
                        name: "FK_companies_owners_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_companies_owners_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_companies_owners_company_id",
                table: "companies_owners",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_companies_owners_user_id",
                table: "companies_owners",
                column: "user_id");
        }
    }
}
