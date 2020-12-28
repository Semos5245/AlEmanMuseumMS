using Microsoft.EntityFrameworkCore;

namespace ALEmanMuseum.Data.ModelConfiguration
{
    public interface ICustomModelConfiguration
    {
        void ApplyCustomConfiguration(ModelBuilder builder);
    }
}
