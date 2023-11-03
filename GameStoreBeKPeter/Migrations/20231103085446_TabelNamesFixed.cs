using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStoreBeKPeter.Migrations
{
    /// <inheritdoc />
    public partial class TabelNamesFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VIdeoGamesUser_Users_UserId",
                table: "VIdeoGamesUser");

            migrationBuilder.DropForeignKey(
                name: "FK_VIdeoGamesUser_VideoGames_VideoGameId",
                table: "VIdeoGamesUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VIdeoGamesUser",
                table: "VIdeoGamesUser");

            migrationBuilder.RenameTable(
                name: "VIdeoGamesUser",
                newName: "VideoGamesUsers");

            migrationBuilder.RenameIndex(
                name: "IX_VIdeoGamesUser_VideoGameId",
                table: "VideoGamesUsers",
                newName: "IX_VideoGamesUsers_VideoGameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoGamesUsers",
                table: "VideoGamesUsers",
                columns: new[] { "UserId", "VideoGameId" });

            migrationBuilder.AddForeignKey(
                name: "FK_VideoGamesUsers_Users_UserId",
                table: "VideoGamesUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoGamesUsers_VideoGames_VideoGameId",
                table: "VideoGamesUsers",
                column: "VideoGameId",
                principalTable: "VideoGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoGamesUsers_Users_UserId",
                table: "VideoGamesUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoGamesUsers_VideoGames_VideoGameId",
                table: "VideoGamesUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoGamesUsers",
                table: "VideoGamesUsers");

            migrationBuilder.RenameTable(
                name: "VideoGamesUsers",
                newName: "VIdeoGamesUser");

            migrationBuilder.RenameIndex(
                name: "IX_VideoGamesUsers_VideoGameId",
                table: "VIdeoGamesUser",
                newName: "IX_VIdeoGamesUser_VideoGameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VIdeoGamesUser",
                table: "VIdeoGamesUser",
                columns: new[] { "UserId", "VideoGameId" });

            migrationBuilder.AddForeignKey(
                name: "FK_VIdeoGamesUser_Users_UserId",
                table: "VIdeoGamesUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VIdeoGamesUser_VideoGames_VideoGameId",
                table: "VIdeoGamesUser",
                column: "VideoGameId",
                principalTable: "VideoGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
