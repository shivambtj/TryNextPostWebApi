using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TryNextPostWebApi.Migrations
{
    /// <inheritdoc />
    public partial class CHANGETABLENAME2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Mail_Settings",
                table: "Mail_Settings");

            migrationBuilder.RenameTable(
                name: "Mail_Settings",
                newName: "MAIL_SETTINGS");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MAIL_SETTINGS",
                table: "MAIL_SETTINGS",
                column: "MailSettingsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MAIL_SETTINGS",
                table: "MAIL_SETTINGS");

            migrationBuilder.RenameTable(
                name: "MAIL_SETTINGS",
                newName: "Mail_Settings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mail_Settings",
                table: "Mail_Settings",
                column: "MailSettingsId");
        }
    }
}
