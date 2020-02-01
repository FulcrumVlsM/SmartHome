using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.ID).IsClustered();
            builder.Property(u => u.Name).IsRequired().HasMaxLength(512);
            builder.Property(u => u.Enable).HasDefaultValue(true);
        }
    }
}
