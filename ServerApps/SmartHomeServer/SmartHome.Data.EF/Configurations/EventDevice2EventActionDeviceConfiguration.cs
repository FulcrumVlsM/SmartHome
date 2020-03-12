using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Configurations
{
    class EventDevice2EventActionDeviceConfiguration : IEntityTypeConfiguration<EventDevice2EventActionDevice>
    {
        public void Configure(EntityTypeBuilder<EventDevice2EventActionDevice> builder)
        {
            builder.HasKey(ed2ead => new { ed2ead.EventActionDeviceID, ed2ead.EventDeviceID }).IsClustered();

            builder.HasOne(ed2ead => ed2ead.EventActionDevice)
                .WithMany(ead => ead.EventDevices2EventActionDevice)
                .HasForeignKey(ed2ead => ed2ead.EventActionDeviceID);

            builder.HasOne(ed2ead => ed2ead.EventDevice)
                .WithMany(ed => ed.EventDevice2EventActionDevices)
                .HasForeignKey(ed2ead => ed2ead.EventDeviceID);
        }
    }
}
