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
    public class ChangePasswordDto
    {
        [DisplayName("رقم الجوال")] public string Phone { get; set; }
        [DisplayName("كلمة المرور القديمة")] public string OldPassword { get; set; }
        [DisplayName("كلمة المرور الجديدة")] public string NewPassword { get; set; }
    }

    //public class ChangePasswordDtoValidator : AbstractValidator<ChangePasswordDto>
    //{
    //    public ChangePasswordDtoValidator( IPathService pathService)
    //    {
    //        var lang = BaseHelper.Lang;
          

    //        RuleFor(x => x.Phone)
    //            .NotEmpty()
    //            .WithMessage(x => FluentValidationHelper.Message<ChangePasswordDto>(lang, path, nameof(x.Phone), ValidationTypesEnum.Required))
    //            .Matches(RegularExpressions.SaudiPhone)
    //            .WithMessage(x => FluentValidationHelper.Message<ChangePasswordDto>(lang, path, nameof(x.Phone), ValidationTypesEnum.SaudiPhone));

    //        RuleFor(x => x.OldPassword)
    //            .NotEmpty()
    //            .WithMessage(x => FluentValidationHelper.Message<ChangePasswordDto>(lang, path, nameof(x.OldPassword), ValidationTypesEnum.Required))
    //            .MinimumLength(6)
    //            .WithMessage(x => FluentValidationHelper.Message<ChangePasswordDto>(lang, path, nameof(x.OldPassword), ValidationTypesEnum.MinLength, 6));

    //        RuleFor(x => x.NewPassword)
    //            .NotEmpty()
    //            .WithMessage(x => FluentValidationHelper.Message<ChangePasswordDto>(lang, path, nameof(x.NewPassword), ValidationTypesEnum.Required))
    //            .MinimumLength(6)
    //            .WithMessage(x => FluentValidationHelper.Message<ChangePasswordDto>(lang, path, nameof(x.NewPassword), ValidationTypesEnum.MinLength, 6));
    //    }
    //}
}