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
using Microsoft.Extensions.Localization;

namespace VuexyBase.Application.Application.DTOs.Auth

{
    public class LoginDto
    {

        [DisplayName("رقم الجوال")] public string Phone { get; set; }
    }

    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {

        public LoginDtoValidator(IStringLocalizer localizer)
        {
            var lang = BaseHelper.Lang;

            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage(x => FluentValidationHelper.Message<LoginDto>(lang, nameof(x.Phone), ValidationTypesEnum.Required, localizer))
                .Matches(RegularExpressions.SaudiPhone)
                .WithMessage(x => FluentValidationHelper.Message<LoginDto>(lang, nameof(x.Phone), ValidationTypesEnum.SaudiPhone, localizer));
        }
    }
}