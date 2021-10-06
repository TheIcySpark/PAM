using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PAM.Migrations
{
    public partial class Recoverdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMDBItem", x => x.IMDBItemID);
                });

            migrationBuilder.CreateTable(
                name: "IMDBItemsList",
                columns: table => new
                {
                    IMDBItemsListID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMDBItemsList", x => x.IMDBItemsListID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoogleUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
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
                name: "IMDBItemsList");

            migrationBuilder.DropTable(
                name: "IMDBWriter");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "IMDBItem");
        }
    }
}
