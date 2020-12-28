using ALEmanMuseum.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALEmanMuseum.Data.Mapping
{
    public class ShoppingCartItemMap : EntityMapper<ShoppingCartItem>
    {
        public override void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder.ToTable(nameof(ShoppingCartItem));
            builder.HasKey(cartItem => cartItem.Id);

            builder.HasOne(cartItem => cartItem.ShoppingCart)
                .WithMany(cart => cart.ShoppingCartItems)
                .HasForeignKey(cart => cart.ShoppingCartId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cartItem => cartItem.Item)
                .WithMany()
                .HasForeignKey(cart => cart.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
