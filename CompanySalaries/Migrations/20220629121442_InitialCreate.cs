using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanySalaries.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalaryPerHour = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TasksWork",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksWork", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesWorkingWeek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    StartWeek = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Day0 = table.Column<int>(type: "int", nullable: false),
                    Day1 = table.Column<int>(type: "int", nullable: false),
                    Day2 = table.Column<int>(type: "int", nullable: false),
                    Day3 = table.Column<int>(type: "int", nullable: false),
                    Day4 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesWorkingWeek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeesWorkingWeek_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TaskWorkId = table.Column<int>(type: "int", nullable: false),
                    WorkedHoursOnTask = table.Column<int>(type: "int", nullable: false),
                    Done = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeesTask_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeesTask_TasksWork_TaskWorkId",
                        column: x => x.TaskWorkId,
                        principalTable: "TasksWork",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesTask_EmployeeId",
                table: "EmployeesTask",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesTask_TaskWorkId",
                table: "EmployeesTask",
                column: "TaskWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesWorkingWeek_EmployeeId",
                table: "EmployeesWorkingWeek",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeesTask");

            migrationBuilder.DropTable(
                name: "EmployeesWorkingWeek");

            migrationBuilder.DropTable(
                name: "TasksWork");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
