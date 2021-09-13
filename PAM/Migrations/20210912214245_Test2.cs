using Microsoft.EntityFrameworkCore.Migrations;

namespace PAM.Migrations
{
    public partial class Test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeList_User_UserID",
                table: "AnimeList");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "AnimeList",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeList_UserID",
                table: "AnimeList",
                newName: "IX_AnimeList_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeList_User_UserId",
                table: "AnimeList",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeList_User_UserId",
                table: "AnimeList");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AnimeList",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeList_UserId",
                table: "AnimeList",
                newName: "IX_AnimeList_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeList_User_UserID",
                table: "AnimeList",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
