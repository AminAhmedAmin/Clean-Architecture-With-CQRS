using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Application.Application.ViewModels.Profile;

namespace VuexyBase.Application.Application.Contracts.Application.Dashboard.Account
{
    public interface IAccountService
    {
        Task<UpdateProfileViewModel> AccountData();

        Task<bool> UpdateProfile(UpdateProfileViewModel model);

        Task<bool> ChangePassword(ChangePasswordViewModel model);

    }
}
