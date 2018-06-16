using RockPaperScissors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using RockPaperScissors.Dto;

namespace RockPaperScissors.Data.Repositories
{
    public class Repository : IRepository
    {
        private RockPaperScissorsContext _dbContext;

        public Repository(RockPaperScissorsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public GameDto AddGame(int gamePlayCount, PlayerType playerOneType, PlayerType playerTwoType)
        {
            var game = new Game
            {
                GameDate = DateTime.Now,
                GamePlayCount = gamePlayCount,
                PlayerOneType = playerOneType,
                PlayerTwoType = playerTwoType
            };
            _dbContext.Games.Add(game);
            _dbContext.SaveChanges();

            return GetGame(game.Id);
        }

        public GameDto GetGame(int id)
        {
            return _dbContext.Set<Game>()
                .Where(g => g.Id == id)                
                .ProjectTo<GameDto>()
                .SingleOrDefault();
        }

        /// <summary>
        /// Get a list of the player types
        /// </summary>
        /// <returns>List of PlayerType</returns>
        public IEnumerable<PlayerType> GetPlayerTypes()
        {
            return _dbContext.Set<PlayerType>();
        }

        /// <summary>
        /// Get a PlayerType by Id
        /// </summary>
        /// <param name="id">PlayerType id</param>
        /// <returns>PlayerType</returns>
        public PlayerType GetPlayerType(int id)
        {
            return _dbContext.Set<PlayerType>().SingleOrDefault(g => g.Id == id);
        }
    }
}