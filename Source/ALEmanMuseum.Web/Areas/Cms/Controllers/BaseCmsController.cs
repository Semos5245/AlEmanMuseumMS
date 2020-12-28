using ALEmanMuseum.Web.Framework;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ALEmanMuseum.Web.Areas.Cms.Controllers
{
    [Area(AreaNames.Cms)]
    [EnableCors("defaultCorsPolicy")]
    public class BaseCmsController : Controller
    {
        #region Private Members

        private readonly IStringLocalizer<BaseCmsController> mStringLocalizer;

        #endregion

        #region Constructor

        public BaseCmsController(
            IStringLocalizer<BaseCmsController> stringLocalizer = null)
            => (mStringLocalizer)
            = (stringLocalizer);

        #endregion

        #region Protected Helper Methods

        #endregion
    }
}
