using RockPaperScissors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RockPaperScissors.Data
{
    public static class DbInitializer
    {
        public static void Initialize(RockPaperScissorsContext context)
        {
            context.Database.EnsureCreated();

            // Look for any existing data.
            if (context.GameItems.Any())
            {
                return;   // DB has been seeded
            }

            // TODO: Add explicit Ids
            var gameItems = new GameItem[]
            {
                new GameItem { Name = "Rock" },
                new GameItem { Name = "Paper" },
                new GameItem { Name = "Scissors" }
            };
            context.GameItems.AddRange(gameItems);

            var rules = new Rule[]
            {
                new Rule { GameItemId = 1, BeatsId = 3, Reason = "Crushes" },
                new Rule { GameItemId = 2, BeatsId = 1, Reason = "Covers" },
                new Rule { GameItemId = 3, BeatsId = 2, Reason = "Cuts" }
            };
            context.Rules.AddRange(rules);
            context.SaveChanges();
        }
    }
}
