using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gp1.Migrations
{
    public partial class wedwq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VidId",
                table: "spokenSentences");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "users",
                newName: "CreationTime");

            migrationBuilder.AlterColumn<string>(
                name: "Sentence",
                table: "spokenSentences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "users",
                newName: "date");

            migrationBuilder.AlterColumn<string>(
                name: "Sentence",
                table: "spokenSentences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "VidId",
                table: "spokenSentences",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
