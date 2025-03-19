using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sql_training.Migrations
{
    /// <inheritdoc />
    public partial class s4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Companies_ComId",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Employees_EmpId",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceSummary_Companies_ComId",
                table: "AttendanceSummary");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceSummary_Employees_EmpId",
                table: "AttendanceSummary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttendanceSummary",
                table: "AttendanceSummary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance");

            migrationBuilder.RenameTable(
                name: "AttendanceSummary",
                newName: "AttendanceSummaries");

            migrationBuilder.RenameTable(
                name: "Attendance",
                newName: "Attendances");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceSummary_Year_Month_EmpId",
                table: "AttendanceSummaries",
                newName: "IX_AttendanceSummaries_Year_Month_EmpId");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceSummary_ComId",
                table: "AttendanceSummaries",
                newName: "IX_AttendanceSummaries_ComId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_ComId",
                table: "Attendances",
                newName: "IX_Attendances_ComId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttendanceSummaries",
                table: "AttendanceSummaries",
                columns: new[] { "EmpId", "Year", "Month" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances",
                columns: new[] { "EmpId", "Date", "ComId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Companies_ComId",
                table: "Attendances",
                column: "ComId",
                principalTable: "Companies",
                principalColumn: "ComId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Employees_EmpId",
                table: "Attendances",
                column: "EmpId",
                principalTable: "Employees",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceSummaries_Companies_ComId",
                table: "AttendanceSummaries",
                column: "ComId",
                principalTable: "Companies",
                principalColumn: "ComId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceSummaries_Employees_EmpId",
                table: "AttendanceSummaries",
                column: "EmpId",
                principalTable: "Employees",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Companies_ComId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Employees_EmpId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceSummaries_Companies_ComId",
                table: "AttendanceSummaries");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceSummaries_Employees_EmpId",
                table: "AttendanceSummaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttendanceSummaries",
                table: "AttendanceSummaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances");

            migrationBuilder.RenameTable(
                name: "AttendanceSummaries",
                newName: "AttendanceSummary");

            migrationBuilder.RenameTable(
                name: "Attendances",
                newName: "Attendance");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceSummaries_Year_Month_EmpId",
                table: "AttendanceSummary",
                newName: "IX_AttendanceSummary_Year_Month_EmpId");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceSummaries_ComId",
                table: "AttendanceSummary",
                newName: "IX_AttendanceSummary_ComId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_ComId",
                table: "Attendance",
                newName: "IX_Attendance_ComId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttendanceSummary",
                table: "AttendanceSummary",
                columns: new[] { "EmpId", "Year", "Month" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance",
                columns: new[] { "EmpId", "Date", "ComId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Companies_ComId",
                table: "Attendance",
                column: "ComId",
                principalTable: "Companies",
                principalColumn: "ComId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Employees_EmpId",
                table: "Attendance",
                column: "EmpId",
                principalTable: "Employees",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceSummary_Companies_ComId",
                table: "AttendanceSummary",
                column: "ComId",
                principalTable: "Companies",
                principalColumn: "ComId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceSummary_Employees_EmpId",
                table: "AttendanceSummary",
                column: "EmpId",
                principalTable: "Employees",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
