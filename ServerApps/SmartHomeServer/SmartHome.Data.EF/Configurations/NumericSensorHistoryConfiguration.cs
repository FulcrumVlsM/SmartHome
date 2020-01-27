using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartHome.Data.EF.Configurations
{
    class NumericSensorHistoryConfiguration : IEntityTypeConfiguration<NumericSensorHistory>
    {
        public void Configure(EntityTypeBuilder<NumericSensorHistory> builder)
        {
            builder.HasKey(nsh => nsh.ID);
            builder.Property(nsh => nsh.SysName).IsRequired().HasMaxLength(1024);
            builder.Property(nsh => nsh.CreateDate).HasDefaultValueSql("GETDATE()");
            builder.HasIndex(nsh => nsh.SysName);
            builder.HasIndex(nsh => new { nsh.CreateDate, nsh.SysName });
        }
    }
}
