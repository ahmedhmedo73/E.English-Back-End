using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gp1.Migrations
{
    public partial class AddUsersAnswersToSentenceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SentenceUsersAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentenceId = table.Column<int>(type: "int", nullable: false),
                    IsCorrectAnswer = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SentenceUsersAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SentenceUsersAnswers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SentenceUsersAnswers_spokenSentences_SentenceId",
                        column: x => x.SentenceId,
                        principalTable: "spokenSentences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SentenceUsersAnswers_SentenceId",
                table: "SentenceUsersAnswers",
                column: "SentenceId");

            migrationBuilder.CreateIndex(
                name: "IX_SentenceUsersAnswers_UserId",
                table: "SentenceUsersAnswers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SentenceUsersAnswers");
        }
    }
}
