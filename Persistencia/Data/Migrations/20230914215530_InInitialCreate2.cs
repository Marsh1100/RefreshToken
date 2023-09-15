using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InInitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_User_UserId",
                table: "RefreshToken");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "RefreshToken",
                newName: "IdUserFK");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                newName: "IX_RefreshToken_IdUserFK");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_User_IdUserFK",
                table: "RefreshToken",
                column: "IdUserFK",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_User_IdUserFK",
                table: "RefreshToken");

            migrationBuilder.RenameColumn(
                name: "IdUserFK",
                table: "RefreshToken",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshToken_IdUserFK",
                table: "RefreshToken",
                newName: "IX_RefreshToken_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_User_UserId",
                table: "RefreshToken",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
