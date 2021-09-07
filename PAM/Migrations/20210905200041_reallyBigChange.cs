using Microsoft.EntityFrameworkCore.Migrations;

namespace PAM.Migrations
{
    public partial class reallyBigChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimeList",
                columns: table => new
                {
                    AnimeListID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeList", x => x.AnimeListID);
                    table.ForeignKey(
                        name: "FK_AnimeList_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnimeItem",
                columns: table => new
                {
                    AnimeItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Synopsis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TralierLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Openings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Episodes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aired = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Studios = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenresList = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Premiered = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InformationLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnimeListID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeItem", x => x.AnimeItemID);
                    table.ForeignKey(
                        name: "FK_AnimeItem_AnimeList_AnimeListID",
                        column: x => x.AnimeListID,
                        principalTable: "AnimeList",
                        principalColumn: "AnimeListID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeItem_AnimeListID",
                table: "AnimeItem",
                column: "AnimeListID");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeList_UserID",
                table: "AnimeList",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeItem");

            migrationBuilder.DropTable(
                name: "AnimeList");
        }
    }
}
