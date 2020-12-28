using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Core.Infrastructure;
using ALEmanMuseum.Data;
using ALEmanMuseum.Services.Dtos;
using ALEmanMuseum.Services.ServicesResponse;
using Microsoft.EntityFrameworkCore;

namespace ALEmanMuseum.Services.ItemImages
{
    public class ItemImageService : IItemImageService
    {
        #region Private Members

        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostHelper _webHostHelper;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ItemImageService(
            ApplicationDbContext dbContext,
            IWebHostHelper webHostHelper)
        {
            _dbContext = dbContext;
            _webHostHelper = webHostHelper;
        }

        #endregion

        #region Public Methods

        public async Task<ServiceResponse<ItemImageErrors>> DeleteImageAsync(int imageId)
        {
            var image = await _dbContext.ItemImages.FindAsync(imageId);

            if (image == null)
                return EntityResponseForError(ItemImageErrors.ImageNotFound);

            try
            {
                File.Delete(Path.Combine(_webHostHelper.ItemsImagesPath, image.ImageUrl));
                File.Delete(Path.Combine(_webHostHelper.ItemsThumbnailImagesPath, image.ThumbNailUrl));
                _dbContext.ItemImages.Remove(image);
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                // Log the e.Messsage error
                return EntityResponseForError(ItemImageErrors.DatabaseError);
            }

            return new ServiceResponse<ItemImageErrors>();
        }

        public async Task<EntityResponse<ItemImage, ItemImageErrors>> GetImageByIdAsync(int imageId)
        {
            var image = await _dbContext.ItemImages.FindAsync(imageId);

            if (image == null)
                return EntityResponseForError(ItemImageErrors.ImageNotFound);

            return new EntityResponse<ItemImage, ItemImageErrors>(entity: image);

        }

        public async Task<EntityResponse<ItemImage, ItemImageErrors>> InsertImageAsync(AddItemImageDto request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.ImageFile == null)
                return EntityResponseForError(ItemImageErrors.NoFileUploaded);

            Category category = null;
            if (request.CategoryId.HasValue)
            {
                category = await _dbContext.Categories.FindAsync(request.CategoryId);
                if (category == null && request.CategoryId.HasValue)
                    return EntityResponseForError(ItemImageErrors.CategoryNotFound);

            }

            Item item = null;
            if (request.ItemId.HasValue)
            {
                item = await _dbContext.Items.FindAsync(request.ItemId);
                if (item == null && request.ItemId.HasValue)
                    return EntityResponseForError(ItemImageErrors.ItemNotFound);

            }

            var allowedExtensions = new string[] { ".jpeg", ".png", ".jpg", ".bmp" };
            var maxImageSize = 2 * 1000 * 1000; // 2 MB

            var fileExtension = Path.GetExtension(request.ImageFile.FileName);

            if (!allowedExtensions.Contains(fileExtension))
                return EntityResponseForError(ItemImageErrors.NotSupportedExtension);

            if (request.ImageFile.Length > maxImageSize)
                return EntityResponseForError(ItemImageErrors.FileTooLarge);

            var guid = Guid.NewGuid().ToString();
            var imageName = "item-image_" + guid + "_" + fileExtension;
            var thumbName = "item-image_thumb" + guid + "_" + fileExtension;
            var imageFullPath = Path.Combine(_webHostHelper.ItemsImagesPath, imageName);
            var thumbFullPath = Path.Combine(_webHostHelper.ItemsThumbnailImagesPath, thumbName);

            var itemImage = new ItemImage
            {
                ImageUrl = imageName,
                ThumbNailUrl = thumbName,
                CategoryId = request.CategoryId,
                ItemId = request.ItemId
            };

            await _dbContext.ItemImages.AddAsync(itemImage);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                // TODO: Log the e.Message error
                return EntityResponseForError(ItemImageErrors.DatabaseError);
            }

            // add the image and the thumb if everything is good so far
            using (var stream = new FileStream(imageFullPath, FileMode.Create))
            {
                await request.ImageFile.CopyToAsync(stream);

                using (var memoryStream = new MemoryStream())
                {
                    await request.ImageFile.CopyToAsync(memoryStream);
                    // Generate the thumbnail image and save it
                    var image = new Bitmap(memoryStream);
                    var thumbImage = image.GetThumbnailImage(150, 150, () => false, IntPtr.Zero);
                    thumbImage.Save(thumbFullPath);
                }
            }

            return new EntityResponse<ItemImage, ItemImageErrors>(entity: itemImage);
        }

        public async Task<EntityResponse<ItemImage, ItemImageErrors>> AttachImageAsync(AttachImageDto request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var image = await _dbContext.ItemImages
                .Include(i => i.Item)
                .Include(i => i.Category)
                .SingleOrDefaultAsync(i => i.Id == request.ImageId);

            if (image == null)
                return EntityResponseForError(ItemImageErrors.ImageNotFound);

            Category category = null;
            if (request.CategoryId.HasValue)
            {
                category = await _dbContext.Categories.FindAsync(request.CategoryId);
                if (category == null)
                    return EntityResponseForError(ItemImageErrors.CategoryNotFound);
            }

            Item item = null;
            if (request.ItemId.HasValue)
            {
                item = await _dbContext.Items.FindAsync(request.ItemId);
                if (item == null)
                    return EntityResponseForError(ItemImageErrors.ItemNotFound);
            }

            if (item?.ItemImage != null)
            {
                item.ItemImage.ItemId = null;
                _dbContext.ItemImages.Update(item.ItemImage);
            }

            image.CategoryId = item?.CategoryId ?? category?.Id;

            image.ItemId = item?.Id;

            image.CreatorModifierId = request.UserId;

            _dbContext.ItemImages.Update(image);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO: Log the e.Message error
                return EntityResponseForError(ItemImageErrors.DatabaseError);
            }

            return new EntityResponse<ItemImage, ItemImageErrors>(entity: image);
        }

        public async Task<EntitiesResponse<ItemImage, ItemImageErrors>> GetImagesAsync(int? categoryId = null, bool onlyUnattachedImages = true, int pageNumber = 0, int pageSize = 10)
        {
            Category category = null;
            if (categoryId.HasValue)
            {
                category = await _dbContext.Categories.FindAsync(categoryId);
                if (category == null)
                    return EntitiesResponseForError(ItemImageErrors.CategoryNotFound);
            }

            var query = _dbContext.ItemImages
                .Include(image => image.Item)
                .Include(image => image.Category)
                .AsQueryable();

            if (category != null)
                query = _dbContext.ItemImages.Where(i => i.CategoryId == category.Id);

            if (onlyUnattachedImages)
                query = query.Where(i => i.ItemId == null);

            query = query.Skip(pageNumber * pageSize).Take(pageSize);

            return new EntitiesResponse<ItemImage, ItemImageErrors>(entities: await query.ToListAsync());
        }

        #endregion

        #region Private Methods

        public EntityResponse<ItemImage, ItemImageErrors> EntityResponseForError(ItemImageErrors itemImageError)
            => new EntityResponse<ItemImage, ItemImageErrors>
            (error: new ServiceError<ItemImageErrors>
                (ItemImageErrorTemplatesCollection.GetTempaletForError(itemImageError), itemImageError));

        public EntitiesResponse<ItemImage, ItemImageErrors> EntitiesResponseForError(ItemImageErrors itemImageError)
            => new EntitiesResponse<ItemImage, ItemImageErrors>
            (error: new ServiceError<ItemImageErrors>
                (ItemImageErrorTemplatesCollection.GetTempaletForError(itemImageError), itemImageError));


        #endregion
    }
}
