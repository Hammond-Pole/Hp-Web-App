using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hp_Web_App.Shared.Migrations;

/// <inheritdoc />
public partial class AddSelectList : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "ListValueId",
            table: "QuestionValues",
            type: "int",
            nullable: true);

        migrationBuilder.CreateTable(
            name: "ListValues",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                QuestionFieldId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ListValues", x => x.Id);
                table.ForeignKey(
                    name: "FK_ListValues_QuestionFields_QuestionFieldId",
                    column: x => x.QuestionFieldId,
                    principalTable: "QuestionFields",
                    principalColumn: "Id");
            });

        migrationBuilder.UpdateData(
            table: "QuestionFieldTypes",
            keyColumn: "Id",
            keyValue: 6,
            column: "ComponentName",
            value: "memo");

        migrationBuilder.InsertData(
            table: "QuestionFieldTypes",
            columns: new[] { "Id", "ComponentName", "DisplayName", "SqlDataType", "SystemType" },
            values: new object[] { 7, "select", "List", "Varchar(500)", "System.String" });

        migrationBuilder.CreateIndex(
            name: "IX_ListValues_QuestionFieldId",
            table: "ListValues",
            column: "QuestionFieldId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "ListValues");

        migrationBuilder.DeleteData(
            table: "QuestionFieldTypes",
            keyColumn: "Id",
            keyValue: 7);

        migrationBuilder.DropColumn(
            name: "ListValueId",
            table: "QuestionValues");

        migrationBuilder.UpdateData(
            table: "QuestionFieldTypes",
            keyColumn: "Id",
            keyValue: 6,
            column: "ComponentName",
            value: "Memo");
    }
}
