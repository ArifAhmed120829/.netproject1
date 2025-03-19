using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sql_training.Migrations
{
    /// <inheritdoc />
    public partial class s51 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "integer", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Month = table.Column<int>(type: "integer", nullable: false),
                    ComId = table.Column<int>(type: "integer", nullable: false),
                    Gross = table.Column<int>(type: "integer", nullable: false),
                    basic = table.Column<int>(type: "integer", nullable: false),
                    HRent = table.Column<int>(type: "integer", nullable: false),
                    Medical = table.Column<int>(type: "integer", nullable: false),
                    AbsentAmount = table.Column<int>(type: "integer", nullable: false),
                    PayableAmount = table.Column<int>(type: "integer", nullable: false),
                    isPaid = table.Column<int>(type: "integer", nullable: false),
                    PaidAmount = table.Column<int>(type: "integer", nullable: false),
                    EmployeeEmpId = table.Column<int>(type: "integer", nullable: true),
                    CompanyComId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => new { x.EmpId, x.Year, x.Month });
                    table.ForeignKey(
                        name: "FK_Salaries_Companies_CompanyComId",
                        column: x => x.CompanyComId,
                        principalTable: "Companies",
                        principalColumn: "ComId");
                    table.ForeignKey(
                        name: "FK_Salaries_Employees_EmployeeEmpId",
                        column: x => x.EmployeeEmpId,
                        principalTable: "Employees",
                        principalColumn: "EmpId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_CompanyComId",
                table: "Salaries",
                column: "CompanyComId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_EmployeeEmpId",
                table: "Salaries",
                column: "EmployeeEmpId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Salaries");
        }
    }
}
