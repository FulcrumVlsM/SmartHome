using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartHome.Data.EF.Configurations
{
    class BoolSensorHistoryConfiguration : IEntityTypeConfiguration<BoolSensorHistory>
    {
        public void Configure(EntityTypeBuilder<BoolSensorHistory> builder)
        {
            builder.HasKey(bsh => bsh.ID);
            builder.Property(bsh => bsh.SysName).IsRequired().HasMaxLength(1024);
            builder.Property(bsh => bsh.CreateDate).HasDefaultValueSql("GETDATE()");
            builder.HasIndex(bsh => bsh.SysName);
            builder.HasIndex(bsh => new { bsh.SysName, bsh.CreateDate });
        }
    }
}
