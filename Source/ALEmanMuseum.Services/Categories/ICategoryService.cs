using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Services.ServicesResponse;
using System.Linq;
using System.Threading.Tasks;

namespace ALEmanMuseum.Services.Categories
{
    public interface ICategoryService
    {
        IQueryable<Category> Table { get; }
        Task<EntitiesResponse<Category, CategoryErrors>> GetAllCategoriesAsync();
        Task<int> GetCategoriesCountAsync();
        Task<EntityResponse<Category, CategoryErrors>> GetCategoryByIdAsync(int entityId);
        Task<EntitiesResponse<Category, CategoryErrors>> FindCategoriesAsync(string searchTerm = null, int pageNumber = 0, int pageSize = 10);
        Task<EntityResponse<Category, CategoryErrors>> InsertCategoryAsync(Category entity);
        Task<EntityResponse<Category, CategoryErrors>> UpdateCategoryAsync(Category entity);
        Task<ServiceResponse<CategoryErrors>> DeleteCategoryAsync(int entityId);
    }
}
