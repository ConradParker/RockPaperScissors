using RockPaperScissors.Dto.Enums;
using System.Collections.Generic;

namespace RockPaperScissors.Dto.Query
{
    public class IndexView
    {
        public IEnumerable<PlayerType> PlayerTypes {get;set;}
    }
}
