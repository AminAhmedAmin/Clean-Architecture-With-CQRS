using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Application.Application.DTOs.Auth;
using VuexyBase.Application.Common.Results;

namespace VuexyBase.Application.Application.Contracts.Application.API.Auth
{
    public interface IAccountService
    {
        Task<Result<bool>> Register(RegisterDto dto);
        Task<Result<bool>> ResendCode(ResendCodeDto dto);

        Task<Result<UserInfoDto>> ConfirmCode(ConfirmCodeDto confirmCodeDto, string lang);
        Task<Result<bool>> Login(LoginDto dto);


        Task<Result<bool>> ChangePassword(ChangePasswordDto input);

        Task<Result<bool>> ResetPassword(ResetPasswordDto resetPasswordDto);

       
        Task<Result<bool>> Logout(LogoutDto userModel, string UserId);
        Task<Result<bool>> RemoveAccount(string UserId);
   //     Task<Result<UserInfoDto>> UpdateUserInfo(UpdateUserInfo UpdateUserInfo, string userId, string lang);
      //  Task<Result<UserInfoDto>> GetUserData(string userId, string lang);
       
    }
}
