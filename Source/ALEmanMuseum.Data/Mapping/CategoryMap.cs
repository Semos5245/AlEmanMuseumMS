using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Core.ExensionMethods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALEmanMuseum.Data.Mapping
{
    public class CategoryMap : EntityMapper<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category).ToPlural());
            builder.HasKey(category => category.Id);

            builder.Property(category => category.ArabicName).HasMaxLength(100).IsRequired();
            builder.Property(category => category.EnglishName).HasMaxLength(100).IsRequired();
        }
    }
}
