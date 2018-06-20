using RockPaperScissors.Dto.Query;
using RockPaperScissors.Model;

namespace RockPaperScissors.Logic
{
    public interface IGameLogic : ILogic
    {
        Match GetMatch(int id);
        MatchView GetMatchView(int id);
        IndexView GetIndexView();
        MatchView StartMatch(int gamePlayCount, Player playerOne, Player playerTwo);
        MatchView PlayGame(Match match, GameItem playerOneChoice, GameItem playerTwoChoiceId);
        Player CreatePlayer(Player player);
        GameItem GetComputerChoice(Player computer);
        Result CalculateGameResult(GameItem playerOneChoice, GameItem playerTwoChoice);
    }
}
