using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Core.ExensionMethods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALEmanMuseum.Data.Mapping
{
    public class CustomerMap : EntityMapper<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer).ToPlural());
            builder.HasKey(customer => customer.Id);

            builder.Property(customer => customer.Name).HasMaxLength(150).IsRequired();
            builder.Property(customer => customer.Email).HasMaxLength(100);
            builder.Property(customer => customer.Phone).HasMaxLength(50).IsRequired();

            builder.HasOne(customer => customer.Country)
                .WithMany()
                .HasForeignKey(customer => customer.CountryId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
