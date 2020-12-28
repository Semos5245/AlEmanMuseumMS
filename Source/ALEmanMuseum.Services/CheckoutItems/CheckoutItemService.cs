using System.Threading.Tasks;
using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Services.ServicesResponse;

namespace ALEmanMuseum.Services.CheckoutItems
{
    public class CheckoutItemService : ICheckoutItemService
    {
        public Task<ServiceResponse<CheckoutItemErrors>> DeleteEntityAsync(int entityId)
        {
            throw new System.NotImplementedException();
        }

        public Task<EntitiesResponse<CheckoutItem, CheckoutItemErrors>> FindEntitiesAsync(string searchTerm = null, int pageNumber = 0, int pageSize = 10)
        {
            throw new System.NotImplementedException();
        }

        public Task<EntitiesResponse<CheckoutItem, CheckoutItemErrors>> GetAllEntitiesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> GetEntitiesCountAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<EntityResponse<CheckoutItem, CheckoutItemErrors>> GetEntityByIdAsync(int entityId)
        {
            throw new System.NotImplementedException();
        }

        public Task<EntityResponse<CheckoutItem, CheckoutItemErrors>> InsertEntityAsync(CheckoutItem entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<EntityResponse<CheckoutItem, CheckoutItemErrors>> UpdateEntityAsync(CheckoutItem entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
