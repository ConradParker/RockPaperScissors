using RockPaperScissors.Model;
using System.Linq;

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

            // Add game items
            var gameItems = new GameItem[]
            {
                new GameItem { Name = "Rock", Icon = "hand-rock" },
                new GameItem { Name = "Paper", Icon = "hand-paper" },
                new GameItem { Name = "Scissors", Icon = "hand-scissors" }
            };
            context.GameItems.AddRange(gameItems);

            // Add rules
            var rules = new Rule[]
            {
                new Rule { GameItemId = 1, BeatsId = 3, Reason = "Crushes" },
                new Rule { GameItemId = 2, BeatsId = 1, Reason = "Covers" },
                new Rule { GameItemId = 3, BeatsId = 2, Reason = "Cuts" }
            };
            context.Rules.AddRange(rules);
            
            // Add result variations
            var results = new Result[]
            {
                new Result { Text = "Player 1 Win" },
                new Result { Text = "Player 2 Win" },
                new Result { Text = "Draw" }
            };
            context.Results.AddRange(results);

            context.SaveChanges();
        }
    }
}
