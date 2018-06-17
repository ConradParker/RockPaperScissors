using RockPaperScissors.Dto;
using RockPaperScissors.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Data.Repositories
{
    public interface IGameRepository : IRepository
    {
        MatchDto GetMatch(int id);
        void AddGame(int matchId, GameItem playerOneChoice, GameItem playerTwoChoice);
        GameItem GetPlayersLastChoice(Player player);
    }
}
