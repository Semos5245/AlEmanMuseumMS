using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Services.Dtos;
using ALEmanMuseum.Services.ServicesResponse;
using System;
using System.Threading.Tasks;

namespace ALEmanMuseum.Services.Checkouts
{
    public interface ICheckoutService
    {
        Task<EntitiesResponse<Checkout, CheckoutErrors>> GetAllCheckoutsAsync();
        Task<int> GetCheckoutsCountAsync();
        Task<EntityResponse<Checkout, CheckoutErrors>> GetCheckoutByIdAsync(int checkoutId);
        Task<ServiceResponse<CheckoutErrors>> InsertCheckoutAsync(CreateCheckoutDto request);
        Task<ServiceResponse<CheckoutErrors>> DeleteCheckoutAsync(int checkoutId, bool reAddContent = true);
        Task<EntitiesResponse<Checkout, CheckoutErrors>> GetCheckoutsBetweenDates(DateTime? fromDate, DateTime? toDate);
        Task<int> GetNextCheckoutNumber();
    }
}
