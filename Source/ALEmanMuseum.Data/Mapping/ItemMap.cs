using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Core.ExensionMethods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALEmanMuseum.Data.Mapping
{
    public class ItemMap : EntityMapper<Item>
    {
        public override void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable(nameof(Item).ToPlural());
            builder.HasKey(item => item.Id);

            builder.Property(item => item.UniqueNumber).HasDefaultValueSql("NEXT VALUE FOR ItemNumberSequence");
            builder.Property(item => item.Guid).HasMaxLength(10).IsRequired();
            builder.Property(item => item.OriginalPrice).HasColumnType("decimal(18, 8)");
            builder.Property(item => item.SellingPrice).HasColumnType("decimal(18, 8)");
            builder.Property(item => item.ArabicName).HasMaxLength(50);
            builder.Property(item => item.EnglishName).HasMaxLength(50);
            builder.Property(item => item.ArabicDescription).HasMaxLength(512);
            builder.Property(item => item.EnglishDescription).HasMaxLength(512);
            builder.Property(item => item.BarcodeImageUrl).HasMaxLength(512);

            builder.HasOne(item => item.Category)
                .WithMany()
                .HasForeignKey(item => item.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
