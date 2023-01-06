using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gp1.Migrations
{
    public partial class RemoveUnnecessary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sentenceAnswers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sentenceAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SentenceId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Answers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectAnswePercentage = table.Column<int>(type: "int", nullable: false),
                    CorrectAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sentenceAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sentenceAnswers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sentenceAnswers_spokenSentences_SentenceId",
                        column: x => x.SentenceId,
                        principalTable: "spokenSentences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sentenceAnswers_SentenceId",
                table: "sentenceAnswers",
                column: "SentenceId");

            migrationBuilder.CreateIndex(
                name: "IX_sentenceAnswers_UserId",
                table: "sentenceAnswers",
                column: "UserId");
        }
    }
}
