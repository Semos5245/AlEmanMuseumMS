using ALEmanMuseum.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALEmanMuseum.Data.Mapping
{
    public class SearchTermMap : EntityMapper<SearchTerm>
    {
        public override void Configure(EntityTypeBuilder<SearchTerm> builder)
        {
            builder.ToTable(nameof(SearchTerm));
            builder.HasKey(term => term.Id);

            builder.Property(term => term.Term).HasMaxLength(100).IsRequired();
        }
    }
}
