using System;

namespace RockPaperScissors.Model
{
    public class Game
    {
        public int Id { get; set; }
        public Match Match { get; set; }
        public GameItem PlayerOneChoice { get; set; }
        public GameItem PlayerTwoChoice { get; set; }
        public DateTime GameDate { get; set; }
    }
}
