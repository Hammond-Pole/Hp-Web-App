using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hp_Web_App.Shared.Migrations
{
    /// <inheritdoc />
    public partial class AddAllTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BoolValue",
                table: "QuestionValue",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FloatValue",
                table: "QuestionValue",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IntValue",
                table: "QuestionValue",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemoValue",
                table: "QuestionValue",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoolValue",
                table: "QuestionValue");

            migrationBuilder.DropColumn(
                name: "FloatValue",
                table: "QuestionValue");

            migrationBuilder.DropColumn(
                name: "IntValue",
                table: "QuestionValue");

            migrationBuilder.DropColumn(
                name: "MemoValue",
                table: "QuestionValue");
        }
    }
}
