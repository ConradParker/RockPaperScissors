using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RockPaperScissors.Model;

namespace RockPaperScissors.Data
{
    public class RulesConfiguration : IEntityTypeConfiguration<Rule>
    {
        public void Configure(EntityTypeBuilder<Rule> builder)
        {
            // Set primary key
            builder.HasKey(r => new { r.GameItemId, r.BeatsId });
        }
    }
}
