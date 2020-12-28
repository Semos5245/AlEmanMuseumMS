using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Data;
using ALEmanMuseum.Services.ServicesResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ALEmanMuseum.Services.Addresses
{
    /// <summary>
    /// Represents an address service
    /// </summary>
    public class AddressService : IAddressService
    {
        #region Private Members

        private readonly ApplicationDbContext _dbContext;

        #endregion

        #region Constructor

        public AddressService(ApplicationDbContext dbContxt)
        {
            _dbContext = dbContxt;
        }

        #endregion

        #region Public Methods

        public async Task<EntitiesResponse<Address, AddressErrors>> FindAddressAsync(string searchTerm = null, int pageNumber = 0, int pageSize = 10)
        {
            var query = _dbContext.Addresses.AsNoTracking();

            if (!string.IsNullOrEmpty(searchTerm))
                query = query.Where(a =>
                                !a.Deleted &&
                                (a.Area.Contains(searchTerm) || a.BuildingName.Contains(searchTerm) ||
                                 a.Street.Contains(searchTerm) || a.Floor.Contains(searchTerm) ||
                                 a.Customer.Name.Contains(searchTerm)));

            query = query.Skip(pageNumber * pageSize).Take(pageSize);

            return new EntitiesResponse<Address, AddressErrors>(
                entities: await query.ToListAsync());
        }

        public async Task<int> GetAddressesCountAsync()
        {
            return await _dbContext.Addresses.CountAsync();
        }

        public async Task<EntityResponse<Address, AddressErrors>> GetAddressByIdAsync(int entityId)
        {
            var address = await _dbContext.Addresses.FindAsync(entityId);

            return address == null ?
                ResponseForError(AddressErrors.AddressNotExist) :
                new EntityResponse<Address, AddressErrors>(entity: address);
        }

        public async Task<EntityResponse<Address, AddressErrors>> InsertAddressAsync(Address entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var entityWithSameInfo = await _dbContext.Addresses.AsNoTracking()
                    .FirstOrDefaultAsync(a =>
                    !a.Deleted && a.BuildingName == entity.BuildingName &&
                     a.Floor == entity.Floor && a.Street == entity.Street &&
                     a.Area == entity.Area);

            if (entityWithSameInfo != null)
                return ResponseForError(AddressErrors.AddressAlreadyExist);

            try
            {
                await _dbContext.Addresses.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: Log the e.Message error
                return ResponseForError(AddressErrors.DatabaseError);
            }

            return new EntityResponse<Address, AddressErrors>
                (entity: entity);
        }

        public async Task<EntityResponse<Address, AddressErrors>> UpdateAddressAsync(Address entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                _dbContext.Addresses.Update(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: Log the e.Message error
                return ResponseForError(AddressErrors.DatabaseError);
            }
            return new EntityResponse<Address, AddressErrors>(entity: entity);
        }

        public async Task<ServiceResponse<AddressErrors>> DeleteAddressAsync(int entityId)
        {
            var address = await _dbContext.Addresses.FindAsync(entityId);

            if (address == null)
                return ResponseForError(AddressErrors.AddressNotExist);

            try
            {
                _dbContext.Addresses.Remove(address);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: Log the e.Message error
                return ResponseForError(AddressErrors.DatabaseError);
            }

            return new ServiceResponse<AddressErrors>();
        }

        #endregion

        #region Helper Methods

        protected EntityResponse<Address, AddressErrors> ResponseForError(AddressErrors addressError)
        {
            return new EntityResponse<Address, AddressErrors>(
                error: new ServiceError<AddressErrors>
                       (AddressErrorTemplatesCollection.GetTemplateForError(addressError), addressError));
        }

        #endregion
    }
}