using Microsoft.EntityFrameworkCore.Migrations;

namespace PAM.Migrations
{
    public partial class updateMIDBItemsListadduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IMDBItemsList_User_UserID",
                table: "IMDBItemsList");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "IMDBItemsList",
                newName: "UserID1");

            migrationBuilder.RenameIndex(
                name: "IX_IMDBItemsList_UserID",
                table: "IMDBItemsList",
                newName: "IX_IMDBItemsList_UserID1");

            migrationBuilder.AddForeignKey(
                name: "FK_IMDBItemsList_User_UserID1",
                table: "IMDBItemsList",
                column: "UserID1",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IMDBItemsList_User_UserID1",
                table: "IMDBItemsList");

            migrationBuilder.RenameColumn(
                name: "UserID1",
                table: "IMDBItemsList",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_IMDBItemsList_UserID1",
                table: "IMDBItemsList",
                newName: "IX_IMDBItemsList_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_IMDBItemsList_User_UserID",
                table: "IMDBItemsList",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
