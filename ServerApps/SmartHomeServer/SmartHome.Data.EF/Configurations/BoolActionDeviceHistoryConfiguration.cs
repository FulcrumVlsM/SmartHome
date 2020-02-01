using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Configurations
{
    class BoolActionDeviceHistoryConfiguration : IEntityTypeConfiguration<BoolActionDeviceHistory>
    {
        public void Configure(EntityTypeBuilder<BoolActionDeviceHistory> builder)
        {
            builder.HasKey(history => history.ID).IsClustered();
            builder.Property(history => history.SysName).IsRequired().HasMaxLength(1024);
            builder.Property(history => history.CreateDate).HasDefaultValueSql("GETDATE()");

            builder.HasIndex(history => history.SysName).IncludeProperties(history => history.CreateDate)
                .HasName("IX_BoolActionDeviceHistory_SysName_CreateDate");
        }
    }
}
