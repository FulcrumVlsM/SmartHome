using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Configurations
{
    internal class UserConditionConfiguration : IEntityTypeConfiguration<UserCondition>
    {
        public void Configure(EntityTypeBuilder<UserCondition> builder)
        {
            builder.HasKey(uc => new { uc.RuleNodeID, uc.UserID }).IsClustered();

            builder.HasOne(uc => uc.Node)
                .WithMany(rn => rn.UserConditions)
                .HasForeignKey(uc => uc.RuleNodeID);

            builder.HasOne(uc => uc.User)
                .WithMany(u => u.Conditions)
                .HasForeignKey(uc => uc.UserID);
        }
    }
}
