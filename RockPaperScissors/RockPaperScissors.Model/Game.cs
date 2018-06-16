using System;
using System.Collections.Generic;

namespace RockPaperScissors.Model
{
    public class Game
    {
        public int Id { get; set; }
        public DateTime GameDate { get; set; }
        public PlayerType PlayerOneType { get; set; }
        public PlayerType PlayerTwoType { get; set; }
        public int GamePlayCount { get; set; }

        public ICollection<GamePlay> Plays { get; set; }

        public Game()
        {
            Plays = new List<GamePlay>();
        }
    }
}
