using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RockPaperScissors.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace RockPaperScissors.Data
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            // Add auto increment PK
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
        }
    }
}
