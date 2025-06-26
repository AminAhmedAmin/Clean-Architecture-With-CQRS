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
    public class ConfirmCodeDto
    {
        [DisplayName("رقم الجوال")] public string PhoneNumber { get; set; }

        [DisplayName("كود التحقق")] public string Code { get; set; }

        [DisplayName("الجهاز")] public DeviceDto Device { get; set; }
    }

    //public class ConfirmCodeDtoValidator : AbstractValidator<ConfirmCodeDto>
    //{
    //    public ConfirmCodeDtoValidator(IPathService pathService)
    //    {
    //        var lang = BaseHelper.Lang;
    //        var path = pathService.ValidationLocalizationPath;

    //        RuleFor(x => x.PhoneNumber)
    //            .NotEmpty()
    //            .WithMessage(x => FluentValidationHelper.Message<ConfirmCodeDto>(lang, path, nameof(x.PhoneNumber), ValidationTypesEnum.Required))
    //            .Matches(RegularExpressions.SaudiPhone)
    //            .WithMessage(x => FluentValidationHelper.Message<ConfirmCodeDto>(lang, path, nameof(x.PhoneNumber), ValidationTypesEnum.SaudiPhone));

    //        RuleFor(x => x.Code)
    //            .NotEmpty()
    //            .WithMessage(x => FluentValidationHelper.Message<ConfirmCodeDto>(lang, path, nameof(x.Code), ValidationTypesEnum.Required));
    //    }
    //}
}