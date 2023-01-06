using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gp1.Migrations
{
    public partial class AddCurrentVideoRelationInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentVideoId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CurrentVideoId",
                table: "AspNetUsers",
                column: "CurrentVideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_videos_CurrentVideoId",
                table: "AspNetUsers",
                column: "CurrentVideoId",
                principalTable: "videos",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_videos_CurrentVideoId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CurrentVideoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CurrentVideoId",
                table: "AspNetUsers");
        }
    }
}
