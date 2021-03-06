﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace chess.games.db.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImportedPgnGameIds",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportedPgnGameIds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PgnGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Event = table.Column<string>(maxLength: 450, nullable: false),
                    Site = table.Column<string>(maxLength: 450, nullable: false),
                    White = table.Column<string>(maxLength: 450, nullable: false),
                    Black = table.Column<string>(maxLength: 450, nullable: false),
                    Date = table.Column<string>(nullable: false),
                    Round = table.Column<string>(nullable: false),
                    Result = table.Column<string>(nullable: false),
                    MoveList = table.Column<string>(nullable: false),
                    Eco = table.Column<string>(nullable: true),
                    WhiteElo = table.Column<string>(nullable: true),
                    BlackElo = table.Column<string>(nullable: true),
                    CustomTagsJson = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PgnGames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PgnImportErrors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PgnGameId = table.Column<Guid>(nullable: false),
                    Error = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PgnImportErrors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PgnImports",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Event = table.Column<string>(nullable: false),
                    Site = table.Column<string>(nullable: false),
                    White = table.Column<string>(nullable: false),
                    Black = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: false),
                    Round = table.Column<string>(nullable: false),
                    Result = table.Column<string>(nullable: false),
                    MoveList = table.Column<string>(nullable: false),
                    Eco = table.Column<string>(nullable: true),
                    WhiteElo = table.Column<string>(nullable: true),
                    BlackElo = table.Column<string>(nullable: true),
                    CustomTagsJson = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PgnImports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Firstname = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: false),
                    OtherNames = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventLookup",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EventId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLookup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventLookup_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerLookup",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PlayerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerLookup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerLookup_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EventId = table.Column<Guid>(nullable: true),
                    SiteId = table.Column<Guid>(nullable: true),
                    WhiteId = table.Column<Guid>(nullable: true),
                    BlackId = table.Column<Guid>(nullable: true),
                    Date = table.Column<string>(maxLength: 30, nullable: true),
                    Round = table.Column<string>(nullable: true),
                    Result = table.Column<int>(nullable: false),
                    MoveText = table.Column<string>(nullable: true),
                    Eco = table.Column<string>(nullable: true),
                    WhiteElo = table.Column<int>(nullable: true),
                    BlackElo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Players_BlackId",
                        column: x => x.BlackId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Players_WhiteId",
                        column: x => x.WhiteId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SiteLookup",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    SiteId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteLookup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiteLookup_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventLookup_EventId",
                table: "EventLookup",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_BlackId",
                table: "Games",
                column: "BlackId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_EventId",
                table: "Games",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_SiteId",
                table: "Games",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_WhiteId",
                table: "Games",
                column: "WhiteId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerLookup_PlayerId",
                table: "PlayerLookup",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteLookup_SiteId",
                table: "SiteLookup",
                column: "SiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventLookup");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "ImportedPgnGameIds");

            migrationBuilder.DropTable(
                name: "PgnGames");

            migrationBuilder.DropTable(
                name: "PgnImportErrors");

            migrationBuilder.DropTable(
                name: "PgnImports");

            migrationBuilder.DropTable(
                name: "PlayerLookup");

            migrationBuilder.DropTable(
                name: "SiteLookup");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Sites");
        }
    }
}
