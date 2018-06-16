using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RockPaperScissors.Model;

namespace RockPaperScissors.Data
{
    public class GamePlayConfiguration : IEntityTypeConfiguration<GamePlay>
    {
        public void Configure(EntityTypeBuilder<GamePlay> builder)
        {
            // Set foreign key
            // 
        }
    }
}
