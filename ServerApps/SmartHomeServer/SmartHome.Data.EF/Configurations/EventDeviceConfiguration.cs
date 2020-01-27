using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Configurations
{
    internal class EventDeviceConfiguration : IEntityTypeConfiguration<EventDevice>
    {
        public void Configure(EntityTypeBuilder<EventDevice> builder)
        {
            builder.HasKey(ed => ed.ID);
            builder.Property(ed => ed.Name).IsRequired().HasMaxLength(2048);
            builder.Property(ed => ed.SysName).IsRequired().HasMaxLength(1024);
            builder.Property(ed => ed.CreateDate).HasDefaultValueSql("GETDATE()");
            builder.Property(ed => ed.LastEventDate).HasDefaultValueSql("GETDATE()");
            builder.HasIndex(ed => ed.SysName);
        }
    }
}
