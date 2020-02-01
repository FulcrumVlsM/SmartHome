using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Configurations
{
    internal class UserActionHistoryConfiguration : IEntityTypeConfiguration<UserActionHistory>
    {
        public void Configure(EntityTypeBuilder<UserActionHistory> builder)
        {
            builder.HasKey(uah => uah.ID).IsClustered();
            builder.HasIndex(uah => uah.SmartCardID).HasName("IX_UserActionHistory_SmartCardID");
            builder.HasIndex(uah => uah.UserID).HasName("IX_UserActionHistory_UserID");

            builder.HasOne(uah => uah.User).WithMany(u => u.History)
                .HasForeignKey(uah => uah.UserID);

            builder.HasOne(uah => uah.SmartCard).WithMany(sc => sc.History)
                .HasForeignKey(uah => uah.SmartCardID);
        }
    }
}
