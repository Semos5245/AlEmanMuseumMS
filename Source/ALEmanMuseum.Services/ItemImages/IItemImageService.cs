using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Services.Dtos;
using ALEmanMuseum.Services.ServicesResponse;
using System.Threading.Tasks;

namespace ALEmanMuseum.Services.ItemImages
{
    public interface IItemImageService
    {
        Task<EntitiesResponse<ItemImage, ItemImageErrors>> GetImagesAsync(int? categoryId = null, bool onlyUnattachedImages = true, int pageNumber = 0, int pageSize = 10);
        Task<EntityResponse<ItemImage, ItemImageErrors>> GetImageByIdAsync(int imageId);
        Task<EntityResponse<ItemImage, ItemImageErrors>> InsertImageAsync(AddItemImageDto request);
        Task<EntityResponse<ItemImage, ItemImageErrors>> AttachImageAsync(AttachImageDto request);
        Task<ServiceResponse<ItemImageErrors>> DeleteImageAsync(int imageId);
    }
}
