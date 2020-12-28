using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Services.Dtos;
using ALEmanMuseum.Services.ServicesResponse;
using System.Linq;
using System.Threading.Tasks;

namespace ALEmanMuseum.Services.Items
{
    public interface IItemService
    {
        IQueryable<Item> Table { get; }
        Task<EntitiesResponse<Item, ItemErrors>> GetAllItemsAsync();
        Task<int> GetItemsCountAsync();
        Task<EntityResponse<Item, ItemErrors>> GetItemByIdAsync(int entityId);
        Task<EntitiesResponse<Item, ItemErrors>> FindItemsAsync(string searchTerm = null, int pageNumber = 0, int pageSize = 10);
        Task<EntityResponse<Item, ItemErrors>> InsertItemAsync(CreateItemDto request);
        Task<EntityResponse<Item, ItemErrors>> UpdateItemAsync(UpdateItemDto request);
        Task<ServiceResponse<ItemErrors>> DeleteItemAsync(int entityId);
    }
}
