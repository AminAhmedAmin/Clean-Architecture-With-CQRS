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
using VuexyBase.Domain.Enums.Devices;

namespace VuexyBase.Application.Application.DTOs.Auth
{

    public class DeviceDto
    {
        [DisplayName("معرف الجهاز")] public string DeviceId { get; set; }

        [DisplayName("نظام الجهاز")] public DeviceType DeviceType { get; set; }

        [DisplayName("اسم المشروع")] public string ProjectName { get; set; }
    }

    //public class DeviceDtoValidator : AbstractValidator<DeviceDto>
    //{
    //    public DeviceDtoValidator( IPathService pathService)
    //    {
    //        var lang = BaseHelper.Lang;
    //        var path = pathService.ValidationLocalizationPath;

    //        RuleFor(x => x.DeviceId)
    //            .NotEmpty()
    //            .WithMessage(x => FluentValidationHelper.Message<DeviceDto>(lang, path, nameof(x.DeviceId), ValidationTypesEnum.Required));

    //        RuleFor(x => x.DeviceType)
    //            .NotEmpty()
    //            .WithMessage(x => FluentValidationHelper.Message<DeviceDto>(lang, path, nameof(x.DeviceType), ValidationTypesEnum.Required));

    //        RuleFor(x => x.ProjectName)
    //            .NotEmpty()
    //            .WithMessage(x => FluentValidationHelper.Message<DeviceDto>(lang, path, nameof(x.ProjectName), ValidationTypesEnum.Required));
    //    }
    //}

}