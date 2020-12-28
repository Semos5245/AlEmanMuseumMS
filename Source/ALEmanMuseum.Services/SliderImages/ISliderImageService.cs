using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Services.ServicesResponse;
using System.Threading.Tasks;

namespace ALEmanMuseum.Services.SliderImages
{
    public interface ISliderImageService : IService<SliderImage, SliderImageErrors>
    {
        Task<EntitiesResponse<SliderImage, SliderImageErrors>> GetSliderImagesBySliderIdAsync(int sliderId);
    }
}
