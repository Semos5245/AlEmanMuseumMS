using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Core.ExensionMethods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALEmanMuseum.Data.Mapping
{
    public class CheckoutMap : EntityMapper<Checkout>
    {
        public override void Configure(EntityTypeBuilder<Checkout> builder)
        {
            builder.ToTable(nameof(Checkout).ToPlural());
            builder.HasKey(checkout => checkout.Id);

            builder.Property(checkout => checkout.CustomerName).HasMaxLength(100);
            builder.Property(checkout => checkout.CustomerPhone).HasMaxLength(75);

            builder.HasOne(checkout => checkout.Customer)
                .WithMany()
                .HasForeignKey(checkout => checkout.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
