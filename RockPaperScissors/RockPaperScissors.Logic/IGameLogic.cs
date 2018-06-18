using RockPaperScissors.Dto;
using RockPaperScissors.Model;

namespace RockPaperScissors.Logic
{
    public interface IGameLogic : ILogic
    {
        MatchDto GetMatch(int id);
        MatchDto StartMatch(int gamePlayCount, Player playerOne, Player playerTwo);
        MatchDto PlayGame(int gameId, int playerOneChoiceId, int playerTwoChoiceId);
        Player CreatePlayer(Player player);
        GameItem GetComputerChoice(Computer computer);
    }
}
