using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RockPaperScissors.Data.Repositories;
using RockPaperScissors.Logic.Test.MockObjects;
using RockPaperScissors.Model;
using System.Linq;

namespace RockPaperScissors.Logic.Test
{
    [TestClass]
    public class ComputerTests
    {
        private Mock<IGameRepository> _mockRepo;
        private GameLogic _gameLogic;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepo = new Mock<IGameRepository>();
            _gameLogic = new GameLogic(_mockRepo.Object);
        }

        [TestMethod]
        public void Computer_SelectsTacticalGameItem()
        {
            // Arrange
            var tacticalPlayer = MatchMocks.MatchWithTwoGames.PlayerTwo;
            var lastChoice = MatchMocks.MatchWithTwoGames.Games.Last().PlayerTwoChoice;
            _mockRepo.Setup(x => x.GetPlayersLastChoice(tacticalPlayer)).Returns(lastChoice);
            _mockRepo.Setup(x => x.GetAll<Rule>()).Returns(RuleMocks.Rules);
            _mockRepo.Setup(x => x.GetById<Result>(1)).Returns(ResultMocks.Results.First());

            // Act
            var nextChoice = _gameLogic.GetComputerChoice(tacticalPlayer);

            // Assert
            Assert.Equals(nextChoice.Id, 2);
        }
    }
}
