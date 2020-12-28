using System.Threading.Tasks;
using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Services.ServicesResponse;

namespace ALEmanMuseum.Services.RentItems
{
    public class RentItemService : IRentItemService
    {
        public Task<ServiceResponse<RentItemErrors>> DeleteEntityAsync(int entityId)
        {
            throw new System.NotImplementedException();
        }

        public Task<EntitiesResponse<RentItem, RentItemErrors>> FindEntitiesAsync(string searchTerm = null, int pageNumber = 0, int pageSize = 10)
        {
            throw new System.NotImplementedException();
        }

        public Task<EntitiesResponse<RentItem, RentItemErrors>> GetAllEntitiesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> GetEntitiesCountAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<EntityResponse<RentItem, RentItemErrors>> GetEntityByIdAsync(int entityId)
        {
            throw new System.NotImplementedException();
        }

        public Task<EntityResponse<RentItem, RentItemErrors>> InsertEntityAsync(RentItem entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<EntityResponse<RentItem, RentItemErrors>> UpdateEntityAsync(RentItem entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
