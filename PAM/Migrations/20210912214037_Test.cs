using Microsoft.EntityFrameworkCore.Migrations;

namespace PAM.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeList_User_UserID",
                table: "AnimeList");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "AnimeList",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeList_User_UserID",
                table: "AnimeList",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeList_User_UserID",
                table: "AnimeList");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "AnimeList",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeList_User_UserID",
                table: "AnimeList",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
