using RockPaperScissors.Dto.Query;
using RockPaperScissors.Model;
using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissors.Logic.Test.MockObjects
{
    public class ResultMocks
    {
        public static IQueryable<Result> Results
        {
            get
            {
                return new Result[]
                {
                    new Result { Id = 1, Text = "Player 1 Win" },
                    new Result { Id = 2, Text = "Player 2 Win" },
                    new Result { Id = 3, Text = "Draw" }
                }.AsQueryable();
            }
        }
    }
}
