using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Application.Application.Contracts.Application.Dashboard.Auth;
using VuexyBase.Application.Application.ViewModels.Auth;
using VuexyBase.Application.Application.ViewModels.User;
using VuexyBase.Application.Common.Extensions;
using VuexyBase.Application.Common.Helpers;
using VuexyBase.Application.Common.Results;
using VuexyBase.Application.Persistence;
using VuexyBase.Domain.Constants;
using VuexyBase.Domain.Entities.General;
using VuexyBase.Domain.Entities.Identities;
using VuexyBase.Domain.Enums.Identities;


namespace VuexyBase.Application.Application.Services.Dashboard.Auth
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _db;
        private readonly SignInManager<ApplicationDbUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationDbUser> _userManager;

        public AuthService(ApplicationDbContext db, SignInManager<ApplicationDbUser> signInManager, UserManager<ApplicationDbUser> userManager ,IConfiguration configuration)
        {
            _db = db;
            _signInManager = signInManager;
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<Result<string>> Login(LoginViewModel model)
        {
            var user = _db.Users
                          .FirstOrDefault(x => x.Email == model.email);

            if (user == null)
                return Result<string>.Fail("BadRequest");

            if (user.UserType != UserType.Admin)
                return Result<string>.Fail("RoleError");


            var result = await _signInManager.PasswordSignInAsync(user.UserName, model.password, true, lockoutOnFailure: false);


            if (!result.Succeeded)
                return Result<string>.Fail("PasswordIsNotCorrect");

            //var token = await GetToken(user.Id, user.UserType, user.UserName);
            var userInfo = await GetUserInfo(user.Id, null);

            return Result<string>.Success(user.Id.ToString().Encrypt(), "LoggedInSuccessfully");
        }

        public async Task<UserViewModel> GetUserInfo(string userId, string token)
        {
            var userInfoDto = await _db.Users
                                       .Where(x => x.Id == userId)
                                       .Select(u => new UserViewModel()
                                       {
                                           id = u.Id,
                                           name = u.User_Name,
                                           email = u.Email,
                                           phone = u.PhoneNumber,
                                           image = AppRoutes.DashboardUrl + u.ProfileImage,
                                           role = u.UserType.ToString(),
                                           token = token,
                                       }).FirstOrDefaultAsync();

            return userInfoDto;
        }



        public async Task<Result<bool>> ForgetPassword(string email)
        {
            var user = await _db.Users
                                .FirstOrDefaultAsync(x => x.Email == email);
            if (user == null)
                return Result<bool>.Fail("UserNotFound");

            var otp = await GenerateCode();

            user.VerificationCode = otp.ToString();
            user.IsCodeVerified = true;

            var result = await _db.SaveChangesAsync() > 0;

            // Send Email Or SMS

            #region Send Email

            #endregion

            return Result<bool>.Success(result, "CodeSentSuccessfully");
        }


        public async Task<Result<bool>> ResetPassword(string email , string newPassword)
        {
            var user = await _db.Users
                                .FirstOrDefaultAsync(x => x.Email == email);
            if (user == null)
                return Result<bool>.Fail("UserNotFound");

            if (user.IsCodeVerified)
            {
                var result = await UpdatePassword(user, newPassword);

                if (result.IsSuccess)
                {
                    user.IsCodeVerified = false;
                    await _db.SaveChangesAsync();

                    return Result<bool>.Success(true, "PasswordChangedSuccessfully");

                }
            }
           
            return Result<bool>.Fail("ErrorInSendActiveCode");
        }


        public async Task<(bool IsSuccess, string messageKey)> UpdatePassword(ApplicationDbUser user, string newPassword)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

            if (!result.Succeeded)
                return (false, "ErrorChangingPassword");

            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return (true, "PasswordResetedSuccessfully");
        }

        public async Task<bool> Logout()
        {
            await _signInManager.SignOutAsync();

            return true;
        }


        public async Task<int> GenerateCode()
        {
            try
            {
                Setting GetInfoSms = await _db.Settings
                                              .FirstOrDefaultAsync();

                var code = 0;

                if (GetInfoSms != null)
                {
                    if (GetInfoSms.SenderName != "test")
                        code = NumberHelper.GenerateCode(4,false);
                }

                code = NumberHelper.GenerateCode(4, true);

                return code;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
