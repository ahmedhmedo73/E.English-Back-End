using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gp1.Migrations
{
    public partial class AddCategoryRelationWithVideos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "section",
                table: "videos");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "videos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_videos_CategoryId",
                table: "videos",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_videos_Categories_CategoryId",
                table: "videos",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videos_Categories_CategoryId",
                table: "videos");

            migrationBuilder.DropIndex(
                name: "IX_videos_CategoryId",
                table: "videos");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "videos");

            migrationBuilder.AddColumn<string>(
                name: "section",
                table: "videos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
