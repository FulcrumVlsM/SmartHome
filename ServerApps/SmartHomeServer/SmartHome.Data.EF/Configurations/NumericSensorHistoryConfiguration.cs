using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartHome.Data.EF.Configurations
{
    class NumericSensorHistoryConfiguration : IEntityTypeConfiguration<NumericSensorHistoryItem>
    {
        public void Configure(EntityTypeBuilder<NumericSensorHistoryItem> builder)
        {
            builder.ToTable("NumericSensorHistory");
            builder.HasKey(nsh => nsh.ID).IsClustered();
            builder.Property(nsh => nsh.SysName).IsRequired().HasMaxLength(1024);
            builder.Property(nsh => nsh.CreateDate).HasDefaultValueSql("GETDATE()");

            builder.HasIndex(nsh => nsh.SysName).IncludeProperties(nsh => nsh.CreateDate)
                .HasName("IX_NumericSensorHistory_SysName_CreateDate");
        }
    }
}
