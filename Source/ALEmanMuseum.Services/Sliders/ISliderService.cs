using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Services.ServicesResponse;
using System.Threading.Tasks;

namespace ALEmanMuseum.Services.Sliders
{
    public interface ISliderService : IService<Slider, SliderErrors>
    {
        Task<EntityResponse<Slider, SliderErrors>> GetActiveSliderAsync();
        Task<ServiceResponse<SliderErrors>> MakeSliderActiveAsync(int sliderId);
    }
}
