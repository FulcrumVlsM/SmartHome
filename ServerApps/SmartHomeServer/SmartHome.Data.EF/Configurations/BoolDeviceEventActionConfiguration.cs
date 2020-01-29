using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartHome.Data.EF.Configurations
{
    internal class BoolDeviceEventActionConfiguration : IEntityTypeConfiguration<BoolDeviceEventAction>
    {
        public void Configure(EntityTypeBuilder<BoolDeviceEventAction> builder)
        {
            builder.HasKey(bdea => new { bdea.BoolActionDeviceID, bdea.EventDeviceID }).IsClustered();

            builder.HasOne(bdea => bdea.EventDevice)
                .WithMany(ed => ed.Actions)
                .HasForeignKey(bdea => bdea.EventDeviceID);

            builder.HasOne(bdea => bdea.Device)
                .WithMany(bad => bad.EventActions)
                .HasForeignKey(bdea => bdea.BoolActionDeviceID);
        }
    }
}
