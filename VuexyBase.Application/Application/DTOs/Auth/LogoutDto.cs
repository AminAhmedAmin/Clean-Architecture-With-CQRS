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

    public class LogoutDto
    {
        public string DeviceId { get; set; }
    }

    //public class LogoutDtoValidator : AbstractValidator<LogoutDto>
    //{
    //    public LogoutDtoValidator( IPathService pathService)
    //    {
    //        var lang = BaseHelper.Lang; var path = pathService.ValidationLocalizationPath;

    //        RuleFor(x => x.DeviceId)
    //            .NotEmpty()
    //            .WithMessage(x => FluentValidationHelper.Message<LogoutDto>(lang, path, nameof(x.DeviceId), ValidationTypesEnum.Required));
    //    }
    //}
}