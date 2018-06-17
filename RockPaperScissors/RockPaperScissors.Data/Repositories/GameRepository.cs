using AutoMapper.QueryableExtensions;
using RockPaperScissors.Dto;
using RockPaperScissors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public void AddGame(int matchId, GameItem playerOneChoice, GameItem playerTwoChoice)
        {
            // Find the match by Id
            var match = _dbContext.Set<Match>()
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
                PlayerTwoChoice = playerTwoChoice
            });
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
    }
}
