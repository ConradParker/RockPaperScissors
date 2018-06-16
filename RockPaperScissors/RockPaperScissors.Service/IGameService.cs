using RockPaperScissors.Model;
using System.Collections.Generic;

namespace RockPaperScissors.Service
{
    public interface IGameService
    {
        Game StartGame(int gamePlayCount, string playerOneType, string playerTwoType);
        IEnumerable<string> GetComputerPlayers();
    }
}
