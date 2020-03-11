using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartHome.Data.EF.Configurations
{
    class UserEventActionConfiguration : IEntityTypeConfiguration<UserEventAction>
    {
        public void Configure(EntityTypeBuilder<UserEventAction> builder)
        {
            builder.HasKey(uea => uea.ID).IsClustered();
            builder.HasIndex(uea => uea.EventDeviceID).HasName("UX_UserEventAction_EventDeviceID").IsUnique();

            builder.HasOne(uea => uea.EventDevice)
                .WithOne(ed => ed.UserEventAction)
                .HasForeignKey<UserEventAction>(uea => uea.EventDeviceID);
        }
    }
}
