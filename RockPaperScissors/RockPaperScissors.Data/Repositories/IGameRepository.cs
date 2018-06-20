using RockPaperScissors.Dto.Query;
using RockPaperScissors.Model;
using System.Collections.Generic;

namespace RockPaperScissors.Data.Repositories
{
    public interface IGameRepository : IRepository
    {
        Match GetMatch(int id);
        MatchDto GetMatchDto(int id);
        void AddGame(Match match, GameItem playerOneChoice, GameItem playerTwoChoice, Result result);
        GameItem GetPlayersLastChoice(Player player);
        void CompleteMatch(Match match, Result result);
        IEnumerable<GameItemDto> GetGameItemDtos();
    }
}
