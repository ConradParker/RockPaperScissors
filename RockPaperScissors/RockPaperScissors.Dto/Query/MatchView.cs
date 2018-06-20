using System.Collections.Generic;

namespace RockPaperScissors.Dto.Query
{
    public class MatchView
    {
        public MatchDto MatchData { get; set; }
        public IEnumerable<GameItemDto> GameItems { get; set; }
    }
}
