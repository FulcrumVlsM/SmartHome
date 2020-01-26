using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartHome.Data.EF.Configurations
{
    internal class BoolSensorConditionConfiguration : IEntityTypeConfiguration<BoolSensorCondition>
    {
        public void Configure(EntityTypeBuilder<BoolSensorCondition> builder)
        {
            builder.HasKey(bsc => new { bsc.BoolSensorID, bsc.RuleNodeID });
            builder.Property(bsc => bsc.RequiredValue).HasDefaultValueSql("0");
        }
    }
}
