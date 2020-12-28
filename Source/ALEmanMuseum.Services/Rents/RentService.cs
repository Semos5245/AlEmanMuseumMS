using System.Threading.Tasks;
using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Services.ServicesResponse;

namespace ALEmanMuseum.Services.Rents
{
    public class RentService : IRentService
    {
        public Task<ServiceResponse<RentErrors>> DeleteEntityAsync(int entityId)
        {
            throw new System.NotImplementedException();
        }

        public Task<EntitiesResponse<Rent, RentErrors>> FindEntitiesAsync(string searchTerm = null, int pageNumber = 0, int pageSize = 10)
        {
            throw new System.NotImplementedException();
        }

        public Task<EntitiesResponse<Rent, RentErrors>> GetAllEntitiesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> GetEntitiesCountAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<EntityResponse<Rent, RentErrors>> GetEntityByIdAsync(int entityId)
        {
            throw new System.NotImplementedException();
        }

        public Task<EntityResponse<Rent, RentErrors>> InsertEntityAsync(Rent entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<EntityResponse<Rent, RentErrors>> UpdateEntityAsync(Rent entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
