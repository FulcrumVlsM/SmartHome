using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartHome.Data.EF.Configurations
{
    class BoolSensorHistoryConfiguration : IEntityTypeConfiguration<BoolSensorHistoryItem>
    {
        public void Configure(EntityTypeBuilder<BoolSensorHistoryItem> builder)
        {
            builder.ToTable("BoolSensorHistory");
            builder.HasKey(bsh => bsh.ID).IsClustered();
            builder.Property(bsh => bsh.SysName).IsRequired().HasMaxLength(1024);
            builder.Property(bsh => bsh.CreateDate).HasDefaultValueSql("GETDATE()");

            builder.HasIndex(bsh => bsh.SysName).IncludeProperties(bsh => bsh.CreateDate)
                .HasName("IX_BoolSensorHistory_SysName_CreateDate");
        }
    }
}
