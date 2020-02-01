using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Configurations
{
    internal class RuleConfiguration : IEntityTypeConfiguration<Rule>
    {
        public void Configure(EntityTypeBuilder<Rule> builder)
        {
            builder.HasKey(r => r.ID).IsClustered();
            builder.Property(r => r.Name).IsRequired().HasMaxLength(2048);
            builder.Property(r => r.CreateDate).HasDefaultValueSql("GETDATE()");
        }
    }
}
