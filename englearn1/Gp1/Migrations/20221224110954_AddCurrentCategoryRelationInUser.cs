using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gp1.Migrations
{
    public partial class AddCurrentCategoryRelationInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentCategoryId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CurrentCategoryId",
                table: "AspNetUsers",
                column: "CurrentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Categories_CurrentCategoryId",
                table: "AspNetUsers",
                column: "CurrentCategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Categories_CurrentCategoryId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CurrentCategoryId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CurrentCategoryId",
                table: "AspNetUsers");
        }
    }
}
