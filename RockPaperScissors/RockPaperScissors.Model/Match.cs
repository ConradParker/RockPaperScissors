using System;
using System.Collections.Generic;

namespace RockPaperScissors.Model
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime MatchDate { get; set; }
        public virtual Player PlayerOne { get; set; }
        public virtual Player PlayerTwo { get; set; }
        public int GameCount { get; set; }

        public ICollection<Game> Games { get; set; }

        public Match()
        {
            Games = new List<Game>();
        }
    }
}
