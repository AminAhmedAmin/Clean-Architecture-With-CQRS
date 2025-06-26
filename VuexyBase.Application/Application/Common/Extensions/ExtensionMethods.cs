using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Application.Common.Results;

namespace VuexyBase.Application.Application.Common.Extensions
{
    public static class ExtensionMethods
    {

        public static async Task<Paging<T>> Paginate<T>(this IQueryable<T> query, int pageNumber, int pageSize) where T : class
        {
            var pagin= new Paging<T>
            {
                Pagination = new PagingDetails
                {
                    recordsTotal = query.Count(),
                    PageSize = pageSize,
                    CurrentPage = pageNumber
                }
            };
            if (pagin.Pagination.recordsTotal > 0)
                pagin.Result = await query
                    .AsNoTracking()
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

            return pagin;
        }
    }
}
