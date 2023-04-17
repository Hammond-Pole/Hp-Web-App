using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hp_Web_App.Shared.Migrations;

/// <inheritdoc />
public partial class UpdateQuestionValues : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameColumn(
            name: "QuestionValueType",
            table: "QuestionValues",
            newName: "Discriminator");

        migrationBuilder.AlterColumn<int>(
            name: "DocumentsAttachedId",
            table: "QuestionValues",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AlterColumn<DateTime>(
            name: "DateValueChanged",
            table: "QuestionValues",
            type: "datetime2",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            oldClrType: typeof(DateTime),
            oldType: "datetime2",
            oldNullable: true);

        migrationBuilder.AddColumn<int>(
            name: "QuestionValueId",
            table: "QuestionValues",
            type: "int",
            nullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "FileUrl",
            table: "DocumentsAttached",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "FileName",
            table: "DocumentsAttached",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "FileDescription",
            table: "DocumentsAttached",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.CreateIndex(
            name: "IX_QuestionValues_DocumentId",
            table: "QuestionValues",
            column: "DocumentId");

        migrationBuilder.CreateIndex(
            name: "IX_QuestionValues_QuestionValueId",
            table: "QuestionValues",
            column: "QuestionValueId");

        migrationBuilder.AddForeignKey(
            name: "FK_QuestionValues_Documents_DocumentId",
            table: "QuestionValues",
            column: "DocumentId",
            principalTable: "Documents",
            principalColumn: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_QuestionValues_QuestionValues_QuestionValueId",
            table: "QuestionValues",
            column: "QuestionValueId",
            principalTable: "QuestionValues",
            principalColumn: "Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_QuestionValues_Documents_DocumentId",
            table: "QuestionValues");

        migrationBuilder.DropForeignKey(
            name: "FK_QuestionValues_QuestionValues_QuestionValueId",
            table: "QuestionValues");

        migrationBuilder.DropIndex(
            name: "IX_QuestionValues_DocumentId",
            table: "QuestionValues");

        migrationBuilder.DropIndex(
            name: "IX_QuestionValues_QuestionValueId",
            table: "QuestionValues");

        migrationBuilder.DropColumn(
            name: "QuestionValueId",
            table: "QuestionValues");

        migrationBuilder.RenameColumn(
            name: "Discriminator",
            table: "QuestionValues",
            newName: "QuestionValueType");

        migrationBuilder.AlterColumn<int>(
            name: "DocumentsAttachedId",
            table: "QuestionValues",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<DateTime>(
            name: "DateValueChanged",
            table: "QuestionValues",
            type: "datetime2",
            nullable: true,
            oldClrType: typeof(DateTime),
            oldType: "datetime2");

        migrationBuilder.AlterColumn<string>(
            name: "FileUrl",
            table: "DocumentsAttached",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "FileName",
            table: "DocumentsAttached",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "FileDescription",
            table: "DocumentsAttached",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");
    }
}
