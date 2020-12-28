using ALEmanMuseum.Services.Checkouts;
using ALEmanMuseum.Services.Dtos;
using ALEmanMuseum.Services.Items;
using ALEmanMuseum.Web.Areas.Cms.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ALEmanMuseum.Web.Areas.Cms.Controllers
{
    public class CheckoutController : BaseCmsController
    {
        #region Private & Protected Members

        protected readonly ICheckoutService _checkoutService;
        protected readonly IItemService _itemService;
        protected readonly IStringLocalizer<Program> _stringLocalizer;

        #endregion

        #region Constructor

        public CheckoutController(
            ICheckoutService checkoutService,
            IStringLocalizer<Program> stringLocalizer,
            IItemService itemService)
        {
            _checkoutService = checkoutService;
            _stringLocalizer = stringLocalizer;
            _itemService = itemService;
        }

        #endregion

        #region Actions

        [HttpGet]
        public async Task<IActionResult> Index(DateTime? fromDate, DateTime? toDate)
        {
            var checkouts = (await
                _checkoutService.GetCheckoutsBetweenDates(fromDate, toDate))
                .Entities.Select(c => new CheckoutViewModel
                {
                    CheckoutNumber = c.Id,
                    CustomerName = c.CustomerName,
                    CustomerPhone = c.CustomerPhone,
                    TotalItems = c.CheckoutItems.Count(),
                    TotalValue = c.CheckoutItems.Sum(i => i.Price * i.Quantity)
                });
            

            return View(checkouts);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new CheckoutCreationViewModel
            {
                CheckoutNumber = await _checkoutService.GetNextCheckoutNumber(), // Get the next checkout id to be generated
                Items = await _itemService.Table.Where(i => i.Quantity > 0)
                .Select(i => new ItemDetailsDto
                {
                    Id = i.Id,
                    FullName = $"{i.ArabicName} - {i.EnglishName}",
                    Quantity = i.Quantity,
                    OriginalPrice = i.OriginalPrice,
                    SellingPrice = i.SellingPrice
                }).ToListAsync()
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddCheckout(CreateCheckoutDto request)
        {
            var response = await _checkoutService.InsertCheckoutAsync(request);

            if (!response.Success)
                return BadRequest(_stringLocalizer[response.Error.ErrorMessage].Value);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, bool reAddContent = true)
        {
            var response = await _checkoutService.DeleteCheckoutAsync(id, reAddContent);

            if (!response.Success)
                return BadRequest(_stringLocalizer[response.Error.ErrorMessage].Value);

            return Ok();
        }

        #endregion
    }
}
