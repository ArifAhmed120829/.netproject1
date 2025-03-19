using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sql_training.Migrations
{
    /// <inheritdoc />
    public partial class s11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Companies_CompanyComId",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_CompanyComId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "CompanyComId",
                table: "Attendances");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyComId",
                table: "Attendances",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_CompanyComId",
                table: "Attendances",
                column: "CompanyComId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Companies_CompanyComId",
                table: "Attendances",
                column: "CompanyComId",
                principalTable: "Companies",
                principalColumn: "ComId");
        }
    }
}
