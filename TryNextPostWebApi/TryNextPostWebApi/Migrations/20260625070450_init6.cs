using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TryNextPostWebApi.Migrations
{
    /// <inheritdoc />
    public partial class init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ForgotPasswordOtp",
                table: "User_Master",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOtpVerified",
                table: "User_Master",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "OtpExpiryTime",
                table: "User_Master",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForgotPasswordOtp",
                table: "User_Master");

            migrationBuilder.DropColumn(
                name: "IsOtpVerified",
                table: "User_Master");

            migrationBuilder.DropColumn(
                name: "OtpExpiryTime",
                table: "User_Master");
        }
    }
}
