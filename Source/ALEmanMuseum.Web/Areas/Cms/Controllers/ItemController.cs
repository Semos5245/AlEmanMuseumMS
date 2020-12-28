using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Core.ExensionMethods;
using ALEmanMuseum.Services.Categories;
using ALEmanMuseum.Services.ItemImages;
using ALEmanMuseum.Services.Items;
using ALEmanMuseum.Web.Areas.Cms.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ALEmanMuseum.Web.Areas.Cms.Controllers
{
    public class ItemController : BaseCmsController
    {
        #region Private Members

        private readonly IStringLocalizer<ItemController> _stringLocalizer;
        private readonly IItemService _itemService;
        private readonly ICategoryService _categoryService;
        private readonly IItemImageService _imageService;

        #endregion

        #region Constructor

        public ItemController(
            IStringLocalizer<ItemController> stringLocalizer,
            IItemService itemService,
            ICategoryService categoryService,
            IItemImageService imageService,
            IWebHostEnvironment webHostEnvironment) : base()
        {
            _stringLocalizer = stringLocalizer;
            _itemService = itemService;
            _categoryService = categoryService;
            _imageService = imageService;
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public IActionResult Index()
        {
            // Returning empty list since items are being retrieved by
            // data tables server side mode
            return View(new List<Item>());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _itemService.Table.Select(item => new ItemDetailsDto
            {
                Id = item.Id,
                FullName = $"{item.ArabicName} - {item.EnglishName}",
                OriginalPrice = item.OriginalPrice,
                SellingPrice = item.SellingPrice,
                Quantity = item.Quantity
            }).ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> ItemsByPageAndSearch(string sEcho, string sSearch, int iDisplayLength, int iDisplayStart)
        {
            sSearch = StringExtensions.IsNullOrEmptyOrWhiteSpace(sSearch) ? "" : sSearch;

            var response = await _itemService.FindItemsAsync(sSearch, iDisplayStart, iDisplayLength);

            return Ok(new
            {
                sEcho,
                iTotalRecords = await _itemService.GetItemsCountAsync(),
                iTotalDisplayRecords = response.Entities.Count(),
                Data = response.Entities.Select(i => new
                {
                    i.Id,
                    i.ArabicName,
                    i.EnglishName,
                    CreatedDate = i.CreatedDate.ToLocalTime().ToString(),
                    i.Quantity,
                    i.SellingPrice,
                    i.UniqueNumber,
                    i.Hidden
                })
            });
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? imageToAttachId = null)
        {
            ItemImage image = null;
            if (imageToAttachId.HasValue)
                image = (await _imageService.GetImageByIdAsync(imageToAttachId.Value)).Entity;

            return View(new ItemViewModel
            {
                Categories = await GetCategoriesSelectList(),
                ImageId = imageToAttachId,
                ImageThumbUrl = image?.ThumbNailUrl
            });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _itemService.GetItemByIdAsync(id);

            return response.Success switch
            {
                false => NotFound(_stringLocalizer[response.Error.ErrorMessage].Value),
                true => View(new ItemViewModel(response.Entity)
                {
                    Categories = await GetCategoriesSelectList(response.Entity.CategoryId),
                    CategoryId = response.Entity.CategoryId,
                    ImageThumbUrl = response.Entity.ItemImage?.ThumbNailUrl
                })
            };
        }

        [HttpGet]
        public async Task<IActionResult> DownloadBarcode(int id)
        {
            var response = await _itemService.GetItemByIdAsync(id);

            if (!response.Success)
                return NotFound(_stringLocalizer[response.Error.ErrorMessage]);

            var memoryStream = new MemoryStream();
            using (var stream = new FileStream(response.Entity.BarcodeImageUrl, FileMode.Open))
                await stream.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            return File(memoryStream, "image/jpeg", response.Entity.BarcodeImageUrl);
        }

        [HttpPost]
        public async Task<IActionResult> GenerateBarcode(int id)
        {
            var response = await _itemService.GetItemByIdAsync(id);

            if (!response.Success)
                return NotFound(_stringLocalizer[response.Error.ErrorMessage]);

            //var barcodeResposne = await mItemService.GenerateBarcodeForItemAsync(id, "");

            //if (!barcodeResposne.Success)
            //    return BadRequest(mStringLocalizer[barcodeResposne.Error.ErrorMessage]);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ItemViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var response = await _itemService.InsertItemAsync(new Services.Dtos.CreateItemDto
            {
                ArabicName = model.ArabicName,
                ArabicDescription = model.ArabicDescription,
                EnglishDescription = model.EnglishDescription,
                EnglishName = model.EnglishName,
                Hidden = model.Hidden,
                Quantity = model.Quantity,
                OriginalPrice = model.OriginalPrice,
                SellingPrice = model.SellingPrice,
                ImageFile = model.ImageFile,
                Tags = model.Tags,
                UserId = User.Identity.Name,
                CategoryId = model.CategoryId,
                ImageId = model.ImageId
            });

            if (!response.Success)
            {
                ModelState.AddModelError("", _stringLocalizer[response.Error.ErrorMessage].Value);
                return View(model);
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ItemViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategoriesSelectList(model.CategoryId);
                return View(model);
            }

            var updateResponse = await _itemService.UpdateItemAsync(new Services.Dtos.UpdateItemDto
            {
                ArabicDescription = model.ArabicDescription,
                ArabicName = model.ArabicName,
                EnglishDescription = model.EnglishDescription,
                EnglishName = model.EnglishName,
                Hidden = model.Hidden,
                CategoryId = model.CategoryId,
                ImageFile = model.ImageFile,
                ItemId = model.ItemId,
                Quantity = model.Quantity,
                OriginalPrice = model.OriginalPrice,
                SellingPrice = model.SellingPrice,
                Tags = model.Tags,
                UserId = User.Identity.Name
            });

            if (!updateResponse.Success)
                return BadRequest(_stringLocalizer[updateResponse.Error.ErrorMessage].Value);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteResponse = await _itemService.DeleteItemAsync(id);

            if (!deleteResponse.Success)
                return deleteResponse.Error.ErrorType switch
                {
                    ItemErrors.ItemNotExist => NotFound(deleteResponse.Error.ErrorMessage),
                    _ => BadRequest(_stringLocalizer[deleteResponse.Error.ErrorMessage])
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

        #endregion
    }
}