using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Data;
using ALEmanMuseum.Services.ServicesResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ALEmanMuseum.Services.Countries
{
    /// <summary>
    /// Represents a service for the <see cref="Country"/> model
    /// </summary>
    public class CountryService : ICountryService
    {
        #region Private Members

        private readonly ApplicationDbContext _dbContext;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CountryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public Methods

        public async Task<EntitiesResponse<Country, CountryErrors>> GetAllCountriesAsync()
            => new EntitiesResponse<Country, CountryErrors>(entities: await _dbContext.Countries.AsNoTracking().ToListAsync());
        
        public async Task<int> GetCountriesCountAsync() => await _dbContext.Countries.AsNoTracking().CountAsync();

        public async Task<EntitiesResponse<Country, CountryErrors>> FindCountriesAsync(string searchTerm = null, int pageStart = 0, int pageSize = 10)
        {
            var query = _dbContext.Countries.AsNoTracking();

            // If there is something to search for
            if (!string.IsNullOrEmpty(searchTerm))
                query = query.Where(c => 
                        c.Name.Contains(searchTerm));

            query = query.Skip(pageStart * pageSize).Take(pageSize);

            return new EntitiesResponse<Country, CountryErrors>(entities: await query.ToListAsync());
        }

        public async Task<EntityResponse<Country, CountryErrors>> GetCountryByIdAsync(int countryId)
        {
            var country = await _dbContext.Countries.FindAsync(countryId);

            return country == null ?
                ResponseForError(CountryErrors.CountryNotExist) :
                new EntityResponse<Country, CountryErrors>(entity: country);
        }

        public async Task<ServiceResponse<CountryErrors>> DeleteCountryAsync(int entityId)
        {
            var country = await _dbContext.Countries.FindAsync(entityId);

            if (country == null)
                return ResponseForError(CountryErrors.CountryNotExist);
            try
            {
                _dbContext.Countries.Remove(country);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: Log the e.Message error
                return ResponseForError(CountryErrors.DatabaseError); 
            }

            return new ServiceResponse<CountryErrors>();
        }

        public async Task<EntityResponse<Country, CountryErrors>> InsertCountryAsync(Country country)
        {
            if (country == null)
                throw new ArgumentNullException(nameof(country));

            var countryWithSameName = _dbContext.Countries.AsNoTracking()
                .FirstOrDefault(c => c.Name == country.Name);

            if (countryWithSameName != null)
                return ResponseForError(CountryErrors.CountryAlreadyExist);

            try
            {
                await _dbContext.Countries.AddAsync(country);
                await _dbContext.SaveChangesAsync();
            } catch (Exception) 
            {
                // TODO: Log the e.Message error
                return ResponseForError(CountryErrors.DatabaseError); 
            }

            return new EntityResponse<Country, CountryErrors>(entity: country);
        }

        public async Task<EntityResponse<Country, CountryErrors>> UpdateCountryAsync(Country entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var countryWithSameName = await _dbContext.Countries.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Name == entity.Name && c.Id != entity.Id);

            if (countryWithSameName != null)
                return ResponseForError(CountryErrors.CountryAlreadyExist);

            try
            {
                _dbContext.Countries.Update(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception) 
            {
                // TODO: Log the e.Message error
                return ResponseForError(CountryErrors.DatabaseError);
            }

            return new EntityResponse<Country, CountryErrors>(entity: entity);
        }

        #endregion

        #region Private Methods

        protected EntityResponse<Country, CountryErrors> ResponseForError(CountryErrors countryError)
        {
            return new EntityResponse<Country, CountryErrors>
                (error: new ServiceError<CountryErrors>
                        (CountryErrorTemplatesCollection.GetTemplateForError(countryError), countryError));
        }

        #endregion
    }
}
