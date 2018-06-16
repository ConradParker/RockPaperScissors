using System;

namespace RockPaperScissors.Model
{
    public class GamePlay
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public GameItem PlayerOneChoice { get; set; }
        public GameItem PlayerTwoChoice { get; set; }
        //public int PlayerOneChoiceId { get; set; }
        //public int PlayerTwoChoiceId { get; set; }
        public DateTime GamePlayDate { get; set; }
    }
}
