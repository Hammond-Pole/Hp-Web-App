using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hp_Web_App.Shared.Migrations
{
    /// <inheritdoc />
    public partial class ComponentName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ComponentName",
                table: "QuestionFieldTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "QuestionFieldTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ComponentName",
                value: "date");

            migrationBuilder.UpdateData(
                table: "QuestionFieldTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ComponentName",
                value: "checkbox");

            migrationBuilder.UpdateData(
                table: "QuestionFieldTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "ComponentName",
                value: "text");

            migrationBuilder.UpdateData(
                table: "QuestionFieldTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "ComponentName",
                value: "number");

            migrationBuilder.UpdateData(
                table: "QuestionFieldTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "ComponentName",
                value: "number");

            migrationBuilder.UpdateData(
                table: "QuestionFieldTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "ComponentName",
                value: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComponentName",
                table: "QuestionFieldTypes");
        }
    }
}
