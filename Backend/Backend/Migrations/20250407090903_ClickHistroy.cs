using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class ClickHistroy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IpAddress",
                table: "ClickHistories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "BrowserName",
                table: "ClickHistories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "ClickHistories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "ClickHistories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceType",
                table: "ClickHistories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBot",
                table: "ClickHistories",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OperatingSystem",
                table: "ClickHistories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WasRedirected",
                table: "ClickHistories",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrowserName",
                table: "ClickHistories");

            migrationBuilder.DropColumn(
                name: "City",
                table: "ClickHistories");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "ClickHistories");

            migrationBuilder.DropColumn(
                name: "DeviceType",
                table: "ClickHistories");

            migrationBuilder.DropColumn(
                name: "IsBot",
                table: "ClickHistories");

            migrationBuilder.DropColumn(
                name: "OperatingSystem",
                table: "ClickHistories");

            migrationBuilder.DropColumn(
                name: "WasRedirected",
                table: "ClickHistories");

            migrationBuilder.AlterColumn<string>(
                name: "IpAddress",
                table: "ClickHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
