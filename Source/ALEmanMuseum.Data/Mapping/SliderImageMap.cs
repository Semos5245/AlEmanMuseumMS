using ALEmanMuseum.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALEmanMuseum.Data.Mapping
{
    public class SliderImageMap : EntityMapper<SliderImage>
    {
        public override void Configure(EntityTypeBuilder<SliderImage> builder)
        {
            builder.ToTable(nameof(SliderImage));
            builder.HasKey(sliderImage => sliderImage.Id);

            builder.Property(sliderImage => sliderImage.ImageName).HasMaxLength(512).IsRequired();

            builder.HasOne(sliderImage => sliderImage.Slider)
                .WithMany(slider => slider.SliderImages)
                .HasForeignKey(sliderImage => sliderImage.SliderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
