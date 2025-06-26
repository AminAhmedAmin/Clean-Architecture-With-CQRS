using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VuexyBase.Dashboard.Controllers
{
    [Authorize]

    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public async Task<IActionResult> Index()
        {
            var successMessage = TempData["ToastMessage"];
            var toastrType = TempData["ToastType"] = "success";

            if (successMessage != null)
            {
                ViewData["ToastMessage"] = successMessage.ToString();
                ViewData["ToastType"] = toastrType.ToString();
            }

            return View();
        }

        public async Task<IActionResult> Error()
        {
            return View();
        }
    }
}
