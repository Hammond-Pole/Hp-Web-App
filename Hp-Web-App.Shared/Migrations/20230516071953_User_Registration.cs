using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hp_Web_App.Shared.Migrations;

/// <inheritdoc />
public partial class User_Registration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<Guid>(
            name: "RegistrationKey",
            table: "Users",
            type: "uniqueidentifier",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

        migrationBuilder.AddColumn<DateTime>(
            name: "RegistrationKeyExpires",
            table: "Users",
            type: "datetime2",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: -1,
            columns: new[] { "RegistrationKey", "RegistrationKeyExpires" },
            values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 5, 17, 9, 19, 52, 864, DateTimeKind.Local).AddTicks(1524) });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "RegistrationKey",
            table: "Users");

        migrationBuilder.DropColumn(
            name: "RegistrationKeyExpires",
            table: "Users");
    }
}
