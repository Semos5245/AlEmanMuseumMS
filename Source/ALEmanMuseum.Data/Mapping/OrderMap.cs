using ALEmanMuseum.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALEmanMuseum.Data.Mapping
{
    public class OrderMap : EntityMapper<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(nameof(Order));
            builder.HasKey(order => order.Id);
            
            builder.Property(order => order.OrderNumber)
                .HasDefaultValueSql("NEXT VALUE FOR OrderNumberSequence");

            builder.HasOne(order => order.Customer)
                .WithMany()
                .HasForeignKey(order => order.CustomerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(order => order.Address)
                .WithMany()
                .HasForeignKey(order => order.AddressId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(order => order.ShoppingCart)
                .WithOne()
                .HasForeignKey<Order>(order => order.ShoppingCartId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Ignore(order => order.OrderStatus);
        }
    }
}
