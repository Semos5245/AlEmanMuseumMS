using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Core.ExensionMethods;
using ALEmanMuseum.Data;
using ALEmanMuseum.Services.ServicesResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ALEmanMuseum.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        #region Private Members

        private readonly ApplicationDbContext _dbContext;

        #endregion

        #region Constructor

        public CustomerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public Methods

        public async Task<EntitiesResponse<Customer, CustomerErrors>> GetAllCustomersAsync()
        {
            return new EntitiesResponse<Customer, CustomerErrors>
                (entities: await _dbContext.Customers.AsNoTracking().ToListAsync());
        }

        public async Task<EntitiesResponse<Customer, CustomerErrors>> FindCustomersAsync(string searchTerm = null, int pageNumber = 0, int pageSize = 10)
        {
            var query = _dbContext.Customers.AsNoTracking();
            var hasNumbers = searchTerm.HasNumbers();

            if (!string.IsNullOrEmpty(searchTerm))
                query = query.Where(c =>
                    c.Name.Contains(searchTerm) || (hasNumbers && c.Phone.Contains(searchTerm)));

            query = query.Skip(pageNumber * pageSize).Take(pageSize);

            return new EntitiesResponse<Customer, CustomerErrors>
                (entities: await query.ToListAsync());
        }

        public async Task<int> GetCustomersCountAsync() => await _dbContext.Customers.CountAsync();

        public async Task<EntityResponse<Customer, CustomerErrors>> GetCustomerByIdAsync(int customerId)
        {
            var customer = await _dbContext.Customers.FindAsync(customerId);

            return customer == null ?
                ResponseForError(CustomerErrors.CustomerNotExist) :
                new EntityResponse<Customer, CustomerErrors>
                (entity: customer);
        }

        public async Task<EntityResponse<Customer, CustomerErrors>> InsertCustomerAsync(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            var customerWithSameInfo = await _dbContext.Customers.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Name == customer.Name && c.Phone == customer.Phone && c.Email == customer.Email);
            if (customerWithSameInfo != null)
                return ResponseForError(CustomerErrors.CustomerAlreadyExist);

            try
            {
                await _dbContext.Customers.AddAsync(customer);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: log the e.Message error
                return ResponseForError(CustomerErrors.DatabaseError);
            }

            return new EntityResponse<Customer, CustomerErrors>(entity: customer);
        }

        public async Task<ServiceResponse<CustomerErrors>> BlockCustomerAsync(int customerId)
        {
            var customer = await _dbContext.Customers.FindAsync(customerId);

            if (customer == null)
                return ResponseForError(CustomerErrors.CustomerNotExist);

            customer.Blocked = true;

            try
            {
                _dbContext.Customers.Update(customer);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: Log the e.Message error
                return ResponseForError(CustomerErrors.DatabaseError);
            }

            return new ServiceResponse<CustomerErrors>();
        }

        public async Task<EntityResponse<Customer, CustomerErrors>> UpdateCustomerAsync(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            var customerWithSameInfo = await _dbContext.Customers.AsNoTracking().FirstOrDefaultAsync(c =>
                    c.Id != customer.Id && c.Name == customer.Name && c.Phone == customer.Phone && c.Email == customer.Email);

            if (customerWithSameInfo != null)
                return ResponseForError(CustomerErrors.CustomerAlreadyExist);

            try
            {
                _dbContext.Customers.Update(customer);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: Log the e.Message error
                return ResponseForError(CustomerErrors.DatabaseError);
            }

            return new EntityResponse<Customer, CustomerErrors>(entity: customer);
        }

        public async Task<ServiceResponse<CustomerErrors>> DeleteCustomerAsync(int customerId)
        {
            var customer = await _dbContext.Customers.FindAsync(customerId);

            if (customer == null)
                return ResponseForError(CustomerErrors.CustomerNotExist);

            try
            {
                _dbContext.Customers.Remove(customer);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: Log the e.Message
                return ResponseForError(CustomerErrors.DatabaseError);
            }

            return new ServiceResponse<CustomerErrors>();
        }

        #endregion

        #region Helper Methods

        protected EntityResponse<Customer, CustomerErrors> ResponseForError(CustomerErrors customerError)
        {
            return new EntityResponse<Customer, CustomerErrors>
                (error: new ServiceError<CustomerErrors>
                    (CustomerErrorTemplatesCollection.GetTemplateForError(customerError), customerError));
        }

        #endregion
    }
}
