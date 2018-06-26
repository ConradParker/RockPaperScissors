using RockPaperScissors.Dto.Query;
using RockPaperScissors.Model;
using System;
using System.Linq;

namespace RockPaperScissors.Logic.Test.MockObjects
{
    // Mock some Rock, Paper, Scissors Match Data
    public class MatchMocks
    {
        public static Match MatchWithTwoGames
        {
            get
            {
                var mockMatch = new Match
                {
                    Id = 1,
                    MatchDate = new DateTime(2018, 1, 1),
                    GameCount = 3,
                    PlayerOne = PlayerMocks.HumanPlayer,
                    PlayerTwo = PlayerMocks.Computer,
                    Games = GameMocks.TwoGameList.ToList()
                };

                return mockMatch;
            }
        }

        public static Match MatchWithThreeGames
        {
            get
            {
                var mockMatch = new Match
                {
                    Id = 1,
                    MatchDate = new DateTime(2018, 1, 1),
                    GameCount = 3,
                    PlayerOne = PlayerMocks.HumanPlayer,
                    PlayerTwo = PlayerMocks.TacticalPlayer,
                    Games = GameMocks.ThreeGameList.ToList()
                };

                return mockMatch;
            }
        }

        public static MatchDto MatchDto
        {
            get
            {
                var mock = new MatchDto
                {
                    Id = 1,
                    GameCount = 3,
                    PlayerOneId = 1,
                    PlayerTwoId = 2,
                    Games = GameMocks.ThreeGameViewList.ToList()
                };

                return mock;
            }
        }
    }
}