using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sql_training.Migrations
{
    /// <inheritdoc />
    public partial class CreateAttendanceSummaryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttendanceSummary",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "integer", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Month = table.Column<int>(type: "integer", nullable: false),
                    ComId = table.Column<int>(type: "integer", nullable: false),
                    TotalAbsents = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceSummary", x => new { x.EmpId, x.Year, x.Month });
                    table.ForeignKey(
                        name: "FK_AttendanceSummary_Companies_ComId",
                        column: x => x.ComId,
                        principalTable: "Companies",
                        principalColumn: "ComId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendanceSummary_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceSummary_ComId",
                table: "AttendanceSummary",
                column: "ComId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendanceSummary");
        }
    }
}
