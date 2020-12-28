using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Core.ExensionMethods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALEmanMuseum.Data.Mapping
{
    public class CountryMap : EntityMapper<Country>
    {
        public override void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable(nameof(Country).ToPlural());
            builder.HasKey(country => country.Id);

            builder.Property(country => country.Name).HasMaxLength(50).IsRequired();
        }
    }
}
