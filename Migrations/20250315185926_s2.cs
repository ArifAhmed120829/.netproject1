using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sql_training.Migrations
{
    /// <inheritdoc />
    public partial class s2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AttendanceSummary_Year_Month",
                table: "AttendanceSummary",
                columns: new[] { "Year", "Month" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AttendanceSummary_Year_Month",
                table: "AttendanceSummary");
        }
    }
}
