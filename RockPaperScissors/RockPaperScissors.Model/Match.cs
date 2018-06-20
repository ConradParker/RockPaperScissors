using System;
using System.Collections.Generic;

namespace RockPaperScissors.Model
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime MatchDate { get; set; }
        public int GameCount { get; set; }
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
        public Result Result { get; set; }

        public List<Game> Games { get; set; }

        public Match()
        {
            Games = new List<Game>();
        }
    }
}
