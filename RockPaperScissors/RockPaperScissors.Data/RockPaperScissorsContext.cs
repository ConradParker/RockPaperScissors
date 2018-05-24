using Microsoft.EntityFrameworkCore;
using RockPaperScissors.Model;
using System;
using System.Collections.Generic;
using System.Text;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GameItemConfiguration());
            modelBuilder.ApplyConfiguration(new RulesConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
