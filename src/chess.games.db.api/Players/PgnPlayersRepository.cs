﻿using System;
using System.Collections.Generic;
using chess.games.db.api.Helpers;
using chess.games.db.Entities;

namespace chess.games.db.api.Players
{
    public class PgnPlayersRepository : ResourceRepositoryBase<PgnPlayer>, IPgnPlayersRepository
    {
        public PgnPlayersRepository(ChessGamesDbContext dbContext)
        : base(dbContext) { }

        public new PgnPlayer Get(Guid id)
            => throw new NotSupportedException($"PgnPlayers do not have GUID primary key, use the Name instead.");

        public PgnPlayer Get(string name)
            => Resource.Find(name);
    }
}