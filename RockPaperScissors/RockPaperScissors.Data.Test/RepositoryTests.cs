using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RockPaperScissors.Data.Repositories;
using RockPaperScissors.Data.Test.Helpers;
using RockPaperScissors.Data.Test.MockObjects;
using RockPaperScissors.Model;
using System.Linq;

namespace RockPaperScissors.Data.Test
{
    [TestClass]
    public class RepositoryTests
    {
        private RockPaperScissorsContext _dbContext;
        private IGameRepository _gameRepository;
        
        
        [TestMethod]
        public void Create_AddsItemToDb()
        {
            // Arrange - Set up InMemory DB and add some mock data
            var options = new DbContextOptionsBuilder<RockPaperScissorsContext>()
                .UseInMemoryDatabase(databaseName: "CreateItemDb")
                .Options;

            // Act
            using (var context = new RockPaperScissorsContext(options))
            {
                _gameRepository = new GameRepository(context);
                _gameRepository.Create(MatchMocks.MatchWithTwoGames);
            }

            // Assert - Use a separate instance of the context to verify correct data was saved to database
            using (var context = new RockPaperScissorsContext(options))
            {
                Assert.AreEqual(1, context.Matches.Count());
                Assert.AreEqual(1, context.Matches.Single().Id);
            }
        }


        [TestMethod]
        public void GetById_ReturnsItemFromDb()
        {
            // Arrange - Set up InMemory DB and add some mock data
            var options = new DbContextOptionsBuilder<RockPaperScissorsContext>()
                .UseInMemoryDatabase(databaseName: "getById")
                .Options;
            using (var context = new RockPaperScissorsContext(options))
            {
                _gameRepository = new GameRepository(context);
                _gameRepository.Create(MatchMocks.MatchWithTwoGames);
            }

            // Use a separate instance of the context to verify correct data was pulled from database
            using (var context = new RockPaperScissorsContext(options))
            {
                // Act
                _gameRepository = new GameRepository(context);
                var match = _gameRepository.GetById<Model.Match>(1);

                // Assert
                Assert.AreEqual(1, match.Id);
            }
        }

        // TODO
        //[TestMethod]
        //public void GetPlayersLastChoice_ReturnsExpectedItem()
        //{
        //    // Arrange - Set up InMemory DB and add some mock data
        //    var options = new DbContextOptionsBuilder<RockPaperScissorsContext>()
        //        .UseInMemoryDatabase(databaseName: "LastChoiceDb")
        //        .Options;
        //    using (var context = new RockPaperScissorsContext(options))
        //    {
        //        _gameRepository = new GameRepository(context);
        //        context.Add(MatchMocks.MatchWithTwoGames.PlayerOne);
        //        context.Add(MatchMocks.MatchWithTwoGames.PlayerTwo);
        //        _gameRepository.Create(MatchMocks.MatchWithTwoGames);
        //    }

        //    // Act - Use a separate instance of the context to verify correct data was saved to database
        //    using (var context = new RockPaperScissorsContext(options))
        //    {
        //        // Arrange
        //        var gameRepository = new GameRepository(context);
        //        var player = context.TacticalComputers.Single();

        //        // Act
        //        var gameItem = gameRepository.GetPlayersLastChoice(player);

        //        // Assert
        //        Assert.AreEqual(1, gameItem.Id);
        //    }
        //}
    }
}
