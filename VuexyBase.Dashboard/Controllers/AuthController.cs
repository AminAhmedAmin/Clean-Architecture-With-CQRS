using Microsoft.AspNetCore.Mvc;
using VuexyBase.Application.Application.Contracts.Application.Dashboard.Auth;
using VuexyBase.Application.Application.ViewModels.Auth;
using VuexyBase.Application.Common.Results;

namespace VuexyBase.Dashboard.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<IActionResult> Login()
        {
            var successMessage = TempData["ToastMessage"];
            var toastrType = TempData["ToastType"];

            if (successMessage != null)
            {
                ViewData["ToastMessage"] = successMessage.ToString();
                ViewData["ToastType"] = toastrType.ToString();
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _authService.Login(model);

            if (result.StatusCode == StatusCodes.Status200OK)
            {
                TempData["ToastMessage"] = result.Message;
                return RedirectToAction("Index", "Home");
            }

            TempData["ToastMessage"] = result.Message;
            TempData["ToastType"] = "danger";

            return RedirectToAction("Login"); ;
        }

        public async Task<IActionResult> ForgetPassword()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ForgetPassword(string email)
        {

            var result = await _authService.ForgetPassword(email);

            if (result.StatusCode == StatusCodes.Status200OK)
            {
                TempData["ToastMessage"] = result.Message;
                return RedirectToAction("ResetPassword" ,new {email});
            }

            TempData["ToastMessage"] = result.Message;
            TempData["ToastType"] = "danger";

            return View();
        }


        public async Task<IActionResult> ResetPassword(string email)
        {
            var successMessage = TempData["ToastMessage"];
            var toastrType = TempData["ToastType"] = "success";

            if (successMessage != null)
            {
                ViewData["ToastMessage"] = successMessage.ToString();
                ViewData["ToastType"] = toastrType.ToString();
            }

            ViewBag.Email = email;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ResetPassword(string email , string newPassword)
        {

            var result = await _authService.ResetPassword(email ,newPassword);

            if (result.StatusCode == StatusCodes.Status200OK)
            {
                TempData["ToastMessage"] = result.Message;
                TempData["ToastType"] = "success";

                return RedirectToAction("Login");
            }

            TempData["ToastMessage"] = result.Message;
            TempData["ToastType"] = "danger";

            return View();
        }


        public async Task<IActionResult> Logout()
        {
            var result = await _authService.Logout();

            return RedirectToAction("Login");
        }

    }
}
