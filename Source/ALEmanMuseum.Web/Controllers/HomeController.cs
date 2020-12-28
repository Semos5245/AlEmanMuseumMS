using System;
using System.Threading.Tasks;
using ALEmanMuseum.Core.Infrastructure;
using ALEmanMuseum.Services.Categories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ALEmanMuseum.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> mStringLocalizer;
        private readonly IWebHostHelper hostHelper;

        public HomeController(
            IStringLocalizer<HomeController> stringLocalizer,
            IWebHostHelper hostHelper)
        {
            mStringLocalizer = stringLocalizer;
            this.hostHelper = hostHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult LanguageToArabic()
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("ar")),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1)}
                );
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult LanguageToEnglish()
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("en-US")),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );
            return RedirectToAction(nameof(Index));
        }
    }
}
