﻿using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCore.MVC.RESTful.Repositories;
using chess.games.db.Entities;

namespace chess.games.db.api.Repositories
{
    public interface IPlayersRepository : IResourceRepository<Player, Guid>
    {
        IEnumerable<Player> Load(IEnumerable<Guid> ids);
    }

    public class PlayersRepository : EntityFrameworkResourceRepository<Player, Guid>, IPlayersRepository
    {
        public PlayersRepository(
            ChessGamesDbContext dbContext
        )
            : base(dbContext) { }

        public IEnumerable<Player> Load(IEnumerable<Guid> ids)
            => Resource.Where(p => ids.Contains(p.Id));

    }
}