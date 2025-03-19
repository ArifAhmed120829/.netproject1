using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sql_training.Migrations
{
    /// <inheritdoc />
    public partial class FixAttendanceForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Employees_EmployeeEmpId",
                table: "Attendance");

            migrationBuilder.DropIndex(
                name: "IX_Attendance_EmployeeEmpId",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "EmployeeEmpId",
                table: "Attendance");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Employees_EmpId",
                table: "Attendance",
                column: "EmpId",
                principalTable: "Employees",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Employees_EmpId",
                table: "Attendance");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeEmpId",
                table: "Attendance",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_EmployeeEmpId",
                table: "Attendance",
                column: "EmployeeEmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Employees_EmployeeEmpId",
                table: "Attendance",
                column: "EmployeeEmpId",
                principalTable: "Employees",
                principalColumn: "EmpId");
        }
    }
}
