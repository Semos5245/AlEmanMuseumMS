using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Services.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALEmanMuseum.Web.Areas.Cms.Controllers
{
    public class CustomerController : BaseCmsController
    {
        #region Private Members

        private readonly IStringLocalizer<CustomerController> mStringLocalizer;
        private readonly ICustomerService mCustomerService;

        #endregion

        #region Constructor

        public CustomerController(
            IStringLocalizer<CustomerController> stringLocalizer,
            ICustomerService customerService)
        {
            mStringLocalizer = stringLocalizer;
            mCustomerService = customerService;
        }

        #endregion

        #region Actions

        public IActionResult Index()
        {
            return View(new List<Customer>());
        }

        public async Task<IActionResult> CustomersBySearchAndPage(string sSearch, int iDisplayStart, int iDisplayLength, string sEcho)
        {
            if (sSearch == null)
                sSearch = string.Empty;

            var response = await mCustomerService.FindCustomersAsync(sSearch, iDisplayStart, iDisplayLength);

            return Json(new
            {
                sEcho,
                iTotalRecords = await mCustomerService.GetCustomersCountAsync(),
                iTotalDislayRecords = response.Entities.Count(),
                Data = response.Entities.Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.Phone,
                    c.Blocked,
                    CountryName = c.Country.Name
                })
            });
        }

        [HttpPost]
        public async Task<IActionResult> BlockCustomer(int id)
        {
            var response = await mCustomerService.BlockCustomerAsync(id);

            if (response == null || !response.Success)
                return BadRequest(mStringLocalizer[response == null ? 
                    "Operation failed" : response.Error.ErrorMessage].Value);

            return Ok();
        }

        #endregion
    }
}