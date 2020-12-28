using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Core.ExensionMethods;
using ALEmanMuseum.Core.Infrastructure;
using ALEmanMuseum.Data;
using ALEmanMuseum.Services.Common;
using ALEmanMuseum.Services.Dtos;
using ALEmanMuseum.Services.ItemImages;
using ALEmanMuseum.Services.ServicesResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ALEmanMuseum.Services.Items
{
    public class ItemService : IItemService
    {
        #region Private Members

        private readonly ApplicationDbContext _dbContext;
        private readonly IItemImageService _imageService;
        private readonly IWebHostHelper mWebHostHelper;

        #endregion

        #region Public Properties

        public IQueryable<Item> Table => _dbContext.Items;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ItemService(
            ApplicationDbContext dbContext,
            IItemImageService imageService,
            IWebHostHelper webHostHelper)
        {
            _dbContext = dbContext;
            _imageService = imageService;
            mWebHostHelper = webHostHelper;
        }

        #endregion

        #region Public Methods

        public async Task<ServiceResponse<ItemErrors>> DeleteItemAsync(int entityId)
        {
            var item = await _dbContext.Items.FindAsync(entityId);

            if (item == null)
                return ResponseForError(ItemErrors.ItemNotExist);
            
            try
            {
                _dbContext.Items.Remove(item);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: Log the e.Message error
                return ResponseForError(ItemErrors.DatabaseError);
            }

            return new ServiceResponse<ItemErrors>();
        }

        public async Task<EntitiesResponse<Item, ItemErrors>> FindItemsAsync(string searchTerm = null, int pageNumber = 0, int pageSize = 10)
        {
            var query = _dbContext.Items.AsNoTracking().Where(i => !i.Deleted);
            var hasNumbers = searchTerm.HasNumbers();

            if (!searchTerm.IsNullOrEmptyOrWhiteSpace())
                query = query.Where(i => i.ArabicName.Contains(searchTerm) || 
                                         i.EnglishName.Contains(searchTerm) ||
                                          (hasNumbers && i.UniqueNumber.ToString() == searchTerm));

            query = query.Skip(pageNumber * pageSize).Take(pageSize);

            return new EntitiesResponse<Item, ItemErrors>
                (entities: await query.ToListAsync());
        }

        public async Task<EntitiesResponse<Item, ItemErrors>> GetAllItemsAsync()
            => new EntitiesResponse<Item, ItemErrors>
            (entities: await _dbContext.Items.ToListAsync());

        public async Task<int> GetItemsCountAsync() => await _dbContext.Items.CountAsync();

        public async Task<EntityResponse<Item, ItemErrors>> GetItemByIdAsync(int entityId)
        {
            var item = await _dbContext.Items.FindAsync(entityId);

            return item switch
            {
                null => ResponseForError(ItemErrors.ItemNotExist),
                _ => new EntityResponse<Item, ItemErrors>(entity: item)
            };
        }

        public async Task<EntityResponse<Item, ItemErrors>> InsertItemAsync(CreateItemDto request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var itemWithSameInfo = await _dbContext.Items.AsNoTracking().FirstOrDefaultAsync
                (i => !i.Deleted && (i.ArabicName == request.ArabicName || i.EnglishName == request.EnglishName));

            if (itemWithSameInfo != null)
                return ResponseForError(ItemErrors.ItemAlreadyExist);

            var category = await _dbContext.Categories.FindAsync(request.CategoryId);

            if (category == null)
                return ResponseForError(ItemErrors.CategoryNotExist);

            var hasUploadedImage = request.ImageFile != null;
            var shouldAttachImage = request.ImageId.HasValue;
            ItemImage imageToAttach = null;

            if (hasUploadedImage)
            {
                var allowedExtensions = new string[] { ".jpeg", ".png", ".jpg", ".bmp" };
                var maxImageSize = 2 * 1000 * 1000; // ~ 2 MB

                var fileExtension = Path.GetExtension(request.ImageFile.FileName);

                if (!allowedExtensions.Contains(fileExtension))
                    return ResponseForError(ItemErrors.NotSupportedExtension);

                if (request.ImageFile.Length > maxImageSize)
                    return ResponseForError(ItemErrors.FileTooLarge);
            }
            else if (shouldAttachImage)
            {
                imageToAttach = await _dbContext.ItemImages.FindAsync(request.ImageId);

                if (imageToAttach == null)
                    return ResponseForError(ItemErrors.ImageNotExist);
            }

            var item = new Item
            {
                ArabicName = request.ArabicName,
                EnglishName = request.EnglishName,
                ArabicDescription = request.ArabicDescription,
                EnglishDescription = request.EnglishDescription,
                CreatorModifierId = request.UserId,
                Quantity = request.Quantity,
                OriginalPrice = request.OriginalPrice,
                SellingPrice = request.SellingPrice,
                Tags = request.Tags,
                Hidden = request.Hidden,
                CategoryId = request.CategoryId,
            };

            try
            {
                await _dbContext.Items.AddAsync(item);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: Log the e.Message error
                return ResponseForError(ItemErrors.DatabaseError);
            }

            if (hasUploadedImage)
                await _imageService.InsertImageAsync
                    (new AddItemImageDto(request.ImageFile, request.UserId, category.Id, item.Id));
            else if (shouldAttachImage)
                await _imageService.AttachImageAsync(new AttachImageDto(request.UserId, imageToAttach.Id, request.CategoryId, item.Id));

            //var itemImagesDirectory = Path.GetDirectoryName(entity.ItemMainImageName);
            //var barcodesDirectory = itemImagesDirectory.Substring(0, itemImagesDirectory.LastIndexOf('\\'));

            //await GenerateBarcodeForItemAsync(entity.Id, Path.Combine(mWebHostHelper.BarcodesImagesPath, entity.BarcodeImageName));

            return new EntityResponse<Item, ItemErrors>(entity: item);
        }

        public async Task<EntityResponse<Item, ItemErrors>> UpdateItemAsync(UpdateItemDto request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var item = await _dbContext.Items
                .Include(i => i.ItemImage)
                .SingleOrDefaultAsync(i => i.Id == request.ItemId);

            if (item == null)
                return ResponseForError(ItemErrors.ItemNotExist);

            var itemWithSameInfo = await _dbContext.Items.AsNoTracking().FirstOrDefaultAsync
                (i => i.Id != request.ItemId && (i.ArabicName == request.ArabicName || i.EnglishName == request.EnglishName));

            if (itemWithSameInfo != null)
                return ResponseForError(ItemErrors.ItemAlreadyExist);

            var category = await _dbContext.Categories.FindAsync(request.CategoryId);

            if (category == null)
                return ResponseForError(ItemErrors.CategoryNotExist);

            var hasUploadedImage = request.ImageFile != null;
            var alreadyAttachedToImage = item.ItemImage != null;

            if (hasUploadedImage)
            {
                var allowedExtensions = new string[] { ".jpeg", ".png", ".jpg", ".bmp" };
                var maxImageSize = 2 * 1000 * 1000; // 2 MB

                var fileExtension = Path.GetExtension(request.ImageFile.FileName);

                if (!allowedExtensions.Contains(fileExtension))
                    return ResponseForError(ItemErrors.NotSupportedExtension);

                if (request.ImageFile.Length > maxImageSize)
                    return ResponseForError(ItemErrors.FileTooLarge);
            }

            request = request.TrimObject();

            item.ArabicName = request.ArabicName;
            item.ArabicDescription = request.ArabicDescription;
            item.EnglishName = request.EnglishName;
            item.EnglishDescription = request.EnglishDescription;
            item.Hidden = request.Hidden;
            item.OriginalPrice = request.OriginalPrice;
            item.SellingPrice = request.SellingPrice;
            item.Tags = request.Tags;
            item.Quantity = request.Quantity;
            item.CategoryId = request.CategoryId;
            item.CreatorModifierId = request.UserId;

            try
            {
                _dbContext.Items.Update(item);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: Log the e.Message error
                return ResponseForError(ItemErrors.DatabaseError);
            }

            if (hasUploadedImage)
            {
                // Unlink the old attached image
                if (alreadyAttachedToImage)
                {
                    item.ItemImage.ItemId = null;
                    _dbContext.ItemImages.Update(item.ItemImage);
                    await _dbContext.SaveChangesAsync();
                }

                // Upload the new image and link it to the item
                await _imageService
                    .InsertImageAsync(new AddItemImageDto(request.ImageFile, request.UserId, item.CategoryId, item.Id));
            }
            else if (!hasUploadedImage && alreadyAttachedToImage)
            {
                // Update the category of the attached image
                item.ItemImage.CategoryId = item.CategoryId;
                _dbContext.ItemImages.Update(item.ItemImage);
                await _dbContext.SaveChangesAsync();
            }

            return new EntityResponse<Item, ItemErrors>(entity: item);
        }

        #endregion

        #region Private Helpers

        protected EntityResponse<Item, ItemErrors> ResponseForError(ItemErrors itemError)
            => new EntityResponse<Item, ItemErrors>
                (error: new ServiceError<ItemErrors>
                    (ItemErrorTemplatesCollection.GetTemplateForError(itemError), itemError));

        #endregion
    }
}
