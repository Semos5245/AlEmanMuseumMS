using ALEmanMuseum.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALEmanMuseum.Data.Mapping
{
    public class SliderMap : EntityMapper<Slider>
    {
        public override void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.ToTable(nameof(Slider));
            builder.HasKey(slider => slider.Id);

            builder.Property(slider => slider.ArabicName).HasMaxLength(50).IsRequired();
            builder.Property(slider => slider.EnglishName).HasMaxLength(50).IsRequired();
        }
    }
}
