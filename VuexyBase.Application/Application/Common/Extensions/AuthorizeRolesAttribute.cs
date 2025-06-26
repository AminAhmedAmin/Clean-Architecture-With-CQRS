using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Domain.Enums.Identities;

namespace VuexyBase.Application.Application.Common.Extensions
{
    public class AuthorizeRolesAttribute : Microsoft.AspNetCore.Authorization.AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params Roles[] roles) : base()
        {
            Roles = string.Join(",", roles);
        }
    }
}
