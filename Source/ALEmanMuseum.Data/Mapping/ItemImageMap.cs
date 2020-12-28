using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Core.ExensionMethods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALEmanMuseum.Data.Mapping
{
    public class ItemImageMap : EntityMapper<ItemImage>
    { 
        public override void Configure(EntityTypeBuilder<ItemImage> builder)
        {
            builder.ToTable(nameof(ItemImage).ToPlural());
            builder.HasKey(image => image.Id);

            builder.Property(image => image.ImageUrl).IsRequired();
            builder.Property(image => image.ThumbNailUrl);

            builder.HasOne(image => image.Item)
                .WithOne(item => item.ItemImage)
                .HasForeignKey<ItemImage>(image => image.ItemId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(image => image.Category)
                .WithMany(category => category.ItemImages)
                .HasForeignKey(image => image.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
