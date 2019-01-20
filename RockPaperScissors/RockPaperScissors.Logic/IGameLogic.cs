using RockPaperScissors.Dto.Enums;
using RockPaperScissors.Dto.Query;
using RockPaperScissors.Model;
using System.Collections.Generic;

namespace RockPaperScissors.Logic
{
    public interface IGameLogic : ILogic
    {
        Match GetMatch(int id);
        IEnumerable<PlayerType> GetPlayerTypes();
        MatchInfo GetMatchInfo(int id);
        MatchInfo StartMatch(int gamePlayCount, Player playerOne, Player playerTwo);
        MatchInfo PlayGame(Match match, GameItem playerOneChoice, GameItem playerTwoChoiceId);
        Player CreatePlayer(Player player);
        GameItem GetComputerChoice(Player computer);
        Result CalculateGameResult(GameItem playerOneChoice, GameItem playerTwoChoice);
    }
}
