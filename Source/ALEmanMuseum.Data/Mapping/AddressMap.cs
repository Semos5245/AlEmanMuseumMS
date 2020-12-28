using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Core.ExensionMethods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALEmanMuseum.Data.Mapping
{
    public class AddressMap : EntityMapper<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable(nameof(Address).ToPlural());
            builder.HasKey(address => address.Id);

            builder.Property(address => address.Area).HasMaxLength(75);
            builder.Property(address => address.BuildingName).HasMaxLength(100);
            builder.Property(address => address.Floor).HasMaxLength(20);
            builder.Property(address => address.Street).HasMaxLength(50);

            builder.HasOne(address => address.Customer)
                .WithOne()
                .HasForeignKey<Address>(address => address.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
