using System.Globalization;
using System.Security.Claims;
using VuexyBase.Application.Common.Extensions;
using VuexyBase.Application.Common.Helpers;

namespace VuexyBase.Dashboard.Middlewares
{
    public class UserContextMiddleware
    {
        private readonly RequestDelegate _next;

        public UserContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            BaseHelper.UserId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value/*.Decrypt()*/ ?? string.Empty;

            var userLang = httpContext.Request.Cookies["Culture"];

            if (string.IsNullOrEmpty(userLang))
            {
                userLang = "ar";

                // Store the default culture in the cookie for future requests
                httpContext.Response.Cookies.Append("Culture", userLang, new CookieOptions { Expires = DateTime.UtcNow.AddYears(1) });
            }

            BaseHelper.Lang = userLang;

            var cultureInfo = new CultureInfo(userLang);
            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

            await _next(httpContext);
        }

    }

    public static class UserContextMiddlewareExtension
    {
        public static IApplicationBuilder UseUserContext(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserContextMiddleware>();
        }
    }
}
