using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class fkdefined : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClickHistories_ShortUrls_ShortUrlId",
                table: "ClickHistories");

            migrationBuilder.AddForeignKey(
                name: "FK_ClickHistories_ShortUrls_ShortUrlId",
                table: "ClickHistories",
                column: "ShortUrlId",
                principalTable: "ShortUrls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClickHistories_ShortUrls_ShortUrlId",
                table: "ClickHistories");

            migrationBuilder.AddForeignKey(
                name: "FK_ClickHistories_ShortUrls_ShortUrlId",
                table: "ClickHistories",
                column: "ShortUrlId",
                principalTable: "ShortUrls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
