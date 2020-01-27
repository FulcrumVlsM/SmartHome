using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Configurations
{
    internal class NumericSensorConfiguration : IEntityTypeConfiguration<NumericSensor>
    {
        public void Configure(EntityTypeBuilder<NumericSensor> builder)
        {
            builder.HasKey(ns => ns.ID);
            builder.Property(ns => ns.SysName).IsRequired().HasMaxLength(1024);
            builder.Property(ns => ns.Name).IsRequired().HasMaxLength(2048);
            builder.Property(ns => ns.CreateDate).HasDefaultValueSql("GETDATE()");
            builder.Property(ns => ns.LastActivity).HasDefaultValueSql("GETDATE()");
        }
    }
}
