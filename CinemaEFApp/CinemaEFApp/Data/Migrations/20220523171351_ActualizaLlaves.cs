using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaEFApp.Data.Migrations
{
    public partial class ActualizaLlaves : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tb_movie_language_language_id",
                table: "tb_movie_language",
                column: "language_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_movie_language_tb_language_language_id",
                table: "tb_movie_language",
                column: "language_id",
                principalTable: "tb_language",
                principalColumn: "language_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_movie_language_tb_movie_movie_id",
                table: "tb_movie_language",
                column: "movie_id",
                principalTable: "tb_movie",
                principalColumn: "movie_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_movie_language_tb_language_language_id",
                table: "tb_movie_language");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_movie_language_tb_movie_movie_id",
                table: "tb_movie_language");

            migrationBuilder.DropIndex(
                name: "IX_tb_movie_language_language_id",
                table: "tb_movie_language");
        }
    }
}
