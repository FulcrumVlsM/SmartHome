using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Configurations
{
    internal class Rule2EventDeviceConfiguration : IEntityTypeConfiguration<Rule2EventDevice>
    {
        public void Configure(EntityTypeBuilder<Rule2EventDevice> builder)
        {
            builder.HasKey(r2ed => new { r2ed.EventDeviceID, r2ed.RuleID }).IsClustered();

            builder.HasOne(r2ed => r2ed.Rule)
                .WithMany(r => r.Rule2EventDevices)
                .HasForeignKey(r2ed => r2ed.RuleID);

            builder.HasOne(r2ed => r2ed.Device)
                .WithMany(ed => ed.Rule2EventDevices)
                .HasForeignKey(r2ed => r2ed.EventDeviceID);
        }
    }
}
