using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sql_training.Migrations
{
    /// <inheritdoc />
    public partial class sol1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance");

            migrationBuilder.AddColumn<int>(
                name: "ComId",
                table: "Attendance",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance",
                columns: new[] { "EmpId", "Date", "ComId" });

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_ComId",
                table: "Attendance",
                column: "ComId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Companies_ComId",
                table: "Attendance",
                column: "ComId",
                principalTable: "Companies",
                principalColumn: "ComId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Companies_ComId",
                table: "Attendance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance");

            migrationBuilder.DropIndex(
                name: "IX_Attendance_ComId",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "ComId",
                table: "Attendance");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance",
                columns: new[] { "EmpId", "Date" });
        }
    }
}
