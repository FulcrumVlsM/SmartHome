using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartHome.Data.EF.Configurations
{
    internal class BoolSensorConfiguration : IEntityTypeConfiguration<BoolSensor>
    {
        public void Configure(EntityTypeBuilder<BoolSensor> builder)
        {
            builder.HasKey(bs => bs.ID).IsClustered();
            
            builder.Property(bs => bs.SysName).IsRequired().HasMaxLength(1024);
            builder.Property(bs => bs.Name).IsRequired().HasMaxLength(2048);
            builder.Property(bs => bs.CreateDate).HasDefaultValueSql("GETDATE()");
            builder.Property(bs => bs.LastActivity).HasDefaultValueSql("GETDATE()");

            builder.HasIndex(bs => bs.SysName).IsUnique().HasName("UX_BoolSensor_SysName");
        }
    }
}
