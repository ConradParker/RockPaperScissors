using RockPaperScissors.Dto.Query;
using RockPaperScissors.Model;
using System;
using System.Linq;

namespace RockPaperScissors.Data.Test.MockObjects
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
                    PlayerOne = new Human { Id = 1 },
                    PlayerTwo = new TacticalComputer { Id = 2 },
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
                    PlayerOne = new Human { Id = 1 },
                    PlayerTwo = new TacticalComputer { Id = 2 },
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