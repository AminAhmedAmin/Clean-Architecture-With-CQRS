using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Application.Application.DTOs.Auth;
using VuexyBase.Domain.Entities.General;
using VuexyBase.Domain.Entities.Identities;
using VuexyBase.Domain.Enums.Identities;

namespace VuexyBase.Application.Application.Contracts.Application.API.Auth
{
    public interface IUserServices
    {
        Task<(bool IsSuccess, string messageKey)> ValidateUser(string email, string phone,
                    HashSet<int>? citiesId = null);
        Task<(bool IsSuccess, string messageKey)> ValidateProivder(string phone, int categoryid);
        Task<string> GenerateCode(int currentCode);
        Task<ApplicationDbUser?> AddUser(RegisterDto dto);
        Task<bool> AddUserToRole(ApplicationDbUser user, string roleName);
        Task<bool> IsDeviceExist(string deviceId);
        Task<DeviceToken?> GetUserDevice(string deviceId);
        Task<bool> AddDeviceId(DeviceDto dto, string userId);

        Task<(bool IsSuccess, ApplicationDbUser? user, string messageKey)> IsValidUser(string phone);
        Task<bool> ValidatePassword(string passwordOne, string passwordTwo);
        Task<ApplicationDbUser?> GetUserByPhone(string phoneNumber);
        Task<string> SendSms(string code, string phone);
        Task<(bool IsSuccess, string messageKey)> UpdatePassword(ApplicationDbUser user, string newPassword);
        Task<UserInfoDto> GetUserInfo(string userId, string token, string lang);
        Task<string> GetToken(string userId, UserType userType, string userName, bool autoGenerate = true);
       
    //    Task<bool> UpdateDataUser(UpdateUserInfo userModel, string userId);
        Task<bool> upddatecode(ApplicationDbUser user, string code);
        Task<ApplicationDbUser?> GetUserById(string UserId);
    }
}
