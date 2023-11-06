using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hp_Web_App.Shared.Migrations
{
    /// <inheritdoc />
    public partial class UsersExternal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "RegistrationKeyExpires", "SentDate" },
                values: new object[] { new DateTime(2023, 11, 7, 9, 36, 4, 356, DateTimeKind.Local).AddTicks(2136), new DateTime(2023, 11, 6, 9, 36, 4, 356, DateTimeKind.Local).AddTicks(2138) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Dob", "RegistrationKeyExpires" },
                values: new object[] { new DateTime(2023, 11, 6, 9, 36, 4, 356, DateTimeKind.Local).AddTicks(2061), new DateTime(2023, 11, 7, 9, 36, 4, 356, DateTimeKind.Local).AddTicks(2044) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "RegistrationKeyExpires", "SentDate" },
                values: new object[] { new DateTime(2023, 11, 3, 14, 25, 24, 259, DateTimeKind.Local).AddTicks(296), new DateTime(2023, 11, 2, 14, 25, 24, 259, DateTimeKind.Local).AddTicks(300) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Dob", "RegistrationKeyExpires" },
                values: new object[] { new DateTime(2023, 11, 2, 14, 25, 24, 259, DateTimeKind.Local).AddTicks(151), new DateTime(2023, 11, 3, 14, 25, 24, 259, DateTimeKind.Local).AddTicks(132) });
        }
    }
}
