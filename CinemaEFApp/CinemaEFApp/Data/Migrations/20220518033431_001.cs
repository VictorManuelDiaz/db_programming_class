using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaEFApp.Data.Migrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_clasification",
                columns: table => new
                {
                    clasification_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    identifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    admitted_age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_clasification", x => x.clasification_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_genre",
                columns: table => new
                {
                    genre_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_genre", x => x.genre_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_language",
                columns: table => new
                {
                    language_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_language", x => x.language_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_movie",
                columns: table => new
                {
                    movie_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    distribution_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    original_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    production_year = table.Column<int>(type: "int", nullable: false),
                    length = table.Column<TimeSpan>(type: "time", nullable: false),
                    premiere_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_on_billboard = table.Column<bool>(type: "bit", nullable: false),
                    genre_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    clasification_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_movie", x => x.movie_id);
                    table.ForeignKey(
                        name: "FK_tb_movie_tb_clasification_clasification_id",
                        column: x => x.clasification_id,
                        principalTable: "tb_clasification",
                        principalColumn: "clasification_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_movie_tb_genre_genre_id",
                        column: x => x.genre_id,
                        principalTable: "tb_genre",
                        principalColumn: "genre_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_movie_language",
                columns: table => new
                {
                    movie_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    language_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    movie_id1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    language_id1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    is_audio = table.Column<bool>(type: "bit", nullable: false),
                    is_subtitle = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_movie_language", x => new { x.movie_id, x.language_id });
                    table.ForeignKey(
                        name: "FK_tb_movie_language_tb_language_language_id1",
                        column: x => x.language_id1,
                        principalTable: "tb_language",
                        principalColumn: "language_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_movie_language_tb_movie_movie_id1",
                        column: x => x.movie_id1,
                        principalTable: "tb_movie",
                        principalColumn: "movie_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_movie_clasification_id",
                table: "tb_movie",
                column: "clasification_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_movie_genre_id",
                table: "tb_movie",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_movie_language_language_id1",
                table: "tb_movie_language",
                column: "language_id1");

            migrationBuilder.CreateIndex(
                name: "IX_tb_movie_language_movie_id1",
                table: "tb_movie_language",
                column: "movie_id1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_movie_language");

            migrationBuilder.DropTable(
                name: "tb_language");

            migrationBuilder.DropTable(
                name: "tb_movie");

            migrationBuilder.DropTable(
                name: "tb_clasification");

            migrationBuilder.DropTable(
                name: "tb_genre");
        }
    }
}
