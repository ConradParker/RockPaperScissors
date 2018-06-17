using System;
using System.Collections.Generic;

namespace RockPaperScissors.Dto
{
    public class MatchDto
    {
        public int Id { get; set; }
        public DateTime GameDate { get; set; }
        public int PlayerOneId { get; set; }
        public int PlayerTwoId { get; set; }
        public int GameCount { get; set; }

        public ICollection<GameDto> Games { get; set; }
    }
}
