using ALEmanMuseum.Services.Categories;
using ALEmanMuseum.Services.Dtos;
using ALEmanMuseum.Services.ItemImages;
using ALEmanMuseum.Services.Items;
using ALEmanMuseum.Web.Areas.Cms.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALEmanMuseum.Web.Areas.Cms.Controllers
{
    public class ItemImageController : BaseCmsController
    {
        #region Private Members

        private readonly IItemImageService _itemImageService;
        private readonly IItemService _itemService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IStringLocalizer<ItemImageController> _stringLocalizer;
        private readonly ICategoryService _categoryService;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ItemImageController(
            IItemImageService itemImageService,
            IItemService itemService,
            IWebHostEnvironment webHostEnvironment,
            ICategoryService categoryService,
            IStringLocalizer<ItemImageController> stringLocalizer
            )
        {
            _itemImageService = itemImageService;
            _itemService = itemService;
            _webHostEnvironment = webHostEnvironment;
            _stringLocalizer = stringLocalizer;
            _categoryService = categoryService;
        }

        #endregion

        #region Actions

        public async Task<IActionResult> Index(int? selectedCategoryId = null, bool onlyUnattached = true)
        {
            var response = await _itemImageService.GetImagesAsync(selectedCategoryId, onlyUnattached);

            var viewModel = new ItemImagesViewModel
            {
                CategoriesList = await GetCategoriesSelectList(selectedCategoryId),
                ItemsList = await GetItemsSelectList(),
                Images = new List<ItemImageViewModel>()
            };

            response.Entities.ToList().ForEach(image =>
            {
                viewModel.Images.Add(new ItemImageViewModel
                {
                    Id = image.Id,
                    ImageUrl = image.ImageUrl,
                    ImageThumbUrl = image.ThumbNailUrl,
                    Attached = image.Item != null,
                    ItemName = image.Item == null ? _stringLocalizer["No item"].Value : $"{image.Item.ArabicName} - {image.Item.EnglishName}",
                    CategoryName = image.Category == null ? _stringLocalizer["No category"].Value : $"{image.Category.ArabicName} - {image.Category.EnglishName}"
                });
            });

            return View(viewModel);
        }

        public async Task<IActionResult> ImageDetails(int imageId)
        {
            var response = await _itemImageService.GetImageByIdAsync(imageId);

            if (!response.Success)
                return NotFound(_stringLocalizer[response.Error.ErrorMessage].Value);
            return Ok(new
            {
                response.Entity.ItemId,
                response.Entity.CategoryId
            });
        }

        public async Task<IActionResult> UploadImage()
        {
            return View(new UploadItemImageViewModel
            {
                CategoriesList = await GetCategoriesSelectList()
            });
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file, int? categoryId)
        {
            var response = await _itemImageService.InsertImageAsync
                (new AddItemImageDto(file,"", categoryId));

            if (!response.Success)
                return BadRequest(_stringLocalizer[response.Error.ErrorMessage].Value);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AttachImage(AttachImageDto request)
        {
            var response = await _itemImageService.AttachImageAsync(request);

            if (!response.Success)
                return BadRequest(response.LocalizedError(_stringLocalizer));

            var image = response.Entity;

            return Ok(new
            {
                ItemName = image.Item == null ? _stringLocalizer["No item"].Value : $"{image.Item.ArabicName} - {image.Item.EnglishName}",
                CategoryName = image.Category == null ? _stringLocalizer["No category"].Value : $"{image.Category.ArabicName} - {image.Category.EnglishName}"
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteResponse = await _itemImageService.DeleteImageAsync(id);

            if (!deleteResponse.Success)
                return deleteResponse.Error.ErrorType switch
                {
                    ItemImageErrors.ImageNotFound => NotFound(_stringLocalizer[deleteResponse.Error.ErrorMessage].Value),
                    _ => BadRequest(_stringLocalizer[deleteResponse.Error.ErrorMessage].Value)
                };

            return Ok();
        }

        #endregion

        #region Helper Methods

        public async Task<SelectList> GetCategoriesSelectList(int? selectedValue = 0)
        {
            return new SelectList
                (await _categoryService.Table.Select(c => new SelectListItem
                {
                    Text = $"{c.ArabicName} - {c.EnglishName}",
                    Value = c.Id.ToString()
                }).ToListAsync(), "Value", "Text", selectedValue.ToString());
        }

        public async Task<SelectList> GetItemsSelectList(int? selectedValue = 0)
        {
            return new SelectList
                (await _itemService.Table.Select(c => new SelectListItem
                {
                    Text = $"{c.ArabicName} - {c.EnglishName}",
                    Value = c.Id.ToString()
                }).ToListAsync(), "Value", "Text", selectedValue.ToString());
        }

        #endregion
    }
}