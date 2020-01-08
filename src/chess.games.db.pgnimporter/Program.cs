﻿using System;
using System.IO;
using System.Linq;
using AutoMapper;
using chess.games.db.api.Repositories;
using chess.games.db.api.Services;
using chess.games.db.Entities;
using chess.games.db.pgnimporter.Mapping;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;

namespace chess.games.db.pgnimporter
{
    class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appSettings.json", optional: false)
            .AddEnvironmentVariables()
            .Build();

        private static ChessGamesDbContext _dbContext;
        private static readonly PgnFileFinder Finder = new PgnFileFinder();

        private static IMapper _mapper;
        private static IPgnImportService _svc;
        private static void RaiseStatus(string status) => Console.Write(status);
        static void Main(string[] args)
        {
            Startup();

            RaiseStatus("Performing any DB migrations...\n");
            _dbContext.UpdateDatabase();
            
            var scanPath = args.Any() ? args[0] : @"";

            if (scanPath != "")
            {
                RaiseStatus($"Starting import from: {scanPath}\n");
                Log.Information("{scanPath}", scanPath);
                var pgnFiles = Finder.FindFiles(scanPath);

                _svc.ImportGames(pgnFiles);
            }
            else
            {
                RaiseStatus("No pgn files/folders specified for input.\n");
            }

            RaiseStatus("Initialising validation process...\n");
            _svc.ProcessUnvalidatedGames();
        }

        private static void Startup()
        {

            var connectionString = Configuration["chess-games-db"];

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration).CreateLogger();
            var serilogLoggerFactory = new SerilogLoggerFactory(Log.Logger);

            _dbContext = new ChessGamesDbContext(connectionString, serilogLoggerFactory);
            _mapper = AutoMapperFactory.Create();

            var pgnRepository = new PgnRepository(_dbContext, serilogLoggerFactory.CreateLogger<PgnRepository>());
            _svc = new PgnImportService(pgnRepository, _mapper, serilogLoggerFactory.CreateLogger<PgnImportService>());
            
            _svc.Status += RaiseStatus;
        }

    }
}
