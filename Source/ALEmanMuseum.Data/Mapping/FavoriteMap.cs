using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Core.ExensionMethods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALEmanMuseum.Data.Mapping
{
    public class FavoriteMap : EntityMapper<Favorite>
    {
        public override void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable(nameof(Favorite).ToPlural());
            builder.HasKey(favorite => favorite.Id);

            builder.HasOne(favorite => favorite.Customer)
                .WithMany(customer => customer.Favorites)
                .HasForeignKey(favorite => favorite.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(favorite => favorite.Item)
                .WithMany()
                .HasForeignKey(favorite => favorite.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
