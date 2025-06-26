using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using FluentValidation;
using VuexyBase.Application.Application.Common.Helpers;
using System.Text.RegularExpressions;
using VuexyBase.Domain.Constants;
using VuexyBase.Domain.Enums.Validation;
using VuexyBase.Application.Common.Helpers;

namespace VuexyBase.Application.Application.DTOs.Auth
{

    public class ResendCodeDto
    {
        [DisplayName("رقم الجوال")] public string PhoneNumber { get; set; }
    }

    //public class ResendCodeDtoValidator : AbstractValidator<ResendCodeDto>
    //{
    //    public ResendCodeDtoValidator( IPathService pathService)
    //    {
    //        var lang = BaseHelper.Lang;
    //        var path = pathService.ValidationLocalizationPath;

    //        RuleFor(x => x.PhoneNumber)
    //            .NotEmpty()
    //            .WithMessage(x => FluentValidationHelper.Message<ResendCodeDto>(lang, path, nameof(x.PhoneNumber), ValidationTypesEnum.Required))
    //            .Matches(RegularExpressions.SaudiPhone)
    //            .WithMessage(x => FluentValidationHelper.Message<ResendCodeDto>(lang, path, nameof(x.PhoneNumber), ValidationTypesEnum.SaudiPhone));
    //    }
    //}
}