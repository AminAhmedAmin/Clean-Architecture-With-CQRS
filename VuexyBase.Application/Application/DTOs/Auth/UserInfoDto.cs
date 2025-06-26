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

    public class UserInfoDto
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
       // public UserType UserType { get; set; }
        public string? ProfilePicture { get; set; }
        public bool AllowNotify { get; set; }
        public string? Token { get; set; }

        public string City { get; set; }
        public int CityId { get; set; }

        public string Lat { get; set; }
        public string Lng { get; set; }
        public string Location { get; set; }

    }
}