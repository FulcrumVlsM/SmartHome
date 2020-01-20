using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.EF.Models;

namespace SmartHome.Data.EF.Configurations
{
    class BoolActionDeviceHistoryConfiguration : IEntityTypeConfiguration<BoolActionDeviceHistory>
    {
        public void Configure(EntityTypeBuilder<BoolActionDeviceHistory> builder)
        {
            builder.HasKey(history => history.ID);
            builder.Property(history => history.SysName).IsRequired().HasMaxLength(1024);
            builder.Property(history => history.Value).IsRequired();
            builder.Property(history => history.CreateDate).HasDefaultValueSql("GETDATE()");

            builder.HasIndex(history => history.SysName);
            builder.HasIndex(history => new { history.SysName, history.CreateDate });
        }
    }
}
