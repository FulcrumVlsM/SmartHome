using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Configurations
{
    class EventActionDeviceConfiguration : IEntityTypeConfiguration<EventActionDevice>
    {
        public void Configure(EntityTypeBuilder<EventActionDevice> builder)
        {
            builder.HasKey(ead => ead.ID).IsClustered();
            builder.HasIndex(ead => ead.SysName).IsUnique().HasName("UX_EventActionDevice_SysName");

            builder.Property(ead => ead.SysName).HasMaxLength(1024);
            builder.Property(ead => ead.Name).HasMaxLength(2048);
            builder.Property(ead => ead.CreateDate).HasDefaultValueSql("GETDATE()");
            builder.Property(ead => ead.LastActivityDate).HasDefaultValueSql("GETDATE()");
        }
    }
}
