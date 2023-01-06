using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gp1.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "result",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    videoid = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deleteState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_result", x => x.Id);
                    table.ForeignKey(
                        name: "FK_result_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_result_videos_videoid",
                        column: x => x.videoid,
                        principalTable: "videos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_result_userId",
                table: "result",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_result_videoid",
                table: "result",
                column: "videoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "result");
        }
    }
}
