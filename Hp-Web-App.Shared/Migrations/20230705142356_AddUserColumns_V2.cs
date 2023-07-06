using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hp_Web_App.Shared.Migrations
{
    /// <inheritdoc />
    public partial class AddUserColumns_V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone_Num",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Dob", "Phone_Num", "RegistrationKeyExpires" },
                values: new object[] { new DateTime(2023, 7, 5, 16, 23, 56, 11, DateTimeKind.Local).AddTicks(2115), "073 345 8900", new DateTime(2023, 7, 6, 16, 23, 56, 11, DateTimeKind.Local).AddTicks(2095) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone_Num",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Dob", "RegistrationKeyExpires" },
                values: new object[] { new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 7, 6, 14, 56, 40, 713, DateTimeKind.Local).AddTicks(5640) });
        }
    }
}
