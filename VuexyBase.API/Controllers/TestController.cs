using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Localization;
using VuexyBase.Application.Application.Contracts.Application.API.Home;
using VuexyBase.Application.Common.Extensions;
using VuexyBase.Application.Common.Helpers;
using VuexyBase.Application.Common.Results;
using VuexyBase.Domain.Entities.Identities;

namespace VuexyBase.API.Controllers
{
    [ApiController]
    [Route("API/Test")]
    [ApiExplorerSettings(GroupName = "Test")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TestController : ControllerBase
    {
        private readonly IStringLocalizer _loc;
        private readonly IHomeService _homeService;

        public TestController(IStringLocalizer loc , IHomeService homeService)
        {
            _loc = loc;
            _homeService = homeService;
        }

        [HttpPost("TryTranslation")]
        public async Task<Result<string>> TryTranslation()
        {
            return Result<string>.Success(_loc["Home"]);
        }

        [HttpGet("TryRateLimit")]
        [EnableRateLimiting("Restrict")]
        public IActionResult TryRateLimit()
        {
            BaseHelper.UserId.Decrypt();
            return Ok("This endpoint is rate-limited!");
        }


        [HttpPut("SaveInclude")]
        [EnableRateLimiting("Restrict")]
        public async Task<IActionResult> SaveInclude(string name)
        {
            //BaseHelper.UserId.Decrypt();

            var updateuser = new ApplicationDbUser
            {
                Id = "bed70a8f-5720-4268-b1f8-0437b3c65aa9",
                User_Name = name,
            };

            await _homeService.SaveIncludeAsync(updateuser, nameof(ApplicationDbUser.User_Name));
            return Ok("This endpoint is rate-limited!");
        }
    }
}
