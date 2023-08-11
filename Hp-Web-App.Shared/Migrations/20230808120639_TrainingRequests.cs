using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hp_Web_App.Shared.Migrations;

/// <inheritdoc />
public partial class TrainingRequests : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "TrainingRequests",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                Surname = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                TelephoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                OfficeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Topic = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TrainingRequests", x => x.Id);
            });

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: -1,
            columns: new[] { "Dob", "RegistrationKeyExpires" },
            values: new object[] { new DateTime(2023, 8, 8, 14, 6, 39, 323, DateTimeKind.Local).AddTicks(4671), new DateTime(2023, 8, 9, 14, 6, 39, 323, DateTimeKind.Local).AddTicks(4611) });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "TrainingRequests");

        migrationBuilder.UpdateData(
            table: "Users",
            keyColumn: "Id",
            keyValue: -1,
            columns: new[] { "Dob", "RegistrationKeyExpires" },
            values: new object[] { new DateTime(2023, 7, 5, 16, 23, 56, 11, DateTimeKind.Local).AddTicks(2115), new DateTime(2023, 7, 6, 16, 23, 56, 11, DateTimeKind.Local).AddTicks(2095) });
    }
}
