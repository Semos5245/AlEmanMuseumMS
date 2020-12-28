using ALEmanMuseum.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALEmanMuseum.Data.Mapping
{
    public class ShoppingCartMap : EntityMapper<ShoppingCart>
    {
        public override void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.ToTable(nameof(ShoppingCart));
            builder.HasKey(cart => cart.Id);

            builder.HasOne(cart => cart.Customer)
                .WithMany()
                .HasForeignKey(cart => cart.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(cart => cart.ShoppingCartStatus);
        }
    }
}
