using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RockPaperScissors.Data.Repositories;
using RockPaperScissors.Logic.Test.MockObjects;
using RockPaperScissors.Model;
using System;
using System.Linq;

namespace RockPaperScissors.Logic.Test
{
    [TestClass]
    public class GameTests
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
        public void PlayGame_AddsGameToRepo()
        {
            // Arrange
            var match = MatchMocks.MatchWithTwoGames;
            var gameItem1 = GameItemMocks.PaperGameItem;
            var gameItem2 = GameItemMocks.RockGameItem;
            var result = ResultMocks.Results.First();
            _mockRepo.Setup(x => x.GetAll<Rule>()).Returns(RuleMocks.Rules);
            _mockRepo.Setup(x => x.GetById<Result>(1)).Returns(result);

            // Act
            _gameLogic.PlayGame(match, gameItem1, gameItem2);

            // Assert
            _mockRepo.Verify(x => x.AddGame(match, gameItem1, gameItem2, result), Times.Once());
        }

        [TestMethod]
        public void PlayGame_FailsIfGameCountExceeded()
        {
            // Act amd Assert
            Assert.ThrowsException<NotSupportedException>(() => _gameLogic.PlayGame(MatchMocks.MatchWithThreeGames, GameItemMocks.RockGameItem, GameItemMocks.PaperGameItem));
        }

        [TestMethod]
        public void PlayGame_CalculatesPlayerOneWin()
        {
            // Arrange
            _mockRepo.Setup(x => x.GetAll<Rule>()).Returns(RuleMocks.Rules);
            _mockRepo.Setup(x => x.GetById<Result>(1)).Returns(ResultMocks.Results.First());
            
            // Act
            var result = _gameLogic.CalculateGameResult(GameItemMocks.PaperGameItem, GameItemMocks.RockGameItem);

            // Assert
            Assert.AreEqual(result.Text, "Player 1 Win");
        }

        [TestMethod]
        public void PlayGame_CalculatesPlayerTwoWin()
        {
            // Arrange
            _mockRepo.Setup(x => x.GetAll<Rule>()).Returns(RuleMocks.Rules);
            _mockRepo.Setup(x => x.GetById<Result>(2)).Returns(ResultMocks.Results.Skip(1).First());

            // Act
            var result = _gameLogic.CalculateGameResult(GameItemMocks.RockGameItem, GameItemMocks.PaperGameItem);

            // Assert
            Assert.AreEqual(result.Text, "Player 2 Win");
        }

        [TestMethod]
        public void PlayGame_CalculatesDraw()
        {
            // Arrange
            _mockRepo.Setup(x => x.GetAll<Rule>()).Returns(RuleMocks.Rules);
            _mockRepo.Setup(x => x.GetById<Result>(3)).Returns(ResultMocks.Results.Last());

            // Act
            var result = _gameLogic.CalculateGameResult(GameItemMocks.PaperGameItem, GameItemMocks.PaperGameItem);

            // Assert
            Assert.AreEqual(result.Text, "Draw");
        }

        [TestMethod]
        public void GetComputerChoice_GetsTacticalChoice()
        {
            // Arrange
            var playerTwo = PlayerMocks.TacticalPlayer;
            _mockRepo.Setup(x => x.GetPlayersLastChoice(playerTwo)).Returns(GameItemMocks.ScissorsGameItem);
            _mockRepo.Setup(x => x.GetAll<Rule>()).Returns(RuleMocks.Rules);
            _mockRepo.Setup(x => x.GetById<GameItem>(1)).Returns(GameItemMocks.RockGameItem);

            // Act
            var result = _gameLogic.GetComputerChoice(playerTwo);

            // Assert
            Assert.AreEqual(result.Id, GameItemMocks.RockGameItem.Id);
            Assert.AreEqual(result.Name, GameItemMocks.RockGameItem.Name);
        }
    }
}
