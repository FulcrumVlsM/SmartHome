using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Configurations
{
    class RuleNodeConfiguration : IEntityTypeConfiguration<RuleNode>
    {
        public void Configure(EntityTypeBuilder<RuleNode> builder)
        {
            builder.HasKey(rn => rn.ID).IsClustered();
            builder.HasIndex(rn => rn.RuleID).HasName("IX_RuleNodeConfigurations_RuleID");

            builder.HasOne(rn => rn.Rule)
                .WithMany(r => r.Nodes)
                .HasForeignKey(rn => rn.RuleID);
        }
    }
}
