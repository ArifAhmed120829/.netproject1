using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sql_training.Migrations
{
    /// <inheritdoc />
    public partial class s13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyComId",
                table: "AttendanceSummaries",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceSummaries_CompanyComId",
                table: "AttendanceSummaries",
                column: "CompanyComId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceSummaries_Companies_CompanyComId",
                table: "AttendanceSummaries",
                column: "CompanyComId",
                principalTable: "Companies",
                principalColumn: "ComId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceSummaries_Companies_CompanyComId",
                table: "AttendanceSummaries");

            migrationBuilder.DropIndex(
                name: "IX_AttendanceSummaries_CompanyComId",
                table: "AttendanceSummaries");

            migrationBuilder.DropColumn(
                name: "CompanyComId",
                table: "AttendanceSummaries");
        }
    }
}
