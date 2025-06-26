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

namespace VuexyBase.Application.Application.DTOs.Auth

{
    public class ResetPasswordDto
    {
        [DisplayName("رقم الجوال")] public string Phone { get; set; }
        [DisplayName("كلمة المرور الجديدة")] public string NewPassword { get; set; }
    }

    //public class ResetPasswordDtoDtoValidator : AbstractValidator<ResetPasswordDto>
    //{
    //    public ResetPasswordDtoDtoValidator(UserContext userContext)
    //    {
    //        var lang = userContext.APILang;
    //        RuleFor(x => x.Phone)
    //            .NotEmpty()
    //            .WithMessage(x => FluentValidationHelper.Message<ResetPasswordDto>(lang,
    //                DefaultPath.ValidationLocalizationPath, nameof(x.Phone), ValidationTypesEnum.Required))
    //            .Matches(RegEx.SaudiPhone)
    //            .WithMessage(x => FluentValidationHelper.Message<ResetPasswordDto>(lang,
    //                DefaultPath.ValidationLocalizationPath, nameof(x.Phone), ValidationTypesEnum.SaudiPhone));

    //        RuleFor(x => x.NewPassword)
    //            .NotEmpty()
    //            .WithMessage(x => FluentValidationHelper.Message<ResetPasswordDto>(lang,
    //                DefaultPath.ValidationLocalizationPath, nameof(x.NewPassword), ValidationTypesEnum.Required))
    //            .MinimumLength(6)
    //            .WithMessage(x => FluentValidationHelper.Message<ResetPasswordDto>(lang,
    //                DefaultPath.ValidationLocalizationPath, nameof(x.NewPassword), ValidationTypesEnum.MinLength, 6));

    //    }
    //}
}