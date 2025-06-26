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

namespace VuexyBase.Application.Application.DTOs.Auth

{
    public class UpdateUserInfo
    {
        public string Email { get; set; }
        public string UserName { get; set; }

        public IFormFile Image { get; set; }

        public int CityId { get; set; }
    }
}
