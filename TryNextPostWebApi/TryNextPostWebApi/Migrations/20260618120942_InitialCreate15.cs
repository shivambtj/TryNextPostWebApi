using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TryNextPostWebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BankAccount",
                table: "User_Master",
                newName: "GSTNumber");

            migrationBuilder.AddColumn<string>(
                name: "BankId",
                table: "User_Master",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankId",
                table: "User_Master");

            migrationBuilder.RenameColumn(
                name: "GSTNumber",
                table: "User_Master",
                newName: "BankAccount");
        }
    }
}
