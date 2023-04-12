using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hp_Web_App.Shared.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "CompanyTypes",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CompanyTypes", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Documents",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
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
                SystemType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ComponentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_QuestionFieldTypes", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "UserRoles",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserRoles", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Companies",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                CompanyTypeId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Companies", x => x.Id);
                table.ForeignKey(
                    name: "FK_Companies_CompanyTypes_CompanyTypeId",
                    column: x => x.CompanyTypeId,
                    principalTable: "CompanyTypes",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "QuestionFields",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                DocumentId = table.Column<int>(type: "int", nullable: false),
                QuestionFieldTypeId = table.Column<int>(type: "int", nullable: false),
                Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_QuestionFields", x => x.Id);
                table.ForeignKey(
                    name: "FK_QuestionFields_Documents_DocumentId",
                    column: x => x.DocumentId,
                    principalTable: "Documents",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_QuestionFields_QuestionFieldTypes_QuestionFieldTypeId",
                    column: x => x.QuestionFieldTypeId,
                    principalTable: "QuestionFieldTypes",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "CompanyDocuments",
            columns: table => new
            {
                DocumentId = table.Column<int>(type: "int", nullable: false),
                CompanyId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CompanyDocuments", x => new { x.CompanyId, x.DocumentId });
                table.ForeignKey(
                    name: "FK_CompanyDocuments_Companies_CompanyId",
                    column: x => x.CompanyId,
                    principalTable: "Companies",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_CompanyDocuments_Documents_DocumentId",
                    column: x => x.DocumentId,
                    principalTable: "Documents",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                UserRoleId = table.Column<int>(type: "int", nullable: false),
                CompanyId = table.Column<int>(type: "int", nullable: false),
                IsActive = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
                table.ForeignKey(
                    name: "FK_Users_Companies_CompanyId",
                    column: x => x.CompanyId,
                    principalTable: "Companies",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_Users_UserRoles_UserRoleId",
                    column: x => x.UserRoleId,
                    principalTable: "UserRoles",
                    principalColumn: "Id");
            });

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

        migrationBuilder.CreateTable(
            name: "QuestionValues",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                DocumentId = table.Column<int>(type: "int", nullable: false),
                QuestionFieldID = table.Column<int>(type: "int", nullable: false),
                DateValueChanged = table.Column<DateTime>(type: "datetime2", nullable: true),
                DocumentsAttachedId = table.Column<int>(type: "int", nullable: true),
                QuestionValueType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                BoolValue = table.Column<bool>(type: "bit", nullable: true),
                DateValue = table.Column<DateTime>(type: "datetime2", nullable: true),
                FloatValue = table.Column<double>(type: "float", nullable: true),
                IntValue = table.Column<int>(type: "int", nullable: true),
                MemoValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                StringValue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_QuestionValues", x => x.Id);
                table.ForeignKey(
                    name: "FK_QuestionValues_DocumentsAttached_DocumentsAttachedId",
                    column: x => x.DocumentsAttachedId,
                    principalTable: "DocumentsAttached",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_QuestionValues_QuestionFields_QuestionFieldID",
                    column: x => x.QuestionFieldID,
                    principalTable: "QuestionFields",
                    principalColumn: "Id");
            });

        migrationBuilder.InsertData(
            table: "CompanyTypes",
            columns: new[] { "Id", "Description", "Name" },
            values: new object[,]
            {
                { 1, "Customers would typically be purchasing or selling.", "Customer" },
                { 2, "Any organization that sells to Hammond Pole.", "Supplier" },
                { 3, "Any company that supplies services to Hammond Pole.", "Contractor" },
                { 4, "These are specifically for Estate Agents and their staff.", "Agency" },
                { 5, "For any company that does not fall into the above categories.", "Other" }
            });

        migrationBuilder.InsertData(
            table: "QuestionFieldTypes",
            columns: new[] { "Id", "ComponentName", "DisplayName", "SqlDataType", "SystemType" },
            values: new object[,]
            {
                { 1, "date", "Date", "DateTime", "System.DateTime" },
                { 2, "checkbox", "Yes / No", "Bit", "System.Boolean" },
                { 3, "text", "Text", "Varchar(500)", "System.String" },
                { 4, "number", "Whole Number", "Int", "System.Int32" },
                { 5, "decimal", "Decimal", "Float", "System.Double" },
                { 6, "Memo", "Memo", "Varchar(max)", "System.String" }
            });

        migrationBuilder.InsertData(
            table: "UserRoles",
            columns: new[] { "Id", "Description", "Name" },
            values: new object[,]
            {
                { 1, "Administrators can Edit or Create Users, Documents, Companies and Questions", "Administrator" },
                { 2, "Users can upload or use non administrative features.", "User" }
            });

        migrationBuilder.InsertData(
            table: "Companies",
            columns: new[] { "Id", "CompanyTypeId", "Name" },
            values: new object[] { 1, 5, "Hammond Pole" });

        migrationBuilder.InsertData(
            table: "Users",
            columns: new[] { "Id", "CompanyId", "Email", "IsActive", "Name", "Password", "UserRoleId" },
            values: new object[] { -1, 1, "alanj@hpd.co.za", true, "Admin", "1234", 1 });

        migrationBuilder.CreateIndex(
            name: "IX_Companies_CompanyTypeId",
            table: "Companies",
            column: "CompanyTypeId");

        migrationBuilder.CreateIndex(
            name: "IX_CompanyDocuments_DocumentId",
            table: "CompanyDocuments",
            column: "DocumentId");

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

        migrationBuilder.CreateIndex(
            name: "IX_QuestionFields_DocumentId",
            table: "QuestionFields",
            column: "DocumentId");

        migrationBuilder.CreateIndex(
            name: "IX_QuestionFields_QuestionFieldTypeId",
            table: "QuestionFields",
            column: "QuestionFieldTypeId");

        migrationBuilder.CreateIndex(
            name: "IX_QuestionValues_DocumentsAttachedId",
            table: "QuestionValues",
            column: "DocumentsAttachedId");

        migrationBuilder.CreateIndex(
            name: "IX_QuestionValues_QuestionFieldID",
            table: "QuestionValues",
            column: "QuestionFieldID");

        migrationBuilder.CreateIndex(
            name: "IX_Users_CompanyId",
            table: "Users",
            column: "CompanyId");

        migrationBuilder.CreateIndex(
            name: "IX_Users_UserRoleId",
            table: "Users",
            column: "UserRoleId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "CompanyDocuments");

        migrationBuilder.DropTable(
            name: "QuestionValues");

        migrationBuilder.DropTable(
            name: "DocumentsAttached");

        migrationBuilder.DropTable(
            name: "QuestionFields");

        migrationBuilder.DropTable(
            name: "Users");

        migrationBuilder.DropTable(
            name: "Documents");

        migrationBuilder.DropTable(
            name: "QuestionFieldTypes");

        migrationBuilder.DropTable(
            name: "Companies");

        migrationBuilder.DropTable(
            name: "UserRoles");

        migrationBuilder.DropTable(
            name: "CompanyTypes");
    }
}
