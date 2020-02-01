using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartHome.Data.EF.Configurations
{
    internal class BoolSensorConditionConfiguration : IEntityTypeConfiguration<BoolSensorCondition>
    {
        public void Configure(EntityTypeBuilder<BoolSensorCondition> builder)
        {
            builder.HasKey(bsc => new { bsc.BoolSensorID, bsc.RuleNodeID }).IsClustered();

            builder.HasOne(bsc => bsc.Sensor)
                .WithMany(bs => bs.Conditions)
                .HasForeignKey(bsc => bsc.BoolSensorID);

            builder.HasOne(bsc => bsc.Node)
                .WithMany(rn => rn.BoolSensorConditions)
                .HasForeignKey(bsc => bsc.RuleNodeID);
        }
    }
}
