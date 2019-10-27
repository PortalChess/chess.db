﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
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

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("ECO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MoveText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PgnPlayerBlack")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PgnPlayerWhite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Result")
                        .HasColumnType("int");

                    b.Property<string>("Round")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SiteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("SiteId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("chess.games.db.Entities.GameImport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BlackName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("ECO")
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

                    b.Property<string>("WhiteName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BlackName");

                    b.HasIndex("EventId");

                    b.HasIndex("SiteId");

                    b.HasIndex("WhiteName");

                    b.ToTable("GameImports");
                });

            modelBuilder.Entity("chess.games.db.Entities.PgnPlayer", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Name");

                    b.HasIndex("PlayerId");

                    b.ToTable("PgnPlayers");
                });

            modelBuilder.Entity("chess.games.db.Entities.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Middlenames")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
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
                    b.HasOne("chess.games.db.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId");

                    b.HasOne("chess.games.db.Entities.Site", "Site")
                        .WithMany()
                        .HasForeignKey("SiteId");
                });

            modelBuilder.Entity("chess.games.db.Entities.GameImport", b =>
                {
                    b.HasOne("chess.games.db.Entities.PgnPlayer", "Black")
                        .WithMany()
                        .HasForeignKey("BlackName");

                    b.HasOne("chess.games.db.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId");

                    b.HasOne("chess.games.db.Entities.Site", "Site")
                        .WithMany()
                        .HasForeignKey("SiteId");

                    b.HasOne("chess.games.db.Entities.PgnPlayer", "White")
                        .WithMany()
                        .HasForeignKey("WhiteName");
                });

            modelBuilder.Entity("chess.games.db.Entities.PgnPlayer", b =>
                {
                    b.HasOne("chess.games.db.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");
                });
#pragma warning restore 612, 618
        }
    }
}
