using ALEmanMuseum.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALEmanMuseum.Data.Mapping
{
    public class RentNoteMap : EntityMapper<RentNote>
    {
        public override void Configure(EntityTypeBuilder<RentNote> builder)
        {
            builder.ToTable(nameof(RentNote));
            builder.HasKey(note => note.Id);

            builder.Property(note => note.Note).HasMaxLength(256).IsRequired();

            builder.HasOne(note => note.Rent)
                .WithMany(rent => rent.RentNotes)
                .HasForeignKey(note => note.RentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
