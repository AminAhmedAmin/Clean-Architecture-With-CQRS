using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;
using VuexyBase.API.Controllers.Shared;
using VuexyBase.Application.Application.Contracts.Application.API.Auth;
using VuexyBase.Application.Application.Contracts.Application.API.Home;
using VuexyBase.Application.Application.Contracts.Application.Dashboard.Auth;
using VuexyBase.Application.Application.DTOs.Auth;
using VuexyBase.Application.Application.Query.More.IntroScreens;
using VuexyBase.Application.Common.Results;
using VuexyBase.Domain.Constants;

namespace VuexyBase.API.Controllers
{

    [AllowAnonymous ]
    [EnableRateLimiting("Restrict")]
    [Route("API/More")]
    [ApiExplorerSettings(GroupName = "More")]
    public class MoreController : BaseAPIController
    {



        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;

        public MoreController(IMediator mediator , IMemoryCache memoryCache)
        {
            _mediator = mediator;
            this._memoryCache = memoryCache;
        }
        [EnableRateLimiting("Restrict")]
        [HttpGet("intro-screens")]
        public async Task<IActionResult> GetIntroScreens([FromQuery] string lang)
        {
            var result = await _mediator.Send(new GetIntroScreensQuery(lang));
            return Ok(result); // or use a helper method to format
        }


        [EnableRateLimiting("Restrict")]
        [HttpGet("SetInMomary")]
        public async Task<IActionResult> SetInMomary([FromQuery] string  momary)
        {

            var cacheKey = "MyMomaryKey";

            // Set cache entry with expiration (optional)
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(10)); // Or use .SetAbsoluteExpiration

            _memoryCache.Set(cacheKey, momary, cacheEntryOptions);

            return Ok(new { Message = "Value set in memory cache", Value = momary });
        }

        [EnableRateLimiting("Restrict")]
        [HttpGet("GetFromMomary")] 
        public async Task<IActionResult> GetFromMomary( )
        {

            var cacheKey = "MyMomaryKey";

            if (_memoryCache.TryGetValue(cacheKey, out string momaryValue))
            {
                return Ok(new { Message = "Value retrieved from memory cache", Value = momaryValue });
            }

            return NotFound(new { Message = "Value not found in memory cache" });
        }



    }
}
