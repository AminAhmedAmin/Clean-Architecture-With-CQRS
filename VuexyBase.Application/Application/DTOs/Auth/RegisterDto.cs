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
using Microsoft.AspNetCore.Http;
using VuexyBase.Application.Common.Helpers;
using Microsoft.Extensions.Localization;

namespace VuexyBase.Application.Application.DTOs.Auth
{

    public class RegisterDto
{
    [DisplayName("اسم المستخدم")] public string UserName { get; set; }

    [DisplayName("البريد الالكتروني")] public string Email { get; set; }

    [DisplayName("رقم الجوال")] public string Phone { get; set; }

    [DisplayName("الصورة")] public IFormFile? Image { get; set; }

    [DisplayName("المدينة")] public int CityId { get; set; }


    [DisplayName("الجهاز")] public DeviceDto Device { get; set; }
    //[DisplayName("المدن")] public HashSet<int> Cities { get; set; } = new HashSet<int>();


}

    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator(IStringLocalizer localizer)
        {
            var lang = BaseHelper.Lang;

            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage(x => FluentValidationHelper.Message<RegisterDto>(lang, nameof(x.UserName), ValidationTypesEnum.Required, localizer));

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(x => FluentValidationHelper.Message<RegisterDto>(lang, nameof(x.Email), ValidationTypesEnum.Required, localizer))
                .Matches(RegularExpressions.Email)
                .WithMessage(x => FluentValidationHelper.Message<RegisterDto>(lang, nameof(x.Email), ValidationTypesEnum.Email, localizer));

            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage(x => FluentValidationHelper.Message<LoginDto>(lang, nameof(x.Phone), ValidationTypesEnum.Required, localizer))
                .Matches(RegularExpressions.SaudiPhone)
                .WithMessage(x => FluentValidationHelper.Message<LoginDto>(lang, nameof(x.Phone), ValidationTypesEnum.SaudiPhone, localizer));

            RuleFor(x => x.Image)
                .NotNull()
                .WithMessage(x => FluentValidationHelper.Message<RegisterDto>(lang, nameof(x.Image), ValidationTypesEnum.Required, localizer));

            RuleFor(x => x.CityId)
                .NotNull()
                .WithMessage(x => FluentValidationHelper.Message<RegisterDto>(lang, nameof(x.CityId), ValidationTypesEnum.Required, localizer));

        }
    }

}