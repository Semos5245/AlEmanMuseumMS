using ALEmanMuseum.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALEmanMuseum.Data.Mapping
{
    public class UserActivityMap : EntityMapper<UserActivity>
    {
        public override void Configure(EntityTypeBuilder<UserActivity> builder)
        {
            builder.ToTable(nameof(UserActivity));
            builder.HasKey(activity => activity.Id);

            builder.Property(activity => activity.Description).HasMaxLength(512).IsRequired();
        }
    }
}
