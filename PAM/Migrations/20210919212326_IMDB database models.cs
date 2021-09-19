using Microsoft.EntityFrameworkCore.Migrations;

namespace PAM.Migrations
{
    public partial class IMDBdatabasemodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeList");

            migrationBuilder.CreateTable(
                name: "IMDBItemsList",
                columns: table => new
                {
                    IMDBItemsListID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMDBItemsList", x => x.IMDBItemsListID);
                    table.ForeignKey(
                        name: "FK_IMDBItemsList_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IMDBItem",
                columns: table => new
                {
                    IMDBItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Awards = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMDBRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMDBID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetacriticRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Runtime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrailerLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMDBItemsListID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMDBItem", x => x.IMDBItemID);
                    table.ForeignKey(
                        name: "FK_IMDBItem_IMDBItemsList_IMDBItemsListID",
                        column: x => x.IMDBItemsListID,
                        principalTable: "IMDBItemsList",
                        principalColumn: "IMDBItemsListID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IMDBActor",
                columns: table => new
                {
                    IMDBActorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CharacterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMDBItemID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMDBActor", x => x.IMDBActorID);
                    table.ForeignKey(
                        name: "FK_IMDBActor_IMDBItem_IMDBItemID",
                        column: x => x.IMDBItemID,
                        principalTable: "IMDBItem",
                        principalColumn: "IMDBItemID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IMDBCompany",
                columns: table => new
                {
                    IMDBCompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMDBItemID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMDBCompany", x => x.IMDBCompanyID);
                    table.ForeignKey(
                        name: "FK_IMDBCompany_IMDBItem_IMDBItemID",
                        column: x => x.IMDBItemID,
                        principalTable: "IMDBItem",
                        principalColumn: "IMDBItemID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IMDBDirector",
                columns: table => new
                {
                    IMDBDirectorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DirectorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMDBItemID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMDBDirector", x => x.IMDBDirectorID);
                    table.ForeignKey(
                        name: "FK_IMDBDirector_IMDBItem_IMDBItemID",
                        column: x => x.IMDBItemID,
                        principalTable: "IMDBItem",
                        principalColumn: "IMDBItemID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IMDBGenre",
                columns: table => new
                {
                    IMDBGenreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMDBItemID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMDBGenre", x => x.IMDBGenreID);
                    table.ForeignKey(
                        name: "FK_IMDBGenre_IMDBItem_IMDBItemID",
                        column: x => x.IMDBItemID,
                        principalTable: "IMDBItem",
                        principalColumn: "IMDBItemID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IMDBWriter",
                columns: table => new
                {
                    IMDBWriterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WriterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMDBItemID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMDBWriter", x => x.IMDBWriterID);
                    table.ForeignKey(
                        name: "FK_IMDBWriter_IMDBItem_IMDBItemID",
                        column: x => x.IMDBItemID,
                        principalTable: "IMDBItem",
                        principalColumn: "IMDBItemID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IMDBActor_IMDBItemID",
                table: "IMDBActor",
                column: "IMDBItemID");

            migrationBuilder.CreateIndex(
                name: "IX_IMDBCompany_IMDBItemID",
                table: "IMDBCompany",
                column: "IMDBItemID");

            migrationBuilder.CreateIndex(
                name: "IX_IMDBDirector_IMDBItemID",
                table: "IMDBDirector",
                column: "IMDBItemID");

            migrationBuilder.CreateIndex(
                name: "IX_IMDBGenre_IMDBItemID",
                table: "IMDBGenre",
                column: "IMDBItemID");

            migrationBuilder.CreateIndex(
                name: "IX_IMDBItem_IMDBItemsListID",
                table: "IMDBItem",
                column: "IMDBItemsListID");

            migrationBuilder.CreateIndex(
                name: "IX_IMDBItemsList_UserID",
                table: "IMDBItemsList",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_IMDBWriter_IMDBItemID",
                table: "IMDBWriter",
                column: "IMDBItemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IMDBActor");

            migrationBuilder.DropTable(
                name: "IMDBCompany");

            migrationBuilder.DropTable(
                name: "IMDBDirector");

            migrationBuilder.DropTable(
                name: "IMDBGenre");

            migrationBuilder.DropTable(
                name: "IMDBWriter");

            migrationBuilder.DropTable(
                name: "IMDBItem");

            migrationBuilder.DropTable(
                name: "IMDBItemsList");

            migrationBuilder.CreateTable(
                name: "AnimeList",
                columns: table => new
                {
                    AnimeListID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimeItems = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeList", x => x.AnimeListID);
                    table.ForeignKey(
                        name: "FK_AnimeList_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeList_UserID",
                table: "AnimeList",
                column: "UserID");
        }
    }
}
