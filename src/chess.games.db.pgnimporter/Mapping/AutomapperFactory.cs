﻿using AutoMapper;

namespace chess.games.db.pgnimporter.Mapping
{
    public static class AutoMapperFactory
    {
        public static readonly MapperConfiguration MapperConfiguration = new MapperConfiguration(cfg => {
            cfg.AddProfile<PgnImportQueueMappingProfile>();
        });

        public static IMapper Create() 
            => MapperConfiguration.CreateMapper();
    }
}