﻿using System;
using System.Collections.Generic;
using AutoMapper;
using chess.db.webapi.Models;
using chess.db.webapi.ResourceParameters;
using chess.db.webapi.Services;
using chess.games.db.api.Players;
using chess.games.db.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace chess.db.webapi.Controllers
{
    [ApiController]
    [Route("api/players")]
    public class PlayersController : ResourceControllerBase<PlayerDto, Player>
    {
        private readonly ILogger<PlayersController> _logger;

        private const string GetPlayerRouteName = "Get";
        private const string GetPlayersRouteName = "GetPlayers";

        public PlayersController(IMapper mapper,
            IPlayersRepository playersRepository,
            IOrderByPropertyMappingService orderByPropertyMappingService,
            ILogger<PlayersController> logger) 
            : base(mapper, playersRepository, orderByPropertyMappingService)
        {
            _logger = logger ?? NullLogger<PlayersController>.Instance;
        }

        private const string UpsertPlayerRouteName = "UpsertPlayer";

        [HttpGet(Name = GetPlayersRouteName)]
        [HttpHead]
        public ActionResult<IEnumerable<PlayerDto>> GetPlayers(
            [FromQuery] GetPlayersParameters parameters
        )
        {
            var filters = Mapper.Map<PlayersFilters>(parameters);
            var query = Mapper.Map<PlayersSearchQuery>(parameters);

            return ResourcesGet(
                parameters, 
                filters, 
                query, 
                GetPlayersRouteName);
        }

        [HttpGet("{id}", Name = GetPlayerRouteName)]
        public ActionResult<PlayerDto> GetPlayer(Guid id)
            => ResourceGet(id);

        [HttpPost]
        public ActionResult<PlayerDto> CreatePlayer(PlayerCreationDto model)
            => ResourceCreate(model, GetPlayerRouteName);

        [HttpPut("{id}", Name = UpsertPlayerRouteName)]
        public ActionResult UpsertPlayer(Guid id, PlayerUpdateDto model)
            => ResourceUpsert(id, model, GetPlayerRouteName);

        [HttpPatch("{id}")]
        public ActionResult PatchPlayer(Guid id,
            JsonPatchDocument<PlayerUpdateDto> patchDocument)
            => ResourcePatch(id, patchDocument);

        [HttpDelete("{id}")]
        public ActionResult DeletePlayer(Guid id)
            => ResourceDelete(id);

        [HttpOptions]
        public IActionResult GetOptions()
            => ResourceOptions("HEAD", "OPTIONS", "GET", "POST", "PUT", "PATCH", "DELETE");
    }
}
