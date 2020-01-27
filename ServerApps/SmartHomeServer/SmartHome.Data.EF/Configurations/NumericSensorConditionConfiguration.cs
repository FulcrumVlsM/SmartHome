using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Configurations
{
    class NumericSensorConditionConfiguration : IEntityTypeConfiguration<NumericSensorCondition>
    {
        public void Configure(EntityTypeBuilder<NumericSensorCondition> builder)
        {
            builder.HasKey(nsc => new { nsc.RuleNodeID, nsc.NumericSensorID });
        }
    }
}
