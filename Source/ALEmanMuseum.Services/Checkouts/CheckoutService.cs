using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Core.Enums;
using ALEmanMuseum.Core.ExensionMethods;
using ALEmanMuseum.Data;
using ALEmanMuseum.Services.Dtos;
using ALEmanMuseum.Services.ServicesResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALEmanMuseum.Services.Checkouts
{
    public class CheckoutService : ICheckoutService
    {
        #region Protected Members

        protected readonly ApplicationDbContext _dbContext;

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="dbContext">Context to use for db access</param>
        public CheckoutService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public Methods

        public async Task<ServiceResponse<CheckoutErrors>> DeleteCheckoutAsync(int checkoutId, bool reAddContent = true)
        {
            var checkout = await _dbContext.Checkouts
                .Include(c => c.CheckoutItems)
                .SingleOrDefaultAsync(c => c.Id == checkoutId);

            if (checkout is null)
                return ResponseForError(CheckoutErrors.CheckoutNotExist);

            foreach (var checkoutItem in checkout.CheckoutItems)
            {
                if (reAddContent)
                {
                    var item = await _dbContext.Items.FindAsync(checkoutItem.ItemId);
                    item.Quantity += checkoutItem.Quantity;
                    _dbContext.Items.Update(item);
                }

                _dbContext.CheckoutItems.Remove(checkoutItem);
            }

            _dbContext.Checkouts.Remove(checkout);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                // TODO: Log the e.Message error
                return ResponseForError(CheckoutErrors.DatabaseError);
            }

            return new ServiceResponse<CheckoutErrors>();
        }

        public Task<EntitiesResponse<Checkout, CheckoutErrors>> GetAllCheckoutsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EntityResponse<Checkout, CheckoutErrors>> GetCheckoutByIdAsync(int checkoutId)
        {
            throw new NotImplementedException();
        }

        public async Task<EntitiesResponse<Checkout, CheckoutErrors>> GetCheckoutsBetweenDates(DateTime? fromDate, DateTime? toDate)
        {
            fromDate ??= new DateTime();
            toDate ??= DateTime.Now;

            var checkouts = await _dbContext.Checkouts
                .Where(c => c.CreatedDate >= fromDate && c.CreatedDate <= toDate)
                .ToListAsync();

            return new EntitiesResponse<Checkout, CheckoutErrors>(entities: checkouts);
        }

        public Task<int> GetCheckoutsCountAsync()
        {
            return _dbContext.Checkouts.CountAsync();
        }

        public async Task<int> GetNextCheckoutNumber()
        {
            using var command = _dbContext.Database.GetDbConnection().CreateCommand();

            command.CommandText = "SELECT IDENT_CURRENT('dbo.Checkouts') + " +
                "IDENT_INCR('dbo.Checkouts');";
            await _dbContext.Database.OpenConnectionAsync();
            var result = Convert.ToInt32(command.ExecuteScalar());
            await _dbContext.Database.OpenConnectionAsync();

            return result;
        }

        public async Task<ServiceResponse<CheckoutErrors>> InsertCheckoutAsync(CreateCheckoutDto request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            if (request.CheckoutItems == null || !request.CheckoutItems.Any())
            {
                return ResponseForError(CheckoutErrors.EmptyCheckout);
            }

            var newCheckout = await _dbContext.Checkouts.AddAsync(new Checkout
            {
                CustomerName = request.CustomerName,
                CustomerPhone = request.CustomerPhone,
                CheckoutStatusId = (int)CheckoutStatus.Confirmed
            });

            foreach (var checkoutItem in request.CheckoutItems)
            {
                var item = _dbContext.Items.Find(checkoutItem.ItemId);
                if (item == null)
                    return ResponseForError(CheckoutErrors.ItemNotExist);

                if (checkoutItem.Quantity > item.Quantity)
                    return ResponseForError(CheckoutErrors.NotEnoughQuantity,
                        new KeyValuePair<string, object>("ItemName", $"{item.ArabicName} - {item.EnglishName}"));
                if (checkoutItem.Price < 0)
                    return ResponseForError(CheckoutErrors.PriceError,
                        new KeyValuePair<string, object>("ItemName", $"{item.ArabicName} - {item.EnglishName}"));

                newCheckout.Entity.CheckoutItems.Add(new CheckoutItem
                {
                    Quantity = checkoutItem.Quantity,
                    Price = checkoutItem.Price,
                    ItemId = item.Id
                });

                item.Quantity -= checkoutItem.Quantity;

                _dbContext.Update(item);
            }

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                // TODO: Log the ex.Message error
                return ResponseForError(CheckoutErrors.DatabaseError);
            }

            return new ServiceResponse<CheckoutErrors>();
        }

        public Task<EntityResponse<Checkout, CheckoutErrors>> UpdateCheckoutAsync(Checkout checkout)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Helpers

        protected EntityResponse<Checkout, CheckoutErrors> ResponseForError(CheckoutErrors itemError, params KeyValuePair<string, object>[] additionalInfo)
            => new EntityResponse<Checkout, CheckoutErrors>
                (error: new ServiceError<CheckoutErrors>
                    (CheckoutErrorTemplatesCollection.GetTemplateForError(itemError), itemError,
                        new Dictionary<string, object>(additionalInfo)));

        protected EntityResponse<Checkout, CheckoutErrors> ResponseForError(CheckoutErrors itemError)
            => new EntityResponse<Checkout, CheckoutErrors>
                (error: new ServiceError<CheckoutErrors>
                    (CheckoutErrorTemplatesCollection.GetTemplateForError(itemError), itemError));

        #endregion
    }
}
