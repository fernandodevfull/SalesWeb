using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesWebMVC.Migrations
{
    /// <inheritdoc />
    public partial class DepartmentForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Department_DepartmentID",
                table: "Sellers");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "Sellers",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Sellers_DepartmentID",
                table: "Sellers",
                newName: "IX_Sellers_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_Department_DepartmentId",
                table: "Sellers",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Department_DepartmentId",
                table: "Sellers");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Sellers",
                newName: "DepartmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Sellers_DepartmentId",
                table: "Sellers",
                newName: "IX_Sellers_DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_Department_DepartmentID",
                table: "Sellers",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
