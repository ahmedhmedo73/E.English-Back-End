using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gp1.Migrations
{
    public partial class UpdateQuestionModelAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer1",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "Answer2",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "Answer3",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "Answer4",
                table: "questions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Answer1",
                table: "questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Answer2",
                table: "questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Answer3",
                table: "questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Answer4",
                table: "questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
