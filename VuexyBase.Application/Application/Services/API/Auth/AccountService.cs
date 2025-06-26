using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VuexyBase.Application.Application.Contracts.Application.API.Auth;
using VuexyBase.Application.Application.DTOs.Auth;
using VuexyBase.Application.Common.Results;
using VuexyBase.Application.Persistence;
using VuexyBase.Domain.Entities.Identities;
using VuexyBase.Domain.Enums.Identities;

namespace VuexyBase.Application.Application.Services.API.Auth
{
    internal class AccountService :IAccountService
    {

        private readonly IUserServices _userService;
        private readonly ApplicationDbContext _context;
 
        public AccountService(IUserServices userService, ApplicationDbContext context)        {
            _userService = userService;
            _context = context;
          
        }


        public async Task<Result<bool>> Register(RegisterDto dto)
        {
            var userResult = await _userService.ValidateUser(dto.Email, dto.Phone);
            if (!userResult.IsSuccess)
                return Result<bool>.Fail(userResult.messageKey);

            var user = await _userService.AddUser(dto);
            if (user is not null)
            {
                var isAddedRole = await _userService.AddUserToRole(user, Roles.MobileUser.ToString());
                if (!isAddedRole)
                    return Result<bool>.Fail("UserRoleAssigningError");
                var isAddedDevice = await _userService.AddDeviceId(dto.Device, user.Id);
                if (!isAddedDevice)
                    return Result<bool>.Fail("DeviceAddingError");
                _ = await _userService.SendSms(user.VerificationCode, user.PhoneNumber);

              
                return Result<bool>.Success(true, "UserCreatedSuccessfully");
            }

            return Result<bool>.Fail("UserCreationError");
        }

        public async Task<Result<UserInfoDto>> ConfirmCode(ConfirmCodeDto dto, string lang)
        {
            var userResult = await _userService.IsValidUser(dto.PhoneNumber);

            if (!userResult.IsSuccess)
                return Result<UserInfoDto>.Fail(userResult.messageKey);

            if (userResult.user!.VerificationCode != dto.Code)
                return Result<UserInfoDto>.Fail("OTPIsInValid");



            userResult.user.IsCodeVerified = true;
            _context.Users.Update(userResult.user);
            await _context.SaveChangesAsync();


            if (!await _userService.IsDeviceExist(dto.Device.DeviceId))
            {
                var isDeviceAdded = await _userService.AddDeviceId(dto.Device, userResult.user.Id);
                if (!isDeviceAdded)
                    return Result<UserInfoDto>.Fail("DeviceAddingError");
            }

            var token = await _userService.GetToken(userResult.user.Id, UserType.Client, userResult.user.UserName);
            var userInfoResult = await _userService.GetUserInfo(userResult.user.Id, token, lang);
            return Result<UserInfoDto>.Success(userInfoResult, "OTPIsValid");
        }


        public async Task<Result<bool>> ResendCode(ResendCodeDto dto)
        {
            var userResult = await _userService.IsValidUser(dto.PhoneNumber);
            if (!userResult.IsSuccess)
                return Result<bool>.Fail(userResult.messageKey);
            var otp = await _userService.GenerateCode(1234);
            userResult.user.VerificationCode = otp;
            userResult.user.IsCodeVerified = false;
            _context.Users.Update(userResult.user);
            var result = await _context.SaveChangesAsync() > 0;
            await _userService.SendSms(otp, dto.PhoneNumber);
            return Result<bool>.Success(result, "CodeSentSuccessfully");
        }


        public async Task<Result<bool>> Login(LoginDto dto)
        {
            var userResult = await _userService.IsValidUser(dto.Phone);
            if (!userResult.IsSuccess)
                return Result<bool>.Fail(userResult.messageKey);

            return Result<bool>.Success(true, "CodeSentSuccessfully");
        }

        public async Task<Result<bool>> ResetPassword(ResetPasswordDto dto)
        {
            var userResult = await _userService.IsValidUser(dto.Phone);
            if (!userResult.IsSuccess)
                return Result<bool>.Fail(userResult.messageKey);
            var result = await _userService.UpdatePassword(userResult.user, dto.NewPassword);

            return result.IsSuccess
                ? Result<bool>.Success(true, result.messageKey)
                : Result<bool>.Fail(result.messageKey);
        }

        public async Task<Result<bool>> ChangePassword(ChangePasswordDto dto)
        {
            var userResult = await _userService.IsValidUser(dto.Phone);
            if (!userResult.IsSuccess)
                return Result<bool>.Fail(userResult.messageKey);
            if (!userResult.user.IsCodeVerified)
                return Result<bool>.Fail("ActivationCodeIsNotValidOrExpired");
            //if (!await _userService.ValidatePassword(dto.OldPassword, userResult.user.ShowPassword))
            //    return Result<bool>.Fail("PasswordIsNotCorrect");

            var result = await _userService.UpdatePassword(userResult.user, dto.NewPassword);
            return result.IsSuccess
                ? Result<bool>.Success(true, result.messageKey)
                : Result<bool>.Fail(result.messageKey);
        }

        public async Task<Result<bool>> Logout(LogoutDto dto, string UserId)
        {
            var user = await _context.Users.FindAsync(UserId);
            if (user is null)
                return Result<bool>.Fail("UserNotFound");
            var device = await _userService.GetUserDevice(dto.DeviceId);
            if (device is not null)
            {
                user.IsCodeVerified = false;
                _context.DeviceTokens.Remove(device);
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }

            return Result<bool>.Success(true, "LoggedOutSuccessfully");
        }

        public async Task<Result<bool>> RemoveAccount(string UserId)
        {
            var user = await _context.Users.FindAsync(UserId);
            if (user is null)
                return Result<bool>.Fail("UserNotFound");
            user.IsDeleted = true;
            user.PhoneNumber += Guid.NewGuid().ToString();
            user.Email += Guid.NewGuid().ToString();
            user.NormalizedEmail += Guid.NewGuid().ToString();
            user.UserName += Guid.NewGuid().ToString();
            user.NormalizedUserName += Guid.NewGuid().ToString();
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return Result<bool>.Success(true, "AccountWasRemovedSuccessfully");
        }


        public async Task<Result<UserInfoDto>> GetUserData(string userId, string lang)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user is null)
                return Result<UserInfoDto>.Fail("UserNotFound");

            var userInfoResult = await _userService.GetUserInfo(userId, "", lang);
            return Result<UserInfoDto>.Success(userInfoResult, "Success");
        }





        //public async Task<Result<UserInfoDto>> UpdateUserInfo(UpdateUserInfo UpdateUserInfo, string userId, string lang)
        //{
        //    var user = await _context.Users.FindAsync(userId);
        //    if (user is null)
        //        return Result<UserInfoDto>.Fail("UserNotFound");

        //    var isUpdated = await _userService.UpdateDataUser(UpdateUserInfo, userId);
        //    if (isUpdated)
        //    {
        //        var userInfoResult = await _userService.GetUserInfo(userId, "", lang);
        //        return Result<UserInfoDto>.Success(userInfoResult, "ItemUpdatedSuccessfully");
        //    }
        //    else
        //    {
        //        return Result<UserInfoDto>.Fail("Error");

        //    }

        //}

      


     
    }
}
