using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Services.ServicesResponse;
using System.Threading.Tasks;

namespace ALEmanMuseum.Services.SearchTerms
{
    public interface ISearchTermService
    {
        Task<EntitiesResponse<SearchTerm, SearchTermErrors>> GetAllTermsAsync();
        Task<int> GetTermsCountAsync();
        Task<EntityResponse<SearchTerm, SearchTermErrors>> GetTermByIdAsync(int entityId);
        Task<EntitiesResponse<SearchTerm, SearchTermErrors>> FindTermsAsync(string searchTerm = null, int pageNumber = 0, int pageSize = 10);
        Task<EntityResponse<SearchTerm, SearchTermErrors>> InsertTermAsync(SearchTerm entity);
        Task<EntityResponse<SearchTerm, SearchTermErrors>> UpdateTermAsync(SearchTerm entity);
        Task<ServiceResponse<SearchTermErrors>> DeleteTermAsync(int entityId);
    }
}
