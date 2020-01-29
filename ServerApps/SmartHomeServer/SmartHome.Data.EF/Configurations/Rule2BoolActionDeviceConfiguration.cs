using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Configurations
{
    internal class Rule2BoolActionDeviceConfiguration : IEntityTypeConfiguration<Rule2BoolActionDevice>
    {
        public void Configure(EntityTypeBuilder<Rule2BoolActionDevice> builder)
        {
            builder.HasKey(r2bad => new { r2bad.BoolActionDeviceID, r2bad.RuleID }).IsClustered();

            builder.HasOne(r2bad => r2bad.Rule)
                .WithMany(r => r.Rule2BoolActionDevices)
                .HasForeignKey(r2bad => r2bad.RuleID);

            builder.HasOne(r2bad => r2bad.Device)
                .WithMany(bad => bad.Rule2BoolActionDevices)
                .HasForeignKey(r2bad => r2bad.BoolActionDeviceID);
        }
    }
}
