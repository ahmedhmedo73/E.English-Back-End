using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gp1.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_users_UserId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_videos_Videoid",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_questionAnswers_users_UserId",
                table: "questionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_questions_videos_Videoid",
                table: "questions");

            migrationBuilder.DropForeignKey(
                name: "FK_result_users_userId",
                table: "result");

            migrationBuilder.DropForeignKey(
                name: "FK_result_videos_videoid",
                table: "result");

            migrationBuilder.DropForeignKey(
                name: "FK_sentenceAnswers_users_UserId",
                table: "sentenceAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_spokenSentences_videos_Videoid",
                table: "spokenSentences");

            migrationBuilder.DropForeignKey(
                name: "FK_Views_users_UserId",
                table: "Views");

            migrationBuilder.DropForeignKey(
                name: "FK_Views_videos_Videoid",
                table: "Views");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.RenameColumn(
                name: "Videoid",
                table: "Views",
                newName: "VideoId");

            migrationBuilder.RenameIndex(
                name: "IX_Views_Videoid",
                table: "Views",
                newName: "IX_Views_VideoId");

            migrationBuilder.RenameColumn(
                name: "Videoid",
                table: "spokenSentences",
                newName: "VideoId");

            migrationBuilder.RenameIndex(
                name: "IX_spokenSentences_Videoid",
                table: "spokenSentences",
                newName: "IX_spokenSentences_VideoId");

            migrationBuilder.RenameColumn(
                name: "videoid",
                table: "result",
                newName: "videoId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "result",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_result_videoid",
                table: "result",
                newName: "IX_result_videoId");

            migrationBuilder.RenameIndex(
                name: "IX_result_userId",
                table: "result",
                newName: "IX_result_UserId");

            migrationBuilder.RenameColumn(
                name: "Videoid",
                table: "questions",
                newName: "VideoId");

            migrationBuilder.RenameIndex(
                name: "IX_questions_Videoid",
                table: "questions",
                newName: "IX_questions_VideoId");

            migrationBuilder.RenameColumn(
                name: "Videoid",
                table: "comments",
                newName: "VideoId");

            migrationBuilder.RenameIndex(
                name: "IX_comments_Videoid",
                table: "comments",
                newName: "IX_comments_VideoId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Views",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "sentenceAnswers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "result",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "questionAnswers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "comments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_AspNetUsers_UserId",
                table: "comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_videos_VideoId",
                table: "comments",
                column: "VideoId",
                principalTable: "videos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_questionAnswers_AspNetUsers_UserId",
                table: "questionAnswers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_questions_videos_VideoId",
                table: "questions",
                column: "VideoId",
                principalTable: "videos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_result_AspNetUsers_UserId",
                table: "result",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_result_videos_videoId",
                table: "result",
                column: "videoId",
                principalTable: "videos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sentenceAnswers_AspNetUsers_UserId",
                table: "sentenceAnswers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_spokenSentences_videos_VideoId",
                table: "spokenSentences",
                column: "VideoId",
                principalTable: "videos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Views_AspNetUsers_UserId",
                table: "Views",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Views_videos_VideoId",
                table: "Views",
                column: "VideoId",
                principalTable: "videos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_AspNetUsers_UserId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_videos_VideoId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_questionAnswers_AspNetUsers_UserId",
                table: "questionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_questions_videos_VideoId",
                table: "questions");

            migrationBuilder.DropForeignKey(
                name: "FK_result_AspNetUsers_UserId",
                table: "result");

            migrationBuilder.DropForeignKey(
                name: "FK_result_videos_videoId",
                table: "result");

            migrationBuilder.DropForeignKey(
                name: "FK_sentenceAnswers_AspNetUsers_UserId",
                table: "sentenceAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_spokenSentences_videos_VideoId",
                table: "spokenSentences");

            migrationBuilder.DropForeignKey(
                name: "FK_Views_AspNetUsers_UserId",
                table: "Views");

            migrationBuilder.DropForeignKey(
                name: "FK_Views_videos_VideoId",
                table: "Views");

            migrationBuilder.RenameColumn(
                name: "VideoId",
                table: "Views",
                newName: "Videoid");

            migrationBuilder.RenameIndex(
                name: "IX_Views_VideoId",
                table: "Views",
                newName: "IX_Views_Videoid");

            migrationBuilder.RenameColumn(
                name: "VideoId",
                table: "spokenSentences",
                newName: "Videoid");

            migrationBuilder.RenameIndex(
                name: "IX_spokenSentences_VideoId",
                table: "spokenSentences",
                newName: "IX_spokenSentences_Videoid");

            migrationBuilder.RenameColumn(
                name: "videoId",
                table: "result",
                newName: "videoid");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "result",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_result_videoId",
                table: "result",
                newName: "IX_result_videoid");

            migrationBuilder.RenameIndex(
                name: "IX_result_UserId",
                table: "result",
                newName: "IX_result_userId");

            migrationBuilder.RenameColumn(
                name: "VideoId",
                table: "questions",
                newName: "Videoid");

            migrationBuilder.RenameIndex(
                name: "IX_questions_VideoId",
                table: "questions",
                newName: "IX_questions_Videoid");

            migrationBuilder.RenameColumn(
                name: "VideoId",
                table: "comments",
                newName: "Videoid");

            migrationBuilder.RenameIndex(
                name: "IX_comments_VideoId",
                table: "comments",
                newName: "IX_comments_Videoid");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Views",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "sentenceAnswers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "result",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "questionAnswers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    deleteState = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_comments_users_UserId",
                table: "comments",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_videos_Videoid",
                table: "comments",
                column: "Videoid",
                principalTable: "videos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_questionAnswers_users_UserId",
                table: "questionAnswers",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_questions_videos_Videoid",
                table: "questions",
                column: "Videoid",
                principalTable: "videos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_result_users_userId",
                table: "result",
                column: "userId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_result_videos_videoid",
                table: "result",
                column: "videoid",
                principalTable: "videos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sentenceAnswers_users_UserId",
                table: "sentenceAnswers",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_spokenSentences_videos_Videoid",
                table: "spokenSentences",
                column: "Videoid",
                principalTable: "videos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Views_users_UserId",
                table: "Views",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Views_videos_Videoid",
                table: "Views",
                column: "Videoid",
                principalTable: "videos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
