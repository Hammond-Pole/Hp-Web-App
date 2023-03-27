using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hp_Web_App.Shared.Migrations
{
    /// <inheritdoc />
    public partial class FixCompanyDocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyDocuments_DocumentsAttached_DocumentAttachedId",
                table: "CompanyDocuments");

            migrationBuilder.DropIndex(
                name: "IX_CompanyDocuments_DocumentAttachedId",
                table: "CompanyDocuments");

            migrationBuilder.DropColumn(
                name: "DocumentAttachedId",
                table: "CompanyDocuments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentAttachedId",
                table: "CompanyDocuments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDocuments_DocumentAttachedId",
                table: "CompanyDocuments",
                column: "DocumentAttachedId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyDocuments_DocumentsAttached_DocumentAttachedId",
                table: "CompanyDocuments",
                column: "DocumentAttachedId",
                principalTable: "DocumentsAttached",
                principalColumn: "Id");
        }
    }
}
