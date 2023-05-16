using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hp_Web_App.Shared.Migrations;

/// <inheritdoc />
public partial class UpdateRegToString : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "RegistrationKey",
            table: "Users",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(Guid),
            oldType: "uniqueidentifier");

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: -1,
            columns: new[] { "RegistrationKey", "RegistrationKeyExpires" },
            values: new object[] { null, new DateTime(2023, 5, 17, 14, 0, 44, 684, DateTimeKind.Local).AddTicks(6527) });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<Guid>(
            name: "RegistrationKey",
            table: "Users",
            type: "uniqueidentifier",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: -1,
            columns: new[] { "RegistrationKey", "RegistrationKeyExpires" },
            values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 5, 17, 9, 19, 52, 864, DateTimeKind.Local).AddTicks(1524) });
    }
}
