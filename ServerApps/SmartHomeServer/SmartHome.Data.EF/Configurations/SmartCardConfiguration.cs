using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Configurations
{
    internal class SmartCardConfiguration : IEntityTypeConfiguration<SmartCard>
    {
        public void Configure(EntityTypeBuilder<SmartCard> builder)
        {
            builder.HasKey(sc => sc.ID).IsClustered();
            builder.Property(sc => sc.Key).IsRequired().HasMaxLength(2048);
            builder.Property(sc => sc.Name).IsRequired().HasMaxLength(2048);
            builder.HasIndex(sc => sc.Key).IsUnique().HasName("UX_SmartCards_Key");

            builder.HasOne(sc => sc.User)
                .WithMany(u => u.SmartCards)
                .HasForeignKey(sc => sc.UserID);
        }
    }
}
