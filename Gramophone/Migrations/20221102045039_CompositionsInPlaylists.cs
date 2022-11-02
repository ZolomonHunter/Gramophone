using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gramophone.Migrations
{
    public partial class CompositionsInPlaylists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compositions_Playlists_PlaylistId",
                table: "Compositions");

            migrationBuilder.DropIndex(
                name: "IX_Compositions_PlaylistId",
                table: "Compositions");

            migrationBuilder.DropColumn(
                name: "PlaylistId",
                table: "Compositions");

            migrationBuilder.CreateTable(
                name: "CompositionPlaylist",
                columns: table => new
                {
                    CompositionsId = table.Column<int>(type: "int", nullable: false),
                    InPlaylistsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompositionPlaylist", x => new { x.CompositionsId, x.InPlaylistsId });
                    table.ForeignKey(
                        name: "FK_CompositionPlaylist_Compositions_CompositionsId",
                        column: x => x.CompositionsId,
                        principalTable: "Compositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompositionPlaylist_Playlists_InPlaylistsId",
                        column: x => x.InPlaylistsId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompositionPlaylist_InPlaylistsId",
                table: "CompositionPlaylist",
                column: "InPlaylistsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompositionPlaylist");

            migrationBuilder.AddColumn<int>(
                name: "PlaylistId",
                table: "Compositions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compositions_PlaylistId",
                table: "Compositions",
                column: "PlaylistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compositions_Playlists_PlaylistId",
                table: "Compositions",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id");
        }
    }
}
