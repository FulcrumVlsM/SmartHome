﻿using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartHome.Data.EF.Configurations
{
    internal class EventDeviceHistoryConfiguration : IEntityTypeConfiguration<EventDeviceHistoryItem>
    {
        public void Configure(EntityTypeBuilder<EventDeviceHistoryItem> builder)
        {
            builder.ToTable("EventDeviceHistory");
            builder.HasKey(edh => edh.ID).IsClustered();
            builder.Property(edh => edh.SysName).IsRequired().HasMaxLength(1024);
            builder.Property(edh => edh.CreateDate).HasDefaultValueSql("GETDATE()");

            builder.HasIndex(edh => edh.SysName).IncludeProperties(edh => edh.CreateDate)
                .HasName("IX_EventDeviceHistory_SysName_CreateDate");
        }
    }
}
