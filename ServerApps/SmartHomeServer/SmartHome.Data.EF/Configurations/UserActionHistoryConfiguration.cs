using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Configurations
{
    internal class UserActionHistoryConfiguration : IEntityTypeConfiguration<UserActionHistory>
    {
        public void Configure(EntityTypeBuilder<UserActionHistory> builder)
        {
            builder.HasKey(uah => uah.ID);
            builder.HasIndex(uah => uah.SmartCardID);
            builder.HasIndex(uah => uah.UserID);
        }
    }
}
