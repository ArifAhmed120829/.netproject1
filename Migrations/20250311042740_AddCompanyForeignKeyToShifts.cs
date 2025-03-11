using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sql_training.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyForeignKeyToShifts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Use raw SQL with IF EXISTS for the Designations table constraint
            migrationBuilder.Sql("ALTER TABLE \"Designations\" DROP CONSTRAINT IF EXISTS \"FK_Designations_Companies_CompanyComId\";");
            migrationBuilder.Sql("ALTER TABLE \"Shifts\" DROP CONSTRAINT IF EXISTS \"FK_Shifts_Companies_CompanyComId\";");
            migrationBuilder.Sql("DROP INDEX IF EXISTS \"IX_Shifts_CompanyComId\";");


            

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_ComId",
                table: "Shifts",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_ComId",
                table: "Designations",
                column: "ComId");

            migrationBuilder.AddForeignKey(
                name: "FK_Designations_Companies_ComId",
                table: "Designations",
                column: "ComId",
                principalTable: "Companies",
                principalColumn: "ComId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_Companies_ComId",
                table: "Shifts",
                column: "ComId",
                principalTable: "Companies",
                principalColumn: "ComId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Designations_Companies_ComId",
                table: "Designations");

            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_Companies_ComId",
                table: "Shifts");

            migrationBuilder.DropIndex(
                name: "IX_Shifts_ComId",
                table: "Shifts");

            migrationBuilder.DropIndex(
                name: "IX_Designations_ComId",
                table: "Designations");

            migrationBuilder.AddColumn<int>(
                name: "CompanyComId",
                table: "Shifts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyComId",
                table: "Designations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_CompanyComId",
                table: "Shifts",
                column: "CompanyComId");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_CompanyComId",
                table: "Designations",
                column: "CompanyComId");

            migrationBuilder.AddForeignKey(
                name: "FK_Designations_Companies_CompanyComId",
                table: "Designations",
                column: "CompanyComId",
                principalTable: "Companies",
                principalColumn: "ComId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_Companies_CompanyComId",
                table: "Shifts",
                column: "CompanyComId",
                principalTable: "Companies",
                principalColumn: "ComId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
