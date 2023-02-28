using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hp_Web_App.Shared.Migrations
{
    /// <inheritdoc />
    public partial class AddTypeDisplayName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "QuestionFieldTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "QuestionFieldTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DisplayName",
                value: "Date");

            migrationBuilder.UpdateData(
                table: "QuestionFieldTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DisplayName",
                value: "Yes / No");

            migrationBuilder.UpdateData(
                table: "QuestionFieldTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DisplayName",
                value: "Text");

            migrationBuilder.UpdateData(
                table: "QuestionFieldTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DisplayName",
                value: "Whole Number");

            migrationBuilder.UpdateData(
                table: "QuestionFieldTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "DisplayName",
                value: "Decimal");

            migrationBuilder.UpdateData(
                table: "QuestionFieldTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "DisplayName",
                value: "Memo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "QuestionFieldTypes");
        }
    }
}
