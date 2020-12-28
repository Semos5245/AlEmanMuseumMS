using System;
using System.Linq;
using System.Threading.Tasks;
using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Core.ExensionMethods;
using ALEmanMuseum.Data;
using ALEmanMuseum.Services.ServicesResponse;
using Microsoft.EntityFrameworkCore;

namespace ALEmanMuseum.Services.SearchTerms
{
    public class SearchTermService : ISearchTermService
    {
        #region Private Members

        private readonly ApplicationDbContext _dbContext;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SearchTermService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public Methods

        public async Task<ServiceResponse<SearchTermErrors>> DeleteTermAsync(int entityId)
        {
            var term = await _dbContext.SearchTerms.FindAsync(entityId);

            if (term == null)
                return ResponseForError(SearchTermErrors.TermNotExist);

            try
            {
                _dbContext.SearchTerms.Remove(term);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: Log the e.Message error
                return ResponseForError(SearchTermErrors.DatabaseError);
            }

            return new ServiceResponse<SearchTermErrors>();
        }

        public async Task<EntitiesResponse<SearchTerm, SearchTermErrors>> FindTermsAsync(string searchTerm = null, int pageNumber = 0, int pageSize = 10)
        {
            var query = _dbContext.SearchTerms.AsNoTracking();

            if (!StringExtensions.IsNullOrEmptyOrWhiteSpace(searchTerm))
                query = query.Where(term => term.Term.Contains(searchTerm));

            query = query.Skip(pageSize * pageNumber).Take(pageSize);

            return new EntitiesResponse<SearchTerm, SearchTermErrors>
                (entities: await query.ToListAsync());
        }

        public async Task<EntitiesResponse<SearchTerm, SearchTermErrors>> GetAllTermsAsync() => 
            new EntitiesResponse<SearchTerm, SearchTermErrors>
            (entities: await _dbContext.SearchTerms.AsNoTracking().ToListAsync());

        public async Task<int> GetTermsCountAsync() => await _dbContext.SearchTerms.CountAsync();

        public async Task<EntityResponse<SearchTerm, SearchTermErrors>> GetTermByIdAsync(int entityId)
        {
            var searchTerm = await _dbContext.SearchTerms.FindAsync(entityId);

            return searchTerm switch
            {
                null => ResponseForError(SearchTermErrors.TermNotExist),
                _ => new EntityResponse<SearchTerm, SearchTermErrors>(entity: searchTerm)
            };
        }

        public async Task<EntityResponse<SearchTerm, SearchTermErrors>> InsertTermAsync(SearchTerm entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var term = await _dbContext.SearchTerms.FirstOrDefaultAsync(term => term.Term == entity.Term);

            try
            {
                if (term == null)
                {
                    await _dbContext.SearchTerms.AddAsync(entity);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    term.Count += 1;
                    await UpdateTermAsync(entity);
                }
            }
            catch (Exception)
            {
                // TODO: Log the e.Message error
                return ResponseForError(SearchTermErrors.DatabaseError);
            }

            return new EntityResponse<SearchTerm, SearchTermErrors>();
        }

        public async Task<EntityResponse<SearchTerm, SearchTermErrors>> UpdateTermAsync(SearchTerm entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                _dbContext.SearchTerms.Update(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: Log the e.Message error
                return ResponseForError(SearchTermErrors.DatabaseError);
            }

            return new EntityResponse<SearchTerm, SearchTermErrors>();
        }

        #endregion

        #region Helper Methods

        public EntityResponse<SearchTerm, SearchTermErrors> ResponseForError(SearchTermErrors searchTermError)
            => new EntityResponse<SearchTerm, SearchTermErrors>
            (error: new ServiceError<SearchTermErrors>
                (SearchTermErrorTemplatesCollection.GetTemplateForError(searchTermError), searchTermError));


        #endregion
    }
}
