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
        }
    }
}
