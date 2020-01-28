using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Configurations
{
    internal class SmartCardConfiguration : IEntityTypeConfiguration<SmartCard>
    {
        public void Configure(EntityTypeBuilder<SmartCard> builder)
        {
            builder.HasKey(sc => sc.ID);
            builder.Property(sc => sc.Key).IsRequired().HasMaxLength(2048);
            builder.Property(sc => sc.Name).IsRequired().HasMaxLength(2048);
            builder.HasIndex(sc => sc.Key).IsUnique();
        }
    }
}
