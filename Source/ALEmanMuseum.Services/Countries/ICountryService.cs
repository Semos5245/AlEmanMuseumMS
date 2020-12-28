using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Services.ServicesResponse;
using System.Threading.Tasks;

namespace ALEmanMuseum.Services.Countries
{
    public interface ICountryService
    {
        Task<EntitiesResponse<Country, CountryErrors>> GetAllCountriesAsync();
        Task<int> GetCountriesCountAsync();
        Task<EntityResponse<Country, CountryErrors>> GetCountryByIdAsync(int countryId);
        Task<EntitiesResponse<Country, CountryErrors>> FindCountriesAsync(string searchTerm = null, int pageNumber = 0, int pageSize = 10);
        Task<EntityResponse<Country, CountryErrors>> InsertCountryAsync(Country entity);
        Task<EntityResponse<Country, CountryErrors>> UpdateCountryAsync(Country entity);
        Task<ServiceResponse<CountryErrors>> DeleteCountryAsync(int countryId);
    }
}
