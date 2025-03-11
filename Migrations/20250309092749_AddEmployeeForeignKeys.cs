using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sql_training.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companies_CompanyComId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentDeptId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Designations_DesignationDesigId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CompanyComId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmentDeptId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DesignationDesigId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CompanyComId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentDeptId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DesignationDesigId",
                table: "Employees");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ComId",
                table: "Employees",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DeptId",
                table: "Employees",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DesigId",
                table: "Employees",
                column: "DesigId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Companies_ComId",
                table: "Employees",
                column: "ComId",
                principalTable: "Companies",
                principalColumn: "ComId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DeptId",
                table: "Employees",
                column: "DeptId",
                principalTable: "Departments",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Designations_DesigId",
                table: "Employees",
                column: "DesigId",
                principalTable: "Designations",
                principalColumn: "DesigId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companies_ComId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DeptId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Designations_DesigId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ComId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DeptId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DesigId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "CompanyComId",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentDeptId",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DesignationDesigId",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyComId",
                table: "Employees",
                column: "CompanyComId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentDeptId",
                table: "Employees",
                column: "DepartmentDeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DesignationDesigId",
                table: "Employees",
                column: "DesignationDesigId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Companies_CompanyComId",
                table: "Employees",
                column: "CompanyComId",
                principalTable: "Companies",
                principalColumn: "ComId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentDeptId",
                table: "Employees",
                column: "DepartmentDeptId",
                principalTable: "Departments",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Designations_DesignationDesigId",
                table: "Employees",
                column: "DesignationDesigId",
                principalTable: "Designations",
                principalColumn: "DesigId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
