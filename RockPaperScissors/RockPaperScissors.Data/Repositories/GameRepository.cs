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

        public MatchDto GetMatchDto(int id)
        {
            return _dbContext.Set<Match>()
                .Where(m => m.Id == id)
                .ProjectTo<MatchDto>()
                .SingleOrDefault();
        }

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

        public void CompleteMatch(Match match, Result result)
        {
            // Update and Save
            match.Result = result;
            _dbContext.SaveChanges();
        }

        public GameItem GetPlayersLastChoice(Player player)
        {
            var lastGame = _dbContext.Set<Match>()
                .Include(p=>p.PlayerOne)
                .Include(p => p.PlayerTwo)
                .LastOrDefault(m => m.PlayerOne.Id == player.Id ||
                    m.PlayerTwo.Id == player.Id &&
                    m.Games.Any())
                ?.Games
                .LastOrDefault();

            GameItem gameItem = null;
            if (lastGame != null)
            {
                gameItem = lastGame.Match.PlayerOne.Id == player.Id ?
                    lastGame.PlayerOneChoice :
                    lastGame.PlayerTwoChoice;
            }
            return gameItem;
        }

        public IEnumerable<GameItemDto> GetGameItemDtos()
        {
            return _dbContext.Set<GameItem>()
                .ProjectTo<GameItemDto>()
                .ToList();
        }

        #endregion Public Methods
    }
}
