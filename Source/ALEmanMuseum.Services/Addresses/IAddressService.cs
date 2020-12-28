using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Services.ServicesResponse;
using System.Threading.Tasks;

namespace ALEmanMuseum.Services.Addresses
{
    public interface IAddressService
    {
        Task<int> GetAddressesCountAsync();
        Task<EntityResponse<Address, AddressErrors>> GetAddressByIdAsync(int addressId);
        Task<EntitiesResponse<Address, AddressErrors>> FindAddressAsync(string searchTerm = null, int pageNumber = 0, int pageSize = 10);
        Task<EntityResponse<Address, AddressErrors>> InsertAddressAsync(Address entity);
        Task<EntityResponse<Address, AddressErrors>> UpdateAddressAsync(Address entity);
        Task<ServiceResponse<AddressErrors>> DeleteAddressAsync(int addressId);
    } 
}
