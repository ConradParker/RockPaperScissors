using System;

namespace RockPaperScissors.Model
{
    public abstract class Player
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
