using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RockPaperScissors.Model;

namespace RockPaperScissors.Data
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            // Set foreign key
            builder.HasMany(g => g.Plays);
        }
    }
}
