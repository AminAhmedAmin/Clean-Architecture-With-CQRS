using VuexyBase.Application.Common.Extensions;
using VuexyBase.Application.Common.Helpers;

namespace VuexyBase.API.Middlewares
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
            BaseHelper.UserId = httpContext.User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value.Decrypt() ?? string.Empty;

            BaseHelper.Lang = httpContext.Request.Headers.AcceptLanguage.FirstOrDefault() ?? "ar";

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
