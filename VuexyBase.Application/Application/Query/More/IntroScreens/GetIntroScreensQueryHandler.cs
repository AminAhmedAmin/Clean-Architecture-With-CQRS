using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Application.Application.DTOs.More;
using VuexyBase.Application.Common.Results;
using VuexyBase.Application.Persistence;
using VuexyBase.Domain.Constants;

namespace VuexyBase.Application.Application.Query.More.IntroScreens
{
    public class GetIntroScreensQueryHandler : IRequestHandler<GetIntroScreensQuery, Result<List<IntroScreenDto>>>
    {
        private readonly ApplicationDbContext _db;

        public GetIntroScreensQueryHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Result<List<IntroScreenDto>>> Handle(GetIntroScreensQuery request, CancellationToken cancellationToken)
        {
            var result = await _db.IntroScreens
                .Where(x => x.IsActive)
                .Select(x => new IntroScreenDto
                {
                    Id = x.Id,
                    Title = request.Lang == "ar" ? x.NameAr : x.NameEn,
                    Description = request.Lang == "ar" ? x.DescriptionAr : x.DescriptionEn,
                    Image = AppRoutes.DashboardUrl + x.BackgroundImage
                }).ToListAsync(cancellationToken);

            return Result<List<IntroScreenDto>>.Success(result, "Success");
        }
    }
}
