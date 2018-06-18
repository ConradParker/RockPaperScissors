using RockPaperScissors.Dto;
using RockPaperScissors.Model;

namespace RockPaperScissors.Data.Repositories
{
    public interface IGameRepository : IRepository
    {
        MatchDto GetMatch(int id);
        void AddGame(int matchId, GameItem playerOneChoice, GameItem playerTwoChoice, Result result);
        GameItem GetPlayersLastChoice(Player player);
    }
}
