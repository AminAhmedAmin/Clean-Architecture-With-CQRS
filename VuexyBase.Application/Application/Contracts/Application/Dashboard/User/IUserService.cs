using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Dashboard.ViewModels.User;

namespace VuexyBase.Application.Application.Contracts.Application.Dashboard.User
{
    public interface IUserService
    {
        Task<UserIndexViewModel> UserIndex();
    }
}
