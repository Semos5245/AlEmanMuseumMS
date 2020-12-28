using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Services.ServicesResponse;
using System.Threading.Tasks;

namespace ALEmanMuseum.Services.Customers
{
    public interface ICustomerService
    {
        Task<EntitiesResponse<Customer, CustomerErrors>> GetAllCustomersAsync();
        Task<int> GetCustomersCountAsync();
        Task<EntityResponse<Customer, CustomerErrors>> GetCustomerByIdAsync(int customerId);
        Task<EntitiesResponse<Customer, CustomerErrors>> FindCustomersAsync(string searchTerm = null, int pageNumber = 0, int pageSize = 10);
        Task<EntityResponse<Customer, CustomerErrors>> InsertCustomerAsync(Customer customer);
        Task<EntityResponse<Customer, CustomerErrors>> UpdateCustomerAsync(Customer customer);
        Task<ServiceResponse<CustomerErrors>> DeleteCustomerAsync(int entityId);
        Task<ServiceResponse<CustomerErrors>> BlockCustomerAsync(int customerId);
    }
}
