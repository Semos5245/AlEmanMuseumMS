using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Core.ExensionMethods;
using ALEmanMuseum.Services.Countries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALEmanMuseum.Web.Areas.Cms.Controllers
{
    public class CountryController : BaseCmsController
    {
        #region Private Members

        private readonly IStringLocalizer<CountryController> mCountryLocalizer;
        private readonly ICountryService mCountryService;
        
        #endregion

        #region Constructor

        public CountryController(
            IStringLocalizer<CountryController> stringLocalizer,
            ICountryService countryService)
        {
            mCountryLocalizer = stringLocalizer;
            mCountryService = countryService;
        }

        #endregion

        #region Actions

        [HttpGet]
        public IActionResult Index()
        {
            return View(new List<Country>());
        }

        [HttpGet]
        public async Task<IActionResult> CountriesByPageAndSearch(int sEcho, int iDisplayStart, int iDisplayLength, string sSearch)
        {
            sSearch = string.IsNullOrEmpty(sSearch) ? "" : sSearch.Trim();

            var response = await mCountryService.FindCountriesAsync(sSearch, iDisplayStart, iDisplayLength);

            return Json(new
            {
                sEcho,
                iTotalRecords = await mCountryService.GetCountriesCountAsync(),
                iTotalDisplayRecords = response.Entities.Count(),
                Data = response.Entities.Select(c => new
                {
                    id = c.Id,
                    name = c.Name,
                    CreatedDate = c.CreatedDate.ToLocalTime().ToString(),
                    LastModifiedDate = c.LastModifiedDate.ToLocalTime().ToString()
                })
            });
        }

        [Route("Cms/Country/Create/{name}")]
        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            // Check if name is empty
            if (StringExtensions.IsNullOrEmptyOrWhiteSpace(name))
                return BadRequest(mCountryLocalizer["Name is empty"].Value);

            var response = await mCountryService.InsertCountryAsync(new Country
            {
                Name = name
            });

            if (!response.Success)
                return BadRequest(mCountryLocalizer[response.Error.ErrorMessage].Value);

            return Ok(new
            {
                response.Entity.Id,
                CreatedDate = response.Entity.CreatedDate.ToLocalTime().ToString(),
                response.Entity.LastModifiedDate,
                response.Entity.Name
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, string name)
        {
            if (StringExtensions.IsNullOrEmptyOrWhiteSpace(name))
                return BadRequest(mCountryLocalizer["Error in entered data"].Value);

            var getCountryResponse = await mCountryService.GetCountryByIdAsync(id);
            
            if (!getCountryResponse.Success)
                return NotFound(mCountryLocalizer[getCountryResponse.Error.ErrorMessage].Value);

            var country = getCountryResponse.Entity;

            country.Name = name.Trim();

            var updateCountryResponse = await mCountryService.UpdateCountryAsync(country);

            if (!updateCountryResponse.Success)
                return BadRequest(mCountryLocalizer[updateCountryResponse.Error.ErrorMessage].Value);

            return Ok(new
            {
                updateCountryResponse.Entity.Name,
                LastModifiedDate = updateCountryResponse.Entity.LastModifiedDate.ToLocalTime().ToString()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await mCountryService.DeleteCountryAsync(id);

            if (!response.Success)
                return response.Error.ErrorType switch
                {
                    CountryErrors.CountryNotExist => NotFound(mCountryLocalizer[response.Error.ErrorMessage].Value),
                    _ => BadRequest(mCountryLocalizer[response.Error.ErrorMessage].Value)
                };

            return Ok();
        }

        #endregion
    }
}
