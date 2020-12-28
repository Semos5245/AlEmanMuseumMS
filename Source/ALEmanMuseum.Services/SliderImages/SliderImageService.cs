using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Core.Infrastructure;
using ALEmanMuseum.Data;
using ALEmanMuseum.Services.ServicesResponse;
using Microsoft.EntityFrameworkCore;

namespace ALEmanMuseum.Services.SliderImages
{
    public class SliderImageService : ISliderImageService
    {
        //#region Private Members

        //private readonly IRepository<SliderImage> mSliderImageRepository;
        //private readonly IWebHostHelper mWebHostHelper;

        //#endregion

        //#region Constructor

        ///// <summary>
        ///// Default constructor
        ///// </summary>
        //public SliderImageService(
        //    IRepository<SliderImage> repository,
        //    IWebHostHelper webHostHelper)
        //{
        //    mSliderImageRepository = repository;
        //    mWebHostHelper = webHostHelper;
        //}

        //#endregion

        //#region Public Methods

        //public async Task<ServiceResponse<SliderImageErrors>> DeleteEntityAsync(int entityId)
        //{
        //    var sliderImage = await mSliderImageRepository.GetByIdAsync(entityId);

        //    if (sliderImage == null)
        //        return ResponseForError(SliderImageErrors.SliderImageNotExist);

        //    try
        //    {
        //        await mSliderImageRepository.DeleteAsync(sliderImage);

        //        var pathToImage = Path.Combine(mWebHostHelper.SlidersImagesPath, sliderImage.ImageName);
        //        File.Delete(pathToImage);
        //    }
        //    catch (Exception)
        //    {
        //        // TODO: Log the e.Message error
        //        return ResponseForError(SliderImageErrors.Database);
        //    }

        //    return new ServiceResponse<SliderImageErrors>();
        //}

        //public async Task<EntitiesResponse<SliderImage, SliderImageErrors>> GetSliderImagesBySliderIdAsync(int sliderId)
        //{
        //    var imagesQuery = mSliderImageRepository.TableNoTracking
        //        .Where(i => i.SliderId == sliderId);

        //    return new EntitiesResponse<SliderImage, SliderImageErrors>
        //        (entities: await imagesQuery.ToListAsync());
        //}


        //public Task<EntitiesResponse<SliderImage, SliderImageErrors>> FindEntitiesAsync(string searchTerm = null, int pageNumber = 0, int pageSize = 10)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<EntitiesResponse<SliderImage, SliderImageErrors>> GetAllEntitiesAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<int> GetEntitiesCountAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<EntityResponse<SliderImage, SliderImageErrors>> GetEntityByIdAsync(int entityId)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<EntityResponse<SliderImage, SliderImageErrors>> InsertEntityAsync(SliderImage entity)
        //{
        //    if (entity == null)
        //        throw new ArgumentNullException(nameof(entity));

        //    try
        //    {
        //        await mSliderImageRepository.InsertAsync(entity);
        //    }
        //    catch (Exception)
        //    {
        //        return ResponseForError(SliderImageErrors.Database);
        //    }

        //    return new EntityResponse<SliderImage, SliderImageErrors>();
        //}

        //public Task<EntityResponse<SliderImage, SliderImageErrors>> UpdateEntityAsync(SliderImage entity)
        //{
        //    throw new NotImplementedException();
        //}

        //#endregion

        //#region Helper Methods

        //protected EntityResponse<SliderImage, SliderImageErrors> ResponseForError(SliderImageErrors sliderImageError)
        //    => new EntityResponse<SliderImage, SliderImageErrors>
        //        (error: new ServiceError<SliderImageErrors>
        //            (SliderImageErrorTemplatesCollection.GetTemplateForError(sliderImageError), sliderImageError));

        //#endregion
        public Task<ServiceResponse<SliderImageErrors>> DeleteEntityAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<EntitiesResponse<SliderImage, SliderImageErrors>> FindEntitiesAsync(string searchTerm = null, int pageNumber = 0, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public Task<EntitiesResponse<SliderImage, SliderImageErrors>> GetAllEntitiesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetEntitiesCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EntityResponse<SliderImage, SliderImageErrors>> GetEntityByIdAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<EntitiesResponse<SliderImage, SliderImageErrors>> GetSliderImagesBySliderIdAsync(int sliderId)
        {
            throw new NotImplementedException();
        }

        public Task<EntityResponse<SliderImage, SliderImageErrors>> InsertEntityAsync(SliderImage entity)
        {
            throw new NotImplementedException();
        }

        public Task<EntityResponse<SliderImage, SliderImageErrors>> UpdateEntityAsync(SliderImage entity)
        {
            throw new NotImplementedException();
        }
    }
}
