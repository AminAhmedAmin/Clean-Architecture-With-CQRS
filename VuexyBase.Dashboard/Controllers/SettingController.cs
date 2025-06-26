using Microsoft.AspNetCore.Mvc;
using VuexyBase.Application.Application.ViewModels.Profile;

namespace VuexyBase.Dashboard.Controllers
{
    public class SettingController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> TermsAndUsePolicy()
        {
            return View();
        }


        //[HttpPost]
        //public async Task<IActionResult> ChangePassowrd(ChangePasswordViewModel viewModel)
        //{

        //    var result = await _accountService.ChangePassword(viewModel);

        //    if (result)
        //    {
        //        TempData["ToastMessage"] = "Password Changed successfully";
        //        TempData["ToastType"] = "success";

        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        TempData["ToastMessage"] = "Wrong Password";
        //        TempData["ToastType"] = "danger";

        //        return View(result);
        //    }
        //}

        public async Task<IActionResult> AboutUs()
        {
            return View();
        }

        public async Task<IActionResult> Commissions()
        {
            return View();
        }

        public async Task<IActionResult> Connections()
        {
            return View();
        }
    }
}
