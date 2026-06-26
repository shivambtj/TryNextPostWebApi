using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TryNextPostWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Add_some_Entity_dataTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserStatus",
                table: "User_Master",
                type: "char(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(1)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "User_Master",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "User_Master",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserStatus",
                table: "User_Master",
                type: "char(1)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedBy",
                table: "User_Master",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedBy",
                table: "User_Master",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
