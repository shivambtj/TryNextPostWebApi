using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TryNextPostWebApi.Migrations
{
    /// <inheritdoc />
    public partial class CHANGETABLENAME1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Master",
                table: "User_Master");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role_Master",
                table: "Role_Master");

            migrationBuilder.RenameTable(
                name: "User_Master",
                newName: "USER_MASTER");

            migrationBuilder.RenameTable(
                name: "Role_Master",
                newName: "ROLE_MASTER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_USER_MASTER",
                table: "USER_MASTER",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ROLE_MASTER",
                table: "ROLE_MASTER",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_USER_MASTER",
                table: "USER_MASTER");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ROLE_MASTER",
                table: "ROLE_MASTER");

            migrationBuilder.RenameTable(
                name: "USER_MASTER",
                newName: "User_Master");

            migrationBuilder.RenameTable(
                name: "ROLE_MASTER",
                newName: "Role_Master");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Master",
                table: "User_Master",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role_Master",
                table: "Role_Master",
                column: "RoleId");
        }
    }
}
