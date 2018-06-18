using AutoMapper.QueryableExtensions;
using RockPaperScissors.Data.Enums;
using RockPaperScissors.Dto;
using RockPaperScissors.Model;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RockPaperScissors.Data.Repositories
{
    public class GameRepository : Repository, IGameRepository
    {
        #region Constructor(s)

        public GameRepository(RockPaperScissorsContext dbContext) : base(dbContext) { }

        #endregion Constructor(s)

        #region Public Methods

        public MatchDto GetMatch(int id)
        {
            return _dbContext.Set<Match>()
                .Where(g => g.Id == id)
                .ProjectTo<MatchDto>()
                .SingleOrDefault();
        }

        public void AddGame(int matchId, GameItem playerOneChoice, GameItem playerTwoChoice, Result result)
        {
            // Find the match by Id
            var match = _dbContext.Set<Match>()
                .Include(m => m.Games)
                .ThenInclude(game => game.Result)
                .SingleOrDefault(g => g.Id == matchId);

            // Check we have not exceeded the allowed number of plays per game
            if (match.Games.Count >= match.GameCount)
            {
                throw new NotSupportedException("Game play count exceeded");
            }

            // Save game play to the DB
            match.Games.Add(new Game
            {
                Match = match,
                GameDate = DateTime.Now,
                PlayerOneChoice = playerOneChoice,
                PlayerTwoChoice = playerTwoChoice,
                Result = result
            });
            
            // Check if match is over
            if (match.Games.Count >= match.GameCount)
            {
                match.Result = CalculateMatchResult(match); 
            }
            _dbContext.SaveChanges();
        }

        public GameItem GetPlayersLastChoice(Player player)
        {
            var lastGame = _dbContext.Set<Match>().LastOrDefault(m => m.PlayerOne.Id == player.Id ||
                m.PlayerTwo.Id == player.Id &&
                m.Games.Any())?.Games.LastOrDefault();

            GameItem gameItem = null;
            if (lastGame != null)
            {
                gameItem = lastGame.Match.PlayerOne.Id == player.Id ?
                    lastGame.PlayerOneChoice :
                    lastGame.PlayerTwoChoice;
            }
            return gameItem;
        }

        #endregion Public Methods

        #region Private Methods
        
        /// <summary>
        /// Calculate the match result
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        private Result CalculateMatchResult(Match match)
        {
            var resultType = ResultType.Draw;

            var playerOneWinCount = match.Games.Count(game => game.Result.Id == (int)ResultType.Player1Win);
            var playerTwoWinCount = match.Games.Count(game => game.Result.Id == (int)ResultType.Player2Win);
            
            if (playerOneWinCount > playerTwoWinCount)
            {
                resultType = ResultType.Player1Win;
            }
            else if (playerTwoWinCount > playerOneWinCount)
            {
                resultType = ResultType.Player2Win;
            }

            return GetById<Result>((int)resultType);
        }

        #endregion Private Methods
    }
}
