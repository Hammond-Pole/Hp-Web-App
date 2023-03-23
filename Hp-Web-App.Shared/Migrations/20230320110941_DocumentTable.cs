using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hp_Web_App.Shared.Migrations
{
    /// <inheritdoc />
    public partial class DocumentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_CompanyTypes_CompanyTypeId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyDocuments_Companies_CompanyId",
                table: "CompanyDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyDocuments_Documents_DocumentId",
                table: "CompanyDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionFields_Documents_DocumentId",
                table: "QuestionFields");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionFields_QuestionFieldTypes_QuestionFieldTypeId",
                table: "QuestionFields");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionValue_QuestionFields_QuestionFieldID",
                table: "QuestionValue");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_CompanyId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "DocumentAttachedId",
                table: "CompanyDocuments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DocumentsAttached",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionFieldId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentsAttached", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentsAttached_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentsAttached_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentsAttached_QuestionFields_QuestionFieldId",
                        column: x => x.QuestionFieldId,
                        principalTable: "QuestionFields",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentsAttached_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDocuments_DocumentAttachedId",
                table: "CompanyDocuments",
                column: "DocumentAttachedId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentsAttached_CompanyId",
                table: "DocumentsAttached",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentsAttached_DocumentId",
                table: "DocumentsAttached",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentsAttached_QuestionFieldId",
                table: "DocumentsAttached",
                column: "QuestionFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentsAttached_UserId",
                table: "DocumentsAttached",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_CompanyTypes_CompanyTypeId",
                table: "Companies",
                column: "CompanyTypeId",
                principalTable: "CompanyTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyDocuments_Companies_CompanyId",
                table: "CompanyDocuments",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyDocuments_DocumentsAttached_DocumentAttachedId",
                table: "CompanyDocuments",
                column: "DocumentAttachedId",
                principalTable: "DocumentsAttached",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyDocuments_Documents_DocumentId",
                table: "CompanyDocuments",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionFields_Documents_DocumentId",
                table: "QuestionFields",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionFields_QuestionFieldTypes_QuestionFieldTypeId",
                table: "QuestionFields",
                column: "QuestionFieldTypeId",
                principalTable: "QuestionFieldTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionValue_QuestionFields_QuestionFieldID",
                table: "QuestionValue",
                column: "QuestionFieldID",
                principalTable: "QuestionFields",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companies_CompanyId",
                table: "Users",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_CompanyTypes_CompanyTypeId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyDocuments_Companies_CompanyId",
                table: "CompanyDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyDocuments_DocumentsAttached_DocumentAttachedId",
                table: "CompanyDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyDocuments_Documents_DocumentId",
                table: "CompanyDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionFields_Documents_DocumentId",
                table: "QuestionFields");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionFields_QuestionFieldTypes_QuestionFieldTypeId",
                table: "QuestionFields");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionValue_QuestionFields_QuestionFieldID",
                table: "QuestionValue");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_CompanyId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "DocumentsAttached");

            migrationBuilder.DropIndex(
                name: "IX_CompanyDocuments_DocumentAttachedId",
                table: "CompanyDocuments");

            migrationBuilder.DropColumn(
                name: "DocumentAttachedId",
                table: "CompanyDocuments");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_CompanyTypes_CompanyTypeId",
                table: "Companies",
                column: "CompanyTypeId",
                principalTable: "CompanyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyDocuments_Companies_CompanyId",
                table: "CompanyDocuments",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyDocuments_Documents_DocumentId",
                table: "CompanyDocuments",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionFields_Documents_DocumentId",
                table: "QuestionFields",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionFields_QuestionFieldTypes_QuestionFieldTypeId",
                table: "QuestionFields",
                column: "QuestionFieldTypeId",
                principalTable: "QuestionFieldTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionValue_QuestionFields_QuestionFieldID",
                table: "QuestionValue",
                column: "QuestionFieldID",
                principalTable: "QuestionFields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companies_CompanyId",
                table: "Users",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_UserRoleId",
                table: "Users",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
