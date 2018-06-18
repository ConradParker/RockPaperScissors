using System;

namespace RockPaperScissors.Model
{
    public class Game
    {
        public int Id { get; set; }
        public DateTime GameDate { get; set; }
        public virtual Match Match { get; set; }
        public virtual GameItem PlayerOneChoice { get; set; }
        public virtual GameItem PlayerTwoChoice { get; set; }
        public virtual Result Result { get; set; }
    }
}
