using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TryNextPostWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Add_some_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrandName",
                table: "User_Master",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessType",
                table: "User_Master",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrandName",
                table: "User_Master");

            migrationBuilder.DropColumn(
                name: "BusinessType",
                table: "User_Master");
        }
    }
}
