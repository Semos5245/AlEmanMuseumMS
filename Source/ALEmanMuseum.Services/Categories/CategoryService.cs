using System;
using System.Linq;
using System.Threading.Tasks;
using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Core.ExensionMethods;
using ALEmanMuseum.Data;
using ALEmanMuseum.Services.ServicesResponse;
using Microsoft.EntityFrameworkCore;

namespace ALEmanMuseum.Services.Categories
{
    /// <summary>
    /// Represents a service for the <see cref="Category"/> Model
    /// </summary>
    public class CategoryService : ICategoryService
    {
        #region Private Members

        private readonly ApplicationDbContext _dbContext;

        #endregion

        #region Public Properties

        public IQueryable<Category> Table => _dbContext.Categories;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public CategoryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public Methods

        public async Task<ServiceResponse<CategoryErrors>> DeleteCategoryAsync(int entityId)
        {
            var category = await _dbContext.Categories.FindAsync(entityId);

            if (category == null)
                return ResponseForError(CategoryErrors.CategoryNotExist);

            try
            {
                _dbContext.Categories.Remove(category);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: Log the e.Message error
                return ResponseForError(CategoryErrors.DatabaseError);
            }

            return new ServiceResponse<CategoryErrors>();
        }

        public async Task<EntitiesResponse<Category, CategoryErrors>> FindCategoriesAsync(string searchTerm = null, int pageNumber = 0, int pageSize = 10)
        {
            var query = _dbContext.Categories.AsNoTracking();
            var hasNumbers = searchTerm.HasNumbers();

            if (!string.IsNullOrEmpty(searchTerm))
                query = query
                    .Where(c => c.ArabicName.Contains(searchTerm) || c.EnglishName.Contains(searchTerm) ||
                                (hasNumbers && (c.CreatedDate.ToString().Contains(searchTerm) ||
                                                (c.LastModifiedDate != null && c.LastModifiedDate.ToString().Contains(searchTerm)))));

            query = query.Skip(pageSize * pageNumber).Take(pageSize);

            return new EntitiesResponse<Category, CategoryErrors>
                (entities: await query.ToListAsync());
         }

        public async Task<EntitiesResponse<Category, CategoryErrors>> GetAllCategoriesAsync()
            => new EntitiesResponse<Category, CategoryErrors>
             (entities: await _dbContext.Categories.ToListAsync());

        public async Task<int> GetCategoriesCountAsync() => await _dbContext.Categories.CountAsync();

        public async Task<EntityResponse<Category, CategoryErrors>> GetCategoryByIdAsync(int entityId)
        {
            var category = await _dbContext.Categories.FindAsync(entityId);

            return category == null ?
                ResponseForError(CategoryErrors.CategoryNotExist) :
                new EntityResponse<Category, CategoryErrors>(entity: category);
        }

        public async Task<EntityResponse<Category, CategoryErrors>> InsertCategoryAsync(Category entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var categoryWithSameInfo = await _dbContext.Categories.AsNoTracking()
                .FirstOrDefaultAsync(c => c.ArabicName == entity.ArabicName || c.EnglishName == entity.EnglishName);

            if (categoryWithSameInfo != null)
                return ResponseForError(CategoryErrors.CategoryAlreadExist);

            try
            {
                await _dbContext.Categories.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: Log the e.Message error
                return ResponseForError(CategoryErrors.DatabaseError);
            }

            return new EntityResponse<Category, CategoryErrors>
                (entity: entity);
        }

        public async Task<EntityResponse<Category, CategoryErrors>> UpdateCategoryAsync(Category entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var categoryWithSameInfo = await _dbContext.Categories.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id != entity.Id && (c.ArabicName == entity.ArabicName || c.EnglishName == entity.EnglishName));

            if (categoryWithSameInfo != null)
                return ResponseForError(CategoryErrors.CategoryAlreadExist);

            try
            {
                _dbContext.Categories.Update(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: Log the e.Message error
                return ResponseForError(CategoryErrors.DatabaseError);
            }

            return new EntityResponse<Category, CategoryErrors>
                (entity: entity);
        }

        #endregion

        #region Helper Methods

        public EntityResponse<Category, CategoryErrors> ResponseForError(CategoryErrors categoryError)
            => new EntityResponse<Category, CategoryErrors>
            (error: new ServiceError<CategoryErrors>
                (CategoryErrorTemplatesCollection.GetTemplateForError(categoryError), categoryError));

        #endregion
    }
}
