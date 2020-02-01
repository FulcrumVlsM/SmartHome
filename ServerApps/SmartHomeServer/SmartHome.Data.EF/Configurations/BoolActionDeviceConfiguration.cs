using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Configurations
{
    internal class BoolActionDeviceConfiguration : IEntityTypeConfiguration<BoolActionDevice>
    {
        public void Configure(EntityTypeBuilder<BoolActionDevice> builder)
        {
            builder.HasKey(bad => bad.ID).IsClustered();
            builder.Property(bad => bad.SysName).IsRequired().HasMaxLength(1024);
            builder.Property(bad => bad.Name).IsRequired().HasMaxLength(2048);
            builder.Property(bad => bad.CreateDate).HasDefaultValueSql("GETDATE()");
            builder.Property(bad => bad.LastActivityDate).HasDefaultValueSql("GETDATE()");

            builder.HasIndex(bad => bad.SysName).IsUnique().HasName("UX_BoolActionDevice_SysName");
        }
    }
}
