using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Core.ExensionMethods;
using ALEmanMuseum.Services.Categories;
using ALEmanMuseum.Web.Areas.Cms.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ALEmanMuseum.Web.Areas.Cms.Controllers
{
    public class CategoryController : BaseCmsController
    {
        #region Private Members

        private readonly ICategoryService mCategoryService;
        private readonly IStringLocalizer<CategoryController> mStringLocalizer;

        #endregion

        #region Constructor

        public CategoryController(
            ICategoryService categoryService,
            IStringLocalizer<CategoryController> stringLocalizer)
            => (mCategoryService, mStringLocalizer)
            =  (categoryService, stringLocalizer);

        #endregion

        #region Actions

        [HttpGet]
        public IActionResult Index()
        {
            return View(new List<Category>());
        }

        [HttpGet]
        public async Task<IActionResult> CategoriesByPageAndSearch(string sEcho, int iDisplayStart, int iDisplayLength, string sSearch)
        {
            sSearch = string.IsNullOrEmpty(sSearch) ? "" : sSearch.Trim();
            var categoriesResponse = await mCategoryService.FindCategoriesAsync(sSearch, iDisplayStart, iDisplayLength);

            return Json(new
            {
                sEcho,
                iTotalRecords = await mCategoryService.GetCategoriesCountAsync(),
                iTotalDisplayRecords = categoriesResponse.Entities.Count(),
                Data = categoriesResponse.Entities.Select(c => new 
                {
                    c.Id,
                    c.ArabicName,
                    c.EnglishName,
                    CreatedDate = c.CreatedDate.ToLocalTime().ToString(),
                    LastModifiedDate = c.LastModifiedDate.ToLocalTime().ToString()
                })
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryVieModel viewModel)
        {
            if (!ModelState.IsValid) return View();

            var response = await mCategoryService.InsertCategoryAsync(viewModel.ToCategoryEntity().TrimObject());

            if (!response.Success)
                return BadRequest(mStringLocalizer[response.Error.ErrorMessage].Value);

            var returnedCategory = response.Entity;

            return Ok(new
            {
                returnedCategory.Id,
                returnedCategory.ArabicName,
                returnedCategory.EnglishName,
                CreatedDate = returnedCategory.CreatedDate.ToLocalTime().ToString(),
                LastModifiedDate = returnedCategory.LastModifiedDate.ToLocalTime().ToString()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryVieModel viewModel)
        {
            if (!ModelState.IsValid) return View();

            var getCategoryResponse = await mCategoryService.GetCategoryByIdAsync(viewModel.CategoryId);

            if (!getCategoryResponse.Success)
                return NotFound(mStringLocalizer[getCategoryResponse.Error.ErrorMessage].Value);

            var category = getCategoryResponse.Entity;

            category.ArabicName = viewModel.ArabicName.Trim();
            category.EnglishName = viewModel.EnglishName.Trim();

            var updateResponse = await mCategoryService.UpdateCategoryAsync(category);

            if (!updateResponse.Success)
                return BadRequest(mStringLocalizer[updateResponse.Error.ErrorMessage].Value);

            var returnedCategory = updateResponse.Entity;

            return Ok(new
            {
                returnedCategory.ArabicName,
                returnedCategory.EnglishName,
                CreatedDate = returnedCategory.CreatedDate.ToLocalTime().ToString(),
                LastModifiedDate = returnedCategory.LastModifiedDate.ToLocalTime().ToString()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await mCategoryService.DeleteCategoryAsync(id);

            if (!response.Success)
                return response.Error.ErrorType switch
                {
                    CategoryErrors.CategoryNotExist => NotFound(mStringLocalizer[response.Error.ErrorMessage].Value),
                    _ => BadRequest(mStringLocalizer[response.Error.ErrorMessage].Value)
                };

            return Ok();
        }

        #endregion
    }
}