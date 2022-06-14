using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicPlayer.Adaptors.SQLServerDataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_song",
                columns: table => new
                {
                    song_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    length = table.Column<TimeSpan>(type: "time", nullable: false),
                    artist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    album = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_song", x => x.song_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_user",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_user", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "tb_playlist",
                columns: table => new
                {
                    playlist_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creation_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_playlist", x => x.playlist_id);
                    table.ForeignKey(
                        name: "FK_tb_playlist_tb_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tb_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_added_song",
                columns: table => new
                {
                    song_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    playlist_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    addition_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_added_song", x => new { x.playlist_id, x.song_id });
                    table.ForeignKey(
                        name: "FK_tb_added_song_tb_playlist_playlist_id",
                        column: x => x.playlist_id,
                        principalTable: "tb_playlist",
                        principalColumn: "playlist_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_added_song_tb_song_song_id",
                        column: x => x.song_id,
                        principalTable: "tb_song",
                        principalColumn: "song_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_added_song_song_id",
                table: "tb_added_song",
                column: "song_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_playlist_user_id",
                table: "tb_playlist",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_added_song");

            migrationBuilder.DropTable(
                name: "tb_playlist");

            migrationBuilder.DropTable(
                name: "tb_song");

            migrationBuilder.DropTable(
                name: "tb_user");
        }
    }
}
