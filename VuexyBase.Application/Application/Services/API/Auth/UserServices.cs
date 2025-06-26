using Autofac.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Application.Application.Common.Helpers;
using VuexyBase.Application.Application.Contracts.Application.API.Auth;
using VuexyBase.Application.Application.DTOs.Auth;
using VuexyBase.Application.Common.Helpers;
using VuexyBase.Application.Persistence;
using VuexyBase.Domain.Entities.General;
using VuexyBase.Domain.Entities.Identities;
using VuexyBase.Domain.Enums.Helper;
using VuexyBase.Domain.Enums.Identities;

namespace VuexyBase.Application.Application.Services.API.Auth
{
    public class UserServices : IUserServices
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationDbUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _HostingEnvironment;

    

        public UserServices(ApplicationDbContext context, UserManager<ApplicationDbUser> userManager,
           IConfiguration configuration, IHostingEnvironment IHostingEnvironment)
        {
            _context = context;
            _userManager = userManager;
           
            _configuration = configuration;
            this._HostingEnvironment = IHostingEnvironment;
        }

        public async Task<(bool IsSuccess, string messageKey)> ValidateUser(string email, string phone,
            HashSet<int>? citiesId)
        {
            /*if (citiesId.Count == 0)
                return (false, "ChooseAtLeastOneCity");*/
            if (!string.IsNullOrEmpty(email))
            {

                if (await IsExistEmail(email))
                    return (false, "ThisEmailIsAlreadyExists");
            }
            if (await IsExistPhone(phone))
                return (false, "ThisMobileAlreadyExists");
            //if (citiesId is { Count: > 0 })
            //{
            //    if (!await IsValidCities(citiesId))
            //        return (false, "OneOrMoreCityNotValid");
            //}

            return (true, string.Empty);
        }
        public async Task<(bool IsSuccess, string messageKey)> ValidateProivder(string phone, int categoryid)
        {
            /*if (citiesId.Count == 0)
                return (false, "ChooseAtLeastOneCity");*/

            if (await IsExistPhone(phone))
                return (false, "ThisMobileAlreadyExists");

            if (!await IsvalidCategory(categoryid))
                return (false, "NotvalidCategory");
            return (true, string.Empty);
        }

        public async Task<ApplicationDbUser?> AddUser(RegisterDto dto)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var user = new ApplicationDbUser
                {
                    User_Name = dto.UserName,
                    UserName = dto.Phone + "@yahoo.com",
                    Email = dto.Email is not null
                        ? dto.Email
                        : string.Empty,
                    VerificationCode = await GenerateCode(1234),
                    UserType = UserType.Client,
                    PhoneNumber = dto.Phone,
                    ProfileImage = dto.Image is not null
                        ? UploadHelper.Upload(dto.Image, (int)FileName.User, _HostingEnvironment)
                        : string.Empty,
                    SecurityStamp = Guid.NewGuid().ToString(),
                };
                var result = await _userManager.CreateAsync(user, "123456");

                if (result.Succeeded)
                {
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return user;
                }

