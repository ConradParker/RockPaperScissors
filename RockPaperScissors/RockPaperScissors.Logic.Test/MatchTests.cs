using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RockPaperScissors.Data.Repositories;
using RockPaperScissors.Logic.Test.MockObjects;
using RockPaperScissors.Model;
using System.Linq;

namespace RockPaperScissors.Logic.Test
{
    [TestClass]
    public class MatchTests
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
        public void StartMatch_AddsMatchToRepo()
        {
            // Arrange
            var match = MatchMocks.MatchWithTwoGames;

            // Act
            _gameLogic.StartMatch(match.GameCount , match.PlayerOne, match.PlayerTwo);

            // Assert
            _mockRepo.Verify(x => x.Create(It.IsAny<Model.Match>()), Times.Once());
        }
        
        [TestMethod]
        public void GetMatch_CallsRepo()
        {
            // Arrange
            
            // Act
            _gameLogic.GetMatch(1);

            // Assert
            _mockRepo.Verify(x => x.GetMatch(1), Times.Once());
        }
    }
}
