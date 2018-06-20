using AutoMapper.QueryableExtensions;
using RockPaperScissors.Model;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RockPaperScissors.Dto.Query;
using System.Collections.Generic;

namespace RockPaperScissors.Data.Repositories
{
    public class GameRepository : Repository, IGameRepository
    {
        #region Constructor(s)

        public GameRepository(RockPaperScissorsContext dbContext) : base(dbContext) { }

        #endregion Constructor(s)

        #region Public Methods

        /// <summary>
        /// Get the Match Data Transfer Object
        /// </summary>
        /// <param name="id"></param>
        /// <returns>MatchDto</returns>
        public MatchDto GetMatchDto(int id)
        {
            return _dbContext.Set<Match>()
                .Where(m => m.Id == id)
                .ProjectTo<MatchDto>()
                .SingleOrDefault();
        }

        /// <summary>
        /// Get a Match Object
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Match Object</returns>
        public Match GetMatch(int id)
        {
            return _dbContext.Set<Match>()
                .Where(m => m.Id == id)
                .Include(m => m.PlayerOne)
                .Include(m => m.PlayerTwo)
                .Include(m => m.Games)
                .ThenInclude(g => g.Result)
                .SingleOrDefault();
        }

        /// <summary>
        /// Add a Game to the Repo
        /// </summary>
        /// <param name="match"></param>
        /// <param name="playerOneChoice"></param>
        /// <param name="playerTwoChoice"></param>
        /// <param name="result"></param>
        public void AddGame(Match match, GameItem playerOneChoice, GameItem playerTwoChoice, Result result)
        {
            // Save game play to the DB
            match.Games.Add(new Game
            {
                GameDate = DateTime.Now,
                PlayerOneChoice = playerOneChoice,
                PlayerTwoChoice = playerTwoChoice,
                Result = result
            });
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Completes a match
        /// </summary>
        /// <param name="match"></param>
        /// <param name="result"></param>
        public void CompleteMatch(Match match, Result result)
        {
            // Update and Save
            match.Result = result;
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Find the last choice of a player
        /// </summary>
        /// <param name="player"></param>
        /// <returns>GameItem Object</returns>
        public GameItem GetPlayersLastChoice(Player player)
        {
            var lastGameId = _dbContext.Set<Match>()
                .Include(p=>p.PlayerOne)
                .Include(p => p.PlayerTwo)
                .LastOrDefault(m => m.PlayerOne.Id == player.Id ||
                    m.PlayerTwo.Id == player.Id &&
                    m.Games.Any())
                ?.Games
                .LastOrDefault().Id;

            GameItem gameItem = null;
            if (lastGameId != null)
            {
                var lastGame = _dbContext.Set<Game>()
                .Include(g => g.PlayerOneChoice)
                .Include(g => g.PlayerTwoChoice)
                .Single(g => g.Id == lastGameId.Value);

                gameItem = lastGame.Match.PlayerOne.Id == player.Id ?
                    lastGame.PlayerOneChoice :
                    lastGame.PlayerTwoChoice;
            }
            return gameItem;
        }

        /// <summary>
        /// Get a list of GameItem Data Transfer Objects
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GameItemDto> GetGameItemDtos()
        {
            return _dbContext.Set<GameItem>()
                .ProjectTo<GameItemDto>()
                .ToList();
        }

        #endregion Public Methods
    }
}
