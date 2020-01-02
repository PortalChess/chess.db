﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using chess.games.db.Entities;

namespace chess.games.db.Migrations
{
    [DbContext(typeof(ChessGamesDbContext))]
    partial class ChessGamesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("chess.games.db.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("chess.games.db.Entities.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("BlackElo")
                        .HasColumnType("int");

                    b.Property<Guid?>("BlackId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Eco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MoveText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Result")
                        .HasColumnType("int");

                    b.Property<string>("Round")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SiteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("WhiteElo")
                        .HasColumnType("int");

                    b.Property<Guid?>("WhiteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BlackId");

                    b.HasIndex("EventId");

                    b.HasIndex("SiteId");

                    b.HasIndex("WhiteId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("chess.games.db.Entities.ImportedPgnGameIds", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("ImportedPgnGameIds");
                });

            modelBuilder.Entity("chess.games.db.Entities.PgnEvent", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("EventLookup");
                });

            modelBuilder.Entity("chess.games.db.Entities.PgnGame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Black")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<string>("BlackElo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomTagsJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Eco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Event")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<string>("MoveList")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Round")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Site")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<string>("White")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<string>("WhiteElo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PgnGames");
                });

            modelBuilder.Entity("chess.games.db.Entities.PgnImport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Black")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BlackElo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomTagsJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Eco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Event")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoveList")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Round")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Site")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("White")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhiteElo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PgnImports");
                });

            modelBuilder.Entity("chess.games.db.Entities.PgnImportError", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Error")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PgnGameId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("PgnImportErrors");
                });

            modelBuilder.Entity("chess.games.db.Entities.PgnPlayer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerLookup");
                });

            modelBuilder.Entity("chess.games.db.Entities.PgnSite", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("SiteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.ToTable("SiteLookup");
                });

            modelBuilder.Entity("chess.games.db.Entities.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherNames")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("chess.games.db.Entities.Site", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("chess.games.db.Entities.Game", b =>
                {
                    b.HasOne("chess.games.db.Entities.Player", "Black")
                        .WithMany()
                        .HasForeignKey("BlackId");

                    b.HasOne("chess.games.db.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId");

                    b.HasOne("chess.games.db.Entities.Site", "Site")
                        .WithMany()
                        .HasForeignKey("SiteId");

                    b.HasOne("chess.games.db.Entities.Player", "White")
                        .WithMany()
                        .HasForeignKey("WhiteId");
                });

            modelBuilder.Entity("chess.games.db.Entities.PgnEvent", b =>
                {
                    b.HasOne("chess.games.db.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("chess.games.db.Entities.PgnPlayer", b =>
                {
                    b.HasOne("chess.games.db.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("chess.games.db.Entities.PgnSite", b =>
                {
                    b.HasOne("chess.games.db.Entities.Site", "Site")
                        .WithMany()
                        .HasForeignKey("SiteId");
                });
#pragma warning restore 612, 618
        }
    }
}
