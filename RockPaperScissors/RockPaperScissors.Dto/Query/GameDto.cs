using System;
using System.Collections.Generic;

namespace RockPaperScissors.Dto
{
    public class GameDto
    {
        public int Id { get; set; }
        public DateTime GameDate { get; set; }
        public string PlayerOneType { get; set; }
        public string PlayerTwoType { get; set; }
        public int GamePlayCount { get; set; }

        public ICollection<GamePlayDto> Plays { get; set; }
    }
}
