using Microsoft.AspNetCore.Mvc;
using VuexyBase.Application.Application.Contracts.Application.Dashboard.Account;
using VuexyBase.Application.Application.ViewModels.Profile;

namespace VuexyBase.Dashboard.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> Index()
        {
            var successMessage = TempData["ToastMessage"];
            var toastrType = TempData["ToastType"];

            if (successMessage != null)
            {
                ViewData["ToastMessage"] = successMessage.ToString();
                ViewData["ToastType"] = toastrType.ToString();
            }

            var result = await _accountService.AccountData();
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateProfile(UpdateProfileViewModel viewModel)
         {
            var result = await _accountService.UpdateProfile(viewModel);

            if (result)
            {
                TempData["ToastMessage"] = "Profile updated successfully";
                TempData["ToastType"] = "success";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ToastMessage"] = "Failed to update profile";
                TempData["ToastType"] = "danger";
                return View(result);
            }
        }


        public async Task<IActionResult> Security()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ChangePassowrd(ChangePasswordViewModel viewModel)
        {

            var result = await _accountService.ChangePassword(viewModel);

            if (result)
            {
                TempData["ToastMessage"] = "Password Changed successfully";
                TempData["ToastType"] = "success";

                return RedirectToAction("Index");
            }
            else
            {
                TempData["ToastMessage"] = "Wrong Password";
                TempData["ToastType"] = "danger";

                return View(result);
            }
        }

    }
}
