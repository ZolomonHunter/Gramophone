using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gramophone.Migrations
{
    public partial class ModifiedPlaylist_AddedAlbom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListenerPlaylist_Listeners_UsersId",
                table: "ListenerPlaylist");

            migrationBuilder.DropForeignKey(
                name: "FK_ListenerPlaylist_Playlists_PlaylistId",
                table: "ListenerPlaylist");

            migrationBuilder.DropTable(
                name: "ActorPlaylist");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "ListenerPlaylist",
                newName: "SubscribersId");

            migrationBuilder.RenameColumn(
                name: "PlaylistId",
                table: "ListenerPlaylist",
                newName: "SubscribedPlaylistsId");

            migrationBuilder.RenameIndex(
                name: "IX_ListenerPlaylist_UsersId",
                table: "ListenerPlaylist",
                newName: "IX_ListenerPlaylist_SubscribersId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Playlists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Playlists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AlbomId",
                table: "Compositions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlaylistId",
                table: "Compositions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Albom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albom_Actors_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Actors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_OwnerId",
                table: "Playlists",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Compositions_AlbomId",
                table: "Compositions",
                column: "AlbomId");

            migrationBuilder.CreateIndex(
                name: "IX_Compositions_PlaylistId",
                table: "Compositions",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_Albom_OwnerId",
                table: "Albom",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compositions_Albom_AlbomId",
                table: "Compositions",
                column: "AlbomId",
                principalTable: "Albom",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Compositions_Playlists_PlaylistId",
                table: "Compositions",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ListenerPlaylist_Listeners_SubscribersId",
                table: "ListenerPlaylist",
                column: "SubscribersId",
                principalTable: "Listeners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListenerPlaylist_Playlists_SubscribedPlaylistsId",
                table: "ListenerPlaylist",
                column: "SubscribedPlaylistsId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Listeners_OwnerId",
                table: "Playlists",
                column: "OwnerId",
                principalTable: "Listeners",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compositions_Albom_AlbomId",
                table: "Compositions");

            migrationBuilder.DropForeignKey(
                name: "FK_Compositions_Playlists_PlaylistId",
                table: "Compositions");

            migrationBuilder.DropForeignKey(
                name: "FK_ListenerPlaylist_Listeners_SubscribersId",
                table: "ListenerPlaylist");

            migrationBuilder.DropForeignKey(
                name: "FK_ListenerPlaylist_Playlists_SubscribedPlaylistsId",
                table: "ListenerPlaylist");

            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Listeners_OwnerId",
                table: "Playlists");

            migrationBuilder.DropTable(
                name: "Albom");

            migrationBuilder.DropIndex(
                name: "IX_Playlists_OwnerId",
                table: "Playlists");

            migrationBuilder.DropIndex(
                name: "IX_Compositions_AlbomId",
                table: "Compositions");

            migrationBuilder.DropIndex(
                name: "IX_Compositions_PlaylistId",
                table: "Compositions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "AlbomId",
                table: "Compositions");

            migrationBuilder.DropColumn(
                name: "PlaylistId",
                table: "Compositions");

            migrationBuilder.RenameColumn(
                name: "SubscribersId",
                table: "ListenerPlaylist",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "SubscribedPlaylistsId",
                table: "ListenerPlaylist",
                newName: "PlaylistId");

            migrationBuilder.RenameIndex(
                name: "IX_ListenerPlaylist_SubscribersId",
                table: "ListenerPlaylist",
                newName: "IX_ListenerPlaylist_UsersId");

            migrationBuilder.CreateTable(
                name: "ActorPlaylist",
                columns: table => new
                {
                    ActorsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlaylistsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorPlaylist", x => new { x.ActorsId, x.PlaylistsId });
                    table.ForeignKey(
                        name: "FK_ActorPlaylist_Actors_ActorsId",
                        column: x => x.ActorsId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorPlaylist_Playlists_PlaylistsId",
                        column: x => x.PlaylistsId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorPlaylist_PlaylistsId",
                table: "ActorPlaylist",
                column: "PlaylistsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListenerPlaylist_Listeners_UsersId",
                table: "ListenerPlaylist",
                column: "UsersId",
                principalTable: "Listeners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListenerPlaylist_Playlists_PlaylistId",
                table: "ListenerPlaylist",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
