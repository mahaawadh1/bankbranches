using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployees1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_BankBranches_BankBranchId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "BankBranchId",
                table: "Employees",
                newName: "BankBranchEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_BankBranchId",
                table: "Employees",
                newName: "IX_Employees_BankBranchEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_BankBranches_BankBranchEmployeeId",
                table: "Employees",
                column: "BankBranchEmployeeId",
                principalTable: "BankBranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_BankBranches_BankBranchEmployeeId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "BankBranchEmployeeId",
                table: "Employees",
                newName: "BankBranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_BankBranchEmployeeId",
                table: "Employees",
                newName: "IX_Employees_BankBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_BankBranches_BankBranchId",
                table: "Employees",
                column: "BankBranchId",
                principalTable: "BankBranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
