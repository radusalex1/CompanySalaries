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
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfObjectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfTask = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfObjectives", x => x.Id);
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
                    Day4 = table.Column<int>(type: "int", nullable: false),
                    TotalSalaryPerWeek = table.Column<int>(type: "int", nullable: false)
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
                name: "Objectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfObjectiveId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Objectives_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Objectives_TypeOfObjectives_TypeOfObjectiveId",
                        column: x => x.TypeOfObjectiveId,
                        principalTable: "TypeOfObjectives",
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
                    ObjectiveId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                        name: "FK_EmployeesTask_Objectives_ObjectiveId",
                        column: x => x.ObjectiveId,
                        principalTable: "Objectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesTask_EmployeeId",
                table: "EmployeesTask",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesTask_ObjectiveId",
                table: "EmployeesTask",
                column: "ObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesWorkingWeek_EmployeeId",
                table: "EmployeesWorkingWeek",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Objectives_ProjectId",
                table: "Objectives",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Objectives_TypeOfObjectiveId",
                table: "Objectives",
                column: "TypeOfObjectiveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeesTask");

            migrationBuilder.DropTable(
                name: "EmployeesWorkingWeek");

            migrationBuilder.DropTable(
                name: "Objectives");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "TypeOfObjectives");
        }
    }
}
