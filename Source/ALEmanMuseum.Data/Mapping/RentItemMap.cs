using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Core.ExensionMethods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALEmanMuseum.Data.Mapping
{
    public class RentItemMap : EntityMapper<RentItem>
    {
        public override void Configure(EntityTypeBuilder<RentItem> builder)
        {
            builder.ToTable(nameof(RentItem).ToPlural());
            builder.HasKey(rentItem => rentItem.Id);

            builder.HasOne(rentItem => rentItem.Rent)
                .WithMany(rent => rent.RentItems)
                .HasForeignKey(rentItem => rentItem.RentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rentItem => rentItem.Item)
                .WithMany()
                .HasForeignKey(rentItem => rentItem.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
