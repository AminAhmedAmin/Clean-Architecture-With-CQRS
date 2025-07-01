using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Application.Application.DTOs.More;
using VuexyBase.Application.Common.Results;


namespace VuexyBase.Application.Application.Query.More.IntroScreens
{
    public record GetIntroScreensQuery(string Lang) : IRequest<Result<List<IntroScreenDto>>>;



}
