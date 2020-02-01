using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Configurations
{
    class NumericSensorConditionConfiguration : IEntityTypeConfiguration<NumericSensorCondition>
    {
        public void Configure(EntityTypeBuilder<NumericSensorCondition> builder)
        {
            builder.HasKey(nsc => new { nsc.RuleNodeID, nsc.NumericSensorID }).IsClustered();

            builder.HasOne(nsc => nsc.Sensor)
                .WithMany(ns => ns.Conditions)
                .HasForeignKey(nsc => nsc.NumericSensorID);

            builder.HasOne(nsc => nsc.Node)
                .WithMany(rn => rn.NumericSensorConditions)
                .HasForeignKey(nsc => nsc.RuleNodeID);
        }
    }
}
