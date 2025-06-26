using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;
using VuexyBase.Application.Persistence;

namespace VuexyBase.Dashboard.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TransactionMiddleware
    {
        private readonly RequestDelegate _nextAction;
        public TransactionMiddleware(RequestDelegate nextAction)
        {
            _nextAction = nextAction;
        }

        public async Task InvokeAsync(HttpContext context, ApplicationDbContext _context)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                await _nextAction(context);

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

    }
}
