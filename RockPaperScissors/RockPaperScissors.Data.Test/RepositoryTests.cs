using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RockPaperScissors.Data.Repositories;

namespace RockPaperScissors.Data.Test
{
    [TestClass]
    public class RepositoryTests
    {
        // private Mock<DbSet<Rule>> _mockRuleDbSet;
        private Mock<RockPaperScissorsContext> _mockContext;
        private IGameRepository _gameRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            // Mock the DbContext
            _mockContext = new Mock<RockPaperScissorsContext>(null);   
            _gameRepository = new GameRepository(_mockContext.Object);
        }

        //[TestMethod]
        //public void GetAll_ReturnsList()
        //{
        //    // Arrange
        //    var mockGameDbSet = EfHelper.AsMockDbSet(GameList.GameListMock.ToList());
        //    _mockContext.Setup(m => m.Set<Game>()).Returns(mockGameDbSet.Object);
            
        //    // Act
        //    var games = _gameRepository.GetAll<Game>();

        //    // Assert
        //    Assert.AreEqual(3, games.Count());
        //    Assert.AreEqual("Player One Wins Test", games.First().Result.Text);
        //}
    }
}
