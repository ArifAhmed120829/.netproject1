using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sql_training.Migrations
{
    /// <inheritdoc />
    public partial class Correction10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Intime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Outtime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    EmployeeEmpId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => new { x.EmpId, x.Date });
                    table.ForeignKey(
                        name: "FK_Attendance_Employees_EmployeeEmpId",
                        column: x => x.EmployeeEmpId,
                        principalTable: "Employees",
                        principalColumn: "EmpId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_EmployeeEmpId",
                table: "Attendance",
                column: "EmployeeEmpId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendance");
        }
    }
}
