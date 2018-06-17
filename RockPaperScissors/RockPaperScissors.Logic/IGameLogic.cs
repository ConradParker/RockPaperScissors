using RockPaperScissors.Dto;
using RockPaperScissors.Model;
using System;
using System.Collections.Generic;

namespace RockPaperScissors.Logic
{
    public interface IGameLogic
    {
        MatchDto GetMatch(int id);
        MatchDto StartMatch(int gamePlayCount, Player playerOne, Player playerTwo);
        MatchDto PlayGame(int gameId, int playerOneChoiceId, int playerTwoChoiceId);
        Player CreatePlayer(Player player);
        GameItem GetComputerChoice(int matchId);
    }
}
