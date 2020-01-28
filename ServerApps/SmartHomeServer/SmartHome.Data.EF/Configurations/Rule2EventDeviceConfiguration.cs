using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Configurations
{
    internal class Rule2EventDeviceConfiguration : IEntityTypeConfiguration<Rule2EventDevice>
    {
        public void Configure(EntityTypeBuilder<Rule2EventDevice> builder)
        {
            builder.HasKey(r2ed => new { r2ed.EventDeviceID, r2ed.RuleID });
        }
    }
}
