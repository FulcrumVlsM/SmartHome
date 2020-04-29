using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Configurations
{
    internal class UserActionHistoryConfiguration : IEntityTypeConfiguration<UserActionHistoryItem>
    {
        public void Configure(EntityTypeBuilder<UserActionHistoryItem> builder)
        {
            builder.ToTable("UserActionHistory");
            builder.HasKey(uah => uah.ID).IsClustered();
            builder.HasIndex(uah => uah.UserID).HasName("IX_UserActionHistory_UserID");

            builder.HasOne(uah => uah.User).WithMany(u => u.History)
                .HasForeignKey(uah => uah.UserID);
        }
    }
}
