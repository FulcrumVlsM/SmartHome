using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Configurations
{
    internal class TimeConditionConfiguration : IEntityTypeConfiguration<TimeCondition>
    {
        public void Configure(EntityTypeBuilder<TimeCondition> builder)
        {
            builder.HasKey(tc => tc.ID).IsClustered();

            builder.HasOne(tc => tc.Node)
                .WithMany(rn => rn.TimeConditions)
                .HasForeignKey(tc => tc.RuleNodeID);
        }
    }
}
