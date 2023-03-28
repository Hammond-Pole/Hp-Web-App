using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hp_Web_App.Shared.Migrations
{
    /// <inheritdoc />
    public partial class LinkDocumentsAttachedandQuestionValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentsAttachedId",
                table: "QuestionValue",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionValue_DocumentsAttachedId",
                table: "QuestionValue",
                column: "DocumentsAttachedId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionValue_DocumentsAttached_DocumentsAttachedId",
                table: "QuestionValue",
                column: "DocumentsAttachedId",
                principalTable: "DocumentsAttached",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionValue_DocumentsAttached_DocumentsAttachedId",
                table: "QuestionValue");

            migrationBuilder.DropIndex(
                name: "IX_QuestionValue_DocumentsAttachedId",
                table: "QuestionValue");

            migrationBuilder.DropColumn(
                name: "DocumentsAttachedId",
                table: "QuestionValue");
        }
    }
}
