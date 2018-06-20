using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RockPaperScissors.Model;

namespace RockPaperScissors.Data
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            // Add auto increment PK
            builder.Property(g => g.Id).ValueGeneratedOnAdd();
        }
    }
}
