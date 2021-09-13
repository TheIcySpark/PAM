using Microsoft.EntityFrameworkCore.Migrations;

namespace PAM.Migrations
{
    public partial class Test7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnimeItemsList",
                table: "AnimeList",
                newName: "AnimeItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnimeItems",
                table: "AnimeList",
                newName: "AnimeItemsList");
        }
    }
}
