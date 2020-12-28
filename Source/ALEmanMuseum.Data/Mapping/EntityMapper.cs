using ALEmanMuseum.Core;
using ALEmanMuseum.Data.ModelConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALEmanMuseum.Data.Mapping
{
    public class EntityMapper<TEntity> : ICustomModelConfiguration, IEntityTypeConfiguration<TEntity> where TEntity: BaseEntity
    {
        public void ApplyCustomConfiguration(ModelBuilder builder)
        {
            builder.ApplyConfiguration(this);
        }

        public virtual void Configure(EntityTypeBuilder<TEntity> builder) { }
    }
}
