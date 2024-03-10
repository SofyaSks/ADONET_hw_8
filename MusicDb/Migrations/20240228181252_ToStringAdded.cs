using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicDb.Migrations
{
    /// <inheritdoc />
    public partial class ToStringAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__artists__3214EC073DB9BB10", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    rating = table.Column<int>(type: "int", nullable: true),
                    weight = table.Column<int>(type: "int", nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__songs__3214EC07E497E6A7", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isBanned = table.Column<byte>(type: "tinyint", nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tmp_ms_x__3214EC0778DBA7BF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "song_artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongId = table.Column<int>(type: "int", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__song_art__3214EC0786299686", x => x.Id);
                    table.ForeignKey(
                        name: "fk_artistId",
                        column: x => x.ArtistId,
                        principalTable: "artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_songId",
                        column: x => x.SongId,
                        principalTable: "songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_song_artists_ArtistId",
                table: "song_artists",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_song_artists_SongId",
                table: "song_artists",
                column: "SongId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "song_artists");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "artists");

            migrationBuilder.DropTable(
                name: "songs");
        }
    }
}
