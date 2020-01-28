using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Configurations
{
    internal class TimeConditionConfiguration : IEntityTypeConfiguration<TimeCondition>
    {
        public void Configure(EntityTypeBuilder<TimeCondition> builder)
        {
            builder.HasKey(tc => tc.RuleNodeID);
            builder.HasIndex(tc => new { tc.RuleNodeID, tc.Value, tc.ComparisonMode }).IsUnique();
        }
    }
}
