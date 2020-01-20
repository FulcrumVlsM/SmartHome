using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.EF.Models;

namespace SmartHome.Data.EF.Configurations
{
    internal class BoolActionDeviceConfiguration : IEntityTypeConfiguration<BoolActionDevice>
    {
        public void Configure(EntityTypeBuilder<BoolActionDevice> builder)
        {
            builder.HasKey(bad => bad.ID);
            builder.Property(bad => bad.SysName).IsRequired().HasMaxLength(1024);
            builder.Property(bad => bad.Name).IsRequired();

            builder.HasIndex(bad => bad.SysName);
        }
    }
}
