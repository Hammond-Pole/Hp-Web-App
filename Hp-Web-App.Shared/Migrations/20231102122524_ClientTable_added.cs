using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hp_Web_App.Shared.Migrations
{
    /// <inheritdoc />
    public partial class ClientTable_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HP_Reference = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationKeyExpires = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "HP_Reference", "RegistrationKey", "RegistrationKeyExpires", "SentDate" },
                values: new object[] { -1, "ErnestH@hpd.co.za", "HP7803252", null, new DateTime(2023, 11, 3, 14, 25, 24, 259, DateTimeKind.Local).AddTicks(296), new DateTime(2023, 11, 2, 14, 25, 24, 259, DateTimeKind.Local).AddTicks(300) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Dob", "RegistrationKeyExpires" },
                values: new object[] { new DateTime(2023, 11, 2, 14, 25, 24, 259, DateTimeKind.Local).AddTicks(151), new DateTime(2023, 11, 3, 14, 25, 24, 259, DateTimeKind.Local).AddTicks(132) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Dob", "RegistrationKeyExpires" },
                values: new object[] { new DateTime(2023, 8, 8, 14, 6, 39, 323, DateTimeKind.Local).AddTicks(4671), new DateTime(2023, 8, 9, 14, 6, 39, 323, DateTimeKind.Local).AddTicks(4611) });
        }
    }
}
