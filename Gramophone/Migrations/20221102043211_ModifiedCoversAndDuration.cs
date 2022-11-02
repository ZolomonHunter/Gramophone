using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gramophone.Migrations
{
    public partial class ModifiedCoversAndDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "Playlists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<long>(
                name: "Duration",
                table: "Compositions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "Albom",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Albom");

            migrationBuilder.AlterColumn<double>(
                name: "Duration",
                table: "Compositions",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
