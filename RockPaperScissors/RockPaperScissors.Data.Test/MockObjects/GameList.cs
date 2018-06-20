using RockPaperScissors.Model;
using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissors.Data.Test.MockObjects
{
    public class GameList
    {
        public static IQueryable<Game> GameListMock
        {
            get
            {
                var games = new List<Game>
                {
                    new Game
                    {
                        Id = 1,
                        Match = new Match{ Id = 1 },
                        PlayerOneChoice = new GameItem{ Id = 1, Name = "Rock" },
                        PlayerTwoChoice = new GameItem{ Id = 2, Name = "Paper" },
                        Result = new Result{ Id = 1, Text="Player One Wins Test" }
                    },
                    new Game
                    {
                        Id = 2,
                        Match = new Match { Id = 1 },
                        PlayerOneChoice = new GameItem{ Id = 1, Name = "Scissors" },
                        PlayerTwoChoice = new GameItem{ Id = 2, Name = "Rock" },
                        Result = new Result{ Id = 2, Text="Player Two Wins Test" }
                    },
                    new Game
                    {
                        Id = 3,
                        Match = new Match { Id = 1 },
                        PlayerOneChoice = new GameItem{ Id = 1, Name = "Rock" },
                        PlayerTwoChoice = new GameItem{ Id = 2, Name = "Rock" },
                        Result = new Result{ Id = 3, Text="Draw Test" }
                    }
                }.AsQueryable();
                return games;
            }
        }
    }
}
