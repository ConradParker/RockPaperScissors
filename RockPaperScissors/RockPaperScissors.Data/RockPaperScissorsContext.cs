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
        public DbSet<Match> Matches { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Human> Humans { get; set; }
        public DbSet<TacticalComputer> TacticalComputers { get; set; }
        public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new RulesConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
