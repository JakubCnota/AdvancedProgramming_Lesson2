using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvancedProgramming_Lesson1.Migrations
{
    public partial class CreatedBibliotekaSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    CountryOfOrigin = table.Column<string>(nullable: false),
                    PublishedBooksAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    Themes = table.Column<string>(nullable: false),
                    Popularity = table.Column<decimal>(type: "decimal(6, 2)", nullable: false),
                    AmountOfBooksWorldwide = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ksiazka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    YearOfRelease = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    PagesCount = table.Column<int>(nullable: false),
                    ListPrice = table.Column<decimal>(type: "decimal(6, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ksiazka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ksiazka_author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ksiazka_genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ksiazka_AuthorId",
                table: "Ksiazka",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ksiazka_GenreId",
                table: "Ksiazka",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ksiazka");

            migrationBuilder.DropTable(
                name: "author");

            migrationBuilder.DropTable(
                name: "genres");
        }
    }
}
