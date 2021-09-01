using Microsoft.EntityFrameworkCore.Migrations;

namespace PAM.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GoogleUser",
                table: "User",
                newName: "GoogleUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GoogleUserID",
                table: "User",
                newName: "GoogleUser");
        }
    }
}
