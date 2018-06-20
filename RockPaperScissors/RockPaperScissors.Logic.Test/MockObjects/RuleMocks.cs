using RockPaperScissors.Dto.Query;
using RockPaperScissors.Model;
using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissors.Logic.Test.MockObjects
{
    public class RuleMocks
    {
        public static IQueryable<Rule> Rules
        {
            get
            {
                return new Rule[]
                {
                    new Rule { GameItemId = 1, BeatsId = 3, Reason = "Crushes" },
                    new Rule { GameItemId = 2, BeatsId = 1, Reason = "Covers" },
                    new Rule { GameItemId = 3, BeatsId = 2, Reason = "Cuts" }
                }.AsQueryable();
            }
        }
    }
}
