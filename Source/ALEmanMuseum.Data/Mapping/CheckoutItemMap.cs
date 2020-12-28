using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Core.ExensionMethods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALEmanMuseum.Data.Mapping
{
    public class CheckoutItemMap : EntityMapper<CheckoutItem>
    {
        public override void Configure(EntityTypeBuilder<CheckoutItem> builder)
        {
            builder.ToTable(nameof(CheckoutItem).ToPlural());
            builder.HasKey(checkoutItem => checkoutItem.Id);

            builder.Property(checkoutItem => checkoutItem.Price).HasColumnType("decimal(18, 8)");

            builder.HasOne(checkoutItem => checkoutItem.Checkout)
                .WithMany(checkout => checkout.CheckoutItems)
                .HasForeignKey(checkoutItem => checkoutItem.CheckoutId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(checkoutItem => checkoutItem.Item)
                .WithMany()
                .HasForeignKey(checkoutItem => checkoutItem.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
