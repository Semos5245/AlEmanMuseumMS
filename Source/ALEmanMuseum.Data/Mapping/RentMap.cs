using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Core.ExensionMethods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALEmanMuseum.Data.Mapping
{
    public class RentMap : EntityMapper<Rent>
    {
        public override void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.ToTable(nameof(Rent).ToPlural());
            builder.HasKey(rent => rent.Id);

            builder.Property(rent => rent.CustomerName).HasMaxLength(100).IsRequired();
            builder.Property(rent => rent.CustomerPhone).HasMaxLength(30);

            builder.HasOne(rent => rent.Customer)
                .WithMany()
                .HasForeignKey(rent => rent.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
