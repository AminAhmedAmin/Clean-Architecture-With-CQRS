using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

public class GlobalErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);

        if (context.Response.StatusCode == 500 || context.Response.StatusCode == 404) 
        {
            context.Response.Redirect("/Home/Error");
        }
    }
}
