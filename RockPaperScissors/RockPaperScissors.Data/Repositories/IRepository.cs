using RockPaperScissors.Dto;
using RockPaperScissors.Model;
using System.Collections.Generic;

namespace RockPaperScissors.Data.Repositories
{
    public interface IRepository
    {
        GameDto GetGame(int gameId);
        GameDto AddGame(int gamePlayCount, PlayerType playerOneType, PlayerType playerTwoType);
        IEnumerable<PlayerType> GetPlayerTypes();
        PlayerType GetPlayerType(int id);
    }
}
