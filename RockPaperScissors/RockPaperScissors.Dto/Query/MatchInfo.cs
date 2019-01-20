using System.Collections.Generic;

namespace RockPaperScissors.Dto.Query
{
    public class MatchInfo
    {
        public MatchDto MatchData { get; set; }
        public IEnumerable<GameItemDto> GameItems { get; set; }
    }
}
