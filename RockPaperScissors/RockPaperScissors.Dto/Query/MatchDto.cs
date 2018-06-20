using System;
using System.Collections.Generic;

namespace RockPaperScissors.Dto.Query
{
    public class MatchDto
    {
        public int Id { get; set; }
        public DateTime GameDate { get; set; }
        public int PlayerOneId { get; set; }
        public int PlayerTwoId { get; set; }
        public string PlayerOneType { get; set; }
        public string PlayerTwoType { get; set; }
        public int GameCount { get; set; }
        public string Result { get; set; }
        public ICollection<GameDto> Games { get; set; }
    }
}
