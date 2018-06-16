using Microsoft.EntityFrameworkCore;
using RockPaperScissors.Model;

namespace RockPaperScissors.Data
{
    public class RockPaperScissorsContext :DbContext
    {
        public RockPaperScissorsContext(DbContextOptions<RockPaperScissorsContext> options)
            : base(options)
        {
        }

        public DbSet<GameItem> GameItems { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GamePlay> GamePlays { get; set; }
        public DbSet<PlayerType> PlayerTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GameItemConfiguration());
            modelBuilder.ApplyConfiguration(new RulesConfiguration());
            modelBuilder.ApplyConfiguration(new GameConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
