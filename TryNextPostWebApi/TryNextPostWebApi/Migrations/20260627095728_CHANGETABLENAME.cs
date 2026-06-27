using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TryNextPostWebApi.Migrations
{
    /// <inheritdoc />
    public partial class CHANGETABLENAME : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MenueItemMaster",
                table: "MenueItemMaster");

            migrationBuilder.RenameTable(
                name: "MenueItemMaster",
                newName: "MENUE_ITEM_MASTER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MENUE_ITEM_MASTER",
                table: "MENUE_ITEM_MASTER",
                column: "MenueItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MENUE_ITEM_MASTER",
                table: "MENUE_ITEM_MASTER");

            migrationBuilder.RenameTable(
                name: "MENUE_ITEM_MASTER",
                newName: "MenueItemMaster");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenueItemMaster",
                table: "MenueItemMaster",
                column: "MenueItemId");
        }
    }
}
