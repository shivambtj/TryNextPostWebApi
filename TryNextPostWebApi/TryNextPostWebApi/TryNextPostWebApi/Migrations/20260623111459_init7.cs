using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TryNextPostWebApi.Migrations
{
    /// <inheritdoc />
    public partial class init7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mail_Config",
                columns: table => new
                {
                    MailSettingsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmtpServer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Port = table.Column<int>(type: "int", nullable: false),
                    MailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToMailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CCMainId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BCCMailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subjects = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mail_Config", x => x.MailSettingsId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mail_Config");
        }
    }
}
