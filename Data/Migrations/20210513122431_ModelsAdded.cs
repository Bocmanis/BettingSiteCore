using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BettingSiteCore.Data.Migrations
{
    public partial class ModelsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    FlagCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    MatchupClosingTime = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    TieAllowed = table.Column<bool>(nullable: false),
                    PointsForPerfect = table.Column<int>(nullable: false),
                    PointForDifference = table.Column<int>(nullable: false),
                    PointsForWinnerOnly = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tournaments_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matchups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(nullable: false),
                    GameTime = table.Column<DateTime>(nullable: true),
                    TournamentId = table.Column<int>(nullable: false),
                    HomeTeamScore = table.Column<int>(nullable: true),
                    EnemyTeamScore = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matchups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matchups_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matchups_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PlayerTournaments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<int>(nullable: false),
                    ApsnetUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTournaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerTournaments_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Predictions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchupId = table.Column<int>(nullable: false),
                    AspNetUserId = table.Column<Guid>(nullable: false),
                    HomeTeamScore = table.Column<int>(nullable: false),
                    EnemyTeamScore = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Predictions_Matchups_MatchupId",
                        column: x => x.MatchupId,
                        principalTable: "Matchups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matchups_CountryId",
                table: "Matchups",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchups_TournamentId",
                table: "Matchups",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTournaments_TournamentId",
                table: "PlayerTournaments",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Predictions_MatchupId",
                table: "Predictions",
                column: "MatchupId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_CountryId",
                table: "Tournaments",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerTournaments");

            migrationBuilder.DropTable(
                name: "Predictions");

            migrationBuilder.DropTable(
                name: "Matchups");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
