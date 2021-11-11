using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Film.DAL.Migrations
{
    public partial class AddLastViewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Watchlists",
                table: "Watchlists");

            migrationBuilder.DropColumn(
                name: "LastView",
                table: "Watchlists");

            migrationBuilder.RenameTable(
                name: "Watchlists",
                newName: "Watchlist");

            migrationBuilder.RenameIndex(
                name: "IX_Watchlists_UserId_FilmId",
                table: "Watchlist",
                newName: "IX_Watchlist_UserId_FilmId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Watchlist",
                table: "Watchlist",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "LastView",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    View = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WatchlistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LastView_Watchlist_WatchlistId",
                        column: x => x.WatchlistId,
                        principalTable: "Watchlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LastView_WatchlistId",
                table: "LastView",
                column: "WatchlistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LastView");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Watchlist",
                table: "Watchlist");

            migrationBuilder.RenameTable(
                name: "Watchlist",
                newName: "Watchlists");

            migrationBuilder.RenameIndex(
                name: "IX_Watchlist_UserId_FilmId",
                table: "Watchlists",
                newName: "IX_Watchlists_UserId_FilmId");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastView",
                table: "Watchlists",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Watchlists",
                table: "Watchlists",
                column: "Id");
        }
    }
}
