using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TryNextPostWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Updatetablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Mail_Config",
                table: "Mail_Config");

            migrationBuilder.RenameTable(
                name: "Mail_Config",
                newName: "Mail_Settings");

            migrationBuilder.RenameColumn(
                name: "ToMailId",
                table: "Mail_Settings",
                newName: "ToMailAddress");

            migrationBuilder.RenameColumn(
                name: "MailId",
                table: "Mail_Settings",
                newName: "FromMailAdress");

            migrationBuilder.RenameColumn(
                name: "CCMainId",
                table: "Mail_Settings",
                newName: "CCMailAddress");

            migrationBuilder.RenameColumn(
                name: "BCCMailId",
                table: "Mail_Settings",
                newName: "BCCMailAddress");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "Mail_Settings",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Mail_Settings",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mail_Settings",
                table: "Mail_Settings",
                column: "MailSettingsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Mail_Settings",
                table: "Mail_Settings");

            migrationBuilder.RenameTable(
                name: "Mail_Settings",
                newName: "Mail_Config");

            migrationBuilder.RenameColumn(
                name: "ToMailAddress",
                table: "Mail_Config",
                newName: "ToMailId");

            migrationBuilder.RenameColumn(
                name: "FromMailAdress",
                table: "Mail_Config",
                newName: "MailId");

            migrationBuilder.RenameColumn(
                name: "CCMailAddress",
                table: "Mail_Config",
                newName: "CCMainId");

            migrationBuilder.RenameColumn(
                name: "BCCMailAddress",
                table: "Mail_Config",
                newName: "BCCMailId");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedOn",
                table: "Mail_Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedOn",
                table: "Mail_Config",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mail_Config",
                table: "Mail_Config",
                column: "MailSettingsId");
        }
    }
}
