using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace VuexyBase.Dashboard.Controllers
{
    public class LocalizationController : Controller
    {
        public IActionResult SetLanguage(string culture, string returnUrl = "/")
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
            TempData["language"] = culture;
            return LocalRedirect(returnUrl);
        }
    }
}
