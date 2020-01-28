using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHome.Data.Models;

namespace SmartHome.Data.EF.Configurations
{
    internal class UserConditionConfiguration : IEntityTypeConfiguration<UserCondition>
    {
        public void Configure(EntityTypeBuilder<UserCondition> builder)
        {
            builder.HasKey(uc => new { uc.RuleNodeID, uc.UserID });
        }
    }
}
