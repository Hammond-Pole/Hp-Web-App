using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hp_Web_App.Shared.Migrations
{
    /// <inheritdoc />
    public partial class AddDocuments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionFieldTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SqlDataType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionFieldTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    QuestionFieldTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionFields_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionFields_QuestionFieldTypes_QuestionFieldTypeId",
                        column: x => x.QuestionFieldTypeId,
                        principalTable: "QuestionFieldTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    QuestionFieldID = table.Column<int>(type: "int", nullable: false),
                    DateValueChanged = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuestionValueType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateValue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StringValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionValue_QuestionFields_QuestionFieldID",
                        column: x => x.QuestionFieldID,
                        principalTable: "QuestionFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "QuestionFieldTypes",
                columns: new[] { "Id", "SqlDataType", "SystemType" },
                values: new object[,]
                {
                    { 1, "DateTime", "System.DateTime" },
                    { 2, "Bit", "System.Boolean" },
                    { 3, "Varchar(500)", "System.String" },
                    { 4, "Int", "System.Int32" },
                    { 5, "Float", "System.Double" },
                    { 6, "Varchar(max)", "System.String" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionFields_DocumentId",
                table: "QuestionFields",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionFields_QuestionFieldTypeId",
                table: "QuestionFields",
                column: "QuestionFieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionValue_QuestionFieldID",
                table: "QuestionValue",
                column: "QuestionFieldID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionValue");

            migrationBuilder.DropTable(
                name: "QuestionFields");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "QuestionFieldTypes");
        }
    }
}
