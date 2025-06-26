using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VuexyBase.API.Filters;
using VuexyBase.Application.Common.Helpers;

namespace VuexyBase.API.Controllers.Shared
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [ValidationFilter]
    public class BaseAPIController : ControllerBase
    {
        public string lang => BaseHelper.Lang;
        public string userId => BaseHelper.Lang;

    }
}
