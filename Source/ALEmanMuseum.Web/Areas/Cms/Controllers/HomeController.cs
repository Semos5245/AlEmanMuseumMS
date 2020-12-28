using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ALEmanMuseum.Web.Areas.Cms.Controllers
{
    public class HomeController : BaseCmsController
    {
        #region Private Members

        private readonly IWebHostEnvironment mWebHostEnvironment;

        #endregion

        #region Constructor

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            mWebHostEnvironment = webHostEnvironment;
        }

        #endregion

        public IActionResult Index()
        {
            //Response.Cookies.Append(
            //    CookieRequestCultureProvider.DefaultCookieName,
            //    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("ar")),
            //    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            //    );
            return View();
        }

        //[HttpPost]
        //public IActionResult ChangeLanguage(string newLanguage)
        //{
        //    var languageSymbol = newLanguage switch
        //    {
        //        "arabic" => "ar",
        //        _ => "en-US",
        //    };

        //    Response.Cookies.Append(
        //        CookieRequestCultureProvider.DefaultCookieName,
        //        CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(languageSymbol)),
        //        new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
        //        );

        //    return RedirectToAction("Index", "Home");
        //}
    }
}
