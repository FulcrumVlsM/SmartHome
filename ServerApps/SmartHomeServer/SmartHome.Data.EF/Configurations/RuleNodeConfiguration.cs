using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Configurations
{
    class RuleNodeConfiguration : IEntityTypeConfiguration<RuleNode>
    {
        public void Configure(EntityTypeBuilder<RuleNode> builder)
        {
            builder.HasKey(rn => rn.ID);
            builder.HasIndex(rn => new { rn.ID, rn.RuleID }).IsUnique();
        }
    }
}
