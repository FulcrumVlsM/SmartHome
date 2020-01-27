using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Configurations
{
    internal class Rule2BoolActionDeviceConfiguration : IEntityTypeConfiguration<Rule2BoolActionDevice>
    {
        public void Configure(EntityTypeBuilder<Rule2BoolActionDevice> builder)
        {
            builder.HasKey(r2bad => new { r2bad.BoolActionDeviceID, r2bad.RuleID });
        }
    }
}
