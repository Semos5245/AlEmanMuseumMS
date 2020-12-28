using ALEmanMuseum.Core;
using ALEmanMuseum.Services.ServicesResponse;
using System.Threading.Tasks;

namespace ALEmanMuseum.Services
{
    public interface IService<TEntity, TError> where TEntity : BaseEntity
    {
        Task<EntitiesResponse<TEntity, TError>> GetAllEntitiesAsync();
        Task<int> GetEntitiesCountAsync();
        Task<EntityResponse<TEntity, TError>> GetEntityByIdAsync(int entityId);
        Task<EntitiesResponse<TEntity, TError>> FindEntitiesAsync(string searchTerm = null, int pageNumber = 0, int pageSize = 10);
        Task<EntityResponse<TEntity, TError>> InsertEntityAsync(TEntity entity);
        Task<EntityResponse<TEntity, TError>> UpdateEntityAsync(TEntity entity);
        Task<ServiceResponse<TError>> DeleteEntityAsync(int entityId);
    }
}
