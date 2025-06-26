using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Application.Application.ViewModels.Auth;
using VuexyBase.Application.Application.ViewModels.User;
using VuexyBase.Application.Common.Results;

namespace VuexyBase.Application.Application.Contracts.Application.Dashboard.Auth
{
    public interface IAuthService
    {
        Task<Result<string>> Login(LoginViewModel model);

        Task<Result<bool>> ForgetPassword(string email);

        Task<Result<bool>> ResetPassword(string email, string newPassword);
        Task<bool> Logout();

    }
}
