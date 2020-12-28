using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Core.ExensionMethods;
using ALEmanMuseum.Core.Infrastructure;
using ALEmanMuseum.Data;
using ALEmanMuseum.Services.ServicesResponse;
using ALEmanMuseum.Services.SliderImages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ALEmanMuseum.Services.Sliders
{
    public class SliderService : ISliderService
    {
        //#region Private Members

        //private readonly IRepository<Slider> mSliderRepository;
        //private readonly ISliderImageService mSliderImageService;
        //private readonly IWebHostHelper mWebHostHelper;
        //private readonly IDbContext mDbContext;

        //#endregion

        //#region Constructor

        ///// <summary>
        ///// Default Constructor
        ///// </summary>
        ///// <param name="sliderImageService">Slider images service</param>
        ///// <param name="sliderRepository">Sliders repository for sliders modification</param>
        //public SliderService(
        //    IDbContext dbContext,
        //    IRepository<Slider> sliderRepository,
        //    ISliderImageService sliderImageService,
        //    IWebHostHelper webHostHelper)
        //{
        //    mDbContext = dbContext;
        //    mSliderRepository = sliderRepository;
        //    mSliderImageService = sliderImageService;
        //    mWebHostHelper = webHostHelper;
        //}

        //#endregion

        //#region Public Methods

        //public async Task<ServiceResponse<SliderErrors>> DeleteEntityAsync(int entityId)
        //{
        //    var sliderCount = await GetEntitiesCountAsync();

        //    if (sliderCount == 1)
        //        return ResponseForError(SliderErrors.OnlyOneSliderExist);

        //    var slider = await mSliderRepository.GetByIdAsync(entityId);

        //    if (slider == null)
        //        return ResponseForError(SliderErrors.SliderNotExist);

        //    try
        //    {
        //        // Reverse for not getting the execption
        //        // {"Collection was modified after the enumerator was instantiated."}
        //        foreach (var sliderImage in slider.SliderImages.Reverse())
        //        {
        //            await mSliderImageService.DeleteEntityAsync(sliderImage.Id);
        //        }

        //        await mSliderRepository.DeleteAsync(slider);
        //    }
        //    catch
        //    {
        //        // TODO: Log the e.Message error
        //        return ResponseForError(SliderErrors.DatabaseError);
        //    }

        //    // Make the first slider active
        //    var firstSlider = await mSliderRepository.Table.FirstOrDefaultAsync();

        //    if (firstSlider != null)
        //    {
        //        firstSlider.Active = true;
        //        await UpdateEntityAsync(firstSlider);
        //    }

        //    return new ServiceResponse<SliderErrors>();
        //}

        //public async Task<EntitiesResponse<Slider, SliderErrors>> FindEntitiesAsync(string searchTerm = null, int pageNumber = 0, int pageSize = 10)
        //{
        //    var query = mSliderRepository.TableNoTracking;
        //    var hasNumbers = searchTerm.HasNumbers();

        //    if (!string.IsNullOrEmpty(searchTerm))
        //        query = query.Where(s => s.ArabicName.Contains(searchTerm) ||
        //                                 s.EnglishName.Contains(searchTerm) ||
        //                                 (hasNumbers && 
        //                                    s.CreatedDate.ToLocalTime().ToString().Contains(searchTerm) ||
        //                                    (s.LastModifiedDate != null && s.LastModifiedDate.Value.ToLocalTime().ToString().Contains(searchTerm))));

        //    query = query.Skip(pageNumber * pageSize).Take(pageSize);

        //    return new EntitiesResponse<Slider, SliderErrors>
        //        (entities: await query.ToListAsync());
        //}

        //public async Task<EntitiesResponse<Slider, SliderErrors>> GetAllEntitiesAsync()
        //    => new EntitiesResponse<Slider, SliderErrors>
        //    (entities: await mSliderRepository.TableNoTracking.ToListAsync());

        //public async Task<int> GetEntitiesCountAsync() => await mSliderRepository.TableNoTracking.CountAsync();

        //public async Task<EntityResponse<Slider, SliderErrors>> GetActiveSliderAsync()
        //    => new EntityResponse<Slider, SliderErrors>
        //        (entity: await mSliderRepository.Table
        //                        .FirstOrDefaultAsync(slider => slider.Active));

        //public async Task<EntityResponse<Slider, SliderErrors>> GetEntityByIdAsync(int entityId)
        //{
        //    var slider = await mSliderRepository.GetByIdAsync(entityId);

        //    return slider == null ?
        //        ResponseForError(SliderErrors.SliderNotExist) :
        //        new EntityResponse<Slider, SliderErrors>(entity: slider);
        //}

        //public async Task<ServiceResponse<SliderErrors>> MakeSliderActiveAsync(int sliderId)
        //{
        //    var slider = await mSliderRepository.GetByIdAsync(sliderId);

        //    if (slider == null)
        //        return ResponseForError(SliderErrors.SliderNotExist);

        //    if (slider.Active) return ResponseForError(SliderErrors.SliderAlreadyActive);

        //    if (slider.SliderImages.Count < 1) return ResponseForError(SliderErrors.SliderWithNoImages);

        //    // Get the current active slider
        //    var activeSlider = (await GetActiveSliderAsync()).Entity;

        //    // Make the current slider inactive
        //    if (activeSlider != null)
        //    {
        //        activeSlider.Active = false;
        //        await UpdateEntityAsync(activeSlider);
        //    }

        //    slider.Active = true;
        //    await UpdateEntityAsync(slider);

        //    return new ServiceResponse<SliderErrors>();
        //}

        //public async Task<EntityResponse<Slider, SliderErrors>> InsertEntityAsync(Slider entity)
        //{
        //    if (entity == null)
        //        throw new ArgumentNullException(nameof(entity));

        //    var sliderWithSameInfo = await mSliderRepository.Table.FirstOrDefaultAsync
        //        (s => s.ArabicName == entity.ArabicName || s.EnglishName == entity.EnglishName);

        //    if (sliderWithSameInfo != null)
        //        return ResponseForError(SliderErrors.SliderAlreadExist);

        //    // Make slider initially not the active one so that we preserve an active slider 
        //    // with actual images contained
        //    entity.Active = false;

        //    try
        //    {
        //        await mSliderRepository.InsertAsync(entity);
        //    }
        //    catch (Exception)
        //    {
        //        // TODO: Log the e.Message error
        //        return ResponseForError(SliderErrors.DatabaseError);
        //    }

        //    return new EntityResponse<Slider, SliderErrors>(entity: entity);
        //}

        //public async Task<EntityResponse<Slider, SliderErrors>> UpdateEntityAsync(Slider entity)
        //{
        //    if (entity == null)
        //        throw new ArgumentNullException(nameof(entity));

        //    var sliderWithSameInfo = await mSliderRepository.TableNoTracking
        //        .FirstOrDefaultAsync(s => s.Id != entity.Id && (s.ArabicName == entity.ArabicName || s.EnglishName == entity.EnglishName));

        //    if (sliderWithSameInfo != null)
        //        return ResponseForError(SliderErrors.SliderAlreadExist);

        //    try
        //    {
        //        entity.LastModifiedDate = DateTime.UtcNow;
        //        await mSliderRepository.UpdateAsync(entity);
        //    }
        //    catch (Exception)
        //    {
        //        // TODO: Log the e.Message error
        //        return ResponseForError(SliderErrors.DatabaseError);
        //    }

        //    return new EntityResponse<Slider, SliderErrors>(entity: entity);
        //}

        //#endregion

        //#region Helper Methods

        //protected EntityResponse<Slider, SliderErrors> ResponseForError(SliderErrors sliderError)
        //    => new EntityResponse<Slider, SliderErrors>
        //    (error: new ServiceError<SliderErrors>
        //        (SliderErrorTemplatesCollection.GetTemplateForError(sliderError), sliderError));

        //#endregion
        public Task<ServiceResponse<SliderErrors>> DeleteEntityAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<EntitiesResponse<Slider, SliderErrors>> FindEntitiesAsync(string searchTerm = null, int pageNumber = 0, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public Task<EntityResponse<Slider, SliderErrors>> GetActiveSliderAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EntitiesResponse<Slider, SliderErrors>> GetAllEntitiesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetEntitiesCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EntityResponse<Slider, SliderErrors>> GetEntityByIdAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<EntityResponse<Slider, SliderErrors>> InsertEntityAsync(Slider entity)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<SliderErrors>> MakeSliderActiveAsync(int sliderId)
        {
            throw new NotImplementedException();
        }

        public Task<EntityResponse<Slider, SliderErrors>> UpdateEntityAsync(Slider entity)
        {
            throw new NotImplementedException();
        }
    }
}