                await transaction.RollbackAsync();
                return null;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return null;
            }
        }

        public async Task<bool> AddUserToRole(ApplicationDbUser user, string roleName)
        {
            var result = (await _userManager.AddToRoleAsync(user, roleName)).Succeeded;
            return result;
        }



        public async Task<bool> IsDeviceExist(string deviceId) => await _context.DeviceTokens
            .AnyAsync(x => x.Token == deviceId );

        public async Task<DeviceToken?> GetUserDevice(string deviceId)
        {
            return await _context.DeviceTokens.FirstOrDefaultAsync(x =>
                x.Token == deviceId );
        }


        public async Task<string> GenerateCode(int currentCode)
        {
            try
            {
                int code = NumberHelper.GetRandomNumber(currentCode); // return 12345a
                Setting GetInfoSms = await _context.Settings.FirstOrDefaultAsync();
                if (GetInfoSms != null)
                {
                    if (GetInfoSms.SenderName != "test")
                    {
                        code = NumberHelper.GetRandomNumber();
                    }
                }

                return code.ToString();
            }
            catch (Exception)
            {
                return "0";
            }
        }

        public async Task<bool> upddatecode(ApplicationDbUser user, string code)
        {
            user.VerificationCode = code;
            user.IsCodeVerified = false;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddDeviceId(DeviceDto dto, string userId)
        {
            try
            {
                DeviceToken deviceId = new()
                {
                    Token = dto.DeviceId,
                    DeviceType = dto.DeviceType,
                    UserId = userId,
                };
                await _context.DeviceTokens.AddAsync(deviceId);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<ApplicationDbUser?> GetUserByPhone(string phoneNumber)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
        }
        public async Task<ApplicationDbUser?> GetUserById(string UserId)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == UserId);
        }

        public async Task<bool> ValidatePassword(string passwordOne, string passwordTwo)
        {
            return passwordOne == passwordTwo;
        }


        public async Task<(bool IsSuccess, ApplicationDbUser? user, string messageKey)> IsValidUser(string phone)
        {
            var user = await GetUserByPhone(phone);
            if (user is null)
                return (false, null, "UserNotFound");
            if (!user.IsActive)
                return (false, null, "UserIsNotActive");
            return (true, user, string.Empty);
        }

        public async Task<string> SendSms(string code, string phone)
        {
            var getInfoSms = await _context.Settings.FirstOrDefaultAsync();
            if (getInfoSms != null)
            {
                if (getInfoSms.SenderName != "test")
                {
                    //string resultSms = await HelperSms.SendMessageBy4jawaly(code.ToString(), phone,
                    //    getInfoSms.SenderName, getInfoSms.SenderName, getInfoSms.SenderName);
                    //return resultSms;
                }
            }

            return "";
        }

        public async Task<(bool IsSuccess, string messageKey)> UpdatePassword(ApplicationDbUser user, string newPassword)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            if (!result.Succeeded)
                return (false, "ErrorChangingPassword");

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return (true, "PasswordResetedSuccessfully");
        }

        public async Task<UserInfoDto> GetUserInfo(string userId, string token, string lang)
        {
            //var userInfoDto = await _context.Users
            //    .Where(x => x.Id == userId && x.UserType == UserType.Client)
            //    .AsQueryable()
            //    .AsNoTracking()
            //    .ProjectTo<UserInfoDto>(MappingProfiles.UserInfo(token, lang))
            //    .AsNoTracking()
            //    .FirstOrDefaultAsync();
            return new  UserInfoDto();
        }


        public async Task<string> GetToken(string userId, UserType userType, string userName, bool autoGenerate = true)
        {
            try
            {
                //      var token = HelperGeneral.GetToken(_configuration, userId, userType.ToString(), userName);
              //  return autoGenerate ? new JwtSecurityTokenHandler().WriteToken(token) : "";
                var token = "";
                return token;
            }
            catch (Exception)
            {
                throw;
            }
        }


        

        //public async Task<bool> UpdateDataUser(UpdateUserInfo userModel, string userId)
        //{

        //    try
        //    {


        //        var user = _context.Users.Where(x => x.Id == userId).FirstOrDefault();

        //        user.FullName = userModel.UserName ?? user.PhoneNumber;
        //        user.Email = userModel.Email;

        //        if (userModel.Image != null)
        //        {
        //            user.ProfilePicture = _helper.Upload(userModel.Image, (int)FileName.Users);
        //        }

        //        user.CityId = userModel.CityId;
        //        _context.Users.Update(user);


        //        await _context.SaveChangesAsync();






        //        await _context.SaveChangesAsync();

        //        return true;
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }

        //}



        #region Private Methods
        private async Task<bool> IsExistEmail(string email, string? userId = null) =>
            await _userManager.Users.AnyAsync(x => x.Email == email && (userId == null || x.Id != userId));

        private async Task<bool> IsExistPhone(string phone, string? userId = null) =>
            await _userManager.Users.AnyAsync(x => x.PhoneNumber == phone && (userId == null || x.Id != userId));

        //private async Task<bool> IsValidCities(HashSet<int>? citiesId)
        //{
        //    foreach (var cityId in citiesId)
        //    {
        //        var city = await _context.Cities.FindAsync(cityId);
        //        if (city is null)
        //            return false;
        //    }
        //    return true;
        //}

        private async Task<bool> IsvalidCategory(int categoryid)
        {

            var city = await _context.Categories.FindAsync(categoryid);
            if (city is null)
                return false;

            return true;
        }

        //private async Task<bool> AddNotification(NotifyModel model)
        //{
        //    await _context.Notifications.AddAsync(new BitaGift.Domain.Entities.UserTables.Notification
        //    {
        //        TextAr = model.TextAr,
        //        TextEn = model.TextEn,
        //        Type = model.Type,
        //        UserId = model.UserId,
        //        ItemId = model.ItemId
        //    });

        //    return await _context.SaveChangesAsync() > 0;
        //}
        #endregion
    }
}
