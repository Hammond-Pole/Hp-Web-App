using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hp_Web_App.Shared.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIdOnCompanyDocuments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "CompanyDocuments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CompanyDocuments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
