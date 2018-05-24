using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RockPaperScissors.Model;

namespace RockPaperScissors.Data
{
    public class GameItemConfiguration : IEntityTypeConfiguration<GameItem>
    {
        public void Configure(EntityTypeBuilder<GameItem> builder)
        {
            // TODO: Set foreign keys
        }
    }
}
