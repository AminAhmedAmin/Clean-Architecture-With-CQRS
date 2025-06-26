using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using VuexyBase.Application.Common.Results;

namespace VuexyBase.API.Filters
{
    public class ValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult objectResult && objectResult.Value is ValidationProblemDetails validationErrors)
            {
                if (validationErrors.Errors.Any())
                {
                    string formattedMessage = GetFormattedErrorMessage(validationErrors.Errors);
                    context.Result = new BadRequestObjectResult(Result<string>.Fail(formattedMessage));
                }
            }

            static string GetFormattedErrorMessage(IDictionary<string, string[]> errors)
            {
                StringBuilder builder = new();
                foreach (var error in errors)
                {
                    builder.AppendLine($"{error.Value[0]}");
                }
                return builder.ToString();
            }

            base.OnResultExecuting(context);
        }
    }

}
