﻿using System;

namespace chess.db.webapi.Models
{
    public class PlayerDto
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string MiddleNames { get; set; }
        public string Lastname { get; set; }
    }
}