using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hp_Web_App.Shared.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "QuestionFieldTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "ComponentName",
                value: "decimal");

            migrationBuilder.UpdateData(
                table: "QuestionFieldTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "ComponentName",
                value: "Memo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
