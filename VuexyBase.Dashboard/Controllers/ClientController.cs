using Microsoft.AspNetCore.Mvc;
using VuexyBase.Application.Application.Common.Extensions;
using VuexyBase.Application.Application.Contracts.Application.Dashboard.User;
using VuexyBase.Domain.Enums.Identities;

namespace VuexyBase.Dashboard.Controllers
{
    //[AuthorizeRolesAttribute(Roles.Admin)]
    public class ClientController : Controller
    {
        private readonly IUserService userService;

        public ClientController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await userService.UserIndex();
            return View(result);
        }
    }
}
